.class public final Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$f;
.super Landroid/view/ScaleGestureDetector$SimpleOnScaleGestureListener;
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
    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$f;->a:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    invoke-direct {p0}, Landroid/view/ScaleGestureDetector$SimpleOnScaleGestureListener;-><init>()V

    return-void
.end method


# virtual methods
.method public final onScale(Landroid/view/ScaleGestureDetector;)Z
    .locals 2

    const-string v0, "detector"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {p1}, Landroid/view/ScaleGestureDetector;->getScaleFactor()F

    move-result p1

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$f;->a:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    .line 1
    iget-object v0, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->h:Landroidx/camera/core/Camera;

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
    const/4 v0, 0x0

    :goto_0
    if-eqz v0, :cond_1

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$f;->a:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    invoke-virtual {v0}, Ljava/lang/Float;->floatValue()F

    move-result v0

    mul-float/2addr v0, p1

    invoke-virtual {v1, v0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->zoomTo(F)V

    :cond_1
    const/4 p1, 0x1

    return p1
.end method
