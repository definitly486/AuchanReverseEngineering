.class public abstract Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/misc/TransposeAlgs_DDRM;
.super Ljava/lang/Object;
.source "TransposeAlgs_DDRM.java"


# direct methods
.method public static block(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;I)V
    .locals 18

    move-object/from16 v0, p0

    move-object/from16 v1, p1

    move/from16 v2, p2

    const/4 v3, 0x0

    move v4, v3

    .line 70
    :goto_0
    iget v5, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    if-ge v4, v5, :cond_3

    add-int v6, v4, v2

    .line 72
    invoke-static {v5, v6}, Ljava/lang/Math;->min(II)I

    move-result v5

    sub-int/2addr v5, v4

    .line 75
    iget v7, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    mul-int/2addr v7, v4

    move v8, v3

    .line 78
    :goto_1
    iget v9, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    if-ge v8, v9, :cond_2

    sub-int/2addr v9, v8

    .line 79
    invoke-static {v2, v9}, Ljava/lang/Math;->min(II)I

    move-result v9

    add-int/2addr v9, v7

    :goto_2
    if-ge v7, v9, :cond_1

    add-int v10, v4, v5

    move v11, v4

    move v12, v7

    :goto_3
    if-ge v11, v10, :cond_0

    .line 93
    iget-object v13, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    add-int/lit8 v14, v11, 0x1

    iget-object v15, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    aget-wide v16, v15, v12

    aput-wide v16, v13, v11

    .line 91
    iget v11, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    add-int/2addr v12, v11

    move v11, v14

    goto :goto_3

    .line 95
    :cond_0
    iget v10, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    add-int/2addr v4, v10

    add-int/lit8 v7, v7, 0x1

    goto :goto_2

    :cond_1
    add-int/2addr v8, v2

    goto :goto_1

    :cond_2
    move v4, v6

    goto :goto_0

    :cond_3
    return-void
.end method

.method public static square(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;)V
    .locals 9

    const/4 v0, 0x0

    .line 41
    :goto_0
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    if-ge v0, v1, :cond_1

    .line 42
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    mul-int v2, v0, v1

    add-int/2addr v2, v0

    add-int/lit8 v2, v2, 0x1

    add-int/lit8 v3, v0, 0x1

    mul-int v4, v3, v1

    mul-int/2addr v1, v3

    :goto_1
    add-int/2addr v1, v0

    if-ge v2, v4, :cond_0

    .line 47
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    aget-wide v5, v0, v2

    .line 48
    aget-wide v7, v0, v1

    aput-wide v7, v0, v2

    .line 49
    aput-wide v5, v0, v1

    add-int/lit8 v2, v2, 0x1

    .line 46
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    goto :goto_1

    :cond_0
    move v0, v3

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static standard(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;)V
    .locals 9

    const/4 v0, 0x0

    .line 110
    :goto_0
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    if-ge v0, v1, :cond_1

    .line 111
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    mul-int v2, v0, v1

    add-int/2addr v1, v2

    move v3, v0

    :goto_1
    if-ge v2, v1, :cond_0

    .line 116
    iget-object v4, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    add-int/lit8 v5, v2, 0x1

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    aget-wide v7, v6, v3

    aput-wide v7, v4, v2

    .line 117
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    add-int/2addr v3, v2

    move v2, v5

    goto :goto_1

    :cond_0
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method
