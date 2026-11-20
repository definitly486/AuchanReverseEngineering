.class public abstract Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplPlatform;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;
.source "EventLoop.kt"


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 7
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;-><init>()V

    return-void
.end method


# virtual methods
.method protected abstract getThread()Ljava/lang/Thread;
.end method

.method protected reschedule(JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedTask;)V
    .locals 1

    .line 18
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DefaultExecutor;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DefaultExecutor;

    invoke-virtual {v0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;->schedule(JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedTask;)V

    return-void
.end method

.method protected final unpark()V
    .locals 2

    .line 12
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplPlatform;->getThread()Ljava/lang/Thread;

    move-result-object v0

    .line 13
    invoke-static {}, Ljava/lang/Thread;->currentThread()Ljava/lang/Thread;

    move-result-object v1

    if-eq v1, v0, :cond_0

    .line 14
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/AbstractTimeSourceKt;->access$getTimeSource$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/AbstractTimeSource;

    invoke-static {v0}, Ljava/util/concurrent/locks/LockSupport;->unpark(Ljava/lang/Thread;)V

    :cond_0
    return-void
.end method
