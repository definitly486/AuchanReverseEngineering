.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/AdjustHomographyMatrix;
.super Ljava/lang/Object;
.source "AdjustHomographyMatrix.java"


# instance fields
.field H_t:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

.field protected svd:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/SingularValueDecomposition_F64;


# direct methods
.method public constructor <init>()V
    .locals 3

    .line 39
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 41
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SafeSvd_DDRM;

    const/4 v1, 0x0

    const/4 v2, 0x1

    invoke-static {v1, v1, v2, v2, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/factory/DecompositionFactory_DDRM;->svd(IIZZZ)Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/SingularValueDecomposition_F64;

    move-result-object v1

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/SafeSvd_DDRM;-><init>(Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/SingularValueDecomposition_F64;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/AdjustHomographyMatrix;->svd:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/SingularValueDecomposition_F64;

    .line 43
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    const/4 v1, 0x3

    invoke-direct {v0, v1, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;-><init>(II)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/AdjustHomographyMatrix;->H_t:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    return-void
.end method


# virtual methods
.method public adjust(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair;)Z
    .locals 1

    .line 46
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/AdjustHomographyMatrix;->findScaleH(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)Z

    move-result v0

    if-nez v0, :cond_0

    const/4 p1, 0x0

    return p1

    .line 49
    :cond_0
    invoke-virtual {p0, p2, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/AdjustHomographyMatrix;->adjustHomographSign(Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)V

    const/4 p1, 0x1

    return p1
.end method

.method protected adjustHomographSign(Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)V
    .locals 4

    .line 85
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair;->p2:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair;->p1:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-static {v0, p2, p1}, Lcom/scanflow/datacapture/barinternal/georegression/geometry/GeometryMath_F64;->innerProd(Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;)D

    move-result-wide v0

    const-wide/16 v2, 0x0

    cmpg-double p1, v0, v2

    if-gez p1, :cond_0

    const-wide/high16 v0, -0x4010000000000000L    # -1.0

    .line 88
    invoke-static {v0, v1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/CommonOps_DDRM;->scale(DLcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;)V

    :cond_0
    return-void
.end method

.method protected findScaleH(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)Z
    .locals 4

    .line 67
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/AdjustHomographyMatrix;->svd:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/SingularValueDecomposition_F64;

    invoke-interface {v0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/DecompositionInterface;->decompose(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Z

    move-result v0

    const/4 v1, 0x0

    if-nez v0, :cond_0

    return v1

    .line 70
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/AdjustHomographyMatrix;->svd:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/SingularValueDecomposition_F64;

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/SingularValueDecomposition_F64;->getSingularValues()[D

    move-result-object v0

    const/4 v2, 0x3

    invoke-static {v0, v1, v2}, Ljava/util/Arrays;->sort([DII)V

    .line 72
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/AdjustHomographyMatrix;->svd:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/SingularValueDecomposition_F64;

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/SingularValueDecomposition_F64;->getSingularValues()[D

    move-result-object v0

    const/4 v1, 0x1

    aget-wide v2, v0, v1

    .line 73
    invoke-static {p1, v2, v3}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/CommonOps_DDRM;->divide(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;D)V

    return v1
.end method
