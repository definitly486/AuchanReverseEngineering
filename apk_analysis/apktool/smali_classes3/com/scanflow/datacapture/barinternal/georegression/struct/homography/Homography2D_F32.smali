.class public Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;
.super Lcom/scanflow/datacapture/barinternal/georegression/struct/Matrix3x3_F32;
.source "Homography2D_F32.java"

# interfaces
.implements Ljava/io/Serializable;


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 55
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/Matrix3x3_F32;-><init>()V

    .line 56
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;->reset()V

    return-void
.end method

.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;)V
    .locals 0

    .line 51
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/Matrix3x3_F32;-><init>()V

    .line 52
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;)Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;

    return-void
.end method


# virtual methods
.method public copy()Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;
    .locals 1

    .line 144
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;-><init>(Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;)V

    return-object v0
.end method

.method public bridge synthetic copy()Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;
    .locals 1

    .line 33
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;->copy()Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;

    move-result-object v0

    return-object v0
.end method

.method public reset()V
    .locals 1

    const/high16 v0, 0x3f800000    # 1.0f

    .line 126
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a33:F

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a22:F

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a11:F

    const/4 v0, 0x0

    .line 127
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a32:F

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a31:F

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a23:F

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a21:F

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a13:F

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a12:F

    return-void
.end method

.method public setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;)Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F32;
    .locals 0

    .line 71
    invoke-super {p0, p1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/Matrix3x3_F32;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/Matrix3x3_F32;)V

    return-object p0
.end method

.method public toString()Ljava/lang/String;
    .locals 11

    .line 149
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Class;->getSimpleName()Ljava/lang/String;

    move-result-object v0

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a11:F

    .line 150
    invoke-static {v1}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v2

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a12:F

    invoke-static {v1}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v3

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a13:F

    invoke-static {v1}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v4

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a21:F

    invoke-static {v1}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v5

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a22:F

    invoke-static {v1}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v6

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a23:F

    invoke-static {v1}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v7

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a31:F

    invoke-static {v1}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v8

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a32:F

    invoke-static {v1}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v9

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a33:F

    invoke-static {v1}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v10

    filled-new-array/range {v2 .. v10}, [Ljava/lang/Object;

    move-result-object v1

    .line 149
    const-string v2, "[ %5.2fe %5.2fe %5.2fe ; %5.2fe %5.2fe %5.2fe ; %5.2fe %5.2fe %5.2fe ]"

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
