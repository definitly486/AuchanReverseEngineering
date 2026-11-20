.class public Lcom/scanflow/datacapture/barinternal/org/opencv/core/Range;
.super Ljava/lang/Object;
.source "Range.java"


# instance fields
.field public end:I

.field public start:I


# direct methods
.method public constructor <init>(II)V
    .locals 0

    .line 8
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 9
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Range;->start:I

    .line 10
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Range;->end:I

    return-void
.end method

.method public static all()Lcom/scanflow/datacapture/barinternal/org/opencv/core/Range;
    .locals 3

    .line 41
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Range;

    const/high16 v1, -0x80000000

    const v2, 0x7fffffff

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Range;-><init>(II)V

    return-object v0
.end method


# virtual methods
.method public clone()Lcom/scanflow/datacapture/barinternal/org/opencv/core/Range;
    .locals 3

    .line 55
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Range;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Range;->start:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Range;->end:I

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Range;-><init>(II)V

    return-object v0
.end method

.method public bridge synthetic clone()Ljava/lang/Object;
    .locals 1

    .line 4
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Range;->clone()Lcom/scanflow/datacapture/barinternal/org/opencv/core/Range;

    move-result-object v0

    return-object v0
.end method

.method public equals(Ljava/lang/Object;)Z
    .locals 4

    const/4 v0, 0x1

    if-ne p0, p1, :cond_0

    return v0

    .line 73
    :cond_0
    instance-of v1, p1, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Range;

    const/4 v2, 0x0

    if-nez v1, :cond_1

    return v2

    .line 74
    :cond_1
    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Range;

    .line 75
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Range;->start:I

    iget v3, p1, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Range;->start:I

    if-ne v1, v3, :cond_2

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Range;->end:I

    iget p1, p1, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Range;->end:I

    if-ne v1, p1, :cond_2

    return v0

    :cond_2
    return v2
.end method

.method public hashCode()I
    .locals 5

    .line 63
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Range;->start:I

    int-to-double v0, v0

    invoke-static {v0, v1}, Ljava/lang/Double;->doubleToLongBits(D)J

    move-result-wide v0

    const/16 v2, 0x20

    ushr-long v3, v0, v2

    xor-long/2addr v0, v3

    long-to-int v0, v0

    const/16 v1, 0x1f

    add-int/2addr v0, v1

    .line 65
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Range;->end:I

    int-to-double v3, v3

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
    .locals 2

    .line 80
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "["

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Range;->start:I

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string v1, ", "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Range;->end:I

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string v1, ")"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
