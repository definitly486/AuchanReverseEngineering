.class public abstract Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletionStateKt;
.super Ljava/lang/Object;
.source "CompletionState.kt"


# direct methods
.method public static final recoverResult(Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;
    .locals 0

    .line 15
    instance-of p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedExceptionally;

    if-eqz p1, :cond_0

    .line 16
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/Result$Companion;

    check-cast p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedExceptionally;

    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedExceptionally;->cause:Ljava/lang/Throwable;

    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/ResultKt;->createFailure(Ljava/lang/Throwable;)Ljava/lang/Object;

    move-result-object p0

    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->constructor-impl(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p0

    return-object p0

    .line 18
    :cond_0
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->constructor-impl(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p0

    return-object p0
.end method

.method public static final toState(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 4

    .line 8
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->exceptionOrNull-impl(Ljava/lang/Object;)Ljava/lang/Throwable;

    move-result-object v0

    if-nez v0, :cond_0

    return-object p0

    :cond_0
    new-instance p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedExceptionally;

    const/4 v1, 0x2

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {p0, v0, v3, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedExceptionally;-><init>(Ljava/lang/Throwable;ZILkotlin/jvm/internal/DefaultConstructorMarker;)V

    return-object p0
.end method

.method public static final toState(Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;)Ljava/lang/Object;
    .locals 3

    .line 11
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->exceptionOrNull-impl(Ljava/lang/Object;)Ljava/lang/Throwable;

    move-result-object p1

    if-nez p1, :cond_0

    return-object p0

    :cond_0
    new-instance p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedExceptionally;

    const/4 v0, 0x2

    const/4 v1, 0x0

    const/4 v2, 0x0

    invoke-direct {p0, p1, v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedExceptionally;-><init>(Ljava/lang/Throwable;ZILkotlin/jvm/internal/DefaultConstructorMarker;)V

    return-object p0
.end method
