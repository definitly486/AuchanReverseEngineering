.class public final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;
.source "DispatchedContinuation.kt"

# interfaces
.implements Lkotlin/coroutines/jvm/internal/CoroutineStackFrame;
.implements Lkotlin/coroutines/Continuation;


# static fields
.field private static final synthetic _reusableCancellableContinuation$volatile$FU:Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;


# instance fields
.field private volatile synthetic _reusableCancellableContinuation$volatile:Ljava/lang/Object;

.field public _state:Ljava/lang/Object;

.field public final continuation:Lkotlin/coroutines/Continuation;

.field public final countOrElement:Ljava/lang/Object;

.field public final dispatcher:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;


# direct methods
.method static constructor <clinit>()V
    .locals 3

    .line 0
    const-class v0, Ljava/lang/Object;

    const-string v1, "_reusableCancellableContinuation$volatile"

    const-class v2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;

    invoke-static {v2, v0, v1}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->newUpdater(Ljava/lang/Class;Ljava/lang/Class;Ljava/lang/String;)Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->_reusableCancellableContinuation$volatile$FU:Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    return-void
.end method

.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;Lkotlin/coroutines/Continuation;)V
    .locals 1

    const/4 v0, -0x1

    .line 15
    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;-><init>(I)V

    .line 13
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->dispatcher:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;

    .line 14
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->continuation:Lkotlin/coroutines/Continuation;

    .line 18
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuationKt;->access$getUNDEFINED$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->_state:Ljava/lang/Object;

    .line 22
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->getContext()Lkotlin/coroutines/CoroutineContext;

    move-result-object p1

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadContextKt;->threadContextElements(Lkotlin/coroutines/CoroutineContext;)Ljava/lang/Object;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->countOrElement:Ljava/lang/Object;

    return-void
.end method

.method private final getReusableCancellableContinuation()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;
    .locals 2

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->get_reusableCancellableContinuation$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    .line 55
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    instance-of v1, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    if-eqz v1, :cond_0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    return-object v0

    :cond_0
    const/4 v0, 0x0

    return-object v0
.end method

.method private static final synthetic get_reusableCancellableContinuation$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;
    .locals 1

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->_reusableCancellableContinuation$volatile$FU:Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    return-object v0
.end method


# virtual methods
.method public final awaitReusability$kotlinx_coroutines_core()V
    .locals 3

    .line 71
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->get_reusableCancellableContinuation$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    :cond_0
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    .line 73
    sget-object v2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuationKt;->REUSABLE_CLAIMED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    if-eq v1, v2, :cond_0

    return-void
.end method

.method public final claimReusableCancellableContinuation$kotlinx_coroutines_core()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;
    .locals 4

    .line 91
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->get_reusableCancellableContinuation$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    :cond_0
    :goto_0
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    if-nez v1, :cond_1

    .line 100
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->get_reusableCancellableContinuation$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    .line 105
    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuationKt;->REUSABLE_CLAIMED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    invoke-virtual {v0, p0, v1}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->set(Ljava/lang/Object;Ljava/lang/Object;)V

    const/4 v0, 0x0

    return-object v0

    .line 109
    :cond_1
    instance-of v2, v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    if-eqz v2, :cond_2

    .line 110
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->get_reusableCancellableContinuation$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v2

    sget-object v3, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuationKt;->REUSABLE_CLAIMED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    invoke-static {v2, p0, v1, v3}, Landroidx/concurrent/futures/AbstractResolvableFuture$SafeAtomicHelper$$ExternalSyntheticBackportWithForwarding0;->m(Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_0

    .line 111
    check-cast v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    return-object v1

    .line 114
    :cond_2
    sget-object v2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuationKt;->REUSABLE_CLAIMED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    if-eq v1, v2, :cond_0

    .line 118
    instance-of v2, v1, Ljava/lang/Throwable;

    if-eqz v2, :cond_3

    goto :goto_0

    :cond_3
    new-instance v0, Ljava/lang/IllegalStateException;

    .line 122
    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "Inconsistent state "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method public final dispatchYield$kotlinx_coroutines_core(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Object;)V
    .locals 0

    .line 243
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->_state:Ljava/lang/Object;

    const/4 p2, 0x1

    .line 244
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;->resumeMode:I

    .line 245
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->dispatcher:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;

    invoke-virtual {p2, p1, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;->dispatchYield(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Runnable;)V

    return-void
.end method

.method public getCallerFrame()Lkotlin/coroutines/jvm/internal/CoroutineStackFrame;
    .locals 2

    .line 19
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->continuation:Lkotlin/coroutines/Continuation;

    instance-of v1, v0, Lkotlin/coroutines/jvm/internal/CoroutineStackFrame;

    if-eqz v1, :cond_0

    check-cast v0, Lkotlin/coroutines/jvm/internal/CoroutineStackFrame;

    return-object v0

    :cond_0
    const/4 v0, 0x0

    return-object v0
.end method

.method public getContext()Lkotlin/coroutines/CoroutineContext;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->continuation:Lkotlin/coroutines/Continuation;

    invoke-interface {v0}, Lkotlin/coroutines/Continuation;->getContext()Lkotlin/coroutines/CoroutineContext;

    move-result-object v0

    return-object v0
.end method

.method public getDelegate$kotlinx_coroutines_core()Lkotlin/coroutines/Continuation;
    .locals 0

    .line 186
    return-object p0
.end method

.method public final isReusable$kotlinx_coroutines_core()Z
    .locals 1

    .line 64
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->get_reusableCancellableContinuation$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public final postponeCancellation$kotlinx_coroutines_core(Ljava/lang/Throwable;)Z
    .locals 5

    .line 161
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->get_reusableCancellableContinuation$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    :cond_0
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    .line 164
    sget-object v2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuationKt;->REUSABLE_CLAIMED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    invoke-static {v1, v2}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v3

    const/4 v4, 0x1

    if-eqz v3, :cond_1

    .line 165
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->get_reusableCancellableContinuation$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v1

    invoke-static {v1, p0, v2, p1}, Landroidx/concurrent/futures/AbstractResolvableFuture$SafeAtomicHelper$$ExternalSyntheticBackportWithForwarding0;->m(Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_0

    return v4

    .line 168
    :cond_1
    instance-of v2, v1, Ljava/lang/Throwable;

    if-eqz v2, :cond_2

    return v4

    .line 171
    :cond_2
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->get_reusableCancellableContinuation$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v2

    const/4 v3, 0x0

    invoke-static {v2, p0, v1, v3}, Landroidx/concurrent/futures/AbstractResolvableFuture$SafeAtomicHelper$$ExternalSyntheticBackportWithForwarding0;->m(Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_0

    const/4 p1, 0x0

    return p1
.end method

.method public final release$kotlinx_coroutines_core()V
    .locals 1

    .line 83
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->awaitReusability$kotlinx_coroutines_core()V

    .line 84
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->getReusableCancellableContinuation()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    move-result-object v0

    if-eqz v0, :cond_0

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->detachChild$kotlinx_coroutines_core()V

    :cond_0
    return-void
.end method

.method public resumeWith(Ljava/lang/Object;)V
    .locals 5

    .line 189
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletionStateKt;->toState(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    .line 190
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->dispatcher:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->getContext()Lkotlin/coroutines/CoroutineContext;

    move-result-object v2

    invoke-static {v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuationKt;->safeIsDispatchNeeded(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;Lkotlin/coroutines/CoroutineContext;)Z

    move-result v1

    const/4 v2, 0x0

    if-eqz v1, :cond_0

    .line 191
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->_state:Ljava/lang/Object;

    .line 192
    iput v2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;->resumeMode:I

    .line 193
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->dispatcher:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->getContext()Lkotlin/coroutines/CoroutineContext;

    move-result-object v0

    invoke-static {p1, v0, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuationKt;->safeDispatch(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;Lkotlin/coroutines/CoroutineContext;Ljava/lang/Runnable;)V

    return-void

    .line 321
    :cond_0
    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ThreadLocalEventLoop;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ThreadLocalEventLoop;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ThreadLocalEventLoop;->getEventLoop$kotlinx_coroutines_core()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;

    move-result-object v1

    .line 324
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;->isUnconfinedLoopActive()Z

    move-result v3

    if-eqz v3, :cond_1

    .line 326
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->_state:Ljava/lang/Object;

    .line 327
    iput v2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;->resumeMode:I

    .line 328
    invoke-virtual {v1, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;->dispatchUnconfined(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;)V

    goto :goto_2

    :cond_1
    const/4 v0, 0x1

    .line 333
    invoke-virtual {v1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;->incrementUseCount(Z)V

    .line 196
    :try_start_0
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->getContext()Lkotlin/coroutines/CoroutineContext;

    move-result-object v2

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->countOrElement:Ljava/lang/Object;

    .line 336
    invoke-static {v2, v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadContextKt;->updateThreadContext(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v3
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 197
    :try_start_1
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->continuation:Lkotlin/coroutines/Continuation;

    invoke-interface {v4, p1}, Lkotlin/coroutines/Continuation;->resumeWith(Ljava/lang/Object;)V

    .line 198
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_1

    .line 340
    :try_start_2
    invoke-static {v2, v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadContextKt;->restoreThreadContext(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Object;)V

    .line 343
    :cond_2
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;->processUnconfinedEvent()Z

    move-result p1
    :try_end_2
    .catchall {:try_start_2 .. :try_end_2} :catchall_0

    if-nez p1, :cond_2

    .line 352
    :goto_0
    invoke-virtual {v1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;->decrementUseCount(Z)V

    goto :goto_2

    :catchall_0
    move-exception p1

    goto :goto_1

    :catchall_1
    move-exception p1

    .line 340
    :try_start_3
    invoke-static {v2, v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadContextKt;->restoreThreadContext(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Object;)V

    throw p1
    :try_end_3
    .catchall {:try_start_3 .. :try_end_3} :catchall_0

    .line 350
    :goto_1
    :try_start_4
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;->handleFatalException$kotlinx_coroutines_core(Ljava/lang/Throwable;)V
    :try_end_4
    .catchall {:try_start_4 .. :try_end_4} :catchall_2

    goto :goto_0

    :goto_2
    return-void

    :catchall_2
    move-exception p1

    .line 352
    invoke-virtual {v1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;->decrementUseCount(Z)V

    throw p1
.end method

.method public takeState$kotlinx_coroutines_core()Ljava/lang/Object;
    .locals 2

    .line 179
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->_state:Ljava/lang/Object;

    .line 181
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuationKt;->access$getUNDEFINED$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v1

    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->_state:Ljava/lang/Object;

    return-object v0
.end method

.method public toString()Ljava/lang/String;
    .locals 2

    .line 249
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "DispatchedContinuation["

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->dispatcher:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v1, ", "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->continuation:Lkotlin/coroutines/Continuation;

    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DebugStringsKt;->toDebugString(Lkotlin/coroutines/Continuation;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const/16 v1, 0x5d

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public final tryReleaseClaimedContinuation$kotlinx_coroutines_core(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;)Ljava/lang/Throwable;
    .locals 4

    .line 141
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->get_reusableCancellableContinuation$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    :cond_0
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    .line 145
    sget-object v2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuationKt;->REUSABLE_CLAIMED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    const/4 v3, 0x0

    if-ne v1, v2, :cond_1

    .line 146
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->get_reusableCancellableContinuation$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v1

    invoke-static {v1, p0, v2, p1}, Landroidx/concurrent/futures/AbstractResolvableFuture$SafeAtomicHelper$$ExternalSyntheticBackportWithForwarding0;->m(Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_0

    return-object v3

    .line 148
    :cond_1
    instance-of p1, v1, Ljava/lang/Throwable;

    if-eqz p1, :cond_3

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->get_reusableCancellableContinuation$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object p1

    .line 149
    invoke-static {p1, p0, v1, v3}, Landroidx/concurrent/futures/AbstractResolvableFuture$SafeAtomicHelper$$ExternalSyntheticBackportWithForwarding0;->m(Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result p1

    if-eqz p1, :cond_2

    .line 150
    check-cast v1, Ljava/lang/Throwable;

    return-object v1

    .line 149
    :cond_2
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string v0, "Failed requirement."

    invoke-direct {p1, v0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1

    .line 150
    :cond_3
    new-instance p1, Ljava/lang/IllegalStateException;

    .line 152
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Inconsistent state "

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-direct {p1, v0}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw p1
.end method
