.class public Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigRefinePolygonLineToImage;
.super Ljava/lang/Object;
.source "ConfigRefinePolygonLineToImage.java"

# interfaces
.implements Ljava/io/Serializable;


# instance fields
.field public convergeTolPixels:D

.field public cornerOffset:D

.field public lineSamples:I

.field public maxCornerChangePixel:D

.field public maxIterations:I

.field public sampleRadius:I


# direct methods
.method public constructor <init>()V
    .locals 2

    .line 29
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const-wide/high16 v0, 0x3ff0000000000000L    # 1.0

    .line 35
    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigRefinePolygonLineToImage;->cornerOffset:D

    const/16 v0, 0x1e

    .line 39
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigRefinePolygonLineToImage;->lineSamples:I

    const/4 v0, 0x1

    .line 44
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigRefinePolygonLineToImage;->sampleRadius:I

    const/16 v0, 0xa

    .line 48
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigRefinePolygonLineToImage;->maxIterations:I

    const-wide v0, 0x3fc999999999999aL    # 0.2

    .line 52
    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigRefinePolygonLineToImage;->convergeTolPixels:D

    const-wide/high16 v0, 0x4000000000000000L    # 2.0

    .line 58
    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigRefinePolygonLineToImage;->maxCornerChangePixel:D

    return-void
.end method


# virtual methods
.method public toString()Ljava/lang/String;
    .locals 11

    .line 74
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Class;->getSimpleName()Ljava/lang/String;

    move-result-object v0

    iget-wide v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigRefinePolygonLineToImage;->cornerOffset:D

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigRefinePolygonLineToImage;->lineSamples:I

    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigRefinePolygonLineToImage;->sampleRadius:I

    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigRefinePolygonLineToImage;->maxIterations:I

    iget-wide v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigRefinePolygonLineToImage;->convergeTolPixels:D

    iget-wide v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/shape/ConfigRefinePolygonLineToImage;->maxCornerChangePixel:D

    new-instance v10, Ljava/lang/StringBuilder;

    invoke-direct {v10}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v10, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v0, "{cornerOffset="

    invoke-virtual {v10, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v10, v1, v2}, Ljava/lang/StringBuilder;->append(D)Ljava/lang/StringBuilder;

    const-string v0, ", lineSamples="

    invoke-virtual {v10, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v10, v3}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string v0, ", sampleRadius="

    invoke-virtual {v10, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v10, v4}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string v0, ", maxIterations="

    invoke-virtual {v10, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v10, v5}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string v0, ", convergeTolPixels="

    invoke-virtual {v10, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v10, v6, v7}, Ljava/lang/StringBuilder;->append(D)Ljava/lang/StringBuilder;

    const-string v0, ", maxCornerChangePixel="

    invoke-virtual {v10, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v10, v8, v9}, Ljava/lang/StringBuilder;->append(D)Ljava/lang/StringBuilder;

    const-string v0, "}"

    invoke-virtual {v10, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v10}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
