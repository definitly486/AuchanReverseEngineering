.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;
.super Ljava/lang/Object;
.source "RefinePolygonToGrayLine.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGray;


# instance fields
.field private final adjA:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

.field private final adjB:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

.field private final before:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

.field private convergeTolPixels:D

.field private cornerOffset:D

.field private general:[Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

.field protected image:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

.field private final imageType:Ljava/lang/Class;

.field private maxCornerChangePixel:D

.field private maxIterations:I

.field private final previous:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

.field private final snapToEdge:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/SnapToLineEdge;

.field private final tempA:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

.field private final tempB:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;


# direct methods
.method public constructor <init>(DIIIDDLjava/lang/Class;)V
    .locals 4

    .line 96
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const-wide/high16 v0, 0x4000000000000000L    # 2.0

    .line 60
    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->cornerOffset:D

    const/16 v2, 0xa

    .line 63
    iput v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->maxIterations:I

    const-wide v2, 0x3f847ae147ae147bL    # 0.01

    .line 66
    iput-wide v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->convergeTolPixels:D

    .line 70
    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->maxCornerChangePixel:D

    const/4 v0, 0x0

    .line 75
    new-array v0, v0, [Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->general:[Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    .line 78
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->adjA:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    .line 79
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->adjB:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    .line 86
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->tempA:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    .line 87
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->tempB:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    .line 88
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->before:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    .line 99
    iput-wide p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->cornerOffset:D

    .line 100
    iput p5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->maxIterations:I

    .line 101
    iput-wide p6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->convergeTolPixels:D

    .line 102
    iput-wide p8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->maxCornerChangePixel:D

    .line 103
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/SnapToLineEdge;

    invoke-direct {p1, p3, p4, p10}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/SnapToLineEdge;-><init>(IILjava/lang/Class;)V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->snapToEdge:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/SnapToLineEdge;

    .line 104
    iput-object p10, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->imageType:Ljava/lang/Class;

    .line 106
    new-instance p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    const/4 p2, 0x1

    invoke-direct {p1, p2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;-><init>(I)V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->previous:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    return-void
.end method

.method private checkShapeTooSmall(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;)Z
    .locals 9

    .line 178
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->cornerOffset:D

    const-wide/high16 v2, 0x4000000000000000L    # 2.0

    mul-double/2addr v0, v2

    add-double/2addr v0, v2

    const/4 v2, 0x0

    move v3, v2

    .line 179
    :goto_0
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->size()I

    move-result v4

    if-ge v3, v4, :cond_1

    add-int/lit8 v4, v3, 0x1

    .line 180
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->size()I

    move-result v5

    rem-int v5, v4, v5

    .line 181
    invoke-virtual {p1, v3}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v3

    .line 182
    invoke-virtual {p1, v5}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v5

    .line 183
    invoke-virtual {v3, v5}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->distance2(Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;)D

    move-result-wide v5

    mul-double v7, v0, v0

    cmpg-double v3, v5, v7

    if-gez v3, :cond_0

    const/4 p1, 0x1

    return p1

    :cond_0
    move v3, v4

    goto :goto_0

    :cond_1
    return v2
.end method

.method private computeAdjustedEndPoints(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)V
    .locals 11

    .line 295
    iget-wide v0, p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    iget-wide v2, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    sub-double/2addr v0, v2

    .line 296
    iget-wide v2, p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    iget-wide v4, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    sub-double/2addr v2, v4

    mul-double v4, v0, v0

    mul-double v6, v2, v2

    add-double/2addr v4, v6

    .line 297
    invoke-static {v4, v5}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide v4

    div-double/2addr v0, v4

    div-double/2addr v2, v4

    .line 303
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->adjA:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide v5, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    iget-wide v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->cornerOffset:D

    mul-double v9, v0, v7

    add-double/2addr v5, v9

    iput-wide v5, v4, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    .line 304
    iget-wide v5, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    mul-double v9, v2, v7

    add-double/2addr v5, v9

    iput-wide v5, v4, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    .line 305
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->adjB:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide v4, p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    mul-double/2addr v0, v7

    sub-double/2addr v4, v0

    iput-wide v4, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    .line 306
    iget-wide v0, p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    mul-double/2addr v2, v7

    sub-double/2addr v0, v2

    iput-wide v0, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    return-void
.end method


# virtual methods
.method protected optimize(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;)Z
    .locals 1

    .line 277
    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->computeAdjustedEndPoints(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)V

    .line 279
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->snapToEdge:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/SnapToLineEdge;

    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->adjA:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->adjB:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-virtual {p1, p2, v0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/SnapToLineEdge;->refine(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;)Z

    move-result p1

    return p1
.end method

.method protected optimize(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;)Z
    .locals 13

    .line 194
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->previous:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    .line 197
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->convergeTolPixels:D

    mul-double/2addr v0, v0

    const/4 v2, 0x0

    move v3, v2

    .line 200
    :goto_0
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->size()I

    move-result v4

    if-ge v3, v4, :cond_0

    add-int/lit8 v4, v3, 0x1

    .line 201
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->size()I

    move-result v5

    rem-int v5, v4, v5

    .line 202
    invoke-virtual {p1, v3}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v6

    .line 203
    invoke-virtual {p1, v5}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v5

    .line 204
    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->general:[Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    aget-object v3, v7, v3

    invoke-static {v6, v5, v3}, Lcom/scanflow/datacapture/barinternal/georegression/geometry/UtilLine2D_F64;->convert(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    move v3, v4

    goto :goto_0

    :cond_0
    move p1, v2

    move v3, p1

    .line 208
    :goto_1
    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->maxIterations:I

    if-ge p1, v4, :cond_7

    move v4, v2

    .line 210
    :goto_2
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->previous:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v5}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->size()I

    move-result v5

    if-ge v4, v5, :cond_4

    add-int/lit8 v5, v4, 0x1

    .line 211
    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->previous:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v6}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->size()I

    move-result v6

    rem-int v6, v5, v6

    .line 212
    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->previous:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v7, v4}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v7

    .line 213
    iget-object v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->previous:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v8, v6}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v8

    .line 215
    iget-object v9, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->before:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    iget-object v10, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->general:[Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    aget-object v10, v10, v4

    invoke-virtual {v9, v10}, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    .line 218
    iget-object v9, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->general:[Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    aget-object v9, v9, v4

    invoke-virtual {p0, v7, v8, v9}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->optimize(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;)Z

    move-result v9

    if-nez v9, :cond_1

    goto :goto_3

    .line 221
    :cond_1
    iget-object v9, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->previous:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v9}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->size()I

    move-result v9

    add-int/2addr v9, v4

    const/4 v10, 0x1

    sub-int/2addr v9, v10

    iget-object v11, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->previous:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v11}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->size()I

    move-result v11

    rem-int/2addr v9, v11

    .line 224
    iget-object v11, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->general:[Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    aget-object v9, v11, v9

    aget-object v11, v11, v4

    iget-object v12, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->tempA:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-static {v9, v11, v12}, Lcom/scanflow/datacapture/barinternal/georegression/metric/Intersection2D_F64;->intersection(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v9

    if-eqz v9, :cond_3

    iget-object v9, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->general:[Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    aget-object v11, v9, v4

    aget-object v6, v9, v6

    iget-object v9, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->tempB:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    .line 225
    invoke-static {v11, v6, v9}, Lcom/scanflow/datacapture/barinternal/georegression/metric/Intersection2D_F64;->intersection(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v6

    if-eqz v6, :cond_3

    .line 227
    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->tempA:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-virtual {v6, v7}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->distance(Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;)D

    move-result-wide v6

    iget-wide v11, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->maxCornerChangePixel:D

    cmpl-double v6, v6, v11

    if-gtz v6, :cond_3

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->tempB:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-virtual {v6, v8}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->distance(Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;)D

    move-result-wide v6

    iget-wide v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->maxCornerChangePixel:D

    cmpl-double v6, v6, v8

    if-lez v6, :cond_2

    goto :goto_3

    :cond_2
    move v3, v10

    goto :goto_4

    .line 237
    :cond_3
    :goto_3
    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->general:[Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    aget-object v4, v6, v4

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->before:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    invoke-virtual {v4, v6}, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    :goto_4
    move v4, v5

    goto/16 :goto_2

    .line 244
    :cond_4
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->general:[Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    invoke-static {v4, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/UtilShapePolygon;->convert([Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;)Z

    move-result v4

    if-nez v4, :cond_5

    return v2

    :cond_5
    move v4, v2

    .line 249
    :goto_5
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->size()I

    move-result v5

    if-ge v4, v5, :cond_7

    .line 250
    invoke-virtual {p2, v4}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v5

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->previous:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v6, v4}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v6

    invoke-virtual {v5, v6}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->distance2(Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;)D

    move-result-wide v5

    cmpl-double v5, v5, v0

    if-lez v5, :cond_6

    .line 259
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->previous:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v4, p2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    add-int/lit8 p1, p1, 0x1

    goto/16 :goto_1

    :cond_6
    add-int/lit8 v4, v4, 0x1

    goto :goto_5

    :cond_7
    return v3
.end method

.method public refine(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;)Z
    .locals 3

    .line 150
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->size()I

    move-result v0

    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->size()I

    move-result v1

    if-ne v0, v1, :cond_2

    .line 154
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->checkShapeTooSmall(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;)Z

    move-result v0

    const/4 v1, 0x0

    if-eqz v0, :cond_0

    return v1

    .line 158
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->general:[Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    array-length v0, v0

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->size()I

    move-result v2

    if-ge v0, v2, :cond_1

    .line 159
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->size()I

    move-result v0

    new-array v0, v0, [Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->general:[Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    .line 160
    :goto_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->general:[Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    array-length v2, v0

    if-ge v1, v2, :cond_1

    .line 161
    new-instance v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    invoke-direct {v2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;-><init>()V

    aput-object v2, v0, v1

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    .line 166
    :cond_1
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->optimize(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;)Z

    move-result p1

    return p1

    .line 151
    :cond_2
    new-instance v0, Ljava/lang/IllegalArgumentException;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->size()I

    move-result p1

    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->size()I

    move-result p2

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Input and output sides do not match. "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p1, " "

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {v0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method public setImage(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)V
    .locals 1

    .line 127
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->image:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    .line 128
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGrayLine;->snapToEdge:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/SnapToLineEdge;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/BaseIntegralEdge;->setImage(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)V

    return-void
.end method
