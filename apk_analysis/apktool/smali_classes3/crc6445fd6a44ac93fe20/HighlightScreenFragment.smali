.class public Lcrc6445fd6a44ac93fe20/HighlightScreenFragment;
.super Lcrc64f03248cb510113f2/BaseDialogFragment_1;
.source "HighlightScreenFragment.java"

# interfaces
.implements Lmono/android/IGCUserPeer;
.implements Landroid/content/DialogInterface$OnKeyListener;


# instance fields
.field private refList:Ljava/util/ArrayList;


# direct methods
.method public constructor <init>()V
    .locals 3

    .line 13
    invoke-direct {p0}, Lcrc64f03248cb510113f2/BaseDialogFragment_1;-><init>()V

    .line 14
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc6445fd6a44ac93fe20/HighlightScreenFragment;

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 15
    new-array v0, v0, [Ljava/lang/Object;

    const-string v1, "Auchan.Android.Common.HighlightScreen.HighlightScreenFragment, Auchan.Android.Net"

    const-string v2, ""

    invoke-static {v1, v2, p0, v0}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method public constructor <init>(I)V
    .locals 2

    .line 21
    invoke-direct {p0, p1}, Lcrc64f03248cb510113f2/BaseDialogFragment_1;-><init>(I)V

    .line 22
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc6445fd6a44ac93fe20/HighlightScreenFragment;

    if-ne v0, v1, :cond_0

    .line 23
    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p1

    filled-new-array {p1}, [Ljava/lang/Object;

    move-result-object p1

    const-string v0, "Auchan.Android.Common.HighlightScreen.HighlightScreenFragment, Auchan.Android.Net"

    const-string v1, "System.Int32, System.Private.CoreLib"

    invoke-static {v0, v1, p0, p1}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method private native n_getTheme()I
.end method

.method private native n_onCreate(Landroid/os/Bundle;)V
.end method

.method private native n_onCreateDialog(Landroid/os/Bundle;)Landroid/app/Dialog;
.end method

.method private native n_onDestroy()V
.end method

.method private native n_onKey(Landroid/content/DialogInterface;ILandroid/view/KeyEvent;)Z
.end method

.method private native n_onViewCreated(Landroid/view/View;Landroid/os/Bundle;)V
.end method


# virtual methods
.method public getTheme()I
    .locals 1

    .line 29
    invoke-direct {p0}, Lcrc6445fd6a44ac93fe20/HighlightScreenFragment;->n_getTheme()I

    move-result v0

    return v0
.end method

.method public monodroidAddReference(Ljava/lang/Object;)V
    .locals 1

    .line 72
    iget-object v0, p0, Lcrc6445fd6a44ac93fe20/HighlightScreenFragment;->refList:Ljava/util/ArrayList;

    if-nez v0, :cond_0

    .line 73
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcrc6445fd6a44ac93fe20/HighlightScreenFragment;->refList:Ljava/util/ArrayList;

    .line 74
    :cond_0
    iget-object v0, p0, Lcrc6445fd6a44ac93fe20/HighlightScreenFragment;->refList:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public monodroidClearReferences()V
    .locals 1

    .line 79
    iget-object v0, p0, Lcrc6445fd6a44ac93fe20/HighlightScreenFragment;->refList:Ljava/util/ArrayList;

    if-eqz v0, :cond_0

    .line 80
    invoke-virtual {v0}, Ljava/util/ArrayList;->clear()V

    :cond_0
    return-void
.end method

.method public onCreate(Landroid/os/Bundle;)V
    .locals 0

    .line 36
    invoke-direct {p0, p1}, Lcrc6445fd6a44ac93fe20/HighlightScreenFragment;->n_onCreate(Landroid/os/Bundle;)V

    return-void
.end method

.method public onCreateDialog(Landroid/os/Bundle;)Landroid/app/Dialog;
    .locals 0

    .line 50
    invoke-direct {p0, p1}, Lcrc6445fd6a44ac93fe20/HighlightScreenFragment;->n_onCreateDialog(Landroid/os/Bundle;)Landroid/app/Dialog;

    move-result-object p1

    return-object p1
.end method

.method public onDestroy()V
    .locals 0

    .line 57
    invoke-direct {p0}, Lcrc6445fd6a44ac93fe20/HighlightScreenFragment;->n_onDestroy()V

    return-void
.end method

.method public onKey(Landroid/content/DialogInterface;ILandroid/view/KeyEvent;)Z
    .locals 0

    .line 64
    invoke-direct {p0, p1, p2, p3}, Lcrc6445fd6a44ac93fe20/HighlightScreenFragment;->n_onKey(Landroid/content/DialogInterface;ILandroid/view/KeyEvent;)Z

    move-result p1

    return p1
.end method

.method public onViewCreated(Landroid/view/View;Landroid/os/Bundle;)V
    .locals 0

    .line 43
    invoke-direct {p0, p1, p2}, Lcrc6445fd6a44ac93fe20/HighlightScreenFragment;->n_onViewCreated(Landroid/view/View;Landroid/os/Bundle;)V

    return-void
.end method
