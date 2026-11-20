.class public abstract Lcom/scanflow/datacapture/barinternal/georegression/metric/Intersection2D_F64;
.super Ljava/lang/Object;
.source "Intersection2D_F64.java"


# direct methods
.method public static intersection(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;
    .locals 12

    if-nez p2, :cond_0

    .line 484
    new-instance p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-direct {p2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;-><init>()V

    .line 487
    :cond_0
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->B:D

    iget-wide v2, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->C:D

    mul-double v4, v0, v2

    iget-wide v6, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->C:D

    iget-wide v8, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->B:D

    mul-double v10, v6, v8

    sub-double/2addr v4, v10

    iput-wide v4, p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    .line 488
    iget-wide v10, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->A:D

    mul-double/2addr v6, v10

    iget-wide p0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->A:D

    mul-double/2addr v2, p0

    sub-double/2addr v6, v2

    iput-wide v6, p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    mul-double/2addr p0, v8

    mul-double/2addr v0, v10

    sub-double/2addr p0, v0

    const-wide/16 v0, 0x0

    cmpl-double v0, p0, v0

    if-nez v0, :cond_1

    const/4 p0, 0x0

    return-object p0

    :cond_1
    div-double/2addr v4, p0

    .line 494
    iput-wide v4, p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    div-double/2addr v6, p0

    .line 495
    iput-wide v6, p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    return-object p2
.end method

.method public static intersection(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;
    .locals 25

    move-object/from16 v0, p0

    move-object/from16 v1, p1

    .line 306
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->b:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide v3, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->a:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide v5, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    sub-double/2addr v3, v5

    .line 307
    iget-wide v7, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    iget-wide v9, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    sub-double/2addr v7, v9

    .line 308
    iget-object v0, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->b:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide v11, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    iget-object v2, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->a:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide v13, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    sub-double/2addr v11, v13

    move-wide v15, v3

    .line 309
    iget-wide v3, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    move-wide/from16 v17, v3

    iget-wide v2, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    sub-double v17, v17, v2

    sub-double v19, v13, v5

    mul-double v19, v19, v7

    sub-double v21, v9, v2

    mul-double v21, v21, v15

    add-double v19, v19, v21

    mul-double v15, v15, v17

    mul-double/2addr v7, v11

    sub-double v21, v15, v7

    const-wide/16 v23, 0x0

    cmpl-double v0, v21, v23

    const/4 v4, 0x0

    if-nez v0, :cond_0

    return-object v4

    :cond_0
    div-double v19, v19, v21

    cmpg-double v0, v19, v23

    if-ltz v0, :cond_4

    const-wide/high16 v21, 0x3ff0000000000000L    # 1.0

    cmpl-double v0, v19, v21

    if-lez v0, :cond_1

    goto :goto_1

    :cond_1
    sub-double/2addr v5, v13

    mul-double v5, v5, v17

    sub-double/2addr v2, v9

    mul-double/2addr v2, v11

    add-double/2addr v5, v2

    sub-double/2addr v7, v15

    div-double/2addr v5, v7

    cmpg-double v0, v5, v23

    if-ltz v0, :cond_4

    cmpl-double v0, v5, v21

    if-lez v0, :cond_2

    goto :goto_1

    :cond_2
    if-nez p2, :cond_3

    .line 332
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;-><init>()V

    goto :goto_0

    :cond_3
    move-object/from16 v0, p2

    .line 335
    :goto_0
    iget-object v1, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->a:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide v2, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    mul-double v11, v11, v19

    add-double/2addr v2, v11

    iget-wide v4, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    mul-double v17, v17, v19

    add-double v4, v4, v17

    invoke-virtual {v0, v2, v3, v4, v5}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->setTo(DD)Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;

    return-object v0

    :cond_4
    :goto_1
    return-object v4
.end method

.method public static intersection(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;
    .locals 17

    move-object/from16 v0, p0

    move-object/from16 v1, p1

    move-object/from16 v2, p2

    move-object/from16 v3, p3

    if-nez p4, :cond_0

    .line 514
    new-instance v4, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-direct {v4}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;-><init>()V

    goto :goto_0

    :cond_0
    move-object/from16 v4, p4

    .line 516
    :goto_0
    iget-wide v5, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    iget-wide v7, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    sub-double/2addr v5, v7

    .line 517
    iget-wide v9, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    iget-wide v0, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    sub-double/2addr v9, v0

    .line 518
    iget-wide v11, v3, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    iget-wide v13, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    sub-double/2addr v11, v13

    move-wide/from16 p0, v0

    .line 519
    iget-wide v0, v3, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    iget-wide v2, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    sub-double/2addr v0, v2

    sub-double v7, v13, v7

    mul-double/2addr v7, v9

    sub-double v15, p0, v2

    mul-double/2addr v15, v5

    add-double/2addr v7, v15

    mul-double/2addr v5, v0

    mul-double/2addr v9, v11

    sub-double/2addr v5, v9

    const-wide/16 v9, 0x0

    cmpl-double v9, v5, v9

    if-nez v9, :cond_1

    const/4 v0, 0x0

    return-object v0

    :cond_1
    div-double/2addr v7, v5

    mul-double/2addr v11, v7

    add-double/2addr v13, v11

    .line 528
    iput-wide v13, v4, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    mul-double/2addr v7, v0

    add-double/2addr v2, v7

    .line 529
    iput-wide v2, v4, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    return-object v4
.end method
