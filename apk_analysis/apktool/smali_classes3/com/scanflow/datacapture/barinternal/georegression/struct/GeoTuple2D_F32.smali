.class public abstract Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;
.super Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple_F32;
.source "GeoTuple2D_F32.java"


# instance fields
.field public x:F

.field public y:F


# direct methods
.method protected constructor <init>()V
    .locals 0

    .line 46
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple_F32;-><init>()V

    return-void
.end method


# virtual methods
.method public equals(Ljava/lang/Object;)Z
    .locals 4

    const/4 v0, 0x1

    if-ne p0, p1, :cond_0

    return v0

    .line 241
    :cond_0
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v1

    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v2

    const/4 v3, 0x0

    if-eq v1, v2, :cond_1

    return v3

    .line 244
    :cond_1
    check-cast p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;

    .line 245
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;->x:F

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;->x:F

    invoke-static {v1, v2}, Ljava/lang/Float;->compare(FF)I

    move-result v1

    if-nez v1, :cond_2

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;->y:F

    iget p1, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;->y:F

    invoke-static {v1, p1}, Ljava/lang/Float;->compare(FF)I

    move-result p1

    if-nez p1, :cond_2

    return v0

    :cond_2
    return v3
.end method

.method public hashCode()I
    .locals 2

    .line 263
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;->x:F

    invoke-static {v0}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v0

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;->y:F

    invoke-static {v1}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v1

    filled-new-array {v0, v1}, [Ljava/lang/Object;

    move-result-object v0

    invoke-static {v0}, Ljava/util/Objects;->hash([Ljava/lang/Object;)I

    move-result v0

    return v0
.end method

.method protected toString(Ljava/lang/String;)Ljava/lang/String;
    .locals 7

    .line 254
    new-instance v0, Ljava/text/DecimalFormat;

    const-string v1, "#"

    invoke-direct {v0, v1}, Ljava/text/DecimalFormat;-><init>(Ljava/lang/String;)V

    .line 255
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;->x:F

    float-to-double v1, v1

    const/16 v3, 0xb

    const/4 v4, 0x4

    invoke-static {v1, v2, v0, v3, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->fancyString(DLjava/text/DecimalFormat;II)Ljava/lang/String;

    move-result-object v1

    .line 256
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;->y:F

    float-to-double v5, v2

    invoke-static {v5, v6, v0, v3, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->fancyString(DLjava/text/DecimalFormat;II)Ljava/lang/String;

    move-result-object v0

    .line 258
    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v2, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string p1, "( "

    invoke-virtual {v2, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string p1, " "

    invoke-virtual {v2, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string p1, " )"

    invoke-virtual {v2, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method
