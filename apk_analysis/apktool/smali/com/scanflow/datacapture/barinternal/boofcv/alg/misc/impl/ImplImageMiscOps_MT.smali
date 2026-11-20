.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageMiscOps_MT;
.super Ljava/lang/Object;
.source "ImplImageMiscOps_MT.java"


# direct methods
.method public static synthetic $r8$lambda$1wFn_nI-jGqZziFhE4NJIDQBZmo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;III)V
    .locals 3

    .line 170
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStartIndex()I

    move-result v0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStride()I

    move-result v1

    mul-int/2addr v1, p4

    add-int/2addr v0, v1

    .line 171
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStartIndex()I

    move-result v1

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStride()I

    move-result v2

    mul-int/2addr p4, v2

    add-int/2addr v1, p4

    add-int/2addr v1, p2

    .line 172
    iget p4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    mul-int/2addr p4, p3

    add-int/2addr p4, v1

    sub-int/2addr p4, p2

    :goto_0
    if-ge v1, p4, :cond_0

    .line 174
    iget-object p2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;->data:[B

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aget-byte v2, v2, v0

    aput-byte v2, p2, v1

    add-int/2addr v1, p3

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$6qNwGIwwnaUxCd3prRxkzyJQ-84(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;III)V
    .locals 3

    .line 2256
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStartIndex()I

    move-result v0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStride()I

    move-result v1

    mul-int/2addr v1, p4

    add-int/2addr v0, v1

    .line 2257
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStartIndex()I

    move-result v1

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStride()I

    move-result v2

    mul-int/2addr p4, v2

    add-int/2addr v1, p4

    add-int/2addr v1, p2

    .line 2258
    iget p4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    mul-int/2addr p4, p3

    add-int/2addr p4, v1

    sub-int/2addr p4, p2

    :goto_0
    if-ge v1, p4, :cond_0

    .line 2260
    iget-object p2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;->data:[F

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v2, v2, v0

    aput v2, p2, v1

    add-int/2addr v1, p3

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$FsmiptJFZZ-2lIxBG4IuwZfQFN8(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI16;III)V
    .locals 3

    .line 692
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStartIndex()I

    move-result v0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStride()I

    move-result v1

    mul-int/2addr v1, p4

    add-int/2addr v0, v1

    .line 693
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStartIndex()I

    move-result v1

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStride()I

    move-result v2

    mul-int/2addr p4, v2

    add-int/2addr v1, p4

    add-int/2addr v1, p2

    .line 694
    iget p4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    mul-int/2addr p4, p3

    add-int/2addr p4, v1

    sub-int/2addr p4, p2

    :goto_0
    if-ge v1, p4, :cond_0

    .line 696
    iget-object p2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI16;->data:[S

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    aget-short v2, v2, v0

    aput-short v2, p2, v1

    add-int/2addr v1, p3

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$M0sSOInO1HeQFf6VdHJbQ0tAXxg(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;III)V
    .locals 5

    .line 1735
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStartIndex()I

    move-result v0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStride()I

    move-result v1

    mul-int/2addr v1, p4

    add-int/2addr v0, v1

    .line 1736
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStartIndex()I

    move-result v1

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStride()I

    move-result v2

    mul-int/2addr p4, v2

    add-int/2addr v1, p4

    add-int/2addr v1, p2

    .line 1737
    iget p4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    mul-int/2addr p4, p3

    add-int/2addr p4, v1

    sub-int/2addr p4, p2

    :goto_0
    if-ge v1, p4, :cond_0

    .line 1739
    iget-object p2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;->data:[J

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;->data:[J

    aget-wide v3, v2, v0

    aput-wide v3, p2, v1

    add-int/2addr v1, p3

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$Qewqezj9qOpZIIowgpt-nfax_4I(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;III)V
    .locals 5

    .line 2777
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStartIndex()I

    move-result v0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStride()I

    move-result v1

    mul-int/2addr v1, p4

    add-int/2addr v0, v1

    .line 2778
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStartIndex()I

    move-result v1

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStride()I

    move-result v2

    mul-int/2addr p4, v2

    add-int/2addr v1, p4

    add-int/2addr v1, p2

    .line 2779
    iget p4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    mul-int/2addr p4, p3

    add-int/2addr p4, v1

    sub-int/2addr p4, p2

    :goto_0
    if-ge v1, p4, :cond_0

    .line 2781
    iget-object p2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;->data:[D

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;->data:[D

    aget-wide v3, v2, v0

    aput-wide v3, p2, v1

    add-int/2addr v1, p3

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static synthetic $r8$lambda$hnfeS48zOyjY2JZ04K5sVbr_U5E(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS32;III)V
    .locals 3

    .line 1214
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStartIndex()I

    move-result v0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStride()I

    move-result v1

    mul-int/2addr v1, p4

    add-int/2addr v0, v1

    .line 1215
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStartIndex()I

    move-result v1

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStride()I

    move-result v2

    mul-int/2addr p4, v2

    add-int/2addr v1, p4

    add-int/2addr v1, p2

    .line 1216
    iget p4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    mul-int/2addr p4, p3

    add-int/2addr p4, v1

    sub-int/2addr p4, p2

    :goto_0
    if-ge v1, p4, :cond_0

    .line 1218
    iget-object p2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS32;->data:[I

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;->data:[I

    aget v2, v2, v0

    aput v2, p2, v1

    add-int/2addr v1, p3

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static insertBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;)V
    .locals 3

    .line 2254
    iget v0, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->numBands:I

    .line 2255
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageMiscOps_MT$$ExternalSyntheticLambda1;

    invoke-direct {v2, p0, p2, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageMiscOps_MT$$ExternalSyntheticLambda1;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;II)V

    const/4 p0, 0x0

    invoke-static {p0, v1, v2}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static insertBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;)V
    .locals 3

    .line 2775
    iget v0, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->numBands:I

    .line 2776
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageMiscOps_MT$$ExternalSyntheticLambda0;

    invoke-direct {v2, p0, p2, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageMiscOps_MT$$ExternalSyntheticLambda0;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;II)V

    const/4 p0, 0x0

    invoke-static {p0, v1, v2}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static insertBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI16;)V
    .locals 3

    .line 690
    iget v0, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->numBands:I

    .line 691
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageMiscOps_MT$$ExternalSyntheticLambda4;

    invoke-direct {v2, p0, p2, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageMiscOps_MT$$ExternalSyntheticLambda4;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI16;II)V

    const/4 p0, 0x0

    invoke-static {p0, v1, v2}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static insertBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;)V
    .locals 3

    .line 168
    iget v0, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->numBands:I

    .line 169
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageMiscOps_MT$$ExternalSyntheticLambda5;

    invoke-direct {v2, p0, p2, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageMiscOps_MT$$ExternalSyntheticLambda5;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;II)V

    const/4 p0, 0x0

    invoke-static {p0, v1, v2}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static insertBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS32;)V
    .locals 3

    .line 1212
    iget v0, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->numBands:I

    .line 1213
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageMiscOps_MT$$ExternalSyntheticLambda2;

    invoke-direct {v2, p0, p2, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageMiscOps_MT$$ExternalSyntheticLambda2;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS32;II)V

    const/4 p0, 0x0

    invoke-static {p0, v1, v2}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method

.method public static insertBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;)V
    .locals 3

    .line 1733
    iget v0, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->numBands:I

    .line 1734
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    new-instance v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageMiscOps_MT$$ExternalSyntheticLambda3;

    invoke-direct {v2, p0, p2, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageMiscOps_MT$$ExternalSyntheticLambda3;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;II)V

    const/4 p0, 0x0

    invoke-static {p0, v1, v2}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void
.end method
