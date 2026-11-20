.class public abstract Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/CommonOps_ZDRM;
.super Ljava/lang/Object;
.source "CommonOps_ZDRM.java"


# direct methods
.method public static fill(Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;DD)V
    .locals 4

    .line 255
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrix;->getDataLength()I

    move-result v0

    const/4 v1, 0x0

    :goto_0
    if-ge v1, v0, :cond_0

    .line 257
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->data:[D

    aput-wide p1, v2, v1

    add-int/lit8 v3, v1, 0x1

    .line 258
    aput-wide p3, v2, v3

    add-int/lit8 v1, v1, 0x2

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;)V
    .locals 2

    .line 352
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numCols:I

    sget v1, Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters;->CMULT_COLUMN_SWITCH:I

    if-lt v0, v1, :cond_0

    .line 353
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_ZDRM;->mult_reorder(Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;)V

    return-void

    .line 355
    :cond_0
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_ZDRM;->mult_small(Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;)V

    return-void
.end method
