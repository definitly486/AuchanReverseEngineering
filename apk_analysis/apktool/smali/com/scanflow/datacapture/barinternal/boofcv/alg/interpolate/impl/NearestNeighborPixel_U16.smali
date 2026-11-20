.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/impl/NearestNeighborPixel_U16;
.super Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/NearestNeighborPixelS;
.source "NearestNeighborPixel_U16.java"


# instance fields
.field private data:[S


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 44
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/NearestNeighborPixelS;-><init>()V

    return-void
.end method


# virtual methods
.method public get(FF)F
    .locals 3

    const/4 v0, 0x0

    cmpg-float v1, p1, v0

    if-ltz v1, :cond_1

    cmpg-float v0, p2, v0

    if-ltz v0, :cond_1

    .line 66
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/NearestNeighborPixelS;->width:I

    add-int/lit8 v0, v0, -0x1

    int-to-float v0, v0

    cmpl-float v0, p1, v0

    if-gtz v0, :cond_1

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/NearestNeighborPixelS;->height:I

    add-int/lit8 v0, v0, -0x1

    int-to-float v0, v0

    cmpl-float v0, p2, v0

    if-lez v0, :cond_0

    goto :goto_0

    :cond_0
    float-to-int p1, p1

    float-to-int p2, p2

    .line 71
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/impl/NearestNeighborPixel_U16;->data:[S

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/NearestNeighborPixelS;->orig:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    check-cast v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    iget v1, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/NearestNeighborPixelS;->stride:I

    mul-int/2addr p2, v2

    add-int/2addr v1, p2

    add-int/2addr v1, p1

    aget-short p1, v0, v1

    const p2, 0xffff

    and-int/2addr p1, p2

    int-to-float p1, p1

    return p1

    .line 67
    :cond_1
    :goto_0
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/impl/NearestNeighborPixel_U16;->get_border(FF)F

    move-result p1

    return p1
.end method

.method public get_border(FF)F
    .locals 3

    .line 61
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/NearestNeighborPixelS;->border:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder;

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder_S32;

    float-to-double v1, p1

    invoke-static {v1, v2}, Ljava/lang/Math;->floor(D)D

    move-result-wide v1

    double-to-int p1, v1

    float-to-double v1, p2

    invoke-static {v1, v2}, Ljava/lang/Math;->floor(D)D

    move-result-wide v1

    double-to-int p2, v1

    invoke-virtual {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder_S32;->get(II)I

    move-result p1

    int-to-float p1, p1

    return p1
.end method

.method public setImage(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;)V
    .locals 0

    .line 51
    invoke-super {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/NearestNeighborPixelS;->setImage(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)V

    .line 52
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/NearestNeighborPixelS;->orig:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/impl/NearestNeighborPixel_U16;->data:[S

    return-void
.end method

.method public bridge synthetic setImage(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V
    .locals 0

    .line 40
    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/impl/NearestNeighborPixel_U16;->setImage(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;)V

    return-void
.end method
