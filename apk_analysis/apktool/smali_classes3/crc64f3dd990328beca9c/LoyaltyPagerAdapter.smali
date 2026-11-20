.class public Lcrc64f3dd990328beca9c/LoyaltyPagerAdapter;
.super Landroidx/viewpager/widget/PagerAdapter;
.source "LoyaltyPagerAdapter.java"

# interfaces
.implements Lmono/android/IGCUserPeer;


# instance fields
.field private refList:Ljava/util/ArrayList;


# direct methods
.method public constructor <init>()V
    .locals 3

    .line 12
    invoke-direct {p0}, Landroidx/viewpager/widget/PagerAdapter;-><init>()V

    .line 13
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc64f3dd990328beca9c/LoyaltyPagerAdapter;

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 14
    new-array v0, v0, [Ljava/lang/Object;

    const-string v1, "Auchan.Android.LoyaltyProgram.LoyaltyPagerAdapter, Auchan.Android.Net"

    const-string v2, ""

    invoke-static {v1, v2, p0, v0}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method public constructor <init>(Landroid/content/Context;Lme/relex/circleindicator/CircleIndicator;)V
    .locals 2

    .line 20
    invoke-direct {p0}, Landroidx/viewpager/widget/PagerAdapter;-><init>()V

    .line 21
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc64f3dd990328beca9c/LoyaltyPagerAdapter;

    if-ne v0, v1, :cond_0

    .line 22
    const-string v0, "Android.Content.Context, Mono.Android:Me.Relex.CircleIndicatorLib.CircleIndicator, Ongakuer.CircleIndicator"

    filled-new-array {p1, p2}, [Ljava/lang/Object;

    move-result-object p1

    const-string p2, "Auchan.Android.LoyaltyProgram.LoyaltyPagerAdapter, Auchan.Android.Net"

    invoke-static {p2, v0, p0, p1}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method private native n_destroyItem(Landroid/view/ViewGroup;ILjava/lang/Object;)V
.end method

.method private native n_getCount()I
.end method

.method private native n_instantiateItem(Landroid/view/ViewGroup;I)Ljava/lang/Object;
.end method

.method private native n_isViewFromObject(Landroid/view/View;Ljava/lang/Object;)Z
.end method


# virtual methods
.method public destroyItem(Landroid/view/ViewGroup;ILjava/lang/Object;)V
    .locals 0

    .line 49
    invoke-direct {p0, p1, p2, p3}, Lcrc64f3dd990328beca9c/LoyaltyPagerAdapter;->n_destroyItem(Landroid/view/ViewGroup;ILjava/lang/Object;)V

    return-void
.end method

.method public getCount()I
    .locals 1

    .line 28
    invoke-direct {p0}, Lcrc64f3dd990328beca9c/LoyaltyPagerAdapter;->n_getCount()I

    move-result v0

    return v0
.end method

.method public instantiateItem(Landroid/view/ViewGroup;I)Ljava/lang/Object;
    .locals 0

    .line 42
    invoke-direct {p0, p1, p2}, Lcrc64f3dd990328beca9c/LoyaltyPagerAdapter;->n_instantiateItem(Landroid/view/ViewGroup;I)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method

.method public isViewFromObject(Landroid/view/View;Ljava/lang/Object;)Z
    .locals 0

    .line 35
    invoke-direct {p0, p1, p2}, Lcrc64f3dd990328beca9c/LoyaltyPagerAdapter;->n_isViewFromObject(Landroid/view/View;Ljava/lang/Object;)Z

    move-result p1

    return p1
.end method

.method public monodroidAddReference(Ljava/lang/Object;)V
    .locals 1

    .line 57
    iget-object v0, p0, Lcrc64f3dd990328beca9c/LoyaltyPagerAdapter;->refList:Ljava/util/ArrayList;

    if-nez v0, :cond_0

    .line 58
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcrc64f3dd990328beca9c/LoyaltyPagerAdapter;->refList:Ljava/util/ArrayList;

    .line 59
    :cond_0
    iget-object v0, p0, Lcrc64f3dd990328beca9c/LoyaltyPagerAdapter;->refList:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public monodroidClearReferences()V
    .locals 1

    .line 64
    iget-object v0, p0, Lcrc64f3dd990328beca9c/LoyaltyPagerAdapter;->refList:Ljava/util/ArrayList;

    if-eqz v0, :cond_0

    .line 65
    invoke-virtual {v0}, Ljava/util/ArrayList;->clear()V

    :cond_0
    return-void
.end method
