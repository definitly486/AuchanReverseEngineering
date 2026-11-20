.class public abstract Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_DDRM;
.super Ljava/lang/Object;
.source "MatrixMatrixMult_MT_DDRM.java"


# direct methods
.method public static synthetic $r8$lambda$LYUuLw1-rM-TAlPmjyjOrARa8xw(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;II)V
    .locals 19

    move-object/from16 v0, p0

    move-object/from16 v1, p1

    move-object/from16 v2, p2

    .line 78
    iget v3, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    mul-int v3, v3, p4

    .line 79
    iget v4, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    mul-int v4, v4, p4

    .line 84
    iget v5, v2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    .line 86
    iget-object v6, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    add-int/lit8 v7, v4, 0x1

    aget-wide v8, v6, v4

    const/4 v4, 0x0

    move v6, v3

    :goto_0
    if-ge v4, v5, :cond_0

    add-int/lit8 v10, v6, 0x1

    .line 89
    iget-object v11, v2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    add-int/lit8 v12, v4, 0x1

    aget-wide v13, v11, v4

    mul-double/2addr v13, v8

    invoke-virtual {v0, v6, v13, v14}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->set(ID)D

    move v6, v10

    move v4, v12

    goto :goto_0

    :cond_0
    move/from16 v5, p3

    :goto_1
    if-eq v4, v5, :cond_2

    .line 95
    iget v6, v2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    add-int/2addr v6, v4

    .line 97
    iget-object v8, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    add-int/lit8 v9, v7, 0x1

    aget-wide v7, v8, v7

    move v10, v3

    :goto_2
    if-ge v4, v6, :cond_1

    .line 100
    iget-object v11, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    add-int/lit8 v12, v10, 0x1

    aget-wide v13, v11, v10

    iget-object v15, v2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    add-int/lit8 v16, v4, 0x1

    aget-wide v17, v15, v4

    mul-double v17, v17, v7

    add-double v13, v13, v17

    aput-wide v13, v11, v10

    move v10, v12

    move/from16 v4, v16

    goto :goto_2

    :cond_1
    move v7, v9

    goto :goto_1

    :cond_2
    return-void
.end method

.method public static mult_reorder(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;)V
    .locals 4

    const/4 v0, 0x0

    if-eq p0, p2, :cond_0

    if-eq p1, p2, :cond_0

    const/4 v1, 0x1

    goto :goto_0

    :cond_0
    move v1, v0

    .line 67
    :goto_0
    const-string v2, "Neither \'A\' or \'B\' can be the same matrix as \'C\'"

    invoke-static {v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->assertTrue(ZLjava/lang/String;)V

    .line 68
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    const-string v3, "The \'A\' and \'B\' matrices do not have compatible dimensions"

    invoke-static {v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->assertShape(IILjava/lang/String;)V

    .line 69
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    invoke-virtual {p2, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->reshape(II)V

    .line 71
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    if-eqz v1, :cond_2

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    if-nez v1, :cond_1

    goto :goto_1

    .line 75
    :cond_1
    iget v2, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    iget v3, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    mul-int/2addr v2, v3

    .line 77
    new-instance v3, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_DDRM$$ExternalSyntheticLambda0;

    invoke-direct {v3, p2, p0, p1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_DDRM$$ExternalSyntheticLambda0;-><init>(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;I)V

    invoke-static {v0, v1, v3}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void

    :cond_2
    :goto_1
    const-wide/16 p0, 0x0

    .line 72
    invoke-static {p2, p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/CommonOps_DDRM;->fill(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;D)V

    return-void
.end method
