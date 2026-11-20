.class public abstract Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/CommonOps_MT_ZDRM;
.super Ljava/lang/Object;
.source "CommonOps_MT_ZDRM.java"


# direct methods
.method public static mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;)V
    .locals 2

    .line 43
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numCols:I

    sget v1, Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters;->CMULT_COLUMN_SWITCH:I

    if-lt v0, v1, :cond_0

    .line 44
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_ZDRM;->mult_reorder(Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;)V

    return-void

    .line 46
    :cond_0
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_ZDRM;->mult_small(Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;)V

    return-void
.end method
