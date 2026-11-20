.class public Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_DDRM;
.super Ljava/lang/Object;
.source "SimpleOperations_DDRM.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleOperations;


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 44
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)V
    .locals 1

    .line 84
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/concurrency/EjmlConcurrency;->useConcurrent(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Z

    move-result v0

    if-nez v0, :cond_1

    invoke-static {p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/concurrency/EjmlConcurrency;->useConcurrent(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Z

    move-result v0

    if-eqz v0, :cond_0

    goto :goto_0

    .line 87
    :cond_0
    invoke-static {p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/CommonOps_DDRM;->mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;

    return-void

    .line 85
    :cond_1
    :goto_0
    invoke-static {p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/CommonOps_MT_DDRM;->mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;

    return-void
.end method

.method public bridge synthetic mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)V
    .locals 0

    .line 44
    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    check-cast p2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    check-cast p3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-virtual {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_DDRM;->mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)V

    return-void
.end method
