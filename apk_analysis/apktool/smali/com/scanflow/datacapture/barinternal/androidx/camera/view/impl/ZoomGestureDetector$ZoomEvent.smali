.class public abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/view/impl/ZoomGestureDetector$ZoomEvent;
.super Ljava/lang/Object;
.source "ZoomGestureDetector.kt"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/view/impl/ZoomGestureDetector;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x409
    name = "ZoomEvent"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/androidx/camera/view/impl/ZoomGestureDetector$ZoomEvent$Begin;,
        Lcom/scanflow/datacapture/barinternal/androidx/camera/view/impl/ZoomGestureDetector$ZoomEvent$End;,
        Lcom/scanflow/datacapture/barinternal/androidx/camera/view/impl/ZoomGestureDetector$ZoomEvent$Move;
    }
.end annotation


# instance fields
.field private final eventTime:J

.field private final focusX:I

.field private final focusY:I


# direct methods
.method private constructor <init>(JII)V
    .locals 0

    .line 73
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 75
    iput-wide p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/view/impl/ZoomGestureDetector$ZoomEvent;->eventTime:J

    .line 76
    iput p3, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/view/impl/ZoomGestureDetector$ZoomEvent;->focusX:I

    .line 77
    iput p4, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/view/impl/ZoomGestureDetector$ZoomEvent;->focusY:I

    return-void
.end method

.method public synthetic constructor <init>(JIILkotlin/jvm/internal/DefaultConstructorMarker;)V
    .locals 0

    .line 0
    invoke-direct {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/androidx/camera/view/impl/ZoomGestureDetector$ZoomEvent;-><init>(JII)V

    return-void
.end method
