.class public Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;
.source "CancellableContinuationImpl.kt"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;
.implements Lkotlin/coroutines/jvm/internal/CoroutineStackFrame;
.implements Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;


# static fields
.field private static final synthetic _decisionAndIndex$volatile$FU:Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

.field private static final synthetic _parentHandle$volatile$FU:Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

.field private static final synthetic _state$volatile$FU:Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;


# instance fields
.field private volatile synthetic _decisionAndIndex$volatile:I

.field private volatile synthetic _parentHandle$volatile:Ljava/lang/Object;

.field private volatile synthetic _state$volatile:Ljava/lang/Object;

.field private final context:Lkotlin/coroutines/CoroutineContext;

.field private final delegate:Lkotlin/coroutines/Continuation;


# direct methods
.method public static synthetic $r8$lambda$l1v82JNL5Nl-KgSjI328OOjF67g(Lkotlin/jvm/functions/Function1;Ljava/lang/Throwable;Ljava/lang/Object;Lkotlin/coroutines/CoroutineContext;)Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
    .locals 0

    .line 0
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->resume$lambda$13$lambda$12(Lkotlin/jvm/functions/Function1;Ljava/lang/Throwable;Ljava/lang/Object;Lkotlin/coroutines/CoroutineContext;)Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    move-result-object p0

    return-object p0
.end method

.method static constructor <clinit>()V
    .locals 3

    .line 0
    const-string v0, "_decisionAndIndex$volatile"

    const-class v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    invoke-static {v1, v0}, Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;->newUpdater(Ljava/lang/Class;Ljava/lang/String;)Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->_decisionAndIndex$volatile$FU:Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    const-string v0, "_state$volatile"

    const-class v2, Ljava/lang/Object;

    invoke-static {v1, v2, v0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->newUpdater(Ljava/lang/Class;Ljava/lang/Class;Ljava/lang/String;)Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->_state$volatile$FU:Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    const-string v0, "_parentHandle$volatile"

    invoke-static {v1, v2, v0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->newUpdater(Ljava/lang/Class;Ljava/lang/Class;Ljava/lang/String;)Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->_parentHandle$volatile$FU:Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    return-void
.end method

.method public constructor <init>(Lkotlin/coroutines/Continuation;I)V
    .locals 0

    .line 33
    invoke-direct {p0, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;-><init>(I)V

    .line 31
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->delegate:Lkotlin/coroutines/Continuation;

    .line 38
    invoke-interface {p1}, Lkotlin/coroutines/Continuation;->getContext()Lkotlin/coroutines/CoroutineContext;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->context:Lkotlin/coroutines/CoroutineContext;

    const p1, 0x1fffffff

    .line 703
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->_decisionAndIndex$volatile:I

    .line 80
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Active;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Active;

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->_state$volatile:Ljava/lang/Object;

    return-void
.end method

.method private final alreadyResumedError(Ljava/lang/Object;)Ljava/lang/Void;
    .locals 3

    new-instance v0, Ljava/lang/IllegalStateException;

    .line 556
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Already resumed, but proposed with update "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-virtual {p1}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {v0, p1}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method private final callSegmentOnCancellation(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;Ljava/lang/Throwable;)V
    .locals 3

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->get_decisionAndIndex$volatile$FU()Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    move-result-object v0

    .line 242
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;->get(Ljava/lang/Object;)I

    move-result v0

    const v1, 0x1fffffff

    and-int/2addr v0, v1

    if-eq v0, v1, :cond_0

    .line 244
    :try_start_0
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->getContext()Lkotlin/coroutines/CoroutineContext;

    move-result-object v1

    invoke-virtual {p1, v0, p2, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->onCancellation(ILjava/lang/Throwable;Lkotlin/coroutines/CoroutineContext;)V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    return-void

    :catchall_0
    move-exception p1

    .line 721
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->getContext()Lkotlin/coroutines/CoroutineContext;

    move-result-object p2

    .line 722
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletionHandlerException;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Exception in invokeOnCancellation handler for "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletionHandlerException;-><init>(Ljava/lang/String;Ljava/lang/Throwable;)V

    .line 720
    invoke-static {p2, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandlerKt;->handleCoroutineException(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Throwable;)V

    return-void

    .line 243
    :cond_0
    new-instance p1, Ljava/lang/IllegalStateException;

    const-string p2, "The index for Segment.onCancellation(..) is broken"

    invoke-direct {p1, p2}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method private final cancelLater(Ljava/lang/Throwable;)Z
    .locals 2

    .line 196
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->isReusable()Z

    move-result v0

    if-nez v0, :cond_0

    const/4 p1, 0x0

    return p1

    .line 197
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->delegate:Lkotlin/coroutines/Continuation;

    const-string v1, "null cannot be cast to non-null type kotlinx.coroutines.internal.DispatchedContinuation<*>"

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;

    .line 198
    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->postponeCancellation$kotlinx_coroutines_core(Ljava/lang/Throwable;)Z

    move-result p1

    return p1
.end method

.method private final detachChildIfNonReusable()V
    .locals 1

    .line 562
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->isReusable()Z

    move-result v0

    if-nez v0, :cond_0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->detachChild$kotlinx_coroutines_core()V

    :cond_0
    return-void
.end method

.method private final dispatchResume(I)V
    .locals 1

    .line 468
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->tryResume()Z

    move-result v0

    if-eqz v0, :cond_0

    return-void

    .line 470
    :cond_0
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTaskKt;->dispatch(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;I)V

    return-void
.end method

.method private final getParentHandle()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;
    .locals 1

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->get_parentHandle$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    .line 103
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;

    return-object v0
.end method

.method private final getStateDebugRepresentation()Ljava/lang/String;
    .locals 2

    .line 114
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->getState$kotlinx_coroutines_core()Ljava/lang/Object;

    move-result-object v0

    .line 115
    instance-of v1, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NotCompleted;

    if-eqz v1, :cond_0

    const-string v0, "Active"

    return-object v0

    .line 116
    :cond_0
    instance-of v0, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancelledContinuation;

    if-eqz v0, :cond_1

    const-string v0, "Cancelled"

    return-object v0

    .line 117
    :cond_1
    const-string v0, "Completed"

    return-object v0
.end method

.method private static final synthetic get_decisionAndIndex$volatile$FU()Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;
    .locals 1

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->_decisionAndIndex$volatile$FU:Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    return-object v0
.end method

.method private static final synthetic get_parentHandle$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;
    .locals 1

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->_parentHandle$volatile$FU:Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    return-object v0
.end method

.method private static final synthetic get_state$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;
    .locals 1

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->_state$volatile$FU:Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    return-object v0
.end method

.method private final installParentHandle()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;
    .locals 5

    .line 340
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->getContext()Lkotlin/coroutines/CoroutineContext;

    move-result-object v0

    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;->Key:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job$Key;

    invoke-interface {v0, v1}, Lkotlin/coroutines/CoroutineContext;->get(Lkotlin/coroutines/CoroutineContext$Key;)Lkotlin/coroutines/CoroutineContext$Element;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;

    const/4 v1, 0x0

    if-nez v0, :cond_0

    return-object v1

    .line 342
    :cond_0
    new-instance v2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ChildContinuation;

    invoke-direct {v2, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ChildContinuation;-><init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;)V

    const/4 v3, 0x1

    const/4 v4, 0x0

    invoke-static {v0, v4, v2, v3, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobKt;->invokeOnCompletion$default(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;ZLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobNode;ILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;

    move-result-object v0

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->get_parentHandle$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v2

    .line 343
    invoke-static {v2, p0, v1, v0}, Landroidx/concurrent/futures/AbstractResolvableFuture$SafeAtomicHelper$$ExternalSyntheticBackportWithForwarding0;->m(Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Z

    return-object v0
.end method

.method private final invokeOnCancellationImpl(Ljava/lang/Object;)V
    .locals 12

    .line 400
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->get_state$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    :cond_0
    :goto_0
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v2

    .line 404
    instance-of v1, v2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Active;

    if-eqz v1, :cond_1

    .line 405
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->get_state$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v1

    invoke-static {v1, p0, v2, p1}, Landroidx/concurrent/futures/AbstractResolvableFuture$SafeAtomicHelper$$ExternalSyntheticBackportWithForwarding0;->m(Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_0

    goto/16 :goto_2

    .line 407
    :cond_1
    instance-of v1, v2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancelHandler;

    if-nez v1, :cond_e

    instance-of v1, v2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;

    if-eqz v1, :cond_2

    goto/16 :goto_3

    .line 408
    :cond_2
    instance-of v1, v2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedExceptionally;

    if-eqz v1, :cond_7

    .line 414
    move-object v0, v2

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedExceptionally;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedExceptionally;->makeHandled()Z

    move-result v1

    if-nez v1, :cond_3

    invoke-direct {p0, p1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->multipleHandlersError(Ljava/lang/Object;Ljava/lang/Object;)V

    .line 420
    :cond_3
    instance-of v1, v2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancelledContinuation;

    if-eqz v1, :cond_d

    const/4 v1, 0x0

    if-eqz v2, :cond_4

    goto :goto_1

    :cond_4
    move-object v0, v1

    :goto_1
    if-eqz v0, :cond_5

    .line 421
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedExceptionally;->cause:Ljava/lang/Throwable;

    .line 422
    :cond_5
    instance-of v0, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancelHandler;

    if-eqz v0, :cond_6

    .line 423
    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancelHandler;

    invoke-virtual {p0, p1, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->callCancelHandler(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancelHandler;Ljava/lang/Throwable;)V

    return-void

    .line 425
    :cond_6
    const-string v0, "null cannot be cast to non-null type kotlinx.coroutines.internal.Segment<*>"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;

    .line 426
    invoke-direct {p0, p1, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->callSegmentOnCancellation(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;Ljava/lang/Throwable;)V

    return-void

    .line 432
    :cond_7
    instance-of v1, v2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedContinuation;

    const-string v3, "null cannot be cast to non-null type kotlinx.coroutines.CancelHandler"

    if-eqz v1, :cond_b

    .line 436
    move-object v4, v2

    check-cast v4, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedContinuation;

    iget-object v1, v4, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedContinuation;->cancelHandler:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancelHandler;

    if-eqz v1, :cond_8

    invoke-direct {p0, p1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->multipleHandlersError(Ljava/lang/Object;Ljava/lang/Object;)V

    .line 438
    :cond_8
    instance-of v1, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;

    if-eqz v1, :cond_9

    return-void

    .line 439
    :cond_9
    invoke-static {p1, v3}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    move-object v6, p1

    check-cast v6, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancelHandler;

    .line 440
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedContinuation;->getCancelled()Z

    move-result v1

    if-eqz v1, :cond_a

    .line 442
    iget-object p1, v4, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedContinuation;->cancelCause:Ljava/lang/Throwable;

    invoke-virtual {p0, v6, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->callCancelHandler(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancelHandler;Ljava/lang/Throwable;)V

    return-void

    :cond_a
    const/16 v10, 0x1d

    const/4 v11, 0x0

    const/4 v5, 0x0

    const/4 v7, 0x0

    const/4 v8, 0x0

    const/4 v9, 0x0

    .line 445
    invoke-static/range {v4 .. v11}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedContinuation;->copy$default(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedContinuation;Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancelHandler;Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;Ljava/lang/Object;Ljava/lang/Throwable;ILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedContinuation;

    move-result-object v1

    .line 446
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->get_state$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v3

    invoke-static {v3, p0, v2, v1}, Landroidx/concurrent/futures/AbstractResolvableFuture$SafeAtomicHelper$$ExternalSyntheticBackportWithForwarding0;->m(Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_0

    goto :goto_2

    .line 454
    :cond_b
    instance-of v1, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;

    if-eqz v1, :cond_c

    return-void

    .line 455
    :cond_c
    invoke-static {p1, v3}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    move-object v3, p1

    check-cast v3, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancelHandler;

    .line 456
    new-instance v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedContinuation;

    const/16 v7, 0x1c

    const/4 v8, 0x0

    const/4 v4, 0x0

    const/4 v5, 0x0

    const/4 v6, 0x0

    invoke-direct/range {v1 .. v8}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedContinuation;-><init>(Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancelHandler;Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;Ljava/lang/Object;Ljava/lang/Throwable;ILkotlin/jvm/internal/DefaultConstructorMarker;)V

    .line 457
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->get_state$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v3

    invoke-static {v3, p0, v2, v1}, Landroidx/concurrent/futures/AbstractResolvableFuture$SafeAtomicHelper$$ExternalSyntheticBackportWithForwarding0;->m(Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_0

    :cond_d
    :goto_2
    return-void

    .line 407
    :cond_e
    :goto_3
    invoke-direct {p0, p1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->multipleHandlersError(Ljava/lang/Object;Ljava/lang/Object;)V

    goto/16 :goto_0
.end method

.method private final isReusable()Z
    .locals 2

    .line 138
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;->resumeMode:I

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTaskKt;->isReusableMode(I)Z

    move-result v0

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->delegate:Lkotlin/coroutines/Continuation;

    const-string v1, "null cannot be cast to non-null type kotlinx.coroutines.internal.DispatchedContinuation<*>"

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->isReusable$kotlinx_coroutines_core()Z

    move-result v0

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method private final multipleHandlersError(Ljava/lang/Object;Ljava/lang/Object;)V
    .locals 3

    new-instance v0, Ljava/lang/IllegalStateException;

    .line 464
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "It\'s prohibited to register multiple handlers, tried to register "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string p1, ", already has "

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-virtual {p1}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {v0, p1}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method private static final resume$lambda$13$lambda$12(Lkotlin/jvm/functions/Function1;Ljava/lang/Throwable;Ljava/lang/Object;Lkotlin/coroutines/CoroutineContext;)Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
    .locals 0

    .line 363
    invoke-interface {p0, p1}, Lkotlin/jvm/functions/Function1;->invoke(Ljava/lang/Object;)Ljava/lang/Object;

    sget-object p0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    return-object p0
.end method

.method public static synthetic resumeImpl$kotlinx_coroutines_core$default(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;Ljava/lang/Object;ILcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;ILjava/lang/Object;)V
    .locals 0

    if-nez p5, :cond_1

    and-int/lit8 p4, p4, 0x4

    if-eqz p4, :cond_0

    const/4 p3, 0x0

    .line 493
    :cond_0
    invoke-virtual {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->resumeImpl$kotlinx_coroutines_core(Ljava/lang/Object;ILcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;)V

    return-void

    :cond_1
    new-instance p0, Ljava/lang/UnsupportedOperationException;

    const-string p1, "Super calls with default arguments not supported in this target, function: resumeImpl"

    invoke-direct {p0, p1}, Ljava/lang/UnsupportedOperationException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method private final resumedState(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NotCompleted;Ljava/lang/Object;ILcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 8

    .line 480
    instance-of v0, p2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedExceptionally;

    if-eqz v0, :cond_0

    return-object p2

    .line 485
    :cond_0
    invoke-static {p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTaskKt;->isCancellableMode(I)Z

    move-result p3

    if-nez p3, :cond_1

    if-nez p5, :cond_1

    goto :goto_0

    :cond_1
    if-nez p4, :cond_3

    .line 486
    instance-of p3, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancelHandler;

    if-nez p3, :cond_3

    if-eqz p5, :cond_2

    goto :goto_1

    :cond_2
    :goto_0
    return-object p2

    .line 489
    :cond_3
    :goto_1
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedContinuation;

    instance-of p3, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancelHandler;

    if-eqz p3, :cond_4

    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancelHandler;

    :goto_2
    move-object v2, p1

    goto :goto_3

    :cond_4
    const/4 p1, 0x0

    goto :goto_2

    :goto_3
    const/16 v6, 0x10

    const/4 v7, 0x0

    const/4 v5, 0x0

    move-object v1, p2

    move-object v3, p4

    move-object v4, p5

    invoke-direct/range {v0 .. v7}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedContinuation;-><init>(Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancelHandler;Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;Ljava/lang/Object;Ljava/lang/Throwable;ILkotlin/jvm/internal/DefaultConstructorMarker;)V

    return-object v0
.end method

.method private final tryResume()Z
    .locals 6

    .line 279
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->get_decisionAndIndex$volatile$FU()Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    move-result-object v0

    :cond_0
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;->get(Ljava/lang/Object;)I

    move-result v1

    shr-int/lit8 v2, v1, 0x1d

    const/4 v3, 0x1

    if-eqz v2, :cond_2

    if-ne v2, v3, :cond_1

    const/4 v0, 0x0

    return v0

    .line 283
    :cond_1
    new-instance v0, Ljava/lang/IllegalStateException;

    .line 284
    const-string v1, "Already resumed"

    invoke-direct {v0, v1}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 282
    :cond_2
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->get_decisionAndIndex$volatile$FU()Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    move-result-object v2

    const v4, 0x1fffffff

    and-int/2addr v4, v1

    const/high16 v5, 0x40000000    # 2.0f

    add-int/2addr v5, v4

    invoke-virtual {v2, p0, v1, v5}, Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;->compareAndSet(Ljava/lang/Object;II)Z

    move-result v1

    if-eqz v1, :cond_0

    return v3
.end method

.method private final tryResumeImpl(Ljava/lang/Object;Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;
    .locals 9

    .line 529
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->get_state$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    :goto_0
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    .line 536
    instance-of v2, v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NotCompleted;

    if-eqz v2, :cond_1

    .line 537
    move-object v4, v1

    check-cast v4, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NotCompleted;

    iget v6, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;->resumeMode:I

    move-object v3, p0

    move-object v5, p1

    move-object v8, p2

    move-object v7, p3

    invoke-direct/range {v3 .. v8}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->resumedState(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NotCompleted;Ljava/lang/Object;ILcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    .line 538
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->get_state$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object p2

    invoke-static {p2, p0, v1, p1}, Landroidx/concurrent/futures/AbstractResolvableFuture$SafeAtomicHelper$$ExternalSyntheticBackportWithForwarding0;->m(Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result p1

    if-eqz p1, :cond_0

    .line 539
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->detachChildIfNonReusable()V

    .line 540
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImplKt;->RESUME_TOKEN:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    return-object p1

    :cond_0
    move-object p1, v5

    move-object p3, v7

    move-object p2, v8

    goto :goto_0

    :cond_1
    move-object v3, p0

    move-object v8, p2

    .line 542
    instance-of p1, v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedContinuation;

    const/4 p2, 0x0

    if-eqz p1, :cond_2

    if-eqz v8, :cond_2

    .line 543
    check-cast v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedContinuation;

    iget-object p1, v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedContinuation;->idempotentResume:Ljava/lang/Object;

    if-ne p1, v8, :cond_2

    .line 545
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImplKt;->RESUME_TOKEN:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    return-object p1

    :cond_2
    return-object p2
.end method

.method private final trySuspend()Z
    .locals 5

    .line 269
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->get_decisionAndIndex$volatile$FU()Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    move-result-object v0

    :cond_0
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;->get(Ljava/lang/Object;)I

    move-result v1

    shr-int/lit8 v2, v1, 0x1d

    if-eqz v2, :cond_2

    const/4 v0, 0x2

    if-ne v2, v0, :cond_1

    const/4 v0, 0x0

    return v0

    .line 273
    :cond_1
    new-instance v0, Ljava/lang/IllegalStateException;

    .line 274
    const-string v1, "Already suspended"

    invoke-direct {v0, v1}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 272
    :cond_2
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->get_decisionAndIndex$volatile$FU()Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    move-result-object v2

    const v3, 0x1fffffff

    and-int/2addr v3, v1

    const/high16 v4, 0x20000000

    add-int/2addr v4, v3

    invoke-virtual {v2, p0, v1, v4}, Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;->compareAndSet(Ljava/lang/Object;II)Z

    move-result v1

    if-eqz v1, :cond_0

    const/4 v0, 0x1

    return v0
.end method


# virtual methods
.method public final callCancelHandler(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancelHandler;Ljava/lang/Throwable;)V
    .locals 3

    .line 239
    :try_start_0
    invoke-interface {p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancelHandler;->invoke(Ljava/lang/Throwable;)V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    return-void

    :catchall_0
    move-exception p1

    .line 710
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->getContext()Lkotlin/coroutines/CoroutineContext;

    move-result-object p2

    .line 711
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletionHandlerException;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Exception in invokeOnCancellation handler for "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletionHandlerException;-><init>(Ljava/lang/String;Ljava/lang/Throwable;)V

    .line 709
    invoke-static {p2, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandlerKt;->handleCoroutineException(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Throwable;)V

    return-void
.end method

.method public final callOnCancellation(Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;Ljava/lang/Throwable;Ljava/lang/Object;)V
    .locals 2

    .line 253
    :try_start_0
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->getContext()Lkotlin/coroutines/CoroutineContext;

    move-result-object v0

    invoke-interface {p1, p2, p3, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;->invoke(Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    return-void

    :catchall_0
    move-exception p1

    .line 257
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->getContext()Lkotlin/coroutines/CoroutineContext;

    move-result-object p2

    .line 258
    new-instance p3, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletionHandlerException;

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "Exception in resume onCancellation handler for "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-direct {p3, v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletionHandlerException;-><init>(Ljava/lang/String;Ljava/lang/Throwable;)V

    .line 256
    invoke-static {p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandlerKt;->handleCoroutineException(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Throwable;)V

    return-void
.end method

.method public cancel(Ljava/lang/Throwable;)Z
    .locals 6

    .line 201
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->get_state$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    :cond_0
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    .line 203
    instance-of v2, v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NotCompleted;

    const/4 v3, 0x0

    if-nez v2, :cond_1

    return v3

    .line 205
    :cond_1
    new-instance v2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancelledContinuation;

    instance-of v4, v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancelHandler;

    const/4 v5, 0x1

    if-nez v4, :cond_2

    instance-of v4, v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;

    if-eqz v4, :cond_3

    :cond_2
    move v3, v5

    :cond_3
    invoke-direct {v2, p0, p1, v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancelledContinuation;-><init>(Lkotlin/coroutines/Continuation;Ljava/lang/Throwable;Z)V

    .line 206
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->get_state$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v3

    invoke-static {v3, p0, v1, v2}, Landroidx/concurrent/futures/AbstractResolvableFuture$SafeAtomicHelper$$ExternalSyntheticBackportWithForwarding0;->m(Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_0

    .line 208
    move-object v0, v1

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NotCompleted;

    .line 209
    instance-of v2, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancelHandler;

    if-eqz v2, :cond_4

    check-cast v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancelHandler;

    invoke-virtual {p0, v1, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->callCancelHandler(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancelHandler;Ljava/lang/Throwable;)V

    goto :goto_0

    .line 210
    :cond_4
    instance-of v0, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;

    if-eqz v0, :cond_5

    check-cast v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;

    invoke-direct {p0, v1, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->callSegmentOnCancellation(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;Ljava/lang/Throwable;)V

    .line 213
    :cond_5
    :goto_0
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->detachChildIfNonReusable()V

    .line 214
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;->resumeMode:I

    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->dispatchResume(I)V

    return v5
.end method

.method public cancelCompletedResult$kotlinx_coroutines_core(Ljava/lang/Object;Ljava/lang/Throwable;)V
    .locals 10

    .line 169
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->get_state$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object p1

    :goto_0
    invoke-virtual {p1, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    .line 171
    instance-of v0, v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NotCompleted;

    if-nez v0, :cond_4

    .line 172
    instance-of v0, v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedExceptionally;

    if-eqz v0, :cond_0

    goto :goto_1

    .line 173
    :cond_0
    instance-of v0, v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedContinuation;

    if-eqz v0, :cond_2

    .line 174
    move-object v2, v1

    check-cast v2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedContinuation;

    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedContinuation;->getCancelled()Z

    move-result v0

    if-nez v0, :cond_1

    const/16 v8, 0xf

    const/4 v9, 0x0

    const/4 v3, 0x0

    const/4 v4, 0x0

    const/4 v5, 0x0

    const/4 v6, 0x0

    move-object v7, p2

    .line 175
    invoke-static/range {v2 .. v9}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedContinuation;->copy$default(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedContinuation;Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancelHandler;Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;Ljava/lang/Object;Ljava/lang/Throwable;ILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedContinuation;

    move-result-object p2

    move-object v5, v7

    .line 176
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->get_state$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    invoke-static {v0, p0, v1, p2}, Landroidx/concurrent/futures/AbstractResolvableFuture$SafeAtomicHelper$$ExternalSyntheticBackportWithForwarding0;->m(Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result p2

    if-eqz p2, :cond_3

    .line 177
    invoke-virtual {v2, p0, v5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedContinuation;->invokeHandlers(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;Ljava/lang/Throwable;)V

    return-void

    .line 174
    :cond_1
    new-instance p1, Ljava/lang/IllegalStateException;

    const-string p2, "Must be called at most once"

    invoke-direct {p1, p2}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw p1

    :cond_2
    move-object v5, p2

    .line 184
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->get_state$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object p2

    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedContinuation;

    const/16 v6, 0xe

    const/4 v7, 0x0

    const/4 v2, 0x0

    const/4 v3, 0x0

    const/4 v4, 0x0

    invoke-direct/range {v0 .. v7}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedContinuation;-><init>(Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancelHandler;Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;Ljava/lang/Object;Ljava/lang/Throwable;ILkotlin/jvm/internal/DefaultConstructorMarker;)V

    invoke-static {p2, p0, v1, v0}, Landroidx/concurrent/futures/AbstractResolvableFuture$SafeAtomicHelper$$ExternalSyntheticBackportWithForwarding0;->m(Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result p2

    if-eqz p2, :cond_3

    :goto_1
    return-void

    :cond_3
    move-object p2, v5

    goto :goto_0

    .line 171
    :cond_4
    new-instance p1, Ljava/lang/IllegalStateException;

    const-string p2, "Not completed"

    invoke-direct {p1, p2}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public completeResume(Ljava/lang/Object;)V
    .locals 0

    .line 591
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;->resumeMode:I

    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->dispatchResume(I)V

    return-void
.end method

.method public final detachChild$kotlinx_coroutines_core()V
    .locals 2

    .line 569
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->getParentHandle()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;

    move-result-object v0

    if-nez v0, :cond_0

    return-void

    .line 570
    :cond_0
    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;->dispose()V

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->get_parentHandle$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    .line 571
    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NonDisposableHandle;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NonDisposableHandle;

    invoke-virtual {v0, p0, v1}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->set(Ljava/lang/Object;Ljava/lang/Object;)V

    return-void
.end method

.method public getCallerFrame()Lkotlin/coroutines/jvm/internal/CoroutineStackFrame;
    .locals 2

    .line 161
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->delegate:Lkotlin/coroutines/Continuation;

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

    .line 38
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->context:Lkotlin/coroutines/CoroutineContext;

    return-object v0
.end method

.method public getContinuationCancellationCause(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;)Ljava/lang/Throwable;
    .locals 0

    .line 267
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;->getCancellationException()Ljava/util/concurrent/CancellationException;

    move-result-object p1

    return-object p1
.end method

.method public final getDelegate$kotlinx_coroutines_core()Lkotlin/coroutines/Continuation;
    .locals 1

    .line 31
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->delegate:Lkotlin/coroutines/Continuation;

    return-object v0
.end method

.method public getExceptionalResult$kotlinx_coroutines_core(Ljava/lang/Object;)Ljava/lang/Throwable;
    .locals 0

    .line 614
    invoke-super {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;->getExceptionalResult$kotlinx_coroutines_core(Ljava/lang/Object;)Ljava/lang/Throwable;

    move-result-object p1

    if-eqz p1, :cond_0

    return-object p1

    :cond_0
    const/4 p1, 0x0

    return-object p1
.end method

.method public final getResult()Ljava/lang/Object;
    .locals 3

    .line 291
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->isReusable()Z

    move-result v0

    .line 294
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->trySuspend()Z

    move-result v1

    if-eqz v1, :cond_2

    .line 304
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->getParentHandle()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;

    move-result-object v1

    if-nez v1, :cond_0

    .line 305
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->installParentHandle()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;

    :cond_0
    if-eqz v0, :cond_1

    .line 313
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->releaseClaimedReusableContinuation$kotlinx_coroutines_core()V

    .line 315
    :cond_1
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->getCOROUTINE_SUSPENDED()Ljava/lang/Object;

    move-result-object v0

    return-object v0

    :cond_2
    if-eqz v0, :cond_3

    .line 320
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->releaseClaimedReusableContinuation$kotlinx_coroutines_core()V

    .line 322
    :cond_3
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->getState$kotlinx_coroutines_core()Ljava/lang/Object;

    move-result-object v0

    .line 323
    instance-of v1, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedExceptionally;

    if-nez v1, :cond_6

    .line 328
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;->resumeMode:I

    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTaskKt;->isCancellableMode(I)Z

    move-result v1

    if-eqz v1, :cond_5

    .line 329
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->getContext()Lkotlin/coroutines/CoroutineContext;

    move-result-object v1

    sget-object v2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;->Key:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job$Key;

    invoke-interface {v1, v2}, Lkotlin/coroutines/CoroutineContext;->get(Lkotlin/coroutines/CoroutineContext$Key;)Lkotlin/coroutines/CoroutineContext$Element;

    move-result-object v1

    check-cast v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;

    if-eqz v1, :cond_5

    .line 330
    invoke-interface {v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;->isActive()Z

    move-result v2

    if-eqz v2, :cond_4

    goto :goto_0

    .line 331
    :cond_4
    invoke-interface {v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;->getCancellationException()Ljava/util/concurrent/CancellationException;

    move-result-object v1

    .line 332
    invoke-virtual {p0, v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->cancelCompletedResult$kotlinx_coroutines_core(Ljava/lang/Object;Ljava/lang/Throwable;)V

    .line 737
    throw v1

    .line 336
    :cond_5
    :goto_0
    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->getSuccessfulResult$kotlinx_coroutines_core(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    return-object v0

    .line 323
    :cond_6
    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedExceptionally;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedExceptionally;->cause:Ljava/lang/Throwable;

    .line 735
    throw v0
.end method

.method public final getState$kotlinx_coroutines_core()Ljava/lang/Object;
    .locals 1

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->get_state$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    .line 105
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    return-object v0
.end method

.method public getSuccessfulResult$kotlinx_coroutines_core(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 1

    .line 607
    instance-of v0, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedContinuation;

    if-eqz v0, :cond_0

    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedContinuation;

    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedContinuation;->result:Ljava/lang/Object;

    :cond_0
    return-object p1
.end method

.method public initCancellability()V
    .locals 2

    .line 126
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->installParentHandle()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;

    move-result-object v0

    if-nez v0, :cond_0

    goto :goto_0

    .line 131
    :cond_0
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->isCompleted()Z

    move-result v1

    if-eqz v1, :cond_1

    .line 133
    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;->dispose()V

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->get_parentHandle$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    .line 134
    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NonDisposableHandle;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NonDisposableHandle;

    invoke-virtual {v0, p0, v1}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->set(Ljava/lang/Object;Ljava/lang/Object;)V

    :cond_1
    :goto_0
    return-void
.end method

.method public invokeOnCancellation(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;I)V
    .locals 4

    .line 385
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->get_decisionAndIndex$volatile$FU()Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    move-result-object v0

    :cond_0
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;->get(Ljava/lang/Object;)I

    move-result v1

    const v2, 0x1fffffff

    and-int v3, v1, v2

    if-ne v3, v2, :cond_1

    shr-int/lit8 v2, v1, 0x1d

    shl-int/lit8 v2, v2, 0x1d

    add-int/2addr v2, p2

    .line 390
    invoke-virtual {v0, p0, v1, v2}, Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;->compareAndSet(Ljava/lang/Object;II)Z

    move-result v1

    if-eqz v1, :cond_0

    .line 392
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->invokeOnCancellationImpl(Ljava/lang/Object;)V

    return-void

    .line 387
    :cond_1
    new-instance p1, Ljava/lang/IllegalStateException;

    const-string p2, "invokeOnCancellation should be called at most once"

    invoke-direct {p1, p2}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public invokeOnCancellation(Lkotlin/jvm/functions/Function1;)V
    .locals 1

    .line 396
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancelHandler$UserSupplied;

    invoke-direct {v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancelHandler$UserSupplied;-><init>(Lkotlin/jvm/functions/Function1;)V

    invoke-static {p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationKt;->invokeOnCancellation(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancelHandler;)V

    return-void
.end method

.method public final invokeOnCancellationInternal$kotlinx_coroutines_core(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancelHandler;)V
    .locals 0

    .line 398
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->invokeOnCancellationImpl(Ljava/lang/Object;)V

    return-void
.end method

.method public isCompleted()Z
    .locals 1

    .line 109
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->getState$kotlinx_coroutines_core()Ljava/lang/Object;

    move-result-object v0

    instance-of v0, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NotCompleted;

    xor-int/lit8 v0, v0, 0x1

    return v0
.end method

.method protected nameString()Ljava/lang/String;
    .locals 1

    .line 621
    const-string v0, "CancellableContinuation"

    return-object v0
.end method

.method public final parentCancelled$kotlinx_coroutines_core(Ljava/lang/Throwable;)V
    .locals 1

    .line 220
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->cancelLater(Ljava/lang/Throwable;)Z

    move-result v0

    if-eqz v0, :cond_0

    return-void

    .line 221
    :cond_0
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->cancel(Ljava/lang/Throwable;)Z

    .line 223
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->detachChildIfNonReusable()V

    return-void
.end method

.method public final releaseClaimedReusableContinuation$kotlinx_coroutines_core()V
    .locals 2

    .line 353
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->delegate:Lkotlin/coroutines/Continuation;

    instance-of v1, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;

    if-eqz v1, :cond_0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;

    goto :goto_0

    :cond_0
    const/4 v0, 0x0

    :goto_0
    if-eqz v0, :cond_2

    invoke-virtual {v0, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->tryReleaseClaimedContinuation$kotlinx_coroutines_core(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;)Ljava/lang/Throwable;

    move-result-object v0

    if-nez v0, :cond_1

    goto :goto_1

    .line 354
    :cond_1
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->detachChild$kotlinx_coroutines_core()V

    .line 355
    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->cancel(Ljava/lang/Throwable;)Z

    :cond_2
    :goto_1
    return-void
.end method

.method public final resetStateReusable()Z
    .locals 2

    .line 147
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->get_state$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    .line 148
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    .line 150
    instance-of v1, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedContinuation;

    if-eqz v1, :cond_0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedContinuation;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedContinuation;->idempotentResume:Ljava/lang/Object;

    if-eqz v0, :cond_0

    .line 152
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->detachChild$kotlinx_coroutines_core()V

    const/4 v0, 0x0

    return v0

    .line 153
    :cond_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->get_decisionAndIndex$volatile$FU()Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    move-result-object v0

    const v1, 0x1fffffff

    .line 704
    invoke-virtual {v0, p0, v1}, Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;->set(Ljava/lang/Object;I)V

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->get_state$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    .line 156
    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Active;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Active;

    invoke-virtual {v0, p0, v1}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->set(Ljava/lang/Object;Ljava/lang/Object;)V

    const/4 v0, 0x1

    return v0
.end method

.method public resume(Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;)V
    .locals 1

    .line 369
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;->resumeMode:I

    invoke-virtual {p0, p1, v0, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->resumeImpl$kotlinx_coroutines_core(Ljava/lang/Object;ILcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;)V

    return-void
.end method

.method public resume(Ljava/lang/Object;Lkotlin/jvm/functions/Function1;)V
    .locals 2

    .line 363
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;->resumeMode:I

    if-eqz p2, :cond_0

    new-instance v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl$$ExternalSyntheticLambda0;

    invoke-direct {v1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl$$ExternalSyntheticLambda0;-><init>(Lkotlin/jvm/functions/Function1;)V

    goto :goto_0

    :cond_0
    const/4 v1, 0x0

    :goto_0
    invoke-virtual {p0, p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->resumeImpl$kotlinx_coroutines_core(Ljava/lang/Object;ILcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;)V

    return-void
.end method

.method public final resumeImpl$kotlinx_coroutines_core(Ljava/lang/Object;ILcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;)V
    .locals 9

    .line 493
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->get_state$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    :goto_0
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    .line 500
    instance-of v2, v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NotCompleted;

    if-eqz v2, :cond_1

    .line 501
    move-object v4, v1

    check-cast v4, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NotCompleted;

    const/4 v8, 0x0

    move-object v3, p0

    move-object v5, p1

    move v6, p2

    move-object v7, p3

    invoke-direct/range {v3 .. v8}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->resumedState(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NotCompleted;Ljava/lang/Object;ILcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    .line 502
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->get_state$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object p2

    invoke-static {p2, p0, v1, p1}, Landroidx/concurrent/futures/AbstractResolvableFuture$SafeAtomicHelper$$ExternalSyntheticBackportWithForwarding0;->m(Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result p1

    if-eqz p1, :cond_0

    .line 503
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->detachChildIfNonReusable()V

    .line 504
    invoke-direct {p0, v6}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->dispatchResume(I)V

    return-void

    :cond_0
    move-object p1, v5

    move p2, v6

    move-object p3, v7

    goto :goto_0

    :cond_1
    move-object v3, p0

    move-object v5, p1

    move-object v7, p3

    .line 508
    instance-of p1, v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancelledContinuation;

    if-eqz p1, :cond_3

    .line 514
    check-cast v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancelledContinuation;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancelledContinuation;->makeResumed()Z

    move-result p1

    if-eqz p1, :cond_3

    if-eqz v7, :cond_2

    .line 516
    iget-object p1, v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletedExceptionally;->cause:Ljava/lang/Throwable;

    invoke-virtual {p0, v7, p1, v5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->callOnCancellation(Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;Ljava/lang/Throwable;Ljava/lang/Object;)V

    :cond_2
    return-void

    .line 521
    :cond_3
    invoke-direct {p0, v5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->alreadyResumedError(Ljava/lang/Object;)Ljava/lang/Void;

    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p1
.end method

.method public resumeUndispatched(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;Ljava/lang/Object;)V
    .locals 6

    .line 595
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->delegate:Lkotlin/coroutines/Continuation;

    instance-of v1, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;

    const/4 v2, 0x0

    if-eqz v1, :cond_0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;

    goto :goto_0

    :cond_0
    move-object v0, v2

    :goto_0
    if-eqz v0, :cond_1

    .line 596
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/DispatchedContinuation;->dispatcher:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;

    :cond_1
    if-ne v2, p1, :cond_2

    const/4 p1, 0x4

    :goto_1
    move v2, p1

    goto :goto_2

    :cond_2
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;->resumeMode:I

    goto :goto_1

    :goto_2
    const/4 v4, 0x4

    const/4 v5, 0x0

    const/4 v3, 0x0

    move-object v0, p0

    move-object v1, p2

    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->resumeImpl$kotlinx_coroutines_core$default(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;Ljava/lang/Object;ILcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;ILjava/lang/Object;)V

    return-void
.end method

.method public resumeWith(Ljava/lang/Object;)V
    .locals 6

    .line 359
    invoke-static {p1, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletionStateKt;->toState(Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;)Ljava/lang/Object;

    move-result-object v1

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DispatchedTask;->resumeMode:I

    const/4 v4, 0x4

    const/4 v5, 0x0

    const/4 v3, 0x0

    move-object v0, p0

    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->resumeImpl$kotlinx_coroutines_core$default(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;Ljava/lang/Object;ILcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;ILjava/lang/Object;)V

    return-void
.end method

.method public takeState$kotlinx_coroutines_core()Ljava/lang/Object;
    .locals 1

    .line 165
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->getState$kotlinx_coroutines_core()Ljava/lang/Object;

    move-result-object v0

    return-object v0
.end method

.method public toString()Ljava/lang/String;
    .locals 2

    .line 618
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->nameString()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const/16 v1, 0x28

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->delegate:Lkotlin/coroutines/Continuation;

    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DebugStringsKt;->toDebugString(Lkotlin/coroutines/Continuation;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, "){"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->getStateDebugRepresentation()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, "}@"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DebugStringsKt;->getHexAddress(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public tryResume(Ljava/lang/Object;Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;)Ljava/lang/Object;
    .locals 0

    .line 583
    invoke-direct {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->tryResumeImpl(Ljava/lang/Object;Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p1

    return-object p1
.end method
