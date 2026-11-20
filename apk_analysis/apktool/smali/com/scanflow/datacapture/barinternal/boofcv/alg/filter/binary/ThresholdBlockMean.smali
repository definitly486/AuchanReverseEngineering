.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlockMean;
.super Ljava/lang/Object;
.source "ThresholdBlockMean.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock$BlockProcessor;


# instance fields
.field protected a:B

.field protected b:B

.field protected blockHeight:I

.field protected blockWidth:I

.field protected thresholdFromLocalBlocks:Z


# direct methods
.method protected constructor <init>(Z)V
    .locals 2

    .line 41
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const/4 v0, 0x0

    const/4 v1, 0x1

    if-eqz p1, :cond_0

    .line 43
    iput-byte v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlockMean;->a:B

    .line 44
    iput-byte v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlockMean;->b:B

    return-void

    .line 46
    :cond_0
    iput-byte v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlockMean;->a:B

    .line 47
    iput-byte v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlockMean;->b:B

    return-void
.end method


# virtual methods
.method public init(IIZ)V
    .locals 0

    .line 53
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlockMean;->blockWidth:I

    .line 54
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlockMean;->blockHeight:I

    .line 55
    iput-boolean p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlockMean;->thresholdFromLocalBlocks:Z

    return-void
.end method

.method public isDown()Z
    .locals 2

    .line 59
    iget-byte v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlockMean;->a:B

    const/4 v1, 0x1

    if-ne v0, v1, :cond_0

    return v1

    :cond_0
    const/4 v0, 0x0

    return v0
.end method
