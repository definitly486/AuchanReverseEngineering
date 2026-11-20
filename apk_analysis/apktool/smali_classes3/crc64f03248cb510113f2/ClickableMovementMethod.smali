.class public Lcrc64f03248cb510113f2/ClickableMovementMethod;
.super Landroid/text/method/BaseMovementMethod;
.source "ClickableMovementMethod.java"

# interfaces
.implements Lmono/android/IGCUserPeer;


# instance fields
.field private refList:Ljava/util/ArrayList;


# direct methods
.method public constructor <init>()V
    .locals 3

    .line 12
    invoke-direct {p0}, Landroid/text/method/BaseMovementMethod;-><init>()V

    .line 13
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc64f03248cb510113f2/ClickableMovementMethod;

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 14
    new-array v0, v0, [Ljava/lang/Object;

    const-string v1, "Auchan.Android.Base.ClickableMovementMethod, Auchan.Android.Net"

    const-string v2, ""

    invoke-static {v1, v2, p0, v0}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method private native n_canSelectArbitrarily()Z
.end method

.method private native n_initialize(Landroid/widget/TextView;Landroid/text/Spannable;)V
.end method

.method private native n_onTouchEvent(Landroid/widget/TextView;Landroid/text/Spannable;Landroid/view/MotionEvent;)Z
.end method


# virtual methods
.method public canSelectArbitrarily()Z
    .locals 1

    .line 27
    invoke-direct {p0}, Lcrc64f03248cb510113f2/ClickableMovementMethod;->n_canSelectArbitrarily()Z

    move-result v0

    return v0
.end method

.method public initialize(Landroid/widget/TextView;Landroid/text/Spannable;)V
    .locals 0

    .line 34
    invoke-direct {p0, p1, p2}, Lcrc64f03248cb510113f2/ClickableMovementMethod;->n_initialize(Landroid/widget/TextView;Landroid/text/Spannable;)V

    return-void
.end method

.method public monodroidAddReference(Ljava/lang/Object;)V
    .locals 1

    .line 42
    iget-object v0, p0, Lcrc64f03248cb510113f2/ClickableMovementMethod;->refList:Ljava/util/ArrayList;

    if-nez v0, :cond_0

    .line 43
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcrc64f03248cb510113f2/ClickableMovementMethod;->refList:Ljava/util/ArrayList;

    .line 44
    :cond_0
    iget-object v0, p0, Lcrc64f03248cb510113f2/ClickableMovementMethod;->refList:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public monodroidClearReferences()V
    .locals 1

    .line 49
    iget-object v0, p0, Lcrc64f03248cb510113f2/ClickableMovementMethod;->refList:Ljava/util/ArrayList;

    if-eqz v0, :cond_0

    .line 50
    invoke-virtual {v0}, Ljava/util/ArrayList;->clear()V

    :cond_0
    return-void
.end method

.method public onTouchEvent(Landroid/widget/TextView;Landroid/text/Spannable;Landroid/view/MotionEvent;)Z
    .locals 0

    .line 20
    invoke-direct {p0, p1, p2, p3}, Lcrc64f03248cb510113f2/ClickableMovementMethod;->n_onTouchEvent(Landroid/widget/TextView;Landroid/text/Spannable;Landroid/view/MotionEvent;)Z

    move-result p1

    return p1
.end method
