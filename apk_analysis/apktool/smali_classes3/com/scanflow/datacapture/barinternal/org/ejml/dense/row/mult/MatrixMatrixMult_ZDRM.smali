.class public abstract Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_ZDRM;
.super Ljava/lang/Object;
.source "MatrixMatrixMult_ZDRM.java"


# direct methods
.method public static mult_reorder(Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;)V
    .locals 29

    move-object/from16 v0, p0

    move-object/from16 v1, p1

    move-object/from16 v2, p2

    if-eq v0, v2, :cond_7

    if-eq v1, v2, :cond_7

    .line 43
    iget v3, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numCols:I

    iget v4, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numRows:I

    if-ne v3, v4, :cond_6

    .line 45
    iget v4, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numRows:I

    iget v5, v2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numRows:I

    if-ne v4, v5, :cond_5

    iget v5, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numCols:I

    iget v6, v2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numCols:I

    if-ne v5, v6, :cond_5

    if-eqz v3, :cond_4

    if-nez v4, :cond_0

    goto/16 :goto_3

    .line 54
    :cond_0
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;->getRowStride()I

    move-result v3

    .line 55
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;->getRowStride()I

    move-result v4

    .line 56
    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;->getRowStride()I

    move-result v5

    .line 57
    iget v6, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numRows:I

    mul-int/2addr v6, v4

    const/4 v8, 0x0

    .line 60
    :goto_0
    iget v9, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numRows:I

    if-ge v8, v9, :cond_3

    mul-int v9, v8, v5

    mul-int v10, v8, v3

    .line 70
    iget-object v11, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->data:[D

    add-int/lit8 v12, v10, 0x1

    aget-wide v13, v11, v10

    add-int/lit8 v10, v10, 0x2

    .line 71
    aget-wide v15, v11, v12

    move v12, v9

    const/4 v11, 0x0

    :goto_1
    if-ge v11, v4, :cond_1

    .line 74
    iget-object v7, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->data:[D

    add-int/lit8 v17, v11, 0x1

    aget-wide v18, v7, v11

    add-int/lit8 v11, v11, 0x2

    .line 75
    aget-wide v20, v7, v17

    .line 77
    iget-object v7, v2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->data:[D

    add-int/lit8 v17, v12, 0x1

    mul-double v22, v13, v18

    mul-double v24, v15, v20

    sub-double v22, v22, v24

    aput-wide v22, v7, v12

    add-int/lit8 v12, v12, 0x2

    mul-double v20, v20, v13

    mul-double v18, v18, v15

    add-double v20, v20, v18

    .line 78
    aput-wide v20, v7, v17

    goto :goto_1

    :cond_1
    if-eq v11, v6, :cond_2

    add-int v7, v11, v4

    .line 86
    iget-object v12, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->data:[D

    add-int/lit8 v13, v10, 0x1

    aget-wide v14, v12, v10

    add-int/lit8 v10, v10, 0x2

    .line 87
    aget-wide v17, v12, v13

    move v12, v9

    :goto_2
    if-ge v11, v7, :cond_1

    .line 90
    iget-object v13, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->data:[D

    add-int/lit8 v16, v11, 0x1

    aget-wide v19, v13, v11

    add-int/lit8 v11, v11, 0x2

    .line 91
    aget-wide v21, v13, v16

    .line 93
    iget-object v13, v2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->data:[D

    add-int/lit8 v16, v12, 0x1

    aget-wide v23, v13, v12

    mul-double v25, v14, v19

    mul-double v27, v17, v21

    sub-double v25, v25, v27

    add-double v23, v23, v25

    aput-wide v23, v13, v12

    add-int/lit8 v12, v12, 0x2

    .line 94
    aget-wide v23, v13, v16

    mul-double v21, v21, v14

    mul-double v19, v19, v17

    add-double v21, v21, v19

    add-double v23, v23, v21

    aput-wide v23, v13, v16

    goto :goto_2

    :cond_2
    add-int/lit8 v8, v8, 0x1

    goto :goto_0

    :cond_3
    return-void

    :cond_4
    :goto_3
    const-wide/16 v0, 0x0

    .line 50
    invoke-static {v2, v0, v1, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/CommonOps_ZDRM;->fill(Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;DD)V

    return-void

    .line 46
    :cond_5
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;

    const-string v1, "The results matrix does not have the desired dimensions"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 44
    :cond_6
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;

    const-string v1, "The \'a\' and \'b\' matrices do not have compatible dimensions"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 42
    :cond_7
    new-instance v0, Ljava/lang/IllegalArgumentException;

    const-string v1, "Neither \'a\' or \'b\' can be the same matrix as \'c\'"

    invoke-direct {v0, v1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method public static mult_small(Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;)V
    .locals 30

    move-object/from16 v0, p0

    move-object/from16 v1, p1

    move-object/from16 v2, p2

    if-eq v0, v2, :cond_5

    if-eq v1, v2, :cond_5

    .line 104
    iget v3, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numCols:I

    iget v4, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numRows:I

    if-ne v3, v4, :cond_4

    .line 106
    iget v3, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numRows:I

    iget v4, v2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numRows:I

    if-ne v3, v4, :cond_3

    iget v3, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numCols:I

    iget v4, v2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numCols:I

    if-ne v3, v4, :cond_3

    .line 110
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;->getRowStride()I

    move-result v3

    .line 111
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;->getRowStride()I

    move-result v4

    const/4 v6, 0x0

    .line 114
    :goto_0
    iget v7, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numRows:I

    if-ge v6, v7, :cond_2

    mul-int v7, v6, v3

    mul-int v8, v6, v4

    const/4 v9, 0x0

    .line 117
    :goto_1
    iget v10, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numCols:I

    if-ge v9, v10, :cond_1

    mul-int/lit8 v10, v9, 0x2

    add-int v11, v7, v3

    const-wide/16 v12, 0x0

    move v5, v7

    move-wide v14, v12

    :goto_2
    if-ge v5, v11, :cond_0

    move/from16 v16, v3

    .line 125
    iget-object v3, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->data:[D

    add-int/lit8 v17, v5, 0x1

    aget-wide v18, v3, v5

    add-int/lit8 v5, v5, 0x2

    .line 126
    aget-wide v20, v3, v17

    .line 128
    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->data:[D

    aget-wide v22, v3, v10

    add-int/lit8 v17, v10, 0x1

    .line 129
    aget-wide v24, v3, v17

    mul-double v26, v18, v22

    mul-double v28, v20, v24

    sub-double v26, v26, v28

    add-double v12, v12, v26

    mul-double v18, v18, v24

    mul-double v20, v20, v22

    add-double v18, v18, v20

    add-double v14, v14, v18

    add-int/2addr v10, v4

    move/from16 v3, v16

    goto :goto_2

    :cond_0
    move/from16 v16, v3

    .line 137
    iget-object v3, v2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->data:[D

    add-int/lit8 v5, v8, 0x1

    aput-wide v12, v3, v8

    add-int/lit8 v8, v8, 0x2

    .line 138
    aput-wide v14, v3, v5

    add-int/lit8 v9, v9, 0x1

    move/from16 v3, v16

    goto :goto_1

    :cond_1
    move/from16 v16, v3

    add-int/lit8 v6, v6, 0x1

    goto :goto_0

    :cond_2
    return-void

    .line 107
    :cond_3
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;

    const-string v1, "The results matrix does not have the desired dimensions"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 105
    :cond_4
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;

    const-string v1, "The \'a\' and \'b\' matrices do not have compatible dimensions"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 103
    :cond_5
    new-instance v0, Ljava/lang/IllegalArgumentException;

    const-string v1, "Neither \'a\' or \'b\' can be the same matrix as \'c\'"

    invoke-direct {v0, v1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0
.end method
