.class public Lcrc641d13f74a87b777a4/AddReviewFragment;
.super Lcrc64f03248cb510113f2/BaseBottomSheetDialogFragment_1;
.source "AddReviewFragment.java"

# interfaces
.implements Lmono/android/IGCUserPeer;
.implements Landroid/view/View$OnTouchListener;
.implements Landroid/app/DatePickerDialog$OnDateSetListener;
.implements Landroid/widget/TextView$OnEditorActionListener;


# instance fields
.field private refList:Ljava/util/ArrayList;


# direct methods
.method public constructor <init>()V
    .locals 3

    .line 15
    invoke-direct {p0}, Lcrc64f03248cb510113f2/BaseBottomSheetDialogFragment_1;-><init>()V

    .line 16
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc641d13f74a87b777a4/AddReviewFragment;

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 17
    new-array v0, v0, [Ljava/lang/Object;

    const-string v1, "Auchan.Android.Reviews.AddReviewFragment, Auchan.Android.Net"

    const-string v2, ""

    invoke-static {v1, v2, p0, v0}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method public constructor <init>(I)V
    .locals 2

    .line 23
    invoke-direct {p0, p1}, Lcrc64f03248cb510113f2/BaseBottomSheetDialogFragment_1;-><init>(I)V

    .line 24
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc641d13f74a87b777a4/AddReviewFragment;

    if-ne v0, v1, :cond_0

    .line 25
    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p1

    filled-new-array {p1}, [Ljava/lang/Object;

    move-result-object p1

    const-string v0, "Auchan.Android.Reviews.AddReviewFragment, Auchan.Android.Net"

    const-string v1, "System.Int32, System.Private.CoreLib"

    invoke-static {v0, v1, p0, p1}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method private native n_getTheme()I
.end method

.method private native n_onDateSet(Landroid/widget/DatePicker;III)V
.end method

.method private native n_onDestroyView()V
.end method

.method private native n_onDismiss(Landroid/content/DialogInterface;)V
.end method

.method private native n_onEditorAction(Landroid/widget/TextView;ILandroid/view/KeyEvent;)Z
.end method

.method private native n_onTouch(Landroid/view/View;Landroid/view/MotionEvent;)Z
.end method

.method private native n_onViewCreated(Landroid/view/View;Landroid/os/Bundle;)V
.end method


# virtual methods
.method public getTheme()I
    .locals 1

    .line 31
    invoke-direct {p0}, Lcrc641d13f74a87b777a4/AddReviewFragment;->n_getTheme()I

    move-result v0

    return v0
.end method

.method public monodroidAddReference(Ljava/lang/Object;)V
    .locals 1

    .line 81
    iget-object v0, p0, Lcrc641d13f74a87b777a4/AddReviewFragment;->refList:Ljava/util/ArrayList;

    if-nez v0, :cond_0

    .line 82
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcrc641d13f74a87b777a4/AddReviewFragment;->refList:Ljava/util/ArrayList;

    .line 83
    :cond_0
    iget-object v0, p0, Lcrc641d13f74a87b777a4/AddReviewFragment;->refList:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public monodroidClearReferences()V
    .locals 1

    .line 88
    iget-object v0, p0, Lcrc641d13f74a87b777a4/AddReviewFragment;->refList:Ljava/util/ArrayList;

    if-eqz v0, :cond_0

    .line 89
    invoke-virtual {v0}, Ljava/util/ArrayList;->clear()V

    :cond_0
    return-void
.end method

.method public onDateSet(Landroid/widget/DatePicker;III)V
    .locals 0

    .line 66
    invoke-direct {p0, p1, p2, p3, p4}, Lcrc641d13f74a87b777a4/AddReviewFragment;->n_onDateSet(Landroid/widget/DatePicker;III)V

    return-void
.end method

.method public onDestroyView()V
    .locals 0

    .line 38
    invoke-direct {p0}, Lcrc641d13f74a87b777a4/AddReviewFragment;->n_onDestroyView()V

    return-void
.end method

.method public onDismiss(Landroid/content/DialogInterface;)V
    .locals 0

    .line 52
    invoke-direct {p0, p1}, Lcrc641d13f74a87b777a4/AddReviewFragment;->n_onDismiss(Landroid/content/DialogInterface;)V

    return-void
.end method

.method public onEditorAction(Landroid/widget/TextView;ILandroid/view/KeyEvent;)Z
    .locals 0

    .line 73
    invoke-direct {p0, p1, p2, p3}, Lcrc641d13f74a87b777a4/AddReviewFragment;->n_onEditorAction(Landroid/widget/TextView;ILandroid/view/KeyEvent;)Z

    move-result p1

    return p1
.end method

.method public onTouch(Landroid/view/View;Landroid/view/MotionEvent;)Z
    .locals 0

    .line 59
    invoke-direct {p0, p1, p2}, Lcrc641d13f74a87b777a4/AddReviewFragment;->n_onTouch(Landroid/view/View;Landroid/view/MotionEvent;)Z

    move-result p1

    return p1
.end method

.method public onViewCreated(Landroid/view/View;Landroid/os/Bundle;)V
    .locals 0

    .line 45
    invoke-direct {p0, p1, p2}, Lcrc641d13f74a87b777a4/AddReviewFragment;->n_onViewCreated(Landroid/view/View;Landroid/os/Bundle;)V

    return-void
.end method
