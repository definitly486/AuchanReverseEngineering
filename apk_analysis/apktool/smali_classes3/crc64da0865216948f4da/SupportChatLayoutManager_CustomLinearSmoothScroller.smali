.class public Lcrc64da0865216948f4da/SupportChatLayoutManager_CustomLinearSmoothScroller;
.super Landroidx/recyclerview/widget/LinearSmoothScroller;
.source "SupportChatLayoutManager_CustomLinearSmoothScroller.java"

# interfaces
.implements Lmono/android/IGCUserPeer;


# instance fields
.field private refList:Ljava/util/ArrayList;


# direct methods
.method public constructor <init>(Landroid/content/Context;)V
    .locals 2

    .line 12
    invoke-direct {p0, p1}, Landroidx/recyclerview/widget/LinearSmoothScroller;-><init>(Landroid/content/Context;)V

    .line 13
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc64da0865216948f4da/SupportChatLayoutManager_CustomLinearSmoothScroller;

    if-ne v0, v1, :cond_0

    .line 14
    const-string v0, "Android.Content.Context, Mono.Android"

    filled-new-array {p1}, [Ljava/lang/Object;

    move-result-object p1

    const-string v1, "Auchan.Android.SupportChat.SupportChatLayoutManager+CustomLinearSmoothScroller, Auchan.Android.Net"

    invoke-static {v1, v0, p0, p1}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method private native n_computeScrollVectorForPosition(I)Landroid/graphics/PointF;
.end method

.method private native n_getVerticalSnapPreference()I
.end method


# virtual methods
.method public computeScrollVectorForPosition(I)Landroid/graphics/PointF;
    .locals 0

    .line 20
    invoke-direct {p0, p1}, Lcrc64da0865216948f4da/SupportChatLayoutManager_CustomLinearSmoothScroller;->n_computeScrollVectorForPosition(I)Landroid/graphics/PointF;

    move-result-object p1

    return-object p1
.end method

.method public getVerticalSnapPreference()I
    .locals 1

    .line 27
    invoke-direct {p0}, Lcrc64da0865216948f4da/SupportChatLayoutManager_CustomLinearSmoothScroller;->n_getVerticalSnapPreference()I

    move-result v0

    return v0
.end method

.method public monodroidAddReference(Ljava/lang/Object;)V
    .locals 1

    .line 35
    iget-object v0, p0, Lcrc64da0865216948f4da/SupportChatLayoutManager_CustomLinearSmoothScroller;->refList:Ljava/util/ArrayList;

    if-nez v0, :cond_0

    .line 36
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcrc64da0865216948f4da/SupportChatLayoutManager_CustomLinearSmoothScroller;->refList:Ljava/util/ArrayList;

    .line 37
    :cond_0
    iget-object v0, p0, Lcrc64da0865216948f4da/SupportChatLayoutManager_CustomLinearSmoothScroller;->refList:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public monodroidClearReferences()V
    .locals 1

    .line 42
    iget-object v0, p0, Lcrc64da0865216948f4da/SupportChatLayoutManager_CustomLinearSmoothScroller;->refList:Ljava/util/ArrayList;

    if-eqz v0, :cond_0

    .line 43
    invoke-virtual {v0}, Ljava/util/ArrayList;->clear()V

    :cond_0
    return-void
.end method
