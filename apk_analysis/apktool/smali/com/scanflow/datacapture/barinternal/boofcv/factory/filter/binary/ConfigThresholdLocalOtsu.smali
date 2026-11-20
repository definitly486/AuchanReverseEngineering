.class public Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThresholdLocalOtsu;
.super Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;
.source "ConfigThresholdLocalOtsu.java"


# instance fields
.field public tuning:D

.field public useOtsu2:Z


# direct methods
.method public constructor <init>()V
    .locals 2

    .line 59
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;-><init>()V

    const-wide/16 v0, 0x0

    .line 40
    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThresholdLocalOtsu;->tuning:D

    const/4 v0, 0x1

    .line 47
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThresholdLocalOtsu;->useOtsu2:Z

    .line 60
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->BLOCK_OTSU:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->type:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    return-void
.end method
