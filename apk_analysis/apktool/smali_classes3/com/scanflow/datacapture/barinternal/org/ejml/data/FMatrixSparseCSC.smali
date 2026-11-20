.class public Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;
.super Ljava/lang/Object;
.source "FMatrixSparseCSC.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;
.implements Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixSparse;


# instance fields
.field public col_idx:[I

.field public indicesSorted:Z

.field public numCols:I

.field public numRows:I

.field public nz_length:I

.field public nz_rows:[I

.field public nz_values:[F


# direct methods
.method public constructor <init>(II)V
    .locals 1

    const/4 v0, 0x0

    .line 83
    invoke-direct {p0, p1, p2, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;-><init>(III)V

    return-void
.end method

.method public constructor <init>(III)V
    .locals 1

    .line 93
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 46
    sget-object v0, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->ZERO_LENGTH_F32:[F

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_values:[F

    .line 55
    sget-object v0, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->ZERO_LENGTH_I32:[I

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_rows:[I

    const/4 v0, 0x0

    .line 74
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->indicesSorted:Z

    if-ltz p1, :cond_0

    if-ltz p2, :cond_0

    if-ltz p3, :cond_0

    .line 96
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numRows:I

    .line 97
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numCols:I

    .line 98
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_length:I

    add-int/lit8 p2, p2, 0x1

    .line 99
    new-array p1, p2, [I

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->col_idx:[I

    .line 100
    invoke-virtual {p0, p3, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->growMaxLength(IZ)V

    return-void

    .line 95
    :cond_0
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string p2, "Rows, columns, and arrayLength must be not be negative"

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;)V
    .locals 3

    .line 104
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numRows:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numCols:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_length:I

    invoke-direct {p0, v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;-><init>(III)V

    .line 106
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->setTo(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)V

    return-void
.end method


# virtual methods
.method public copy()Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;
    .locals 1

    .line 118
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;-><init>(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;)V

    return-object v0
.end method

.method public bridge synthetic copy()Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;
    .locals 1

    .line 41
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->copy()Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;

    move-result-object v0

    return-object v0
.end method

.method public create(II)Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;
    .locals 1

    .line 287
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;

    invoke-direct {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;-><init>(II)V

    return-object v0
.end method

.method public bridge synthetic create(II)Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;
    .locals 0

    .line 41
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->create(II)Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;

    move-result-object p1

    return-object p1
.end method

.method public get(II)F
    .locals 1

    if-ltz p1, :cond_0

    .line 167
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numRows:I

    if-ge p1, v0, :cond_0

    if-ltz p2, :cond_0

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numCols:I

    if-ge p2, v0, :cond_0

    .line 170
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->unsafe_get(II)F

    move-result p1

    return p1

    .line 168
    :cond_0
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string p2, "Outside of matrix bounds"

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public getNonZeroLength()I
    .locals 1

    .line 291
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_length:I

    return v0
.end method

.method public getNumCols()I
    .locals 1

    .line 114
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numCols:I

    return v0
.end method

.method public getNumRows()I
    .locals 1

    .line 110
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numRows:I

    return v0
.end method

.method public getType()Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;
    .locals 1

    .line 440
    sget-object v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->FSCC:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    return-object v0
.end method

.method public growMaxLength(IZ)V
    .locals 3

    if-ltz p1, :cond_2

    .line 349
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_values:[F

    array-length v1, v0

    if-le p1, v1, :cond_1

    .line 350
    new-array v1, p1, [F

    .line 351
    new-array p1, p1, [I

    if-eqz p2, :cond_0

    .line 354
    iget p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_length:I

    const/4 v2, 0x0

    invoke-static {v0, v2, v1, v2, p2}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    .line 355
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_rows:[I

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_length:I

    invoke-static {p2, v2, p1, v2, v0}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    .line 358
    :cond_0
    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_values:[F

    .line 359
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_rows:[I

    :cond_1
    return-void

    .line 339
    :cond_2
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string p2, "Negative array length. Overflow?"

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public nz_index(II)I
    .locals 2

    .line 203
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->col_idx:[I

    aget v1, v0, p2

    add-int/lit8 p2, p2, 0x1

    .line 204
    aget p2, v0, p2

    .line 206
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->indicesSorted:Z

    if-eqz v0, :cond_0

    .line 207
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_rows:[I

    invoke-static {v0, v1, p2, p1}, Ljava/util/Arrays;->binarySearch([IIII)I

    move-result p1

    return p1

    :cond_0
    :goto_0
    if-ge v1, p2, :cond_2

    .line 210
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_rows:[I

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

    .line 314
    invoke-virtual {p0, p1, p2, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->reshape(III)V

    return-void
.end method

.method public reshape(III)V
    .locals 1

    if-ltz p1, :cond_1

    if-ltz p2, :cond_1

    if-ltz p3, :cond_1

    const/4 v0, 0x0

    .line 300
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->indicesSorted:Z

    .line 301
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numRows:I

    .line 302
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numCols:I

    .line 303
    invoke-virtual {p0, p3, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->growMaxLength(IZ)V

    .line 304
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_length:I

    add-int/lit8 p2, p2, 0x1

    .line 306
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->col_idx:[I

    array-length p3, p1

    if-le p2, p3, :cond_0

    .line 307
    new-array p1, p2, [I

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->col_idx:[I

    return-void

    .line 309
    :cond_0
    invoke-static {p1, v0, p2, v0}, Ljava/util/Arrays;->fill([IIII)V

    return-void

    .line 296
    :cond_1
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string p2, "Rows, columns, and arrayLength must be not be negative"

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public setTo(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)V
    .locals 4

    .line 126
    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;

    .line 127
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numRows:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numCols:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_length:I

    invoke-virtual {p0, v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->reshape(III)V

    .line 128
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_length:I

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_length:I

    .line 130
    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_values:[F

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_values:[F

    const/4 v3, 0x0

    invoke-static {v1, v3, v2, v3, v0}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    .line 131
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_rows:[I

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_rows:[I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_length:I

    invoke-static {v0, v3, v1, v3, v2}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    .line 132
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->col_idx:[I

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->col_idx:[I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numCols:I

    add-int/lit8 v2, v2, 0x1

    invoke-static {v0, v3, v1, v3, v2}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    .line 133
    iget-boolean p1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->indicesSorted:Z

    iput-boolean p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->indicesSorted:Z

    return-void
.end method

.method public unsafe_get(II)F
    .locals 0

    .line 181
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_index(II)I

    move-result p1

    if-ltz p1, :cond_0

    .line 183
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_values:[F

    aget p1, p2, p1

    return p1

    :cond_0
    const/4 p1, 0x0

    return p1
.end method

.method public unsafe_set(IIF)V
    .locals 5

    .line 226
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_index(II)I

    move-result v0

    if-ltz v0, :cond_0

    .line 228
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_values:[F

    aput p3, p1, v0

    return-void

    .line 231
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->col_idx:[I

    aget v1, v0, p2

    const/4 v2, 0x1

    add-int/2addr p2, v2

    .line 232
    aget v0, v0, p2

    :goto_0
    if-ge v1, v0, :cond_2

    .line 237
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_rows:[I

    aget v3, v3, v1

    if-ge p1, v3, :cond_1

    goto :goto_1

    :cond_1
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    .line 243
    :cond_2
    :goto_1
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numCols:I

    if-gt p2, v0, :cond_3

    .line 244
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->col_idx:[I

    aget v3, v0, p2

    add-int/2addr v3, v2

    aput v3, v0, p2

    add-int/lit8 p2, p2, 0x1

    goto :goto_1

    .line 248
    :cond_3
    iget p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_length:I

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_values:[F

    array-length v0, v0

    if-lt p2, v0, :cond_4

    mul-int/lit8 p2, p2, 0x2

    add-int/2addr p2, v2

    .line 249
    invoke-virtual {p0, p2, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->growMaxLength(IZ)V

    .line 252
    :cond_4
    iget p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_length:I

    :goto_2
    if-le p2, v1, :cond_5

    .line 253
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_rows:[I

    add-int/lit8 v3, p2, -0x1

    aget v4, v0, v3

    aput v4, v0, p2

    .line 254
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_values:[F

    aget v3, v0, v3

    aput v3, v0, p2

    add-int/lit8 p2, p2, -0x1

    goto :goto_2

    .line 256
    :cond_5
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_rows:[I

    aput p1, p2, v1

    .line 257
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_values:[F

    aput p3, p1, v1

    .line 258
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_length:I

    add-int/2addr p1, v2

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_length:I

    return-void
.end method
