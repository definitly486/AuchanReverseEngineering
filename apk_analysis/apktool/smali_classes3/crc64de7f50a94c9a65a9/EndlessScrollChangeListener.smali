.class public Lcrc64de7f50a94c9a65a9/EndlessScrollChangeListener;
.super Landroidx/recyclerview/widget/RecyclerView$OnScrollListener;
.source "EndlessScrollChangeListener.java"

# interfaces
.implements Lmono/android/IGCUserPeer;


# instance fields
.field private refList:Ljava/util/ArrayList;


# direct methods
.method public constructor <init>()V
    .locals 3

    .line 12
    invoke-direct {p0}, Landroidx/recyclerview/widget/RecyclerView$OnScrollListener;-><init>()V

    .line 13
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc64de7f50a94c9a65a9/EndlessScrollChangeListener;

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 14
    new-array v0, v0, [Ljava/lang/Object;

    const-string v1, "Auchan.Android.Recommendations.EndlessScrollChangeListener, Auchan.Android.Net"

    const-string v2, ""

    invoke-static {v1, v2, p0, v0}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method private native n_onScrolled(Landroidx/recyclerview/widget/RecyclerView;II)V
.end method


# virtual methods
.method public monodroidAddReference(Ljava/lang/Object;)V
    .locals 1

    .line 28
    iget-object v0, p0, Lcrc64de7f50a94c9a65a9/EndlessScrollChangeListener;->refList:Ljava/util/ArrayList;

    if-nez v0, :cond_0

    .line 29
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcrc64de7f50a94c9a65a9/EndlessScrollChangeListener;->refList:Ljava/util/ArrayList;

    .line 30
    :cond_0
    iget-object v0, p0, Lcrc64de7f50a94c9a65a9/EndlessScrollChangeListener;->refList:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public monodroidClearReferences()V
    .locals 1

    .line 35
    iget-object v0, p0, Lcrc64de7f50a94c9a65a9/EndlessScrollChangeListener;->refList:Ljava/util/ArrayList;

    if-eqz v0, :cond_0

    .line 36
    invoke-virtual {v0}, Ljava/util/ArrayList;->clear()V

    :cond_0
    return-void
.end method

.method public onScrolled(Landroidx/recyclerview/widget/RecyclerView;II)V
    .locals 0

    .line 20
    invoke-direct {p0, p1, p2, p3}, Lcrc64de7f50a94c9a65a9/EndlessScrollChangeListener;->n_onScrolled(Landroidx/recyclerview/widget/RecyclerView;II)V

    return-void
.end method
