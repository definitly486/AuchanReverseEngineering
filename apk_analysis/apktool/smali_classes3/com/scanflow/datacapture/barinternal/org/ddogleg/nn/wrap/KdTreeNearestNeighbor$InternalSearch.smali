.class Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeNearestNeighbor$InternalSearch;
.super Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeInternalSearch;
.source "KdTreeNearestNeighbor.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeNearestNeighbor;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x2
    name = "InternalSearch"
.end annotation


# instance fields
.field final synthetic this$0:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeNearestNeighbor;


# direct methods
.method constructor <init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeNearestNeighbor;Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearch1;Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearchN;)V
    .locals 0

    .line 75
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeNearestNeighbor$InternalSearch;->this$0:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeNearestNeighbor;

    .line 76
    invoke-direct {p0, p2, p3}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeInternalSearch;-><init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearch1;Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearchN;)V

    return-void
.end method


# virtual methods
.method setTree()V
    .locals 2

    .line 81
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeInternalSearch;->search1:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearch1;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeNearestNeighbor$InternalSearch;->this$0:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeNearestNeighbor;

    iget-object v1, v1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeNearestNeighbor;->tree:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree;

    invoke-interface {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearch1;->setTree(Ljava/lang/Object;)V

    .line 82
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeInternalSearch;->searchN:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearchN;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeNearestNeighbor$InternalSearch;->this$0:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeNearestNeighbor;

    iget-object v1, v1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeNearestNeighbor;->tree:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree;

    invoke-interface {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearchN;->setTree(Ljava/lang/Object;)V

    return-void
.end method
