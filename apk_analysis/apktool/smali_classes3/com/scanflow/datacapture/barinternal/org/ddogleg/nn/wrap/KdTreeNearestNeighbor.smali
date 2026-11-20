.class public Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeNearestNeighbor;
.super Ljava/lang/Object;
.source "KdTreeNearestNeighbor.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/NearestNeighbor;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeNearestNeighbor$InternalSearch;
    }
.end annotation


# instance fields
.field constructor:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeConstructor;

.field memory:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeMemory;

.field search1:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearch1;

.field searchN:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearchN;

.field splitter:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitter;

.field tree:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeDistance;)V
    .locals 3

    .line 58
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearch1Standard;

    invoke-direct {v0, p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearch1Standard;-><init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeDistance;)V

    new-instance v1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;

    invoke-direct {v1, p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearchNStandard;-><init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeDistance;)V

    new-instance v2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;

    invoke-direct {v2, p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitterMedian;-><init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeDistance;)V

    invoke-direct {p0, v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeNearestNeighbor;-><init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearch1;Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearchN;Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitter;)V

    return-void
.end method

.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearch1;Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearchN;Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitter;)V
    .locals 1

    .line 50
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 48
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeMemory;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeMemory;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeNearestNeighbor;->memory:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeMemory;

    .line 51
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeNearestNeighbor;->search1:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearch1;

    .line 52
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeNearestNeighbor;->searchN:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearchN;

    .line 53
    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeNearestNeighbor;->splitter:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitter;

    .line 54
    new-instance p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeConstructor;

    invoke-direct {p1, v0, p3}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeConstructor;-><init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeMemory;Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitter;)V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeNearestNeighbor;->constructor:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeConstructor;

    return-void
.end method


# virtual methods
.method public createSearch()Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/NearestNeighbor$Search;
    .locals 3

    .line 70
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeNearestNeighbor$InternalSearch;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeNearestNeighbor;->search1:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearch1;

    invoke-interface {v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearch1;->copy()Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearch1;

    move-result-object v1

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeNearestNeighbor;->searchN:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearchN;

    invoke-interface {v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearchN;->copy()Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearchN;

    move-result-object v2

    invoke-direct {v0, p0, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeNearestNeighbor$InternalSearch;-><init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeNearestNeighbor;Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearch1;Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearchN;)V

    return-object v0
.end method

.method public setPoints(Ljava/util/List;Z)V
    .locals 2

    .line 63
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeNearestNeighbor;->tree:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree;

    if-eqz v0, :cond_0

    .line 64
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeNearestNeighbor;->memory:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeMemory;

    invoke-virtual {v1, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeMemory;->recycleGraph(Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree;)V

    .line 65
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeNearestNeighbor;->constructor:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeConstructor;

    invoke-virtual {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeConstructor;->construct(Ljava/util/List;Z)Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeNearestNeighbor;->tree:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree;

    return-void
.end method
