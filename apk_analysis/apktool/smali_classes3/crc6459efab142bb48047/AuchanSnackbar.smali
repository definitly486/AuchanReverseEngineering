.class public Lcrc6459efab142bb48047/AuchanSnackbar;
.super Lcom/google/android/material/snackbar/BaseTransientBottomBar;
.source "AuchanSnackbar.java"

# interfaces
.implements Lmono/android/IGCUserPeer;


# instance fields
.field private refList:Ljava/util/ArrayList;


# direct methods
.method public constructor <init>(Landroid/content/Context;Landroid/view/ViewGroup;Landroid/view/View;Lcom/google/android/material/snackbar/ContentViewCallback;)V
    .locals 2

    .line 12
    invoke-direct {p0, p1, p2, p3, p4}, Lcom/google/android/material/snackbar/BaseTransientBottomBar;-><init>(Landroid/content/Context;Landroid/view/ViewGroup;Landroid/view/View;Lcom/google/android/material/snackbar/ContentViewCallback;)V

    .line 13
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc6459efab142bb48047/AuchanSnackbar;

    if-ne v0, v1, :cond_0

    .line 14
    const-string v0, "Android.Content.Context, Mono.Android:Android.Views.ViewGroup, Mono.Android:Android.Views.View, Mono.Android:Google.Android.Material.Snackbar.IContentViewCallback, Xamarin.Google.Android.Material"

    filled-new-array {p1, p2, p3, p4}, [Ljava/lang/Object;

    move-result-object p1

    const-string p2, "Auchan.Android.Common.UiUtils.AuchanSnackbar, Auchan.Android.Net"

    invoke-static {p2, v0, p0, p1}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method public constructor <init>(Landroid/view/ViewGroup;Landroid/view/View;Lcom/google/android/material/snackbar/ContentViewCallback;)V
    .locals 2

    .line 20
    invoke-direct {p0, p1, p2, p3}, Lcom/google/android/material/snackbar/BaseTransientBottomBar;-><init>(Landroid/view/ViewGroup;Landroid/view/View;Lcom/google/android/material/snackbar/ContentViewCallback;)V

    .line 21
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc6459efab142bb48047/AuchanSnackbar;

    if-ne v0, v1, :cond_0

    .line 22
    const-string v0, "Android.Views.ViewGroup, Mono.Android:Android.Views.View, Mono.Android:Google.Android.Material.Snackbar.IContentViewCallback, Xamarin.Google.Android.Material"

    filled-new-array {p1, p2, p3}, [Ljava/lang/Object;

    move-result-object p1

    const-string p2, "Auchan.Android.Common.UiUtils.AuchanSnackbar, Auchan.Android.Net"

    invoke-static {p2, v0, p0, p1}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method private native n_setDuration(I)Lcom/google/android/material/snackbar/BaseTransientBottomBar;
.end method


# virtual methods
.method public monodroidAddReference(Ljava/lang/Object;)V
    .locals 1

    .line 36
    iget-object v0, p0, Lcrc6459efab142bb48047/AuchanSnackbar;->refList:Ljava/util/ArrayList;

    if-nez v0, :cond_0

    .line 37
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcrc6459efab142bb48047/AuchanSnackbar;->refList:Ljava/util/ArrayList;

    .line 38
    :cond_0
    iget-object v0, p0, Lcrc6459efab142bb48047/AuchanSnackbar;->refList:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public monodroidClearReferences()V
    .locals 1

    .line 43
    iget-object v0, p0, Lcrc6459efab142bb48047/AuchanSnackbar;->refList:Ljava/util/ArrayList;

    if-eqz v0, :cond_0

    .line 44
    invoke-virtual {v0}, Ljava/util/ArrayList;->clear()V

    :cond_0
    return-void
.end method

.method public setDuration(I)Lcom/google/android/material/snackbar/BaseTransientBottomBar;
    .locals 0

    .line 28
    invoke-direct {p0, p1}, Lcrc6459efab142bb48047/AuchanSnackbar;->n_setDuration(I)Lcom/google/android/material/snackbar/BaseTransientBottomBar;

    move-result-object p1

    return-object p1
.end method
