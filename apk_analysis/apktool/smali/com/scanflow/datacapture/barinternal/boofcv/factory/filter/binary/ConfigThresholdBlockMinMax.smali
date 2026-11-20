.class public Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThresholdBlockMinMax;
.super Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;
.source "ConfigThresholdBlockMinMax.java"


# instance fields
.field public minimumSpread:D


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;DZ)V
    .locals 2

    .line 46
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;-><init>()V

    const-wide/high16 v0, 0x4024000000000000L    # 10.0

    .line 36
    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThresholdBlockMinMax;->minimumSpread:D

    const-wide v0, 0x3feb333333333333L    # 0.85

    .line 39
    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->scale:D

    .line 47
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->BLOCK_MIN_MAX:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->type:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    .line 48
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->width:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    .line 49
    iput-wide p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThresholdBlockMinMax;->minimumSpread:D

    .line 50
    iput-boolean p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->down:Z

    return-void
.end method


# virtual methods
.method public checkValidity()V
    .locals 0

    .line 64
    invoke-super {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->checkValidity()V

    return-void
.end method
