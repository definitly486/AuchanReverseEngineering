.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/GImageMiscOps;
.super Ljava/lang/Object;
.source "GImageMiscOps.java"


# direct methods
.method public static insertBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageMultiBand;)V
    .locals 2

    .line 300
    instance-of v0, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;

    if-eqz v0, :cond_6

    .line 301
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;

    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/Class;->isAssignableFrom(Ljava/lang/Class;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 302
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;

    check-cast p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;

    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/ImageMiscOps;->insertBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;)V

    return-void

    .line 303
    :cond_0
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI16;

    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/Class;->isAssignableFrom(Ljava/lang/Class;)Z

    move-result v0

    if-eqz v0, :cond_1

    .line 304
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;

    check-cast p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI16;

    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/ImageMiscOps;->insertBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI16;)V

    return-void

    .line 305
    :cond_1
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS32;

    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v1

    if-ne v0, v1, :cond_2

    .line 306
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;

    check-cast p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS32;

    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/ImageMiscOps;->insertBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS32;)V

    return-void

    .line 307
    :cond_2
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;

    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v1

    if-ne v0, v1, :cond_3

    .line 308
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;

    check-cast p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;

    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/ImageMiscOps;->insertBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;)V

    return-void

    .line 309
    :cond_3
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;

    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v1

    if-ne v0, v1, :cond_4

    .line 310
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    check-cast p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;

    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/ImageMiscOps;->insertBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;)V

    return-void

    .line 311
    :cond_4
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;

    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v1

    if-ne v0, v1, :cond_5

    .line 312
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    check-cast p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;

    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/ImageMiscOps;->insertBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;)V

    return-void

    .line 314
    :cond_5
    new-instance p1, Ljava/lang/IllegalArgumentException;

    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object p0

    invoke-virtual {p0}, Ljava/lang/Class;->getSimpleName()Ljava/lang/String;

    move-result-object p0

    new-instance p2, Ljava/lang/StringBuilder;

    invoke-direct {p2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v0, "Unknown image Type: "

    invoke-virtual {p2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    invoke-direct {p1, p0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1

    .line 316
    :cond_6
    instance-of v0, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;

    if-eqz v0, :cond_7

    .line 317
    check-cast p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;

    .line 318
    invoke-virtual {p2, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p1

    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->setTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    return-void

    .line 320
    :cond_7
    new-instance p1, Ljava/lang/IllegalArgumentException;

    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object p0

    invoke-virtual {p0}, Ljava/lang/Class;->getSimpleName()Ljava/lang/String;

    move-result-object p0

    new-instance p2, Ljava/lang/StringBuilder;

    invoke-direct {p2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v0, "Unknown image type: "

    invoke-virtual {p2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    invoke-direct {p1, p0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method
