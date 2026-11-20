.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/SquareLocatorPatternDetectorBase;
.super Ljava/lang/Object;
.source "SquareLocatorPatternDetectorBase.java"


# instance fields
.field protected interpolate:Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;

.field protected maxContourFraction:D

.field protected profilingMS:Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;

.field protected squareDetector:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;

.field protected verbose:Ljava/io/PrintStream;


# direct methods
.method protected constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;)V
    .locals 3

    .line 70
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const-wide v0, 0x3ff5555555555555L    # 1.3333333333333333

    .line 55
    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/SquareLocatorPatternDetectorBase;->maxContourFraction:D

    .line 61
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;

    const-wide v1, 0x3fe999999999999aL    # 0.8

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;-><init>(D)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/SquareLocatorPatternDetectorBase;->profilingMS:Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;

    const/4 v0, 0x0

    .line 63
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/SquareLocatorPatternDetectorBase;->verbose:Ljava/io/PrintStream;

    .line 71
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/SquareLocatorPatternDetectorBase;->squareDetector:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;

    .line 73
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->getDetector()Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;

    move-result-object v0

    const/4 v1, 0x1

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->setConvex(Z)V

    .line 74
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->getDetector()Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;

    move-result-object v0

    const/4 v1, 0x0

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->setOutputClockwiseUpY(Z)V

    .line 75
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->getDetector()Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;

    move-result-object v0

    const/4 v1, 0x4

    invoke-virtual {v0, v1, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->setNumberOfSides(II)V

    .line 77
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->getInputType()Ljava/lang/Class;

    move-result-object p1

    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;->EXTENDED:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;

    invoke-static {p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/interpolate/FactoryInterpolation;->bilinearPixelS(Ljava/lang/Class;Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;)Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/SquareLocatorPatternDetectorBase;->interpolate:Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;

    return-void
.end method


# virtual methods
.method protected configureContourDetector(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)V
    .locals 4

    .line 138
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-static {v0, p1}, Ljava/lang/Math;->min(II)I

    move-result p1

    int-to-double v0, p1

    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/SquareLocatorPatternDetectorBase;->maxContourFraction:D

    mul-double/2addr v0, v2

    double-to-int p1, v0

    .line 139
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/SquareLocatorPatternDetectorBase;->squareDetector:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->getDetector()Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;

    move-result-object v0

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonFromContour;->getContourFinder()Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourFinder;

    move-result-object v0

    int-to-double v1, p1

    .line 140
    invoke-static {v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->fixed(D)Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    move-result-object p1

    invoke-interface {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourInterface;->setMaxContour(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;)V

    const/4 p1, 0x0

    .line 141
    invoke-interface {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourInterface;->setSaveInnerContour(Z)V

    return-void
.end method

.method protected abstract findLocatorPatternsFromSquares()V
.end method

.method public getProfilingMS()Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;
    .locals 1

    .line 61
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/SquareLocatorPatternDetectorBase;->profilingMS:Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;

    return-object v0
.end method

.method public getSquareDetector()Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;
    .locals 1

    .line 58
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/SquareLocatorPatternDetectorBase;->squareDetector:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;

    return-object v0
.end method

.method public process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
    .locals 3

    .line 88
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/SquareLocatorPatternDetectorBase;->configureContourDetector(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)V

    .line 89
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/SquareLocatorPatternDetectorBase;->interpolate:Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;

    invoke-interface {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixel;->setImage(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 92
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/SquareLocatorPatternDetectorBase;->squareDetector:Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;

    invoke-virtual {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/DetectPolygonBinaryGrayRefine;->process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    .line 94
    invoke-static {}, Ljava/lang/System;->nanoTime()J

    move-result-wide p1

    .line 95
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/SquareLocatorPatternDetectorBase;->findLocatorPatternsFromSquares()V

    .line 96
    invoke-static {}, Ljava/lang/System;->nanoTime()J

    move-result-wide v0

    .line 98
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/SquareLocatorPatternDetectorBase;->profilingMS:Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;

    sub-long/2addr v0, p1

    long-to-double p1, v0

    const-wide v0, 0x3eb0c6f7a0b5ed8dL    # 1.0E-6

    mul-double/2addr p1, v0

    invoke-virtual {v2, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/misc/MovingAverage;->update(D)D

    return-void
.end method
