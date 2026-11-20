.class public Lcrc64fac7521b55e1fcf3/SectionedGridDataObserver;
.super Landroidx/recyclerview/widget/RecyclerView$AdapterDataObserver;
.source "SectionedGridDataObserver.java"

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

    const-class v1, Lcrc64fac7521b55e1fcf3/SectionedGridDataObserver;

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 14
    new-array v0, v0, [Ljava/lang/Object;

    const-string v1, "Auchan.Android.Controls.SectionedGridDataObserver, Auchan.Android.Net"

    const-string v2, ""

    invoke-static {v1, v2, p0, v0}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

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

    .line 63
    iget-object v0, p0, Lcrc64fac7521b55e1fcf3/SectionedGridDataObserver;->refList:Ljava/util/ArrayList;

    if-nez v0, :cond_0

    .line 64
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcrc64fac7521b55e1fcf3/SectionedGridDataObserver;->refList:Ljava/util/ArrayList;

    .line 65
    :cond_0
    iget-object v0, p0, Lcrc64fac7521b55e1fcf3/SectionedGridDataObserver;->refList:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public monodroidClearReferences()V
    .locals 1

    .line 70
    iget-object v0, p0, Lcrc64fac7521b55e1fcf3/SectionedGridDataObserver;->refList:Ljava/util/ArrayList;

    if-eqz v0, :cond_0

    .line 71
    invoke-virtual {v0}, Ljava/util/ArrayList;->clear()V

    :cond_0
    return-void
.end method

.method public onChanged()V
    .locals 0

    .line 20
    invoke-direct {p0}, Lcrc64fac7521b55e1fcf3/SectionedGridDataObserver;->n_onChanged()V

    return-void
.end method

.method public onItemRangeChanged(II)V
    .locals 0

    .line 27
    invoke-direct {p0, p1, p2}, Lcrc64fac7521b55e1fcf3/SectionedGridDataObserver;->n_onItemRangeChanged(II)V

    return-void
.end method

.method public onItemRangeChanged(IILjava/lang/Object;)V
    .locals 0

    .line 34
    invoke-direct {p0, p1, p2, p3}, Lcrc64fac7521b55e1fcf3/SectionedGridDataObserver;->n_onItemRangeChanged(IILjava/lang/Object;)V

    return-void
.end method

.method public onItemRangeInserted(II)V
    .locals 0

    .line 41
    invoke-direct {p0, p1, p2}, Lcrc64fac7521b55e1fcf3/SectionedGridDataObserver;->n_onItemRangeInserted(II)V

    return-void
.end method

.method public onItemRangeMoved(III)V
    .locals 0

    .line 48
    invoke-direct {p0, p1, p2, p3}, Lcrc64fac7521b55e1fcf3/SectionedGridDataObserver;->n_onItemRangeMoved(III)V

    return-void
.end method

.method public onItemRangeRemoved(II)V
    .locals 0

    .line 55
    invoke-direct {p0, p1, p2}, Lcrc64fac7521b55e1fcf3/SectionedGridDataObserver;->n_onItemRangeRemoved(II)V

    return-void
.end method
