.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/robust/GenerateHomographyLinear;
.super Ljava/lang/Object;
.source "GenerateHomographyLinear.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/org/ddogleg/fitting/modelset/ModelGenerator;


# instance fields
.field H:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

.field alg:Lcom/scanflow/datacapture/barinternal/boofcv/abst/geo/Estimate1ofEpipolar;


# direct methods
.method public constructor <init>(Z)V
    .locals 2

    .line 44
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 42
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    const/4 v1, 0x3

    invoke-direct {v0, v1, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;-><init>(II)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/robust/GenerateHomographyLinear;->H:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    .line 45
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/geo/FactoryMultiView;->homographyDLT(Z)Lcom/scanflow/datacapture/barinternal/boofcv/abst/geo/h/HomographyDLT_to_Epipolar;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/robust/GenerateHomographyLinear;->alg:Lcom/scanflow/datacapture/barinternal/boofcv/abst/geo/Estimate1ofEpipolar;

    return-void
.end method


# virtual methods
.method public generate(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;)Z
    .locals 2

    .line 61
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/robust/GenerateHomographyLinear;->alg:Lcom/scanflow/datacapture/barinternal/boofcv/abst/geo/Estimate1ofEpipolar;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/robust/GenerateHomographyLinear;->H:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-interface {v0, p1, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/GeoModelEstimator1;->process(Ljava/util/List;Ljava/lang/Object;)Z

    move-result p1

    if-nez p1, :cond_0

    const/4 p1, 0x0

    return p1

    .line 64
    :cond_0
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/robust/GenerateHomographyLinear;->H:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/UtilHomography_F64;->convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;

    const/4 p1, 0x1

    return p1
.end method

.method public bridge synthetic generate(Ljava/util/List;Ljava/lang/Object;)Z
    .locals 0

    .line 37
    check-cast p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/robust/GenerateHomographyLinear;->generate(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;)Z

    move-result p1

    return p1
.end method
