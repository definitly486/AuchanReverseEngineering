.class public abstract Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/UtilDecompositons_DDRM;
.super Ljava/lang/Object;
.source "UtilDecompositons_DDRM.java"


# direct methods
.method public static checkZerosLT(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;II)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;
    .locals 5

    if-nez p0, :cond_0

    .line 56
    new-instance p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;-><init>(II)V

    return-object p0

    .line 57
    :cond_0
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    if-ne p1, v0, :cond_4

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    if-eq p2, v0, :cond_1

    goto :goto_2

    :cond_1
    const/4 p1, 0x0

    .line 61
    :goto_0
    iget p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    if-ge p1, p2, :cond_3

    .line 62
    iget p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    mul-int v0, p1, p2

    .line 63
    invoke-static {p1, p2}, Ljava/lang/Math;->min(II)I

    move-result p2

    add-int/2addr p2, v0

    :goto_1
    if-ge v0, p2, :cond_2

    .line 65
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    add-int/lit8 v2, v0, 0x1

    const-wide/16 v3, 0x0

    aput-wide v3, v1, v0

    move v0, v2

    goto :goto_1

    :cond_2
    add-int/lit8 p1, p1, 0x1

    goto :goto_0

    :cond_3
    return-object p0

    .line 58
    :cond_4
    :goto_2
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->reshape(II)V

    .line 59
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->zero()V

    return-object p0
.end method

.method public static ensureIdentity(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;II)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;
    .locals 0

    if-nez p0, :cond_0

    .line 34
    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/CommonOps_DDRM;->identity(II)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    move-result-object p0

    return-object p0

    .line 36
    :cond_0
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->reshape(II)V

    .line 37
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/CommonOps_DDRM;->setIdentity(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;)V

    return-object p0
.end method
