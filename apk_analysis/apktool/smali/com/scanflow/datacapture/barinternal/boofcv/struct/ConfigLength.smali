.class public Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;
.super Ljava/lang/Object;
.source "ConfigLength.java"

# interfaces
.implements Ljava/io/Serializable;


# instance fields
.field public fraction:D

.field public length:D


# direct methods
.method public constructor <init>()V
    .locals 2

    .line 45
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const-wide/high16 v0, -0x4010000000000000L    # -1.0

    .line 34
    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->length:D

    .line 38
    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->fraction:D

    return-void
.end method

.method public constructor <init>(DD)V
    .locals 0

    .line 40
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 41
    iput-wide p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->length:D

    .line 42
    iput-wide p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->fraction:D

    return-void
.end method

.method public static fixed(D)Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;
    .locals 3

    .line 48
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    const-wide/high16 v1, -0x4010000000000000L    # -1.0

    invoke-direct {v0, p0, p1, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;-><init>(DD)V

    return-object v0
.end method

.method public static relative(DD)Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;
    .locals 1

    .line 52
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    invoke-direct {v0, p2, p3, p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;-><init>(DD)V

    return-object v0
.end method


# virtual methods
.method public checkValidity()V
    .locals 4

    .line 124
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->isRelative()Z

    move-result v0

    if-eqz v0, :cond_1

    .line 125
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->fraction:D

    const-wide/16 v2, 0x0

    cmpg-double v2, v0, v2

    if-ltz v2, :cond_0

    const-wide/high16 v2, 0x3ff0000000000000L    # 1.0

    cmpl-double v0, v0, v2

    if-gtz v0, :cond_0

    goto :goto_0

    .line 126
    :cond_0
    new-instance v0, Ljava/lang/IllegalArgumentException;

    const-string v1, "Fractional value must be from 0.0 to 1.0, inclusive"

    invoke-direct {v0, v1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0

    :cond_1
    :goto_0
    return-void
.end method

.method public compute(D)D
    .locals 4

    .line 73
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->fraction:D

    const-wide/16 v2, 0x0

    cmpl-double v2, v0, v2

    if-ltz v2, :cond_0

    mul-double/2addr v0, p1

    .line 75
    iget-wide p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->length:D

    invoke-static {v0, v1, p1, p2}, Ljava/lang/Math;->max(DD)D

    move-result-wide p1

    return-wide p1

    .line 77
    :cond_0
    iget-wide p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->length:D

    return-wide p1
.end method

.method public computeI(D)I
    .locals 3

    .line 95
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->compute(D)D

    move-result-wide p1

    const-wide/16 v0, 0x0

    cmpl-double v0, p1, v0

    if-ltz v0, :cond_0

    .line 97
    invoke-static {p1, p2}, Ljava/lang/Math;->round(D)J

    move-result-wide p1

    long-to-int p1, p1

    return p1

    .line 99
    :cond_0
    new-instance v0, Ljava/lang/IllegalArgumentException;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Threshold was set to a negative value: "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p1, p2}, Ljava/lang/StringBuilder;->append(D)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {v0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method public computeNegMaxI(D)I
    .locals 2

    .line 104
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->compute(D)D

    move-result-wide p1

    const-wide/16 v0, 0x0

    cmpl-double v0, p1, v0

    if-ltz v0, :cond_0

    .line 106
    invoke-static {p1, p2}, Ljava/lang/Math;->round(D)J

    move-result-wide p1

    long-to-int p1, p1

    return p1

    :cond_0
    const p1, 0x7fffffff

    return p1
.end method

.method public copy()Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;
    .locals 1

    .line 136
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;-><init>()V

    invoke-virtual {v0, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->setTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    move-result-object v0

    return-object v0
.end method

.method public isRelative()Z
    .locals 4

    .line 85
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->fraction:D

    const-wide/16 v2, 0x0

    cmpl-double v0, v0, v2

    if-ltz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public setTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;
    .locals 2

    .line 130
    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->length:D

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->length:D

    .line 131
    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->fraction:D

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->fraction:D

    return-object p0
.end method

.method public toString()Ljava/lang/String;
    .locals 6

    .line 141
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->fraction:D

    const-wide/16 v2, 0x0

    cmpl-double v2, v0, v2

    const-string v3, "ConfigLength{"

    if-ltz v2, :cond_0

    .line 142
    iget-wide v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->length:D

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v3, "fraction="

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v0, v1}, Ljava/lang/StringBuilder;->append(D)Ljava/lang/StringBuilder;

    const-string v0, ", minimum="

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v4, v5}, Ljava/lang/StringBuilder;->append(D)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    goto :goto_0

    .line 144
    :cond_0
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->length:D

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v3, ", length="

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v0, v1}, Ljava/lang/StringBuilder;->append(D)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 145
    :goto_0
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v0, "}"

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
