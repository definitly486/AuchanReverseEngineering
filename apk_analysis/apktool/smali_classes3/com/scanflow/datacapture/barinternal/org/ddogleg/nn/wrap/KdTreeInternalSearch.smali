.class public abstract Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeInternalSearch;
.super Ljava/lang/Object;
.source "KdTreeInternalSearch.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/NearestNeighbor$Search;


# instance fields
.field found:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

.field search1:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearch1;

.field searchN:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearchN;


# direct methods
.method constructor <init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearch1;Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearchN;)V
    .locals 2

    .line 40
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 37
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeInternalSearch$$ExternalSyntheticLambda0;

    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeInternalSearch$$ExternalSyntheticLambda0;-><init>()V

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;-><init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/Factory;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeInternalSearch;->found:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 41
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeInternalSearch;->search1:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearch1;

    .line 42
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeInternalSearch;->searchN:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearchN;

    return-void
.end method


# virtual methods
.method public findNearest(Ljava/lang/Object;DILcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;)V
    .locals 2

    .line 70
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeInternalSearch;->setTree()V

    .line 71
    invoke-virtual {p5}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    const-wide/16 v0, 0x0

    cmpg-double v0, p2, v0

    if-gtz v0, :cond_0

    .line 73
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeInternalSearch;->searchN:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearchN;

    const-wide v0, 0x7fefffffffffffffL    # Double.MAX_VALUE

    invoke-interface {p2, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearchN;->setMaxDistance(D)V

    goto :goto_0

    .line 75
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeInternalSearch;->searchN:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearchN;

    invoke-interface {v0, p2, p3}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearchN;->setMaxDistance(D)V

    .line 77
    :goto_0
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeInternalSearch;->found:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 78
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeInternalSearch;->searchN:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearchN;

    iget-object p3, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeInternalSearch;->found:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-interface {p2, p1, p4, p3}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearchN;->findNeighbor(Ljava/lang/Object;ILcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;)V

    const/4 p1, 0x0

    .line 80
    :goto_1
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeInternalSearch;->found:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    iget p3, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    if-ge p1, p3, :cond_1

    .line 81
    invoke-virtual {p2, p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->get(I)Ljava/lang/Object;

    move-result-object p2

    check-cast p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeResult;

    .line 82
    invoke-virtual {p5}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->grow()Ljava/lang/Object;

    move-result-object p3

    check-cast p3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/NnData;

    .line 84
    iget-object p4, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeResult;->node:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;

    iget-object v0, p4, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;->point:Ljava/lang/Object;

    iput-object v0, p3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/NnData;->point:Ljava/lang/Object;

    .line 85
    iget p4, p4, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;->index:I

    iput p4, p3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/NnData;->index:I

    .line 86
    iget-wide v0, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeResult;->distance:D

    iput-wide v0, p3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/NnData;->distance:D

    add-int/lit8 p1, p1, 0x1

    goto :goto_1

    :cond_1
    return-void
.end method

.method abstract setTree()V
.end method
