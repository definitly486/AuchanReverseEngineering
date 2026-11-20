.class public Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodePreciseDetector;
.super Ljava/lang/Object;
.source "QrCodePreciseDetector.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodeDetector;


# instance fields
.field contourHelper:Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourHelper;

.field decoder:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;

.field detectPositionPatterns:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;

.field graphPositionPatterns:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;

.field imageType:Ljava/lang/Class;

.field inputToBinary:Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;

.field protected milliBinary:Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;

.field protected milliDecoding:Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;

.field profiler:Z


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;Ljava/lang/String;Ljava/lang/String;ZLjava/lang/Class;)V
    .locals 3

    .line 56
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 40
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodePreciseDetector;->graphPositionPatterns:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;

    const/4 v0, 0x0

    .line 48
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodePreciseDetector;->profiler:Z

    .line 49
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;

    const-wide v1, 0x3fe999999999999aL    # 0.8

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;-><init>(D)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodePreciseDetector;->milliBinary:Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;

    .line 50
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;-><init>(D)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodePreciseDetector;->milliDecoding:Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;

    .line 57
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodePreciseDetector;->inputToBinary:Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;

    .line 58
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodePreciseDetector;->detectPositionPatterns:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;

    .line 59
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;

    invoke-direct {p1, p3, p4, p6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;-><init>(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Class;)V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodePreciseDetector;->decoder:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;

    .line 60
    iput-object p6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodePreciseDetector;->imageType:Ljava/lang/Class;

    .line 61
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourHelper;

    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/SquareLocatorPatternDetectorBase;->getSquareDetector()Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;

    move-result-object p2

    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->getDetector()Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;

    move-result-object p2

    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->getContourFinder()Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinder;

    move-result-object p2

    invoke-direct {p1, p2, p5}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourHelper;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourInterface;Z)V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodePreciseDetector;->contourHelper:Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourHelper;

    return-void
.end method


# virtual methods
.method public getDecoder()Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;
    .locals 1

    .line 41
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodePreciseDetector;->decoder:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;

    return-object v0
.end method

.method public getDetections()Ljava/util/List;
    .locals 1

    .line 99
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodePreciseDetector;->decoder:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->getSuccesses()Ljava/util/List;

    move-result-object v0

    return-object v0
.end method

.method public getGraphPositionPatterns()Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;
    .locals 1

    .line 40
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodePreciseDetector;->graphPositionPatterns:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;

    return-object v0
.end method

.method public process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)V
    .locals 9

    .line 66
    invoke-static {}, Ljava/lang/System;->nanoTime()J

    move-result-wide v0

    .line 67
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodePreciseDetector;->contourHelper:Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourHelper;

    iget v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-virtual {v2, v3, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourHelper;->reshape(II)V

    .line 68
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodePreciseDetector;->inputToBinary:Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodePreciseDetector;->contourHelper:Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourHelper;

    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourHelper;->withoutPadding()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    move-result-object v3

    invoke-interface {v2, p1, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;->process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    .line 69
    invoke-static {}, Ljava/lang/System;->nanoTime()J

    move-result-wide v2

    .line 70
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodePreciseDetector;->milliBinary:Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;

    sub-long/2addr v2, v0

    long-to-double v0, v2

    const-wide v2, 0x3eb0c6f7a0b5ed8dL    # 1.0E-6

    mul-double/2addr v0, v2

    invoke-virtual {v4, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;->update(D)D

    .line 72
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodePreciseDetector;->profiler:Z

    if-eqz v0, :cond_0

    .line 73
    sget-object v0, Ljava/lang/System;->out:Ljava/io/PrintStream;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodePreciseDetector;->milliBinary:Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;->getAverage()D

    move-result-wide v4

    invoke-static {v4, v5}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object v1

    filled-new-array {v1}, [Ljava/lang/Object;

    move-result-object v1

    const-string v4, "qrcode: binary %5.2f "

    invoke-virtual {v0, v4, v1}, Ljava/io/PrintStream;->printf(Ljava/lang/String;[Ljava/lang/Object;)Ljava/io/PrintStream;

    .line 76
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodePreciseDetector;->detectPositionPatterns:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodePreciseDetector;->contourHelper:Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourHelper;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourHelper;->padded()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    move-result-object v1

    invoke-virtual {v0, p1, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/SquareLocatorPatternDetectorBase;->process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    .line 77
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodePreciseDetector;->detectPositionPatterns:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;->getPositionPatterns()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    move-result-object v0

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->toList()Ljava/util/List;

    move-result-object v0

    .line 78
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodePreciseDetector;->graphPositionPatterns:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;

    invoke-virtual {v1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternGraphGenerator;->process(Ljava/util/List;)V

    .line 80
    iget-boolean v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodePreciseDetector;->profiler:Z

    if-eqz v1, :cond_1

    .line 81
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodePreciseDetector;->detectPositionPatterns:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/SquareLocatorPatternDetectorBase;->getSquareDetector()Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;

    move-result-object v1

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->getDetector()Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;

    move-result-object v1

    .line 82
    sget-object v4, Ljava/lang/System;->out:Ljava/io/PrintStream;

    .line 83
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->getMilliContour()D

    move-result-wide v5

    invoke-static {v5, v6}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object v5

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->getMilliShapes()D

    move-result-wide v6

    invoke-static {v6, v7}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object v1

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodePreciseDetector;->detectPositionPatterns:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;

    .line 84
    invoke-virtual {v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/SquareLocatorPatternDetectorBase;->getSquareDetector()Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;

    move-result-object v6

    invoke-virtual {v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->getMilliAdjustBias()D

    move-result-wide v6

    invoke-static {v6, v7}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object v6

    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodePreciseDetector;->detectPositionPatterns:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePositionPatternDetector;

    .line 85
    invoke-virtual {v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/SquareLocatorPatternDetectorBase;->getProfilingMS()Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;

    move-result-object v7

    invoke-virtual {v7}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;->getAverage()D

    move-result-wide v7

    invoke-static {v7, v8}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object v7

    filled-new-array {v5, v1, v6, v7}, [Ljava/lang/Object;

    move-result-object v1

    .line 82
    const-string v5, " contour %5.1f shapes %5.1f adjust_bias %5.2f PosPat %6.2f"

    invoke-virtual {v4, v5, v1}, Ljava/io/PrintStream;->printf(Ljava/lang/String;[Ljava/lang/Object;)Ljava/io/PrintStream;

    .line 88
    :cond_1
    invoke-static {}, Ljava/lang/System;->nanoTime()J

    move-result-wide v4

    .line 89
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodePreciseDetector;->decoder:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;

    invoke-virtual {v1, v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->process(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)V

    .line 90
    invoke-static {}, Ljava/lang/System;->nanoTime()J

    move-result-wide v0

    .line 91
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodePreciseDetector;->milliDecoding:Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;

    sub-long/2addr v0, v4

    long-to-double v0, v0

    mul-double/2addr v0, v2

    invoke-virtual {p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;->update(D)D

    .line 93
    iget-boolean p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodePreciseDetector;->profiler:Z

    if-eqz p1, :cond_2

    .line 94
    sget-object p1, Ljava/lang/System;->out:Ljava/io/PrintStream;

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodePreciseDetector;->milliDecoding:Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;->getAverage()D

    move-result-wide v0

    invoke-static {v0, v1}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object v0

    filled-new-array {v0}, [Ljava/lang/Object;

    move-result-object v0

    const-string v1, " decoding %5.1f\n"

    invoke-virtual {p1, v1, v0}, Ljava/io/PrintStream;->printf(Ljava/lang/String;[Ljava/lang/Object;)Ljava/io/PrintStream;

    :cond_2
    return-void
.end method
