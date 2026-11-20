.class public abstract Lcom/scanflow/datacapture/barinternal/georegression/fitting/line/FitLine_I32;
.super Ljava/lang/Object;
.source "FitLine_I32.java"


# direct methods
.method public static polar(Ljava/util/List;IILcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;
    .locals 17

    move-object/from16 v0, p0

    move/from16 v1, p2

    if-nez p3, :cond_0

    .line 103
    new-instance v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;

    invoke-direct {v2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;-><init>()V

    goto :goto_0

    :cond_0
    move-object/from16 v2, p3

    :goto_0
    const/4 v3, 0x0

    move v4, v3

    move v5, v4

    move v6, v5

    :goto_1
    if-ge v4, v1, :cond_1

    add-int v7, p1, v4

    .line 110
    invoke-interface {v0, v7}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v7

    check-cast v7, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 111
    iget v8, v7, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    add-int/2addr v5, v8

    .line 112
    iget v7, v7, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    add-int/2addr v6, v7

    add-int/lit8 v4, v4, 0x1

    goto :goto_1

    :cond_1
    int-to-double v4, v5

    int-to-double v7, v1

    div-double/2addr v4, v7

    int-to-double v9, v6

    div-double/2addr v9, v7

    const-wide/16 v6, 0x0

    move-wide v11, v6

    :goto_2
    if-ge v3, v1, :cond_2

    add-int v8, p1, v3

    .line 121
    invoke-interface {v0, v8}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v8

    check-cast v8, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 122
    iget v13, v8, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    int-to-double v13, v13

    sub-double v13, v4, v13

    .line 123
    iget v8, v8, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    int-to-double v0, v8

    sub-double v0, v9, v0

    mul-double v15, v13, v0

    add-double/2addr v6, v15

    mul-double/2addr v0, v0

    mul-double/2addr v13, v13

    sub-double/2addr v0, v13

    add-double/2addr v11, v0

    add-int/lit8 v3, v3, 0x1

    move-object/from16 v0, p0

    move/from16 v1, p2

    goto :goto_2

    :cond_2
    const-wide/high16 v0, -0x4000000000000000L    # -2.0

    mul-double/2addr v6, v0

    .line 129
    invoke-static {v6, v7, v11, v12}, Ljava/lang/Math;->atan2(DD)D

    move-result-wide v0

    const-wide/high16 v6, 0x4000000000000000L    # 2.0

    div-double/2addr v0, v6

    iput-wide v0, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;->angle:D

    .line 130
    invoke-static {v0, v1}, Ljava/lang/Math;->cos(D)D

    move-result-wide v0

    mul-double/2addr v4, v0

    iget-wide v0, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;->angle:D

    invoke-static {v0, v1}, Ljava/lang/Math;->sin(D)D

    move-result-wide v0

    mul-double/2addr v9, v0

    add-double/2addr v4, v9

    iput-wide v4, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;->distance:D

    return-object v2
.end method
