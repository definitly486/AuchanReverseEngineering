.class public Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;
.super Ljava/lang/Object;
.source "DogArray_F64.java"


# instance fields
.field public data:[D

.field public size:I


# direct methods
.method public constructor <init>()V
    .locals 1

    const/16 v0, 0xa

    .line 42
    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;-><init>(I)V

    return-void
.end method

.method public constructor <init>(I)V
    .locals 0

    .line 36
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 37
    new-array p1, p1, [D

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;->data:[D

    const/4 p1, 0x0

    .line 38
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;->size:I

    return-void
.end method


# virtual methods
.method public add(D)V
    .locals 0

    .line 147
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;->push(D)V

    return-void
.end method

.method public get(I)D
    .locals 4

    if-ltz p1, :cond_0

    .line 270
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;->size:I

    if-ge p1, v0, :cond_0

    .line 272
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;->data:[D

    aget-wide v1, v0, p1

    return-wide v1

    .line 271
    :cond_0
    new-instance v0, Ljava/lang/IndexOutOfBoundsException;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;->size:I

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

.method public push(D)V
    .locals 4

    .line 151
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;->size:I

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;->data:[D

    array-length v1, v1

    if-ne v0, v1, :cond_0

    mul-int/lit8 v0, v0, 0x2

    add-int/lit8 v0, v0, 0x5

    .line 154
    :try_start_0
    new-array v0, v0, [D
    :try_end_0
    .catch Ljava/lang/OutOfMemoryError; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 156
    :catch_0
    invoke-static {}, Ljava/lang/System;->gc()V

    .line 157
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;->size:I

    mul-int/lit8 v0, v0, 0x3

    div-int/lit8 v0, v0, 0x2

    new-array v0, v0, [D

    .line 159
    :goto_0
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;->data:[D

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;->size:I

    const/4 v3, 0x0

    invoke-static {v1, v3, v0, v3, v2}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    .line 160
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;->data:[D

    .line 162
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;->data:[D

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;->size:I

    add-int/lit8 v2, v1, 0x1

    iput v2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;->size:I

    aput-wide p1, v0, v1

    return-void
.end method

.method public reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;
    .locals 1

    const/4 v0, 0x0

    .line 117
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;->size:I

    return-object p0
.end method
