.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;
.super Ljava/lang/Object;
.source "FitLinesToContour.java"


# instance fields
.field anchor0:I

.field anchor1:I

.field contour:Ljava/util/List;

.field private final intersection:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

.field private final linePolar:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;

.field lines:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

.field maxIterations:I

.field maxSamples:I

.field minimumLineLength:I

.field pointsFit:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

.field skippedCorners:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

.field verbose:Z

.field private final workCorners:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;


# direct methods
.method public constructor <init>()V
    .locals 2

    .line 48
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const/16 v0, 0x14

    .line 52
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->maxSamples:I

    const/4 v0, 0x5

    .line 55
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->maxIterations:I

    const/4 v0, 0x4

    .line 58
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->minimumLineLength:I

    .line 64
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToContour$$ExternalSyntheticLambda0;

    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToContour$$ExternalSyntheticLambda0;-><init>()V

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;-><init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/Factory;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->lines:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 65
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel$$ExternalSyntheticLambda2;

    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel$$ExternalSyntheticLambda2;-><init>()V

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;-><init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/Factory;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->pointsFit:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 67
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->linePolar:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;

    .line 69
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->intersection:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    .line 71
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->workCorners:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    const/4 v0, 0x0

    .line 76
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->verbose:Z

    .line 173
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->skippedCorners:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    return-void
.end method


# virtual methods
.method closestPoint(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)I
    .locals 13

    const-wide v0, 0x7fefffffffffffffL    # Double.MAX_VALUE

    const/4 v2, -0x1

    const/4 v3, 0x0

    .line 344
    :goto_0
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->contour:Ljava/util/List;

    invoke-interface {v4}, Ljava/util/List;->size()I

    move-result v4

    if-ge v3, v4, :cond_1

    .line 345
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->contour:Ljava/util/List;

    invoke-interface {v4, v3}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 347
    iget-wide v5, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    iget-wide v7, p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    iget v9, v4, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    int-to-double v9, v9

    iget v4, v4, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    int-to-double v11, v4

    invoke-static/range {v5 .. v12}, Lcom/scanflow/datacapture/barinternal/georegression/geometry/UtilPoint2D_F64;->distanceSq(DDDD)D

    move-result-wide v4

    cmpg-double v6, v4, v0

    if-gez v6, :cond_0

    move v2, v3

    move-wide v0, v4

    :cond_0
    add-int/lit8 v3, v3, 0x1

    goto :goto_0

    :cond_1
    return v2
.end method

.method public fitAnchored(IILcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)Z
    .locals 2

    .line 93
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->anchor0:I

    .line 94
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->anchor1:I

    if-ne p1, p2, :cond_0

    .line 96
    invoke-virtual {p3}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size()I

    move-result p1

    goto :goto_0

    :cond_0
    iget v0, p3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    invoke-static {p1, p2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/CircularIndex;->distanceP(III)I

    move-result p1

    :goto_0
    const/4 p2, 0x2

    if-lt p1, p2, :cond_7

    .line 101
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->lines:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {p2, p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->resize(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 103
    iget-boolean p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->verbose:Z

    if-eqz p2, :cond_1

    sget-object p2, Ljava/lang/System;->out:Ljava/io/PrintStream;

    const-string v0, "ENTER FitLinesToContour"

    invoke-virtual {p2, v0}, Ljava/io/PrintStream;->println(Ljava/lang/String;)V

    .line 108
    :cond_1
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->workCorners:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {p2, p3}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->setTo(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    const/4 p2, 0x0

    move v0, p2

    .line 110
    :goto_1
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->maxIterations:I

    if-ge v0, v1, :cond_5

    .line 112
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->workCorners:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {p0, p1, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->fitLinesUsingCorners(ILcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)Z

    move-result v1

    if-nez v1, :cond_2

    return p2

    .line 117
    :cond_2
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->workCorners:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {p0, p1, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->linesIntoCorners(ILcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)Z

    move-result v1

    if-nez v1, :cond_3

    return p2

    .line 122
    :cond_3
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->workCorners:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {p0, p1, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->sanityCheckCornerOrder(ILcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)Z

    move-result v1

    if-nez v1, :cond_4

    return p2

    :cond_4
    add-int/lit8 v0, v0, 0x1

    goto :goto_1

    .line 129
    :cond_5
    iget-boolean p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->verbose:Z

    if-eqz p1, :cond_6

    sget-object p1, Ljava/lang/System;->out:Ljava/io/PrintStream;

    invoke-virtual {p3}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size()I

    move-result p2

    iget-object p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->workCorners:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {p3}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size()I

    move-result p3

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "EXIT FitLinesToContour. "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, p2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p2, "  "

    invoke-virtual {v0, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, p3}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p2

    invoke-virtual {p1, p2}, Ljava/io/PrintStream;->println(Ljava/lang/String;)V

    .line 130
    :cond_6
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->workCorners:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {p4, p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->setTo(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    const/4 p1, 0x1

    return p1

    .line 98
    :cond_7
    new-instance p1, Ljava/lang/RuntimeException;

    const-string p2, "The one line is anchored and can\'t be optimized"

    invoke-direct {p1, p2}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method fitLine(IILcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;)Z
    .locals 19

    move-object/from16 v0, p0

    move/from16 v1, p1

    move/from16 v2, p2

    move-object/from16 v3, p3

    .line 298
    iget-object v4, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->contour:Ljava/util/List;

    invoke-interface {v4}, Ljava/util/List;->size()I

    move-result v4

    invoke-static {v1, v2, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/CircularIndex;->distanceP(III)I

    move-result v4

    .line 301
    iget v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->minimumLineLength:I

    const/4 v6, 0x0

    if-ge v4, v5, :cond_0

    return v6

    .line 304
    :cond_0
    iget-object v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->contour:Ljava/util/List;

    invoke-interface {v5, v1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v5

    check-cast v5, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 305
    iget-object v7, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->contour:Ljava/util/List;

    invoke-interface {v7, v2}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 307
    invoke-virtual {v5, v2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->distance(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;)D

    move-result-wide v7

    .line 308
    iget v9, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    iget v10, v5, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    add-int/2addr v9, v10

    int-to-double v9, v9

    const-wide/high16 v11, 0x4000000000000000L    # 2.0

    div-double/2addr v9, v11

    .line 309
    iget v2, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    iget v5, v5, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    add-int/2addr v2, v5

    int-to-double v13, v2

    div-double/2addr v13, v11

    .line 311
    iget v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->maxSamples:I

    invoke-static {v2, v4}, Ljava/lang/Math;->min(II)I

    move-result v2

    .line 313
    iget-object v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->pointsFit:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v5}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    move v5, v6

    :goto_0
    const/4 v11, 0x1

    if-ge v5, v2, :cond_1

    add-int/lit8 v11, v4, -0x1

    mul-int/2addr v11, v5

    add-int/lit8 v12, v2, -0x1

    .line 316
    div-int/2addr v11, v12

    .line 318
    iget-object v12, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->contour:Ljava/util/List;

    invoke-interface {v12}, Ljava/util/List;->size()I

    move-result v15

    invoke-static {v1, v11, v15}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/CircularIndex;->addOffset(III)I

    move-result v11

    invoke-interface {v12, v11}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v11

    check-cast v11, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 320
    iget-object v12, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->pointsFit:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v12}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->grow()Ljava/lang/Object;

    move-result-object v12

    check-cast v12, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    .line 321
    iget v15, v11, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    move/from16 v16, v6

    move-wide/from16 v17, v7

    int-to-double v6, v15

    sub-double/2addr v6, v9

    div-double v6, v6, v17

    iput-wide v6, v12, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    .line 322
    iget v6, v11, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    int-to-double v6, v6

    sub-double/2addr v6, v13

    div-double v6, v6, v17

    iput-wide v6, v12, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    add-int/lit8 v5, v5, 0x1

    move/from16 v6, v16

    move-wide/from16 v7, v17

    goto :goto_0

    :cond_1
    move/from16 v16, v6

    move-wide/from16 v17, v7

    .line 325
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->pointsFit:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->toList()Ljava/util/List;

    move-result-object v1

    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->linePolar:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;

    invoke-static {v1, v2}, Lcom/scanflow/datacapture/barinternal/georegression/fitting/line/FitLine_F64;->polar(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;

    move-result-object v1

    if-nez v1, :cond_2

    return v16

    .line 328
    :cond_2
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->linePolar:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;

    invoke-static {v1, v3}, Lcom/scanflow/datacapture/barinternal/georegression/geometry/UtilLine2D_F64;->convert(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    .line 331
    iget-wide v1, v3, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->C:D

    mul-double v7, v17, v1

    iget-wide v1, v3, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->A:D

    mul-double/2addr v9, v1

    sub-double/2addr v7, v9

    iget-wide v1, v3, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->B:D

    mul-double/2addr v13, v1

    sub-double/2addr v7, v13

    iput-wide v7, v3, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->C:D

    return v11
.end method

.method fitLinesUsingCorners(ILcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)Z
    .locals 7

    const/4 v0, 0x1

    move v1, v0

    :goto_0
    if-gt v1, p1, :cond_3

    .line 271
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->anchor0:I

    add-int/lit8 v3, v1, -0x1

    iget v4, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    invoke-static {v2, v3, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/CircularIndex;->addOffset(III)I

    move-result v2

    invoke-virtual {p2, v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->get(I)I

    move-result v2

    .line 272
    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->anchor0:I

    iget v5, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    invoke-static {v4, v1, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/CircularIndex;->addOffset(III)I

    move-result v4

    invoke-virtual {p2, v4}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->get(I)I

    move-result v4

    const/4 v5, 0x0

    if-ne v2, v4, :cond_0

    return v5

    .line 277
    :cond_0
    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->lines:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v6, v3}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->get(I)Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    invoke-virtual {p0, v2, v4, v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->fitLine(IILcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;)Z

    move-result v2

    if-nez v2, :cond_1

    return v5

    .line 281
    :cond_1
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->lines:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v2, v3}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->get(I)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    .line 282
    iget-wide v3, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->A:D

    invoke-static {v3, v4}, Ljava/lang/Double;->isNaN(D)Z

    move-result v3

    if-nez v3, :cond_2

    iget-wide v3, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->B:D

    invoke-static {v3, v4}, Ljava/lang/Double;->isNaN(D)Z

    move-result v3

    if-nez v3, :cond_2

    iget-wide v2, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;->C:D

    invoke-static {v2, v3}, Ljava/lang/Double;->isNaN(D)Z

    move-result v2

    if-nez v2, :cond_2

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    .line 283
    :cond_2
    new-instance p1, Ljava/lang/RuntimeException;

    const-string p2, "This should be impossible"

    invoke-direct {p1, p2}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw p1

    :cond_3
    return v0
.end method

.method linesIntoCorners(ILcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)Z
    .locals 10

    .line 180
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->skippedCorners:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    .line 184
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->anchor0:I

    invoke-virtual {p2, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->get(I)I

    move-result v0

    const/4 v1, 0x1

    move v2, v1

    :goto_0
    const/4 v3, 0x0

    if-ge v2, p1, :cond_5

    .line 186
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->lines:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    add-int/lit8 v5, v2, -0x1

    invoke-virtual {v4, v5}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->get(I)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    .line 187
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->lines:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v5, v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->get(I)Ljava/lang/Object;

    move-result-object v5

    check-cast v5, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    .line 189
    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->anchor0:I

    iget v7, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    invoke-static {v6, v2, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/CircularIndex;->addOffset(III)I

    move-result v6

    .line 194
    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->intersection:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-static {v4, v5, v7}, Lcom/scanflow/datacapture/barinternal/georegression/metric/Intersection2D_F64;->intersection(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v4

    if-nez v4, :cond_1

    .line 195
    iget-boolean v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->verbose:Z

    if-eqz v3, :cond_0

    sget-object v3, Ljava/lang/System;->out:Ljava/io/PrintStream;

    const-string v4, "  SKIPPING no intersection"

    invoke-virtual {v3, v4}, Ljava/io/PrintStream;->println(Ljava/lang/String;)V

    :cond_0
    :goto_1
    move v3, v1

    goto :goto_2

    .line 200
    :cond_1
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->intersection:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-virtual {p0, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->closestPoint(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)I

    move-result v4

    if-eq v4, v0, :cond_3

    .line 203
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->contour:Ljava/util/List;

    invoke-interface {v5, v0}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v5

    check-cast v5, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 204
    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->contour:Ljava/util/List;

    invoke-interface {v7, v4}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v7

    check-cast v7, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 206
    iget v8, v5, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    iget v9, v7, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    if-ne v8, v9, :cond_2

    iget v5, v5, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    iget v7, v7, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    if-ne v5, v7, :cond_2

    .line 207
    iget-boolean v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->verbose:Z

    if-eqz v3, :cond_0

    sget-object v3, Ljava/lang/System;->out:Ljava/io/PrintStream;

    const-string v4, "  SKIPPING duplicate coordinate"

    invoke-virtual {v3, v4}, Ljava/io/PrintStream;->println(Ljava/lang/String;)V

    goto :goto_1

    .line 212
    :cond_2
    invoke-virtual {p2, v6, v4}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->set(II)V

    move v0, v4

    goto :goto_2

    .line 216
    :cond_3
    iget-boolean v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->verbose:Z

    if-eqz v3, :cond_0

    sget-object v3, Ljava/lang/System;->out:Ljava/io/PrintStream;

    const-string v4, "  SKIPPING duplicate corner index"

    invoke-virtual {v3, v4}, Ljava/io/PrintStream;->println(Ljava/lang/String;)V

    goto :goto_1

    :goto_2
    if-eqz v3, :cond_4

    .line 222
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->skippedCorners:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {v3, v6}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->add(I)V

    :cond_4
    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    .line 226
    :cond_5
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->anchor0:I

    iget v4, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    invoke-static {v2, p1, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/CircularIndex;->addOffset(III)I

    move-result v2

    .line 227
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->contour:Ljava/util/List;

    invoke-interface {v4, v0}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 228
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->contour:Ljava/util/List;

    invoke-virtual {p2, v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->get(I)I

    move-result v5

    invoke-interface {v4, v5}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 229
    iget v5, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    iget v6, v4, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    if-ne v5, v6, :cond_6

    iget v0, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    iget v4, v4, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    if-ne v0, v4, :cond_6

    .line 230
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->skippedCorners:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {v0, v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->add(I)V

    .line 234
    :cond_6
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->skippedCorners:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->data:[I

    iget v0, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    invoke-static {v2, v3, v0}, Ljava/util/Arrays;->sort([III)V

    .line 236
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->skippedCorners:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    iget v0, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    sub-int/2addr v0, v1

    :goto_3
    if-ltz v0, :cond_9

    .line 237
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->skippedCorners:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {v2, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->get(I)I

    move-result v2

    .line 238
    invoke-virtual {p2, v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->remove(I)V

    .line 240
    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->anchor0:I

    if-lt v4, v2, :cond_7

    add-int/lit8 v4, v4, -0x1

    .line 241
    iput v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->anchor0:I

    .line 243
    :cond_7
    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->anchor1:I

    if-lt v4, v2, :cond_8

    add-int/lit8 v4, v4, -0x1

    .line 244
    iput v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->anchor1:I

    :cond_8
    add-int/lit8 v0, v0, -0x1

    goto :goto_3

    .line 249
    :cond_9
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->skippedCorners:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    iget v0, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    sub-int/2addr p1, v0

    move v0, v3

    :cond_a
    :goto_4
    if-ge v0, p1, :cond_c

    .line 251
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->anchor0:I

    iget v4, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    invoke-static {v2, v0, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/CircularIndex;->addOffset(III)I

    move-result v2

    .line 252
    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->anchor0:I

    add-int/lit8 v0, v0, 0x1

    iget v5, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    invoke-static {v4, v0, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/CircularIndex;->addOffset(III)I

    move-result v4

    .line 253
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->contour:Ljava/util/List;

    invoke-virtual {p2, v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->get(I)I

    move-result v2

    invoke-interface {v5, v2}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 254
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->contour:Ljava/util/List;

    invoke-virtual {p2, v4}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->get(I)I

    move-result v4

    invoke-interface {v5, v4}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 256
    iget v5, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    iget v6, v4, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    if-ne v5, v6, :cond_a

    iget v2, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    iget v4, v4, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    if-eq v2, v4, :cond_b

    goto :goto_4

    .line 257
    :cond_b
    new-instance p1, Ljava/lang/RuntimeException;

    const-string p2, "Well I screwed up"

    invoke-direct {p1, p2}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw p1

    .line 261
    :cond_c
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size()I

    move-result p1

    const/4 p2, 0x3

    if-lt p1, p2, :cond_d

    return v1

    :cond_d
    return v3
.end method

.method sanityCheckCornerOrder(ILcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)Z
    .locals 7

    .line 158
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->anchor0:I

    invoke-virtual {p2, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->get(I)I

    move-result v0

    const/4 v1, 0x0

    const/4 v2, 0x1

    move v4, v1

    move v3, v2

    :goto_0
    if-ge v3, p1, :cond_1

    .line 161
    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->anchor0:I

    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size()I

    move-result v6

    invoke-static {v5, v3, v6}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/CircularIndex;->addOffset(III)I

    move-result v5

    invoke-virtual {p2, v5}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->get(I)I

    move-result v5

    .line 162
    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->contour:Ljava/util/List;

    invoke-interface {v6}, Ljava/util/List;->size()I

    move-result v6

    invoke-static {v0, v5, v6}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/CircularIndex;->distanceP(III)I

    move-result v5

    if-ge v5, v4, :cond_0

    return v1

    :cond_0
    add-int/lit8 v3, v3, 0x1

    move v4, v5

    goto :goto_0

    :cond_1
    return v2
.end method

.method public setContour(Ljava/util/List;)V
    .locals 0

    .line 79
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/FitLinesToContour;->contour:Ljava/util/List;

    return-void
.end method
