.class Lme/relex/circleindicator/BaseCircleIndicator;
.super Landroid/widget/LinearLayout;
.source "BaseCircleIndicator.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lme/relex/circleindicator/BaseCircleIndicator$ReverseInterpolator;,
        Lme/relex/circleindicator/BaseCircleIndicator$IndicatorCreatedListener;
    }
.end annotation


# instance fields
.field protected mAnimatorIn:Landroid/animation/Animator;

.field protected mAnimatorOut:Landroid/animation/Animator;

.field protected mImmediateAnimatorIn:Landroid/animation/Animator;

.field protected mImmediateAnimatorOut:Landroid/animation/Animator;

.field protected mIndicatorBackgroundResId:I

.field protected mIndicatorHeight:I

.field protected mIndicatorMargin:I

.field protected mIndicatorUnselectedBackgroundResId:I

.field protected mIndicatorWidth:I

.field protected mLastPosition:I


# direct methods
.method public constructor <init>(Landroid/content/Context;)V
    .locals 1

    .line 38
    invoke-direct {p0, p1}, Landroid/widget/LinearLayout;-><init>(Landroid/content/Context;)V

    const/4 v0, -0x1

    .line 21
    iput v0, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mIndicatorMargin:I

    .line 22
    iput v0, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mIndicatorWidth:I

    .line 23
    iput v0, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mIndicatorHeight:I

    .line 33
    iput v0, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mLastPosition:I

    const/4 v0, 0x0

    .line 39
    invoke-direct {p0, p1, v0}, Lme/relex/circleindicator/BaseCircleIndicator;->init(Landroid/content/Context;Landroid/util/AttributeSet;)V

    return-void
.end method

.method public constructor <init>(Landroid/content/Context;Landroid/util/AttributeSet;)V
    .locals 1

    .line 43
    invoke-direct {p0, p1, p2}, Landroid/widget/LinearLayout;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;)V

    const/4 v0, -0x1

    .line 21
    iput v0, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mIndicatorMargin:I

    .line 22
    iput v0, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mIndicatorWidth:I

    .line 23
    iput v0, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mIndicatorHeight:I

    .line 33
    iput v0, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mLastPosition:I

    .line 44
    invoke-direct {p0, p1, p2}, Lme/relex/circleindicator/BaseCircleIndicator;->init(Landroid/content/Context;Landroid/util/AttributeSet;)V

    return-void
.end method

.method public constructor <init>(Landroid/content/Context;Landroid/util/AttributeSet;I)V
    .locals 0

    .line 48
    invoke-direct {p0, p1, p2, p3}, Landroid/widget/LinearLayout;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;I)V

    const/4 p3, -0x1

    .line 21
    iput p3, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mIndicatorMargin:I

    .line 22
    iput p3, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mIndicatorWidth:I

    .line 23
    iput p3, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mIndicatorHeight:I

    .line 33
    iput p3, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mLastPosition:I

    .line 49
    invoke-direct {p0, p1, p2}, Lme/relex/circleindicator/BaseCircleIndicator;->init(Landroid/content/Context;Landroid/util/AttributeSet;)V

    return-void
.end method

.method public constructor <init>(Landroid/content/Context;Landroid/util/AttributeSet;II)V
    .locals 0

    .line 55
    invoke-direct {p0, p1, p2, p3, p4}, Landroid/widget/LinearLayout;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;II)V

    const/4 p3, -0x1

    .line 21
    iput p3, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mIndicatorMargin:I

    .line 22
    iput p3, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mIndicatorWidth:I

    .line 23
    iput p3, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mIndicatorHeight:I

    .line 33
    iput p3, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mLastPosition:I

    .line 56
    invoke-direct {p0, p1, p2}, Lme/relex/circleindicator/BaseCircleIndicator;->init(Landroid/content/Context;Landroid/util/AttributeSet;)V

    return-void
.end method

.method private handleTypedArray(Landroid/content/Context;Landroid/util/AttributeSet;)Lme/relex/circleindicator/Config;
    .locals 3

    .line 65
    new-instance v0, Lme/relex/circleindicator/Config;

    invoke-direct {v0}, Lme/relex/circleindicator/Config;-><init>()V

    if-nez p2, :cond_0

    return-object v0

    .line 69
    :cond_0
    sget-object v1, Lme/relex/circleindicator/R$styleable;->BaseCircleIndicator:[I

    .line 70
    invoke-virtual {p1, p2, v1}, Landroid/content/Context;->obtainStyledAttributes(Landroid/util/AttributeSet;[I)Landroid/content/res/TypedArray;

    move-result-object p1

    .line 71
    sget p2, Lme/relex/circleindicator/R$styleable;->BaseCircleIndicator_ci_width:I

    const/4 v1, -0x1

    .line 72
    invoke-virtual {p1, p2, v1}, Landroid/content/res/TypedArray;->getDimensionPixelSize(II)I

    move-result p2

    iput p2, v0, Lme/relex/circleindicator/Config;->width:I

    .line 73
    sget p2, Lme/relex/circleindicator/R$styleable;->BaseCircleIndicator_ci_height:I

    .line 74
    invoke-virtual {p1, p2, v1}, Landroid/content/res/TypedArray;->getDimensionPixelSize(II)I

    move-result p2

    iput p2, v0, Lme/relex/circleindicator/Config;->height:I

    .line 75
    sget p2, Lme/relex/circleindicator/R$styleable;->BaseCircleIndicator_ci_margin:I

    .line 76
    invoke-virtual {p1, p2, v1}, Landroid/content/res/TypedArray;->getDimensionPixelSize(II)I

    move-result p2

    iput p2, v0, Lme/relex/circleindicator/Config;->margin:I

    .line 77
    sget p2, Lme/relex/circleindicator/R$styleable;->BaseCircleIndicator_ci_animator:I

    sget v2, Lme/relex/circleindicator/R$animator;->scale_with_alpha:I

    invoke-virtual {p1, p2, v2}, Landroid/content/res/TypedArray;->getResourceId(II)I

    move-result p2

    iput p2, v0, Lme/relex/circleindicator/Config;->animatorResId:I

    .line 79
    sget p2, Lme/relex/circleindicator/R$styleable;->BaseCircleIndicator_ci_animator_reverse:I

    const/4 v2, 0x0

    .line 80
    invoke-virtual {p1, p2, v2}, Landroid/content/res/TypedArray;->getResourceId(II)I

    move-result p2

    iput p2, v0, Lme/relex/circleindicator/Config;->animatorReverseResId:I

    .line 81
    sget p2, Lme/relex/circleindicator/R$styleable;->BaseCircleIndicator_ci_drawable:I

    sget v2, Lme/relex/circleindicator/R$drawable;->white_radius:I

    .line 82
    invoke-virtual {p1, p2, v2}, Landroid/content/res/TypedArray;->getResourceId(II)I

    move-result p2

    iput p2, v0, Lme/relex/circleindicator/Config;->backgroundResId:I

    .line 84
    sget v2, Lme/relex/circleindicator/R$styleable;->BaseCircleIndicator_ci_drawable_unselected:I

    .line 85
    invoke-virtual {p1, v2, p2}, Landroid/content/res/TypedArray;->getResourceId(II)I

    move-result p2

    iput p2, v0, Lme/relex/circleindicator/Config;->unselectedBackgroundId:I

    .line 87
    sget p2, Lme/relex/circleindicator/R$styleable;->BaseCircleIndicator_ci_orientation:I

    invoke-virtual {p1, p2, v1}, Landroid/content/res/TypedArray;->getInt(II)I

    move-result p2

    iput p2, v0, Lme/relex/circleindicator/Config;->orientation:I

    .line 88
    sget p2, Lme/relex/circleindicator/R$styleable;->BaseCircleIndicator_ci_gravity:I

    invoke-virtual {p1, p2, v1}, Landroid/content/res/TypedArray;->getInt(II)I

    move-result p2

    iput p2, v0, Lme/relex/circleindicator/Config;->gravity:I

    .line 89
    invoke-virtual {p1}, Landroid/content/res/TypedArray;->recycle()V

    return-object v0
.end method

.method private init(Landroid/content/Context;Landroid/util/AttributeSet;)V
    .locals 0

    .line 60
    invoke-direct {p0, p1, p2}, Lme/relex/circleindicator/BaseCircleIndicator;->handleTypedArray(Landroid/content/Context;Landroid/util/AttributeSet;)Lme/relex/circleindicator/Config;

    move-result-object p1

    .line 61
    invoke-virtual {p0, p1}, Lme/relex/circleindicator/BaseCircleIndicator;->initialize(Lme/relex/circleindicator/Config;)V

    return-void
.end method


# virtual methods
.method protected addIndicator(I)V
    .locals 3

    .line 197
    new-instance v0, Landroid/view/View;

    invoke-virtual {p0}, Landroid/view/View;->getContext()Landroid/content/Context;

    move-result-object v1

    invoke-direct {v0, v1}, Landroid/view/View;-><init>(Landroid/content/Context;)V

    .line 198
    invoke-virtual {p0}, Landroid/widget/LinearLayout;->generateDefaultLayoutParams()Landroid/widget/LinearLayout$LayoutParams;

    move-result-object v1

    .line 199
    iget v2, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mIndicatorWidth:I

    iput v2, v1, Landroid/widget/LinearLayout$LayoutParams;->width:I

    .line 200
    iget v2, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mIndicatorHeight:I

    iput v2, v1, Landroid/widget/LinearLayout$LayoutParams;->height:I

    if-nez p1, :cond_0

    .line 202
    iget p1, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mIndicatorMargin:I

    iput p1, v1, Landroid/widget/LinearLayout$LayoutParams;->leftMargin:I

    .line 203
    iput p1, v1, Landroid/widget/LinearLayout$LayoutParams;->rightMargin:I

    goto :goto_0

    .line 205
    :cond_0
    iget p1, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mIndicatorMargin:I

    iput p1, v1, Landroid/widget/LinearLayout$LayoutParams;->topMargin:I

    .line 206
    iput p1, v1, Landroid/widget/LinearLayout$LayoutParams;->bottomMargin:I

    .line 208
    :goto_0
    invoke-virtual {p0, v0, v1}, Landroid/view/ViewGroup;->addView(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V

    return-void
.end method

.method public animatePageSelected(I)V
    .locals 2

    .line 213
    iget v0, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mLastPosition:I

    if-ne v0, p1, :cond_0

    return-void

    .line 217
    :cond_0
    iget-object v0, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mAnimatorIn:Landroid/animation/Animator;

    invoke-virtual {v0}, Landroid/animation/Animator;->isRunning()Z

    move-result v0

    if-eqz v0, :cond_1

    .line 218
    iget-object v0, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mAnimatorIn:Landroid/animation/Animator;

    invoke-virtual {v0}, Landroid/animation/Animator;->end()V

    .line 219
    iget-object v0, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mAnimatorIn:Landroid/animation/Animator;

    invoke-virtual {v0}, Landroid/animation/Animator;->cancel()V

    .line 222
    :cond_1
    iget-object v0, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mAnimatorOut:Landroid/animation/Animator;

    invoke-virtual {v0}, Landroid/animation/Animator;->isRunning()Z

    move-result v0

    if-eqz v0, :cond_2

    .line 223
    iget-object v0, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mAnimatorOut:Landroid/animation/Animator;

    invoke-virtual {v0}, Landroid/animation/Animator;->end()V

    .line 224
    iget-object v0, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mAnimatorOut:Landroid/animation/Animator;

    invoke-virtual {v0}, Landroid/animation/Animator;->cancel()V

    .line 228
    :cond_2
    iget v0, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mLastPosition:I

    if-ltz v0, :cond_3

    invoke-virtual {p0, v0}, Landroid/view/ViewGroup;->getChildAt(I)Landroid/view/View;

    move-result-object v0

    if-eqz v0, :cond_3

    .line 229
    iget v1, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mIndicatorUnselectedBackgroundResId:I

    invoke-virtual {v0, v1}, Landroid/view/View;->setBackgroundResource(I)V

    .line 230
    iget-object v1, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mAnimatorIn:Landroid/animation/Animator;

    invoke-virtual {v1, v0}, Landroid/animation/Animator;->setTarget(Ljava/lang/Object;)V

    .line 231
    iget-object v0, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mAnimatorIn:Landroid/animation/Animator;

    invoke-virtual {v0}, Landroid/animation/Animator;->start()V

    .line 234
    :cond_3
    invoke-virtual {p0, p1}, Landroid/view/ViewGroup;->getChildAt(I)Landroid/view/View;

    move-result-object v0

    if-eqz v0, :cond_4

    .line 236
    iget v1, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mIndicatorBackgroundResId:I

    invoke-virtual {v0, v1}, Landroid/view/View;->setBackgroundResource(I)V

    .line 237
    iget-object v1, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mAnimatorOut:Landroid/animation/Animator;

    invoke-virtual {v1, v0}, Landroid/animation/Animator;->setTarget(Ljava/lang/Object;)V

    .line 238
    iget-object v0, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mAnimatorOut:Landroid/animation/Animator;

    invoke-virtual {v0}, Landroid/animation/Animator;->start()V

    .line 240
    :cond_4
    iput p1, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mLastPosition:I

    return-void
.end method

.method protected createAnimatorIn(Lme/relex/circleindicator/Config;)Landroid/animation/Animator;
    .locals 1

    .line 140
    iget v0, p1, Lme/relex/circleindicator/Config;->animatorReverseResId:I

    if-nez v0, :cond_0

    .line 141
    invoke-virtual {p0}, Landroid/view/View;->getContext()Landroid/content/Context;

    move-result-object v0

    iget p1, p1, Lme/relex/circleindicator/Config;->animatorResId:I

    invoke-static {v0, p1}, Landroid/animation/AnimatorInflater;->loadAnimator(Landroid/content/Context;I)Landroid/animation/Animator;

    move-result-object p1

    .line 142
    new-instance v0, Lme/relex/circleindicator/BaseCircleIndicator$ReverseInterpolator;

    invoke-direct {v0, p0}, Lme/relex/circleindicator/BaseCircleIndicator$ReverseInterpolator;-><init>(Lme/relex/circleindicator/BaseCircleIndicator;)V

    invoke-virtual {p1, v0}, Landroid/animation/Animator;->setInterpolator(Landroid/animation/TimeInterpolator;)V

    return-object p1

    .line 144
    :cond_0
    invoke-virtual {p0}, Landroid/view/View;->getContext()Landroid/content/Context;

    move-result-object v0

    iget p1, p1, Lme/relex/circleindicator/Config;->animatorReverseResId:I

    invoke-static {v0, p1}, Landroid/animation/AnimatorInflater;->loadAnimator(Landroid/content/Context;I)Landroid/animation/Animator;

    move-result-object p1

    return-object p1
.end method

.method protected createAnimatorOut(Lme/relex/circleindicator/Config;)Landroid/animation/Animator;
    .locals 1

    .line 135
    invoke-virtual {p0}, Landroid/view/View;->getContext()Landroid/content/Context;

    move-result-object v0

    iget p1, p1, Lme/relex/circleindicator/Config;->animatorResId:I

    invoke-static {v0, p1}, Landroid/animation/AnimatorInflater;->loadAnimator(Landroid/content/Context;I)Landroid/animation/Animator;

    move-result-object p1

    return-object p1
.end method

.method public createIndicators(II)V
    .locals 4

    .line 150
    iget-object v0, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mImmediateAnimatorOut:Landroid/animation/Animator;

    invoke-virtual {v0}, Landroid/animation/Animator;->isRunning()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 151
    iget-object v0, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mImmediateAnimatorOut:Landroid/animation/Animator;

    invoke-virtual {v0}, Landroid/animation/Animator;->end()V

    .line 152
    iget-object v0, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mImmediateAnimatorOut:Landroid/animation/Animator;

    invoke-virtual {v0}, Landroid/animation/Animator;->cancel()V

    .line 155
    :cond_0
    iget-object v0, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mImmediateAnimatorIn:Landroid/animation/Animator;

    invoke-virtual {v0}, Landroid/animation/Animator;->isRunning()Z

    move-result v0

    if-eqz v0, :cond_1

    .line 156
    iget-object v0, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mImmediateAnimatorIn:Landroid/animation/Animator;

    invoke-virtual {v0}, Landroid/animation/Animator;->end()V

    .line 157
    iget-object v0, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mImmediateAnimatorIn:Landroid/animation/Animator;

    invoke-virtual {v0}, Landroid/animation/Animator;->cancel()V

    .line 161
    :cond_1
    invoke-virtual {p0}, Landroid/view/ViewGroup;->getChildCount()I

    move-result v0

    const/4 v1, 0x0

    if-ge p1, v0, :cond_2

    sub-int/2addr v0, p1

    .line 163
    invoke-virtual {p0, p1, v0}, Landroid/view/ViewGroup;->removeViews(II)V

    goto :goto_1

    :cond_2
    if-le p1, v0, :cond_3

    sub-int v0, p1, v0

    .line 166
    invoke-virtual {p0}, Landroid/widget/LinearLayout;->getOrientation()I

    move-result v2

    move v3, v1

    :goto_0
    if-ge v3, v0, :cond_3

    .line 168
    invoke-virtual {p0, v2}, Lme/relex/circleindicator/BaseCircleIndicator;->addIndicator(I)V

    add-int/lit8 v3, v3, 0x1

    goto :goto_0

    :cond_3
    :goto_1
    if-ge v1, p1, :cond_5

    .line 175
    invoke-virtual {p0, v1}, Landroid/view/ViewGroup;->getChildAt(I)Landroid/view/View;

    move-result-object v0

    if-ne p2, v1, :cond_4

    .line 177
    iget v2, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mIndicatorBackgroundResId:I

    invoke-virtual {v0, v2}, Landroid/view/View;->setBackgroundResource(I)V

    .line 178
    iget-object v2, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mImmediateAnimatorOut:Landroid/animation/Animator;

    invoke-virtual {v2, v0}, Landroid/animation/Animator;->setTarget(Ljava/lang/Object;)V

    .line 179
    iget-object v0, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mImmediateAnimatorOut:Landroid/animation/Animator;

    invoke-virtual {v0}, Landroid/animation/Animator;->start()V

    .line 180
    iget-object v0, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mImmediateAnimatorOut:Landroid/animation/Animator;

    invoke-virtual {v0}, Landroid/animation/Animator;->end()V

    goto :goto_2

    .line 182
    :cond_4
    iget v2, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mIndicatorUnselectedBackgroundResId:I

    invoke-virtual {v0, v2}, Landroid/view/View;->setBackgroundResource(I)V

    .line 183
    iget-object v2, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mImmediateAnimatorIn:Landroid/animation/Animator;

    invoke-virtual {v2, v0}, Landroid/animation/Animator;->setTarget(Ljava/lang/Object;)V

    .line 184
    iget-object v0, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mImmediateAnimatorIn:Landroid/animation/Animator;

    invoke-virtual {v0}, Landroid/animation/Animator;->start()V

    .line 185
    iget-object v0, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mImmediateAnimatorIn:Landroid/animation/Animator;

    invoke-virtual {v0}, Landroid/animation/Animator;->end()V

    :goto_2
    add-int/lit8 v1, v1, 0x1

    goto :goto_1

    .line 193
    :cond_5
    iput p2, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mLastPosition:I

    return-void
.end method

.method public initialize(Lme/relex/circleindicator/Config;)V
    .locals 4

    .line 96
    invoke-virtual {p0}, Landroid/view/View;->getResources()Landroid/content/res/Resources;

    move-result-object v0

    invoke-virtual {v0}, Landroid/content/res/Resources;->getDisplayMetrics()Landroid/util/DisplayMetrics;

    move-result-object v0

    const/4 v1, 0x1

    const/high16 v2, 0x40a00000    # 5.0f

    .line 95
    invoke-static {v1, v2, v0}, Landroid/util/TypedValue;->applyDimension(IFLandroid/util/DisplayMetrics;)F

    move-result v0

    const/high16 v2, 0x3f000000    # 0.5f

    add-float/2addr v0, v2

    float-to-int v0, v0

    .line 97
    iget v2, p1, Lme/relex/circleindicator/Config;->width:I

    if-gez v2, :cond_0

    move v2, v0

    :cond_0
    iput v2, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mIndicatorWidth:I

    .line 98
    iget v2, p1, Lme/relex/circleindicator/Config;->height:I

    if-gez v2, :cond_1

    move v2, v0

    :cond_1
    iput v2, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mIndicatorHeight:I

    .line 99
    iget v2, p1, Lme/relex/circleindicator/Config;->margin:I

    if-gez v2, :cond_2

    goto :goto_0

    :cond_2
    move v0, v2

    :goto_0
    iput v0, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mIndicatorMargin:I

    .line 101
    invoke-virtual {p0, p1}, Lme/relex/circleindicator/BaseCircleIndicator;->createAnimatorOut(Lme/relex/circleindicator/Config;)Landroid/animation/Animator;

    move-result-object v0

    iput-object v0, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mAnimatorOut:Landroid/animation/Animator;

    .line 102
    invoke-virtual {p0, p1}, Lme/relex/circleindicator/BaseCircleIndicator;->createAnimatorOut(Lme/relex/circleindicator/Config;)Landroid/animation/Animator;

    move-result-object v0

    iput-object v0, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mImmediateAnimatorOut:Landroid/animation/Animator;

    const-wide/16 v2, 0x0

    .line 103
    invoke-virtual {v0, v2, v3}, Landroid/animation/Animator;->setDuration(J)Landroid/animation/Animator;

    .line 105
    invoke-virtual {p0, p1}, Lme/relex/circleindicator/BaseCircleIndicator;->createAnimatorIn(Lme/relex/circleindicator/Config;)Landroid/animation/Animator;

    move-result-object v0

    iput-object v0, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mAnimatorIn:Landroid/animation/Animator;

    .line 106
    invoke-virtual {p0, p1}, Lme/relex/circleindicator/BaseCircleIndicator;->createAnimatorIn(Lme/relex/circleindicator/Config;)Landroid/animation/Animator;

    move-result-object v0

    iput-object v0, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mImmediateAnimatorIn:Landroid/animation/Animator;

    .line 107
    invoke-virtual {v0, v2, v3}, Landroid/animation/Animator;->setDuration(J)Landroid/animation/Animator;

    .line 109
    iget v0, p1, Lme/relex/circleindicator/Config;->backgroundResId:I

    if-nez v0, :cond_3

    sget v2, Lme/relex/circleindicator/R$drawable;->white_radius:I

    goto :goto_1

    :cond_3
    move v2, v0

    :goto_1
    iput v2, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mIndicatorBackgroundResId:I

    .line 111
    iget v2, p1, Lme/relex/circleindicator/Config;->unselectedBackgroundId:I

    if-nez v2, :cond_4

    goto :goto_2

    :cond_4
    move v0, v2

    :goto_2
    iput v0, p0, Lme/relex/circleindicator/BaseCircleIndicator;->mIndicatorUnselectedBackgroundResId:I

    .line 115
    iget v0, p1, Lme/relex/circleindicator/Config;->orientation:I

    if-ne v0, v1, :cond_5

    goto :goto_3

    :cond_5
    const/4 v1, 0x0

    :goto_3
    invoke-virtual {p0, v1}, Landroid/widget/LinearLayout;->setOrientation(I)V

    .line 116
    iget p1, p1, Lme/relex/circleindicator/Config;->gravity:I

    if-ltz p1, :cond_6

    goto :goto_4

    :cond_6
    const/16 p1, 0x11

    :goto_4
    invoke-virtual {p0, p1}, Landroid/widget/LinearLayout;->setGravity(I)V

    return-void
.end method

.method public setIndicatorCreatedListener(Lme/relex/circleindicator/BaseCircleIndicator$IndicatorCreatedListener;)V
    .locals 0

    .line 0
    return-void
.end method
