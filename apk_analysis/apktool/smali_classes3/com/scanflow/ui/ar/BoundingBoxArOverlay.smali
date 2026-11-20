.class public final Lcom/scanflow/ui/ar/BoundingBoxArOverlay;
.super Lcom/scanflow/ui/ar/a;
.source "SourceFile"

# interfaces
.implements Lcom/scanflow/ui/ar/ArObjectTracker$ArObjectTrackingListener;


# instance fields
.field private arObject:Ljava/util/ArrayList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/ArrayList<",
            "Lcom/scanflow/ui/ar/ArObject;",
            ">;"
        }
    .end annotation
.end field

.field private final boundingBoxBorderPaint:Landroid/graphics/Paint;

.field private final boundingBoxFillPaint:Landroid/graphics/Paint;

.field private final context:Landroid/content/Context;

.field private final cornerRadius:F

.field private currentBoundingBox:Landroid/graphics/RectF;

.field private currentTrackingId:Ljava/lang/String;

.field private final debugMode:Z

.field private final textPaint:Landroid/graphics/Paint;


# direct methods
.method public constructor <init>(Landroid/content/Context;Z)V
    .locals 2

    .line 1
    const-string v0, "context"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-direct {p0}, Lcom/scanflow/ui/ar/a;-><init>()V

    iput-object p1, p0, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;->context:Landroid/content/Context;

    iput-boolean p2, p0, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;->debugMode:Z

    invoke-virtual {p1}, Landroid/content/Context;->getResources()Landroid/content/res/Resources;

    move-result-object p2

    sget v0, Lcom/scanflow/datacapture/R$dimen;->ar_bounding_box_corner_radius:I

    invoke-virtual {p2, v0}, Landroid/content/res/Resources;->getDimension(I)F

    move-result p2

    iput p2, p0, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;->cornerRadius:F

    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;->arObject:Ljava/util/ArrayList;

    new-instance v0, Landroid/graphics/Paint;

    invoke-direct {v0}, Landroid/graphics/Paint;-><init>()V

    invoke-virtual {p1}, Landroid/content/Context;->getResources()Landroid/content/res/Resources;

    move-result-object p1

    sget v1, Lcom/scanflow/datacapture/R$dimen;->ar_bounding_rect_stroke_width:I

    invoke-virtual {p1, v1}, Landroid/content/res/Resources;->getDimension(I)F

    move-result p1

    invoke-virtual {v0, p1}, Landroid/graphics/Paint;->setStrokeWidth(F)V

    sget-object p1, Landroid/graphics/Paint$Style;->STROKE:Landroid/graphics/Paint$Style;

    invoke-virtual {v0, p1}, Landroid/graphics/Paint;->setStyle(Landroid/graphics/Paint$Style;)V

    const/4 p1, 0x1

    invoke-virtual {v0, p1}, Landroid/graphics/Paint;->setAntiAlias(Z)V

    iput-object v0, p0, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;->boundingBoxBorderPaint:Landroid/graphics/Paint;

    new-instance v0, Landroid/graphics/Paint;

    invoke-direct {v0}, Landroid/graphics/Paint;-><init>()V

    sget-object v1, Landroid/graphics/Paint$Style;->FILL:Landroid/graphics/Paint$Style;

    invoke-virtual {v0, v1}, Landroid/graphics/Paint;->setStyle(Landroid/graphics/Paint$Style;)V

    invoke-virtual {v0, p1}, Landroid/graphics/Paint;->setAntiAlias(Z)V

    iput-object v0, p0, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;->boundingBoxFillPaint:Landroid/graphics/Paint;

    new-instance v0, Landroid/graphics/Paint;

    invoke-direct {v0}, Landroid/graphics/Paint;-><init>()V

    const/4 v1, -0x1

    invoke-virtual {v0, v1}, Landroid/graphics/Paint;->setColor(I)V

    invoke-virtual {v0, p2}, Landroid/graphics/Paint;->setTextSize(F)V

    invoke-virtual {v0, p1}, Landroid/graphics/Paint;->setAntiAlias(Z)V

    iput-object v0, p0, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;->textPaint:Landroid/graphics/Paint;

    invoke-virtual {p0, v1}, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;->setBoundingBoxColor(I)V

    return-void
.end method

.method public synthetic constructor <init>(Landroid/content/Context;ZILkotlin/jvm/internal/DefaultConstructorMarker;)V
    .locals 0

    and-int/lit8 p3, p3, 0x2

    if-eqz p3, :cond_0

    const/4 p2, 0x0

    .line 2
    :cond_0
    invoke-direct {p0, p1, p2}, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;-><init>(Landroid/content/Context;Z)V

    return-void
.end method


# virtual methods
.method public onDraw(Landroid/graphics/Canvas;)V
    .locals 6

    .line 0
    const-string v0, "canvas"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iget-object v0, p0, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;->currentBoundingBox:Landroid/graphics/RectF;

    if-eqz v0, :cond_0

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    iget v1, p0, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;->cornerRadius:F

    iget-object v2, p0, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;->boundingBoxFillPaint:Landroid/graphics/Paint;

    invoke-virtual {p1, v0, v1, v1, v2}, Landroid/graphics/Canvas;->drawRoundRect(Landroid/graphics/RectF;FFLandroid/graphics/Paint;)V

    iget-object v0, p0, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;->currentBoundingBox:Landroid/graphics/RectF;

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    iget v1, p0, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;->cornerRadius:F

    iget-object v2, p0, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;->boundingBoxBorderPaint:Landroid/graphics/Paint;

    invoke-virtual {p1, v0, v1, v1, v2}, Landroid/graphics/Canvas;->drawRoundRect(Landroid/graphics/RectF;FFLandroid/graphics/Paint;)V

    iget-boolean v0, p0, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;->debugMode:Z

    if-eqz v0, :cond_2

    iget-object v0, p0, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;->currentTrackingId:Ljava/lang/String;

    invoke-static {v0}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    iget-object v1, p0, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;->currentBoundingBox:Landroid/graphics/RectF;

    invoke-static {v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    iget v1, v1, Landroid/graphics/RectF;->left:F

    iget v2, p0, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;->cornerRadius:F

    add-float/2addr v1, v2

    iget-object v2, p0, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;->currentBoundingBox:Landroid/graphics/RectF;

    invoke-static {v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    iget v2, v2, Landroid/graphics/RectF;->bottom:F

    iget v3, p0, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;->cornerRadius:F

    sub-float/2addr v2, v3

    iget-object v3, p0, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;->textPaint:Landroid/graphics/Paint;

    invoke-virtual {p1, v0, v1, v2, v3}, Landroid/graphics/Canvas;->drawText(Ljava/lang/String;FFLandroid/graphics/Paint;)V

    return-void

    :cond_0
    iget-object v0, p0, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;->arObject:Ljava/util/ArrayList;

    invoke-virtual {v0}, Ljava/util/ArrayList;->size()I

    move-result v0

    if-lez v0, :cond_2

    iget-object v0, p0, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;->arObject:Ljava/util/ArrayList;

    invoke-virtual {v0}, Ljava/util/ArrayList;->iterator()Ljava/util/Iterator;

    move-result-object v0

    const-string v1, "iterator(...)"

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    :goto_0
    invoke-interface {v0}, Ljava/util/Iterator;->hasNext()Z

    move-result v1

    if-eqz v1, :cond_2

    invoke-interface {v0}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v1

    const-string v2, "next(...)"

    invoke-static {v1, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast v1, Lcom/scanflow/ui/ar/ArObject;

    invoke-virtual {v1}, Lcom/scanflow/ui/ar/ArObject;->getBboxcolor()I

    move-result v2

    invoke-virtual {p0, v2}, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;->setBoundingBoxColor(I)V

    invoke-virtual {v1}, Lcom/scanflow/ui/ar/ArObject;->getShowtickimage()Z

    move-result v2

    if-eqz v2, :cond_1

    iget-object v2, p0, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;->context:Landroid/content/Context;

    invoke-virtual {v2}, Landroid/content/Context;->getResources()Landroid/content/res/Resources;

    move-result-object v2

    const-string v3, "getResources(...)"

    invoke-static {v2, v3}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    sget v3, Lcom/scanflow/datacapture/R$drawable;->ic_blue_tick_20:I

    invoke-static {v2, v3}, Landroid/graphics/BitmapFactory;->decodeResource(Landroid/content/res/Resources;I)Landroid/graphics/Bitmap;

    move-result-object v2

    invoke-virtual {v1}, Lcom/scanflow/ui/ar/ArObject;->getBoundingBox()Landroid/graphics/RectF;

    move-result-object v3

    invoke-virtual {v3}, Landroid/graphics/RectF;->centerX()F

    move-result v3

    invoke-virtual {v2}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v4

    div-int/lit8 v4, v4, 0x2

    int-to-float v4, v4

    sub-float/2addr v3, v4

    invoke-virtual {v1}, Lcom/scanflow/ui/ar/ArObject;->getBoundingBox()Landroid/graphics/RectF;

    move-result-object v4

    invoke-virtual {v4}, Landroid/graphics/RectF;->centerY()F

    move-result v4

    invoke-virtual {v2}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v5

    div-int/lit8 v5, v5, 0x2

    int-to-float v5, v5

    sub-float/2addr v4, v5

    new-instance v5, Landroid/graphics/Paint;

    invoke-direct {v5}, Landroid/graphics/Paint;-><init>()V

    invoke-virtual {p1, v2, v3, v4, v5}, Landroid/graphics/Canvas;->drawBitmap(Landroid/graphics/Bitmap;FFLandroid/graphics/Paint;)V

    :cond_1
    invoke-virtual {v1}, Lcom/scanflow/ui/ar/ArObject;->getBoundingBox()Landroid/graphics/RectF;

    move-result-object v2

    iget v3, p0, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;->cornerRadius:F

    iget-object v4, p0, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;->boundingBoxFillPaint:Landroid/graphics/Paint;

    invoke-virtual {p1, v2, v3, v3, v4}, Landroid/graphics/Canvas;->drawRoundRect(Landroid/graphics/RectF;FFLandroid/graphics/Paint;)V

    invoke-virtual {v1}, Lcom/scanflow/ui/ar/ArObject;->getBoundingBox()Landroid/graphics/RectF;

    move-result-object v1

    iget v2, p0, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;->cornerRadius:F

    iget-object v3, p0, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;->boundingBoxBorderPaint:Landroid/graphics/Paint;

    invoke-virtual {p1, v1, v2, v2, v3}, Landroid/graphics/Canvas;->drawRoundRect(Landroid/graphics/RectF;FFLandroid/graphics/Paint;)V

    goto :goto_0

    :cond_2
    return-void
.end method

.method public onObjectTracked(Lcom/scanflow/ui/ar/ArObject;)V
    .locals 2

    const/4 v0, 0x0

    if-eqz p1, :cond_0

    .line 1
    invoke-virtual {p1}, Lcom/scanflow/ui/ar/ArObject;->getBoundingBox()Landroid/graphics/RectF;

    move-result-object v1

    goto :goto_0

    :cond_0
    move-object v1, v0

    :goto_0
    iput-object v1, p0, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;->currentBoundingBox:Landroid/graphics/RectF;

    if-eqz p1, :cond_1

    invoke-virtual {p1}, Lcom/scanflow/ui/ar/ArObject;->getTrackingId()Ljava/lang/String;

    move-result-object v0

    :cond_1
    iput-object v0, p0, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;->currentTrackingId:Ljava/lang/String;

    if-eqz p1, :cond_2

    invoke-virtual {p1}, Lcom/scanflow/ui/ar/ArObject;->getBboxcolor()I

    move-result p1

    invoke-virtual {p0, p1}, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;->setBoundingBoxColor(I)V

    :cond_2
    invoke-virtual {p0}, Lcom/scanflow/ui/ar/a;->getHost()Lcom/scanflow/ui/ar/ArOverlayView;

    move-result-object p1

    if-eqz p1, :cond_3

    invoke-virtual {p1}, Landroid/view/View;->invalidate()V

    :cond_3
    return-void
.end method

.method public onObjectTracked(Ljava/util/ArrayList;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/ArrayList<",
            "Lcom/scanflow/ui/ar/ArObject;",
            ">;)V"
        }
    .end annotation

    .line 2
    const-string v0, "arObject"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iput-object p1, p0, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;->arObject:Ljava/util/ArrayList;

    invoke-virtual {p0}, Lcom/scanflow/ui/ar/a;->getHost()Lcom/scanflow/ui/ar/ArOverlayView;

    move-result-object p1

    if-eqz p1, :cond_0

    invoke-virtual {p1}, Landroid/view/View;->invalidate()V

    :cond_0
    return-void
.end method

.method public final setBoundingBoxColor(I)V
    .locals 2

    .line 0
    iget-object v0, p0, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;->boundingBoxBorderPaint:Landroid/graphics/Paint;

    invoke-virtual {v0, p1}, Landroid/graphics/Paint;->setColor(I)V

    iget-object v0, p0, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;->boundingBoxBorderPaint:Landroid/graphics/Paint;

    const/16 v1, 0x99

    invoke-virtual {v0, v1}, Landroid/graphics/Paint;->setAlpha(I)V

    iget-object v0, p0, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;->boundingBoxFillPaint:Landroid/graphics/Paint;

    invoke-virtual {v0, p1}, Landroid/graphics/Paint;->setColor(I)V

    iget-object p1, p0, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;->boundingBoxFillPaint:Landroid/graphics/Paint;

    const/16 v0, 0x33

    invoke-virtual {p1, v0}, Landroid/graphics/Paint;->setAlpha(I)V

    invoke-virtual {p0}, Lcom/scanflow/ui/ar/a;->getHost()Lcom/scanflow/ui/ar/ArOverlayView;

    move-result-object p1

    if-eqz p1, :cond_0

    invoke-virtual {p1}, Landroid/view/View;->invalidate()V

    :cond_0
    return-void
.end method
