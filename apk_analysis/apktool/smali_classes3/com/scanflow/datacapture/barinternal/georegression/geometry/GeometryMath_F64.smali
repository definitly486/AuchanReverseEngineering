.class public abstract Lcom/scanflow/datacapture/barinternal/georegression/geometry/GeometryMath_F64;
.super Ljava/lang/Object;
.source "GeometryMath_F64.java"


# direct methods
.method public static innerProd(Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;)D
    .locals 10

    .line 867
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    const/4 v1, 0x3

    if-ne v0, v1, :cond_0

    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    if-ne v0, v1, :cond_0

    .line 871
    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    const/4 v0, 0x0

    aget-wide v4, p1, v0

    mul-double/2addr v4, v2

    iget-wide v6, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    aget-wide v0, p1, v1

    mul-double/2addr v0, v6

    add-double/2addr v4, v0

    const/4 p0, 0x6

    aget-wide v0, p1, p0

    add-double/2addr v4, v0

    const/4 p0, 0x1

    .line 872
    aget-wide v0, p1, p0

    mul-double/2addr v0, v2

    const/4 p0, 0x4

    aget-wide v8, p1, p0

    mul-double/2addr v8, v6

    add-double/2addr v0, v8

    const/4 p0, 0x7

    aget-wide v8, p1, p0

    add-double/2addr v0, v8

    const/4 p0, 0x2

    .line 873
    aget-wide v8, p1, p0

    mul-double/2addr v2, v8

    const/4 p0, 0x5

    aget-wide v8, p1, p0

    mul-double/2addr v6, v8

    add-double/2addr v2, v6

    const/16 p0, 0x8

    aget-wide p0, p1, p0

    add-double/2addr v2, p0

    .line 876
    iget-wide p0, p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    mul-double/2addr v4, p0

    iget-wide p0, p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    mul-double/2addr v0, p0

    add-double/2addr v4, v0

    add-double/2addr v4, v2

    return-wide v4

    .line 868
    :cond_0
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "M must be 3 by 3."

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method
