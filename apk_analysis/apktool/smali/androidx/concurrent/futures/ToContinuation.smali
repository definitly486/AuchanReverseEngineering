.class final Landroidx/concurrent/futures/ToContinuation;
.super Ljava/lang/Object;
.source "ListenableFuture.kt"

# interfaces
.implements Ljava/lang/Runnable;


# instance fields
.field private final continuation:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;

.field private final futureToObserve:Lcom/google/common/util/concurrent/ListenableFuture;


# direct methods
.method public constructor <init>(Lcom/google/common/util/concurrent/ListenableFuture;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;)V
    .locals 0

    .line 66
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 67
    iput-object p1, p0, Landroidx/concurrent/futures/ToContinuation;->futureToObserve:Lcom/google/common/util/concurrent/ListenableFuture;

    .line 68
    iput-object p2, p0, Landroidx/concurrent/futures/ToContinuation;->continuation:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;

    return-void
.end method


# virtual methods
.method public run()V
    .locals 3

    .line 71
    iget-object v0, p0, Landroidx/concurrent/futures/ToContinuation;->futureToObserve:Lcom/google/common/util/concurrent/ListenableFuture;

    invoke-interface {v0}, Ljava/util/concurrent/Future;->isCancelled()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 72
    iget-object v0, p0, Landroidx/concurrent/futures/ToContinuation;->continuation:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;

    const/4 v1, 0x1

    const/4 v2, 0x0

    invoke-static {v0, v2, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation$DefaultImpls;->cancel$default(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;Ljava/lang/Throwable;ILjava/lang/Object;)Z

    return-void

    .line 75
    :cond_0
    :try_start_0
    iget-object v0, p0, Landroidx/concurrent/futures/ToContinuation;->continuation:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/Result$Companion;

    iget-object v1, p0, Landroidx/concurrent/futures/ToContinuation;->futureToObserve:Lcom/google/common/util/concurrent/ListenableFuture;

    invoke-static {v1}, Landroidx/concurrent/futures/AbstractResolvableFuture;->getUninterruptibly(Ljava/util/concurrent/Future;)Ljava/lang/Object;

    move-result-object v1

    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->constructor-impl(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    invoke-interface {v0, v1}, Lkotlin/coroutines/Continuation;->resumeWith(Ljava/lang/Object;)V
    :try_end_0
    .catch Ljava/util/concurrent/ExecutionException; {:try_start_0 .. :try_end_0} :catch_0

    return-void

    :catch_0
    move-exception v0

    .line 80
    iget-object v1, p0, Landroidx/concurrent/futures/ToContinuation;->continuation:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;

    sget-object v2, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/Result$Companion;

    invoke-static {v0}, Landroidx/concurrent/futures/ListenableFutureKt;->nonNullCause(Ljava/util/concurrent/ExecutionException;)Ljava/lang/Throwable;

    move-result-object v0

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/ResultKt;->createFailure(Ljava/lang/Throwable;)Ljava/lang/Object;

    move-result-object v0

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->constructor-impl(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    invoke-interface {v1, v0}, Lkotlin/coroutines/Continuation;->resumeWith(Ljava/lang/Object;)V

    return-void
.end method
