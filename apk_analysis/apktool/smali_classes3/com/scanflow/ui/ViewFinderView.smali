.class public final Lcom/scanflow/ui/ViewFinderView;
.super Landroid/view/View;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/ui/ViewFinderView$Companion;
    }
.end annotation


# static fields
.field private static final ANIMATION_DELAY:J = 0x50L

.field public static final Companion:Lcom/scanflow/ui/ViewFinderView$Companion;

.field private static final DEFAULT_SQUARE_DIMENSION_RATIO:F = 0.625f

.field private static final LANDSCAPE_HEIGHT_RATIO:F = 0.625f

.field private static final LANDSCAPE_WIDTH_HEIGHT_RATIO:F = 1.4f

.field private static final MIN_DIMENSION_DIFF:I = 0x32

.field private static final POINT_SIZE:I = 0xa

.field private static final PORTRAIT_WIDTH_HEIGHT_RATIO:F = 0.75f

.field private static final PORTRAIT_WIDTH_RATIO:F = 0.75f

.field private static final SCANNER_ALPHA:[I

.field private static final TAG:Ljava/lang/String; = "ViewFinderView"


# instance fields
.field private final ANIMATION_DELAY$1:J

.field private final DEFAULT_SQUARE_DIMENSION_RATIO$1:F

.field private final LANDSCAPE_HEIGHT_RATIO$1:F

.field private final LANDSCAPE_WIDTH_HEIGHT_RATIO$1:F

.field private final MIN_DIMENSION_DIFF$1:I

.field private final POINT_SIZE$1:I

.field private final PORTRAIT_WIDTH_HEIGHT_RATIO$1:F

.field private final PORTRAIT_WIDTH_RATIO$1:F

.field private final SCANNER_ALPHA$1:[I

.field private final TAG$1:Ljava/lang/String;

.field private borderCornersRadius:I

.field private isBorderCornersRounded:Z

.field private mBorderLineLength:I

.field private mBorderPaint:Landroid/graphics/Paint;

.field private mBordersAlpha:F

.field private mBottomLeftColor:I

.field private mBottomRightColor:I

.field private final mDefaultBorderColor:I

.field private final mDefaultBorderLineLength:I

.field private final mDefaultBorderStrokeWidth:I

.field private final mDefaultLaserColor:I

.field private final mDefaultMaskColor:I

.field private mFinderMaskPaint:Landroid/graphics/Paint;

.field private mFramingRect:Landroid/graphics/Rect;

.field private mIsLaserEnabled:Z

.field private mLaserPaint:Landroid/graphics/Paint;

.field private mSquareViewFinder:Z

.field private mTopLeftColor:I

.field private mTopRightColor:I

.field private mViewFinderOffset:I

.field private scannerAlpha:I


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 0
    new-instance v0, Lcom/scanflow/ui/ViewFinderView$Companion;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Lcom/scanflow/ui/ViewFinderView$Companion;-><init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V

    sput-object v0, Lcom/scanflow/ui/ViewFinderView;->Companion:Lcom/scanflow/ui/ViewFinderView$Companion;

    const/16 v0, 0x8

    new-array v0, v0, [I

    fill-array-data v0, :array_0

    sput-object v0, Lcom/scanflow/ui/ViewFinderView;->SCANNER_ALPHA:[I

    return-void

    :array_0
    .array-data 4
        0x0
        0x40
        0x80
        0xc0
        0xff
        0xc0
        0x80
        0x40
    .end array-data
.end method

.method public constructor <init>(Landroid/content/Context;)V
    .locals 2

    .line 1
    invoke-direct {p0, p1}, Landroid/view/View;-><init>(Landroid/content/Context;)V

    const-string p1, "ViewFinderView"

    iput-object p1, p0, Lcom/scanflow/ui/ViewFinderView;->TAG$1:Ljava/lang/String;

    const/high16 p1, 0x3f500000    # 0.8125f

    iput p1, p0, Lcom/scanflow/ui/ViewFinderView;->PORTRAIT_WIDTH_RATIO$1:F

    const p1, 0x3f666666    # 0.9f

    iput p1, p0, Lcom/scanflow/ui/ViewFinderView;->PORTRAIT_WIDTH_HEIGHT_RATIO$1:F

    const/high16 p1, 0x3f200000    # 0.625f

    iput p1, p0, Lcom/scanflow/ui/ViewFinderView;->LANDSCAPE_HEIGHT_RATIO$1:F

    const v0, 0x3fb33333    # 1.4f

    iput v0, p0, Lcom/scanflow/ui/ViewFinderView;->LANDSCAPE_WIDTH_HEIGHT_RATIO$1:F

    const/16 v0, 0x32

    iput v0, p0, Lcom/scanflow/ui/ViewFinderView;->MIN_DIMENSION_DIFF$1:I

    iput p1, p0, Lcom/scanflow/ui/ViewFinderView;->DEFAULT_SQUARE_DIMENSION_RATIO$1:F

    const/16 p1, 0x8

    new-array p1, p1, [I

    fill-array-data p1, :array_0

    iput-object p1, p0, Lcom/scanflow/ui/ViewFinderView;->SCANNER_ALPHA$1:[I

    const/16 p1, 0xa

    iput p1, p0, Lcom/scanflow/ui/ViewFinderView;->POINT_SIZE$1:I

    const-wide/16 v0, 0x50

    iput-wide v0, p0, Lcom/scanflow/ui/ViewFinderView;->ANIMATION_DELAY$1:J

    invoke-virtual {p0}, Landroid/view/View;->getContext()Landroid/content/Context;

    move-result-object p1

    sget v0, Lcom/scanflow/datacapture/R$color;->viewfinder_laser:I

    invoke-static {p1, v0}, Landroidx/core/content/ContextCompat;->getColor(Landroid/content/Context;I)I

    move-result p1

    iput p1, p0, Lcom/scanflow/ui/ViewFinderView;->mDefaultLaserColor:I

    invoke-virtual {p0}, Landroid/view/View;->getContext()Landroid/content/Context;

    move-result-object p1

    sget v0, Lcom/scanflow/datacapture/R$color;->viewfinder_mask:I

    invoke-static {p1, v0}, Landroidx/core/content/ContextCompat;->getColor(Landroid/content/Context;I)I

    move-result p1

    iput p1, p0, Lcom/scanflow/ui/ViewFinderView;->mDefaultMaskColor:I

    invoke-virtual {p0}, Landroid/view/View;->getContext()Landroid/content/Context;

    move-result-object p1

    sget v0, Lcom/scanflow/datacapture/R$color;->viewfinder_border:I

    invoke-static {p1, v0}, Landroidx/core/content/ContextCompat;->getColor(Landroid/content/Context;I)I

    move-result p1

    iput p1, p0, Lcom/scanflow/ui/ViewFinderView;->mDefaultBorderColor:I

    invoke-virtual {p0}, Landroid/view/View;->getResources()Landroid/content/res/Resources;

    move-result-object p1

    sget v0, Lcom/scanflow/datacapture/R$integer;->viewfinder_border_width:I

    invoke-virtual {p1, v0}, Landroid/content/res/Resources;->getInteger(I)I

    move-result p1

    iput p1, p0, Lcom/scanflow/ui/ViewFinderView;->mDefaultBorderStrokeWidth:I

    invoke-virtual {p0}, Landroid/view/View;->getResources()Landroid/content/res/Resources;

    move-result-object p1

    sget v0, Lcom/scanflow/datacapture/R$integer;->viewfinder_border_length:I

    invoke-virtual {p1, v0}, Landroid/content/res/Resources;->getInteger(I)I

    move-result p1

    iput p1, p0, Lcom/scanflow/ui/ViewFinderView;->mDefaultBorderLineLength:I

    const-string p1, "#2256DE"

    invoke-static {p1}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result p1

    iput p1, p0, Lcom/scanflow/ui/ViewFinderView;->mTopLeftColor:I

    const-string p1, "#FF543E"

    invoke-static {p1}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result p1

    iput p1, p0, Lcom/scanflow/ui/ViewFinderView;->mTopRightColor:I

    const-string p1, "#FFAF4D"

    invoke-static {p1}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result p1

    iput p1, p0, Lcom/scanflow/ui/ViewFinderView;->mBottomLeftColor:I

    const-string p1, "#3098F1"

    invoke-static {p1}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result p1

    iput p1, p0, Lcom/scanflow/ui/ViewFinderView;->mBottomRightColor:I

    invoke-direct {p0}, Lcom/scanflow/ui/ViewFinderView;->init()V

    return-void

    :array_0
    .array-data 4
        0x0
        0x40
        0x80
        0xc0
        0xff
        0xc0
        0x80
        0x40
    .end array-data
.end method

.method public constructor <init>(Landroid/content/Context;Landroid/util/AttributeSet;)V
    .locals 2

    .line 2
    invoke-direct {p0, p1, p2}, Landroid/view/View;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;)V

    const-string v0, "ViewFinderView"

    iput-object v0, p0, Lcom/scanflow/ui/ViewFinderView;->TAG$1:Ljava/lang/String;

    const/high16 v0, 0x3f500000    # 0.8125f

    iput v0, p0, Lcom/scanflow/ui/ViewFinderView;->PORTRAIT_WIDTH_RATIO$1:F

    const v0, 0x3f666666    # 0.9f

    iput v0, p0, Lcom/scanflow/ui/ViewFinderView;->PORTRAIT_WIDTH_HEIGHT_RATIO$1:F

    const/high16 v0, 0x3f200000    # 0.625f

    iput v0, p0, Lcom/scanflow/ui/ViewFinderView;->LANDSCAPE_HEIGHT_RATIO$1:F

    const v1, 0x3fb33333    # 1.4f

    iput v1, p0, Lcom/scanflow/ui/ViewFinderView;->LANDSCAPE_WIDTH_HEIGHT_RATIO$1:F

    const/16 v1, 0x32

    iput v1, p0, Lcom/scanflow/ui/ViewFinderView;->MIN_DIMENSION_DIFF$1:I

    iput v0, p0, Lcom/scanflow/ui/ViewFinderView;->DEFAULT_SQUARE_DIMENSION_RATIO$1:F

    const/16 v0, 0x8

    new-array v0, v0, [I

    fill-array-data v0, :array_0

    iput-object v0, p0, Lcom/scanflow/ui/ViewFinderView;->SCANNER_ALPHA$1:[I

    const/16 v0, 0xa

    iput v0, p0, Lcom/scanflow/ui/ViewFinderView;->POINT_SIZE$1:I

    const-wide/16 v0, 0x50

    iput-wide v0, p0, Lcom/scanflow/ui/ViewFinderView;->ANIMATION_DELAY$1:J

    invoke-virtual {p0}, Landroid/view/View;->getContext()Landroid/content/Context;

    move-result-object v0

    sget v1, Lcom/scanflow/datacapture/R$color;->viewfinder_laser:I

    invoke-static {v0, v1}, Landroidx/core/content/ContextCompat;->getColor(Landroid/content/Context;I)I

    move-result v0

    iput v0, p0, Lcom/scanflow/ui/ViewFinderView;->mDefaultLaserColor:I

    invoke-virtual {p0}, Landroid/view/View;->getContext()Landroid/content/Context;

    move-result-object v0

    sget v1, Lcom/scanflow/datacapture/R$color;->viewfinder_mask:I

    invoke-static {v0, v1}, Landroidx/core/content/ContextCompat;->getColor(Landroid/content/Context;I)I

    move-result v0

    iput v0, p0, Lcom/scanflow/ui/ViewFinderView;->mDefaultMaskColor:I

    invoke-virtual {p0}, Landroid/view/View;->getContext()Landroid/content/Context;

    move-result-object v0

    sget v1, Lcom/scanflow/datacapture/R$color;->viewfinder_border:I

    invoke-static {v0, v1}, Landroidx/core/content/ContextCompat;->getColor(Landroid/content/Context;I)I

    move-result v0

    iput v0, p0, Lcom/scanflow/ui/ViewFinderView;->mDefaultBorderColor:I

    invoke-virtual {p0}, Landroid/view/View;->getResources()Landroid/content/res/Resources;

    move-result-object v0

    sget v1, Lcom/scanflow/datacapture/R$integer;->viewfinder_border_width:I

    invoke-virtual {v0, v1}, Landroid/content/res/Resources;->getInteger(I)I

    move-result v0

    iput v0, p0, Lcom/scanflow/ui/ViewFinderView;->mDefaultBorderStrokeWidth:I

    invoke-virtual {p0}, Landroid/view/View;->getResources()Landroid/content/res/Resources;

    move-result-object v0

    sget v1, Lcom/scanflow/datacapture/R$integer;->viewfinder_border_length:I

    invoke-virtual {v0, v1}, Landroid/content/res/Resources;->getInteger(I)I

    move-result v0

    iput v0, p0, Lcom/scanflow/ui/ViewFinderView;->mDefaultBorderLineLength:I

    const-string v0, "#2256DE"

    invoke-static {v0}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result v0

    iput v0, p0, Lcom/scanflow/ui/ViewFinderView;->mTopLeftColor:I

    const-string v0, "#FF543E"

    invoke-static {v0}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result v0

    iput v0, p0, Lcom/scanflow/ui/ViewFinderView;->mTopRightColor:I

    const-string v0, "#FFAF4D"

    invoke-static {v0}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result v0

    iput v0, p0, Lcom/scanflow/ui/ViewFinderView;->mBottomLeftColor:I

    const-string v0, "#3098F1"

    invoke-static {v0}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result v0

    iput v0, p0, Lcom/scanflow/ui/ViewFinderView;->mBottomRightColor:I

    invoke-direct {p0, p1, p2}, Lcom/scanflow/ui/ViewFinderView;->attributeSetLoaded(Landroid/content/Context;Landroid/util/AttributeSet;)Z

    move-result p1

    if-eqz p1, :cond_0

    invoke-direct {p0}, Lcom/scanflow/ui/ViewFinderView;->init()V

    :cond_0
    return-void

    :array_0
    .array-data 4
        0x0
        0x40
        0x80
        0xc0
        0xff
        0xc0
        0x80
        0x40
    .end array-data
.end method

.method private final attributeSetLoaded(Landroid/content/Context;Landroid/util/AttributeSet;)Z
    .locals 2

    .line 0
    if-eqz p1, :cond_0

    sget-object v0, Lcom/scanflow/datacapture/R$styleable;->ViewFinderView:[I

    invoke-virtual {p1, p2, v0}, Landroid/content/Context;->obtainStyledAttributes(Landroid/util/AttributeSet;[I)Landroid/content/res/TypedArray;

    move-result-object p2

    const-string v0, "obtainStyledAttributes(...)"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    sget v0, Lcom/scanflow/datacapture/R$styleable;->ViewFinderView_topLeftCornerColor:I

    sget v1, Lcom/scanflow/datacapture/R$color;->viewfinder_topleftcornor:I

    invoke-static {p1, v1}, Landroidx/core/content/ContextCompat;->getColor(Landroid/content/Context;I)I

    move-result v1

    invoke-virtual {p2, v0, v1}, Landroid/content/res/TypedArray;->getColor(II)I

    move-result v0

    iput v0, p0, Lcom/scanflow/ui/ViewFinderView;->mTopLeftColor:I

    sget v0, Lcom/scanflow/datacapture/R$styleable;->ViewFinderView_topRightCornerColor:I

    sget v1, Lcom/scanflow/datacapture/R$color;->viewfinder_toprightcornor:I

    invoke-static {p1, v1}, Landroidx/core/content/ContextCompat;->getColor(Landroid/content/Context;I)I

    move-result v1

    invoke-virtual {p2, v0, v1}, Landroid/content/res/TypedArray;->getColor(II)I

    move-result v0

    iput v0, p0, Lcom/scanflow/ui/ViewFinderView;->mTopRightColor:I

    sget v0, Lcom/scanflow/datacapture/R$styleable;->ViewFinderView_bottomLeftCornerColor:I

    sget v1, Lcom/scanflow/datacapture/R$color;->viewfinder_bottomleftcornor:I

    invoke-static {p1, v1}, Landroidx/core/content/ContextCompat;->getColor(Landroid/content/Context;I)I

    move-result v1

    invoke-virtual {p2, v0, v1}, Landroid/content/res/TypedArray;->getColor(II)I

    move-result v0

    iput v0, p0, Lcom/scanflow/ui/ViewFinderView;->mBottomLeftColor:I

    sget v0, Lcom/scanflow/datacapture/R$styleable;->ViewFinderView_bottomRightCornerColor:I

    sget v1, Lcom/scanflow/datacapture/R$color;->viewfinder_bottomrightcornor:I

    invoke-static {p1, v1}, Landroidx/core/content/ContextCompat;->getColor(Landroid/content/Context;I)I

    move-result p1

    invoke-virtual {p2, v0, p1}, Landroid/content/res/TypedArray;->getColor(II)I

    move-result p1

    iput p1, p0, Lcom/scanflow/ui/ViewFinderView;->mBottomRightColor:I

    sget p1, Lcom/scanflow/datacapture/R$styleable;->ViewFinderView_roundedCorner:I

    const/4 v0, 0x0

    invoke-virtual {p2, p1, v0}, Landroid/content/res/TypedArray;->getBoolean(IZ)Z

    move-result p1

    iput-boolean p1, p0, Lcom/scanflow/ui/ViewFinderView;->isBorderCornersRounded:Z

    if-eqz p1, :cond_0

    sget p1, Lcom/scanflow/datacapture/R$styleable;->ViewFinderView_cornerRadius:I

    const/high16 v0, 0x41a00000    # 20.0f

    invoke-virtual {p2, p1, v0}, Landroid/content/res/TypedArray;->getDimension(IF)F

    move-result p1

    float-to-int p1, p1

    iput p1, p0, Lcom/scanflow/ui/ViewFinderView;->borderCornersRadius:I

    :cond_0
    const/4 p1, 0x1

    return p1
.end method

.method private final init()V
    .locals 3

    .line 0
    new-instance v0, Landroid/graphics/Paint;

    invoke-direct {v0}, Landroid/graphics/Paint;-><init>()V

    iput-object v0, p0, Lcom/scanflow/ui/ViewFinderView;->mLaserPaint:Landroid/graphics/Paint;

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    iget v1, p0, Lcom/scanflow/ui/ViewFinderView;->mDefaultLaserColor:I

    invoke-virtual {v0, v1}, Landroid/graphics/Paint;->setColor(I)V

    iget-object v0, p0, Lcom/scanflow/ui/ViewFinderView;->mLaserPaint:Landroid/graphics/Paint;

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    sget-object v1, Landroid/graphics/Paint$Style;->FILL:Landroid/graphics/Paint$Style;

    invoke-virtual {v0, v1}, Landroid/graphics/Paint;->setStyle(Landroid/graphics/Paint$Style;)V

    new-instance v0, Landroid/graphics/Paint;

    invoke-direct {v0}, Landroid/graphics/Paint;-><init>()V

    iput-object v0, p0, Lcom/scanflow/ui/ViewFinderView;->mFinderMaskPaint:Landroid/graphics/Paint;

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    iget v1, p0, Lcom/scanflow/ui/ViewFinderView;->mDefaultMaskColor:I

    invoke-virtual {v0, v1}, Landroid/graphics/Paint;->setColor(I)V

    new-instance v0, Landroid/graphics/Paint;

    invoke-direct {v0}, Landroid/graphics/Paint;-><init>()V

    iput-object v0, p0, Lcom/scanflow/ui/ViewFinderView;->mBorderPaint:Landroid/graphics/Paint;

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    iget v1, p0, Lcom/scanflow/ui/ViewFinderView;->mDefaultBorderColor:I

    invoke-virtual {v0, v1}, Landroid/graphics/Paint;->setColor(I)V

    iget-object v0, p0, Lcom/scanflow/ui/ViewFinderView;->mBorderPaint:Landroid/graphics/Paint;

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    sget-object v1, Landroid/graphics/Paint$Style;->STROKE:Landroid/graphics/Paint$Style;

    invoke-virtual {v0, v1}, Landroid/graphics/Paint;->setStyle(Landroid/graphics/Paint$Style;)V

    iget-object v0, p0, Lcom/scanflow/ui/ViewFinderView;->mBorderPaint:Landroid/graphics/Paint;

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    iget v1, p0, Lcom/scanflow/ui/ViewFinderView;->mDefaultBorderStrokeWidth:I

    int-to-float v1, v1

    invoke-virtual {v0, v1}, Landroid/graphics/Paint;->setStrokeWidth(F)V

    iget-object v0, p0, Lcom/scanflow/ui/ViewFinderView;->mBorderPaint:Landroid/graphics/Paint;

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    const/4 v1, 0x1

    invoke-virtual {v0, v1}, Landroid/graphics/Paint;->setAntiAlias(Z)V

    iget-boolean v0, p0, Lcom/scanflow/ui/ViewFinderView;->isBorderCornersRounded:Z

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/scanflow/ui/ViewFinderView;->mBorderPaint:Landroid/graphics/Paint;

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    sget-object v1, Landroid/graphics/Paint$Join;->ROUND:Landroid/graphics/Paint$Join;

    invoke-virtual {v0, v1}, Landroid/graphics/Paint;->setStrokeJoin(Landroid/graphics/Paint$Join;)V

    iget-object v0, p0, Lcom/scanflow/ui/ViewFinderView;->mBorderPaint:Landroid/graphics/Paint;

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    new-instance v1, Landroid/graphics/CornerPathEffect;

    iget v2, p0, Lcom/scanflow/ui/ViewFinderView;->borderCornersRadius:I

    int-to-float v2, v2

    invoke-direct {v1, v2}, Landroid/graphics/CornerPathEffect;-><init>(F)V

    invoke-virtual {v0, v1}, Landroid/graphics/Paint;->setPathEffect(Landroid/graphics/PathEffect;)Landroid/graphics/PathEffect;

    goto :goto_0

    :cond_0
    iget-object v0, p0, Lcom/scanflow/ui/ViewFinderView;->mBorderPaint:Landroid/graphics/Paint;

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    sget-object v1, Landroid/graphics/Paint$Join;->BEVEL:Landroid/graphics/Paint$Join;

    invoke-virtual {v0, v1}, Landroid/graphics/Paint;->setStrokeJoin(Landroid/graphics/Paint$Join;)V

    :goto_0
    iget v0, p0, Lcom/scanflow/ui/ViewFinderView;->mDefaultBorderLineLength:I

    iput v0, p0, Lcom/scanflow/ui/ViewFinderView;->mBorderLineLength:I

    return-void
.end method


# virtual methods
.method public final drawLaser(Landroid/graphics/Canvas;)V
    .locals 8

    .line 0
    const-string v1, "canvas"

    invoke-static {p1, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iget-object v1, p0, Lcom/scanflow/ui/ViewFinderView;->mFramingRect:Landroid/graphics/Rect;

    iget-object v3, p0, Lcom/scanflow/ui/ViewFinderView;->mLaserPaint:Landroid/graphics/Paint;

    invoke-static {v3}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    iget-object v4, p0, Lcom/scanflow/ui/ViewFinderView;->SCANNER_ALPHA$1:[I

    iget v5, p0, Lcom/scanflow/ui/ViewFinderView;->scannerAlpha:I

    aget v4, v4, v5

    invoke-virtual {v3, v4}, Landroid/graphics/Paint;->setAlpha(I)V

    iget v3, p0, Lcom/scanflow/ui/ViewFinderView;->scannerAlpha:I

    add-int/lit8 v3, v3, 0x1

    iget-object v4, p0, Lcom/scanflow/ui/ViewFinderView;->SCANNER_ALPHA$1:[I

    array-length v4, v4

    rem-int/2addr v3, v4

    iput v3, p0, Lcom/scanflow/ui/ViewFinderView;->scannerAlpha:I

    invoke-static {v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {v1}, Landroid/graphics/Rect;->height()I

    move-result v3

    div-int/lit8 v3, v3, 0x2

    iget v4, v1, Landroid/graphics/Rect;->top:I

    add-int/2addr v3, v4

    iget v4, v1, Landroid/graphics/Rect;->left:I

    add-int/lit8 v4, v4, 0x2

    int-to-float v4, v4

    add-int/lit8 v5, v3, -0x1

    int-to-float v5, v5

    iget v6, v1, Landroid/graphics/Rect;->right:I

    add-int/lit8 v6, v6, -0x1

    int-to-float v6, v6

    add-int/lit8 v3, v3, 0x2

    int-to-float v3, v3

    iget-object v7, p0, Lcom/scanflow/ui/ViewFinderView;->mLaserPaint:Landroid/graphics/Paint;

    invoke-static {v7}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    move v2, v6

    move v6, v3

    move v3, v4

    move v4, v5

    move v5, v2

    move-object v2, p1

    invoke-virtual/range {v2 .. v7}, Landroid/graphics/Canvas;->drawRect(FFFFLandroid/graphics/Paint;)V

    iget-wide v2, p0, Lcom/scanflow/ui/ViewFinderView;->ANIMATION_DELAY$1:J

    iget v4, v1, Landroid/graphics/Rect;->left:I

    iget v5, p0, Lcom/scanflow/ui/ViewFinderView;->POINT_SIZE$1:I

    sub-int/2addr v4, v5

    iget v6, v1, Landroid/graphics/Rect;->top:I

    sub-int/2addr v6, v5

    iget v7, v1, Landroid/graphics/Rect;->right:I

    add-int/2addr v7, v5

    iget v1, v1, Landroid/graphics/Rect;->bottom:I

    add-int/2addr v1, v5

    move v0, v6

    move v6, v1

    move-wide v1, v2

    move v3, v4

    move v4, v0

    move-object v0, p0

    move v5, v7

    invoke-virtual/range {v0 .. v6}, Landroid/view/View;->postInvalidateDelayed(JIIII)V

    return-void
.end method

.method public final drawViewFinderBorder(Landroid/graphics/Canvas;)V
    .locals 5

    .line 0
    const-string v0, "canvas"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iget-object v0, p0, Lcom/scanflow/ui/ViewFinderView;->mFramingRect:Landroid/graphics/Rect;

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    new-instance v1, Landroid/graphics/Paint;

    const/4 v2, 0x1

    invoke-direct {v1, v2}, Landroid/graphics/Paint;-><init>(I)V

    invoke-virtual {p0}, Landroid/view/View;->getContext()Landroid/content/Context;

    move-result-object v2

    sget v3, Lcom/scanflow/datacapture/R$color;->design_default_color_background:I

    invoke-static {v2, v3}, Landroidx/core/content/ContextCompat;->getColor(Landroid/content/Context;I)I

    move-result v2

    invoke-virtual {v1, v2}, Landroid/graphics/Paint;->setColor(I)V

    new-instance v1, Landroid/graphics/Path;

    invoke-direct {v1}, Landroid/graphics/Path;-><init>()V

    iget-object v2, p0, Lcom/scanflow/ui/ViewFinderView;->mBorderPaint:Landroid/graphics/Paint;

    invoke-static {v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    iget v3, p0, Lcom/scanflow/ui/ViewFinderView;->mTopLeftColor:I

    invoke-virtual {v2, v3}, Landroid/graphics/Paint;->setColor(I)V

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    iget v2, v0, Landroid/graphics/Rect;->left:I

    int-to-float v2, v2

    iget v3, v0, Landroid/graphics/Rect;->top:I

    iget v4, p0, Lcom/scanflow/ui/ViewFinderView;->mBorderLineLength:I

    add-int/2addr v3, v4

    int-to-float v3, v3

    invoke-virtual {v1, v2, v3}, Landroid/graphics/Path;->moveTo(FF)V

    iget v2, v0, Landroid/graphics/Rect;->left:I

    int-to-float v2, v2

    iget v3, v0, Landroid/graphics/Rect;->top:I

    int-to-float v3, v3

    invoke-virtual {v1, v2, v3}, Landroid/graphics/Path;->lineTo(FF)V

    iget v2, v0, Landroid/graphics/Rect;->left:I

    iget v3, p0, Lcom/scanflow/ui/ViewFinderView;->mBorderLineLength:I

    add-int/2addr v2, v3

    int-to-float v2, v2

    iget v3, v0, Landroid/graphics/Rect;->top:I

    int-to-float v3, v3

    invoke-virtual {v1, v2, v3}, Landroid/graphics/Path;->lineTo(FF)V

    iget-object v2, p0, Lcom/scanflow/ui/ViewFinderView;->mBorderPaint:Landroid/graphics/Paint;

    invoke-static {v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {p1, v1, v2}, Landroid/graphics/Canvas;->drawPath(Landroid/graphics/Path;Landroid/graphics/Paint;)V

    new-instance v1, Landroid/graphics/Path;

    invoke-direct {v1}, Landroid/graphics/Path;-><init>()V

    iget-object v2, p0, Lcom/scanflow/ui/ViewFinderView;->mBorderPaint:Landroid/graphics/Paint;

    invoke-static {v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    iget v3, p0, Lcom/scanflow/ui/ViewFinderView;->mTopRightColor:I

    invoke-virtual {v2, v3}, Landroid/graphics/Paint;->setColor(I)V

    iget v2, v0, Landroid/graphics/Rect;->right:I

    int-to-float v2, v2

    iget v3, v0, Landroid/graphics/Rect;->top:I

    iget v4, p0, Lcom/scanflow/ui/ViewFinderView;->mBorderLineLength:I

    add-int/2addr v3, v4

    int-to-float v3, v3

    invoke-virtual {v1, v2, v3}, Landroid/graphics/Path;->moveTo(FF)V

    iget v2, v0, Landroid/graphics/Rect;->right:I

    int-to-float v2, v2

    iget v3, v0, Landroid/graphics/Rect;->top:I

    int-to-float v3, v3

    invoke-virtual {v1, v2, v3}, Landroid/graphics/Path;->lineTo(FF)V

    iget v2, v0, Landroid/graphics/Rect;->right:I

    iget v3, p0, Lcom/scanflow/ui/ViewFinderView;->mBorderLineLength:I

    sub-int/2addr v2, v3

    int-to-float v2, v2

    iget v3, v0, Landroid/graphics/Rect;->top:I

    int-to-float v3, v3

    invoke-virtual {v1, v2, v3}, Landroid/graphics/Path;->lineTo(FF)V

    iget-object v2, p0, Lcom/scanflow/ui/ViewFinderView;->mBorderPaint:Landroid/graphics/Paint;

    invoke-static {v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {p1, v1, v2}, Landroid/graphics/Canvas;->drawPath(Landroid/graphics/Path;Landroid/graphics/Paint;)V

    new-instance v1, Landroid/graphics/Path;

    invoke-direct {v1}, Landroid/graphics/Path;-><init>()V

    iget-object v2, p0, Lcom/scanflow/ui/ViewFinderView;->mBorderPaint:Landroid/graphics/Paint;

    invoke-static {v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    iget v3, p0, Lcom/scanflow/ui/ViewFinderView;->mBottomRightColor:I

    invoke-virtual {v2, v3}, Landroid/graphics/Paint;->setColor(I)V

    iget v2, v0, Landroid/graphics/Rect;->right:I

    int-to-float v2, v2

    iget v3, v0, Landroid/graphics/Rect;->bottom:I

    iget v4, p0, Lcom/scanflow/ui/ViewFinderView;->mBorderLineLength:I

    sub-int/2addr v3, v4

    int-to-float v3, v3

    invoke-virtual {v1, v2, v3}, Landroid/graphics/Path;->moveTo(FF)V

    iget v2, v0, Landroid/graphics/Rect;->right:I

    int-to-float v2, v2

    iget v3, v0, Landroid/graphics/Rect;->bottom:I

    int-to-float v3, v3

    invoke-virtual {v1, v2, v3}, Landroid/graphics/Path;->lineTo(FF)V

    iget v2, v0, Landroid/graphics/Rect;->right:I

    iget v3, p0, Lcom/scanflow/ui/ViewFinderView;->mBorderLineLength:I

    sub-int/2addr v2, v3

    int-to-float v2, v2

    iget v3, v0, Landroid/graphics/Rect;->bottom:I

    int-to-float v3, v3

    invoke-virtual {v1, v2, v3}, Landroid/graphics/Path;->lineTo(FF)V

    iget-object v2, p0, Lcom/scanflow/ui/ViewFinderView;->mBorderPaint:Landroid/graphics/Paint;

    invoke-static {v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {p1, v1, v2}, Landroid/graphics/Canvas;->drawPath(Landroid/graphics/Path;Landroid/graphics/Paint;)V

    new-instance v1, Landroid/graphics/Path;

    invoke-direct {v1}, Landroid/graphics/Path;-><init>()V

    iget-object v2, p0, Lcom/scanflow/ui/ViewFinderView;->mBorderPaint:Landroid/graphics/Paint;

    invoke-static {v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    iget v3, p0, Lcom/scanflow/ui/ViewFinderView;->mBottomLeftColor:I

    invoke-virtual {v2, v3}, Landroid/graphics/Paint;->setColor(I)V

    iget v2, v0, Landroid/graphics/Rect;->left:I

    int-to-float v2, v2

    iget v3, v0, Landroid/graphics/Rect;->bottom:I

    iget v4, p0, Lcom/scanflow/ui/ViewFinderView;->mBorderLineLength:I

    sub-int/2addr v3, v4

    int-to-float v3, v3

    invoke-virtual {v1, v2, v3}, Landroid/graphics/Path;->moveTo(FF)V

    iget v2, v0, Landroid/graphics/Rect;->left:I

    int-to-float v2, v2

    iget v3, v0, Landroid/graphics/Rect;->bottom:I

    int-to-float v3, v3

    invoke-virtual {v1, v2, v3}, Landroid/graphics/Path;->lineTo(FF)V

    iget v2, v0, Landroid/graphics/Rect;->left:I

    iget v3, p0, Lcom/scanflow/ui/ViewFinderView;->mBorderLineLength:I

    add-int/2addr v2, v3

    int-to-float v2, v2

    iget v3, v0, Landroid/graphics/Rect;->bottom:I

    int-to-float v3, v3

    invoke-virtual {v1, v2, v3}, Landroid/graphics/Path;->lineTo(FF)V

    iget-object v2, p0, Lcom/scanflow/ui/ViewFinderView;->mBorderPaint:Landroid/graphics/Paint;

    invoke-static {v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {p1, v1, v2}, Landroid/graphics/Canvas;->drawPath(Landroid/graphics/Path;Landroid/graphics/Paint;)V

    new-instance v1, Landroid/graphics/Paint;

    invoke-direct {v1}, Landroid/graphics/Paint;-><init>()V

    const/4 v2, -0x1

    invoke-virtual {v1, v2}, Landroid/graphics/Paint;->setColor(I)V

    const/high16 v2, 0x41a00000    # 20.0f

    invoke-virtual {v1, v2}, Landroid/graphics/Paint;->setTextSize(F)V

    sget-object v2, Landroid/graphics/Typeface;->DEFAULT:Landroid/graphics/Typeface;

    const/4 v3, 0x0

    invoke-static {v2, v3}, Landroid/graphics/Typeface;->create(Landroid/graphics/Typeface;I)Landroid/graphics/Typeface;

    move-result-object v2

    invoke-virtual {v1, v2}, Landroid/graphics/Paint;->setTypeface(Landroid/graphics/Typeface;)Landroid/graphics/Typeface;

    iget v2, v0, Landroid/graphics/Rect;->right:I

    iget v3, p0, Lcom/scanflow/ui/ViewFinderView;->mBorderLineLength:I

    sub-int/2addr v2, v3

    int-to-float v2, v2

    const/16 v3, 0x23

    int-to-float v3, v3

    sub-float/2addr v2, v3

    iget v0, v0, Landroid/graphics/Rect;->bottom:I

    int-to-float v0, v0

    const/16 v3, 0x32

    int-to-float v3, v3

    add-float/2addr v0, v3

    const-string v3, "SCANFLOW"

    invoke-virtual {p1, v3, v2, v0, v1}, Landroid/graphics/Canvas;->drawText(Ljava/lang/String;FFLandroid/graphics/Paint;)V

    return-void
.end method

.method public final drawViewFinderMask(Landroid/graphics/Canvas;)V
    .locals 9

    .line 0
    const-string v0, "canvas"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {p1}, Landroid/graphics/Canvas;->getWidth()I

    move-result v0

    invoke-virtual {p1}, Landroid/graphics/Canvas;->getHeight()I

    move-result v7

    iget-object v8, p0, Lcom/scanflow/ui/ViewFinderView;->mFramingRect:Landroid/graphics/Rect;

    int-to-float v4, v0

    invoke-static {v8}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    iget v0, v8, Landroid/graphics/Rect;->top:I

    int-to-float v5, v0

    iget-object v6, p0, Lcom/scanflow/ui/ViewFinderView;->mFinderMaskPaint:Landroid/graphics/Paint;

    invoke-static {v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    const/4 v2, 0x0

    const/4 v3, 0x0

    move-object v1, p1

    invoke-virtual/range {v1 .. v6}, Landroid/graphics/Canvas;->drawRect(FFFFLandroid/graphics/Paint;)V

    move v0, v4

    iget v1, v8, Landroid/graphics/Rect;->top:I

    int-to-float v3, v1

    iget v1, v8, Landroid/graphics/Rect;->left:I

    int-to-float v4, v1

    iget v1, v8, Landroid/graphics/Rect;->bottom:I

    add-int/lit8 v1, v1, 0x1

    int-to-float v5, v1

    iget-object v6, p0, Lcom/scanflow/ui/ViewFinderView;->mFinderMaskPaint:Landroid/graphics/Paint;

    invoke-static {v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    move-object v1, p1

    invoke-virtual/range {v1 .. v6}, Landroid/graphics/Canvas;->drawRect(FFFFLandroid/graphics/Paint;)V

    iget v1, v8, Landroid/graphics/Rect;->right:I

    add-int/lit8 v1, v1, 0x1

    int-to-float v2, v1

    iget v1, v8, Landroid/graphics/Rect;->top:I

    int-to-float v3, v1

    iget v1, v8, Landroid/graphics/Rect;->bottom:I

    add-int/lit8 v1, v1, 0x1

    int-to-float v5, v1

    iget-object v6, p0, Lcom/scanflow/ui/ViewFinderView;->mFinderMaskPaint:Landroid/graphics/Paint;

    invoke-static {v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    move-object v1, p1

    move v4, v0

    invoke-virtual/range {v1 .. v6}, Landroid/graphics/Canvas;->drawRect(FFFFLandroid/graphics/Paint;)V

    iget v0, v8, Landroid/graphics/Rect;->bottom:I

    add-int/lit8 v0, v0, 0x1

    int-to-float v3, v0

    int-to-float v5, v7

    iget-object v6, p0, Lcom/scanflow/ui/ViewFinderView;->mFinderMaskPaint:Landroid/graphics/Paint;

    invoke-static {v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    const/4 v2, 0x0

    invoke-virtual/range {v1 .. v6}, Landroid/graphics/Canvas;->drawRect(FFFFLandroid/graphics/Paint;)V

    return-void
.end method

.method public final getMBorderLineLength()I
    .locals 1

    .line 0
    iget v0, p0, Lcom/scanflow/ui/ViewFinderView;->mBorderLineLength:I

    return v0
.end method

.method public final getMBorderPaint()Landroid/graphics/Paint;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/ui/ViewFinderView;->mBorderPaint:Landroid/graphics/Paint;

    return-object v0
.end method

.method public final getMFinderMaskPaint()Landroid/graphics/Paint;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/ui/ViewFinderView;->mFinderMaskPaint:Landroid/graphics/Paint;

    return-object v0
.end method

.method public final getMLaserPaint()Landroid/graphics/Paint;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/ui/ViewFinderView;->mLaserPaint:Landroid/graphics/Paint;

    return-object v0
.end method

.method public final getMSquareViewFinder()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/ui/ViewFinderView;->mSquareViewFinder:Z

    return v0
.end method

.method public onDraw(Landroid/graphics/Canvas;)V
    .locals 1

    .line 0
    const-string v0, "canvas"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iget-object v0, p0, Lcom/scanflow/ui/ViewFinderView;->mFramingRect:Landroid/graphics/Rect;

    if-nez v0, :cond_0

    goto :goto_0

    :cond_0
    invoke-virtual {p0, p1}, Lcom/scanflow/ui/ViewFinderView;->drawViewFinderBorder(Landroid/graphics/Canvas;)V

    iget-boolean v0, p0, Lcom/scanflow/ui/ViewFinderView;->mIsLaserEnabled:Z

    if-eqz v0, :cond_1

    invoke-virtual {p0, p1}, Lcom/scanflow/ui/ViewFinderView;->drawLaser(Landroid/graphics/Canvas;)V

    :cond_1
    :goto_0
    return-void
.end method

.method public onSizeChanged(IIII)V
    .locals 0

    .line 0
    invoke-virtual {p0}, Lcom/scanflow/ui/ViewFinderView;->updateFramingRect()V

    return-void
.end method

.method public onVisibilityChanged(Landroid/view/View;I)V
    .locals 1

    .line 0
    const-string v0, "changedView"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-super {p0, p1, p2}, Landroid/view/View;->onVisibilityChanged(Landroid/view/View;I)V

    return-void
.end method

.method public setBorderAlpha(F)V
    .locals 1

    .line 0
    const/16 v0, 0xff

    int-to-float v0, v0

    mul-float/2addr v0, p1

    float-to-int v0, v0

    iput p1, p0, Lcom/scanflow/ui/ViewFinderView;->mBordersAlpha:F

    iget-object p1, p0, Lcom/scanflow/ui/ViewFinderView;->mBorderPaint:Landroid/graphics/Paint;

    invoke-static {p1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {p1, v0}, Landroid/graphics/Paint;->setAlpha(I)V

    return-void
.end method

.method public setBorderColor(I)V
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/ui/ViewFinderView;->mBorderPaint:Landroid/graphics/Paint;

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {v0, p1}, Landroid/graphics/Paint;->setColor(I)V

    return-void
.end method

.method public setBorderCornerRadius(I)V
    .locals 2

    .line 0
    iget-object v0, p0, Lcom/scanflow/ui/ViewFinderView;->mBorderPaint:Landroid/graphics/Paint;

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    new-instance v1, Landroid/graphics/CornerPathEffect;

    int-to-float p1, p1

    invoke-direct {v1, p1}, Landroid/graphics/CornerPathEffect;-><init>(F)V

    invoke-virtual {v0, v1}, Landroid/graphics/Paint;->setPathEffect(Landroid/graphics/PathEffect;)Landroid/graphics/PathEffect;

    return-void
.end method

.method public setBorderCornerRounded(Z)V
    .locals 1

    .line 0
    if-eqz p1, :cond_0

    iget-object p1, p0, Lcom/scanflow/ui/ViewFinderView;->mBorderPaint:Landroid/graphics/Paint;

    invoke-static {p1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    sget-object v0, Landroid/graphics/Paint$Join;->ROUND:Landroid/graphics/Paint$Join;

    :goto_0
    invoke-virtual {p1, v0}, Landroid/graphics/Paint;->setStrokeJoin(Landroid/graphics/Paint$Join;)V

    return-void

    :cond_0
    iget-object p1, p0, Lcom/scanflow/ui/ViewFinderView;->mBorderPaint:Landroid/graphics/Paint;

    invoke-static {p1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    sget-object v0, Landroid/graphics/Paint$Join;->BEVEL:Landroid/graphics/Paint$Join;

    goto :goto_0
.end method

.method public setBorderLineLength(I)V
    .locals 0

    .line 0
    iput p1, p0, Lcom/scanflow/ui/ViewFinderView;->mBorderLineLength:I

    return-void
.end method

.method public setBorderStrokeWidth(I)V
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/ui/ViewFinderView;->mBorderPaint:Landroid/graphics/Paint;

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    int-to-float p1, p1

    invoke-virtual {v0, p1}, Landroid/graphics/Paint;->setStrokeWidth(F)V

    return-void
.end method

.method public setBottomLeftCornerColor(I)V
    .locals 0

    .line 0
    iput p1, p0, Lcom/scanflow/ui/ViewFinderView;->mBottomLeftColor:I

    return-void
.end method

.method public setBottomRightCornerColor(I)V
    .locals 0

    .line 0
    iput p1, p0, Lcom/scanflow/ui/ViewFinderView;->mBottomRightColor:I

    return-void
.end method

.method public setLaserColor(I)V
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/ui/ViewFinderView;->mLaserPaint:Landroid/graphics/Paint;

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {v0, p1}, Landroid/graphics/Paint;->setColor(I)V

    return-void
.end method

.method public setLaserEnabled(Z)V
    .locals 0

    .line 0
    iput-boolean p1, p0, Lcom/scanflow/ui/ViewFinderView;->mIsLaserEnabled:Z

    return-void
.end method

.method public final setMBorderLineLength(I)V
    .locals 0

    .line 0
    iput p1, p0, Lcom/scanflow/ui/ViewFinderView;->mBorderLineLength:I

    return-void
.end method

.method public final setMBorderPaint(Landroid/graphics/Paint;)V
    .locals 0

    .line 0
    iput-object p1, p0, Lcom/scanflow/ui/ViewFinderView;->mBorderPaint:Landroid/graphics/Paint;

    return-void
.end method

.method public final setMFinderMaskPaint(Landroid/graphics/Paint;)V
    .locals 0

    .line 0
    iput-object p1, p0, Lcom/scanflow/ui/ViewFinderView;->mFinderMaskPaint:Landroid/graphics/Paint;

    return-void
.end method

.method public final setMLaserPaint(Landroid/graphics/Paint;)V
    .locals 0

    .line 0
    iput-object p1, p0, Lcom/scanflow/ui/ViewFinderView;->mLaserPaint:Landroid/graphics/Paint;

    return-void
.end method

.method public final setMSquareViewFinder(Z)V
    .locals 0

    .line 0
    iput-boolean p1, p0, Lcom/scanflow/ui/ViewFinderView;->mSquareViewFinder:Z

    return-void
.end method

.method public setMaskColor(I)V
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/ui/ViewFinderView;->mFinderMaskPaint:Landroid/graphics/Paint;

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {v0, p1}, Landroid/graphics/Paint;->setColor(I)V

    return-void
.end method

.method public setSquareViewFinder(Z)V
    .locals 0

    .line 0
    iput-boolean p1, p0, Lcom/scanflow/ui/ViewFinderView;->mSquareViewFinder:Z

    return-void
.end method

.method public setTopLeftCornerColor(I)V
    .locals 0

    .line 0
    iput p1, p0, Lcom/scanflow/ui/ViewFinderView;->mTopLeftColor:I

    return-void
.end method

.method public setTopRightCornerColor(I)V
    .locals 0

    .line 0
    iput p1, p0, Lcom/scanflow/ui/ViewFinderView;->mTopRightColor:I

    return-void
.end method

.method public setViewFinderOffset(I)V
    .locals 0

    .line 0
    iput p1, p0, Lcom/scanflow/ui/ViewFinderView;->mViewFinderOffset:I

    return-void
.end method

.method public setupViewFinder()V
    .locals 0

    .line 0
    invoke-virtual {p0}, Lcom/scanflow/ui/ViewFinderView;->updateFramingRect()V

    invoke-virtual {p0}, Landroid/view/View;->invalidate()V

    return-void
.end method

.method public final declared-synchronized updateFramingRect()V
    .locals 9

    .line 0
    monitor-enter p0

    :try_start_0
    new-instance v0, Landroid/graphics/Point;

    invoke-virtual {p0}, Landroid/view/View;->getWidth()I

    move-result v1

    invoke-virtual {p0}, Landroid/view/View;->getHeight()I

    move-result v2

    invoke-direct {v0, v1, v2}, Landroid/graphics/Point;-><init>(II)V

    invoke-virtual {p0}, Landroid/view/View;->getContext()Landroid/content/Context;

    move-result-object v1

    invoke-virtual {v1}, Landroid/content/Context;->getResources()Landroid/content/res/Resources;

    move-result-object v1

    invoke-virtual {v1}, Landroid/content/res/Resources;->getConfiguration()Landroid/content/res/Configuration;

    move-result-object v1

    iget v1, v1, Landroid/content/res/Configuration;->orientation:I

    iget-boolean v2, p0, Lcom/scanflow/ui/ViewFinderView;->mSquareViewFinder:Z

    const/4 v3, 0x1

    if-eqz v2, :cond_1

    if-eq v1, v3, :cond_0

    invoke-virtual {p0}, Landroid/view/View;->getHeight()I

    move-result v1

    :goto_0
    int-to-float v1, v1

    iget v2, p0, Lcom/scanflow/ui/ViewFinderView;->DEFAULT_SQUARE_DIMENSION_RATIO$1:F

    mul-float/2addr v1, v2

    float-to-int v1, v1

    move v2, v1

    goto :goto_1

    :catchall_0
    move-exception v0

    goto :goto_2

    :cond_0
    invoke-virtual {p0}, Landroid/view/View;->getWidth()I

    move-result v1

    goto :goto_0

    :cond_1
    if-eq v1, v3, :cond_2

    invoke-virtual {p0}, Landroid/view/View;->getHeight()I

    move-result v1

    int-to-float v1, v1

    iget v2, p0, Lcom/scanflow/ui/ViewFinderView;->LANDSCAPE_HEIGHT_RATIO$1:F

    mul-float/2addr v1, v2

    float-to-int v1, v1

    iget v2, p0, Lcom/scanflow/ui/ViewFinderView;->LANDSCAPE_WIDTH_HEIGHT_RATIO$1:F

    int-to-float v3, v1

    mul-float/2addr v2, v3

    float-to-int v2, v2

    move v8, v2

    move v2, v1

    move v1, v8

    goto :goto_1

    :cond_2
    invoke-virtual {p0}, Landroid/view/View;->getWidth()I

    move-result v1

    int-to-float v1, v1

    iget v2, p0, Lcom/scanflow/ui/ViewFinderView;->PORTRAIT_WIDTH_RATIO$1:F

    mul-float/2addr v1, v2

    float-to-int v1, v1

    iget v2, p0, Lcom/scanflow/ui/ViewFinderView;->PORTRAIT_WIDTH_HEIGHT_RATIO$1:F

    int-to-float v3, v1

    mul-float/2addr v2, v3

    float-to-int v2, v2

    :goto_1
    invoke-virtual {p0}, Landroid/view/View;->getWidth()I

    move-result v3

    if-le v1, v3, :cond_3

    invoke-virtual {p0}, Landroid/view/View;->getWidth()I

    move-result v1

    iget v3, p0, Lcom/scanflow/ui/ViewFinderView;->MIN_DIMENSION_DIFF$1:I

    sub-int/2addr v1, v3

    :cond_3
    invoke-virtual {p0}, Landroid/view/View;->getHeight()I

    move-result v3

    if-le v2, v3, :cond_4

    invoke-virtual {p0}, Landroid/view/View;->getHeight()I

    move-result v2

    iget v3, p0, Lcom/scanflow/ui/ViewFinderView;->MIN_DIMENSION_DIFF$1:I

    sub-int/2addr v2, v3

    :cond_4
    iget v3, v0, Landroid/graphics/Point;->x:I

    sub-int/2addr v3, v1

    div-int/lit8 v3, v3, 0x2

    iget v0, v0, Landroid/graphics/Point;->y:I

    sub-int/2addr v0, v2

    div-int/lit8 v0, v0, 0x2

    new-instance v4, Landroid/graphics/Rect;

    iget v5, p0, Lcom/scanflow/ui/ViewFinderView;->mViewFinderOffset:I

    add-int v6, v3, v5

    add-int v7, v0, v5

    add-int/2addr v3, v1

    sub-int/2addr v3, v5

    add-int/2addr v0, v2

    sub-int/2addr v0, v5

    invoke-direct {v4, v6, v7, v3, v0}, Landroid/graphics/Rect;-><init>(IIII)V

    iput-object v4, p0, Lcom/scanflow/ui/ViewFinderView;->mFramingRect:Landroid/graphics/Rect;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit p0

    return-void

    :goto_2
    :try_start_1
    monitor-exit p0
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    throw v0
.end method
