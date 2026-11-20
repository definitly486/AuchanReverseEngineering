.class public abstract Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixVectorMult_DDRM;
.super Ljava/lang/Object;
.source "MatrixVectorMult_DDRM.java"


# direct methods
.method public static mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;)V
    .locals 17

    move-object/from16 v0, p0

    move-object/from16 v1, p1

    move-object/from16 v2, p2

    .line 63
    iget v3, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    const-string v4, "A and B are not compatible"

    const/4 v5, 0x1

    if-ne v3, v5, :cond_1

    .line 64
    iget v3, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    iget v6, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    if-ne v3, v6, :cond_0

    goto :goto_0

    .line 65
    :cond_0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;

    invoke-direct {v0, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 67
    :cond_1
    iget v6, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    if-ne v6, v5, :cond_6

    .line 68
    iget v6, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    if-ne v6, v3, :cond_5

    .line 74
    :goto_0
    iget v3, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    invoke-virtual {v2, v3, v5}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->reshape(II)V

    .line 76
    iget v3, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    if-nez v3, :cond_2

    const-wide/16 v0, 0x0

    .line 77
    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/CommonOps_DDRM;->fill(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;D)V

    return-void

    :cond_2
    const/4 v3, 0x0

    .line 83
    invoke-virtual {v1, v3}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->get(I)D

    move-result-wide v6

    move v4, v3

    move v8, v4

    .line 84
    :goto_1
    iget v9, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    if-ge v3, v9, :cond_4

    add-int/lit8 v9, v4, 0x1

    .line 85
    invoke-virtual {v0, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->get(I)D

    move-result-wide v10

    mul-double/2addr v10, v6

    move v4, v9

    move v9, v5

    .line 87
    :goto_2
    iget v12, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    if-ge v9, v12, :cond_3

    add-int/lit8 v12, v4, 0x1

    .line 88
    invoke-virtual {v0, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->get(I)D

    move-result-wide v13

    invoke-virtual {v1, v9}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->get(I)D

    move-result-wide v15

    mul-double/2addr v13, v15

    add-double/2addr v10, v13

    add-int/lit8 v9, v9, 0x1

    move v4, v12

    goto :goto_2

    :cond_3
    add-int/lit8 v9, v8, 0x1

    .line 91
    invoke-virtual {v2, v8, v10, v11}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->set(ID)D

    add-int/lit8 v3, v3, 0x1

    move v8, v9

    goto :goto_1

    :cond_4
    return-void

    .line 69
    :cond_5
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;

    invoke-direct {v0, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 72
    :cond_6
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;

    const-string v1, "B is not a vector"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;-><init>(Ljava/lang/String;)V

    throw v0
.end method
