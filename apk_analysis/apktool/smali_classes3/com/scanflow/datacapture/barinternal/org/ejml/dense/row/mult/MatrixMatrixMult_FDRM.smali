.class public abstract Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_FDRM;
.super Ljava/lang/Object;
.source "MatrixMatrixMult_FDRM.java"


# direct methods
.method public static mult_reorder(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix1Row;)V
    .locals 17

    move-object/from16 v0, p0

    move-object/from16 v1, p1

    move-object/from16 v2, p2

    const/4 v3, 0x0

    if-eq v0, v2, :cond_0

    if-eq v1, v2, :cond_0

    const/4 v4, 0x1

    goto :goto_0

    :cond_0
    move v4, v3

    .line 67
    :goto_0
    const-string v5, "Neither \'A\' or \'B\' can be the same matrix as \'C\'"

    invoke-static {v4, v5}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->assertTrue(ZLjava/lang/String;)V

    .line 68
    iget v4, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numCols:I

    iget v5, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numRows:I

    const-string v6, "The \'A\' and \'B\' matrices do not have compatible dimensions"

    invoke-static {v4, v5, v6}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->assertShape(IILjava/lang/String;)V

    .line 69
    iget v4, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numRows:I

    iget v5, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numCols:I

    invoke-virtual {v2, v4, v5}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->reshape(II)V

    .line 71
    iget v4, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numCols:I

    if-eqz v4, :cond_6

    iget v4, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numRows:I

    if-nez v4, :cond_1

    goto :goto_5

    .line 75
    :cond_1
    iget v4, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numRows:I

    iget v5, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numCols:I

    mul-int/2addr v4, v5

    move v5, v3

    .line 78
    :goto_1
    iget v6, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numRows:I

    if-ge v5, v6, :cond_5

    .line 79
    iget v6, v2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numCols:I

    mul-int/2addr v6, v5

    .line 80
    iget v7, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numCols:I

    mul-int/2addr v7, v5

    .line 85
    iget v8, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numCols:I

    .line 87
    iget-object v9, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->data:[F

    add-int/lit8 v10, v7, 0x1

    aget v7, v9, v7

    move v9, v3

    move v11, v6

    :goto_2
    if-ge v9, v8, :cond_2

    add-int/lit8 v12, v11, 0x1

    .line 90
    iget-object v13, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->data:[F

    add-int/lit8 v14, v9, 0x1

    aget v9, v13, v9

    mul-float/2addr v9, v7

    invoke-virtual {v2, v11, v9}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->set(IF)F

    move v11, v12

    move v9, v14

    goto :goto_2

    :cond_2
    :goto_3
    if-eq v9, v4, :cond_4

    .line 96
    iget v7, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numCols:I

    add-int/2addr v7, v9

    .line 98
    iget-object v8, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->data:[F

    add-int/lit8 v11, v10, 0x1

    aget v8, v8, v10

    move v10, v6

    :goto_4
    if-ge v9, v7, :cond_3

    .line 101
    iget-object v12, v2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->data:[F

    add-int/lit8 v13, v10, 0x1

    aget v14, v12, v10

    iget-object v15, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->data:[F

    add-int/lit8 v16, v9, 0x1

    aget v9, v15, v9

    mul-float/2addr v9, v8

    add-float/2addr v14, v9

    aput v14, v12, v10

    move v10, v13

    move/from16 v9, v16

    goto :goto_4

    :cond_3
    move v10, v11

    goto :goto_3

    :cond_4
    add-int/lit8 v5, v5, 0x1

    goto :goto_1

    :cond_5
    return-void

    :cond_6
    :goto_5
    const/4 v0, 0x0

    .line 72
    invoke-static {v2, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/CommonOps_FDRM;->fill(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;F)V

    return-void
.end method

.method public static mult_small(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix1Row;)V
    .locals 11

    const/4 v0, 0x0

    if-eq p0, p2, :cond_0

    if-eq p1, p2, :cond_0

    const/4 v1, 0x1

    goto :goto_0

    :cond_0
    move v1, v0

    .line 112
    :goto_0
    const-string v2, "Neither \'A\' or \'B\' can be the same matrix as \'C\'"

    invoke-static {v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->assertTrue(ZLjava/lang/String;)V

    .line 113
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numCols:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numRows:I

    const-string v3, "The \'A\' and \'B\' matrices do not have compatible dimensions"

    invoke-static {v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->assertShape(IILjava/lang/String;)V

    .line 114
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numRows:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numCols:I

    invoke-virtual {p2, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->reshape(II)V

    move v1, v0

    .line 117
    :goto_1
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numRows:I

    if-ge v1, v2, :cond_3

    .line 118
    iget v2, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numCols:I

    mul-int/2addr v2, v1

    .line 119
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numCols:I

    mul-int/2addr v3, v1

    move v4, v0

    .line 120
    :goto_2
    iget v5, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numCols:I

    if-ge v4, v5, :cond_2

    .line 125
    iget v5, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numRows:I

    add-int/2addr v5, v3

    const/4 v6, 0x0

    move v7, v3

    move v8, v4

    :goto_3
    if-ge v7, v5, :cond_1

    .line 127
    iget-object v9, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->data:[F

    add-int/lit8 v10, v7, 0x1

    aget v7, v9, v7

    iget-object v9, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->data:[F

    aget v9, v9, v8

    mul-float/2addr v7, v9

    add-float/2addr v6, v7

    .line 128
    iget v7, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numCols:I

    add-int/2addr v8, v7

    move v7, v10

    goto :goto_3

    :cond_1
    add-int/lit8 v5, v2, 0x1

    .line 131
    invoke-virtual {p2, v2, v6}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->set(IF)F

    add-int/lit8 v4, v4, 0x1

    move v2, v5

    goto :goto_2

    :cond_2
    add-int/lit8 v1, v1, 0x1

    goto :goto_1

    :cond_3
    return-void
.end method
