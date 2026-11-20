.class public abstract Lcrc64f03248cb510113f2/BaseActivity;
.super Landroidx/appcompat/app/AppCompatActivity;
.source "BaseActivity.java"

# interfaces
.implements Lmono/android/IGCUserPeer;


# instance fields
.field private refList:Ljava/util/ArrayList;


# direct methods
.method public constructor <init>()V
    .locals 3

    .line 12
    invoke-direct {p0}, Landroidx/appcompat/app/AppCompatActivity;-><init>()V

    .line 13
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc64f03248cb510113f2/BaseActivity;

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 14
    new-array v0, v0, [Ljava/lang/Object;

    const-string v1, "Auchan.Android.Base.BaseActivity, Auchan.Android.Net"

    const-string v2, ""

    invoke-static {v1, v2, p0, v0}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method public constructor <init>(I)V
    .locals 2

    .line 20
    invoke-direct {p0, p1}, Landroidx/appcompat/app/AppCompatActivity;-><init>(I)V

    .line 21
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc64f03248cb510113f2/BaseActivity;

    if-ne v0, v1, :cond_0

    .line 22
    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p1

    filled-new-array {p1}, [Ljava/lang/Object;

    move-result-object p1

    const-string v0, "Auchan.Android.Base.BaseActivity, Auchan.Android.Net"

    const-string v1, "System.Int32, System.Private.CoreLib"

    invoke-static {v0, v1, p0, p1}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method private native n_onCreate(Landroid/os/Bundle;)V
.end method

.method private native n_onNewIntent(Landroid/content/Intent;)V
.end method

.method private native n_onRequestPermissionsResult(I[Ljava/lang/String;[I)V
.end method

.method private native n_onResume()V
.end method

.method private native n_onUserInteraction()V
.end method

.method private native n_setContentView(I)V
.end method

.method private native n_setContentView(Landroid/view/View;)V
.end method

.method private native n_setContentView(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V
.end method


# virtual methods
.method public monodroidAddReference(Ljava/lang/Object;)V
    .locals 1

    .line 85
    iget-object v0, p0, Lcrc64f03248cb510113f2/BaseActivity;->refList:Ljava/util/ArrayList;

    if-nez v0, :cond_0

    .line 86
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcrc64f03248cb510113f2/BaseActivity;->refList:Ljava/util/ArrayList;

    .line 87
    :cond_0
    iget-object v0, p0, Lcrc64f03248cb510113f2/BaseActivity;->refList:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public monodroidClearReferences()V
    .locals 1

    .line 92
    iget-object v0, p0, Lcrc64f03248cb510113f2/BaseActivity;->refList:Ljava/util/ArrayList;

    if-eqz v0, :cond_0

    .line 93
    invoke-virtual {v0}, Ljava/util/ArrayList;->clear()V

    :cond_0
    return-void
.end method

.method public onCreate(Landroid/os/Bundle;)V
    .locals 0

    .line 28
    invoke-direct {p0, p1}, Lcrc64f03248cb510113f2/BaseActivity;->n_onCreate(Landroid/os/Bundle;)V

    return-void
.end method

.method public onNewIntent(Landroid/content/Intent;)V
    .locals 0

    .line 56
    invoke-direct {p0, p1}, Lcrc64f03248cb510113f2/BaseActivity;->n_onNewIntent(Landroid/content/Intent;)V

    return-void
.end method

.method public onRequestPermissionsResult(I[Ljava/lang/String;[I)V
    .locals 0

    .line 70
    invoke-direct {p0, p1, p2, p3}, Lcrc64f03248cb510113f2/BaseActivity;->n_onRequestPermissionsResult(I[Ljava/lang/String;[I)V

    return-void
.end method

.method public onResume()V
    .locals 0

    .line 63
    invoke-direct {p0}, Lcrc64f03248cb510113f2/BaseActivity;->n_onResume()V

    return-void
.end method

.method public onUserInteraction()V
    .locals 0

    .line 77
    invoke-direct {p0}, Lcrc64f03248cb510113f2/BaseActivity;->n_onUserInteraction()V

    return-void
.end method

.method public setContentView(I)V
    .locals 0

    .line 49
    invoke-direct {p0, p1}, Lcrc64f03248cb510113f2/BaseActivity;->n_setContentView(I)V

    return-void
.end method

.method public setContentView(Landroid/view/View;)V
    .locals 0

    .line 42
    invoke-direct {p0, p1}, Lcrc64f03248cb510113f2/BaseActivity;->n_setContentView(Landroid/view/View;)V

    return-void
.end method

.method public setContentView(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V
    .locals 0

    .line 35
    invoke-direct {p0, p1, p2}, Lcrc64f03248cb510113f2/BaseActivity;->n_setContentView(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V

    return-void
.end method
