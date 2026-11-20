.class public abstract Lcom/scanflow/datacapture/barinternal/georegression/metric/Area2D_F64;
.super Ljava/lang/Object;
.source "Area2D_F64.java"


# direct methods
.method public static polygonSimple(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;)D
    .locals 15

    const/4 v0, 0x0

    .line 78
    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v1

    const/4 v2, 0x1

    .line 79
    invoke-virtual {p0, v2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v3

    const-wide/16 v4, 0x0

    const/4 v6, 0x2

    move-object v14, v3

    move-object v3, v1

    move-object v1, v14

    .line 80
    :goto_0
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->size()I

    move-result v7

    if-ge v6, v7, :cond_0

    .line 81
    invoke-virtual {p0, v6}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v7

    .line 83
    iget-wide v8, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    iget-wide v10, v7, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    iget-wide v12, v3, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    sub-double/2addr v10, v12

    mul-double/2addr v8, v10

    add-double/2addr v4, v8

    add-int/lit8 v6, v6, 0x1

    move-object v3, v1

    move-object v1, v7

    goto :goto_0

    .line 88
    :cond_0
    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v0

    .line 89
    iget-wide v6, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    iget-wide v8, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    iget-wide v10, v3, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    sub-double/2addr v8, v10

    mul-double/2addr v6, v8

    add-double/2addr v4, v6

    .line 91
    invoke-virtual {p0, v2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object p0

    .line 92
    iget-wide v2, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    iget-wide v6, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    iget-wide v0, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    sub-double/2addr v6, v0

    mul-double/2addr v2, v6

    add-double/2addr v4, v2

    const-wide/high16 v0, 0x4000000000000000L    # 2.0

    div-double/2addr v4, v0

    .line 94
    invoke-static {v4, v5}, Ljava/lang/Math;->abs(D)D

    move-result-wide v0

    return-wide v0
.end method
