.class public Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;
.super Ljava/lang/Object;
.source "DogArray_I32.java"


# instance fields
.field public data:[I

.field public size:I


# direct methods
.method public constructor <init>()V
    .locals 1

    const/16 v0, 0xa

    .line 42
    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;-><init>(I)V

    return-void
.end method

.method public constructor <init>(I)V
    .locals 0

    .line 36
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 37
    new-array p1, p1, [I

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->data:[I

    const/4 p1, 0x0

    .line 38
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    return-void
.end method


# virtual methods
.method public add(I)V
    .locals 0

    .line 147
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->push(I)V

    return-void
.end method

.method public addAll(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)V
    .locals 6

    .line 122
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    add-int v2, v0, v1

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->data:[I

    array-length v4, v3

    const/4 v5, 0x0

    if-le v2, v4, :cond_0

    add-int/2addr v1, v0

    mul-int/lit8 v1, v1, 0x2

    .line 123
    new-array v1, v1, [I

    .line 124
    invoke-static {v3, v5, v1, v5, v0}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    .line 125
    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->data:[I

    .line 127
    :cond_0
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->data:[I

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->data:[I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    iget v3, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    invoke-static {v0, v5, v1, v2, v3}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    .line 128
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    iget p1, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    add-int/2addr v0, p1

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    return-void
.end method

.method public fill(I)V
    .locals 3

    .line 368
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->data:[I

    const/4 v1, 0x0

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    invoke-static {v0, v1, v2, p1}, Ljava/util/Arrays;->fill([IIII)V

    return-void
.end method

.method public get(I)I
    .locals 4

    if-ltz p1, :cond_0

    .line 269
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    if-ge p1, v0, :cond_0

    .line 271
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->data:[I

    aget p1, v0, p1

    return p1

    .line 270
    :cond_0
    new-instance v0, Ljava/lang/IndexOutOfBoundsException;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "index = "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p1, "  size = "

    invoke-virtual {v2, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {v0, p1}, Ljava/lang/IndexOutOfBoundsException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method public push(I)V
    .locals 4

    .line 151
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->data:[I

    array-length v1, v1

    if-ne v0, v1, :cond_0

    mul-int/lit8 v0, v0, 0x2

    add-int/lit8 v0, v0, 0x5

    .line 154
    :try_start_0
    new-array v0, v0, [I
    :try_end_0
    .catch Ljava/lang/OutOfMemoryError; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 156
    :catch_0
    invoke-static {}, Ljava/lang/System;->gc()V

    .line 157
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    mul-int/lit8 v0, v0, 0x3

    div-int/lit8 v0, v0, 0x2

    new-array v0, v0, [I

    .line 159
    :goto_0
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->data:[I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    const/4 v3, 0x0

    invoke-static {v1, v3, v0, v3, v2}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    .line 160
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->data:[I

    .line 162
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->data:[I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    add-int/lit8 v2, v1, 0x1

    iput v2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    aput p1, v0, v1

    return-void
.end method

.method public remove(I)V
    .locals 3

    :goto_0
    add-int/lit8 p1, p1, 0x1

    .line 198
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    if-ge p1, v0, :cond_0

    .line 199
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->data:[I

    add-int/lit8 v1, p1, -0x1

    aget v2, v0, p1

    aput v2, v0, v1

    goto :goto_0

    :cond_0
    add-int/lit8 v0, v0, -0x1

    .line 201
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    return-void
.end method

.method public reserve(I)V
    .locals 3

    .line 390
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->data:[I

    array-length v1, v0

    if-lt v1, p1, :cond_0

    return-void

    .line 392
    :cond_0
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    if-nez v1, :cond_1

    const/4 v0, 0x0

    .line 395
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->data:[I

    .line 396
    new-array p1, p1, [I

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->data:[I

    return-void

    .line 398
    :cond_1
    new-array p1, p1, [I

    const/4 v2, 0x0

    .line 399
    invoke-static {v0, v2, p1, v2, v1}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    .line 400
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->data:[I

    return-void
.end method

.method public reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;
    .locals 1

    const/4 v0, 0x0

    .line 117
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    return-object p0
.end method

.method public resize(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;
    .locals 0

    .line 320
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->reserve(I)V

    .line 321
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    return-object p0
.end method

.method public set(II)V
    .locals 1

    .line 310
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->data:[I

    aput p2, v0, p1

    return-void
.end method

.method public setTo(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;
    .locals 3

    .line 314
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->resize(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    .line 315
    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->data:[I

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->data:[I

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size()I

    move-result v1

    const/4 v2, 0x0

    invoke-static {p1, v2, v0, v2, v1}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    return-object p0
.end method

.method public size()I
    .locals 1

    .line 405
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    return v0
.end method
