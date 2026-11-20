.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;
.super Ljava/lang/Object;
.source "PolylineSplitMerge.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;,
        Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$ErrorValue;,
        Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$CandidatePolyline;,
        Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;
    }
.end annotation


# instance fields
.field private bestPolyline:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$CandidatePolyline;

.field private convex:Z

.field convexTest:D

.field private cornerScorePenalty:D

.field corners:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

.field private final extraConsider:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

.field private fatalError:Z

.field private final line:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

.field list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;

.field private loops:Z

.field maxNumberOfSideSamples:I

.field final maxSideError:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

.field private maxSides:I

.field private minSides:I

.field private minimumSideLength:I

.field private final polylines:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

.field private final resultsA:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;

.field private final resultsB:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;

.field sideError:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$ErrorValue;

.field private splitter:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitSelector;

.field private thresholdSideSplitScore:D


# direct methods
.method public constructor <init>()V
    .locals 4

    .line 72
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const/4 v0, 0x1

    .line 75
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->loops:Z

    const/4 v0, 0x0

    .line 78
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->convex:Z

    const v0, 0x7fffffff

    .line 81
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->maxSides:I

    const/4 v0, 0x3

    .line 83
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->minSides:I

    const/16 v0, 0xa

    .line 86
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->minimumSideLength:I

    const-wide/high16 v0, 0x3ff0000000000000L    # 1.0

    const-wide/16 v2, 0x0

    .line 89
    invoke-static {v0, v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->relative(DD)Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->extraConsider:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    const-wide/high16 v0, 0x3fd0000000000000L    # 0.25

    .line 92
    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->cornerScorePenalty:D

    .line 95
    iput-wide v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->thresholdSideSplitScore:D

    const/16 v0, 0x32

    .line 101
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->maxNumberOfSideSamples:I

    const-wide/high16 v0, 0x4004000000000000L    # 2.5

    .line 107
    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->convexTest:D

    const-wide v0, 0x3fb999999999999aL    # 0.1

    const-wide/high16 v2, 0x4008000000000000L    # 3.0

    .line 110
    invoke-static {v0, v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->relative(DD)Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->maxSideError:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    .line 113
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->line:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

    .line 116
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;

    .line 117
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$$ExternalSyntheticLambda0;

    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$$ExternalSyntheticLambda0;-><init>()V

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;-><init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/Factory;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->corners:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 119
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/MaximumLineDistance;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/MaximumLineDistance;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->splitter:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitSelector;

    .line 120
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->resultsA:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;

    .line 121
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->resultsB:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;

    .line 124
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$$ExternalSyntheticLambda1;

    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$$ExternalSyntheticLambda1;-><init>()V

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;-><init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/Factory;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->polylines:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 131
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$ErrorValue;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$ErrorValue;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->sideError:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$ErrorValue;

    return-void
.end method

.method public static assignLine(Ljava/util/List;IILcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;)V
    .locals 3

    .line 817
    invoke-interface {p0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 818
    invoke-interface {p0, p2}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 820
    iget-object p2, p3, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;->p:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget v0, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    int-to-double v1, v0

    iput-wide v1, p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    .line 821
    iget p1, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    int-to-double v1, p1

    iput-wide v1, p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    .line 822
    iget-object p2, p3, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;->slope:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;

    iget p3, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    sub-int/2addr p3, v0

    int-to-double v0, p3

    iput-wide v0, p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    .line 823
    iget p0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    sub-int/2addr p0, p1

    int-to-double p0, p0

    iput-wide p0, p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    return-void
.end method

.method public static assignLine(Ljava/util/List;IILcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;)V
    .locals 4

    .line 827
    invoke-interface {p0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 828
    invoke-interface {p0, p2}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 830
    iget-object p2, p3, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->a:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget v0, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    int-to-double v0, v0

    iget p1, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    int-to-double v2, p1

    invoke-virtual {p2, v0, v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->setTo(DD)Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;

    .line 831
    iget-object p1, p3, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->b:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget p2, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    int-to-double p2, p2

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    int-to-double v0, p0

    invoke-virtual {p1, p2, p3, v0, v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->setTo(DD)Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;

    return-void
.end method

.method static computeScore(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;DZ)D
    .locals 6

    .line 302
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->getHead()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    move-result-object v0

    if-eqz p3, :cond_0

    const/4 v1, 0x0

    goto :goto_0

    .line 303
    :cond_0
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->getTail()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    move-result-object v1

    :goto_0
    const-wide/16 v2, 0x0

    :goto_1
    if-eq v0, v1, :cond_1

    .line 305
    iget-object v4, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    check-cast v4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    iget-wide v4, v4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->sideError:D

    add-double/2addr v2, v4

    .line 306
    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->next:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    goto :goto_1

    .line 309
    :cond_1
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->size()I

    move-result p0

    if-eqz p3, :cond_2

    goto :goto_2

    :cond_2
    add-int/lit8 p0, p0, -0x1

    :goto_2
    int-to-double v0, p0

    div-double/2addr v2, v0

    mul-double/2addr p1, v0

    add-double/2addr v2, p1

    return-wide v2
.end method

.method static distanceAbs(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;)D
    .locals 2

    .line 807
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    sub-int/2addr v0, v1

    int-to-double v0, v0

    .line 808
    iget p1, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    sub-int/2addr p1, p0

    int-to-double p0, p1

    .line 810
    invoke-static {v0, v1}, Ljava/lang/Math;->abs(D)D

    move-result-wide v0

    invoke-static {p0, p1}, Ljava/lang/Math;->abs(D)D

    move-result-wide p0

    add-double/2addr v0, p0

    return-wide v0
.end method

.method static distanceSq(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;)D
    .locals 2

    .line 800
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    sub-int/2addr v0, v1

    int-to-double v0, v0

    .line 801
    iget p1, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    sub-int/2addr p1, p0

    int-to-double p0, p1

    mul-double/2addr v0, v0

    mul-double/2addr p0, p0

    add-double/2addr v0, p0

    return-wide v0
.end method

.method static findCornerSeed(Ljava/util/List;)I
    .locals 8

    const/4 v0, 0x0

    .line 580
    invoke-interface {p0, v0}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    const/4 v1, -0x1

    const-wide v2, -0x10000000000001L

    const/4 v4, 0x1

    .line 585
    :goto_0
    invoke-interface {p0}, Ljava/util/List;->size()I

    move-result v5

    if-ge v4, v5, :cond_1

    .line 586
    invoke-interface {p0, v4}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v5

    check-cast v5, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 588
    invoke-static {v0, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->distanceSq(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;)D

    move-result-wide v5

    cmpl-double v7, v5, v2

    if-lez v7, :cond_0

    move v1, v4

    move-wide v2, v5

    :cond_0
    add-int/lit8 v4, v4, 0x1

    goto :goto_0

    :cond_1
    return v1
.end method

.method private initializeScore(Ljava/util/List;Z)Z
    .locals 5

    .line 358
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->getHead()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    move-result-object v0

    if-eqz p2, :cond_0

    const/4 p2, 0x0

    goto :goto_0

    .line 359
    :cond_0
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;

    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->getTail()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    move-result-object p2

    :goto_0
    const/4 v1, 0x0

    if-eq v0, p2, :cond_3

    .line 361
    iget-boolean v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->convex:Z

    if-eqz v2, :cond_1

    invoke-virtual {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->isSideConvex(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;)Z

    move-result v2

    if-nez v2, :cond_1

    return v1

    .line 364
    :cond_1
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->next:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    if-nez v1, :cond_2

    .line 368
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    check-cast v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    iget v2, v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->index:I

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;

    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->getHead()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    move-result-object v3

    iget-object v3, v3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    check-cast v3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    iget v3, v3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->index:I

    invoke-virtual {p0, p1, v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->computeSideError(Ljava/util/List;II)D

    move-result-wide v2

    goto :goto_1

    .line 370
    :cond_2
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    check-cast v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    iget v2, v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->index:I

    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    check-cast v3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    iget v3, v3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->index:I

    invoke-virtual {p0, p1, v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->computeSideError(Ljava/util/List;II)D

    move-result-wide v2

    .line 372
    :goto_1
    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    iput-wide v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->sideError:D

    move-object v0, v1

    goto :goto_0

    .line 377
    :cond_3
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->getHead()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    move-result-object v0

    :goto_2
    const/4 v2, 0x1

    if-eq v0, p2, :cond_5

    .line 379
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;

    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->size()I

    move-result v3

    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->minSides:I

    if-ge v3, v4, :cond_4

    goto :goto_3

    :cond_4
    move v2, v1

    :goto_3
    invoke-virtual {p0, p1, v0, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->computePotentialSplitScore(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;Z)V

    .line 380
    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->next:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    goto :goto_2

    :cond_5
    return v2
.end method

.method static isConvexUsingMaxDistantPoints(Ljava/util/List;II)Z
    .locals 4

    .line 785
    invoke-interface {p0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    invoke-interface {p0, p2}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->distanceSq(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;)D

    move-result-wide v0

    invoke-static {v0, v1}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide v0

    const-wide v2, 0x401090fdaa22168cL    # 4.141592653589793

    mul-double/2addr v0, v2

    const-wide/high16 v2, 0x3fe0000000000000L    # 0.5

    add-double/2addr v0, v2

    double-to-int v0, v0

    .line 790
    invoke-interface {p0}, Ljava/util/List;->size()I

    move-result v1

    invoke-static {p1, p2, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/CircularIndex;->distanceP(III)I

    move-result v1

    .line 791
    invoke-interface {p0}, Ljava/util/List;->size()I

    move-result p0

    invoke-static {p2, p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/CircularIndex;->distanceP(III)I

    move-result p0

    if-gt v1, v0, :cond_0

    if-gt p0, v0, :cond_0

    const/4 p0, 0x1

    return p0

    :cond_0
    const/4 p0, 0x0

    return p0
.end method

.method static maximumDistance(Ljava/util/List;II)I
    .locals 9

    .line 608
    invoke-interface {p0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 609
    invoke-interface {p0, p2}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p2

    check-cast p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    const/4 v0, -0x1

    const-wide v1, -0x10000000000001L

    const/4 v3, 0x0

    .line 614
    :goto_0
    invoke-interface {p0}, Ljava/util/List;->size()I

    move-result v4

    if-ge v3, v4, :cond_1

    .line 615
    invoke-interface {p0, v3}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 618
    invoke-static {p1, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->distanceAbs(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;)D

    move-result-wide v5

    invoke-static {p2, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->distanceAbs(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;)D

    move-result-wide v7

    add-double/2addr v5, v7

    cmpl-double v4, v5, v1

    if-lez v4, :cond_0

    move v0, v3

    move-wide v1, v5

    :cond_0
    add-int/lit8 v3, v3, 0x1

    goto :goto_0

    :cond_1
    return v0
.end method

.method private reset()V
    .locals 1

    .line 221
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->reset()V

    .line 222
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->corners:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 223
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->polylines:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    const/4 v0, 0x0

    .line 224
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->bestPolyline:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$CandidatePolyline;

    const/4 v0, 0x0

    .line 225
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->fatalError:Z

    return-void
.end method

.method private sequentialSideFit(Ljava/util/List;Z)V
    .locals 4

    .line 202
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->maxSides:I

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->extraConsider:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    int-to-double v2, v0

    invoke-virtual {v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->computeI(D)I

    move-result v1

    add-int/2addr v0, v1

    if-gtz v0, :cond_0

    .line 203
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v0

    .line 204
    :cond_0
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->size()I

    move-result v1

    if-ge v1, v0, :cond_1

    iget-boolean v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->fatalError:Z

    if-nez v1, :cond_1

    .line 205
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->increaseNumberOfSidesByOne(Ljava/util/List;Z)Z

    move-result v1

    if-nez v1, :cond_0

    .line 210
    :cond_1
    :goto_0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->fatalError:Z

    if-nez v0, :cond_2

    .line 211
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->sideError:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$ErrorValue;

    invoke-virtual {p0, p1, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->selectCornerToRemove(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$ErrorValue;Z)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    move-result-object v0

    if-eqz v0, :cond_2

    .line 213
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->sideError:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$ErrorValue;

    iget-wide v1, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$ErrorValue;->value:D

    invoke-virtual {p0, v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->removeCornerAndSavePolyline(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;D)Z

    goto :goto_0

    :cond_2
    return-void
.end method


# virtual methods
.method addCorner(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;
    .locals 1

    .line 409
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->corners:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->grow()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    .line 410
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->reset()V

    .line 411
    iput p1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->index:I

    .line 412
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;

    invoke-virtual {p1, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->pushTail(Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    .line 413
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->getTail()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    move-result-object p1

    return-object p1
.end method

.method canBeSplit(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;Z)Z
    .locals 4

    .line 732
    invoke-virtual {p0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->next(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    move-result-object v0

    .line 736
    iget-object v1, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    check-cast v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    iget v1, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->index:I

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    iget v0, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->index:I

    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result p1

    invoke-static {v1, v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/CircularIndex;->distanceP(III)I

    move-result p1

    .line 740
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->minimumSideLength:I

    mul-int/lit8 v0, v0, 0x2

    const/4 v1, 0x0

    if-gt p1, v0, :cond_0

    return v1

    :cond_0
    if-nez p3, :cond_2

    .line 745
    iget-object p1, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    iget-wide p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->sideError:D

    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->thresholdSideSplitScore:D

    cmpl-double p1, p1, v2

    if-lez p1, :cond_1

    goto :goto_0

    :cond_1
    return v1

    :cond_2
    :goto_0
    const/4 p1, 0x1

    return p1
.end method

.method computePotentialSplitScore(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;Z)V
    .locals 2

    .line 674
    invoke-virtual {p0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->next(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    move-result-object v0

    .line 676
    iget-object v1, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    check-cast v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    invoke-virtual {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->canBeSplit(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;Z)Z

    move-result p3

    iput-boolean p3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->splitable:Z

    .line 678
    iget-object p3, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    check-cast p3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    iget-boolean p3, p3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->splitable:Z

    if-eqz p3, :cond_0

    .line 679
    invoke-virtual {p0, p1, p2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->setSplitVariables(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;)V

    :cond_0
    return-void
.end method

.method computeSideError(Ljava/util/List;II)D
    .locals 12

    .line 636
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->line:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

    invoke-static {p1, p2, p3, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->assignLine(Ljava/util/List;IILcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;)V

    const/4 v0, 0x0

    const-wide/16 v1, 0x0

    if-lt p3, p2, :cond_1

    sub-int/2addr p3, p2

    add-int/lit8 p3, p3, -0x1

    .line 644
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->maxNumberOfSideSamples:I

    invoke-static {p3, v3}, Ljava/lang/Math;->min(II)I

    move-result v3

    move-wide v4, v1

    :goto_0
    if-ge v0, v3, :cond_0

    add-int/lit8 v6, p2, 0x1

    mul-int v7, p3, v0

    .line 646
    div-int/2addr v7, v3

    add-int/2addr v6, v7

    .line 647
    invoke-interface {p1, v6}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 648
    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->line:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

    iget v8, v6, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    int-to-double v8, v8

    iget v6, v6, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    int-to-double v10, v6

    invoke-static {v7, v8, v9, v10, v11}, Lcom/scanflow/datacapture/barinternal/georegression/metric/Distance2D_F64;->distanceSq(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;DD)D

    move-result-wide v6

    add-double/2addr v4, v6

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    int-to-double p1, v3

    div-double/2addr v4, p1

    goto :goto_2

    .line 652
    :cond_1
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v3

    sub-int/2addr v3, p2

    add-int/lit8 v3, v3, -0x1

    add-int/2addr v3, p3

    .line 653
    iget p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->maxNumberOfSideSamples:I

    invoke-static {v3, p3}, Ljava/lang/Math;->min(II)I

    move-result p3

    move-wide v4, v1

    :goto_1
    if-ge v0, p3, :cond_2

    mul-int v6, v3, v0

    .line 655
    div-int/2addr v6, p3

    add-int/lit8 v7, p2, 0x1

    add-int/2addr v7, v6

    .line 656
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v6

    rem-int/2addr v7, v6

    .line 657
    invoke-interface {p1, v7}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 658
    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->line:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

    iget v8, v6, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    int-to-double v8, v8

    iget v6, v6, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    int-to-double v10, v6

    invoke-static {v7, v8, v9, v10, v11}, Lcom/scanflow/datacapture/barinternal/georegression/metric/Distance2D_F64;->distanceSq(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;DD)D

    move-result-wide v6

    add-double/2addr v4, v6

    add-int/lit8 v0, v0, 0x1

    goto :goto_1

    :cond_2
    int-to-double p1, p3

    div-double/2addr v4, p1

    move v3, p3

    :goto_2
    if-lez v3, :cond_3

    return-wide v4

    :cond_3
    return-wide v1
.end method

.method ensureTriangleOrder(Ljava/util/List;)V
    .locals 6

    .line 390
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->getHead()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    move-result-object v0

    .line 391
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    check-cast v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    .line 392
    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->next:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    .line 393
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    check-cast v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    .line 394
    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->next:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    .line 395
    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    .line 397
    iget v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->index:I

    iget v4, v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->index:I

    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v5

    invoke-static {v3, v4, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/CircularIndex;->distanceP(III)I

    move-result v3

    .line 398
    iget v4, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->index:I

    iget v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->index:I

    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result p1

    invoke-static {v4, v5, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/CircularIndex;->distanceP(III)I

    move-result p1

    if-le v3, p1, :cond_0

    .line 401
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->reset()V

    .line 402
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;

    invoke-virtual {p1, v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->pushTail(Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    .line 403
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;

    invoke-virtual {p1, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->pushTail(Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    .line 404
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;

    invoke-virtual {p1, v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->pushTail(Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    :cond_0
    return-void
.end method

.method findInitialTriangle(Ljava/util/List;)Z
    .locals 6

    .line 320
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->findCornerSeed(Ljava/util/List;)I

    move-result v0

    .line 323
    iget-boolean v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->convex:Z

    const/4 v2, 0x0

    if-eqz v1, :cond_0

    .line 324
    invoke-static {p1, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->isConvexUsingMaxDistantPoints(Ljava/util/List;II)Z

    move-result v1

    if-nez v1, :cond_0

    return v2

    .line 329
    :cond_0
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->splitter:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitSelector;

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->resultsA:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;

    invoke-interface {v1, p1, v2, v0, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitSelector;->selectSplitPoint(Ljava/util/List;IILcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;)V

    .line 330
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->splitter:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitSelector;

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->resultsB:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;

    invoke-interface {v1, p1, v0, v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitSelector;->selectSplitPoint(Ljava/util/List;IILcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;)V

    .line 332
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->splitter:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitSelector;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->resultsA:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;

    iget-wide v2, v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;->score:D

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->resultsB:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;

    iget-wide v4, v4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;->score:D

    invoke-interface {v1, v2, v3, v4, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitSelector;->compareScore(DD)I

    move-result v1

    if-ltz v1, :cond_1

    .line 333
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->resultsA:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;

    iget v1, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;->index:I

    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->addCorner(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    .line 334
    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->addCorner(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    goto :goto_0

    .line 336
    :cond_1
    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->addCorner(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    .line 337
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->resultsB:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;

    iget v0, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;->index:I

    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->addCorner(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    .line 342
    :goto_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->getHead()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    move-result-object v0

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    iget v0, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->index:I

    .line 343
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->getHead()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    move-result-object v1

    iget-object v1, v1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->next:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    iget-object v1, v1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    check-cast v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    iget v1, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->index:I

    .line 344
    invoke-static {p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->maximumDistance(Ljava/util/List;II)I

    move-result v0

    .line 345
    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->addCorner(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    .line 348
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->ensureTriangleOrder(Ljava/util/List;)V

    const/4 v0, 0x1

    .line 350
    invoke-direct {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->initializeScore(Ljava/util/List;Z)Z

    move-result p1

    return p1
.end method

.method public getBestPolyline()Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$CandidatePolyline;
    .locals 1

    .line 842
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->bestPolyline:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$CandidatePolyline;

    return-object v0
.end method

.method public getMinSides()I
    .locals 1

    .line 83
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->minSides:I

    return v0
.end method

.method increaseNumberOfSidesByOne(Ljava/util/List;Z)Z
    .locals 5

    .line 425
    invoke-virtual {p0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->selectCornerToSplit(Z)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    move-result-object p2

    const/4 v0, 0x0

    if-nez p2, :cond_0

    return v0

    .line 432
    :cond_0
    iget-object v1, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    move-object v2, v1

    check-cast v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    check-cast v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    iget-wide v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->splitError0:D

    iput-wide v3, v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->sideError:D

    .line 434
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->corners:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->grow()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    .line 435
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->reset()V

    .line 436
    iget-object v2, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    move-object v3, v2

    check-cast v3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    iget v3, v3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->splitLocation:I

    iput v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->index:I

    .line 437
    check-cast v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    iget-wide v2, v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->splitError1:D

    iput-wide v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->sideError:D

    .line 438
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;

    invoke-virtual {v2, p2, v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->insertAfter(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    move-result-object v1

    .line 441
    iget-boolean v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->convex:Z

    if-eqz v2, :cond_1

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->isSideConvex(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;)Z

    move-result v2

    if-nez v2, :cond_1

    return v0

    .line 445
    :cond_1
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;

    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->size()I

    move-result v2

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->minSides:I

    const/4 v4, 0x1

    if-ge v2, v3, :cond_2

    move v2, v4

    goto :goto_0

    :cond_2
    move v2, v0

    :goto_0
    invoke-virtual {p0, p1, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->computePotentialSplitScore(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;Z)V

    .line 446
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->size()I

    move-result v1

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->minSides:I

    if-ge v1, v2, :cond_3

    move v0, v4

    :cond_3
    invoke-virtual {p0, p1, p2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->computePotentialSplitScore(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;Z)V

    .line 450
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->savePolyline()Z

    return v4
.end method

.method public isLoops()Z
    .locals 1

    .line 75
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->loops:Z

    return v0
.end method

.method isSideConvex(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;)Z
    .locals 4

    .line 463
    invoke-virtual {p0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->next(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    move-result-object v0

    .line 465
    iget-object v1, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    check-cast v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    iget v1, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->index:I

    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    check-cast v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    iget v2, v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->index:I

    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v3

    invoke-static {v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/CircularIndex;->distanceP(III)I

    move-result v1

    .line 467
    iget-object p2, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    check-cast p2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    iget p2, p2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->index:I

    invoke-interface {p1, p2}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p2

    check-cast p2, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 468
    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    iget v0, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->index:I

    invoke-interface {p1, v0}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 470
    invoke-virtual {p2, p1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->distance(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;)D

    move-result-wide p1

    int-to-double v0, v1

    .line 472
    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->convexTest:D

    mul-double/2addr p1, v2

    cmpl-double p1, v0, p1

    if-gez p1, :cond_0

    const/4 p1, 0x1

    return p1

    :cond_0
    const/4 p1, 0x0

    return p1
.end method

.method next(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;
    .locals 0

    .line 752
    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->next:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    if-nez p1, :cond_0

    .line 753
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->getHead()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    move-result-object p1

    :cond_0
    return-object p1
.end method

.method previous(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;
    .locals 0

    .line 763
    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->prev:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    if-nez p1, :cond_0

    .line 764
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->getTail()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    move-result-object p1

    :cond_0
    return-object p1
.end method

.method public process(Ljava/util/List;)Z
    .locals 10

    .line 141
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->reset()V

    .line 143
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->loops:Z

    const/4 v1, 0x2

    const/4 v2, 0x3

    const/4 v3, 0x1

    const/4 v4, 0x0

    if-eqz v0, :cond_1

    .line 145
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v0

    if-ge v0, v2, :cond_0

    return v4

    .line 148
    :cond_0
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->findInitialTriangle(Ljava/util/List;)Z

    move-result v0

    if-nez v0, :cond_3

    return v4

    .line 152
    :cond_1
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v0

    if-ge v0, v1, :cond_2

    return v4

    .line 156
    :cond_2
    invoke-virtual {p0, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->addCorner(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    .line 157
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v0

    sub-int/2addr v0, v3

    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->addCorner(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    .line 158
    invoke-direct {p0, p1, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->initializeScore(Ljava/util/List;Z)Z

    .line 160
    :cond_3
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->savePolyline()Z

    .line 162
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->loops:Z

    invoke-direct {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->sequentialSideFit(Ljava/util/List;Z)V

    .line 164
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->fatalError:Z

    if-eqz v0, :cond_4

    return v4

    .line 167
    :cond_4
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->loops:Z

    if-eqz v0, :cond_5

    move v1, v2

    :cond_5
    const-wide v5, 0x7fefffffffffffffL    # Double.MAX_VALUE

    const/4 v0, -0x1

    move v2, v4

    .line 171
    :goto_0
    iget v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->maxSides:I

    add-int/lit8 v8, v1, -0x1

    sub-int/2addr v7, v8

    iget-object v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->polylines:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    iget v8, v8, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    invoke-static {v7, v8}, Ljava/lang/Math;->min(II)I

    move-result v7

    if-ge v2, v7, :cond_7

    .line 172
    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->polylines:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v7, v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->get(I)Ljava/lang/Object;

    move-result-object v7

    check-cast v7, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$CandidatePolyline;

    iget-wide v7, v7, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$CandidatePolyline;->score:D

    cmpg-double v7, v7, v5

    if-gez v7, :cond_6

    .line 173
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->polylines:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v0, v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$CandidatePolyline;

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->bestPolyline:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$CandidatePolyline;

    .line 174
    iget-wide v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$CandidatePolyline;->score:D

    add-int v0, v2, v1

    :cond_6
    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    .line 180
    :cond_7
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->minSides:I

    if-lt v0, v1, :cond_b

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->bestPolyline:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$CandidatePolyline;

    if-nez v1, :cond_8

    goto :goto_2

    :cond_8
    add-int/lit8 v1, v0, -0x1

    move v2, v1

    move v1, v4

    :goto_1
    if-ge v1, v0, :cond_a

    .line 186
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->bestPolyline:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$CandidatePolyline;

    iget-object v5, v5, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$CandidatePolyline;->splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {v5, v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->get(I)I

    move-result v5

    invoke-interface {p1, v5}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v5

    check-cast v5, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 187
    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->bestPolyline:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$CandidatePolyline;

    iget-object v6, v6, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$CandidatePolyline;->splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {v6, v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->get(I)I

    move-result v2

    invoke-interface {p1, v2}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 189
    invoke-virtual {v5, v2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->distance(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;)D

    move-result-wide v5

    .line 190
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->maxSideError:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    invoke-virtual {v2, v5, v6}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->compute(D)D

    move-result-wide v5

    .line 191
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->bestPolyline:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$CandidatePolyline;

    iget-object v2, v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$CandidatePolyline;->sideErrors:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;

    invoke-virtual {v2, v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;->get(I)D

    move-result-wide v7

    mul-double/2addr v5, v5

    cmpl-double v2, v7, v5

    if-ltz v2, :cond_9

    const/4 p1, 0x0

    .line 192
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->bestPolyline:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$CandidatePolyline;

    return v4

    :cond_9
    add-int/lit8 v2, v1, 0x1

    move v9, v2

    move v2, v1

    move v1, v9

    goto :goto_1

    :cond_a
    return v3

    :cond_b
    :goto_2
    return v4
.end method

.method removeCornerAndSavePolyline(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;D)Z
    .locals 1

    .line 563
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->previous(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    move-result-object v0

    .line 567
    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    iput-wide p2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->sideError:D

    .line 568
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;

    invoke-virtual {p2, p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->remove(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;)V

    .line 572
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->savePolyline()Z

    move-result p1

    return p1
.end method

.method savePolyline()Z
    .locals 8

    .line 260
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->loops:Z

    if-eqz v0, :cond_0

    const/4 v0, 0x3

    goto :goto_0

    :cond_0
    const/4 v0, 0x2

    .line 264
    :goto_0
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->size()I

    move-result v1

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->polylines:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    iget v3, v2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    add-int/2addr v3, v0

    const/4 v4, 0x1

    sub-int/2addr v3, v4

    if-gt v1, v3, :cond_2

    .line 265
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->size()I

    move-result v1

    sub-int/2addr v1, v0

    invoke-virtual {v2, v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$CandidatePolyline;

    .line 267
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$CandidatePolyline;->splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    iget v1, v1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;

    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->size()I

    move-result v2

    if-ne v1, v2, :cond_1

    goto :goto_1

    .line 268
    :cond_1
    new-instance v0, Ljava/lang/RuntimeException;

    const-string v1, "Egads saved polylines aren\'t in the expected order"

    invoke-direct {v0, v1}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 270
    :cond_2
    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->grow()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$CandidatePolyline;

    .line 271
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$CandidatePolyline;->reset()V

    const-wide v1, 0x7fefffffffffffffL    # Double.MAX_VALUE

    .line 272
    iput-wide v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$CandidatePolyline;->score:D

    .line 275
    :goto_1
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;

    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->cornerScorePenalty:D

    iget-boolean v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->loops:Z

    invoke-static {v1, v2, v3, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->computeScore(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;DZ)D

    move-result-wide v1

    .line 278
    iget-wide v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$CandidatePolyline;->score:D

    cmpl-double v3, v5, v1

    if-lez v3, :cond_4

    .line 279
    iput-wide v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$CandidatePolyline;->score:D

    .line 280
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$CandidatePolyline;->splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    .line 281
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$CandidatePolyline;->sideErrors:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;

    .line 282
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->getHead()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    move-result-object v1

    const-wide/16 v2, 0x0

    :goto_2
    if-eqz v1, :cond_3

    .line 285
    iget-object v5, v1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    check-cast v5, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    iget-wide v5, v5, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->sideError:D

    invoke-static {v2, v3, v5, v6}, Ljava/lang/Math;->max(DD)D

    move-result-wide v2

    .line 286
    iget-object v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$CandidatePolyline;->splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    iget-object v6, v1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    check-cast v6, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    iget v6, v6, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->index:I

    invoke-virtual {v5, v6}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->add(I)V

    .line 287
    iget-object v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$CandidatePolyline;->sideErrors:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;

    iget-object v6, v1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    check-cast v6, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    iget-wide v6, v6, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->sideError:D

    invoke-virtual {v5, v6, v7}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;->add(D)V

    .line 288
    iget-object v1, v1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->next:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    goto :goto_2

    .line 290
    :cond_3
    iput-wide v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$CandidatePolyline;->maxSideError:D

    return v4

    :cond_4
    const/4 v0, 0x0

    return v0
.end method

.method selectCornerToRemove(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$ErrorValue;Z)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;
    .locals 10

    .line 517
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->size()I

    move-result v0

    const/4 v1, 0x3

    const/4 v2, 0x0

    if-gt v0, v1, :cond_0

    return-object v2

    :cond_0
    if-eqz p3, :cond_1

    .line 525
    iget-object p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;

    invoke-virtual {p3}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->getHead()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    move-result-object p3

    move-object v0, v2

    goto :goto_0

    .line 528
    :cond_1
    iget-object p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;

    invoke-virtual {p3}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->getHead()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    move-result-object p3

    iget-object p3, p3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->next:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    .line 529
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->getTail()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    move-result-object v0

    :goto_0
    const-wide v3, -0x10000000000001L

    :goto_1
    if-eq p3, v0, :cond_3

    .line 536
    invoke-virtual {p0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->previous(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    move-result-object v1

    .line 537
    invoke-virtual {p0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->next(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    move-result-object v5

    .line 540
    iget-object v1, v1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    move-object v6, v1

    check-cast v6, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    iget-wide v6, v6, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->sideError:D

    iget-object v8, p3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    check-cast v8, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    iget-wide v8, v8, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->sideError:D

    add-double/2addr v6, v8

    const-wide/high16 v8, 0x4000000000000000L    # 2.0

    div-double/2addr v6, v8

    iget-wide v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->cornerScorePenalty:D

    add-double/2addr v6, v8

    .line 541
    check-cast v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    iget v1, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->index:I

    iget-object v5, v5, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    check-cast v5, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    iget v5, v5, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->index:I

    invoke-virtual {p0, p1, v1, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->computeSideError(Ljava/util/List;II)D

    move-result-wide v8

    sub-double/2addr v6, v8

    cmpl-double v1, v6, v3

    if-lez v1, :cond_2

    .line 546
    iput-wide v8, p2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$ErrorValue;->value:D

    move-object v2, p3

    move-wide v3, v6

    .line 548
    :cond_2
    iget-object p3, p3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->next:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    goto :goto_1

    .line 551
    :cond_3
    invoke-static {v2}, Ljava/util/Objects;->requireNonNull(Ljava/lang/Object;)Ljava/lang/Object;

    return-object v2
.end method

.method selectCornerToSplit(Z)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;
    .locals 11

    .line 482
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->convex:Z

    const-wide/16 v1, 0x0

    if-eqz v0, :cond_0

    move-wide v3, v1

    goto :goto_0

    :cond_0
    const-wide v3, -0x10000000000001L

    .line 485
    :goto_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->getHead()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    move-result-object v0

    const/4 v5, 0x0

    if-eqz p1, :cond_1

    move-object p1, v5

    goto :goto_1

    .line 486
    :cond_1
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->getTail()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    move-result-object p1

    :goto_1
    if-eq v0, p1, :cond_5

    .line 489
    iget-object v6, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    check-cast v6, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    .line 490
    iget-boolean v7, v6, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->splitable:Z

    if-nez v7, :cond_2

    .line 491
    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->next:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    goto :goto_1

    .line 496
    :cond_2
    iget-wide v7, v6, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->sideError:D

    const-wide/high16 v9, 0x4000000000000000L    # 2.0

    mul-double/2addr v7, v9

    iget-wide v9, v6, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->splitError0:D

    sub-double/2addr v7, v9

    iget-wide v9, v6, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->splitError1:D

    sub-double/2addr v7, v9

    cmpg-double v6, v7, v1

    if-gez v6, :cond_3

    neg-double v7, v7

    :cond_3
    cmpl-double v6, v7, v3

    if-lez v6, :cond_4

    move-object v5, v0

    move-wide v3, v7

    .line 505
    :cond_4
    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->next:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    goto :goto_1

    :cond_5
    return-object v5
.end method

.method public setConvex(Z)V
    .locals 0

    .line 78
    iput-boolean p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->convex:Z

    return-void
.end method

.method public setConvexTest(D)V
    .locals 0

    .line 107
    iput-wide p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->convexTest:D

    return-void
.end method

.method public setCornerScorePenalty(D)V
    .locals 0

    .line 92
    iput-wide p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->cornerScorePenalty:D

    return-void
.end method

.method public setExtraConsider(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;)V
    .locals 1

    .line 901
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->extraConsider:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->setTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    return-void
.end method

.method public setLoops(Z)V
    .locals 0

    .line 75
    iput-boolean p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->loops:Z

    return-void
.end method

.method public setMaxNumberOfSideSamples(I)V
    .locals 0

    .line 101
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->maxNumberOfSideSamples:I

    return-void
.end method

.method public setMaxSideError(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;)V
    .locals 1

    .line 905
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->maxSideError:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->setTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    return-void
.end method

.method public setMaxSides(I)V
    .locals 0

    .line 81
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->maxSides:I

    return-void
.end method

.method public setMinSides(I)V
    .locals 0

    .line 83
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->minSides:I

    return-void
.end method

.method public setMinimumSideLength(I)V
    .locals 1

    if-lez p1, :cond_0

    .line 897
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->minimumSideLength:I

    return-void

    .line 896
    :cond_0
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string v0, "Minimum length must be at least 1"

    invoke-direct {p1, v0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method setSplitVariables(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;)V
    .locals 4

    .line 691
    iget-object v0, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    iget v0, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->index:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->minimumSideLength:I

    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v2

    invoke-static {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/CircularIndex;->plusPOffset(III)I

    move-result v0

    .line 692
    iget-object v1, p3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    check-cast v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    iget v1, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->index:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->minimumSideLength:I

    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v3

    invoke-static {v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/CircularIndex;->minusPOffset(III)I

    move-result v1

    .line 694
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->splitter:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitSelector;

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->resultsA:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;

    invoke-interface {v2, p1, v0, v1, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitSelector;->selectSplitPoint(Ljava/util/List;IILcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;)V

    .line 697
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->convex:Z

    if-eqz v0, :cond_0

    .line 698
    iget-object v0, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    iget v0, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->index:I

    invoke-interface {p1, v0}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 699
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->resultsA:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;

    iget v1, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;->index:I

    invoke-interface {p1, v1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 700
    invoke-virtual {p0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->next(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    move-result-object v2

    iget-object v2, v2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    check-cast v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    iget v2, v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->index:I

    invoke-interface {p1, v2}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 702
    invoke-static {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/georegression/geometry/UtilPolygons2D_I32;->isPositiveZ(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 703
    iget-object p1, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    const/4 p2, 0x0

    iput-boolean p2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->splitable:Z

    return-void

    .line 709
    :cond_0
    iget-object v0, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    iget v0, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->index:I

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->resultsA:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;

    iget v1, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;->index:I

    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v2

    invoke-static {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/CircularIndex;->distanceP(III)I

    move-result v0

    .line 710
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->minimumSideLength:I

    if-lt v0, v1, :cond_2

    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v1

    sub-int/2addr v1, v0

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->minimumSideLength:I

    if-lt v1, v0, :cond_2

    .line 715
    iget-object v0, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    move-object v1, v0

    check-cast v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->resultsA:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;

    iget v2, v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;->index:I

    iput v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->splitLocation:I

    .line 716
    move-object v1, v0

    check-cast v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    iget v0, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->index:I

    invoke-virtual {p0, p1, v0, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->computeSideError(Ljava/util/List;II)D

    move-result-wide v2

    iput-wide v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->splitError0:D

    .line 717
    iget-object v0, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->resultsA:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;

    iget v1, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$SplitResults;->index:I

    iget-object p3, p3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    check-cast p3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    iget p3, p3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->index:I

    invoke-virtual {p0, p1, v1, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->computeSideError(Ljava/util/List;II)D

    move-result-wide v1

    iput-wide v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->splitError1:D

    .line 719
    iget-object p2, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    check-cast p2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;

    iget p2, p2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->splitLocation:I

    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result p1

    if-ge p2, p1, :cond_1

    return-void

    .line 720
    :cond_1
    new-instance p1, Ljava/lang/RuntimeException;

    const-string p2, "Egads"

    invoke-direct {p1, p2}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw p1

    .line 711
    :cond_2
    new-instance p1, Ljava/lang/RuntimeException;

    const-string p2, "Should be impossible"

    invoke-direct {p1, p2}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public setThresholdSideSplitScore(D)V
    .locals 0

    .line 95
    iput-wide p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;->thresholdSideSplitScore:D

    return-void
.end method
