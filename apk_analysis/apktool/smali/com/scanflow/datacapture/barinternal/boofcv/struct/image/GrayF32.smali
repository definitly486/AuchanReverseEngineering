.class public Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;
.super Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF;
.source "GrayF32.java"


# instance fields
.field public data:[F


# direct methods
.method public constructor <init>()V
    .locals 1

    .line 44
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF;-><init>()V

    const/4 v0, 0x0

    new-array v0, v0, [F

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

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

    .line 126
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    return-object v0
.end method

.method public _setData(Ljava/lang/Object;)V
    .locals 0

    .line 130
    check-cast p1, [F

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    return-void
.end method

.method public createNew(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;
    .locals 1

    const/4 v0, -0x1

    if-eq p1, v0, :cond_1

    if-ne p2, v0, :cond_0

    goto :goto_0

    .line 137
    :cond_0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    invoke-direct {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;-><init>(II)V

    return-object v0

    .line 136
    :cond_1
    :goto_0
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;-><init>()V

    return-object p1
.end method

.method public bridge synthetic createNew(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;
    .locals 0

    .line 28
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->createNew(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    move-result-object p1

    return-object p1
.end method

.method public get(II)F
    .locals 3

    .line 54
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->isInBounds(II)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 57
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->unsafe_get(II)F

    move-result p1

    return p1

    .line 55
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

    .line 154
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->F32:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    return-object v0
.end method

.method public set(IIF)V
    .locals 2

    .line 72
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->isInBounds(II)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 75
    invoke-virtual {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->unsafe_set(IIF)V

    return-void

    .line 73
    :cond_0
    new-instance p3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageAccessException;

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "Requested pixel is out of bounds: "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p1, " "

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, p2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {p3, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageAccessException;-><init>(Ljava/lang/String;)V

    throw p3
.end method

.method public unsafe_get(II)F
    .locals 1

    .line 61
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p1

    aget p1, v0, p1

    return p1
.end method

.method public unsafe_set(IIF)V
    .locals 1

    .line 79
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p1

    aput p3, v0, p1

    return-void
.end method
