.class public Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;
.super Ljava/lang/Object;
.source "MovingAverage.java"


# instance fields
.field average:D

.field decay:D

.field first:Z


# direct methods
.method public constructor <init>(D)V
    .locals 0

    .line 38
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 39
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;->setDecay(D)V

    .line 40
    iput-wide p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;->decay:D

    .line 41
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;->reset()V

    return-void
.end method


# virtual methods
.method public getAverage()D
    .locals 2

    .line 60
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;->average:D

    return-wide v0
.end method

.method public reset()V
    .locals 2

    const/4 v0, 0x1

    .line 45
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;->first:Z

    const-wide/16 v0, 0x0

    .line 46
    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;->average:D

    return-void
.end method

.method public setDecay(D)V
    .locals 2

    const-wide/16 v0, 0x0

    cmpg-double v0, p1, v0

    if-ltz v0, :cond_0

    const-wide/high16 v0, 0x3ff0000000000000L    # 1.0

    cmpl-double v0, p1, v0

    if-gtz v0, :cond_0

    .line 70
    iput-wide p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;->decay:D

    return-void

    .line 69
    :cond_0
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string p2, "Decay must be from 0 to 1, inclusive"

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public update(D)D
    .locals 6

    .line 50
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;->first:Z

    if-eqz v0, :cond_0

    const/4 v0, 0x0

    .line 51
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;->first:Z

    .line 52
    iput-wide p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;->average:D

    goto :goto_0

    .line 54
    :cond_0
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;->average:D

    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;->decay:D

    mul-double/2addr v0, v2

    const-wide/high16 v4, 0x3ff0000000000000L    # 1.0

    sub-double/2addr v4, v2

    mul-double/2addr v4, p1

    add-double/2addr v0, v4

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;->average:D

    .line 56
    :goto_0
    iget-wide p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;->average:D

    return-wide p1
.end method
