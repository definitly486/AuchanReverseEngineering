.class public Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_FDRM;
.super Ljava/lang/Object;
.source "SimpleOperations_FDRM.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleOperations;


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 46
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;)V
    .locals 1

    .line 86
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/concurrency/EjmlConcurrency;->useConcurrent(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Z

    move-result v0

    if-nez v0, :cond_1

    invoke-static {p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/concurrency/EjmlConcurrency;->useConcurrent(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Z

    move-result v0

    if-eqz v0, :cond_0

    goto :goto_0

    .line 89
    :cond_0
    invoke-static {p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/CommonOps_FDRM;->mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix1Row;)Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix1Row;

    return-void

    .line 87
    :cond_1
    :goto_0
    invoke-static {p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/CommonOps_MT_FDRM;->mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix1Row;)Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix1Row;

    return-void
.end method

.method public bridge synthetic mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)V
    .locals 0

    .line 45
    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;

    check-cast p2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;

    check-cast p3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;

    invoke-virtual {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_FDRM;->mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;)V

    return-void
.end method
