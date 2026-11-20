.class public Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;
.super Ljava/lang/Object;
.source "LineSegment2D_F64.java"

# interfaces
.implements Ljava/io/Serializable;


# instance fields
.field public a:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

.field public b:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;


# direct methods
.method public constructor <init>()V
    .locals 1

    .line 38
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 35
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->a:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    .line 36
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->b:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    return-void
.end method


# virtual methods
.method public equals(Ljava/lang/Object;)Z
    .locals 4

    const/4 v0, 0x1

    if-ne p0, p1, :cond_0

    return v0

    .line 111
    :cond_0
    instance-of v1, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

    const/4 v2, 0x0

    if-nez v1, :cond_1

    return v2

    .line 114
    :cond_1
    check-cast p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

    .line 115
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->a:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->a:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-virtual {v1, v3}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_2

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->b:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->b:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-virtual {v1, p1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->equals(Ljava/lang/Object;)Z

    move-result p1

    if-eqz p1, :cond_2

    return v0

    :cond_2
    return v2
.end method

.method public getLength()D
    .locals 2

    .line 87
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->a:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->b:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->distance(Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;)D

    move-result-wide v0

    return-wide v0
.end method

.method public hashCode()I
    .locals 2

    .line 120
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->a:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->hashCode()I

    move-result v0

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->b:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->hashCode()I

    move-result v1

    add-int/2addr v0, v1

    return v0
.end method

.method public slopeX()D
    .locals 4

    .line 79
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->b:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide v0, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->a:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide v2, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    sub-double/2addr v0, v2

    return-wide v0
.end method

.method public slopeY()D
    .locals 4

    .line 83
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->b:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide v0, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->a:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide v2, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    sub-double/2addr v0, v2

    return-wide v0
.end method

.method public toString()Ljava/lang/String;
    .locals 4

    .line 100
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Class;->getSimpleName()Ljava/lang/String;

    move-result-object v0

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->a:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->b:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v3, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v0, "{a="

    invoke-virtual {v3, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v3, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v0, ", b="

    invoke-virtual {v3, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v3, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v0, "}"

    invoke-virtual {v3, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
