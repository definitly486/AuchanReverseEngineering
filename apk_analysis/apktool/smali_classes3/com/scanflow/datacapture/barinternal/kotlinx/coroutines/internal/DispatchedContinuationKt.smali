.class public abstract Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuationKt;
.super Ljava/lang/Object;
.source "DispatchedContinuation.kt"


# static fields
.field public static final REUSABLE_CLAIMED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

.field private static final UNDEFINED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 8
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    const-string v1, "UNDEFINED"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;-><init>(Ljava/lang/String;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuationKt;->UNDEFINED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    .line 10
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    const-string v1, "REUSABLE_CLAIMED"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;-><init>(Ljava/lang/String;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuationKt;->REUSABLE_CLAIMED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    return-void
.end method

.method public static final synthetic access$getUNDEFINED$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;
    .locals 1

    .line 1
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuationKt;->UNDEFINED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    return-object v0
.end method

.method public static final resumeCancellableWith(Lkotlin/coroutines/Continuation;Ljava/lang/Object;)V
    .locals 6

    .line 278
    instance-of v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;

    if-eqz v0, :cond_8

    check-cast p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;

    .line 314
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletionStateKt;->toState(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    .line 315
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->dispatcher:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->getContext()Lkotlin/coroutines/CoroutineContext;

    move-result-object v2

    invoke-static {v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuationKt;->safeIsDispatchNeeded(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;Lkotlin/coroutines/CoroutineContext;)Z

    move-result v1

    const/4 v2, 0x1

    if-eqz v1, :cond_0

    .line 316
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->_state:Ljava/lang/Object;

    .line 317
    iput v2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;->resumeMode:I

    .line 318
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->dispatcher:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->getContext()Lkotlin/coroutines/CoroutineContext;

    move-result-object v0

    invoke-static {p1, v0, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuationKt;->safeDispatch(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;Lkotlin/coroutines/CoroutineContext;Ljava/lang/Runnable;)V

    goto/16 :goto_4

    .line 327
    :cond_0
    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ThreadLocalEventLoop;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ThreadLocalEventLoop;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ThreadLocalEventLoop;->getEventLoop$kotlinx_coroutines_core()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;

    move-result-object v1

    .line 330
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;->isUnconfinedLoopActive()Z

    move-result v3

    if-eqz v3, :cond_1

    .line 332
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->_state:Ljava/lang/Object;

    .line 333
    iput v2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;->resumeMode:I

    .line 334
    invoke-virtual {v1, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;->dispatchUnconfined(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;)V

    goto/16 :goto_4

    .line 339
    :cond_1
    invoke-virtual {v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;->incrementUseCount(Z)V

    .line 352
    :try_start_0
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->getContext()Lkotlin/coroutines/CoroutineContext;

    move-result-object v3

    sget-object v4, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;->Key:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job$Key;

    invoke-interface {v3, v4}, Lkotlin/coroutines/CoroutineContext;->get(Lkotlin/coroutines/CoroutineContext$Key;)Lkotlin/coroutines/CoroutineContext$Element;

    move-result-object v3

    check-cast v3, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;

    if-eqz v3, :cond_2

    .line 353
    invoke-interface {v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;->isActive()Z

    move-result v4

    if-nez v4, :cond_2

    .line 354
    invoke-interface {v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;->getCancellationException()Ljava/util/concurrent/CancellationException;

    move-result-object p1

    .line 355
    invoke-virtual {p0, v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;->cancelCompletedResult$kotlinx_coroutines_core(Ljava/lang/Object;Ljava/lang/Throwable;)V

    .line 356
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/Result$Companion;

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/ResultKt;->createFailure(Ljava/lang/Throwable;)Ljava/lang/Object;

    move-result-object p1

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->constructor-impl(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    invoke-interface {p0, p1}, Lkotlin/coroutines/Continuation;->resumeWith(Ljava/lang/Object;)V

    goto :goto_1

    :catchall_0
    move-exception p1

    goto :goto_3

    .line 364
    :cond_2
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->continuation:Lkotlin/coroutines/Continuation;

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->countOrElement:Ljava/lang/Object;

    .line 365
    invoke-interface {v0}, Lkotlin/coroutines/Continuation;->getContext()Lkotlin/coroutines/CoroutineContext;

    move-result-object v4

    .line 366
    invoke-static {v4, v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadContextKt;->updateThreadContext(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v3

    .line 367
    sget-object v5, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadContextKt;->NO_THREAD_ELEMENTS:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    if-eq v3, v5, :cond_3

    .line 369
    invoke-static {v0, v4, v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineContextKt;->updateUndispatchedCompletion(Lkotlin/coroutines/Continuation;Lkotlin/coroutines/CoroutineContext;Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/UndispatchedCoroutine;

    move-result-object v0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    goto :goto_0

    :cond_3
    const/4 v0, 0x0

    .line 375
    :goto_0
    :try_start_1
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->continuation:Lkotlin/coroutines/Continuation;

    invoke-interface {v5, p1}, Lkotlin/coroutines/Continuation;->resumeWith(Ljava/lang/Object;)V

    .line 376
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_1

    if-eqz v0, :cond_4

    .line 377
    :try_start_2
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/UndispatchedCoroutine;->clearThreadContext()Z

    move-result p1

    if-eqz p1, :cond_5

    .line 378
    :cond_4
    invoke-static {v4, v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadContextKt;->restoreThreadContext(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Object;)V

    .line 383
    :cond_5
    :goto_1
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;->processUnconfinedEvent()Z

    move-result p1
    :try_end_2
    .catchall {:try_start_2 .. :try_end_2} :catchall_0

    if-nez p1, :cond_5

    .line 392
    :goto_2
    invoke-virtual {v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;->decrementUseCount(Z)V

    goto :goto_4

    :catchall_1
    move-exception p1

    if-eqz v0, :cond_6

    .line 377
    :try_start_3
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/UndispatchedCoroutine;->clearThreadContext()Z

    move-result v0

    if-eqz v0, :cond_7

    .line 378
    :cond_6
    invoke-static {v4, v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadContextKt;->restoreThreadContext(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Object;)V

    :cond_7
    throw p1
    :try_end_3
    .catchall {:try_start_3 .. :try_end_3} :catchall_0

    .line 390
    :goto_3
    :try_start_4
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;->handleFatalException$kotlinx_coroutines_core(Ljava/lang/Throwable;)V
    :try_end_4
    .catchall {:try_start_4 .. :try_end_4} :catchall_2

    goto :goto_2

    :goto_4
    return-void

    :catchall_2
    move-exception p0

    .line 392
    invoke-virtual {v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;->decrementUseCount(Z)V

    throw p0

    .line 279
    :cond_8
    invoke-interface {p0, p1}, Lkotlin/coroutines/Continuation;->resumeWith(Ljava/lang/Object;)V

    return-void
.end method

.method public static final safeDispatch(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;Lkotlin/coroutines/CoroutineContext;Ljava/lang/Runnable;)V
    .locals 1

    .line 254
    :try_start_0
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;->dispatch(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Runnable;)V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    return-void

    :catchall_0
    move-exception p2

    .line 256
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchException;

    invoke-direct {v0, p2, p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchException;-><init>(Ljava/lang/Throwable;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;Lkotlin/coroutines/CoroutineContext;)V

    throw v0
.end method

.method public static final safeIsDispatchNeeded(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;Lkotlin/coroutines/CoroutineContext;)Z
    .locals 2

    .line 262
    :try_start_0
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;->isDispatchNeeded(Lkotlin/coroutines/CoroutineContext;)Z

    move-result p0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    return p0

    :catchall_0
    move-exception v0

    .line 264
    new-instance v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchException;

    invoke-direct {v1, v0, p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchException;-><init>(Ljava/lang/Throwable;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;Lkotlin/coroutines/CoroutineContext;)V

    throw v1
.end method

.method public static final yieldUndispatched(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;)Z
    .locals 5

    .line 283
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    .line 399
    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ThreadLocalEventLoop;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ThreadLocalEventLoop;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ThreadLocalEventLoop;->getEventLoop$kotlinx_coroutines_core()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;

    move-result-object v1

    .line 401
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;->isUnconfinedQueueEmpty()Z

    move-result v2

    const/4 v3, 0x0

    if-eqz v2, :cond_0

    return v3

    .line 402
    :cond_0
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;->isUnconfinedLoopActive()Z

    move-result v2

    const/4 v4, 0x1

    if-eqz v2, :cond_1

    .line 404
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->_state:Ljava/lang/Object;

    .line 405
    iput v4, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;->resumeMode:I

    .line 406
    invoke-virtual {v1, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;->dispatchUnconfined(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;)V

    move v3, v4

    goto :goto_1

    .line 411
    :cond_1
    invoke-virtual {v1, v4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;->incrementUseCount(Z)V

    .line 284
    :try_start_0
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;->run()V

    .line 416
    :cond_2
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;->processUnconfinedEvent()Z

    move-result v0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    if-nez v0, :cond_2

    .line 425
    :goto_0
    invoke-virtual {v1, v4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;->decrementUseCount(Z)V

    goto :goto_1

    :catchall_0
    move-exception v0

    .line 423
    :try_start_1
    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;->handleFatalException$kotlinx_coroutines_core(Ljava/lang/Throwable;)V
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_1

    goto :goto_0

    :goto_1
    return v3

    :catchall_1
    move-exception p0

    .line 425
    invoke-virtual {v1, v4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;->decrementUseCount(Z)V

    throw p0
.end method
