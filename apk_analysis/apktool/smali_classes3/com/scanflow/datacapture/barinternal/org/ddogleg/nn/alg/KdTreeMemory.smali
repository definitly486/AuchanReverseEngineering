.class public Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeMemory;
.super Ljava/lang/Object;
.source "KdTreeMemory.java"


# instance fields
.field protected open:Ljava/util/List;

.field protected unusedNodes:Ljava/util/List;

.field protected unusedTrees:Ljava/util/List;


# direct methods
.method public constructor <init>()V
    .locals 1

    .line 29
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 32
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeMemory;->unusedNodes:Ljava/util/List;

    .line 33
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeMemory;->unusedTrees:Ljava/util/List;

    .line 36
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeMemory;->open:Ljava/util/List;

    return-void
.end method


# virtual methods
.method public recycle(Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;)V
    .locals 1

    const/4 v0, 0x0

    .line 70
    iput-object v0, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;->point:Ljava/lang/Object;

    .line 71
    iput-object v0, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;->left:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;

    .line 72
    iput-object v0, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;->right:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;

    .line 73
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeMemory;->unusedNodes:Ljava/util/List;

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public recycleGraph(Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree;)V
    .locals 3

    .line 77
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree;->root:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;

    if-eqz v0, :cond_3

    .line 79
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeMemory;->open:Ljava/util/List;

    invoke-interface {v1, v0}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 81
    :goto_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeMemory;->open:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->isEmpty()Z

    move-result v0

    if-nez v0, :cond_2

    .line 82
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeMemory;->open:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v1

    add-int/lit8 v1, v1, -0x1

    invoke-interface {v0, v1}, Ljava/util/List;->remove(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;

    .line 83
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;->left:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;

    if-eqz v1, :cond_0

    .line 84
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeMemory;->open:Ljava/util/List;

    invoke-interface {v2, v1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 85
    :cond_0
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;->right:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;

    if-eqz v1, :cond_1

    .line 86
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeMemory;->open:Ljava/util/List;

    invoke-interface {v2, v1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 88
    :cond_1
    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeMemory;->recycle(Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;)V

    goto :goto_0

    :cond_2
    const/4 v0, 0x0

    .line 91
    iput-object v0, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree;->root:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;

    .line 93
    :cond_3
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeMemory;->unusedTrees:Ljava/util/List;

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public requestNode()Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;
    .locals 2

    .line 42
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeMemory;->unusedNodes:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->isEmpty()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 43
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;-><init>()V

    return-object v0

    .line 44
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeMemory;->unusedNodes:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v1

    add-int/lit8 v1, v1, -0x1

    invoke-interface {v0, v1}, Ljava/util/List;->remove(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;

    return-object v0
.end method

.method public requestNode(Ljava/lang/Object;I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;
    .locals 1

    .line 52
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeMemory;->requestNode()Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;

    move-result-object v0

    .line 53
    iput-object p1, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;->point:Ljava/lang/Object;

    .line 54
    iput p2, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;->index:I

    const/4 p1, -0x1

    .line 55
    iput p1, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;->split:I

    return-object v0
.end method

.method public requestTree(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree;
    .locals 2

    .line 60
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeMemory;->unusedTrees:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->isEmpty()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 61
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree;

    invoke-direct {v0, p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree;-><init>(I)V

    return-object v0

    .line 62
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeMemory;->unusedTrees:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v1

    add-int/lit8 v1, v1, -0x1

    invoke-interface {v0, v1}, Ljava/util/List;->remove(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree;

    .line 63
    iput p1, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree;->N:I

    return-object v0
.end method
