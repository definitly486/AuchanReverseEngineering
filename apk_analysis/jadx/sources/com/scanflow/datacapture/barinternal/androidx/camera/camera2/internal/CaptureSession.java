package com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal;

import android.hardware.camera2.CameraAccessException;
import android.hardware.camera2.CameraCaptureSession;
import android.hardware.camera2.CameraDevice;
import android.hardware.camera2.CaptureRequest;
import android.hardware.camera2.TotalCaptureResult;
import android.hardware.camera2.params.DynamicRangeProfiles;
import android.os.Build;
import android.view.Surface;
import androidx.camera.camera2.internal.compat.quirk.CaptureNoResponseQuirk;
import androidx.camera.core.DynamicRange;
import androidx.camera.core.Logger;
import androidx.camera.core.impl.CameraCaptureCallback;
import androidx.camera.core.impl.CaptureConfig;
import androidx.camera.core.impl.DeferrableSurface;
import androidx.camera.core.impl.Quirks;
import androidx.camera.core.impl.SessionConfig;
import androidx.camera.core.impl.utils.executor.CameraXExecutors;
import androidx.camera.core.impl.utils.futures.AsyncFunction;
import androidx.camera.core.impl.utils.futures.FutureCallback;
import androidx.camera.core.impl.utils.futures.FutureChain;
import androidx.camera.core.impl.utils.futures.Futures;
import androidx.concurrent.futures.CallbackToFutureAdapter;
import androidx.lifecycle.CoroutineLiveDataKt;
import com.google.common.util.concurrent.ListenableFuture;
import com.scanflow.datacapture.barinternal.androidx.camera.camera2.impl.Camera2ImplConfig;
import com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params.DynamicRangeConversions;
import com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params.DynamicRangesCompat;
import com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params.InputConfigurationCompat;
import com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params.OutputConfigurationCompat;
import com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params.SessionConfigurationCompat;
import com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.workaround.RequestMonitor;
import com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.workaround.StillCaptureFlow;
import com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.workaround.TemplateParamsOverride;
import com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.workaround.TorchStateReset;
import com.scanflow.datacapture.barinternal.androidx.core.util.Preconditions;
import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.concurrent.CancellationException;

/* JADX INFO: loaded from: classes.dex */
final class CaptureSession implements CaptureSessionInterface {
    private final List mCaptureConfigs;
    private final StateCallback mCaptureSessionStateCallback;
    List mConfiguredDeferrableSurfaces;
    private final Map mConfiguredSurfaceMap;
    private final DynamicRangesCompat mDynamicRangesCompat;
    CallbackToFutureAdapter.Completer mReleaseCompleter;
    ListenableFuture mReleaseFuture;
    private final RequestMonitor mRequestMonitor;
    SessionConfig mSessionConfig;
    final Object mSessionLock;
    SynchronizedCaptureSession.Opener mSessionOpener;
    State mState;
    private final StillCaptureFlow mStillCaptureFlow;
    private Map mStreamUseCaseMap;
    SynchronizedCaptureSession mSynchronizedCaptureSession;
    private final TemplateParamsOverride mTemplateParamsOverride;
    private final TorchStateReset mTorchStateReset;

    enum State {
        UNINITIALIZED,
        INITIALIZED,
        GET_SURFACE,
        OPENING,
        OPENED,
        CLOSED,
        RELEASING,
        RELEASED
    }

    CaptureSession(DynamicRangesCompat dynamicRangesCompat) {
        this(dynamicRangesCompat, new Quirks(Collections.EMPTY_LIST));
    }

    CaptureSession(DynamicRangesCompat dynamicRangesCompat, Quirks quirks) {
        this.mSessionLock = new Object();
        this.mCaptureConfigs = new ArrayList();
        this.mConfiguredSurfaceMap = new HashMap();
        this.mConfiguredDeferrableSurfaces = Collections.EMPTY_LIST;
        this.mState = State.UNINITIALIZED;
        this.mStreamUseCaseMap = new HashMap();
        this.mStillCaptureFlow = new StillCaptureFlow();
        this.mTorchStateReset = new TorchStateReset();
        this.mState = State.INITIALIZED;
        this.mDynamicRangesCompat = dynamicRangesCompat;
        this.mCaptureSessionStateCallback = new StateCallback();
        this.mRequestMonitor = new RequestMonitor(quirks.contains(CaptureNoResponseQuirk.class));
        this.mTemplateParamsOverride = new TemplateParamsOverride(quirks);
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.CaptureSessionInterface
    public void setStreamUseCaseMap(Map map) {
        synchronized (this.mSessionLock) {
            this.mStreamUseCaseMap = map;
        }
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.CaptureSessionInterface
    public SessionConfig getSessionConfig() {
        SessionConfig sessionConfig;
        synchronized (this.mSessionLock) {
            sessionConfig = this.mSessionConfig;
        }
        return sessionConfig;
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.CaptureSessionInterface
    public void setSessionConfig(SessionConfig sessionConfig) {
        synchronized (this.mSessionLock) {
            try {
                switch (this.mState) {
                    case UNINITIALIZED:
                        throw new IllegalStateException("setSessionConfig() should not be possible in state: " + this.mState);
                    case INITIALIZED:
                    case GET_SURFACE:
                    case OPENING:
                        this.mSessionConfig = sessionConfig;
                        break;
                    case OPENED:
                        this.mSessionConfig = sessionConfig;
                        if (sessionConfig == null) {
                            return;
                        }
                        if (!this.mConfiguredSurfaceMap.keySet().containsAll(sessionConfig.getSurfaces())) {
                            Logger.e("CaptureSession", "Does not have the proper configured lists");
                            return;
                        } else {
                            Logger.d("CaptureSession", "Attempting to submit CaptureRequest after setting");
                            issueRepeatingCaptureRequests(this.mSessionConfig);
                        }
                        break;
                    case CLOSED:
                    case RELEASING:
                    case RELEASED:
                        throw new IllegalStateException("Session configuration cannot be set on a closed/released session.");
                }
            } catch (Throwable th) {
                throw th;
            }
        }
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.CaptureSessionInterface
    public ListenableFuture open(final SessionConfig sessionConfig, final CameraDevice cameraDevice, SynchronizedCaptureSession.Opener opener) {
        synchronized (this.mSessionLock) {
            try {
                if (this.mState.ordinal() == 1) {
                    this.mState = State.GET_SURFACE;
                    ArrayList arrayList = new ArrayList(sessionConfig.getSurfaces());
                    this.mConfiguredDeferrableSurfaces = arrayList;
                    this.mSessionOpener = opener;
                    FutureChain futureChainTransformAsync = FutureChain.from(opener.startWithDeferrableSurface(arrayList, CoroutineLiveDataKt.DEFAULT_TIMEOUT)).transformAsync(new AsyncFunction() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.CaptureSession$$ExternalSyntheticLambda1
                        @Override // androidx.camera.core.impl.utils.futures.AsyncFunction
                        public final ListenableFuture apply(Object obj) {
                            return this.f$0.openCaptureSession((List) obj, sessionConfig, cameraDevice);
                        }
                    }, this.mSessionOpener.getExecutor());
                    Futures.addCallback(futureChainTransformAsync, new FutureCallback() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.CaptureSession.1
                        @Override // androidx.camera.core.impl.utils.futures.FutureCallback
                        public void onSuccess(Void r1) {
                        }

                        @Override // androidx.camera.core.impl.utils.futures.FutureCallback
                        public void onFailure(Throwable th) {
                            synchronized (CaptureSession.this.mSessionLock) {
                                try {
                                    CaptureSession.this.mSessionOpener.stop();
                                    int iOrdinal = CaptureSession.this.mState.ordinal();
                                    if ((iOrdinal == 3 || iOrdinal == 5 || iOrdinal == 6) && !(th instanceof CancellationException)) {
                                        Logger.w("CaptureSession", "Opening session with fail " + CaptureSession.this.mState, th);
                                        CaptureSession.this.finishClose();
                                    }
                                } catch (Throwable th2) {
                                    throw th2;
                                }
                            }
                        }
                    }, this.mSessionOpener.getExecutor());
                    return Futures.nonCancellationPropagating(futureChainTransformAsync);
                }
                Logger.e("CaptureSession", "Open not allowed in state: " + this.mState);
                return Futures.immediateFailedFuture(new IllegalStateException("open() should not allow the state: " + this.mState));
            } catch (Throwable th) {
                throw th;
            }
        }
    }

    /* JADX INFO: Access modifiers changed from: private */
    public ListenableFuture openCaptureSession(List list, SessionConfig sessionConfig, CameraDevice cameraDevice) {
        synchronized (this.mSessionLock) {
            try {
                int iOrdinal = this.mState.ordinal();
                if (iOrdinal != 0 && iOrdinal != 1) {
                    if (iOrdinal == 2) {
                        this.mConfiguredSurfaceMap.clear();
                        for (int i = 0; i < list.size(); i++) {
                            this.mConfiguredSurfaceMap.put((DeferrableSurface) this.mConfiguredDeferrableSurfaces.get(i), (Surface) list.get(i));
                        }
                        this.mState = State.OPENING;
                        Logger.d("CaptureSession", "Opening capture session.");
                        SynchronizedCaptureSession.StateCallback stateCallbackCreateComboCallback = SynchronizedCaptureSessionStateCallbacks.createComboCallback(this.mCaptureSessionStateCallback, new SynchronizedCaptureSessionStateCallbacks.Adapter(sessionConfig.getSessionStateCallbacks()));
                        Camera2ImplConfig camera2ImplConfig = new Camera2ImplConfig(sessionConfig.getImplementationOptions());
                        CaptureConfig.Builder builderFrom = CaptureConfig.Builder.from(sessionConfig.getRepeatingCaptureConfig());
                        ArrayList arrayList = new ArrayList();
                        String physicalCameraId = camera2ImplConfig.getPhysicalCameraId(null);
                        for (SessionConfig.OutputConfig outputConfig : sessionConfig.getOutputConfigs()) {
                            OutputConfigurationCompat outputConfigurationCompat = getOutputConfigurationCompat(outputConfig, this.mConfiguredSurfaceMap, physicalCameraId);
                            if (this.mStreamUseCaseMap.containsKey(outputConfig.getSurface())) {
                                outputConfigurationCompat.setStreamUseCase(((Long) this.mStreamUseCaseMap.get(outputConfig.getSurface())).longValue());
                            }
                            arrayList.add(outputConfigurationCompat);
                        }
                        SessionConfigurationCompat sessionConfigurationCompatCreateSessionConfigurationCompat = this.mSessionOpener.createSessionConfigurationCompat(sessionConfig.getSessionType(), getUniqueOutputConfigurations(arrayList), stateCallbackCreateComboCallback);
                        if (sessionConfig.getTemplateType() == 5 && sessionConfig.getInputConfiguration() != null) {
                            sessionConfigurationCompatCreateSessionConfigurationCompat.setInputConfiguration(InputConfigurationCompat.wrap(sessionConfig.getInputConfiguration()));
                        }
                        try {
                            CaptureRequest captureRequestBuildWithoutTarget = Camera2CaptureRequestBuilder.buildWithoutTarget(builderFrom.build(), cameraDevice, this.mTemplateParamsOverride);
                            if (captureRequestBuildWithoutTarget != null) {
                                sessionConfigurationCompatCreateSessionConfigurationCompat.setSessionParameters(captureRequestBuildWithoutTarget);
                            }
                            return this.mSessionOpener.openCaptureSession(cameraDevice, sessionConfigurationCompatCreateSessionConfigurationCompat, this.mConfiguredDeferrableSurfaces);
                        } catch (CameraAccessException e) {
                            return Futures.immediateFailedFuture(e);
                        }
                    }
                    if (iOrdinal != 4) {
                        return Futures.immediateFailedFuture(new CancellationException("openCaptureSession() not execute in state: " + this.mState));
                    }
                }
                return Futures.immediateFailedFuture(new IllegalStateException("openCaptureSession() should not be possible in state: " + this.mState));
            } catch (Throwable th) {
                throw th;
            }
        }
    }

    private List getUniqueOutputConfigurations(List list) {
        ArrayList arrayList = new ArrayList();
        ArrayList arrayList2 = new ArrayList();
        Iterator it = list.iterator();
        while (it.hasNext()) {
            OutputConfigurationCompat outputConfigurationCompat = (OutputConfigurationCompat) it.next();
            if (!arrayList.contains(outputConfigurationCompat.getSurface())) {
                arrayList.add(outputConfigurationCompat.getSurface());
                arrayList2.add(outputConfigurationCompat);
            }
        }
        return arrayList2;
    }

    private OutputConfigurationCompat getOutputConfigurationCompat(SessionConfig.OutputConfig outputConfig, Map map, String str) {
        long jLongValue;
        DynamicRangeProfiles dynamicRangeProfiles;
        Surface surface = (Surface) map.get(outputConfig.getSurface());
        Preconditions.checkNotNull(surface, "Surface in OutputConfig not found in configuredSurfaceMap.");
        OutputConfigurationCompat outputConfigurationCompat = new OutputConfigurationCompat(outputConfig.getSurfaceGroupId(), surface);
        if (str != null) {
            outputConfigurationCompat.setPhysicalCameraId(str);
        } else {
            outputConfigurationCompat.setPhysicalCameraId(outputConfig.getPhysicalCameraId());
        }
        if (outputConfig.getMirrorMode() == 0) {
            outputConfigurationCompat.setMirrorMode(1);
        } else if (outputConfig.getMirrorMode() == 1) {
            outputConfigurationCompat.setMirrorMode(2);
        }
        if (!outputConfig.getSharedSurfaces().isEmpty()) {
            outputConfigurationCompat.enableSurfaceSharing();
            Iterator<DeferrableSurface> it = outputConfig.getSharedSurfaces().iterator();
            while (it.hasNext()) {
                Surface surface2 = (Surface) map.get(it.next());
                Preconditions.checkNotNull(surface2, "Surface in OutputConfig not found in configuredSurfaceMap.");
                outputConfigurationCompat.addSurface(surface2);
            }
        }
        if (Build.VERSION.SDK_INT < 33 || (dynamicRangeProfiles = this.mDynamicRangesCompat.toDynamicRangeProfiles()) == null) {
            jLongValue = 1;
        } else {
            DynamicRange dynamicRange = outputConfig.getDynamicRange();
            Long lDynamicRangeToFirstSupportedProfile = DynamicRangeConversions.dynamicRangeToFirstSupportedProfile(dynamicRange, dynamicRangeProfiles);
            if (lDynamicRangeToFirstSupportedProfile == null) {
                Logger.e("CaptureSession", "Requested dynamic range is not supported. Defaulting to STANDARD dynamic range profile.\nRequested dynamic range:\n  " + dynamicRange);
                jLongValue = 1;
            } else {
                jLongValue = lDynamicRangeToFirstSupportedProfile.longValue();
            }
        }
        outputConfigurationCompat.setDynamicRangeProfile(jLongValue);
        return outputConfigurationCompat;
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.CaptureSessionInterface
    public void close() {
        synchronized (this.mSessionLock) {
            try {
                int iOrdinal = this.mState.ordinal();
                if (iOrdinal == 0) {
                    throw new IllegalStateException("close() should not be possible in state: " + this.mState);
                }
                if (iOrdinal == 1) {
                    this.mState = State.RELEASED;
                } else if (iOrdinal == 2) {
                    Preconditions.checkNotNull(this.mSessionOpener, "The Opener shouldn't null in state:" + this.mState);
                    this.mSessionOpener.stop();
                    this.mState = State.RELEASED;
                } else if (iOrdinal == 3 || iOrdinal == 4) {
                    Preconditions.checkNotNull(this.mSessionOpener, "The Opener shouldn't null in state:" + this.mState);
                    this.mSessionOpener.stop();
                    this.mState = State.CLOSED;
                    this.mRequestMonitor.stop();
                    this.mSessionConfig = null;
                }
            } catch (Throwable th) {
                throw th;
            }
        }
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.CaptureSessionInterface
    public ListenableFuture release(boolean z) {
        synchronized (this.mSessionLock) {
            switch (this.mState) {
                case UNINITIALIZED:
                    throw new IllegalStateException("release() should not be possible in state: " + this.mState);
                case GET_SURFACE:
                    Preconditions.checkNotNull(this.mSessionOpener, "The Opener shouldn't null in state:" + this.mState);
                    this.mSessionOpener.stop();
                case INITIALIZED:
                    this.mState = State.RELEASED;
                    return Futures.immediateFuture(null);
                case OPENED:
                case CLOSED:
                    SynchronizedCaptureSession synchronizedCaptureSession = this.mSynchronizedCaptureSession;
                    if (synchronizedCaptureSession != null) {
                        if (z) {
                            try {
                                synchronizedCaptureSession.abortCaptures();
                            } catch (CameraAccessException e) {
                                Logger.e("CaptureSession", "Unable to abort captures.", e);
                            }
                        }
                        this.mSynchronizedCaptureSession.close();
                        break;
                    }
                case OPENING:
                    this.mState = State.RELEASING;
                    this.mRequestMonitor.stop();
                    Preconditions.checkNotNull(this.mSessionOpener, "The Opener shouldn't null in state:" + this.mState);
                    if (this.mSessionOpener.stop()) {
                        finishClose();
                        return Futures.immediateFuture(null);
                    }
                case RELEASING:
                    if (this.mReleaseFuture == null) {
                        this.mReleaseFuture = CallbackToFutureAdapter.getFuture(new CallbackToFutureAdapter.Resolver() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.CaptureSession$$ExternalSyntheticLambda0
                            @Override // androidx.concurrent.futures.CallbackToFutureAdapter.Resolver
                            public final Object attachCompleter(CallbackToFutureAdapter.Completer completer) {
                                return CaptureSession.$r8$lambda$IZn2iVWeWbQg4rbAIYzCbmSJlKA(this.f$0, completer);
                            }
                        });
                    }
                    return this.mReleaseFuture;
                default:
                    return Futures.immediateFuture(null);
            }
        }
    }

    public static /* synthetic */ Object $r8$lambda$IZn2iVWeWbQg4rbAIYzCbmSJlKA(CaptureSession captureSession, CallbackToFutureAdapter.Completer completer) {
        String str;
        synchronized (captureSession.mSessionLock) {
            Preconditions.checkState(captureSession.mReleaseCompleter == null, "Release completer expected to be null");
            captureSession.mReleaseCompleter = completer;
            str = "Release[session=" + captureSession + "]";
        }
        return str;
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.CaptureSessionInterface
    public void issueCaptureRequests(List list) {
        synchronized (this.mSessionLock) {
            try {
                switch (this.mState) {
                    case UNINITIALIZED:
                        throw new IllegalStateException("issueCaptureRequests() should not be possible in state: " + this.mState);
                    case INITIALIZED:
                    case GET_SURFACE:
                    case OPENING:
                        this.mCaptureConfigs.addAll(list);
                        break;
                    case OPENED:
                        this.mCaptureConfigs.addAll(list);
                        issuePendingCaptureRequest();
                        break;
                    case CLOSED:
                    case RELEASING:
                    case RELEASED:
                        throw new IllegalStateException("Cannot issue capture request on a closed/released session.");
                }
            } catch (Throwable th) {
                throw th;
            }
        }
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.CaptureSessionInterface
    public List getCaptureConfigs() {
        List listUnmodifiableList;
        synchronized (this.mSessionLock) {
            listUnmodifiableList = Collections.unmodifiableList(this.mCaptureConfigs);
        }
        return listUnmodifiableList;
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.CaptureSessionInterface
    public boolean isInOpenState() {
        boolean z;
        synchronized (this.mSessionLock) {
            try {
                State state = this.mState;
                z = state == State.OPENED || state == State.OPENING;
            } catch (Throwable th) {
                throw th;
            }
        }
        return z;
    }

    void finishClose() {
        State state = this.mState;
        State state2 = State.RELEASED;
        if (state == state2) {
            Logger.d("CaptureSession", "Skipping finishClose due to being state RELEASED.");
            return;
        }
        this.mState = state2;
        this.mSynchronizedCaptureSession = null;
        CallbackToFutureAdapter.Completer completer = this.mReleaseCompleter;
        if (completer != null) {
            completer.set(null);
            this.mReleaseCompleter = null;
        }
    }

    int issueRepeatingCaptureRequests(SessionConfig sessionConfig) {
        synchronized (this.mSessionLock) {
            try {
                if (sessionConfig == null) {
                    Logger.d("CaptureSession", "Skipping issueRepeatingCaptureRequests for no configuration case.");
                    return -1;
                }
                if (this.mState != State.OPENED) {
                    Logger.d("CaptureSession", "Skipping issueRepeatingCaptureRequests due to session closed");
                    return -1;
                }
                CaptureConfig repeatingCaptureConfig = sessionConfig.getRepeatingCaptureConfig();
                if (repeatingCaptureConfig.getSurfaces().isEmpty()) {
                    Logger.d("CaptureSession", "Skipping issueRepeatingCaptureRequests for no surface.");
                    try {
                        this.mSynchronizedCaptureSession.stopRepeating();
                    } catch (CameraAccessException e) {
                        Logger.e("CaptureSession", "Unable to access camera: " + e.getMessage());
                        Thread.dumpStack();
                    }
                    return -1;
                }
                try {
                    Logger.d("CaptureSession", "Issuing request for session.");
                    CaptureRequest captureRequestBuild = Camera2CaptureRequestBuilder.build(repeatingCaptureConfig, this.mSynchronizedCaptureSession.getDevice(), this.mConfiguredSurfaceMap, true, this.mTemplateParamsOverride);
                    if (captureRequestBuild == null) {
                        Logger.d("CaptureSession", "Skipping issuing empty request for session.");
                        return -1;
                    }
                    return this.mSynchronizedCaptureSession.setSingleRepeatingRequest(captureRequestBuild, this.mRequestMonitor.createMonitorListener(createCamera2CaptureCallback(repeatingCaptureConfig.getCameraCaptureCallbacks(), new CameraCaptureSession.CaptureCallback[0])));
                } catch (CameraAccessException e2) {
                    Logger.e("CaptureSession", "Unable to access camera: " + e2.getMessage());
                    Thread.dumpStack();
                    return -1;
                }
                throw th;
            } catch (Throwable th) {
                throw th;
            }
        }
    }

    void issuePendingCaptureRequest() {
        this.mRequestMonitor.getRequestsProcessedFuture().addListener(new Runnable() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.CaptureSession$$ExternalSyntheticLambda2
            @Override // java.lang.Runnable
            public final void run() {
                CaptureSession.$r8$lambda$2W5qxBVndJUC9kIOBllmzuSaIDQ(this.f$0);
            }
        }, CameraXExecutors.directExecutor());
    }

    public static /* synthetic */ void $r8$lambda$2W5qxBVndJUC9kIOBllmzuSaIDQ(CaptureSession captureSession) {
        synchronized (captureSession.mSessionLock) {
            if (captureSession.mCaptureConfigs.isEmpty()) {
                return;
            }
            try {
                captureSession.issueBurstCaptureRequest(captureSession.mCaptureConfigs);
                captureSession.mCaptureConfigs.clear();
            } catch (Throwable th) {
                captureSession.mCaptureConfigs.clear();
                throw th;
            }
        }
    }

    int issueBurstCaptureRequest(List list) {
        synchronized (this.mSessionLock) {
            try {
                if (this.mState != State.OPENED) {
                    Logger.d("CaptureSession", "Skipping issueBurstCaptureRequest due to session closed");
                    return -1;
                }
                if (list.isEmpty()) {
                    return -1;
                }
                try {
                    CameraBurstCaptureCallback cameraBurstCaptureCallback = new CameraBurstCaptureCallback();
                    ArrayList arrayList = new ArrayList();
                    Logger.d("CaptureSession", "Issuing capture request.");
                    Iterator it = list.iterator();
                    boolean z = false;
                    while (it.hasNext()) {
                        CaptureConfig captureConfig = (CaptureConfig) it.next();
                        if (captureConfig.getSurfaces().isEmpty()) {
                            Logger.d("CaptureSession", "Skipping issuing empty capture request.");
                        } else {
                            Iterator<DeferrableSurface> it2 = captureConfig.getSurfaces().iterator();
                            while (true) {
                                if (it2.hasNext()) {
                                    DeferrableSurface next = it2.next();
                                    if (!this.mConfiguredSurfaceMap.containsKey(next)) {
                                        Logger.d("CaptureSession", "Skipping capture request with invalid surface: " + next);
                                        break;
                                    }
                                } else {
                                    if (captureConfig.getTemplateType() == 2) {
                                        z = true;
                                    }
                                    CaptureConfig.Builder builderFrom = CaptureConfig.Builder.from(captureConfig);
                                    if (captureConfig.getTemplateType() == 5 && captureConfig.getCameraCaptureResult() != null) {
                                        builderFrom.setCameraCaptureResult(captureConfig.getCameraCaptureResult());
                                    }
                                    SessionConfig sessionConfig = this.mSessionConfig;
                                    if (sessionConfig != null) {
                                        builderFrom.addImplementationOptions(sessionConfig.getRepeatingCaptureConfig().getImplementationOptions());
                                    }
                                    builderFrom.addImplementationOptions(captureConfig.getImplementationOptions());
                                    CaptureRequest captureRequestBuild = Camera2CaptureRequestBuilder.build(builderFrom.build(), this.mSynchronizedCaptureSession.getDevice(), this.mConfiguredSurfaceMap, false, this.mTemplateParamsOverride);
                                    if (captureRequestBuild == null) {
                                        Logger.d("CaptureSession", "Skipping issuing request without surface.");
                                        return -1;
                                    }
                                    ArrayList arrayList2 = new ArrayList();
                                    Iterator<CameraCaptureCallback> it3 = captureConfig.getCameraCaptureCallbacks().iterator();
                                    while (it3.hasNext()) {
                                        CaptureCallbackConverter.toCaptureCallback(it3.next(), arrayList2);
                                    }
                                    cameraBurstCaptureCallback.addCamera2Callbacks(captureRequestBuild, arrayList2);
                                    arrayList.add(captureRequestBuild);
                                    break;
                                }
                            }
                        }
                    }
                    if (!arrayList.isEmpty()) {
                        if (this.mStillCaptureFlow.shouldStopRepeatingBeforeCapture(arrayList, z)) {
                            this.mSynchronizedCaptureSession.stopRepeating();
                            cameraBurstCaptureCallback.setCaptureSequenceCallback(new CameraBurstCaptureCallback.CaptureSequenceCallback() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.CaptureSession$$ExternalSyntheticLambda3
                                @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.CameraBurstCaptureCallback.CaptureSequenceCallback
                                public final void onCaptureSequenceCompletedOrAborted(CameraCaptureSession cameraCaptureSession, int i, boolean z2) {
                                    CaptureSession.$r8$lambda$nvQ5fvAnYk1Ayi7oaohIe_EPEJg(this.f$0, cameraCaptureSession, i, z2);
                                }
                            });
                        }
                        if (this.mTorchStateReset.isTorchResetRequired(arrayList, z)) {
                            cameraBurstCaptureCallback.addCamera2Callbacks((CaptureRequest) arrayList.get(arrayList.size() - 1), Collections.singletonList(new CameraCaptureSession.CaptureCallback() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.CaptureSession.2
                                @Override // android.hardware.camera2.CameraCaptureSession.CaptureCallback
                                public void onCaptureCompleted(CameraCaptureSession cameraCaptureSession, CaptureRequest captureRequest, TotalCaptureResult totalCaptureResult) {
                                    synchronized (CaptureSession.this.mSessionLock) {
                                        try {
                                            SessionConfig sessionConfig2 = CaptureSession.this.mSessionConfig;
                                            if (sessionConfig2 == null) {
                                                return;
                                            }
                                            CaptureConfig repeatingCaptureConfig = sessionConfig2.getRepeatingCaptureConfig();
                                            Logger.d("CaptureSession", "Submit FLASH_MODE_OFF request");
                                            CaptureSession captureSession = CaptureSession.this;
                                            captureSession.issueCaptureRequests(Collections.singletonList(captureSession.mTorchStateReset.createTorchResetRequest(repeatingCaptureConfig)));
                                        } catch (Throwable th) {
                                            throw th;
                                        }
                                    }
                                }
                            }));
                        }
                        return this.mSynchronizedCaptureSession.captureBurstRequests(arrayList, cameraBurstCaptureCallback);
                    }
                    Logger.d("CaptureSession", "Skipping issuing burst request due to no valid request elements");
                    return -1;
                } catch (CameraAccessException e) {
                    Logger.e("CaptureSession", "Unable to access camera: " + e.getMessage());
                    Thread.dumpStack();
                }
            } catch (Throwable th) {
                throw th;
            }
        }
    }

    public static /* synthetic */ void $r8$lambda$nvQ5fvAnYk1Ayi7oaohIe_EPEJg(CaptureSession captureSession, CameraCaptureSession cameraCaptureSession, int i, boolean z) {
        synchronized (captureSession.mSessionLock) {
            try {
                if (captureSession.mState == State.OPENED) {
                    captureSession.issueRepeatingCaptureRequests(captureSession.mSessionConfig);
                }
            } catch (Throwable th) {
                throw th;
            }
        }
    }

    void abortCaptures() {
        synchronized (this.mSessionLock) {
            if (this.mState != State.OPENED) {
                Logger.e("CaptureSession", "Unable to abort captures. Incorrect state:" + this.mState);
                return;
            }
            try {
                this.mSynchronizedCaptureSession.abortCaptures();
            } catch (CameraAccessException e) {
                Logger.e("CaptureSession", "Unable to abort captures.", e);
            }
        }
    }

    void stopRepeating() {
        synchronized (this.mSessionLock) {
            if (this.mState != State.OPENED) {
                Logger.e("CaptureSession", "Unable to stop repeating. Incorrect state:" + this.mState);
                return;
            }
            try {
                this.mSynchronizedCaptureSession.stopRepeating();
            } catch (CameraAccessException e) {
                Logger.e("CaptureSession", "Unable to stop repeating.", e);
            }
        }
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.CaptureSessionInterface
    public void cancelIssuedCaptureRequests() {
        ArrayList arrayList;
        synchronized (this.mSessionLock) {
            try {
                if (this.mCaptureConfigs.isEmpty()) {
                    arrayList = null;
                } else {
                    arrayList = new ArrayList(this.mCaptureConfigs);
                    this.mCaptureConfigs.clear();
                }
            } catch (Throwable th) {
                throw th;
            }
        }
        if (arrayList != null) {
            int size = arrayList.size();
            int i = 0;
            while (i < size) {
                Object obj = arrayList.get(i);
                i++;
                CaptureConfig captureConfig = (CaptureConfig) obj;
                Iterator<CameraCaptureCallback> it = captureConfig.getCameraCaptureCallbacks().iterator();
                while (it.hasNext()) {
                    it.next().onCaptureCancelled(captureConfig.getId());
                }
            }
        }
    }

    private CameraCaptureSession.CaptureCallback createCamera2CaptureCallback(List list, CameraCaptureSession.CaptureCallback... captureCallbackArr) {
        ArrayList arrayList = new ArrayList(list.size() + captureCallbackArr.length);
        Iterator it = list.iterator();
        while (it.hasNext()) {
            arrayList.add(CaptureCallbackConverter.toCaptureCallback((CameraCaptureCallback) it.next()));
        }
        Collections.addAll(arrayList, captureCallbackArr);
        return Camera2CaptureCallbacks.createComboCallback(arrayList);
    }

    final class StateCallback extends SynchronizedCaptureSession.StateCallback {
        StateCallback() {
        }

        @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.SynchronizedCaptureSession.StateCallback
        public void onConfigured(SynchronizedCaptureSession synchronizedCaptureSession) {
            synchronized (CaptureSession.this.mSessionLock) {
                try {
                    switch (CaptureSession.this.mState) {
                        case UNINITIALIZED:
                        case INITIALIZED:
                        case GET_SURFACE:
                        case OPENED:
                        case RELEASED:
                            throw new IllegalStateException("onConfigured() should not be possible in state: " + CaptureSession.this.mState);
                        case OPENING:
                            CaptureSession captureSession = CaptureSession.this;
                            captureSession.mState = State.OPENED;
                            captureSession.mSynchronizedCaptureSession = synchronizedCaptureSession;
                            Logger.d("CaptureSession", "Attempting to send capture request onConfigured");
                            CaptureSession captureSession2 = CaptureSession.this;
                            captureSession2.issueRepeatingCaptureRequests(captureSession2.mSessionConfig);
                            CaptureSession.this.issuePendingCaptureRequest();
                            break;
                        case CLOSED:
                            CaptureSession.this.mSynchronizedCaptureSession = synchronizedCaptureSession;
                            break;
                        case RELEASING:
                            synchronizedCaptureSession.close();
                            break;
                    }
                    Logger.d("CaptureSession", "CameraCaptureSession.onConfigured() mState=" + CaptureSession.this.mState);
                } catch (Throwable th) {
                    throw th;
                }
            }
        }

        @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.SynchronizedCaptureSession.StateCallback
        public void onReady(SynchronizedCaptureSession synchronizedCaptureSession) {
            synchronized (CaptureSession.this.mSessionLock) {
                try {
                    if (CaptureSession.this.mState.ordinal() == 0) {
                        throw new IllegalStateException("onReady() should not be possible in state: " + CaptureSession.this.mState);
                    }
                    Logger.d("CaptureSession", "CameraCaptureSession.onReady() " + CaptureSession.this.mState);
                } catch (Throwable th) {
                    throw th;
                }
            }
        }

        @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.SynchronizedCaptureSession.StateCallback
        /* JADX INFO: renamed from: onSessionFinished */
        public void m482$r8$lambda$dP3DguhPXTXPVRCgeBvlk8lcbs(SynchronizedCaptureSession synchronizedCaptureSession) {
            synchronized (CaptureSession.this.mSessionLock) {
                try {
                    if (CaptureSession.this.mState == State.UNINITIALIZED) {
                        throw new IllegalStateException("onSessionFinished() should not be possible in state: " + CaptureSession.this.mState);
                    }
                    Logger.d("CaptureSession", "onSessionFinished()");
                    CaptureSession.this.finishClose();
                } catch (Throwable th) {
                    throw th;
                }
            }
        }

        @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.SynchronizedCaptureSession.StateCallback
        public void onConfigureFailed(SynchronizedCaptureSession synchronizedCaptureSession) {
            synchronized (CaptureSession.this.mSessionLock) {
                try {
                    switch (CaptureSession.this.mState) {
                        case UNINITIALIZED:
                        case INITIALIZED:
                        case GET_SURFACE:
                        case OPENED:
                            throw new IllegalStateException("onConfigureFailed() should not be possible in state: " + CaptureSession.this.mState);
                        case OPENING:
                        case CLOSED:
                        case RELEASING:
                            CaptureSession.this.finishClose();
                            break;
                        case RELEASED:
                            Logger.d("CaptureSession", "ConfigureFailed callback after change to RELEASED state");
                            break;
                    }
                    Logger.e("CaptureSession", "CameraCaptureSession.onConfigureFailed() " + CaptureSession.this.mState);
                } catch (Throwable th) {
                    throw th;
                }
            }
        }
    }
}
