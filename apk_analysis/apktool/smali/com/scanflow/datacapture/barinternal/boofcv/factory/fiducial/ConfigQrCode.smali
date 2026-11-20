.class public Lcom/scanflow/datacapture/barinternal/boofcv/factory/fiducial/ConfigQrCode;
.super Ljava/lang/Object;
.source "ConfigQrCode.java"

# interfaces
.implements Ljava/io/Serializable;


# instance fields
.field public considerTransposed:Z

.field public defaultEncoding:Ljava/lang/String;

.field public forceEncoding:Ljava/lang/String;

.field public ignorePaddingBytes:Z

.field public polygon:Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonDetector;

.field public threshold:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;

.field public versionMaximum:I

.field public versionMinimum:I


# direct methods
.method public constructor <init>()V
    .locals 7

    .line 37
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 42
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonDetector;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonDetector;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/fiducial/ConfigQrCode;->polygon:Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonDetector;

    const/4 v0, 0x1

    .line 47
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/fiducial/ConfigQrCode;->versionMinimum:I

    const/16 v1, 0x28

    .line 48
    iput v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/fiducial/ConfigQrCode;->versionMaximum:I

    const/4 v2, 0x0

    .line 55
    iput-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/fiducial/ConfigQrCode;->forceEncoding:Ljava/lang/String;

    .line 62
    const-string v2, "ISO8859_1"

    iput-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/fiducial/ConfigQrCode;->defaultEncoding:Ljava/lang/String;

    .line 68
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/fiducial/ConfigQrCode;->considerTransposed:Z

    .line 75
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/fiducial/ConfigQrCode;->ignorePaddingBytes:Z

    .line 83
    sget-object v2, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->BLOCK_OTSU:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    invoke-static {v2, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->local(Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;I)Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;

    move-result-object v1

    check-cast v1, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThresholdLocalOtsu;

    .line 84
    iput-boolean v0, v1, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThresholdLocalOtsu;->useOtsu2:Z

    const-wide/high16 v2, 0x3ff0000000000000L    # 1.0

    .line 86
    iput-wide v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->scale:D

    .line 88
    iput-boolean v0, v1, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->thresholdFromLocalBlocks:Z

    const-wide/high16 v2, 0x4010000000000000L    # 4.0

    .line 89
    iput-wide v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThresholdLocalOtsu;->tuning:D

    .line 91
    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/fiducial/ConfigQrCode;->threshold:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;

    .line 93
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/fiducial/ConfigQrCode;->polygon:Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonDetector;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonDetector;->detector:Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;->EIGHT:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;

    iput-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;->contourRule:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;

    const/4 v1, 0x0

    .line 94
    iput-boolean v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;->clockwise:Z

    .line 95
    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;->contourToPoly:Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/BaseConfigPolyline;

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;

    const-wide v1, 0x3fbeb851eb851eb8L    # 0.12

    const-wide/high16 v3, 0x4008000000000000L    # 3.0

    invoke-static {v1, v2, v3, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->relative(DD)Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    move-result-object v1

    iput-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;->maxSideError:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    .line 96
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/fiducial/ConfigQrCode;->polygon:Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonDetector;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonDetector;->detector:Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;

    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;->contourToPoly:Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/BaseConfigPolyline;

    move-object v2, v1

    check-cast v2, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;

    const-wide v5, 0x3fd999999999999aL    # 0.4

    iput-wide v5, v2, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;->cornerScorePenalty:D

    .line 97
    check-cast v1, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;

    const/4 v2, 0x2

    iput v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;->minimumSideLength:I

    const-wide/high16 v1, 0x4044000000000000L    # 40.0

    .line 100
    invoke-static {v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->fixed(D)Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    move-result-object v1

    iput-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;->minimumContour:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    .line 102
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/fiducial/ConfigQrCode;->polygon:Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonDetector;

    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonDetector;->detector:Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;

    iput-wide v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;->minimumEdgeIntensity:D

    const-wide/high16 v2, 0x4018000000000000L    # 6.0

    .line 103
    iput-wide v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonDetector;->minimumRefineEdgeIntensity:D

    const-wide/high16 v2, 0x3ff8000000000000L    # 1.5

    .line 105
    iput-wide v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;->tangentEdgeIntensity:D

    return-void
.end method


# virtual methods
.method public checkValidity()V
    .locals 1

    .line 138
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/fiducial/ConfigQrCode;->threshold:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->checkValidity()V

    .line 139
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/fiducial/ConfigQrCode;->polygon:Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonDetector;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonDetector;->checkValidity()V

    return-void
.end method
