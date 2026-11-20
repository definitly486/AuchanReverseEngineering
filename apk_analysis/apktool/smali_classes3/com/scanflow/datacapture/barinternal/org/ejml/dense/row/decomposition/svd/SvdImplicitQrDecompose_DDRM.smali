.class public Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;
.super Ljava/lang/Object;
.source "SvdImplicitQrDecompose_DDRM.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/SingularValueDecomposition_F64;


# instance fields
.field private A_mod:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

.field private Ut:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

.field private Vt:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

.field protected bidiag:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/BidiagonalDecomposition_F64;

.field protected canUseTallBidiagonal:Z

.field protected compact:Z

.field protected computeU:Z

.field protected computeV:Z

.field diag:[D

.field protected numCols:I

.field protected numColsT:I

.field protected numRows:I

.field protected numRowsT:I

.field private numSingular:I

.field off:[D

.field protected prefComputeU:Z

.field protected prefComputeV:Z

.field protected qralg:Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;

.field private singularValues:[D

.field protected transposed:Z


# direct methods
.method public constructor <init>(ZZZZ)V
    .locals 2

    .line 100
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 63
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->qralg:Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;

    .line 89
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    const/4 v1, 0x1

    invoke-direct {v0, v1, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;-><init>(II)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->A_mod:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    .line 101
    iput-boolean p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->compact:Z

    .line 102
    iput-boolean p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->prefComputeU:Z

    .line 103
    iput-boolean p3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->prefComputeV:Z

    .line 104
    iput-boolean p4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->canUseTallBidiagonal:Z

    return-void
.end method

.method private bidiagonalization(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)Z
    .locals 4

    .line 205
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->transposed:Z

    const/4 v1, 0x0

    if-eqz v0, :cond_0

    .line 206
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->A_mod:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    iget v3, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    invoke-virtual {v0, v2, v3, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->reshape(IIZ)V

    .line 207
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->A_mod:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-virtual {p0, v0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->transpose(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)V

    goto :goto_0

    .line 209
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->A_mod:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    iget v3, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    invoke-virtual {v0, v2, v3, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->reshape(IIZ)V

    .line 210
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->A_mod:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->setTo(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;)V

    .line 212
    :goto_0
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->bidiag:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/BidiagonalDecomposition_F64;

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->A_mod:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-interface {p1, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/DecompositionInterface;->decompose(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Z

    move-result p1

    xor-int/lit8 p1, p1, 0x1

    return p1
.end method

.method private computeUWV()Z
    .locals 5

    .line 230
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->bidiag:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/BidiagonalDecomposition_F64;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->diag:[D

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->off:[D

    invoke-interface {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/BidiagonalDecomposition_F64;->getDiagonal([D[D)V

    .line 231
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->qralg:Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->numRowsT:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->numColsT:I

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->diag:[D

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->off:[D

    invoke-virtual {v0, v1, v2, v3, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->setMatrix(II[D[D)V

    .line 235
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->computeU:Z

    const/4 v1, 0x1

    if-eqz v0, :cond_0

    .line 236
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->bidiag:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/BidiagonalDecomposition_F64;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->Ut:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    iget-boolean v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->compact:Z

    invoke-interface {v0, v2, v1, v3}, Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/BidiagonalDecomposition;->getU(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;ZZ)Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->Ut:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    .line 237
    :cond_0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->computeV:Z

    if-eqz v0, :cond_1

    .line 238
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->bidiag:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/BidiagonalDecomposition_F64;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->Vt:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    iget-boolean v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->compact:Z

    invoke-interface {v0, v2, v1, v3}, Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/BidiagonalDecomposition;->getV(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;ZZ)Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->Vt:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    .line 240
    :cond_1
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->qralg:Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;

    const/4 v2, 0x0

    invoke-virtual {v0, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->setFastValues(Z)V

    .line 241
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->computeU:Z

    const/4 v2, 0x0

    if-eqz v0, :cond_2

    .line 242
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->qralg:Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->Ut:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-virtual {v0, v3}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->setUt(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)V

    goto :goto_0

    .line 244
    :cond_2
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->qralg:Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;

    invoke-virtual {v0, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->setUt(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)V

    .line 245
    :goto_0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->computeV:Z

    if-eqz v0, :cond_3

    .line 246
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->qralg:Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->Vt:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-virtual {v0, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->setVt(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)V

    goto :goto_1

    .line 248
    :cond_3
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->qralg:Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;

    invoke-virtual {v0, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->setVt(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)V

    .line 252
    :goto_1
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->qralg:Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->process()Z

    move-result v0

    xor-int/2addr v0, v1

    return v0
.end method

.method private makeSingularPositive()V
    .locals 8

    .line 305
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->qralg:Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->getNumberOfSingularValues()I

    move-result v0

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->numSingular:I

    .line 306
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->qralg:Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->getSingularValues()[D

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->singularValues:[D

    const/4 v0, 0x0

    .line 308
    :goto_0
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->numSingular:I

    if-ge v0, v1, :cond_2

    .line 309
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->qralg:Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;

    invoke-virtual {v1, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->getSingularValue(I)D

    move-result-wide v1

    const-wide/16 v3, 0x0

    cmpg-double v5, v1, v3

    if-gez v5, :cond_0

    .line 312
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->singularValues:[D

    sub-double v1, v3, v1

    aput-wide v1, v5, v0

    .line 314
    iget-boolean v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->computeU:Z

    if-eqz v1, :cond_1

    .line 317
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->Ut:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    iget v1, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    mul-int v2, v0, v1

    add-int/2addr v1, v2

    :goto_1
    if-ge v2, v1, :cond_1

    .line 321
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->Ut:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-virtual {v5, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->get(I)D

    move-result-wide v6

    sub-double v6, v3, v6

    invoke-virtual {v5, v2, v6, v7}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->set(ID)D

    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    .line 325
    :cond_0
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->singularValues:[D

    aput-wide v1, v3, v0

    :cond_1
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_2
    return-void
.end method

.method private setup(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)Z
    .locals 4

    .line 261
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    iget p1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    const/4 v1, 0x0

    const/4 v2, 0x1

    if-le v0, p1, :cond_0

    move v3, v2

    goto :goto_0

    :cond_0
    move v3, v1

    :goto_0
    iput-boolean v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->transposed:Z

    if-eqz v3, :cond_1

    .line 265
    iget-boolean v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->prefComputeV:Z

    iput-boolean v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->computeU:Z

    .line 266
    iget-boolean v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->prefComputeU:Z

    iput-boolean v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->computeV:Z

    .line 267
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->numRowsT:I

    .line 268
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->numColsT:I

    goto :goto_1

    .line 270
    :cond_1
    iget-boolean v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->prefComputeU:Z

    iput-boolean v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->computeU:Z

    .line 271
    iget-boolean v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->prefComputeV:Z

    iput-boolean v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->computeV:Z

    .line 272
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->numRowsT:I

    .line 273
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->numColsT:I

    .line 276
    :goto_1
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->numRows:I

    .line 277
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->numCols:I

    .line 279
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->diag:[D

    if-eqz p1, :cond_2

    array-length p1, p1

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->numColsT:I

    if-ge p1, v0, :cond_3

    .line 280
    :cond_2
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->numColsT:I

    new-array v0, p1, [D

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->diag:[D

    sub-int/2addr p1, v2

    .line 281
    invoke-static {v1, p1}, Ljava/lang/Math;->max(II)I

    move-result p1

    new-array p1, p1, [D

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->off:[D

    .line 285
    :cond_3
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->declareBidiagonalDecomposition()V

    return v2
.end method

.method private undoTranspose()V
    .locals 2

    .line 219
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->transposed:Z

    if-eqz v0, :cond_0

    .line 220
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->Vt:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    .line 221
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->Ut:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->Vt:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    .line 222
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->Ut:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    :cond_0
    return-void
.end method


# virtual methods
.method protected declareBidiagonalDecomposition()V
    .locals 2

    .line 291
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->canUseTallBidiagonal:Z

    if-eqz v0, :cond_1

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->numRows:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->numCols:I

    mul-int/lit8 v1, v1, 0x2

    if-le v0, v1, :cond_1

    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->computeU:Z

    if-nez v0, :cond_1

    .line 292
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->bidiag:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/BidiagonalDecomposition_F64;

    if-eqz v0, :cond_0

    instance-of v0, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionTall_DDRM;

    if-nez v0, :cond_2

    .line 293
    :cond_0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionTall_DDRM;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionTall_DDRM;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->bidiag:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/BidiagonalDecomposition_F64;

    return-void

    .line 295
    :cond_1
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->bidiag:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/BidiagonalDecomposition_F64;

    if-eqz v0, :cond_3

    instance-of v0, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;

    if-nez v0, :cond_2

    goto :goto_0

    :cond_2
    return-void

    .line 296
    :cond_3
    :goto_0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->bidiag:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/BidiagonalDecomposition_F64;

    return-void
.end method

.method public decompose(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)Z
    .locals 2

    .line 180
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->setup(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)Z

    move-result v0

    const/4 v1, 0x0

    if-nez v0, :cond_0

    return v1

    .line 183
    :cond_0
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->bidiagonalization(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)Z

    move-result p1

    if-eqz p1, :cond_1

    return v1

    .line 186
    :cond_1
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->computeUWV()Z

    move-result p1

    if-eqz p1, :cond_2

    return v1

    .line 190
    :cond_2
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->makeSingularPositive()V

    .line 193
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->undoTranspose()V

    const/4 p1, 0x1

    return p1
.end method

.method public bridge synthetic decompose(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Z
    .locals 0

    .line 47
    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->decompose(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)Z

    move-result p1

    return p1
.end method

.method public getSingularValues()[D
    .locals 1

    .line 109
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->singularValues:[D

    return-object v0
.end method

.method public getV(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;Z)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;
    .locals 1

    .line 140
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->prefComputeV:Z

    if-eqz v0, :cond_2

    if-eqz p2, :cond_1

    if-nez p1, :cond_0

    .line 144
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->Vt:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    return-object p1

    .line 146
    :cond_0
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->Vt:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->setTo(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;)V

    return-object p1

    .line 148
    :cond_1
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->Vt:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    iget v0, p2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    iget p2, p2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    invoke-static {p1, v0, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->reshapeOrDeclare(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;II)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    move-result-object p1

    .line 149
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->Vt:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->transpose(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)V

    return-object p1

    .line 141
    :cond_2
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string p2, "As requested V was not computed."

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public bridge synthetic getV(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;Z)Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;
    .locals 0

    .line 47
    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->getV(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;Z)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    move-result-object p1

    return-object p1
.end method

.method public inputModified()Z
    .locals 1

    .line 200
    const/4 v0, 0x0

    return v0
.end method

.method public numberOfSingularValues()I
    .locals 1

    .line 114
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SvdImplicitQrDecompose_DDRM;->numSingular:I

    return v0
.end method

.method protected transpose(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)V
    .locals 0

    .line 156
    invoke-static {p2, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/CommonOps_DDRM;->transpose(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    return-void
.end method
