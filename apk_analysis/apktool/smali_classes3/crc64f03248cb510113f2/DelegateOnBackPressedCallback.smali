.class public Lcrc64f03248cb510113f2/DelegateOnBackPressedCallback;
.super Landroidx/activity/OnBackPressedCallback;
.source "DelegateOnBackPressedCallback.java"

# interfaces
.implements Lmono/android/IGCUserPeer;


# instance fields
.field private refList:Ljava/util/ArrayList;


# direct methods
.method public constructor <init>(Z)V
    .locals 2

    .line 12
    invoke-direct {p0, p1}, Landroidx/activity/OnBackPressedCallback;-><init>(Z)V

    .line 13
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc64f03248cb510113f2/DelegateOnBackPressedCallback;

    if-ne v0, v1, :cond_0

    .line 14
    invoke-static {p1}, Ljava/lang/Boolean;->valueOf(Z)Ljava/lang/Boolean;

    move-result-object p1

    filled-new-array {p1}, [Ljava/lang/Object;

    move-result-object p1

    const-string v0, "Auchan.Android.Base.DelegateOnBackPressedCallback, Auchan.Android.Net"

    const-string v1, "System.Boolean, System.Private.CoreLib"

    invoke-static {v0, v1, p0, p1}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method private native n_handleOnBackPressed()V
.end method


# virtual methods
.method public handleOnBackPressed()V
    .locals 0

    .line 20
    invoke-direct {p0}, Lcrc64f03248cb510113f2/DelegateOnBackPressedCallback;->n_handleOnBackPressed()V

    return-void
.end method

.method public monodroidAddReference(Ljava/lang/Object;)V
    .locals 1

    .line 28
    iget-object v0, p0, Lcrc64f03248cb510113f2/DelegateOnBackPressedCallback;->refList:Ljava/util/ArrayList;

    if-nez v0, :cond_0

    .line 29
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcrc64f03248cb510113f2/DelegateOnBackPressedCallback;->refList:Ljava/util/ArrayList;

    .line 30
    :cond_0
    iget-object v0, p0, Lcrc64f03248cb510113f2/DelegateOnBackPressedCallback;->refList:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public monodroidClearReferences()V
    .locals 1

    .line 35
    iget-object v0, p0, Lcrc64f03248cb510113f2/DelegateOnBackPressedCallback;->refList:Ljava/util/ArrayList;

    if-eqz v0, :cond_0

    .line 36
    invoke-virtual {v0}, Ljava/util/ArrayList;->clear()V

    :cond_0
    return-void
.end method
