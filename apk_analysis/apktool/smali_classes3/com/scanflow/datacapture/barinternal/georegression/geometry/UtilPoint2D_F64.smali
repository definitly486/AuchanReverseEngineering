.class public abstract Lcom/scanflow/datacapture/barinternal/georegression/geometry/UtilPoint2D_F64;
.super Ljava/lang/Object;
.source "UtilPoint2D_F64.java"


# direct methods
.method public static distanceSq(DDDD)D
    .locals 0

    .line 101
    sub-double/2addr p4, p0

    sub-double/2addr p6, p2

    mul-double/2addr p4, p4

    mul-double/2addr p6, p6

    add-double/2addr p4, p6

    return-wide p4
.end method

.method public static mean(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;
    .locals 4

    if-nez p2, :cond_0

    .line 176
    new-instance p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-direct {p2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;-><init>()V

    .line 178
    :cond_0
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    iget-wide v2, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    add-double/2addr v0, v2

    const-wide/high16 v2, 0x4000000000000000L    # 2.0

    div-double/2addr v0, v2

    iput-wide v0, p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    .line 179
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    iget-wide p0, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    add-double/2addr v0, p0

    div-double/2addr v0, v2

    iput-wide v0, p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    return-object p2
.end method
