.class public Lcrc64aa332189f4eef90d/App;
.super Landroid/support/multidex/MultiDexApplication;
.source "App.java"

# interfaces
.implements Lmono/android/IGCUserPeer;


# instance fields
.field private refList:Ljava/util/ArrayList;


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 11
    invoke-direct {p0}, Landroid/support/multidex/MultiDexApplication;-><init>()V

    .line 12
    invoke-static {p0}, Lmono/MonoPackageManager;->setContext(Landroid/content/Context;)V

    return-void
.end method

.method private native n_onCreate()V
.end method

.method private native n_onTrimMemory(I)V
.end method


# virtual methods
.method public monodroidAddReference(Ljava/lang/Object;)V
    .locals 1

    .line 32
    iget-object v0, p0, Lcrc64aa332189f4eef90d/App;->refList:Ljava/util/ArrayList;

    if-nez v0, :cond_0

    .line 33
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcrc64aa332189f4eef90d/App;->refList:Ljava/util/ArrayList;

    .line 34
    :cond_0
    iget-object v0, p0, Lcrc64aa332189f4eef90d/App;->refList:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public monodroidClearReferences()V
    .locals 1

    .line 39
    iget-object v0, p0, Lcrc64aa332189f4eef90d/App;->refList:Ljava/util/ArrayList;

    if-eqz v0, :cond_0

    .line 40
    invoke-virtual {v0}, Ljava/util/ArrayList;->clear()V

    :cond_0
    return-void
.end method

.method public onCreate()V
    .locals 0

    .line 17
    invoke-direct {p0}, Lcrc64aa332189f4eef90d/App;->n_onCreate()V

    return-void
.end method

.method public onTrimMemory(I)V
    .locals 0

    .line 24
    invoke-direct {p0, p1}, Lcrc64aa332189f4eef90d/App;->n_onTrimMemory(I)V

    return-void
.end method
