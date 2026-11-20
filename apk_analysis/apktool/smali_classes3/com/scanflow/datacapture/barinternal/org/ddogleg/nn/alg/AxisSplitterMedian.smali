.class public Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;
.super Ljava/lang/Object;
.source "AxisSplitterMedian.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitter;


# instance fields
.field private final N:I

.field distance:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeDistance;

.field private indexes:[I

.field private final mean:[D

.field splitAxis:I

.field splitIndex:I

.field splitPoint:Ljava/lang/Object;

.field splitRule:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitRule;

.field private tmp:[D

.field private final var:[D


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeDistance;)V
    .locals 1

    .line 76
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitRuleMax;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitRuleMax;-><init>()V

    invoke-direct {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;-><init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeDistance;Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitRule;)V

    return-void
.end method

.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeDistance;Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitRule;)V
    .locals 2

    .line 61
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const/4 v0, 0x1

    .line 46
    new-array v1, v0, [D

    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->tmp:[D

    .line 47
    new-array v0, v0, [I

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->indexes:[I

    .line 62
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->distance:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeDistance;

    .line 63
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->splitRule:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitRule;

    .line 64
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeDistance;->length()I

    move-result p1

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->N:I

    .line 66
    new-array v0, p1, [D

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->mean:[D

    .line 67
    new-array v0, p1, [D

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->var:[D

    .line 69
    invoke-interface {p2, p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitRule;->setDimension(I)V

    return-void
.end method

.method private computeAxisVariance(Ljava/util/List;)V
    .locals 10

    .line 151
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v0

    const/4 v1, 0x0

    move v2, v1

    .line 153
    :goto_0
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->N:I

    if-ge v2, v3, :cond_0

    .line 154
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->mean:[D

    const-wide/16 v4, 0x0

    aput-wide v4, v3, v2

    .line 155
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->var:[D

    aput-wide v4, v3, v2

    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    :cond_0
    move v2, v1

    :goto_1
    if-ge v2, v0, :cond_2

    .line 160
    invoke-interface {p1, v2}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v3

    move v4, v1

    .line 162
    :goto_2
    iget v5, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->N:I

    if-ge v4, v5, :cond_1

    .line 163
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->mean:[D

    aget-wide v6, v5, v4

    iget-object v8, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->distance:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeDistance;

    invoke-interface {v8, v3, v4}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeDistance;->valueAt(Ljava/lang/Object;I)D

    move-result-wide v8

    add-double/2addr v6, v8

    aput-wide v6, v5, v4

    add-int/lit8 v4, v4, 0x1

    goto :goto_2

    :cond_1
    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    :cond_2
    move v2, v1

    .line 167
    :goto_3
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->N:I

    if-ge v2, v3, :cond_3

    .line 168
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->mean:[D

    aget-wide v4, v3, v2

    int-to-double v6, v0

    div-double/2addr v4, v6

    aput-wide v4, v3, v2

    add-int/lit8 v2, v2, 0x1

    goto :goto_3

    :cond_3
    move v2, v1

    :goto_4
    if-ge v2, v0, :cond_5

    .line 173
    invoke-interface {p1, v2}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v3

    move v4, v1

    .line 175
    :goto_5
    iget v5, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->N:I

    if-ge v4, v5, :cond_4

    .line 176
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->mean:[D

    aget-wide v6, v5, v4

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->distance:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeDistance;

    invoke-interface {v5, v3, v4}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeDistance;->valueAt(Ljava/lang/Object;I)D

    move-result-wide v8

    sub-double/2addr v6, v8

    .line 177
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->var:[D

    aget-wide v8, v5, v4

    mul-double/2addr v6, v6

    add-double/2addr v8, v6

    aput-wide v8, v5, v4

    add-int/lit8 v4, v4, 0x1

    goto :goto_5

    :cond_4
    add-int/lit8 v2, v2, 0x1

    goto :goto_4

    :cond_5
    return-void
.end method

.method private quickSelect(Ljava/util/List;II)V
    .locals 5

    .line 186
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v0

    .line 188
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->tmp:[D

    array-length v1, v1

    if-ge v1, v0, :cond_0

    .line 189
    new-array v1, v0, [D

    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->tmp:[D

    .line 190
    new-array v1, v0, [I

    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->indexes:[I

    :cond_0
    const/4 v1, 0x0

    :goto_0
    if-ge v1, v0, :cond_1

    .line 193
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->tmp:[D

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->distance:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeDistance;

    invoke-interface {p1, v1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v4

    invoke-interface {v3, v4, p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeDistance;->valueAt(Ljava/lang/Object;I)D

    move-result-wide v3

    aput-wide v3, v2, v1

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    .line 196
    :cond_1
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->tmp:[D

    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->indexes:[I

    invoke-static {p1, p3, v0, p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/sorting/QuickSelect;->selectIndex([DII[I)I

    return-void
.end method


# virtual methods
.method public getPointLength()I
    .locals 1

    .line 144
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->N:I

    return v0
.end method

.method public getSplitAxis()I
    .locals 1

    .line 139
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->splitAxis:I

    return v0
.end method

.method public getSplitIndex()I
    .locals 1

    .line 134
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->splitIndex:I

    return v0
.end method

.method public getSplitPoint()Ljava/lang/Object;
    .locals 1

    .line 129
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->splitPoint:Ljava/lang/Object;

    return-object v0
.end method

.method public splitData(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)V
    .locals 5

    .line 83
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->computeAxisVariance(Ljava/util/List;)V

    const/4 v0, 0x0

    move v1, v0

    .line 84
    :goto_0
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->N:I

    if-ge v1, v2, :cond_1

    .line 85
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->var:[D

    aget-wide v3, v2, v1

    invoke-static {v3, v4}, Ljava/lang/Double;->isNaN(D)Z

    move-result v2

    if-nez v2, :cond_0

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    .line 86
    :cond_0
    new-instance p2, Ljava/lang/RuntimeException;

    iget-object p3, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->mean:[D

    aget-wide p4, p3, v1

    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result p1

    new-instance p3, Ljava/lang/StringBuilder;

    invoke-direct {p3}, Ljava/lang/StringBuilder;-><init>()V

    const-string p6, "Variance is NaN.  Bad input is the cause. mean[i]="

    invoke-virtual {p3, p6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p3, p4, p5}, Ljava/lang/StringBuilder;->append(D)Ljava/lang/StringBuilder;

    const-string p4, " i="

    invoke-virtual {p3, p4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p3, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p4, " points.size="

    invoke-virtual {p3, p4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p3, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {p3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {p2, p1}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw p2

    .line 90
    :cond_1
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->splitRule:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitRule;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->var:[D

    invoke-interface {v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitRule;->select([D)I

    move-result v1

    iput v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->splitAxis:I

    .line 93
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v1

    div-int/lit8 v1, v1, 0x2

    .line 95
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->splitAxis:I

    invoke-direct {p0, p1, v2, v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->quickSelect(Ljava/util/List;II)V

    .line 97
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->indexes:[I

    aget v2, v2, v1

    invoke-interface {p1, v2}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v2

    iput-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->splitPoint:Ljava/lang/Object;

    if-nez p2, :cond_4

    :goto_1
    if-ge v0, v1, :cond_2

    .line 102
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->indexes:[I

    aget p2, p2, v0

    invoke-interface {p1, p2}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p2

    invoke-interface {p3, p2}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    add-int/lit8 v0, v0, 0x1

    goto :goto_1

    :cond_2
    :goto_2
    add-int/lit8 v1, v1, 0x1

    .line 104
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result p2

    if-ge v1, p2, :cond_3

    .line 105
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->indexes:[I

    aget p2, p2, v1

    invoke-interface {p1, p2}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p2

    invoke-interface {p5, p2}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    goto :goto_2

    :cond_3
    return-void

    .line 108
    :cond_4
    invoke-static {p4}, Ljava/util/Objects;->requireNonNull(Ljava/lang/Object;)Ljava/lang/Object;

    .line 109
    invoke-static {p6}, Ljava/util/Objects;->requireNonNull(Ljava/lang/Object;)Ljava/lang/Object;

    .line 110
    invoke-virtual {p4}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    .line 111
    invoke-virtual {p6}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    :goto_3
    if-ge v0, v1, :cond_5

    .line 114
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->indexes:[I

    aget v2, v2, v0

    .line 115
    invoke-interface {p1, v2}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v3

    invoke-interface {p3, v3}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 116
    invoke-virtual {p2, v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->get(I)I

    move-result v2

    invoke-virtual {p4, v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->add(I)V

    add-int/lit8 v0, v0, 0x1

    goto :goto_3

    :cond_5
    add-int/lit8 p3, v1, 0x1

    .line 118
    :goto_4
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result p4

    if-ge p3, p4, :cond_6

    .line 119
    iget-object p4, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->indexes:[I

    aget p4, p4, p3

    .line 120
    invoke-interface {p1, p4}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v0

    invoke-interface {p5, v0}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 121
    invoke-virtual {p2, p4}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->get(I)I

    move-result p4

    invoke-virtual {p6, p4}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->add(I)V

    add-int/lit8 p3, p3, 0x1

    goto :goto_4

    .line 123
    :cond_6
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->indexes:[I

    aget p1, p1, v1

    invoke-virtual {p2, p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->get(I)I

    move-result p1

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;->splitIndex:I

    return-void
.end method
