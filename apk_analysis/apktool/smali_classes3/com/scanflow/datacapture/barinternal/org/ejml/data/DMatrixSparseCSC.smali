.class public Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;
.super Ljava/lang/Object;
.source "DMatrixSparseCSC.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;
.implements Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixSparse;


# instance fields
.field public col_idx:[I

.field public indicesSorted:Z

.field public numCols:I

.field public numRows:I

.field public nz_length:I

.field public nz_rows:[I

.field public nz_values:[D


# direct methods
.method public constructor <init>(II)V
    .locals 1

    const/4 v0, 0x0

    .line 81
    invoke-direct {p0, p1, p2, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;-><init>(III)V

    return-void
.end method

.method public constructor <init>(III)V
    .locals 1

    .line 91
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 44
    sget-object v0, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->ZERO_LENGTH_F64:[D

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_values:[D

    .line 53
    sget-object v0, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->ZERO_LENGTH_I32:[I

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_rows:[I

    const/4 v0, 0x0

    .line 72
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->indicesSorted:Z

    if-ltz p1, :cond_0

    if-ltz p2, :cond_0

    if-ltz p3, :cond_0

    .line 94
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->numRows:I

    .line 95
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->numCols:I

    .line 96
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_length:I

    add-int/lit8 p2, p2, 0x1

    .line 97
    new-array p1, p2, [I

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->col_idx:[I

    .line 98
    invoke-virtual {p0, p3, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->growMaxLength(IZ)V

    return-void

    .line 93
    :cond_0
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string p2, "Rows, columns, and arrayLength must be not be negative"

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;)V
    .locals 3

    .line 102
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->numRows:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->numCols:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_length:I

    invoke-direct {p0, v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;-><init>(III)V

    .line 104
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->setTo(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)V

    return-void
.end method


# virtual methods
.method public copy()Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;
    .locals 1

    .line 116
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;-><init>(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;)V

    return-object v0
.end method

.method public bridge synthetic copy()Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;
    .locals 1

    .line 40
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->copy()Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;

    move-result-object v0

    return-object v0
.end method

.method public create(II)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;
    .locals 1

    .line 285
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;

    invoke-direct {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;-><init>(II)V

    return-object v0
.end method

.method public bridge synthetic create(II)Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;
    .locals 0

    .line 40
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->create(II)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;

    move-result-object p1

    return-object p1
.end method

.method public get(II)D
    .locals 1

    if-ltz p1, :cond_0

    .line 165
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->numRows:I

    if-ge p1, v0, :cond_0

    if-ltz p2, :cond_0

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->numCols:I

    if-ge p2, v0, :cond_0

    .line 168
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->unsafe_get(II)D

    move-result-wide p1

    return-wide p1

    .line 166
    :cond_0
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string p2, "Outside of matrix bounds"

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public getNonZeroLength()I
    .locals 1

    .line 289
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_length:I

    return v0
.end method

.method public getNumCols()I
    .locals 1

    .line 112
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->numCols:I

    return v0
.end method

.method public getNumRows()I
    .locals 1

    .line 108
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->numRows:I

    return v0
.end method

.method public getType()Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;
    .locals 1

    .line 438
    sget-object v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->DSCC:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    return-object v0
.end method

.method public growMaxLength(IZ)V
    .locals 3

    if-ltz p1, :cond_2

    .line 347
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_values:[D

    array-length v1, v0

    if-le p1, v1, :cond_1

    .line 348
    new-array v1, p1, [D

    .line 349
    new-array p1, p1, [I

    if-eqz p2, :cond_0

    .line 352
    iget p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_length:I

    const/4 v2, 0x0

    invoke-static {v0, v2, v1, v2, p2}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    .line 353
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_rows:[I

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_length:I

    invoke-static {p2, v2, p1, v2, v0}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    .line 356
    :cond_0
    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_values:[D

    .line 357
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_rows:[I

    :cond_1
    return-void

    .line 337
    :cond_2
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string p2, "Negative array length. Overflow?"

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public nz_index(II)I
    .locals 2

    .line 201
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->col_idx:[I

    aget v1, v0, p2

    add-int/lit8 p2, p2, 0x1

    .line 202
    aget p2, v0, p2

    .line 204
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->indicesSorted:Z

    if-eqz v0, :cond_0

    .line 205
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_rows:[I

    invoke-static {v0, v1, p2, p1}, Ljava/util/Arrays;->binarySearch([IIII)I

    move-result p1

    return p1

    :cond_0
    :goto_0
    if-ge v1, p2, :cond_2

    .line 208
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_rows:[I

    aget v0, v0, v1

    if-ne v0, p1, :cond_1

    return v1

    :cond_1
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_2
    const/4 p1, -0x1

    return p1
.end method

.method public reshape(II)V
    .locals 1

    const/4 v0, 0x0

    .line 312
    invoke-virtual {p0, p1, p2, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->reshape(III)V

    return-void
.end method

.method public reshape(III)V
    .locals 1

    if-ltz p1, :cond_1

    if-ltz p2, :cond_1

    if-ltz p3, :cond_1

    const/4 v0, 0x0

    .line 298
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->indicesSorted:Z

    .line 299
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->numRows:I

    .line 300
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->numCols:I

    .line 301
    invoke-virtual {p0, p3, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->growMaxLength(IZ)V

    .line 302
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_length:I

    add-int/lit8 p2, p2, 0x1

    .line 304
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->col_idx:[I

    array-length p3, p1

    if-le p2, p3, :cond_0

    .line 305
    new-array p1, p2, [I

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->col_idx:[I

    return-void

    .line 307
    :cond_0
    invoke-static {p1, v0, p2, v0}, Ljava/util/Arrays;->fill([IIII)V

    return-void

    .line 294
    :cond_1
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string p2, "Rows, columns, and arrayLength must be not be negative"

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public set(IID)V
    .locals 1

    if-ltz p1, :cond_0

    .line 217
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->numRows:I

    if-ge p1, v0, :cond_0

    if-ltz p2, :cond_0

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->numCols:I

    if-ge p2, v0, :cond_0

    .line 220
    invoke-virtual {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->unsafe_set(IID)V

    return-void

    .line 218
    :cond_0
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string p2, "Outside of matrix bounds"

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public setTo(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)V
    .locals 4

    .line 124
    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;

    .line 125
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->numRows:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->numCols:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_length:I

    invoke-virtual {p0, v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->reshape(III)V

    .line 126
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_length:I

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_length:I

    .line 128
    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_values:[D

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_values:[D

    const/4 v3, 0x0

    invoke-static {v1, v3, v2, v3, v0}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    .line 129
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_rows:[I

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_rows:[I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_length:I

    invoke-static {v0, v3, v1, v3, v2}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    .line 130
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->col_idx:[I

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->col_idx:[I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->numCols:I

    add-int/lit8 v2, v2, 0x1

    invoke-static {v0, v3, v1, v3, v2}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    .line 131
    iget-boolean p1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->indicesSorted:Z

    iput-boolean p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->indicesSorted:Z

    return-void
.end method

.method public unsafe_get(II)D
    .locals 0

    .line 179
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_index(II)I

    move-result p1

    if-ltz p1, :cond_0

    .line 181
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_values:[D

    aget-wide p1, p2, p1

    return-wide p1

    :cond_0
    const-wide/16 p1, 0x0

    return-wide p1
.end method

.method public unsafe_set(IID)V
    .locals 5

    .line 224
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_index(II)I

    move-result v0

    if-ltz v0, :cond_0

    .line 226
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_values:[D

    aput-wide p3, p1, v0

    return-void

    .line 229
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->col_idx:[I

    aget v1, v0, p2

    const/4 v2, 0x1

    add-int/2addr p2, v2

    .line 230
    aget v0, v0, p2

    :goto_0
    if-ge v1, v0, :cond_2

    .line 235
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_rows:[I

    aget v3, v3, v1

    if-ge p1, v3, :cond_1

    goto :goto_1

    :cond_1
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    .line 241
    :cond_2
    :goto_1
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->numCols:I

    if-gt p2, v0, :cond_3

    .line 242
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->col_idx:[I

    aget v3, v0, p2

    add-int/2addr v3, v2

    aput v3, v0, p2

    add-int/lit8 p2, p2, 0x1

    goto :goto_1

    .line 246
    :cond_3
    iget p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_length:I

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_values:[D

    array-length v0, v0

    if-lt p2, v0, :cond_4

    mul-int/lit8 p2, p2, 0x2

    add-int/2addr p2, v2

    .line 247
    invoke-virtual {p0, p2, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->growMaxLength(IZ)V

    .line 250
    :cond_4
    iget p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_length:I

    :goto_2
    if-le p2, v1, :cond_5

    .line 251
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_rows:[I

    add-int/lit8 v3, p2, -0x1

    aget v4, v0, v3

    aput v4, v0, p2

    .line 252
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_values:[D

    aget-wide v3, v0, v3

    aput-wide v3, v0, p2

    add-int/lit8 p2, p2, -0x1

    goto :goto_2

    .line 254
    :cond_5
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_rows:[I

    aput p1, p2, v1

    .line 255
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_values:[D

    aput-wide p3, p1, v1

    .line 256
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_length:I

    add-int/2addr p1, v2

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_length:I

    return-void
.end method
