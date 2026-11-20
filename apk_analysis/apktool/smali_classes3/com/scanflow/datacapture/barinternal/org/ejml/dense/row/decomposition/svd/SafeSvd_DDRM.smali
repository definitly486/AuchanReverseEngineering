.class public Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SafeSvd_DDRM;
.super Ljava/lang/Object;
.source "SafeSvd_DDRM.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/SingularValueDecomposition_F64;


# instance fields
.field alg:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/SingularValueDecomposition_F64;

.field work:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/SingularValueDecomposition_F64;)V
    .locals 2

    .line 38
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 36
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    const/4 v1, 0x1

    invoke-direct {v0, v1, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;-><init>(II)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SafeSvd_DDRM;->work:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    .line 39
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SafeSvd_DDRM;->alg:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/SingularValueDecomposition_F64;

    return-void
.end method


# virtual methods
.method public decompose(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)Z
    .locals 3

    .line 84
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SafeSvd_DDRM;->alg:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/SingularValueDecomposition_F64;

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/DecompositionInterface;->inputModified()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 85
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SafeSvd_DDRM;->work:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    invoke-virtual {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->reshape(II)V

    .line 86
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SafeSvd_DDRM;->work:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->setTo(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;)V

    .line 87
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SafeSvd_DDRM;->alg:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/SingularValueDecomposition_F64;

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SafeSvd_DDRM;->work:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-interface {p1, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/DecompositionInterface;->decompose(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Z

    move-result p1

    return p1

    .line 89
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SafeSvd_DDRM;->alg:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/SingularValueDecomposition_F64;

    invoke-interface {v0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/DecompositionInterface;->decompose(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Z

    move-result p1

    return p1
.end method

.method public bridge synthetic decompose(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Z
    .locals 0

    .line 31
    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SafeSvd_DDRM;->decompose(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)Z

    move-result p1

    return p1
.end method

.method public getSingularValues()[D
    .locals 1

    .line 44
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SafeSvd_DDRM;->alg:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/SingularValueDecomposition_F64;

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/SingularValueDecomposition_F64;->getSingularValues()[D

    move-result-object v0

    return-object v0
.end method

.method public getV(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;Z)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;
    .locals 1

    .line 64
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SafeSvd_DDRM;->alg:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/SingularValueDecomposition_F64;

    invoke-interface {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/SingularValueDecomposition;->getV(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;Z)Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    return-object p1
.end method

.method public bridge synthetic getV(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;Z)Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;
    .locals 0

    .line 31
    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SafeSvd_DDRM;->getV(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;Z)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    move-result-object p1

    return-object p1
.end method

.method public inputModified()Z
    .locals 1

    .line 95
    const/4 v0, 0x0

    return v0
.end method

.method public numberOfSingularValues()I
    .locals 1

    .line 49
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SafeSvd_DDRM;->alg:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/SingularValueDecomposition_F64;

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/SingularValueDecomposition;->numberOfSingularValues()I

    move-result v0

    return v0
.end method
