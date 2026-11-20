.class public Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;
.super Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;
.source "InterleavedF32.java"


# instance fields
.field public data:[F


# direct methods
.method public constructor <init>()V
    .locals 1

    .line 46
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;-><init>()V

    const/4 v0, 0x0

    new-array v0, v0, [F

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;->data:[F

    return-void
.end method

.method public constructor <init>(III)V
    .locals 0

    .line 43
    invoke-direct {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;-><init>(III)V

    return-void
.end method


# virtual methods
.method protected _getData()Ljava/lang/Object;
    .locals 1

    .line 159
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;->data:[F

    return-object v0
.end method

.method protected _setData(Ljava/lang/Object;)V
    .locals 0

    .line 167
    check-cast p1, [F

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;->data:[F

    return-void
.end method

.method public bridge synthetic createNew(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;
    .locals 0

    .line 30
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;->createNew(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;

    move-result-object p1

    return-object p1
.end method

.method public createNew(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;
    .locals 2

    const/4 v0, -0x1

    if-eq p1, v0, :cond_1

    if-ne p2, v0, :cond_0

    goto :goto_0

    .line 173
    :cond_0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->numBands:I

    invoke-direct {v0, p1, p2, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;-><init>(III)V

    return-object v0

    .line 172
    :cond_1
    :goto_0
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;-><init>()V

    return-object p1
.end method

.method public getBand(III)F
    .locals 1

    .line 120
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->isInBounds(II)Z

    move-result v0

    if-eqz v0, :cond_1

    if-ltz p3, :cond_0

    .line 122
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->numBands:I

    if-ge p3, v0, :cond_0

    .line 125
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;->data:[F

    invoke-virtual {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getIndex(III)I

    move-result p1

    aget p1, v0, p1

    return p1

    .line 123
    :cond_0
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageAccessException;

    const-string p2, "Invalid band requested."

    invoke-direct {p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageAccessException;-><init>(Ljava/lang/String;)V

    throw p1

    .line 121
    :cond_1
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageAccessException;

    const-string p2, "Requested pixel is out of bounds."

    invoke-direct {p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageAccessException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method protected getPrimitiveDataType()Ljava/lang/Class;
    .locals 1

    .line 163
    sget-object v0, Ljava/lang/Float;->TYPE:Ljava/lang/Class;

    return-object v0
.end method

.method public toString_element(I)Ljava/lang/String;
    .locals 1

    .line 49
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;->data:[F

    aget p1, v0, p1

    invoke-static {p1}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object p1

    filled-new-array {p1}, [Ljava/lang/Object;

    move-result-object p1

    const-string v0, "%5f"

    invoke-static {v0, p1}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method
