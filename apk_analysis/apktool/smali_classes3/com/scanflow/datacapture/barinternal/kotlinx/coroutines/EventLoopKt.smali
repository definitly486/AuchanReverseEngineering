.class public abstract Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopKt;
.super Ljava/lang/Object;
.source "EventLoop.kt"


# direct methods
.method public static final createEventLoop()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;
    .locals 2

    .line 26
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/BlockingEventLoop;

    invoke-static {}, Ljava/lang/Thread;->currentThread()Ljava/lang/Thread;

    move-result-object v1

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/BlockingEventLoop;-><init>(Ljava/lang/Thread;)V

    return-object v0
.end method
