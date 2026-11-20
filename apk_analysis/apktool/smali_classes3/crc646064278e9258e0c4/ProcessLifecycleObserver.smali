.class public Lcrc646064278e9258e0c4/ProcessLifecycleObserver;
.super Ljava/lang/Object;
.source "ProcessLifecycleObserver.java"

# interfaces
.implements Lmono/android/IGCUserPeer;
.implements Landroidx/lifecycle/DefaultLifecycleObserver;
.implements Landroidx/lifecycle/LifecycleObserver;


# instance fields
.field private refList:Ljava/util/ArrayList;


# direct methods
.method public constructor <init>()V
    .locals 3

    .line 14
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 15
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc646064278e9258e0c4/ProcessLifecycleObserver;

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 16
    new-array v0, v0, [Ljava/lang/Object;

    const-string v1, "Auchan.Android.Common.ProcessLifecycleObserver, Auchan.Android.Net"

    const-string v2, ""

    invoke-static {v1, v2, p0, v0}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method private native n_onCreate(Landroidx/lifecycle/LifecycleOwner;)V
.end method

.method private native n_onDestroy(Landroidx/lifecycle/LifecycleOwner;)V
.end method

.method private native n_onPause(Landroidx/lifecycle/LifecycleOwner;)V
.end method

.method private native n_onResume(Landroidx/lifecycle/LifecycleOwner;)V
.end method

.method private native n_onStart(Landroidx/lifecycle/LifecycleOwner;)V
.end method

.method private native n_onStop(Landroidx/lifecycle/LifecycleOwner;)V
.end method


# virtual methods
.method public monodroidAddReference(Ljava/lang/Object;)V
    .locals 1

    .line 65
    iget-object v0, p0, Lcrc646064278e9258e0c4/ProcessLifecycleObserver;->refList:Ljava/util/ArrayList;

    if-nez v0, :cond_0

    .line 66
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcrc646064278e9258e0c4/ProcessLifecycleObserver;->refList:Ljava/util/ArrayList;

    .line 67
    :cond_0
    iget-object v0, p0, Lcrc646064278e9258e0c4/ProcessLifecycleObserver;->refList:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public monodroidClearReferences()V
    .locals 1

    .line 72
    iget-object v0, p0, Lcrc646064278e9258e0c4/ProcessLifecycleObserver;->refList:Ljava/util/ArrayList;

    if-eqz v0, :cond_0

    .line 73
    invoke-virtual {v0}, Ljava/util/ArrayList;->clear()V

    :cond_0
    return-void
.end method

.method public onCreate(Landroidx/lifecycle/LifecycleOwner;)V
    .locals 0

    .line 22
    invoke-direct {p0, p1}, Lcrc646064278e9258e0c4/ProcessLifecycleObserver;->n_onCreate(Landroidx/lifecycle/LifecycleOwner;)V

    return-void
.end method

.method public onDestroy(Landroidx/lifecycle/LifecycleOwner;)V
    .locals 0

    .line 29
    invoke-direct {p0, p1}, Lcrc646064278e9258e0c4/ProcessLifecycleObserver;->n_onDestroy(Landroidx/lifecycle/LifecycleOwner;)V

    return-void
.end method

.method public onPause(Landroidx/lifecycle/LifecycleOwner;)V
    .locals 0

    .line 36
    invoke-direct {p0, p1}, Lcrc646064278e9258e0c4/ProcessLifecycleObserver;->n_onPause(Landroidx/lifecycle/LifecycleOwner;)V

    return-void
.end method

.method public onResume(Landroidx/lifecycle/LifecycleOwner;)V
    .locals 0

    .line 43
    invoke-direct {p0, p1}, Lcrc646064278e9258e0c4/ProcessLifecycleObserver;->n_onResume(Landroidx/lifecycle/LifecycleOwner;)V

    return-void
.end method

.method public onStart(Landroidx/lifecycle/LifecycleOwner;)V
    .locals 0

    .line 50
    invoke-direct {p0, p1}, Lcrc646064278e9258e0c4/ProcessLifecycleObserver;->n_onStart(Landroidx/lifecycle/LifecycleOwner;)V

    return-void
.end method

.method public onStop(Landroidx/lifecycle/LifecycleOwner;)V
    .locals 0

    .line 57
    invoke-direct {p0, p1}, Lcrc646064278e9258e0c4/ProcessLifecycleObserver;->n_onStop(Landroidx/lifecycle/LifecycleOwner;)V

    return-void
.end method
