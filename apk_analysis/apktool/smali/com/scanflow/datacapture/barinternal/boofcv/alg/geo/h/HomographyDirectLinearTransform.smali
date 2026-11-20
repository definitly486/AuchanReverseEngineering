.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;
.super Ljava/lang/Object;
.source "HomographyDirectLinearTransform.java"


# instance fields
.field protected A:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

.field private final C1:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;

.field private final C1_inv:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;

.field private final C2:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;

.field private final C2_inv:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;

.field private final L:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;

.field protected N1:Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;

.field protected N2:Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;

.field private final R:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;

.field private final V1:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;

.field private final V1_inv:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;

.field private final V2:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;

.field private final V2_inv:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;

.field private adjust:Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/AdjustHomographyMatrix;

.field private exhaustiveConics:Z

.field normalize:Z

.field private shouldNormalize:Z

.field protected solverNullspace:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/SolveNullSpace;


# direct methods
.method public constructor <init>(Z)V
    .locals 3

    .line 110
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 75
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    const/4 v1, 0x1

    const/16 v2, 0x9

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;-><init>(II)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->A:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    .line 76
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/linsol/svd/SolveNullSpaceSvd_DDRM;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/linsol/svd/SolveNullSpaceSvd_DDRM;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->solverNullspace:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/SolveNullSpace;

    .line 79
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->N1:Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;

    .line 80
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->N2:Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;

    .line 83
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/AdjustHomographyMatrix;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/AdjustHomographyMatrix;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->adjust:Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/AdjustHomographyMatrix;

    const/4 v0, 0x0

    .line 91
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->exhaustiveConics:Z

    .line 94
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->C1:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;

    .line 95
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->V1:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;

    .line 96
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->C1_inv:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;

    .line 97
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->V1_inv:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;

    .line 98
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->C2:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;

    .line 99
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->V2:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;

    .line 100
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->C2_inv:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;

    .line 101
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->V2_inv:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;

    .line 102
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->L:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;

    .line 103
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->R:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;

    .line 111
    iput-boolean p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->normalize:Z

    return-void
.end method

.method private adjustPoint(Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair3D;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;)V
    .locals 2

    .line 227
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->shouldNormalize:Z

    if-eqz v0, :cond_0

    .line 228
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->N1:Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;

    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair3D;->p1:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;

    invoke-virtual {v0, v1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;->apply(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;)V

    .line 229
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->N2:Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;

    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair3D;->p2:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;

    invoke-virtual {p2, p1, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;->apply(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;)V

    return-void

    .line 231
    :cond_0
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair3D;->p1:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;

    invoke-virtual {p2, v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;

    .line 232
    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair3D;->p2:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;

    invoke-virtual {p3, p1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;

    return-void
.end method

.method private adjustPoint(Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)V
    .locals 2

    .line 213
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->shouldNormalize:Z

    if-eqz v0, :cond_0

    .line 214
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->N1:Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;

    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair;->p1:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-virtual {v0, v1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;->apply(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)V

    .line 215
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->N2:Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;

    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair;->p2:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-virtual {p2, p1, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;->apply(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)V

    return-void

    .line 217
    :cond_0
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair;->p1:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-virtual {p2, v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    .line 218
    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair;->p2:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-virtual {p3, p1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    return-void
.end method

.method public static undoNormalizationH(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;)V
    .locals 2

    .line 203
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleMatrix;->wrap(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleMatrix;

    move-result-object v0

    const/4 v1, 0x0

    .line 204
    invoke-virtual {p1, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;->matrix(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    move-result-object p1

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleMatrix;->wrap(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleMatrix;

    move-result-object p1

    .line 205
    invoke-virtual {p2, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;->matrixInv(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    move-result-object p2

    invoke-static {p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleMatrix;->wrap(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleMatrix;

    move-result-object p2

    .line 207
    invoke-virtual {p2, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->mult(Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ConstMatrix;)Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;

    move-result-object p2

    check-cast p2, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleMatrix;

    invoke-virtual {p2, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->mult(Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ConstMatrix;)Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleMatrix;

    .line 209
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->getDDRM()Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    move-result-object p1

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->setTo(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;)V

    return-void
.end method


# virtual methods
.method protected addConicPairConstraints(Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPairConic;Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPairConic;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;I)I
    .locals 0

    const/4 p1, 0x0

    .line 336
    throw p1
.end method

.method protected addConics(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;I)I
    .locals 5

    .line 310
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->exhaustiveConics:Z

    const/4 v1, 0x0

    const/4 v2, 0x0

    if-eqz v0, :cond_2

    .line 312
    :goto_0
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v0

    if-ge v1, v0, :cond_1

    add-int/lit8 v0, v1, 0x1

    move v3, v0

    .line 313
    :goto_1
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v4

    if-ge v3, v4, :cond_0

    .line 314
    invoke-interface {p1, v1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v4

    invoke-static {v4}, Lcom/scanflow/datacapture/barinternal/a/a$$ExternalSyntheticThrowCCEIfNotNull0;->m(Ljava/lang/Object;)V

    invoke-interface {p1, v3}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v4

    invoke-static {v4}, Lcom/scanflow/datacapture/barinternal/a/a$$ExternalSyntheticThrowCCEIfNotNull0;->m(Ljava/lang/Object;)V

    invoke-virtual {p0, v2, v2, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->addConicPairConstraints(Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPairConic;Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPairConic;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;I)I

    move-result p3

    add-int/lit8 v3, v3, 0x1

    goto :goto_1

    :cond_0
    move v1, v0

    goto :goto_0

    :cond_1
    return p3

    :cond_2
    const/4 v0, 0x1

    move v3, v0

    .line 319
    :goto_2
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v4

    if-ge v3, v4, :cond_3

    add-int/lit8 v4, v3, -0x1

    .line 320
    invoke-interface {p1, v4}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v4

    invoke-static {v4}, Lcom/scanflow/datacapture/barinternal/a/a$$ExternalSyntheticThrowCCEIfNotNull0;->m(Ljava/lang/Object;)V

    invoke-interface {p1, v3}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v4

    invoke-static {v4}, Lcom/scanflow/datacapture/barinternal/a/a$$ExternalSyntheticThrowCCEIfNotNull0;->m(Ljava/lang/Object;)V

    invoke-virtual {p0, v2, v2, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->addConicPairConstraints(Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPairConic;Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPairConic;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;I)I

    move-result p3

    add-int/lit8 v3, v3, 0x1

    goto :goto_2

    .line 322
    :cond_3
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v3

    .line 323
    invoke-interface {p1, v1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v1

    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/a/a$$ExternalSyntheticThrowCCEIfNotNull0;->m(Ljava/lang/Object;)V

    sub-int/2addr v3, v0

    invoke-interface {p1, v3}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/a/a$$ExternalSyntheticThrowCCEIfNotNull0;->m(Ljava/lang/Object;)V

    invoke-virtual {p0, v2, v2, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->addConicPairConstraints(Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPairConic;Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPairConic;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;I)I

    move-result p1

    return p1
.end method

.method protected addPoints2D(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;I)I
    .locals 14

    move-object/from16 v0, p2

    .line 247
    new-instance v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;-><init>()V

    .line 248
    new-instance v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-direct {v2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;-><init>()V

    const/4 v3, 0x0

    move/from16 v4, p3

    move v5, v3

    .line 250
    :goto_0
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v6

    if-ge v5, v6, :cond_0

    move-object v6, p1

    .line 251
    invoke-interface {p1, v5}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v7

    check-cast v7, Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair;

    .line 253
    invoke-direct {p0, v7, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->adjustPoint(Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)V

    .line 255
    iget-wide v8, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    neg-double v8, v8

    const/4 v7, 0x3

    invoke-virtual {v0, v4, v7, v8, v9}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    .line 256
    iget-wide v8, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    neg-double v8, v8

    const/4 v7, 0x4

    invoke-virtual {v0, v4, v7, v8, v9}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    const/4 v7, 0x5

    const-wide/high16 v8, -0x4010000000000000L    # -1.0

    .line 257
    invoke-virtual {v0, v4, v7, v8, v9}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    .line 258
    iget-wide v8, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    iget-wide v10, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    mul-double/2addr v8, v10

    const/4 v7, 0x6

    invoke-virtual {v0, v4, v7, v8, v9}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    .line 259
    iget-wide v8, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    iget-wide v10, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    mul-double/2addr v8, v10

    const/4 v10, 0x7

    invoke-virtual {v0, v4, v10, v8, v9}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    .line 260
    iget-wide v8, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    const/16 v11, 0x8

    invoke-virtual {v0, v4, v11, v8, v9}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    add-int/lit8 v8, v4, 0x1

    .line 262
    iget-wide v12, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    invoke-virtual {v0, v8, v3, v12, v13}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    .line 263
    iget-wide v12, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    const/4 v9, 0x1

    invoke-virtual {v0, v8, v9, v12, v13}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    const-wide/high16 v12, 0x3ff0000000000000L    # 1.0

    const/4 v9, 0x2

    .line 264
    invoke-virtual {v0, v8, v9, v12, v13}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    .line 265
    iget-wide v12, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    neg-double v12, v12

    move/from16 p3, v4

    iget-wide v3, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    mul-double/2addr v12, v3

    invoke-virtual {v0, v8, v7, v12, v13}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    .line 266
    iget-wide v3, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    neg-double v3, v3

    iget-wide v12, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    mul-double/2addr v3, v12

    invoke-virtual {v0, v8, v10, v3, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    .line 267
    iget-wide v3, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    neg-double v3, v3

    invoke-virtual {v0, v8, v11, v3, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    add-int/lit8 v4, p3, 0x2

    add-int/lit8 v5, v5, 0x1

    const/4 v3, 0x0

    goto :goto_0

    :cond_0
    move/from16 p3, v4

    return p3
.end method

.method protected addPoints3D(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;I)I
    .locals 17

    move-object/from16 v0, p2

    .line 274
    new-instance v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;

    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;-><init>()V

    .line 275
    new-instance v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;

    invoke-direct {v2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;-><init>()V

    const/4 v3, 0x0

    move/from16 v4, p3

    move v5, v3

    .line 277
    :goto_0
    invoke-interface/range {p1 .. p1}, Ljava/util/List;->size()I

    move-result v6

    if-ge v5, v6, :cond_0

    move-object/from16 v6, p1

    .line 278
    invoke-interface {v6, v5}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v7

    check-cast v7, Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair3D;

    move-object/from16 v8, p0

    .line 280
    invoke-direct {v8, v7, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->adjustPoint(Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair3D;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;)V

    .line 282
    iget-wide v9, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->z:D

    neg-double v9, v9

    iget-wide v11, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->x:D

    mul-double/2addr v9, v11

    const/4 v7, 0x3

    invoke-virtual {v0, v4, v7, v9, v10}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    .line 283
    iget-wide v9, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->z:D

    neg-double v9, v9

    iget-wide v11, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->y:D

    mul-double/2addr v9, v11

    const/4 v7, 0x4

    invoke-virtual {v0, v4, v7, v9, v10}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    .line 284
    iget-wide v9, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->z:D

    neg-double v9, v9

    iget-wide v11, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->z:D

    mul-double/2addr v9, v11

    const/4 v7, 0x5

    invoke-virtual {v0, v4, v7, v9, v10}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    .line 285
    iget-wide v9, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->y:D

    iget-wide v11, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->x:D

    mul-double/2addr v9, v11

    const/4 v7, 0x6

    invoke-virtual {v0, v4, v7, v9, v10}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    .line 286
    iget-wide v9, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->y:D

    iget-wide v11, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->y:D

    mul-double/2addr v9, v11

    const/4 v11, 0x7

    invoke-virtual {v0, v4, v11, v9, v10}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    .line 287
    iget-wide v9, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->y:D

    iget-wide v12, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->z:D

    mul-double/2addr v9, v12

    const/16 v12, 0x8

    invoke-virtual {v0, v4, v12, v9, v10}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    add-int/lit8 v9, v4, 0x1

    .line 289
    iget-wide v13, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->z:D

    move-wide v15, v13

    iget-wide v12, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->x:D

    mul-double v13, v15, v12

    invoke-virtual {v0, v9, v3, v13, v14}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    .line 290
    iget-wide v12, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->z:D

    iget-wide v14, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->y:D

    mul-double/2addr v12, v14

    const/4 v10, 0x1

    invoke-virtual {v0, v9, v10, v12, v13}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    .line 291
    iget-wide v12, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->z:D

    iget-wide v14, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->z:D

    mul-double/2addr v12, v14

    const/4 v10, 0x2

    invoke-virtual {v0, v9, v10, v12, v13}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    .line 292
    iget-wide v12, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->x:D

    neg-double v12, v12

    iget-wide v14, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->x:D

    mul-double/2addr v12, v14

    invoke-virtual {v0, v9, v7, v12, v13}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    .line 293
    iget-wide v12, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->x:D

    neg-double v12, v12

    iget-wide v14, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->y:D

    mul-double/2addr v12, v14

    invoke-virtual {v0, v9, v11, v12, v13}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    .line 294
    iget-wide v10, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->x:D

    neg-double v10, v10

    iget-wide v12, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->z:D

    mul-double/2addr v10, v12

    const/16 v7, 0x8

    invoke-virtual {v0, v9, v7, v10, v11}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    add-int/lit8 v4, v4, 0x2

    add-int/lit8 v5, v5, 0x1

    goto/16 :goto_0

    :cond_0
    move-object/from16 v8, p0

    return v4
.end method

.method protected computeH(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)Z
    .locals 2

    .line 190
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->solverNullspace:Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/SolveNullSpace;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->copy()Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    move-result-object p1

    const/4 v1, 0x1

    invoke-interface {v0, p1, v1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/SolveNullSpace;->process(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;ILcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Z

    move-result p1

    if-nez p1, :cond_0

    return v1

    :cond_0
    const/4 p1, 0x3

    .line 193
    iput p1, p2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    .line 194
    iput p1, p2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    const/4 p1, 0x0

    return p1
.end method

.method computeTotalRows(III)I
    .locals 0

    .line 223
    mul-int/lit8 p1, p1, 0x2

    mul-int/lit8 p2, p2, 0x2

    add-int/2addr p1, p2

    mul-int/lit8 p3, p3, 0x9

    add-int/2addr p1, p3

    return p1
.end method

.method public process(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)Z
    .locals 1

    const/4 v0, 0x0

    .line 127
    invoke-virtual {p0, p1, v0, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->process(Ljava/util/List;Ljava/util/List;Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)Z

    move-result p1

    return p1
.end method

.method public process(Ljava/util/List;Ljava/util/List;Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)Z
    .locals 4

    const/4 v0, 0x0

    if-eqz p1, :cond_0

    .line 146
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v1

    goto :goto_0

    :cond_0
    move v1, v0

    :goto_0
    if-eqz p2, :cond_1

    .line 147
    invoke-interface {p2}, Ljava/util/List;->size()I

    move-result v2

    goto :goto_1

    :cond_1
    move v2, v0

    :goto_1
    if-eqz p3, :cond_2

    .line 148
    invoke-interface {p3}, Ljava/util/List;->size()I

    move-result v3

    goto :goto_2

    :cond_2
    move v3, v0

    .line 150
    :goto_2
    invoke-virtual {p0, v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->computeTotalRows(III)I

    move-result v1

    .line 155
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->shouldNormalize:Z

    .line 160
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->A:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    const/16 v3, 0x9

    invoke-virtual {v2, v1, v3}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->reshape(II)V

    .line 161
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->A:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->zero()V

    if-eqz p1, :cond_3

    .line 165
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->A:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-virtual {p0, p1, v1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->addPoints2D(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;I)I

    move-result v1

    goto :goto_3

    :cond_3
    move v1, v0

    :goto_3
    if-eqz p2, :cond_4

    .line 167
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->A:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-virtual {p0, p2, v2, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->addPoints3D(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;I)I

    move-result v1

    :cond_4
    if-eqz p3, :cond_5

    .line 169
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->A:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-virtual {p0, p3, p2, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->addConics(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;I)I

    .line 172
    :cond_5
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->A:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-virtual {p0, p2, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->computeH(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)Z

    move-result p2

    if-eqz p2, :cond_6

    return v0

    .line 175
    :cond_6
    iget-boolean p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->shouldNormalize:Z

    if-eqz p2, :cond_7

    .line 176
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->N1:Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;

    iget-object p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->N2:Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;

    invoke-static {p4, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->undoNormalizationH(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/NormalizationPoint2D;)V

    :cond_7
    if-eqz p1, :cond_8

    .line 180
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->adjust:Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/AdjustHomographyMatrix;

    invoke-interface {p1, v0}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair;

    invoke-virtual {p2, p4, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/AdjustHomographyMatrix;->adjust(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair;)Z

    :cond_8
    const/4 p1, 0x1

    return p1
.end method
