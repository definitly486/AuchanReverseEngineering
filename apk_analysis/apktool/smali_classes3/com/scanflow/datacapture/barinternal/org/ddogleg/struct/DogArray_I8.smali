.class public Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;
.super Ljava/lang/Object;
.source "DogArray_I8.java"


# instance fields
.field public data:[B

.field public size:I


# direct methods
.method public constructor <init>()V
    .locals 1

    const/16 v0, 0xa

    .line 40
    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;-><init>(I)V

    return-void
.end method

.method public constructor <init>(I)V
    .locals 0

    .line 34
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 35
    new-array p1, p1, [B

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    const/4 p1, 0x0

    .line 36
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    return-void
.end method


# virtual methods
.method public fill(IIB)V
    .locals 1

    .line 390
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    invoke-static {v0, p1, p2, p3}, Ljava/util/Arrays;->fill([BIIB)V

    return-void
.end method

.method public reserve(I)V
    .locals 3

    .line 408
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    array-length v1, v0

    if-lt v1, p1, :cond_0

    return-void

    .line 410
    :cond_0
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    if-nez v1, :cond_1

    const/4 v0, 0x0

    .line 413
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    .line 414
    new-array p1, p1, [B

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    return-void

    .line 416
    :cond_1
    new-array p1, p1, [B

    const/4 v2, 0x0

    .line 417
    invoke-static {v0, v2, p1, v2, v1}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    .line 418
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    return-void
.end method

.method public reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;
    .locals 1

    const/4 v0, 0x0

    .line 133
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    return-object p0
.end method

.method public resize(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;
    .locals 0

    .line 337
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->reserve(I)V

    .line 338
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    return-object p0
.end method

.method public resize(IB)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;
    .locals 1

    .line 349
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    .line 350
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->resize(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    if-lt v0, p1, :cond_0

    return-object p0

    .line 353
    :cond_0
    invoke-virtual {p0, v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->fill(IIB)V

    return-object p0
.end method

.method public setTo(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;
    .locals 3

    .line 331
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->resize(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    .line 332
    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size()I

    move-result v1

    const/4 v2, 0x0

    invoke-static {p1, v2, v0, v2, v1}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    return-object p0
.end method

.method public size()I
    .locals 1

    .line 423
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    return v0
.end method

.method public zero()V
    .locals 3

    .line 427
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    const/4 v1, 0x0

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    invoke-static {v0, v1, v2, v1}, Ljava/util/Arrays;->fill([BIIB)V

    return-void
.end method
