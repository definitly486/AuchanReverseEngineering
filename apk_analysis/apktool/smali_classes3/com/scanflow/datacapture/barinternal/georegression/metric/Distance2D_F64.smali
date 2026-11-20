.class public abstract Lcom/scanflow/datacapture/barinternal/georegression/metric/Distance2D_F64;
.super Ljava/lang/Object;
.source "Distance2D_F64.java"


# direct methods
.method public static distanceSq(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;DD)D
    .locals 11

    .line 106
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;->slope:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;

    iget-wide v0, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    invoke-static {v0, v1}, Ljava/lang/Math;->abs(D)D

    move-result-wide v0

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;->slope:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;

    iget-wide v2, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    invoke-static {v2, v3}, Ljava/lang/Math;->abs(D)D

    move-result-wide v2

    invoke-static {v0, v1, v2, v3}, Ljava/lang/Math;->max(DD)D

    move-result-wide v9

    move-object v4, p0

    move-wide v5, p1

    move-wide v7, p3

    .line 108
    invoke-static/range {v4 .. v10}, Lcom/scanflow/datacapture/barinternal/georegression/metric/ClosestPoint2D_F64;->closestPointT(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;DDD)D

    move-result-wide p0

    .line 110
    iget-object p2, v4, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;->slope:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;

    iget-wide p3, p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    div-double/2addr p3, v9

    mul-double/2addr p3, p0

    iget-object v0, v4, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;->p:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide v1, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    add-double/2addr p3, v1

    .line 111
    iget-wide v1, p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    div-double/2addr v1, v9

    mul-double/2addr v1, p0

    iget-wide p0, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    add-double/2addr v1, p0

    sub-double p1, v5, p3

    sub-double p3, v7, v1

    mul-double/2addr p1, p1

    mul-double/2addr p3, p3

    add-double/2addr p1, p3

    return-wide p1
.end method

.method public static distanceSq(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)D
    .locals 9

    .line 82
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;->slope:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;

    iget-wide v0, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    invoke-static {v0, v1}, Ljava/lang/Math;->abs(D)D

    move-result-wide v0

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;->slope:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;

    iget-wide v2, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    invoke-static {v2, v3}, Ljava/lang/Math;->abs(D)D

    move-result-wide v2

    invoke-static {v0, v1, v2, v3}, Ljava/lang/Math;->max(DD)D

    move-result-wide v0

    .line 84
    invoke-static {p0, p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/georegression/metric/ClosestPoint2D_F64;->closestPointT(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;D)D

    move-result-wide v2

    .line 86
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;->slope:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;

    iget-wide v5, v4, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    div-double/2addr v5, v0

    mul-double/2addr v5, v2

    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;->p:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide v7, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    add-double/2addr v5, v7

    .line 87
    iget-wide v7, v4, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    div-double/2addr v7, v0

    mul-double/2addr v7, v2

    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    add-double/2addr v7, v0

    .line 89
    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    sub-double/2addr v0, v5

    .line 90
    iget-wide p0, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    sub-double/2addr p0, v7

    mul-double/2addr v0, v0

    mul-double/2addr p0, p0

    add-double/2addr v0, p0

    return-wide v0
.end method

.method public static distanceSq(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;DD)D
    .locals 20

    move-object/from16 v0, p0

    .line 184
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->b:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide v2, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->a:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide v4, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    sub-double v12, v2, v4

    .line 185
    iget-wide v14, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    iget-wide v6, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    sub-double v0, v14, v6

    sub-double v8, p1, v4

    mul-double/2addr v8, v12

    sub-double v10, p3, v6

    mul-double/2addr v10, v0

    add-double/2addr v8, v10

    mul-double v10, v12, v12

    mul-double v16, v0, v0

    add-double v10, v10, v16

    div-double v16, v8, v10

    const-wide/16 v8, 0x0

    cmpg-double v8, v16, v8

    if-gez v8, :cond_0

    move-wide/from16 v8, p1

    move-wide/from16 v10, p3

    .line 193
    invoke-static/range {v4 .. v11}, Lcom/scanflow/datacapture/barinternal/georegression/geometry/UtilPoint2D_F64;->distanceSq(DDDD)D

    move-result-wide v0

    return-wide v0

    :cond_0
    move-wide v10, v4

    move-wide/from16 v18, v6

    const-wide/high16 v4, 0x3ff0000000000000L    # 1.0

    cmpl-double v4, v16, v4

    if-lez v4, :cond_1

    move-wide/from16 v6, p1

    move-wide/from16 v8, p3

    move-wide v4, v14

    .line 195
    invoke-static/range {v2 .. v9}, Lcom/scanflow/datacapture/barinternal/georegression/geometry/UtilPoint2D_F64;->distanceSq(DDDD)D

    move-result-wide v0

    return-wide v0

    :cond_1
    mul-double v12, v12, v16

    add-double v2, v10, v12

    mul-double v16, v16, v0

    add-double v4, v18, v16

    move-wide/from16 v6, p1

    move-wide/from16 v8, p3

    .line 198
    invoke-static/range {v2 .. v9}, Lcom/scanflow/datacapture/barinternal/georegression/geometry/UtilPoint2D_F64;->distanceSq(DDDD)D

    move-result-wide v0

    return-wide v0
.end method
