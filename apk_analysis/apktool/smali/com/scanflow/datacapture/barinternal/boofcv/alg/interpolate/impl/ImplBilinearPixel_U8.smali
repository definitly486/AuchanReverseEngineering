.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/impl/ImplBilinearPixel_U8;
.super Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/BilinearPixelS;
.source "ImplBilinearPixel_U8.java"


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
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/impl/ImplBilinearPixel_U8;->get_fast(FF)F

    move-result p1

    return p1

    .line 87
    :cond_1
    :goto_0
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/impl/ImplBilinearPixel_U8;->get_border(FF)F

    move-result p1

    return p1
.end method

.method public get_border(FF)F
    .locals 8

    float-to-double v0, p1

    .line 67
    invoke-static {v0, v1}, Ljava/lang/Math;->floor(D)D

    move-result-wide v0

    double-to-float v0, v0

    float-to-double v1, p2

    .line 68
    invoke-static {v1, v2}, Ljava/lang/Math;->floor(D)D

    move-result-wide v1

    double-to-float v1, v1

    float-to-int v2, v0

    float-to-int v3, v1

    sub-float/2addr p1, v0

    sub-float/2addr p2, v1

    .line 74
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/BilinearPixelS;->border:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder;

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder_S32;

    const/high16 v1, 0x3f800000    # 1.0f

    sub-float v4, v1, p1

    sub-float/2addr v1, p2

    mul-float v5, v4, v1

    .line 76
    invoke-virtual {v0, v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder_S32;->get(II)I

    move-result v6

    int-to-float v6, v6

    mul-float/2addr v5, v6

    mul-float/2addr v1, p1

    add-int/lit8 v6, v2, 0x1

    .line 77
    invoke-virtual {v0, v6, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder_S32;->get(II)I

    move-result v7

    int-to-float v7, v7

    mul-float/2addr v1, v7

    add-float/2addr v5, v1

    mul-float/2addr p1, p2

    add-int/lit8 v3, v3, 0x1

    .line 78
    invoke-virtual {v0, v6, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder_S32;->get(II)I

    move-result v1

    int-to-float v1, v1

    mul-float/2addr p1, v1

    add-float/2addr v5, p1

    mul-float/2addr v4, p2

    .line 79
    invoke-virtual {v0, v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder_S32;->get(II)I

    move-result p1

    int-to-float p1, p1

    mul-float/2addr v4, p1

    add-float/2addr v5, v4

    return v5
.end method

.method public get_fast(FF)F
    .locals 8

    float-to-int v0, p1

    float-to-int v1, p2

    int-to-float v2, v0

    sub-float/2addr p1, v2

    int-to-float v2, v1

    sub-float/2addr p2, v2

    .line 54
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/BilinearPixelS;->orig:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-object v3, v2

    check-cast v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    iget v3, v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/BilinearPixelS;->stride:I

    mul-int/2addr v1, v4

    add-int/2addr v3, v1

    add-int/2addr v3, v0

    .line 56
    check-cast v2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    iget-object v0, v2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    const/high16 v1, 0x3f800000    # 1.0f

    sub-float v2, v1, p1

    sub-float/2addr v1, p2

    mul-float v5, v2, v1

    .line 58
    aget-byte v6, v0, v3

    and-int/lit16 v6, v6, 0xff

    int-to-float v6, v6

    mul-float/2addr v5, v6

    mul-float/2addr v1, p1

    add-int/lit8 v6, v3, 0x1

    .line 59
    aget-byte v7, v0, v6

    and-int/lit16 v7, v7, 0xff

    int-to-float v7, v7

    mul-float/2addr v1, v7

    add-float/2addr v5, v1

    mul-float/2addr p1, p2

    add-int/2addr v6, v4

    .line 60
    aget-byte v1, v0, v6

    and-int/lit16 v1, v1, 0xff

    int-to-float v1, v1

    mul-float/2addr p1, v1

    add-float/2addr v5, p1

    mul-float/2addr v2, p2

    add-int/2addr v3, v4

    .line 61
    aget-byte p1, v0, v3

    and-int/lit16 p1, p1, 0xff

    int-to-float p1, p1

    mul-float/2addr v2, p1

    add-float/2addr v5, v2

    return v5
.end method
