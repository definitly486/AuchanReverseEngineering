.class public Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;
.super Ljava/lang/Object;
.source "ConfigPolygonFromContour.java"

# interfaces
.implements Ljava/io/Serializable;


# instance fields
.field public canTouchBorder:Z

.field public clockwise:Z

.field public contourRule:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;

.field public contourToPoly:Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/BaseConfigPolyline;

.field public maximumContour:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

.field public minimumContour:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

.field public minimumEdgeIntensity:D

.field public tangentEdgeIntensity:D


# direct methods
.method public constructor <init>(II)V
    .locals 4

    .line 87
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const/4 v0, 0x0

    .line 38
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;->canTouchBorder:Z

    .line 43
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;->FOUR:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;->contourRule:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;

    .line 48
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/ConfigPolylineSplitMerge;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;->contourToPoly:Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/BaseConfigPolyline;

    const-wide/high16 v0, 0x4018000000000000L    # 6.0

    .line 60
    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;->minimumEdgeIntensity:D

    const-wide/high16 v0, 0x4004000000000000L    # 2.5

    .line 65
    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;->tangentEdgeIntensity:D

    const-wide v0, 0x3fa6872b020c49baL    # 0.044

    const-wide/high16 v2, 0x4010000000000000L    # 4.0

    .line 71
    invoke-static {v0, v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->relative(DD)Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;->minimumContour:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    const-wide/high16 v0, -0x4010000000000000L    # -1.0

    .line 77
    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->fixed(D)Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;->maximumContour:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    const/4 v0, 0x1

    .line 82
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;->clockwise:Z

    .line 88
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;->contourToPoly:Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/BaseConfigPolyline;

    iput p1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/BaseConfigPolyline;->minimumSides:I

    .line 89
    iput p2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/BaseConfigPolyline;->maximumSides:I

    return-void
.end method


# virtual methods
.method public checkValidity()V
    .locals 1

    .line 115
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;->minimumContour:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->checkValidity()V

    .line 116
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;->maximumContour:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->checkValidity()V

    return-void
.end method

.method public toString()Ljava/lang/String;
    .locals 10

    .line 121
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;->contourToPoly:Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/BaseConfigPolyline;

    iget-wide v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;->minimumEdgeIntensity:D

    iget-wide v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;->tangentEdgeIntensity:D

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;->minimumContour:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;->maximumContour:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    iget-boolean v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigPolygonFromContour;->clockwise:Z

    new-instance v8, Ljava/lang/StringBuilder;

    invoke-direct {v8}, Ljava/lang/StringBuilder;-><init>()V

    const-string v9, "ConfigPolygonFromContour{ contourToPoly="

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v8, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v0, ", minimumEdgeIntensity="

    invoke-virtual {v8, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v8, v1, v2}, Ljava/lang/StringBuilder;->append(D)Ljava/lang/StringBuilder;

    const-string v0, ", tangentEdgeIntensity="

    invoke-virtual {v8, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v8, v3, v4}, Ljava/lang/StringBuilder;->append(D)Ljava/lang/StringBuilder;

    const-string v0, ", minimumContour="

    invoke-virtual {v8, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v8, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v0, ", maximumContour="

    invoke-virtual {v8, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v8, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v0, ", clockwise="

    invoke-virtual {v8, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v8, v7}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    const-string v0, "}"

    invoke-virtual {v8, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
