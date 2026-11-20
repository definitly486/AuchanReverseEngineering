.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/ImageMiscOps;
.super Ljava/lang/Object;
.source "ImageMiscOps.java"


# static fields
.field public static MIN_ELEMENTS_CONCURRENT:I = 0x27100


# direct methods
.method static constructor <clinit>()V
    .locals 0

    .line 49
    return-void
.end method

.method public static copy(IIIIIILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;)V
    .locals 0

    .line 101
    invoke-static/range {p0 .. p7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageMiscOps;->copy(IIIIIILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;)V

    return-void
.end method

.method public static fillBorder(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;II)V
    .locals 0

    .line 244
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageMiscOps;->fillBorder(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;II)V

    return-void
.end method

.method public static insertBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;)V
    .locals 1

    .line 1948
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/ImageMiscOps;->runConcurrent(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 1949
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageMiscOps_MT;->insertBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;)V

    return-void

    .line 1951
    :cond_0
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageMiscOps;->insertBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;)V

    return-void
.end method

.method public static insertBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;)V
    .locals 1

    .line 2382
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/ImageMiscOps;->runConcurrent(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 2383
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageMiscOps_MT;->insertBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;)V

    return-void

    .line 2385
    :cond_0
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageMiscOps;->insertBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;)V

    return-void
.end method

.method public static insertBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI16;)V
    .locals 1

    .line 645
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/ImageMiscOps;->runConcurrent(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 646
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageMiscOps_MT;->insertBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI16;)V

    return-void

    .line 648
    :cond_0
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageMiscOps;->insertBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI16;)V

    return-void
.end method

.method public static insertBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;)V
    .locals 1

    .line 210
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/ImageMiscOps;->runConcurrent(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 211
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageMiscOps_MT;->insertBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;)V

    return-void

    .line 213
    :cond_0
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageMiscOps;->insertBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;)V

    return-void
.end method

.method public static insertBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS32;)V
    .locals 1

    .line 1080
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/ImageMiscOps;->runConcurrent(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 1081
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageMiscOps_MT;->insertBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS32;)V

    return-void

    .line 1083
    :cond_0
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageMiscOps;->insertBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS32;)V

    return-void
.end method

.method public static insertBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;)V
    .locals 1

    .line 1514
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/ImageMiscOps;->runConcurrent(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 1515
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageMiscOps_MT;->insertBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;)V

    return-void

    .line 1517
    :cond_0
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageMiscOps;->insertBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;)V

    return-void
.end method

.method public static runConcurrent(I)Z
    .locals 1

    .line 55
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->isUseConcurrent()Z

    move-result v0

    if-eqz v0, :cond_0

    sget v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/ImageMiscOps;->MIN_ELEMENTS_CONCURRENT:I

    if-lt p0, v0, :cond_0

    const/4 p0, 0x1

    return p0

    :cond_0
    const/4 p0, 0x0

    return p0
.end method

.method public static runConcurrent(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)Z
    .locals 1

    .line 52
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    mul-int/2addr v0, p0

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/ImageMiscOps;->runConcurrent(I)Z

    move-result p0

    return p0
.end method
