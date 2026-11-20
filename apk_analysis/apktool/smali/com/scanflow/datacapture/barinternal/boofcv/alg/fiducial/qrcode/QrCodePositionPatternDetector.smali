.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;
.super Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/SquareLocatorPatternDetectorBase;
.source "QrCodePositionPatternDetector.java"


# instance fields
.field length:[I

.field parametric:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;

.field protected positionPatterns:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

.field samples:[F

.field segment:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

.field type:[I


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;)V
    .locals 2

    .line 62
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/SquareLocatorPatternDetectorBase;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;)V

    .line 53
    new-instance p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector$$ExternalSyntheticLambda0;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector$$ExternalSyntheticLambda0;-><init>()V

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector$$ExternalSyntheticLambda1;

    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector$$ExternalSyntheticLambda1;-><init>()V

    invoke-direct {p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;-><init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/Factory;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DProcess;)V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;->positionPatterns:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 119
    new-instance p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;->segment:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

    .line 120
    new-instance p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;->parametric:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;

    const/16 p1, 0x2e

    .line 121
    new-array p1, p1, [F

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;->samples:[F

    const/16 p1, 0xc

    .line 122
    new-array v0, p1, [I

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;->length:[I

    .line 123
    new-array p1, p1, [I

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;->type:[I

    return-void
.end method

.method private checkLine(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;FI)Z
    .locals 16

    move-object/from16 v0, p0

    move-object/from16 v1, p1

    move/from16 v2, p3

    add-int/lit8 v3, v2, 0x1

    .line 128
    rem-int/lit8 v3, v3, 0x4

    add-int/lit8 v4, v2, 0x2

    .line 129
    rem-int/lit8 v4, v4, 0x4

    add-int/lit8 v5, v2, 0x3

    .line 130
    rem-int/lit8 v5, v5, 0x4

    .line 132
    invoke-virtual {v1, v2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v2

    invoke-virtual {v1, v3}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v3

    iget-object v6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;->segment:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

    iget-object v6, v6, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->a:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-static {v2, v3, v6}, Lcom/scanflow/datacapture/barinternal/georegression/geometry/UtilPoint2D_F64;->mean(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    .line 133
    invoke-virtual {v1, v4}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v2

    invoke-virtual {v1, v5}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v1

    iget-object v3, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;->segment:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

    iget-object v3, v3, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;->b:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-static {v2, v1, v3}, Lcom/scanflow/datacapture/barinternal/georegression/geometry/UtilPoint2D_F64;->mean(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    .line 135
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;->segment:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;

    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;->parametric:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;

    invoke-static {v1, v2}, Lcom/scanflow/datacapture/barinternal/georegression/geometry/UtilLine2D_F64;->convert(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineSegment2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;

    .line 138
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;->samples:[F

    array-length v2, v1

    const/16 v3, 0x9

    div-int/2addr v2, v3

    .line 139
    array-length v1, v1

    mul-int/lit8 v4, v2, 0x2

    sub-int/2addr v1, v4

    const/4 v4, 0x1

    sub-int/2addr v1, v4

    int-to-double v5, v1

    const/4 v7, 0x0

    .line 141
    :goto_0
    iget-object v8, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;->samples:[F

    array-length v9, v8

    if-ge v7, v9, :cond_0

    sub-int v9, v7, v2

    int-to-double v9, v9

    div-double/2addr v9, v5

    .line 144
    iget-object v11, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;->parametric:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;

    iget-object v12, v11, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;->p:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide v13, v12, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    iget-object v11, v11, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;->slope:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Vector2D_F64;

    move/from16 p1, v2

    const/16 p3, 0x0

    iget-wide v1, v11, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    mul-double/2addr v1, v9

    add-double/2addr v13, v1

    double-to-float v1, v13

    .line 145
    iget-wide v12, v12, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    iget-wide v14, v11, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    mul-double/2addr v9, v14

    add-double/2addr v12, v9

    double-to-float v2, v12

    .line 147
    iget-object v9, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/SquareLocatorPatternDetectorBase;->interpolate:Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;

    invoke-interface {v9, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;->get(FF)F

    move-result v1

    aput v1, v8, v7

    add-int/lit8 v7, v7, 0x1

    move/from16 v2, p1

    goto :goto_0

    :cond_0
    const/16 p3, 0x0

    .line 153
    aget v1, v8, p3

    cmpg-float v1, v1, p2

    if-gez v1, :cond_1

    move v1, v4

    goto :goto_1

    :cond_1
    move/from16 v1, p3

    .line 154
    :goto_1
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;->type:[I

    xor-int/lit8 v5, v1, 0x1

    aput v5, v2, p3

    move/from16 v2, p3

    move v5, v2

    .line 155
    :goto_2
    iget-object v6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;->samples:[F

    array-length v7, v6

    if-ge v2, v7, :cond_4

    .line 156
    aget v6, v6, v2

    cmpg-float v6, v6, p2

    if-gez v6, :cond_2

    move v6, v4

    goto :goto_3

    :cond_2
    move/from16 v6, p3

    :goto_3
    if-ne v1, v6, :cond_3

    .line 159
    iget-object v6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;->length:[I

    aget v7, v6, v5

    add-int/2addr v7, v4

    aput v7, v6, v5

    goto :goto_4

    .line 162
    :cond_3
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;->type:[I

    array-length v7, v1

    sub-int/2addr v7, v4

    if-ge v5, v7, :cond_4

    add-int/lit8 v5, v5, 0x1

    xor-int/lit8 v7, v6, 0x1

    .line 164
    aput v7, v1, v5

    .line 165
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;->length:[I

    aput v4, v1, v5

    move v1, v6

    :goto_4
    add-int/lit8 v2, v2, 0x1

    goto :goto_2

    :cond_4
    add-int/2addr v5, v4

    const/4 v1, 0x5

    if-lt v5, v1, :cond_a

    if-le v5, v3, :cond_5

    goto :goto_7

    :cond_5
    move/from16 v1, p3

    :goto_5
    add-int/lit8 v2, v1, 0x5

    if-gt v2, v5, :cond_a

    .line 178
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;->type:[I

    aget v2, v2, v1

    if-eqz v2, :cond_6

    goto :goto_6

    .line 181
    :cond_6
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;->length:[I

    aget v3, v2, v1

    add-int/lit8 v6, v1, 0x2

    .line 182
    aget v6, v2, v6

    add-int/lit8 v7, v1, 0x4

    .line 183
    aget v7, v2, v7

    add-int/lit8 v8, v1, 0x1

    .line 185
    aget v8, v2, v8

    add-int/lit8 v9, v1, 0x3

    .line 186
    aget v2, v2, v9

    int-to-double v9, v3

    int-to-double v11, v8

    const-wide v13, 0x3fd999999999999aL    # 0.4

    mul-double/2addr v11, v13

    cmpg-double v9, v9, v11

    if-ltz v9, :cond_9

    mul-int/lit8 v8, v8, 0x3

    if-le v3, v8, :cond_7

    goto :goto_6

    :cond_7
    int-to-double v8, v7

    int-to-double v10, v2

    mul-double/2addr v10, v13

    cmpg-double v8, v8, v10

    if-ltz v8, :cond_9

    mul-int/lit8 v2, v2, 0x3

    if-le v7, v2, :cond_8

    goto :goto_6

    :cond_8
    add-int/2addr v3, v7

    if-lt v6, v3, :cond_9

    mul-int/lit8 v3, v3, 0x2

    if-gt v6, v3, :cond_9

    return v4

    :cond_9
    :goto_6
    add-int/lit8 v1, v1, 0x1

    goto :goto_5

    :cond_a
    :goto_7
    return p3
.end method

.method private squaresToPositionList()V
    .locals 7

    .line 77
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;->positionPatterns:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 78
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/SquareLocatorPatternDetectorBase;->squareDetector:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->getPolygonInfo()Ljava/util/List;

    move-result-object v0

    const/4 v1, 0x0

    .line 79
    :goto_0
    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v2

    if-ge v1, v2, :cond_1

    .line 80
    invoke-interface {v0, v1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$Info;

    .line 89
    iget-wide v3, v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$Info;->edgeInside:D

    iget-wide v5, v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$Info;->edgeOutside:D

    add-double/2addr v3, v5

    const-wide/high16 v5, 0x4000000000000000L    # 2.0

    div-double/2addr v3, v5

    .line 90
    iget-object v5, v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$Info;->polygon:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    double-to-float v6, v3

    invoke-virtual {p0, v5, v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;->checkPositionPatternAppearance(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;F)Z

    move-result v5

    if-nez v5, :cond_0

    goto :goto_1

    .line 94
    :cond_0
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/SquareLocatorPatternDetectorBase;->squareDetector:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;

    invoke-virtual {v5, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->refine(Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$Info;)Z

    .line 96
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;->positionPatterns:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v5}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->grow()Ljava/lang/Object;

    move-result-object v5

    check-cast v5, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PositionPatternNode;

    .line 97
    iget-object v2, v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour$Info;->polygon:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    iput-object v2, v5, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->square:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    .line 98
    iput-wide v3, v5, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PositionPatternNode;->grayThreshold:D

    .line 100
    invoke-static {v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareGraph;->computeNodeInfo(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;)V

    :goto_1
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    .line 103
    :cond_1
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/SquareLocatorPatternDetectorBase;->verbose:Ljava/io/PrintStream;

    if-eqz v0, :cond_2

    .line 104
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/SquareLocatorPatternDetectorBase;->squareDetector:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->getPolygonInfo()Ljava/util/List;

    move-result-object v1

    invoke-interface {v1}, Ljava/util/List;->size()I

    move-result v1

    invoke-static {v1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v1

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;->positionPatterns:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    iget v2, v2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    invoke-static {v2}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v2

    filled-new-array {v1, v2}, [Ljava/lang/Object;

    move-result-object v1

    const-string v2, "squares=%d position_pattern=%d\n"

    invoke-virtual {v0, v2, v1}, Ljava/io/PrintStream;->printf(Ljava/lang/String;[Ljava/lang/Object;)Ljava/io/PrintStream;

    :cond_2
    return-void
.end method


# virtual methods
.method checkPositionPatternAppearance(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;F)Z
    .locals 3

    const/4 v0, 0x0

    .line 116
    invoke-direct {p0, p1, p2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;->checkLine(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;FI)Z

    move-result v1

    const/4 v2, 0x1

    if-nez v1, :cond_1

    invoke-direct {p0, p1, p2, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;->checkLine(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;FI)Z

    move-result p1

    if-eqz p1, :cond_0

    goto :goto_0

    :cond_0
    return v0

    :cond_1
    :goto_0
    return v2
.end method

.method protected findLocatorPatternsFromSquares()V
    .locals 0

    .line 70
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;->squaresToPositionList()V

    return-void
.end method

.method public getPositionPatterns()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;
    .locals 1

    .line 53
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;->positionPatterns:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    return-object v0
.end method
