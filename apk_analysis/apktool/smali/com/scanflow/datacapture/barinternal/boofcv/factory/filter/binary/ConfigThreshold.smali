.class public Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;
.super Ljava/lang/Object;
.source "ConfigThreshold.java"

# interfaces
.implements Ljava/io/Serializable;


# instance fields
.field public down:Z

.field public fixedThreshold:D

.field public maxPixelValue:I

.field public minPixelValue:I

.field public niblackK:F

.field public nickK:F

.field public scale:D

.field public thresholdFromLocalBlocks:Z

.field public type:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

.field public width:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;


# direct methods
.method public constructor <init>()V
    .locals 3

    .line 33
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const-wide/high16 v0, 0x3ff0000000000000L    # 1.0

    .line 50
    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->scale:D

    const/4 v0, 0x1

    .line 55
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->down:Z

    const-wide/high16 v1, 0x4026000000000000L    # 11.0

    .line 60
    invoke-static {v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->fixed(D)Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    move-result-object v1

    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->width:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    const v1, 0x3e99999a    # 0.3f

    .line 69
    iput v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->niblackK:F

    const v1, -0x41b33333    # -0.2f

    .line 76
    iput v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->nickK:F

    const/4 v1, 0x0

    .line 81
    iput v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->minPixelValue:I

    const/16 v1, 0xff

    .line 85
    iput v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->maxPixelValue:I

    .line 92
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->thresholdFromLocalBlocks:Z

    return-void
.end method

.method public static local(Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;I)Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;
    .locals 2

    int-to-double v0, p1

    .line 114
    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->fixed(D)Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    move-result-object p1

    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->local(Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;)Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;

    move-result-object p0

    return-object p0
.end method

.method public static local(Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;)Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;
    .locals 4

    .line 118
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->isAdaptive()Z

    move-result v0

    if-eqz v0, :cond_3

    .line 121
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->isGlobal()Z

    move-result v0

    if-nez v0, :cond_2

    .line 125
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->BLOCK_MIN_MAX:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    if-ne p0, v0, :cond_0

    .line 126
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThresholdBlockMinMax;

    const-wide/high16 v1, 0x4024000000000000L    # 10.0

    const/4 v3, 0x1

    invoke-direct {v0, p1, v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThresholdBlockMinMax;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;DZ)V

    goto :goto_0

    .line 127
    :cond_0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;->BLOCK_OTSU:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    if-ne p0, v0, :cond_1

    .line 128
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThresholdLocalOtsu;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThresholdLocalOtsu;-><init>()V

    goto :goto_0

    .line 130
    :cond_1
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;-><init>()V

    :goto_0
    const-wide v1, 0x3fee666666666666L    # 0.95

    .line 135
    iput-wide v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->scale:D

    .line 136
    iput-object p0, v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->type:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    .line 137
    iput-object p1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->width:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    return-object v0

    .line 122
    :cond_2
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Type must be local"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0

    .line 119
    :cond_3
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Type must be adaptive"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method


# virtual methods
.method public checkValidity()V
    .locals 0

    .line 155
    return-void
.end method

.method public toString()Ljava/lang/String;
    .locals 12

    .line 159
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->type:Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ThresholdType;

    iget-wide v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->fixedThreshold:D

    iget-wide v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->scale:D

    iget-boolean v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->down:Z

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->width:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    iget v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->niblackK:F

    iget v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->minPixelValue:I

    iget v9, p0, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/binary/ConfigThreshold;->maxPixelValue:I

    new-instance v10, Ljava/lang/StringBuilder;

    invoke-direct {v10}, Ljava/lang/StringBuilder;-><init>()V

    const-string v11, "ConfigThreshold{type="

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v10, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v0, ", fixedThreshold="

    invoke-virtual {v10, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v10, v1, v2}, Ljava/lang/StringBuilder;->append(D)Ljava/lang/StringBuilder;

    const-string v0, ", scale="

    invoke-virtual {v10, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v10, v3, v4}, Ljava/lang/StringBuilder;->append(D)Ljava/lang/StringBuilder;

    const-string v0, ", down="

    invoke-virtual {v10, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v10, v5}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    const-string v0, ", width="

    invoke-virtual {v10, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v10, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v0, ", savolaK="

    invoke-virtual {v10, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v10, v7}, Ljava/lang/StringBuilder;->append(F)Ljava/lang/StringBuilder;

    const-string v0, ", minPixelValue="

    invoke-virtual {v10, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v10, v8}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string v0, ", maxPixelValue="

    invoke-virtual {v10, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v10, v9}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string v0, "}"

    invoke-virtual {v10, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v10}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
