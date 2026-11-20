.class public abstract Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_DDRM;
.super Ljava/lang/Object;
.source "MatrixMatrixMult_DDRM.java"


# direct methods
.method public static multTransB(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;)V
    .locals 19

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

    .line 302
    :goto_0
    const-string v5, "Neither \'A\' or \'B\' can be the same matrix as \'C\'"

    invoke-static {v4, v5}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->assertTrue(ZLjava/lang/String;)V

    .line 303
    iget v4, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    iget v5, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    const-string v6, "The \'A\' and \'B\' matrices do not have compatible dimensions"

    invoke-static {v4, v5, v6}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->assertShape(IILjava/lang/String;)V

    .line 304
    iget v4, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    iget v5, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    invoke-virtual {v2, v4, v5}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->reshape(II)V

    move v4, v3

    .line 307
    :goto_1
    iget v5, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    if-ge v4, v5, :cond_3

    .line 308
    iget v5, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    mul-int/2addr v5, v4

    .line 309
    iget v6, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    mul-int v7, v4, v6

    add-int/2addr v6, v7

    move v8, v3

    move v9, v8

    .line 312
    :goto_2
    iget v10, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    if-ge v8, v10, :cond_2

    const-wide/16 v10, 0x0

    move v12, v7

    :goto_3
    if-ge v12, v6, :cond_1

    .line 317
    iget-object v13, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    add-int/lit8 v14, v12, 0x1

    aget-wide v12, v13, v12

    iget-object v15, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    add-int/lit8 v16, v9, 0x1

    aget-wide v17, v15, v9

    mul-double v12, v12, v17

    add-double/2addr v10, v12

    move v12, v14

    move/from16 v9, v16

    goto :goto_3

    :cond_1
    add-int/lit8 v12, v5, 0x1

    .line 320
    invoke-virtual {v2, v5, v10, v11}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->set(ID)D

    add-int/lit8 v8, v8, 0x1

    move v5, v12

    goto :goto_2

    :cond_2
    add-int/lit8 v4, v4, 0x1

    goto :goto_1

    :cond_3
    return-void
.end method

.method public static mult_reorder(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;)V
    .locals 21

    move-object/from16 v0, p0

    move-object/from16 v1, p1

    move-object/from16 v2, p2

    if-eq v0, v2, :cond_0

    if-eq v1, v2, :cond_0

    const/4 v4, 0x1

    goto :goto_0

    :cond_0
    const/4 v4, 0x0

    .line 67
    :goto_0
    const-string v5, "Neither \'A\' or \'B\' can be the same matrix as \'C\'"

    invoke-static {v4, v5}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->assertTrue(ZLjava/lang/String;)V

    .line 68
    iget v4, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    iget v5, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    const-string v6, "The \'A\' and \'B\' matrices do not have compatible dimensions"

    invoke-static {v4, v5, v6}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->assertShape(IILjava/lang/String;)V

    .line 69
    iget v4, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    iget v5, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    invoke-virtual {v2, v4, v5}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->reshape(II)V

    .line 71
    iget v4, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    if-eqz v4, :cond_6

    iget v4, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    if-nez v4, :cond_1

    goto :goto_5

    .line 75
    :cond_1
    iget v4, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    iget v5, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    mul-int/2addr v4, v5

    const/4 v5, 0x0

    .line 78
    :goto_1
    iget v6, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    if-ge v5, v6, :cond_5

    .line 79
    iget v6, v2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    mul-int/2addr v6, v5

    .line 80
    iget v7, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    mul-int/2addr v7, v5

    .line 85
    iget v8, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    .line 87
    iget-object v9, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    add-int/lit8 v10, v7, 0x1

    aget-wide v11, v9, v7

    move v9, v6

    const/4 v7, 0x0

    :goto_2
    if-ge v7, v8, :cond_2

    add-int/lit8 v13, v9, 0x1

    .line 90
    iget-object v14, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    add-int/lit8 v15, v7, 0x1

    aget-wide v16, v14, v7

    move/from16 v18, v4

    mul-double v3, v11, v16

    invoke-virtual {v2, v9, v3, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->set(ID)D

    move v9, v13

    move v7, v15

    move/from16 v4, v18

    goto :goto_2

    :cond_2
    :goto_3
    if-eq v7, v4, :cond_4

    .line 96
    iget v3, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    add-int/2addr v3, v7

    .line 98
    iget-object v8, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    add-int/lit8 v9, v10, 0x1

    aget-wide v10, v8, v10

    move v8, v6

    :goto_4
    if-ge v7, v3, :cond_3

    .line 101
    iget-object v12, v2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    add-int/lit8 v13, v8, 0x1

    aget-wide v15, v12, v8

    iget-object v14, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    add-int/lit8 v18, v7, 0x1

    aget-wide v19, v14, v7

    mul-double v19, v19, v10

    add-double v15, v15, v19

    aput-wide v15, v12, v8

    move v8, v13

    move/from16 v7, v18

    goto :goto_4

    :cond_3
    move v10, v9

    goto :goto_3

    :cond_4
    add-int/lit8 v5, v5, 0x1

    goto :goto_1

    :cond_5
    return-void

    :cond_6
    :goto_5
    const-wide/16 v0, 0x0

    .line 72
    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/CommonOps_DDRM;->fill(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;D)V

    return-void
.end method

.method public static mult_small(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;)V
    .locals 19

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

    .line 112
    :goto_0
    const-string v5, "Neither \'A\' or \'B\' can be the same matrix as \'C\'"

    invoke-static {v4, v5}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->assertTrue(ZLjava/lang/String;)V

    .line 113
    iget v4, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    iget v5, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    const-string v6, "The \'A\' and \'B\' matrices do not have compatible dimensions"

    invoke-static {v4, v5, v6}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->assertShape(IILjava/lang/String;)V

    .line 114
    iget v4, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    iget v5, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    invoke-virtual {v2, v4, v5}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->reshape(II)V

    move v4, v3

    .line 117
    :goto_1
    iget v5, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    if-ge v4, v5, :cond_3

    .line 118
    iget v5, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    mul-int/2addr v5, v4

    .line 119
    iget v6, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    mul-int/2addr v6, v4

    move v7, v3

    .line 120
    :goto_2
    iget v8, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    if-ge v7, v8, :cond_2

    .line 125
    iget v8, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    add-int/2addr v8, v6

    const-wide/16 v9, 0x0

    move v11, v6

    move v12, v7

    :goto_3
    if-ge v11, v8, :cond_1

    .line 127
    iget-object v13, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    add-int/lit8 v14, v11, 0x1

    aget-wide v15, v13, v11

    iget-object v11, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    aget-wide v17, v11, v12

    mul-double v15, v15, v17

    add-double/2addr v9, v15

    .line 128
    iget v11, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    add-int/2addr v12, v11

    move v11, v14

    goto :goto_3

    :cond_1
    add-int/lit8 v8, v5, 0x1

    .line 131
    invoke-virtual {v2, v5, v9, v10}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->set(ID)D

    add-int/lit8 v7, v7, 0x1

    move v5, v8

    goto :goto_2

    :cond_2
    add-int/lit8 v4, v4, 0x1

    goto :goto_1

    :cond_3
    return-void
.end method
