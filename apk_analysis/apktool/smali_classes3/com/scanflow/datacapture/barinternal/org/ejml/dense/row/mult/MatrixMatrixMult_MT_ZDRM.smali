.class public abstract Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_ZDRM;
.super Ljava/lang/Object;
.source "MatrixMatrixMult_MT_ZDRM.java"


# direct methods
.method public static synthetic $r8$lambda$1YauJERjRxWy3_B7m63We9q4eq8(IIILcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;II)V
    .locals 26

    move/from16 v0, p2

    move-object/from16 v1, p3

    move-object/from16 v2, p4

    move-object/from16 v3, p5

    mul-int v4, p7, p0

    mul-int v5, p7, p1

    .line 69
    iget-object v6, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->data:[D

    add-int/lit8 v7, v5, 0x1

    aget-wide v8, v6, v5

    add-int/lit8 v5, v5, 0x2

    .line 70
    aget-wide v10, v6, v7

    const/4 v6, 0x0

    move v7, v4

    :goto_0
    if-ge v6, v0, :cond_0

    .line 73
    iget-object v12, v2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->data:[D

    add-int/lit8 v13, v6, 0x1

    aget-wide v14, v12, v6

    add-int/lit8 v6, v6, 0x2

    .line 74
    aget-wide v16, v12, v13

    .line 76
    iget-object v12, v3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->data:[D

    add-int/lit8 v13, v7, 0x1

    mul-double v18, v8, v14

    mul-double v20, v10, v16

    sub-double v18, v18, v20

    aput-wide v18, v12, v7

    add-int/lit8 v7, v7, 0x2

    mul-double v16, v16, v8

    mul-double/2addr v14, v10

    add-double v16, v16, v14

    .line 77
    aput-wide v16, v12, v13

    goto :goto_0

    :cond_0
    move/from16 v7, p6

    :cond_1
    if-eq v6, v7, :cond_2

    add-int v8, v6, v0

    .line 85
    iget-object v9, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->data:[D

    add-int/lit8 v10, v5, 0x1

    aget-wide v11, v9, v5

    add-int/lit8 v5, v5, 0x2

    .line 86
    aget-wide v13, v9, v10

    move v9, v4

    :goto_1
    if-ge v6, v8, :cond_1

    .line 89
    iget-object v10, v2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->data:[D

    add-int/lit8 v15, v6, 0x1

    aget-wide v16, v10, v6

    add-int/lit8 v6, v6, 0x2

    .line 90
    aget-wide v18, v10, v15

    .line 92
    iget-object v10, v3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->data:[D

    add-int/lit8 v15, v9, 0x1

    aget-wide v20, v10, v9

    mul-double v22, v11, v16

    mul-double v24, v13, v18

    sub-double v22, v22, v24

    add-double v20, v20, v22

    aput-wide v20, v10, v9

    add-int/lit8 v9, v9, 0x2

    .line 93
    aget-wide v20, v10, v15

    mul-double v18, v18, v11

    mul-double v16, v16, v13

    add-double v18, v18, v16

    add-double v20, v20, v18

    aput-wide v20, v10, v15

    goto :goto_1

    :cond_2
    return-void
.end method

.method public static synthetic $r8$lambda$aa_0xnb2uPQKdVjb_e7EGSSZep0(IILcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;I)V
    .locals 24

    move-object/from16 v0, p2

    mul-int v1, p5, p0

    mul-int v2, p5, p1

    const/4 v3, 0x0

    .line 114
    :goto_0
    iget v4, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numCols:I

    if-ge v3, v4, :cond_1

    mul-int/lit8 v4, v3, 0x2

    add-int v5, v1, p0

    const-wide/16 v6, 0x0

    move v10, v1

    move-wide v8, v6

    :goto_1
    if-ge v10, v5, :cond_0

    move-object/from16 v11, p3

    .line 122
    iget-object v12, v11, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->data:[D

    add-int/lit8 v13, v10, 0x1

    aget-wide v14, v12, v10

    add-int/lit8 v10, v10, 0x2

    .line 123
    aget-wide v16, v12, v13

    .line 125
    iget-object v12, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->data:[D

    aget-wide v18, v12, v4

    add-int/lit8 v13, v4, 0x1

    .line 126
    aget-wide v20, v12, v13

    mul-double v12, v14, v18

    mul-double v22, v16, v20

    sub-double v12, v12, v22

    add-double/2addr v6, v12

    mul-double v14, v14, v20

    mul-double v16, v16, v18

    add-double v14, v14, v16

    add-double/2addr v8, v14

    add-int v4, v4, p1

    goto :goto_1

    :cond_0
    move-object/from16 v11, p3

    move-object/from16 v4, p4

    .line 134
    iget-object v5, v4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->data:[D

    add-int/lit8 v10, v2, 0x1

    aput-wide v6, v5, v2

    add-int/lit8 v2, v2, 0x2

    .line 135
    aput-wide v8, v5, v10

    add-int/lit8 v3, v3, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static mult_reorder(Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;)V
    .locals 12

    if-eq p0, p2, :cond_4

    if-eq p1, p2, :cond_4

    .line 43
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numCols:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numRows:I

    if-ne v0, v1, :cond_3

    .line 45
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numRows:I

    iget v2, p2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numRows:I

    if-ne v1, v2, :cond_2

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numCols:I

    iget v3, p2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numCols:I

    if-ne v2, v3, :cond_2

    if-eqz v0, :cond_0

    if-nez v1, :cond_1

    :cond_0
    move-object v10, p2

    goto :goto_0

    .line 54
    :cond_1
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;->getRowStride()I

    move-result v6

    .line 55
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;->getRowStride()I

    move-result v7

    .line 56
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;->getRowStride()I

    move-result v5

    .line 57
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numRows:I

    mul-int v11, v0, v7

    .line 59
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numRows:I

    new-instance v4, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_ZDRM$$ExternalSyntheticLambda1;

    move-object v8, p0

    move-object v9, p1

    move-object v10, p2

    invoke-direct/range {v4 .. v11}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_ZDRM$$ExternalSyntheticLambda1;-><init>(IIILcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;I)V

    const/4 p0, 0x0

    invoke-static {p0, v0, v4}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void

    :goto_0
    const-wide/16 p0, 0x0

    .line 50
    invoke-static {v10, p0, p1, p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/CommonOps_ZDRM;->fill(Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;DD)V

    return-void

    .line 46
    :cond_2
    new-instance p0, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;

    const-string p1, "The results matrix does not have the desired dimensions"

    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;-><init>(Ljava/lang/String;)V

    throw p0

    .line 44
    :cond_3
    new-instance p0, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;

    const-string p1, "The \'a\' and \'b\' matrices do not have compatible dimensions"

    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;-><init>(Ljava/lang/String;)V

    throw p0

    .line 42
    :cond_4
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Neither \'a\' or \'b\' can be the same matrix as \'c\'"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method public static mult_small(Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;)V
    .locals 8

    if-eq p0, p2, :cond_2

    if-eq p1, p2, :cond_2

    .line 102
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numCols:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numRows:I

    if-ne v0, v1, :cond_1

    .line 104
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numRows:I

    iget v1, p2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numRows:I

    if-ne v0, v1, :cond_0

    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numCols:I

    iget v1, p2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numCols:I

    if-ne v0, v1, :cond_0

    .line 108
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;->getRowStride()I

    move-result v3

    .line 109
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;->getRowStride()I

    move-result v4

    .line 111
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numRows:I

    new-instance v2, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_ZDRM$$ExternalSyntheticLambda0;

    move-object v6, p0

    move-object v5, p1

    move-object v7, p2

    invoke-direct/range {v2 .. v7}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_ZDRM$$ExternalSyntheticLambda0;-><init>(IILcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;)V

    const/4 p0, 0x0

    invoke-static {p0, v0, v2}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->loopFor(IILjava/util/function/IntConsumer;)V

    return-void

    .line 105
    :cond_0
    new-instance p0, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;

    const-string p1, "The results matrix does not have the desired dimensions"

    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;-><init>(Ljava/lang/String;)V

    throw p0

    .line 103
    :cond_1
    new-instance p0, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;

    const-string p1, "The \'a\' and \'b\' matrices do not have compatible dimensions"

    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;-><init>(Ljava/lang/String;)V

    throw p0

    .line 101
    :cond_2
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Neither \'a\' or \'b\' can be the same matrix as \'c\'"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method
