.class Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline;
.super Ljava/lang/Object;
.source "Camera2CapturePipeline.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$Pipeline;,
        Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$AfTask;,
        Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$PipelineTask;,
        Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$ScreenFlashTask;,
        Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$TorchTask;,
        Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$AePreCaptureTask;,
        Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$CameraCapturePipelineImpl;,
        Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$ResultListener;
    }
.end annotation


# instance fields
.field private final mCameraControl:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl;

.field private final mCameraQuirk:Landroidx/camera/core/impl/Quirks;

.field private final mExecutor:Ljava/util/concurrent/Executor;

.field private final mHasFlashUnit:Z

.field private final mIsLegacyDevice:Z

.field private final mScheduler:Ljava/util/concurrent/ScheduledExecutorService;

.field private mTemplate:I

.field private final mUseTorchAsFlash:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/workaround/UseTorchAsFlash;


# direct methods
.method public static synthetic $r8$lambda$MXfuXiDt1SaeqiqwpYNspq2eJK4(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl;Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$ResultListener;)V
    .locals 0

    .line 502
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl;->removeCaptureResultListener(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl$CaptureResultListener;)V

    return-void
.end method

.method constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl;Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCharacteristicsCompat;Landroidx/camera/core/impl/Quirks;Ljava/util/concurrent/Executor;Ljava/util/concurrent/ScheduledExecutorService;)V
    .locals 2

    .line 114
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const/4 v0, 0x1

    .line 105
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline;->mTemplate:I

    .line 115
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline;->mCameraControl:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl;

    .line 116
    sget-object p1, Landroid/hardware/camera2/CameraCharacteristics;->INFO_SUPPORTED_HARDWARE_LEVEL:Landroid/hardware/camera2/CameraCharacteristics$Key;

    .line 117
    invoke-virtual {p2, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCharacteristicsCompat;->get(Landroid/hardware/camera2/CameraCharacteristics$Key;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/lang/Integer;

    if-eqz p1, :cond_0

    .line 119
    invoke-virtual {p1}, Ljava/lang/Integer;->intValue()I

    move-result p1

    const/4 v1, 0x2

    if-ne p1, v1, :cond_0

    goto :goto_0

    :cond_0
    const/4 v0, 0x0

    :goto_0
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline;->mIsLegacyDevice:Z

    .line 120
    iput-object p4, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline;->mExecutor:Ljava/util/concurrent/Executor;

    .line 121
    iput-object p5, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline;->mScheduler:Ljava/util/concurrent/ScheduledExecutorService;

    .line 122
    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline;->mCameraQuirk:Landroidx/camera/core/impl/Quirks;

    .line 123
    new-instance p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/workaround/UseTorchAsFlash;

    invoke-direct {p1, p3}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/workaround/UseTorchAsFlash;-><init>(Landroidx/camera/core/impl/Quirks;)V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline;->mUseTorchAsFlash:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/workaround/UseTorchAsFlash;

    .line 124
    new-instance p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraInfoImpl$$ExternalSyntheticLambda0;

    invoke-direct {p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraInfoImpl$$ExternalSyntheticLambda0;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCharacteristicsCompat;)V

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/workaround/FlashAvailabilityChecker;->isFlashAvailable(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/workaround/CameraCharacteristicsProvider;)Z

    move-result p1

    iput-boolean p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline;->mHasFlashUnit:Z

    return-void
.end method

.method static is3AConverged(Landroid/hardware/camera2/TotalCaptureResult;Z)Z
    .locals 1

    if-nez p0, :cond_0

    const/4 p0, 0x0

    return p0

    .line 514
    :cond_0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraCaptureResult;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraCaptureResult;-><init>(Landroid/hardware/camera2/CaptureResult;)V

    .line 516
    invoke-static {v0, p1}, Landroidx/camera/core/impl/ConvergenceUtils;->is3AConverged(Landroidx/camera/core/impl/CameraCaptureResult;Z)Z

    move-result p0

    return p0
.end method

.method static isFlashRequired(ILandroid/hardware/camera2/TotalCaptureResult;)Z
    .locals 4

    .line 848
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "isFlashRequired: flashMode = "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, p0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    const-string v1, "Camera2CapturePipeline"

    invoke-static {v1, v0}, Landroidx/camera/core/Logger;->d(Ljava/lang/String;Ljava/lang/String;)V

    const/4 v0, 0x0

    const/4 v2, 0x1

    if-eqz p0, :cond_3

    if-eq p0, v2, :cond_2

    const/4 p1, 0x2

    if-eq p0, p1, :cond_1

    const/4 p1, 0x3

    if-ne p0, p1, :cond_0

    goto :goto_0

    .line 862
    :cond_0
    new-instance p1, Ljava/lang/AssertionError;

    invoke-direct {p1, p0}, Ljava/lang/AssertionError;-><init>(I)V

    throw p1

    :cond_1
    return v0

    :cond_2
    :goto_0
    return v2

    :cond_3
    if-eqz p1, :cond_4

    .line 855
    sget-object p0, Landroid/hardware/camera2/CaptureResult;->CONTROL_AE_STATE:Landroid/hardware/camera2/CaptureResult$Key;

    invoke-virtual {p1, p0}, Landroid/hardware/camera2/CaptureResult;->get(Landroid/hardware/camera2/CaptureResult$Key;)Ljava/lang/Object;

    move-result-object p0

    check-cast p0, Ljava/lang/Integer;

    goto :goto_1

    :cond_4
    const/4 p0, 0x0

    .line 857
    :goto_1
    new-instance p1, Ljava/lang/StringBuilder;

    invoke-direct {p1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "isFlashRequired: aeState = "

    invoke-virtual {p1, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p1, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {p1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-static {v1, p1}, Landroidx/camera/core/Logger;->d(Ljava/lang/String;Ljava/lang/String;)V

    if-eqz p0, :cond_5

    .line 858
    invoke-virtual {p0}, Ljava/lang/Integer;->intValue()I

    move-result p0

    const/4 p1, 0x4

    if-ne p0, p1, :cond_5

    return v2

    :cond_5
    return v0
.end method

.method private isTorchAsFlash(I)Z
    .locals 3

    .line 913
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline;->mUseTorchAsFlash:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/workaround/UseTorchAsFlash;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/workaround/UseTorchAsFlash;->shouldUseTorchAsFlash()Z

    move-result v0

    const/4 v1, 0x1

    if-nez v0, :cond_1

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline;->mTemplate:I

    const/4 v2, 0x3

    if-eq v0, v2, :cond_1

    if-ne p1, v1, :cond_0

    goto :goto_0

    :cond_0
    const/4 p1, 0x0

    return p1

    :cond_1
    :goto_0
    return v1
.end method

.method static waitForResult(JLjava/util/concurrent/ScheduledExecutorService;Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl;Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$ResultListener$Checker;)Lcom/google/common/util/concurrent/ListenableFuture;
    .locals 7

    .line 478
    sget-object v0, Ljava/util/concurrent/TimeUnit;->NANOSECONDS:Ljava/util/concurrent/TimeUnit;

    invoke-virtual {v0, p0, p1}, Ljava/util/concurrent/TimeUnit;->toMillis(J)J

    move-result-wide v1

    const/4 v5, 0x1

    .line 479
    invoke-static {p3, p4}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline;->waitForResult(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl;Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$ResultListener$Checker;)Lcom/google/common/util/concurrent/ListenableFuture;

    move-result-object v6

    const/4 v4, 0x0

    move-object v3, p2

    .line 478
    invoke-static/range {v1 .. v6}, Landroidx/camera/core/impl/utils/futures/Futures;->makeTimeoutFuture(JLjava/util/concurrent/ScheduledExecutorService;Ljava/lang/Object;ZLcom/google/common/util/concurrent/ListenableFuture;)Lcom/google/common/util/concurrent/ListenableFuture;

    move-result-object p0

    return-object p0
.end method

.method static waitForResult(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl;Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$ResultListener$Checker;)Lcom/google/common/util/concurrent/ListenableFuture;
    .locals 2

    .line 498
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$ResultListener;

    invoke-direct {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$ResultListener;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$ResultListener$Checker;)V

    .line 499
    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl;->addCaptureResultListener(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl$CaptureResultListener;)V

    .line 501
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$ResultListener;->getFuture()Lcom/google/common/util/concurrent/ListenableFuture;

    move-result-object p1

    .line 502
    new-instance v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$$ExternalSyntheticLambda0;

    invoke-direct {v1, p0, v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$$ExternalSyntheticLambda0;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl;Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$ResultListener;)V

    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl;->mExecutor:Ljava/util/concurrent/Executor;

    invoke-interface {p1, v1, p0}, Lcom/google/common/util/concurrent/ListenableFuture;->addListener(Ljava/lang/Runnable;Ljava/util/concurrent/Executor;)V

    return-object p1
.end method


# virtual methods
.method createPipeline(III)Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$Pipeline;
    .locals 8

    .line 158
    new-instance v6, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/workaround/OverrideAeModeForStillCapture;

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline;->mCameraQuirk:Landroidx/camera/core/impl/Quirks;

    invoke-direct {v6, v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/workaround/OverrideAeModeForStillCapture;-><init>(Landroidx/camera/core/impl/Quirks;)V

    .line 159
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$Pipeline;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline;->mTemplate:I

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline;->mExecutor:Ljava/util/concurrent/Executor;

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline;->mScheduler:Ljava/util/concurrent/ScheduledExecutorService;

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline;->mCameraControl:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl;

    iget-boolean v5, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline;->mIsLegacyDevice:Z

    invoke-direct/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$Pipeline;-><init>(ILjava/util/concurrent/Executor;Ljava/util/concurrent/ScheduledExecutorService;Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl;ZLcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/workaround/OverrideAeModeForStillCapture;)V

    if-nez p1, :cond_0

    .line 163
    new-instance v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$AfTask;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline;->mCameraControl:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl;

    invoke-direct {v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$AfTask;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl;)V

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$Pipeline;->addTask(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$PipelineTask;)V

    :cond_0
    const/4 v1, 0x3

    if-ne p2, v1, :cond_2

    .line 167
    new-instance v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$ScreenFlashTask;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline;->mCameraControl:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl;

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline;->mExecutor:Ljava/util/concurrent/Executor;

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline;->mScheduler:Ljava/util/concurrent/ScheduledExecutorService;

    new-instance v5, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/workaround/UseFlashModeTorchFor3aUpdate;

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline;->mCameraQuirk:Landroidx/camera/core/impl/Quirks;

    invoke-direct {v5, v6}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/workaround/UseFlashModeTorchFor3aUpdate;-><init>(Landroidx/camera/core/impl/Quirks;)V

    invoke-direct {v1, v2, v3, v4, v5}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$ScreenFlashTask;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl;Ljava/util/concurrent/Executor;Ljava/util/concurrent/ScheduledExecutorService;Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/workaround/UseFlashModeTorchFor3aUpdate;)V

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$Pipeline;->addTask(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$PipelineTask;)V

    :cond_1
    move v4, p2

    goto :goto_2

    .line 170
    :cond_2
    iget-boolean v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline;->mHasFlashUnit:Z

    if-eqz v1, :cond_1

    .line 171
    invoke-direct {p0, p3}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline;->isTorchAsFlash(I)Z

    move-result v1

    if-eqz v1, :cond_4

    .line 174
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline;->mUseTorchAsFlash:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/workaround/UseTorchAsFlash;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/workaround/UseTorchAsFlash;->shouldUseTorchAsFlash()Z

    move-result v1

    if-nez v1, :cond_3

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline;->mCameraControl:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl;

    .line 175
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl;->isInVideoUsage()Z

    move-result v1

    if-nez v1, :cond_3

    const/4 v1, 0x1

    :goto_0
    move v7, v1

    goto :goto_1

    :cond_3
    const/4 v1, 0x0

    goto :goto_0

    .line 176
    :goto_1
    new-instance v2, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$TorchTask;

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline;->mCameraControl:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl;

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline;->mExecutor:Ljava/util/concurrent/Executor;

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline;->mScheduler:Ljava/util/concurrent/ScheduledExecutorService;

    move v4, p2

    invoke-direct/range {v2 .. v7}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$TorchTask;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl;ILjava/util/concurrent/Executor;Ljava/util/concurrent/ScheduledExecutorService;Z)V

    invoke-virtual {v0, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$Pipeline;->addTask(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$PipelineTask;)V

    goto :goto_2

    :cond_4
    move v4, p2

    .line 179
    new-instance p2, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$AePreCaptureTask;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline;->mCameraControl:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl;

    invoke-direct {p2, v1, v4, v6}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$AePreCaptureTask;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl;ILcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/workaround/OverrideAeModeForStillCapture;)V

    invoke-virtual {v0, p2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$Pipeline;->addTask(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$PipelineTask;)V

    .line 186
    :goto_2
    new-instance p2, Ljava/lang/StringBuilder;

    invoke-direct {p2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "createPipeline: captureMode = "

    invoke-virtual {p2, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p1, ", flashMode = "

    invoke-virtual {p2, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2, v4}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p1, ", flashType = "

    invoke-virtual {p2, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2, p3}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p1, ", pipeline tasks = "

    invoke-virtual {p2, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object p1, v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$Pipeline;->mTasks:Ljava/util/List;

    invoke-virtual {p2, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {p2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    const-string p2, "Camera2CapturePipeline"

    invoke-static {p2, p1}, Landroidx/camera/core/Logger;->d(Ljava/lang/String;Ljava/lang/String;)V

    return-object v0
.end method

.method getCameraCapturePipeline(III)Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CameraCapturePipeline;
    .locals 1

    .line 195
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$CameraCapturePipelineImpl;

    invoke-virtual {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline;->createPipeline(III)Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$Pipeline;

    move-result-object p1

    iget-object p3, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline;->mExecutor:Ljava/util/concurrent/Executor;

    invoke-direct {v0, p1, p3, p2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$CameraCapturePipelineImpl;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$Pipeline;Ljava/util/concurrent/Executor;I)V

    return-object v0
.end method

.method public setTemplate(I)V
    .locals 0

    .line 129
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline;->mTemplate:I

    return-void
.end method

.method public submitStillCaptures(Ljava/util/List;III)Lcom/google/common/util/concurrent/ListenableFuture;
    .locals 0

    .line 147
    invoke-virtual {p0, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline;->createPipeline(III)Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$Pipeline;

    move-result-object p2

    .line 149
    invoke-virtual {p2, p1, p3}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CapturePipeline$Pipeline;->executeCapture(Ljava/util/List;I)Lcom/google/common/util/concurrent/ListenableFuture;

    move-result-object p1

    .line 148
    invoke-static {p1}, Landroidx/camera/core/impl/utils/futures/Futures;->nonCancellationPropagating(Lcom/google/common/util/concurrent/ListenableFuture;)Lcom/google/common/util/concurrent/ListenableFuture;

    move-result-object p1

    return-object p1
.end method
