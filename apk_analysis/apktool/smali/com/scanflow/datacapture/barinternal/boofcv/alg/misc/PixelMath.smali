.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/PixelMath;
.super Ljava/lang/Object;
.source "PixelMath.java"


# static fields
.field public static SMALL_IMAGE:I = 0x2710


# direct methods
.method static constructor <clinit>()V
    .locals 0

    .line 42
    return-void
.end method

.method public static pow2(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 10

    .line 7693
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-virtual {p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(II)V

    .line 7695
    iget v9, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    mul-int v0, v9, v8

    .line 7696
    sget-boolean v1, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v1, :cond_0

    sget v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/PixelMath;->SMALL_IMAGE:I

    if-le v0, v1, :cond_0

    .line 7697
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    iget v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v7, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    invoke-static/range {v2 .. v9}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplPixelMath_MT;->pow2([FII[FIIII)V

    return-void

    .line 7702
    :cond_0
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    iget v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v7, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    invoke-static/range {v2 .. v9}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplPixelMath;->pow2([FII[FIIII)V

    return-void
.end method

.method public static sqrt(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 10

    .line 7208
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-virtual {p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(II)V

    .line 7210
    iget v9, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    mul-int v0, v9, v8

    .line 7211
    sget-boolean v1, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v1, :cond_0

    sget v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/PixelMath;->SMALL_IMAGE:I

    if-le v0, v1, :cond_0

    .line 7212
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    iget v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v7, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    invoke-static/range {v2 .. v9}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplPixelMath_MT;->sqrt([FII[FIIII)V

    return-void

    .line 7217
    :cond_0
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    iget v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v7, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    invoke-static/range {v2 .. v9}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplPixelMath;->sqrt([FII[FIIII)V

    return-void
.end method

.method public static subtract(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 2

    .line 7095
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->checkSameShape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 7096
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-virtual {p2, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(II)V

    .line 7098
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    mul-int/2addr v0, v1

    .line 7099
    sget-boolean v1, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    if-eqz v1, :cond_0

    sget v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/PixelMath;->SMALL_IMAGE:I

    if-le v0, v1, :cond_0

    .line 7100
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplPixelMath_MT;->subtract(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    return-void

    .line 7102
    :cond_0
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplPixelMath;->subtract(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    return-void
.end method
