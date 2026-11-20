.class public Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;
.super Ljava/lang/Object;
.source "DogArray_F32.java"


# instance fields
.field public data:[F

.field public size:I


# direct methods
.method public constructor <init>()V
    .locals 1

    const/16 v0, 0xa

    .line 42
    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;-><init>(I)V

    return-void
.end method

.method public constructor <init>(I)V
    .locals 0

    .line 36
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 37
    new-array p1, p1, [F

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;->data:[F

    const/4 p1, 0x0

    .line 38
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;->size:I

    return-void
.end method


# virtual methods
.method public add(F)V
    .locals 0

    .line 147
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;->push(F)V

    return-void
.end method

.method public fill(F)V
    .locals 3

    .line 370
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;->data:[F

    const/4 v1, 0x0

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;->size:I

    invoke-static {v0, v1, v2, p1}, Ljava/util/Arrays;->fill([FIIF)V

    return-void
.end method

.method public push(F)V
    .locals 4

    .line 151
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;->size:I

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;->data:[F

    array-length v1, v1

    if-ne v0, v1, :cond_0

    mul-int/lit8 v0, v0, 0x2

    add-int/lit8 v0, v0, 0x5

    .line 154
    :try_start_0
    new-array v0, v0, [F
    :try_end_0
    .catch Ljava/lang/OutOfMemoryError; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 156
    :catch_0
    invoke-static {}, Ljava/lang/System;->gc()V

    .line 157
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;->size:I

    mul-int/lit8 v0, v0, 0x3

    div-int/lit8 v0, v0, 0x2

    new-array v0, v0, [F

    .line 159
    :goto_0
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;->data:[F

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;->size:I

    const/4 v3, 0x0

    invoke-static {v1, v3, v0, v3, v2}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    .line 160
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;->data:[F

    .line 162
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;->data:[F

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;->size:I

    add-int/lit8 v2, v1, 0x1

    iput v2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;->size:I

    aput p1, v0, v1

    return-void
.end method

.method public reserve(I)V
    .locals 3

    .line 392
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;->data:[F

    array-length v1, v0

    if-lt v1, p1, :cond_0

    return-void

    .line 394
    :cond_0
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;->size:I

    if-nez v1, :cond_1

    const/4 v0, 0x0

    .line 397
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;->data:[F

    .line 398
    new-array p1, p1, [F

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;->data:[F

    return-void

    .line 400
    :cond_1
    new-array p1, p1, [F

    const/4 v2, 0x0

    .line 401
    invoke-static {v0, v2, p1, v2, v1}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    .line 402
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;->data:[F

    return-void
.end method

.method public reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;
    .locals 1

    const/4 v0, 0x0

    .line 117
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;->size:I

    return-object p0
.end method

.method public resize(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;
    .locals 0

    .line 321
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;->reserve(I)V

    .line 322
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;->size:I

    return-object p0
.end method
