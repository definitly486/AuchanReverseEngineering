.class public final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/NamedDispatcher;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;
.source "NamedDispatcher.kt"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Delay;


# instance fields
.field private final synthetic $$delegate_0:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Delay;

.field private final dispatcher:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;

.field private final name:Ljava/lang/String;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;Ljava/lang/String;)V
    .locals 1

    .line 13
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;-><init>()V

    instance-of v0, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Delay;

    if-eqz v0, :cond_0

    move-object v0, p1

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Delay;

    goto :goto_0

    :cond_0
    const/4 v0, 0x0

    :goto_0
    if-nez v0, :cond_1

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DefaultExecutorKt;->getDefaultDelay()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Delay;

    move-result-object v0

    :cond_1
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/NamedDispatcher;->$$delegate_0:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Delay;

    .line 11
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/NamedDispatcher;->dispatcher:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;

    .line 12
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/NamedDispatcher;->name:Ljava/lang/String;

    return-void
.end method


# virtual methods
.method public dispatch(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Runnable;)V
    .locals 1

    .line 17
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/NamedDispatcher;->dispatcher:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;

    invoke-virtual {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;->dispatch(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Runnable;)V

    return-void
.end method

.method public dispatchYield(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Runnable;)V
    .locals 1

    .line 20
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/NamedDispatcher;->dispatcher:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;

    invoke-virtual {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;->dispatchYield(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Runnable;)V

    return-void
.end method

.method public invokeOnTimeout(JLjava/lang/Runnable;Lkotlin/coroutines/CoroutineContext;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/NamedDispatcher;->$$delegate_0:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Delay;

    invoke-interface {v0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Delay;->invokeOnTimeout(JLjava/lang/Runnable;Lkotlin/coroutines/CoroutineContext;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;

    move-result-object p1

    return-object p1
.end method

.method public isDispatchNeeded(Lkotlin/coroutines/CoroutineContext;)Z
    .locals 1

    .line 15
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/NamedDispatcher;->dispatcher:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;->isDispatchNeeded(Lkotlin/coroutines/CoroutineContext;)Z

    move-result p1

    return p1
.end method

.method public scheduleResumeAfterDelay(JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;)V
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/NamedDispatcher;->$$delegate_0:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Delay;

    invoke-interface {v0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Delay;->scheduleResumeAfterDelay(JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;)V

    return-void
.end method

.method public toString()Ljava/lang/String;
    .locals 1

    .line 23
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/NamedDispatcher;->name:Ljava/lang/String;

    return-object v0
.end method
