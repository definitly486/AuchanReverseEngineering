.class public abstract Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/CommonOps_MT_DDRM;
.super Ljava/lang/Object;
.source "CommonOps_MT_DDRM.java"


# direct methods
.method public static mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;
    .locals 2

    .line 51
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    invoke-static {p2, p0, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->reshapeOrDeclare(Lcom/scanflow/datacapture/barinternal/org/ejml/data/ReshapeMatrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ReshapeMatrix;II)Lcom/scanflow/datacapture/barinternal/org/ejml/data/ReshapeMatrix;

    move-result-object p2

    check-cast p2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;

    .line 52
    invoke-static {p0, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->checkSameInstance(Ljava/lang/Object;Ljava/lang/Object;)V

    .line 53
    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->checkSameInstance(Ljava/lang/Object;Ljava/lang/Object;)V

    .line 55
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_DDRM;->mult_reorder(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;)V

    return-object p2
.end method
