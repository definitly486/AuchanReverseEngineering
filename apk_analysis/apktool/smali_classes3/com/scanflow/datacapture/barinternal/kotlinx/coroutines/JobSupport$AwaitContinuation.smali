.class final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport$AwaitContinuation;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;
.source "JobSupport.kt"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x1a
    name = "AwaitContinuation"
.end annotation


# instance fields
.field private final job:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;


# direct methods
.method public constructor <init>(Lkotlin/coroutines/Continuation;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;)V
    .locals 1

    const/4 v0, 0x1

    .line 1275
    invoke-direct {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;-><init>(Lkotlin/coroutines/Continuation;I)V

    .line 1274
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport$AwaitContinuation;->job:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;

    return-void
.end method


# virtual methods
.method public getContinuationCancellationCause(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;)Ljava/lang/Throwable;
    .locals 2

    .line 1277
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport$AwaitContinuation;->job:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;->getState$kotlinx_coroutines_core()Ljava/lang/Object;

    move-result-object v0

    .line 1282
    instance-of v1, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport$Finishing;

    if-eqz v1, :cond_0

    move-object v1, v0

    check-cast v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport$Finishing;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport$Finishing;->getRootCause()Ljava/lang/Throwable;

    move-result-object v1

    if-eqz v1, :cond_0

    return-object v1

    .line 1283
    :cond_0
    instance-of v1, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedExceptionally;

    if-eqz v1, :cond_1

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedExceptionally;

    iget-object p1, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedExceptionally;->cause:Ljava/lang/Throwable;

    return-object p1

    .line 1284
    :cond_1
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;->getCancellationException()Ljava/util/concurrent/CancellationException;

    move-result-object p1

    return-object p1
.end method

.method protected nameString()Ljava/lang/String;
    .locals 1

    .line 1288
    const-string v0, "AwaitContinuation"

    return-object v0
.end method
