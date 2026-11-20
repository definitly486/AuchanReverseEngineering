.class Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/ZoomControl$1;
.super Ljava/lang/Object;
.source "ZoomControl.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraControlImpl$CaptureResultListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/ZoomControl;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/ZoomControl;


# direct methods
.method constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/ZoomControl;)V
    .locals 0

    .line 181
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/ZoomControl$1;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/ZoomControl;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onCaptureResult(Landroid/hardware/camera2/TotalCaptureResult;)Z
    .locals 1

    .line 185
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/ZoomControl$1;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/ZoomControl;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/ZoomControl;->mZoomImpl:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/ZoomControl$ZoomImpl;

    invoke-interface {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/ZoomControl$ZoomImpl;->onCaptureResult(Landroid/hardware/camera2/TotalCaptureResult;)V

    const/4 p1, 0x0

    return p1
.end method
