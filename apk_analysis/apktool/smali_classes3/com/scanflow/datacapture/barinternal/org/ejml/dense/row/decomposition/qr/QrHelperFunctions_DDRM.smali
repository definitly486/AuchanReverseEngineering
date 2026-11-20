.class public abstract Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QrHelperFunctions_DDRM;
.super Ljava/lang/Object;
.source "QrHelperFunctions_DDRM.java"


# direct methods
.method public static computeTauAndDivide(II[DD)D
    .locals 7

    const-wide/16 v0, 0x0

    move v2, p0

    move-wide v3, v0

    :goto_0
    if-ge v2, p1, :cond_0

    .line 180
    aget-wide v5, p2, v2

    div-double/2addr v5, p3

    aput-wide v5, p2, v2

    mul-double/2addr v5, v5

    add-double/2addr v3, v5

    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    .line 189
    :cond_0
    invoke-static {v3, v4}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide p3

    .line 191
    aget-wide p0, p2, p0

    cmpg-double p0, p0, v0

    if-gez p0, :cond_1

    neg-double p0, p3

    return-wide p0

    :cond_1
    return-wide p3
.end method

.method public static computeTauAndDivide(II[DID)D
    .locals 8

    const-wide/16 v0, 0x0

    move v2, p0

    move-wide v3, v0

    :goto_0
    if-ge v2, p1, :cond_0

    add-int v5, p3, v2

    .line 135
    aget-wide v6, p2, v5

    div-double/2addr v6, p4

    aput-wide v6, p2, v5

    mul-double/2addr v6, v6

    add-double/2addr v3, v6

    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    .line 145
    :cond_0
    invoke-static {v3, v4}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide p4

    add-int/2addr p3, p0

    .line 147
    aget-wide p0, p2, p3

    cmpg-double p0, p0, v0

    if-gez p0, :cond_1

    neg-double p0, p4

    return-wide p0

    :cond_1
    return-wide p4
.end method

.method public static divideElements(II[DD)V
    .locals 2

    :goto_0
    if-ge p0, p1, :cond_0

    .line 69
    aget-wide v0, p2, p0

    div-double/2addr v0, p3

    aput-wide v0, p2, p0

    add-int/lit8 p0, p0, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static divideElements_Bcol(III[D[DID)V
    .locals 3

    mul-int v0, p0, p2

    add-int/2addr v0, p5

    :goto_0
    if-ge p0, p1, :cond_0

    .line 117
    aget-wide v1, p3, p0

    div-double/2addr v1, p6

    aput-wide v1, p3, p0

    aput-wide v1, p4, v0

    add-int/lit8 p0, p0, 0x1

    add-int/2addr v0, p2

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static divideElements_Brow(II[D[DID)V
    .locals 3

    :goto_0
    if-ge p0, p1, :cond_0

    add-int v0, p0, p4

    .line 99
    aget-wide v1, p3, v0

    div-double/2addr v1, p5

    aput-wide v1, p3, v0

    aput-wide v1, p2, p0

    add-int/lit8 p0, p0, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static findMax([DII)D
    .locals 6

    add-int/2addr p2, p1

    const-wide/high16 v0, -0x4010000000000000L    # -1.0

    :goto_0
    if-ge p1, p2, :cond_2

    .line 54
    aget-wide v2, p0, p1

    const-wide/16 v4, 0x0

    cmpg-double v4, v2, v4

    if-gez v4, :cond_0

    neg-double v2, v2

    :cond_0
    cmpl-double v4, v2, v0

    if-lez v4, :cond_1

    move-wide v0, v2

    :cond_1
    add-int/lit8 p1, p1, 0x1

    goto :goto_0

    :cond_2
    return-wide v0
.end method

.method public static rank1UpdateMultL(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;[DDIII)V
    .locals 14

    move/from16 v0, p6

    move/from16 v1, p4

    .line 376
    :goto_0
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    if-ge v1, v2, :cond_2

    .line 377
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    mul-int/2addr v2, v1

    add-int v2, v2, p5

    const-wide/16 v3, 0x0

    move/from16 v5, p5

    move v6, v2

    :goto_1
    if-ge v5, v0, :cond_0

    .line 381
    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    add-int/lit8 v8, v6, 0x1

    aget-wide v6, v7, v6

    aget-wide v9, p1, v5

    mul-double/2addr v6, v9

    add-double/2addr v3, v6

    add-int/lit8 v5, v5, 0x1

    move v6, v8

    goto :goto_1

    :cond_0
    move-wide/from16 v5, p2

    neg-double v7, v5

    mul-double/2addr v7, v3

    move/from16 v3, p5

    :goto_2
    if-ge v3, v0, :cond_1

    .line 387
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    add-int/lit8 v9, v2, 0x1

    aget-wide v10, v4, v2

    aget-wide v12, p1, v3

    mul-double/2addr v12, v7

    add-double/2addr v10, v12

    aput-wide v10, v4, v2

    add-int/lit8 v3, v3, 0x1

    move v2, v9

    goto :goto_2

    :cond_1
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_2
    return-void
.end method

.method public static rank1UpdateMultR(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;[DDIII[D)V
    .locals 12

    move/from16 v0, p6

    move/from16 v1, p4

    .line 228
    :goto_0
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    if-ge v1, v2, :cond_0

    .line 229
    aget-wide v3, p1, p5

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    mul-int v2, v2, p5

    add-int/2addr v2, v1

    aget-wide v6, v5, v2

    mul-double/2addr v3, v6

    aput-wide v3, p7, v1

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_0
    add-int/lit8 v1, p5, 0x1

    :goto_1
    if-ge v1, v0, :cond_2

    .line 233
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    mul-int/2addr v2, v1

    add-int v2, v2, p4

    .line 234
    aget-wide v3, p1, v1

    move/from16 v5, p4

    .line 235
    :goto_2
    iget v6, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    if-ge v5, v6, :cond_1

    .line 236
    aget-wide v6, p7, v5

    iget-object v8, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    add-int/lit8 v9, v2, 0x1

    aget-wide v10, v8, v2

    mul-double/2addr v10, v3

    add-double/2addr v6, v10

    aput-wide v6, p7, v5

    add-int/lit8 v5, v5, 0x1

    move v2, v9

    goto :goto_2

    :cond_1
    add-int/lit8 v1, v1, 0x1

    goto :goto_1

    :cond_2
    move/from16 v1, p4

    .line 240
    :goto_3
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    if-ge v1, v2, :cond_3

    .line 241
    aget-wide v2, p7, v1

    mul-double/2addr v2, p2

    aput-wide v2, p7, v1

    add-int/lit8 v1, v1, 0x1

    goto :goto_3

    :cond_3
    move/from16 p2, p5

    :goto_4
    if-ge p2, v0, :cond_5

    .line 248
    aget-wide v1, p1, p2

    .line 250
    iget p3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    mul-int/2addr p3, p2

    add-int p3, p3, p4

    move/from16 v3, p4

    .line 251
    :goto_5
    iget v4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    if-ge v3, v4, :cond_4

    .line 252
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    add-int/lit8 v5, p3, 0x1

    aget-wide v6, v4, p3

    aget-wide v8, p7, v3

    mul-double/2addr v8, v1

    sub-double/2addr v6, v8

    aput-wide v6, v4, p3

    add-int/lit8 v3, v3, 0x1

    move p3, v5

    goto :goto_5

    :cond_4
    add-int/lit8 p2, p2, 0x1

    goto :goto_4

    :cond_5
    return-void
.end method
