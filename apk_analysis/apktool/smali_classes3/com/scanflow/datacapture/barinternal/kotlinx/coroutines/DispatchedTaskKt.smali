.class public abstract Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTaskKt;
.super Ljava/lang/Object;
.source "DispatchedTask.kt"


# direct methods
.method public static final dispatch(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;I)V
    .locals 3

    .line 138
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;->getDelegate$kotlinx_coroutines_core()Lkotlin/coroutines/Continuation;

    move-result-object v0

    const/4 v1, 0x4

    if-ne p1, v1, :cond_0

    const/4 v1, 0x1

    goto :goto_0

    :cond_0
    const/4 v1, 0x0

    :goto_0
    if-nez v1, :cond_2

    .line 140
    instance-of v2, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;

    if-eqz v2, :cond_2

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTaskKt;->isCancellableMode(I)Z

    move-result p1

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;->resumeMode:I

    invoke-static {v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTaskKt;->isCancellableMode(I)Z

    move-result v2

    if-ne p1, v2, :cond_2

    .line 142
    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;

    iget-object p1, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->dispatcher:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;

    .line 143
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->getContext()Lkotlin/coroutines/CoroutineContext;

    move-result-object v0

    .line 144
    invoke-static {p1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuationKt;->safeIsDispatchNeeded(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;Lkotlin/coroutines/CoroutineContext;)Z

    move-result v1

    if-eqz v1, :cond_1

    .line 145
    invoke-static {p1, v0, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuationKt;->safeDispatch(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;Lkotlin/coroutines/CoroutineContext;Ljava/lang/Runnable;)V

    return-void

    .line 147
    :cond_1
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTaskKt;->resumeUnconfined(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;)V

    return-void

    .line 152
    :cond_2
    invoke-static {p0, v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTaskKt;->resume(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;Lkotlin/coroutines/Continuation;Z)V

    return-void
.end method

.method public static final isCancellableMode(I)Z
    .locals 2

    .line 43
    const/4 v0, 0x1

    if-eq p0, v0, :cond_1

    const/4 v1, 0x2

    if-ne p0, v1, :cond_0

    goto :goto_0

    :cond_0
    const/4 p0, 0x0

    return p0

    :cond_1
    :goto_0
    return v0
.end method

.method public static final isReusableMode(I)Z
    .locals 1

    .line 44
    const/4 v0, 0x2

    if-ne p0, v0, :cond_0

    const/4 p0, 0x1

    return p0

    :cond_0
    const/4 p0, 0x0

    return p0
.end method

.method public static final resume(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;Lkotlin/coroutines/Continuation;Z)V
    .locals 3

    .line 158
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;->takeState$kotlinx_coroutines_core()Ljava/lang/Object;

    move-result-object v0

    .line 159
    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;->getExceptionalResult$kotlinx_coroutines_core(Ljava/lang/Object;)Ljava/lang/Throwable;

    move-result-object v1

    if-eqz v1, :cond_0

    .line 160
    sget-object p0, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/Result$Companion;

    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/kotlin/ResultKt;->createFailure(Ljava/lang/Throwable;)Ljava/lang/Object;

    move-result-object p0

    :goto_0
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->constructor-impl(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p0

    goto :goto_1

    :cond_0
    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/Result$Companion;

    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;->getSuccessfulResult$kotlinx_coroutines_core(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p0

    goto :goto_0

    :goto_1
    if-eqz p2, :cond_6

    .line 162
    const-string p2, "null cannot be cast to non-null type kotlinx.coroutines.internal.DispatchedContinuation<T of kotlinx.coroutines.DispatchedTaskKt.resume>"

    invoke-static {p1, p2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;

    .line 222
    iget-object p2, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->continuation:Lkotlin/coroutines/Continuation;

    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->countOrElement:Ljava/lang/Object;

    .line 223
    invoke-interface {p2}, Lkotlin/coroutines/Continuation;->getContext()Lkotlin/coroutines/CoroutineContext;

    move-result-object v1

    .line 224
    invoke-static {v1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadContextKt;->updateThreadContext(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    .line 225
    sget-object v2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadContextKt;->NO_THREAD_ELEMENTS:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    if-eq v0, v2, :cond_1

    .line 227
    invoke-static {p2, v1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineContextKt;->updateUndispatchedCompletion(Lkotlin/coroutines/Continuation;Lkotlin/coroutines/CoroutineContext;Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/UndispatchedCoroutine;

    move-result-object p2

    goto :goto_2

    :cond_1
    const/4 p2, 0x0

    .line 233
    :goto_2
    :try_start_0
    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->continuation:Lkotlin/coroutines/Continuation;

    invoke-interface {p1, p0}, Lkotlin/coroutines/Continuation;->resumeWith(Ljava/lang/Object;)V

    .line 234
    sget-object p0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    if-eqz p2, :cond_3

    .line 235
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/UndispatchedCoroutine;->clearThreadContext()Z

    move-result p0

    if-eqz p0, :cond_2

    goto :goto_3

    :cond_2
    return-void

    .line 236
    :cond_3
    :goto_3
    invoke-static {v1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadContextKt;->restoreThreadContext(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Object;)V

    return-void

    :catchall_0
    move-exception p0

    if-eqz p2, :cond_4

    .line 235
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/UndispatchedCoroutine;->clearThreadContext()Z

    move-result p1

    if-eqz p1, :cond_5

    .line 236
    :cond_4
    invoke-static {v1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadContextKt;->restoreThreadContext(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Object;)V

    :cond_5
    throw p0

    .line 163
    :cond_6
    invoke-interface {p1, p0}, Lkotlin/coroutines/Continuation;->resumeWith(Ljava/lang/Object;)V

    return-void
.end method

.method private static final resumeUnconfined(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;)V
    .locals 3

    .line 168
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ThreadLocalEventLoop;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ThreadLocalEventLoop;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ThreadLocalEventLoop;->getEventLoop$kotlinx_coroutines_core()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;

    move-result-object v0

    .line 169
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;->isUnconfinedLoopActive()Z

    move-result v1

    if-eqz v1, :cond_0

    .line 171
    invoke-virtual {v0, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;->dispatchUnconfined(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;)V

    return-void

    :cond_0
    const/4 v1, 0x1

    .line 238
    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;->incrementUseCount(Z)V

    .line 175
    :try_start_0
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;->getDelegate$kotlinx_coroutines_core()Lkotlin/coroutines/Continuation;

    move-result-object v2

    invoke-static {p0, v2, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTaskKt;->resume(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;Lkotlin/coroutines/Continuation;Z)V

    .line 243
    :cond_1
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;->processUnconfinedEvent()Z

    move-result v2
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    if-nez v2, :cond_1

    .line 252
    :goto_0
    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;->decrementUseCount(Z)V

    goto :goto_1

    :catchall_0
    move-exception v2

    .line 250
    :try_start_1
    invoke-virtual {p0, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;->handleFatalException$kotlinx_coroutines_core(Ljava/lang/Throwable;)V
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_1

    goto :goto_0

    :goto_1
    return-void

    :catchall_1
    move-exception p0

    .line 252
    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;->decrementUseCount(Z)V

    throw p0
.end method
