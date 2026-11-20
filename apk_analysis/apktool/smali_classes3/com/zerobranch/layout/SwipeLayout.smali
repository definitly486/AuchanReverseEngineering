.class public Lcom/zerobranch/layout/SwipeLayout;
.super Landroid/widget/FrameLayout;
.source "SwipeLayout.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/zerobranch/layout/SwipeLayout$SwipeActionsListener;
    }
.end annotation


# static fields
.field private static final CLOSE_POSITION:I = 0x0

.field private static final DEFAULT_AUTO_OPEN_SPEED:I = 0x3e8

.field public static final HORIZONTAL:I = 0x3

.field public static final LEFT:I = 0x1

.field private static final NO_POSITION:I = -0x1

.field public static final RIGHT:I = 0x2


# instance fields
.field private actionsListener:Lcom/zerobranch/layout/SwipeLayout$SwipeActionsListener;

.field private autoOpenSpeed:D

.field private currentDirection:I

.field private currentDraggingState:I

.field private disallowIntercept:Z

.field private dragHelper:Landroidx/customview/widget/ViewDragHelper;

.field private final dragHelperCallback:Landroidx/customview/widget/ViewDragHelper$Callback;

.field private draggedView:Landroid/view/View;

.field private draggedViewId:I

.field private draggingViewLeft:I

.field private gestureDetector:Landroidx/core/view/GestureDetectorCompat;

.field private gestureDetectorCallBack:Landroid/view/GestureDetector$OnGestureListener;

.field private horizontalWidth:I

.field private isContinuousSwipe:Z

.field private isEnabledSwipe:Z

.field private isFreeDragAfterOpen:Z

.field private isFreeHorizontalDrag:Z

.field private isLeftOpen:Z

.field private isRightOpen:Z

.field private isTogether:Z

.field private leftDragViewPadding:I

.field private rightDragViewPadding:I

.field private staticLeftView:Landroid/view/View;

.field private staticLeftViewId:I

.field private staticRightView:Landroid/view/View;

.field private staticRightViewId:I


# direct methods
.method public constructor <init>(Landroid/content/Context;Landroid/util/AttributeSet;)V
    .locals 2

    .line 139
    invoke-direct {p0, p1, p2}, Landroid/widget/FrameLayout;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;)V

    const/4 p1, 0x0

    .line 123
    iput p1, p0, Lcom/zerobranch/layout/SwipeLayout;->currentDraggingState:I

    .line 631
    new-instance v0, Lcom/zerobranch/layout/SwipeLayout$2;

    invoke-direct {v0, p0}, Lcom/zerobranch/layout/SwipeLayout$2;-><init>(Lcom/zerobranch/layout/SwipeLayout;)V

    iput-object v0, p0, Lcom/zerobranch/layout/SwipeLayout;->gestureDetectorCallBack:Landroid/view/GestureDetector$OnGestureListener;

    .line 641
    new-instance v0, Lcom/zerobranch/layout/SwipeLayout$3;

    invoke-direct {v0, p0}, Lcom/zerobranch/layout/SwipeLayout$3;-><init>(Lcom/zerobranch/layout/SwipeLayout;)V

    iput-object v0, p0, Lcom/zerobranch/layout/SwipeLayout;->dragHelperCallback:Landroidx/customview/widget/ViewDragHelper$Callback;

    .line 140
    iput-boolean p1, p0, Lcom/zerobranch/layout/SwipeLayout;->isLeftOpen:Z

    .line 141
    iput-boolean p1, p0, Lcom/zerobranch/layout/SwipeLayout;->isRightOpen:Z

    .line 143
    invoke-virtual {p0}, Landroid/view/View;->getContext()Landroid/content/Context;

    move-result-object v0

    sget-object v1, Lcom/zerobranch/layout/R$styleable;->SwipeLayout:[I

    invoke-virtual {v0, p2, v1}, Landroid/content/Context;->obtainStyledAttributes(Landroid/util/AttributeSet;[I)Landroid/content/res/TypedArray;

    move-result-object p2

    .line 144
    sget v0, Lcom/zerobranch/layout/R$styleable;->SwipeLayout_swipeDirection:I

    const/4 v1, 0x1

    invoke-virtual {p2, v0, v1}, Landroid/content/res/TypedArray;->getInteger(II)I

    move-result v0

    iput v0, p0, Lcom/zerobranch/layout/SwipeLayout;->currentDirection:I

    .line 145
    sget v0, Lcom/zerobranch/layout/R$styleable;->SwipeLayout_isFreeDragAfterOpen:I

    invoke-virtual {p2, v0, p1}, Landroid/content/res/TypedArray;->getBoolean(IZ)Z

    move-result v0

    iput-boolean v0, p0, Lcom/zerobranch/layout/SwipeLayout;->isFreeDragAfterOpen:Z

    .line 146
    sget v0, Lcom/zerobranch/layout/R$styleable;->SwipeLayout_isFreeHorizontalDrag:I

    invoke-virtual {p2, v0, p1}, Landroid/content/res/TypedArray;->getBoolean(IZ)Z

    move-result v0

    iput-boolean v0, p0, Lcom/zerobranch/layout/SwipeLayout;->isFreeHorizontalDrag:Z

    .line 147
    sget v0, Lcom/zerobranch/layout/R$styleable;->SwipeLayout_isContinuousSwipe:I

    invoke-virtual {p2, v0, p1}, Landroid/content/res/TypedArray;->getBoolean(IZ)Z

    move-result v0

    iput-boolean v0, p0, Lcom/zerobranch/layout/SwipeLayout;->isContinuousSwipe:Z

    .line 148
    sget v0, Lcom/zerobranch/layout/R$styleable;->SwipeLayout_isTogether:I

    invoke-virtual {p2, v0, p1}, Landroid/content/res/TypedArray;->getBoolean(IZ)Z

    move-result v0

    iput-boolean v0, p0, Lcom/zerobranch/layout/SwipeLayout;->isTogether:Z

    .line 149
    sget v0, Lcom/zerobranch/layout/R$styleable;->SwipeLayout_isEnabledSwipe:I

    invoke-virtual {p2, v0, v1}, Landroid/content/res/TypedArray;->getBoolean(IZ)Z

    move-result v0

    iput-boolean v0, p0, Lcom/zerobranch/layout/SwipeLayout;->isEnabledSwipe:Z

    .line 150
    sget v0, Lcom/zerobranch/layout/R$styleable;->SwipeLayout_leftItem:I

    invoke-virtual {p2, v0, p1}, Landroid/content/res/TypedArray;->getResourceId(II)I

    move-result v0

    iput v0, p0, Lcom/zerobranch/layout/SwipeLayout;->staticLeftViewId:I

    .line 151
    sget v0, Lcom/zerobranch/layout/R$styleable;->SwipeLayout_rightItem:I

    invoke-virtual {p2, v0, p1}, Landroid/content/res/TypedArray;->getResourceId(II)I

    move-result v0

    iput v0, p0, Lcom/zerobranch/layout/SwipeLayout;->staticRightViewId:I

    .line 152
    sget v0, Lcom/zerobranch/layout/R$styleable;->SwipeLayout_draggedItem:I

    invoke-virtual {p2, v0, p1}, Landroid/content/res/TypedArray;->getResourceId(II)I

    move-result p1

    iput p1, p0, Lcom/zerobranch/layout/SwipeLayout;->draggedViewId:I

    .line 153
    sget p1, Lcom/zerobranch/layout/R$styleable;->SwipeLayout_autoMovingSensitivity:I

    const/16 v0, 0x3e8

    invoke-virtual {p2, p1, v0}, Landroid/content/res/TypedArray;->getInt(II)I

    move-result p1

    int-to-double v0, p1

    iput-wide v0, p0, Lcom/zerobranch/layout/SwipeLayout;->autoOpenSpeed:D

    .line 154
    sget p1, Lcom/zerobranch/layout/R$styleable;->SwipeLayout_rightDragViewPadding:I

    const/4 v0, 0x0

    invoke-virtual {p2, p1, v0}, Landroid/content/res/TypedArray;->getDimension(IF)F

    move-result p1

    float-to-int p1, p1

    iput p1, p0, Lcom/zerobranch/layout/SwipeLayout;->rightDragViewPadding:I

    .line 155
    sget p1, Lcom/zerobranch/layout/R$styleable;->SwipeLayout_leftDragViewPadding:I

    invoke-virtual {p2, p1, v0}, Landroid/content/res/TypedArray;->getDimension(IF)F

    move-result p1

    float-to-int p1, p1

    iput p1, p0, Lcom/zerobranch/layout/SwipeLayout;->leftDragViewPadding:I

    .line 157
    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->parametersAdjustment()V

    .line 158
    invoke-virtual {p2}, Landroid/content/res/TypedArray;->recycle()V

    return-void
.end method

.method static synthetic access$000(Lcom/zerobranch/layout/SwipeLayout;)I
    .locals 0

    .line 51
    iget p0, p0, Lcom/zerobranch/layout/SwipeLayout;->currentDraggingState:I

    return p0
.end method

.method static synthetic access$002(Lcom/zerobranch/layout/SwipeLayout;I)I
    .locals 0

    .line 51
    iput p1, p0, Lcom/zerobranch/layout/SwipeLayout;->currentDraggingState:I

    return p1
.end method

.method static synthetic access$100(Lcom/zerobranch/layout/SwipeLayout;I)Z
    .locals 0

    .line 51
    invoke-direct {p0, p1}, Lcom/zerobranch/layout/SwipeLayout;->isIdleAfterMoving(I)Z

    move-result p0

    return p0
.end method

.method static synthetic access$1000(Lcom/zerobranch/layout/SwipeLayout;)Z
    .locals 0

    .line 51
    iget-boolean p0, p0, Lcom/zerobranch/layout/SwipeLayout;->isEnabledSwipe:Z

    return p0
.end method

.method static synthetic access$1100(Lcom/zerobranch/layout/SwipeLayout;I)I
    .locals 0

    .line 51
    invoke-direct {p0, p1}, Lcom/zerobranch/layout/SwipeLayout;->clampLeftViewPosition(I)I

    move-result p0

    return p0
.end method

.method static synthetic access$1200(Lcom/zerobranch/layout/SwipeLayout;I)I
    .locals 0

    .line 51
    invoke-direct {p0, p1}, Lcom/zerobranch/layout/SwipeLayout;->clampRightViewPosition(I)I

    move-result p0

    return p0
.end method

.method static synthetic access$1300(Lcom/zerobranch/layout/SwipeLayout;II)I
    .locals 0

    .line 51
    invoke-direct {p0, p1, p2}, Lcom/zerobranch/layout/SwipeLayout;->clampHorizontalViewPosition(II)I

    move-result p0

    return p0
.end method

.method static synthetic access$1400(Lcom/zerobranch/layout/SwipeLayout;F)I
    .locals 0

    .line 51
    invoke-direct {p0, p1}, Lcom/zerobranch/layout/SwipeLayout;->getFinalXLeftDirection(F)I

    move-result p0

    return p0
.end method

.method static synthetic access$1500(Lcom/zerobranch/layout/SwipeLayout;F)I
    .locals 0

    .line 51
    invoke-direct {p0, p1}, Lcom/zerobranch/layout/SwipeLayout;->getFinalXRightDirection(F)I

    move-result p0

    return p0
.end method

.method static synthetic access$1600(Lcom/zerobranch/layout/SwipeLayout;F)I
    .locals 0

    .line 51
    invoke-direct {p0, p1}, Lcom/zerobranch/layout/SwipeLayout;->getFinalXHorizontalDirection(F)I

    move-result p0

    return p0
.end method

.method static synthetic access$1700(Lcom/zerobranch/layout/SwipeLayout;)I
    .locals 0

    .line 51
    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->getPreviousPosition()I

    move-result p0

    return p0
.end method

.method static synthetic access$1800(Lcom/zerobranch/layout/SwipeLayout;)Landroidx/customview/widget/ViewDragHelper;
    .locals 0

    .line 51
    iget-object p0, p0, Lcom/zerobranch/layout/SwipeLayout;->dragHelper:Landroidx/customview/widget/ViewDragHelper;

    return-object p0
.end method

.method static synthetic access$200(Lcom/zerobranch/layout/SwipeLayout;)V
    .locals 0

    .line 51
    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->updateState()V

    return-void
.end method

.method static synthetic access$302(Lcom/zerobranch/layout/SwipeLayout;I)I
    .locals 0

    .line 51
    iput p1, p0, Lcom/zerobranch/layout/SwipeLayout;->draggingViewLeft:I

    return p1
.end method

.method static synthetic access$400(Lcom/zerobranch/layout/SwipeLayout;)Z
    .locals 0

    .line 51
    iget-boolean p0, p0, Lcom/zerobranch/layout/SwipeLayout;->isTogether:Z

    return p0
.end method

.method static synthetic access$500(Lcom/zerobranch/layout/SwipeLayout;)I
    .locals 0

    .line 51
    iget p0, p0, Lcom/zerobranch/layout/SwipeLayout;->currentDirection:I

    return p0
.end method

.method static synthetic access$600(Lcom/zerobranch/layout/SwipeLayout;)Landroid/view/View;
    .locals 0

    .line 51
    iget-object p0, p0, Lcom/zerobranch/layout/SwipeLayout;->staticRightView:Landroid/view/View;

    return-object p0
.end method

.method static synthetic access$700(Lcom/zerobranch/layout/SwipeLayout;)Landroid/view/View;
    .locals 0

    .line 51
    iget-object p0, p0, Lcom/zerobranch/layout/SwipeLayout;->staticLeftView:Landroid/view/View;

    return-object p0
.end method

.method static synthetic access$800(Lcom/zerobranch/layout/SwipeLayout;)I
    .locals 0

    .line 51
    iget p0, p0, Lcom/zerobranch/layout/SwipeLayout;->horizontalWidth:I

    return p0
.end method

.method static synthetic access$900(Lcom/zerobranch/layout/SwipeLayout;)Landroid/view/View;
    .locals 0

    .line 51
    iget-object p0, p0, Lcom/zerobranch/layout/SwipeLayout;->draggedView:Landroid/view/View;

    return-object p0
.end method

.method private clampHorizontalViewPosition(II)I
    .locals 3

    .line 769
    iget-boolean v0, p0, Lcom/zerobranch/layout/SwipeLayout;->isFreeHorizontalDrag:Z

    const/4 v1, 0x0

    if-nez v0, :cond_0

    iget-boolean v2, p0, Lcom/zerobranch/layout/SwipeLayout;->isLeftOpen:Z

    if-eqz v2, :cond_0

    if-gez p2, :cond_0

    .line 770
    invoke-static {p1, v1}, Ljava/lang/Math;->max(II)I

    move-result p1

    return p1

    :cond_0
    if-nez v0, :cond_1

    .line 773
    iget-boolean v0, p0, Lcom/zerobranch/layout/SwipeLayout;->isRightOpen:Z

    if-eqz v0, :cond_1

    if-lez p2, :cond_1

    .line 774
    invoke-static {p1, v1}, Ljava/lang/Math;->min(II)I

    move-result p1

    return p1

    .line 777
    :cond_1
    iget-boolean p2, p0, Lcom/zerobranch/layout/SwipeLayout;->isFreeDragAfterOpen:Z

    if-nez p2, :cond_2

    if-lez p1, :cond_2

    .line 778
    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->getLeftViewWidth()I

    move-result p2

    invoke-static {p1, p2}, Ljava/lang/Math;->min(II)I

    move-result p1

    return p1

    :cond_2
    if-nez p2, :cond_3

    if-gez p1, :cond_3

    .line 782
    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->getRightViewWidth()I

    move-result p2

    neg-int p2, p2

    invoke-static {p1, p2}, Ljava/lang/Math;->max(II)I

    move-result p1

    return p1

    :cond_3
    if-gez p1, :cond_4

    .line 785
    iget p2, p0, Lcom/zerobranch/layout/SwipeLayout;->leftDragViewPadding:I

    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->horizontalWidth:I

    sub-int/2addr p2, v0

    invoke-static {p1, p2}, Ljava/lang/Math;->max(II)I

    move-result p1

    return p1

    :cond_4
    iget p2, p0, Lcom/zerobranch/layout/SwipeLayout;->horizontalWidth:I

    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->rightDragViewPadding:I

    sub-int/2addr p2, v0

    .line 786
    invoke-static {p1, p2}, Ljava/lang/Math;->min(II)I

    move-result p1

    return p1
.end method

.method private clampLeftViewPosition(I)I
    .locals 2

    .line 721
    iget-boolean v0, p0, Lcom/zerobranch/layout/SwipeLayout;->isContinuousSwipe:Z

    const/4 v1, 0x0

    if-eqz v0, :cond_3

    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->isEmptyRightView()Z

    move-result v0

    if-eqz v0, :cond_3

    .line 722
    iget-boolean v0, p0, Lcom/zerobranch/layout/SwipeLayout;->isFreeHorizontalDrag:Z

    if-eqz v0, :cond_1

    .line 723
    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->horizontalWidth:I

    if-le p1, v0, :cond_0

    return v1

    :cond_0
    neg-int v0, v0

    invoke-static {p1, v0}, Ljava/lang/Math;->max(II)I

    move-result p1

    return p1

    :cond_1
    if-lez p1, :cond_2

    return v1

    .line 725
    :cond_2
    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->horizontalWidth:I

    neg-int v0, v0

    invoke-static {p1, v0}, Ljava/lang/Math;->max(II)I

    move-result p1

    return p1

    .line 729
    :cond_3
    iget-boolean v0, p0, Lcom/zerobranch/layout/SwipeLayout;->isFreeDragAfterOpen:Z

    if-eqz v0, :cond_7

    .line 730
    iget-boolean v0, p0, Lcom/zerobranch/layout/SwipeLayout;->isFreeHorizontalDrag:Z

    if-eqz v0, :cond_5

    .line 731
    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->horizontalWidth:I

    if-le p1, v0, :cond_4

    return v1

    :cond_4
    iget v1, p0, Lcom/zerobranch/layout/SwipeLayout;->leftDragViewPadding:I

    sub-int/2addr v1, v0

    .line 732
    invoke-static {p1, v1}, Ljava/lang/Math;->max(II)I

    move-result p1

    return p1

    :cond_5
    if-lez p1, :cond_6

    return v1

    .line 734
    :cond_6
    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->leftDragViewPadding:I

    iget v1, p0, Lcom/zerobranch/layout/SwipeLayout;->horizontalWidth:I

    sub-int/2addr v0, v1

    .line 735
    invoke-static {p1, v0}, Ljava/lang/Math;->max(II)I

    move-result p1

    return p1

    .line 738
    :cond_7
    iget-boolean v0, p0, Lcom/zerobranch/layout/SwipeLayout;->isFreeHorizontalDrag:Z

    if-eqz v0, :cond_9

    .line 739
    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->horizontalWidth:I

    if-le p1, v0, :cond_8

    return v1

    :cond_8
    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->getRightViewWidth()I

    move-result v0

    neg-int v0, v0

    invoke-static {p1, v0}, Ljava/lang/Math;->max(II)I

    move-result p1

    return p1

    :cond_9
    if-lez p1, :cond_a

    return v1

    .line 741
    :cond_a
    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->getRightViewWidth()I

    move-result v0

    neg-int v0, v0

    invoke-static {p1, v0}, Ljava/lang/Math;->max(II)I

    move-result p1

    return p1
.end method

.method private clampRightViewPosition(I)I
    .locals 2

    .line 745
    iget-boolean v0, p0, Lcom/zerobranch/layout/SwipeLayout;->isContinuousSwipe:Z

    const/4 v1, 0x0

    if-eqz v0, :cond_3

    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->isEmptyLeftView()Z

    move-result v0

    if-eqz v0, :cond_3

    .line 746
    iget-boolean v0, p0, Lcom/zerobranch/layout/SwipeLayout;->isFreeHorizontalDrag:Z

    if-eqz v0, :cond_1

    .line 747
    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->horizontalWidth:I

    neg-int v1, v0

    if-ge p1, v1, :cond_0

    neg-int p1, v0

    return p1

    :cond_0
    invoke-static {p1, v0}, Ljava/lang/Math;->min(II)I

    move-result p1

    return p1

    :cond_1
    if-gez p1, :cond_2

    return v1

    .line 749
    :cond_2
    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->horizontalWidth:I

    invoke-static {p1, v0}, Ljava/lang/Math;->min(II)I

    move-result p1

    return p1

    .line 753
    :cond_3
    iget-boolean v0, p0, Lcom/zerobranch/layout/SwipeLayout;->isFreeDragAfterOpen:Z

    if-eqz v0, :cond_7

    .line 754
    iget-boolean v0, p0, Lcom/zerobranch/layout/SwipeLayout;->isFreeHorizontalDrag:Z

    if-eqz v0, :cond_5

    .line 755
    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->horizontalWidth:I

    neg-int v1, v0

    if-ge p1, v1, :cond_4

    neg-int p1, v0

    return p1

    :cond_4
    iget v1, p0, Lcom/zerobranch/layout/SwipeLayout;->rightDragViewPadding:I

    sub-int/2addr v0, v1

    .line 756
    invoke-static {p1, v0}, Ljava/lang/Math;->min(II)I

    move-result p1

    return p1

    :cond_5
    if-gez p1, :cond_6

    return v1

    .line 758
    :cond_6
    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->horizontalWidth:I

    iget v1, p0, Lcom/zerobranch/layout/SwipeLayout;->rightDragViewPadding:I

    sub-int/2addr v0, v1

    .line 759
    invoke-static {p1, v0}, Ljava/lang/Math;->min(II)I

    move-result p1

    return p1

    .line 762
    :cond_7
    iget-boolean v0, p0, Lcom/zerobranch/layout/SwipeLayout;->isFreeHorizontalDrag:Z

    if-eqz v0, :cond_9

    .line 763
    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->horizontalWidth:I

    neg-int v1, v0

    if-ge p1, v1, :cond_8

    neg-int p1, v0

    return p1

    :cond_8
    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->getLeftViewWidth()I

    move-result v0

    invoke-static {p1, v0}, Ljava/lang/Math;->min(II)I

    move-result p1

    return p1

    :cond_9
    if-gez p1, :cond_a

    return v1

    .line 765
    :cond_a
    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->getLeftViewWidth()I

    move-result v0

    invoke-static {p1, v0}, Ljava/lang/Math;->min(II)I

    move-result p1

    return p1
.end method

.method private getFinalXHorizontalDirection(F)I
    .locals 1

    .line 860
    invoke-direct {p0, p1}, Lcom/zerobranch/layout/SwipeLayout;->isSwipeToOpenLeft(F)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 861
    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->getLeftViewWidth()I

    move-result p1

    return p1

    .line 862
    :cond_0
    invoke-direct {p0, p1}, Lcom/zerobranch/layout/SwipeLayout;->isSwipeToOpenRight(F)Z

    move-result v0

    if-eqz v0, :cond_1

    .line 863
    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->getRightViewWidth()I

    move-result p1

    neg-int p1, p1

    return p1

    .line 864
    :cond_1
    invoke-direct {p0, p1}, Lcom/zerobranch/layout/SwipeLayout;->isSwipeToClose(F)Z

    move-result p1

    if-eqz p1, :cond_2

    const/4 p1, 0x0

    return p1

    :cond_2
    const/4 p1, -0x1

    return p1
.end method

.method private getFinalXLeftDirection(F)I
    .locals 6

    .line 800
    iget-boolean v0, p0, Lcom/zerobranch/layout/SwipeLayout;->isContinuousSwipe:Z

    const/4 v1, 0x0

    if-eqz v0, :cond_4

    .line 801
    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->isEmptyRightView()Z

    move-result v0

    if-eqz v0, :cond_3

    .line 802
    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->draggingViewLeft:I

    if-gez v0, :cond_0

    invoke-static {v0}, Ljava/lang/Math;->abs(I)I

    move-result v0

    iget v2, p0, Lcom/zerobranch/layout/SwipeLayout;->horizontalWidth:I

    div-int/lit8 v2, v2, 0x2

    if-gt v0, v2, :cond_1

    :cond_0
    float-to-double v2, p1

    iget-wide v4, p0, Lcom/zerobranch/layout/SwipeLayout;->autoOpenSpeed:D

    neg-double v4, v4

    cmpg-double p1, v2, v4

    if-gez p1, :cond_2

    .line 804
    :cond_1
    iget p1, p0, Lcom/zerobranch/layout/SwipeLayout;->horizontalWidth:I

    :goto_0
    neg-int p1, p1

    return p1

    :cond_2
    return v1

    .line 809
    :cond_3
    invoke-direct {p0, p1}, Lcom/zerobranch/layout/SwipeLayout;->isContinuousSwipeToLeft(F)Z

    move-result v0

    if-eqz v0, :cond_4

    .line 810
    iget p1, p0, Lcom/zerobranch/layout/SwipeLayout;->horizontalWidth:I

    goto :goto_0

    :cond_4
    float-to-double v2, p1

    .line 815
    iget-wide v4, p0, Lcom/zerobranch/layout/SwipeLayout;->autoOpenSpeed:D

    cmpl-double p1, v2, v4

    if-lez p1, :cond_5

    goto :goto_2

    :cond_5
    neg-double v4, v4

    cmpg-double p1, v2, v4

    if-gez p1, :cond_6

    goto :goto_1

    .line 819
    :cond_6
    iget p1, p0, Lcom/zerobranch/layout/SwipeLayout;->draggingViewLeft:I

    if-gez p1, :cond_7

    invoke-static {p1}, Ljava/lang/Math;->abs(I)I

    move-result p1

    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->getRightViewWidth()I

    move-result v0

    div-int/lit8 v0, v0, 0x2

    if-le p1, v0, :cond_7

    .line 826
    :goto_1
    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->getRightViewWidth()I

    move-result p1

    goto :goto_0

    .line 821
    :cond_7
    iget p1, p0, Lcom/zerobranch/layout/SwipeLayout;->draggingViewLeft:I

    if-gez p1, :cond_8

    invoke-static {p1}, Ljava/lang/Math;->abs(I)I

    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->getRightViewWidth()I

    :cond_8
    :goto_2
    return v1
.end method

.method private getFinalXRightDirection(F)I
    .locals 6

    .line 830
    iget-boolean v0, p0, Lcom/zerobranch/layout/SwipeLayout;->isContinuousSwipe:Z

    const/4 v1, 0x0

    if-eqz v0, :cond_4

    .line 831
    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->isEmptyLeftView()Z

    move-result v0

    if-eqz v0, :cond_3

    .line 832
    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->draggingViewLeft:I

    if-lez v0, :cond_0

    invoke-static {v0}, Ljava/lang/Math;->abs(I)I

    move-result v0

    iget v2, p0, Lcom/zerobranch/layout/SwipeLayout;->horizontalWidth:I

    div-int/lit8 v2, v2, 0x2

    if-gt v0, v2, :cond_1

    :cond_0
    float-to-double v2, p1

    iget-wide v4, p0, Lcom/zerobranch/layout/SwipeLayout;->autoOpenSpeed:D

    cmpl-double p1, v2, v4

    if-lez p1, :cond_2

    .line 834
    :cond_1
    iget p1, p0, Lcom/zerobranch/layout/SwipeLayout;->horizontalWidth:I

    return p1

    :cond_2
    return v1

    .line 839
    :cond_3
    invoke-direct {p0, p1}, Lcom/zerobranch/layout/SwipeLayout;->isContinuousSwipeToRight(F)Z

    move-result v0

    if-eqz v0, :cond_4

    .line 840
    iget p1, p0, Lcom/zerobranch/layout/SwipeLayout;->horizontalWidth:I

    return p1

    :cond_4
    float-to-double v2, p1

    .line 845
    iget-wide v4, p0, Lcom/zerobranch/layout/SwipeLayout;->autoOpenSpeed:D

    cmpl-double p1, v2, v4

    if-lez p1, :cond_5

    goto :goto_0

    :cond_5
    neg-double v4, v4

    cmpg-double p1, v2, v4

    if-gez p1, :cond_6

    goto :goto_1

    .line 849
    :cond_6
    iget p1, p0, Lcom/zerobranch/layout/SwipeLayout;->draggingViewLeft:I

    if-lez p1, :cond_7

    invoke-static {p1}, Ljava/lang/Math;->abs(I)I

    move-result p1

    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->getLeftViewWidth()I

    move-result v0

    div-int/lit8 v0, v0, 0x2

    if-le p1, v0, :cond_7

    .line 856
    :goto_0
    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->getLeftViewWidth()I

    move-result p1

    return p1

    .line 851
    :cond_7
    iget p1, p0, Lcom/zerobranch/layout/SwipeLayout;->draggingViewLeft:I

    if-lez p1, :cond_8

    invoke-static {p1}, Ljava/lang/Math;->abs(I)I

    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->getLeftViewWidth()I

    :cond_8
    :goto_1
    return v1
.end method

.method private getLeftViewWidth()I
    .locals 1

    .line 994
    iget-object v0, p0, Lcom/zerobranch/layout/SwipeLayout;->staticLeftView:Landroid/view/View;

    invoke-virtual {v0}, Landroid/view/View;->getWidth()I

    move-result v0

    return v0
.end method

.method private getNeededTouchView(Landroid/view/MotionEvent;Landroid/view/ViewGroup;)Landroid/view/View;
    .locals 4

    .line 931
    invoke-virtual {p2, p1}, Landroid/view/ViewGroup;->onInterceptTouchEvent(Landroid/view/MotionEvent;)Z

    move-result v0

    if-eqz v0, :cond_0

    return-object p2

    .line 935
    :cond_0
    invoke-virtual {p2}, Landroid/view/ViewGroup;->getChildCount()I

    move-result v0

    const/4 v1, 0x0

    :goto_0
    if-ge v1, v0, :cond_3

    .line 938
    invoke-virtual {p2, v1}, Landroid/view/ViewGroup;->getChildAt(I)Landroid/view/View;

    move-result-object v2

    .line 940
    invoke-direct {p0, v2}, Lcom/zerobranch/layout/SwipeLayout;->isViewGroup(Landroid/view/View;)Z

    move-result v3

    if-nez v3, :cond_1

    goto :goto_1

    .line 944
    :cond_1
    check-cast v2, Landroid/view/ViewGroup;

    invoke-direct {p0, p1, v2}, Lcom/zerobranch/layout/SwipeLayout;->getNeededTouchView(Landroid/view/MotionEvent;Landroid/view/ViewGroup;)Landroid/view/View;

    move-result-object v2

    if-eqz v2, :cond_2

    return-object v2

    :cond_2
    :goto_1
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_3
    const/4 p1, 0x0

    return-object p1
.end method

.method private getPreviousPosition()I
    .locals 1

    .line 790
    iget-boolean v0, p0, Lcom/zerobranch/layout/SwipeLayout;->isLeftOpen:Z

    if-eqz v0, :cond_0

    .line 791
    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->getLeftViewWidth()I

    move-result v0

    return v0

    .line 792
    :cond_0
    iget-boolean v0, p0, Lcom/zerobranch/layout/SwipeLayout;->isRightOpen:Z

    if-eqz v0, :cond_1

    .line 793
    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->getRightViewWidth()I

    move-result v0

    neg-int v0, v0

    return v0

    :cond_1
    const/4 v0, 0x0

    return v0
.end method

.method private getRightViewWidth()I
    .locals 1

    .line 998
    iget-object v0, p0, Lcom/zerobranch/layout/SwipeLayout;->staticRightView:Landroid/view/View;

    invoke-virtual {v0}, Landroid/view/View;->getWidth()I

    move-result v0

    return v0
.end method

.method private isContinuousSwipeToLeft(F)Z
    .locals 4

    float-to-double v0, p1

    .line 878
    iget-wide v2, p0, Lcom/zerobranch/layout/SwipeLayout;->autoOpenSpeed:D

    neg-double v2, v2

    cmpg-double p1, v0, v2

    if-gez p1, :cond_0

    iget p1, p0, Lcom/zerobranch/layout/SwipeLayout;->draggingViewLeft:I

    invoke-static {p1}, Ljava/lang/Math;->abs(I)I

    move-result p1

    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->getRightViewWidth()I

    move-result v0

    if-gt p1, v0, :cond_1

    :cond_0
    iget p1, p0, Lcom/zerobranch/layout/SwipeLayout;->draggingViewLeft:I

    if-gez p1, :cond_2

    .line 879
    invoke-static {p1}, Ljava/lang/Math;->abs(I)I

    move-result p1

    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->horizontalWidth:I

    div-int/lit8 v0, v0, 0x2

    if-le p1, v0, :cond_2

    :cond_1
    const/4 p1, 0x1

    return p1

    :cond_2
    const/4 p1, 0x0

    return p1
.end method

.method private isContinuousSwipeToRight(F)Z
    .locals 4

    float-to-double v0, p1

    .line 872
    iget-wide v2, p0, Lcom/zerobranch/layout/SwipeLayout;->autoOpenSpeed:D

    cmpl-double p1, v0, v2

    if-lez p1, :cond_0

    iget p1, p0, Lcom/zerobranch/layout/SwipeLayout;->draggingViewLeft:I

    invoke-static {p1}, Ljava/lang/Math;->abs(I)I

    move-result p1

    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->getLeftViewWidth()I

    move-result v0

    if-gt p1, v0, :cond_1

    :cond_0
    iget p1, p0, Lcom/zerobranch/layout/SwipeLayout;->draggingViewLeft:I

    if-lez p1, :cond_2

    .line 873
    invoke-static {p1}, Ljava/lang/Math;->abs(I)I

    move-result p1

    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->horizontalWidth:I

    div-int/lit8 v0, v0, 0x2

    if-le p1, v0, :cond_2

    :cond_1
    const/4 p1, 0x1

    return p1

    :cond_2
    const/4 p1, 0x0

    return p1
.end method

.method private isDragIdle(I)Z
    .locals 0

    .line 0
    if-nez p1, :cond_0

    const/4 p1, 0x1

    return p1

    :cond_0
    const/4 p1, 0x0

    return p1
.end method

.method private isEmptyLeftView()Z
    .locals 1

    .line 1002
    iget-object v0, p0, Lcom/zerobranch/layout/SwipeLayout;->staticLeftView:Landroid/view/View;

    if-nez v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method private isEmptyRightView()Z
    .locals 1

    .line 1006
    iget-object v0, p0, Lcom/zerobranch/layout/SwipeLayout;->staticRightView:Landroid/view/View;

    if-nez v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method private isIdleAfterMoving(I)Z
    .locals 3

    .line 968
    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->currentDraggingState:I

    const/4 v1, 0x1

    if-eq v0, v1, :cond_0

    const/4 v2, 0x2

    if-ne v0, v2, :cond_1

    :cond_0
    if-nez p1, :cond_1

    return v1

    :cond_1
    const/4 p1, 0x0

    return p1
.end method

.method private isLeftOpenCompletely()Z
    .locals 2

    .line 990
    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->draggingViewLeft:I

    iget v1, p0, Lcom/zerobranch/layout/SwipeLayout;->horizontalWidth:I

    if-ne v0, v1, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method private isLeftViewOpen()Z
    .locals 2

    .line 982
    iget-object v0, p0, Lcom/zerobranch/layout/SwipeLayout;->staticLeftView:Landroid/view/View;

    if-eqz v0, :cond_0

    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->draggingViewLeft:I

    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->getLeftViewWidth()I

    move-result v1

    if-ne v0, v1, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method private isRightOpenCompletely()Z
    .locals 2

    .line 986
    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->draggingViewLeft:I

    iget v1, p0, Lcom/zerobranch/layout/SwipeLayout;->horizontalWidth:I

    neg-int v1, v1

    if-ne v0, v1, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method private isRightViewOpen()Z
    .locals 2

    .line 978
    iget-object v0, p0, Lcom/zerobranch/layout/SwipeLayout;->staticRightView:Landroid/view/View;

    if-eqz v0, :cond_0

    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->draggingViewLeft:I

    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->getRightViewWidth()I

    move-result v1

    neg-int v1, v1

    if-ne v0, v1, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method private isSwipeToClose(F)Z
    .locals 5

    .line 899
    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->draggingViewLeft:I

    if-ltz v0, :cond_0

    float-to-double v1, p1

    iget-wide v3, p0, Lcom/zerobranch/layout/SwipeLayout;->autoOpenSpeed:D

    neg-double v3, v3

    cmpg-double v1, v1, v3

    if-ltz v1, :cond_3

    :cond_0
    if-gtz v0, :cond_1

    float-to-double v1, p1

    iget-wide v3, p0, Lcom/zerobranch/layout/SwipeLayout;->autoOpenSpeed:D

    cmpl-double p1, v1, v3

    if-gtz p1, :cond_3

    :cond_1
    if-ltz v0, :cond_2

    .line 901
    invoke-static {v0}, Ljava/lang/Math;->abs(I)I

    move-result p1

    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->getLeftViewWidth()I

    move-result v0

    div-int/lit8 v0, v0, 0x2

    if-lt p1, v0, :cond_3

    :cond_2
    iget p1, p0, Lcom/zerobranch/layout/SwipeLayout;->draggingViewLeft:I

    if-gtz p1, :cond_4

    .line 902
    invoke-static {p1}, Ljava/lang/Math;->abs(I)I

    move-result p1

    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->getRightViewWidth()I

    move-result v0

    div-int/lit8 v0, v0, 0x2

    if-ge p1, v0, :cond_4

    :cond_3
    const/4 p1, 0x1

    return p1

    :cond_4
    const/4 p1, 0x0

    return p1
.end method

.method private isSwipeToOpenLeft(F)Z
    .locals 6

    const/4 v0, 0x0

    cmpg-float v0, p1, v0

    const/4 v1, 0x0

    if-gez v0, :cond_0

    return v1

    .line 894
    :cond_0
    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->draggingViewLeft:I

    if-lez v0, :cond_1

    float-to-double v2, p1

    iget-wide v4, p0, Lcom/zerobranch/layout/SwipeLayout;->autoOpenSpeed:D

    cmpl-double p1, v2, v4

    if-gtz p1, :cond_2

    :cond_1
    if-lez v0, :cond_3

    .line 895
    invoke-static {v0}, Ljava/lang/Math;->abs(I)I

    move-result p1

    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->getLeftViewWidth()I

    move-result v0

    div-int/lit8 v0, v0, 0x2

    if-le p1, v0, :cond_3

    :cond_2
    const/4 p1, 0x1

    return p1

    :cond_3
    return v1
.end method

.method private isSwipeToOpenRight(F)Z
    .locals 6

    const/4 v0, 0x0

    cmpl-float v0, p1, v0

    const/4 v1, 0x0

    if-lez v0, :cond_0

    return v1

    .line 886
    :cond_0
    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->draggingViewLeft:I

    if-gez v0, :cond_1

    float-to-double v2, p1

    iget-wide v4, p0, Lcom/zerobranch/layout/SwipeLayout;->autoOpenSpeed:D

    neg-double v4, v4

    cmpg-double p1, v2, v4

    if-ltz p1, :cond_2

    :cond_1
    if-gez v0, :cond_3

    .line 887
    invoke-static {v0}, Ljava/lang/Math;->abs(I)I

    move-result p1

    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->getRightViewWidth()I

    move-result v0

    div-int/lit8 v0, v0, 0x2

    if-le p1, v0, :cond_3

    :cond_2
    const/4 p1, 0x1

    return p1

    :cond_3
    return v1
.end method

.method private isSwipeViewTarget(Landroid/view/MotionEvent;)Z
    .locals 4

    const/4 v0, 0x2

    .line 959
    new-array v0, v0, [I

    .line 960
    iget-object v1, p0, Lcom/zerobranch/layout/SwipeLayout;->draggedView:Landroid/view/View;

    invoke-virtual {v1, v0}, Landroid/view/View;->getLocationOnScreen([I)V

    const/4 v1, 0x1

    .line 961
    aget v2, v0, v1

    iget-object v3, p0, Lcom/zerobranch/layout/SwipeLayout;->draggedView:Landroid/view/View;

    invoke-virtual {v3}, Landroid/view/View;->getMeasuredHeight()I

    move-result v3

    add-int/2addr v2, v3

    .line 962
    aget v0, v0, v1

    .line 963
    invoke-virtual {p1}, Landroid/view/MotionEvent;->getRawY()F

    move-result p1

    float-to-int p1, p1

    if-le p1, v0, :cond_0

    if-ge p1, v2, :cond_0

    return v1

    :cond_0
    const/4 p1, 0x0

    return p1
.end method

.method private isViewGroup(Landroid/view/View;)Z
    .locals 0

    .line 955
    instance-of p1, p1, Landroid/view/ViewGroup;

    return p1
.end method

.method private isViewTouchTarget(Landroid/view/View;Landroid/graphics/Point;)Z
    .locals 2

    .line 924
    iget v0, p2, Landroid/graphics/Point;->y:I

    invoke-virtual {p1}, Landroid/view/View;->getTop()I

    move-result v1

    if-lt v0, v1, :cond_0

    iget v0, p2, Landroid/graphics/Point;->y:I

    .line 925
    invoke-virtual {p1}, Landroid/view/View;->getBottom()I

    move-result v1

    if-ge v0, v1, :cond_0

    iget v0, p2, Landroid/graphics/Point;->x:I

    .line 926
    invoke-virtual {p1}, Landroid/view/View;->getLeft()I

    move-result v1

    if-lt v0, v1, :cond_0

    iget p2, p2, Landroid/graphics/Point;->y:I

    .line 927
    invoke-virtual {p1}, Landroid/view/View;->getRight()I

    move-result p1

    if-ge p2, p1, :cond_0

    const/4 p1, 0x1

    return p1

    :cond_0
    const/4 p1, 0x0

    return p1
.end method

.method private moveTo(I)V
    .locals 3

    .line 1021
    iget-object v0, p0, Lcom/zerobranch/layout/SwipeLayout;->dragHelper:Landroidx/customview/widget/ViewDragHelper;

    iget-object v1, p0, Lcom/zerobranch/layout/SwipeLayout;->draggedView:Landroid/view/View;

    invoke-virtual {v1}, Landroid/view/View;->getTop()I

    move-result v2

    invoke-virtual {v0, v1, p1, v2}, Landroidx/customview/widget/ViewDragHelper;->smoothSlideViewTo(Landroid/view/View;II)Z

    .line 1022
    invoke-static {p0}, Landroidx/core/view/ViewCompat;->postInvalidateOnAnimation(Landroid/view/View;)V

    return-void
.end method

.method private parametersAdjustment()V
    .locals 2

    .line 1010
    iget-boolean v0, p0, Lcom/zerobranch/layout/SwipeLayout;->isContinuousSwipe:Z

    const/4 v1, 0x3

    if-eqz v0, :cond_0

    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->currentDirection:I

    if-eq v0, v1, :cond_0

    const/4 v0, 0x1

    .line 1011
    iput-boolean v0, p0, Lcom/zerobranch/layout/SwipeLayout;->isFreeDragAfterOpen:Z

    .line 1014
    :cond_0
    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->currentDirection:I

    if-ne v0, v1, :cond_1

    const/4 v0, 0x0

    .line 1015
    iput v0, p0, Lcom/zerobranch/layout/SwipeLayout;->rightDragViewPadding:I

    .line 1016
    iput v0, p0, Lcom/zerobranch/layout/SwipeLayout;->leftDragViewPadding:I

    :cond_1
    return-void
.end method

.method private setupPost()V
    .locals 1

    .line 906
    iget-boolean v0, p0, Lcom/zerobranch/layout/SwipeLayout;->isTogether:Z

    if-eqz v0, :cond_0

    .line 907
    new-instance v0, Lcom/zerobranch/layout/SwipeLayout$4;

    invoke-direct {v0, p0}, Lcom/zerobranch/layout/SwipeLayout$4;-><init>(Lcom/zerobranch/layout/SwipeLayout;)V

    invoke-virtual {p0, v0}, Landroid/view/View;->post(Ljava/lang/Runnable;)Z

    :cond_0
    return-void
.end method

.method private updateState()V
    .locals 3

    .line 607
    invoke-virtual {p0}, Lcom/zerobranch/layout/SwipeLayout;->isClosed()Z

    move-result v0

    const/4 v1, 0x0

    if-eqz v0, :cond_0

    .line 608
    iput-boolean v1, p0, Lcom/zerobranch/layout/SwipeLayout;->isLeftOpen:Z

    .line 609
    iput-boolean v1, p0, Lcom/zerobranch/layout/SwipeLayout;->isRightOpen:Z

    .line 611
    iget-object v0, p0, Lcom/zerobranch/layout/SwipeLayout;->actionsListener:Lcom/zerobranch/layout/SwipeLayout$SwipeActionsListener;

    if-eqz v0, :cond_4

    .line 612
    invoke-interface {v0}, Lcom/zerobranch/layout/SwipeLayout$SwipeActionsListener;->onClose()V

    return-void

    .line 614
    :cond_0
    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->isLeftOpenCompletely()Z

    move-result v0

    const/4 v2, 0x1

    if-nez v0, :cond_3

    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->isLeftViewOpen()Z

    move-result v0

    if-eqz v0, :cond_1

    goto :goto_0

    .line 621
    :cond_1
    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->isRightOpenCompletely()Z

    move-result v0

    if-nez v0, :cond_2

    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->isRightViewOpen()Z

    move-result v0

    if-eqz v0, :cond_4

    .line 622
    :cond_2
    iput-boolean v1, p0, Lcom/zerobranch/layout/SwipeLayout;->isLeftOpen:Z

    .line 623
    iput-boolean v2, p0, Lcom/zerobranch/layout/SwipeLayout;->isRightOpen:Z

    .line 625
    iget-object v0, p0, Lcom/zerobranch/layout/SwipeLayout;->actionsListener:Lcom/zerobranch/layout/SwipeLayout$SwipeActionsListener;

    if-eqz v0, :cond_4

    .line 626
    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->isRightOpenCompletely()Z

    move-result v1

    invoke-interface {v0, v2, v1}, Lcom/zerobranch/layout/SwipeLayout$SwipeActionsListener;->onOpen(IZ)V

    return-void

    .line 615
    :cond_3
    :goto_0
    iput-boolean v2, p0, Lcom/zerobranch/layout/SwipeLayout;->isLeftOpen:Z

    .line 616
    iput-boolean v1, p0, Lcom/zerobranch/layout/SwipeLayout;->isRightOpen:Z

    .line 618
    iget-object v0, p0, Lcom/zerobranch/layout/SwipeLayout;->actionsListener:Lcom/zerobranch/layout/SwipeLayout$SwipeActionsListener;

    if-eqz v0, :cond_4

    const/4 v1, 0x2

    .line 619
    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->isLeftOpenCompletely()Z

    move-result v2

    invoke-interface {v0, v1, v2}, Lcom/zerobranch/layout/SwipeLayout$SwipeActionsListener;->onOpen(IZ)V

    :cond_4
    return-void
.end method


# virtual methods
.method public close()V
    .locals 1

    const/4 v0, 0x0

    .line 416
    invoke-direct {p0, v0}, Lcom/zerobranch/layout/SwipeLayout;->moveTo(I)V

    return-void
.end method

.method public close(Z)V
    .locals 5

    if-eqz p1, :cond_0

    .line 347
    invoke-virtual {p0}, Lcom/zerobranch/layout/SwipeLayout;->close()V

    return-void

    .line 349
    :cond_0
    iget-boolean p1, p0, Lcom/zerobranch/layout/SwipeLayout;->isTogether:Z

    const/4 v0, 0x0

    if-eqz p1, :cond_3

    .line 350
    iget-object p1, p0, Lcom/zerobranch/layout/SwipeLayout;->staticLeftView:Landroid/view/View;

    if-eqz p1, :cond_1

    iget v1, p0, Lcom/zerobranch/layout/SwipeLayout;->currentDirection:I

    const/4 v2, 0x2

    if-ne v1, v2, :cond_1

    .line 351
    invoke-virtual {p1}, Landroid/view/View;->getTop()I

    move-result v1

    iget-object v2, p0, Lcom/zerobranch/layout/SwipeLayout;->staticLeftView:Landroid/view/View;

    .line 352
    invoke-virtual {v2}, Landroid/view/View;->getWidth()I

    move-result v2

    iget-object v3, p0, Lcom/zerobranch/layout/SwipeLayout;->staticLeftView:Landroid/view/View;

    invoke-virtual {v3}, Landroid/view/View;->getBottom()I

    move-result v3

    .line 351
    invoke-virtual {p1, v0, v1, v2, v3}, Landroid/view/View;->layout(IIII)V

    goto :goto_0

    .line 353
    :cond_1
    iget-object v1, p0, Lcom/zerobranch/layout/SwipeLayout;->staticRightView:Landroid/view/View;

    if-eqz v1, :cond_2

    iget v2, p0, Lcom/zerobranch/layout/SwipeLayout;->currentDirection:I

    const/4 v3, 0x1

    if-ne v2, v3, :cond_2

    .line 354
    iget p1, p0, Lcom/zerobranch/layout/SwipeLayout;->horizontalWidth:I

    invoke-virtual {v1}, Landroid/view/View;->getWidth()I

    move-result v2

    sub-int/2addr p1, v2

    iget-object v2, p0, Lcom/zerobranch/layout/SwipeLayout;->staticRightView:Landroid/view/View;

    invoke-virtual {v2}, Landroid/view/View;->getTop()I

    move-result v2

    iget v3, p0, Lcom/zerobranch/layout/SwipeLayout;->horizontalWidth:I

    iget-object v4, p0, Lcom/zerobranch/layout/SwipeLayout;->staticRightView:Landroid/view/View;

    .line 355
    invoke-virtual {v4}, Landroid/view/View;->getBottom()I

    move-result v4

    .line 354
    invoke-virtual {v1, p1, v2, v3, v4}, Landroid/view/View;->layout(IIII)V

    goto :goto_0

    .line 356
    :cond_2
    iget v2, p0, Lcom/zerobranch/layout/SwipeLayout;->currentDirection:I

    const/4 v3, 0x3

    if-ne v2, v3, :cond_3

    if-eqz v1, :cond_3

    if-eqz p1, :cond_3

    .line 357
    invoke-virtual {p1}, Landroid/view/View;->getTop()I

    move-result v1

    iget-object v2, p0, Lcom/zerobranch/layout/SwipeLayout;->staticLeftView:Landroid/view/View;

    .line 358
    invoke-virtual {v2}, Landroid/view/View;->getWidth()I

    move-result v2

    iget-object v3, p0, Lcom/zerobranch/layout/SwipeLayout;->staticLeftView:Landroid/view/View;

    invoke-virtual {v3}, Landroid/view/View;->getBottom()I

    move-result v3

    .line 357
    invoke-virtual {p1, v0, v1, v2, v3}, Landroid/view/View;->layout(IIII)V

    .line 359
    iget-object p1, p0, Lcom/zerobranch/layout/SwipeLayout;->staticRightView:Landroid/view/View;

    iget v1, p0, Lcom/zerobranch/layout/SwipeLayout;->horizontalWidth:I

    invoke-virtual {p1}, Landroid/view/View;->getWidth()I

    move-result v2

    sub-int/2addr v1, v2

    iget-object v2, p0, Lcom/zerobranch/layout/SwipeLayout;->staticRightView:Landroid/view/View;

    invoke-virtual {v2}, Landroid/view/View;->getTop()I

    move-result v2

    iget v3, p0, Lcom/zerobranch/layout/SwipeLayout;->horizontalWidth:I

    iget-object v4, p0, Lcom/zerobranch/layout/SwipeLayout;->staticRightView:Landroid/view/View;

    .line 360
    invoke-virtual {v4}, Landroid/view/View;->getBottom()I

    move-result v4

    .line 359
    invoke-virtual {p1, v1, v2, v3, v4}, Landroid/view/View;->layout(IIII)V

    .line 364
    :cond_3
    :goto_0
    iget-object p1, p0, Lcom/zerobranch/layout/SwipeLayout;->draggedView:Landroid/view/View;

    .line 365
    invoke-virtual {p1}, Landroid/view/View;->getTop()I

    move-result v1

    iget-object v2, p0, Lcom/zerobranch/layout/SwipeLayout;->draggedView:Landroid/view/View;

    .line 366
    invoke-virtual {v2}, Landroid/view/View;->getWidth()I

    move-result v2

    iget-object v3, p0, Lcom/zerobranch/layout/SwipeLayout;->draggedView:Landroid/view/View;

    .line 367
    invoke-virtual {v3}, Landroid/view/View;->getBottom()I

    move-result v3

    .line 364
    invoke-virtual {p1, v0, v1, v2, v3}, Landroid/view/View;->layout(IIII)V

    .line 369
    iput v0, p0, Lcom/zerobranch/layout/SwipeLayout;->draggingViewLeft:I

    .line 370
    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->updateState()V

    return-void
.end method

.method public computeScroll()V
    .locals 2

    .line 235
    iget-object v0, p0, Lcom/zerobranch/layout/SwipeLayout;->dragHelper:Landroidx/customview/widget/ViewDragHelper;

    const/4 v1, 0x1

    invoke-virtual {v0, v1}, Landroidx/customview/widget/ViewDragHelper;->continueSettling(Z)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 236
    invoke-static {p0}, Landroidx/core/view/ViewCompat;->postInvalidateOnAnimation(Landroid/view/View;)V

    :cond_0
    return-void
.end method

.method public enableTouchForViewGroup(Landroid/view/ViewGroup;)V
    .locals 1

    .line 597
    new-instance v0, Lcom/zerobranch/layout/SwipeLayout$1;

    invoke-direct {v0, p0}, Lcom/zerobranch/layout/SwipeLayout$1;-><init>(Lcom/zerobranch/layout/SwipeLayout;)V

    invoke-virtual {p1, v0}, Landroid/view/View;->setOnTouchListener(Landroid/view/View$OnTouchListener;)V

    return-void
.end method

.method public getCurrentDirection()I
    .locals 1

    .line 438
    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->currentDirection:I

    return v0
.end method

.method public getLeftDragViewPadding()I
    .locals 1

    .line 581
    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->leftDragViewPadding:I

    return v0
.end method

.method public getRightDragViewPadding()I
    .locals 1

    .line 565
    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->rightDragViewPadding:I

    return v0
.end method

.method public isClosed()Z
    .locals 1

    .line 431
    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->draggingViewLeft:I

    if-nez v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public isContinuousSwipe()Z
    .locals 1

    .line 475
    iget-boolean v0, p0, Lcom/zerobranch/layout/SwipeLayout;->isContinuousSwipe:Z

    return v0
.end method

.method public isEnabledSwipe()Z
    .locals 1

    .line 246
    iget-boolean v0, p0, Lcom/zerobranch/layout/SwipeLayout;->isEnabledSwipe:Z

    return v0
.end method

.method public isFreeDragAfterOpen()Z
    .locals 1

    .line 501
    iget-boolean v0, p0, Lcom/zerobranch/layout/SwipeLayout;->isFreeDragAfterOpen:Z

    return v0
.end method

.method public isFreeHorizontalDrag()Z
    .locals 1

    .line 524
    iget-boolean v0, p0, Lcom/zerobranch/layout/SwipeLayout;->isFreeHorizontalDrag:Z

    return v0
.end method

.method public isLeftOpen()Z
    .locals 1

    .line 550
    iget-boolean v0, p0, Lcom/zerobranch/layout/SwipeLayout;->isLeftOpen:Z

    return v0
.end method

.method public isMoving()Z
    .locals 3

    .line 423
    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->currentDraggingState:I

    const/4 v1, 0x1

    if-eq v0, v1, :cond_1

    const/4 v2, 0x2

    if-ne v0, v2, :cond_0

    goto :goto_0

    :cond_0
    const/4 v0, 0x0

    return v0

    :cond_1
    :goto_0
    return v1
.end method

.method public isRightOpen()Z
    .locals 1

    .line 543
    iget-boolean v0, p0, Lcom/zerobranch/layout/SwipeLayout;->isRightOpen:Z

    return v0
.end method

.method public isTogether()Z
    .locals 1

    .line 453
    iget-boolean v0, p0, Lcom/zerobranch/layout/SwipeLayout;->isTogether:Z

    return v0
.end method

.method protected onFinishInflate()V
    .locals 3

    .line 189
    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->draggedViewId:I

    if-eqz v0, :cond_0

    .line 190
    invoke-virtual {p0, v0}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v0

    iput-object v0, p0, Lcom/zerobranch/layout/SwipeLayout;->draggedView:Landroid/view/View;

    .line 193
    :cond_0
    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->staticLeftViewId:I

    if-eqz v0, :cond_1

    .line 194
    invoke-virtual {p0, v0}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v0

    iput-object v0, p0, Lcom/zerobranch/layout/SwipeLayout;->staticLeftView:Landroid/view/View;

    .line 197
    :cond_1
    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->staticRightViewId:I

    if-eqz v0, :cond_2

    .line 198
    invoke-virtual {p0, v0}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v0

    iput-object v0, p0, Lcom/zerobranch/layout/SwipeLayout;->staticRightView:Landroid/view/View;

    .line 201
    :cond_2
    iget-object v0, p0, Lcom/zerobranch/layout/SwipeLayout;->draggedView:Landroid/view/View;

    if-eqz v0, :cond_d

    .line 203
    iget-boolean v0, p0, Lcom/zerobranch/layout/SwipeLayout;->isTogether:Z

    const/4 v1, 0x1

    if-eqz v0, :cond_4

    iget v2, p0, Lcom/zerobranch/layout/SwipeLayout;->currentDirection:I

    if-ne v2, v1, :cond_4

    iget-object v2, p0, Lcom/zerobranch/layout/SwipeLayout;->staticRightView:Landroid/view/View;

    if-eqz v2, :cond_3

    goto :goto_0

    .line 204
    :cond_3
    new-instance v0, Ljava/lang/RuntimeException;

    const-string v1, "If \'isTogether = true\' \'rightItem\' must be specified"

    invoke-direct {v0, v1}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw v0

    :cond_4
    :goto_0
    const/4 v2, 0x2

    if-eqz v0, :cond_6

    .line 205
    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->currentDirection:I

    if-ne v0, v2, :cond_6

    iget-object v0, p0, Lcom/zerobranch/layout/SwipeLayout;->staticLeftView:Landroid/view/View;

    if-eqz v0, :cond_5

    goto :goto_1

    .line 206
    :cond_5
    new-instance v0, Ljava/lang/RuntimeException;

    const-string v1, "If \'isTogether = true\' \'leftItem\' must be specified"

    invoke-direct {v0, v1}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 207
    :cond_6
    :goto_1
    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->currentDirection:I

    if-ne v0, v1, :cond_8

    iget-boolean v1, p0, Lcom/zerobranch/layout/SwipeLayout;->isContinuousSwipe:Z

    if-nez v1, :cond_8

    iget-object v1, p0, Lcom/zerobranch/layout/SwipeLayout;->staticRightView:Landroid/view/View;

    if-eqz v1, :cond_7

    goto :goto_2

    .line 208
    :cond_7
    new-instance v0, Ljava/lang/RuntimeException;

    const-string v1, "Must be specified \'rightItem\' or flag isContinuousSwipe = true"

    invoke-direct {v0, v1}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw v0

    :cond_8
    :goto_2
    if-ne v0, v2, :cond_a

    .line 209
    iget-boolean v1, p0, Lcom/zerobranch/layout/SwipeLayout;->isContinuousSwipe:Z

    if-nez v1, :cond_a

    iget-object v1, p0, Lcom/zerobranch/layout/SwipeLayout;->staticLeftView:Landroid/view/View;

    if-eqz v1, :cond_9

    goto :goto_3

    .line 210
    :cond_9
    new-instance v0, Ljava/lang/RuntimeException;

    const-string v1, "Must be specified \'leftItem\' or flag isContinuousSwipe = true"

    invoke-direct {v0, v1}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw v0

    :cond_a
    :goto_3
    const/4 v1, 0x3

    if-ne v0, v1, :cond_c

    .line 211
    iget-object v0, p0, Lcom/zerobranch/layout/SwipeLayout;->staticRightView:Landroid/view/View;

    if-eqz v0, :cond_b

    iget-object v0, p0, Lcom/zerobranch/layout/SwipeLayout;->staticLeftView:Landroid/view/View;

    if-eqz v0, :cond_b

    goto :goto_4

    .line 212
    :cond_b
    new-instance v0, Ljava/lang/RuntimeException;

    const-string v1, "\'leftItem\' and \'rightItem\' must be specified"

    invoke-direct {v0, v1}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw v0

    :cond_c
    :goto_4
    const/high16 v0, 0x3f800000    # 1.0f

    .line 215
    iget-object v1, p0, Lcom/zerobranch/layout/SwipeLayout;->dragHelperCallback:Landroidx/customview/widget/ViewDragHelper$Callback;

    invoke-static {p0, v0, v1}, Landroidx/customview/widget/ViewDragHelper;->create(Landroid/view/ViewGroup;FLandroidx/customview/widget/ViewDragHelper$Callback;)Landroidx/customview/widget/ViewDragHelper;

    move-result-object v0

    iput-object v0, p0, Lcom/zerobranch/layout/SwipeLayout;->dragHelper:Landroidx/customview/widget/ViewDragHelper;

    .line 216
    new-instance v0, Landroidx/core/view/GestureDetectorCompat;

    invoke-virtual {p0}, Landroid/view/View;->getContext()Landroid/content/Context;

    move-result-object v1

    iget-object v2, p0, Lcom/zerobranch/layout/SwipeLayout;->gestureDetectorCallBack:Landroid/view/GestureDetector$OnGestureListener;

    invoke-direct {v0, v1, v2}, Landroidx/core/view/GestureDetectorCompat;-><init>(Landroid/content/Context;Landroid/view/GestureDetector$OnGestureListener;)V

    iput-object v0, p0, Lcom/zerobranch/layout/SwipeLayout;->gestureDetector:Landroidx/core/view/GestureDetectorCompat;

    .line 218
    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->setupPost()V

    .line 219
    invoke-super {p0}, Landroid/view/View;->onFinishInflate()V

    return-void

    .line 202
    :cond_d
    new-instance v0, Ljava/lang/RuntimeException;

    const-string v1, "\'draggedItem\' must be specified"

    invoke-direct {v0, v1}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method public onInterceptTouchEvent(Landroid/view/MotionEvent;)Z
    .locals 5

    .line 169
    iget-boolean v0, p0, Lcom/zerobranch/layout/SwipeLayout;->disallowIntercept:Z

    const/4 v1, 0x0

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/zerobranch/layout/SwipeLayout;->draggedView:Landroid/view/View;

    invoke-direct {p0, v0}, Lcom/zerobranch/layout/SwipeLayout;->isViewGroup(Landroid/view/View;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 170
    iget-object v0, p0, Lcom/zerobranch/layout/SwipeLayout;->draggedView:Landroid/view/View;

    check-cast v0, Landroid/view/ViewGroup;

    invoke-direct {p0, p1, v0}, Lcom/zerobranch/layout/SwipeLayout;->getNeededTouchView(Landroid/view/MotionEvent;Landroid/view/ViewGroup;)Landroid/view/View;

    move-result-object v0

    .line 171
    new-instance v2, Landroid/graphics/Point;

    invoke-virtual {p1}, Landroid/view/MotionEvent;->getX()F

    move-result v3

    float-to-int v3, v3

    invoke-virtual {p1}, Landroid/view/MotionEvent;->getY()F

    move-result v4

    float-to-int v4, v4

    invoke-direct {v2, v3, v4}, Landroid/graphics/Point;-><init>(II)V

    if-eqz v0, :cond_0

    .line 173
    invoke-direct {p0, v0, v2}, Lcom/zerobranch/layout/SwipeLayout;->isViewTouchTarget(Landroid/view/View;Landroid/graphics/Point;)Z

    move-result v0

    if-eqz v0, :cond_0

    return v1

    .line 178
    :cond_0
    invoke-direct {p0, p1}, Lcom/zerobranch/layout/SwipeLayout;->isSwipeViewTarget(Landroid/view/MotionEvent;)Z

    move-result v0

    if-eqz v0, :cond_1

    iget-object v0, p0, Lcom/zerobranch/layout/SwipeLayout;->dragHelper:Landroidx/customview/widget/ViewDragHelper;

    invoke-virtual {v0, p1}, Landroidx/customview/widget/ViewDragHelper;->shouldInterceptTouchEvent(Landroid/view/MotionEvent;)Z

    move-result p1

    if-eqz p1, :cond_1

    const/4 p1, 0x1

    return p1

    :cond_1
    return v1
.end method

.method protected onSizeChanged(IIII)V
    .locals 0

    .line 163
    iput p1, p0, Lcom/zerobranch/layout/SwipeLayout;->horizontalWidth:I

    .line 164
    invoke-super {p0, p1, p2, p3, p4}, Landroid/view/View;->onSizeChanged(IIII)V

    return-void
.end method

.method public onTouchEvent(Landroid/view/MotionEvent;)Z
    .locals 1

    .line 224
    invoke-direct {p0, p1}, Lcom/zerobranch/layout/SwipeLayout;->isSwipeViewTarget(Landroid/view/MotionEvent;)Z

    move-result v0

    if-nez v0, :cond_1

    invoke-virtual {p0}, Lcom/zerobranch/layout/SwipeLayout;->isMoving()Z

    move-result v0

    if-eqz v0, :cond_0

    goto :goto_0

    .line 229
    :cond_0
    invoke-super {p0, p1}, Landroid/view/View;->onTouchEvent(Landroid/view/MotionEvent;)Z

    move-result p1

    return p1

    .line 225
    :cond_1
    :goto_0
    iget-object v0, p0, Lcom/zerobranch/layout/SwipeLayout;->gestureDetector:Landroidx/core/view/GestureDetectorCompat;

    invoke-virtual {v0, p1}, Landroidx/core/view/GestureDetectorCompat;->onTouchEvent(Landroid/view/MotionEvent;)Z

    .line 226
    iget-object v0, p0, Lcom/zerobranch/layout/SwipeLayout;->dragHelper:Landroidx/customview/widget/ViewDragHelper;

    invoke-virtual {v0, p1}, Landroidx/customview/widget/ViewDragHelper;->processTouchEvent(Landroid/view/MotionEvent;)V

    const/4 p1, 0x1

    return p1
.end method

.method public openLeft()V
    .locals 2

    .line 378
    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->currentDraggingState:I

    invoke-direct {p0, v0}, Lcom/zerobranch/layout/SwipeLayout;->isDragIdle(I)Z

    move-result v0

    if-eqz v0, :cond_2

    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->currentDirection:I

    const/4 v1, 0x2

    if-ne v0, v1, :cond_0

    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->isEmptyLeftView()Z

    move-result v0

    if-eqz v0, :cond_1

    :cond_0
    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->currentDirection:I

    const/4 v1, 0x3

    if-ne v0, v1, :cond_2

    .line 380
    :cond_1
    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->getLeftViewWidth()I

    move-result v0

    invoke-direct {p0, v0}, Lcom/zerobranch/layout/SwipeLayout;->moveTo(I)V

    :cond_2
    return-void
.end method

.method public openLeft(Z)V
    .locals 2

    if-eqz p1, :cond_0

    .line 306
    invoke-virtual {p0}, Lcom/zerobranch/layout/SwipeLayout;->openLeft()V

    return-void

    .line 307
    :cond_0
    iget p1, p0, Lcom/zerobranch/layout/SwipeLayout;->currentDraggingState:I

    invoke-direct {p0, p1}, Lcom/zerobranch/layout/SwipeLayout;->isDragIdle(I)Z

    move-result p1

    if-eqz p1, :cond_7

    iget p1, p0, Lcom/zerobranch/layout/SwipeLayout;->currentDirection:I

    const/4 v0, 0x2

    if-ne p1, v0, :cond_1

    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->isEmptyLeftView()Z

    move-result p1

    if-eqz p1, :cond_2

    :cond_1
    iget p1, p0, Lcom/zerobranch/layout/SwipeLayout;->currentDirection:I

    const/4 v1, 0x3

    if-ne p1, v1, :cond_7

    :cond_2
    iget-boolean p1, p0, Lcom/zerobranch/layout/SwipeLayout;->isLeftOpen:Z

    if-nez p1, :cond_7

    .line 309
    iget-boolean p1, p0, Lcom/zerobranch/layout/SwipeLayout;->isTogether:Z

    if-eqz p1, :cond_4

    .line 310
    iget-object p1, p0, Lcom/zerobranch/layout/SwipeLayout;->staticLeftView:Landroid/view/View;

    iget-boolean v1, p0, Lcom/zerobranch/layout/SwipeLayout;->isRightOpen:Z

    if-eqz v1, :cond_3

    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->getLeftViewWidth()I

    move-result v1

    mul-int/2addr v1, v0

    goto :goto_0

    :cond_3
    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->getLeftViewWidth()I

    move-result v1

    :goto_0
    invoke-virtual {p1, v1}, Landroid/view/View;->offsetLeftAndRight(I)V

    .line 313
    :cond_4
    iget-object p1, p0, Lcom/zerobranch/layout/SwipeLayout;->draggedView:Landroid/view/View;

    iget-boolean v1, p0, Lcom/zerobranch/layout/SwipeLayout;->isRightOpen:Z

    if-eqz v1, :cond_5

    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->getLeftViewWidth()I

    move-result v1

    mul-int/2addr v1, v0

    goto :goto_1

    :cond_5
    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->getLeftViewWidth()I

    move-result v1

    :goto_1
    invoke-virtual {p1, v1}, Landroid/view/View;->offsetLeftAndRight(I)V

    .line 314
    iget p1, p0, Lcom/zerobranch/layout/SwipeLayout;->draggingViewLeft:I

    iget-boolean v1, p0, Lcom/zerobranch/layout/SwipeLayout;->isRightOpen:Z

    if-eqz v1, :cond_6

    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->getLeftViewWidth()I

    move-result v1

    mul-int/2addr v1, v0

    goto :goto_2

    :cond_6
    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->getLeftViewWidth()I

    move-result v1

    :goto_2
    add-int/2addr p1, v1

    iput p1, p0, Lcom/zerobranch/layout/SwipeLayout;->draggingViewLeft:I

    .line 315
    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->updateState()V

    :cond_7
    return-void
.end method

.method public openLeftCompletely()V
    .locals 2

    .line 398
    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->currentDraggingState:I

    invoke-direct {p0, v0}, Lcom/zerobranch/layout/SwipeLayout;->isDragIdle(I)Z

    move-result v0

    if-eqz v0, :cond_0

    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->currentDirection:I

    const/4 v1, 0x2

    if-ne v0, v1, :cond_0

    .line 399
    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->horizontalWidth:I

    invoke-direct {p0, v0}, Lcom/zerobranch/layout/SwipeLayout;->moveTo(I)V

    :cond_0
    return-void
.end method

.method public openLeftCompletely(Z)V
    .locals 1

    if-eqz p1, :cond_0

    .line 326
    invoke-virtual {p0}, Lcom/zerobranch/layout/SwipeLayout;->openRightCompletely()V

    return-void

    .line 328
    :cond_0
    iget p1, p0, Lcom/zerobranch/layout/SwipeLayout;->currentDraggingState:I

    invoke-direct {p0, p1}, Lcom/zerobranch/layout/SwipeLayout;->isDragIdle(I)Z

    move-result p1

    if-eqz p1, :cond_2

    iget p1, p0, Lcom/zerobranch/layout/SwipeLayout;->currentDirection:I

    const/4 v0, 0x2

    if-ne p1, v0, :cond_2

    .line 329
    iget-boolean p1, p0, Lcom/zerobranch/layout/SwipeLayout;->isTogether:Z

    if-eqz p1, :cond_1

    .line 330
    iget-object p1, p0, Lcom/zerobranch/layout/SwipeLayout;->staticRightView:Landroid/view/View;

    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->horizontalWidth:I

    invoke-virtual {p1, v0}, Landroid/view/View;->offsetLeftAndRight(I)V

    .line 333
    :cond_1
    iget-object p1, p0, Lcom/zerobranch/layout/SwipeLayout;->draggedView:Landroid/view/View;

    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->horizontalWidth:I

    invoke-virtual {p1, v0}, Landroid/view/View;->offsetLeftAndRight(I)V

    .line 334
    iget p1, p0, Lcom/zerobranch/layout/SwipeLayout;->draggingViewLeft:I

    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->horizontalWidth:I

    add-int/2addr p1, v0

    iput p1, p0, Lcom/zerobranch/layout/SwipeLayout;->draggingViewLeft:I

    .line 335
    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->updateState()V

    :cond_2
    return-void
.end method

.method public openRight()V
    .locals 2

    .line 388
    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->currentDraggingState:I

    invoke-direct {p0, v0}, Lcom/zerobranch/layout/SwipeLayout;->isDragIdle(I)Z

    move-result v0

    if-eqz v0, :cond_2

    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->currentDirection:I

    const/4 v1, 0x1

    if-ne v0, v1, :cond_0

    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->isEmptyRightView()Z

    move-result v0

    if-eqz v0, :cond_1

    :cond_0
    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->currentDirection:I

    const/4 v1, 0x3

    if-ne v0, v1, :cond_2

    .line 390
    :cond_1
    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->getRightViewWidth()I

    move-result v0

    neg-int v0, v0

    invoke-direct {p0, v0}, Lcom/zerobranch/layout/SwipeLayout;->moveTo(I)V

    :cond_2
    return-void
.end method

.method public openRight(Z)V
    .locals 1

    if-eqz p1, :cond_0

    .line 265
    invoke-virtual {p0}, Lcom/zerobranch/layout/SwipeLayout;->openRight()V

    return-void

    .line 266
    :cond_0
    iget p1, p0, Lcom/zerobranch/layout/SwipeLayout;->currentDraggingState:I

    invoke-direct {p0, p1}, Lcom/zerobranch/layout/SwipeLayout;->isDragIdle(I)Z

    move-result p1

    if-eqz p1, :cond_7

    iget p1, p0, Lcom/zerobranch/layout/SwipeLayout;->currentDirection:I

    const/4 v0, 0x1

    if-ne p1, v0, :cond_1

    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->isEmptyRightView()Z

    move-result p1

    if-eqz p1, :cond_2

    :cond_1
    iget p1, p0, Lcom/zerobranch/layout/SwipeLayout;->currentDirection:I

    const/4 v0, 0x3

    if-ne p1, v0, :cond_7

    :cond_2
    iget-boolean p1, p0, Lcom/zerobranch/layout/SwipeLayout;->isRightOpen:Z

    if-nez p1, :cond_7

    .line 268
    iget-boolean p1, p0, Lcom/zerobranch/layout/SwipeLayout;->isTogether:Z

    if-eqz p1, :cond_4

    .line 269
    iget-object p1, p0, Lcom/zerobranch/layout/SwipeLayout;->staticRightView:Landroid/view/View;

    iget-boolean v0, p0, Lcom/zerobranch/layout/SwipeLayout;->isLeftOpen:Z

    if-eqz v0, :cond_3

    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->getRightViewWidth()I

    move-result v0

    mul-int/lit8 v0, v0, 0x2

    goto :goto_0

    :cond_3
    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->getRightViewWidth()I

    move-result v0

    :goto_0
    mul-int/lit8 v0, v0, -0x1

    invoke-virtual {p1, v0}, Landroid/view/View;->offsetLeftAndRight(I)V

    .line 272
    :cond_4
    iget-object p1, p0, Lcom/zerobranch/layout/SwipeLayout;->draggedView:Landroid/view/View;

    iget-boolean v0, p0, Lcom/zerobranch/layout/SwipeLayout;->isLeftOpen:Z

    if-eqz v0, :cond_5

    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->getRightViewWidth()I

    move-result v0

    mul-int/lit8 v0, v0, 0x2

    goto :goto_1

    :cond_5
    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->getRightViewWidth()I

    move-result v0

    :goto_1
    mul-int/lit8 v0, v0, -0x1

    invoke-virtual {p1, v0}, Landroid/view/View;->offsetLeftAndRight(I)V

    .line 273
    iget p1, p0, Lcom/zerobranch/layout/SwipeLayout;->draggingViewLeft:I

    iget-boolean v0, p0, Lcom/zerobranch/layout/SwipeLayout;->isLeftOpen:Z

    if-eqz v0, :cond_6

    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->getRightViewWidth()I

    move-result v0

    mul-int/lit8 v0, v0, 0x2

    goto :goto_2

    :cond_6
    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->getRightViewWidth()I

    move-result v0

    :goto_2
    sub-int/2addr p1, v0

    iput p1, p0, Lcom/zerobranch/layout/SwipeLayout;->draggingViewLeft:I

    .line 274
    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->updateState()V

    :cond_7
    return-void
.end method

.method public openRightCompletely()V
    .locals 2

    .line 407
    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->currentDraggingState:I

    invoke-direct {p0, v0}, Lcom/zerobranch/layout/SwipeLayout;->isDragIdle(I)Z

    move-result v0

    if-eqz v0, :cond_0

    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->currentDirection:I

    const/4 v1, 0x1

    if-ne v0, v1, :cond_0

    .line 408
    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->horizontalWidth:I

    neg-int v0, v0

    invoke-direct {p0, v0}, Lcom/zerobranch/layout/SwipeLayout;->moveTo(I)V

    :cond_0
    return-void
.end method

.method public openRightCompletely(Z)V
    .locals 1

    if-eqz p1, :cond_0

    .line 285
    invoke-virtual {p0}, Lcom/zerobranch/layout/SwipeLayout;->openRightCompletely()V

    return-void

    .line 287
    :cond_0
    iget p1, p0, Lcom/zerobranch/layout/SwipeLayout;->currentDraggingState:I

    invoke-direct {p0, p1}, Lcom/zerobranch/layout/SwipeLayout;->isDragIdle(I)Z

    move-result p1

    if-eqz p1, :cond_2

    iget p1, p0, Lcom/zerobranch/layout/SwipeLayout;->currentDirection:I

    const/4 v0, 0x1

    if-ne p1, v0, :cond_2

    .line 288
    iget-boolean p1, p0, Lcom/zerobranch/layout/SwipeLayout;->isTogether:Z

    if-eqz p1, :cond_1

    .line 289
    iget-object p1, p0, Lcom/zerobranch/layout/SwipeLayout;->staticRightView:Landroid/view/View;

    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->horizontalWidth:I

    neg-int v0, v0

    invoke-virtual {p1, v0}, Landroid/view/View;->offsetLeftAndRight(I)V

    .line 292
    :cond_1
    iget-object p1, p0, Lcom/zerobranch/layout/SwipeLayout;->draggedView:Landroid/view/View;

    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->horizontalWidth:I

    neg-int v0, v0

    invoke-virtual {p1, v0}, Landroid/view/View;->offsetLeftAndRight(I)V

    .line 293
    iget p1, p0, Lcom/zerobranch/layout/SwipeLayout;->draggingViewLeft:I

    iget v0, p0, Lcom/zerobranch/layout/SwipeLayout;->horizontalWidth:I

    sub-int/2addr p1, v0

    iput p1, p0, Lcom/zerobranch/layout/SwipeLayout;->draggingViewLeft:I

    .line 294
    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->updateState()V

    :cond_2
    return-void
.end method

.method public requestDisallowInterceptTouchEvent(Z)V
    .locals 0

    .line 183
    invoke-super {p0, p1}, Landroid/view/ViewGroup;->requestDisallowInterceptTouchEvent(Z)V

    .line 184
    iput-boolean p1, p0, Lcom/zerobranch/layout/SwipeLayout;->disallowIntercept:Z

    return-void
.end method

.method public setContinuousSwipe(Z)Lcom/zerobranch/layout/SwipeLayout;
    .locals 0

    .line 489
    iput-boolean p1, p0, Lcom/zerobranch/layout/SwipeLayout;->isContinuousSwipe:Z

    .line 490
    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->parametersAdjustment()V

    return-object p0
.end method

.method public setCurrentDirection(I)Lcom/zerobranch/layout/SwipeLayout;
    .locals 0

    .line 445
    iput p1, p0, Lcom/zerobranch/layout/SwipeLayout;->currentDirection:I

    return-object p0
.end method

.method public setEnabledSwipe(Z)V
    .locals 0

    .line 255
    iput-boolean p1, p0, Lcom/zerobranch/layout/SwipeLayout;->isEnabledSwipe:Z

    return-void
.end method

.method public setFreeDragAfterOpen(Z)Lcom/zerobranch/layout/SwipeLayout;
    .locals 0

    .line 511
    iput-boolean p1, p0, Lcom/zerobranch/layout/SwipeLayout;->isFreeDragAfterOpen:Z

    .line 512
    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->parametersAdjustment()V

    return-object p0
.end method

.method public setFreeHorizontalDrag(Z)Lcom/zerobranch/layout/SwipeLayout;
    .locals 0

    .line 535
    iput-boolean p1, p0, Lcom/zerobranch/layout/SwipeLayout;->isFreeHorizontalDrag:Z

    return-object p0
.end method

.method public setLeftDragViewPadding(I)Lcom/zerobranch/layout/SwipeLayout;
    .locals 0

    .line 588
    iput p1, p0, Lcom/zerobranch/layout/SwipeLayout;->leftDragViewPadding:I

    .line 589
    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->parametersAdjustment()V

    return-object p0
.end method

.method public setOnActionsListener(Lcom/zerobranch/layout/SwipeLayout$SwipeActionsListener;)Lcom/zerobranch/layout/SwipeLayout;
    .locals 0

    .line 557
    iput-object p1, p0, Lcom/zerobranch/layout/SwipeLayout;->actionsListener:Lcom/zerobranch/layout/SwipeLayout$SwipeActionsListener;

    return-object p0
.end method

.method public setRightDragViewPadding(I)Lcom/zerobranch/layout/SwipeLayout;
    .locals 0

    .line 572
    iput p1, p0, Lcom/zerobranch/layout/SwipeLayout;->rightDragViewPadding:I

    .line 573
    invoke-direct {p0}, Lcom/zerobranch/layout/SwipeLayout;->parametersAdjustment()V

    return-object p0
.end method

.method public setTogether(Z)Lcom/zerobranch/layout/SwipeLayout;
    .locals 0

    .line 460
    iput-boolean p1, p0, Lcom/zerobranch/layout/SwipeLayout;->isTogether:Z

    return-object p0
.end method
