.class public abstract Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobKt;
.super Ljava/lang/Object;


# direct methods
.method public static final Job(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletableJob;
    .locals 0

    .line 1
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobKt__JobKt;->Job(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletableJob;

    move-result-object p0

    return-object p0
.end method

.method public static synthetic Job$default(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;ILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletableJob;
    .locals 0

    .line 1
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobKt__JobKt;->Job$default(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;ILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletableJob;

    move-result-object p0

    return-object p0
.end method

.method public static final cancel(Lkotlin/coroutines/CoroutineContext;Ljava/util/concurrent/CancellationException;)V
    .locals 0

    .line 1
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobKt__JobKt;->cancel(Lkotlin/coroutines/CoroutineContext;Ljava/util/concurrent/CancellationException;)V

    return-void
.end method

.method public static synthetic cancel$default(Lkotlin/coroutines/CoroutineContext;Ljava/util/concurrent/CancellationException;ILjava/lang/Object;)V
    .locals 0

    .line 1
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobKt__JobKt;->cancel$default(Lkotlin/coroutines/CoroutineContext;Ljava/util/concurrent/CancellationException;ILjava/lang/Object;)V

    return-void
.end method

.method public static final cancelAndJoin(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;
    .locals 0

    .line 1
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobKt__JobKt;->cancelAndJoin(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;

    move-result-object p0

    return-object p0
.end method

.method public static final disposeOnCompletion(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;
    .locals 0

    .line 1
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobKt__JobKt;->disposeOnCompletion(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;

    move-result-object p0

    return-object p0
.end method

.method public static final ensureActive(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;)V
    .locals 0

    .line 1
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobKt__JobKt;->ensureActive(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;)V

    return-void
.end method

.method public static final ensureActive(Lkotlin/coroutines/CoroutineContext;)V
    .locals 0

    .line 1
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobKt__JobKt;->ensureActive(Lkotlin/coroutines/CoroutineContext;)V

    return-void
.end method

.method public static final invokeOnCompletion(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;ZLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobNode;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;
    .locals 0

    .line 1
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobKt__JobKt;->invokeOnCompletion(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;ZLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobNode;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;

    move-result-object p0

    return-object p0
.end method

.method public static synthetic invokeOnCompletion$default(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;ZLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobNode;ILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;
    .locals 0

    .line 1
    invoke-static {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobKt__JobKt;->invokeOnCompletion$default(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;ZLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobNode;ILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;

    move-result-object p0

    return-object p0
.end method
