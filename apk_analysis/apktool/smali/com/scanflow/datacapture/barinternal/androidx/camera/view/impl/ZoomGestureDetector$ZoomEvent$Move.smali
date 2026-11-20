.class public final Lcom/scanflow/datacapture/barinternal/androidx/camera/view/impl/ZoomGestureDetector$ZoomEvent$Move;
.super Lcom/scanflow/datacapture/barinternal/androidx/camera/view/impl/ZoomGestureDetector$ZoomEvent;
.source "ZoomGestureDetector.kt"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/view/impl/ZoomGestureDetector$ZoomEvent;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Move"
.end annotation


# instance fields
.field private final incrementalScaleFactor:F


# direct methods
.method public constructor <init>(JIIF)V
    .locals 6

    const/4 v5, 0x0

    move-object v0, p0

    move-wide v1, p1

    move v3, p3

    move v4, p4

    .line 109
    invoke-direct/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/androidx/camera/view/impl/ZoomGestureDetector$ZoomEvent;-><init>(JIILkotlin/jvm/internal/DefaultConstructorMarker;)V

    .line 108
    iput p5, v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/view/impl/ZoomGestureDetector$ZoomEvent$Move;->incrementalScaleFactor:F

    return-void
.end method


# virtual methods
.method public final getIncrementalScaleFactor()F
    .locals 1

    .line 108
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/view/impl/ZoomGestureDetector$ZoomEvent$Move;->incrementalScaleFactor:F

    return v0
.end method
