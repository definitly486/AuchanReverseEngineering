.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;
.super Ljava/lang/Object;
.source "RefinePolyLineCorner.java"


# instance fields
.field line0:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

.field line1:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

.field looping:Z

.field private maxIterations:I

.field private final maxLineSamples:I

.field protected searchRadius:I

.field private final work:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;


# direct methods
.method public constructor <init>(ZI)V
    .locals 1

    .line 73
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const/16 v0, 0xa

    .line 50
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;->maxIterations:I

    const/16 v0, 0x14

    .line 53
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;->maxLineSamples:I

    .line 59
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;->work:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

    .line 61
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;->line0:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    .line 62
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;->line1:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    .line 74
    iput-boolean p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;->looping:Z

    .line 75
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;->maxIterations:I

    return-void
.end method

.method private createLine(IILjava/util/List;Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;)V
    .locals 4

    if-gez p2, :cond_0

    .line 217
    sget-object v0, Ljava/lang/System;->out:Ljava/io/PrintStream;

    const-string v1, "SHIT"

    invoke-virtual {v0, v1}, Ljava/io/PrintStream;->println(Ljava/lang/String;)V

    .line 218
    :cond_0
    invoke-interface {p3, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 219
    invoke-interface {p3, p2}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p2

    check-cast p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 223
    iget-object p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;->work:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

    iget-object p3, p3, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->a:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget v0, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    int-to-double v0, v0

    iget p1, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    int-to-double v2, p1

    invoke-virtual {p3, v0, v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->setTo(DD)Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;

    .line 224
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;->work:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->b:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget p3, p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    int-to-double v0, p3

    iget p2, p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    int-to-double p2, p2

    invoke-virtual {p1, v0, v1, p2, p3}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->setTo(DD)Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;

    .line 226
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;->work:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

    invoke-static {p1, p4}, Lcom/scanflow/datacapture/barinternal/georegression/geometry/UtilLine2D_F64;->convert(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    .line 229
    invoke-virtual {p4}, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->normalize()V

    return-void
.end method

.method protected static distance(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;)D
    .locals 6

    .line 209
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->A:D

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    int-to-double v2, v2

    mul-double/2addr v0, v2

    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->B:D

    iget p1, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    int-to-double v4, p1

    mul-double/2addr v2, v4

    add-double/2addr v0, v2

    iget-wide p0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->C:D

    add-double/2addr v0, p0

    invoke-static {v0, v1}, Ljava/lang/Math;->abs(D)D

    move-result-wide p0

    return-wide p0
.end method


# virtual methods
.method protected computeCost(Ljava/util/List;IIII)D
    .locals 2

    .line 164
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v0

    invoke-static {p3, p5, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/CircularIndex;->addOffset(III)I

    move-result p3

    .line 165
    iget-object p5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;->line0:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    invoke-direct {p0, p2, p3, p1, p5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;->createLine(IILjava/util/List;Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;)V

    .line 166
    iget-object p5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;->line1:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    invoke-direct {p0, p3, p4, p1, p5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;->createLine(IILjava/util/List;Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;)V

    .line 167
    iget-object p5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;->line0:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    invoke-virtual {p0, p5, p2, p3, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;->distanceSum(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;IILjava/util/List;)D

    move-result-wide v0

    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;->line1:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    invoke-virtual {p0, p2, p3, p4, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;->distanceSum(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;IILjava/util/List;)D

    move-result-wide p1

    add-double/2addr v0, p1

    return-wide v0
.end method

.method protected distanceSum(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;IILjava/util/List;)D
    .locals 10

    const/16 v0, 0x14

    const/4 v1, 0x0

    const-wide/16 v2, 0x0

    if-ge p2, p3, :cond_1

    sub-int/2addr p3, p2

    add-int/lit8 v4, p3, 0x1

    .line 177
    invoke-static {v0, v4}, Ljava/lang/Math;->min(II)I

    move-result v0

    :goto_0
    if-ge v1, v0, :cond_0

    mul-int v4, v1, p3

    add-int/lit8 v5, v0, -0x1

    .line 180
    div-int/2addr v4, v5

    add-int/2addr v4, p2

    .line 181
    invoke-interface {p4, v4}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    invoke-static {p1, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;->distance(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;)D

    move-result-wide v4

    add-double/2addr v2, v4

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_0
    return-wide v2

    .line 184
    :cond_1
    invoke-interface {p4}, Ljava/util/List;->size()I

    move-result v4

    sub-int/2addr v4, p2

    add-int/lit8 v5, p3, 0x1

    add-int/2addr p3, v4

    add-int/lit8 p3, p3, 0x1

    .line 188
    invoke-static {v0, p3}, Ljava/lang/Math;->min(II)I

    move-result v0

    mul-int v6, v0, v4

    .line 190
    div-int/2addr v6, p3

    mul-int v7, v0, v5

    .line 191
    div-int/2addr v7, p3

    move p3, v1

    :goto_1
    if-ge p3, v6, :cond_2

    mul-int v8, p3, v4

    add-int/lit8 v9, v0, -0x1

    .line 194
    div-int/2addr v8, v9

    add-int/2addr v8, p2

    .line 195
    invoke-interface {p4, v8}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v8

    check-cast v8, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    invoke-static {p1, v8}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;->distance(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;)D

    move-result-wide v8

    add-double/2addr v2, v8

    add-int/lit8 p3, p3, 0x1

    goto :goto_1

    :cond_2
    :goto_2
    if-ge v1, v7, :cond_3

    mul-int p2, v1, v5

    add-int/lit8 p3, v0, -0x1

    .line 198
    div-int/2addr p2, p3

    .line 199
    invoke-interface {p4, p2}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p2

    check-cast p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;->distance(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;)D

    move-result-wide p2

    add-double/2addr v2, p2

    add-int/lit8 v1, v1, 0x1

    goto :goto_2

    :cond_3
    return-wide v2
.end method

.method public fit(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)Z
    .locals 10

    .line 93
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size()I

    move-result v0

    const/4 v1, 0x0

    const/4 v2, 0x3

    if-ge v0, v2, :cond_0

    return v1

    .line 96
    :cond_0
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v0

    div-int/lit8 v0, v0, 0xc

    invoke-static {v0, v2}, Ljava/lang/Math;->max(II)I

    move-result v0

    const/4 v2, 0x6

    invoke-static {v2, v0}, Ljava/lang/Math;->min(II)I

    move-result v0

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;->searchRadius:I

    .line 99
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;->looping:Z

    const/4 v2, 0x1

    if-eqz v0, :cond_1

    .line 101
    iget v0, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    move v3, v1

    goto :goto_0

    .line 105
    :cond_1
    iget v0, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    sub-int/2addr v0, v2

    move v3, v2

    :goto_0
    move v4, v1

    move v5, v2

    .line 109
    :goto_1
    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;->maxIterations:I

    if-ge v4, v6, :cond_4

    if-eqz v5, :cond_4

    move v5, v1

    move v6, v3

    :goto_2
    if-ge v6, v0, :cond_3

    .line 112
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size()I

    move-result v7

    invoke-static {v6, v2, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/CircularIndex;->minusPOffset(III)I

    move-result v7

    .line 113
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size()I

    move-result v8

    invoke-static {v6, v2, v8}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/CircularIndex;->plusPOffset(III)I

    move-result v8

    .line 115
    invoke-virtual {p2, v7}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->get(I)I

    move-result v7

    invoke-virtual {p2, v6}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->get(I)I

    move-result v9

    invoke-virtual {p2, v8}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->get(I)I

    move-result v8

    invoke-virtual {p0, p1, v7, v9, v8}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;->optimize(Ljava/util/List;III)I

    move-result v7

    .line 116
    invoke-virtual {p2, v6}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->get(I)I

    move-result v8

    if-eq v7, v8, :cond_2

    .line 117
    invoke-virtual {p2, v6, v7}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->set(II)V

    move v5, v2

    :cond_2
    add-int/lit8 v6, v6, 0x1

    goto :goto_2

    :cond_3
    add-int/lit8 v4, v4, 0x1

    goto :goto_1

    :cond_4
    return v2
.end method

.method protected optimize(Ljava/util/List;III)I
    .locals 8

    const/4 v5, 0x0

    move-object v0, p0

    move-object v1, p1

    move v2, p2

    move v3, p3

    move v4, p4

    .line 133
    invoke-virtual/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;->computeCost(Ljava/util/List;IIII)D

    move-result-wide p1

    .line 135
    iget p3, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;->searchRadius:I

    neg-int p3, p3

    const/4 p4, 0x0

    move v5, p3

    :goto_0
    iget p3, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;->searchRadius:I

    if-gt v5, p3, :cond_2

    if-nez v5, :cond_0

    if-eqz p4, :cond_1

    goto :goto_1

    .line 142
    :cond_0
    invoke-virtual/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/RefinePolyLineCorner;->computeCost(Ljava/util/List;IIII)D

    move-result-wide v6

    cmpg-double p3, v6, p1

    if-gez p3, :cond_1

    move p4, v5

    move-wide p1, v6

    :cond_1
    add-int/lit8 v5, v5, 0x1

    move-object v0, p0

    goto :goto_0

    .line 149
    :cond_2
    :goto_1
    invoke-interface {v1}, Ljava/util/List;->size()I

    move-result p1

    invoke-static {v3, p4, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/CircularIndex;->addOffset(III)I

    move-result p1

    return p1
.end method
