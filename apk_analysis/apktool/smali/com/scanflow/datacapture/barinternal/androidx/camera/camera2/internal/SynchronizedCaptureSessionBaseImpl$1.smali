.class Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSessionBaseImpl$1;
.super Ljava/lang/Object;
.source "SynchronizedCaptureSessionBaseImpl.java"

# interfaces
.implements Landroidx/camera/core/impl/utils/futures/FutureCallback;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSessionBaseImpl;->openCaptureSession(Landroid/hardware/camera2/CameraDevice;Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/SessionConfigurationCompat;Ljava/util/List;)Lcom/google/common/util/concurrent/ListenableFuture;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSessionBaseImpl;


# direct methods
.method constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSessionBaseImpl;)V
    .locals 0

    .line 163
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSessionBaseImpl$1;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSessionBaseImpl;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onFailure(Ljava/lang/Throwable;)V
    .locals 1

    .line 171
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSessionBaseImpl$1;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSessionBaseImpl;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSessionBaseImpl;->finishClose()V

    .line 172
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSessionBaseImpl$1;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSessionBaseImpl;

    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSessionBaseImpl;->mCaptureSessionRepository:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSessionRepository;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSessionRepository;->onCaptureSessionConfigureFail(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession;)V

    return-void
.end method

.method public bridge synthetic onSuccess(Ljava/lang/Object;)V
    .locals 0

    .line 163
    check-cast p1, Ljava/lang/Void;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSessionBaseImpl$1;->onSuccess(Ljava/lang/Void;)V

    return-void
.end method

.method public onSuccess(Ljava/lang/Void;)V
    .locals 0

    .line 167
    return-void
.end method
