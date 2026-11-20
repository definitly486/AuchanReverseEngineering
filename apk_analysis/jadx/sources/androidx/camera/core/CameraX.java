package androidx.camera.core;

import android.content.ComponentCallbacks2;
import android.content.ComponentName;
import android.content.Context;
import android.content.pm.PackageManager;
import android.os.Bundle;
import android.os.Handler;
import android.os.HandlerThread;
import android.os.SystemClock;
import android.util.SparseArray;
import androidx.arch.core.util.Function;
import androidx.camera.core.impl.CameraDeviceSurfaceManager;
import androidx.camera.core.impl.CameraFactory;
import androidx.camera.core.impl.CameraProviderExecutionState;
import androidx.camera.core.impl.CameraRepository;
import androidx.camera.core.impl.CameraThreadConfig;
import androidx.camera.core.impl.CameraValidator;
import androidx.camera.core.impl.MetadataHolderService;
import androidx.camera.core.impl.QuirkSettings;
import androidx.camera.core.impl.QuirkSettingsHolder;
import androidx.camera.core.impl.QuirkSettingsLoader;
import androidx.camera.core.impl.UseCaseConfigFactory;
import androidx.camera.core.impl.utils.futures.Futures;
import androidx.concurrent.futures.CallbackToFutureAdapter;
import com.google.common.util.concurrent.ListenableFuture;
import com.scanflow.datacapture.barinternal.androidx.camera.core.impl.utils.ContextUtil;
import com.scanflow.datacapture.barinternal.androidx.core.os.HandlerCompat;
import com.scanflow.datacapture.barinternal.androidx.core.util.Preconditions;
import com.scanflow.datacapture.barinternal.androidx.tracing.Trace;
import java.lang.reflect.InvocationTargetException;
import java.util.concurrent.Executor;

/* JADX INFO: loaded from: classes.dex */
public final class CameraX {
    private static final Object MIN_LOG_LEVEL_LOCK = new Object();
    private static final SparseArray sMinLogLevelReferenceCountMap = new SparseArray();
    private final Executor mCameraExecutor;
    private CameraFactory mCameraFactory;
    final CameraRepository mCameraRepository;
    private final CameraXConfig mCameraXConfig;
    private UseCaseConfigFactory mDefaultConfigFactory;
    private final ListenableFuture mInitInternalFuture;
    private InternalInitState mInitState;
    private final Object mInitializeLock;
    private final Integer mMinLogLevel;
    private final RetryPolicy mRetryPolicy;
    private final Handler mSchedulerHandler;
    private final HandlerThread mSchedulerThread;
    private ListenableFuture mShutdownInternalFuture;
    private CameraDeviceSurfaceManager mSurfaceManager;

    /* JADX INFO: Access modifiers changed from: private */
    enum InternalInitState {
        UNINITIALIZED,
        INITIALIZING,
        INITIALIZING_ERROR,
        INITIALIZED,
        SHUTDOWN
    }

    public CameraX(Context context, CameraXConfig.Provider provider) {
        this(context, provider, new QuirkSettingsLoader());
    }

    CameraX(Context context, CameraXConfig.Provider provider, Function function) {
        this.mCameraRepository = new CameraRepository();
        this.mInitializeLock = new Object();
        this.mInitState = InternalInitState.UNINITIALIZED;
        this.mShutdownInternalFuture = Futures.immediateFuture(null);
        if (provider != null) {
            this.mCameraXConfig = provider.getCameraXConfig();
        } else {
            CameraXConfig.Provider configProvider = getConfigProvider(context);
            if (configProvider == null) {
                throw new IllegalStateException("CameraX is not configured properly. The most likely cause is you did not include a default implementation in your build such as 'camera-camera2'.");
            }
            this.mCameraXConfig = configProvider.getCameraXConfig();
        }
        updateQuirkSettings(context, this.mCameraXConfig.getQuirkSettings(), function);
        Executor cameraExecutor = this.mCameraXConfig.getCameraExecutor(null);
        Handler schedulerHandler = this.mCameraXConfig.getSchedulerHandler(null);
        this.mCameraExecutor = cameraExecutor == null ? new CameraExecutor() : cameraExecutor;
        if (schedulerHandler == null) {
            HandlerThread handlerThread = new HandlerThread("CameraX-scheduler", 10);
            this.mSchedulerThread = handlerThread;
            handlerThread.start();
            this.mSchedulerHandler = HandlerCompat.createAsync(handlerThread.getLooper());
        } else {
            this.mSchedulerThread = null;
            this.mSchedulerHandler = schedulerHandler;
        }
        Integer num = (Integer) this.mCameraXConfig.retrieveOption(CameraXConfig.OPTION_MIN_LOGGING_LEVEL, null);
        this.mMinLogLevel = num;
        increaseMinLogLevelReference(num);
        this.mRetryPolicy = new RetryPolicy.Builder(this.mCameraXConfig.getCameraProviderInitRetryPolicy()).build();
        this.mInitInternalFuture = initInternal(context);
    }

    public CameraFactory getCameraFactory() {
        CameraFactory cameraFactory = this.mCameraFactory;
        if (cameraFactory != null) {
            return cameraFactory;
        }
        throw new IllegalStateException("CameraX not initialized yet.");
    }

    private static CameraXConfig.Provider getConfigProvider(Context context) {
        ComponentCallbacks2 applicationFromContext = ContextUtil.getApplicationFromContext(context);
        if (applicationFromContext instanceof CameraXConfig.Provider) {
            return (CameraXConfig.Provider) applicationFromContext;
        }
        try {
            Context applicationContext = ContextUtil.getApplicationContext(context);
            Bundle bundle = applicationContext.getPackageManager().getServiceInfo(new ComponentName(applicationContext, (Class<?>) MetadataHolderService.class), 640).metaData;
            String string = bundle != null ? bundle.getString("androidx.camera.core.impl.MetadataHolderService.DEFAULT_CONFIG_PROVIDER") : null;
            if (string == null) {
                Logger.e("CameraX", "No default CameraXConfig.Provider specified in meta-data. The most likely cause is you did not include a default implementation in your build such as 'camera-camera2'.");
                return null;
            }
            return (CameraXConfig.Provider) Class.forName(string).getDeclaredConstructor(null).newInstance(null);
        } catch (PackageManager.NameNotFoundException e) {
            e = e;
            Logger.e("CameraX", "Failed to retrieve default CameraXConfig.Provider from meta-data", e);
            return null;
        } catch (ClassNotFoundException e2) {
            e = e2;
            Logger.e("CameraX", "Failed to retrieve default CameraXConfig.Provider from meta-data", e);
            return null;
        } catch (IllegalAccessException e3) {
            e = e3;
            Logger.e("CameraX", "Failed to retrieve default CameraXConfig.Provider from meta-data", e);
            return null;
        } catch (InstantiationException e4) {
            e = e4;
            Logger.e("CameraX", "Failed to retrieve default CameraXConfig.Provider from meta-data", e);
            return null;
        } catch (NoSuchMethodException e5) {
            e = e5;
            Logger.e("CameraX", "Failed to retrieve default CameraXConfig.Provider from meta-data", e);
            return null;
        } catch (NullPointerException e6) {
            e = e6;
            Logger.e("CameraX", "Failed to retrieve default CameraXConfig.Provider from meta-data", e);
            return null;
        } catch (InvocationTargetException e7) {
            e = e7;
            Logger.e("CameraX", "Failed to retrieve default CameraXConfig.Provider from meta-data", e);
            return null;
        }
    }

    private static void updateQuirkSettings(Context context, QuirkSettings quirkSettings, Function function) {
        if (quirkSettings != null) {
            Logger.d("CameraX", "QuirkSettings from CameraXConfig: " + quirkSettings);
        } else {
            quirkSettings = (QuirkSettings) function.apply(context);
            Logger.d("CameraX", "QuirkSettings from app metadata: " + quirkSettings);
        }
        if (quirkSettings == null) {
            quirkSettings = QuirkSettingsHolder.DEFAULT;
            Logger.d("CameraX", "QuirkSettings by default: " + quirkSettings);
        }
        QuirkSettingsHolder.instance().set(quirkSettings);
    }

    public CameraDeviceSurfaceManager getCameraDeviceSurfaceManager() {
        CameraDeviceSurfaceManager cameraDeviceSurfaceManager = this.mSurfaceManager;
        if (cameraDeviceSurfaceManager != null) {
            return cameraDeviceSurfaceManager;
        }
        throw new IllegalStateException("CameraX not initialized yet.");
    }

    public CameraRepository getCameraRepository() {
        return this.mCameraRepository;
    }

    public UseCaseConfigFactory getDefaultConfigFactory() {
        UseCaseConfigFactory useCaseConfigFactory = this.mDefaultConfigFactory;
        if (useCaseConfigFactory != null) {
            return useCaseConfigFactory;
        }
        throw new IllegalStateException("CameraX not initialized yet.");
    }

    public ListenableFuture getInitializeFuture() {
        return this.mInitInternalFuture;
    }

    private ListenableFuture initInternal(final Context context) {
        ListenableFuture future;
        synchronized (this.mInitializeLock) {
            Preconditions.checkState(this.mInitState == InternalInitState.UNINITIALIZED, "CameraX.initInternal() should only be called once per instance");
            this.mInitState = InternalInitState.INITIALIZING;
            future = CallbackToFutureAdapter.getFuture(new CallbackToFutureAdapter.Resolver() { // from class: androidx.camera.core.CameraX$$ExternalSyntheticLambda0
                @Override // androidx.concurrent.futures.CallbackToFutureAdapter.Resolver
                public final Object attachCompleter(CallbackToFutureAdapter.Completer completer) {
                    return CameraX.$r8$lambda$b1jPpot1TIpFqpamUa911fV8DN4(this.f$0, context, completer);
                }
            });
        }
        return future;
    }

    public static /* synthetic */ Object $r8$lambda$b1jPpot1TIpFqpamUa911fV8DN4(CameraX cameraX, Context context, CallbackToFutureAdapter.Completer completer) {
        cameraX.initAndRetryRecursively(cameraX.mCameraExecutor, SystemClock.elapsedRealtime(), 1, context, completer);
        return "CameraX initInternal";
    }

    /* JADX INFO: Access modifiers changed from: private */
    public void initAndRetryRecursively(final Executor executor, final long j, final int i, final Context context, final CallbackToFutureAdapter.Completer completer) {
        executor.execute(new Runnable() { // from class: androidx.camera.core.CameraX$$ExternalSyntheticLambda1
            @Override // java.lang.Runnable
            public final void run() {
                CameraX.$r8$lambda$0hQ2PO2Vr1crheudPSlgjvs3IZ4(this.f$0, context, executor, i, completer, j);
            }
        });
    }

    /* JADX WARN: Code duplicated, block: B:32:0x00c9  */
    /* JADX WARN: Code duplicated, block: B:35:0x0103 A[Catch: all -> 0x0160, TryCatch #0 {all -> 0x0160, blocks: (B:3:0x0015, B:5:0x001d, B:7:0x003f, B:9:0x0059, B:11:0x0063, B:18:0x0072, B:20:0x0081, B:21:0x0084, B:24:0x008e, B:25:0x009a, B:26:0x009b, B:27:0x00a7, B:28:0x00a8, B:29:0x00b4, B:30:0x00b5, B:34:0x00ce, B:35:0x0103, B:36:0x0105, B:39:0x010b, B:41:0x0111, B:42:0x0118, B:44:0x011c, B:45:0x0148, B:47:0x014c, B:48:0x0150, B:54:0x015f, B:37:0x0106, B:38:0x010a), top: B:58:0x0015, inners: #3 }] */
    /* JADX WARN: Code duplicated, block: B:41:0x0111 A[Catch: all -> 0x0160, TryCatch #0 {all -> 0x0160, blocks: (B:3:0x0015, B:5:0x001d, B:7:0x003f, B:9:0x0059, B:11:0x0063, B:18:0x0072, B:20:0x0081, B:21:0x0084, B:24:0x008e, B:25:0x009a, B:26:0x009b, B:27:0x00a7, B:28:0x00a8, B:29:0x00b4, B:30:0x00b5, B:34:0x00ce, B:35:0x0103, B:36:0x0105, B:39:0x010b, B:41:0x0111, B:42:0x0118, B:44:0x011c, B:45:0x0148, B:47:0x014c, B:48:0x0150, B:54:0x015f, B:37:0x0106, B:38:0x010a), top: B:58:0x0015, inners: #3 }] */
    /* JADX WARN: Code duplicated, block: B:42:0x0118 A[Catch: all -> 0x0160, TryCatch #0 {all -> 0x0160, blocks: (B:3:0x0015, B:5:0x001d, B:7:0x003f, B:9:0x0059, B:11:0x0063, B:18:0x0072, B:20:0x0081, B:21:0x0084, B:24:0x008e, B:25:0x009a, B:26:0x009b, B:27:0x00a7, B:28:0x00a8, B:29:0x00b4, B:30:0x00b5, B:34:0x00ce, B:35:0x0103, B:36:0x0105, B:39:0x010b, B:41:0x0111, B:42:0x0118, B:44:0x011c, B:45:0x0148, B:47:0x014c, B:48:0x0150, B:54:0x015f, B:37:0x0106, B:38:0x010a), top: B:58:0x0015, inners: #3 }] */
    /* JADX WARN: Code duplicated, block: B:44:0x011c A[Catch: all -> 0x0160, TryCatch #0 {all -> 0x0160, blocks: (B:3:0x0015, B:5:0x001d, B:7:0x003f, B:9:0x0059, B:11:0x0063, B:18:0x0072, B:20:0x0081, B:21:0x0084, B:24:0x008e, B:25:0x009a, B:26:0x009b, B:27:0x00a7, B:28:0x00a8, B:29:0x00b4, B:30:0x00b5, B:34:0x00ce, B:35:0x0103, B:36:0x0105, B:39:0x010b, B:41:0x0111, B:42:0x0118, B:44:0x011c, B:45:0x0148, B:47:0x014c, B:48:0x0150, B:54:0x015f, B:37:0x0106, B:38:0x010a), top: B:58:0x0015, inners: #3 }] */
    /* JADX WARN: Code duplicated, block: B:45:0x0148 A[Catch: all -> 0x0160, TryCatch #0 {all -> 0x0160, blocks: (B:3:0x0015, B:5:0x001d, B:7:0x003f, B:9:0x0059, B:11:0x0063, B:18:0x0072, B:20:0x0081, B:21:0x0084, B:24:0x008e, B:25:0x009a, B:26:0x009b, B:27:0x00a7, B:28:0x00a8, B:29:0x00b4, B:30:0x00b5, B:34:0x00ce, B:35:0x0103, B:36:0x0105, B:39:0x010b, B:41:0x0111, B:42:0x0118, B:44:0x011c, B:45:0x0148, B:47:0x014c, B:48:0x0150, B:54:0x015f, B:37:0x0106, B:38:0x010a), top: B:58:0x0015, inners: #3 }] */
    /* JADX WARN: Code duplicated, block: B:47:0x014c A[Catch: all -> 0x0160, TryCatch #0 {all -> 0x0160, blocks: (B:3:0x0015, B:5:0x001d, B:7:0x003f, B:9:0x0059, B:11:0x0063, B:18:0x0072, B:20:0x0081, B:21:0x0084, B:24:0x008e, B:25:0x009a, B:26:0x009b, B:27:0x00a7, B:28:0x00a8, B:29:0x00b4, B:30:0x00b5, B:34:0x00ce, B:35:0x0103, B:36:0x0105, B:39:0x010b, B:41:0x0111, B:42:0x0118, B:44:0x011c, B:45:0x0148, B:47:0x014c, B:48:0x0150, B:54:0x015f, B:37:0x0106, B:38:0x010a), top: B:58:0x0015, inners: #3 }] */
    /* JADX WARN: Code duplicated, block: B:48:0x0150 A[Catch: all -> 0x0160, TRY_LEAVE, TryCatch #0 {all -> 0x0160, blocks: (B:3:0x0015, B:5:0x001d, B:7:0x003f, B:9:0x0059, B:11:0x0063, B:18:0x0072, B:20:0x0081, B:21:0x0084, B:24:0x008e, B:25:0x009a, B:26:0x009b, B:27:0x00a7, B:28:0x00a8, B:29:0x00b4, B:30:0x00b5, B:34:0x00ce, B:35:0x0103, B:36:0x0105, B:39:0x010b, B:41:0x0111, B:42:0x0118, B:44:0x011c, B:45:0x0148, B:47:0x014c, B:48:0x0150, B:54:0x015f, B:37:0x0106, B:38:0x010a), top: B:58:0x0015, inners: #3 }] */
    /* JADX WARN: Code duplicated, block: B:59:0x0106 A[EXC_TOP_SPLITTER, SYNTHETIC] */
    /* JADX WARN: Instruction removed from duplicated block: B:44:0x011c, please report this as an issue */
    public static /* synthetic */ void $r8$lambda$0hQ2PO2Vr1crheudPSlgjvs3IZ4(final CameraX cameraX, Context context, final Executor executor, final int i, final CallbackToFutureAdapter.Completer completer, final long j) {
        RetryPolicy.RetryConfig retryConfigOnRetryDecisionRequested;
        cameraX.getClass();
        Trace.beginSection("CX:initAndRetryRecursively");
        final Context applicationContext = ContextUtil.getApplicationContext(context);
        try {
            try {
                CameraFactory.Provider cameraFactoryProvider = cameraX.mCameraXConfig.getCameraFactoryProvider(null);
                if (cameraFactoryProvider == null) {
                    throw new InitializationException(new IllegalArgumentException("Invalid app configuration provided. Missing CameraFactory."));
                }
                CameraThreadConfig cameraThreadConfigCreate = CameraThreadConfig.create(cameraX.mCameraExecutor, cameraX.mSchedulerHandler);
                CameraSelector availableCamerasLimiter = cameraX.mCameraXConfig.getAvailableCamerasLimiter(null);
                cameraX.mCameraFactory = cameraFactoryProvider.newInstance(applicationContext, cameraThreadConfigCreate, availableCamerasLimiter, cameraX.mCameraXConfig.getCameraOpenRetryMaxTimeoutInMillisWhileResuming());
                CameraDeviceSurfaceManager.Provider deviceSurfaceManagerProvider = cameraX.mCameraXConfig.getDeviceSurfaceManagerProvider(null);
                if (deviceSurfaceManagerProvider == null) {
                    throw new InitializationException(new IllegalArgumentException("Invalid app configuration provided. Missing CameraDeviceSurfaceManager."));
                }
                cameraX.mSurfaceManager = deviceSurfaceManagerProvider.newInstance(applicationContext, cameraX.mCameraFactory.getCameraManager(), cameraX.mCameraFactory.getAvailableCameraIds());
                UseCaseConfigFactory.Provider useCaseConfigFactoryProvider = cameraX.mCameraXConfig.getUseCaseConfigFactoryProvider(null);
                if (useCaseConfigFactoryProvider == null) {
                    throw new InitializationException(new IllegalArgumentException("Invalid app configuration provided. Missing UseCaseConfigFactory."));
                }
                cameraX.mDefaultConfigFactory = useCaseConfigFactoryProvider.newInstance(applicationContext);
                if (executor instanceof CameraExecutor) {
                    ((CameraExecutor) executor).init(cameraX.mCameraFactory);
                }
                cameraX.mCameraRepository.init(cameraX.mCameraFactory);
                CameraValidator.validateCameras(applicationContext, cameraX.mCameraRepository, availableCamerasLimiter);
                if (i > 1) {
                    cameraX.traceExecutionState(null);
                }
                cameraX.setStateToInitialized();
                completer.set(null);
                Trace.endSection();
            } catch (Throwable th) {
                Trace.endSection();
                throw th;
            }
        } catch (InitializationException e) {
            e = e;
            CameraProviderExecutionState cameraProviderExecutionState = new CameraProviderExecutionState(j, i, e);
            retryConfigOnRetryDecisionRequested = cameraX.mRetryPolicy.onRetryDecisionRequested(cameraProviderExecutionState);
            cameraX.traceExecutionState(cameraProviderExecutionState);
            if (!retryConfigOnRetryDecisionRequested.shouldRetry() && i < Integer.MAX_VALUE) {
                Logger.w("CameraX", "Retry init. Start time " + j + " current time " + SystemClock.elapsedRealtime(), e);
                HandlerCompat.postDelayed(cameraX.mSchedulerHandler, new Runnable() { // from class: androidx.camera.core.CameraX$$ExternalSyntheticLambda2
                    @Override // java.lang.Runnable
                    public final void run() {
                        this.f$0.initAndRetryRecursively(executor, j, i + 1, applicationContext, completer);
                    }
                }, "retry_token", retryConfigOnRetryDecisionRequested.getRetryDelayInMillis());
            } else {
                synchronized (cameraX.mInitializeLock) {
                    cameraX.mInitState = InternalInitState.INITIALIZING_ERROR;
                }
                if (retryConfigOnRetryDecisionRequested.shouldCompleteWithoutFailure()) {
                    cameraX.setStateToInitialized();
                    completer.set(null);
                } else if (e instanceof CameraValidator.CameraIdListIncorrectException) {
                    String str = "Device reporting less cameras than anticipated. On real devices: Retrying initialization might resolve temporary camera errors. On emulators: Ensure virtual camera configuration matches supported camera features as reported by PackageManager#hasSystemFeature. Available cameras: " + ((CameraValidator.CameraIdListIncorrectException) e).getAvailableCameraCount();
                    Logger.e("CameraX", str, e);
                    completer.setException(new InitializationException(new CameraUnavailableException(3, str)));
                } else if (e instanceof InitializationException) {
                    completer.setException(e);
                } else {
                    completer.setException(new InitializationException(e));
                }
            }
            Trace.endSection();
        } catch (CameraValidator.CameraIdListIncorrectException e2) {
            e = e2;
            CameraProviderExecutionState cameraProviderExecutionState2 = new CameraProviderExecutionState(j, i, e);
            retryConfigOnRetryDecisionRequested = cameraX.mRetryPolicy.onRetryDecisionRequested(cameraProviderExecutionState2);
            cameraX.traceExecutionState(cameraProviderExecutionState2);
            if (!retryConfigOnRetryDecisionRequested.shouldRetry()) {
                synchronized (cameraX.mInitializeLock) {
                    cameraX.mInitState = InternalInitState.INITIALIZING_ERROR;
                    if (retryConfigOnRetryDecisionRequested.shouldCompleteWithoutFailure()) {
                        cameraX.setStateToInitialized();
                        completer.set(null);
                    } else if (e instanceof CameraValidator.CameraIdListIncorrectException) {
                        String str2 = "Device reporting less cameras than anticipated. On real devices: Retrying initialization might resolve temporary camera errors. On emulators: Ensure virtual camera configuration matches supported camera features as reported by PackageManager#hasSystemFeature. Available cameras: " + ((CameraValidator.CameraIdListIncorrectException) e).getAvailableCameraCount();
                        Logger.e("CameraX", str2, e);
                        completer.setException(new InitializationException(new CameraUnavailableException(3, str2)));
                    } else if (e instanceof InitializationException) {
                        completer.setException(e);
                    } else {
                        completer.setException(new InitializationException(e));
                    }
                }
            } else {
                synchronized (cameraX.mInitializeLock) {
                    cameraX.mInitState = InternalInitState.INITIALIZING_ERROR;
                    if (retryConfigOnRetryDecisionRequested.shouldCompleteWithoutFailure()) {
                        cameraX.setStateToInitialized();
                        completer.set(null);
                    } else if (e instanceof CameraValidator.CameraIdListIncorrectException) {
                        String str3 = "Device reporting less cameras than anticipated. On real devices: Retrying initialization might resolve temporary camera errors. On emulators: Ensure virtual camera configuration matches supported camera features as reported by PackageManager#hasSystemFeature. Available cameras: " + ((CameraValidator.CameraIdListIncorrectException) e).getAvailableCameraCount();
                        Logger.e("CameraX", str3, e);
                        completer.setException(new InitializationException(new CameraUnavailableException(3, str3)));
                    } else if (e instanceof InitializationException) {
                        completer.setException(e);
                    } else {
                        completer.setException(new InitializationException(e));
                    }
                }
            }
            Trace.endSection();
        } catch (RuntimeException e3) {
            e = e3;
            CameraProviderExecutionState cameraProviderExecutionState3 = new CameraProviderExecutionState(j, i, e);
            retryConfigOnRetryDecisionRequested = cameraX.mRetryPolicy.onRetryDecisionRequested(cameraProviderExecutionState3);
            cameraX.traceExecutionState(cameraProviderExecutionState3);
            if (!retryConfigOnRetryDecisionRequested.shouldRetry()) {
                synchronized (cameraX.mInitializeLock) {
                    cameraX.mInitState = InternalInitState.INITIALIZING_ERROR;
                    if (retryConfigOnRetryDecisionRequested.shouldCompleteWithoutFailure()) {
                        cameraX.setStateToInitialized();
                        completer.set(null);
                    } else if (e instanceof CameraValidator.CameraIdListIncorrectException) {
                        String str4 = "Device reporting less cameras than anticipated. On real devices: Retrying initialization might resolve temporary camera errors. On emulators: Ensure virtual camera configuration matches supported camera features as reported by PackageManager#hasSystemFeature. Available cameras: " + ((CameraValidator.CameraIdListIncorrectException) e).getAvailableCameraCount();
                        Logger.e("CameraX", str4, e);
                        completer.setException(new InitializationException(new CameraUnavailableException(3, str4)));
                    } else if (e instanceof InitializationException) {
                        completer.setException(e);
                    } else {
                        completer.setException(new InitializationException(e));
                    }
                }
            } else {
                synchronized (cameraX.mInitializeLock) {
                    cameraX.mInitState = InternalInitState.INITIALIZING_ERROR;
                    if (retryConfigOnRetryDecisionRequested.shouldCompleteWithoutFailure()) {
                        cameraX.setStateToInitialized();
                        completer.set(null);
                    } else if (e instanceof CameraValidator.CameraIdListIncorrectException) {
                        String str5 = "Device reporting less cameras than anticipated. On real devices: Retrying initialization might resolve temporary camera errors. On emulators: Ensure virtual camera configuration matches supported camera features as reported by PackageManager#hasSystemFeature. Available cameras: " + ((CameraValidator.CameraIdListIncorrectException) e).getAvailableCameraCount();
                        Logger.e("CameraX", str5, e);
                        completer.setException(new InitializationException(new CameraUnavailableException(3, str5)));
                    } else if (e instanceof InitializationException) {
                        completer.setException(e);
                    } else {
                        completer.setException(new InitializationException(e));
                    }
                }
            }
            Trace.endSection();
        }
    }

    private void setStateToInitialized() {
        synchronized (this.mInitializeLock) {
            this.mInitState = InternalInitState.INITIALIZED;
        }
    }

    private static void increaseMinLogLevelReference(Integer num) {
        synchronized (MIN_LOG_LEVEL_LOCK) {
            try {
                if (num == null) {
                    return;
                }
                Preconditions.checkArgumentInRange(num.intValue(), 3, 6, "minLogLevel");
                SparseArray sparseArray = sMinLogLevelReferenceCountMap;
                sparseArray.put(num.intValue(), Integer.valueOf(sparseArray.get(num.intValue()) != null ? 1 + ((Integer) sparseArray.get(num.intValue())).intValue() : 1));
                updateOrResetMinLogLevel();
            } catch (Throwable th) {
                throw th;
            }
        }
    }

    private static void updateOrResetMinLogLevel() {
        SparseArray sparseArray = sMinLogLevelReferenceCountMap;
        if (sparseArray.size() == 0) {
            Logger.resetMinLogLevel();
            return;
        }
        if (sparseArray.get(3) != null) {
            Logger.setMinLogLevel(3);
            return;
        }
        if (sparseArray.get(4) != null) {
            Logger.setMinLogLevel(4);
        } else if (sparseArray.get(5) != null) {
            Logger.setMinLogLevel(5);
        } else if (sparseArray.get(6) != null) {
            Logger.setMinLogLevel(6);
        }
    }

    private void traceExecutionState(RetryPolicy.ExecutionState executionState) throws Throwable {
        if (Trace.isEnabled()) {
            Trace.setCounter("CX:CameraProvider-RetryStatus", executionState != null ? executionState.getStatus() : -1);
        }
    }
}
