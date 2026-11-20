.class final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;
.super Ljava/lang/Object;
.source "BufferedChannel.kt"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelIterator;
.implements Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x12
    name = "BufferedChannelIterator"
.end annotation


# instance fields
.field private continuation:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

.field private receiveResult:Ljava/lang/Object;

.field final synthetic this$0:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;)V
    .locals 0

    .line 1595
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;->this$0:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 1601
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getNO_RECEIVE_RESULT$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;->receiveResult:Ljava/lang/Object;

    return-void
.end method

.method public static final synthetic access$onClosedHasNextNoWaiterSuspend(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;)V
    .locals 0

    .line 1595
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;->onClosedHasNextNoWaiterSuspend()V

    return-void
.end method

.method public static final synthetic access$setContinuation$p(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;)V
    .locals 0

    .line 1595
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;->continuation:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    return-void
.end method

.method public static final synthetic access$setReceiveResult$p(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;Ljava/lang/Object;)V
    .locals 0

    .line 1595
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;->receiveResult:Ljava/lang/Object;

    return-void
.end method

.method private final hasNextOnNoWaiterSuspend(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;IJLkotlin/coroutines/Continuation;)Ljava/lang/Object;
    .locals 9

    .line 1655
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;->this$0:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;

    .line 3170
    invoke-static {p5}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->intercepted(Lkotlin/coroutines/Continuation;)Lkotlin/coroutines/Continuation;

    move-result-object v1

    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationKt;->getOrCreateCancellableContinuation(Lkotlin/coroutines/Continuation;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    move-result-object v6

    .line 1656
    :try_start_0
    invoke-static {p0, v6}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;->access$setContinuation$p(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;)V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_1

    move-object v5, p0

    move-object v1, p1

    move v2, p2

    move-wide v3, p3

    .line 3173
    :try_start_1
    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$updateCellReceive(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;IJLjava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    .line 3175
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getSUSPEND$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p2

    if-ne p1, p2, :cond_0

    .line 3176
    invoke-static {v0, p0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$prepareReceiverForSuspension(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;I)V

    goto/16 :goto_5

    :catchall_0
    move-exception v0

    :goto_0
    move-object p1, v0

    goto/16 :goto_6

    .line 3178
    :cond_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getFAILED$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p2

    const/4 p3, 0x1

    const/4 p4, 0x0

    if-ne p1, p2, :cond_a

    .line 3179
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendersCounter$kotlinx_coroutines_core()J

    move-result-wide p1

    cmp-long p1, v3, p1

    if-gez p1, :cond_1

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->cleanPrev()V

    .line 3181
    :cond_1
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$getReceiveSegment$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object p1

    .line 3186
    invoke-virtual {p1, v0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    .line 3190
    :goto_1
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->isClosedForReceive()Z

    move-result p2

    if-eqz p2, :cond_2

    .line 1671
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;->access$onClosedHasNextNoWaiterSuspend(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;)V

    goto/16 :goto_5

    .line 3190
    :cond_2
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$getReceivers$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object p2

    .line 3193
    invoke-virtual {p2, v0}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->getAndIncrement(Ljava/lang/Object;)J

    move-result-wide v3

    .line 3195
    sget p2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->SEGMENT_SIZE:I

    int-to-long v1, p2

    div-long v1, v3, v1

    int-to-long v7, p2

    .line 3196
    rem-long v7, v3, v7

    long-to-int p2, v7

    .line 3199
    iget-wide v7, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    cmp-long v7, v7, v1

    if-eqz v7, :cond_4

    .line 3201
    invoke-static {v0, v1, v2, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$findSegmentReceive(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    move-result-object v1

    if-nez v1, :cond_3

    goto :goto_1

    :cond_3
    :goto_2
    move v2, p2

    goto :goto_3

    :cond_4
    move-object v1, p1

    goto :goto_2

    .line 3208
    :goto_3
    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$updateCellReceive(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;IJLjava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    .line 3210
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getSUSPEND$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p2

    if-ne p1, p2, :cond_5

    .line 3213
    invoke-static {v0, p0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$prepareReceiverForSuspension(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;I)V

    goto :goto_5

    .line 3216
    :cond_5
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getFAILED$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p2

    if-ne p1, p2, :cond_7

    .line 3223
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendersCounter$kotlinx_coroutines_core()J

    move-result-wide p1

    cmp-long p1, v3, p1

    if-gez p1, :cond_6

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->cleanPrev()V

    :cond_6
    move-object p1, v1

    goto :goto_1

    .line 3226
    :cond_7
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getSUSPEND_NO_WAITER$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p2

    if-eq p1, p2, :cond_9

    .line 3231
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->cleanPrev()V

    .line 1667
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;->access$setReceiveResult$p(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;Ljava/lang/Object;)V

    .line 1668
    invoke-static {p0, p4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;->access$setContinuation$p(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;)V

    .line 1669
    invoke-static {p3}, Lkotlin/coroutines/jvm/internal/Boxing;->boxBoolean(Z)Ljava/lang/Boolean;

    move-result-object p2

    iget-object p3, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->onUndeliveredElement:Lkotlin/jvm/functions/Function1;

    if-eqz p3, :cond_8

    invoke-static {v0, p3, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$bindCancellationFun(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lkotlin/jvm/functions/Function1;Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;

    move-result-object p4

    :cond_8
    :goto_4
    invoke-virtual {v6, p2, p4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->resume(Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;)V

    goto :goto_5

    .line 3229
    :cond_9
    new-instance p1, Ljava/lang/IllegalStateException;

    .line 3230
    const-string p2, "unexpected"

    invoke-direct {p1, p2}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw p1

    .line 3234
    :cond_a
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->cleanPrev()V

    .line 1667
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;->access$setReceiveResult$p(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;Ljava/lang/Object;)V

    .line 1668
    invoke-static {p0, p4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;->access$setContinuation$p(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;)V

    .line 1669
    invoke-static {p3}, Lkotlin/coroutines/jvm/internal/Boxing;->boxBoolean(Z)Ljava/lang/Boolean;

    move-result-object p2

    iget-object p3, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->onUndeliveredElement:Lkotlin/jvm/functions/Function1;

    if-eqz p3, :cond_8

    invoke-static {v0, p3, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$bindCancellationFun(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lkotlin/jvm/functions/Function1;Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;

    move-result-object p4
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    goto :goto_4

    .line 3246
    :goto_5
    invoke-virtual {v6}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->getResult()Ljava/lang/Object;

    move-result-object p1

    .line 3169
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->getCOROUTINE_SUSPENDED()Ljava/lang/Object;

    move-result-object p2

    if-ne p1, p2, :cond_b

    invoke-static {p5}, Lkotlin/coroutines/jvm/internal/DebugProbesKt;->probeCoroutineSuspended(Lkotlin/coroutines/Continuation;)V

    :cond_b
    return-object p1

    :catchall_1
    move-exception v0

    move-object v5, p0

    goto/16 :goto_0

    .line 3243
    :goto_6
    invoke-virtual {v6}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->releaseClaimedReusableContinuation$kotlinx_coroutines_core()V

    .line 3244
    throw p1
.end method

.method private final onClosedHasNext()Z
    .locals 1

    .line 1643
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->getCHANNEL_CLOSED()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;->receiveResult:Ljava/lang/Object;

    .line 1644
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;->this$0:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getCloseCause()Ljava/lang/Throwable;

    move-result-object v0

    if-nez v0, :cond_0

    const/4 v0, 0x0

    return v0

    .line 1645
    :cond_0
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/StackTraceRecoveryKt;->recoverStackTrace(Ljava/lang/Throwable;)Ljava/lang/Throwable;

    move-result-object v0

    throw v0
.end method

.method private final onClosedHasNextNoWaiterSuspend()V
    .locals 3

    .line 1682
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;->continuation:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    const/4 v1, 0x0

    .line 1683
    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;->continuation:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    .line 1685
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->getCHANNEL_CLOSED()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v1

    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;->receiveResult:Ljava/lang/Object;

    .line 1689
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;->this$0:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getCloseCause()Ljava/lang/Throwable;

    move-result-object v1

    if-nez v1, :cond_0

    .line 1691
    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/Result$Companion;

    sget-object v1, Ljava/lang/Boolean;->FALSE:Ljava/lang/Boolean;

    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->constructor-impl(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    invoke-interface {v0, v1}, Lkotlin/coroutines/Continuation;->resumeWith(Ljava/lang/Object;)V

    return-void

    .line 1693
    :cond_0
    sget-object v2, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/Result$Companion;

    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/kotlin/ResultKt;->createFailure(Ljava/lang/Throwable;)Ljava/lang/Object;

    move-result-object v1

    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->constructor-impl(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    invoke-interface {v0, v1}, Lkotlin/coroutines/Continuation;->resumeWith(Ljava/lang/Object;)V

    return-void
.end method


# virtual methods
.method public hasNext(Lkotlin/coroutines/Continuation;)Ljava/lang/Object;
    .locals 10

    .line 1617
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;->receiveResult:Ljava/lang/Object;

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getNO_RECEIVE_RESULT$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v1

    const/4 v2, 0x1

    if-eq v0, v1, :cond_0

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;->receiveResult:Ljava/lang/Object;

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->getCHANNEL_CLOSED()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v1

    if-eq v0, v1, :cond_0

    :goto_0
    move-object v4, p0

    goto/16 :goto_2

    .line 1619
    :cond_0
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;->this$0:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$getReceiveSegment$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    .line 3117
    invoke-virtual {v0, v3}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    .line 3121
    :goto_1
    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->isClosedForReceive()Z

    move-result v1

    if-eqz v1, :cond_1

    .line 1634
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;->onClosedHasNext()Z

    move-result v2

    goto :goto_0

    .line 3121
    :cond_1
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$getReceivers$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v1

    .line 3124
    invoke-virtual {v1, v3}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->getAndIncrement(Ljava/lang/Object;)J

    move-result-wide v6

    .line 3126
    sget v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->SEGMENT_SIZE:I

    int-to-long v4, v1

    div-long v4, v6, v4

    int-to-long v8, v1

    .line 3127
    rem-long v8, v6, v8

    long-to-int v1, v8

    .line 3130
    iget-wide v8, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    cmp-long v8, v8, v4

    if-eqz v8, :cond_2

    .line 3132
    invoke-static {v3, v4, v5, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$findSegmentReceive(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    move-result-object v4

    if-nez v4, :cond_3

    goto :goto_1

    :cond_2
    move-object v4, v0

    :cond_3
    const/4 v8, 0x0

    move v5, v1

    .line 3139
    invoke-static/range {v3 .. v8}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$updateCellReceive(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;IJLjava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    .line 3141
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getSUSPEND$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v1

    if-eq v0, v1, :cond_7

    .line 3147
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getFAILED$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v1

    if-ne v0, v1, :cond_5

    .line 3154
    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendersCounter$kotlinx_coroutines_core()J

    move-result-wide v0

    cmp-long v0, v6, v0

    if-gez v0, :cond_4

    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->cleanPrev()V

    :cond_4
    move-object v0, v4

    goto :goto_1

    .line 3157
    :cond_5
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getSUSPEND_NO_WAITER$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v1

    if-ne v0, v1, :cond_6

    move-object v9, p1

    move-wide v7, v6

    move v6, v5

    move-object v5, v4

    move-object v4, p0

    .line 1638
    invoke-direct/range {v4 .. v9}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;->hasNextOnNoWaiterSuspend(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;IJLkotlin/coroutines/Continuation;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    :cond_6
    move-object v5, v4

    move-object v4, p0

    .line 3166
    invoke-virtual {v5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->cleanPrev()V

    .line 1628
    iput-object v0, v4, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;->receiveResult:Ljava/lang/Object;

    .line 3140
    :goto_2
    invoke-static {v2}, Lkotlin/coroutines/jvm/internal/Boxing;->boxBoolean(Z)Ljava/lang/Boolean;

    move-result-object p1

    return-object p1

    :cond_7
    move-object v4, p0

    .line 3145
    new-instance p1, Ljava/lang/IllegalStateException;

    .line 1632
    const-string v0, "unreachable"

    invoke-direct {p1, v0}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public invokeOnCancellation(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;I)V
    .locals 1

    .line 1676
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;->continuation:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    if-eqz v0, :cond_0

    invoke-virtual {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->invokeOnCancellation(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;I)V

    :cond_0
    return-void
.end method

.method public next()Ljava/lang/Object;
    .locals 2

    .line 1700
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;->receiveResult:Ljava/lang/Object;

    .line 1701
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getNO_RECEIVE_RESULT$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v1

    if-eq v0, v1, :cond_1

    .line 1702
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getNO_RECEIVE_RESULT$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v1

    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;->receiveResult:Ljava/lang/Object;

    .line 1704
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->getCHANNEL_CLOSED()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v1

    if-eq v0, v1, :cond_0

    return-object v0

    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;->this$0:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$getReceiveException(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;)Ljava/lang/Throwable;

    move-result-object v0

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/StackTraceRecoveryKt;->recoverStackTrace(Ljava/lang/Throwable;)Ljava/lang/Throwable;

    move-result-object v0

    throw v0

    .line 1701
    :cond_1
    new-instance v0, Ljava/lang/IllegalStateException;

    const-string v1, "`hasNext()` has not been invoked"

    invoke-direct {v0, v1}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method public final tryResumeHasNext(Ljava/lang/Object;)Z
    .locals 5

    .line 1712
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;->continuation:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    const/4 v1, 0x0

    .line 1713
    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;->continuation:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    .line 1715
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;->receiveResult:Ljava/lang/Object;

    .line 1719
    sget-object v2, Ljava/lang/Boolean;->TRUE:Ljava/lang/Boolean;

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;->this$0:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;

    iget-object v4, v3, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->onUndeliveredElement:Lkotlin/jvm/functions/Function1;

    if-eqz v4, :cond_0

    invoke-static {v3, v4, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$bindCancellationFun(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lkotlin/jvm/functions/Function1;Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;

    move-result-object v1

    :cond_0
    invoke-static {v0, v2, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$tryResume0(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;)Z

    move-result p1

    return p1
.end method

.method public final tryResumeHasNextOnClosedChannel()V
    .locals 3

    .line 1728
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;->continuation:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    const/4 v1, 0x0

    .line 1729
    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;->continuation:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    .line 1733
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->getCHANNEL_CLOSED()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v1

    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;->receiveResult:Ljava/lang/Object;

    .line 1737
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;->this$0:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getCloseCause()Ljava/lang/Throwable;

    move-result-object v1

    if-nez v1, :cond_0

    .line 1739
    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/Result$Companion;

    sget-object v1, Ljava/lang/Boolean;->FALSE:Ljava/lang/Boolean;

    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->constructor-impl(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    invoke-interface {v0, v1}, Lkotlin/coroutines/Continuation;->resumeWith(Ljava/lang/Object;)V

    return-void

    .line 1741
    :cond_0
    sget-object v2, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/Result$Companion;

    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/kotlin/ResultKt;->createFailure(Ljava/lang/Throwable;)Ljava/lang/Object;

    move-result-object v1

    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->constructor-impl(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    invoke-interface {v0, v1}, Lkotlin/coroutines/Continuation;->resumeWith(Ljava/lang/Object;)V

    return-void
.end method
