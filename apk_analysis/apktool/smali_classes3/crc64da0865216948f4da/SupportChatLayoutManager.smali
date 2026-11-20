.class public Lcrc64da0865216948f4da/SupportChatLayoutManager;
.super Landroidx/recyclerview/widget/RecyclerView$LayoutManager;
.source "SupportChatLayoutManager.java"

# interfaces
.implements Lmono/android/IGCUserPeer;


# instance fields
.field private refList:Ljava/util/ArrayList;


# direct methods
.method public constructor <init>()V
    .locals 3

    .line 12
    invoke-direct {p0}, Landroidx/recyclerview/widget/RecyclerView$LayoutManager;-><init>()V

    .line 13
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc64da0865216948f4da/SupportChatLayoutManager;

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 14
    new-array v0, v0, [Ljava/lang/Object;

    const-string v1, "Auchan.Android.SupportChat.SupportChatLayoutManager, Auchan.Android.Net"

    const-string v2, ""

    invoke-static {v1, v2, p0, v0}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method public constructor <init>(Landroid/content/Context;)V
    .locals 2

    .line 20
    invoke-direct {p0}, Landroidx/recyclerview/widget/RecyclerView$LayoutManager;-><init>()V

    .line 21
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc64da0865216948f4da/SupportChatLayoutManager;

    if-ne v0, v1, :cond_0

    .line 22
    const-string v0, "Android.Content.Context, Mono.Android"

    filled-new-array {p1}, [Ljava/lang/Object;

    move-result-object p1

    const-string v1, "Auchan.Android.SupportChat.SupportChatLayoutManager, Auchan.Android.Net"

    invoke-static {v1, v0, p0, p1}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method private native n_canScrollHorizontally()Z
.end method

.method private native n_canScrollVertically()Z
.end method

.method private native n_generateDefaultLayoutParams()Landroidx/recyclerview/widget/RecyclerView$LayoutParams;
.end method

.method private native n_isAutoMeasureEnabled()Z
.end method

.method private native n_onLayoutChildren(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)V
.end method

.method private native n_scrollVerticallyBy(ILandroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)I
.end method

.method private native n_setAutoMeasureEnabled(Z)V
.end method

.method private native n_smoothScrollToPosition(Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$State;I)V
.end method


# virtual methods
.method public canScrollHorizontally()Z
    .locals 1

    .line 70
    invoke-direct {p0}, Lcrc64da0865216948f4da/SupportChatLayoutManager;->n_canScrollHorizontally()Z

    move-result v0

    return v0
.end method

.method public canScrollVertically()Z
    .locals 1

    .line 63
    invoke-direct {p0}, Lcrc64da0865216948f4da/SupportChatLayoutManager;->n_canScrollVertically()Z

    move-result v0

    return v0
.end method

.method public generateDefaultLayoutParams()Landroidx/recyclerview/widget/RecyclerView$LayoutParams;
    .locals 1

    .line 28
    invoke-direct {p0}, Lcrc64da0865216948f4da/SupportChatLayoutManager;->n_generateDefaultLayoutParams()Landroidx/recyclerview/widget/RecyclerView$LayoutParams;

    move-result-object v0

    return-object v0
.end method

.method public isAutoMeasureEnabled()Z
    .locals 1

    .line 35
    invoke-direct {p0}, Lcrc64da0865216948f4da/SupportChatLayoutManager;->n_isAutoMeasureEnabled()Z

    move-result v0

    return v0
.end method

.method public monodroidAddReference(Ljava/lang/Object;)V
    .locals 1

    .line 85
    iget-object v0, p0, Lcrc64da0865216948f4da/SupportChatLayoutManager;->refList:Ljava/util/ArrayList;

    if-nez v0, :cond_0

    .line 86
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcrc64da0865216948f4da/SupportChatLayoutManager;->refList:Ljava/util/ArrayList;

    .line 87
    :cond_0
    iget-object v0, p0, Lcrc64da0865216948f4da/SupportChatLayoutManager;->refList:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public monodroidClearReferences()V
    .locals 1

    .line 92
    iget-object v0, p0, Lcrc64da0865216948f4da/SupportChatLayoutManager;->refList:Ljava/util/ArrayList;

    if-eqz v0, :cond_0

    .line 93
    invoke-virtual {v0}, Ljava/util/ArrayList;->clear()V

    :cond_0
    return-void
.end method

.method public onLayoutChildren(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)V
    .locals 0

    .line 49
    invoke-direct {p0, p1, p2}, Lcrc64da0865216948f4da/SupportChatLayoutManager;->n_onLayoutChildren(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)V

    return-void
.end method

.method public scrollVerticallyBy(ILandroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)I
    .locals 0

    .line 77
    invoke-direct {p0, p1, p2, p3}, Lcrc64da0865216948f4da/SupportChatLayoutManager;->n_scrollVerticallyBy(ILandroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)I

    move-result p1

    return p1
.end method

.method public setAutoMeasureEnabled(Z)V
    .locals 0

    .line 42
    invoke-direct {p0, p1}, Lcrc64da0865216948f4da/SupportChatLayoutManager;->n_setAutoMeasureEnabled(Z)V

    return-void
.end method

.method public smoothScrollToPosition(Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$State;I)V
    .locals 0

    .line 56
    invoke-direct {p0, p1, p2, p3}, Lcrc64da0865216948f4da/SupportChatLayoutManager;->n_smoothScrollToPosition(Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$State;I)V

    return-void
.end method
