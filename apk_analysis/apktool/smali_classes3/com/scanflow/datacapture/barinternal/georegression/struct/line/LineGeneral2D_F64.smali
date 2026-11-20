.class public Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;
.super Ljava/lang/Object;
.source "LineGeneral2D_F64.java"

# interfaces
.implements Ljava/io/Serializable;


# instance fields
.field public A:D

.field public B:D

.field public C:D


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 62
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public equals(Ljava/lang/Object;)Z
    .locals 7

    const/4 v0, 0x1

    if-ne p0, p1, :cond_0

    return v0

    .line 130
    :cond_0
    instance-of v1, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    const/4 v2, 0x0

    if-nez v1, :cond_1

    return v2

    .line 133
    :cond_1
    check-cast p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    .line 134
    iget-wide v3, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->A:D

    iget-wide v5, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->A:D

    cmpl-double v1, v3, v5

    if-nez v1, :cond_2

    iget-wide v3, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->B:D

    iget-wide v5, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->B:D

    cmpl-double v1, v3, v5

    if-nez v1, :cond_2

    iget-wide v3, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->C:D

    iget-wide v5, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->C:D

    cmpl-double p1, v3, v5

    if-nez p1, :cond_2

    return v0

    :cond_2
    return v2
.end method

.method public hashCode()I
    .locals 4

    .line 139
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->A:D

    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->B:D

    add-double/2addr v0, v2

    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->C:D

    add-double/2addr v0, v2

    invoke-static {v0, v1}, Ljava/lang/Double;->hashCode(D)I

    move-result v0

    return v0
.end method

.method public normalize()V
    .locals 4

    .line 93
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->A:D

    mul-double/2addr v0, v0

    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->B:D

    mul-double/2addr v2, v2

    add-double/2addr v0, v2

    invoke-static {v0, v1}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide v0

    .line 94
    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->A:D

    div-double/2addr v2, v0

    iput-wide v2, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->A:D

    .line 95
    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->B:D

    div-double/2addr v2, v0

    iput-wide v2, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->B:D

    .line 96
    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->C:D

    div-double/2addr v2, v0

    iput-wide v2, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->C:D

    return-void
.end method

.method public setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;
    .locals 2

    .line 65
    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->A:D

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->A:D

    .line 66
    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->B:D

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->B:D

    .line 67
    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->C:D

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->C:D

    return-object p0
.end method

.method public toString()Ljava/lang/String;
    .locals 6

    .line 121
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/FancyPrint;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/FancyPrint;-><init>()V

    .line 122
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Class;->getSimpleName()Ljava/lang/String;

    move-result-object v1

    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->A:D

    invoke-virtual {v0, v2, v3}, Lcom/scanflow/datacapture/barinternal/org/ejml/FancyPrint;->s(D)Ljava/lang/String;

    move-result-object v2

    iget-wide v3, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->B:D

    invoke-virtual {v0, v3, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/FancyPrint;->s(D)Ljava/lang/String;

    move-result-object v3

    iget-wide v4, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->C:D

    invoke-virtual {v0, v4, v5}, Lcom/scanflow/datacapture/barinternal/org/ejml/FancyPrint;->s(D)Ljava/lang/String;

    move-result-object v0

    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v4, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, "{ A="

    invoke-virtual {v4, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v4, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, " B="

    invoke-virtual {v4, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v4, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, " C="

    invoke-virtual {v4, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v4, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v0, " }"

    invoke-virtual {v4, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
