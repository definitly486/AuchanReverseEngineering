.class public Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F32;
.super Ljava/lang/Object;
.source "Complex_F32.java"


# instance fields
.field public imaginary:F

.field public real:F


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 41
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method protected canEqual(Ljava/lang/Object;)Z
    .locals 0

    .line 30
    instance-of p1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F32;

    return p1
.end method

.method public equals(Ljava/lang/Object;)Z
    .locals 4

    const/4 v0, 0x1

    if-ne p1, p0, :cond_0

    return v0

    .line 30
    :cond_0
    instance-of v1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F32;

    const/4 v2, 0x0

    if-nez v1, :cond_1

    return v2

    :cond_1
    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F32;

    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F32;->canEqual(Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_2

    return v2

    :cond_2
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F32;->getReal()F

    move-result v1

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F32;->getReal()F

    move-result v3

    invoke-static {v1, v3}, Ljava/lang/Float;->compare(FF)I

    move-result v1

    if-eqz v1, :cond_3

    return v2

    :cond_3
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F32;->getImaginary()F

    move-result v1

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F32;->getImaginary()F

    move-result p1

    invoke-static {v1, p1}, Ljava/lang/Float;->compare(FF)I

    move-result p1

    if-eqz p1, :cond_4

    return v2

    :cond_4
    return v0
.end method

.method public getImaginary()F
    .locals 1

    .line 34
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F32;->imaginary:F

    return v0
.end method

.method public getReal()F
    .locals 1

    .line 33
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F32;->real:F

    return v0
.end method

.method public hashCode()I
    .locals 2

    .line 30
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F32;->getReal()F

    move-result v0

    invoke-static {v0}, Ljava/lang/Float;->floatToIntBits(F)I

    move-result v0

    const/16 v1, 0x3b

    add-int/2addr v0, v1

    mul-int/2addr v0, v1

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F32;->getImaginary()F

    move-result v1

    invoke-static {v1}, Ljava/lang/Float;->floatToIntBits(F)I

    move-result v1

    add-int/2addr v0, v1

    return v0
.end method

.method public toString()Ljava/lang/String;
    .locals 3

    .line 91
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F32;->imaginary:F

    const/4 v1, 0x0

    cmpl-float v1, v0, v1

    if-nez v1, :cond_0

    .line 92
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F32;->real:F

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(F)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0

    .line 94
    :cond_0
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F32;->real:F

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v2, v1}, Ljava/lang/StringBuilder;->append(F)Ljava/lang/StringBuilder;

    const-string v1, " "

    invoke-virtual {v2, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(F)Ljava/lang/StringBuilder;

    const-string v0, "i"

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
