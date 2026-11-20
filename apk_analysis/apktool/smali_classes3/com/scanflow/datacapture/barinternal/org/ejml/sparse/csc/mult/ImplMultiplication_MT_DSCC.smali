.class public abstract Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/ImplMultiplication_MT_DSCC;
.super Ljava/lang/Object;
.source "ImplMultiplication_MT_DSCC.java"


# direct methods
.method public static synthetic $r8$lambda$Xc9PSBNyxiepKsGHeJXRME-MlpY(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/Workspace_MT_DSCC;II)V
    .locals 11

    .line 57
    iget-object v4, p2, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/Workspace_MT_DSCC;->mat:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;

    .line 58
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->numRows:I

    sub-int v1, p4, p3

    invoke-virtual {v4, v0, v1, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->reshape(III)V

    .line 59
    iget-object v0, v4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->col_idx:[I

    const/4 v1, 0x0

    aput v1, v0, v1

    .line 61
    iget-object v0, p2, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/Workspace_MT_DSCC;->gx:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DGrowArray;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->numRows:I

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->adjust(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DGrowArray;I)[D

    move-result-object v6

    .line 62
    iget-object p2, p2, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/Workspace_MT_DSCC;->gw:Lcom/scanflow/datacapture/barinternal/org/ejml/data/IGrowArray;

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->numRows:I

    invoke-static {p2, v0, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->adjust(Lcom/scanflow/datacapture/barinternal/org/ejml/data/IGrowArray;II)[I

    move-result-object v7

    move p2, p3

    :goto_0
    if-ge p2, p4, :cond_3

    sub-int v8, p2, p3

    .line 67
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->col_idx:[I

    aget v1, v0, p2

    add-int/lit8 p2, p2, 0x1

    .line 68
    aget v9, v0, p2

    .line 69
    iget-object v0, v4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->col_idx:[I

    add-int/lit8 v5, v8, 0x1

    iget v2, v4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_length:I

    aput v2, v0, v5

    if-ne v1, v9, :cond_0

    move-object v0, p0

    goto :goto_3

    :cond_0
    move v10, v1

    :goto_1
    if-ge v10, v9, :cond_1

    .line 77
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_rows:[I

    aget v1, v0, v10

    .line 78
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_values:[D

    aget-wide v2, v0, v10

    move-object v0, p0

    .line 80
    invoke-static/range {v0 .. v7}, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/ImplMultiplication_DSCC;->multAddColA(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;IDLcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;I[D[I)V

    add-int/lit8 v10, v10, 0x1

    goto :goto_1

    :cond_1
    move-object v0, p0

    .line 84
    iget-object p0, v4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->col_idx:[I

    aget v1, p0, v8

    .line 85
    aget p0, p0, v5

    :goto_2
    if-ge v1, p0, :cond_2

    .line 88
    iget-object v2, v4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_values:[D

    iget-object v3, v4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_rows:[I

    aget v3, v3, v1

    aget-wide v8, v6, v3

    aput-wide v8, v2, v1

    add-int/lit8 v1, v1, 0x1

    goto :goto_2

    :cond_2
    :goto_3
    move-object p0, v0

    goto :goto_0

    :cond_3
    return-void
.end method

.method public static mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V
    .locals 3

    .line 56
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->numCols:I

    new-instance v1, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/ImplMultiplication_MT_DSCC$$ExternalSyntheticLambda0;

    invoke-direct {v1, p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/ImplMultiplication_MT_DSCC$$ExternalSyntheticLambda0;-><init>(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;)V

    const/4 v2, 0x0

    invoke-static {v2, v0, p3, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopBlocks(IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntRangeObjectConsumer;)V

    .line 94
    iget p0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->numRows:I

    iget p1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->numCols:I

    invoke-static {p2, p0, p1, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/ImplMultiplication_MT_DSCC;->stitchMatrix(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V

    return-void
.end method

.method public static stitchMatrix(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V
    .locals 8

    .line 102
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->reshape(II)V

    const/4 p1, 0x0

    .line 103
    iput-boolean p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->indicesSorted:Z

    .line 104
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_length:I

    move v0, p1

    .line 106
    :goto_0
    invoke-virtual {p3}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->size()I

    move-result v1

    if-ge v0, v1, :cond_0

    .line 107
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_length:I

    invoke-virtual {p3, v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->get(I)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/Workspace_MT_DSCC;

    iget-object v2, v2, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/Workspace_MT_DSCC;->mat:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;

    iget v2, v2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_length:I

    add-int/2addr v1, v2

    iput v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_length:I

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    .line 109
    :cond_0
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_length:I

    invoke-virtual {p0, v0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->growMaxLength(IZ)V

    .line 111
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_length:I

    .line 112
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->numCols:I

    .line 113
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->col_idx:[I

    aput p1, v0, p1

    move v0, p1

    .line 114
    :goto_1
    invoke-virtual {p3}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->size()I

    move-result v1

    if-ge v0, v1, :cond_2

    .line 115
    invoke-virtual {p3, v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->get(I)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/Workspace_MT_DSCC;

    .line 117
    iget-object v2, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/Workspace_MT_DSCC;->mat:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;

    iget-object v3, v2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_rows:[I

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_rows:[I

    iget v5, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_length:I

    iget v2, v2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_length:I

    invoke-static {v3, p1, v4, v5, v2}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    .line 118
    iget-object v2, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/Workspace_MT_DSCC;->mat:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;

    iget-object v3, v2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_values:[D

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_values:[D

    iget v5, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_length:I

    iget v2, v2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_length:I

    invoke-static {v3, p1, v4, v5, v2}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    const/4 v2, 0x1

    move v3, v2

    .line 120
    :goto_2
    iget-object v4, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/Workspace_MT_DSCC;->mat:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;

    iget v5, v4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->numCols:I

    if-gt v3, v5, :cond_1

    .line 121
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->col_idx:[I

    iget v6, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->numCols:I

    add-int/2addr v6, v2

    iput v6, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->numCols:I

    iget v7, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_length:I

    iget-object v4, v4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->col_idx:[I

    aget v4, v4, v3

    add-int/2addr v7, v4

    aput v7, v5, v6

    add-int/lit8 v3, v3, 0x1

    goto :goto_2

    .line 124
    :cond_1
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_length:I

    iget v2, v4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_length:I

    add-int/2addr v1, v2

    iput v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_length:I

    add-int/lit8 v0, v0, 0x1

    goto :goto_1

    .line 128
    :cond_2
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->numCols:I

    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->assertEq(II)V

    .line 129
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->col_idx:[I

    aget p1, p1, p2

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->nz_length:I

    invoke-static {p1, p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->assertEq(II)V

    return-void
.end method
