.class public abstract Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/ImplMultiplication_MT_FSCC;
.super Ljava/lang/Object;
.source "ImplMultiplication_MT_FSCC.java"


# direct methods
.method public static synthetic $r8$lambda$7c66ZP4n2dqp4sSNt5qn_2M53ps(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/Workspace_MT_FSCC;II)V
    .locals 10

    .line 59
    iget-object v3, p2, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/Workspace_MT_FSCC;->mat:Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;

    .line 60
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numRows:I

    sub-int v1, p4, p3

    invoke-virtual {v3, v0, v1, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->reshape(III)V

    .line 61
    iget-object v0, v3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->col_idx:[I

    const/4 v1, 0x0

    aput v1, v0, v1

    .line 63
    iget-object v0, p2, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/Workspace_MT_FSCC;->gx:Lcom/scanflow/datacapture/barinternal/org/ejml/data/FGrowArray;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numRows:I

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->adjust(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FGrowArray;I)[F

    move-result-object v5

    .line 64
    iget-object p2, p2, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/Workspace_MT_FSCC;->gw:Lcom/scanflow/datacapture/barinternal/org/ejml/data/IGrowArray;

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numRows:I

    invoke-static {p2, v0, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->adjust(Lcom/scanflow/datacapture/barinternal/org/ejml/data/IGrowArray;II)[I

    move-result-object v6

    move p2, p3

    :goto_0
    if-ge p2, p4, :cond_3

    sub-int v7, p2, p3

    .line 69
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->col_idx:[I

    aget v1, v0, p2

    add-int/lit8 p2, p2, 0x1

    .line 70
    aget v8, v0, p2

    .line 71
    iget-object v0, v3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->col_idx:[I

    add-int/lit8 v4, v7, 0x1

    iget v2, v3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_length:I

    aput v2, v0, v4

    if-ne v1, v8, :cond_0

    move-object v0, p0

    goto :goto_3

    :cond_0
    move v9, v1

    :goto_1
    if-ge v9, v8, :cond_1

    .line 79
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_rows:[I

    aget v1, v0, v9

    .line 80
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_values:[F

    aget v2, v0, v9

    move-object v0, p0

    .line 82
    invoke-static/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/ImplMultiplication_FSCC;->multAddColA(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;IFLcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;I[F[I)V

    add-int/lit8 v9, v9, 0x1

    goto :goto_1

    :cond_1
    move-object v0, p0

    .line 86
    iget-object p0, v3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->col_idx:[I

    aget v1, p0, v7

    .line 87
    aget p0, p0, v4

    :goto_2
    if-ge v1, p0, :cond_2

    .line 90
    iget-object v2, v3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_values:[F

    iget-object v4, v3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_rows:[I

    aget v4, v4, v1

    aget v4, v5, v4

    aput v4, v2, v1

    add-int/lit8 v1, v1, 0x1

    goto :goto_2

    :cond_2
    :goto_3
    move-object p0, v0

    goto :goto_0

    :cond_3
    return-void
.end method

.method public static mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V
    .locals 3

    .line 58
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numCols:I

    new-instance v1, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/ImplMultiplication_MT_FSCC$$ExternalSyntheticLambda0;

    invoke-direct {v1, p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/ImplMultiplication_MT_FSCC$$ExternalSyntheticLambda0;-><init>(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;)V

    const/4 v2, 0x0

    invoke-static {v2, v0, p3, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopBlocks(IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntRangeObjectConsumer;)V

    .line 96
    iget p0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numRows:I

    iget p1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numCols:I

    invoke-static {p2, p0, p1, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/ImplMultiplication_MT_FSCC;->stitchMatrix(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V

    return-void
.end method

.method public static stitchMatrix(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V
    .locals 8

    .line 104
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->reshape(II)V

    const/4 p1, 0x0

    .line 105
    iput-boolean p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->indicesSorted:Z

    .line 106
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_length:I

    move v0, p1

    .line 108
    :goto_0
    invoke-virtual {p3}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->size()I

    move-result v1

    if-ge v0, v1, :cond_0

    .line 109
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_length:I

    invoke-virtual {p3, v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->get(I)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/Workspace_MT_FSCC;

    iget-object v2, v2, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/Workspace_MT_FSCC;->mat:Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;

    iget v2, v2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_length:I

    add-int/2addr v1, v2

    iput v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_length:I

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    .line 111
    :cond_0
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_length:I

    invoke-virtual {p0, v0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->growMaxLength(IZ)V

    .line 113
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_length:I

    .line 114
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numCols:I

    .line 115
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->col_idx:[I

    aput p1, v0, p1

    move v0, p1

    .line 116
    :goto_1
    invoke-virtual {p3}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->size()I

    move-result v1

    if-ge v0, v1, :cond_2

    .line 117
    invoke-virtual {p3, v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->get(I)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/Workspace_MT_FSCC;

    .line 119
    iget-object v2, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/Workspace_MT_FSCC;->mat:Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;

    iget-object v3, v2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_rows:[I

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_rows:[I

    iget v5, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_length:I

    iget v2, v2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_length:I

    invoke-static {v3, p1, v4, v5, v2}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    .line 120
    iget-object v2, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/Workspace_MT_FSCC;->mat:Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;

    iget-object v3, v2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_values:[F

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_values:[F

    iget v5, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_length:I

    iget v2, v2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_length:I

    invoke-static {v3, p1, v4, v5, v2}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    const/4 v2, 0x1

    move v3, v2

    .line 122
    :goto_2
    iget-object v4, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/Workspace_MT_FSCC;->mat:Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;

    iget v5, v4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numCols:I

    if-gt v3, v5, :cond_1

    .line 123
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->col_idx:[I

    iget v6, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numCols:I

    add-int/2addr v6, v2

    iput v6, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numCols:I

    iget v7, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_length:I

    iget-object v4, v4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->col_idx:[I

    aget v4, v4, v3

    add-int/2addr v7, v4

    aput v7, v5, v6

    add-int/lit8 v3, v3, 0x1

    goto :goto_2

    .line 126
    :cond_1
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_length:I

    iget v2, v4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_length:I

    add-int/2addr v1, v2

    iput v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_length:I

    add-int/lit8 v0, v0, 0x1

    goto :goto_1

    .line 130
    :cond_2
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numCols:I

    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->assertEq(II)V

    .line 131
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->col_idx:[I

    aget p1, p1, p2

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_length:I

    invoke-static {p1, p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->assertEq(II)V

    return-void
.end method
