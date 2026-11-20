.class public Lcrc64fac7521b55e1fcf3/OutlinedErrorEditText;
.super Lcom/google/android/material/textfield/TextInputEditText;
.source "OutlinedErrorEditText.java"

# interfaces
.implements Lmono/android/IGCUserPeer;


# instance fields
.field private refList:Ljava/util/ArrayList;


# direct methods
.method public constructor <init>(Landroid/content/Context;)V
    .locals 2

    .line 12
    invoke-direct {p0, p1}, Lcom/google/android/material/textfield/TextInputEditText;-><init>(Landroid/content/Context;)V

    .line 13
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc64fac7521b55e1fcf3/OutlinedErrorEditText;

    if-ne v0, v1, :cond_0

    .line 14
    const-string v0, "Android.Content.Context, Mono.Android"

    filled-new-array {p1}, [Ljava/lang/Object;

    move-result-object p1

    const-string v1, "Auchan.Android.Controls.OutlinedErrorEditText, Auchan.Android.Net"

    invoke-static {v1, v0, p0, p1}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method public constructor <init>(Landroid/content/Context;Landroid/util/AttributeSet;)V
    .locals 2

    .line 20
    invoke-direct {p0, p1, p2}, Lcom/google/android/material/textfield/TextInputEditText;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;)V

    .line 21
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc64fac7521b55e1fcf3/OutlinedErrorEditText;

    if-ne v0, v1, :cond_0

    .line 22
    const-string v0, "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android"

    filled-new-array {p1, p2}, [Ljava/lang/Object;

    move-result-object p1

    const-string p2, "Auchan.Android.Controls.OutlinedErrorEditText, Auchan.Android.Net"

    invoke-static {p2, v0, p0, p1}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method public constructor <init>(Landroid/content/Context;Landroid/util/AttributeSet;I)V
    .locals 2

    .line 28
    invoke-direct {p0, p1, p2, p3}, Lcom/google/android/material/textfield/TextInputEditText;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;I)V

    .line 29
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc64fac7521b55e1fcf3/OutlinedErrorEditText;

    if-ne v0, v1, :cond_0

    .line 30
    invoke-static {p3}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p3

    filled-new-array {p1, p2, p3}, [Ljava/lang/Object;

    move-result-object p1

    const-string p2, "Auchan.Android.Controls.OutlinedErrorEditText, Auchan.Android.Net"

    const-string p3, "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib"

    invoke-static {p2, p3, p0, p1}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method private native n_getBackground()Landroid/graphics/drawable/Drawable;
.end method

.method private native n_onKeyPreIme(ILandroid/view/KeyEvent;)Z
.end method

.method private native n_setBackground(Landroid/graphics/drawable/Drawable;)V
.end method


# virtual methods
.method public getBackground()Landroid/graphics/drawable/Drawable;
    .locals 1

    .line 43
    invoke-direct {p0}, Lcrc64fac7521b55e1fcf3/OutlinedErrorEditText;->n_getBackground()Landroid/graphics/drawable/Drawable;

    move-result-object v0

    return-object v0
.end method

.method public monodroidAddReference(Ljava/lang/Object;)V
    .locals 1

    .line 58
    iget-object v0, p0, Lcrc64fac7521b55e1fcf3/OutlinedErrorEditText;->refList:Ljava/util/ArrayList;

    if-nez v0, :cond_0

    .line 59
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcrc64fac7521b55e1fcf3/OutlinedErrorEditText;->refList:Ljava/util/ArrayList;

    .line 60
    :cond_0
    iget-object v0, p0, Lcrc64fac7521b55e1fcf3/OutlinedErrorEditText;->refList:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public monodroidClearReferences()V
    .locals 1

    .line 65
    iget-object v0, p0, Lcrc64fac7521b55e1fcf3/OutlinedErrorEditText;->refList:Ljava/util/ArrayList;

    if-eqz v0, :cond_0

    .line 66
    invoke-virtual {v0}, Ljava/util/ArrayList;->clear()V

    :cond_0
    return-void
.end method

.method public onKeyPreIme(ILandroid/view/KeyEvent;)Z
    .locals 0

    .line 36
    invoke-direct {p0, p1, p2}, Lcrc64fac7521b55e1fcf3/OutlinedErrorEditText;->n_onKeyPreIme(ILandroid/view/KeyEvent;)Z

    move-result p1

    return p1
.end method

.method public setBackground(Landroid/graphics/drawable/Drawable;)V
    .locals 0

    .line 50
    invoke-direct {p0, p1}, Lcrc64fac7521b55e1fcf3/OutlinedErrorEditText;->n_setBackground(Landroid/graphics/drawable/Drawable;)V

    return-void
.end method
