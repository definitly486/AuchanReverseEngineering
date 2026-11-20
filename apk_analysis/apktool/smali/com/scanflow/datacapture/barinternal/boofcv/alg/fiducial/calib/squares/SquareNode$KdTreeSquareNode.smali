.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode$KdTreeSquareNode;
.super Ljava/lang/Object;
.source "SquareNode.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeDistance;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x9
    name = "KdTreeSquareNode"
.end annotation


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 139
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public distance(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;)D
    .locals 0

    .line 143
    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->center:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-object p2, p2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->center:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->distance2(Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;)D

    move-result-wide p1

    return-wide p1
.end method

.method public bridge synthetic distance(Ljava/lang/Object;Ljava/lang/Object;)D
    .locals 0

    .line 139
    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;

    check-cast p2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode$KdTreeSquareNode;->distance(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;)D

    move-result-wide p1

    return-wide p1
.end method

.method public length()I
    .locals 1

    .line 159
    const/4 v0, 0x2

    return v0
.end method

.method public valueAt(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;I)D
    .locals 2

    if-eqz p2, :cond_1

    const/4 v0, 0x1

    if-ne p2, v0, :cond_0

    .line 152
    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->center:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide p1, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    return-wide p1

    .line 154
    :cond_0
    new-instance p1, Ljava/lang/IllegalArgumentException;

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "Out of bounds. "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, p2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p2

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1

    .line 150
    :cond_1
    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->center:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide p1, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    return-wide p1
.end method

.method public bridge synthetic valueAt(Ljava/lang/Object;I)D
    .locals 0

    .line 139
    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode$KdTreeSquareNode;->valueAt(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;I)D

    move-result-wide p1

    return-wide p1
.end method
