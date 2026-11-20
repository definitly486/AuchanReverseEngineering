.class public abstract Lcom/scanflow/datacapture/barinternal/georegression/fitting/line/FitLine_F64;
.super Ljava/lang/Object;
.source "FitLine_F64.java"


# direct methods
.method public static polar(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;
    .locals 18

    move-object/from16 v0, p0

    if-nez p1, :cond_0

    .line 52
    new-instance v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;

    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;-><init>()V

    goto :goto_0

    :cond_0
    move-object/from16 v1, p1

    .line 57
    :goto_0
    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v2

    const/4 v3, 0x0

    const-wide/16 v4, 0x0

    move v6, v3

    move-wide v7, v4

    move-wide v9, v7

    :goto_1
    if-ge v6, v2, :cond_1

    .line 59
    invoke-interface {v0, v6}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v11

    check-cast v11, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    .line 60
    iget-wide v12, v11, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    add-double/2addr v7, v12

    .line 61
    iget-wide v11, v11, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    add-double/2addr v9, v11

    add-int/lit8 v6, v6, 0x1

    goto :goto_1

    :cond_1
    int-to-double v11, v2

    div-double/2addr v7, v11

    div-double/2addr v9, v11

    move-wide v11, v4

    :goto_2
    if-ge v3, v2, :cond_2

    .line 70
    invoke-interface {v0, v3}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    .line 71
    iget-wide v13, v6, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    sub-double v13, v7, v13

    move/from16 p1, v2

    move v15, v3

    .line 72
    iget-wide v2, v6, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    sub-double v2, v9, v2

    mul-double v16, v13, v2

    add-double v4, v4, v16

    mul-double/2addr v2, v2

    mul-double/2addr v13, v13

    sub-double/2addr v2, v13

    add-double/2addr v11, v2

    add-int/lit8 v3, v15, 0x1

    move/from16 v2, p1

    goto :goto_2

    :cond_2
    const-wide/high16 v2, -0x4000000000000000L    # -2.0

    mul-double/2addr v4, v2

    .line 78
    invoke-static {v4, v5, v11, v12}, Ljava/lang/Math;->atan2(DD)D

    move-result-wide v2

    const-wide/high16 v4, 0x4000000000000000L    # 2.0

    div-double/2addr v2, v4

    iput-wide v2, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;->angle:D

    .line 79
    invoke-static {v2, v3}, Ljava/lang/Math;->cos(D)D

    move-result-wide v2

    mul-double/2addr v7, v2

    iget-wide v2, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;->angle:D

    invoke-static {v2, v3}, Ljava/lang/Math;->sin(D)D

    move-result-wide v2

    mul-double/2addr v9, v2

    add-double/2addr v7, v9

    iput-wide v7, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;->distance:D

    return-object v1
.end method

.method public static polar(Ljava/util/List;[DLcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;
    .locals 22

    move-object/from16 v0, p0

    .line 103
    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v1

    const-wide/16 v2, 0x0

    const/4 v4, 0x0

    move-wide v6, v2

    move v5, v4

    :goto_0
    if-ge v5, v1, :cond_0

    .line 106
    aget-wide v8, p1, v5

    add-double/2addr v6, v8

    add-int/lit8 v5, v5, 0x1

    goto :goto_0

    :cond_0
    cmpl-double v5, v6, v2

    if-nez v5, :cond_1

    const/4 v0, 0x0

    return-object v0

    :cond_1
    if-nez p2, :cond_2

    .line 113
    new-instance v5, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;

    invoke-direct {v5}, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;-><init>()V

    goto :goto_1

    :cond_2
    move-object/from16 v5, p2

    :goto_1
    move-wide v9, v2

    move-wide v11, v9

    move v8, v4

    :goto_2
    if-ge v8, v1, :cond_3

    .line 119
    invoke-interface {v0, v8}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v13

    check-cast v13, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    .line 120
    aget-wide v14, p1, v8

    .line 121
    iget-wide v2, v13, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    mul-double/2addr v2, v14

    add-double/2addr v9, v2

    .line 122
    iget-wide v2, v13, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    mul-double/2addr v14, v2

    add-double/2addr v11, v14

    add-int/lit8 v8, v8, 0x1

    const-wide/16 v2, 0x0

    goto :goto_2

    :cond_3
    div-double/2addr v9, v6

    div-double/2addr v11, v6

    const-wide/16 v2, 0x0

    const-wide/16 v16, 0x0

    :goto_3
    if-ge v4, v1, :cond_4

    .line 131
    invoke-interface {v0, v4}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v8

    check-cast v8, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    .line 132
    aget-wide v13, p1, v4

    move v15, v1

    .line 133
    iget-wide v0, v8, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    sub-double v0, v9, v0

    move-wide/from16 v18, v0

    .line 134
    iget-wide v0, v8, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    sub-double v0, v11, v0

    mul-double v20, v13, v18

    mul-double v20, v20, v0

    add-double v2, v2, v20

    mul-double/2addr v0, v0

    mul-double v18, v18, v18

    sub-double v0, v0, v18

    mul-double/2addr v13, v0

    add-double v16, v16, v13

    add-int/lit8 v4, v4, 0x1

    move-object/from16 v0, p0

    move v1, v15

    goto :goto_3

    :cond_4
    div-double/2addr v2, v6

    div-double v0, v16, v6

    const-wide/high16 v6, -0x4000000000000000L    # -2.0

    mul-double/2addr v2, v6

    .line 142
    invoke-static {v2, v3, v0, v1}, Ljava/lang/Math;->atan2(DD)D

    move-result-wide v0

    const-wide/high16 v2, 0x4000000000000000L    # 2.0

    div-double/2addr v0, v2

    iput-wide v0, v5, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;->angle:D

    .line 143
    invoke-static {v0, v1}, Ljava/lang/Math;->cos(D)D

    move-result-wide v0

    mul-double/2addr v9, v0

    iget-wide v0, v5, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;->angle:D

    invoke-static {v0, v1}, Ljava/lang/Math;->sin(D)D

    move-result-wide v0

    mul-double/2addr v11, v0

    add-double/2addr v9, v11

    iput-wide v9, v5, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;->distance:D

    return-object v5
.end method
