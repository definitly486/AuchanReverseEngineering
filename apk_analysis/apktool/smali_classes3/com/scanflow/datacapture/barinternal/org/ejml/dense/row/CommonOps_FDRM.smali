.class public abstract Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/CommonOps_FDRM;
.super Ljava/lang/Object;
.source "CommonOps_FDRM.java"


# direct methods
.method public static fill(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;F)V
    .locals 2

    .line 2462
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->data:[F

    const/4 v1, 0x0

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;->getNumElements()I

    move-result p0

    invoke-static {v0, v1, p0, p1}, Ljava/util/Arrays;->fill([FIIF)V

    return-void
.end method

.method public static mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix1Row;)Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix1Row;
    .locals 2

    .line 82
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numRows:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numCols:I

    invoke-static {p2, p0, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->reshapeOrDeclare(Lcom/scanflow/datacapture/barinternal/org/ejml/data/ReshapeMatrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ReshapeMatrix;II)Lcom/scanflow/datacapture/barinternal/org/ejml/data/ReshapeMatrix;

    move-result-object p2

    check-cast p2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix1Row;

    .line 83
    invoke-static {p0, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->checkSameInstance(Ljava/lang/Object;Ljava/lang/Object;)V

    .line 84
    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->checkSameInstance(Ljava/lang/Object;Ljava/lang/Object;)V

    .line 86
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numCols:I

    const/4 v1, 0x1

    if-ne v0, v1, :cond_0

    .line 87
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixVectorMult_FDRM;->mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;)V

    return-object p2

    .line 88
    :cond_0
    sget v1, Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters;->MULT_COLUMN_SWITCH:I

    if-lt v0, v1, :cond_1

    .line 89
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_FDRM;->mult_reorder(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix1Row;)V

    return-object p2

    .line 91
    :cond_1
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_FDRM;->mult_small(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix1Row;)V

    return-object p2
.end method
