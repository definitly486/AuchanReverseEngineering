.class public Lcom/scanflow/datacapture/barinternal/boofcv/abst/geo/h/HomographyDLT_to_Epipolar;
.super Ljava/lang/Object;
.source "HomographyDLT_to_Epipolar.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/boofcv/abst/geo/Estimate1ofEpipolar;


# instance fields
.field alg:Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;)V
    .locals 0

    .line 36
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 37
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/geo/h/HomographyDLT_to_Epipolar;->alg:Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;

    return-void
.end method


# virtual methods
.method public process(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)Z
    .locals 1

    .line 42
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/geo/h/HomographyDLT_to_Epipolar;->alg:Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;

    invoke-virtual {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;->process(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)Z

    move-result p1

    return p1
.end method

.method public bridge synthetic process(Ljava/util/List;Ljava/lang/Object;)Z
    .locals 0

    .line 33
    check-cast p2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/geo/h/HomographyDLT_to_Epipolar;->process(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)Z

    move-result p1

    return p1
.end method
