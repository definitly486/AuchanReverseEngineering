.class public abstract Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/ImplMultiplication_DSCC;
.super Ljava/lang/Object;
.source "ImplMultiplication_DSCC.java"


# direct methods
.method public static mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/IGrowArray;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DGrowArray;)V
    .locals 9

    .line 54
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->numRows:I

    invoke-static {p4, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->adjust(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DGrowArray;I)[D

    move-result-object v7

    .line 55
    iget p4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->numRows:I

    invoke-static {p3, p4, p4}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->adjust(Lcom/scanflow/datacapture/barinternal/org/ejml/data/IGrowArray;II)[I

    move-result-object v8

    .line 57
    iget p3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_length:I

    iget p4, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_length:I

    add-int/2addr p3, p4

    const/4 p4, 0x0

    invoke-virtual {p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->growMaxLength(IZ)V

    .line 58
    iput-boolean p4, p2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->indicesSorted:Z

    .line 59
    iput p4, p2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_length:I

    .line 62
    iget-object p3, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->col_idx:[I

    aget p3, p3, p4

    const/4 p4, 0x1

    move v6, p4

    .line 63
    :goto_0
    iget p4, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->numCols:I

    if-gt v6, p4, :cond_3

    add-int/lit8 p4, v6, -0x1

    .line 65
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->col_idx:[I

    aget v0, v0, v6

    .line 66
    iget-object v1, p2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->col_idx:[I

    iget v2, p2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_length:I

    aput v2, v1, v6

    if-ne p3, v0, :cond_0

    move-object v1, p0

    move-object v5, p2

    goto :goto_3

    :cond_0
    :goto_1
    if-ge p3, v0, :cond_1

    .line 74
    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_rows:[I

    aget v2, v1, p3

    .line 75
    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_values:[D

    aget-wide v3, v1, p3

    move-object v1, p0

    move-object v5, p2

    .line 77
    invoke-static/range {v1 .. v8}, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/ImplMultiplication_DSCC;->multAddColA(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;IDLcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;I[D[I)V

    add-int/lit8 p3, p3, 0x1

    goto :goto_1

    :cond_1
    move-object v1, p0

    move-object v5, p2

    .line 81
    iget-object p0, v5, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->col_idx:[I

    aget p2, p0, p4

    .line 82
    aget p0, p0, v6

    :goto_2
    if-ge p2, p0, :cond_2

    .line 85
    iget-object p3, v5, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_values:[D

    iget-object p4, v5, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_rows:[I

    aget p4, p4, p2

    aget-wide v2, v7, p4

    aput-wide v2, p3, p2

    add-int/lit8 p2, p2, 0x1

    goto :goto_2

    :cond_2
    move p3, v0

    :goto_3
    add-int/lit8 v6, v6, 0x1

    move-object p0, v1

    move-object p2, v5

    goto :goto_0

    :cond_3
    return-void
.end method

.method public static multAddColA(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;IDLcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;I[D[I)V
    .locals 8

    .line 101
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->col_idx:[I

    aget v1, v0, p1

    const/4 v2, 0x1

    add-int/2addr p1, v2

    .line 102
    aget p1, v0, p1

    :goto_0
    if-ge v1, p1, :cond_2

    .line 105
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_rows:[I

    aget v0, v0, v1

    .line 107
    aget v3, p7, v0

    if-ge v3, p5, :cond_1

    .line 108
    iget v3, p4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_length:I

    iget-object v4, p4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_rows:[I

    array-length v4, v4

    if-lt v3, v4, :cond_0

    mul-int/lit8 v3, v3, 0x2

    add-int/2addr v3, v2

    .line 109
    invoke-virtual {p4, v3, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->growMaxLength(IZ)V

    .line 112
    :cond_0
    aput p5, p7, v0

    .line 113
    iget-object v3, p4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_rows:[I

    iget v4, p4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_length:I

    aput v0, v3, v4

    .line 114
    iget-object v3, p4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->col_idx:[I

    add-int/2addr v4, v2

    iput v4, p4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_length:I

    aput v4, v3, p5

    .line 115
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_values:[D

    aget-wide v4, v3, v1

    mul-double/2addr v4, p2

    aput-wide v4, p6, v0

    goto :goto_1

    .line 117
    :cond_1
    aget-wide v3, p6, v0

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_values:[D

    aget-wide v6, v5, v1

    mul-double/2addr v6, p2

    add-double/2addr v3, v6

    aput-wide v3, p6, v0

    :goto_1
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_2
    return-void
.end method
