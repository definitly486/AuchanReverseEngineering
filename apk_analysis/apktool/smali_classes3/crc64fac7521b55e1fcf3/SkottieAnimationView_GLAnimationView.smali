.class public Lcrc64fac7521b55e1fcf3/SkottieAnimationView_GLAnimationView;
.super Lcrc648e35430423bd4943/SKGLTextureView;
.source "SkottieAnimationView_GLAnimationView.java"

# interfaces
.implements Lmono/android/IGCUserPeer;
.implements Landroidx/lifecycle/LifecycleEventObserver;
.implements Landroidx/lifecycle/LifecycleObserver;


# instance fields
.field private refList:Ljava/util/ArrayList;


# direct methods
.method public constructor <init>(Landroid/content/Context;)V
    .locals 2

    .line 30
    invoke-direct {p0, p1}, Lcrc648e35430423bd4943/SKGLTextureView;-><init>(Landroid/content/Context;)V

    .line 31
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc64fac7521b55e1fcf3/SkottieAnimationView_GLAnimationView;

    if-ne v0, v1, :cond_0

    .line 32
    const-string v0, "Android.Content.Context, Mono.Android"

    filled-new-array {p1}, [Ljava/lang/Object;

    move-result-object p1

    const-string v1, "Auchan.Android.Controls.SkottieAnimationView+GLAnimationView, Auchan.Android.Net"

    invoke-static {v1, v0, p0, p1}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method public constructor <init>(Landroid/content/Context;Landroid/util/AttributeSet;)V
    .locals 2

    .line 22
    invoke-direct {p0, p1, p2}, Lcrc648e35430423bd4943/SKGLTextureView;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;)V

    .line 23
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc64fac7521b55e1fcf3/SkottieAnimationView_GLAnimationView;

    if-ne v0, v1, :cond_0

    .line 24
    const-string v0, "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android"

    filled-new-array {p1, p2}, [Ljava/lang/Object;

    move-result-object p1

    const-string p2, "Auchan.Android.Controls.SkottieAnimationView+GLAnimationView, Auchan.Android.Net"

    invoke-static {p2, v0, p0, p1}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method public constructor <init>(Landroid/content/Context;Landroid/util/AttributeSet;I)V
    .locals 2

    .line 14
    invoke-direct {p0, p1, p2, p3}, Lcrc648e35430423bd4943/SKGLTextureView;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;I)V

    .line 15
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc64fac7521b55e1fcf3/SkottieAnimationView_GLAnimationView;

    if-ne v0, v1, :cond_0

    .line 16
    invoke-static {p3}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p3

    filled-new-array {p1, p2, p3}, [Ljava/lang/Object;

    move-result-object p1

    const-string p2, "Auchan.Android.Controls.SkottieAnimationView+GLAnimationView, Auchan.Android.Net"

    const-string p3, "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib"

    invoke-static {p2, p3, p0, p1}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method private native n_onStateChanged(Landroidx/lifecycle/LifecycleOwner;Landroidx/lifecycle/Lifecycle$Event;)V
.end method


# virtual methods
.method public monodroidAddReference(Ljava/lang/Object;)V
    .locals 1

    .line 46
    iget-object v0, p0, Lcrc64fac7521b55e1fcf3/SkottieAnimationView_GLAnimationView;->refList:Ljava/util/ArrayList;

    if-nez v0, :cond_0

    .line 47
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcrc64fac7521b55e1fcf3/SkottieAnimationView_GLAnimationView;->refList:Ljava/util/ArrayList;

    .line 48
    :cond_0
    iget-object v0, p0, Lcrc64fac7521b55e1fcf3/SkottieAnimationView_GLAnimationView;->refList:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public monodroidClearReferences()V
    .locals 1

    .line 53
    iget-object v0, p0, Lcrc64fac7521b55e1fcf3/SkottieAnimationView_GLAnimationView;->refList:Ljava/util/ArrayList;

    if-eqz v0, :cond_0

    .line 54
    invoke-virtual {v0}, Ljava/util/ArrayList;->clear()V

    :cond_0
    return-void
.end method

.method public onStateChanged(Landroidx/lifecycle/LifecycleOwner;Landroidx/lifecycle/Lifecycle$Event;)V
    .locals 0

    .line 38
    invoke-direct {p0, p1, p2}, Lcrc64fac7521b55e1fcf3/SkottieAnimationView_GLAnimationView;->n_onStateChanged(Landroidx/lifecycle/LifecycleOwner;Landroidx/lifecycle/Lifecycle$Event;)V

    return-void
.end method
