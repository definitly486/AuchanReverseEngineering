.class final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/StateFlowSlot;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/internal/AbstractSharedFlowSlot;
.source "StateFlow.kt"


# instance fields
.field private final _state:Ljava/util/concurrent/atomic/AtomicReference;


# direct methods
.method public constructor <init>()V
    .locals 2

    .line 246
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/internal/AbstractSharedFlowSlot;-><init>()V

    .line 264
    new-instance v0, Ljava/util/concurrent/atomic/AtomicReference;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Ljava/util/concurrent/atomic/AtomicReference;-><init>(Ljava/lang/Object;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/StateFlowSlot;->_state:Ljava/util/concurrent/atomic/AtomicReference;

    return-void
.end method

.method public static final synthetic access$get_state$p(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/StateFlowSlot;)Ljava/util/concurrent/atomic/AtomicReference;
    .locals 0

    .line 246
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/StateFlowSlot;->_state:Ljava/util/concurrent/atomic/AtomicReference;

    return-object p0
.end method


# virtual methods
.method public allocateLocked(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/StateFlowImpl;)Z
    .locals 1

    .line 268
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/StateFlowSlot;->_state:Ljava/util/concurrent/atomic/AtomicReference;

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Concurrent_commonKt;->getValue(Ljava/util/concurrent/atomic/AtomicReference;)Ljava/lang/Object;

    move-result-object p1

    if-eqz p1, :cond_0

    const/4 p1, 0x0

    return p1

    .line 269
    :cond_0
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/StateFlowSlot;->_state:Ljava/util/concurrent/atomic/AtomicReference;

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/StateFlowKt;->access$getNONE$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v0

    invoke-static {p1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Concurrent_commonKt;->setValue(Ljava/util/concurrent/atomic/AtomicReference;Ljava/lang/Object;)V

    const/4 p1, 0x1

    return p1
.end method

.method public bridge synthetic allocateLocked(Ljava/lang/Object;)Z
    .locals 0

    .line 246
    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/StateFlowImpl;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/StateFlowSlot;->allocateLocked(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/StateFlowImpl;)Z

    move-result p1

    return p1
.end method

.method public final awaitPending(Lkotlin/coroutines/Continuation;)Ljava/lang/Object;
    .locals 3

    .line 438
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->intercepted(Lkotlin/coroutines/Continuation;)Lkotlin/coroutines/Continuation;

    move-result-object v1

    const/4 v2, 0x1

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;-><init>(Lkotlin/coroutines/Continuation;I)V

    .line 444
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->initCancellability()V

    .line 305
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/StateFlowSlot;->access$get_state$p(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/StateFlowSlot;)Ljava/util/concurrent/atomic/AtomicReference;

    move-result-object v1

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/StateFlowKt;->access$getNONE$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v2

    invoke-static {v1, v2, v0}, Landroidx/camera/view/PreviewView$1$$ExternalSyntheticBackportWithForwarding0;->m(Ljava/util/concurrent/atomic/AtomicReference;Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_0

    .line 308
    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/Result$Companion;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->constructor-impl(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    invoke-interface {v0, v1}, Lkotlin/coroutines/Continuation;->resumeWith(Ljava/lang/Object;)V

    .line 446
    :cond_0
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->getResult()Ljava/lang/Object;

    move-result-object v0

    .line 437
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->getCOROUTINE_SUSPENDED()Ljava/lang/Object;

    move-result-object v1

    if-ne v0, v1, :cond_1

    invoke-static {p1}, Lkotlin/coroutines/jvm/internal/DebugProbesKt;->probeCoroutineSuspended(Lkotlin/coroutines/Continuation;)V

    :cond_1
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->getCOROUTINE_SUSPENDED()Ljava/lang/Object;

    move-result-object p1

    if-ne v0, p1, :cond_2

    return-object v0

    .line 447
    :cond_2
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    return-object p1
.end method

.method public freeLocked(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/StateFlowImpl;)[Lkotlin/coroutines/Continuation;
    .locals 1

    .line 274
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/StateFlowSlot;->_state:Ljava/util/concurrent/atomic/AtomicReference;

    const/4 v0, 0x0

    invoke-static {p1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Concurrent_commonKt;->setValue(Ljava/util/concurrent/atomic/AtomicReference;Ljava/lang/Object;)V

    .line 275
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/internal/AbstractSharedFlowKt;->EMPTY_RESUMES:[Lkotlin/coroutines/Continuation;

    return-object p1
.end method

.method public bridge synthetic freeLocked(Ljava/lang/Object;)[Lkotlin/coroutines/Continuation;
    .locals 0

    .line 246
    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/StateFlowImpl;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/StateFlowSlot;->freeLocked(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/StateFlowImpl;)[Lkotlin/coroutines/Continuation;

    move-result-object p1

    return-object p1
.end method

.method public final makePending()V
    .locals 4

    .line 280
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/StateFlowSlot;->_state:Ljava/util/concurrent/atomic/AtomicReference;

    .line 435
    :cond_0
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Concurrent_commonKt;->getValue(Ljava/util/concurrent/atomic/AtomicReference;)Ljava/lang/Object;

    move-result-object v1

    if-nez v1, :cond_1

    goto :goto_0

    .line 283
    :cond_1
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/StateFlowKt;->access$getPENDING$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v2

    if-ne v1, v2, :cond_2

    goto :goto_0

    .line 284
    :cond_2
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/StateFlowKt;->access$getNONE$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v2

    if-ne v1, v2, :cond_3

    .line 285
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/StateFlowSlot;->_state:Ljava/util/concurrent/atomic/AtomicReference;

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/StateFlowKt;->access$getPENDING$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v3

    invoke-static {v2, v1, v3}, Landroidx/camera/view/PreviewView$1$$ExternalSyntheticBackportWithForwarding0;->m(Ljava/util/concurrent/atomic/AtomicReference;Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_0

    :goto_0
    return-void

    .line 289
    :cond_3
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/StateFlowSlot;->_state:Ljava/util/concurrent/atomic/AtomicReference;

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/StateFlowKt;->access$getNONE$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v3

    invoke-static {v2, v1, v3}, Landroidx/camera/view/PreviewView$1$$ExternalSyntheticBackportWithForwarding0;->m(Ljava/util/concurrent/atomic/AtomicReference;Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_0

    .line 290
    check-cast v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/Result$Companion;

    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->constructor-impl(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    invoke-interface {v1, v0}, Lkotlin/coroutines/Continuation;->resumeWith(Ljava/lang/Object;)V

    return-void
.end method

.method public final takePending()Z
    .locals 2

    .line 298
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/StateFlowSlot;->_state:Ljava/util/concurrent/atomic/AtomicReference;

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/StateFlowKt;->access$getNONE$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/util/concurrent/atomic/AtomicReference;->getAndSet(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    .line 300
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/StateFlowKt;->access$getPENDING$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v1

    if-ne v0, v1, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method
