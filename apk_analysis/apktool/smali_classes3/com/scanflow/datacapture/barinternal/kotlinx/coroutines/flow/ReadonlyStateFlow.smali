.class final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/ReadonlyStateFlow;
.super Ljava/lang/Object;
.source "Share.kt"

# interfaces
.implements Lkotlinx/coroutines/flow/StateFlow;
.implements Lkotlinx/coroutines/flow/Flow;
.implements Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/internal/FusibleFlow;


# instance fields
.field private final synthetic $$delegate_0:Lkotlinx/coroutines/flow/StateFlow;

.field private final job:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;


# direct methods
.method public constructor <init>(Lkotlinx/coroutines/flow/StateFlow;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;)V
    .locals 0

    .line 381
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 385
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/ReadonlyStateFlow;->$$delegate_0:Lkotlinx/coroutines/flow/StateFlow;

    .line 383
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/ReadonlyStateFlow;->job:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;

    return-void
.end method


# virtual methods
.method public collect(Lkotlinx/coroutines/flow/FlowCollector;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/ReadonlyStateFlow;->$$delegate_0:Lkotlinx/coroutines/flow/StateFlow;

    invoke-interface {v0, p1, p2}, Lkotlinx/coroutines/flow/SharedFlow;->collect(Lkotlinx/coroutines/flow/FlowCollector;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method

.method public fuse(Lkotlin/coroutines/CoroutineContext;ILcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;)Lkotlinx/coroutines/flow/Flow;
    .locals 0

    .line 387
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/StateFlowKt;->fuseStateFlow(Lkotlinx/coroutines/flow/StateFlow;Lkotlin/coroutines/CoroutineContext;ILcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;)Lkotlinx/coroutines/flow/Flow;

    move-result-object p1

    return-object p1
.end method

.method public getReplayCache()Ljava/util/List;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/ReadonlyStateFlow;->$$delegate_0:Lkotlinx/coroutines/flow/StateFlow;

    invoke-interface {v0}, Lkotlinx/coroutines/flow/SharedFlow;->getReplayCache()Ljava/util/List;

    move-result-object v0

    return-object v0
.end method

.method public getValue()Ljava/lang/Object;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/ReadonlyStateFlow;->$$delegate_0:Lkotlinx/coroutines/flow/StateFlow;

    invoke-interface {v0}, Lkotlinx/coroutines/flow/StateFlow;->getValue()Ljava/lang/Object;

    move-result-object v0

    return-object v0
.end method
