.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;
.super Ljava/lang/Object;
.source "DetectPolygonBinaryGrayRefine.java"


# instance fields
.field adjustForBias:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/AdjustPolygonForThresholdBias;

.field detector:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;

.field private final edgeIntensity:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;

.field milliAdjustBias:Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;

.field minimumRefineEdgeIntensity:D

.field private final refineContour:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToContour;

.field private final refineGray:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGray;

.field private final work:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToContour;Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGray;DZ)V
    .locals 7

    .line 84
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 60
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->work:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    .line 69
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;

    const-wide v1, 0x3fe999999999999aL    # 0.8

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;-><init>(D)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->milliAdjustBias:Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;

    .line 85
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->detector:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;

    .line 86
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->refineContour:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToContour;

    .line 87
    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->refineGray:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGray;

    .line 88
    iput-wide p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->minimumRefineEdgeIntensity:D

    if-eqz p6, :cond_0

    .line 90
    new-instance p2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/AdjustPolygonForThresholdBias;

    invoke-direct {p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/AdjustPolygonForThresholdBias;-><init>()V

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->adjustForBias:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/AdjustPolygonForThresholdBias;

    .line 93
    :cond_0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;

    const/16 v5, 0xf

    .line 94
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->getInputType()Ljava/lang/Class;

    move-result-object v6

    const-wide/high16 v1, 0x3ff0000000000000L    # 1.0

    const-wide/high16 v3, 0x3ff8000000000000L    # 1.5

    invoke-direct/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;-><init>(DDILjava/lang/Class;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->edgeIntensity:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;

    return-void
.end method


# virtual methods
.method public getDetector()Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;
    .locals 1

    .line 303
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->detector:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;

    return-object v0
.end method

.method public getInputType()Ljava/lang/Class;
    .locals 1

    .line 287
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->detector:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->getInputType()Ljava/lang/Class;

    move-result-object v0

    return-object v0
.end method

.method public getMilliAdjustBias()D
    .locals 2

    .line 315
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->milliAdjustBias:Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;->getAverage()D

    move-result-wide v0

    return-wide v0
.end method

.method public getMinimumSides()I
    .locals 1

    .line 291
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->detector:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->getMinimumSides()I

    move-result v0

    return v0
.end method

.method public getPolygonInfo()Ljava/util/List;
    .locals 1

    .line 283
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->detector:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->getFoundInfo()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    move-result-object v0

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->toList()Ljava/util/List;

    move-result-object v0

    return-object v0
.end method

.method public process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
    .locals 6

    .line 151
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->detector:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;

    invoke-virtual {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    .line 152
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->refineGray:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGray;

    if-eqz p2, :cond_0

    .line 153
    invoke-interface {p2, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGray;->setImage(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)V

    .line 154
    :cond_0
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->edgeIntensity:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;

    invoke-virtual {p2, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->setImage(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)V

    .line 156
    invoke-static {}, Ljava/lang/System;->nanoTime()J

    move-result-wide p1

    .line 157
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->detector:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->getFoundInfo()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    move-result-object v0

    .line 159
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->adjustForBias:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/AdjustPolygonForThresholdBias;

    if-eqz v1, :cond_2

    .line 160
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->getMinimumSides()I

    move-result v1

    .line 161
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size()I

    move-result v2

    add-int/lit8 v2, v2, -0x1

    :goto_0
    if-ltz v2, :cond_2

    .line 162
    invoke-virtual {v0, v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->get(I)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$Info;

    iget-object v3, v3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$Info;->polygon:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    .line 163
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->adjustForBias:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/AdjustPolygonForThresholdBias;

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->detector:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;

    invoke-virtual {v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->isOutputClockwiseUpY()Z

    move-result v5

    invoke-virtual {v4, v3, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/AdjustPolygonForThresholdBias;->process(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;Z)V

    .line 167
    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->size()I

    move-result v3

    if-ge v3, v1, :cond_1

    .line 168
    invoke-virtual {v0, v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->remove(I)Ljava/lang/Object;

    :cond_1
    add-int/lit8 v2, v2, -0x1

    goto :goto_0

    .line 171
    :cond_2
    invoke-static {}, Ljava/lang/System;->nanoTime()J

    move-result-wide v0

    sub-long/2addr v0, p1

    long-to-double p1, v0

    const-wide v0, 0x3eb0c6f7a0b5ed8dL    # 1.0E-6

    mul-double/2addr p1, v0

    .line 175
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->milliAdjustBias:Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;

    invoke-virtual {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;->update(D)D

    return-void
.end method

.method public refine(Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$Info;)Z
    .locals 10

    .line 188
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->edgeIntensity:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;

    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$Info;->polygon:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->detector:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;

    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->isOutputClockwiseUpY()Z

    move-result v2

    const/4 v3, 0x1

    xor-int/2addr v2, v3

    invoke-virtual {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->computeEdge(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;Z)Z

    move-result v0

    const/4 v1, 0x0

    if-eqz v0, :cond_2

    .line 189
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->edgeIntensity:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->getAverageOutside()D

    move-result-wide v4

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->edgeIntensity:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->getAverageInside()D

    move-result-wide v6

    sub-double/2addr v4, v6

    .line 196
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->refineContour:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToContour;

    if-eqz v0, :cond_1

    .line 197
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->detector:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->getContour(Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$Info;)Ljava/util/List;

    move-result-object v0

    .line 198
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->refineContour:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToContour;

    iget-object v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$Info;->splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->work:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v2, v0, v6, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToContour;->process(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;)V

    .line 200
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->adjustForBias:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/AdjustPolygonForThresholdBias;

    if-eqz v0, :cond_0

    .line 201
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->work:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->detector:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;

    invoke-virtual {v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->isOutputClockwiseUpY()Z

    move-result v6

    invoke-virtual {v0, v2, v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/AdjustPolygonForThresholdBias;->process(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;Z)V

    .line 203
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->edgeIntensity:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->work:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->detector:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;

    invoke-virtual {v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->isOutputClockwiseUpY()Z

    move-result v6

    xor-int/2addr v6, v3

    invoke-virtual {v0, v2, v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->computeEdge(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;Z)Z

    move-result v0

    if-eqz v0, :cond_1

    .line 204
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->edgeIntensity:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->getAverageOutside()D

    move-result-wide v6

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->edgeIntensity:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->getAverageInside()D

    move-result-wide v8

    sub-double/2addr v6, v8

    cmpl-double v0, v6, v4

    if-lez v0, :cond_1

    .line 206
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->edgeIntensity:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->getAverageInside()D

    move-result-wide v0

    iput-wide v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$Info;->edgeInside:D

    .line 207
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->edgeIntensity:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->getAverageOutside()D

    move-result-wide v0

    iput-wide v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$Info;->edgeOutside:D

    .line 208
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$Info;->polygon:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->work:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    move v1, v3

    move-wide v4, v6

    .line 219
    :cond_1
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->refineGray:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGray;

    if-eqz v0, :cond_2

    .line 220
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->work:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->vertexes:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$Info;->polygon:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->size()I

    move-result v2

    invoke-virtual {v0, v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->resize(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 221
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->refineGray:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGray;

    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$Info;->polygon:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->work:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-interface {v0, v2, v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToGray;->refine(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;)Z

    move-result v0

    if-eqz v0, :cond_2

    .line 222
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->edgeIntensity:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->work:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->detector:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;

    invoke-virtual {v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->isOutputClockwiseUpY()Z

    move-result v6

    xor-int/2addr v6, v3

    invoke-virtual {v0, v2, v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->computeEdge(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;Z)Z

    move-result v0

    if-eqz v0, :cond_2

    .line 223
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->edgeIntensity:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->getAverageOutside()D

    move-result-wide v6

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->edgeIntensity:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->getAverageInside()D

    move-result-wide v8

    sub-double/2addr v6, v8

    const-wide/high16 v8, 0x3ff8000000000000L    # 1.5

    mul-double/2addr v6, v8

    cmpl-double v0, v6, v4

    if-lez v0, :cond_2

    .line 228
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->edgeIntensity:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->getAverageInside()D

    move-result-wide v0

    iput-wide v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$Info;->edgeInside:D

    .line 229
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->edgeIntensity:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/EdgeIntensityPolygon;->getAverageOutside()D

    move-result-wide v0

    iput-wide v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$Info;->edgeOutside:D

    .line 230
    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$Info;->polygon:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->work:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {p1, v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    return v3

    :cond_2
    return v1
.end method
