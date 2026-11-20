.class Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode$1;
.super Landroidx/camera/core/impl/CameraCaptureCallback;
.source "CaptureNode.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode;->transform(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode$In;)Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$In;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode;


# direct methods
.method public static synthetic $r8$lambda$9Z-85vUMCoUYHuaiE1yU-NMe4EM(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode$1;)V
    .locals 0

    .line 108
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode$1;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode;

    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode;->mCurrentRequest:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;

    if-eqz p0, :cond_0

    .line 109
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;->onCaptureStarted()V

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$MGCZJvSMnFbJoxIZMXUjnrGd84Q(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode$1;I)V
    .locals 0

    .line 117
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode$1;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode;

    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode;->mCurrentRequest:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;

    if-eqz p0, :cond_0

    .line 118
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;->onCaptureProcessProgressed(I)V

    :cond_0
    return-void
.end method

.method constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode;)V
    .locals 0

    .line 104
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode$1;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode;

    invoke-direct {p0}, Landroidx/camera/core/impl/CameraCaptureCallback;-><init>()V

    return-void
.end method


# virtual methods
.method public onCaptureProcessProgressed(II)V
    .locals 1

    .line 116
    invoke-static {}, Landroidx/camera/core/impl/utils/executor/CameraXExecutors;->mainThreadExecutor()Ljava/util/concurrent/ScheduledExecutorService;

    move-result-object p1

    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode$1$$ExternalSyntheticLambda0;

    invoke-direct {v0, p0, p2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode$1$$ExternalSyntheticLambda0;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode$1;I)V

    invoke-interface {p1, v0}, Ljava/util/concurrent/Executor;->execute(Ljava/lang/Runnable;)V

    return-void
.end method

.method public onCaptureStarted(I)V
    .locals 1

    .line 107
    invoke-static {}, Landroidx/camera/core/impl/utils/executor/CameraXExecutors;->mainThreadExecutor()Ljava/util/concurrent/ScheduledExecutorService;

    move-result-object p1

    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode$1$$ExternalSyntheticLambda1;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode$1$$ExternalSyntheticLambda1;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/CaptureNode$1;)V

    invoke-interface {p1, v0}, Ljava/util/concurrent/Executor;->execute(Ljava/lang/Runnable;)V

    return-void
.end method
