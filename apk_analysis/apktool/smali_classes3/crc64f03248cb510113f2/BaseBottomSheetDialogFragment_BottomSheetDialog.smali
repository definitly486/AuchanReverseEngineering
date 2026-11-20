.class public Lcrc64f03248cb510113f2/BaseBottomSheetDialogFragment_BottomSheetDialog;
.super Lcom/google/android/material/bottomsheet/BottomSheetDialog;
.source "BaseBottomSheetDialogFragment_BottomSheetDialog.java"

# interfaces
.implements Lmono/android/IGCUserPeer;


# instance fields
.field private refList:Ljava/util/ArrayList;


# direct methods
.method public constructor <init>(Landroid/content/Context;)V
    .locals 2

    .line 12
    invoke-direct {p0, p1}, Lcom/google/android/material/bottomsheet/BottomSheetDialog;-><init>(Landroid/content/Context;)V

    .line 13
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc64f03248cb510113f2/BaseBottomSheetDialogFragment_BottomSheetDialog;

    if-ne v0, v1, :cond_0

    .line 14
    const-string v0, "Android.Content.Context, Mono.Android"

    filled-new-array {p1}, [Ljava/lang/Object;

    move-result-object p1

    const-string v1, "Auchan.Android.Base.BaseBottomSheetDialogFragment+BottomSheetDialog, Auchan.Android.Net"

    invoke-static {v1, v0, p0, p1}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method public constructor <init>(Landroid/content/Context;I)V
    .locals 2

    .line 28
    invoke-direct {p0, p1, p2}, Lcom/google/android/material/bottomsheet/BottomSheetDialog;-><init>(Landroid/content/Context;I)V

    .line 29
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc64f03248cb510113f2/BaseBottomSheetDialogFragment_BottomSheetDialog;

    if-ne v0, v1, :cond_0

    .line 30
    invoke-static {p2}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p2

    filled-new-array {p1, p2}, [Ljava/lang/Object;

    move-result-object p1

    const-string p2, "Auchan.Android.Base.BaseBottomSheetDialogFragment+BottomSheetDialog, Auchan.Android.Net"

    const-string v0, "Android.Content.Context, Mono.Android:System.Int32, System.Private.CoreLib"

    invoke-static {p2, v0, p0, p1}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method public constructor <init>(Landroid/content/Context;ZLandroid/content/DialogInterface$OnCancelListener;)V
    .locals 2

    .line 20
    invoke-direct {p0, p1, p2, p3}, Lcom/google/android/material/bottomsheet/BottomSheetDialog;-><init>(Landroid/content/Context;ZLandroid/content/DialogInterface$OnCancelListener;)V

    .line 21
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc64f03248cb510113f2/BaseBottomSheetDialogFragment_BottomSheetDialog;

    if-ne v0, v1, :cond_0

    .line 22
    invoke-static {p2}, Ljava/lang/Boolean;->valueOf(Z)Ljava/lang/Boolean;

    move-result-object p2

    filled-new-array {p1, p2, p3}, [Ljava/lang/Object;

    move-result-object p1

    const-string p2, "Auchan.Android.Base.BaseBottomSheetDialogFragment+BottomSheetDialog, Auchan.Android.Net"

    const-string p3, "Android.Content.Context, Mono.Android:System.Boolean, System.Private.CoreLib:Android.Content.IDialogInterfaceOnCancelListener, Mono.Android"

    invoke-static {p2, p3, p0, p1}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method private native n_onAttachedToWindow()V
.end method


# virtual methods
.method public monodroidAddReference(Ljava/lang/Object;)V
    .locals 1

    .line 44
    iget-object v0, p0, Lcrc64f03248cb510113f2/BaseBottomSheetDialogFragment_BottomSheetDialog;->refList:Ljava/util/ArrayList;

    if-nez v0, :cond_0

    .line 45
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcrc64f03248cb510113f2/BaseBottomSheetDialogFragment_BottomSheetDialog;->refList:Ljava/util/ArrayList;

    .line 46
    :cond_0
    iget-object v0, p0, Lcrc64f03248cb510113f2/BaseBottomSheetDialogFragment_BottomSheetDialog;->refList:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public monodroidClearReferences()V
    .locals 1

    .line 51
    iget-object v0, p0, Lcrc64f03248cb510113f2/BaseBottomSheetDialogFragment_BottomSheetDialog;->refList:Ljava/util/ArrayList;

    if-eqz v0, :cond_0

    .line 52
    invoke-virtual {v0}, Ljava/util/ArrayList;->clear()V

    :cond_0
    return-void
.end method

.method public onAttachedToWindow()V
    .locals 0

    .line 36
    invoke-direct {p0}, Lcrc64f03248cb510113f2/BaseBottomSheetDialogFragment_BottomSheetDialog;->n_onAttachedToWindow()V

    return-void
.end method
