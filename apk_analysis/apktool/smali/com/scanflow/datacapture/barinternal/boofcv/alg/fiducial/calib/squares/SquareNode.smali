.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;
.super Ljava/lang/Object;
.source "SquareNode.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode$KdTreeSquareNode;
    }
.end annotation


# instance fields
.field public center:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

.field public edges:[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;

.field public graph:I

.field public largestSide:D

.field public sideLengths:[D

.field public smallestSide:D

.field public square:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

.field public touch:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;


# direct methods
.method public constructor <init>()V
    .locals 2

    .line 35
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 45
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->center:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    const/4 v0, 0x4

    .line 47
    new-array v1, v0, [D

    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->sideLengths:[D

    .line 56
    new-array v0, v0, [Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->edges:[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;

    return-void
.end method


# virtual methods
.method public findEdgeIndex(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;)I
    .locals 2

    const/4 v0, 0x0

    :goto_0
    const/4 v1, 0x4

    if-ge v0, v1, :cond_1

    .line 132
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->edges:[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;

    aget-object v1, v1, v0

    if-eqz v1, :cond_0

    invoke-virtual {v1, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;->isEndPoint(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;)Z

    move-result v1

    if-eqz v1, :cond_0

    return v0

    :cond_0
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_1
    const/4 p1, -0x1

    return p1
.end method

.method public reset()V
    .locals 6

    const/4 v0, 0x0

    .line 77
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->square:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    .line 78
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->touch:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;

    .line 79
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->center:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    const-wide/high16 v2, -0x4010000000000000L    # -1.0

    invoke-virtual {v1, v2, v3, v2, v3}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->setTo(DD)Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;

    const-wide/16 v1, 0x0

    .line 80
    iput-wide v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->largestSide:D

    const-wide v3, 0x7fefffffffffffffL    # Double.MAX_VALUE

    .line 81
    iput-wide v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->smallestSide:D

    const/4 v3, -0x2

    .line 82
    iput v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->graph:I

    const/4 v3, 0x0

    .line 83
    :goto_0
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->edges:[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;

    array-length v5, v4

    if-ge v3, v5, :cond_0

    .line 84
    aput-object v0, v4, v3

    .line 85
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->sideLengths:[D

    aput-wide v1, v4, v3

    add-int/lit8 v3, v3, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method
