.class public abstract Lcom/scanflow/datacapture/barinternal/georegression/geometry/UtilPolygons2D_F64;
.super Ljava/lang/Object;
.source "UtilPolygons2D_F64.java"


# direct methods
.method public static isConvex(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;)Z
    .locals 16

    .line 48
    invoke-virtual/range {p0 .. p0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->size()I

    move-result v0

    const/4 v2, 0x0

    const/4 v3, 0x0

    :goto_0
    if-ge v2, v0, :cond_1

    add-int/lit8 v4, v2, 0x1

    .line 51
    rem-int v5, v4, v0

    add-int/lit8 v6, v2, 0x2

    .line 52
    rem-int/2addr v6, v0

    move-object/from16 v7, p0

    .line 54
    iget-object v8, v7, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->vertexes:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    iget-object v8, v8, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->data:[Ljava/lang/Object;

    move-object v9, v8

    check-cast v9, [Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    aget-object v2, v9, v2

    .line 55
    move-object v9, v8

    check-cast v9, [Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    aget-object v5, v9, v5

    .line 56
    check-cast v8, [Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    aget-object v6, v8, v6

    .line 58
    iget-wide v8, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    iget-wide v10, v5, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    sub-double/2addr v8, v10

    .line 59
    iget-wide v12, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    iget-wide v14, v5, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    sub-double/2addr v12, v14

    const/4 v5, 0x0

    .line 61
    iget-wide v1, v6, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    sub-double/2addr v1, v10

    .line 62
    iget-wide v10, v6, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    sub-double/2addr v10, v14

    mul-double/2addr v8, v10

    mul-double/2addr v12, v1

    sub-double/2addr v8, v12

    const-wide/16 v1, 0x0

    cmpl-double v1, v8, v1

    if-lez v1, :cond_0

    add-int/lit8 v3, v3, 0x1

    :cond_0
    move v2, v4

    goto :goto_0

    :cond_1
    const/4 v5, 0x0

    if-eqz v3, :cond_3

    if-ne v3, v0, :cond_2

    goto :goto_1

    :cond_2
    return v5

    :cond_3
    :goto_1
    const/4 v0, 0x1

    return v0
.end method

.method public static removeAdjacentDuplicates(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;D)V
    .locals 5

    .line 590
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->vertexes:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size()I

    move-result v0

    const/4 v1, 0x1

    sub-int/2addr v0, v1

    const/4 v2, 0x0

    :goto_0
    if-ltz v0, :cond_1

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->size()I

    move-result v3

    if-le v3, v1, :cond_1

    .line 591
    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v3

    invoke-virtual {p0, v2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v2

    invoke-virtual {v3, v2, p1, p2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->isIdentical(Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;D)Z

    move-result v2

    if-eqz v2, :cond_0

    .line 592
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->vertexes:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v2, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->remove(I)Ljava/lang/Object;

    :cond_0
    add-int/lit8 v2, v0, -0x1

    move v4, v2

    move v2, v0

    move v0, v4

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static shiftDown(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;)V
    .locals 5

    .line 545
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->size()I

    move-result v0

    add-int/lit8 v0, v0, -0x1

    .line 547
    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v1

    :goto_0
    if-lez v0, :cond_0

    .line 550
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->vertexes:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    iget-object v2, v2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->data:[Ljava/lang/Object;

    move-object v3, v2

    check-cast v3, [Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    check-cast v2, [Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    add-int/lit8 v4, v0, -0x1

    aget-object v2, v2, v4

    aput-object v2, v3, v0

    add-int/lit8 v0, v0, -0x1

    goto :goto_0

    .line 552
    :cond_0
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->vertexes:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->data:[Ljava/lang/Object;

    check-cast p0, [Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    const/4 v0, 0x0

    aput-object v1, p0, v0

    return-void
.end method
