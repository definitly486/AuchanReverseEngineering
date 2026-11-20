.class public abstract Lcom/scanflow/datacapture/barinternal/kotlin/jdk7/AutoCloseableKt;
.super Ljava/lang/Object;
.source "AutoCloseableJVM.kt"


# direct methods
.method public static final closeFinally(Ljava/lang/AutoCloseable;Ljava/lang/Throwable;)V
    .locals 0

    if-eqz p0, :cond_1

    if-nez p1, :cond_0

    .line 43
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/androidx/lifecycle/viewmodel/internal/ViewModelImpl$$ExternalSyntheticAutoCloseableDispatcher0;->m(Ljava/lang/Object;)V

    return-void

    .line 46
    :cond_0
    :try_start_0
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/androidx/lifecycle/viewmodel/internal/ViewModelImpl$$ExternalSyntheticAutoCloseableDispatcher0;->m(Ljava/lang/Object;)V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    return-void

    :catchall_0
    move-exception p0

    .line 48
    invoke-static {p1, p0}, Lcom/scanflow/datacapture/barinternal/kotlin/ExceptionsKt;->addSuppressed(Ljava/lang/Throwable;Ljava/lang/Throwable;)V

    :cond_1
    return-void
.end method
