.class public Lmono/android/text/TextWatcherImplementor;
.super Ljava/lang/Object;
.source "TextWatcherImplementor.java"

# interfaces
.implements Lmono/android/IGCUserPeer;
.implements Landroid/text/TextWatcher;
.implements Landroid/text/NoCopySpan;


# instance fields
.field private refList:Ljava/util/ArrayList;


# direct methods
.method public constructor <init>()V
    .locals 3

    .line 14
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 15
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lmono/android/text/TextWatcherImplementor;

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 16
    new-array v0, v0, [Ljava/lang/Object;

    const-string v1, "Android.Text.TextWatcherImplementor, Mono.Android"

    const-string v2, ""

    invoke-static {v1, v2, p0, v0}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method private native n_afterTextChanged(Landroid/text/Editable;)V
.end method

.method private native n_beforeTextChanged(Ljava/lang/CharSequence;III)V
.end method

.method private native n_onTextChanged(Ljava/lang/CharSequence;III)V
.end method


# virtual methods
.method public afterTextChanged(Landroid/text/Editable;)V
    .locals 0

    .line 22
    invoke-direct {p0, p1}, Lmono/android/text/TextWatcherImplementor;->n_afterTextChanged(Landroid/text/Editable;)V

    return-void
.end method

.method public beforeTextChanged(Ljava/lang/CharSequence;III)V
    .locals 0

    .line 29
    invoke-direct {p0, p1, p2, p3, p4}, Lmono/android/text/TextWatcherImplementor;->n_beforeTextChanged(Ljava/lang/CharSequence;III)V

    return-void
.end method

.method public monodroidAddReference(Ljava/lang/Object;)V
    .locals 1

    .line 44
    iget-object v0, p0, Lmono/android/text/TextWatcherImplementor;->refList:Ljava/util/ArrayList;

    if-nez v0, :cond_0

    .line 45
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lmono/android/text/TextWatcherImplementor;->refList:Ljava/util/ArrayList;

    .line 46
    :cond_0
    iget-object v0, p0, Lmono/android/text/TextWatcherImplementor;->refList:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public monodroidClearReferences()V
    .locals 1

    .line 51
    iget-object v0, p0, Lmono/android/text/TextWatcherImplementor;->refList:Ljava/util/ArrayList;

    if-eqz v0, :cond_0

    .line 52
    invoke-virtual {v0}, Ljava/util/ArrayList;->clear()V

    :cond_0
    return-void
.end method

.method public onTextChanged(Ljava/lang/CharSequence;III)V
    .locals 0

    .line 36
    invoke-direct {p0, p1, p2, p3, p4}, Lmono/android/text/TextWatcherImplementor;->n_onTextChanged(Ljava/lang/CharSequence;III)V

    return-void
.end method
