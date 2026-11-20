.class public Lcrc6459efab142bb48047/AuchanSnackbar_Callback;
.super Lcom/google/android/material/snackbar/BaseTransientBottomBar$BaseCallback;
.source "AuchanSnackbar_Callback.java"

# interfaces
.implements Lmono/android/IGCUserPeer;


# instance fields
.field private refList:Ljava/util/ArrayList;


# direct methods
.method public constructor <init>()V
    .locals 3

    .line 12
    invoke-direct {p0}, Lcom/google/android/material/snackbar/BaseTransientBottomBar$BaseCallback;-><init>()V

    .line 13
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc6459efab142bb48047/AuchanSnackbar_Callback;

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 14
    new-array v0, v0, [Ljava/lang/Object;

    const-string v1, "Auchan.Android.Common.UiUtils.AuchanSnackbar+Callback, Auchan.Android.Net"

    const-string v2, ""

    invoke-static {v1, v2, p0, v0}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method public constructor <init>(Landroid/widget/PopupWindow;Ljava/lang/String;ILcrc646064278e9258e0c4/DroidInfoMessageService;)V
    .locals 2

    .line 20
    invoke-direct {p0}, Lcom/google/android/material/snackbar/BaseTransientBottomBar$BaseCallback;-><init>()V

    .line 21
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc6459efab142bb48047/AuchanSnackbar_Callback;

    if-ne v0, v1, :cond_0

    .line 22
    invoke-static {p3}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p3

    filled-new-array {p1, p2, p3, p4}, [Ljava/lang/Object;

    move-result-object p1

    const-string p2, "Auchan.Android.Common.UiUtils.AuchanSnackbar+Callback, Auchan.Android.Net"

    const-string p3, "Android.Widget.PopupWindow, Mono.Android:System.String, System.Private.CoreLib:Auchan.Common.Common.SnackbarStyle, Auchan.Common.Net:Auchan.Android.Common.DroidInfoMessageService, Auchan.Android.Net"

    invoke-static {p2, p3, p0, p1}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method private native n_onDismissed(Ljava/lang/Object;I)V
.end method


# virtual methods
.method public monodroidAddReference(Ljava/lang/Object;)V
    .locals 1

    .line 36
    iget-object v0, p0, Lcrc6459efab142bb48047/AuchanSnackbar_Callback;->refList:Ljava/util/ArrayList;

    if-nez v0, :cond_0

    .line 37
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcrc6459efab142bb48047/AuchanSnackbar_Callback;->refList:Ljava/util/ArrayList;

    .line 38
    :cond_0
    iget-object v0, p0, Lcrc6459efab142bb48047/AuchanSnackbar_Callback;->refList:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public monodroidClearReferences()V
    .locals 1

    .line 43
    iget-object v0, p0, Lcrc6459efab142bb48047/AuchanSnackbar_Callback;->refList:Ljava/util/ArrayList;

    if-eqz v0, :cond_0

    .line 44
    invoke-virtual {v0}, Ljava/util/ArrayList;->clear()V

    :cond_0
    return-void
.end method

.method public onDismissed(Ljava/lang/Object;I)V
    .locals 0

    .line 28
    invoke-direct {p0, p1, p2}, Lcrc6459efab142bb48047/AuchanSnackbar_Callback;->n_onDismissed(Ljava/lang/Object;I)V

    return-void
.end method
