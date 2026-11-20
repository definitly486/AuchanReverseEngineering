.class public abstract Lcom/scanflow/datacapture/barinternal/georegression/struct/ConvertFloatType;
.super Ljava/lang/Object;
.source "ConvertFloatType.java"


# direct methods
.method public static convert(Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;)Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;
    .locals 0

    if-nez p1, :cond_0

    .line 92
    new-instance p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;-><init>()V

    .line 95
    :cond_0
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/ConvertMatrixData;->convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;)V

    return-object p1
.end method
