.class public Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;
.super Lcom/scanflow/datacapture/barinternal/georegression/struct/Matrix3x3_F64;
.source "Homography2D_F64.java"

# interfaces
.implements Ljava/io/Serializable;


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 53
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/Matrix3x3_F64;-><init>()V

    .line 54
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;->reset()V

    return-void
.end method

.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;)V
    .locals 0

    .line 49
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/Matrix3x3_F64;-><init>()V

    .line 50
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;

    return-void
.end method


# virtual methods
.method public copy()Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;
    .locals 1

    .line 142
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;-><init>(Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;)V

    return-object v0
.end method

.method public bridge synthetic copy()Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;
    .locals 1

    .line 32
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;->copy()Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;

    move-result-object v0

    return-object v0
.end method

.method public invert(Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;
    .locals 30

    move-object/from16 v0, p0

    if-nez p1, :cond_0

    .line 94
    new-instance v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;

    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;-><init>()V

    goto :goto_0

    :cond_0
    move-object/from16 v1, p1

    .line 97
    :goto_0
    iget-wide v2, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a22:D

    iget-wide v4, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a33:D

    mul-double v6, v2, v4

    iget-wide v8, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a23:D

    iget-wide v10, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a32:D

    mul-double v12, v8, v10

    sub-double/2addr v6, v12

    .line 98
    iget-wide v12, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a21:D

    mul-double v14, v12, v4

    move-wide/from16 v16, v2

    iget-wide v2, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a31:D

    mul-double v18, v8, v2

    sub-double v14, v14, v18

    neg-double v14, v14

    mul-double v18, v12, v10

    mul-double v20, v16, v2

    sub-double v18, v18, v20

    move-wide/from16 v20, v2

    .line 100
    iget-wide v2, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a12:D

    mul-double v22, v2, v4

    move-wide/from16 v24, v2

    iget-wide v2, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a13:D

    mul-double v26, v2, v10

    move-wide/from16 v28, v2

    sub-double v2, v22, v26

    neg-double v2, v2

    move-wide/from16 v22, v2

    .line 101
    iget-wide v2, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a11:D

    mul-double/2addr v4, v2

    mul-double v26, v28, v20

    sub-double v4, v4, v26

    mul-double/2addr v10, v2

    mul-double v20, v20, v24

    sub-double v10, v10, v20

    neg-double v10, v10

    mul-double v20, v24, v8

    mul-double v26, v28, v16

    sub-double v20, v20, v26

    mul-double/2addr v8, v2

    mul-double v26, v28, v12

    sub-double v8, v8, v26

    neg-double v8, v8

    mul-double v16, v16, v2

    mul-double v12, v12, v24

    sub-double v16, v16, v12

    mul-double/2addr v2, v6

    mul-double v12, v24, v14

    add-double/2addr v2, v12

    mul-double v12, v28, v18

    add-double/2addr v2, v12

    div-double/2addr v6, v2

    .line 109
    iput-wide v6, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a11:D

    div-double v6, v22, v2

    .line 110
    iput-wide v6, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a12:D

    div-double v6, v20, v2

    .line 111
    iput-wide v6, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a13:D

    div-double/2addr v14, v2

    .line 112
    iput-wide v14, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a21:D

    div-double/2addr v4, v2

    .line 113
    iput-wide v4, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a22:D

    div-double/2addr v8, v2

    .line 114
    iput-wide v8, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a23:D

    div-double v4, v18, v2

    .line 115
    iput-wide v4, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a31:D

    div-double/2addr v10, v2

    .line 116
    iput-wide v10, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a32:D

    div-double v2, v16, v2

    .line 117
    iput-wide v2, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a33:D

    return-object v1
.end method

.method public reset()V
    .locals 2

    const-wide/high16 v0, 0x3ff0000000000000L    # 1.0

    .line 124
    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a33:D

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a22:D

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a11:D

    const-wide/16 v0, 0x0

    .line 125
    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a32:D

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a31:D

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a23:D

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a21:D

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a13:D

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a12:D

    return-void
.end method

.method public setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;
    .locals 0

    .line 69
    invoke-super {p0, p1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/Matrix3x3_F64;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/Matrix3x3_F64;)V

    return-object p0
.end method

.method public toString()Ljava/lang/String;
    .locals 12

    .line 147
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Class;->getSimpleName()Ljava/lang/String;

    move-result-object v0

    iget-wide v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a11:D

    .line 148
    invoke-static {v1, v2}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object v3

    iget-wide v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a12:D

    invoke-static {v1, v2}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object v4

    iget-wide v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a13:D

    invoke-static {v1, v2}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object v5

    iget-wide v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a21:D

    invoke-static {v1, v2}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object v6

    iget-wide v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a22:D

    invoke-static {v1, v2}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object v7

    iget-wide v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a23:D

    invoke-static {v1, v2}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object v8

    iget-wide v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a31:D

    invoke-static {v1, v2}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object v9

    iget-wide v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a32:D

    invoke-static {v1, v2}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object v10

    iget-wide v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a33:D

    invoke-static {v1, v2}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object v11

    filled-new-array/range {v3 .. v11}, [Ljava/lang/Object;

    move-result-object v1

    .line 147
    const-string v2, "[ %5.2e %5.2e %5.2e ; %5.2e %5.2e %5.2e ; %5.2e %5.2e %5.2e ]"

    invoke-static {v2, v1}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v1

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
