.class public abstract Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelCoroutine;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/AbstractCoroutine;
.source "ChannelCoroutine.kt"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/Channel;


# instance fields
.field private final _channel:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/Channel;


# direct methods
.method public constructor <init>(Lkotlin/coroutines/CoroutineContext;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/Channel;ZZ)V
    .locals 0

    .line 11
    invoke-direct {p0, p1, p3, p4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/AbstractCoroutine;-><init>(Lkotlin/coroutines/CoroutineContext;ZZ)V

    .line 8
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelCoroutine;->_channel:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/Channel;

    return-void
.end method


# virtual methods
.method public final cancel(Ljava/util/concurrent/CancellationException;)V
    .locals 2

    .line 29
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;->isCancelled()Z

    move-result v0

    if-eqz v0, :cond_0

    return-void

    :cond_0
    if-nez p1, :cond_1

    .line 48
    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobCancellationException;

    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;->access$cancellationExceptionMessage(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;)Ljava/lang/String;

    move-result-object v0

    const/4 v1, 0x0

    invoke-direct {p1, v0, v1, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobCancellationException;-><init>(Ljava/lang/String;Ljava/lang/Throwable;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;)V

    .line 30
    :cond_1
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelCoroutine;->cancelInternal(Ljava/lang/Throwable;)V

    return-void
.end method

.method public cancelInternal(Ljava/lang/Throwable;)V
    .locals 2

    const/4 v0, 0x0

    const/4 v1, 0x1

    .line 34
    invoke-static {p0, p1, v0, v1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;->toCancellationException$default(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;Ljava/lang/Throwable;Ljava/lang/String;ILjava/lang/Object;)Ljava/util/concurrent/CancellationException;

    move-result-object p1

    .line 35
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelCoroutine;->_channel:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/Channel;

    invoke-interface {v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ReceiveChannel;->cancel(Ljava/util/concurrent/CancellationException;)V

    .line 36
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;->cancelCoroutine(Ljava/lang/Throwable;)Z

    return-void
.end method

.method public close(Ljava/lang/Throwable;)Z
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelCoroutine;->_channel:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/Channel;

    invoke-interface {v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/SendChannel;->close(Ljava/lang/Throwable;)Z

    move-result p1

    return p1
.end method

.method public final getChannel()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/Channel;
    .locals 0

    .line 13
    return-object p0
.end method

.method protected final get_channel()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/Channel;
    .locals 1

    .line 8
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelCoroutine;->_channel:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/Channel;

    return-object v0
.end method

.method public invokeOnClose(Lkotlin/jvm/functions/Function1;)V
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelCoroutine;->_channel:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/Channel;

    invoke-interface {v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/SendChannel;->invokeOnClose(Lkotlin/jvm/functions/Function1;)V

    return-void
.end method

.method public isClosedForSend()Z
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelCoroutine;->_channel:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/Channel;

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/SendChannel;->isClosedForSend()Z

    move-result v0

    return v0
.end method

.method public iterator()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelIterator;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelCoroutine;->_channel:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/Channel;

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ReceiveChannel;->iterator()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelIterator;

    move-result-object v0

    return-object v0
.end method

.method public receiveCatching-JP2dKIU(Lkotlin/coroutines/Continuation;)Ljava/lang/Object;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelCoroutine;->_channel:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/Channel;

    invoke-interface {v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ReceiveChannel;->receiveCatching-JP2dKIU(Lkotlin/coroutines/Continuation;)Ljava/lang/Object;

    move-result-object p1

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->getCOROUTINE_SUSPENDED()Ljava/lang/Object;

    return-object p1
.end method

.method public send(Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelCoroutine;->_channel:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/Channel;

    invoke-interface {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/SendChannel;->send(Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method

.method public tryReceive-PtdJZtk()Ljava/lang/Object;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelCoroutine;->_channel:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/Channel;

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ReceiveChannel;->tryReceive-PtdJZtk()Ljava/lang/Object;

    move-result-object v0

    return-object v0
.end method

.method public trySend-JP2dKIU(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelCoroutine;->_channel:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/Channel;

    invoke-interface {v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/SendChannel;->trySend-JP2dKIU(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method
