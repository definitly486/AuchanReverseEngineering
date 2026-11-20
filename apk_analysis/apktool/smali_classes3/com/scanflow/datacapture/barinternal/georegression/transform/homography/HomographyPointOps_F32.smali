.class public abstract Lcom/scanflow/datacapture/barinternal/georegression/transform/homography/HomographyPointOps_F32;
.super Ljava/lang/Object;
.source "HomographyPointOps_F32.java"


# direct methods
.method public static transform(Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;FFLcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;
    .locals 3

    if-nez p3, :cond_0

    .line 81
    new-instance p3, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;

    invoke-direct {p3}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;-><init>()V

    .line 84
    :cond_0
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a31:F

    mul-float/2addr v0, p1

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a32:F

    mul-float/2addr v1, p2

    add-float/2addr v0, v1

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a33:F

    add-float/2addr v0, v1

    .line 86
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a11:F

    mul-float/2addr v1, p1

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a12:F

    mul-float/2addr v2, p2

    add-float/2addr v1, v2

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a13:F

    add-float/2addr v1, v2

    div-float/2addr v1, v0

    iput v1, p3, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;->x:F

    .line 87
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a21:F

    mul-float/2addr v1, p1

    iget p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a22:F

    mul-float/2addr p1, p2

    add-float/2addr v1, p1

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a23:F

    add-float/2addr v1, p0

    div-float/2addr v1, v0

    iput v1, p3, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;->y:F

    return-object p3
.end method
