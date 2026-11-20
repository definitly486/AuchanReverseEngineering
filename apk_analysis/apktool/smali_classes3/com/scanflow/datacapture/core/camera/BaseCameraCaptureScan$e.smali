.class public final Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$e;
.super Landroid/view/GestureDetector$SimpleOnGestureListener;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;-><init>(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/sfbarcode/SFCameraView;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = null
.end annotation


# instance fields
.field public final synthetic a:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan<",
            "TT;>;"
        }
    .end annotation
.end field


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan<",
            "TT;>;)V"
        }
    .end annotation

    .line 0
    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$e;->a:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    invoke-direct {p0}, Landroid/view/GestureDetector$SimpleOnGestureListener;-><init>()V

    return-void
.end method


# virtual methods
.method public final onDoubleTap(Landroid/view/MotionEvent;)Z
    .locals 5

    const-string v0, "e"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    sget-object v0, Lcom/scanflow/datacapture/utils/ScanflowLog;->INSTANCE:Lcom/scanflow/datacapture/utils/ScanflowLog;

    const-string v1, "XXX onGesture"

    const-string v2, "onDoubleTap"

    invoke-virtual {v0, v1, v2}, Lcom/scanflow/datacapture/utils/ScanflowLog;->e(Ljava/lang/String;Ljava/lang/String;)V

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$e;->a:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    .line 1
    iget-object v0, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->h:Landroidx/camera/core/Camera;

    const/4 v1, 0x0

    if-eqz v0, :cond_0

    .line 2
    invoke-interface {v0}, Landroidx/camera/core/Camera;->getCameraInfo()Landroidx/camera/core/CameraInfo;

    move-result-object v0

    if-eqz v0, :cond_0

    invoke-interface {v0}, Landroidx/camera/core/CameraInfo;->getZoomState()Landroidx/lifecycle/LiveData;

    move-result-object v0

    if-eqz v0, :cond_0

    invoke-virtual {v0}, Landroidx/lifecycle/LiveData;->getValue()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroidx/camera/core/ZoomState;

    if-eqz v0, :cond_0

    invoke-interface {v0}, Landroidx/camera/core/ZoomState;->getZoomRatio()F

    move-result v0

    invoke-static {v0}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v0

    goto :goto_0

    :cond_0
    move-object v0, v1

    :goto_0
    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$e;->a:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    .line 3
    iget-object v2, v2, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->h:Landroidx/camera/core/Camera;

    if-eqz v2, :cond_1

    .line 4
    invoke-interface {v2}, Landroidx/camera/core/Camera;->getCameraInfo()Landroidx/camera/core/CameraInfo;

    move-result-object v2

    if-eqz v2, :cond_1

    invoke-interface {v2}, Landroidx/camera/core/CameraInfo;->getZoomState()Landroidx/lifecycle/LiveData;

    move-result-object v2

    if-eqz v2, :cond_1

    invoke-virtual {v2}, Landroidx/lifecycle/LiveData;->getValue()Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Landroidx/camera/core/ZoomState;

    if-eqz v2, :cond_1

    invoke-interface {v2}, Landroidx/camera/core/ZoomState;->getMinZoomRatio()F

    move-result v2

    invoke-static {v2}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v2

    goto :goto_1

    :cond_1
    move-object v2, v1

    :goto_1
    iget-object v3, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$e;->a:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    .line 5
    iget-object v3, v3, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->h:Landroidx/camera/core/Camera;

    if-eqz v3, :cond_2

    .line 6
    invoke-interface {v3}, Landroidx/camera/core/Camera;->getCameraInfo()Landroidx/camera/core/CameraInfo;

    move-result-object v3

    if-eqz v3, :cond_2

    invoke-interface {v3}, Landroidx/camera/core/CameraInfo;->getZoomState()Landroidx/lifecycle/LiveData;

    move-result-object v3

    if-eqz v3, :cond_2

    invoke-virtual {v3}, Landroidx/lifecycle/LiveData;->getValue()Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Landroidx/camera/core/ZoomState;

    if-eqz v3, :cond_2

    invoke-interface {v3}, Landroidx/camera/core/ZoomState;->getMaxZoomRatio()F

    move-result v1

    invoke-static {v1}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v1

    :cond_2
    if-eqz v0, :cond_5

    if-eqz v1, :cond_5

    if-eqz v2, :cond_5

    invoke-virtual {v0}, Ljava/lang/Float;->floatValue()F

    move-result v3

    invoke-virtual {v2}, Ljava/lang/Float;->floatValue()F

    move-result v4

    cmpl-float v3, v3, v4

    if-gtz v3, :cond_4

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Float;Ljava/lang/Float;)Z

    move-result v0

    if-eqz v0, :cond_3

    goto :goto_2

    :cond_3
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$e;->a:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    .line 7
    iget-object v0, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->h:Landroidx/camera/core/Camera;

    if-eqz v0, :cond_5

    .line 8
    invoke-interface {v0}, Landroidx/camera/core/Camera;->getCameraControl()Landroidx/camera/core/CameraControl;

    move-result-object v0

    if-eqz v0, :cond_5

    invoke-virtual {v1}, Ljava/lang/Float;->floatValue()F

    move-result v1

    invoke-interface {v0, v1}, Landroidx/camera/core/CameraControl;->setZoomRatio(F)Lcom/google/common/util/concurrent/ListenableFuture;

    goto :goto_3

    :cond_4
    :goto_2
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$e;->a:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    .line 9
    iget-object v0, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->h:Landroidx/camera/core/Camera;

    if-eqz v0, :cond_5

    .line 10
    invoke-interface {v0}, Landroidx/camera/core/Camera;->getCameraControl()Landroidx/camera/core/CameraControl;

    move-result-object v0

    if-eqz v0, :cond_5

    invoke-virtual {v2}, Ljava/lang/Float;->floatValue()F

    move-result v1

    invoke-interface {v0, v1}, Landroidx/camera/core/CameraControl;->setZoomRatio(F)Lcom/google/common/util/concurrent/ListenableFuture;

    :cond_5
    :goto_3
    invoke-super {p0, p1}, Landroid/view/GestureDetector$SimpleOnGestureListener;->onDoubleTap(Landroid/view/MotionEvent;)Z

    move-result p1

    return p1
.end method
