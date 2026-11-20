.class public abstract Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationKt;
.super Ljava/lang/Object;
.source "CancellableContinuation.kt"


# direct methods
.method public static final disposeOnCancellation(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;)V
    .locals 1

    .line 492
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposeOnCancel;

    invoke-direct {v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposeOnCancel;-><init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;)V

    invoke-static {p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationKt;->invokeOnCancellation(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancelHandler;)V

    return-void
.end method

.method public static final getOrCreateCancellableContinuation(Lkotlin/coroutines/Continuation;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;
    .locals 2

    .line 459
    instance-of v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;

    if-nez v0, :cond_0

    .line 460
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    const/4 v1, 0x1

    invoke-direct {v0, p0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;-><init>(Lkotlin/coroutines/Continuation;I)V

    return-object v0

    .line 476
    :cond_0
    move-object v0, p0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->claimReusableCancellableContinuation$kotlinx_coroutines_core()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    move-result-object v0

    if-eqz v0, :cond_3

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->resetStateReusable()Z

    move-result v1

    if-eqz v1, :cond_1

    goto :goto_0

    :cond_1
    const/4 v0, 0x0

    :goto_0
    if-nez v0, :cond_2

    goto :goto_1

    :cond_2
    return-object v0

    .line 477
    :cond_3
    :goto_1
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    const/4 v1, 0x2

    invoke-direct {v0, p0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;-><init>(Lkotlin/coroutines/Continuation;I)V

    return-object v0
.end method

.method public static final invokeOnCancellation(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancelHandler;)V
    .locals 1

    .line 314
    instance-of v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    if-eqz v0, :cond_0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->invokeOnCancellationInternal$kotlinx_coroutines_core(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancelHandler;)V

    return-void

    .line 315
    :cond_0
    new-instance p0, Ljava/lang/UnsupportedOperationException;

    const-string p1, "third-party implementation of CancellableContinuation is not supported"

    invoke-direct {p0, p1}, Ljava/lang/UnsupportedOperationException;-><init>(Ljava/lang/String;)V

    throw p0
.end method
