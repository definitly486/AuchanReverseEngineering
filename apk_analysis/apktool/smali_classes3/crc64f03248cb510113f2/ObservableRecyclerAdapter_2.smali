.class public Lcrc64f03248cb510113f2/ObservableRecyclerAdapter_2;
.super Landroidx/recyclerview/widget/RecyclerView$Adapter;
.source "ObservableRecyclerAdapter_2.java"

# interfaces
.implements Lmono/android/IGCUserPeer;
.implements Landroidx/lifecycle/LifecycleEventObserver;
.implements Landroidx/lifecycle/LifecycleObserver;
.implements Landroid/view/View$OnAttachStateChangeListener;


# instance fields
.field private refList:Ljava/util/ArrayList;


# direct methods
.method public constructor <init>()V
    .locals 3

    .line 15
    invoke-direct {p0}, Landroidx/recyclerview/widget/RecyclerView$Adapter;-><init>()V

    .line 16
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc64f03248cb510113f2/ObservableRecyclerAdapter_2;

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 17
    new-array v0, v0, [Ljava/lang/Object;

    const-string v1, "Auchan.Android.Base.ObservableRecyclerAdapter`2, Auchan.Android.Net"

    const-string v2, ""

    invoke-static {v1, v2, p0, v0}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

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

.method private native n_onCreateViewHolder(Landroid/view/ViewGroup;I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;
.end method

.method private native n_onDetachedFromRecyclerView(Landroidx/recyclerview/widget/RecyclerView;)V
.end method

.method private native n_onStateChanged(Landroidx/lifecycle/LifecycleOwner;Landroidx/lifecycle/Lifecycle$Event;)V
.end method

.method private native n_onViewAttachedToWindow(Landroid/view/View;)V
.end method

.method private native n_onViewDetachedFromWindow(Landroid/view/View;)V
.end method

.method private native n_onViewRecycled(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V
.end method


# virtual methods
.method public getItemCount()I
    .locals 1

    .line 23
    invoke-direct {p0}, Lcrc64f03248cb510113f2/ObservableRecyclerAdapter_2;->n_getItemCount()I

    move-result v0

    return v0
.end method

.method public getItemId(I)J
    .locals 2

    .line 30
    invoke-direct {p0, p1}, Lcrc64f03248cb510113f2/ObservableRecyclerAdapter_2;->n_getItemId(I)J

    move-result-wide v0

    return-wide v0
.end method

.method public getItemViewType(I)I
    .locals 0

    .line 51
    invoke-direct {p0, p1}, Lcrc64f03248cb510113f2/ObservableRecyclerAdapter_2;->n_getItemViewType(I)I

    move-result p1

    return p1
.end method

.method public monodroidAddReference(Ljava/lang/Object;)V
    .locals 1

    .line 101
    iget-object v0, p0, Lcrc64f03248cb510113f2/ObservableRecyclerAdapter_2;->refList:Ljava/util/ArrayList;

    if-nez v0, :cond_0

    .line 102
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcrc64f03248cb510113f2/ObservableRecyclerAdapter_2;->refList:Ljava/util/ArrayList;

    .line 103
    :cond_0
    iget-object v0, p0, Lcrc64f03248cb510113f2/ObservableRecyclerAdapter_2;->refList:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public monodroidClearReferences()V
    .locals 1

    .line 108
    iget-object v0, p0, Lcrc64f03248cb510113f2/ObservableRecyclerAdapter_2;->refList:Ljava/util/ArrayList;

    if-eqz v0, :cond_0

    .line 109
    invoke-virtual {v0}, Ljava/util/ArrayList;->clear()V

    :cond_0
    return-void
.end method

.method public onAttachedToRecyclerView(Landroidx/recyclerview/widget/RecyclerView;)V
    .locals 0

    .line 65
    invoke-direct {p0, p1}, Lcrc64f03248cb510113f2/ObservableRecyclerAdapter_2;->n_onAttachedToRecyclerView(Landroidx/recyclerview/widget/RecyclerView;)V

    return-void
.end method

.method public onBindViewHolder(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;I)V
    .locals 0

    .line 44
    invoke-direct {p0, p1, p2}, Lcrc64f03248cb510113f2/ObservableRecyclerAdapter_2;->n_onBindViewHolder(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;I)V

    return-void
.end method

.method public onCreateViewHolder(Landroid/view/ViewGroup;I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;
    .locals 0

    .line 58
    invoke-direct {p0, p1, p2}, Lcrc64f03248cb510113f2/ObservableRecyclerAdapter_2;->n_onCreateViewHolder(Landroid/view/ViewGroup;I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;

    move-result-object p1

    return-object p1
.end method

.method public onDetachedFromRecyclerView(Landroidx/recyclerview/widget/RecyclerView;)V
    .locals 0

    .line 72
    invoke-direct {p0, p1}, Lcrc64f03248cb510113f2/ObservableRecyclerAdapter_2;->n_onDetachedFromRecyclerView(Landroidx/recyclerview/widget/RecyclerView;)V

    return-void
.end method

.method public onStateChanged(Landroidx/lifecycle/LifecycleOwner;Landroidx/lifecycle/Lifecycle$Event;)V
    .locals 0

    .line 79
    invoke-direct {p0, p1, p2}, Lcrc64f03248cb510113f2/ObservableRecyclerAdapter_2;->n_onStateChanged(Landroidx/lifecycle/LifecycleOwner;Landroidx/lifecycle/Lifecycle$Event;)V

    return-void
.end method

.method public onViewAttachedToWindow(Landroid/view/View;)V
    .locals 0

    .line 86
    invoke-direct {p0, p1}, Lcrc64f03248cb510113f2/ObservableRecyclerAdapter_2;->n_onViewAttachedToWindow(Landroid/view/View;)V

    return-void
.end method

.method public onViewDetachedFromWindow(Landroid/view/View;)V
    .locals 0

    .line 93
    invoke-direct {p0, p1}, Lcrc64f03248cb510113f2/ObservableRecyclerAdapter_2;->n_onViewDetachedFromWindow(Landroid/view/View;)V

    return-void
.end method

.method public onViewRecycled(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V
    .locals 0

    .line 37
    invoke-direct {p0, p1}, Lcrc64f03248cb510113f2/ObservableRecyclerAdapter_2;->n_onViewRecycled(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V

    return-void
.end method
