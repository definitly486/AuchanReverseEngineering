.class public abstract Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;
.super Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple_F64;
.source "GeoTuple3D_F64.java"


# instance fields
.field public x:D

.field public y:D

.field public z:D


# direct methods
.method protected constructor <init>()V
    .locals 0

    .line 46
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple_F64;-><init>()V

    return-void
.end method


# virtual methods
.method protected _setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;)V
    .locals 2

    .line 54
    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->x:D

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->x:D

    .line 55
    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->y:D

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->y:D

    .line 56
    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->z:D

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->z:D

    return-void
.end method

.method public divideIP(D)V
    .locals 2

    .line 200
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->x:D

    div-double/2addr v0, p1

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->x:D

    .line 201
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->y:D

    div-double/2addr v0, p1

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->y:D

    .line 202
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->z:D

    div-double/2addr v0, p1

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->z:D

    return-void
.end method

.method public equals(Ljava/lang/Object;)Z
    .locals 6

    const/4 v0, 0x1

    if-ne p0, p1, :cond_0

    return v0

    .line 285
    :cond_0
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v1

    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v2

    const/4 v3, 0x0

    if-eq v1, v2, :cond_1

    return v3

    .line 288
    :cond_1
    check-cast p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;

    .line 289
    iget-wide v1, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->x:D

    iget-wide v4, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->x:D

    invoke-static {v1, v2, v4, v5}, Ljava/lang/Double;->compare(DD)I

    move-result v1

    if-nez v1, :cond_2

    iget-wide v1, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->y:D

    iget-wide v4, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->y:D

    invoke-static {v1, v2, v4, v5}, Ljava/lang/Double;->compare(DD)I

    move-result v1

    if-nez v1, :cond_2

    iget-wide v1, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->z:D

    iget-wide v4, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->z:D

    invoke-static {v1, v2, v4, v5}, Ljava/lang/Double;->compare(DD)I

    move-result p1

    if-nez p1, :cond_2

    return v0

    :cond_2
    return v3
.end method

.method public hashCode()I
    .locals 4

    .line 303
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->x:D

    invoke-static {v0, v1}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object v0

    iget-wide v1, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->y:D

    invoke-static {v1, v2}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object v1

    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->z:D

    invoke-static {v2, v3}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object v2

    filled-new-array {v0, v1, v2}, [Ljava/lang/Object;

    move-result-object v0

    invoke-static {v0}, Ljava/util/Objects;->hash([Ljava/lang/Object;)I

    move-result v0

    return v0
.end method

.method public norm()D
    .locals 4

    .line 221
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->x:D

    mul-double/2addr v0, v0

    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->y:D

    mul-double/2addr v2, v2

    add-double/2addr v0, v2

    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->z:D

    mul-double/2addr v2, v2

    add-double/2addr v0, v2

    invoke-static {v0, v1}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide v0

    return-wide v0
.end method

.method public setTo(DDD)Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;
    .locals 0

    .line 60
    iput-wide p1, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->x:D

    .line 61
    iput-wide p3, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->y:D

    .line 62
    iput-wide p5, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->z:D

    return-object p0
.end method

.method public toString(Ljava/lang/String;)Ljava/lang/String;
    .locals 7

    .line 293
    new-instance v0, Ljava/text/DecimalFormat;

    const-string v1, "#"

    invoke-direct {v0, v1}, Ljava/text/DecimalFormat;-><init>(Ljava/lang/String;)V

    .line 294
    iget-wide v1, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->x:D

    const/16 v3, 0xb

    const/4 v4, 0x4

    invoke-static {v1, v2, v0, v3, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->fancyString(DLjava/text/DecimalFormat;II)Ljava/lang/String;

    move-result-object v1

    .line 295
    iget-wide v5, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->y:D

    invoke-static {v5, v6, v0, v3, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->fancyString(DLjava/text/DecimalFormat;II)Ljava/lang/String;

    move-result-object v2

    .line 296
    iget-wide v5, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->z:D

    invoke-static {v5, v6, v0, v3, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->fancyString(DLjava/text/DecimalFormat;II)Ljava/lang/String;

    move-result-object v0

    .line 298
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v3, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string p1, "( "

    invoke-virtual {v3, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v3, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string p1, " , "

    invoke-virtual {v3, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v3, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v3, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v3, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string p1, " )"

    invoke-virtual {v3, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method
