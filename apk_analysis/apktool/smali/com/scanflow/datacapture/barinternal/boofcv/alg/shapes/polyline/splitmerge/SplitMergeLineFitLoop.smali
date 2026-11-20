.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFitLoop;
.super Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;
.source "SplitMergeLineFitLoop.java"


# instance fields
.field protected N:I


# direct methods
.method public constructor <init>(DLcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;I)V
    .locals 0

    .line 49
    invoke-direct {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;-><init>(DLcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;I)V

    return-void
.end method

.method private checkSplit(ZII)Z
    .locals 1

    .line 207
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->data:[I

    aget p2, v0, p2

    .line 208
    aget p3, v0, p3

    .line 209
    invoke-virtual {p0, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFitLoop;->circularDistance(II)I

    move-result p3

    .line 211
    invoke-virtual {p0, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFitLoop;->selectSplitOffset(II)I

    move-result p3

    if-ltz p3, :cond_0

    .line 214
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->work:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->add(I)V

    .line 215
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->work:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    add-int/2addr p2, p3

    iget p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFitLoop;->N:I

    rem-int/2addr p2, p3

    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->add(I)V

    const/4 p1, 0x1

    return p1

    .line 217
    :cond_0
    iget-object p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->work:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {p3, p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->add(I)V

    return p1
.end method


# virtual methods
.method public _process(Ljava/util/List;)Z
    .locals 5

    .line 54
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v0

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFitLoop;->N:I

    const/4 v1, 0x0

    const/4 v2, 0x1

    if-gt v0, v2, :cond_0

    return v1

    .line 63
    :cond_0
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFitLoop;->selectFarthest(Ljava/util/List;)I

    move-result p1

    .line 64
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFitLoop;->N:I

    div-int/lit8 v3, v0, 0x2

    add-int/2addr v3, p1

    rem-int/2addr v3, v0

    .line 67
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->add(I)V

    .line 68
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFitLoop;->N:I

    const/4 v4, 0x2

    div-int/2addr v0, v4

    invoke-virtual {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFitLoop;->splitPixels(II)V

    .line 69
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {p1, v3}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->add(I)V

    .line 70
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFitLoop;->N:I

    div-int/lit8 v0, p1, 0x2

    sub-int/2addr p1, v0

    invoke-virtual {p0, v3, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFitLoop;->splitPixels(II)V

    .line 73
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    iget p1, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    if-gt p1, v4, :cond_1

    return v1

    :cond_1
    move p1, v1

    .line 77
    :goto_0
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->maxIterations:I

    if-ge p1, v0, :cond_6

    .line 78
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFitLoop;->mergeSegments()Z

    move-result v0

    .line 80
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size()I

    move-result v3

    if-gtz v3, :cond_2

    return v1

    :cond_2
    if-nez v0, :cond_3

    .line 83
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFitLoop;->splitSegments()Z

    move-result v0

    if-nez v0, :cond_3

    goto :goto_2

    .line 86
    :cond_3
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size()I

    move-result v0

    if-le v0, v4, :cond_5

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size()I

    move-result v0

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->abortSplits:I

    if-lt v0, v3, :cond_4

    goto :goto_1

    :cond_4
    add-int/lit8 p1, p1, 0x1

    goto :goto_0

    :cond_5
    :goto_1
    return v1

    :cond_6
    :goto_2
    return v2
.end method

.method protected circularDistance(II)I
    .locals 1

    if-lt p2, p1, :cond_0

    sub-int/2addr p2, p1

    return p2

    .line 265
    :cond_0
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFitLoop;->N:I

    sub-int/2addr v0, p1

    add-int/2addr v0, p2

    return v0
.end method

.method protected mergeSegments()Z
    .locals 6

    .line 157
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size()I

    move-result v0

    const/4 v1, 0x3

    const/4 v2, 0x0

    if-gt v0, v1, :cond_0

    return v2

    .line 161
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->work:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    move v0, v2

    .line 163
    :goto_0
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    iget v3, v1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    if-ge v2, v3, :cond_2

    .line 164
    iget-object v1, v1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->data:[I

    aget v4, v1, v2

    add-int/lit8 v5, v2, 0x2

    .line 165
    rem-int/2addr v5, v3

    aget v1, v1, v5

    .line 167
    invoke-virtual {p0, v4, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFitLoop;->circularDistance(II)I

    move-result v1

    invoke-virtual {p0, v4, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFitLoop;->selectSplitOffset(II)I

    move-result v1

    if-gez v1, :cond_1

    const/4 v0, 0x1

    goto :goto_1

    .line 171
    :cond_1
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->work:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    iget-object v4, v3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->data:[I

    add-int/lit8 v5, v2, 0x1

    iget v3, v3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    rem-int/2addr v5, v3

    aget v3, v4, v5

    invoke-virtual {v1, v3}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->add(I)V

    :goto_1
    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    .line 176
    :cond_2
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->work:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    .line 177
    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->work:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    .line 178
    iput-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    return v0
.end method

.method protected selectFarthest(Ljava/util/List;)I
    .locals 9

    .line 126
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v0

    .line 127
    div-int/lit8 v1, v0, 0x2

    const/4 v2, -0x1

    const/4 v3, 0x0

    move v4, v3

    :goto_0
    if-ge v3, v1, :cond_1

    add-int v5, v3, v1

    .line 131
    rem-int/2addr v5, v0

    .line 133
    invoke-interface {p1, v3}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 134
    invoke-interface {p1, v5}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v5

    check-cast v5, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 136
    iget v7, v6, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    iget v6, v6, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    iget v8, v5, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    iget v5, v5, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    invoke-static {v7, v6, v8, v5}, Lcom/scanflow/datacapture/barinternal/georegression/geometry/UtilPoint2D_I32;->distanceSq(IIII)I

    move-result v5

    if-ge v4, v5, :cond_0

    move v2, v3

    move v4, v5

    :cond_0
    add-int/lit8 v3, v3, 0x1

    goto :goto_0

    :cond_1
    return v2
.end method

.method protected selectSplitOffset(II)I
    .locals 10

    .line 229
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->contour:Ljava/util/List;

    invoke-static {v0}, Ljava/util/Objects;->requireNonNull(Ljava/lang/Object;)Ljava/lang/Object;

    add-int v0, p1, p2

    .line 232
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFitLoop;->N:I

    rem-int/2addr v0, v1

    .line 233
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->contour:Ljava/util/List;

    invoke-interface {v1, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 234
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->contour:Ljava/util/List;

    invoke-interface {v2, v0}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 236
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->line:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;

    iget-object v3, v3, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;->p:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget v4, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    int-to-double v4, v4

    iget v6, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    int-to-double v6, v6

    invoke-virtual {v3, v4, v5, v6, v7}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->setTo(DD)Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;

    .line 237
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->line:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;

    iget-object v3, v3, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;->slope:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;

    iget v4, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    iget v5, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    sub-int/2addr v4, v5

    int-to-double v4, v4

    iget v2, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    iget v1, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    sub-int/2addr v2, v1

    int-to-double v1, v2

    invoke-virtual {v3, v4, v5, v1, v2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->setTo(DD)Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;

    .line 239
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->contour:Ljava/util/List;

    invoke-interface {v1, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->contour:Ljava/util/List;

    invoke-interface {v2, v0}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    invoke-virtual {p0, v1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->splitThresholdSq(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;)D

    move-result-wide v0

    const/4 v2, 0x1

    .line 242
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->minimumSideLengthPixel:I

    invoke-static {v2, v3}, Ljava/lang/Math;->max(II)I

    move-result v2

    sub-int/2addr p2, v2

    const/4 v3, -0x1

    :goto_0
    if-gt v2, p2, :cond_1

    .line 245
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->contour:Ljava/util/List;

    add-int v5, p1, v2

    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFitLoop;->N:I

    rem-int/2addr v5, v6

    invoke-interface {v4, v5}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 246
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->point2D:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget v6, v4, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    int-to-double v6, v6

    iget v4, v4, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    int-to-double v8, v4

    invoke-virtual {v5, v6, v7, v8, v9}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->setTo(DD)Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;

    .line 248
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->line:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->point2D:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-static {v4, v5}, Lcom/scanflow/datacapture/barinternal/georegression/metric/Distance2D_F64;->distanceSq(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)D

    move-result-wide v4

    cmpl-double v6, v4, v0

    if-ltz v6, :cond_0

    move v3, v2

    move-wide v0, v4

    :cond_0
    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    :cond_1
    return v3
.end method

.method protected splitPixels(II)V
    .locals 2

    .line 99
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->minimumSideLengthPixel:I

    if-ge p2, v0, :cond_0

    goto :goto_0

    :cond_0
    add-int v0, p1, p2

    .line 103
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFitLoop;->N:I

    rem-int/2addr v0, v1

    .line 105
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFitLoop;->selectSplitOffset(II)I

    move-result p2

    if-ltz p2, :cond_1

    .line 109
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFitLoop;->splitPixels(II)V

    add-int/2addr p1, p2

    .line 110
    iget p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFitLoop;->N:I

    rem-int/2addr p1, p2

    .line 111
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {p2, p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->add(I)V

    .line 112
    invoke-virtual {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFitLoop;->circularDistance(II)I

    move-result p2

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFitLoop;->splitPixels(II)V

    :cond_1
    :goto_0
    return-void
.end method

.method protected splitSegments()Z
    .locals 5

    .line 191
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->work:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    const/4 v0, 0x0

    move v1, v0

    move v2, v1

    .line 192
    :goto_0
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    iget v3, v3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    add-int/lit8 v4, v3, -0x1

    if-ge v1, v4, :cond_0

    add-int/lit8 v3, v1, 0x1

    .line 193
    invoke-direct {p0, v2, v1, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFitLoop;->checkSplit(ZII)Z

    move-result v1

    or-int/2addr v2, v1

    move v1, v3

    goto :goto_0

    :cond_0
    add-int/lit8 v3, v3, -0x1

    .line 196
    invoke-direct {p0, v2, v3, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFitLoop;->checkSplit(ZII)Z

    move-result v0

    or-int/2addr v0, v2

    .line 199
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->work:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    .line 200
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    iput-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->work:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    .line 201
    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    return v0
.end method
