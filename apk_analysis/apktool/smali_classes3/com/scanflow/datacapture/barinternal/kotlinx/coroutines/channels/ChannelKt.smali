.class public abstract Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelKt;
.super Ljava/lang/Object;
.source "Channel.kt"


# direct methods
.method public static final Channel(ILcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;Lkotlin/jvm/functions/Function1;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/Channel;
    .locals 2

    const/4 v0, -0x2

    const/4 v1, 0x1

    if-eq p0, v0, :cond_6

    const/4 v0, -0x1

    if-eq p0, v0, :cond_4

    if-eqz p0, :cond_2

    const v0, 0x7fffffff

    if-eq p0, v0, :cond_1

    .line 1449
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;->SUSPEND:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;

    if-ne p1, v0, :cond_0

    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;

    invoke-direct {p1, p0, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;-><init>(ILkotlin/jvm/functions/Function1;)V

    return-object p1

    .line 1450
    :cond_0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ConflatedBufferedChannel;

    invoke-direct {v0, p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ConflatedBufferedChannel;-><init>(ILcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;Lkotlin/jvm/functions/Function1;)V

    return-object v0

    .line 1443
    :cond_1
    new-instance p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;

    invoke-direct {p0, v0, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;-><init>(ILkotlin/jvm/functions/Function1;)V

    return-object p0

    .line 1432
    :cond_2
    sget-object p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;->SUSPEND:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;

    if-ne p1, p0, :cond_3

    .line 1433
    new-instance p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;

    const/4 p1, 0x0

    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;-><init>(ILkotlin/jvm/functions/Function1;)V

    return-object p0

    .line 1435
    :cond_3
    new-instance p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ConflatedBufferedChannel;

    invoke-direct {p0, v1, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ConflatedBufferedChannel;-><init>(ILcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;Lkotlin/jvm/functions/Function1;)V

    return-object p0

    .line 1438
    :cond_4
    sget-object p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;->SUSPEND:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;

    if-ne p1, p0, :cond_5

    .line 1441
    new-instance p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ConflatedBufferedChannel;

    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;->DROP_OLDEST:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;

    invoke-direct {p0, v1, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ConflatedBufferedChannel;-><init>(ILcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;Lkotlin/jvm/functions/Function1;)V

    return-object p0

    .line 1438
    :cond_5
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "CONFLATED capacity cannot be used with non-default onBufferOverflow"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0

    .line 1445
    :cond_6
    sget-object p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;->SUSPEND:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;

    if-ne p1, p0, :cond_7

    new-instance p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;

    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/Channel;->Factory:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/Channel$Factory;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/Channel$Factory;->getCHANNEL_DEFAULT_CAPACITY$kotlinx_coroutines_core()I

    move-result p1

    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;-><init>(ILkotlin/jvm/functions/Function1;)V

    return-object p0

    .line 1446
    :cond_7
    new-instance p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ConflatedBufferedChannel;

    invoke-direct {p0, v1, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ConflatedBufferedChannel;-><init>(ILcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;Lkotlin/jvm/functions/Function1;)V

    return-object p0
.end method

.method public static synthetic Channel$default(ILcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;Lkotlin/jvm/functions/Function1;ILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/Channel;
    .locals 0

    and-int/lit8 p4, p3, 0x1

    if-eqz p4, :cond_0

    const/4 p0, 0x0

    :cond_0
    and-int/lit8 p4, p3, 0x2

    if-eqz p4, :cond_1

    .line 1427
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;->SUSPEND:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;

    :cond_1
    and-int/lit8 p3, p3, 0x4

    if-eqz p3, :cond_2

    const/4 p2, 0x0

    .line 1425
    :cond_2
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelKt;->Channel(ILcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;Lkotlin/jvm/functions/Function1;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/Channel;

    move-result-object p0

    return-object p0
.end method
