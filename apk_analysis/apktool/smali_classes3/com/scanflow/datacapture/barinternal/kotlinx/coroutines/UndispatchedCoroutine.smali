.class public final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/UndispatchedCoroutine;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ScopeCoroutine;
.source "CoroutineContext.kt"


# instance fields
.field private volatile threadLocalIsSet:Z

.field private final threadStateToRecover:Ljava/lang/ThreadLocal;


# direct methods
.method public constructor <init>(Lkotlin/coroutines/CoroutineContext;Lkotlin/coroutines/Continuation;)V
    .locals 2

    .line 164
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/UndispatchedMarker;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/UndispatchedMarker;

    invoke-interface {p1, v0}, Lkotlin/coroutines/CoroutineContext;->get(Lkotlin/coroutines/CoroutineContext$Key;)Lkotlin/coroutines/CoroutineContext$Element;

    move-result-object v1

    if-nez v1, :cond_0

    invoke-interface {p1, v0}, Lkotlin/coroutines/CoroutineContext;->plus(Lkotlin/coroutines/CoroutineContext;)Lkotlin/coroutines/CoroutineContext;

    move-result-object v0

    goto :goto_0

    :cond_0
    move-object v0, p1

    :goto_0
    invoke-direct {p0, v0, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ScopeCoroutine;-><init>(Lkotlin/coroutines/CoroutineContext;Lkotlin/coroutines/Continuation;)V

    .line 198
    new-instance v0, Ljava/lang/ThreadLocal;

    invoke-direct {v0}, Ljava/lang/ThreadLocal;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/UndispatchedCoroutine;->threadStateToRecover:Ljava/lang/ThreadLocal;

    .line 233
    invoke-interface {p2}, Lkotlin/coroutines/Continuation;->getContext()Lkotlin/coroutines/CoroutineContext;

    move-result-object p2

    sget-object v0, Lkotlin/coroutines/ContinuationInterceptor;->Key:Lkotlin/coroutines/ContinuationInterceptor$Key;

    invoke-interface {p2, v0}, Lkotlin/coroutines/CoroutineContext;->get(Lkotlin/coroutines/CoroutineContext$Key;)Lkotlin/coroutines/CoroutineContext$Element;

    move-result-object p2

    instance-of p2, p2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;

    if-nez p2, :cond_1

    const/4 p2, 0x0

    .line 240
    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadContextKt;->updateThreadContext(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p2

    .line 241
    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadContextKt;->restoreThreadContext(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Object;)V

    .line 242
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/UndispatchedCoroutine;->saveThreadContext(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Object;)V

    :cond_1
    return-void
.end method

.method private final clearThreadLocal()V
    .locals 2

    .line 271
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/UndispatchedCoroutine;->threadLocalIsSet:Z

    if-eqz v0, :cond_1

    .line 272
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/UndispatchedCoroutine;->threadStateToRecover:Ljava/lang/ThreadLocal;

    invoke-virtual {v0}, Ljava/lang/ThreadLocal;->get()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    if-eqz v0, :cond_0

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;->component1()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lkotlin/coroutines/CoroutineContext;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;->component2()Ljava/lang/Object;

    move-result-object v0

    .line 273
    invoke-static {v1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadContextKt;->restoreThreadContext(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Object;)V

    .line 275
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/UndispatchedCoroutine;->threadStateToRecover:Ljava/lang/ThreadLocal;

    invoke-virtual {v0}, Ljava/lang/ThreadLocal;->remove()V

    :cond_1
    return-void
.end method


# virtual methods
.method public afterCompletionUndispatched()V
    .locals 0

    .line 258
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/UndispatchedCoroutine;->clearThreadLocal()V

    return-void
.end method

.method protected afterResume(Ljava/lang/Object;)V
    .locals 5

    .line 262
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/UndispatchedCoroutine;->clearThreadLocal()V

    .line 264
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ScopeCoroutine;->uCont:Lkotlin/coroutines/Continuation;

    invoke-static {p1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CompletionStateKt;->recoverResult(Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;

    move-result-object p1

    .line 265
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ScopeCoroutine;->uCont:Lkotlin/coroutines/Continuation;

    .line 320
    invoke-interface {v0}, Lkotlin/coroutines/Continuation;->getContext()Lkotlin/coroutines/CoroutineContext;

    move-result-object v1

    const/4 v2, 0x0

    .line 321
    invoke-static {v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadContextKt;->updateThreadContext(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v3

    .line 322
    sget-object v4, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadContextKt;->NO_THREAD_ELEMENTS:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    if-eq v3, v4, :cond_0

    .line 324
    invoke-static {v0, v1, v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineContextKt;->updateUndispatchedCompletion(Lkotlin/coroutines/Continuation;Lkotlin/coroutines/CoroutineContext;Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/UndispatchedCoroutine;

    move-result-object v2

    .line 266
    :cond_0
    :try_start_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ScopeCoroutine;->uCont:Lkotlin/coroutines/Continuation;

    invoke-interface {v0, p1}, Lkotlin/coroutines/Continuation;->resumeWith(Ljava/lang/Object;)V

    .line 267
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    if-eqz v2, :cond_2

    .line 331
    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/UndispatchedCoroutine;->clearThreadContext()Z

    move-result p1

    if-eqz p1, :cond_1

    goto :goto_0

    :cond_1
    return-void

    .line 332
    :cond_2
    :goto_0
    invoke-static {v1, v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadContextKt;->restoreThreadContext(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Object;)V

    return-void

    :catchall_0
    move-exception p1

    if-eqz v2, :cond_3

    .line 331
    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/UndispatchedCoroutine;->clearThreadContext()Z

    move-result v0

    if-eqz v0, :cond_4

    .line 332
    :cond_3
    invoke-static {v1, v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadContextKt;->restoreThreadContext(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Object;)V

    :cond_4
    throw p1
.end method

.method public final clearThreadContext()Z
    .locals 3

    .line 252
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/UndispatchedCoroutine;->threadLocalIsSet:Z

    const/4 v1, 0x1

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/UndispatchedCoroutine;->threadStateToRecover:Ljava/lang/ThreadLocal;

    invoke-virtual {v0}, Ljava/lang/ThreadLocal;->get()Ljava/lang/Object;

    move-result-object v0

    if-nez v0, :cond_0

    move v0, v1

    goto :goto_0

    :cond_0
    const/4 v0, 0x0

    .line 253
    :goto_0
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/UndispatchedCoroutine;->threadStateToRecover:Ljava/lang/ThreadLocal;

    invoke-virtual {v2}, Ljava/lang/ThreadLocal;->remove()V

    xor-int/2addr v0, v1

    return v0
.end method

.method public final saveThreadContext(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Object;)V
    .locals 1

    const/4 v0, 0x1

    .line 247
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/UndispatchedCoroutine;->threadLocalIsSet:Z

    .line 248
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/UndispatchedCoroutine;->threadStateToRecover:Ljava/lang/ThreadLocal;

    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlin/TuplesKt;->to(Ljava/lang/Object;Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    move-result-object p1

    invoke-virtual {v0, p1}, Ljava/lang/ThreadLocal;->set(Ljava/lang/Object;)V

    return-void
.end method
