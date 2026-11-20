.class public Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonDetector;
.super Ljava/lang/Object;
.source "ConfigPolygonDetector.java"

# interfaces
.implements Ljava/io/Serializable;


# instance fields
.field public adjustForThresholdBias:Z

.field public detector:Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;

.field public minimumRefineEdgeIntensity:D

.field public refineContour:Z

.field public refineGray:Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigRefinePolygonLineToImage;


# direct methods
.method public constructor <init>()V
    .locals 3

    .line 77
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 36
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;

    const/4 v1, 0x3

    const/16 v2, 0x2710

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;-><init>(II)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonDetector;->detector:Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;

    const-wide/high16 v0, 0x4018000000000000L    # 6.0

    .line 48
    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonDetector;->minimumRefineEdgeIntensity:D

    const/4 v0, 0x0

    .line 53
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonDetector;->refineContour:Z

    const/4 v0, 0x1

    .line 59
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonDetector;->adjustForThresholdBias:Z

    .line 64
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigRefinePolygonLineToImage;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigRefinePolygonLineToImage;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonDetector;->refineGray:Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigRefinePolygonLineToImage;

    return-void
.end method


# virtual methods
.method public checkValidity()V
    .locals 0

    .line 94
    return-void
.end method

.method public toString()Ljava/lang/String;
    .locals 7

    .line 98
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonDetector;->detector:Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;

    iget-wide v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonDetector;->minimumRefineEdgeIntensity:D

    iget-boolean v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonDetector;->refineContour:Z

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonDetector;->refineGray:Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigRefinePolygonLineToImage;

    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "ConfigPolygonDetector{detector="

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v5, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v0, ", minimumEdgeIntensity="

    invoke-virtual {v5, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v5, v1, v2}, Ljava/lang/StringBuilder;->append(D)Ljava/lang/StringBuilder;

    const-string v0, ", refineContour="

    invoke-virtual {v5, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v5, v3}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    const-string v0, ", refineGray="

    invoke-virtual {v5, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v5, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v0, "}"

    invoke-virtual {v5, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
