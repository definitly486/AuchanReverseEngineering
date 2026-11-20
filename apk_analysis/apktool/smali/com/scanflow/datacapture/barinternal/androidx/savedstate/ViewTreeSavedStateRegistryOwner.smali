.class public abstract Lcom/scanflow/datacapture/barinternal/androidx/savedstate/ViewTreeSavedStateRegistryOwner;
.super Ljava/lang/Object;
.source "ViewTreeSavedStateRegistryOwner.android.kt"


# direct methods
.method public static final set(Landroid/view/View;Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateRegistryOwner;)V
    .locals 1

    const-string v0, "<this>"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 39
    sget v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/R$id;->view_tree_saved_state_registry_owner:I

    invoke-virtual {p0, v0, p1}, Landroid/view/View;->setTag(ILjava/lang/Object;)V

    return-void
.end method
