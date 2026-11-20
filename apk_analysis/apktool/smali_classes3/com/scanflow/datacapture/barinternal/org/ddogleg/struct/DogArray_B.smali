.class public Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;
.super Ljava/lang/Object;
.source "DogArray_B.java"


# instance fields
.field public data:[Z

.field public size:I


# direct methods
.method public constructor <init>()V
    .locals 1

    const/16 v0, 0xa

    .line 40
    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;-><init>(I)V

    return-void
.end method

.method public constructor <init>(I)V
    .locals 0

    .line 34
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 35
    new-array p1, p1, [Z

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;->data:[Z

    const/4 p1, 0x0

    .line 36
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;->size:I

    return-void
.end method


# virtual methods
.method public add(Z)V
    .locals 0

    .line 152
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;->push(Z)V

    return-void
.end method

.method public push(Z)V
    .locals 4

    .line 156
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;->size:I

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;->data:[Z

    array-length v1, v1

    if-ne v0, v1, :cond_0

    mul-int/lit8 v0, v0, 0x2

    add-int/lit8 v0, v0, 0x5

    .line 159
    :try_start_0
    new-array v0, v0, [Z
    :try_end_0
    .catch Ljava/lang/OutOfMemoryError; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 161
    :catch_0
    invoke-static {}, Ljava/lang/System;->gc()V

    .line 162
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;->size:I

    mul-int/lit8 v0, v0, 0x3

    div-int/lit8 v0, v0, 0x2

    new-array v0, v0, [Z

    .line 164
    :goto_0
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;->data:[Z

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;->size:I

    const/4 v3, 0x0

    invoke-static {v1, v3, v0, v3, v2}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    .line 165
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;->data:[Z

    .line 167
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;->data:[Z

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;->size:I

    add-int/lit8 v2, v1, 0x1

    iput v2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;->size:I

    aput-boolean p1, v0, v1

    return-void
.end method

.method public reserve(I)V
    .locals 3

    .line 387
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;->data:[Z

    array-length v1, v0

    if-lt v1, p1, :cond_0

    return-void

    .line 389
    :cond_0
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;->size:I

    if-nez v1, :cond_1

    const/4 v0, 0x0

    .line 392
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;->data:[Z

    .line 393
    new-array p1, p1, [Z

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;->data:[Z

    return-void

    .line 395
    :cond_1
    new-array p1, p1, [Z

    const/4 v2, 0x0

    .line 396
    invoke-static {v0, v2, p1, v2, v1}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    .line 397
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;->data:[Z

    return-void
.end method

.method public reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;
    .locals 1

    const/4 v0, 0x0

    .line 122
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;->size:I

    return-object p0
.end method

.method public resize(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;
    .locals 0

    .line 316
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;->reserve(I)V

    .line 317
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;->size:I

    return-object p0
.end method

.method public setTo(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;
    .locals 3

    .line 310
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;->size:I

    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;->resize(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;

    .line 311
    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;->data:[Z

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;->data:[Z

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;->size()I

    move-result v1

    const/4 v2, 0x0

    invoke-static {p1, v2, v0, v2, v1}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    return-object p0
.end method

.method public size()I
    .locals 1

    .line 402
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;->size:I

    return v0
.end method
