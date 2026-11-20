.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/HistogramStatistics;
.super Ljava/lang/Object;
.source "HistogramStatistics.java"


# direct methods
.method public static count([II)I
    .locals 3

    const/4 v0, 0x0

    move v1, v0

    :goto_0
    if-ge v0, p1, :cond_0

    .line 69
    aget v2, p0, v0

    add-int/2addr v1, v2

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    return v1
.end method

.method public static mean([II)D
    .locals 1

    .line 82
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/HistogramStatistics;->count([II)I

    move-result v0

    invoke-static {p0, v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/HistogramStatistics;->mean([III)D

    move-result-wide p0

    return-wide p0
.end method

.method public static mean([III)D
    .locals 5

    const-wide/16 v0, 0x0

    const/4 v2, 0x0

    :goto_0
    if-ge v2, p2, :cond_0

    .line 88
    aget v3, p0, v2

    mul-int/2addr v3, v2

    int-to-double v3, v3

    add-double/2addr v0, v3

    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    :cond_0
    int-to-double p0, p1

    div-double/2addr v0, p0

    return-wide v0
.end method
