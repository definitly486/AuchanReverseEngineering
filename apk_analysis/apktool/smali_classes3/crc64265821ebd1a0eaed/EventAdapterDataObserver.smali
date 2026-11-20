.class public Lcrc64265821ebd1a0eaed/EventAdapterDataObserver;
.super Landroidx/recyclerview/widget/RecyclerView$AdapterDataObserver;
.source "EventAdapterDataObserver.java"

# interfaces
.implements Lmono/android/IGCUserPeer;


# instance fields
.field private refList:Ljava/util/ArrayList;


# direct methods
.method public constructor <init>()V
    .locals 3

    .line 12
    invoke-direct {p0}, Landroidx/recyclerview/widget/RecyclerView$AdapterDataObserver;-><init>()V

    .line 13
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc64265821ebd1a0eaed/EventAdapterDataObserver;

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 14
    new-array v0, v0, [Ljava/lang/Object;

    const-string v1, "ViewSparsedRecycler.EventAdapterDataObserver, Auchan.Android.Net"

    const-string v2, ""

    invoke-static {v1, v2, p0, v0}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method public constructor <init>(Landroidx/recyclerview/widget/RecyclerView$Adapter;)V
    .locals 2

    .line 20
    invoke-direct {p0}, Landroidx/recyclerview/widget/RecyclerView$AdapterDataObserver;-><init>()V

    .line 21
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc64265821ebd1a0eaed/EventAdapterDataObserver;

    if-ne v0, v1, :cond_0

    .line 22
    const-string v0, "AndroidX.RecyclerView.Widget.RecyclerView+Adapter, Xamarin.AndroidX.RecyclerView"

    filled-new-array {p1}, [Ljava/lang/Object;

    move-result-object p1

    const-string v1, "ViewSparsedRecycler.EventAdapterDataObserver, Auchan.Android.Net"

    invoke-static {v1, v0, p0, p1}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method private native n_onChanged()V
.end method

.method private native n_onItemRangeChanged(II)V
.end method

.method private native n_onItemRangeChanged(IILjava/lang/Object;)V
.end method

.method private native n_onItemRangeInserted(II)V
.end method

.method private native n_onItemRangeMoved(III)V
.end method

.method private native n_onItemRangeRemoved(II)V
.end method


# virtual methods
.method public monodroidAddReference(Ljava/lang/Object;)V
    .locals 1

    .line 71
    iget-object v0, p0, Lcrc64265821ebd1a0eaed/EventAdapterDataObserver;->refList:Ljava/util/ArrayList;

    if-nez v0, :cond_0

    .line 72
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcrc64265821ebd1a0eaed/EventAdapterDataObserver;->refList:Ljava/util/ArrayList;

    .line 73
    :cond_0
    iget-object v0, p0, Lcrc64265821ebd1a0eaed/EventAdapterDataObserver;->refList:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public monodroidClearReferences()V
    .locals 1

    .line 78
    iget-object v0, p0, Lcrc64265821ebd1a0eaed/EventAdapterDataObserver;->refList:Ljava/util/ArrayList;

    if-eqz v0, :cond_0

    .line 79
    invoke-virtual {v0}, Ljava/util/ArrayList;->clear()V

    :cond_0
    return-void
.end method

.method public onChanged()V
    .locals 0

    .line 28
    invoke-direct {p0}, Lcrc64265821ebd1a0eaed/EventAdapterDataObserver;->n_onChanged()V

    return-void
.end method

.method public onItemRangeChanged(II)V
    .locals 0

    .line 35
    invoke-direct {p0, p1, p2}, Lcrc64265821ebd1a0eaed/EventAdapterDataObserver;->n_onItemRangeChanged(II)V

    return-void
.end method

.method public onItemRangeChanged(IILjava/lang/Object;)V
    .locals 0

    .line 42
    invoke-direct {p0, p1, p2, p3}, Lcrc64265821ebd1a0eaed/EventAdapterDataObserver;->n_onItemRangeChanged(IILjava/lang/Object;)V

    return-void
.end method

.method public onItemRangeInserted(II)V
    .locals 0

    .line 49
    invoke-direct {p0, p1, p2}, Lcrc64265821ebd1a0eaed/EventAdapterDataObserver;->n_onItemRangeInserted(II)V

    return-void
.end method

.method public onItemRangeMoved(III)V
    .locals 0

    .line 56
    invoke-direct {p0, p1, p2, p3}, Lcrc64265821ebd1a0eaed/EventAdapterDataObserver;->n_onItemRangeMoved(III)V

    return-void
.end method

.method public onItemRangeRemoved(II)V
    .locals 0

    .line 63
    invoke-direct {p0, p1, p2}, Lcrc64265821ebd1a0eaed/EventAdapterDataObserver;->n_onItemRangeRemoved(II)V

    return-void
.end method
