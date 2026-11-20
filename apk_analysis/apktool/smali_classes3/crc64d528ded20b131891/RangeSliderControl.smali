.class public Lcrc64d528ded20b131891/RangeSliderControl;
.super Landroid/widget/ImageView;
.source "RangeSliderControl.java"

# interfaces
.implements Lmono/android/IGCUserPeer;


# instance fields
.field private refList:Ljava/util/ArrayList;


# direct methods
.method public constructor <init>(Landroid/content/Context;)V
    .locals 2

    .line 36
    invoke-direct {p0, p1}, Landroid/widget/ImageView;-><init>(Landroid/content/Context;)V

    .line 37
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc64d528ded20b131891/RangeSliderControl;

    if-ne v0, v1, :cond_0

    .line 38
    const-string v0, "Android.Content.Context, Mono.Android"

    filled-new-array {p1}, [Ljava/lang/Object;

    move-result-object p1

    const-string v1, "Xamarin.RangeSlider.RangeSliderControl, Xamarin.RangeSlider.Droid"

    invoke-static {v1, v0, p0, p1}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method public constructor <init>(Landroid/content/Context;Landroid/util/AttributeSet;)V
    .locals 2

    .line 28
    invoke-direct {p0, p1, p2}, Landroid/widget/ImageView;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;)V

    .line 29
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc64d528ded20b131891/RangeSliderControl;

    if-ne v0, v1, :cond_0

    .line 30
    const-string v0, "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android"

    filled-new-array {p1, p2}, [Ljava/lang/Object;

    move-result-object p1

    const-string p2, "Xamarin.RangeSlider.RangeSliderControl, Xamarin.RangeSlider.Droid"

    invoke-static {p2, v0, p0, p1}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method public constructor <init>(Landroid/content/Context;Landroid/util/AttributeSet;I)V
    .locals 2

    .line 20
    invoke-direct {p0, p1, p2, p3}, Landroid/widget/ImageView;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;I)V

    .line 21
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc64d528ded20b131891/RangeSliderControl;

    if-ne v0, v1, :cond_0

    .line 22
    invoke-static {p3}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p3

    filled-new-array {p1, p2, p3}, [Ljava/lang/Object;

    move-result-object p1

    const-string p2, "Xamarin.RangeSlider.RangeSliderControl, Xamarin.RangeSlider.Droid"

    const-string p3, "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib"

    invoke-static {p2, p3, p0, p1}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method public constructor <init>(Landroid/content/Context;Landroid/util/AttributeSet;II)V
    .locals 2

    .line 12
    invoke-direct {p0, p1, p2, p3, p4}, Landroid/widget/ImageView;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;II)V

    .line 13
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc64d528ded20b131891/RangeSliderControl;

    if-ne v0, v1, :cond_0

    .line 14
    invoke-static {p3}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p3

    invoke-static {p4}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p4

    filled-new-array {p1, p2, p3, p4}, [Ljava/lang/Object;

    move-result-object p1

    const-string p2, "Xamarin.RangeSlider.RangeSliderControl, Xamarin.RangeSlider.Droid"

    const-string p3, "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib"

    invoke-static {p2, p3, p0, p1}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method private native n_isEnabled()Z
.end method

.method private native n_onDraw(Landroid/graphics/Canvas;)V
.end method

.method private native n_onMeasure(II)V
.end method

.method private native n_onRestoreInstanceState(Landroid/os/Parcelable;)V
.end method

.method private native n_onSaveInstanceState()Landroid/os/Parcelable;
.end method

.method private native n_onTouchEvent(Landroid/view/MotionEvent;)Z
.end method

.method private native n_setEnabled(Z)V
.end method


# virtual methods
.method public isEnabled()Z
    .locals 1

    .line 44
    invoke-direct {p0}, Lcrc64d528ded20b131891/RangeSliderControl;->n_isEnabled()Z

    move-result v0

    return v0
.end method

.method public monodroidAddReference(Ljava/lang/Object;)V
    .locals 1

    .line 94
    iget-object v0, p0, Lcrc64d528ded20b131891/RangeSliderControl;->refList:Ljava/util/ArrayList;

    if-nez v0, :cond_0

    .line 95
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcrc64d528ded20b131891/RangeSliderControl;->refList:Ljava/util/ArrayList;

    .line 96
    :cond_0
    iget-object v0, p0, Lcrc64d528ded20b131891/RangeSliderControl;->refList:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public monodroidClearReferences()V
    .locals 1

    .line 101
    iget-object v0, p0, Lcrc64d528ded20b131891/RangeSliderControl;->refList:Ljava/util/ArrayList;

    if-eqz v0, :cond_0

    .line 102
    invoke-virtual {v0}, Ljava/util/ArrayList;->clear()V

    :cond_0
    return-void
.end method

.method public onDraw(Landroid/graphics/Canvas;)V
    .locals 0

    .line 72
    invoke-direct {p0, p1}, Lcrc64d528ded20b131891/RangeSliderControl;->n_onDraw(Landroid/graphics/Canvas;)V

    return-void
.end method

.method public onMeasure(II)V
    .locals 0

    .line 65
    invoke-direct {p0, p1, p2}, Lcrc64d528ded20b131891/RangeSliderControl;->n_onMeasure(II)V

    return-void
.end method

.method public onRestoreInstanceState(Landroid/os/Parcelable;)V
    .locals 0

    .line 86
    invoke-direct {p0, p1}, Lcrc64d528ded20b131891/RangeSliderControl;->n_onRestoreInstanceState(Landroid/os/Parcelable;)V

    return-void
.end method

.method public onSaveInstanceState()Landroid/os/Parcelable;
    .locals 1

    .line 79
    invoke-direct {p0}, Lcrc64d528ded20b131891/RangeSliderControl;->n_onSaveInstanceState()Landroid/os/Parcelable;

    move-result-object v0

    return-object v0
.end method

.method public onTouchEvent(Landroid/view/MotionEvent;)Z
    .locals 0

    .line 58
    invoke-direct {p0, p1}, Lcrc64d528ded20b131891/RangeSliderControl;->n_onTouchEvent(Landroid/view/MotionEvent;)Z

    move-result p1

    return p1
.end method

.method public setEnabled(Z)V
    .locals 0

    .line 51
    invoke-direct {p0, p1}, Lcrc64d528ded20b131891/RangeSliderControl;->n_setEnabled(Z)V

    return-void
.end method
