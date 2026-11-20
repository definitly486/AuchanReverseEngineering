.class public Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;
.super Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;
.source "GrayS8.java"


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 39
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;-><init>()V

    return-void
.end method

.method public constructor <init>(II)V
    .locals 0

    .line 36
    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;-><init>(II)V

    return-void
.end method


# virtual methods
.method public createNew(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;
    .locals 1

    const/4 v0, -0x1

    if-eq p1, v0, :cond_1

    if-ne p2, v0, :cond_0

    goto :goto_0

    .line 56
    :cond_0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;

    invoke-direct {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;-><init>(II)V

    return-object v0

    .line 54
    :cond_1
    :goto_0
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;-><init>()V

    return-object p1
.end method

.method public bridge synthetic createNew(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;
    .locals 0

    .line 28
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;->createNew(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;

    move-result-object p1

    return-object p1
.end method

.method public getDataType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;
    .locals 1

    .line 48
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->S8:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    return-object v0
.end method

.method public unsafe_get(II)I
    .locals 1

    .line 43
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p1

    aget-byte p1, v0, p1

    return p1
.end method
