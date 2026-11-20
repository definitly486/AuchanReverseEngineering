.class public abstract Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/CommonOps_MT_DSCC;
.super Ljava/lang/Object;
.source "CommonOps_MT_DSCC.java"


# direct methods
.method public static mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;
    .locals 2

    .line 66
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->numCols:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->numRows:I

    if-ne v0, v1, :cond_1

    .line 68
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->numRows:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;->numCols:I

    invoke-static {p2, p0, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->reshapeOrDeclare(Lcom/scanflow/datacapture/barinternal/org/ejml/data/ReshapeMatrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ReshapeMatrix;II)Lcom/scanflow/datacapture/barinternal/org/ejml/data/ReshapeMatrix;

    move-result-object p2

    check-cast p2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;

    if-nez p3, :cond_0

    .line 71
    new-instance p3, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;

    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_DSCC$$ExternalSyntheticLambda0;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_DSCC$$ExternalSyntheticLambda0;-><init>()V

    invoke-direct {p3, v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;-><init>(Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$NewInstance;)V

    .line 73
    :cond_0
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/ImplMultiplication_MT_DSCC;->mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V

    return-object p2

    .line 67
    :cond_1
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
