.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;
.super Ljava/lang/Object;
.source "MinimizeEnergyPrune.java"


# instance fields
.field bestCorners:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

.field contour:Ljava/util/List;

.field energySegment:[D

.field line:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;

.field point:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

.field splitPenalty:D

.field workCorners1:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

.field workCorners2:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;


# direct methods
.method public constructor <init>(D)V
    .locals 1

    .line 59
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 49
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->line:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;

    .line 50
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->point:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    const/4 v0, 0x1

    .line 53
    new-array v0, v0, [D

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->energySegment:[D

    .line 55
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->bestCorners:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    .line 56
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->workCorners1:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    .line 57
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->workCorners2:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    .line 60
    iput-wide p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->splitPenalty:D

    return-void
.end method


# virtual methods
.method protected circularDistance(II)I
    .locals 1

    .line 248
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->contour:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    invoke-static {p1, p2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/CircularIndex;->distanceP(III)I

    move-result p1

    return p1
.end method

.method protected computeSegmentEnergy(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;II)D
    .locals 11

    .line 213
    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->get(I)I

    move-result p2

    .line 214
    invoke-virtual {p1, p3}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->get(I)I

    move-result p1

    if-ne p2, p1, :cond_0

    const-wide p1, 0x40f86a0000000000L    # 100000.0

    return-wide p1

    .line 220
    :cond_0
    iget-object p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->contour:Ljava/util/List;

    invoke-interface {p3, p2}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p3

    check-cast p3, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 221
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->contour:Ljava/util/List;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 223
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->line:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;

    iget-object v2, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;->p:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget v3, p3, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    int-to-double v4, v3

    iput-wide v4, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    .line 224
    iget v4, p3, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    int-to-double v5, v4

    iput-wide v5, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    .line 225
    iget-object v1, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;->slope:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;

    iget v2, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    sub-int/2addr v2, v3

    int-to-double v2, v2

    iget v5, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    sub-int/2addr v5, v4

    int-to-double v4, v5

    invoke-virtual {v1, v2, v3, v4, v5}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->setTo(DD)Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;

    .line 228
    invoke-virtual {p0, p2, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->circularDistance(II)I

    move-result p1

    const/4 v1, 0x1

    const-wide/16 v2, 0x0

    move v4, v1

    :goto_0
    if-ge v4, p1, :cond_1

    add-int/lit8 v5, p2, 0x1

    add-int/2addr v5, v4

    .line 231
    invoke-virtual {p0, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->getContour(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    move-result-object v5

    .line 232
    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->point:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget v7, v5, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    int-to-double v7, v7

    iget v5, v5, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    int-to-double v9, v5

    invoke-virtual {v6, v7, v8, v9, v10}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->setTo(DD)Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;

    .line 234
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->line:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->point:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-static {v5, v6}, Lcom/scanflow/datacapture/barinternal/georegression/metric/Distance2D_F64;->distanceSq(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)D

    move-result-wide v5

    add-double/2addr v2, v5

    add-int/lit8 v4, v4, 0x1

    goto :goto_0

    .line 237
    :cond_1
    iget-wide p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->splitPenalty:D

    add-double/2addr v2, p1

    invoke-virtual {p3, v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->distance2(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;)I

    move-result p1

    int-to-double p1, p1

    div-double/2addr v2, p1

    return-wide v2
.end method

.method computeSegmentEnergy(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)V
    .locals 6

    .line 171
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->energySegment:[D

    array-length v0, v0

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size()I

    move-result v1

    if-ge v0, v1, :cond_0

    .line 172
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size()I

    move-result v0

    new-array v0, v0, [D

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->energySegment:[D

    .line 175
    :cond_0
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size()I

    move-result v0

    add-int/lit8 v0, v0, -0x1

    const/4 v1, 0x0

    :goto_0
    move v5, v1

    move v1, v0

    move v0, v5

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size()I

    move-result v2

    if-ge v0, v2, :cond_1

    .line 176
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->energySegment:[D

    invoke-virtual {p0, p1, v1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->computeSegmentEnergy(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;II)D

    move-result-wide v3

    aput-wide v3, v2, v1

    add-int/lit8 v1, v0, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method protected getContour(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;
    .locals 2

    .line 241
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->contour:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v1

    rem-int/2addr p1, v1

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    return-object p1
.end method

.method public prune(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)Z
    .locals 18

    move-object/from16 v0, p0

    move-object/from16 v1, p1

    move-object/from16 v2, p3

    .line 73
    iput-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->contour:Ljava/util/List;

    move-object/from16 v3, p2

    .line 74
    invoke-virtual {v2, v3}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->setTo(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    .line 75
    invoke-virtual {v0, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->removeDuplicates(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)V

    .line 78
    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size()I

    move-result v3

    const/4 v4, 0x0

    const/4 v5, 0x3

    if-gt v3, v5, :cond_0

    return v4

    .line 81
    :cond_0
    invoke-virtual {v0, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->computeSegmentEnergy(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)V

    const-wide/16 v6, 0x0

    move v3, v4

    move-wide v8, v6

    .line 84
    :goto_0
    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size()I

    move-result v10

    if-ge v3, v10, :cond_1

    .line 85
    iget-object v10, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->energySegment:[D

    aget-wide v11, v10, v3

    add-double/2addr v8, v11

    add-int/lit8 v3, v3, 0x1

    goto :goto_0

    .line 88
    :cond_1
    new-instance v3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;

    invoke-direct {v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;-><init>()V

    .line 89
    invoke-virtual {v3, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->setContour(Ljava/util/List;)V

    move v1, v4

    .line 92
    :goto_1
    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size()I

    move-result v10

    if-le v10, v5, :cond_7

    .line 95
    iget-object v10, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->bestCorners:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {v10}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    move v10, v4

    move v11, v10

    .line 97
    :goto_2
    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size()I

    move-result v12

    const/4 v13, 0x1

    if-ge v10, v12, :cond_6

    .line 99
    iget-object v12, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->workCorners1:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {v12}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    move v12, v4

    .line 100
    :goto_3
    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size()I

    move-result v14

    if-ge v12, v14, :cond_3

    if-eq v10, v12, :cond_2

    .line 102
    iget-object v14, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->workCorners1:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {v2, v12}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->get(I)I

    move-result v15

    invoke-virtual {v14, v15}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->add(I)V

    :cond_2
    add-int/lit8 v12, v12, 0x1

    goto :goto_3

    .line 107
    :cond_3
    iget-object v12, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->workCorners1:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {v0, v12}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->removeDuplicates(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)V

    .line 108
    iget-object v12, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->workCorners1:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {v12}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size()I

    move-result v12

    if-le v12, v5, :cond_5

    .line 112
    iget-object v12, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->workCorners1:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {v12}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size()I

    move-result v12

    const/4 v14, -0x2

    invoke-static {v10, v14, v12}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/CircularIndex;->addOffset(III)I

    move-result v12

    .line 113
    iget-object v14, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->workCorners1:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {v14}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size()I

    move-result v14

    invoke-static {v10, v13, v14}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/CircularIndex;->addOffset(III)I

    move-result v14

    .line 116
    iget-object v15, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->workCorners1:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    iget-object v4, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->workCorners2:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {v3, v12, v14, v15, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->fitAnchored(IILcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)Z

    move-result v4

    if-eqz v4, :cond_5

    .line 121
    iget-object v4, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->workCorners2:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size()I

    move-result v4

    sub-int/2addr v4, v13

    move v12, v4

    move-wide v14, v6

    const/4 v4, 0x0

    :goto_4
    iget-object v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->workCorners2:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {v5}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size()I

    move-result v5

    if-ge v4, v5, :cond_4

    .line 122
    iget-object v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->workCorners2:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {v0, v5, v12, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->computeSegmentEnergy(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;II)D

    move-result-wide v16

    add-double v14, v14, v16

    add-int/lit8 v5, v4, 0x1

    move v12, v4

    move v4, v5

    goto :goto_4

    :cond_4
    cmpg-double v4, v14, v8

    if-gez v4, :cond_5

    .line 128
    iget-object v4, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->bestCorners:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    .line 129
    iget-object v4, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->bestCorners:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    iget-object v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->workCorners2:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {v4, v5}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->addAll(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)V

    move v11, v13

    move-wide v8, v14

    :cond_5
    add-int/lit8 v10, v10, 0x1

    const/4 v4, 0x0

    const/4 v5, 0x3

    goto/16 :goto_2

    :cond_6
    if-eqz v11, :cond_7

    .line 138
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->bestCorners:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {v2, v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->setTo(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    move v1, v13

    const/4 v4, 0x0

    const/4 v5, 0x3

    goto/16 :goto_1

    :cond_7
    return v1
.end method

.method removeDuplicates(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)V
    .locals 6

    const/4 v0, 0x0

    .line 152
    :goto_0
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size()I

    move-result v1

    if-ge v0, v1, :cond_2

    .line 153
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->contour:Ljava/util/List;

    invoke-virtual {p1, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->get(I)I

    move-result v2

    invoke-interface {v1, v2}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 156
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size()I

    move-result v2

    add-int/lit8 v2, v2, -0x1

    :goto_1
    if-le v2, v0, :cond_1

    .line 157
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/MinimizeEnergyPrune;->contour:Ljava/util/List;

    invoke-virtual {p1, v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->get(I)I

    move-result v4

    invoke-interface {v3, v4}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 159
    iget v4, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    iget v5, v3, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    if-ne v4, v5, :cond_0

    iget v4, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    iget v3, v3, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    if-ne v4, v3, :cond_0

    .line 161
    invoke-virtual {p1, v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->remove(I)V

    :cond_0
    add-int/lit8 v2, v2, -0x1

    goto :goto_1

    :cond_1
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_2
    return-void
.end method
