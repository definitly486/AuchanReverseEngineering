.class public final synthetic Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda0;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Landroid/view/View$OnTouchListener;


# instance fields
.field public final synthetic f$0:Landroid/view/GestureDetector;

.field public final synthetic f$1:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

.field public final synthetic f$2:Landroid/view/ScaleGestureDetector;


# direct methods
.method public synthetic constructor <init>(Landroid/view/GestureDetector;Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;Landroid/view/ScaleGestureDetector;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda0;->f$0:Landroid/view/GestureDetector;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda0;->f$1:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda0;->f$2:Landroid/view/ScaleGestureDetector;

    return-void
.end method


# virtual methods
.method public final onTouch(Landroid/view/View;Landroid/view/MotionEvent;)Z
    .locals 3

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda0;->f$0:Landroid/view/GestureDetector;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda0;->f$1:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda0;->f$2:Landroid/view/ScaleGestureDetector;

    invoke-static {v0, v1, v2, p1, p2}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a(Landroid/view/GestureDetector;Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;Landroid/view/ScaleGestureDetector;Landroid/view/View;Landroid/view/MotionEvent;)Z

    move-result p1

    return p1
.end method
