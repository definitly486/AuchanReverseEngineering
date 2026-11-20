.class public final Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateRegistryController;
.super Ljava/lang/Object;
.source "SavedStateRegistryController.android.kt"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateRegistryController$Companion;
    }
.end annotation


# static fields
.field public static final Companion:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateRegistryController$Companion;


# instance fields
.field private final impl:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/internal/SavedStateRegistryImpl;

.field private final savedStateRegistry:Landroidx/savedstate/SavedStateRegistry;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateRegistryController$Companion;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateRegistryController$Companion;-><init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateRegistryController;->Companion:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateRegistryController$Companion;

    return-void
.end method

.method private constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/savedstate/internal/SavedStateRegistryImpl;)V
    .locals 1

    .line 22
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 23
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateRegistryController;->impl:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/internal/SavedStateRegistryImpl;

    .line 26
    new-instance v0, Landroidx/savedstate/SavedStateRegistry;

    invoke-direct {v0, p1}, Landroidx/savedstate/SavedStateRegistry;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/savedstate/internal/SavedStateRegistryImpl;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateRegistryController;->savedStateRegistry:Landroidx/savedstate/SavedStateRegistry;

    return-void
.end method

.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/savedstate/internal/SavedStateRegistryImpl;Lkotlin/jvm/internal/DefaultConstructorMarker;)V
    .locals 0

    .line 0
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateRegistryController;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/savedstate/internal/SavedStateRegistryImpl;)V

    return-void
.end method

.method public static final create(Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateRegistryOwner;)Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateRegistryController;
    .locals 1

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateRegistryController;->Companion:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateRegistryController$Companion;

    invoke-virtual {v0, p0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateRegistryController$Companion;->create(Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateRegistryOwner;)Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateRegistryController;

    move-result-object p0

    return-object p0
.end method


# virtual methods
.method public final getSavedStateRegistry()Landroidx/savedstate/SavedStateRegistry;
    .locals 1

    .line 26
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateRegistryController;->savedStateRegistry:Landroidx/savedstate/SavedStateRegistry;

    return-object v0
.end method

.method public final performAttach()V
    .locals 1

    .line 30
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateRegistryController;->impl:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/internal/SavedStateRegistryImpl;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/internal/SavedStateRegistryImpl;->performAttach()V

    return-void
.end method

.method public final performRestore(Landroid/os/Bundle;)V
    .locals 1

    .line 35
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateRegistryController;->impl:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/internal/SavedStateRegistryImpl;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/internal/SavedStateRegistryImpl;->performRestore$savedstate_release(Landroid/os/Bundle;)V

    return-void
.end method

.method public final performSave(Landroid/os/Bundle;)V
    .locals 1

    const-string v0, "outBundle"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 40
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateRegistryController;->impl:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/internal/SavedStateRegistryImpl;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/internal/SavedStateRegistryImpl;->performSave$savedstate_release(Landroid/os/Bundle;)V

    return-void
.end method
