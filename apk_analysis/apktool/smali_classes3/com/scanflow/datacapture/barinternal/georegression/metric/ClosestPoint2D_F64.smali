.class public abstract Lcom/scanflow/datacapture/barinternal/georegression/metric/ClosestPoint2D_F64;
.super Ljava/lang/Object;
.source "ClosestPoint2D_F64.java"


# direct methods
.method public static closestPointT(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;DDD)D
    .locals 5

    .line 162
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;->slope:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;

    iget-wide v1, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    div-double/2addr v1, p5

    .line 163
    iget-wide v3, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    div-double/2addr v3, p5

    .line 165
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;->p:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide p5, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    sub-double/2addr p1, p5

    mul-double/2addr p1, v1

    iget-wide p5, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    sub-double/2addr p3, p5

    mul-double/2addr p3, v3

    add-double/2addr p1, p3

    mul-double/2addr v1, v1

    mul-double/2addr v3, v3

    add-double/2addr v1, v3

    div-double/2addr p1, v1

    return-wide p1
.end method

.method public static closestPointT(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;D)D
    .locals 7

    .line 122
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;->slope:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;

    iget-wide v1, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    div-double/2addr v1, p2

    .line 123
    iget-wide v3, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    div-double/2addr v3, p2

    .line 125
    iget-wide p2, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;->p:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide v5, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    sub-double/2addr p2, v5

    mul-double/2addr p2, v1

    iget-wide v5, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    iget-wide p0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    sub-double/2addr v5, p0

    mul-double/2addr v5, v3

    add-double/2addr p2, v5

    mul-double/2addr v1, v1

    mul-double/2addr v3, v3

    add-double/2addr v1, v3

    div-double/2addr p2, v1

    return-wide p2
.end method
