.class public Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/linsol/svd/SolveNullSpaceSvd_DDRM;
.super Ljava/lang/Object;
.source "SolveNullSpaceSvd_DDRM.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/SolveNullSpace;


# instance fields
.field V:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

.field compact:Z

.field svd:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/SingularValueDecomposition_F64;


# direct methods
.method public constructor <init>()V
    .locals 2

    .line 32
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const/4 v0, 0x1

    .line 34
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/linsol/svd/SolveNullSpaceSvd_DDRM;->compact:Z

    const/4 v1, 0x0

    .line 35
    invoke-static {v0, v0, v1, v0, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/factory/DecompositionFactory_DDRM;->svd(IIZZZ)Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/SingularValueDecomposition_F64;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/linsol/svd/SolveNullSpaceSvd_DDRM;->svd:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/SingularValueDecomposition_F64;

    return-void
.end method


# virtual methods
.method public process(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;ILcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)Z
    .locals 12

    .line 40
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    const/4 v2, 0x0

    const/4 v3, 0x1

    if-le v0, v1, :cond_0

    .line 41
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/linsol/svd/SolveNullSpaceSvd_DDRM;->compact:Z

    if-eqz v0, :cond_1

    .line 42
    invoke-static {v3, v3, v2, v3, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/factory/DecompositionFactory_DDRM;->svd(IIZZZ)Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/SingularValueDecomposition_F64;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/linsol/svd/SolveNullSpaceSvd_DDRM;->svd:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/SingularValueDecomposition_F64;

    .line 43
    iput-boolean v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/linsol/svd/SolveNullSpaceSvd_DDRM;->compact:Z

    goto :goto_0

    .line 46
    :cond_0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/linsol/svd/SolveNullSpaceSvd_DDRM;->compact:Z

    if-nez v0, :cond_1

    .line 47
    invoke-static {v3, v3, v2, v3, v3}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/factory/DecompositionFactory_DDRM;->svd(IIZZZ)Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/SingularValueDecomposition_F64;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/linsol/svd/SolveNullSpaceSvd_DDRM;->svd:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/SingularValueDecomposition_F64;

    .line 48
    iput-boolean v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/linsol/svd/SolveNullSpaceSvd_DDRM;->compact:Z

    .line 52
    :cond_1
    :goto_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/linsol/svd/SolveNullSpaceSvd_DDRM;->svd:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/SingularValueDecomposition_F64;

    invoke-interface {v0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/DecompositionInterface;->decompose(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Z

    move-result p1

    if-nez p1, :cond_2

    return v2

    .line 55
    :cond_2
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/linsol/svd/SolveNullSpaceSvd_DDRM;->svd:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/SingularValueDecomposition_F64;

    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/SingularValueDecomposition_F64;->getSingularValues()[D

    move-result-object v6

    .line 56
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/linsol/svd/SolveNullSpaceSvd_DDRM;->svd:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/SingularValueDecomposition_F64;

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/linsol/svd/SolveNullSpaceSvd_DDRM;->V:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-interface {p1, v0, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/SingularValueDecomposition;->getV(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;Z)Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/linsol/svd/SolveNullSpaceSvd_DDRM;->V:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    .line 58
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/linsol/svd/SolveNullSpaceSvd_DDRM;->svd:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/SingularValueDecomposition_F64;

    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/SingularValueDecomposition;->numberOfSingularValues()I

    move-result v7

    iget-object v8, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/linsol/svd/SolveNullSpaceSvd_DDRM;->V:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    const/4 v9, 0x0

    const/4 v4, 0x0

    const/4 v5, 0x0

    invoke-static/range {v4 .. v9}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/SingularOps_DDRM;->descendingOrder(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;Z[DILcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;Z)V

    .line 60
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/linsol/svd/SolveNullSpaceSvd_DDRM;->V:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    iget p1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    invoke-virtual {p3, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->reshape(II)V

    .line 61
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/linsol/svd/SolveNullSpaceSvd_DDRM;->V:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    iget v6, v4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    iget v8, v4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    sub-int v7, v8, p2

    const/4 v10, 0x0

    const/4 v11, 0x0

    move-object v9, p3

    invoke-static/range {v4 .. v11}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/CommonOps_DDRM;->extract(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;IIIILcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;II)V

    return v3
.end method

.method public bridge synthetic process(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;ILcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Z
    .locals 0

    .line 31
    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    check-cast p3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-virtual {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/linsol/svd/SolveNullSpaceSvd_DDRM;->process(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;ILcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)Z

    move-result p1

    return p1
.end method
