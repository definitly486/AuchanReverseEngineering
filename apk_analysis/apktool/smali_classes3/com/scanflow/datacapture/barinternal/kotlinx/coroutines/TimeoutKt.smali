.class public abstract Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/TimeoutKt;
.super Ljava/lang/Object;
.source "Timeout.kt"


# direct methods
.method public static final TimeoutCancellationException(JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Delay;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/TimeoutCancellationException;
    .locals 1

    .line 188
    new-instance p2, Ljava/lang/StringBuilder;

    invoke-direct {p2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v0, "Timed out waiting for "

    invoke-virtual {p2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2, p0, p1}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    const-string p0, " ms"

    invoke-virtual {p2, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    .line 189
    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/TimeoutCancellationException;

    invoke-direct {p1, p0, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/TimeoutCancellationException;-><init>(Ljava/lang/String;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;)V

    return-object p1
.end method

.method private static final setupTimeout(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/TimeoutCoroutine;Lkotlin/jvm/functions/Function2;)Ljava/lang/Object;
    .locals 4

    .line 144
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ScopeCoroutine;->uCont:Lkotlin/coroutines/Continuation;

    .line 145
    invoke-interface {v0}, Lkotlin/coroutines/Continuation;->getContext()Lkotlin/coroutines/CoroutineContext;

    move-result-object v0

    .line 146
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DelayKt;->getDelay(Lkotlin/coroutines/CoroutineContext;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Delay;

    move-result-object v0

    iget-wide v1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/TimeoutCoroutine;->time:J

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/AbstractCoroutine;->getContext()Lkotlin/coroutines/CoroutineContext;

    move-result-object v3

    invoke-interface {v0, v1, v2, p0, v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Delay;->invokeOnTimeout(JLjava/lang/Runnable;Lkotlin/coroutines/CoroutineContext;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;

    move-result-object v0

    invoke-static {p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobKt;->disposeOnCompletion(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;

    .line 149
    invoke-static {p0, p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/intrinsics/UndispatchedKt;->startUndispatchedOrReturnIgnoreTimeout(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ScopeCoroutine;Ljava/lang/Object;Lkotlin/jvm/functions/Function2;)Ljava/lang/Object;

    move-result-object p0

    return-object p0
.end method

.method public static final withTimeout(JLkotlin/jvm/functions/Function2;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;
    .locals 2

    const-wide/16 v0, 0x0

    cmp-long v0, p0, v0

    if-lez v0, :cond_1

    .line 44
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/TimeoutCoroutine;

    invoke-direct {v0, p0, p1, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/TimeoutCoroutine;-><init>(JLkotlin/coroutines/Continuation;)V

    invoke-static {v0, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/TimeoutKt;->setupTimeout(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/TimeoutCoroutine;Lkotlin/jvm/functions/Function2;)Ljava/lang/Object;

    move-result-object p0

    .line 43
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->getCOROUTINE_SUSPENDED()Ljava/lang/Object;

    move-result-object p1

    if-ne p0, p1, :cond_0

    invoke-static {p3}, Lkotlin/coroutines/jvm/internal/DebugProbesKt;->probeCoroutineSuspended(Lkotlin/coroutines/Continuation;)V

    :cond_0
    return-object p0

    .line 42
    :cond_1
    new-instance p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/TimeoutCancellationException;

    const-string p1, "Timed out immediately"

    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/TimeoutCancellationException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method public static final withTimeout-KLykuaI(JLkotlin/jvm/functions/Function2;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;
    .locals 0

    .line 72
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DelayKt;->toDelayMillis-LRDsOJo(J)J

    move-result-wide p0

    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/TimeoutKt;->withTimeout(JLkotlin/jvm/functions/Function2;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;

    move-result-object p0

    return-object p0
.end method
