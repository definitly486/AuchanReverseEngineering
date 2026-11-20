.class Lcom/zerobranch/layout/SwipeLayout$1;
.super Ljava/lang/Object;
.source "SwipeLayout.java"

# interfaces
.implements Landroid/view/View$OnTouchListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/zerobranch/layout/SwipeLayout;->enableTouchForViewGroup(Landroid/view/ViewGroup;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/zerobranch/layout/SwipeLayout;


# direct methods
.method constructor <init>(Lcom/zerobranch/layout/SwipeLayout;)V
    .locals 0

    .line 597
    iput-object p1, p0, Lcom/zerobranch/layout/SwipeLayout$1;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onTouch(Landroid/view/View;Landroid/view/MotionEvent;)Z
    .locals 0

    .line 600
    iget-object p1, p0, Lcom/zerobranch/layout/SwipeLayout$1;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    const/4 p2, 0x1

    invoke-virtual {p1, p2}, Lcom/zerobranch/layout/SwipeLayout;->requestDisallowInterceptTouchEvent(Z)V

    const/4 p1, 0x0

    return p1
.end method
