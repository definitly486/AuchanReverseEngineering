.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlockMinMax;
.super Ljava/lang/Object;
.source "ThresholdBlockMinMax.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;


# instance fields
.field protected blockHeight:I

.field protected blockWidth:I

.field protected down:Z

.field protected minimumSpread:D

.field protected thresholdFromLocalBlocks:Z


# direct methods
.method protected constructor <init>(DZ)V
    .locals 0

    .line 68
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 69
    iput-wide p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlockMinMax;->minimumSpread:D

    .line 70
    iput-boolean p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlockMinMax;->down:Z

    return-void
.end method


# virtual methods
.method public init(IIZ)V
    .locals 0

    .line 75
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlockMinMax;->blockWidth:I

    .line 76
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlockMinMax;->blockHeight:I

    .line 77
    iput-boolean p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlockMinMax;->thresholdFromLocalBlocks:Z

    return-void
.end method
