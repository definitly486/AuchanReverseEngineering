.class abstract synthetic Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobKt__JobKt;
.super Ljava/lang/Object;
.source "Job.kt"


# direct methods
.method public static final Job(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletableJob;
    .locals 1

    .line 391
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobImpl;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobImpl;-><init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;)V

    return-object v0
.end method

.method public static synthetic Job$default(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;ILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletableJob;
    .locals 0

    and-int/lit8 p1, p1, 0x1

    if-eqz p1, :cond_0

    const/4 p0, 0x0

    .line 390
    :cond_0
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobKt;->Job(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletableJob;

    move-result-object p0

    return-object p0
.end method

.method public static final cancel(Lkotlin/coroutines/CoroutineContext;Ljava/util/concurrent/CancellationException;)V
    .locals 1

    .line 563
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;->Key:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job$Key;

    invoke-interface {p0, v0}, Lkotlin/coroutines/CoroutineContext;->get(Lkotlin/coroutines/CoroutineContext$Key;)Lkotlin/coroutines/CoroutineContext$Element;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;

    if-eqz p0, :cond_0

    invoke-interface {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;->cancel(Ljava/util/concurrent/CancellationException;)V

    :cond_0
    return-void
.end method

.method public static synthetic cancel$default(Lkotlin/coroutines/CoroutineContext;Ljava/util/concurrent/CancellationException;ILjava/lang/Object;)V
    .locals 0

    and-int/lit8 p2, p2, 0x1

    if-eqz p2, :cond_0

    const/4 p1, 0x0

    .line 562
    :cond_0
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobKt;->cancel(Lkotlin/coroutines/CoroutineContext;Ljava/util/concurrent/CancellationException;)V

    return-void
.end method

.method public static final cancelAndJoin(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;
    .locals 2

    const/4 v0, 0x0

    const/4 v1, 0x1

    .line 510
    invoke-static {p0, v0, v1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job$DefaultImpls;->cancel$default(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;Ljava/util/concurrent/CancellationException;ILjava/lang/Object;)V

    .line 511
    invoke-interface {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;->join(Lkotlin/coroutines/Continuation;)Ljava/lang/Object;

    move-result-object p0

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->getCOROUTINE_SUSPENDED()Ljava/lang/Object;

    move-result-object p1

    if-ne p0, p1, :cond_0

    return-object p0

    :cond_0
    sget-object p0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    return-object p0
.end method

.method public static final disposeOnCompletion(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;
    .locals 3

    .line 493
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposeOnCompletion;

    invoke-direct {v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposeOnCompletion;-><init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;)V

    const/4 p1, 0x1

    const/4 v1, 0x0

    const/4 v2, 0x0

    invoke-static {p0, v2, v0, p1, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobKt;->invokeOnCompletion$default(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;ZLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobNode;ILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;

    move-result-object p0

    return-object p0
.end method

.method public static final ensureActive(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;)V
    .locals 1

    .line 585
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;->isActive()Z

    move-result v0

    if-eqz v0, :cond_0

    return-void

    :cond_0
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;->getCancellationException()Ljava/util/concurrent/CancellationException;

    move-result-object p0

    throw p0
.end method

.method public static final ensureActive(Lkotlin/coroutines/CoroutineContext;)V
    .locals 1

    .line 603
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;->Key:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job$Key;

    invoke-interface {p0, v0}, Lkotlin/coroutines/CoroutineContext;->get(Lkotlin/coroutines/CoroutineContext$Key;)Lkotlin/coroutines/CoroutineContext$Element;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;

    if-eqz p0, :cond_0

    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobKt;->ensureActive(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;)V

    :cond_0
    return-void
.end method

.method public static final invokeOnCompletion(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;ZLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobNode;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;
    .locals 2

    .line 370
    instance-of v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;

    if-eqz v0, :cond_0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;->invokeOnCompletionInternal$kotlinx_coroutines_core(ZLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobNode;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;

    move-result-object p0

    return-object p0

    .line 371
    :cond_0
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobNode;->getOnCancelling()Z

    move-result v0

    new-instance v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobKt__JobKt$invokeOnCompletion$1;

    invoke-direct {v1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobKt__JobKt$invokeOnCompletion$1;-><init>(Ljava/lang/Object;)V

    invoke-interface {p0, v0, p1, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;->invokeOnCompletion(ZZLkotlin/jvm/functions/Function1;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;

    move-result-object p0

    return-object p0
.end method

.method public static synthetic invokeOnCompletion$default(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;ZLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobNode;ILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;
    .locals 0

    const/4 p4, 0x1

    and-int/2addr p3, p4

    if-eqz p3, :cond_0

    move p1, p4

    .line 366
    :cond_0
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobKt;->invokeOnCompletion(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;ZLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobNode;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;

    move-result-object p0

    return-object p0
.end method
