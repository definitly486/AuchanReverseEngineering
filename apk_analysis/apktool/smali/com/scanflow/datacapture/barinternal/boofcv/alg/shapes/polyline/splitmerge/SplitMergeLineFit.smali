.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;
.super Ljava/lang/Object;
.source "SplitMergeLineFit.java"


# instance fields
.field protected abortSplits:I

.field protected changed:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;

.field protected contour:Ljava/util/List;

.field protected line:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;

.field protected maxIterations:I

.field protected minimumSideLength:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

.field protected minimumSideLengthPixel:I

.field protected point2D:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

.field protected splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

.field protected toleranceFractionSq:D

.field work:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;


# direct methods
.method protected constructor <init>(DLcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;I)V
    .locals 1

    .line 91
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 68
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->line:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineParametric2D_F64;

    .line 69
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->point2D:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    .line 72
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    .line 73
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->work:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    .line 76
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->changed:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_B;

    const v0, 0x7fffffff

    .line 79
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->abortSplits:I

    .line 92
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->setSplitFraction(D)V

    .line 93
    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->minimumSideLength:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    .line 94
    invoke-virtual {p0, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->setMaxIterations(I)V

    return-void
.end method


# virtual methods
.method protected abstract _process(Ljava/util/List;)Z
.end method

.method public process(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)Z
    .locals 3

    .line 105
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->contour:Ljava/util/List;

    .line 106
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->minimumSideLength:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v1

    int-to-double v1, v1

    invoke-virtual {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->computeI(D)I

    move-result v0

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->minimumSideLengthPixel:I

    .line 107
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    .line 109
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->_process(Ljava/util/List;)Z

    move-result p1

    const/4 v0, 0x0

    .line 112
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->contour:Ljava/util/List;

    .line 113
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {p2, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->setTo(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    return p1
.end method

.method public setAbortSplits(I)V
    .locals 0

    .line 139
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->abortSplits:I

    return-void
.end method

.method public setMaxIterations(I)V
    .locals 0

    .line 127
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->maxIterations:I

    return-void
.end method

.method public setSplitFraction(D)V
    .locals 0

    mul-double/2addr p1, p1

    .line 131
    iput-wide p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->toleranceFractionSq:D

    return-void
.end method

.method protected splitThresholdSq(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;)D
    .locals 2

    .line 123
    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->distance2(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;)I

    move-result p1

    int-to-double p1, p1

    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/SplitMergeLineFit;->toleranceFractionSq:D

    mul-double/2addr p1, v0

    const-wide/high16 v0, 0x4000000000000000L    # 2.0

    invoke-static {v0, v1, p1, p2}, Ljava/lang/Math;->max(DD)D

    move-result-wide p1

    return-wide p1
.end method
