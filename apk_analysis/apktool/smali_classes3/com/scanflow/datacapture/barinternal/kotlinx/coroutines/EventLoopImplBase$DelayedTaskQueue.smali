.class public final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedTaskQueue;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadSafeHeap;
.source "EventLoop.common.kt"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "DelayedTaskQueue"
.end annotation


# instance fields
.field public timeNow:J


# direct methods
.method public constructor <init>(J)V
    .locals 0

    .line 526
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadSafeHeap;-><init>()V

    .line 525
    iput-wide p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedTaskQueue;->timeNow:J

    return-void
.end method
