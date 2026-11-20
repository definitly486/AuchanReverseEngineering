.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/factory/geo/FactoryMultiView;
.super Ljava/lang/Object;
.source "FactoryMultiView.java"


# direct methods
.method public static homographyDLT(Z)Lcom/scanflow/datacapture/barinternal/boofcv/abst/geo/h/HomographyDLT_to_Epipolar;
    .locals 2

    .line 179
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/geo/h/HomographyDLT_to_Epipolar;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;

    invoke-direct {v1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;-><init>(Z)V

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/geo/h/HomographyDLT_to_Epipolar;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/alg/geo/h/HomographyDirectLinearTransform;)V

    return-object v0
.end method
