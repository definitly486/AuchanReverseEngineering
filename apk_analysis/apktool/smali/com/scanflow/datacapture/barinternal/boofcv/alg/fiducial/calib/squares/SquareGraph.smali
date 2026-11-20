.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;
.super Ljava/lang/Object;
.source "SquareGraph.java"


# instance fields
.field protected declaredEdges:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

.field parallelThreshold:D

.field protected unused:Ljava/util/Deque;

.field vector0:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;

.field vector1:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;


# direct methods
.method public constructor <init>()V
    .locals 3

    .line 37
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 39
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph$$ExternalSyntheticLambda0;

    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph$$ExternalSyntheticLambda0;-><init>()V

    new-instance v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph$$ExternalSyntheticLambda1;

    invoke-direct {v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph$$ExternalSyntheticLambda1;-><init>()V

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;-><init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/Factory;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DProcess;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;->declaredEdges:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 41
    new-instance v0, Ljava/util/ArrayDeque;

    invoke-direct {v0}, Ljava/util/ArrayDeque;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;->unused:Ljava/util/Deque;

    .line 43
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;->vector0:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;

    .line 44
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;->vector1:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;

    const/high16 v0, 0x42340000    # 45.0f

    .line 46
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/georegression/metric/UtilAngle;->radian(F)F

    move-result v0

    float-to-double v0, v0

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;->parallelThreshold:D

    return-void
.end method

.method private static add(II)I
    .locals 1

    const/4 v0, 0x4

    .line 200
    invoke-static {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/CircularIndex;->addOffset(III)I

    move-result p0

    return p0
.end method

.method public static computeNodeInfo(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;)V
    .locals 7

    .line 59
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->square:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    const/4 v1, 0x0

    .line 60
    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v0

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->square:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    const/4 v3, 0x2

    invoke-virtual {v2, v3}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v2

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->square:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    const/4 v4, 0x1

    invoke-virtual {v3, v4}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v3

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->square:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    const/4 v5, 0x3

    invoke-virtual {v4, v5}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v4

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->center:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    .line 59
    invoke-static {v0, v2, v3, v4, v6}, Lcom/scanflow/datacapture/barinternal/georegression/metric/Intersection2D_F64;->intersection(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v0

    if-eqz v0, :cond_1

    const-wide/16 v2, 0x0

    .line 67
    iput-wide v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->largestSide:D

    const-wide v2, 0x7fefffffffffffffL    # Double.MAX_VALUE

    .line 68
    iput-wide v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->smallestSide:D

    :goto_0
    const/4 v0, 0x4

    if-ge v1, v0, :cond_0

    .line 70
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->square:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v0

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->square:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v2, v5}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v2

    invoke-virtual {v0, v2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->distance(Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;)D

    move-result-wide v2

    .line 71
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->sideLengths:[D

    aput-wide v2, v0, v5

    .line 72
    iget-wide v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->largestSide:D

    invoke-static {v4, v5, v2, v3}, Ljava/lang/Math;->max(DD)D

    move-result-wide v4

    iput-wide v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->largestSide:D

    .line 73
    iget-wide v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->smallestSide:D

    invoke-static {v4, v5, v2, v3}, Ljava/lang/Math;->min(DD)D

    move-result-wide v2

    iput-wide v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->smallestSide:D

    add-int/lit8 v0, v1, 0x1

    move v5, v1

    move v1, v0

    goto :goto_0

    :cond_0
    return-void

    .line 63
    :cond_1
    new-instance p0, Ljava/lang/RuntimeException;

    const-string v0, "BAD"

    invoke-direct {p0, v0}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method private getUnusedEdge()Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;
    .locals 1

    .line 204
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;->unused:Ljava/util/Deque;

    invoke-interface {v0}, Ljava/util/Collection;->isEmpty()Z

    move-result v0

    if-nez v0, :cond_0

    .line 205
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;->unused:Ljava/util/Deque;

    invoke-interface {v0}, Ljava/util/Deque;->remove()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;

    return-object v0

    .line 207
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;->declaredEdges:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->grow()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;

    return-object v0
.end method


# virtual methods
.method public acuteAngle(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;ILcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;I)D
    .locals 7

    .line 183
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->square:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v0, p2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v0

    .line 184
    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->square:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    const/4 v1, 0x1

    invoke-static {p2, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;->add(II)I

    move-result p2

    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object p1

    .line 186
    iget-object p2, p3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->square:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {p2, p4}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object p2

    .line 187
    iget-object p3, p3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->square:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-static {p4, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;->add(II)I

    move-result p4

    invoke-virtual {p3, p4}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object p3

    .line 189
    iget-object p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;->vector0:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;

    iget-wide v1, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    iget-wide v3, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    sub-double/2addr v1, v3

    iget-wide v3, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    iget-wide v5, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    sub-double/2addr v3, v5

    invoke-virtual {p4, v1, v2, v3, v4}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->setTo(DD)Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;

    .line 190
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;->vector1:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;

    iget-wide v0, p3, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    iget-wide v2, p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    sub-double/2addr v0, v2

    iget-wide p3, p3, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    iget-wide v2, p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    sub-double/2addr p3, v2

    invoke-virtual {p1, v0, v1, p3, p4}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->setTo(DD)Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;

    .line 192
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;->vector0:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;

    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;->vector1:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;

    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;->acute(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;)D

    move-result-wide p1

    const-wide p3, 0x400921fb54442d18L    # Math.PI

    .line 193
    invoke-static {p3, p4, p1, p2}, Lcom/scanflow/datacapture/barinternal/georegression/metric/UtilAngle;->dist(DD)D

    move-result-wide p3

    invoke-static {p3, p4, p1, p2}, Ljava/lang/Math;->min(DD)D

    move-result-wide p1

    return-wide p1
.end method

.method public almostParallel(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;ILcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;I)Z
    .locals 0

    .line 156
    invoke-virtual {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;->acuteAngle(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;ILcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;I)D

    move-result-wide p1

    .line 158
    iget-wide p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;->parallelThreshold:D

    cmpl-double p1, p1, p3

    if-lez p1, :cond_0

    const/4 p1, 0x0

    return p1

    :cond_0
    const/4 p1, 0x1

    return p1
.end method

.method public checkConnect(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;ILcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;ID)Z
    .locals 3

    .line 113
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->edges:[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;

    aget-object v0, v0, p2

    if-eqz v0, :cond_0

    iget-wide v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;->distance:D

    cmpl-double v1, v1, p5

    if-lez v1, :cond_0

    .line 114
    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;->detachEdge(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;)V

    .line 117
    :cond_0
    iget-object v0, p3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->edges:[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;

    aget-object v0, v0, p4

    if-eqz v0, :cond_1

    iget-wide v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;->distance:D

    cmpl-double v1, v1, p5

    if-lez v1, :cond_1

    .line 118
    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;->detachEdge(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;)V

    .line 121
    :cond_1
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->edges:[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;

    aget-object v0, v0, p2

    if-nez v0, :cond_2

    iget-object v0, p3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->edges:[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;

    aget-object v0, v0, p4

    if-nez v0, :cond_2

    .line 122
    invoke-virtual/range {p0 .. p6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;->connect(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;ILcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;ID)V

    const/4 p1, 0x1

    return p1

    :cond_2
    const/4 p1, 0x0

    return p1
.end method

.method connect(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;ILcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;ID)V
    .locals 1

    .line 139
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;->getUnusedEdge()Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;

    move-result-object v0

    .line 141
    iput-object p1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;->a:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;

    .line 142
    iput p2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;->sideA:I

    .line 143
    iput-object p3, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;->b:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;

    .line 144
    iput p4, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;->sideB:I

    .line 145
    iput-wide p5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;->distance:D

    .line 147
    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->edges:[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;

    aput-object v0, p1, p2

    .line 148
    iget-object p1, p3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->edges:[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;

    aput-object v0, p1, p4

    return-void
.end method

.method public detachEdge(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;)V
    .locals 3

    .line 81
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;->a:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->edges:[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;->sideA:I

    const/4 v2, 0x0

    aput-object v2, v0, v1

    .line 82
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;->b:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->edges:[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;->sideB:I

    aput-object v2, v0, v1

    .line 83
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;->reset()V

    .line 84
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;->unused:Ljava/util/Deque;

    invoke-interface {v0, p1}, Ljava/util/Deque;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public findSideIntersect(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;)I
    .locals 4

    const/4 v0, 0x0

    const/4 v1, 0x3

    :goto_0
    const/4 v2, 0x4

    if-ge v0, v2, :cond_1

    .line 93
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->square:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v2, v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v2

    iput-object v2, p4, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->a:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    .line 94
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->square:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v2, v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v2

    iput-object v2, p4, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->b:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    .line 96
    invoke-static {p2, p4, p3}, Lcom/scanflow/datacapture/barinternal/georegression/metric/Intersection2D_F64;->intersection(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v2

    if-eqz v2, :cond_0

    return v1

    :cond_0
    add-int/lit8 v1, v0, 0x1

    move v3, v1

    move v1, v0

    move v0, v3

    goto :goto_0

    :cond_1
    const/4 p1, -0x1

    return p1
.end method

.method public reset()V
    .locals 3

    const/4 v0, 0x0

    .line 49
    :goto_0
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;->declaredEdges:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    iget v2, v1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    if-ge v0, v2, :cond_0

    .line 50
    invoke-virtual {v1, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->get(I)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;->reset()V

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    .line 52
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;->unused:Ljava/util/Deque;

    invoke-interface {v0}, Ljava/util/Collection;->clear()V

    .line 53
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;->unused:Ljava/util/Deque;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;->declaredEdges:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->toList()Ljava/util/List;

    move-result-object v1

    invoke-interface {v0, v1}, Ljava/util/Deque;->addAll(Ljava/util/Collection;)Z

    return-void
.end method
