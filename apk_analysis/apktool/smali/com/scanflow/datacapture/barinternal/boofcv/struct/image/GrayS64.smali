.class public Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;
.super Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;
.source "GrayS64.java"


# instance fields
.field public data:[J


# direct methods
.method public constructor <init>()V
    .locals 1

    .line 44
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;-><init>()V

    const/4 v0, 0x0

    new-array v0, v0, [J

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;->data:[J

    return-void
.end method

.method public constructor <init>(II)V
    .locals 0

    .line 40
    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;-><init>(II)V

    return-void
.end method


# virtual methods
.method protected _getData()Ljava/lang/Object;
    .locals 1

    .line 103
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;->data:[J

    return-object v0
.end method

.method public _setData(Ljava/lang/Object;)V
    .locals 0

    .line 107
    check-cast p1, [J

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;->data:[J

    return-void
.end method

.method public createNew(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;
    .locals 1

    const/4 v0, -0x1

    if-eq p1, v0, :cond_1

    if-ne p2, v0, :cond_0

    goto :goto_0

    .line 114
    :cond_0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;

    invoke-direct {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;-><init>(II)V

    return-object v0

    .line 113
    :cond_1
    :goto_0
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;-><init>()V

    return-object p1
.end method

.method public bridge synthetic createNew(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;
    .locals 0

    .line 28
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;->createNew(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;

    move-result-object p1

    return-object p1
.end method

.method public getDataType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;
    .locals 1

    .line 98
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->S64:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    return-object v0
.end method

.method public unsafe_get(II)J
    .locals 1

    .line 61
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;->data:[J

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p1

    aget-wide p1, v0, p1

    return-wide p1
.end method
