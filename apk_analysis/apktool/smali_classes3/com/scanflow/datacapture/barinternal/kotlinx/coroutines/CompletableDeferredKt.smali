.class public abstract Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletableDeferredKt;
.super Ljava/lang/Object;
.source "CompletableDeferred.kt"


# direct methods
.method public static final CompletableDeferred(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletableDeferred;
    .locals 1

    .line 64
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletableDeferredImpl;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletableDeferredImpl;-><init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;)V

    return-object v0
.end method

.method public static synthetic CompletableDeferred$default(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;ILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletableDeferred;
    .locals 0

    and-int/lit8 p1, p1, 0x1

    if-eqz p1, :cond_0

    const/4 p0, 0x0

    .line 63
    :cond_0
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletableDeferredKt;->CompletableDeferred(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletableDeferred;

    move-result-object p0

    return-object p0
.end method

.method public static final completeWith(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletableDeferred;Ljava/lang/Object;)Z
    .locals 1

    .line 57
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->exceptionOrNull-impl(Ljava/lang/Object;)Ljava/lang/Throwable;

    move-result-object v0

    if-nez v0, :cond_0

    invoke-interface {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletableDeferred;->complete(Ljava/lang/Object;)Z

    move-result p0

    return p0

    :cond_0
    invoke-interface {p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletableDeferred;->completeExceptionally(Ljava/lang/Throwable;)Z

    move-result p0

    return p0
.end method
