.class public Lcrc64f40001e2c9184636/AutoLayoutRecyclerAdapter;
.super Landroidx/recyclerview/widget/RecyclerView$Adapter;
.source "AutoLayoutRecyclerAdapter.java"

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

    const-class v1, Lcrc64f40001e2c9184636/AutoLayoutRecyclerAdapter;

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 14
    new-array v0, v0, [Ljava/lang/Object;

    const-string v1, "Auchan.Android.Controls.AutoLayout.AutoLayoutRecyclerAdapter, Auchan.Android.Net"

    const-string v2, ""

    invoke-static {v1, v2, p0, v0}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method private native n_getItemCount()I
.end method

.method private native n_getItemViewType(I)I
.end method

.method private native n_onAttachedToRecyclerView(Landroidx/recyclerview/widget/RecyclerView;)V
.end method

.method private native n_onBindViewHolder(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;I)V
.end method

.method private native n_onCreateViewHolder(Landroid/view/ViewGroup;I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;
.end method

.method private native n_onDetachedFromRecyclerView(Landroidx/recyclerview/widget/RecyclerView;)V
.end method

.method private native n_onViewRecycled(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V
.end method


# virtual methods
.method public getItemCount()I
    .locals 1

    .line 20
    invoke-direct {p0}, Lcrc64f40001e2c9184636/AutoLayoutRecyclerAdapter;->n_getItemCount()I

    move-result v0

    return v0
.end method

.method public getItemViewType(I)I
    .locals 0

    .line 34
    invoke-direct {p0, p1}, Lcrc64f40001e2c9184636/AutoLayoutRecyclerAdapter;->n_getItemViewType(I)I

    move-result p1

    return p1
.end method

.method public monodroidAddReference(Ljava/lang/Object;)V
    .locals 1

    .line 70
    iget-object v0, p0, Lcrc64f40001e2c9184636/AutoLayoutRecyclerAdapter;->refList:Ljava/util/ArrayList;

    if-nez v0, :cond_0

    .line 71
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcrc64f40001e2c9184636/AutoLayoutRecyclerAdapter;->refList:Ljava/util/ArrayList;

    .line 72
    :cond_0
    iget-object v0, p0, Lcrc64f40001e2c9184636/AutoLayoutRecyclerAdapter;->refList:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public monodroidClearReferences()V
    .locals 1

    .line 77
    iget-object v0, p0, Lcrc64f40001e2c9184636/AutoLayoutRecyclerAdapter;->refList:Ljava/util/ArrayList;

    if-eqz v0, :cond_0

    .line 78
    invoke-virtual {v0}, Ljava/util/ArrayList;->clear()V

    :cond_0
    return-void
.end method

.method public onAttachedToRecyclerView(Landroidx/recyclerview/widget/RecyclerView;)V
    .locals 0

    .line 48
    invoke-direct {p0, p1}, Lcrc64f40001e2c9184636/AutoLayoutRecyclerAdapter;->n_onAttachedToRecyclerView(Landroidx/recyclerview/widget/RecyclerView;)V

    return-void
.end method

.method public onBindViewHolder(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;I)V
    .locals 0

    .line 27
    invoke-direct {p0, p1, p2}, Lcrc64f40001e2c9184636/AutoLayoutRecyclerAdapter;->n_onBindViewHolder(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;I)V

    return-void
.end method

.method public onCreateViewHolder(Landroid/view/ViewGroup;I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;
    .locals 0

    .line 41
    invoke-direct {p0, p1, p2}, Lcrc64f40001e2c9184636/AutoLayoutRecyclerAdapter;->n_onCreateViewHolder(Landroid/view/ViewGroup;I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;

    move-result-object p1

    return-object p1
.end method

.method public onDetachedFromRecyclerView(Landroidx/recyclerview/widget/RecyclerView;)V
    .locals 0

    .line 55
    invoke-direct {p0, p1}, Lcrc64f40001e2c9184636/AutoLayoutRecyclerAdapter;->n_onDetachedFromRecyclerView(Landroidx/recyclerview/widget/RecyclerView;)V

    return-void
.end method

.method public onViewRecycled(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V
    .locals 0

    .line 62
    invoke-direct {p0, p1}, Lcrc64f40001e2c9184636/AutoLayoutRecyclerAdapter;->n_onViewRecycled(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V

    return-void
.end method
