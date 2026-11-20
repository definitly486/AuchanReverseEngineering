.class public Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;
.super Ljava/lang/Object;
.source "Complex_F64.java"


# instance fields
.field public imaginary:D

.field public real:D


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 39
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method protected canEqual(Ljava/lang/Object;)Z
    .locals 0

    .line 29
    instance-of p1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;

    return p1
.end method

.method public equals(Ljava/lang/Object;)Z
    .locals 7

    const/4 v0, 0x1

    if-ne p1, p0, :cond_0

    return v0

    .line 29
    :cond_0
    instance-of v1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;

    const/4 v2, 0x0

    if-nez v1, :cond_1

    return v2

    :cond_1
    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;

    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;->canEqual(Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_2

    return v2

    :cond_2
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;->getReal()D

    move-result-wide v3

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;->getReal()D

    move-result-wide v5

    invoke-static {v3, v4, v5, v6}, Ljava/lang/Double;->compare(DD)I

    move-result v1

    if-eqz v1, :cond_3

    return v2

    :cond_3
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;->getImaginary()D

    move-result-wide v3

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;->getImaginary()D

    move-result-wide v5

    invoke-static {v3, v4, v5, v6}, Ljava/lang/Double;->compare(DD)I

    move-result p1

    if-eqz p1, :cond_4

    return v2

    :cond_4
    return v0
.end method

.method public getImaginary()D
    .locals 2

    .line 32
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;->imaginary:D

    return-wide v0
.end method

.method public getReal()D
    .locals 2

    .line 31
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;->real:D

    return-wide v0
.end method

.method public hashCode()I
    .locals 5

    .line 29
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;->getReal()D

    move-result-wide v0

    invoke-static {v0, v1}, Ljava/lang/Double;->doubleToLongBits(D)J

    move-result-wide v0

    const/16 v2, 0x20

    ushr-long v3, v0, v2

    xor-long/2addr v0, v3

    long-to-int v0, v0

    const/16 v1, 0x3b

    add-int/2addr v0, v1

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;->getImaginary()D

    move-result-wide v3

    invoke-static {v3, v4}, Ljava/lang/Double;->doubleToLongBits(D)J

    move-result-wide v3

    mul-int/2addr v0, v1

    ushr-long v1, v3, v2

    xor-long/2addr v1, v3

    long-to-int v1, v1

    add-int/2addr v0, v1

    return v0
.end method

.method public toString()Ljava/lang/String;
    .locals 5

    .line 89
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;->imaginary:D

    const-wide/16 v2, 0x0

    cmpl-double v2, v0, v2

    if-nez v2, :cond_0

    .line 90
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;->real:D

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v2, v0, v1}, Ljava/lang/StringBuilder;->append(D)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0

    .line 92
    :cond_0
    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;->real:D

    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v4, v2, v3}, Ljava/lang/StringBuilder;->append(D)Ljava/lang/StringBuilder;

    const-string v2, " "

    invoke-virtual {v4, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v4, v0, v1}, Ljava/lang/StringBuilder;->append(D)Ljava/lang/StringBuilder;

    const-string v0, "i"

    invoke-virtual {v4, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
