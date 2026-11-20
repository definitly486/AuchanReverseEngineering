.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/UtilShapePolygon;
.super Ljava/lang/Object;
.source "UtilShapePolygon.java"


# direct methods
.method public static convert([Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;)Z
    .locals 5

    const/4 v0, 0x0

    move v1, v0

    .line 38
    :goto_0
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->size()I

    move-result v2

    if-ge v1, v2, :cond_1

    add-int/lit8 v2, v1, 0x1

    .line 39
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->size()I

    move-result v3

    rem-int v3, v2, v3

    .line 40
    aget-object v1, p0, v1

    aget-object v4, p0, v3

    invoke-virtual {p1, v3}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v3

    invoke-static {v1, v4, v3}, Lcom/scanflow/datacapture/barinternal/georegression/metric/Intersection2D_F64;->intersection(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v1

    if-nez v1, :cond_0

    return v0

    :cond_0
    move v1, v2

    goto :goto_0

    :cond_1
    const/4 p0, 0x1

    return p0
.end method
