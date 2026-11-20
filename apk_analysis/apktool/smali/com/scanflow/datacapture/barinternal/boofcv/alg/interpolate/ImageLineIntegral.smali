.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/ImageLineIntegral;
.super Ljava/lang/Object;
.source "ImageLineIntegral.java"


# instance fields
.field image:Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GImageGray;

.field length:D


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 48
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public compute(DDDD)D
    .locals 20

    move-object/from16 v0, p0

    move-wide/from16 v1, p1

    move-wide/from16 v3, p3

    sub-double v5, p5, v1

    sub-double v7, p7, v3

    mul-double v9, v5, v5

    mul-double v11, v7, v7

    add-double/2addr v9, v11

    .line 81
    invoke-static {v9, v10}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide v9

    iput-wide v9, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/ImageLineIntegral;->length:D

    .line 83
    invoke-static {v5, v6}, Ljava/lang/Math;->signum(D)D

    move-result-wide v9

    double-to-int v9, v9

    .line 84
    invoke-static {v7, v8}, Ljava/lang/Math;->signum(D)D

    move-result-wide v10

    double-to-int v10, v10

    double-to-int v11, v1

    double-to-int v12, v3

    const-wide/16 v13, 0x0

    cmpl-double v15, v5, v13

    const-wide/high16 v16, 0x3ff0000000000000L    # 1.0

    if-eqz v15, :cond_0

    cmpl-double v18, v7, v13

    if-nez v18, :cond_1

    :cond_0
    move-wide/from16 p5, v13

    goto/16 :goto_6

    :cond_1
    if-lez v15, :cond_2

    add-int/lit8 v15, v11, 0x1

    move-wide/from16 p5, v13

    int-to-double v13, v15

    :goto_0
    sub-double/2addr v13, v1

    goto :goto_1

    :cond_2
    move-wide/from16 p5, v13

    int-to-double v13, v11

    goto :goto_0

    :goto_1
    if-lez v18, :cond_3

    add-int/lit8 v15, v12, 0x1

    int-to-double v1, v15

    :goto_2
    sub-double/2addr v1, v3

    goto :goto_3

    :cond_3
    int-to-double v1, v12

    goto :goto_2

    :goto_3
    div-double/2addr v13, v5

    div-double/2addr v1, v7

    .line 124
    invoke-static {v13, v14, v1, v2}, Ljava/lang/Math;->min(DD)D

    move-result-wide v1

    cmpl-double v13, v1, v16

    if-lez v13, :cond_4

    move-wide/from16 v1, v16

    :cond_4
    cmpl-double v13, v1, p5

    if-lez v13, :cond_5

    .line 127
    iget-object v13, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/ImageLineIntegral;->image:Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GImageGray;

    invoke-interface {v13, v11, v12}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GImageGray;->unsafe_getD(II)D

    move-result-wide v11

    mul-double/2addr v11, v1

    add-double v13, v11, p5

    goto :goto_4

    :cond_5
    move-wide/from16 v13, p5

    :goto_4
    mul-double v11, v1, v5

    add-double v11, p1, v11

    mul-double v18, v1, v7

    move-wide/from16 p7, v1

    add-double v1, v3, v18

    double-to-int v15, v11

    double-to-int v3, v1

    add-int/2addr v15, v9

    add-int/2addr v3, v10

    move-wide/from16 p5, v11

    move v11, v3

    move-wide v3, v1

    move v1, v15

    move-wide v14, v13

    move-wide/from16 v12, p5

    move-wide/from16 p5, p7

    :goto_5
    cmpg-double v2, p5, v16

    if-gez v2, :cond_f

    int-to-double v1, v1

    sub-double/2addr v1, v12

    div-double/2addr v1, v5

    int-to-double v11, v11

    sub-double/2addr v11, v3

    div-double/2addr v11, v7

    .line 140
    invoke-static {v1, v2, v11, v12}, Ljava/lang/Math;->min(DD)D

    move-result-wide v3

    .line 143
    sget-wide v18, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->TEST_F64:D

    cmpg-double v13, v3, v18

    if-gtz v13, :cond_6

    .line 144
    invoke-static {v1, v2, v11, v12}, Ljava/lang/Math;->max(DD)D

    move-result-wide v3

    :cond_6
    add-double v1, p5, v3

    cmpl-double v1, v1, v16

    if-lez v1, :cond_7

    sub-double v3, v16, p5

    :cond_7
    const-wide/high16 v1, 0x3fe0000000000000L    # 0.5

    mul-double/2addr v1, v3

    add-double v1, p5, v1

    mul-double v11, v1, v5

    add-double v11, p1, v11

    mul-double/2addr v1, v7

    add-double v1, p3, v1

    .line 155
    iget-object v13, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/ImageLineIntegral;->image:Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GImageGray;

    double-to-int v11, v11

    double-to-int v1, v1

    invoke-interface {v13, v11, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GImageGray;->unsafe_getD(II)D

    move-result-wide v1

    mul-double/2addr v1, v3

    add-double/2addr v14, v1

    add-double v1, p5, v3

    mul-double v3, v1, v5

    add-double v12, p1, v3

    mul-double v3, v1, v7

    add-double v3, p3, v3

    double-to-int v11, v12

    move-wide/from16 p5, v1

    double-to-int v1, v3

    add-int v2, v11, v9

    add-int v11, v1, v10

    move v1, v2

    goto :goto_5

    :goto_6
    cmpl-double v1, v5, v7

    if-nez v1, :cond_8

    return-wide p5

    :cond_8
    if-nez v15, :cond_a

    cmpl-double v1, v7, p5

    if-lez v1, :cond_9

    add-int/lit8 v1, v12, 0x1

    int-to-double v1, v1

    :goto_7
    sub-double v1, v1, p3

    goto :goto_9

    :cond_9
    int-to-double v1, v12

    goto :goto_7

    :cond_a
    if-lez v15, :cond_b

    add-int/lit8 v1, v11, 0x1

    int-to-double v1, v1

    :goto_8
    sub-double v1, v1, p1

    goto :goto_9

    :cond_b
    int-to-double v1, v11

    goto :goto_8

    :goto_9
    add-double/2addr v5, v7

    div-double/2addr v1, v5

    cmpl-double v3, v1, v16

    if-lez v3, :cond_c

    move-wide/from16 v1, v16

    :cond_c
    cmpl-double v3, v1, p5

    if-lez v3, :cond_d

    .line 104
    iget-object v3, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/ImageLineIntegral;->image:Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GImageGray;

    invoke-interface {v3, v11, v12}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GImageGray;->unsafe_getD(II)D

    move-result-wide v3

    mul-double/2addr v3, v1

    add-double v13, v3, p5

    goto :goto_a

    :cond_d
    move-wide/from16 v13, p5

    :goto_a
    add-int v3, v9, v10

    int-to-double v3, v3

    div-double/2addr v3, v5

    move-wide v14, v13

    :goto_b
    cmpg-double v5, v1, v16

    if-gez v5, :cond_f

    add-int/2addr v11, v9

    add-int/2addr v12, v10

    add-double v5, v1, v3

    cmpl-double v7, v5, v16

    if-lez v7, :cond_e

    sub-double v1, v16, v1

    goto :goto_c

    :cond_e
    move-wide v1, v3

    .line 116
    :goto_c
    iget-object v7, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/ImageLineIntegral;->image:Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GImageGray;

    invoke-interface {v7, v11, v12}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GImageGray;->unsafe_getD(II)D

    move-result-wide v7

    mul-double/2addr v1, v7

    add-double/2addr v14, v1

    move-wide v1, v5

    goto :goto_b

    .line 166
    :cond_f
    iget-wide v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/ImageLineIntegral;->length:D

    mul-double/2addr v14, v1

    return-wide v14
.end method

.method public isInside(DD)Z
    .locals 7

    .line 185
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/ImageLineIntegral;->image:Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GImageGray;

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GImageGray;->getWidth()I

    move-result v1

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/ImageLineIntegral;->image:Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GImageGray;

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GImageGray;->getHeight()I

    move-result v2

    move-wide v3, p1

    move-wide v5, p3

    invoke-static/range {v1 .. v6}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/BoofMiscOps;->isInside(IIDD)Z

    move-result p1

    return p1
.end method

.method public setImage(Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GImageGray;)V
    .locals 0

    .line 61
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/ImageLineIntegral;->image:Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GImageGray;

    return-void
.end method
