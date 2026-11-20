.class public abstract Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/intrinsics/UndispatchedKt;
.super Ljava/lang/Object;
.source "Undispatched.kt"


# direct methods
.method private static final dispatchExceptionAndMakeCompleting(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ScopeCoroutine;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchException;)Ljava/lang/Void;
    .locals 5

    .line 102
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedExceptionally;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchException;->getCause()Ljava/lang/Throwable;

    move-result-object v1

    const/4 v2, 0x2

    const/4 v3, 0x0

    const/4 v4, 0x0

    invoke-direct {v0, v1, v4, v2, v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedExceptionally;-><init>(Ljava/lang/Throwable;ZILkotlin/jvm/internal/DefaultConstructorMarker;)V

    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;->makeCompleting$kotlinx_coroutines_core(Ljava/lang/Object;)Z

    .line 103
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchException;->getCause()Ljava/lang/Throwable;

    move-result-object p0

    .line 118
    throw p0
.end method

.method private static final notOwnTimeout(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ScopeCoroutine;Ljava/lang/Throwable;)Z
    .locals 1

    .line 98
    instance-of v0, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/TimeoutCancellationException;

    if-eqz v0, :cond_1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/TimeoutCancellationException;

    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/TimeoutCancellationException;->coroutine:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;

    if-eq p1, p0, :cond_0

    goto :goto_0

    :cond_0
    const/4 p0, 0x0

    return p0

    :cond_1
    :goto_0
    const/4 p0, 0x1

    return p0
.end method

.method public static final startCoroutineUndispatched(Lkotlin/jvm/functions/Function2;Ljava/lang/Object;Lkotlin/coroutines/Continuation;)V
    .locals 3

    .line 106
    invoke-static {p2}, Lkotlin/coroutines/jvm/internal/DebugProbesKt;->probeCoroutineCreated(Lkotlin/coroutines/Continuation;)Lkotlin/coroutines/Continuation;

    move-result-object p2

    .line 18
    :try_start_0
    invoke-interface {p2}, Lkotlin/coroutines/Continuation;->getContext()Lkotlin/coroutines/CoroutineContext;

    move-result-object v0

    const/4 v1, 0x0

    .line 107
    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadContextKt;->updateThreadContext(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_1

    .line 110
    :try_start_1
    invoke-static {p2}, Lkotlin/coroutines/jvm/internal/DebugProbesKt;->probeCoroutineResumed(Lkotlin/coroutines/Continuation;)V

    .line 20
    instance-of v2, p0, Lkotlin/coroutines/jvm/internal/BaseContinuationImpl;

    if-nez v2, :cond_0

    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->wrapWithContinuationImpl(Lkotlin/jvm/functions/Function2;Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;

    move-result-object p0

    goto :goto_0

    :catchall_0
    move-exception p0

    goto :goto_1

    :cond_0
    const/4 v2, 0x2

    invoke-static {p0, v2}, Lkotlin/jvm/internal/TypeIntrinsics;->beforeCheckcastToFunctionOfArity(Ljava/lang/Object;I)Ljava/lang/Object;

    move-result-object p0

    check-cast p0, Lkotlin/jvm/functions/Function2;

    invoke-interface {p0, p1, p2}, Lkotlin/jvm/functions/Function2;->invoke(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p0
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    .line 112
    :goto_0
    :try_start_2
    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadContextKt;->restoreThreadContext(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Object;)V
    :try_end_2
    .catchall {:try_start_2 .. :try_end_2} :catchall_1

    .line 27
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->getCOROUTINE_SUSPENDED()Ljava/lang/Object;

    move-result-object p1

    if-eq p0, p1, :cond_1

    .line 29
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->constructor-impl(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p0

    invoke-interface {p2, p0}, Lkotlin/coroutines/Continuation;->resumeWith(Ljava/lang/Object;)V

    :cond_1
    return-void

    :catchall_1
    move-exception p0

    goto :goto_2

    .line 112
    :goto_1
    :try_start_3
    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadContextKt;->restoreThreadContext(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Object;)V

    throw p0
    :try_end_3
    .catchall {:try_start_3 .. :try_end_3} :catchall_1

    .line 23
    :goto_2
    instance-of p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchException;

    if-eqz p1, :cond_2

    check-cast p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchException;

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchException;->getCause()Ljava/lang/Throwable;

    move-result-object p0

    .line 24
    :cond_2
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/Result$Companion;

    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/ResultKt;->createFailure(Ljava/lang/Throwable;)Ljava/lang/Object;

    move-result-object p0

    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->constructor-impl(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p0

    invoke-interface {p2, p0}, Lkotlin/coroutines/Continuation;->resumeWith(Ljava/lang/Object;)V

    return-void
.end method

.method public static final startUndispatchedOrReturn(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ScopeCoroutine;Ljava/lang/Object;Lkotlin/jvm/functions/Function2;)Ljava/lang/Object;
    .locals 1

    const/4 v0, 0x1

    .line 43
    invoke-static {p0, v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/intrinsics/UndispatchedKt;->startUndspatched(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ScopeCoroutine;ZLjava/lang/Object;Lkotlin/jvm/functions/Function2;)Ljava/lang/Object;

    move-result-object p0

    return-object p0
.end method

.method public static final startUndispatchedOrReturnIgnoreTimeout(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ScopeCoroutine;Ljava/lang/Object;Lkotlin/jvm/functions/Function2;)Ljava/lang/Object;
    .locals 1

    const/4 v0, 0x0

    .line 50
    invoke-static {p0, v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/intrinsics/UndispatchedKt;->startUndspatched(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ScopeCoroutine;ZLjava/lang/Object;Lkotlin/jvm/functions/Function2;)Ljava/lang/Object;

    move-result-object p0

    return-object p0
.end method

.method private static final startUndspatched(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ScopeCoroutine;ZLjava/lang/Object;Lkotlin/jvm/functions/Function2;)Ljava/lang/Object;
    .locals 3

    const/4 v0, 0x2

    .line 66
    :try_start_0
    instance-of v1, p3, Lkotlin/coroutines/jvm/internal/BaseContinuationImpl;

    if-nez v1, :cond_0

    invoke-static {p3, p2, p0}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->wrapWithContinuationImpl(Lkotlin/jvm/functions/Function2;Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;

    move-result-object p2

    goto :goto_1

    :catchall_0
    move-exception p2

    goto :goto_0

    :catch_0
    move-exception p1

    goto :goto_3

    :cond_0
    invoke-static {p3, v0}, Lkotlin/jvm/internal/TypeIntrinsics;->beforeCheckcastToFunctionOfArity(Ljava/lang/Object;I)Ljava/lang/Object;

    move-result-object p3

    check-cast p3, Lkotlin/jvm/functions/Function2;

    invoke-interface {p3, p2, p0}, Lkotlin/jvm/functions/Function2;->invoke(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p2
    :try_end_0
    .catch Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchException; {:try_start_0 .. :try_end_0} :catch_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    goto :goto_1

    .line 72
    :goto_0
    new-instance p3, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedExceptionally;

    const/4 v1, 0x0

    const/4 v2, 0x0

    invoke-direct {p3, p2, v1, v0, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedExceptionally;-><init>(Ljava/lang/Throwable;ZILkotlin/jvm/internal/DefaultConstructorMarker;)V

    move-object p2, p3

    .line 82
    :goto_1
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->getCOROUTINE_SUSPENDED()Ljava/lang/Object;

    move-result-object p3

    if-ne p2, p3, :cond_1

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->getCOROUTINE_SUSPENDED()Ljava/lang/Object;

    move-result-object p0

    return-object p0

    .line 83
    :cond_1
    invoke-virtual {p0, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;->makeCompletingOnce$kotlinx_coroutines_core(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p3

    .line 84
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupportKt;->COMPLETING_WAITING_CHILDREN:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    if-ne p3, v0, :cond_2

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->getCOROUTINE_SUSPENDED()Ljava/lang/Object;

    move-result-object p0

    return-object p0

    .line 85
    :cond_2
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ScopeCoroutine;->afterCompletionUndispatched()V

    .line 86
    instance-of v0, p3, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedExceptionally;

    if-eqz v0, :cond_5

    if-nez p1, :cond_4

    .line 88
    move-object p1, p3

    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedExceptionally;

    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedExceptionally;->cause:Ljava/lang/Throwable;

    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/intrinsics/UndispatchedKt;->notOwnTimeout(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ScopeCoroutine;Ljava/lang/Throwable;)Z

    move-result p0

    if-nez p0, :cond_4

    .line 89
    instance-of p0, p2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedExceptionally;

    if-nez p0, :cond_3

    goto :goto_2

    :cond_3
    check-cast p2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedExceptionally;

    iget-object p0, p2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedExceptionally;->cause:Ljava/lang/Throwable;

    .line 116
    throw p0

    .line 88
    :cond_4
    check-cast p3, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedExceptionally;

    iget-object p0, p3, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedExceptionally;->cause:Ljava/lang/Throwable;

    .line 114
    throw p0

    .line 93
    :cond_5
    invoke-static {p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupportKt;->unboxState(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p2

    :goto_2
    return-object p2

    .line 70
    :goto_3
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/intrinsics/UndispatchedKt;->dispatchExceptionAndMakeCompleting(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ScopeCoroutine;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchException;)Ljava/lang/Void;

    new-instance p0, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p0
.end method
