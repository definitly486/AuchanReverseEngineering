.class public abstract Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/CommonOps_FSCC;
.super Ljava/lang/Object;
.source "CommonOps_FSCC.java"


# direct methods
.method public static mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;)Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;
    .locals 1

    const/4 v0, 0x0

    .line 137
    invoke-static {p0, p1, p2, v0, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/CommonOps_FSCC;->mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/IGrowArray;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FGrowArray;)Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;

    move-result-object p0

    return-object p0
.end method

.method public static mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/IGrowArray;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FGrowArray;)Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;
    .locals 2

    .line 152
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numCols:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numRows:I

    if-ne v0, v1, :cond_0

    .line 154
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numRows:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;->numCols:I

    invoke-static {p2, p0, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->reshapeOrDeclare(Lcom/scanflow/datacapture/barinternal/org/ejml/data/ReshapeMatrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ReshapeMatrix;II)Lcom/scanflow/datacapture/barinternal/org/ejml/data/ReshapeMatrix;

    move-result-object p2

    check-cast p2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;

    .line 156
    invoke-static {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/ImplMultiplication_FSCC;->mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/IGrowArray;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FGrowArray;)V

    return-object p2

    .line 153
    :cond_0
    new-instance p2, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;

    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->stringShapes(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Ljava/lang/String;

    move-result-object p0

    new-instance p1, Ljava/lang/StringBuilder;

    invoke-direct {p1}, Ljava/lang/StringBuilder;-><init>()V

    const-string p3, "Inconsistent matrix shapes. "

    invoke-virtual {p1, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p1, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    invoke-direct {p2, p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;-><init>(Ljava/lang/String;)V

    throw p2
.end method
