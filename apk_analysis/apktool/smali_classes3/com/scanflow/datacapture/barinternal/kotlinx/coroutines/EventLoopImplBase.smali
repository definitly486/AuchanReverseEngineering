.class public abstract Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplPlatform;
.source "EventLoop.common.kt"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Delay;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedResumeTask;,
        Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedRunnableTask;,
        Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedTask;,
        Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedTaskQueue;
    }
.end annotation


# static fields
.field private static final synthetic _delayed$volatile$FU:Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

.field private static final synthetic _isCompleted$volatile$FU:Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

.field private static final synthetic _queue$volatile$FU:Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;


# instance fields
.field private volatile synthetic _delayed$volatile:Ljava/lang/Object;

.field private volatile synthetic _isCompleted$volatile:I

.field private volatile synthetic _queue$volatile:Ljava/lang/Object;


# direct methods
.method static constructor <clinit>()V
    .locals 3

    .line 0
    const-string v0, "_queue$volatile"

    const-class v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;

    const-class v2, Ljava/lang/Object;

    invoke-static {v1, v2, v0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->newUpdater(Ljava/lang/Class;Ljava/lang/Class;Ljava/lang/String;)Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->_queue$volatile$FU:Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    const-string v0, "_delayed$volatile"

    invoke-static {v1, v2, v0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->newUpdater(Ljava/lang/Class;Ljava/lang/Class;Ljava/lang/String;)Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->_delayed$volatile$FU:Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    const-string v0, "_isCompleted$volatile"

    invoke-static {v1, v0}, Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;->newUpdater(Ljava/lang/Class;Ljava/lang/String;)Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->_isCompleted$volatile$FU:Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    return-void
.end method

.method public constructor <init>()V
    .locals 0

    .line 177
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplPlatform;-><init>()V

    return-void
.end method

.method public static final synthetic access$isCompleted(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;)Z
    .locals 0

    .line 177
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->isCompleted()Z

    move-result p0

    return p0
.end method

.method private final closeQueue()V
    .locals 5

    .line 346
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->get_queue$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    :cond_0
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    if-nez v1, :cond_1

    .line 350
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->get_queue$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v1

    const/4 v2, 0x0

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop_commonKt;->access$getCLOSED_EMPTY$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v3

    invoke-static {v1, p0, v2, v3}, Landroidx/concurrent/futures/AbstractResolvableFuture$SafeAtomicHelper$$ExternalSyntheticBackportWithForwarding0;->m(Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_0

    goto :goto_0

    .line 351
    :cond_1
    instance-of v2, v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LockFreeTaskQueueCore;

    if-eqz v2, :cond_2

    .line 352
    check-cast v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LockFreeTaskQueueCore;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LockFreeTaskQueueCore;->close()Z

    return-void

    .line 356
    :cond_2
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop_commonKt;->access$getCLOSED_EMPTY$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v2

    if-ne v1, v2, :cond_3

    goto :goto_0

    .line 359
    :cond_3
    new-instance v2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LockFreeTaskQueueCore;

    const/16 v3, 0x8

    const/4 v4, 0x1

    invoke-direct {v2, v3, v4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LockFreeTaskQueueCore;-><init>(IZ)V

    .line 360
    const-string v3, "null cannot be cast to non-null type java.lang.Runnable"

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    move-object v3, v1

    check-cast v3, Ljava/lang/Runnable;

    invoke-virtual {v2, v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LockFreeTaskQueueCore;->addLast(Ljava/lang/Object;)I

    .line 361
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->get_queue$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v3

    invoke-static {v3, p0, v1, v2}, Landroidx/concurrent/futures/AbstractResolvableFuture$SafeAtomicHelper$$ExternalSyntheticBackportWithForwarding0;->m(Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_0

    :goto_0
    return-void
.end method

.method private final dequeue()Ljava/lang/Runnable;
    .locals 5

    .line 309
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->get_queue$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    :cond_0
    :goto_0
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    const/4 v2, 0x0

    if-nez v1, :cond_1

    return-object v2

    .line 314
    :cond_1
    instance-of v3, v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LockFreeTaskQueueCore;

    if-eqz v3, :cond_3

    .line 315
    const-string v2, "null cannot be cast to non-null type kotlinx.coroutines.internal.LockFreeTaskQueueCore<java.lang.Runnable>"

    invoke-static {v1, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    move-object v2, v1

    check-cast v2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LockFreeTaskQueueCore;

    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LockFreeTaskQueueCore;->removeFirstOrNull()Ljava/lang/Object;

    move-result-object v3

    .line 316
    sget-object v4, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LockFreeTaskQueueCore;->REMOVE_FROZEN:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    if-eq v3, v4, :cond_2

    check-cast v3, Ljava/lang/Runnable;

    return-object v3

    :cond_2
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->get_queue$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v3

    .line 317
    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LockFreeTaskQueueCore;->next()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LockFreeTaskQueueCore;

    move-result-object v2

    invoke-static {v3, p0, v1, v2}, Landroidx/concurrent/futures/AbstractResolvableFuture$SafeAtomicHelper$$ExternalSyntheticBackportWithForwarding0;->m(Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Z

    goto :goto_0

    .line 320
    :cond_3
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop_commonKt;->access$getCLOSED_EMPTY$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v3

    if-ne v1, v3, :cond_4

    return-object v2

    .line 321
    :cond_4
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->get_queue$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v3

    invoke-static {v3, p0, v1, v2}, Landroidx/concurrent/futures/AbstractResolvableFuture$SafeAtomicHelper$$ExternalSyntheticBackportWithForwarding0;->m(Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_0

    const-string v0, "null cannot be cast to non-null type java.lang.Runnable"

    invoke-static {v1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast v1, Ljava/lang/Runnable;

    return-object v1
.end method

.method private final enqueueDelayedTasks()V
    .locals 7

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->get_delayed$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    .line 329
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedTaskQueue;

    if-eqz v0, :cond_4

    .line 330
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadSafeHeap;->isEmpty()Z

    move-result v1

    if-nez v1, :cond_4

    .line 331
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/AbstractTimeSourceKt;->access$getTimeSource$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/AbstractTimeSource;

    invoke-static {}, Ljava/lang/System;->nanoTime()J

    move-result-wide v1

    .line 551
    :cond_0
    monitor-enter v0

    .line 552
    :try_start_0
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadSafeHeap;->firstImpl()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadSafeHeapNode;

    move-result-object v3
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    const/4 v4, 0x0

    if-nez v3, :cond_1

    monitor-exit v0

    goto :goto_1

    .line 553
    :cond_1
    :try_start_1
    check-cast v3, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedTask;

    .line 337
    invoke-virtual {v3, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedTask;->timeToExecute(J)Z

    move-result v5

    const/4 v6, 0x0

    if-eqz v5, :cond_2

    .line 338
    invoke-direct {p0, v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->enqueueImpl(Ljava/lang/Runnable;)Z

    move-result v3

    goto :goto_0

    :catchall_0
    move-exception v1

    goto :goto_2

    :cond_2
    move v3, v6

    :goto_0
    if-eqz v3, :cond_3

    .line 554
    invoke-virtual {v0, v6}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadSafeHeap;->removeAtImpl(I)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadSafeHeapNode;

    move-result-object v4
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    .line 551
    :cond_3
    monitor-exit v0

    .line 336
    :goto_1
    check-cast v4, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedTask;

    if-nez v4, :cond_0

    goto :goto_3

    .line 551
    :goto_2
    monitor-exit v0

    throw v1

    :cond_4
    :goto_3
    return-void
.end method

.method private final enqueueImpl(Ljava/lang/Runnable;)Z
    .locals 6

    .line 282
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->get_queue$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    :cond_0
    :goto_0
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    .line 285
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->isCompleted()Z

    move-result v2

    const/4 v3, 0x0

    if-eqz v2, :cond_1

    return v3

    :cond_1
    const/4 v2, 0x1

    if-nez v1, :cond_2

    .line 287
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->get_queue$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v1

    const/4 v3, 0x0

    invoke-static {v1, p0, v3, p1}, Landroidx/concurrent/futures/AbstractResolvableFuture$SafeAtomicHelper$$ExternalSyntheticBackportWithForwarding0;->m(Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_0

    return v2

    .line 288
    :cond_2
    instance-of v4, v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LockFreeTaskQueueCore;

    if-eqz v4, :cond_6

    .line 289
    const-string v4, "null cannot be cast to non-null type kotlinx.coroutines.internal.LockFreeTaskQueueCore<java.lang.Runnable>"

    invoke-static {v1, v4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    move-object v4, v1

    check-cast v4, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LockFreeTaskQueueCore;

    invoke-virtual {v4, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LockFreeTaskQueueCore;->addLast(Ljava/lang/Object;)I

    move-result v5

    if-eqz v5, :cond_5

    if-eq v5, v2, :cond_4

    const/4 v1, 0x2

    if-eq v5, v1, :cond_3

    goto :goto_0

    :cond_3
    return v3

    .line 291
    :cond_4
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->get_queue$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v2

    .line 292
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LockFreeTaskQueueCore;->next()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LockFreeTaskQueueCore;

    move-result-object v3

    invoke-static {v2, p0, v1, v3}, Landroidx/concurrent/futures/AbstractResolvableFuture$SafeAtomicHelper$$ExternalSyntheticBackportWithForwarding0;->m(Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Z

    goto :goto_0

    :cond_5
    return v2

    .line 296
    :cond_6
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop_commonKt;->access$getCLOSED_EMPTY$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v4

    if-ne v1, v4, :cond_7

    return v3

    .line 299
    :cond_7
    new-instance v3, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LockFreeTaskQueueCore;

    const/16 v4, 0x8

    invoke-direct {v3, v4, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LockFreeTaskQueueCore;-><init>(IZ)V

    .line 300
    const-string v4, "null cannot be cast to non-null type java.lang.Runnable"

    invoke-static {v1, v4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    move-object v4, v1

    check-cast v4, Ljava/lang/Runnable;

    invoke-virtual {v3, v4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LockFreeTaskQueueCore;->addLast(Ljava/lang/Object;)I

    .line 301
    invoke-virtual {v3, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LockFreeTaskQueueCore;->addLast(Ljava/lang/Object;)I

    .line 302
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->get_queue$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v4

    invoke-static {v4, p0, v1, v3}, Landroidx/concurrent/futures/AbstractResolvableFuture$SafeAtomicHelper$$ExternalSyntheticBackportWithForwarding0;->m(Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_0

    return v2
.end method

.method private static final synthetic get_delayed$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;
    .locals 1

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->_delayed$volatile$FU:Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    return-object v0
.end method

.method private static final synthetic get_isCompleted$volatile$FU()Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;
    .locals 1

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->_isCompleted$volatile$FU:Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    return-object v0
.end method

.method private static final synthetic get_queue$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;
    .locals 1

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->_queue$volatile$FU:Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    return-object v0
.end method

.method private final isCompleted()Z
    .locals 2

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->get_isCompleted$volatile$FU()Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    move-result-object v0

    .line 186
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;->get(Ljava/lang/Object;)I

    move-result v0

    const/4 v1, 0x1

    if-ne v0, v1, :cond_0

    return v1

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method private final rescheduleAllDelayed()V
    .locals 3

    .line 397
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/AbstractTimeSourceKt;->access$getTimeSource$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/AbstractTimeSource;

    invoke-static {}, Ljava/lang/System;->nanoTime()J

    move-result-wide v0

    .line 406
    :goto_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->get_delayed$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v2

    invoke-virtual {v2, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedTaskQueue;

    if-eqz v2, :cond_1

    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadSafeHeap;->removeFirstOrNull()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadSafeHeapNode;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedTask;

    if-nez v2, :cond_0

    goto :goto_1

    .line 407
    :cond_0
    invoke-virtual {p0, v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplPlatform;->reschedule(JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedTask;)V

    goto :goto_0

    :cond_1
    :goto_1
    return-void
.end method

.method private final scheduleImpl(JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedTask;)I
    .locals 3

    .line 381
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->isCompleted()Z

    move-result v0

    if-eqz v0, :cond_0

    const/4 p1, 0x1

    return p1

    .line 382
    :cond_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->get_delayed$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedTaskQueue;

    if-nez v0, :cond_1

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->get_delayed$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    .line 383
    new-instance v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedTaskQueue;

    invoke-direct {v1, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedTaskQueue;-><init>(J)V

    const/4 v2, 0x0

    invoke-static {v0, p0, v2, v1}, Landroidx/concurrent/futures/AbstractResolvableFuture$SafeAtomicHelper$$ExternalSyntheticBackportWithForwarding0;->m(Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Z

    .line 384
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->get_delayed$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedTaskQueue;

    .line 386
    :cond_1
    invoke-virtual {p3, p1, p2, v0, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedTask;->scheduleTask(JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedTaskQueue;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;)I

    move-result p1

    return p1
.end method

.method private final setCompleted(Z)V
    .locals 1

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->get_isCompleted$volatile$FU()Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    move-result-object v0

    .line 187
    invoke-virtual {v0, p0, p1}, Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;->set(Ljava/lang/Object;I)V

    return-void
.end method

.method private final shouldUnpark(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedTask;)Z
    .locals 1

    .line 378
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->get_delayed$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedTaskQueue;

    if-eqz v0, :cond_0

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadSafeHeap;->peek()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadSafeHeapNode;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedTask;

    goto :goto_0

    :cond_0
    const/4 v0, 0x0

    :goto_0
    if-ne v0, p1, :cond_1

    const/4 p1, 0x1

    return p1

    :cond_1
    const/4 p1, 0x0

    return p1
.end method


# virtual methods
.method public final dispatch(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Runnable;)V
    .locals 0

    .line 269
    invoke-virtual {p0, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->enqueue(Ljava/lang/Runnable;)V

    return-void
.end method

.method public enqueue(Ljava/lang/Runnable;)V
    .locals 1

    .line 273
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->enqueueDelayedTasks()V

    .line 274
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->enqueueImpl(Ljava/lang/Runnable;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 276
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplPlatform;->unpark()V

    return-void

    .line 278
    :cond_0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DefaultExecutor;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DefaultExecutor;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DefaultExecutor;->enqueue(Ljava/lang/Runnable;)V

    return-void
.end method

.method protected getNextTime()J
    .locals 6

    .line 202
    invoke-super {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;->getNextTime()J

    move-result-wide v0

    const-wide/16 v2, 0x0

    cmp-long v0, v0, v2

    if-nez v0, :cond_0

    return-wide v2

    :cond_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->get_queue$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    .line 203
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    const-wide v4, 0x7fffffffffffffffL

    if-eqz v0, :cond_3

    .line 206
    instance-of v1, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LockFreeTaskQueueCore;

    if-eqz v1, :cond_1

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LockFreeTaskQueueCore;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LockFreeTaskQueueCore;->isEmpty()Z

    move-result v0

    if-nez v0, :cond_3

    return-wide v2

    .line 207
    :cond_1
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop_commonKt;->access$getCLOSED_EMPTY$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v1

    if-ne v0, v1, :cond_2

    return-wide v4

    :cond_2
    return-wide v2

    .line 210
    :cond_3
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->get_delayed$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedTaskQueue;

    if-eqz v0, :cond_5

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadSafeHeap;->peek()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadSafeHeapNode;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedTask;

    if-nez v0, :cond_4

    goto :goto_0

    .line 211
    :cond_4
    iget-wide v0, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedTask;->nanoTime:J

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/AbstractTimeSourceKt;->access$getTimeSource$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/AbstractTimeSource;

    invoke-static {}, Ljava/lang/System;->nanoTime()J

    move-result-wide v4

    sub-long/2addr v0, v4

    invoke-static {v0, v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/RangesKt;->coerceAtLeast(JJ)J

    move-result-wide v0

    return-wide v0

    :cond_5
    :goto_0
    return-wide v4
.end method

.method public invokeOnTimeout(JLjava/lang/Runnable;Lkotlin/coroutines/CoroutineContext;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;
    .locals 0

    .line 177
    invoke-static {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Delay$DefaultImpls;->invokeOnTimeout(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Delay;JLjava/lang/Runnable;Lkotlin/coroutines/CoroutineContext;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;

    move-result-object p1

    return-object p1
.end method

.method protected isEmpty()Z
    .locals 4

    .line 190
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;->isUnconfinedQueueEmpty()Z

    move-result v0

    const/4 v1, 0x0

    if-nez v0, :cond_0

    return v1

    :cond_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->get_delayed$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    .line 191
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedTaskQueue;

    if-eqz v0, :cond_1

    .line 192
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadSafeHeap;->isEmpty()Z

    move-result v0

    if-nez v0, :cond_1

    return v1

    :cond_1
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->get_queue$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    .line 193
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    const/4 v2, 0x1

    if-nez v0, :cond_2

    return v2

    .line 195
    :cond_2
    instance-of v3, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LockFreeTaskQueueCore;

    if-eqz v3, :cond_3

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LockFreeTaskQueueCore;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LockFreeTaskQueueCore;->isEmpty()Z

    move-result v0

    return v0

    .line 196
    :cond_3
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop_commonKt;->access$getCLOSED_EMPTY$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v3

    if-ne v0, v3, :cond_4

    return v2

    :cond_4
    return v1
.end method

.method public processNextEvent()J
    .locals 3

    .line 257
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;->processUnconfinedEvent()Z

    move-result v0

    const-wide/16 v1, 0x0

    if-eqz v0, :cond_0

    return-wide v1

    .line 259
    :cond_0
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->enqueueDelayedTasks()V

    .line 261
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->dequeue()Ljava/lang/Runnable;

    move-result-object v0

    if-eqz v0, :cond_1

    .line 263
    invoke-interface {v0}, Ljava/lang/Runnable;->run()V

    return-wide v1

    .line 266
    :cond_1
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->getNextTime()J

    move-result-wide v0

    return-wide v0
.end method

.method protected final resetAll()V
    .locals 2

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->get_queue$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    const/4 v1, 0x0

    .line 391
    invoke-virtual {v0, p0, v1}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->set(Ljava/lang/Object;Ljava/lang/Object;)V

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->get_delayed$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    .line 392
    invoke-virtual {v0, p0, v1}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->set(Ljava/lang/Object;Ljava/lang/Object;)V

    return-void
.end method

.method public final schedule(JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedTask;)V
    .locals 2

    .line 374
    invoke-direct {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->scheduleImpl(JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedTask;)I

    move-result v0

    if-eqz v0, :cond_2

    const/4 v1, 0x1

    if-eq v0, v1, :cond_1

    const/4 p1, 0x2

    if-ne v0, p1, :cond_0

    goto :goto_0

    .line 372
    :cond_0
    new-instance p1, Ljava/lang/IllegalStateException;

    .line 374
    const-string p2, "unexpected result"

    invoke-direct {p1, p2}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw p1

    .line 372
    :cond_1
    invoke-virtual {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplPlatform;->reschedule(JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedTask;)V

    return-void

    .line 371
    :cond_2
    invoke-direct {p0, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->shouldUnpark(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedTask;)Z

    move-result p1

    if-eqz p1, :cond_3

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplPlatform;->unpark()V

    :cond_3
    :goto_0
    return-void
.end method

.method protected final scheduleInvokeOnTimeout(JLjava/lang/Runnable;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;
    .locals 3

    .line 244
    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop_commonKt;->delayToNanos(J)J

    move-result-wide p1

    const-wide v0, 0x3fffffffffffffffL    # 1.9999999999999998

    cmp-long v0, p1, v0

    if-gez v0, :cond_0

    .line 246
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/AbstractTimeSourceKt;->access$getTimeSource$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/AbstractTimeSource;

    invoke-static {}, Ljava/lang/System;->nanoTime()J

    move-result-wide v0

    .line 247
    new-instance v2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedRunnableTask;

    add-long/2addr p1, v0

    invoke-direct {v2, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedRunnableTask;-><init>(JLjava/lang/Runnable;)V

    .line 248
    invoke-virtual {p0, v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->schedule(JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedTask;)V

    return-object v2

    .line 251
    :cond_0
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NonDisposableHandle;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NonDisposableHandle;

    return-object p1
.end method

.method public scheduleResumeAfterDelay(JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;)V
    .locals 3

    .line 228
    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop_commonKt;->delayToNanos(J)J

    move-result-wide p1

    const-wide v0, 0x3fffffffffffffffL    # 1.9999999999999998

    cmp-long v0, p1, v0

    if-gez v0, :cond_0

    .line 230
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/AbstractTimeSourceKt;->access$getTimeSource$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/AbstractTimeSource;

    invoke-static {}, Ljava/lang/System;->nanoTime()J

    move-result-wide v0

    .line 231
    new-instance v2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedResumeTask;

    add-long/2addr p1, v0

    invoke-direct {v2, p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedResumeTask;-><init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;)V

    .line 237
    invoke-virtual {p0, v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->schedule(JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedTask;)V

    .line 238
    invoke-static {p3, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationKt;->disposeOnCancellation(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;)V

    :cond_0
    return-void
.end method

.method public shutdown()V
    .locals 4

    .line 216
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ThreadLocalEventLoop;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ThreadLocalEventLoop;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ThreadLocalEventLoop;->resetEventLoop$kotlinx_coroutines_core()V

    const/4 v0, 0x1

    .line 219
    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->setCompleted(Z)V

    .line 220
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->closeQueue()V

    .line 222
    :cond_0
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->processNextEvent()J

    move-result-wide v0

    const-wide/16 v2, 0x0

    cmp-long v0, v0, v2

    if-lez v0, :cond_0

    .line 224
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->rescheduleAllDelayed()V

    return-void
.end method
