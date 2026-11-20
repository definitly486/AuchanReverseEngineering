.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/GImageStatistics;
.super Ljava/lang/Object;
.source "GImageStatistics.java"


# direct methods
.method public static histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;D[I)V
    .locals 2

    .line 500
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v1

    if-ne v0, v1, :cond_0

    .line 501
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    double-to-int p1, p1

    invoke-static {p0, p1, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/ImageStatistics;->histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I[I)V

    return-void

    .line 502
    :cond_0
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;

    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v1

    if-ne v0, v1, :cond_1

    .line 503
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;

    double-to-int p1, p1

    invoke-static {p0, p1, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/ImageStatistics;->histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;I[I)V

    return-void

    .line 504
    :cond_1
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v1

    if-ne v0, v1, :cond_2

    .line 505
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    double-to-int p1, p1

    invoke-static {p0, p1, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/ImageStatistics;->histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;I[I)V

    return-void

    .line 506
    :cond_2
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;

    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v1

    if-ne v0, v1, :cond_3

    .line 507
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;

    double-to-int p1, p1

    invoke-static {p0, p1, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/ImageStatistics;->histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;I[I)V

    return-void

    .line 508
    :cond_3
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;

    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v1

    if-ne v0, v1, :cond_4

    .line 509
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;

    double-to-int p1, p1

    invoke-static {p0, p1, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/ImageStatistics;->histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;I[I)V

    return-void

    .line 510
    :cond_4
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;

    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v1

    if-ne v0, v1, :cond_5

    .line 511
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;

    double-to-long p1, p1

    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/ImageStatistics;->histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;J[I)V

    return-void

    .line 512
    :cond_5
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v1

    if-ne v0, v1, :cond_6

    .line 513
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    double-to-float p1, p1

    invoke-static {p0, p1, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/ImageStatistics;->histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;F[I)V

    return-void

    .line 514
    :cond_6
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v1

    if-ne v0, v1, :cond_7

    .line 515
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/ImageStatistics;->histogram(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;D[I)V

    return-void

    .line 517
    :cond_7
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Unknown image Type"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method
