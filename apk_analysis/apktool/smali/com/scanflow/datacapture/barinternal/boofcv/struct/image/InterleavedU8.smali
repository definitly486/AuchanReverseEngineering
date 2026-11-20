.class public Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;
.super Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;
.source "InterleavedU8.java"


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 41
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;-><init>()V

    return-void
.end method

.method public constructor <init>(III)V
    .locals 0

    .line 38
    invoke-direct {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;-><init>(III)V

    return-void
.end method


# virtual methods
.method public bridge synthetic createNew(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;
    .locals 0

    .line 28
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;->createNew(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;

    move-result-object p1

    return-object p1
.end method

.method public createNew(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;
    .locals 2

    const/4 v0, -0x1

    if-eq p1, v0, :cond_1

    if-ne p2, v0, :cond_0

    goto :goto_0

    .line 121
    :cond_0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->numBands:I

    invoke-direct {v0, p1, p2, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;-><init>(III)V

    return-object v0

    .line 120
    :cond_1
    :goto_0
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;-><init>()V

    return-object p1
.end method

.method public getBand(III)I
    .locals 1

    .line 101
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->isInBounds(II)Z

    move-result v0

    if-eqz v0, :cond_1

    if-ltz p3, :cond_0

    .line 103
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->numBands:I

    if-ge p3, v0, :cond_0

    .line 106
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;->data:[B

    invoke-virtual {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(III)I

    move-result p1

    aget-byte p1, v0, p1

    and-int/lit16 p1, p1, 0xff

    return p1

    .line 104
    :cond_0
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageAccessException;

    const-string p2, "Invalid band requested."

    invoke-direct {p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageAccessException;-><init>(Ljava/lang/String;)V

    throw p1

    .line 102
    :cond_1
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageAccessException;

    const-string p2, "Requested pixel is out of bounds."

    invoke-direct {p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageAccessException;-><init>(Ljava/lang/String;)V

    throw p1
.end method
