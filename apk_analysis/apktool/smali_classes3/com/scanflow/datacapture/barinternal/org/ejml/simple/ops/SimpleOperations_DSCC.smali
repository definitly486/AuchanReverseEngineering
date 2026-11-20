.class public Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_DSCC;
.super Ljava/lang/Object;
.source "SimpleOperations_DSCC.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleOperations;
.implements Ljava/io/Serializable;


# instance fields
.field public transient gw:Lcom/scanflow/datacapture/barinternal/org/ejml/data/IGrowArray;

.field public transient gx:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DGrowArray;

.field public transient workspaceA:Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;

.field public transient workspaceMT:Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;


# direct methods
.method public constructor <init>()V
    .locals 2

    .line 42
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 45
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/IGrowArray;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/IGrowArray;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_DSCC;->gw:Lcom/scanflow/datacapture/barinternal/org/ejml/data/IGrowArray;

    .line 46
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DGrowArray;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DGrowArray;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_DSCC;->gx:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DGrowArray;

    .line 49
    new-instance v0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_DSCC$$ExternalSyntheticLambda0;

    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_DSCC$$ExternalSyntheticLambda0;-><init>()V

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;-><init>(Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$NewInstance;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_DSCC;->workspaceMT:Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;

    .line 50
    new-instance v0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_DSCC$$ExternalSyntheticLambda1;

    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_DSCC$$ExternalSyntheticLambda1;-><init>()V

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;-><init>(Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$NewInstance;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_DSCC;->workspaceA:Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;

    return-void
.end method


# virtual methods
.method public mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;)V
    .locals 1

    .line 90
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/concurrency/EjmlConcurrency;->useConcurrent(Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixSparse;)Z

    move-result v0

    if-nez v0, :cond_1

    invoke-static {p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/concurrency/EjmlConcurrency;->useConcurrent(Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixSparse;)Z

    move-result v0

    if-eqz v0, :cond_0

    goto :goto_0

    .line 93
    :cond_0
    invoke-static {p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/CommonOps_DSCC;->mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;

    return-void

    .line 91
    :cond_1
    :goto_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_DSCC;->workspaceMT:Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;

    invoke-static {p1, p2, p3, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/CommonOps_MT_DSCC;->mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;

    return-void
.end method

.method public bridge synthetic mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)V
    .locals 0

    .line 42
    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;

    check-cast p2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;

    check-cast p3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;

    invoke-virtual {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_DSCC;->mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixSparseCSC;)V

    return-void
.end method
