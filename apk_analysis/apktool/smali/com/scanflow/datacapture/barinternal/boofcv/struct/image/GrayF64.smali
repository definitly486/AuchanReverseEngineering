.class public Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;
.super Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF;
.source "GrayF64.java"


# instance fields
.field public data:[D


# direct methods
.method public constructor <init>()V
    .locals 1

    .line 46
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF;-><init>()V

    const/4 v0, 0x0

    new-array v0, v0, [D

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;->data:[D

    return-void
.end method

.method public constructor <init>(II)V
    .locals 0

    .line 40
    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF;-><init>(II)V

    return-void
.end method


# virtual methods
.method protected _getData()Ljava/lang/Object;
    .locals 1

    .line 123
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;->data:[D

    return-object v0
.end method

.method public _setData(Ljava/lang/Object;)V
    .locals 0

    .line 127
    check-cast p1, [D

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;->data:[D

    return-void
.end method

.method public createNew(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;
    .locals 1

    const/4 v0, -0x1

    if-eq p1, v0, :cond_1

    if-ne p2, v0, :cond_0

    goto :goto_0

    .line 134
    :cond_0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    invoke-direct {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;-><init>(II)V

    return-object v0

    .line 133
    :cond_1
    :goto_0
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;-><init>()V

    return-object p1
.end method

.method public bridge synthetic createNew(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;
    .locals 0

    .line 28
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;->createNew(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    move-result-object p1

    return-object p1
.end method

.method public get(II)D
    .locals 3

    .line 56
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->isInBounds(II)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 59
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;->unsafe_get(II)D

    move-result-wide p1

    return-wide p1

    .line 57
    :cond_0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageAccessException;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Requested pixel is out of bounds: "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p1, " "

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageAccessException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method public getDataType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;
    .locals 1

    .line 151
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->F64:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    return-object v0
.end method

.method public unsafe_get(II)D
    .locals 1

    .line 63
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;->data:[D

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p1

    aget-wide p1, v0, p1

    return-wide p1
.end method
