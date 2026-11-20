.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/misc/CircularIndex;
.super Ljava/lang/Object;
.source "CircularIndex.java"


# direct methods
.method public static addOffset(III)I
    .locals 0

    add-int/2addr p0, p1

    if-gez p0, :cond_0

    add-int/2addr p2, p0

    return p2

    .line 69
    :cond_0
    rem-int/2addr p0, p2

    return p0
.end method

.method public static distanceP(III)I
    .locals 0

    .line 83
    sub-int/2addr p1, p0

    if-gez p1, :cond_0

    add-int/2addr p2, p1

    return p2

    :cond_0
    return p1
.end method

.method public static minusPOffset(III)I
    .locals 0

    .line 48
    sub-int/2addr p0, p1

    if-gez p0, :cond_0

    add-int/2addr p2, p0

    return p2

    :cond_0
    return p0
.end method

.method public static plusPOffset(III)I
    .locals 0

    add-int/2addr p0, p1

    .line 37
    rem-int/2addr p0, p2

    return p0
.end method
