.class public abstract Lcom/scanflow/datacapture/barinternal/georegression/metric/UtilAngle;
.super Ljava/lang/Object;
.source "UtilAngle.java"


# direct methods
.method public static degreeToRadian(F)F
    .locals 1

    .line 44
    sget v0, Lcom/scanflow/datacapture/barinternal/georegression/misc/GrlConstants;->F_PI:F

    mul-float/2addr v0, p0

    const/high16 p0, 0x43340000    # 180.0f

    div-float/2addr v0, p0

    return v0
.end method

.method public static dist(DD)D
    .locals 0

    .line 437
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/georegression/metric/UtilAngle;->minus(DD)D

    move-result-wide p0

    invoke-static {p0, p1}, Ljava/lang/Math;->abs(D)D

    move-result-wide p0

    return-wide p0
.end method

.method public static distanceCCW(DD)D
    .locals 2

    cmpl-double v0, p2, p0

    if-ltz v0, :cond_0

    sub-double/2addr p2, p0

    return-wide p2

    .line 266
    :cond_0
    sget-wide v0, Lcom/scanflow/datacapture/barinternal/georegression/misc/GrlConstants;->PI2:D

    sub-double/2addr p0, p2

    sub-double/2addr v0, p0

    return-wide v0
.end method

.method public static distanceCW(DD)D
    .locals 2

    cmpl-double v0, p0, p2

    if-ltz v0, :cond_0

    sub-double/2addr p0, p2

    return-wide p0

    .line 332
    :cond_0
    sget-wide v0, Lcom/scanflow/datacapture/barinternal/georegression/misc/GrlConstants;->PI2:D

    sub-double/2addr p2, p0

    sub-double/2addr v0, p2

    return-wide v0
.end method

.method public static minus(DD)D
    .locals 2

    .line 398
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/georegression/metric/UtilAngle;->distanceCCW(DD)D

    move-result-wide v0

    .line 399
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/georegression/metric/UtilAngle;->distanceCW(DD)D

    move-result-wide p0

    cmpg-double p2, v0, p0

    if-gez p2, :cond_0

    neg-double p0, v0

    :cond_0
    return-wide p0
.end method

.method public static radian(F)F
    .locals 0

    .line 74
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/georegression/metric/UtilAngle;->degreeToRadian(F)F

    move-result p0

    return p0
.end method
