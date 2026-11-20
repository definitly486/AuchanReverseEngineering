.class public Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;
.super Ljava/lang/Object;
.source "LineParametric2D_F64.java"

# interfaces
.implements Ljava/io/Serializable;


# instance fields
.field public p:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

.field public slope:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;


# direct methods
.method public constructor <init>()V
    .locals 1

    .line 68
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 42
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;->p:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    .line 45
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;->slope:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;

    return-void
.end method


# virtual methods
.method public equals(Ljava/lang/Object;)Z
    .locals 4

    const/4 v0, 0x1

    if-ne p0, p1, :cond_0

    return v0

    .line 162
    :cond_0
    instance-of v1, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;

    const/4 v2, 0x0

    if-nez v1, :cond_1

    return v2

    .line 165
    :cond_1
    check-cast p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;

    .line 166
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;->p:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;->p:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-virtual {v1, v3}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_2

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;->slope:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;

    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;->slope:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;

    invoke-virtual {v1, p1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->equals(Ljava/lang/Object;)Z

    move-result p1

    if-eqz p1, :cond_2

    return v0

    :cond_2
    return v2
.end method

.method public hashCode()I
    .locals 2

    .line 171
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;->p:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->hashCode()I

    move-result v0

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;->slope:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->hashCode()I

    move-result v1

    add-int/2addr v0, v1

    return v0
.end method

.method public toString()Ljava/lang/String;
    .locals 7

    .line 153
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/FancyPrint;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/FancyPrint;-><init>()V

    .line 154
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Class;->getSimpleName()Ljava/lang/String;

    move-result-object v1

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;->p:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide v2, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    invoke-virtual {v0, v2, v3}, Lcom/scanflow/datacapture/barinternal/org/ejml/FancyPrint;->s(D)Ljava/lang/String;

    move-result-object v2

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;->p:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide v3, v3, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    invoke-virtual {v0, v3, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/FancyPrint;->s(D)Ljava/lang/String;

    move-result-object v3

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;->slope:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;

    iget-wide v4, v4, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    invoke-virtual {v0, v4, v5}, Lcom/scanflow/datacapture/barinternal/org/ejml/FancyPrint;->s(D)Ljava/lang/String;

    move-result-object v4

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;->slope:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;

    iget-wide v5, v5, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    invoke-virtual {v0, v5, v6}, Lcom/scanflow/datacapture/barinternal/org/ejml/FancyPrint;->s(D)Ljava/lang/String;

    move-result-object v0

    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v5, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, " P( "

    invoke-virtual {v5, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v5, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, " "

    invoke-virtual {v5, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v5, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v2, " ) Slope( "

    invoke-virtual {v5, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v5, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v5, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v5, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v0, " )"

    invoke-virtual {v5, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
