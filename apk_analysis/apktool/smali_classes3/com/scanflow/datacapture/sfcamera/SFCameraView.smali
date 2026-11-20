.class public Lcom/scanflow/datacapture/sfcamera/SFCameraView;
.super Landroid/widget/FrameLayout;
.source "SourceFile"


# instance fields
.field private copyright:Landroid/widget/TextView;

.field private img_card_flip:Landroid/widget/ImageView;

.field private isBorderCornersRounded:Ljava/lang/Boolean;

.field private mBottomLeftColor:Ljava/lang/Integer;

.field private mBottomRightColor:Ljava/lang/Integer;

.field private mTopLeftColor:Ljava/lang/Integer;

.field private mTopRightColor:Ljava/lang/Integer;

.field private overlayView:Lcom/scanflow/datacapture/sfcamera/OverlayView;

.field private previewView:Landroidx/camera/view/PreviewView;

.field private ratioHeight:I

.field private ratioWidth:I

.field private surfaceView:Landroid/view/SurfaceView;

.field private textCaptureHeightPercentage:Ljava/lang/Integer;

.field private textCaptureWidthPercentage:Ljava/lang/Integer;

.field private textView:Landroid/widget/TextView;


# direct methods
.method public constructor <init>(Landroid/content/Context;)V
    .locals 1

    const/4 v0, 0x0

    .line 1
    invoke-direct {p0, p1, v0}, Landroid/widget/FrameLayout;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;)V

    sget-object p1, Ljava/lang/Boolean;->FALSE:Ljava/lang/Boolean;

    iput-object p1, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->isBorderCornersRounded:Ljava/lang/Boolean;

    const-string p1, "#2256DE"

    invoke-static {p1}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result p1

    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->mTopLeftColor:Ljava/lang/Integer;

    const-string p1, "#FF543E"

    invoke-static {p1}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result p1

    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->mTopRightColor:Ljava/lang/Integer;

    const-string p1, "#FFAF4D"

    invoke-static {p1}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result p1

    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->mBottomLeftColor:Ljava/lang/Integer;

    const-string p1, "#3098F1"

    invoke-static {p1}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result p1

    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->mBottomRightColor:Ljava/lang/Integer;

    const/4 p1, 0x0

    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->textCaptureHeightPercentage:Ljava/lang/Integer;

    iput-object v0, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->textCaptureWidthPercentage:Ljava/lang/Integer;

    iput p1, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->ratioWidth:I

    iput p1, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->ratioHeight:I

    return-void
.end method

.method public constructor <init>(Landroid/content/Context;Landroid/util/AttributeSet;)V
    .locals 7

    const/4 v0, 0x0

    .line 2
    invoke-static {v0}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v1

    invoke-direct {p0, p1, p2, v0}, Landroid/widget/FrameLayout;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;I)V

    sget-object v2, Ljava/lang/Boolean;->FALSE:Ljava/lang/Boolean;

    iput-object v2, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->isBorderCornersRounded:Ljava/lang/Boolean;

    const-string v2, "#2256DE"

    invoke-static {v2}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result v3

    invoke-static {v3}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v3

    iput-object v3, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->mTopLeftColor:Ljava/lang/Integer;

    const-string v3, "#FF543E"

    invoke-static {v3}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result v4

    invoke-static {v4}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v4

    iput-object v4, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->mTopRightColor:Ljava/lang/Integer;

    const-string v4, "#FFAF4D"

    invoke-static {v4}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result v5

    invoke-static {v5}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v5

    iput-object v5, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->mBottomLeftColor:Ljava/lang/Integer;

    const-string v5, "#3098F1"

    invoke-static {v5}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result v6

    invoke-static {v6}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v6

    iput-object v6, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->mBottomRightColor:Ljava/lang/Integer;

    iput-object v1, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->textCaptureHeightPercentage:Ljava/lang/Integer;

    iput-object v1, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->textCaptureWidthPercentage:Ljava/lang/Integer;

    iput v0, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->ratioWidth:I

    iput v0, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->ratioHeight:I

    new-instance v1, Landroidx/camera/view/PreviewView;

    invoke-direct {v1, p1, p2}, Landroidx/camera/view/PreviewView;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;)V

    iput-object v1, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->previewView:Landroidx/camera/view/PreviewView;

    new-instance v1, Landroid/view/SurfaceView;

    invoke-direct {v1, p1, p2}, Landroid/view/SurfaceView;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;)V

    iput-object v1, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->surfaceView:Landroid/view/SurfaceView;

    new-instance v1, Lcom/scanflow/datacapture/sfcamera/OverlayView;

    invoke-direct {v1, p1, p2}, Lcom/scanflow/datacapture/sfcamera/OverlayView;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;)V

    iput-object v1, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->overlayView:Lcom/scanflow/datacapture/sfcamera/OverlayView;

    sget-object v1, Lcom/scanflow/datacapture/R$styleable;->SFCameraView:[I

    invoke-virtual {p1, p2, v1}, Landroid/content/Context;->obtainStyledAttributes(Landroid/util/AttributeSet;[I)Landroid/content/res/TypedArray;

    move-result-object v1

    sget v6, Lcom/scanflow/datacapture/R$styleable;->SFCameraView_roundedCorner:I

    invoke-virtual {v1, v6, v0}, Landroid/content/res/TypedArray;->getBoolean(IZ)Z

    move-result v6

    invoke-static {v6}, Ljava/lang/Boolean;->valueOf(Z)Ljava/lang/Boolean;

    move-result-object v6

    iput-object v6, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->isBorderCornersRounded:Ljava/lang/Boolean;

    sget v6, Lcom/scanflow/datacapture/R$styleable;->SFCameraView_topLeftCornerColor:I

    invoke-static {v2}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result v2

    invoke-virtual {v1, v6, v2}, Landroid/content/res/TypedArray;->getColor(II)I

    move-result v2

    invoke-static {v2}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v2

    iput-object v2, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->mTopLeftColor:Ljava/lang/Integer;

    sget v2, Lcom/scanflow/datacapture/R$styleable;->SFCameraView_topRightCornerColor:I

    invoke-static {v3}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result v3

    invoke-virtual {v1, v2, v3}, Landroid/content/res/TypedArray;->getColor(II)I

    move-result v2

    invoke-static {v2}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v2

    iput-object v2, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->mTopRightColor:Ljava/lang/Integer;

    sget v2, Lcom/scanflow/datacapture/R$styleable;->SFCameraView_bottomLeftCornerColor:I

    invoke-static {v4}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result v3

    invoke-virtual {v1, v2, v3}, Landroid/content/res/TypedArray;->getColor(II)I

    move-result v2

    invoke-static {v2}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v2

    iput-object v2, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->mBottomLeftColor:Ljava/lang/Integer;

    sget v2, Lcom/scanflow/datacapture/R$styleable;->SFCameraView_bottomRightCornerColor:I

    invoke-static {v5}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result v3

    invoke-virtual {v1, v2, v3}, Landroid/content/res/TypedArray;->getColor(II)I

    move-result v2

    invoke-static {v2}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v2

    iput-object v2, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->mBottomRightColor:Ljava/lang/Integer;

    sget v2, Lcom/scanflow/datacapture/R$styleable;->SFCameraView_textCaptureHeightPercentage:I

    invoke-virtual {v1, v2, v0}, Landroid/content/res/TypedArray;->getInteger(II)I

    move-result v2

    invoke-static {v2}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v2

    iput-object v2, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->textCaptureHeightPercentage:Ljava/lang/Integer;

    sget v2, Lcom/scanflow/datacapture/R$styleable;->SFCameraView_textCaptureWidthPercentage:I

    invoke-virtual {v1, v2, v0}, Landroid/content/res/TypedArray;->getInteger(II)I

    move-result v1

    invoke-static {v1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v1

    iput-object v1, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->textCaptureWidthPercentage:Ljava/lang/Integer;

    new-instance v1, Landroid/widget/TextView;

    invoke-direct {v1, p1, p2}, Landroid/widget/TextView;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;)V

    iput-object v1, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->textView:Landroid/widget/TextView;

    const/16 v2, 0x11

    invoke-virtual {v1, v2}, Landroid/widget/TextView;->setGravity(I)V

    iget-object v1, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->textView:Landroid/widget/TextView;

    const/high16 v3, 0x41900000    # 18.0f

    invoke-virtual {v1, v3}, Landroid/widget/TextView;->setTextSize(F)V

    iget-object v1, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->textView:Landroid/widget/TextView;

    const/16 v3, 0x14

    invoke-virtual {v1, v3, v0, v3, v0}, Landroid/widget/TextView;->setPadding(IIII)V

    iget-object v1, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->textView:Landroid/widget/TextView;

    const-string v4, "#C0C0C0"

    invoke-static {v4}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result v4

    invoke-virtual {v1, v4}, Landroid/widget/TextView;->setTextColor(I)V

    iget-object v1, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->textView:Landroid/widget/TextView;

    const-string v4, "The Scanflow SDK licence validation failed. Your licence key has expired!"

    invoke-virtual {v1, v4}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    new-instance v1, Landroid/widget/TextView;

    invoke-direct {v1, p1, p2}, Landroid/widget/TextView;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;)V

    iput-object v1, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->copyright:Landroid/widget/TextView;

    const/16 p2, 0x55

    invoke-virtual {v1, p2}, Landroid/widget/TextView;->setGravity(I)V

    iget-object p2, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->copyright:Landroid/widget/TextView;

    const/high16 v1, 0x41200000    # 10.0f

    invoke-virtual {p2, v1}, Landroid/widget/TextView;->setTextSize(F)V

    iget-object p2, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->copyright:Landroid/widget/TextView;

    const-string v1, "#FFFFFF"

    invoke-static {v1}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result v1

    invoke-virtual {p2, v1}, Landroid/widget/TextView;->setTextColor(I)V

    iget-object p2, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->copyright:Landroid/widget/TextView;

    invoke-virtual {p2, v0, v0, v3, v3}, Landroid/widget/TextView;->setPadding(IIII)V

    iget-object p2, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->copyright:Landroid/widget/TextView;

    sget-object v1, Landroid/graphics/Typeface;->DEFAULT:Landroid/graphics/Typeface;

    invoke-static {v1, v0}, Landroid/graphics/Typeface;->create(Landroid/graphics/Typeface;I)Landroid/graphics/Typeface;

    move-result-object v1

    invoke-virtual {p2, v1}, Landroid/widget/TextView;->setTypeface(Landroid/graphics/Typeface;)V

    iget-object p2, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->copyright:Landroid/widget/TextView;

    const-string v1, "SCANFLOW"

    invoke-virtual {p2, v1}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    new-instance p2, Landroid/widget/ImageView;

    invoke-direct {p2, p1}, Landroid/widget/ImageView;-><init>(Landroid/content/Context;)V

    iput-object p2, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->img_card_flip:Landroid/widget/ImageView;

    invoke-virtual {p0}, Landroid/view/View;->getResources()Landroid/content/res/Resources;

    move-result-object p1

    invoke-virtual {p1}, Landroid/content/res/Resources;->getDisplayMetrics()Landroid/util/DisplayMetrics;

    move-result-object p1

    const/4 p2, 0x2

    const/high16 v1, 0x43160000    # 150.0f

    invoke-static {p2, v1, p1}, Landroid/util/TypedValue;->applyDimension(IFLandroid/util/DisplayMetrics;)F

    move-result p1

    float-to-int p1, p1

    invoke-virtual {p0}, Landroid/view/View;->getResources()Landroid/content/res/Resources;

    move-result-object v3

    invoke-virtual {v3}, Landroid/content/res/Resources;->getDisplayMetrics()Landroid/util/DisplayMetrics;

    move-result-object v3

    invoke-static {p2, v1, v3}, Landroid/util/TypedValue;->applyDimension(IFLandroid/util/DisplayMetrics;)F

    move-result p2

    float-to-int p2, p2

    iget-object v1, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->img_card_flip:Landroid/widget/ImageView;

    sget v3, Lcom/scanflow/datacapture/R$drawable;->ic_flip_card:I

    invoke-virtual {v1, v3}, Landroid/widget/ImageView;->setImageResource(I)V

    iget-object v1, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->img_card_flip:Landroid/widget/ImageView;

    const/16 v3, 0x8

    invoke-virtual {v1, v3}, Landroid/widget/ImageView;->setVisibility(I)V

    new-instance v1, Landroid/widget/FrameLayout$LayoutParams;

    invoke-direct {v1, p2, p1, v2}, Landroid/widget/FrameLayout$LayoutParams;-><init>(III)V

    new-instance p1, Landroid/widget/FrameLayout$LayoutParams;

    const/4 p2, -0x2

    invoke-direct {p1, p2, p2, v2}, Landroid/widget/FrameLayout$LayoutParams;-><init>(III)V

    new-instance p2, Landroid/widget/FrameLayout$LayoutParams;

    const/4 v4, -0x1

    invoke-direct {p2, v4, v4, v2}, Landroid/widget/FrameLayout$LayoutParams;-><init>(III)V

    iget-object v2, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->previewView:Landroidx/camera/view/PreviewView;

    invoke-virtual {p0, v2, p2}, Landroid/view/ViewGroup;->addView(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V

    iget-object v2, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->surfaceView:Landroid/view/SurfaceView;

    invoke-virtual {p0, v2, p2}, Landroid/view/ViewGroup;->addView(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V

    iget-object v2, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->overlayView:Lcom/scanflow/datacapture/sfcamera/OverlayView;

    invoke-virtual {p0, v2, p1}, Landroid/view/ViewGroup;->addView(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V

    iget-object p1, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->img_card_flip:Landroid/widget/ImageView;

    invoke-virtual {p0, p1, v1}, Landroid/view/ViewGroup;->addView(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V

    iget-object p1, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->textView:Landroid/widget/TextView;

    invoke-virtual {p0, p1, p2}, Landroid/view/ViewGroup;->addView(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V

    iget-object p1, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->copyright:Landroid/widget/TextView;

    invoke-virtual {p0, p1, p2}, Landroid/view/ViewGroup;->addView(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V

    iget-object p1, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->textView:Landroid/widget/TextView;

    invoke-virtual {p1, v3}, Landroid/view/View;->setVisibility(I)V

    iget-object p1, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->previewView:Landroidx/camera/view/PreviewView;

    invoke-virtual {p1, v0}, Landroid/view/View;->setVisibility(I)V

    return-void
.end method

.method public constructor <init>(Landroid/content/Context;Landroid/util/AttributeSet;I)V
    .locals 0

    const p3, 0x101005d

    .line 3
    invoke-direct {p0, p1, p2, p3}, Landroid/widget/FrameLayout;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;I)V

    sget-object p1, Ljava/lang/Boolean;->FALSE:Ljava/lang/Boolean;

    iput-object p1, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->isBorderCornersRounded:Ljava/lang/Boolean;

    const-string p1, "#2256DE"

    invoke-static {p1}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result p1

    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->mTopLeftColor:Ljava/lang/Integer;

    const-string p1, "#FF543E"

    invoke-static {p1}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result p1

    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->mTopRightColor:Ljava/lang/Integer;

    const-string p1, "#FFAF4D"

    invoke-static {p1}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result p1

    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->mBottomLeftColor:Ljava/lang/Integer;

    const-string p1, "#3098F1"

    invoke-static {p1}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result p1

    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->mBottomRightColor:Ljava/lang/Integer;

    const/4 p1, 0x0

    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p2

    iput-object p2, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->textCaptureHeightPercentage:Ljava/lang/Integer;

    iput-object p2, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->textCaptureWidthPercentage:Ljava/lang/Integer;

    iput p1, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->ratioWidth:I

    iput p1, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->ratioHeight:I

    return-void
.end method

.method public static synthetic access$000(Lcom/scanflow/datacapture/sfcamera/SFCameraView;)Landroid/widget/ImageView;
    .locals 0

    .line 0
    iget-object p0, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->img_card_flip:Landroid/widget/ImageView;

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

    iget-object v0, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->img_card_flip:Landroid/widget/ImageView;

    invoke-virtual {p1, v0}, Landroid/animation/AnimatorSet;->setTarget(Ljava/lang/Object;)V

    new-instance v0, Lcom/scanflow/datacapture/sfcamera/SFCameraView$1;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/sfcamera/SFCameraView$1;-><init>(Lcom/scanflow/datacapture/sfcamera/SFCameraView;)V

    invoke-virtual {p1, v0}, Landroid/animation/Animator;->addListener(Landroid/animation/Animator$AnimatorListener;)V

    invoke-virtual {p1}, Landroid/animation/AnimatorSet;->start()V

    return-void
.end method

.method public getArOverlayView()Lcom/scanflow/datacapture/sfcamera/OverlayView;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->overlayView:Lcom/scanflow/datacapture/sfcamera/OverlayView;

    return-object v0
.end method

.method public getPreviewView()Landroidx/camera/view/PreviewView;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->previewView:Landroidx/camera/view/PreviewView;

    return-object v0
.end method

.method public getSurfaceView()Landroid/view/SurfaceView;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->surfaceView:Landroid/view/SurfaceView;

    return-object v0
.end method

.method public isBorderCornersRounded()Ljava/lang/Boolean;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->isBorderCornersRounded:Ljava/lang/Boolean;

    return-object v0
.end method

.method public mBottomLeftColor()Ljava/lang/Integer;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->mBottomLeftColor:Ljava/lang/Integer;

    return-object v0
.end method

.method public mBottomRightColor()Ljava/lang/Integer;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->mBottomRightColor:Ljava/lang/Integer;

    return-object v0
.end method

.method public mTopLeftColor()Ljava/lang/Integer;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->mTopLeftColor:Ljava/lang/Integer;

    return-object v0
.end method

.method public mTopRightColor()Ljava/lang/Integer;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->mTopRightColor:Ljava/lang/Integer;

    return-object v0
.end method

.method public onMeasure(II)V
    .locals 3

    .line 0
    invoke-super {p0, p1, p2}, Landroid/widget/FrameLayout;->onMeasure(II)V

    invoke-static {p1}, Landroid/view/View$MeasureSpec;->getSize(I)I

    move-result p1

    invoke-static {p2}, Landroid/view/View$MeasureSpec;->getSize(I)I

    move-result p2

    iget v0, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->ratioWidth:I

    if-eqz v0, :cond_2

    iget v1, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->ratioHeight:I

    if-nez v1, :cond_0

    goto :goto_0

    :cond_0
    mul-int v2, p2, v0

    div-int/2addr v2, v1

    if-ge p1, v2, :cond_1

    mul-int/2addr v1, p1

    div-int/2addr v1, v0

    invoke-virtual {p0, p1, v1}, Landroid/view/View;->setMeasuredDimension(II)V

    return-void

    :cond_1
    invoke-virtual {p0, v2, p2}, Landroid/view/View;->setMeasuredDimension(II)V

    return-void

    :cond_2
    :goto_0
    invoke-virtual {p0, p1, p2}, Landroid/view/View;->setMeasuredDimension(II)V

    return-void
.end method

.method public setExpiredVisibility(Ljava/lang/Boolean;Ljava/lang/String;)V
    .locals 0

    .line 0
    invoke-virtual {p1}, Ljava/lang/Boolean;->booleanValue()Z

    move-result p1

    if-eqz p1, :cond_0

    iget-object p1, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->textView:Landroid/widget/TextView;

    invoke-virtual {p1, p2}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    iget-object p1, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->textView:Landroid/widget/TextView;

    const/4 p2, 0x0

    :goto_0
    invoke-virtual {p1, p2}, Landroid/view/View;->setVisibility(I)V

    return-void

    :cond_0
    iget-object p1, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->textView:Landroid/widget/TextView;

    const/16 p2, 0x8

    goto :goto_0
.end method

.method public textCaptureHeightPercentage()Ljava/lang/Integer;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->textCaptureHeightPercentage:Ljava/lang/Integer;

    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v0

    rsub-int/lit8 v0, v0, 0x64

    invoke-static {v0}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v0

    return-object v0
.end method

.method public textCaptureWidthPercentage()Ljava/lang/Integer;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->textCaptureWidthPercentage:Ljava/lang/Integer;

    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v0

    rsub-int/lit8 v0, v0, 0x64

    invoke-static {v0}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v0

    return-object v0
.end method
