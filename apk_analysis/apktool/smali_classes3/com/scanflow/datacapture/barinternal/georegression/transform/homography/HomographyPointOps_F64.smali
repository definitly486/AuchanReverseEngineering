.class public abstract Lcom/scanflow/datacapture/barinternal/georegression/transform/homography/HomographyPointOps_F64;
.super Ljava/lang/Object;
.source "HomographyPointOps_F64.java"


# direct methods
.method public static transform(Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;DDLcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;
    .locals 6

    if-nez p5, :cond_0

    .line 79
    new-instance p5, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-direct {p5}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;-><init>()V

    .line 82
    :cond_0
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a31:D

    mul-double/2addr v0, p1

    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a32:D

    mul-double/2addr v2, p3

    add-double/2addr v0, v2

    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a33:D

    add-double/2addr v0, v2

    .line 84
    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a11:D

    mul-double/2addr v2, p1

    iget-wide v4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a12:D

    mul-double/2addr v4, p3

    add-double/2addr v2, v4

    iget-wide v4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a13:D

    add-double/2addr v2, v4

    div-double/2addr v2, v0

    iput-wide v2, p5, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    .line 85
    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a21:D

    mul-double/2addr v2, p1

    iget-wide p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a22:D

    mul-double/2addr p1, p3

    add-double/2addr v2, p1

    iget-wide p0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a23:D

    add-double/2addr v2, p0

    div-double/2addr v2, v0

    iput-wide v2, p5, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    return-object p5
.end method
