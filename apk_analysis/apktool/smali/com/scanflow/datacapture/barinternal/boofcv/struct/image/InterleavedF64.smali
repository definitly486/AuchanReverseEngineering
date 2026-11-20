.class public Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;
.super Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;
.source "InterleavedF64.java"


# instance fields
.field public data:[D


# direct methods
.method public constructor <init>()V
    .locals 1

    .line 46
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;-><init>()V

    const/4 v0, 0x0

    new-array v0, v0, [D

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;->data:[D

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

    .line 153
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;->data:[D

    return-object v0
.end method

.method protected _setData(Ljava/lang/Object;)V
    .locals 0

    .line 161
    check-cast p1, [D

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;->data:[D

    return-void
.end method

.method public bridge synthetic createNew(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;
    .locals 0

    .line 30
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;->createNew(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;

    move-result-object p1

    return-object p1
.end method

.method public createNew(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;
    .locals 2

    const/4 v0, -0x1

    if-eq p1, v0, :cond_1

    if-ne p2, v0, :cond_0

    goto :goto_0

    .line 167
    :cond_0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->numBands:I

    invoke-direct {v0, p1, p2, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;-><init>(III)V

    return-object v0

    .line 166
    :cond_1
    :goto_0
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;-><init>()V

    return-object p1
.end method

.method protected getPrimitiveDataType()Ljava/lang/Class;
    .locals 1

    .line 157
    sget-object v0, Ljava/lang/Double;->TYPE:Ljava/lang/Class;

    return-object v0
.end method

.method public toString_element(I)Ljava/lang/String;
    .locals 3

    .line 49
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;->data:[D

    aget-wide v1, v0, p1

    invoke-static {v1, v2}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object p1

    filled-new-array {p1}, [Ljava/lang/Object;

    move-result-object p1

    const-string v0, "%5f"

    invoke-static {v0, p1}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method
