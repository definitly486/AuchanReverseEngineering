.class abstract synthetic Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/BuildersKt__Builders_commonKt;
.super Ljava/lang/Object;
.source "Builders.common.kt"


# direct methods
.method public static final async(Lkotlinx/coroutines/CoroutineScope;Lkotlin/coroutines/CoroutineContext;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;Lkotlin/jvm/functions/Function2;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Deferred;
    .locals 1

    .line 84
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineContextKt;->newCoroutineContext(Lkotlinx/coroutines/CoroutineScope;Lkotlin/coroutines/CoroutineContext;)Lkotlin/coroutines/CoroutineContext;

    move-result-object p0

    .line 85
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;->isLazy()Z

    move-result p1

    if-eqz p1, :cond_0

    .line 86
    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/LazyDeferredCoroutine;

    invoke-direct {p1, p0, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/LazyDeferredCoroutine;-><init>(Lkotlin/coroutines/CoroutineContext;Lkotlin/jvm/functions/Function2;)V

    goto :goto_0

    .line 87
    :cond_0
    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DeferredCoroutine;

    const/4 v0, 0x1

    invoke-direct {p1, p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DeferredCoroutine;-><init>(Lkotlin/coroutines/CoroutineContext;Z)V

    .line 88
    :goto_0
    invoke-virtual {p1, p2, p1, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/AbstractCoroutine;->start(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;Ljava/lang/Object;Lkotlin/jvm/functions/Function2;)V

    return-object p1
.end method

.method public static synthetic async$default(Lkotlinx/coroutines/CoroutineScope;Lkotlin/coroutines/CoroutineContext;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;Lkotlin/jvm/functions/Function2;ILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Deferred;
    .locals 0

    and-int/lit8 p5, p4, 0x1

    if-eqz p5, :cond_0

    .line 80
    sget-object p1, Lkotlin/coroutines/EmptyCoroutineContext;->INSTANCE:Lkotlin/coroutines/EmptyCoroutineContext;

    :cond_0
    and-int/lit8 p4, p4, 0x2

    if-eqz p4, :cond_1

    .line 81
    sget-object p2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;->DEFAULT:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;

    .line 79
    :cond_1
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/BuildersKt;->async(Lkotlinx/coroutines/CoroutineScope;Lkotlin/coroutines/CoroutineContext;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;Lkotlin/jvm/functions/Function2;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Deferred;

    move-result-object p0

    return-object p0
.end method

.method public static final launch(Lkotlinx/coroutines/CoroutineScope;Lkotlin/coroutines/CoroutineContext;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;Lkotlin/jvm/functions/Function2;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;
    .locals 1

    .line 49
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineContextKt;->newCoroutineContext(Lkotlinx/coroutines/CoroutineScope;Lkotlin/coroutines/CoroutineContext;)Lkotlin/coroutines/CoroutineContext;

    move-result-object p0

    .line 50
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;->isLazy()Z

    move-result p1

    if-eqz p1, :cond_0

    .line 51
    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/LazyStandaloneCoroutine;

    invoke-direct {p1, p0, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/LazyStandaloneCoroutine;-><init>(Lkotlin/coroutines/CoroutineContext;Lkotlin/jvm/functions/Function2;)V

    goto :goto_0

    .line 52
    :cond_0
    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/StandaloneCoroutine;

    const/4 v0, 0x1

    invoke-direct {p1, p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/StandaloneCoroutine;-><init>(Lkotlin/coroutines/CoroutineContext;Z)V

    .line 53
    :goto_0
    invoke-virtual {p1, p2, p1, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/AbstractCoroutine;->start(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;Ljava/lang/Object;Lkotlin/jvm/functions/Function2;)V

    return-object p1
.end method

.method public static synthetic launch$default(Lkotlinx/coroutines/CoroutineScope;Lkotlin/coroutines/CoroutineContext;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;Lkotlin/jvm/functions/Function2;ILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;
    .locals 0

    and-int/lit8 p5, p4, 0x1

    if-eqz p5, :cond_0

    .line 45
    sget-object p1, Lkotlin/coroutines/EmptyCoroutineContext;->INSTANCE:Lkotlin/coroutines/EmptyCoroutineContext;

    :cond_0
    and-int/lit8 p4, p4, 0x2

    if-eqz p4, :cond_1

    .line 46
    sget-object p2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;->DEFAULT:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;

    .line 44
    :cond_1
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/BuildersKt;->launch(Lkotlinx/coroutines/CoroutineScope;Lkotlin/coroutines/CoroutineContext;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;Lkotlin/jvm/functions/Function2;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;

    move-result-object p0

    return-object p0
.end method

.method public static final withContext(Lkotlin/coroutines/CoroutineContext;Lkotlin/jvm/functions/Function2;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;
    .locals 3

    .line 149
    invoke-interface {p2}, Lkotlin/coroutines/Continuation;->getContext()Lkotlin/coroutines/CoroutineContext;

    move-result-object v0

    .line 151
    invoke-static {v0, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineContextKt;->newCoroutineContext(Lkotlin/coroutines/CoroutineContext;Lkotlin/coroutines/CoroutineContext;)Lkotlin/coroutines/CoroutineContext;

    move-result-object p0

    .line 153
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobKt;->ensureActive(Lkotlin/coroutines/CoroutineContext;)V

    if-ne p0, v0, :cond_0

    .line 156
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ScopeCoroutine;

    invoke-direct {v0, p0, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ScopeCoroutine;-><init>(Lkotlin/coroutines/CoroutineContext;Lkotlin/coroutines/Continuation;)V

    .line 157
    invoke-static {v0, v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/intrinsics/UndispatchedKt;->startUndispatchedOrReturn(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ScopeCoroutine;Ljava/lang/Object;Lkotlin/jvm/functions/Function2;)Ljava/lang/Object;

    move-result-object p0

    goto :goto_0

    .line 161
    :cond_0
    sget-object v1, Lkotlin/coroutines/ContinuationInterceptor;->Key:Lkotlin/coroutines/ContinuationInterceptor$Key;

    invoke-interface {p0, v1}, Lkotlin/coroutines/CoroutineContext;->get(Lkotlin/coroutines/CoroutineContext$Key;)Lkotlin/coroutines/CoroutineContext$Element;

    move-result-object v2

    invoke-interface {v0, v1}, Lkotlin/coroutines/CoroutineContext;->get(Lkotlin/coroutines/CoroutineContext$Key;)Lkotlin/coroutines/CoroutineContext$Element;

    move-result-object v0

    invoke-static {v2, v0}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_1

    .line 162
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/UndispatchedCoroutine;

    invoke-direct {v0, p0, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/UndispatchedCoroutine;-><init>(Lkotlin/coroutines/CoroutineContext;Lkotlin/coroutines/Continuation;)V

    .line 164
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/AbstractCoroutine;->getContext()Lkotlin/coroutines/CoroutineContext;

    move-result-object p0

    const/4 v1, 0x0

    .line 269
    invoke-static {p0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadContextKt;->updateThreadContext(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    .line 165
    :try_start_0
    invoke-static {v0, v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/intrinsics/UndispatchedKt;->startUndispatchedOrReturn(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ScopeCoroutine;Ljava/lang/Object;Lkotlin/jvm/functions/Function2;)Ljava/lang/Object;

    move-result-object p1
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 273
    invoke-static {p0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadContextKt;->restoreThreadContext(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Object;)V

    move-object p0, p1

    goto :goto_0

    :catchall_0
    move-exception p1

    invoke-static {p0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadContextKt;->restoreThreadContext(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Object;)V

    throw p1

    .line 169
    :cond_1
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedCoroutine;

    invoke-direct {v0, p0, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedCoroutine;-><init>(Lkotlin/coroutines/CoroutineContext;Lkotlin/coroutines/Continuation;)V

    .line 170
    invoke-static {p1, v0, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/intrinsics/CancellableKt;->startCoroutineCancellable(Lkotlin/jvm/functions/Function2;Ljava/lang/Object;Lkotlin/coroutines/Continuation;)V

    .line 171
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedCoroutine;->getResult$kotlinx_coroutines_core()Ljava/lang/Object;

    move-result-object p0

    .line 147
    :goto_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->getCOROUTINE_SUSPENDED()Ljava/lang/Object;

    move-result-object p1

    if-ne p0, p1, :cond_2

    invoke-static {p2}, Lkotlin/coroutines/jvm/internal/DebugProbesKt;->probeCoroutineSuspended(Lkotlin/coroutines/Continuation;)V

    :cond_2
    return-object p0
.end method
