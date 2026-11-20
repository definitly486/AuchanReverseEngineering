.class public Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRColPivDecompositionHouseholderColumn_DDRM;
.super Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRDecompositionHouseholderColumn_DDRM;
.source "QRColPivDecompositionHouseholderColumn_DDRM.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/QRPDecomposition_F64;


# instance fields
.field maxValueAbs:D

.field protected normsCol:[D

.field protected pivots:[I

.field protected rank:I

.field protected singularThreshold:D


# direct methods
.method public constructor <init>()V
    .locals 2

    .line 75
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRDecompositionHouseholderColumn_DDRM;-><init>()V

    .line 58
    sget-wide v0, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->EPS:D

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRColPivDecompositionHouseholderColumn_DDRM;->singularThreshold:D

    return-void
.end method


# virtual methods
.method public decompose(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)Z
    .locals 2

    .line 133
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    invoke-virtual {p0, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRColPivDecompositionHouseholderColumn_DDRM;->setExpectedMaxSize(II)V

    .line 135
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/CommonOps_DDRM;->elementMaxAbs(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;)D

    move-result-wide v0

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRColPivDecompositionHouseholderColumn_DDRM;->maxValueAbs:D

    .line 136
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRDecompositionHouseholderColumn_DDRM;->convertToColumnMajor(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)V

    .line 139
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRColPivDecompositionHouseholderColumn_DDRM;->setupPivotInfo()V

    const/4 p1, 0x0

    .line 142
    :goto_0
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRDecompositionHouseholderColumn_DDRM;->minLength:I

    if-ge p1, v0, :cond_2

    if-lez p1, :cond_0

    .line 144
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRColPivDecompositionHouseholderColumn_DDRM;->updateNorms(I)V

    .line 145
    :cond_0
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRColPivDecompositionHouseholderColumn_DDRM;->swapColumns(I)V

    .line 147
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRColPivDecompositionHouseholderColumn_DDRM;->householderPivot(I)Z

    move-result v0

    if-nez v0, :cond_1

    goto :goto_1

    .line 149
    :cond_1
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRDecompositionHouseholderColumn_DDRM;->updateA(I)V

    add-int/lit8 p1, p1, 0x1

    .line 150
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRColPivDecompositionHouseholderColumn_DDRM;->rank:I

    goto :goto_0

    :cond_2
    :goto_1
    const/4 p1, 0x1

    return p1
.end method

.method public bridge synthetic decompose(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Z
    .locals 0

    .line 47
    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRColPivDecompositionHouseholderColumn_DDRM;->decompose(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)Z

    move-result p1

    return p1
.end method

.method public getColPivotMatrix(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;
    .locals 4

    if-nez p1, :cond_0

    .line 287
    new-instance p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRDecompositionHouseholderColumn_DDRM;->numCols:I

    invoke-direct {p1, v0, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;-><init>(II)V

    goto :goto_0

    .line 288
    :cond_0
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRDecompositionHouseholderColumn_DDRM;->numCols:I

    if-ne v0, v1, :cond_3

    .line 290
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    if-ne v0, v1, :cond_2

    .line 293
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->zero()V

    :goto_0
    const/4 v0, 0x0

    .line 296
    :goto_1
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRDecompositionHouseholderColumn_DDRM;->numCols:I

    if-ge v0, v1, :cond_1

    .line 297
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRColPivDecompositionHouseholderColumn_DDRM;->pivots:[I

    aget v1, v1, v0

    const-wide/high16 v2, 0x3ff0000000000000L    # 1.0

    invoke-virtual {p1, v1, v0, v2, v3}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    add-int/lit8 v0, v0, 0x1

    goto :goto_1

    :cond_1
    return-object p1

    .line 291
    :cond_2
    new-instance p1, Ljava/lang/IllegalArgumentException;

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRDecompositionHouseholderColumn_DDRM;->numCols:I

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Number of columns must be "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-direct {p1, v0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1

    .line 289
    :cond_3
    new-instance p1, Ljava/lang/IllegalArgumentException;

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRDecompositionHouseholderColumn_DDRM;->numCols:I

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Number of rows must be "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-direct {p1, v0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public bridge synthetic getColPivotMatrix(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;
    .locals 0

    .line 47
    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRColPivDecompositionHouseholderColumn_DDRM;->getColPivotMatrix(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    move-result-object p1

    return-object p1
.end method

.method public getQ(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;Z)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;
    .locals 8

    if-eqz p2, :cond_0

    .line 102
    iget p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRDecompositionHouseholderColumn_DDRM;->numRows:I

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRDecompositionHouseholderColumn_DDRM;->minLength:I

    invoke-static {p1, p2, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/UtilDecompositons_DDRM;->ensureIdentity(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;II)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    move-result-object p1

    :goto_0
    move-object v0, p1

    goto :goto_1

    .line 104
    :cond_0
    iget p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRDecompositionHouseholderColumn_DDRM;->numRows:I

    invoke-static {p1, p2, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/UtilDecompositons_DDRM;->ensureIdentity(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;II)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    move-result-object p1

    goto :goto_0

    .line 107
    :goto_1
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRColPivDecompositionHouseholderColumn_DDRM;->rank:I

    add-int/lit8 p1, p1, -0x1

    move v4, p1

    :goto_2
    if-ltz v4, :cond_1

    .line 108
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRDecompositionHouseholderColumn_DDRM;->dataQR:[[D

    aget-object v1, p1, v4

    .line 110
    aget-wide p1, v1, v4

    const-wide/high16 v2, 0x3ff0000000000000L    # 1.0

    .line 111
    aput-wide v2, v1, v4

    .line 112
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRDecompositionHouseholderColumn_DDRM;->gammas:[D

    aget-wide v5, v2, v4

    move-wide v2, v5

    iget v6, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRDecompositionHouseholderColumn_DDRM;->numRows:I

    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRDecompositionHouseholderColumn_DDRM;->v:[D

    move v5, v4

    invoke-static/range {v0 .. v7}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QrHelperFunctions_DDRM;->rank1UpdateMultR(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;[DDIII[D)V

    .line 113
    aput-wide p1, v1, v4

    add-int/lit8 v4, v4, -0x1

    goto :goto_2

    :cond_1
    return-object v0
.end method

.method public bridge synthetic getQ(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;Z)Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;
    .locals 0

    .line 47
    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRColPivDecompositionHouseholderColumn_DDRM;->getQ(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;Z)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    move-result-object p1

    return-object p1
.end method

.method protected householderPivot(I)Z
    .locals 7

    .line 247
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRDecompositionHouseholderColumn_DDRM;->dataQR:[[D

    aget-object v0, v0, p1

    .line 251
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRDecompositionHouseholderColumn_DDRM;->numRows:I

    sub-int/2addr v1, p1

    invoke-static {v0, p1, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QrHelperFunctions_DDRM;->findMax([DII)D

    move-result-wide v1

    .line 253
    iget-wide v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRColPivDecompositionHouseholderColumn_DDRM;->singularThreshold:D

    iget-wide v5, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRColPivDecompositionHouseholderColumn_DDRM;->maxValueAbs:D

    mul-double/2addr v3, v5

    cmpg-double v3, v1, v3

    if-gtz v3, :cond_0

    const/4 p1, 0x0

    return p1

    .line 257
    :cond_0
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRDecompositionHouseholderColumn_DDRM;->numRows:I

    invoke-static {p1, v3, v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QrHelperFunctions_DDRM;->computeTauAndDivide(II[DD)D

    move-result-wide v3

    iput-wide v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRDecompositionHouseholderColumn_DDRM;->tau:D

    .line 260
    aget-wide v5, v0, p1

    add-double/2addr v5, v3

    add-int/lit8 v3, p1, 0x1

    .line 261
    iget v4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRDecompositionHouseholderColumn_DDRM;->numRows:I

    invoke-static {v3, v4, v0, v5, v6}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QrHelperFunctions_DDRM;->divideElements(II[DD)V

    .line 263
    iget-wide v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRDecompositionHouseholderColumn_DDRM;->tau:D

    div-double/2addr v5, v3

    iput-wide v5, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRDecompositionHouseholderColumn_DDRM;->gamma:D

    mul-double/2addr v3, v1

    .line 264
    iput-wide v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRDecompositionHouseholderColumn_DDRM;->tau:D

    neg-double v1, v3

    .line 266
    aput-wide v1, v0, p1

    .line 269
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRDecompositionHouseholderColumn_DDRM;->gammas:[D

    aput-wide v5, v0, p1

    const/4 p1, 0x1

    return p1
.end method

.method public setExpectedMaxSize(II)V
    .locals 0

    .line 85
    invoke-super {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRDecompositionHouseholderColumn_DDRM;->setExpectedMaxSize(II)V

    .line 87
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRColPivDecompositionHouseholderColumn_DDRM;->pivots:[I

    if-eqz p1, :cond_1

    array-length p1, p1

    if-ge p1, p2, :cond_0

    goto :goto_0

    :cond_0
    return-void

    .line 88
    :cond_1
    :goto_0
    new-array p1, p2, [I

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRColPivDecompositionHouseholderColumn_DDRM;->pivots:[I

    .line 89
    new-array p1, p2, [D

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRColPivDecompositionHouseholderColumn_DDRM;->normsCol:[D

    return-void
.end method

.method protected setupPivotInfo()V
    .locals 8

    const/4 v0, 0x0

    move v1, v0

    .line 160
    :goto_0
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRDecompositionHouseholderColumn_DDRM;->numCols:I

    if-ge v1, v2, :cond_1

    .line 161
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRColPivDecompositionHouseholderColumn_DDRM;->pivots:[I

    aput v1, v2, v1

    .line 162
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRDecompositionHouseholderColumn_DDRM;->dataQR:[[D

    aget-object v2, v2, v1

    const-wide/16 v3, 0x0

    move v5, v0

    .line 164
    :goto_1
    iget v6, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRDecompositionHouseholderColumn_DDRM;->numRows:I

    if-ge v5, v6, :cond_0

    .line 165
    aget-wide v6, v2, v5

    mul-double/2addr v6, v6

    add-double/2addr v3, v6

    add-int/lit8 v5, v5, 0x1

    goto :goto_1

    .line 168
    :cond_0
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRColPivDecompositionHouseholderColumn_DDRM;->normsCol:[D

    aput-wide v3, v2, v1

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method protected swapColumns(I)V
    .locals 7

    .line 211
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRColPivDecompositionHouseholderColumn_DDRM;->normsCol:[D

    aget-wide v1, v0, p1

    add-int/lit8 v0, p1, 0x1

    move v3, p1

    .line 212
    :goto_0
    iget v4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRDecompositionHouseholderColumn_DDRM;->numCols:I

    if-ge v0, v4, :cond_1

    .line 213
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRColPivDecompositionHouseholderColumn_DDRM;->normsCol:[D

    aget-wide v5, v4, v0

    cmpl-double v4, v5, v1

    if-lez v4, :cond_0

    move v3, v0

    move-wide v1, v5

    :cond_0
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    .line 220
    :cond_1
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRDecompositionHouseholderColumn_DDRM;->dataQR:[[D

    aget-object v1, v0, p1

    .line 221
    aget-object v2, v0, v3

    aput-object v2, v0, p1

    .line 222
    aput-object v1, v0, v3

    .line 223
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRColPivDecompositionHouseholderColumn_DDRM;->normsCol:[D

    aget-wide v1, v0, p1

    .line 224
    aget-wide v4, v0, v3

    aput-wide v4, v0, p1

    .line 225
    aput-wide v1, v0, v3

    .line 226
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRColPivDecompositionHouseholderColumn_DDRM;->pivots:[I

    aget v1, v0, p1

    .line 227
    aget v2, v0, v3

    aput v2, v0, p1

    .line 228
    aput v1, v0, v3

    return-void
.end method

.method protected updateNorms(I)V
    .locals 9

    move v0, p1

    .line 177
    :goto_0
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRDecompositionHouseholderColumn_DDRM;->numCols:I

    if-ge v0, v1, :cond_2

    .line 178
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRDecompositionHouseholderColumn_DDRM;->dataQR:[[D

    aget-object v1, v1, v0

    add-int/lit8 v2, p1, -0x1

    aget-wide v2, v1, v2

    .line 179
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRColPivDecompositionHouseholderColumn_DDRM;->normsCol:[D

    aget-wide v4, v1, v0

    mul-double/2addr v2, v2

    sub-double/2addr v4, v2

    aput-wide v4, v1, v0

    const-wide/16 v1, 0x0

    cmpg-double v3, v4, v1

    if-gez v3, :cond_1

    move v0, p1

    .line 190
    :goto_1
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRDecompositionHouseholderColumn_DDRM;->numCols:I

    if-ge v0, v3, :cond_2

    .line 191
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRDecompositionHouseholderColumn_DDRM;->dataQR:[[D

    aget-object v3, v3, v0

    move v4, p1

    move-wide v5, v1

    .line 193
    :goto_2
    iget v7, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRDecompositionHouseholderColumn_DDRM;->numRows:I

    if-ge v4, v7, :cond_0

    .line 194
    aget-wide v7, v3, v4

    mul-double/2addr v7, v7

    add-double/2addr v5, v7

    add-int/lit8 v4, v4, 0x1

    goto :goto_2

    .line 197
    :cond_0
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QRColPivDecompositionHouseholderColumn_DDRM;->normsCol:[D

    aput-wide v5, v3, v0

    add-int/lit8 v0, v0, 0x1

    goto :goto_1

    :cond_1
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_2
    return-void
.end method
