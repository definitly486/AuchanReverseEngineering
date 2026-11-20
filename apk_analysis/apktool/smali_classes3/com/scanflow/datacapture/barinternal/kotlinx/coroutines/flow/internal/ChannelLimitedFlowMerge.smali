.class public final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/internal/ChannelLimitedFlowMerge;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/internal/ChannelFlow;
.source "Merge.kt"


# instance fields
.field private final flows:Ljava/lang/Iterable;


# direct methods
.method public constructor <init>(Ljava/lang/Iterable;Lkotlin/coroutines/CoroutineContext;ILcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;)V
    .locals 0

    .line 81
    invoke-direct {p0, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/internal/ChannelFlow;-><init>(Lkotlin/coroutines/CoroutineContext;ILcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;)V

    .line 77
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/internal/ChannelLimitedFlowMerge;->flows:Ljava/lang/Iterable;

    return-void
.end method

.method public synthetic constructor <init>(Ljava/lang/Iterable;Lkotlin/coroutines/CoroutineContext;ILcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;ILkotlin/jvm/internal/DefaultConstructorMarker;)V
    .locals 0

    and-int/lit8 p6, p5, 0x2

    if-eqz p6, :cond_0

    .line 78
    sget-object p2, Lkotlin/coroutines/EmptyCoroutineContext;->INSTANCE:Lkotlin/coroutines/EmptyCoroutineContext;

    :cond_0
    and-int/lit8 p6, p5, 0x4

    if-eqz p6, :cond_1

    const/4 p3, -0x2

    :cond_1
    and-int/lit8 p5, p5, 0x8

    if-eqz p5, :cond_2

    .line 80
    sget-object p4, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;->SUSPEND:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;

    .line 76
    :cond_2
    invoke-direct {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/internal/ChannelLimitedFlowMerge;-><init>(Ljava/lang/Iterable;Lkotlin/coroutines/CoroutineContext;ILcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;)V

    return-void
.end method


# virtual methods
.method protected collectTo(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ProducerScope;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;
    .locals 8

    .line 90
    new-instance p2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/internal/SendingCollector;

    invoke-direct {p2, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/internal/SendingCollector;-><init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/SendChannel;)V

    .line 91
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/internal/ChannelLimitedFlowMerge;->flows:Ljava/lang/Iterable;

    .line 97
    invoke-interface {v0}, Ljava/lang/Iterable;->iterator()Ljava/util/Iterator;

    move-result-object v0

    :goto_0
    invoke-interface {v0}, Ljava/util/Iterator;->hasNext()Z

    move-result v1

    if-eqz v1, :cond_0

    invoke-interface {v0}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lkotlinx/coroutines/flow/Flow;

    .line 92
    new-instance v5, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/internal/ChannelLimitedFlowMerge$collectTo$2$1;

    const/4 v2, 0x0

    invoke-direct {v5, v1, p2, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/internal/ChannelLimitedFlowMerge$collectTo$2$1;-><init>(Lkotlinx/coroutines/flow/Flow;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/internal/SendingCollector;Lkotlin/coroutines/Continuation;)V

    const/4 v6, 0x3

    const/4 v7, 0x0

    const/4 v3, 0x0

    const/4 v4, 0x0

    move-object v2, p1

    invoke-static/range {v2 .. v7}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/BuildersKt;->launch$default(Lkotlinx/coroutines/CoroutineScope;Lkotlin/coroutines/CoroutineContext;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;Lkotlin/jvm/functions/Function2;ILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;

    goto :goto_0

    .line 94
    :cond_0
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    return-object p1
.end method

.method protected create(Lkotlin/coroutines/CoroutineContext;ILcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/internal/ChannelFlow;
    .locals 2

    .line 83
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/internal/ChannelLimitedFlowMerge;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/internal/ChannelLimitedFlowMerge;->flows:Ljava/lang/Iterable;

    invoke-direct {v0, v1, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/internal/ChannelLimitedFlowMerge;-><init>(Ljava/lang/Iterable;Lkotlin/coroutines/CoroutineContext;ILcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;)V

    return-object v0
.end method

.method public produceImpl(Lkotlinx/coroutines/CoroutineScope;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ReceiveChannel;
    .locals 3

    .line 86
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/internal/ChannelFlow;->context:Lkotlin/coroutines/CoroutineContext;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/internal/ChannelFlow;->capacity:I

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/internal/ChannelFlow;->getCollectToFun$kotlinx_coroutines_core()Lkotlin/jvm/functions/Function2;

    move-result-object v2

    invoke-static {p1, v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ProduceKt;->produce(Lkotlinx/coroutines/CoroutineScope;Lkotlin/coroutines/CoroutineContext;ILkotlin/jvm/functions/Function2;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ReceiveChannel;

    move-result-object p1

    return-object p1
.end method
