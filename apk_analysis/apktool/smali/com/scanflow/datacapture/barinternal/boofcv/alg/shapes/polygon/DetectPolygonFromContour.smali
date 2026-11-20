.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;
.super Ljava/lang/Object;
.source "DetectPolygonFromContour.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$Info;
    }
.end annotation


# instance fields
.field private final borderCorners:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;

.field private canTouchBorder:Z

.field private contourEdgeIntensity:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;

.field contourEdgeThreshold:D

.field private contourFinder:Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinder;

.field private contourPadded:Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourInterface$Padded;

.field private final contourTmp:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

.field private contourToPolyline:Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/PointsToPolyline;

.field protected distortedPoint:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;

.field foundInfo:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

.field imageHeight:I

.field imageWidth:I

.field private inputType:Ljava/lang/Class;

.field milliContour:Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;

.field milliShapes:Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;

.field private minimumArea:D

.field private minimumContourPixels:I

.field private outputClockwiseUpY:Z

.field private final polygonDistorted:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

.field polygonPixel:Ljava/util/List;

.field private polygonWork:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

.field private final splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

.field private final undistorted:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

.field verbose:Ljava/io/PrintStream;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/PointsToPolyline;ZZDDLcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinder;Ljava/lang/Class;)V
    .locals 3

    .line 157
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 89
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    .line 95
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$$ExternalSyntheticLambda0;

    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$$ExternalSyntheticLambda0;-><init>()V

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;-><init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/Factory;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->foundInfo:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 101
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->polygonWork:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    .line 102
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->polygonDistorted:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    .line 114
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->distortedPoint:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;

    .line 123
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$$ExternalSyntheticLambda1;

    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$$ExternalSyntheticLambda1;-><init>()V

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;-><init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/Factory;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->undistorted:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 129
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->borderCorners:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;

    .line 132
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$$ExternalSyntheticLambda1;

    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$$ExternalSyntheticLambda1;-><init>()V

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;-><init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/Factory;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->contourTmp:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 133
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->polygonPixel:Ljava/util/List;

    .line 136
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;

    const-wide v1, 0x3fe999999999999aL    # 0.8

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;-><init>(D)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->milliContour:Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;

    .line 137
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;-><init>(D)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->milliShapes:Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;

    const/4 v0, 0x0

    .line 140
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->verbose:Ljava/io/PrintStream;

    .line 158
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->contourToPolyline:Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/PointsToPolyline;

    .line 159
    iput-boolean p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->outputClockwiseUpY:Z

    .line 160
    iput-boolean p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->canTouchBorder:Z

    .line 161
    iput-wide p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->contourEdgeThreshold:D

    .line 162
    iput-object p8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->contourFinder:Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinder;

    .line 163
    iput-object p9, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->inputType:Ljava/lang/Class;

    .line 165
    instance-of p2, p8, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourInterface$Padded;

    if-eqz p2, :cond_0

    .line 166
    check-cast p8, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourInterface$Padded;

    iput-object p8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->contourPadded:Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourInterface$Padded;

    .line 169
    :cond_0
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/PointsToPolyline;->isLoop()Z

    move-result p1

    if-eqz p1, :cond_2

    const-wide/16 p1, 0x0

    cmpl-double p1, p4, p1

    if-lez p1, :cond_1

    .line 173
    new-instance p2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;

    const/16 p3, 0x1e

    const/4 p4, 0x1

    move-wide p5, p6

    move-object p7, p9

    invoke-direct/range {p2 .. p7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;-><init>(IIDLjava/lang/Class;)V

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->contourEdgeIntensity:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;

    .line 176
    :cond_1
    new-instance p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    const/4 p2, 0x1

    invoke-direct {p1, p2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;-><init>(I)V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->polygonWork:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    return-void

    .line 170
    :cond_2
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string p2, "ContourToPolygon must be configured for loops"

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method private configure(II)V
    .locals 2

    .line 271
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->imageWidth:I

    .line 272
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->imageHeight:I

    .line 275
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->contourFinder:Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinder;

    const/4 v1, 0x0

    invoke-interface {v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourInterface;->getMinContour(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    move-result-object v0

    mul-int/2addr p1, p2

    int-to-double p1, p1

    invoke-static {p1, p2}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide p1

    invoke-virtual {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->computeNegMaxI(D)I

    move-result p1

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->minimumContourPixels:I

    const/4 p2, 0x4

    .line 276
    invoke-static {p2, p1}, Ljava/lang/Math;->max(II)I

    move-result p1

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->minimumContourPixels:I

    int-to-double p1, p1

    const-wide/high16 v0, 0x4010000000000000L    # 4.0

    div-double/2addr p1, v0

    const-wide/high16 v0, 0x4000000000000000L    # 2.0

    .line 277
    invoke-static {p1, p2, v0, v1}, Ljava/lang/Math;->pow(DD)D

    move-result-wide p1

    iput-wide p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->minimumArea:D

    return-void
.end method

.method private findCandidateShapes()V
    .locals 18

    move-object/from16 v0, p0

    .line 289
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->contourFinder:Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinder;

    invoke-interface {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourInterface;->getContours()Ljava/util/List;

    move-result-object v1

    const/4 v2, 0x0

    move v3, v2

    .line 290
    :goto_0
    invoke-interface {v1}, Ljava/util/List;->size()I

    move-result v4

    if-ge v3, v4, :cond_d

    .line 291
    invoke-interface {v1, v3}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourPacked;

    .line 293
    iget-object v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->contourTmp:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v5}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 294
    iget-object v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->contourFinder:Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinder;

    iget v6, v4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourPacked;->externalIndex:I

    iget-object v7, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->contourTmp:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-interface {v5, v6, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourInterface;->loadContour(ILcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;)V

    .line 295
    iget-object v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->contourTmp:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    iget v6, v5, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    iget v7, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->minimumContourPixels:I

    if-ge v6, v7, :cond_0

    goto/16 :goto_4

    .line 300
    :cond_0
    invoke-virtual {v5}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->toList()Ljava/util/List;

    move-result-object v5

    invoke-virtual {v0, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->touchesBorder(Ljava/util/List;)Z

    move-result v5

    .line 301
    iget-boolean v6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->canTouchBorder:Z

    if-nez v6, :cond_1

    if-eqz v5, :cond_1

    .line 302
    iget-object v4, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->verbose:Ljava/io/PrintStream;

    if-eqz v4, :cond_c

    const-string v5, "rejected polygon, touched border"

    invoke-virtual {v4, v5}, Ljava/io/PrintStream;->println(Ljava/lang/String;)V

    goto/16 :goto_4

    .line 311
    :cond_1
    iget-object v6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->contourEdgeIntensity:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;

    const/4 v7, 0x1

    if-eqz v6, :cond_2

    .line 312
    iget-object v8, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->contourTmp:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v8}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->toList()Ljava/util/List;

    move-result-object v8

    invoke-virtual {v6, v8, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;->process(Ljava/util/List;Z)V

    .line 313
    iget-object v6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->contourEdgeIntensity:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;

    invoke-virtual {v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;->getEdgeInsideAverage()F

    move-result v6

    .line 314
    iget-object v8, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->contourEdgeIntensity:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;

    invoke-virtual {v8}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;->getEdgeOutsideAverage()F

    move-result v8

    sub-float v9, v8, v6

    .line 317
    invoke-static {v9}, Ljava/lang/Math;->abs(F)F

    move-result v9

    float-to-double v9, v9

    iget-wide v11, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->contourEdgeThreshold:D

    cmpg-double v9, v9, v11

    if-gez v9, :cond_3

    .line 318
    iget-object v4, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->verbose:Ljava/io/PrintStream;

    if-eqz v4, :cond_c

    const-string v5, "rejected polygon. contour edge intensity"

    invoke-virtual {v4, v5}, Ljava/io/PrintStream;->println(Ljava/lang/String;)V

    goto/16 :goto_4

    :cond_2
    const/high16 v6, -0x40800000    # -1.0f

    move v8, v6

    .line 332
    :cond_3
    iget-object v9, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->contourTmp:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v9}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->toList()Ljava/util/List;

    move-result-object v9

    .line 340
    iget-object v10, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->contourToPolyline:Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/PointsToPolyline;

    iget-object v11, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-interface {v10, v9, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/PointsToPolyline;->process(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)Z

    move-result v10

    if-nez v10, :cond_4

    .line 341
    iget-object v4, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->verbose:Ljava/io/PrintStream;

    if-eqz v4, :cond_c

    .line 342
    iget-object v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->contourTmp:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v5}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size()I

    move-result v5

    new-instance v6, Ljava/lang/StringBuilder;

    invoke-direct {v6}, Ljava/lang/StringBuilder;-><init>()V

    const-string v7, "rejected polygon initial fit failed. contour size = "

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v6, v5}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v6}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v4, v5}, Ljava/io/PrintStream;->println(Ljava/lang/String;)V

    goto/16 :goto_4

    .line 347
    :cond_4
    iget-object v10, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->polygonPixel:Ljava/util/List;

    invoke-interface {v10}, Ljava/util/List;->clear()V

    move v10, v2

    .line 348
    :goto_1
    iget-object v11, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    iget v12, v11, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    if-ge v10, v12, :cond_5

    .line 349
    iget-object v12, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->polygonPixel:Ljava/util/List;

    invoke-virtual {v11, v10}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->get(I)I

    move-result v11

    invoke-interface {v9, v11}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v11

    check-cast v11, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    invoke-interface {v12, v11}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    add-int/lit8 v10, v10, 0x1

    goto :goto_1

    .line 353
    :cond_5
    iget-object v10, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->polygonPixel:Ljava/util/List;

    invoke-static {v10}, Lcom/scanflow/datacapture/barinternal/georegression/geometry/UtilPolygons2D_I32;->isCCW(Ljava/util/List;)Z

    move-result v10

    .line 357
    iget-object v11, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->contourEdgeIntensity:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;

    if-eqz v11, :cond_7

    if-nez v10, :cond_6

    move/from16 v17, v8

    move v8, v6

    move/from16 v6, v17

    :cond_6
    cmpl-float v11, v6, v8

    if-lez v11, :cond_7

    .line 366
    iget-object v4, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->verbose:Ljava/io/PrintStream;

    if-eqz v4, :cond_c

    const-string v5, "White blob. Rejected"

    invoke-virtual {v4, v5}, Ljava/io/PrintStream;->println(Ljava/lang/String;)V

    goto/16 :goto_4

    .line 372
    :cond_7
    iget-boolean v11, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->outputClockwiseUpY:Z

    if-ne v11, v10, :cond_8

    .line 373
    iget-object v10, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    iget-object v11, v10, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->data:[I

    iget v10, v10, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    invoke-static {v11, v10}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->flip([II)V

    .line 377
    :cond_8
    iget-object v10, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->polygonWork:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    iget-object v10, v10, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->vertexes:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    iget-object v11, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {v11}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size()I

    move-result v11

    invoke-virtual {v10, v11}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->resize(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 378
    iget-object v10, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->polygonDistorted:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    iget-object v10, v10, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->vertexes:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    iget-object v11, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {v11}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size()I

    move-result v11

    invoke-virtual {v10, v11}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->resize(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    move v10, v2

    .line 379
    :goto_2
    iget-object v11, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {v11}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size()I

    move-result v11

    if-ge v10, v11, :cond_9

    .line 380
    iget-object v11, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {v11, v10}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->get(I)I

    move-result v11

    invoke-interface {v9, v11}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v11

    check-cast v11, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 381
    iget-object v12, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->contourTmp:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    iget-object v13, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {v13, v10}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->get(I)I

    move-result v13

    invoke-virtual {v12, v13}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->get(I)Ljava/lang/Object;

    move-result-object v12

    check-cast v12, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 382
    iget-object v13, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->polygonWork:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v13, v10}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v13

    iget v14, v11, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    int-to-double v14, v14

    iget v11, v11, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    move/from16 v16, v8

    int-to-double v7, v11

    invoke-virtual {v13, v14, v15, v7, v8}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->setTo(DD)Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;

    .line 383
    iget-object v7, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->polygonDistorted:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v7, v10}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v7

    iget v8, v12, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    int-to-double v13, v8

    iget v8, v12, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    int-to-double v11, v8

    invoke-virtual {v7, v13, v14, v11, v12}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->setTo(DD)Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;

    add-int/lit8 v10, v10, 0x1

    move/from16 v8, v16

    const/4 v7, 0x1

    goto :goto_2

    :cond_9
    move/from16 v16, v8

    if-eqz v5, :cond_a

    .line 387
    iget-object v7, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->polygonDistorted:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    iget-object v8, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->borderCorners:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;

    invoke-virtual {v0, v7, v8}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->determineCornersOnBorder(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;)V

    goto :goto_3

    .line 389
    :cond_a
    iget-object v7, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->borderCorners:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;

    invoke-virtual {v7, v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;->resize(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;

    .line 400
    :goto_3
    iget-object v7, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->polygonWork:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-static {v7}, Lcom/scanflow/datacapture/barinternal/georegression/metric/Area2D_F64;->polygonSimple(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;)D

    move-result-wide v7

    .line 402
    iget-wide v9, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->minimumArea:D

    cmpg-double v7, v7, v9

    if-gez v7, :cond_b

    .line 403
    iget-object v4, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->verbose:Ljava/io/PrintStream;

    if-eqz v4, :cond_c

    const-string v5, "Rejected area"

    invoke-virtual {v4, v5}, Ljava/io/PrintStream;->println(Ljava/lang/String;)V

    goto :goto_4

    .line 408
    :cond_b
    iget-object v7, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->foundInfo:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v7}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->grow()Ljava/lang/Object;

    move-result-object v7

    check-cast v7, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$Info;

    .line 416
    iget-object v8, v7, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$Info;->splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    iget-object v9, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {v8, v9}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->setTo(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    .line 417
    iput-boolean v5, v7, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$Info;->contourTouchesBorder:Z

    const/4 v5, 0x1

    .line 418
    iput-boolean v5, v7, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$Info;->external:Z

    float-to-double v5, v6

    .line 419
    iput-wide v5, v7, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$Info;->edgeInside:D

    move/from16 v8, v16

    float-to-double v5, v8

    .line 420
    iput-wide v5, v7, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$Info;->edgeOutside:D

    .line 421
    iput-object v4, v7, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$Info;->contour:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourPacked;

    .line 422
    iget-object v4, v7, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$Info;->polygon:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    iget-object v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->polygonWork:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v4, v5}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    .line 423
    iget-object v4, v7, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$Info;->polygonDistorted:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    iget-object v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->polygonDistorted:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v4, v5}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    .line 424
    iget-object v4, v7, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$Info;->borderCorners:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;

    iget-object v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->borderCorners:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;

    invoke-virtual {v4, v5}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;->setTo(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;

    :cond_c
    :goto_4
    add-int/lit8 v3, v3, 0x1

    goto/16 :goto_0

    :cond_d
    return-void
.end method

.method public static flip([II)V
    .locals 5

    .line 430
    div-int/lit8 v0, p1, 0x2

    const/4 v1, 0x1

    :goto_0
    if-gt v1, v0, :cond_0

    sub-int v2, p1, v1

    .line 434
    aget v3, p0, v1

    .line 435
    aget v4, p0, v2

    aput v4, p0, v1

    .line 436
    aput v3, p0, v2

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method


# virtual methods
.method determineCornersOnBorder(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;)V
    .locals 9

    .line 447
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;

    const/4 v0, 0x0

    move v1, v0

    .line 448
    :goto_0
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->size()I

    move-result v2

    if-ge v1, v2, :cond_2

    .line 449
    invoke-virtual {p1, v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v2

    .line 451
    iget-wide v3, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    const-wide/high16 v5, 0x3ff0000000000000L    # 1.0

    cmpg-double v7, v3, v5

    if-lez v7, :cond_1

    iget-wide v7, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    cmpg-double v2, v7, v5

    if-lez v2, :cond_1

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->imageWidth:I

    add-int/lit8 v2, v2, -0x2

    int-to-double v5, v2

    cmpl-double v2, v3, v5

    if-gez v2, :cond_1

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->imageHeight:I

    add-int/lit8 v2, v2, -0x2

    int-to-double v2, v2

    cmpl-double v2, v7, v2

    if-ltz v2, :cond_0

    goto :goto_1

    :cond_0
    move v2, v0

    goto :goto_2

    :cond_1
    :goto_1
    const/4 v2, 0x1

    :goto_2
    invoke-virtual {p2, v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;->add(Z)V

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_2
    return-void
.end method

.method public getContour(Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$Info;)Ljava/util/List;
    .locals 2

    .line 463
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->contourTmp:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 464
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->contourFinder:Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinder;

    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$Info;->contour:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourPacked;

    iget p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourPacked;->externalIndex:I

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->contourTmp:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-interface {v0, p1, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourInterface;->loadContour(ILcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;)V

    .line 465
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->contourTmp:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->toList()Ljava/util/List;

    move-result-object p1

    return-object p1
.end method

.method public getContourFinder()Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinder;
    .locals 1

    .line 83
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->contourFinder:Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinder;

    return-object v0
.end method

.method public getFoundInfo()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;
    .locals 1

    .line 95
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->foundInfo:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    return-object v0
.end method

.method public getInputType()Ljava/lang/Class;
    .locals 1

    .line 126
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->inputType:Ljava/lang/Class;

    return-object v0
.end method

.method public getMilliContour()D
    .locals 2

    .line 571
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->milliContour:Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;->getAverage()D

    move-result-wide v0

    return-wide v0
.end method

.method public getMilliShapes()D
    .locals 2

    .line 575
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->milliShapes:Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;->getAverage()D

    move-result-wide v0

    return-wide v0
.end method

.method public getMinimumSides()I
    .locals 1

    .line 563
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->contourToPolyline:Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/PointsToPolyline;

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/PointsToPolyline;->getMinimumSides()I

    move-result v0

    return v0
.end method

.method public isOutputClockwiseUpY()Z
    .locals 1

    .line 110
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->outputClockwiseUpY:Z

    return v0
.end method

.method public process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
    .locals 6

    .line 220
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->verbose:Ljava/io/PrintStream;

    if-eqz v0, :cond_0

    const-string v1, "ENTER  DetectPolygonFromContour.process()"

    invoke-virtual {v0, v1}, Ljava/io/PrintStream;->println(Ljava/lang/String;)V

    .line 222
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->contourPadded:Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourInterface$Padded;

    if-eqz v0, :cond_2

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourInterface$Padded;->isCreatePaddedCopy()Z

    move-result v0

    if-nez v0, :cond_2

    .line 224
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/lit8 v0, v0, 0x2

    iget v1, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ne v0, v1, :cond_1

    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    add-int/lit8 v0, v0, 0x2

    iget v1, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ne v0, v1, :cond_1

    goto :goto_0

    .line 225
    :cond_1
    new-instance p2, Ljava/lang/IllegalArgumentException;

    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/lit8 v0, v0, 0x2

    iget p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    add-int/lit8 p1, p1, 0x2

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Including padding, expected a binary image with shape "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string v0, "x"

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {p2, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p2

    .line 229
    :cond_2
    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/InputSanityCheck;->checkSameShape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 231
    :goto_0
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->imageWidth:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ne v0, v1, :cond_3

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->imageHeight:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-eq v0, v2, :cond_4

    .line 232
    :cond_3
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-direct {p0, v1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->configure(II)V

    :cond_4
    const/4 v0, 0x0

    .line 235
    :goto_1
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->foundInfo:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    iget v2, v1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    if-ge v0, v2, :cond_5

    .line 236
    invoke-virtual {v1, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->get(I)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$Info;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$Info;->reset()V

    add-int/lit8 v0, v0, 0x1

    goto :goto_1

    .line 238
    :cond_5
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 240
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->contourEdgeIntensity:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;

    if-eqz v0, :cond_6

    .line 241
    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/ContourEdgeIntensity;->setImage(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)V

    .line 243
    :cond_6
    invoke-static {}, Ljava/lang/System;->nanoTime()J

    move-result-wide v0

    .line 246
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->contourFinder:Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinder;

    invoke-interface {p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinder;->process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    .line 248
    invoke-static {}, Ljava/lang/System;->nanoTime()J

    move-result-wide p1

    .line 251
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->findCandidateShapes()V

    .line 253
    invoke-static {}, Ljava/lang/System;->nanoTime()J

    move-result-wide v2

    sub-long v0, p1, v0

    long-to-double v0, v0

    const-wide v4, 0x3eb0c6f7a0b5ed8dL    # 1.0E-6

    mul-double/2addr v0, v4

    sub-long/2addr v2, p1

    long-to-double p1, v2

    mul-double/2addr p1, v4

    .line 258
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->milliContour:Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;

    invoke-virtual {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;->update(D)D

    .line 259
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->milliShapes:Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;

    invoke-virtual {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;->update(D)D

    .line 261
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->verbose:Ljava/io/PrintStream;

    if-eqz p1, :cond_7

    const-string p2, "EXIT  DetectPolygonFromContour.process()"

    invoke-virtual {p1, p2}, Ljava/io/PrintStream;->println(Ljava/lang/String;)V

    :cond_7
    return-void
.end method

.method public setConvex(Z)V
    .locals 1

    .line 547
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->contourToPolyline:Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/PointsToPolyline;

    invoke-interface {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/PointsToPolyline;->setConvex(Z)V

    return-void
.end method

.method public setNumberOfSides(II)V
    .locals 1

    const/4 v0, 0x3

    if-lt p1, v0, :cond_1

    if-lt p2, p1, :cond_0

    .line 558
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->contourToPolyline:Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/PointsToPolyline;

    invoke-interface {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/PointsToPolyline;->setMinimumSides(I)V

    .line 559
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->contourToPolyline:Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/PointsToPolyline;

    invoke-interface {p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/PointsToPolyline;->setMaximumSides(I)V

    return-void

    .line 556
    :cond_0
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string p2, "The max must be >= the min"

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1

    .line 554
    :cond_1
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string p2, "The min must be >= 3"

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public setOutputClockwiseUpY(Z)V
    .locals 0

    .line 110
    iput-boolean p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->outputClockwiseUpY:Z

    return-void
.end method

.method protected final touchesBorder(Ljava/util/List;)Z
    .locals 7

    .line 525
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->imageWidth:I

    const/4 v1, 0x1

    sub-int/2addr v0, v1

    .line 526
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->imageHeight:I

    sub-int/2addr v2, v1

    const/4 v3, 0x0

    move v4, v3

    .line 528
    :goto_0
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v5

    if-ge v4, v5, :cond_2

    .line 529
    invoke-interface {p1, v4}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v5

    check-cast v5, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 530
    iget v6, v5, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    if-eqz v6, :cond_1

    iget v5, v5, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    if-eqz v5, :cond_1

    if-eq v6, v0, :cond_1

    if-ne v5, v2, :cond_0

    goto :goto_1

    :cond_0
    add-int/lit8 v4, v4, 0x1

    goto :goto_0

    :cond_1
    :goto_1
    return v1

    :cond_2
    return v3
.end method
