.class public final Lcom/scanflow/datacapture/barinternal/androidx/camera/view/impl/ZoomGestureDetector$gestureDetector$1;
.super Landroid/view/GestureDetector$SimpleOnGestureListener;
.source "ZoomGestureDetector.kt"


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/view/impl/ZoomGestureDetector;-><init>(Landroid/content/Context;IILcom/scanflow/datacapture/barinternal/androidx/camera/view/impl/ZoomGestureDetector$OnZoomGestureListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/view/impl/ZoomGestureDetector;


# direct methods
.method constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/view/impl/ZoomGestureDetector;)V
    .locals 0

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/view/impl/ZoomGestureDetector$gestureDetector$1;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/view/impl/ZoomGestureDetector;

    .line 244
    invoke-direct {p0}, Landroid/view/GestureDetector$SimpleOnGestureListener;-><init>()V

    return-void
.end method


# virtual methods
.method public onDoubleTap(Landroid/view/MotionEvent;)Z
    .locals 2

    const-string v0, "e"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 247
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/view/impl/ZoomGestureDetector$gestureDetector$1;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/view/impl/ZoomGestureDetector;

    invoke-virtual {p1}, Landroid/view/MotionEvent;->getX()F

    move-result v1

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/view/impl/ZoomGestureDetector;->access$setAnchoredZoomStartX$p(Lcom/scanflow/datacapture/barinternal/androidx/camera/view/impl/ZoomGestureDetector;F)V

    .line 248
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/view/impl/ZoomGestureDetector$gestureDetector$1;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/view/impl/ZoomGestureDetector;

    invoke-virtual {p1}, Landroid/view/MotionEvent;->getY()F

    move-result p1

    invoke-static {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/view/impl/ZoomGestureDetector;->access$setAnchoredZoomStartY$p(Lcom/scanflow/datacapture/barinternal/androidx/camera/view/impl/ZoomGestureDetector;F)V

    .line 249
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/view/impl/ZoomGestureDetector$gestureDetector$1;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/view/impl/ZoomGestureDetector;

    const/4 v0, 0x1

    invoke-static {p1, v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/view/impl/ZoomGestureDetector;->access$setAnchoredZoomMode$p(Lcom/scanflow/datacapture/barinternal/androidx/camera/view/impl/ZoomGestureDetector;I)V

    return v0
.end method
