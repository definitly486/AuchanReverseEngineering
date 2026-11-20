.class public Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_FSCC;
.super Ljava/lang/Object;
.source "SimpleOperations_FSCC.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleOperations;
.implements Ljava/io/Serializable;


# instance fields
.field public transient gw:Lcom/scanflow/datacapture/barinternal/org/ejml/data/IGrowArray;

.field public transient gx:Lcom/scanflow/datacapture/barinternal/org/ejml/data/FGrowArray;

.field public transient workspaceA:Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;

.field public transient workspaceMT:Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;


# direct methods
.method public constructor <init>()V
    .locals 2

    .line 44
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 47
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/IGrowArray;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/IGrowArray;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_FSCC;->gw:Lcom/scanflow/datacapture/barinternal/org/ejml/data/IGrowArray;

    .line 48
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FGrowArray;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FGrowArray;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_FSCC;->gx:Lcom/scanflow/datacapture/barinternal/org/ejml/data/FGrowArray;

    .line 51
    new-instance v0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_FSCC$$ExternalSyntheticLambda0;

    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_FSCC$$ExternalSyntheticLambda0;-><init>()V

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;-><init>(Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$NewInstance;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_FSCC;->workspaceMT:Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;

    .line 52
    new-instance v0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_FSCC$$ExternalSyntheticLambda1;

    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_FSCC$$ExternalSyntheticLambda1;-><init>()V

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;-><init>(Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$NewInstance;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_FSCC;->workspaceA:Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;

    return-void
.end method


# virtual methods
.method public mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;)V
    .locals 1

    .line 92
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/concurrency/EjmlConcurrency;->useConcurrent(Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixSparse;)Z

    move-result v0

    if-nez v0, :cond_1

    invoke-static {p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/concurrency/EjmlConcurrency;->useConcurrent(Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixSparse;)Z

    move-result v0

    if-eqz v0, :cond_0

    goto :goto_0

    .line 95
    :cond_0
    invoke-static {p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/CommonOps_FSCC;->mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;)Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;

    return-void

    .line 93
    :cond_1
    :goto_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_FSCC;->workspaceMT:Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;

    invoke-static {p1, p2, p3, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/CommonOps_MT_FSCC;->mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;

    return-void
.end method

.method public bridge synthetic mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)V
    .locals 0

    .line 43
    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;

    check-cast p2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;

    check-cast p3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;

    invoke-virtual {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_FSCC;->mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;)V

    return-void
.end method
