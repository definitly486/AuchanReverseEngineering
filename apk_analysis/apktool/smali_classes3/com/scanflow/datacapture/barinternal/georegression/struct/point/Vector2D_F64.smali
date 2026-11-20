.class public Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;
.super Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;
.source "Vector2D_F64.java"


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 38
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;-><init>()V

    return-void
.end method


# virtual methods
.method public acute(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;)D
    .locals 2

    .line 99
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/georegression/geometry/UtilVector2D_F64;->acute(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;)D

    move-result-wide v0

    return-wide v0
.end method

.method public dot(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;)D
    .locals 6

    .line 89
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    iget-wide v2, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    mul-double/2addr v0, v2

    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    iget-wide v4, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    mul-double/2addr v2, v4

    add-double/2addr v0, v2

    return-wide v0
.end method

.method public toString()Ljava/lang/String;
    .locals 1

    .line 79
    const-string v0, "V"

    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->toString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
