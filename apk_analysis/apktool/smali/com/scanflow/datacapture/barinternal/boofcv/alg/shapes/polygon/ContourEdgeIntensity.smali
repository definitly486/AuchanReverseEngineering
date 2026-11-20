.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;
.super Ljava/lang/Object;
.source "ContourEdgeIntensity.java"


# instance fields
.field private final contourSamples:I

.field private edgeInsideAverage:F

.field private edgeOutsideAverage:F

.field private imageHeight:I

.field private imageWidth:I

.field private final sampler:Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;

.field private final tangentSamples:I

.field private final tangentStep:F


# direct methods
.method public constructor <init>(IIDLjava/lang/Class;)V
    .locals 0

    .line 64
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 65
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;->contourSamples:I

    .line 66
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;->tangentSamples:I

    double-to-float p1, p3

    .line 67
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;->tangentStep:F

    .line 69
    sget-object p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;->EXTENDED:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;

    invoke-static {p5, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/interpolate/FactoryInterpolation;->bilinearPixelS(Ljava/lang/Class;Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;)Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;->sampler:Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;

    return-void
.end method


# virtual methods
.method public getEdgeInsideAverage()F
    .locals 1

    .line 56
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;->edgeInsideAverage:F

    return v0
.end method

.method public getEdgeOutsideAverage()F
    .locals 1

    .line 57
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;->edgeOutsideAverage:F

    return v0
.end method

.method public process(Ljava/util/List;Z)V
    .locals 19

    move-object/from16 v0, p0

    move-object/from16 v1, p1

    .line 79
    iget v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;->imageWidth:I

    if-eqz v2, :cond_7

    .line 84
    invoke-interface {v1}, Ljava/util/List;->size()I

    move-result v2

    iget v3, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;->contourSamples:I

    const/4 v4, 0x1

    if-gt v2, v3, :cond_0

    move v2, v4

    goto :goto_0

    .line 87
    :cond_0
    invoke-interface {v1}, Ljava/util/List;->size()I

    move-result v2

    iget v3, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;->contourSamples:I

    div-int/2addr v2, v3

    .line 90
    :goto_0
    div-int/lit8 v3, v2, 0x2

    const/4 v5, 0x5

    invoke-static {v3, v5}, Ljava/lang/Math;->min(II)I

    move-result v3

    invoke-static {v4, v3}, Ljava/lang/Math;->max(II)I

    move-result v3

    const/4 v5, 0x0

    .line 92
    iput v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;->edgeInsideAverage:F

    iput v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;->edgeOutsideAverage:F

    const/4 v7, 0x0

    const/4 v8, 0x0

    const/4 v9, 0x0

    .line 97
    :goto_1
    invoke-interface {v1}, Ljava/util/List;->size()I

    move-result v10

    if-ge v7, v10, :cond_5

    .line 98
    invoke-interface {v1, v7}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v10

    check-cast v10, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    add-int v11, v7, v3

    .line 99
    invoke-interface {v1}, Ljava/util/List;->size()I

    move-result v12

    rem-int/2addr v11, v12

    invoke-interface {v1, v11}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v11

    check-cast v11, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 102
    iget v12, v11, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    iget v13, v10, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    sub-int/2addr v12, v13

    int-to-float v12, v12

    iget v11, v11, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    iget v13, v10, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    sub-int/2addr v11, v13

    int-to-float v11, v11

    mul-float v13, v12, v12

    mul-float v14, v11, v11

    add-float/2addr v13, v14

    float-to-double v13, v13

    .line 103
    invoke-static {v13, v14}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide v13

    double-to-float v13, v13

    div-float/2addr v12, v13

    div-float/2addr v11, v13

    const/4 v13, 0x0

    .line 108
    :goto_2
    iget v14, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;->tangentSamples:I

    if-ge v13, v14, :cond_4

    add-int/lit8 v13, v13, 0x1

    int-to-float v14, v13

    .line 110
    iget v15, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;->tangentStep:F

    mul-float/2addr v14, v15

    .line 112
    iget v15, v10, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    int-to-float v15, v15

    mul-float v16, v14, v11

    add-float v15, v15, v16

    move/from16 v17, v4

    .line 113
    iget v4, v10, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    int-to-float v4, v4

    mul-float/2addr v14, v12

    sub-float/2addr v4, v14

    cmpl-float v18, v15, v5

    if-ltz v18, :cond_1

    cmpl-float v18, v4, v5

    if-ltz v18, :cond_1

    move/from16 v18, v5

    .line 114
    iget v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;->imageWidth:I

    add-int/lit8 v5, v5, -0x1

    int-to-float v5, v5

    cmpg-float v5, v15, v5

    if-gtz v5, :cond_2

    iget v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;->imageHeight:I

    add-int/lit8 v5, v5, -0x1

    int-to-float v5, v5

    cmpg-float v5, v4, v5

    if-gtz v5, :cond_2

    .line 115
    iget v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;->edgeOutsideAverage:F

    iget-object v6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;->sampler:Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;

    invoke-interface {v6, v15, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;->get(FF)F

    move-result v4

    add-float/2addr v5, v4

    iput v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;->edgeOutsideAverage:F

    add-int/lit8 v8, v8, 0x1

    goto :goto_3

    :cond_1
    move/from16 v18, v5

    .line 119
    :cond_2
    :goto_3
    iget v4, v10, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    int-to-float v4, v4

    sub-float v4, v4, v16

    .line 120
    iget v5, v10, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    int-to-float v5, v5

    add-float/2addr v5, v14

    cmpl-float v6, v4, v18

    if-ltz v6, :cond_3

    cmpl-float v6, v5, v18

    if-ltz v6, :cond_3

    .line 121
    iget v6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;->imageWidth:I

    add-int/lit8 v6, v6, -0x1

    int-to-float v6, v6

    cmpg-float v6, v4, v6

    if-gtz v6, :cond_3

    iget v6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;->imageHeight:I

    add-int/lit8 v6, v6, -0x1

    int-to-float v6, v6

    cmpg-float v6, v5, v6

    if-gtz v6, :cond_3

    .line 122
    iget v6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;->edgeInsideAverage:F

    iget-object v14, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;->sampler:Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;

    invoke-interface {v14, v4, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;->get(FF)F

    move-result v4

    add-float/2addr v6, v4

    iput v6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;->edgeInsideAverage:F

    add-int/lit8 v9, v9, 0x1

    :cond_3
    move/from16 v4, v17

    move/from16 v5, v18

    goto :goto_2

    :cond_4
    move/from16 v17, v4

    move/from16 v18, v5

    add-int/2addr v7, v2

    goto/16 :goto_1

    .line 128
    :cond_5
    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;->edgeOutsideAverage:F

    int-to-float v2, v8

    div-float/2addr v1, v2

    iput v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;->edgeOutsideAverage:F

    .line 129
    iget v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;->edgeInsideAverage:F

    int-to-float v3, v9

    div-float/2addr v2, v3

    iput v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;->edgeInsideAverage:F

    if-nez p2, :cond_6

    .line 133
    iput v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;->edgeOutsideAverage:F

    .line 134
    iput v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;->edgeInsideAverage:F

    :cond_6
    return-void

    .line 80
    :cond_7
    new-instance v1, Ljava/lang/RuntimeException;

    const-string v2, "You didn\'t call setImage()"

    invoke-direct {v1, v2}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw v1
.end method

.method public setImage(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)V
    .locals 1

    .line 73
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;->sampler:Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;

    invoke-interface {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixel;->setImage(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 74
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;->imageWidth:I

    .line 75
    iget p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;->imageHeight:I

    return-void
.end method
