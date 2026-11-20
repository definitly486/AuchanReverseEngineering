.class public abstract Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/ImplMultiplication_FSCC;
.super Ljava/lang/Object;
.source "ImplMultiplication_FSCC.java"


# direct methods
.method public static mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/IGrowArray;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FGrowArray;)V
    .locals 8

    .line 56
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numRows:I

    invoke-static {p4, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->adjust(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FGrowArray;I)[F

    move-result-object v6

    .line 57
    iget p4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numRows:I

    invoke-static {p3, p4, p4}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->adjust(Lcom/scanflow/datacapture/barinternal/org/ejml/data/IGrowArray;II)[I

    move-result-object v7

    .line 59
    iget p3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_length:I

    iget p4, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_length:I

    add-int/2addr p3, p4

    const/4 p4, 0x0

    invoke-virtual {p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->growMaxLength(IZ)V

    .line 60
    iput-boolean p4, p2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->indicesSorted:Z

    .line 61
    iput p4, p2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_length:I

    .line 64
    iget-object p3, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->col_idx:[I

    aget p3, p3, p4

    const/4 p4, 0x1

    move v5, p4

    .line 65
    :goto_0
    iget p4, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numCols:I

    if-gt v5, p4, :cond_3

    add-int/lit8 p4, v5, -0x1

    .line 67
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->col_idx:[I

    aget v0, v0, v5

    .line 68
    iget-object v1, p2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->col_idx:[I

    iget v2, p2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_length:I

    aput v2, v1, v5

    if-ne p3, v0, :cond_0

    move-object v1, p0

    move-object v4, p2

    goto :goto_3

    :cond_0
    :goto_1
    if-ge p3, v0, :cond_1

    .line 76
    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_rows:[I

    aget v2, v1, p3

    .line 77
    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_values:[F

    aget v3, v1, p3

    move-object v1, p0

    move-object v4, p2

    .line 79
    invoke-static/range {v1 .. v7}, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/ImplMultiplication_FSCC;->multAddColA(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;IFLcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;I[F[I)V

    add-int/lit8 p3, p3, 0x1

    goto :goto_1

    :cond_1
    move-object v1, p0

    move-object v4, p2

    .line 83
    iget-object p0, v4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->col_idx:[I

    aget p2, p0, p4

    .line 84
    aget p0, p0, v5

    :goto_2
    if-ge p2, p0, :cond_2

    .line 87
    iget-object p3, v4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_values:[F

    iget-object p4, v4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_rows:[I

    aget p4, p4, p2

    aget p4, v6, p4

    aput p4, p3, p2

    add-int/lit8 p2, p2, 0x1

    goto :goto_2

    :cond_2
    move p3, v0

    :goto_3
    add-int/lit8 v5, v5, 0x1

    move-object p0, v1

    move-object p2, v4

    goto :goto_0

    :cond_3
    return-void
.end method

.method public static multAddColA(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;IFLcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;I[F[I)V
    .locals 5

    .line 103
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->col_idx:[I

    aget v1, v0, p1

    const/4 v2, 0x1

    add-int/2addr p1, v2

    .line 104
    aget p1, v0, p1

    :goto_0
    if-ge v1, p1, :cond_2

    .line 107
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_rows:[I

    aget v0, v0, v1

    .line 109
    aget v3, p6, v0

    if-ge v3, p4, :cond_1

    .line 110
    iget v3, p3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_length:I

    iget-object v4, p3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_rows:[I

    array-length v4, v4

    if-lt v3, v4, :cond_0

    mul-int/lit8 v3, v3, 0x2

    add-int/2addr v3, v2

    .line 111
    invoke-virtual {p3, v3, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->growMaxLength(IZ)V

    .line 114
    :cond_0
    aput p4, p6, v0

    .line 115
    iget-object v3, p3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_rows:[I

    iget v4, p3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_length:I

    aput v0, v3, v4

    .line 116
    iget-object v3, p3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->col_idx:[I

    add-int/2addr v4, v2

    iput v4, p3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_length:I

    aput v4, v3, p4

    .line 117
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_values:[F

    aget v3, v3, v1

    mul-float/2addr v3, p2

    aput v3, p5, v0

    goto :goto_1

    .line 119
    :cond_1
    aget v3, p5, v0

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_values:[F

    aget v4, v4, v1

    mul-float/2addr v4, p2

    add-float/2addr v3, v4

    aput v3, p5, v0

    :goto_1
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_2
    return-void
.end method
