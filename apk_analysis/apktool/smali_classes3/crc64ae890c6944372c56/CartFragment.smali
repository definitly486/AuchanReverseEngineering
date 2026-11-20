.class public Lcrc64ae890c6944372c56/CartFragment;
.super Lcrc64f40001e2c9184636/AutoLayoutFragment_1;
.source "CartFragment.java"

# interfaces
.implements Lmono/android/IGCUserPeer;


# instance fields
.field private refList:Ljava/util/ArrayList;


# direct methods
.method public constructor <init>()V
    .locals 3

    .line 12
    invoke-direct {p0}, Lcrc64f40001e2c9184636/AutoLayoutFragment_1;-><init>()V

    .line 13
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc64ae890c6944372c56/CartFragment;

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 14
    new-array v0, v0, [Ljava/lang/Object;

    const-string v1, "Auchan.Android.Ecom.Cart.CartFragment, Auchan.Android.Net"

    const-string v2, ""

    invoke-static {v1, v2, p0, v0}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method public constructor <init>(I)V
    .locals 2

    .line 20
    invoke-direct {p0, p1}, Lcrc64f40001e2c9184636/AutoLayoutFragment_1;-><init>(I)V

    .line 21
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc64ae890c6944372c56/CartFragment;

    if-ne v0, v1, :cond_0

    .line 22
    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p1

    filled-new-array {p1}, [Ljava/lang/Object;

    move-result-object p1

    const-string v0, "Auchan.Android.Ecom.Cart.CartFragment, Auchan.Android.Net"

    const-string v1, "System.Int32, System.Private.CoreLib"

    invoke-static {v0, v1, p0, p1}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method private native n_onCreate(Landroid/os/Bundle;)V
.end method

.method private native n_onDestroyView()V
.end method

.method private native n_onHiddenChanged(Z)V
.end method

.method private native n_onResume()V
.end method

.method private native n_onStart()V
.end method

.method private native n_onStop()V
.end method

.method private native n_onViewCreated(Landroid/view/View;Landroid/os/Bundle;)V
.end method


# virtual methods
.method public monodroidAddReference(Ljava/lang/Object;)V
    .locals 1

    .line 78
    iget-object v0, p0, Lcrc64ae890c6944372c56/CartFragment;->refList:Ljava/util/ArrayList;

    if-nez v0, :cond_0

    .line 79
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcrc64ae890c6944372c56/CartFragment;->refList:Ljava/util/ArrayList;

    .line 80
    :cond_0
    iget-object v0, p0, Lcrc64ae890c6944372c56/CartFragment;->refList:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public monodroidClearReferences()V
    .locals 1

    .line 85
    iget-object v0, p0, Lcrc64ae890c6944372c56/CartFragment;->refList:Ljava/util/ArrayList;

    if-eqz v0, :cond_0

    .line 86
    invoke-virtual {v0}, Ljava/util/ArrayList;->clear()V

    :cond_0
    return-void
.end method

.method public onCreate(Landroid/os/Bundle;)V
    .locals 0

    .line 28
    invoke-direct {p0, p1}, Lcrc64ae890c6944372c56/CartFragment;->n_onCreate(Landroid/os/Bundle;)V

    return-void
.end method

.method public onDestroyView()V
    .locals 0

    .line 70
    invoke-direct {p0}, Lcrc64ae890c6944372c56/CartFragment;->n_onDestroyView()V

    return-void
.end method

.method public onHiddenChanged(Z)V
    .locals 0

    .line 56
    invoke-direct {p0, p1}, Lcrc64ae890c6944372c56/CartFragment;->n_onHiddenChanged(Z)V

    return-void
.end method

.method public onResume()V
    .locals 0

    .line 63
    invoke-direct {p0}, Lcrc64ae890c6944372c56/CartFragment;->n_onResume()V

    return-void
.end method

.method public onStart()V
    .locals 0

    .line 42
    invoke-direct {p0}, Lcrc64ae890c6944372c56/CartFragment;->n_onStart()V

    return-void
.end method

.method public onStop()V
    .locals 0

    .line 49
    invoke-direct {p0}, Lcrc64ae890c6944372c56/CartFragment;->n_onStop()V

    return-void
.end method

.method public onViewCreated(Landroid/view/View;Landroid/os/Bundle;)V
    .locals 0

    .line 35
    invoke-direct {p0, p1, p2}, Lcrc64ae890c6944372c56/CartFragment;->n_onViewCreated(Landroid/view/View;Landroid/os/Bundle;)V

    return-void
.end method
