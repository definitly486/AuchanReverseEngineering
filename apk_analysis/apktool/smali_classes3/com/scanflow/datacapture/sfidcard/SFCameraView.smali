.class public Lcom/scanflow/datacapture/sfidcard/SFCameraView;
.super Landroid/widget/FrameLayout;
.source "SourceFile"


# instance fields
.field private arOverlayView:Lcom/scanflow/ui/ar/ArOverlayView;

.field private img_card_flip:Landroid/widget/ImageView;

.field private isBorderCornersRounded:Ljava/lang/Boolean;

.field private mBottomLeftColor:Ljava/lang/Integer;

.field private mBottomRightColor:Ljava/lang/Integer;

.field private mTopLeftColor:Ljava/lang/Integer;

.field private mTopRightColor:Ljava/lang/Integer;

.field private previewView:Landroidx/camera/view/PreviewView;

.field private surfaceView:Landroid/view/SurfaceView;

.field private textView:Landroid/widget/TextView;


# direct methods
.method public constructor <init>(Landroid/content/Context;)V
    .locals 1

    const/4 v0, 0x0

    .line 1
    invoke-direct {p0, p1, v0}, Landroid/widget/FrameLayout;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;)V

    sget-object p1, Ljava/lang/Boolean;->FALSE:Ljava/lang/Boolean;

    iput-object p1, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->isBorderCornersRounded:Ljava/lang/Boolean;

    const-string p1, "#2256DE"

    invoke-static {p1}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result p1

    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->mTopLeftColor:Ljava/lang/Integer;

    const-string p1, "#FF543E"

    invoke-static {p1}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result p1

    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->mTopRightColor:Ljava/lang/Integer;

    const-string p1, "#FFAF4D"

    invoke-static {p1}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result p1

    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->mBottomLeftColor:Ljava/lang/Integer;

    const-string p1, "#3098F1"

    invoke-static {p1}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result p1

    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->mBottomRightColor:Ljava/lang/Integer;

    return-void
.end method

.method public constructor <init>(Landroid/content/Context;Landroid/util/AttributeSet;)V
    .locals 7

    const/4 v0, 0x0

    .line 2
    invoke-direct {p0, p1, p2, v0}, Landroid/widget/FrameLayout;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;I)V

    sget-object v1, Ljava/lang/Boolean;->FALSE:Ljava/lang/Boolean;

    iput-object v1, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->isBorderCornersRounded:Ljava/lang/Boolean;

    const-string v1, "#2256DE"

    invoke-static {v1}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result v2

    invoke-static {v2}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v2

    iput-object v2, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->mTopLeftColor:Ljava/lang/Integer;

    const-string v2, "#FF543E"

    invoke-static {v2}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result v3

    invoke-static {v3}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v3

    iput-object v3, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->mTopRightColor:Ljava/lang/Integer;

    const-string v3, "#FFAF4D"

    invoke-static {v3}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result v4

    invoke-static {v4}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v4

    iput-object v4, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->mBottomLeftColor:Ljava/lang/Integer;

    const-string v4, "#3098F1"

    invoke-static {v4}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result v5

    invoke-static {v5}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v5

    iput-object v5, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->mBottomRightColor:Ljava/lang/Integer;

    new-instance v5, Landroidx/camera/view/PreviewView;

    invoke-direct {v5, p1, p2}, Landroidx/camera/view/PreviewView;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;)V

    iput-object v5, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->previewView:Landroidx/camera/view/PreviewView;

    new-instance v5, Landroid/view/SurfaceView;

    invoke-direct {v5, p1, p2}, Landroid/view/SurfaceView;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;)V

    iput-object v5, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->surfaceView:Landroid/view/SurfaceView;

    new-instance v5, Lcom/scanflow/ui/ar/ArOverlayView;

    invoke-direct {v5, p1, p2}, Lcom/scanflow/ui/ar/ArOverlayView;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;)V

    iput-object v5, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->arOverlayView:Lcom/scanflow/ui/ar/ArOverlayView;

    sget-object v5, Lcom/scanflow/datacapture/R$styleable;->SFCameraView:[I

    invoke-virtual {p1, p2, v5}, Landroid/content/Context;->obtainStyledAttributes(Landroid/util/AttributeSet;[I)Landroid/content/res/TypedArray;

    move-result-object v5

    sget v6, Lcom/scanflow/datacapture/R$styleable;->SFCameraView_roundedCorner:I

    invoke-virtual {v5, v6, v0}, Landroid/content/res/TypedArray;->getBoolean(IZ)Z

    move-result v6

    invoke-static {v6}, Ljava/lang/Boolean;->valueOf(Z)Ljava/lang/Boolean;

    move-result-object v6

    iput-object v6, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->isBorderCornersRounded:Ljava/lang/Boolean;

    sget v6, Lcom/scanflow/datacapture/R$styleable;->SFCameraView_topLeftCornerColor:I

    invoke-static {v1}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result v1

    invoke-virtual {v5, v6, v1}, Landroid/content/res/TypedArray;->getColor(II)I

    move-result v1

    invoke-static {v1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v1

    iput-object v1, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->mTopLeftColor:Ljava/lang/Integer;

    sget v1, Lcom/scanflow/datacapture/R$styleable;->SFCameraView_topRightCornerColor:I

    invoke-static {v2}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result v2

    invoke-virtual {v5, v1, v2}, Landroid/content/res/TypedArray;->getColor(II)I

    move-result v1

    invoke-static {v1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v1

    iput-object v1, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->mTopRightColor:Ljava/lang/Integer;

    sget v1, Lcom/scanflow/datacapture/R$styleable;->SFCameraView_bottomLeftCornerColor:I

    invoke-static {v3}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result v2

    invoke-virtual {v5, v1, v2}, Landroid/content/res/TypedArray;->getColor(II)I

    move-result v1

    invoke-static {v1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v1

    iput-object v1, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->mBottomLeftColor:Ljava/lang/Integer;

    sget v1, Lcom/scanflow/datacapture/R$styleable;->SFCameraView_bottomRightCornerColor:I

    invoke-static {v4}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result v2

    invoke-virtual {v5, v1, v2}, Landroid/content/res/TypedArray;->getColor(II)I

    move-result v1

    invoke-static {v1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v1

    iput-object v1, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->mBottomRightColor:Ljava/lang/Integer;

    new-instance v1, Landroid/widget/TextView;

    invoke-direct {v1, p1, p2}, Landroid/widget/TextView;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;)V

    iput-object v1, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->textView:Landroid/widget/TextView;

    const/16 p2, 0x11

    invoke-virtual {v1, p2}, Landroid/widget/TextView;->setGravity(I)V

    iget-object v1, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->textView:Landroid/widget/TextView;

    const/high16 v2, 0x41900000    # 18.0f

    invoke-virtual {v1, v2}, Landroid/widget/TextView;->setTextSize(F)V

    iget-object v1, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->textView:Landroid/widget/TextView;

    const/16 v2, 0x14

    invoke-virtual {v1, v2, v0, v2, v0}, Landroid/widget/TextView;->setPadding(IIII)V

    iget-object v1, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->textView:Landroid/widget/TextView;

    const-string v2, "#C0C0C0"

    invoke-static {v2}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result v2

    invoke-virtual {v1, v2}, Landroid/widget/TextView;->setTextColor(I)V

    iget-object v1, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->textView:Landroid/widget/TextView;

    const-string v2, "The Scanflow SDK licence validation failed. Your licence key has expired!"

    invoke-virtual {v1, v2}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    new-instance v1, Landroid/widget/ImageView;

    invoke-direct {v1, p1}, Landroid/widget/ImageView;-><init>(Landroid/content/Context;)V

    iput-object v1, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->img_card_flip:Landroid/widget/ImageView;

    invoke-virtual {p0}, Landroid/view/View;->getResources()Landroid/content/res/Resources;

    move-result-object p1

    invoke-virtual {p1}, Landroid/content/res/Resources;->getDisplayMetrics()Landroid/util/DisplayMetrics;

    move-result-object p1

    const/4 v1, 0x2

    const/high16 v2, 0x43160000    # 150.0f

    invoke-static {v1, v2, p1}, Landroid/util/TypedValue;->applyDimension(IFLandroid/util/DisplayMetrics;)F

    move-result p1

    float-to-int p1, p1

    invoke-virtual {p0}, Landroid/view/View;->getResources()Landroid/content/res/Resources;

    move-result-object v3

    invoke-virtual {v3}, Landroid/content/res/Resources;->getDisplayMetrics()Landroid/util/DisplayMetrics;

    move-result-object v3

    invoke-static {v1, v2, v3}, Landroid/util/TypedValue;->applyDimension(IFLandroid/util/DisplayMetrics;)F

    move-result v1

    float-to-int v1, v1

    iget-object v2, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->img_card_flip:Landroid/widget/ImageView;

    sget v3, Lcom/scanflow/datacapture/R$drawable;->ic_flip_card:I

    invoke-virtual {v2, v3}, Landroid/widget/ImageView;->setImageResource(I)V

    iget-object v2, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->img_card_flip:Landroid/widget/ImageView;

    const/16 v3, 0x8

    invoke-virtual {v2, v3}, Landroid/widget/ImageView;->setVisibility(I)V

    new-instance v2, Landroid/widget/FrameLayout$LayoutParams;

    invoke-direct {v2, v1, p1, p2}, Landroid/widget/FrameLayout$LayoutParams;-><init>(III)V

    new-instance p1, Landroid/widget/FrameLayout$LayoutParams;

    const/4 v1, -0x1

    invoke-direct {p1, v1, v1, p2}, Landroid/widget/FrameLayout$LayoutParams;-><init>(III)V

    iget-object p2, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->previewView:Landroidx/camera/view/PreviewView;

    invoke-virtual {p0, p2, p1}, Landroid/view/ViewGroup;->addView(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V

    iget-object p2, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->surfaceView:Landroid/view/SurfaceView;

    invoke-virtual {p0, p2, p1}, Landroid/view/ViewGroup;->addView(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V

    iget-object p2, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->arOverlayView:Lcom/scanflow/ui/ar/ArOverlayView;

    invoke-virtual {p0, p2, p1}, Landroid/view/ViewGroup;->addView(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V

    iget-object p2, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->img_card_flip:Landroid/widget/ImageView;

    invoke-virtual {p0, p2, v2}, Landroid/view/ViewGroup;->addView(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V

    iget-object p2, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->textView:Landroid/widget/TextView;

    invoke-virtual {p0, p2, p1}, Landroid/view/ViewGroup;->addView(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V

    iget-object p1, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->textView:Landroid/widget/TextView;

    invoke-virtual {p1, v3}, Landroid/view/View;->setVisibility(I)V

    iget-object p1, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->previewView:Landroidx/camera/view/PreviewView;

    invoke-virtual {p1, v0}, Landroid/view/View;->setVisibility(I)V

    return-void
.end method

.method public constructor <init>(Landroid/content/Context;Landroid/util/AttributeSet;I)V
    .locals 0

    const p3, 0x101005d

    .line 3
    invoke-direct {p0, p1, p2, p3}, Landroid/widget/FrameLayout;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;I)V

    sget-object p1, Ljava/lang/Boolean;->FALSE:Ljava/lang/Boolean;

    iput-object p1, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->isBorderCornersRounded:Ljava/lang/Boolean;

    const-string p1, "#2256DE"

    invoke-static {p1}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result p1

    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->mTopLeftColor:Ljava/lang/Integer;

    const-string p1, "#FF543E"

    invoke-static {p1}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result p1

    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->mTopRightColor:Ljava/lang/Integer;

    const-string p1, "#FFAF4D"

    invoke-static {p1}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result p1

    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->mBottomLeftColor:Ljava/lang/Integer;

    const-string p1, "#3098F1"

    invoke-static {p1}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result p1

    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->mBottomRightColor:Ljava/lang/Integer;

    return-void
.end method

.method public static synthetic access$000(Lcom/scanflow/datacapture/sfidcard/SFCameraView;)Landroid/widget/ImageView;
    .locals 0

    .line 0
    iget-object p0, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->img_card_flip:Landroid/widget/ImageView;

    return-object p0
.end method


# virtual methods
.method public doFlipAnimation(Landroid/content/Context;)V
    .locals 1

    .line 0
    sget v0, Lcom/scanflow/datacapture/R$animator;->flip:I

    invoke-static {p1, v0}, Landroid/animation/AnimatorInflater;->loadAnimator(Landroid/content/Context;I)Landroid/animation/Animator;

    move-result-object p1

    check-cast p1, Landroid/animation/AnimatorSet;

    iget-object v0, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->img_card_flip:Landroid/widget/ImageView;

    invoke-virtual {p1, v0}, Landroid/animation/AnimatorSet;->setTarget(Ljava/lang/Object;)V

    new-instance v0, Lcom/scanflow/datacapture/sfidcard/SFCameraView$1;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/sfidcard/SFCameraView$1;-><init>(Lcom/scanflow/datacapture/sfidcard/SFCameraView;)V

    invoke-virtual {p1, v0}, Landroid/animation/Animator;->addListener(Landroid/animation/Animator$AnimatorListener;)V

    invoke-virtual {p1}, Landroid/animation/AnimatorSet;->start()V

    return-void
.end method

.method public getArOverlayView()Lcom/scanflow/ui/ar/ArOverlayView;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->arOverlayView:Lcom/scanflow/ui/ar/ArOverlayView;

    return-object v0
.end method

.method public getPreviewView()Landroidx/camera/view/PreviewView;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->previewView:Landroidx/camera/view/PreviewView;

    return-object v0
.end method

.method public getSurfaceView()Landroid/view/SurfaceView;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->surfaceView:Landroid/view/SurfaceView;

    return-object v0
.end method

.method public isBorderCornersRounded()Ljava/lang/Boolean;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->isBorderCornersRounded:Ljava/lang/Boolean;

    return-object v0
.end method

.method public mBottomLeftColor()Ljava/lang/Integer;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->mBottomLeftColor:Ljava/lang/Integer;

    return-object v0
.end method

.method public mBottomRightColor()Ljava/lang/Integer;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->mBottomRightColor:Ljava/lang/Integer;

    return-object v0
.end method

.method public mTopLeftColor()Ljava/lang/Integer;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->mTopLeftColor:Ljava/lang/Integer;

    return-object v0
.end method

.method public mTopRightColor()Ljava/lang/Integer;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->mTopRightColor:Ljava/lang/Integer;

    return-object v0
.end method

.method public setExpiredVisibility(Ljava/lang/Boolean;Ljava/lang/String;)V
    .locals 0

    .line 0
    invoke-virtual {p1}, Ljava/lang/Boolean;->booleanValue()Z

    move-result p1

    if-eqz p1, :cond_0

    iget-object p1, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->textView:Landroid/widget/TextView;

    invoke-virtual {p1, p2}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    iget-object p1, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->textView:Landroid/widget/TextView;

    const/4 p2, 0x0

    :goto_0
    invoke-virtual {p1, p2}, Landroid/view/View;->setVisibility(I)V

    return-void

    :cond_0
    iget-object p1, p0, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->textView:Landroid/widget/TextView;

    const/16 p2, 0x8

    goto :goto_0
.end method
