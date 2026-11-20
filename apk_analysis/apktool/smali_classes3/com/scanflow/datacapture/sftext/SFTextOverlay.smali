.class public final Lcom/scanflow/datacapture/sftext/SFTextOverlay;
.super Ljava/lang/Object;
.source "SourceFile"


# static fields
.field public static final INSTANCE:Lcom/scanflow/datacapture/sftext/SFTextOverlay;

.field private static isBorderCornersRounded:Z

.field private static mBottomLeftColor:I

.field private static mBottomRightColor:I

.field private static mTopLeftColor:I

.field private static mTopRightColor:I


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/sftext/SFTextOverlay;

    invoke-direct {v0}, Lcom/scanflow/datacapture/sftext/SFTextOverlay;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/sftext/SFTextOverlay;->INSTANCE:Lcom/scanflow/datacapture/sftext/SFTextOverlay;

    const/4 v0, 0x1

    sput-boolean v0, Lcom/scanflow/datacapture/sftext/SFTextOverlay;->isBorderCornersRounded:Z

    const-string v0, "#2256DE"

    invoke-static {v0}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result v0

    sput v0, Lcom/scanflow/datacapture/sftext/SFTextOverlay;->mTopLeftColor:I

    const-string v0, "#FF543E"

    invoke-static {v0}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result v0

    sput v0, Lcom/scanflow/datacapture/sftext/SFTextOverlay;->mTopRightColor:I

    const-string v0, "#FFAF4D"

    invoke-static {v0}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result v0

    sput v0, Lcom/scanflow/datacapture/sftext/SFTextOverlay;->mBottomLeftColor:I

    const-string v0, "#3098F1"

    invoke-static {v0}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result v0

    sput v0, Lcom/scanflow/datacapture/sftext/SFTextOverlay;->mBottomRightColor:I

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public final drawOverlay(Landroid/view/SurfaceHolder;II)Landroid/graphics/RectF;
    .locals 12

    .line 0
    const-string v0, "holder"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-interface {p1}, Landroid/view/SurfaceHolder;->lockCanvas()Landroid/graphics/Canvas;

    move-result-object v0

    new-instance v1, Landroid/graphics/Paint;

    invoke-direct {v1}, Landroid/graphics/Paint;-><init>()V

    const/16 v2, 0x3c

    invoke-virtual {v1, v2}, Landroid/graphics/Paint;->setAlpha(I)V

    invoke-virtual {v0, v1}, Landroid/graphics/Canvas;->drawPaint(Landroid/graphics/Paint;)V

    new-instance v1, Landroid/graphics/Paint;

    invoke-direct {v1}, Landroid/graphics/Paint;-><init>()V

    new-instance v3, Landroid/graphics/PorterDuffXfermode;

    sget-object v4, Landroid/graphics/PorterDuff$Mode;->CLEAR:Landroid/graphics/PorterDuff$Mode;

    invoke-direct {v3, v4}, Landroid/graphics/PorterDuffXfermode;-><init>(Landroid/graphics/PorterDuff$Mode;)V

    invoke-virtual {v1, v3}, Landroid/graphics/Paint;->setXfermode(Landroid/graphics/Xfermode;)Landroid/graphics/Xfermode;

    sget-object v3, Landroid/graphics/Paint$Style;->FILL:Landroid/graphics/Paint$Style;

    invoke-virtual {v1, v3}, Landroid/graphics/Paint;->setStyle(Landroid/graphics/Paint$Style;)V

    const/4 v3, -0x1

    invoke-virtual {v1, v3}, Landroid/graphics/Paint;->setColor(I)V

    new-instance v4, Landroid/graphics/Paint;

    invoke-direct {v4}, Landroid/graphics/Paint;-><init>()V

    sget-object v5, Landroid/graphics/Paint$Style;->STROKE:Landroid/graphics/Paint$Style;

    invoke-virtual {v4, v5}, Landroid/graphics/Paint;->setStyle(Landroid/graphics/Paint$Style;)V

    invoke-virtual {v4, v3}, Landroid/graphics/Paint;->setColor(I)V

    const/high16 v6, 0x40800000    # 4.0f

    invoke-virtual {v4, v6}, Landroid/graphics/Paint;->setStrokeWidth(F)V

    invoke-interface {p1}, Landroid/view/SurfaceHolder;->getSurfaceFrame()Landroid/graphics/Rect;

    move-result-object v4

    invoke-virtual {v4}, Landroid/graphics/Rect;->width()I

    move-result v4

    invoke-interface {p1}, Landroid/view/SurfaceHolder;->getSurfaceFrame()Landroid/graphics/Rect;

    move-result-object v6

    invoke-virtual {v6}, Landroid/graphics/Rect;->height()I

    move-result v6

    mul-int v7, v6, p2

    div-int/lit8 v7, v7, 0x2

    int-to-float v7, v7

    const/high16 v8, 0x42c80000    # 100.0f

    div-float/2addr v7, v8

    mul-int v9, v4, p3

    div-int/lit8 v9, v9, 0x2

    int-to-float v9, v9

    div-float/2addr v9, v8

    int-to-float v4, v4

    const/4 v10, 0x1

    int-to-float v11, v10

    div-int/lit8 p3, p3, 0x2

    int-to-float p3, p3

    div-float/2addr p3, v8

    sub-float p3, v11, p3

    mul-float/2addr p3, v4

    int-to-float v4, v6

    div-int/lit8 p2, p2, 0x2

    int-to-float p2, p2

    div-float/2addr p2, v8

    sub-float/2addr v11, p2

    mul-float/2addr v11, v4

    new-instance p2, Landroid/graphics/RectF;

    invoke-direct {p2, v9, v7, p3, v11}, Landroid/graphics/RectF;-><init>(FFFF)V

    const/high16 v4, 0x41200000    # 10.0f

    invoke-virtual {v0, p2, v4, v4, v1}, Landroid/graphics/Canvas;->drawRoundRect(Landroid/graphics/RectF;FFLandroid/graphics/Paint;)V

    new-instance v1, Landroid/graphics/Paint;

    invoke-direct {v1}, Landroid/graphics/Paint;-><init>()V

    sget v4, Lcom/scanflow/datacapture/sftext/SFTextOverlay;->mTopLeftColor:I

    invoke-virtual {v1, v4}, Landroid/graphics/Paint;->setColor(I)V

    invoke-virtual {v1, v5}, Landroid/graphics/Paint;->setStyle(Landroid/graphics/Paint$Style;)V

    const/high16 v4, 0x40a00000    # 5.0f

    invoke-virtual {v1, v4}, Landroid/graphics/Paint;->setStrokeWidth(F)V

    invoke-virtual {v1, v10}, Landroid/graphics/Paint;->setAntiAlias(Z)V

    sget-boolean v4, Lcom/scanflow/datacapture/sftext/SFTextOverlay;->isBorderCornersRounded:Z

    if-eqz v4, :cond_0

    sget-object v4, Landroid/graphics/Paint$Join;->ROUND:Landroid/graphics/Paint$Join;

    invoke-virtual {v1, v4}, Landroid/graphics/Paint;->setStrokeJoin(Landroid/graphics/Paint$Join;)V

    new-instance v4, Landroid/graphics/CornerPathEffect;

    const/high16 v5, 0x41a00000    # 20.0f

    invoke-direct {v4, v5}, Landroid/graphics/CornerPathEffect;-><init>(F)V

    invoke-virtual {v1, v4}, Landroid/graphics/Paint;->setPathEffect(Landroid/graphics/PathEffect;)Landroid/graphics/PathEffect;

    goto :goto_0

    :cond_0
    sget-object v4, Landroid/graphics/Paint$Join;->BEVEL:Landroid/graphics/Paint$Join;

    invoke-virtual {v1, v4}, Landroid/graphics/Paint;->setStrokeJoin(Landroid/graphics/Paint$Join;)V

    :goto_0
    new-instance v4, Landroid/graphics/Path;

    invoke-direct {v4}, Landroid/graphics/Path;-><init>()V

    int-to-float v2, v2

    add-float v5, v7, v2

    invoke-virtual {v4, v9, v5}, Landroid/graphics/Path;->moveTo(FF)V

    invoke-virtual {v4, v9, v7}, Landroid/graphics/Path;->lineTo(FF)V

    add-float v6, v9, v2

    invoke-virtual {v4, v6, v7}, Landroid/graphics/Path;->lineTo(FF)V

    invoke-virtual {v0, v4, v1}, Landroid/graphics/Canvas;->drawPath(Landroid/graphics/Path;Landroid/graphics/Paint;)V

    new-instance v4, Landroid/graphics/Path;

    invoke-direct {v4}, Landroid/graphics/Path;-><init>()V

    sget v8, Lcom/scanflow/datacapture/sftext/SFTextOverlay;->mTopRightColor:I

    invoke-virtual {v1, v8}, Landroid/graphics/Paint;->setColor(I)V

    invoke-virtual {v4, p3, v5}, Landroid/graphics/Path;->moveTo(FF)V

    invoke-virtual {v4, p3, v7}, Landroid/graphics/Path;->lineTo(FF)V

    sub-float v5, p3, v2

    invoke-virtual {v4, v5, v7}, Landroid/graphics/Path;->lineTo(FF)V

    invoke-virtual {v0, v4, v1}, Landroid/graphics/Canvas;->drawPath(Landroid/graphics/Path;Landroid/graphics/Paint;)V

    new-instance v4, Landroid/graphics/Path;

    invoke-direct {v4}, Landroid/graphics/Path;-><init>()V

    sget v7, Lcom/scanflow/datacapture/sftext/SFTextOverlay;->mBottomRightColor:I

    invoke-virtual {v1, v7}, Landroid/graphics/Paint;->setColor(I)V

    sub-float v2, v11, v2

    invoke-virtual {v4, p3, v2}, Landroid/graphics/Path;->moveTo(FF)V

    invoke-virtual {v4, p3, v11}, Landroid/graphics/Path;->lineTo(FF)V

    invoke-virtual {v4, v5, v11}, Landroid/graphics/Path;->lineTo(FF)V

    invoke-virtual {v0, v4, v1}, Landroid/graphics/Canvas;->drawPath(Landroid/graphics/Path;Landroid/graphics/Paint;)V

    new-instance p3, Landroid/graphics/Path;

    invoke-direct {p3}, Landroid/graphics/Path;-><init>()V

    sget v4, Lcom/scanflow/datacapture/sftext/SFTextOverlay;->mBottomLeftColor:I

    invoke-virtual {v1, v4}, Landroid/graphics/Paint;->setColor(I)V

    invoke-virtual {p3, v9, v2}, Landroid/graphics/Path;->moveTo(FF)V

    invoke-virtual {p3, v9, v11}, Landroid/graphics/Path;->lineTo(FF)V

    invoke-virtual {p3, v6, v11}, Landroid/graphics/Path;->lineTo(FF)V

    invoke-virtual {v0, p3, v1}, Landroid/graphics/Canvas;->drawPath(Landroid/graphics/Path;Landroid/graphics/Paint;)V

    new-instance p3, Landroid/graphics/Paint;

    invoke-direct {p3}, Landroid/graphics/Paint;-><init>()V

    invoke-virtual {p3, v3}, Landroid/graphics/Paint;->setColor(I)V

    const/high16 v1, 0x42080000    # 34.0f

    invoke-virtual {p3, v1}, Landroid/graphics/Paint;->setTextSize(F)V

    sget-object v1, Landroid/graphics/Typeface;->DEFAULT:Landroid/graphics/Typeface;

    invoke-static {v1, v10}, Landroid/graphics/Typeface;->create(Landroid/graphics/Typeface;I)Landroid/graphics/Typeface;

    move-result-object v1

    invoke-virtual {p3, v1}, Landroid/graphics/Paint;->setTypeface(Landroid/graphics/Typeface;)Landroid/graphics/Typeface;

    invoke-interface {p1, v0}, Landroid/view/SurfaceHolder;->unlockCanvasAndPost(Landroid/graphics/Canvas;)V

    return-object p2
.end method

.method public final getMBottomLeftColor()I
    .locals 1

    .line 0
    sget v0, Lcom/scanflow/datacapture/sftext/SFTextOverlay;->mBottomLeftColor:I

    return v0
.end method

.method public final getMBottomRightColor()I
    .locals 1

    .line 0
    sget v0, Lcom/scanflow/datacapture/sftext/SFTextOverlay;->mBottomRightColor:I

    return v0
.end method

.method public final getMTopLeftColor()I
    .locals 1

    .line 0
    sget v0, Lcom/scanflow/datacapture/sftext/SFTextOverlay;->mTopLeftColor:I

    return v0
.end method

.method public final getMTopRightColor()I
    .locals 1

    .line 0
    sget v0, Lcom/scanflow/datacapture/sftext/SFTextOverlay;->mTopRightColor:I

    return v0
.end method

.method public final isBorderCornersRounded()Z
    .locals 1

    .line 0
    sget-boolean v0, Lcom/scanflow/datacapture/sftext/SFTextOverlay;->isBorderCornersRounded:Z

    return v0
.end method

.method public final setBorderCornersRounded(Z)V
    .locals 0

    .line 0
    sput-boolean p1, Lcom/scanflow/datacapture/sftext/SFTextOverlay;->isBorderCornersRounded:Z

    return-void
.end method

.method public final setMBottomLeftColor(I)V
    .locals 0

    .line 0
    sput p1, Lcom/scanflow/datacapture/sftext/SFTextOverlay;->mBottomLeftColor:I

    return-void
.end method

.method public final setMBottomRightColor(I)V
    .locals 0

    .line 0
    sput p1, Lcom/scanflow/datacapture/sftext/SFTextOverlay;->mBottomRightColor:I

    return-void
.end method

.method public final setMTopLeftColor(I)V
    .locals 0

    .line 0
    sput p1, Lcom/scanflow/datacapture/sftext/SFTextOverlay;->mTopLeftColor:I

    return-void
.end method

.method public final setMTopRightColor(I)V
    .locals 0

    .line 0
    sput p1, Lcom/scanflow/datacapture/sftext/SFTextOverlay;->mTopRightColor:I

    return-void
.end method

.method public final setTextCaptureOverlay(Landroid/view/SurfaceView;IIIIIIZ)V
    .locals 1

    .line 0
    const-string v0, "surfaceView"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    sput-boolean p8, Lcom/scanflow/datacapture/sftext/SFTextOverlay;->isBorderCornersRounded:Z

    sput p4, Lcom/scanflow/datacapture/sftext/SFTextOverlay;->mTopLeftColor:I

    sput p5, Lcom/scanflow/datacapture/sftext/SFTextOverlay;->mTopRightColor:I

    sput p6, Lcom/scanflow/datacapture/sftext/SFTextOverlay;->mBottomLeftColor:I

    sput p7, Lcom/scanflow/datacapture/sftext/SFTextOverlay;->mBottomRightColor:I

    const/4 p4, 0x1

    invoke-virtual {p1, p4}, Landroid/view/SurfaceView;->setZOrderMediaOverlay(Z)V

    invoke-virtual {p1}, Landroid/view/SurfaceView;->getHolder()Landroid/view/SurfaceHolder;

    move-result-object p4

    const/4 p5, -0x2

    invoke-interface {p4, p5}, Landroid/view/SurfaceHolder;->setFormat(I)V

    invoke-virtual {p1}, Landroid/view/SurfaceView;->getHolder()Landroid/view/SurfaceHolder;

    move-result-object p4

    new-instance p5, Lcom/scanflow/datacapture/sftext/SFTextOverlay$setTextCaptureOverlay$1$1;

    invoke-direct {p5, p1, p2, p3}, Lcom/scanflow/datacapture/sftext/SFTextOverlay$setTextCaptureOverlay$1$1;-><init>(Landroid/view/SurfaceView;II)V

    invoke-interface {p4, p5}, Landroid/view/SurfaceHolder;->addCallback(Landroid/view/SurfaceHolder$Callback;)V

    return-void
.end method
