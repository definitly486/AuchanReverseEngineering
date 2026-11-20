.class public final Landroidx/lifecycle/LifecycleRegistry_androidKt;
.super Ljava/lang/Object;
.source "LifecycleRegistry.android.kt"


# direct methods
.method public static final isMainThread()Z
    .locals 1
    .annotation build Landroid/annotation/SuppressLint;
        value = {
            "RestrictedApi"
        }
    .end annotation

    .line 23
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/arch/core/executor/ArchTaskExecutor;->getInstance()Lcom/scanflow/datacapture/barinternal/androidx/arch/core/executor/ArchTaskExecutor;

    move-result-object v0

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/arch/core/executor/ArchTaskExecutor;->isMainThread()Z

    move-result v0

    return v0
.end method
