.class public Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_ZDRM;
.super Ljava/lang/Object;
.source "SimpleOperations_ZDRM.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleOperations;


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 38
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public bridge synthetic mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)V
    .locals 0

    .line 38
    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;

    check-cast p2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;

    check-cast p3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;

    invoke-virtual {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_ZDRM;->mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;)V

    return-void
.end method

.method public mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;)V
    .locals 1

    .line 76
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/concurrency/EjmlConcurrency;->useConcurrent(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Z

    move-result v0

    if-nez v0, :cond_1

    invoke-static {p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/concurrency/EjmlConcurrency;->useConcurrent(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Z

    move-result v0

    if-eqz v0, :cond_0

    goto :goto_0

    .line 79
    :cond_0
    invoke-static {p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/CommonOps_ZDRM;->mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;)V

    return-void

    .line 77
    :cond_1
    :goto_0
    invoke-static {p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/CommonOps_MT_ZDRM;->mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;)V

    return-void
.end method
