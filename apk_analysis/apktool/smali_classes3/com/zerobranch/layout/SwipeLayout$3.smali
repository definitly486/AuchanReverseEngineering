.class Lcom/zerobranch/layout/SwipeLayout$3;
.super Landroidx/customview/widget/ViewDragHelper$Callback;
.source "SwipeLayout.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/zerobranch/layout/SwipeLayout;
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

    .line 641
    iput-object p1, p0, Lcom/zerobranch/layout/SwipeLayout$3;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-direct {p0}, Landroidx/customview/widget/ViewDragHelper$Callback;-><init>()V

    return-void
.end method


# virtual methods
.method public clampViewPositionHorizontal(Landroid/view/View;II)I
    .locals 2

    .line 682
    iget-object p1, p0, Lcom/zerobranch/layout/SwipeLayout$3;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {p1}, Lcom/zerobranch/layout/SwipeLayout;->access$1000(Lcom/zerobranch/layout/SwipeLayout;)Z

    move-result p1

    const/4 v0, 0x0

    if-nez p1, :cond_0

    return v0

    .line 686
    :cond_0
    iget-object p1, p0, Lcom/zerobranch/layout/SwipeLayout$3;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {p1}, Lcom/zerobranch/layout/SwipeLayout;->access$500(Lcom/zerobranch/layout/SwipeLayout;)I

    move-result p1

    const/4 v1, 0x1

    if-eq p1, v1, :cond_3

    const/4 v1, 0x2

    if-eq p1, v1, :cond_2

    const/4 v1, 0x3

    if-eq p1, v1, :cond_1

    return v0

    .line 692
    :cond_1
    iget-object p1, p0, Lcom/zerobranch/layout/SwipeLayout$3;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {p1, p2, p3}, Lcom/zerobranch/layout/SwipeLayout;->access$1300(Lcom/zerobranch/layout/SwipeLayout;II)I

    move-result p1

    return p1

    .line 690
    :cond_2
    iget-object p1, p0, Lcom/zerobranch/layout/SwipeLayout$3;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {p1, p2}, Lcom/zerobranch/layout/SwipeLayout;->access$1200(Lcom/zerobranch/layout/SwipeLayout;I)I

    move-result p1

    return p1

    .line 688
    :cond_3
    iget-object p1, p0, Lcom/zerobranch/layout/SwipeLayout$3;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {p1, p2}, Lcom/zerobranch/layout/SwipeLayout;->access$1100(Lcom/zerobranch/layout/SwipeLayout;I)I

    move-result p1

    return p1
.end method

.method public getViewHorizontalDragRange(Landroid/view/View;)I
    .locals 0

    .line 672
    iget-object p1, p0, Lcom/zerobranch/layout/SwipeLayout$3;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {p1}, Lcom/zerobranch/layout/SwipeLayout;->access$800(Lcom/zerobranch/layout/SwipeLayout;)I

    move-result p1

    return p1
.end method

.method public onViewDragStateChanged(I)V
    .locals 1

    .line 644
    iget-object v0, p0, Lcom/zerobranch/layout/SwipeLayout$3;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {v0}, Lcom/zerobranch/layout/SwipeLayout;->access$000(Lcom/zerobranch/layout/SwipeLayout;)I

    move-result v0

    if-ne p1, v0, :cond_0

    return-void

    .line 647
    :cond_0
    iget-object v0, p0, Lcom/zerobranch/layout/SwipeLayout$3;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {v0, p1}, Lcom/zerobranch/layout/SwipeLayout;->access$100(Lcom/zerobranch/layout/SwipeLayout;I)Z

    move-result v0

    if-eqz v0, :cond_1

    .line 648
    iget-object v0, p0, Lcom/zerobranch/layout/SwipeLayout$3;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {v0}, Lcom/zerobranch/layout/SwipeLayout;->access$200(Lcom/zerobranch/layout/SwipeLayout;)V

    .line 651
    :cond_1
    iget-object v0, p0, Lcom/zerobranch/layout/SwipeLayout$3;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {v0, p1}, Lcom/zerobranch/layout/SwipeLayout;->access$002(Lcom/zerobranch/layout/SwipeLayout;I)I

    return-void
.end method

.method public onViewPositionChanged(Landroid/view/View;IIII)V
    .locals 0

    .line 656
    iget-object p1, p0, Lcom/zerobranch/layout/SwipeLayout$3;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {p1, p2}, Lcom/zerobranch/layout/SwipeLayout;->access$302(Lcom/zerobranch/layout/SwipeLayout;I)I

    .line 658
    iget-object p1, p0, Lcom/zerobranch/layout/SwipeLayout$3;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {p1}, Lcom/zerobranch/layout/SwipeLayout;->access$400(Lcom/zerobranch/layout/SwipeLayout;)Z

    move-result p1

    if-eqz p1, :cond_2

    .line 659
    iget-object p1, p0, Lcom/zerobranch/layout/SwipeLayout$3;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {p1}, Lcom/zerobranch/layout/SwipeLayout;->access$500(Lcom/zerobranch/layout/SwipeLayout;)I

    move-result p1

    const/4 p2, 0x1

    if-ne p1, p2, :cond_0

    .line 660
    iget-object p1, p0, Lcom/zerobranch/layout/SwipeLayout$3;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {p1}, Lcom/zerobranch/layout/SwipeLayout;->access$600(Lcom/zerobranch/layout/SwipeLayout;)Landroid/view/View;

    move-result-object p1

    invoke-virtual {p1, p4}, Landroid/view/View;->offsetLeftAndRight(I)V

    return-void

    .line 661
    :cond_0
    iget-object p1, p0, Lcom/zerobranch/layout/SwipeLayout$3;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {p1}, Lcom/zerobranch/layout/SwipeLayout;->access$500(Lcom/zerobranch/layout/SwipeLayout;)I

    move-result p1

    const/4 p2, 0x2

    if-ne p1, p2, :cond_1

    .line 662
    iget-object p1, p0, Lcom/zerobranch/layout/SwipeLayout$3;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {p1}, Lcom/zerobranch/layout/SwipeLayout;->access$700(Lcom/zerobranch/layout/SwipeLayout;)Landroid/view/View;

    move-result-object p1

    invoke-virtual {p1, p4}, Landroid/view/View;->offsetLeftAndRight(I)V

    return-void

    .line 663
    :cond_1
    iget-object p1, p0, Lcom/zerobranch/layout/SwipeLayout$3;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {p1}, Lcom/zerobranch/layout/SwipeLayout;->access$500(Lcom/zerobranch/layout/SwipeLayout;)I

    move-result p1

    const/4 p2, 0x3

    if-ne p1, p2, :cond_2

    .line 664
    iget-object p1, p0, Lcom/zerobranch/layout/SwipeLayout$3;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {p1}, Lcom/zerobranch/layout/SwipeLayout;->access$700(Lcom/zerobranch/layout/SwipeLayout;)Landroid/view/View;

    move-result-object p1

    invoke-virtual {p1, p4}, Landroid/view/View;->offsetLeftAndRight(I)V

    .line 665
    iget-object p1, p0, Lcom/zerobranch/layout/SwipeLayout$3;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {p1}, Lcom/zerobranch/layout/SwipeLayout;->access$600(Lcom/zerobranch/layout/SwipeLayout;)Landroid/view/View;

    move-result-object p1

    invoke-virtual {p1, p4}, Landroid/view/View;->offsetLeftAndRight(I)V

    :cond_2
    return-void
.end method

.method public onViewReleased(Landroid/view/View;FF)V
    .locals 0

    .line 702
    iget-object p1, p0, Lcom/zerobranch/layout/SwipeLayout$3;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {p1}, Lcom/zerobranch/layout/SwipeLayout;->access$500(Lcom/zerobranch/layout/SwipeLayout;)I

    move-result p1

    const/4 p3, 0x1

    if-ne p1, p3, :cond_0

    .line 703
    iget-object p1, p0, Lcom/zerobranch/layout/SwipeLayout$3;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {p1, p2}, Lcom/zerobranch/layout/SwipeLayout;->access$1400(Lcom/zerobranch/layout/SwipeLayout;F)I

    move-result p1

    goto :goto_0

    .line 704
    :cond_0
    iget-object p1, p0, Lcom/zerobranch/layout/SwipeLayout$3;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {p1}, Lcom/zerobranch/layout/SwipeLayout;->access$500(Lcom/zerobranch/layout/SwipeLayout;)I

    move-result p1

    const/4 p3, 0x2

    if-ne p1, p3, :cond_1

    .line 705
    iget-object p1, p0, Lcom/zerobranch/layout/SwipeLayout$3;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {p1, p2}, Lcom/zerobranch/layout/SwipeLayout;->access$1500(Lcom/zerobranch/layout/SwipeLayout;F)I

    move-result p1

    goto :goto_0

    .line 706
    :cond_1
    iget-object p1, p0, Lcom/zerobranch/layout/SwipeLayout$3;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {p1}, Lcom/zerobranch/layout/SwipeLayout;->access$500(Lcom/zerobranch/layout/SwipeLayout;)I

    move-result p1

    const/4 p3, 0x3

    if-ne p1, p3, :cond_2

    .line 707
    iget-object p1, p0, Lcom/zerobranch/layout/SwipeLayout$3;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {p1, p2}, Lcom/zerobranch/layout/SwipeLayout;->access$1600(Lcom/zerobranch/layout/SwipeLayout;F)I

    move-result p1

    const/4 p2, -0x1

    if-ne p1, p2, :cond_3

    .line 710
    iget-object p1, p0, Lcom/zerobranch/layout/SwipeLayout$3;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {p1}, Lcom/zerobranch/layout/SwipeLayout;->access$1700(Lcom/zerobranch/layout/SwipeLayout;)I

    move-result p1

    goto :goto_0

    :cond_2
    const/4 p1, 0x0

    .line 714
    :cond_3
    :goto_0
    iget-object p2, p0, Lcom/zerobranch/layout/SwipeLayout$3;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {p2}, Lcom/zerobranch/layout/SwipeLayout;->access$1800(Lcom/zerobranch/layout/SwipeLayout;)Landroidx/customview/widget/ViewDragHelper;

    move-result-object p2

    iget-object p3, p0, Lcom/zerobranch/layout/SwipeLayout$3;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {p3}, Lcom/zerobranch/layout/SwipeLayout;->access$900(Lcom/zerobranch/layout/SwipeLayout;)Landroid/view/View;

    move-result-object p3

    invoke-virtual {p3}, Landroid/view/View;->getTop()I

    move-result p3

    invoke-virtual {p2, p1, p3}, Landroidx/customview/widget/ViewDragHelper;->settleCapturedViewAt(II)Z

    move-result p1

    if-eqz p1, :cond_4

    .line 715
    iget-object p1, p0, Lcom/zerobranch/layout/SwipeLayout$3;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {p1}, Landroidx/core/view/ViewCompat;->postInvalidateOnAnimation(Landroid/view/View;)V

    :cond_4
    return-void
.end method

.method public tryCaptureView(Landroid/view/View;I)Z
    .locals 0

    .line 677
    invoke-virtual {p1}, Landroid/view/View;->getId()I

    move-result p1

    iget-object p2, p0, Lcom/zerobranch/layout/SwipeLayout$3;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {p2}, Lcom/zerobranch/layout/SwipeLayout;->access$900(Lcom/zerobranch/layout/SwipeLayout;)Landroid/view/View;

    move-result-object p2

    invoke-virtual {p2}, Landroid/view/View;->getId()I

    move-result p2

    if-ne p1, p2, :cond_0

    const/4 p1, 0x1

    return p1

    :cond_0
    const/4 p1, 0x0

    return p1
.end method
