.class public Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_CDRM;
.super Ljava/lang/Object;
.source "SimpleOperations_CDRM.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleOperations;


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 40
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public bridge synthetic mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)V
    .locals 0

    .line 39
    check-cast p1, Lorg/ejml/data/CMatrixRMaj;

    check-cast p2, Lorg/ejml/data/CMatrixRMaj;

    check-cast p3, Lorg/ejml/data/CMatrixRMaj;

    invoke-virtual {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_CDRM;->mult(Lorg/ejml/data/CMatrixRMaj;Lorg/ejml/data/CMatrixRMaj;Lorg/ejml/data/CMatrixRMaj;)V

    return-void
.end method

.method public mult(Lorg/ejml/data/CMatrixRMaj;Lorg/ejml/data/CMatrixRMaj;Lorg/ejml/data/CMatrixRMaj;)V
    .locals 1

    .line 78
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/concurrency/EjmlConcurrency;->useConcurrent(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Z

    move-result v0

    if-nez v0, :cond_1

    invoke-static {p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/concurrency/EjmlConcurrency;->useConcurrent(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Z

    move-result v0

    if-eqz v0, :cond_0

    goto :goto_0

    .line 81
    :cond_0
    invoke-static {p1, p2, p3}, Lorg/ejml/dense/row/CommonOps_CDRM;->mult(Lorg/ejml/data/CMatrixRMaj;Lorg/ejml/data/CMatrixRMaj;Lorg/ejml/data/CMatrixRMaj;)V

    return-void

    .line 79
    :cond_1
    :goto_0
    invoke-static {p1, p2, p3}, Lorg/ejml/dense/row/CommonOps_MT_CDRM;->mult(Lorg/ejml/data/CMatrixRMaj;Lorg/ejml/data/CMatrixRMaj;Lorg/ejml/data/CMatrixRMaj;)V

    return-void
.end method
