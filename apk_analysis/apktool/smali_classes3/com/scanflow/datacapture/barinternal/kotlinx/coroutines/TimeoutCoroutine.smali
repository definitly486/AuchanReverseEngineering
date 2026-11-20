.class final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/TimeoutCoroutine;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ScopeCoroutine;
.source "Timeout.kt"

# interfaces
.implements Ljava/lang/Runnable;


# instance fields
.field public final time:J


# direct methods
.method public constructor <init>(JLkotlin/coroutines/Continuation;)V
    .locals 1

    .line 155
    invoke-interface {p3}, Lkotlin/coroutines/Continuation;->getContext()Lkotlin/coroutines/CoroutineContext;

    move-result-object v0

    invoke-direct {p0, v0, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ScopeCoroutine;-><init>(Lkotlin/coroutines/CoroutineContext;Lkotlin/coroutines/Continuation;)V

    .line 153
    iput-wide p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/TimeoutCoroutine;->time:J

    return-void
.end method


# virtual methods
.method public nameString$kotlinx_coroutines_core()Ljava/lang/String;
    .locals 3

    .line 161
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-super {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/AbstractCoroutine;->nameString$kotlinx_coroutines_core()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, "(timeMillis="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-wide v1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/TimeoutCoroutine;->time:J

    invoke-virtual {v0, v1, v2}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    const/16 v1, 0x29

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public run()V
    .locals 3

    .line 157
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/TimeoutCoroutine;->time:J

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/AbstractCoroutine;->getContext()Lkotlin/coroutines/CoroutineContext;

    move-result-object v2

    invoke-static {v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DelayKt;->getDelay(Lkotlin/coroutines/CoroutineContext;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Delay;

    move-result-object v2

    invoke-static {v0, v1, v2, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/TimeoutKt;->TimeoutCancellationException(JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Delay;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/TimeoutCancellationException;

    move-result-object v0

    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;->cancelCoroutine(Ljava/lang/Throwable;)Z

    return-void
.end method
