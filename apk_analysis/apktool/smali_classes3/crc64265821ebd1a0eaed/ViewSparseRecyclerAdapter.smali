.class public Lcrc64265821ebd1a0eaed/ViewSparseRecyclerAdapter;
.super Landroidx/recyclerview/widget/RecyclerView$Adapter;
.source "ViewSparseRecyclerAdapter.java"

# interfaces
.implements Lmono/android/IGCUserPeer;


# instance fields
.field private refList:Ljava/util/ArrayList;


# direct methods
.method public constructor <init>()V
    .locals 3

    .line 12
    invoke-direct {p0}, Landroidx/recyclerview/widget/RecyclerView$Adapter;-><init>()V

    .line 13
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc64265821ebd1a0eaed/ViewSparseRecyclerAdapter;

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 14
    new-array v0, v0, [Ljava/lang/Object;

    const-string v1, "ViewSparsedRecycler.ViewSparseRecyclerAdapter, Auchan.Android.Net"

    const-string v2, ""

    invoke-static {v1, v2, p0, v0}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method public constructor <init>(Landroidx/recyclerview/widget/RecyclerView$Adapter;)V
    .locals 2

    .line 20
    invoke-direct {p0}, Landroidx/recyclerview/widget/RecyclerView$Adapter;-><init>()V

    .line 21
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc64265821ebd1a0eaed/ViewSparseRecyclerAdapter;

    if-ne v0, v1, :cond_0

    .line 22
    const-string v0, "AndroidX.RecyclerView.Widget.RecyclerView+Adapter, Xamarin.AndroidX.RecyclerView"

    filled-new-array {p1}, [Ljava/lang/Object;

    move-result-object p1

    const-string v1, "ViewSparsedRecycler.ViewSparseRecyclerAdapter, Auchan.Android.Net"

    invoke-static {v1, v0, p0, p1}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method private native n_getItemCount()I
.end method

.method private native n_getItemId(I)J
.end method

.method private native n_getItemViewType(I)I
.end method

.method private native n_onAttachedToRecyclerView(Landroidx/recyclerview/widget/RecyclerView;)V
.end method

.method private native n_onBindViewHolder(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;I)V
.end method

.method private native n_onBindViewHolder(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;ILjava/util/List;)V
.end method

.method private native n_onCreateViewHolder(Landroid/view/ViewGroup;I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;
.end method

.method private native n_onDetachedFromRecyclerView(Landroidx/recyclerview/widget/RecyclerView;)V
.end method

.method private native n_onFailedToRecycleView(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)Z
.end method

.method private native n_onViewAttachedToWindow(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V
.end method

.method private native n_onViewDetachedFromWindow(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V
.end method

.method private native n_onViewRecycled(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V
.end method

.method private native n_registerAdapterDataObserver(Landroidx/recyclerview/widget/RecyclerView$AdapterDataObserver;)V
.end method

.method private native n_unregisterAdapterDataObserver(Landroidx/recyclerview/widget/RecyclerView$AdapterDataObserver;)V
.end method


# virtual methods
.method public getItemCount()I
    .locals 1

    .line 28
    invoke-direct {p0}, Lcrc64265821ebd1a0eaed/ViewSparseRecyclerAdapter;->n_getItemCount()I

    move-result v0

    return v0
.end method

.method public getItemId(I)J
    .locals 2

    .line 35
    invoke-direct {p0, p1}, Lcrc64265821ebd1a0eaed/ViewSparseRecyclerAdapter;->n_getItemId(I)J

    move-result-wide v0

    return-wide v0
.end method

.method public getItemViewType(I)I
    .locals 0

    .line 42
    invoke-direct {p0, p1}, Lcrc64265821ebd1a0eaed/ViewSparseRecyclerAdapter;->n_getItemViewType(I)I

    move-result p1

    return p1
.end method

.method public monodroidAddReference(Ljava/lang/Object;)V
    .locals 1

    .line 127
    iget-object v0, p0, Lcrc64265821ebd1a0eaed/ViewSparseRecyclerAdapter;->refList:Ljava/util/ArrayList;

    if-nez v0, :cond_0

    .line 128
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcrc64265821ebd1a0eaed/ViewSparseRecyclerAdapter;->refList:Ljava/util/ArrayList;

    .line 129
    :cond_0
    iget-object v0, p0, Lcrc64265821ebd1a0eaed/ViewSparseRecyclerAdapter;->refList:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public monodroidClearReferences()V
    .locals 1

    .line 134
    iget-object v0, p0, Lcrc64265821ebd1a0eaed/ViewSparseRecyclerAdapter;->refList:Ljava/util/ArrayList;

    if-eqz v0, :cond_0

    .line 135
    invoke-virtual {v0}, Ljava/util/ArrayList;->clear()V

    :cond_0
    return-void
.end method

.method public onAttachedToRecyclerView(Landroidx/recyclerview/widget/RecyclerView;)V
    .locals 0

    .line 49
    invoke-direct {p0, p1}, Lcrc64265821ebd1a0eaed/ViewSparseRecyclerAdapter;->n_onAttachedToRecyclerView(Landroidx/recyclerview/widget/RecyclerView;)V

    return-void
.end method

.method public onBindViewHolder(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;I)V
    .locals 0

    .line 56
    invoke-direct {p0, p1, p2}, Lcrc64265821ebd1a0eaed/ViewSparseRecyclerAdapter;->n_onBindViewHolder(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;I)V

    return-void
.end method

.method public onBindViewHolder(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;ILjava/util/List;)V
    .locals 0

    .line 63
    invoke-direct {p0, p1, p2, p3}, Lcrc64265821ebd1a0eaed/ViewSparseRecyclerAdapter;->n_onBindViewHolder(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;ILjava/util/List;)V

    return-void
.end method

.method public onCreateViewHolder(Landroid/view/ViewGroup;I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;
    .locals 0

    .line 70
    invoke-direct {p0, p1, p2}, Lcrc64265821ebd1a0eaed/ViewSparseRecyclerAdapter;->n_onCreateViewHolder(Landroid/view/ViewGroup;I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;

    move-result-object p1

    return-object p1
.end method

.method public onDetachedFromRecyclerView(Landroidx/recyclerview/widget/RecyclerView;)V
    .locals 0

    .line 77
    invoke-direct {p0, p1}, Lcrc64265821ebd1a0eaed/ViewSparseRecyclerAdapter;->n_onDetachedFromRecyclerView(Landroidx/recyclerview/widget/RecyclerView;)V

    return-void
.end method

.method public onFailedToRecycleView(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)Z
    .locals 0

    .line 84
    invoke-direct {p0, p1}, Lcrc64265821ebd1a0eaed/ViewSparseRecyclerAdapter;->n_onFailedToRecycleView(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)Z

    move-result p1

    return p1
.end method

.method public onViewAttachedToWindow(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V
    .locals 0

    .line 91
    invoke-direct {p0, p1}, Lcrc64265821ebd1a0eaed/ViewSparseRecyclerAdapter;->n_onViewAttachedToWindow(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V

    return-void
.end method

.method public onViewDetachedFromWindow(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V
    .locals 0

    .line 98
    invoke-direct {p0, p1}, Lcrc64265821ebd1a0eaed/ViewSparseRecyclerAdapter;->n_onViewDetachedFromWindow(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V

    return-void
.end method

.method public onViewRecycled(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V
    .locals 0

    .line 105
    invoke-direct {p0, p1}, Lcrc64265821ebd1a0eaed/ViewSparseRecyclerAdapter;->n_onViewRecycled(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V

    return-void
.end method

.method public registerAdapterDataObserver(Landroidx/recyclerview/widget/RecyclerView$AdapterDataObserver;)V
    .locals 0

    .line 112
    invoke-direct {p0, p1}, Lcrc64265821ebd1a0eaed/ViewSparseRecyclerAdapter;->n_registerAdapterDataObserver(Landroidx/recyclerview/widget/RecyclerView$AdapterDataObserver;)V

    return-void
.end method

.method public unregisterAdapterDataObserver(Landroidx/recyclerview/widget/RecyclerView$AdapterDataObserver;)V
    .locals 0

    .line 119
    invoke-direct {p0, p1}, Lcrc64265821ebd1a0eaed/ViewSparseRecyclerAdapter;->n_unregisterAdapterDataObserver(Landroidx/recyclerview/widget/RecyclerView$AdapterDataObserver;)V

    return-void
.end method
