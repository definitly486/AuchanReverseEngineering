.class public final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/BlockingEventLoop;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;
.source "EventLoop.kt"


# instance fields
.field private final thread:Ljava/lang/Thread;


# direct methods
.method public constructor <init>(Ljava/lang/Thread;)V
    .locals 0

    .line 24
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;-><init>()V

    .line 23
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/BlockingEventLoop;->thread:Ljava/lang/Thread;

    return-void
.end method


# virtual methods
.method protected getThread()Ljava/lang/Thread;
    .locals 1

    .line 23
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/BlockingEventLoop;->thread:Ljava/lang/Thread;

    return-object v0
.end method
