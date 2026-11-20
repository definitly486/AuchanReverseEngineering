.class public Lcrc64ba438d8f48cf7e75/ActivityLifecycleContextListener;
.super Ljava/lang/Object;
.source "ActivityLifecycleContextListener.java"

# interfaces
.implements Lmono/android/IGCUserPeer;
.implements Landroid/app/Application$ActivityLifecycleCallbacks;


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

    const-class v1, Lcrc64ba438d8f48cf7e75/ActivityLifecycleContextListener;

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 15
    new-array v0, v0, [Ljava/lang/Object;

    const-string v1, "Microsoft.Maui.ApplicationModel.ActivityLifecycleContextListener, Microsoft.Maui.Essentials"

    const-string v2, ""

    invoke-static {v1, v2, p0, v0}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method private native n_onActivityCreated(Landroid/app/Activity;Landroid/os/Bundle;)V
.end method

.method private native n_onActivityDestroyed(Landroid/app/Activity;)V
.end method

.method private native n_onActivityPaused(Landroid/app/Activity;)V
.end method

.method private native n_onActivityPostCreated(Landroid/app/Activity;Landroid/os/Bundle;)V
.end method

.method private native n_onActivityPostDestroyed(Landroid/app/Activity;)V
.end method

.method private native n_onActivityPostPaused(Landroid/app/Activity;)V
.end method

.method private native n_onActivityPostResumed(Landroid/app/Activity;)V
.end method

.method private native n_onActivityPostSaveInstanceState(Landroid/app/Activity;Landroid/os/Bundle;)V
.end method

.method private native n_onActivityPostStarted(Landroid/app/Activity;)V
.end method

.method private native n_onActivityPostStopped(Landroid/app/Activity;)V
.end method

.method private native n_onActivityPreCreated(Landroid/app/Activity;Landroid/os/Bundle;)V
.end method

.method private native n_onActivityPreDestroyed(Landroid/app/Activity;)V
.end method

.method private native n_onActivityPrePaused(Landroid/app/Activity;)V
.end method

.method private native n_onActivityPreResumed(Landroid/app/Activity;)V
.end method

.method private native n_onActivityPreSaveInstanceState(Landroid/app/Activity;Landroid/os/Bundle;)V
.end method

.method private native n_onActivityPreStarted(Landroid/app/Activity;)V
.end method

.method private native n_onActivityPreStopped(Landroid/app/Activity;)V
.end method

.method private native n_onActivityResumed(Landroid/app/Activity;)V
.end method

.method private native n_onActivitySaveInstanceState(Landroid/app/Activity;Landroid/os/Bundle;)V
.end method

.method private native n_onActivityStarted(Landroid/app/Activity;)V
.end method

.method private native n_onActivityStopped(Landroid/app/Activity;)V
.end method


# virtual methods
.method public monodroidAddReference(Ljava/lang/Object;)V
    .locals 1

    .line 169
    iget-object v0, p0, Lcrc64ba438d8f48cf7e75/ActivityLifecycleContextListener;->refList:Ljava/util/ArrayList;

    if-nez v0, :cond_0

    .line 170
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcrc64ba438d8f48cf7e75/ActivityLifecycleContextListener;->refList:Ljava/util/ArrayList;

    .line 171
    :cond_0
    iget-object v0, p0, Lcrc64ba438d8f48cf7e75/ActivityLifecycleContextListener;->refList:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public monodroidClearReferences()V
    .locals 1

    .line 176
    iget-object v0, p0, Lcrc64ba438d8f48cf7e75/ActivityLifecycleContextListener;->refList:Ljava/util/ArrayList;

    if-eqz v0, :cond_0

    .line 177
    invoke-virtual {v0}, Ljava/util/ArrayList;->clear()V

    :cond_0
    return-void
.end method

.method public onActivityCreated(Landroid/app/Activity;Landroid/os/Bundle;)V
    .locals 0

    .line 21
    invoke-direct {p0, p1, p2}, Lcrc64ba438d8f48cf7e75/ActivityLifecycleContextListener;->n_onActivityCreated(Landroid/app/Activity;Landroid/os/Bundle;)V

    return-void
.end method

.method public onActivityDestroyed(Landroid/app/Activity;)V
    .locals 0

    .line 28
    invoke-direct {p0, p1}, Lcrc64ba438d8f48cf7e75/ActivityLifecycleContextListener;->n_onActivityDestroyed(Landroid/app/Activity;)V

    return-void
.end method

.method public onActivityPaused(Landroid/app/Activity;)V
    .locals 0

    .line 35
    invoke-direct {p0, p1}, Lcrc64ba438d8f48cf7e75/ActivityLifecycleContextListener;->n_onActivityPaused(Landroid/app/Activity;)V

    return-void
.end method

.method public onActivityPostCreated(Landroid/app/Activity;Landroid/os/Bundle;)V
    .locals 0

    .line 70
    invoke-direct {p0, p1, p2}, Lcrc64ba438d8f48cf7e75/ActivityLifecycleContextListener;->n_onActivityPostCreated(Landroid/app/Activity;Landroid/os/Bundle;)V

    return-void
.end method

.method public onActivityPostDestroyed(Landroid/app/Activity;)V
    .locals 0

    .line 77
    invoke-direct {p0, p1}, Lcrc64ba438d8f48cf7e75/ActivityLifecycleContextListener;->n_onActivityPostDestroyed(Landroid/app/Activity;)V

    return-void
.end method

.method public onActivityPostPaused(Landroid/app/Activity;)V
    .locals 0

    .line 84
    invoke-direct {p0, p1}, Lcrc64ba438d8f48cf7e75/ActivityLifecycleContextListener;->n_onActivityPostPaused(Landroid/app/Activity;)V

    return-void
.end method

.method public onActivityPostResumed(Landroid/app/Activity;)V
    .locals 0

    .line 91
    invoke-direct {p0, p1}, Lcrc64ba438d8f48cf7e75/ActivityLifecycleContextListener;->n_onActivityPostResumed(Landroid/app/Activity;)V

    return-void
.end method

.method public onActivityPostSaveInstanceState(Landroid/app/Activity;Landroid/os/Bundle;)V
    .locals 0

    .line 98
    invoke-direct {p0, p1, p2}, Lcrc64ba438d8f48cf7e75/ActivityLifecycleContextListener;->n_onActivityPostSaveInstanceState(Landroid/app/Activity;Landroid/os/Bundle;)V

    return-void
.end method

.method public onActivityPostStarted(Landroid/app/Activity;)V
    .locals 0

    .line 105
    invoke-direct {p0, p1}, Lcrc64ba438d8f48cf7e75/ActivityLifecycleContextListener;->n_onActivityPostStarted(Landroid/app/Activity;)V

    return-void
.end method

.method public onActivityPostStopped(Landroid/app/Activity;)V
    .locals 0

    .line 112
    invoke-direct {p0, p1}, Lcrc64ba438d8f48cf7e75/ActivityLifecycleContextListener;->n_onActivityPostStopped(Landroid/app/Activity;)V

    return-void
.end method

.method public onActivityPreCreated(Landroid/app/Activity;Landroid/os/Bundle;)V
    .locals 0

    .line 119
    invoke-direct {p0, p1, p2}, Lcrc64ba438d8f48cf7e75/ActivityLifecycleContextListener;->n_onActivityPreCreated(Landroid/app/Activity;Landroid/os/Bundle;)V

    return-void
.end method

.method public onActivityPreDestroyed(Landroid/app/Activity;)V
    .locals 0

    .line 126
    invoke-direct {p0, p1}, Lcrc64ba438d8f48cf7e75/ActivityLifecycleContextListener;->n_onActivityPreDestroyed(Landroid/app/Activity;)V

    return-void
.end method

.method public onActivityPrePaused(Landroid/app/Activity;)V
    .locals 0

    .line 133
    invoke-direct {p0, p1}, Lcrc64ba438d8f48cf7e75/ActivityLifecycleContextListener;->n_onActivityPrePaused(Landroid/app/Activity;)V

    return-void
.end method

.method public onActivityPreResumed(Landroid/app/Activity;)V
    .locals 0

    .line 140
    invoke-direct {p0, p1}, Lcrc64ba438d8f48cf7e75/ActivityLifecycleContextListener;->n_onActivityPreResumed(Landroid/app/Activity;)V

    return-void
.end method

.method public onActivityPreSaveInstanceState(Landroid/app/Activity;Landroid/os/Bundle;)V
    .locals 0

    .line 147
    invoke-direct {p0, p1, p2}, Lcrc64ba438d8f48cf7e75/ActivityLifecycleContextListener;->n_onActivityPreSaveInstanceState(Landroid/app/Activity;Landroid/os/Bundle;)V

    return-void
.end method

.method public onActivityPreStarted(Landroid/app/Activity;)V
    .locals 0

    .line 154
    invoke-direct {p0, p1}, Lcrc64ba438d8f48cf7e75/ActivityLifecycleContextListener;->n_onActivityPreStarted(Landroid/app/Activity;)V

    return-void
.end method

.method public onActivityPreStopped(Landroid/app/Activity;)V
    .locals 0

    .line 161
    invoke-direct {p0, p1}, Lcrc64ba438d8f48cf7e75/ActivityLifecycleContextListener;->n_onActivityPreStopped(Landroid/app/Activity;)V

    return-void
.end method

.method public onActivityResumed(Landroid/app/Activity;)V
    .locals 0

    .line 42
    invoke-direct {p0, p1}, Lcrc64ba438d8f48cf7e75/ActivityLifecycleContextListener;->n_onActivityResumed(Landroid/app/Activity;)V

    return-void
.end method

.method public onActivitySaveInstanceState(Landroid/app/Activity;Landroid/os/Bundle;)V
    .locals 0

    .line 49
    invoke-direct {p0, p1, p2}, Lcrc64ba438d8f48cf7e75/ActivityLifecycleContextListener;->n_onActivitySaveInstanceState(Landroid/app/Activity;Landroid/os/Bundle;)V

    return-void
.end method

.method public onActivityStarted(Landroid/app/Activity;)V
    .locals 0

    .line 56
    invoke-direct {p0, p1}, Lcrc64ba438d8f48cf7e75/ActivityLifecycleContextListener;->n_onActivityStarted(Landroid/app/Activity;)V

    return-void
.end method

.method public onActivityStopped(Landroid/app/Activity;)V
    .locals 0

    .line 63
    invoke-direct {p0, p1}, Lcrc64ba438d8f48cf7e75/ActivityLifecycleContextListener;->n_onActivityStopped(Landroid/app/Activity;)V

    return-void
.end method
