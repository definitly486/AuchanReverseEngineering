.class public Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU16;
.super Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI16;
.source "InterleavedU16.java"


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 41
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI16;-><init>()V

    return-void
.end method

.method public constructor <init>(III)V
    .locals 0

    .line 38
    invoke-direct {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI16;-><init>(III)V

    return-void
.end method


# virtual methods
.method public bridge synthetic createNew(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;
    .locals 0

    .line 28
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU16;->createNew(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU16;

    move-result-object p1

    return-object p1
.end method

.method public createNew(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU16;
    .locals 2

    const/4 v0, -0x1

    if-eq p1, v0, :cond_1

    if-ne p2, v0, :cond_0

    goto :goto_0

    .line 82
    :cond_0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU16;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->numBands:I

    invoke-direct {v0, p1, p2, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU16;-><init>(III)V

    return-object v0

    .line 81
    :cond_1
    :goto_0
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU16;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU16;-><init>()V

    return-object p1
.end method
