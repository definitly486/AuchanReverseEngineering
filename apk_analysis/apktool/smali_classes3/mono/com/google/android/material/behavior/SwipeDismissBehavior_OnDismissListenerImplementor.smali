.class public Lmono/com/google/android/material/behavior/SwipeDismissBehavior_OnDismissListenerImplementor;
.super Ljava/lang/Object;
.source "SwipeDismissBehavior_OnDismissListenerImplementor.java"

# interfaces
.implements Lmono/android/IGCUserPeer;
.implements Lcom/google/android/material/behavior/SwipeDismissBehavior$OnDismissListener;


# instance fields
.field private refList:Ljava/util/ArrayList;


# direct methods
.method public constructor <init>()V
    .locals 3

    .line 13
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 14
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lmono/com/google/android/material/behavior/SwipeDismissBehavior_OnDismissListenerImplementor;

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 15
    new-array v0, v0, [Ljava/lang/Object;

    const-string v1, "Google.Android.Material.Behavior.SwipeDismissBehavior+IOnDismissListenerImplementor, Xamarin.Google.Android.Material"

    const-string v2, ""

    invoke-static {v1, v2, p0, v0}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method private native n_onDismiss(Landroid/view/View;)V
.end method

.method private native n_onDragStateChanged(I)V
.end method


# virtual methods
.method public monodroidAddReference(Ljava/lang/Object;)V
    .locals 1

    .line 36
    iget-object v0, p0, Lmono/com/google/android/material/behavior/SwipeDismissBehavior_OnDismissListenerImplementor;->refList:Ljava/util/ArrayList;

    if-nez v0, :cond_0

    .line 37
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lmono/com/google/android/material/behavior/SwipeDismissBehavior_OnDismissListenerImplementor;->refList:Ljava/util/ArrayList;

    .line 38
    :cond_0
    iget-object v0, p0, Lmono/com/google/android/material/behavior/SwipeDismissBehavior_OnDismissListenerImplementor;->refList:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public monodroidClearReferences()V
    .locals 1

    .line 43
    iget-object v0, p0, Lmono/com/google/android/material/behavior/SwipeDismissBehavior_OnDismissListenerImplementor;->refList:Ljava/util/ArrayList;

    if-eqz v0, :cond_0

    .line 44
    invoke-virtual {v0}, Ljava/util/ArrayList;->clear()V

    :cond_0
    return-void
.end method

.method public onDismiss(Landroid/view/View;)V
    .locals 0

    .line 21
    invoke-direct {p0, p1}, Lmono/com/google/android/material/behavior/SwipeDismissBehavior_OnDismissListenerImplementor;->n_onDismiss(Landroid/view/View;)V

    return-void
.end method

.method public onDragStateChanged(I)V
    .locals 0

    .line 28
    invoke-direct {p0, p1}, Lmono/com/google/android/material/behavior/SwipeDismissBehavior_OnDismissListenerImplementor;->n_onDragStateChanged(I)V

    return-void
.end method
