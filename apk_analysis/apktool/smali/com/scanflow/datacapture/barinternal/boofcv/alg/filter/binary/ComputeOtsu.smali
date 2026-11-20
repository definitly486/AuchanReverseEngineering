.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;
.super Ljava/lang/Object;
.source "ComputeOtsu.java"


# instance fields
.field public down:Z

.field private scale:D

.field public threshold:D

.field private tuning:D

.field private useOtsu2:Z

.field public variance:D


# direct methods
.method public constructor <init>(ZDZD)V
    .locals 0

    .line 55
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 56
    iput-boolean p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;->useOtsu2:Z

    .line 57
    iput-wide p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;->tuning:D

    .line 58
    iput-boolean p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;->down:Z

    .line 59
    iput-wide p5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;->scale:D

    return-void
.end method


# virtual methods
.method public compute([III)V
    .locals 6

    .line 74
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;->useOtsu2:Z

    if-eqz v0, :cond_0

    .line 75
    invoke-virtual {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;->computeOtsu2([III)V

    goto :goto_0

    .line 77
    :cond_0
    invoke-virtual {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;->computeOtsu([III)V

    .line 81
    :goto_0
    iget-wide p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;->variance:D

    const-wide v0, 0x3f50624dd2f1a9fcL    # 0.001

    add-double/2addr p1, v0

    iput-wide p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;->variance:D

    .line 83
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;->tuning:D

    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;->threshold:D

    mul-double v4, v0, v2

    mul-double/2addr v4, v0

    mul-double/2addr v4, v2

    div-double/2addr v4, p1

    const-wide/high16 p1, 0x3fe0000000000000L    # 0.5

    add-double/2addr v4, p1

    double-to-int p3, v4

    .line 84
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;->down:Z

    if-eqz v0, :cond_1

    neg-int p3, p3

    :cond_1
    int-to-double v0, p3

    add-double/2addr v2, v0

    iput-wide v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;->threshold:D

    .line 85
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;->scale:D

    const-wide/16 v4, 0x0

    invoke-static {v2, v3, v4, v5}, Ljava/lang/Math;->max(DD)D

    move-result-wide v2

    mul-double/2addr v0, v2

    add-double/2addr v0, p1

    double-to-int p1, v0

    int-to-double p1, p1

    iput-wide p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;->threshold:D

    return-void
.end method

.method protected computeOtsu([III)V
    .locals 20

    move-object/from16 v0, p0

    move/from16 v1, p2

    int-to-double v2, v1

    const-wide/16 v4, 0x0

    const/4 v6, 0x0

    move-wide v8, v4

    move v7, v6

    :goto_0
    if-ge v7, v1, :cond_0

    int-to-double v10, v7

    div-double/2addr v10, v2

    .line 93
    aget v12, p1, v7

    int-to-double v12, v12

    mul-double/2addr v10, v12

    add-double/2addr v8, v10

    add-int/lit8 v7, v7, 0x1

    goto :goto_0

    .line 98
    :cond_0
    iput-wide v4, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;->variance:D

    .line 99
    iput-wide v4, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;->threshold:D

    move v7, v6

    :goto_1
    if-ge v6, v1, :cond_4

    .line 103
    aget v10, p1, v6

    add-int/2addr v7, v10

    if-nez v7, :cond_1

    move-wide/from16 v16, v2

    goto :goto_2

    :cond_1
    sub-int v11, p3, v7

    if-nez v11, :cond_2

    goto :goto_3

    :cond_2
    int-to-double v12, v6

    div-double v14, v12, v2

    move-wide/from16 v16, v2

    int-to-double v1, v10

    mul-double/2addr v14, v1

    add-double/2addr v4, v14

    int-to-double v1, v7

    div-double v14, v4, v1

    sub-double v18, v8, v4

    int-to-double v10, v11

    div-double v18, v18, v10

    mul-double/2addr v1, v10

    sub-double v14, v14, v18

    mul-double/2addr v1, v14

    mul-double/2addr v1, v14

    .line 119
    iget-wide v10, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;->variance:D

    cmpl-double v3, v1, v10

    if-lez v3, :cond_3

    .line 120
    iput-wide v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;->variance:D

    .line 121
    iput-wide v12, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;->threshold:D

    :cond_3
    :goto_2
    add-int/lit8 v6, v6, 0x1

    move/from16 v1, p2

    move-wide/from16 v2, v16

    goto :goto_1

    :cond_4
    :goto_3
    return-void
.end method

.method protected computeOtsu2([III)V
    .locals 22

    move-object/from16 v0, p0

    move/from16 v1, p2

    int-to-double v2, v1

    const-wide/16 v4, 0x0

    const/4 v6, 0x0

    move-wide v8, v4

    move v7, v6

    :goto_0
    if-ge v7, v1, :cond_0

    int-to-double v10, v7

    div-double/2addr v10, v2

    .line 131
    aget v12, p1, v7

    int-to-double v12, v12

    mul-double/2addr v10, v12

    add-double/2addr v8, v10

    add-int/lit8 v7, v7, 0x1

    goto :goto_0

    .line 136
    :cond_0
    iput-wide v4, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;->variance:D

    .line 137
    iput-wide v4, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;->threshold:D

    move-wide v10, v4

    move v12, v6

    move v13, v12

    move-wide v6, v10

    :goto_1
    if-ge v12, v1, :cond_2

    .line 144
    aget v14, p1, v12

    add-int/2addr v13, v14

    if-nez v13, :cond_1

    move-wide/from16 v16, v2

    goto :goto_2

    :cond_1
    sub-int v15, p3, v13

    if-nez v15, :cond_3

    :cond_2
    move-wide/from16 v16, v2

    goto :goto_3

    :cond_3
    move-wide/from16 v16, v2

    int-to-double v1, v12

    div-double v1, v1, v16

    move-wide/from16 v18, v1

    int-to-double v1, v14

    mul-double v1, v1, v18

    add-double/2addr v4, v1

    int-to-double v1, v13

    div-double v18, v4, v1

    sub-double v20, v8, v4

    int-to-double v14, v15

    div-double v20, v20, v14

    mul-double/2addr v1, v14

    sub-double v14, v18, v20

    mul-double/2addr v1, v14

    mul-double/2addr v1, v14

    .line 160
    iget-wide v14, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;->variance:D

    cmpl-double v3, v1, v14

    if-lez v3, :cond_4

    .line 161
    iput-wide v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;->variance:D

    move-wide/from16 v6, v18

    move-wide/from16 v10, v20

    :cond_4
    :goto_2
    add-int/lit8 v12, v12, 0x1

    move/from16 v1, p2

    move-wide/from16 v2, v16

    goto :goto_1

    :goto_3
    add-double/2addr v6, v10

    mul-double v2, v16, v6

    const-wide/high16 v4, 0x4000000000000000L    # 2.0

    div-double/2addr v2, v4

    .line 170
    iput-wide v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;->threshold:D

    return-void
.end method

.method public getScale()D
    .locals 2

    .line 47
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;->scale:D

    return-wide v0
.end method

.method public getTuning()D
    .locals 2

    .line 41
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;->tuning:D

    return-wide v0
.end method

.method public isUseOtsu2()Z
    .locals 1

    .line 34
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;->useOtsu2:Z

    return v0
.end method
