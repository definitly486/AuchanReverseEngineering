.class public abstract Lcom/scanflow/datacapture/barinternal/georegression/geometry/UtilLine2D_F64;
.super Ljava/lang/Object;
.source "UtilLine2D_F64.java"


# direct methods
.method public static convert(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;
    .locals 4

    if-nez p1, :cond_0

    .line 104
    new-instance p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;-><init>()V

    .line 106
    :cond_0
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;->angle:D

    invoke-static {v0, v1}, Ljava/lang/Math;->cos(D)D

    move-result-wide v0

    .line 107
    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;->angle:D

    invoke-static {v2, v3}, Ljava/lang/Math;->sin(D)D

    move-result-wide v2

    .line 109
    iput-wide v0, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->A:D

    .line 110
    iput-wide v2, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->B:D

    .line 111
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;->distance:D

    neg-double v0, v0

    iput-wide v0, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->C:D

    return-object p1
.end method

.method public static convert(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;
    .locals 1

    .line 166
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->a:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->b:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-static {v0, p0, p1}, Lcom/scanflow/datacapture/barinternal/georegression/geometry/UtilLine2D_F64;->convert(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    move-result-object p0

    return-object p0
.end method

.method public static convert(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;
    .locals 6

    if-nez p2, :cond_0

    .line 180
    new-instance p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    invoke-direct {p2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;-><init>()V

    .line 182
    :cond_0
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    iget-wide v2, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    sub-double v2, v0, v2

    iput-wide v2, p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->A:D

    .line 183
    iget-wide v4, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    iget-wide p0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    sub-double/2addr v4, p0

    iput-wide v4, p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->B:D

    mul-double/2addr v2, p0

    mul-double/2addr v4, v0

    add-double/2addr v2, v4

    neg-double p0, v2

    .line 184
    iput-wide p0, p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->C:D

    return-object p2
.end method

.method public static convert(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;
    .locals 5

    if-nez p1, :cond_0

    .line 149
    new-instance p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;-><init>()V

    .line 151
    :cond_0
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;->p:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->a:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    .line 152
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;->slope:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->slopeX()D

    move-result-wide v1

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->slopeY()D

    move-result-wide v3

    invoke-virtual {v0, v1, v2, v3, v4}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->setTo(DD)Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;

    return-object p1
.end method
