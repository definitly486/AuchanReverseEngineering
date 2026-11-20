.class final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/CallbackFlowBuilder;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/ChannelFlowBuilder;
.source "Builders.kt"


# instance fields
.field private final block:Lkotlin/jvm/functions/Function2;


# direct methods
.method public constructor <init>(Lkotlin/jvm/functions/Function2;Lkotlin/coroutines/CoroutineContext;ILcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;)V
    .locals 0

    .line 327
    invoke-direct {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/ChannelFlowBuilder;-><init>(Lkotlin/jvm/functions/Function2;Lkotlin/coroutines/CoroutineContext;ILcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;)V

    .line 323
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/CallbackFlowBuilder;->block:Lkotlin/jvm/functions/Function2;

    return-void
.end method

.method public synthetic constructor <init>(Lkotlin/jvm/functions/Function2;Lkotlin/coroutines/CoroutineContext;ILcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;ILkotlin/jvm/internal/DefaultConstructorMarker;)V
    .locals 0

    and-int/lit8 p6, p5, 0x2

    if-eqz p6, :cond_0

    .line 324
    sget-object p2, Lkotlin/coroutines/EmptyCoroutineContext;->INSTANCE:Lkotlin/coroutines/EmptyCoroutineContext;

    :cond_0
    and-int/lit8 p6, p5, 0x4

    if-eqz p6, :cond_1

    const/4 p3, -0x2

    :cond_1
    and-int/lit8 p5, p5, 0x8

    if-eqz p5, :cond_2

    .line 326
    sget-object p4, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;->SUSPEND:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;

    .line 322
    :cond_2
    invoke-direct {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/CallbackFlowBuilder;-><init>(Lkotlin/jvm/functions/Function2;Lkotlin/coroutines/CoroutineContext;ILcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;)V

    return-void
.end method


# virtual methods
.method protected collectTo(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ProducerScope;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;
    .locals 4

    instance-of v0, p2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/CallbackFlowBuilder$collectTo$1;

    if-eqz v0, :cond_0

    move-object v0, p2

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/CallbackFlowBuilder$collectTo$1;

    iget v1, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/CallbackFlowBuilder$collectTo$1;->label:I

    const/high16 v2, -0x80000000

    and-int v3, v1, v2

    if-eqz v3, :cond_0

    sub-int/2addr v1, v2

    iput v1, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/CallbackFlowBuilder$collectTo$1;->label:I

    goto :goto_0

    :cond_0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/CallbackFlowBuilder$collectTo$1;

    invoke-direct {v0, p0, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/CallbackFlowBuilder$collectTo$1;-><init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/CallbackFlowBuilder;Lkotlin/coroutines/Continuation;)V

    :goto_0
    iget-object p2, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/CallbackFlowBuilder$collectTo$1;->result:Ljava/lang/Object;

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->getCOROUTINE_SUSPENDED()Ljava/lang/Object;

    move-result-object v1

    .line 329
    iget v2, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/CallbackFlowBuilder$collectTo$1;->label:I

    const/4 v3, 0x1

    if-eqz v2, :cond_2

    if-ne v2, v3, :cond_1

    iget-object p1, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/CallbackFlowBuilder$collectTo$1;->L$0:Ljava/lang/Object;

    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ProducerScope;

    invoke-static {p2}, Lcom/scanflow/datacapture/barinternal/kotlin/ResultKt;->throwOnFailure(Ljava/lang/Object;)V

    goto :goto_1

    :cond_1
    new-instance p1, Ljava/lang/IllegalStateException;

    const-string p2, "call to \'resume\' before \'invoke\' with coroutine"

    invoke-direct {p1, p2}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw p1

    :cond_2
    invoke-static {p2}, Lcom/scanflow/datacapture/barinternal/kotlin/ResultKt;->throwOnFailure(Ljava/lang/Object;)V

    .line 330
    iput-object p1, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/CallbackFlowBuilder$collectTo$1;->L$0:Ljava/lang/Object;

    iput v3, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/CallbackFlowBuilder$collectTo$1;->label:I

    invoke-super {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/ChannelFlowBuilder;->collectTo(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ProducerScope;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;

    move-result-object p2

    if-ne p2, v1, :cond_3

    return-object v1

    .line 336
    :cond_3
    :goto_1
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/SendChannel;->isClosedForSend()Z

    move-result p1

    if-eqz p1, :cond_4

    .line 345
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    return-object p1

    .line 337
    :cond_4
    new-instance p1, Ljava/lang/IllegalStateException;

    .line 342
    const-string p2, "\'awaitClose { yourCallbackOrListener.cancel() }\' should be used in the end of callbackFlow block.\nOtherwise, a callback/listener may leak in case of external cancellation.\nSee callbackFlow API documentation for the details."

    .line 337
    invoke-direct {p1, p2}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method protected create(Lkotlin/coroutines/CoroutineContext;ILcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/internal/ChannelFlow;
    .locals 2

    .line 348
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/CallbackFlowBuilder;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/CallbackFlowBuilder;->block:Lkotlin/jvm/functions/Function2;

    invoke-direct {v0, v1, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/CallbackFlowBuilder;-><init>(Lkotlin/jvm/functions/Function2;Lkotlin/coroutines/CoroutineContext;ILcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;)V

    return-object v0
.end method
