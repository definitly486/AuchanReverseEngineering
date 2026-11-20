.class public Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;
.super Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple_I32;
.source "Point2D_I32.java"


# instance fields
.field public x:I

.field public y:I


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 45
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple_I32;-><init>()V

    return-void
.end method

.method public constructor <init>(II)V
    .locals 0

    .line 35
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple_I32;-><init>()V

    .line 36
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    .line 37
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    return-void
.end method


# virtual methods
.method public distance(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;)D
    .locals 2

    .line 59
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    sub-int/2addr v0, v1

    .line 60
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    iget p1, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    sub-int/2addr v1, p1

    mul-int/2addr v0, v0

    mul-int/2addr v1, v1

    add-int/2addr v0, v1

    int-to-double v0, v0

    .line 62
    invoke-static {v0, v1}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide v0

    return-wide v0
.end method

.method public distance2(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;)I
    .locals 2

    .line 86
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    sub-int/2addr v0, v1

    .line 87
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    iget p1, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    sub-int/2addr v1, p1

    mul-int/2addr v0, v0

    mul-int/2addr v1, v1

    add-int/2addr v0, v1

    return v0
.end method

.method public equals(Ljava/lang/Object;)Z
    .locals 4

    const/4 v0, 0x1

    if-ne p0, p1, :cond_0

    return v0

    .line 159
    :cond_0
    instance-of v1, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    const/4 v2, 0x0

    if-nez v1, :cond_1

    return v2

    .line 160
    :cond_1
    check-cast p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 161
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    iget v3, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    if-ne v1, v3, :cond_2

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    iget p1, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    if-ne v1, p1, :cond_2

    return v0

    :cond_2
    return v2
.end method

.method public hashCode()I
    .locals 2

    .line 166
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    invoke-static {v0}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v0

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    invoke-static {v1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v1

    filled-new-array {v0, v1}, [Ljava/lang/Object;

    move-result-object v0

    invoke-static {v0}, Ljava/util/Objects;->hash([Ljava/lang/Object;)I

    move-result v0

    return v0
.end method

.method public setTo(II)V
    .locals 0

    .line 48
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    .line 49
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    return-void
.end method

.method public toString()Ljava/lang/String;
    .locals 4

    .line 140
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "Point2D_I32{x="

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string v0, ", y="

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string v0, "}"

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
