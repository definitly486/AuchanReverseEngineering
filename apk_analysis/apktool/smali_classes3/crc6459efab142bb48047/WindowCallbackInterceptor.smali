.class public Lcrc6459efab142bb48047/WindowCallbackInterceptor;
.super Ljava/lang/Object;
.source "WindowCallbackInterceptor.java"

# interfaces
.implements Lmono/android/IGCUserPeer;
.implements Landroid/view/Window$Callback;


# instance fields
.field private refList:Ljava/util/ArrayList;


# direct methods
.method public constructor <init>()V
    .locals 3

    .line 13
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 14
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc6459efab142bb48047/WindowCallbackInterceptor;

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 15
    new-array v0, v0, [Ljava/lang/Object;

    const-string v1, "Auchan.Android.Common.UiUtils.WindowCallbackInterceptor, Auchan.Android.Net"

    const-string v2, ""

    invoke-static {v1, v2, p0, v0}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method public constructor <init>(Landroid/view/Window;)V
    .locals 2

    .line 21
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 22
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc6459efab142bb48047/WindowCallbackInterceptor;

    if-ne v0, v1, :cond_0

    .line 23
    const-string v0, "Android.Views.Window, Mono.Android"

    filled-new-array {p1}, [Ljava/lang/Object;

    move-result-object p1

    const-string v1, "Auchan.Android.Common.UiUtils.WindowCallbackInterceptor, Auchan.Android.Net"

    invoke-static {v1, v0, p0, p1}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method private native n_dispatchGenericMotionEvent(Landroid/view/MotionEvent;)Z
.end method

.method private native n_dispatchKeyEvent(Landroid/view/KeyEvent;)Z
.end method

.method private native n_dispatchKeyShortcutEvent(Landroid/view/KeyEvent;)Z
.end method

.method private native n_dispatchPopulateAccessibilityEvent(Landroid/view/accessibility/AccessibilityEvent;)Z
.end method

.method private native n_dispatchTouchEvent(Landroid/view/MotionEvent;)Z
.end method

.method private native n_dispatchTrackballEvent(Landroid/view/MotionEvent;)Z
.end method

.method private native n_onActionModeFinished(Landroid/view/ActionMode;)V
.end method

.method private native n_onActionModeStarted(Landroid/view/ActionMode;)V
.end method

.method private native n_onAttachedToWindow()V
.end method

.method private native n_onContentChanged()V
.end method

.method private native n_onCreatePanelMenu(ILandroid/view/Menu;)Z
.end method

.method private native n_onCreatePanelView(I)Landroid/view/View;
.end method

.method private native n_onDetachedFromWindow()V
.end method

.method private native n_onMenuItemSelected(ILandroid/view/MenuItem;)Z
.end method

.method private native n_onMenuOpened(ILandroid/view/Menu;)Z
.end method

.method private native n_onPanelClosed(ILandroid/view/Menu;)V
.end method

.method private native n_onPointerCaptureChanged(Z)V
.end method

.method private native n_onPreparePanel(ILandroid/view/View;Landroid/view/Menu;)Z
.end method

.method private native n_onProvideKeyboardShortcuts(Ljava/util/List;Landroid/view/Menu;I)V
.end method

.method private native n_onSearchRequested()Z
.end method

.method private native n_onSearchRequested(Landroid/view/SearchEvent;)Z
.end method

.method private native n_onWindowAttributesChanged(Landroid/view/WindowManager$LayoutParams;)V
.end method

.method private native n_onWindowFocusChanged(Z)V
.end method

.method private native n_onWindowStartingActionMode(Landroid/view/ActionMode$Callback;)Landroid/view/ActionMode;
.end method

.method private native n_onWindowStartingActionMode(Landroid/view/ActionMode$Callback;I)Landroid/view/ActionMode;
.end method


# virtual methods
.method public dispatchGenericMotionEvent(Landroid/view/MotionEvent;)Z
    .locals 0

    .line 29
    invoke-direct {p0, p1}, Lcrc6459efab142bb48047/WindowCallbackInterceptor;->n_dispatchGenericMotionEvent(Landroid/view/MotionEvent;)Z

    move-result p1

    return p1
.end method

.method public dispatchKeyEvent(Landroid/view/KeyEvent;)Z
    .locals 0

    .line 36
    invoke-direct {p0, p1}, Lcrc6459efab142bb48047/WindowCallbackInterceptor;->n_dispatchKeyEvent(Landroid/view/KeyEvent;)Z

    move-result p1

    return p1
.end method

.method public dispatchKeyShortcutEvent(Landroid/view/KeyEvent;)Z
    .locals 0

    .line 43
    invoke-direct {p0, p1}, Lcrc6459efab142bb48047/WindowCallbackInterceptor;->n_dispatchKeyShortcutEvent(Landroid/view/KeyEvent;)Z

    move-result p1

    return p1
.end method

.method public dispatchPopulateAccessibilityEvent(Landroid/view/accessibility/AccessibilityEvent;)Z
    .locals 0

    .line 50
    invoke-direct {p0, p1}, Lcrc6459efab142bb48047/WindowCallbackInterceptor;->n_dispatchPopulateAccessibilityEvent(Landroid/view/accessibility/AccessibilityEvent;)Z

    move-result p1

    return p1
.end method

.method public dispatchTouchEvent(Landroid/view/MotionEvent;)Z
    .locals 0

    .line 57
    invoke-direct {p0, p1}, Lcrc6459efab142bb48047/WindowCallbackInterceptor;->n_dispatchTouchEvent(Landroid/view/MotionEvent;)Z

    move-result p1

    return p1
.end method

.method public dispatchTrackballEvent(Landroid/view/MotionEvent;)Z
    .locals 0

    .line 64
    invoke-direct {p0, p1}, Lcrc6459efab142bb48047/WindowCallbackInterceptor;->n_dispatchTrackballEvent(Landroid/view/MotionEvent;)Z

    move-result p1

    return p1
.end method

.method public monodroidAddReference(Ljava/lang/Object;)V
    .locals 1

    .line 205
    iget-object v0, p0, Lcrc6459efab142bb48047/WindowCallbackInterceptor;->refList:Ljava/util/ArrayList;

    if-nez v0, :cond_0

    .line 206
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcrc6459efab142bb48047/WindowCallbackInterceptor;->refList:Ljava/util/ArrayList;

    .line 207
    :cond_0
    iget-object v0, p0, Lcrc6459efab142bb48047/WindowCallbackInterceptor;->refList:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public monodroidClearReferences()V
    .locals 1

    .line 212
    iget-object v0, p0, Lcrc6459efab142bb48047/WindowCallbackInterceptor;->refList:Ljava/util/ArrayList;

    if-eqz v0, :cond_0

    .line 213
    invoke-virtual {v0}, Ljava/util/ArrayList;->clear()V

    :cond_0
    return-void
.end method

.method public onActionModeFinished(Landroid/view/ActionMode;)V
    .locals 0

    .line 71
    invoke-direct {p0, p1}, Lcrc6459efab142bb48047/WindowCallbackInterceptor;->n_onActionModeFinished(Landroid/view/ActionMode;)V

    return-void
.end method

.method public onActionModeStarted(Landroid/view/ActionMode;)V
    .locals 0

    .line 78
    invoke-direct {p0, p1}, Lcrc6459efab142bb48047/WindowCallbackInterceptor;->n_onActionModeStarted(Landroid/view/ActionMode;)V

    return-void
.end method

.method public onAttachedToWindow()V
    .locals 0

    .line 85
    invoke-direct {p0}, Lcrc6459efab142bb48047/WindowCallbackInterceptor;->n_onAttachedToWindow()V

    return-void
.end method

.method public onContentChanged()V
    .locals 0

    .line 92
    invoke-direct {p0}, Lcrc6459efab142bb48047/WindowCallbackInterceptor;->n_onContentChanged()V

    return-void
.end method

.method public onCreatePanelMenu(ILandroid/view/Menu;)Z
    .locals 0

    .line 99
    invoke-direct {p0, p1, p2}, Lcrc6459efab142bb48047/WindowCallbackInterceptor;->n_onCreatePanelMenu(ILandroid/view/Menu;)Z

    move-result p1

    return p1
.end method

.method public onCreatePanelView(I)Landroid/view/View;
    .locals 0

    .line 106
    invoke-direct {p0, p1}, Lcrc6459efab142bb48047/WindowCallbackInterceptor;->n_onCreatePanelView(I)Landroid/view/View;

    move-result-object p1

    return-object p1
.end method

.method public onDetachedFromWindow()V
    .locals 0

    .line 113
    invoke-direct {p0}, Lcrc6459efab142bb48047/WindowCallbackInterceptor;->n_onDetachedFromWindow()V

    return-void
.end method

.method public onMenuItemSelected(ILandroid/view/MenuItem;)Z
    .locals 0

    .line 120
    invoke-direct {p0, p1, p2}, Lcrc6459efab142bb48047/WindowCallbackInterceptor;->n_onMenuItemSelected(ILandroid/view/MenuItem;)Z

    move-result p1

    return p1
.end method

.method public onMenuOpened(ILandroid/view/Menu;)Z
    .locals 0

    .line 127
    invoke-direct {p0, p1, p2}, Lcrc6459efab142bb48047/WindowCallbackInterceptor;->n_onMenuOpened(ILandroid/view/Menu;)Z

    move-result p1

    return p1
.end method

.method public onPanelClosed(ILandroid/view/Menu;)V
    .locals 0

    .line 134
    invoke-direct {p0, p1, p2}, Lcrc6459efab142bb48047/WindowCallbackInterceptor;->n_onPanelClosed(ILandroid/view/Menu;)V

    return-void
.end method

.method public onPointerCaptureChanged(Z)V
    .locals 0

    .line 190
    invoke-direct {p0, p1}, Lcrc6459efab142bb48047/WindowCallbackInterceptor;->n_onPointerCaptureChanged(Z)V

    return-void
.end method

.method public onPreparePanel(ILandroid/view/View;Landroid/view/Menu;)Z
    .locals 0

    .line 141
    invoke-direct {p0, p1, p2, p3}, Lcrc6459efab142bb48047/WindowCallbackInterceptor;->n_onPreparePanel(ILandroid/view/View;Landroid/view/Menu;)Z

    move-result p1

    return p1
.end method

.method public onProvideKeyboardShortcuts(Ljava/util/List;Landroid/view/Menu;I)V
    .locals 0

    .line 197
    invoke-direct {p0, p1, p2, p3}, Lcrc6459efab142bb48047/WindowCallbackInterceptor;->n_onProvideKeyboardShortcuts(Ljava/util/List;Landroid/view/Menu;I)V

    return-void
.end method

.method public onSearchRequested()Z
    .locals 1

    .line 148
    invoke-direct {p0}, Lcrc6459efab142bb48047/WindowCallbackInterceptor;->n_onSearchRequested()Z

    move-result v0

    return v0
.end method

.method public onSearchRequested(Landroid/view/SearchEvent;)Z
    .locals 0

    .line 155
    invoke-direct {p0, p1}, Lcrc6459efab142bb48047/WindowCallbackInterceptor;->n_onSearchRequested(Landroid/view/SearchEvent;)Z

    move-result p1

    return p1
.end method

.method public onWindowAttributesChanged(Landroid/view/WindowManager$LayoutParams;)V
    .locals 0

    .line 162
    invoke-direct {p0, p1}, Lcrc6459efab142bb48047/WindowCallbackInterceptor;->n_onWindowAttributesChanged(Landroid/view/WindowManager$LayoutParams;)V

    return-void
.end method

.method public onWindowFocusChanged(Z)V
    .locals 0

    .line 169
    invoke-direct {p0, p1}, Lcrc6459efab142bb48047/WindowCallbackInterceptor;->n_onWindowFocusChanged(Z)V

    return-void
.end method

.method public onWindowStartingActionMode(Landroid/view/ActionMode$Callback;)Landroid/view/ActionMode;
    .locals 0

    .line 183
    invoke-direct {p0, p1}, Lcrc6459efab142bb48047/WindowCallbackInterceptor;->n_onWindowStartingActionMode(Landroid/view/ActionMode$Callback;)Landroid/view/ActionMode;

    move-result-object p1

    return-object p1
.end method

.method public onWindowStartingActionMode(Landroid/view/ActionMode$Callback;I)Landroid/view/ActionMode;
    .locals 0

    .line 176
    invoke-direct {p0, p1, p2}, Lcrc6459efab142bb48047/WindowCallbackInterceptor;->n_onWindowStartingActionMode(Landroid/view/ActionMode$Callback;I)Landroid/view/ActionMode;

    move-result-object p1

    return-object p1
.end method
