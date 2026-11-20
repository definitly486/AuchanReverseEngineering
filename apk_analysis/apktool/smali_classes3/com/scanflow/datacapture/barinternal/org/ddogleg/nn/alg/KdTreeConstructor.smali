.class public Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeConstructor;
.super Ljava/lang/Object;
.source "KdTreeConstructor.java"


# instance fields
.field memory:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeMemory;

.field splitter:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitter;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeMemory;Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitter;)V
    .locals 0

    .line 51
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 52
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeConstructor;->memory:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeMemory;

    .line 53
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeConstructor;->splitter:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitter;

    return-void
.end method

.method private createLeaf(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;
    .locals 2

    const/4 v0, 0x0

    if-nez p2, :cond_0

    const/4 p2, -0x1

    goto :goto_0

    .line 151
    :cond_0
    invoke-virtual {p2, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->get(I)I

    move-result p2

    .line 152
    :goto_0
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeConstructor;->memory:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeMemory;

    invoke-interface {p1, v0}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    invoke-virtual {v1, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeMemory;->requestNode(Ljava/lang/Object;I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;

    move-result-object p1

    return-object p1
.end method


# virtual methods
.method protected computeBranch(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;
    .locals 7

    .line 103
    new-instance v3, Ljava/util/ArrayList;

    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v0

    div-int/lit8 v0, v0, 0x2

    invoke-direct {v3, v0}, Ljava/util/ArrayList;-><init>(I)V

    .line 104
    new-instance v5, Ljava/util/ArrayList;

    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v0

    div-int/lit8 v0, v0, 0x2

    invoke-direct {v5, v0}, Ljava/util/ArrayList;-><init>(I)V

    if-nez p2, :cond_0

    const/4 v0, 0x0

    move-object v4, v0

    move-object v6, v4

    goto :goto_0

    .line 110
    :cond_0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v1

    div-int/lit8 v1, v1, 0x2

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;-><init>(I)V

    .line 111
    new-instance v1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v2

    div-int/lit8 v2, v2, 0x2

    invoke-direct {v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;-><init>(I)V

    move-object v4, v0

    move-object v6, v1

    .line 115
    :goto_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeConstructor;->splitter:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitter;

    move-object v1, p1

    move-object v2, p2

    invoke-interface/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitter;->splitData(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)V

    .line 118
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeConstructor;->memory:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeMemory;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeMemory;->requestNode()Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;

    move-result-object p1

    .line 120
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeConstructor;->splitter:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitter;

    invoke-interface {p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitter;->getSplitAxis()I

    move-result p2

    iput p2, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;->split:I

    .line 121
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeConstructor;->splitter:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitter;

    invoke-interface {p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitter;->getSplitPoint()Ljava/lang/Object;

    move-result-object p2

    iput-object p2, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;->point:Ljava/lang/Object;

    .line 122
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeConstructor;->splitter:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitter;

    invoke-interface {p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitter;->getSplitIndex()I

    move-result p2

    iput p2, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;->index:I

    .line 125
    invoke-virtual {p0, v3, v4}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeConstructor;->computeChild(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;

    move-result-object p2

    iput-object p2, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;->left:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;

    .line 128
    invoke-virtual {p0, v5, v6}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeConstructor;->computeChild(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;

    move-result-object p2

    iput-object p2, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;->right:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;

    return-object p1
.end method

.method protected computeChild(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;
    .locals 2

    .line 138
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v0

    if-nez v0, :cond_0

    const/4 p1, 0x0

    return-object p1

    .line 140
    :cond_0
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v0

    const/4 v1, 0x1

    if-ne v0, v1, :cond_1

    .line 141
    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeConstructor;->createLeaf(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;

    move-result-object p1

    return-object p1

    .line 143
    :cond_1
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeConstructor;->computeBranch(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;

    move-result-object p1

    return-object p1
.end method

.method public construct(Ljava/util/List;Z)Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree;
    .locals 3

    if-eqz p2, :cond_0

    .line 76
    new-instance p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-direct {p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;-><init>()V

    .line 77
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v0

    invoke-virtual {p2, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->resize(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    const/4 v0, 0x0

    .line 78
    :goto_0
    iget v1, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    if-ge v0, v1, :cond_1

    .line 79
    iget-object v1, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->data:[I

    aput v0, v1, v0

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    const/4 p2, 0x0

    .line 83
    :cond_1
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeConstructor;->memory:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeMemory;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeConstructor;->splitter:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitter;

    invoke-interface {v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitter;->getPointLength()I

    move-result v1

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeMemory;->requestTree(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree;

    move-result-object v0

    .line 85
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v1

    const/4 v2, 0x1

    if-ne v1, v2, :cond_2

    .line 86
    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeConstructor;->createLeaf(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;

    move-result-object p1

    iput-object p1, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree;->root:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;

    return-object v0

    .line 87
    :cond_2
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v1

    if-le v1, v2, :cond_3

    .line 88
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeConstructor;->computeBranch(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;

    move-result-object p1

    iput-object p1, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree;->root:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;

    :cond_3
    return-object v0
.end method
