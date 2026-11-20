.class public abstract Lcom/scanflow/datacapture/barinternal/org/ejml/ops/FConvertMatrixStruct;
.super Ljava/lang/Object;
.source "FConvertMatrixStruct.java"


# direct methods
.method public static convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;)Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;
    .locals 6

    if-nez p1, :cond_0

    .line 794
    new-instance p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numRows:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numCols:I

    invoke-direct {p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;-><init>(II)V

    goto :goto_0

    .line 796
    :cond_0
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numRows:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numCols:I

    invoke-virtual {p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->reshape(II)V

    .line 797
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;->zero()V

    .line 800
    :goto_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->col_idx:[I

    const/4 v1, 0x0

    aget v0, v0, v1

    const/4 v1, 0x1

    .line 801
    :goto_1
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numCols:I

    if-gt v1, v2, :cond_2

    .line 802
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->col_idx:[I

    aget v2, v2, v1

    :goto_2
    if-ge v0, v2, :cond_1

    .line 805
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_rows:[I

    aget v3, v3, v0

    .line 806
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->nz_values:[F

    aget v4, v4, v0

    add-int/lit8 v5, v1, -0x1

    .line 808
    invoke-virtual {p1, v3, v5, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;->unsafe_set(IIF)V

    add-int/lit8 v0, v0, 0x1

    goto :goto_2

    :cond_1
    add-int/lit8 v1, v1, 0x1

    move v0, v2

    goto :goto_1

    :cond_2
    return-object p1
.end method

.method public static convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;)V
    .locals 4

    .line 43
    instance-of v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ReshapeMatrix;

    if-eqz v0, :cond_0

    .line 44
    move-object v0, p1

    check-cast v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ReshapeMatrix;

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v1

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v2

    invoke-interface {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ReshapeMatrix;->reshape(II)V

    goto :goto_0

    .line 46
    :cond_0
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v0

    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v1

    if-ne v0, v1, :cond_4

    .line 48
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v0

    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v1

    if-ne v0, v1, :cond_3

    :goto_0
    const/4 v0, 0x0

    move v1, v0

    .line 52
    :goto_1
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v2

    if-ge v1, v2, :cond_2

    move v2, v0

    .line 53
    :goto_2
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v3

    if-ge v2, v3, :cond_1

    .line 54
    invoke-interface {p0, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;->unsafe_get(II)F

    move-result v3

    invoke-interface {p1, v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;->unsafe_set(IIF)V

    add-int/lit8 v2, v2, 0x1

    goto :goto_2

    :cond_1
    add-int/lit8 v1, v1, 0x1

    goto :goto_1

    :cond_2
    return-void

    .line 49
    :cond_3
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Number of columns do not match"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0

    .line 47
    :cond_4
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Number of rows do not match"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method
