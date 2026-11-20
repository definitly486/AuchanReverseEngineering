.class public abstract Lcom/scanflow/datacapture/barinternal/georegression/geometry/UtilVector2D_F64;
.super Ljava/lang/Object;
.source "UtilVector2D_F64.java"


# direct methods
.method public static acute(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;)D
    .locals 4

    .line 36
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;->dot(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;)D

    move-result-wide v0

    .line 38
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->norm()D

    move-result-wide v2

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->norm()D

    move-result-wide p0

    mul-double/2addr v2, p0

    div-double/2addr v0, v2

    const-wide/high16 p0, 0x3ff0000000000000L    # 1.0

    cmpl-double v2, v0, p0

    if-lez v2, :cond_0

    :goto_0
    move-wide v0, p0

    goto :goto_1

    :cond_0
    const-wide/high16 p0, -0x4010000000000000L    # -1.0

    cmpg-double v2, v0, p0

    if-gez v2, :cond_1

    goto :goto_0

    .line 44
    :cond_1
    :goto_1
    invoke-static {v0, v1}, Ljava/lang/Math;->acos(D)D

    move-result-wide p0

    return-wide p0
.end method
