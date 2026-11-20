.class public abstract Lcom/scanflow/datacapture/barinternal/georegression/geometry/UtilPoint2D_I32;
.super Ljava/lang/Object;
.source "UtilPoint2D_I32.java"


# direct methods
.method public static distanceSq(IIII)I
    .locals 0

    .line 56
    sub-int/2addr p2, p0

    sub-int/2addr p3, p1

    mul-int/2addr p2, p2

    mul-int/2addr p3, p3

    add-int/2addr p2, p3

    return p2
.end method
