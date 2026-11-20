.class public abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/workaround/CorrectNegativeLatLongForMediaMuxer;
.super Ljava/lang/Object;
.source "CorrectNegativeLatLongForMediaMuxer.java"


# direct methods
.method public static adjustGeoLocation(DD)Landroid/util/Pair;
    .locals 1

    .line 57
    const-class v0, Landroidx/camera/video/internal/compat/quirk/NegativeLatLongSavesIncorrectlyQuirk;

    invoke-static {v0}, Landroidx/camera/video/internal/compat/quirk/DeviceQuirks;->get(Ljava/lang/Class;)Landroidx/camera/core/impl/Quirk;

    move-result-object v0

    if-eqz v0, :cond_0

    .line 58
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/workaround/CorrectNegativeLatLongForMediaMuxer;->adjustInternal(D)D

    move-result-wide p0

    .line 59
    invoke-static {p2, p3}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/workaround/CorrectNegativeLatLongForMediaMuxer;->adjustInternal(D)D

    move-result-wide p2

    .line 61
    :cond_0
    invoke-static {p0, p1}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object p0

    invoke-static {p2, p3}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object p1

    invoke-static {p0, p1}, Landroid/util/Pair;->create(Ljava/lang/Object;Ljava/lang/Object;)Landroid/util/Pair;

    move-result-object p0

    return-object p0
.end method

.method private static adjustInternal(D)D
    .locals 4

    .line 65
    const-wide/16 v0, 0x0

    cmpl-double v0, p0, v0

    if-ltz v0, :cond_0

    return-wide p0

    :cond_0
    const-wide v0, 0x40c3880000000000L    # 10000.0

    mul-double/2addr p0, v0

    const-wide/high16 v2, 0x3ff0000000000000L    # 1.0

    sub-double/2addr p0, v2

    div-double/2addr p0, v0

    return-wide p0
.end method
