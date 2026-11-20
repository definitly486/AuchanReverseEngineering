.class public abstract Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/CoroutineExceptionHandlerImpl_commonKt;
.super Ljava/lang/Object;
.source "CoroutineExceptionHandlerImpl.common.kt"


# direct methods
.method public static final handleUncaughtCoroutineException(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Throwable;)V
    .locals 2

    .line 32
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/CoroutineExceptionHandlerImplKt;->getPlatformExceptionHandlers()Ljava/util/Collection;

    move-result-object v0

    invoke-interface {v0}, Ljava/util/Collection;->iterator()Ljava/util/Iterator;

    move-result-object v0

    :goto_0
    invoke-interface {v0}, Ljava/util/Iterator;->hasNext()Z

    move-result v1

    if-eqz v1, :cond_0

    invoke-interface {v0}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandler;

    .line 34
    :try_start_0
    invoke-interface {v1, p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandler;->handleException(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Throwable;)V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    goto :goto_0

    :catchall_0
    move-exception v1

    .line 38
    invoke-static {p1, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandlerKt;->handlerException(Ljava/lang/Throwable;Ljava/lang/Throwable;)Ljava/lang/Throwable;

    move-result-object v1

    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/CoroutineExceptionHandlerImplKt;->propagateExceptionFinalResort(Ljava/lang/Throwable;)V

    goto :goto_0

    .line 43
    :cond_0
    :try_start_1
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DiagnosticCoroutineContextException;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DiagnosticCoroutineContextException;-><init>(Lkotlin/coroutines/CoroutineContext;)V

    invoke-static {p1, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/ExceptionsKt;->addSuppressed(Ljava/lang/Throwable;Ljava/lang/Throwable;)V
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_1

    .line 48
    :catchall_1
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/CoroutineExceptionHandlerImplKt;->propagateExceptionFinalResort(Ljava/lang/Throwable;)V

    return-void
.end method
