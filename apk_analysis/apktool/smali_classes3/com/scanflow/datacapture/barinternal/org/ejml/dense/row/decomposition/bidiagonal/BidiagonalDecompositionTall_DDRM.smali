.class public Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionTall_DDRM;
.super Ljava/lang/Object;
.source "BidiagonalDecompositionTall_DDRM.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/BidiagonalDecomposition_F64;


# instance fields
.field B:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

.field decompBi:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/BidiagonalDecomposition_F64;

.field decompQRP:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/QRPDecomposition_F64;

.field m:I

.field min:I

.field n:I


# direct methods
.method public constructor <init>()V
    .locals 2

    .line 60
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const/16 v0, 0x1f4

    const/16 v1, 0x64

    .line 62
    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/factory/DecompositionFactory_DDRM;->qrp(II)Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/QRPDecomposition_F64;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionTall_DDRM;->decompQRP:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/QRPDecomposition_F64;

    .line 64
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionTall_DDRM;->decompBi:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/BidiagonalDecomposition_F64;

    .line 66
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    const/4 v1, 0x1

    invoke-direct {v0, v1, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;-><init>(II)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionTall_DDRM;->B:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    return-void
.end method


# virtual methods
.method public decompose(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)Z
    .locals 3

    .line 134
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionTall_DDRM;->decompQRP:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/QRPDecomposition_F64;

    invoke-interface {v0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/DecompositionInterface;->decompose(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Z

    move-result v0

    const/4 v1, 0x0

    if-nez v0, :cond_0

    return v1

    .line 138
    :cond_0
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionTall_DDRM;->m:I

    .line 139
    iget p1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionTall_DDRM;->n:I

    .line 140
    invoke-static {v0, p1}, Ljava/lang/Math;->min(II)I

    move-result p1

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionTall_DDRM;->min:I

    .line 141
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionTall_DDRM;->B:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionTall_DDRM;->n:I

    invoke-virtual {v0, p1, v2, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->reshape(IIZ)V

    .line 143
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionTall_DDRM;->decompQRP:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/QRPDecomposition_F64;

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionTall_DDRM;->B:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    const/4 v1, 0x1

    invoke-interface {p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/QRDecomposition;->getR(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;Z)Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    .line 147
    new-instance p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionTall_DDRM;->min:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionTall_DDRM;->n:I

    invoke-direct {p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;-><init>(II)V

    .line 148
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionTall_DDRM;->decompQRP:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/QRPDecomposition_F64;

    const/4 v1, 0x0

    invoke-interface {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/QRPDecomposition;->getColPivotMatrix(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    .line 150
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionTall_DDRM;->B:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-static {v1, v0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/CommonOps_DDRM;->multTransB(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;

    .line 151
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionTall_DDRM;->B:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->setTo(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;)V

    .line 153
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionTall_DDRM;->decompBi:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/BidiagonalDecomposition_F64;

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionTall_DDRM;->B:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-interface {p1, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/DecompositionInterface;->decompose(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Z

    move-result p1

    return p1
.end method

.method public bridge synthetic decompose(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Z
    .locals 0

    .line 60
    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionTall_DDRM;->decompose(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)Z

    move-result p1

    return p1
.end method

.method public getDiagonal([D[D)V
    .locals 4

    .line 77
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionTall_DDRM;->B:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    const/4 v1, 0x0

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->get(I)D

    move-result-wide v2

    aput-wide v2, p1, v1

    const/4 v0, 0x1

    .line 78
    :goto_0
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionTall_DDRM;->n:I

    if-ge v0, v1, :cond_0

    .line 79
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionTall_DDRM;->B:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-virtual {v1, v0, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->unsafe_get(II)D

    move-result-wide v1

    aput-wide v1, p1, v0

    add-int/lit8 v1, v0, -0x1

    .line 80
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionTall_DDRM;->B:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-virtual {v2, v1, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->unsafe_get(II)D

    move-result-wide v2

    aput-wide v2, p2, v1

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public getU(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;ZZ)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;
    .locals 6

    .line 101
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionTall_DDRM;->m:I

    iget v4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionTall_DDRM;->n:I

    iget v5, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionTall_DDRM;->min:I

    const/4 v1, 0x0

    move-object v0, p1

    move v2, p3

    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->handleU(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;ZZIII)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    move-result-object p1

    const/4 p3, 0x1

    const/4 v0, 0x0

    if-eqz v2, :cond_0

    .line 105
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionTall_DDRM;->decompQRP:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/QRPDecomposition_F64;

    invoke-interface {v2, v0, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/QRDecomposition;->getQ(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;Z)Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    .line 106
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionTall_DDRM;->decompBi:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/BidiagonalDecomposition_F64;

    invoke-interface {v3, v0, v1, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/BidiagonalDecomposition;->getU(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;ZZ)Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    move-result-object p3

    check-cast p3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    .line 108
    invoke-static {v2, p3, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/CommonOps_DDRM;->mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;

    goto :goto_0

    .line 111
    :cond_0
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionTall_DDRM;->decompQRP:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/QRPDecomposition_F64;

    invoke-interface {v2, p1, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/QRDecomposition;->getQ(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;Z)Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    .line 112
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionTall_DDRM;->decompBi:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/BidiagonalDecomposition_F64;

    invoke-interface {v3, v0, v1, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/BidiagonalDecomposition;->getU(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;ZZ)Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    move-result-object p3

    check-cast p3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    .line 113
    iget v0, v2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionTall_DDRM;->min:I

    invoke-static {v2, v1, v0, v1, v3}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/CommonOps_DDRM;->extract(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;IIII)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    move-result-object v0

    .line 114
    new-instance v3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    iget v4, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    iget v5, p3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    invoke-direct {v3, v4, v5}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;-><init>(II)V

    .line 116
    invoke-static {v0, p3, v3}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/CommonOps_DDRM;->mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;

    .line 117
    invoke-static {v3, v2, v1, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/CommonOps_DDRM;->insert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;II)V

    :goto_0
    if-eqz p2, :cond_1

    .line 121
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/CommonOps_DDRM;->transpose(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)V

    :cond_1
    return-object p1
.end method

.method public bridge synthetic getU(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;ZZ)Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;
    .locals 0

    .line 60
    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-virtual {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionTall_DDRM;->getU(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;ZZ)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    move-result-object p1

    return-object p1
.end method

.method public getV(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;ZZ)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;
    .locals 1

    .line 128
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionTall_DDRM;->decompBi:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/BidiagonalDecomposition_F64;

    invoke-interface {v0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/BidiagonalDecomposition;->getV(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;ZZ)Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    return-object p1
.end method

.method public bridge synthetic getV(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;ZZ)Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;
    .locals 0

    .line 60
    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-virtual {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionTall_DDRM;->getV(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;ZZ)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    move-result-object p1

    return-object p1
.end method
