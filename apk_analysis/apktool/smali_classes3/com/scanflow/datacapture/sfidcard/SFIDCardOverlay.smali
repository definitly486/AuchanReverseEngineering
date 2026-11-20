.class public final Lcom/scanflow/datacapture/sfidcard/SFIDCardOverlay;
.super Ljava/lang/Object;
.source "SourceFile"


# static fields
.field public static final INSTANCE:Lcom/scanflow/datacapture/sfidcard/SFIDCardOverlay;

.field private static isBorderCornersRounded:Z

.field private static mBottomLeftColor:I

.field private static mBottomRightColor:I

.field private static mTopLeftColor:I

.field private static mTopRightColor:I


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/sfidcard/SFIDCardOverlay;

    invoke-direct {v0}, Lcom/scanflow/datacapture/sfidcard/SFIDCardOverlay;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/sfidcard/SFIDCardOverlay;->INSTANCE:Lcom/scanflow/datacapture/sfidcard/SFIDCardOverlay;

    const/4 v0, 0x1

    sput-boolean v0, Lcom/scanflow/datacapture/sfidcard/SFIDCardOverlay;->isBorderCornersRounded:Z

    const-string v0, "#2256DE"

    invoke-static {v0}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result v0

    sput v0, Lcom/scanflow/datacapture/sfidcard/SFIDCardOverlay;->mTopLeftColor:I

    const-string v0, "#FF543E"

    invoke-static {v0}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result v0

    sput v0, Lcom/scanflow/datacapture/sfidcard/SFIDCardOverlay;->mTopRightColor:I

    const-string v0, "#FFAF4D"

    invoke-static {v0}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result v0

    sput v0, Lcom/scanflow/datacapture/sfidcard/SFIDCardOverlay;->mBottomLeftColor:I

    const-string v0, "#3098F1"

    invoke-static {v0}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result v0

    sput v0, Lcom/scanflow/datacapture/sfidcard/SFIDCardOverlay;->mBottomRightColor:I

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public final drawOverlay(Landroid/view/SurfaceHolder;IIZ)V
    .locals 16

    .line 0
    move-object/from16 v0, p1

    const-string v1, "holder"

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-interface {v0}, Landroid/view/SurfaceHolder;->lockCanvas()Landroid/graphics/Canvas;

    move-result-object v1

    new-instance v2, Landroid/graphics/Paint;

    invoke-direct {v2}, Landroid/graphics/Paint;-><init>()V

    const/16 v3, 0x3c

    invoke-virtual {v2, v3}, Landroid/graphics/Paint;->setAlpha(I)V

    invoke-virtual {v1, v2}, Landroid/graphics/Canvas;->drawPaint(Landroid/graphics/Paint;)V

    new-instance v2, Landroid/graphics/Paint;

    invoke-direct {v2}, Landroid/graphics/Paint;-><init>()V

    new-instance v4, Landroid/graphics/PorterDuffXfermode;

    sget-object v5, Landroid/graphics/PorterDuff$Mode;->CLEAR:Landroid/graphics/PorterDuff$Mode;

    invoke-direct {v4, v5}, Landroid/graphics/PorterDuffXfermode;-><init>(Landroid/graphics/PorterDuff$Mode;)V

    invoke-virtual {v2, v4}, Landroid/graphics/Paint;->setXfermode(Landroid/graphics/Xfermode;)Landroid/graphics/Xfermode;

    sget-object v4, Landroid/graphics/Paint$Style;->FILL:Landroid/graphics/Paint$Style;

    invoke-virtual {v2, v4}, Landroid/graphics/Paint;->setStyle(Landroid/graphics/Paint$Style;)V

    const/4 v4, -0x1

    invoke-virtual {v2, v4}, Landroid/graphics/Paint;->setColor(I)V

    new-instance v5, Landroid/graphics/Paint;

    invoke-direct {v5}, Landroid/graphics/Paint;-><init>()V

    sget-object v6, Landroid/graphics/Paint$Style;->STROKE:Landroid/graphics/Paint$Style;

    invoke-virtual {v5, v6}, Landroid/graphics/Paint;->setStyle(Landroid/graphics/Paint$Style;)V

    invoke-virtual {v5, v4}, Landroid/graphics/Paint;->setColor(I)V

    const/high16 v7, 0x40800000    # 4.0f

    invoke-virtual {v5, v7}, Landroid/graphics/Paint;->setStrokeWidth(F)V

    invoke-interface {v0}, Landroid/view/SurfaceHolder;->getSurfaceFrame()Landroid/graphics/Rect;

    move-result-object v5

    invoke-virtual {v5}, Landroid/graphics/Rect;->width()I

    move-result v5

    invoke-interface {v0}, Landroid/view/SurfaceHolder;->getSurfaceFrame()Landroid/graphics/Rect;

    move-result-object v7

    invoke-virtual {v7}, Landroid/graphics/Rect;->height()I

    move-result v7

    mul-int v8, v7, p2

    div-int/lit8 v8, v8, 0x2

    int-to-float v8, v8

    const/high16 v9, 0x42c80000    # 100.0f

    div-float/2addr v8, v9

    mul-int v10, v5, p3

    div-int/lit8 v10, v10, 0x2

    int-to-float v10, v10

    div-float/2addr v10, v9

    int-to-float v11, v5

    const/4 v12, 0x1

    int-to-float v13, v12

    div-int/lit8 v14, p3, 0x2

    int-to-float v14, v14

    div-float/2addr v14, v9

    sub-float v14, v13, v14

    mul-float/2addr v14, v11

    int-to-float v7, v7

    div-int/lit8 v11, p2, 0x2

    int-to-float v11, v11

    div-float/2addr v11, v9

    sub-float/2addr v13, v11

    mul-float/2addr v13, v7

    new-instance v7, Landroid/graphics/RectF;

    invoke-direct {v7, v10, v8, v14, v13}, Landroid/graphics/RectF;-><init>(FFFF)V

    const/high16 v9, 0x41200000    # 10.0f

    invoke-virtual {v1, v7, v9, v9, v2}, Landroid/graphics/Canvas;->drawRoundRect(Landroid/graphics/RectF;FFLandroid/graphics/Paint;)V

    new-instance v2, Landroid/graphics/Paint;

    invoke-direct {v2}, Landroid/graphics/Paint;-><init>()V

    sget-object v7, Lcom/scanflow/datacapture/sftext/SFTextOverlay;->INSTANCE:Lcom/scanflow/datacapture/sftext/SFTextOverlay;

    invoke-virtual {v7}, Lcom/scanflow/datacapture/sftext/SFTextOverlay;->getMTopLeftColor()I

    move-result v9

    invoke-virtual {v2, v9}, Landroid/graphics/Paint;->setColor(I)V

    invoke-virtual {v2, v6}, Landroid/graphics/Paint;->setStyle(Landroid/graphics/Paint$Style;)V

    const/high16 v6, 0x40a00000    # 5.0f

    invoke-virtual {v2, v6}, Landroid/graphics/Paint;->setStrokeWidth(F)V

    invoke-virtual {v2, v12}, Landroid/graphics/Paint;->setAntiAlias(Z)V

    invoke-virtual {v7}, Lcom/scanflow/datacapture/sftext/SFTextOverlay;->isBorderCornersRounded()Z

    move-result v6

    if-eqz v6, :cond_0

    sget-object v6, Landroid/graphics/Paint$Join;->ROUND:Landroid/graphics/Paint$Join;

    invoke-virtual {v2, v6}, Landroid/graphics/Paint;->setStrokeJoin(Landroid/graphics/Paint$Join;)V

    new-instance v6, Landroid/graphics/CornerPathEffect;

    const/high16 v9, 0x41a00000    # 20.0f

    invoke-direct {v6, v9}, Landroid/graphics/CornerPathEffect;-><init>(F)V

    invoke-virtual {v2, v6}, Landroid/graphics/Paint;->setPathEffect(Landroid/graphics/PathEffect;)Landroid/graphics/PathEffect;

    goto :goto_0

    :cond_0
    sget-object v6, Landroid/graphics/Paint$Join;->BEVEL:Landroid/graphics/Paint$Join;

    invoke-virtual {v2, v6}, Landroid/graphics/Paint;->setStrokeJoin(Landroid/graphics/Paint$Join;)V

    :goto_0
    new-instance v6, Landroid/graphics/Path;

    invoke-direct {v6}, Landroid/graphics/Path;-><init>()V

    int-to-float v3, v3

    add-float v9, v8, v3

    invoke-virtual {v6, v10, v9}, Landroid/graphics/Path;->moveTo(FF)V

    invoke-virtual {v6, v10, v8}, Landroid/graphics/Path;->lineTo(FF)V

    add-float v11, v10, v3

    invoke-virtual {v6, v11, v8}, Landroid/graphics/Path;->lineTo(FF)V

    invoke-virtual {v1, v6, v2}, Landroid/graphics/Canvas;->drawPath(Landroid/graphics/Path;Landroid/graphics/Paint;)V

    new-instance v6, Landroid/graphics/Path;

    invoke-direct {v6}, Landroid/graphics/Path;-><init>()V

    invoke-virtual {v7}, Lcom/scanflow/datacapture/sftext/SFTextOverlay;->getMTopRightColor()I

    move-result v15

    invoke-virtual {v2, v15}, Landroid/graphics/Paint;->setColor(I)V

    invoke-virtual {v6, v14, v9}, Landroid/graphics/Path;->moveTo(FF)V

    invoke-virtual {v6, v14, v8}, Landroid/graphics/Path;->lineTo(FF)V

    sub-float v9, v14, v3

    invoke-virtual {v6, v9, v8}, Landroid/graphics/Path;->lineTo(FF)V

    invoke-virtual {v1, v6, v2}, Landroid/graphics/Canvas;->drawPath(Landroid/graphics/Path;Landroid/graphics/Paint;)V

    new-instance v6, Landroid/graphics/Path;

    invoke-direct {v6}, Landroid/graphics/Path;-><init>()V

    invoke-virtual {v7}, Lcom/scanflow/datacapture/sftext/SFTextOverlay;->getMBottomRightColor()I

    move-result v8

    invoke-virtual {v2, v8}, Landroid/graphics/Paint;->setColor(I)V

    sub-float v3, v13, v3

    invoke-virtual {v6, v14, v3}, Landroid/graphics/Path;->moveTo(FF)V

    invoke-virtual {v6, v14, v13}, Landroid/graphics/Path;->lineTo(FF)V

    invoke-virtual {v6, v9, v13}, Landroid/graphics/Path;->lineTo(FF)V

    invoke-virtual {v1, v6, v2}, Landroid/graphics/Canvas;->drawPath(Landroid/graphics/Path;Landroid/graphics/Paint;)V

    new-instance v6, Landroid/graphics/Path;

    invoke-direct {v6}, Landroid/graphics/Path;-><init>()V

    invoke-virtual {v7}, Lcom/scanflow/datacapture/sftext/SFTextOverlay;->getMBottomLeftColor()I

    move-result v7

    invoke-virtual {v2, v7}, Landroid/graphics/Paint;->setColor(I)V

    invoke-virtual {v6, v10, v3}, Landroid/graphics/Path;->moveTo(FF)V

    invoke-virtual {v6, v10, v13}, Landroid/graphics/Path;->lineTo(FF)V

    invoke-virtual {v6, v11, v13}, Landroid/graphics/Path;->lineTo(FF)V

    invoke-virtual {v1, v6, v2}, Landroid/graphics/Canvas;->drawPath(Landroid/graphics/Path;Landroid/graphics/Paint;)V

    new-instance v2, Landroid/graphics/Paint;

    invoke-direct {v2}, Landroid/graphics/Paint;-><init>()V

    invoke-virtual {v2, v4}, Landroid/graphics/Paint;->setColor(I)V

    const/high16 v3, 0x42080000    # 34.0f

    invoke-virtual {v2, v3}, Landroid/graphics/Paint;->setTextSize(F)V

    sget-object v3, Landroid/graphics/Typeface;->DEFAULT:Landroid/graphics/Typeface;

    invoke-static {v3, v12}, Landroid/graphics/Typeface;->create(Landroid/graphics/Typeface;I)Landroid/graphics/Typeface;

    move-result-object v3

    invoke-virtual {v2, v3}, Landroid/graphics/Paint;->setTypeface(Landroid/graphics/Typeface;)Landroid/graphics/Typeface;

    if-eqz p4, :cond_1

    const-string v3, "Scan the front side"

    goto :goto_1

    :cond_1
    const-string v3, "Scan the back side"

    :goto_1
    new-instance v4, Landroid/graphics/Rect;

    invoke-direct {v4}, Landroid/graphics/Rect;-><init>()V

    invoke-virtual {v3}, Ljava/lang/String;->length()I

    move-result v6

    const/4 v7, 0x0

    invoke-virtual {v2, v3, v7, v6, v4}, Landroid/graphics/Paint;->getTextBounds(Ljava/lang/String;IILandroid/graphics/Rect;)V

    invoke-virtual {v4}, Landroid/graphics/Rect;->width()I

    move-result v6

    sub-int v6, v5, v6

    int-to-float v6, v6

    const/high16 v8, 0x40000000    # 2.0f

    div-float/2addr v6, v8

    invoke-virtual {v4}, Landroid/graphics/Rect;->height()I

    move-result v9

    int-to-float v9, v9

    add-float/2addr v9, v13

    const/high16 v10, 0x41700000    # 15.0f

    add-float/2addr v9, v10

    invoke-virtual {v1, v3, v6, v9, v2}, Landroid/graphics/Canvas;->drawText(Ljava/lang/String;FFLandroid/graphics/Paint;)V

    new-instance v3, Landroid/graphics/Rect;

    invoke-direct {v3}, Landroid/graphics/Rect;-><init>()V

    const/16 v6, 0xd

    const-string v9, "of a document"

    invoke-virtual {v2, v9, v7, v6, v3}, Landroid/graphics/Paint;->getTextBounds(Ljava/lang/String;IILandroid/graphics/Rect;)V

    invoke-virtual {v3}, Landroid/graphics/Rect;->width()I

    move-result v6

    sub-int/2addr v5, v6

    int-to-float v5, v5

    div-float/2addr v5, v8

    invoke-virtual {v4}, Landroid/graphics/Rect;->height()I

    move-result v4

    int-to-float v4, v4

    add-float/2addr v13, v4

    invoke-virtual {v3}, Landroid/graphics/Rect;->height()I

    move-result v3

    int-to-float v3, v3

    add-float/2addr v13, v3

    const/high16 v3, 0x41f00000    # 30.0f

    add-float/2addr v13, v3

    invoke-virtual {v1, v9, v5, v13, v2}, Landroid/graphics/Canvas;->drawText(Ljava/lang/String;FFLandroid/graphics/Paint;)V

    invoke-interface {v0, v1}, Landroid/view/SurfaceHolder;->unlockCanvasAndPost(Landroid/graphics/Canvas;)V

    return-void
.end method

.method public final getMBottomLeftColor()I
    .locals 1

    .line 0
    sget v0, Lcom/scanflow/datacapture/sfidcard/SFIDCardOverlay;->mBottomLeftColor:I

    return v0
.end method

.method public final getMBottomRightColor()I
    .locals 1

    .line 0
    sget v0, Lcom/scanflow/datacapture/sfidcard/SFIDCardOverlay;->mBottomRightColor:I

    return v0
.end method

.method public final getMTopLeftColor()I
    .locals 1

    .line 0
    sget v0, Lcom/scanflow/datacapture/sfidcard/SFIDCardOverlay;->mTopLeftColor:I

    return v0
.end method

.method public final getMTopRightColor()I
    .locals 1

    .line 0
    sget v0, Lcom/scanflow/datacapture/sfidcard/SFIDCardOverlay;->mTopRightColor:I

    return v0
.end method

.method public final isBorderCornersRounded()Z
    .locals 1

    .line 0
    sget-boolean v0, Lcom/scanflow/datacapture/sfidcard/SFIDCardOverlay;->isBorderCornersRounded:Z

    return v0
.end method

.method public final setBorderCornersRounded(Z)V
    .locals 0

    .line 0
    sput-boolean p1, Lcom/scanflow/datacapture/sfidcard/SFIDCardOverlay;->isBorderCornersRounded:Z

    return-void
.end method

.method public final setIDCaptureOverlay(Landroid/view/SurfaceView;IIZ)V
    .locals 2

    .line 0
    const-string v0, "surfaceView"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const/4 v0, 0x1

    invoke-virtual {p1, v0}, Landroid/view/SurfaceView;->setZOrderMediaOverlay(Z)V

    invoke-virtual {p1}, Landroid/view/SurfaceView;->getHolder()Landroid/view/SurfaceHolder;

    move-result-object v0

    const/4 v1, -0x2

    invoke-interface {v0, v1}, Landroid/view/SurfaceHolder;->setFormat(I)V

    invoke-virtual {p1}, Landroid/view/SurfaceView;->getHolder()Landroid/view/SurfaceHolder;

    move-result-object v0

    new-instance v1, Lcom/scanflow/datacapture/sfidcard/SFIDCardOverlay$setIDCaptureOverlay$1$1;

    invoke-direct {v1, p1, p2, p3, p4}, Lcom/scanflow/datacapture/sfidcard/SFIDCardOverlay$setIDCaptureOverlay$1$1;-><init>(Landroid/view/SurfaceView;IIZ)V

    invoke-interface {v0, v1}, Landroid/view/SurfaceHolder;->addCallback(Landroid/view/SurfaceHolder$Callback;)V

    return-void
.end method

.method public final setMBottomLeftColor(I)V
    .locals 0

    .line 0
    sput p1, Lcom/scanflow/datacapture/sfidcard/SFIDCardOverlay;->mBottomLeftColor:I

    return-void
.end method

.method public final setMBottomRightColor(I)V
    .locals 0

    .line 0
    sput p1, Lcom/scanflow/datacapture/sfidcard/SFIDCardOverlay;->mBottomRightColor:I

    return-void
.end method

.method public final setMTopLeftColor(I)V
    .locals 0

    .line 0
    sput p1, Lcom/scanflow/datacapture/sfidcard/SFIDCardOverlay;->mTopLeftColor:I

    return-void
.end method

.method public final setMTopRightColor(I)V
    .locals 0

    .line 0
    sput p1, Lcom/scanflow/datacapture/sfidcard/SFIDCardOverlay;->mTopRightColor:I

    return-void
.end method
