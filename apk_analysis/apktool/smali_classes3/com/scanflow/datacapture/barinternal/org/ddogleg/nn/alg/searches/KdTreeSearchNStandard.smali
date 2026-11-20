.class public Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;
.super Ljava/lang/Object;
.source "KdTreeSearchNStandard.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearchN;


# instance fields
.field distance:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeDistance;

.field private maxDistanceSq:D

.field private mostDistantNeighborIndex:I

.field private mostDistantNeighborSq:D

.field private searchN:I

.field private target:Ljava/lang/Object;

.field private tree:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeDistance;)V
    .locals 2

    .line 55
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const-wide v0, 0x7fefffffffffffffL    # Double.MAX_VALUE

    .line 44
    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;->maxDistanceSq:D

    .line 56
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;->distance:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeDistance;

    return-void
.end method

.method private checkBestDistance(Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;)V
    .locals 11

    .line 146
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;->distance:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeDistance;

    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;->point:Ljava/lang/Object;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;->target:Ljava/lang/Object;

    invoke-interface {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeDistance;->distance(Ljava/lang/Object;Ljava/lang/Object;)D

    move-result-wide v0

    .line 148
    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;->mostDistantNeighborSq:D

    cmpg-double v2, v0, v2

    if-gtz v2, :cond_5

    .line 149
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size()I

    move-result v2

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;->searchN:I

    const-wide/high16 v4, -0x4010000000000000L    # -1.0

    const/4 v6, 0x0

    if-ge v2, v3, :cond_1

    .line 152
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->grow()Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeResult;

    .line 153
    iput-wide v0, v2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeResult;->distance:D

    .line 154
    iput-object p1, v2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeResult;->node:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;

    .line 155
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size()I

    move-result p1

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;->searchN:I

    if-ne p1, v0, :cond_5

    .line 157
    iput-wide v4, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;->mostDistantNeighborSq:D

    .line 158
    :goto_0
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;->searchN:I

    if-ge v6, p1, :cond_5

    .line 159
    invoke-virtual {p2, v6}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeResult;

    .line 160
    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeResult;->distance:D

    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;->mostDistantNeighborSq:D

    cmpl-double p1, v0, v2

    if-lez p1, :cond_0

    .line 161
    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;->mostDistantNeighborSq:D

    .line 162
    iput v6, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;->mostDistantNeighborIndex:I

    :cond_0
    add-int/lit8 v6, v6, 0x1

    goto :goto_0

    :cond_1
    move v2, v6

    .line 167
    :goto_1
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;->searchN:I

    if-ge v2, v3, :cond_3

    .line 168
    invoke-virtual {p2, v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->get(I)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeResult;

    .line 169
    iget-wide v7, v3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeResult;->distance:D

    iget-wide v9, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;->mostDistantNeighborSq:D

    cmpl-double v3, v7, v9

    if-gtz v3, :cond_2

    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    .line 170
    :cond_2
    new-instance p1, Ljava/lang/RuntimeException;

    const-string p2, "Most distant isn\'t the most distant"

    invoke-direct {p1, p2}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw p1

    .line 176
    :cond_3
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;->mostDistantNeighborIndex:I

    invoke-virtual {p2, v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->get(I)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeResult;

    .line 177
    iput-object p1, v2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeResult;->node:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;

    .line 178
    iput-wide v0, v2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeResult;->distance:D

    .line 182
    iput-wide v4, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;->mostDistantNeighborSq:D

    .line 183
    :goto_2
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;->searchN:I

    if-ge v6, p1, :cond_5

    .line 184
    invoke-virtual {p2, v6}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeResult;

    .line 185
    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeResult;->distance:D

    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;->mostDistantNeighborSq:D

    cmpl-double p1, v0, v2

    if-lez p1, :cond_4

    .line 186
    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;->mostDistantNeighborSq:D

    .line 187
    iput v6, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;->mostDistantNeighborIndex:I

    :cond_4
    add-int/lit8 v6, v6, 0x1

    goto :goto_2

    :cond_5
    return-void
.end method

.method private stepClosest(Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;)V
    .locals 5

    if-nez p1, :cond_0

    goto :goto_1

    .line 110
    :cond_0
    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;->checkBestDistance(Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;)V

    .line 112
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;->isLeaf()Z

    move-result v0

    if-eqz v0, :cond_1

    goto :goto_1

    .line 119
    :cond_1
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;->distance:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeDistance;

    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;->point:Ljava/lang/Object;

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;->split:I

    invoke-interface {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeDistance;->valueAt(Ljava/lang/Object;I)D

    move-result-wide v0

    .line 121
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;->distance:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeDistance;

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;->target:Ljava/lang/Object;

    iget v4, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;->split:I

    invoke-interface {v2, v3, v4}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeDistance;->valueAt(Ljava/lang/Object;I)D

    move-result-wide v2

    cmpg-double v4, v2, v0

    if-gtz v4, :cond_2

    .line 123
    iget-object v4, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;->left:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;

    .line 124
    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;->right:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;

    goto :goto_0

    .line 126
    :cond_2
    iget-object v4, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;->right:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;

    .line 127
    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;->left:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;

    .line 130
    :goto_0
    invoke-direct {p0, v4, p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;->stepClosest(Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;)V

    sub-double/2addr v0, v2

    mul-double/2addr v0, v0

    .line 135
    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;->mostDistantNeighborSq:D

    cmpg-double v2, v0, v2

    if-gtz v2, :cond_4

    .line 136
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size()I

    move-result v2

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;->searchN:I

    if-lt v2, v3, :cond_3

    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;->mostDistantNeighborSq:D

    cmpg-double v0, v0, v2

    if-gez v0, :cond_4

    .line 137
    :cond_3
    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;->stepClosest(Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;)V

    :cond_4
    :goto_1
    return-void
.end method


# virtual methods
.method public copy()Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearchN;
    .locals 2

    .line 99
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;->distance:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeDistance;

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;-><init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeDistance;)V

    return-object v0
.end method

.method public findNeighbor(Ljava/lang/Object;ILcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;)V
    .locals 1

    if-lez p2, :cond_1

    .line 87
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;->tree:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree;->root:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;

    if-nez v0, :cond_0

    return-void

    .line 90
    :cond_0
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;->searchN:I

    .line 91
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;->target:Ljava/lang/Object;

    .line 92
    iget-wide p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;->maxDistanceSq:D

    iput-wide p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;->mostDistantNeighborSq:D

    .line 94
    invoke-direct {p0, v0, p3}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;->stepClosest(Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;)V

    return-void

    .line 85
    :cond_1
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string p2, "I\'m sorry, but I refuse to search for less than or equal to 0 neighbors."

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public setMaxDistance(D)V
    .locals 0

    .line 72
    iput-wide p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;->maxDistanceSq:D

    return-void
.end method

.method public setTree(Ljava/lang/Object;)V
    .locals 0

    .line 61
    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree;

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;->tree:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree;

    return-void
.end method
