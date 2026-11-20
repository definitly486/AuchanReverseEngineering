.class public abstract Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_FDRM;
.super Ljava/lang/Object;
.source "MatrixMatrixMult_MT_FDRM.java"


# direct methods
.method public static synthetic $r8$lambda$rwB1Fa91jozVpSQroAA-VLQaMHw(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix1Row;II)V
    .locals 10

    .line 78
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numCols:I

    mul-int/2addr v0, p4

    .line 79
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numCols:I

    mul-int/2addr p4, v1

    .line 84
    iget v1, p2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numCols:I

    .line 86
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->data:[F

    add-int/lit8 v3, p4, 0x1

    aget p4, v2, p4

    const/4 v2, 0x0

    move v4, v0

    :goto_0
    if-ge v2, v1, :cond_0

    add-int/lit8 v5, v4, 0x1

    .line 89
    iget-object v6, p2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->data:[F

    add-int/lit8 v7, v2, 0x1

    aget v2, v6, v2

    mul-float/2addr v2, p4

    invoke-virtual {p0, v4, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->set(IF)F

    move v4, v5

    move v2, v7

    goto :goto_0

    :cond_0
    :goto_1
    if-eq v2, p3, :cond_2

    .line 95
    iget p4, p2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numCols:I

    add-int/2addr p4, v2

    .line 97
    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->data:[F

    add-int/lit8 v4, v3, 0x1

    aget v1, v1, v3

    move v3, v0

    :goto_2
    if-ge v2, p4, :cond_1

    .line 100
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->data:[F

    add-int/lit8 v6, v3, 0x1

    aget v7, v5, v3

    iget-object v8, p2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->data:[F

    add-int/lit8 v9, v2, 0x1

    aget v2, v8, v2

    mul-float/2addr v2, v1

    add-float/2addr v7, v2

    aput v7, v5, v3

    move v3, v6

    move v2, v9

    goto :goto_2

    :cond_1
    move v3, v4

    goto :goto_1

    :cond_2
    return-void
.end method

.method public static mult_reorder(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix1Row;)V
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
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numCols:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numRows:I

    const-string v3, "The \'A\' and \'B\' matrices do not have compatible dimensions"

    invoke-static {v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->assertShape(IILjava/lang/String;)V

    .line 69
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numRows:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numCols:I

    invoke-virtual {p2, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->reshape(II)V

    .line 71
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numCols:I

    if-eqz v1, :cond_2

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numRows:I

    if-nez v1, :cond_1

    goto :goto_1

    .line 75
    :cond_1
    iget v2, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numRows:I

    iget v3, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numCols:I

    mul-int/2addr v2, v3

    .line 77
    new-instance v3, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_FDRM$$ExternalSyntheticLambda0;

    invoke-direct {v3, p2, p0, p1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_FDRM$$ExternalSyntheticLambda0;-><init>(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix1Row;I)V

    invoke-static {v0, v1, v3}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void

    :cond_2
    :goto_1
    const/4 p0, 0x0

    .line 72
    invoke-static {p2, p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/CommonOps_FDRM;->fill(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;F)V

    return-void
.end method
