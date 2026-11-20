package com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal;

import android.hardware.camera2.CameraDevice;
import android.hardware.camera2.CaptureRequest;
import androidx.arch.core.util.Function;
import androidx.camera.core.ImageAnalysis;
import androidx.camera.core.ImageCapture;
import androidx.camera.core.Logger;
import androidx.camera.core.Preview;
import androidx.camera.core.impl.CameraCaptureCallback;
import androidx.camera.core.impl.CameraCaptureFailure;
import androidx.camera.core.impl.CameraCaptureResult;
import androidx.camera.core.impl.CaptureConfig;
import androidx.camera.core.impl.Config;
import androidx.camera.core.impl.DeferrableSurface;
import androidx.camera.core.impl.DeferrableSurfaces;
import androidx.camera.core.impl.OutputSurface;
import androidx.camera.core.impl.OutputSurfaceConfiguration;
import androidx.camera.core.impl.SessionConfig;
import androidx.camera.core.impl.SessionProcessor;
import androidx.camera.core.impl.utils.executor.CameraXExecutors;
import androidx.camera.core.impl.utils.futures.AsyncFunction;
import androidx.camera.core.impl.utils.futures.FutureCallback;
import androidx.camera.core.impl.utils.futures.FutureChain;
import androidx.camera.core.impl.utils.futures.Futures;
import androidx.lifecycle.CoroutineLiveDataKt;
import com.google.common.util.concurrent.ListenableFuture;
import com.scanflow.datacapture.barinternal.a.a$$ExternalSyntheticThrowCCEIfNotNull0;
import com.scanflow.datacapture.barinternal.androidx.camera.camera2.impl.Camera2ImplConfig;
import com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params.DynamicRangesCompat;
import com.scanflow.datacapture.barinternal.androidx.camera.camera2.interop.CaptureRequestOptions;
import com.scanflow.datacapture.barinternal.androidx.camera.core.streamsharing.StreamSharing;
import com.scanflow.datacapture.barinternal.androidx.core.util.Preconditions;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.Objects;
import java.util.concurrent.Executor;
import java.util.concurrent.ScheduledExecutorService;

/* JADX INFO: loaded from: classes.dex */
final class ProcessingCaptureSession implements CaptureSessionInterface {
    private static List sHeldProcessorSurfaces = new ArrayList();
    private static int sNextInstanceId = 0;
    private final Camera2CameraInfoImpl mCamera2CameraInfoImpl;
    private final CaptureSession mCaptureSession;
    final Executor mExecutor;
    private int mInstanceId;
    private SessionConfig mProcessorSessionConfig;
    private Camera2RequestProcessor mRequestProcessor;
    private final ScheduledExecutorService mScheduledExecutorService;
    private SessionConfig mSessionConfig;
    private final SessionProcessor mSessionProcessor;
    private List mOutputSurfaces = new ArrayList();
    private volatile List mPendingCaptureConfigs = null;
    private CaptureRequestOptions mSessionOptions = new CaptureRequestOptions.Builder().build();
    private CaptureRequestOptions mStillCaptureOptions = new CaptureRequestOptions.Builder().build();
    private ProcessorState mProcessorState = ProcessorState.UNINITIALIZED;
    private final SessionProcessorCaptureCallback mSessionProcessorCaptureCallback = new SessionProcessorCaptureCallback();

    /* JADX INFO: Access modifiers changed from: private */
    enum ProcessorState {
        UNINITIALIZED,
        SESSION_INITIALIZED,
        ON_CAPTURE_SESSION_STARTED,
        ON_CAPTURE_SESSION_ENDED,
        DE_INITIALIZED
    }

    ProcessingCaptureSession(SessionProcessor sessionProcessor, Camera2CameraInfoImpl camera2CameraInfoImpl, DynamicRangesCompat dynamicRangesCompat, Executor executor, ScheduledExecutorService scheduledExecutorService) {
        this.mInstanceId = 0;
        this.mCaptureSession = new CaptureSession(dynamicRangesCompat);
        this.mSessionProcessor = sessionProcessor;
        this.mCamera2CameraInfoImpl = camera2CameraInfoImpl;
        this.mExecutor = executor;
        this.mScheduledExecutorService = scheduledExecutorService;
        int i = sNextInstanceId;
        sNextInstanceId = i + 1;
        this.mInstanceId = i;
        Logger.d("ProcessingCaptureSession", "New ProcessingCaptureSession (id=" + this.mInstanceId + ")");
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.CaptureSessionInterface
    public ListenableFuture open(final SessionConfig sessionConfig, final CameraDevice cameraDevice, final SynchronizedCaptureSession.Opener opener) {
        Preconditions.checkArgument(this.mProcessorState == ProcessorState.UNINITIALIZED, "Invalid state state:" + this.mProcessorState);
        Preconditions.checkArgument(sessionConfig.getSurfaces().isEmpty() ^ true, "SessionConfig contains no surfaces");
        Logger.d("ProcessingCaptureSession", "open (id=" + this.mInstanceId + ")");
        List<DeferrableSurface> surfaces = sessionConfig.getSurfaces();
        this.mOutputSurfaces = surfaces;
        return FutureChain.from(DeferrableSurfaces.surfaceListWithTimeout(surfaces, false, CoroutineLiveDataKt.DEFAULT_TIMEOUT, this.mExecutor, this.mScheduledExecutorService)).transformAsync(new AsyncFunction() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.ProcessingCaptureSession$$ExternalSyntheticLambda1
            @Override // androidx.camera.core.impl.utils.futures.AsyncFunction
            public final ListenableFuture apply(Object obj) {
                return ProcessingCaptureSession.m478$r8$lambda$dZ2c23B5bVnn66XeR4ziZkVHU8(this.f$0, sessionConfig, cameraDevice, opener, (List) obj);
            }
        }, this.mExecutor).transform(new Function() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.ProcessingCaptureSession$$ExternalSyntheticLambda2
            @Override // androidx.arch.core.util.Function
            public final Object apply(Object obj) {
                return ProcessingCaptureSession.m476$r8$lambda$2Ikygs5MgFo_bUmfTtcoZrUUZ0(this.f$0, (Void) obj);
            }
        }, this.mExecutor);
    }

    /* JADX INFO: renamed from: $r8$lambda$dZ2c23B5-bVnn66XeR4ziZkVHU8, reason: not valid java name */
    public static /* synthetic */ ListenableFuture m478$r8$lambda$dZ2c23B5bVnn66XeR4ziZkVHU8(final ProcessingCaptureSession processingCaptureSession, SessionConfig sessionConfig, CameraDevice cameraDevice, SynchronizedCaptureSession.Opener opener, List list) {
        OutputSurface outputSurfaceCreate;
        processingCaptureSession.getClass();
        Logger.d("ProcessingCaptureSession", "-- getSurfaces done, start init (id=" + processingCaptureSession.mInstanceId + ")");
        if (processingCaptureSession.mProcessorState == ProcessorState.DE_INITIALIZED) {
            return Futures.immediateFailedFuture(new IllegalStateException("SessionProcessorCaptureSession is closed."));
        }
        final DeferrableSurface surface = null;
        if (list.contains(null)) {
            return Futures.immediateFailedFuture(new DeferrableSurface.SurfaceClosedException("Surface closed", sessionConfig.getSurfaces().get(list.indexOf(null))));
        }
        OutputSurface outputSurfaceCreate2 = null;
        OutputSurface outputSurfaceCreate3 = null;
        OutputSurface outputSurfaceCreate4 = null;
        for (int i = 0; i < sessionConfig.getSurfaces().size(); i++) {
            DeferrableSurface deferrableSurface = sessionConfig.getSurfaces().get(i);
            if (isPreview(deferrableSurface) || isStreamSharing(deferrableSurface)) {
                outputSurfaceCreate2 = OutputSurface.create(deferrableSurface.getSurface().get(), deferrableSurface.getPrescribedSize(), deferrableSurface.getPrescribedStreamFormat());
            } else if (isImageCapture(deferrableSurface)) {
                outputSurfaceCreate3 = OutputSurface.create(deferrableSurface.getSurface().get(), deferrableSurface.getPrescribedSize(), deferrableSurface.getPrescribedStreamFormat());
            } else if (isImageAnalysis(deferrableSurface)) {
                outputSurfaceCreate4 = OutputSurface.create(deferrableSurface.getSurface().get(), deferrableSurface.getPrescribedSize(), deferrableSurface.getPrescribedStreamFormat());
            }
        }
        if (sessionConfig.getPostviewOutputConfig() != null) {
            surface = sessionConfig.getPostviewOutputConfig().getSurface();
            outputSurfaceCreate = OutputSurface.create(surface.getSurface().get(), surface.getPrescribedSize(), surface.getPrescribedStreamFormat());
        } else {
            outputSurfaceCreate = null;
        }
        processingCaptureSession.mProcessorState = ProcessorState.SESSION_INITIALIZED;
        try {
            ArrayList arrayList = new ArrayList(processingCaptureSession.mOutputSurfaces);
            if (surface != null) {
                arrayList.add(surface);
            }
            DeferrableSurfaces.incrementAll(arrayList);
            Logger.w("ProcessingCaptureSession", "== initSession (id=" + processingCaptureSession.mInstanceId + ")");
            try {
                SessionConfig sessionConfigInitSession = processingCaptureSession.mSessionProcessor.initSession(processingCaptureSession.mCamera2CameraInfoImpl, OutputSurfaceConfiguration.create(outputSurfaceCreate2, outputSurfaceCreate3, outputSurfaceCreate4, outputSurfaceCreate));
                processingCaptureSession.mProcessorSessionConfig = sessionConfigInitSession;
                sessionConfigInitSession.getSurfaces().get(0).getTerminationFuture().addListener(new Runnable() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.ProcessingCaptureSession$$ExternalSyntheticLambda3
                    @Override // java.lang.Runnable
                    public final void run() {
                        ProcessingCaptureSession.$r8$lambda$Z32MVrdMDtug9F4o3nU9esh4m5w(this.f$0, surface);
                    }
                }, CameraXExecutors.directExecutor());
                for (final DeferrableSurface deferrableSurface2 : processingCaptureSession.mProcessorSessionConfig.getSurfaces()) {
                    sHeldProcessorSurfaces.add(deferrableSurface2);
                    deferrableSurface2.getTerminationFuture().addListener(new Runnable() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.ProcessingCaptureSession$$ExternalSyntheticLambda4
                        @Override // java.lang.Runnable
                        public final void run() {
                            ProcessingCaptureSession.sHeldProcessorSurfaces.remove(deferrableSurface2);
                        }
                    }, processingCaptureSession.mExecutor);
                }
                SessionConfig.ValidatingBuilder validatingBuilder = new SessionConfig.ValidatingBuilder();
                validatingBuilder.add(sessionConfig);
                validatingBuilder.clearSurfaces();
                validatingBuilder.add(processingCaptureSession.mProcessorSessionConfig);
                Preconditions.checkArgument(validatingBuilder.isValid(), "Cannot transform the SessionConfig");
                ListenableFuture listenableFutureOpen = processingCaptureSession.mCaptureSession.open(validatingBuilder.build(), (CameraDevice) Preconditions.checkNotNull(cameraDevice), opener);
                Futures.addCallback(listenableFutureOpen, new FutureCallback() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.ProcessingCaptureSession.1
                    @Override // androidx.camera.core.impl.utils.futures.FutureCallback
                    public void onSuccess(Void r1) {
                    }

                    @Override // androidx.camera.core.impl.utils.futures.FutureCallback
                    public void onFailure(Throwable th) {
                        Logger.e("ProcessingCaptureSession", "open session failed ", th);
                        ProcessingCaptureSession.this.close();
                        ProcessingCaptureSession.this.release(false);
                    }
                }, processingCaptureSession.mExecutor);
                return listenableFutureOpen;
            } catch (Throwable th) {
                Logger.e("ProcessingCaptureSession", "initSession failed", th);
                DeferrableSurfaces.decrementAll(processingCaptureSession.mOutputSurfaces);
                if (surface != null) {
                    surface.decrementUseCount();
                }
                throw th;
            }
        } catch (DeferrableSurface.SurfaceClosedException e) {
            return Futures.immediateFailedFuture(e);
        }
    }

    public static /* synthetic */ void $r8$lambda$Z32MVrdMDtug9F4o3nU9esh4m5w(ProcessingCaptureSession processingCaptureSession, DeferrableSurface deferrableSurface) {
        DeferrableSurfaces.decrementAll(processingCaptureSession.mOutputSurfaces);
        if (deferrableSurface != null) {
            deferrableSurface.decrementUseCount();
        }
    }

    /* JADX INFO: renamed from: $r8$lambda$2Ikyg-s5MgFo_bUmfTtcoZrUUZ0, reason: not valid java name */
    public static /* synthetic */ Void m476$r8$lambda$2Ikygs5MgFo_bUmfTtcoZrUUZ0(ProcessingCaptureSession processingCaptureSession, Void r1) {
        processingCaptureSession.onConfigured(processingCaptureSession.mCaptureSession);
        return null;
    }

    private static void cancelRequests(List list) {
        Iterator it = list.iterator();
        while (it.hasNext()) {
            CaptureConfig captureConfig = (CaptureConfig) it.next();
            Iterator<CameraCaptureCallback> it2 = captureConfig.getCameraCaptureCallbacks().iterator();
            while (it2.hasNext()) {
                it2.next().onCaptureCancelled(captureConfig.getId());
            }
        }
    }

    void issueTriggerRequest(CaptureConfig captureConfig) {
        Logger.d("ProcessingCaptureSession", "issueTriggerRequest");
        CaptureRequestOptions captureRequestOptionsBuild = CaptureRequestOptions.Builder.from(captureConfig.getImplementationOptions()).build();
        Iterator<Config.Option<?>> it = captureRequestOptionsBuild.listOptions().iterator();
        while (it.hasNext()) {
            CaptureRequest.Key key = (CaptureRequest.Key) it.next().getToken();
            if (key.equals(CaptureRequest.CONTROL_AF_TRIGGER) || key.equals(CaptureRequest.CONTROL_AE_PRECAPTURE_TRIGGER)) {
                this.mSessionProcessor.startTrigger(captureRequestOptionsBuild, captureConfig.getTagBundle(), new CaptureCallbackAdapter(captureConfig.getId(), captureConfig.getCameraCaptureCallbacks()));
                return;
            }
        }
        cancelRequests(Arrays.asList(captureConfig));
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.CaptureSessionInterface
    public void issueCaptureRequests(List list) {
        if (list.isEmpty()) {
            return;
        }
        Logger.d("ProcessingCaptureSession", "issueCaptureRequests (id=" + this.mInstanceId + ") + state =" + this.mProcessorState);
        int iOrdinal = this.mProcessorState.ordinal();
        if (iOrdinal == 0 || iOrdinal == 1) {
            if (this.mPendingCaptureConfigs != null) {
                cancelRequests(list);
                Logger.d("ProcessingCaptureSession", "cancel the request because are pending un-submitted request");
                return;
            } else {
                this.mPendingCaptureConfigs = list;
                return;
            }
        }
        if (iOrdinal == 2) {
            Iterator it = list.iterator();
            while (it.hasNext()) {
                CaptureConfig captureConfig = (CaptureConfig) it.next();
                if (captureConfig.getTemplateType() == 2) {
                    issueStillCaptureRequest(captureConfig);
                } else {
                    issueTriggerRequest(captureConfig);
                }
            }
            return;
        }
        if (iOrdinal == 3 || iOrdinal == 4) {
            Logger.d("ProcessingCaptureSession", "Run issueCaptureRequests in wrong state, state = " + this.mProcessorState);
            cancelRequests(list);
        }
    }

    void issueStillCaptureRequest(CaptureConfig captureConfig) {
        CaptureRequestOptions.Builder builderFrom = CaptureRequestOptions.Builder.from(captureConfig.getImplementationOptions());
        Config implementationOptions = captureConfig.getImplementationOptions();
        Config.Option<?> option = CaptureConfig.OPTION_ROTATION;
        if (implementationOptions.containsOption(option)) {
            builderFrom.setCaptureRequestOption(CaptureRequest.JPEG_ORIENTATION, (Integer) captureConfig.getImplementationOptions().retrieveOption(option));
        }
        Config implementationOptions2 = captureConfig.getImplementationOptions();
        Config.Option<?> option2 = CaptureConfig.OPTION_JPEG_QUALITY;
        if (implementationOptions2.containsOption(option2)) {
            builderFrom.setCaptureRequestOption(CaptureRequest.JPEG_QUALITY, Byte.valueOf(((Integer) captureConfig.getImplementationOptions().retrieveOption(option2)).byteValue()));
        }
        CaptureRequestOptions captureRequestOptionsBuild = builderFrom.build();
        this.mStillCaptureOptions = captureRequestOptionsBuild;
        updateParameters(this.mSessionOptions, captureRequestOptionsBuild);
        this.mSessionProcessor.startCapture(captureConfig.isPostviewEnabled(), captureConfig.getTagBundle(), new CaptureCallbackAdapter(captureConfig.getId(), captureConfig.getCameraCaptureCallbacks()));
    }

    private static class CaptureCallbackAdapter implements SessionProcessor.CaptureCallback {
        private List mCameraCaptureCallbacks;
        private final int mCaptureConfigId;
        private CameraCaptureResult mCaptureResult;

        private CaptureCallbackAdapter(int i, List list) {
            this.mCaptureResult = null;
            this.mCaptureConfigId = i;
            this.mCameraCaptureCallbacks = list;
        }

        @Override // androidx.camera.core.impl.SessionProcessor.CaptureCallback
        public void onCaptureStarted(int i, long j) {
            Iterator it = this.mCameraCaptureCallbacks.iterator();
            while (it.hasNext()) {
                ((CameraCaptureCallback) it.next()).onCaptureStarted(this.mCaptureConfigId);
            }
        }

        @Override // androidx.camera.core.impl.SessionProcessor.CaptureCallback
        public void onCaptureFailed(int i) {
            Iterator it = this.mCameraCaptureCallbacks.iterator();
            while (it.hasNext()) {
                ((CameraCaptureCallback) it.next()).onCaptureFailed(this.mCaptureConfigId, new CameraCaptureFailure(CameraCaptureFailure.Reason.ERROR));
            }
        }

        @Override // androidx.camera.core.impl.SessionProcessor.CaptureCallback
        public void onCaptureCompleted(long j, int i, CameraCaptureResult cameraCaptureResult) {
            this.mCaptureResult = cameraCaptureResult;
        }

        @Override // androidx.camera.core.impl.SessionProcessor.CaptureCallback
        public void onCaptureSequenceCompleted(int i) {
            CameraCaptureResult emptyCameraCaptureResult = this.mCaptureResult;
            if (emptyCameraCaptureResult == null) {
                emptyCameraCaptureResult = new CameraCaptureResult.EmptyCameraCaptureResult();
            }
            Iterator it = this.mCameraCaptureCallbacks.iterator();
            while (it.hasNext()) {
                ((CameraCaptureCallback) it.next()).onCaptureCompleted(this.mCaptureConfigId, emptyCameraCaptureResult);
            }
        }

        @Override // androidx.camera.core.impl.SessionProcessor.CaptureCallback
        public void onCaptureProcessProgressed(int i) {
            Iterator it = this.mCameraCaptureCallbacks.iterator();
            while (it.hasNext()) {
                ((CameraCaptureCallback) it.next()).onCaptureProcessProgressed(this.mCaptureConfigId, i);
            }
        }
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.CaptureSessionInterface
    public ListenableFuture release(boolean z) {
        Logger.d("ProcessingCaptureSession", "release (id=" + this.mInstanceId + ") mProcessorState=" + this.mProcessorState);
        ListenableFuture listenableFutureRelease = this.mCaptureSession.release(z);
        int iOrdinal = this.mProcessorState.ordinal();
        if (iOrdinal == 1 || iOrdinal == 3) {
            listenableFutureRelease.addListener(new Runnable() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.ProcessingCaptureSession$$ExternalSyntheticLambda0
                @Override // java.lang.Runnable
                public final void run() {
                    ProcessingCaptureSession.m479$r8$lambda$zYW1SpAS4VP53yGc3G9YkyKoU(this.f$0);
                }
            }, CameraXExecutors.directExecutor());
        }
        this.mProcessorState = ProcessorState.DE_INITIALIZED;
        return listenableFutureRelease;
    }

    /* JADX INFO: renamed from: $r8$lambda$zYW1SpAS4VP53yGc3G9YkyK--oU, reason: not valid java name */
    public static /* synthetic */ void m479$r8$lambda$zYW1SpAS4VP53yGc3G9YkyKoU(ProcessingCaptureSession processingCaptureSession) {
        processingCaptureSession.getClass();
        Logger.d("ProcessingCaptureSession", "== deInitSession (id=" + processingCaptureSession.mInstanceId + ")");
        processingCaptureSession.mSessionProcessor.deInitSession();
    }

    private static List getSessionProcessorSurfaceList(List list) {
        ArrayList arrayList = new ArrayList();
        Iterator it = list.iterator();
        while (it.hasNext()) {
            DeferrableSurface deferrableSurface = (DeferrableSurface) it.next();
            Preconditions.checkArgument(false, "Surface must be SessionProcessorSurface");
            a$$ExternalSyntheticThrowCCEIfNotNull0.m(deferrableSurface);
            arrayList.add(null);
        }
        return arrayList;
    }

    void onConfigured(CaptureSession captureSession) {
        if (this.mProcessorState != ProcessorState.SESSION_INITIALIZED) {
            return;
        }
        this.mRequestProcessor = new Camera2RequestProcessor(captureSession, getSessionProcessorSurfaceList(this.mProcessorSessionConfig.getSurfaces()));
        Logger.d("ProcessingCaptureSession", "== onCaptureSessinStarted (id = " + this.mInstanceId + ")");
        this.mSessionProcessor.onCaptureSessionStart(this.mRequestProcessor);
        this.mProcessorState = ProcessorState.ON_CAPTURE_SESSION_STARTED;
        SessionConfig sessionConfig = this.mSessionConfig;
        if (sessionConfig != null) {
            setSessionConfig(sessionConfig);
        }
        if (this.mPendingCaptureConfigs != null) {
            issueCaptureRequests(this.mPendingCaptureConfigs);
            this.mPendingCaptureConfigs = null;
        }
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.CaptureSessionInterface
    public SessionConfig getSessionConfig() {
        return this.mSessionConfig;
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.CaptureSessionInterface
    public List getCaptureConfigs() {
        return this.mPendingCaptureConfigs != null ? this.mPendingCaptureConfigs : Collections.EMPTY_LIST;
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.CaptureSessionInterface
    public void cancelIssuedCaptureRequests() {
        Logger.d("ProcessingCaptureSession", "cancelIssuedCaptureRequests (id=" + this.mInstanceId + ")");
        if (this.mPendingCaptureConfigs != null) {
            for (CaptureConfig captureConfig : this.mPendingCaptureConfigs) {
                Iterator<CameraCaptureCallback> it = captureConfig.getCameraCaptureCallbacks().iterator();
                while (it.hasNext()) {
                    it.next().onCaptureCancelled(captureConfig.getId());
                }
            }
            this.mPendingCaptureConfigs = null;
        }
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.CaptureSessionInterface
    public void close() {
        Logger.d("ProcessingCaptureSession", "close (id=" + this.mInstanceId + ") state=" + this.mProcessorState);
        if (this.mProcessorState == ProcessorState.ON_CAPTURE_SESSION_STARTED) {
            Logger.d("ProcessingCaptureSession", "== onCaptureSessionEnd (id = " + this.mInstanceId + ")");
            this.mSessionProcessor.onCaptureSessionEnd();
            Camera2RequestProcessor camera2RequestProcessor = this.mRequestProcessor;
            if (camera2RequestProcessor != null) {
                camera2RequestProcessor.close();
            }
            this.mProcessorState = ProcessorState.ON_CAPTURE_SESSION_ENDED;
        }
        this.mCaptureSession.close();
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.CaptureSessionInterface
    public void setSessionConfig(SessionConfig sessionConfig) {
        Logger.d("ProcessingCaptureSession", "setSessionConfig (id=" + this.mInstanceId + ")");
        this.mSessionConfig = sessionConfig;
        if (sessionConfig == null) {
            return;
        }
        Camera2RequestProcessor camera2RequestProcessor = this.mRequestProcessor;
        if (camera2RequestProcessor != null) {
            camera2RequestProcessor.updateSessionConfig(sessionConfig);
        }
        if (this.mProcessorState == ProcessorState.ON_CAPTURE_SESSION_STARTED) {
            CaptureRequestOptions captureRequestOptionsBuild = CaptureRequestOptions.Builder.from(sessionConfig.getImplementationOptions()).build();
            this.mSessionOptions = captureRequestOptionsBuild;
            updateParameters(captureRequestOptionsBuild, this.mStillCaptureOptions);
            if (!hasPreviewSurface(sessionConfig.getRepeatingCaptureConfig())) {
                this.mSessionProcessor.stopRepeating();
            } else {
                this.mSessionProcessor.startRepeating(sessionConfig.getRepeatingCaptureConfig().getTagBundle(), this.mSessionProcessorCaptureCallback);
            }
        }
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.CaptureSessionInterface
    public boolean isInOpenState() {
        return this.mCaptureSession.isInOpenState();
    }

    private static boolean hasPreviewSurface(CaptureConfig captureConfig) {
        for (DeferrableSurface deferrableSurface : captureConfig.getSurfaces()) {
            if (isPreview(deferrableSurface) || isStreamSharing(deferrableSurface)) {
                return true;
            }
        }
        return false;
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.CaptureSessionInterface
    public void setStreamUseCaseMap(Map map) {
    }

    private void updateParameters(CaptureRequestOptions captureRequestOptions, CaptureRequestOptions captureRequestOptions2) {
        Camera2ImplConfig.Builder builder = new Camera2ImplConfig.Builder();
        builder.insertAllOptions(captureRequestOptions);
        builder.insertAllOptions(captureRequestOptions2);
        this.mSessionProcessor.setParameters(builder.build());
    }

    private static boolean isPreview(DeferrableSurface deferrableSurface) {
        return Objects.equals(deferrableSurface.getContainerClass(), Preview.class);
    }

    private static boolean isImageCapture(DeferrableSurface deferrableSurface) {
        return Objects.equals(deferrableSurface.getContainerClass(), ImageCapture.class);
    }

    private static boolean isImageAnalysis(DeferrableSurface deferrableSurface) {
        return Objects.equals(deferrableSurface.getContainerClass(), ImageAnalysis.class);
    }

    private static boolean isStreamSharing(DeferrableSurface deferrableSurface) {
        return Objects.equals(deferrableSurface.getContainerClass(), StreamSharing.class);
    }

    private static class SessionProcessorCaptureCallback implements SessionProcessor.CaptureCallback {
        SessionProcessorCaptureCallback() {
        }

        @Override // androidx.camera.core.impl.SessionProcessor.CaptureCallback
        public void onCaptureStarted(int i, long j) {
        }

        @Override // androidx.camera.core.impl.SessionProcessor.CaptureCallback
        public void onCaptureProcessStarted(int i) {
        }

        @Override // androidx.camera.core.impl.SessionProcessor.CaptureCallback
        public void onCaptureFailed(int i) {
        }

        @Override // androidx.camera.core.impl.SessionProcessor.CaptureCallback
        public void onCaptureSequenceCompleted(int i) {
        }

        @Override // androidx.camera.core.impl.SessionProcessor.CaptureCallback
        public void onCaptureSequenceAborted(int i) {
        }

        @Override // androidx.camera.core.impl.SessionProcessor.CaptureCallback
        public void onCaptureCompleted(long j, int i, CameraCaptureResult cameraCaptureResult) {
        }
    }
}
