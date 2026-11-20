.class public abstract Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ExecutorsKt;
.super Ljava/lang/Object;
.source "Executors.kt"


# direct methods
.method public static final asExecutor(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;)Ljava/util/concurrent/Executor;
    .locals 1

    .line 104
    instance-of v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ExecutorCoroutineDispatcher;

    if-eqz v0, :cond_0

    move-object v0, p0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ExecutorCoroutineDispatcher;

    goto :goto_0

    :cond_0
    const/4 v0, 0x0

    :goto_0
    if-eqz v0, :cond_2

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ExecutorCoroutineDispatcher;->getExecutor()Ljava/util/concurrent/Executor;

    move-result-object v0

    if-nez v0, :cond_1

    goto :goto_1

    :cond_1
    return-object v0

    :cond_2
    :goto_1
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatcherExecutor;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatcherExecutor;-><init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;)V

    return-object v0
.end method

.method public static final from(Ljava/util/concurrent/Executor;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;
    .locals 1

    .line 96
    instance-of v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatcherExecutor;

    if-eqz v0, :cond_0

    move-object v0, p0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatcherExecutor;

    goto :goto_0

    :cond_0
    const/4 v0, 0x0

    :goto_0
    if-eqz v0, :cond_2

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatcherExecutor;->dispatcher:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;

    if-nez v0, :cond_1

    goto :goto_1

    :cond_1
    return-object v0

    :cond_2
    :goto_1
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ExecutorCoroutineDispatcherImpl;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ExecutorCoroutineDispatcherImpl;-><init>(Ljava/util/concurrent/Executor;)V

    return-object v0
.end method
