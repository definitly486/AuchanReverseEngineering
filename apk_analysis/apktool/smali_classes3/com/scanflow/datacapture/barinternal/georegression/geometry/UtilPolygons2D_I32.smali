.class public abstract Lcom/scanflow/datacapture/barinternal/georegression/geometry/UtilPolygons2D_I32;
.super Ljava/lang/Object;
.source "UtilPolygons2D_I32.java"


# direct methods
.method public static isCCW(Ljava/util/List;)Z
    .locals 7

    .line 85
    invoke-interface {p0}, Ljava/util/List;->size()I

    move-result v0

    const/4 v1, 0x0

    move v2, v1

    move v3, v2

    :goto_0
    if-ge v2, v0, :cond_1

    add-int/lit8 v4, v2, 0x1

    .line 88
    rem-int v5, v4, v0

    add-int/lit8 v6, v2, 0x2

    .line 89
    rem-int/2addr v6, v0

    .line 91
    invoke-interface {p0, v2}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    invoke-interface {p0, v5}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v5

    check-cast v5, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    invoke-interface {p0, v6}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    invoke-static {v2, v5, v6}, Lcom/scanflow/datacapture/barinternal/georegression/geometry/UtilPolygons2D_I32;->isPositiveZ(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;)Z

    move-result v2

    if-eqz v2, :cond_0

    add-int/lit8 v3, v3, 0x1

    goto :goto_1

    :cond_0
    add-int/lit8 v3, v3, -0x1

    :goto_1
    move v2, v4

    goto :goto_0

    :cond_1
    if-gez v3, :cond_2

    const/4 p0, 0x1

    return p0

    :cond_2
    return v1
.end method

.method public static isPositiveZ(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;)Z
    .locals 3

    .line 166
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    sub-int/2addr v0, v1

    .line 167
    iget p0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    iget p1, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    sub-int/2addr p0, p1

    .line 169
    iget v2, p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    sub-int/2addr v2, v1

    .line 170
    iget p2, p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    sub-int/2addr p2, p1

    mul-int/2addr v0, p2

    mul-int/2addr p0, v2

    sub-int/2addr v0, p0

    if-lez v0, :cond_0

    const/4 p0, 0x1

    return p0

    :cond_0
    const/4 p0, 0x0

    return p0
.end method
