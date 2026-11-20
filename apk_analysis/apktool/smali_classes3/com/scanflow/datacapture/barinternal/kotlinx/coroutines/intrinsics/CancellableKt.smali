.class public abstract Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/intrinsics/CancellableKt;
.super Ljava/lang/Object;
.source "Cancellable.kt"


# direct methods
.method private static final dispatcherFailure(Lkotlin/coroutines/Continuation;Ljava/lang/Throwable;)V
    .locals 1

    .line 61
    instance-of v0, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchException;

    if-eqz v0, :cond_0

    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchException;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchException;->getCause()Ljava/lang/Throwable;

    move-result-object p1

    .line 62
    :cond_0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/Result$Companion;

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/ResultKt;->createFailure(Ljava/lang/Throwable;)Ljava/lang/Object;

    move-result-object v0

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->constructor-impl(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    invoke-interface {p0, v0}, Lkotlin/coroutines/Continuation;->resumeWith(Ljava/lang/Object;)V

    .line 63
    throw p1
.end method

.method public static final startCoroutineCancellable(Lkotlin/coroutines/Continuation;Lkotlin/coroutines/Continuation;)V
    .locals 1

    .line 35
    :try_start_0
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->intercepted(Lkotlin/coroutines/Continuation;)Lkotlin/coroutines/Continuation;

    move-result-object p0

    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/Result$Companion;

    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->constructor-impl(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    invoke-static {p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuationKt;->resumeCancellableWith(Lkotlin/coroutines/Continuation;Ljava/lang/Object;)V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    return-void

    :catchall_0
    move-exception p0

    .line 81
    invoke-static {p1, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/intrinsics/CancellableKt;->dispatcherFailure(Lkotlin/coroutines/Continuation;Ljava/lang/Throwable;)V

    return-void
.end method

.method public static final startCoroutineCancellable(Lkotlin/jvm/functions/Function2;Ljava/lang/Object;Lkotlin/coroutines/Continuation;)V
    .locals 0

    .line 26
    :try_start_0
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->createCoroutineUnintercepted(Lkotlin/jvm/functions/Function2;Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Lkotlin/coroutines/Continuation;

    move-result-object p0

    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->intercepted(Lkotlin/coroutines/Continuation;)Lkotlin/coroutines/Continuation;

    move-result-object p0

    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/Result$Companion;

    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->constructor-impl(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuationKt;->resumeCancellableWith(Lkotlin/coroutines/Continuation;Ljava/lang/Object;)V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    return-void

    :catchall_0
    move-exception p0

    .line 75
    invoke-static {p2, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/intrinsics/CancellableKt;->dispatcherFailure(Lkotlin/coroutines/Continuation;Ljava/lang/Throwable;)V

    return-void
.end method
