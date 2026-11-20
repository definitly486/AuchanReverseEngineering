.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/impl/ImplBilinearPixel_F64;
.super Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/BilinearPixelS;
.source "ImplBilinearPixel_F64.java"


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 41
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/BilinearPixelS;-><init>()V

    return-void
.end method


# virtual methods
.method public get(FF)F
    .locals 2

    const/4 v0, 0x0

    cmpg-float v1, p1, v0

    if-ltz v1, :cond_1

    cmpg-float v0, p2, v0

    if-ltz v0, :cond_1

    .line 86
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/BilinearPixelS;->width:I

    add-int/lit8 v0, v0, -0x2

    int-to-float v0, v0

    cmpl-float v0, p1, v0

    if-gtz v0, :cond_1

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/BilinearPixelS;->height:I

    add-int/lit8 v0, v0, -0x2

    int-to-float v0, v0

    cmpl-float v0, p2, v0

    if-lez v0, :cond_0

    goto :goto_0

    .line 89
    :cond_0
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/impl/ImplBilinearPixel_F64;->get_fast(FF)F

    move-result p1

    return p1

    .line 87
    :cond_1
    :goto_0
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/impl/ImplBilinearPixel_F64;->get_border(FF)F

    move-result p1

    return p1
.end method

.method public get_border(FF)F
    .locals 17

    move/from16 v0, p1

    float-to-double v0, v0

    .line 67
    invoke-static {v0, v1}, Ljava/lang/Math;->floor(D)D

    move-result-wide v2

    move/from16 v4, p2

    float-to-double v4, v4

    .line 68
    invoke-static {v4, v5}, Ljava/lang/Math;->floor(D)D

    move-result-wide v6

    double-to-int v8, v2

    double-to-int v9, v6

    sub-double/2addr v0, v2

    sub-double/2addr v4, v6

    move-object/from16 v2, p0

    .line 74
    iget-object v3, v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/BilinearPixelS;->border:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder;

    check-cast v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder_F64;

    const-wide/high16 v6, 0x3ff0000000000000L    # 1.0

    sub-double v10, v6, v0

    sub-double/2addr v6, v4

    mul-double v12, v10, v6

    .line 76
    invoke-virtual {v3, v8, v9}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder_F64;->get(II)D

    move-result-wide v14

    mul-double/2addr v12, v14

    mul-double/2addr v6, v0

    add-int/lit8 v14, v8, 0x1

    .line 77
    invoke-virtual {v3, v14, v9}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder_F64;->get(II)D

    move-result-wide v15

    mul-double/2addr v6, v15

    add-double/2addr v12, v6

    mul-double/2addr v0, v4

    add-int/lit8 v9, v9, 0x1

    .line 78
    invoke-virtual {v3, v14, v9}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder_F64;->get(II)D

    move-result-wide v6

    mul-double/2addr v0, v6

    add-double/2addr v12, v0

    mul-double/2addr v10, v4

    .line 79
    invoke-virtual {v3, v8, v9}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder_F64;->get(II)D

    move-result-wide v0

    mul-double/2addr v10, v0

    add-double/2addr v12, v10

    double-to-float v0, v12

    return v0
.end method

.method public get_fast(FF)F
    .locals 18

    move-object/from16 v0, p0

    move/from16 v1, p1

    move/from16 v2, p2

    float-to-int v3, v1

    float-to-int v4, v2

    int-to-float v5, v3

    sub-float/2addr v1, v5

    float-to-double v5, v1

    int-to-float v1, v4

    sub-float v1, v2, v1

    float-to-double v1, v1

    .line 54
    iget-object v7, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/BilinearPixelS;->orig:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-object v8, v7

    check-cast v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    iget v8, v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v9, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/BilinearPixelS;->stride:I

    mul-int/2addr v4, v9

    add-int/2addr v8, v4

    add-int/2addr v8, v3

    .line 56
    check-cast v7, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    iget-object v3, v7, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;->data:[D

    const-wide/high16 v10, 0x3ff0000000000000L    # 1.0

    sub-double v12, v10, v5

    sub-double/2addr v10, v1

    mul-double v14, v12, v10

    .line 58
    aget-wide v16, v3, v8

    mul-double v14, v14, v16

    mul-double/2addr v10, v5

    add-int/lit8 v4, v8, 0x1

    .line 59
    aget-wide v16, v3, v4

    mul-double v10, v10, v16

    add-double/2addr v14, v10

    mul-double/2addr v5, v1

    add-int/2addr v4, v9

    .line 60
    aget-wide v10, v3, v4

    mul-double/2addr v5, v10

    add-double/2addr v14, v5

    mul-double/2addr v12, v1

    add-int/2addr v8, v9

    .line 61
    aget-wide v1, v3, v8

    mul-double/2addr v12, v1

    add-double/2addr v14, v12

    double-to-float v1, v14

    return v1
.end method
