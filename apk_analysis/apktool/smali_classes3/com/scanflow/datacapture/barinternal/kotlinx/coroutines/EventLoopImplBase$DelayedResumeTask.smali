.class final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedResumeTask;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedTask;
.source "EventLoop.common.kt"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x12
    name = "DelayedResumeTask"
.end annotation


# instance fields
.field private final cont:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;

.field final synthetic this$0:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;)V
    .locals 0

    .line 493
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedResumeTask;->this$0:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;

    .line 496
    invoke-direct {p0, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedTask;-><init>(J)V

    .line 495
    iput-object p4, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedResumeTask;->cont:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;

    return-void
.end method


# virtual methods
.method public run()V
    .locals 3

    .line 497
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedResumeTask;->cont:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedResumeTask;->this$0:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase;

    sget-object v2, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    invoke-interface {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;->resumeUndispatched(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;Ljava/lang/Object;)V

    return-void
.end method

.method public toString()Ljava/lang/String;
    .locals 2

    .line 498
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-super {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedTask;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopImplBase$DelayedResumeTask;->cont:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
