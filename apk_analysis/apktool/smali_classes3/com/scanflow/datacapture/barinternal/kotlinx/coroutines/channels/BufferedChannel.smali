.class public Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;
.super Ljava/lang/Object;
.source "BufferedChannel.kt"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/Channel;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;
    }
.end annotation


# static fields
.field private static final synthetic _closeCause$volatile$FU:Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

.field private static final synthetic bufferEnd$volatile$FU:Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

.field private static final synthetic bufferEndSegment$volatile$FU:Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

.field private static final synthetic closeHandler$volatile$FU:Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

.field private static final synthetic completedExpandBuffersAndPauseFlag$volatile$FU:Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

.field private static final synthetic receiveSegment$volatile$FU:Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

.field private static final synthetic receivers$volatile$FU:Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

.field private static final synthetic sendSegment$volatile$FU:Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

.field private static final synthetic sendersAndCloseStatus$volatile$FU:Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;


# instance fields
.field private volatile synthetic _closeCause$volatile:Ljava/lang/Object;

.field private volatile synthetic bufferEnd$volatile:J

.field private volatile synthetic bufferEndSegment$volatile:Ljava/lang/Object;

.field private final capacity:I

.field private volatile synthetic closeHandler$volatile:Ljava/lang/Object;

.field private volatile synthetic completedExpandBuffersAndPauseFlag$volatile:J

.field public final onUndeliveredElement:Lkotlin/jvm/functions/Function1;

.field private final onUndeliveredElementReceiveCancellationConstructor:Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;

.field private volatile synthetic receiveSegment$volatile:Ljava/lang/Object;

.field private volatile synthetic receivers$volatile:J

.field private volatile synthetic sendSegment$volatile:Ljava/lang/Object;

.field private volatile synthetic sendersAndCloseStatus$volatile:J


# direct methods
.method public static synthetic $r8$lambda$4YtRDnxWiAY_lEFg7xfxub3g44Y(Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/selects/SelectInstance;Ljava/lang/Throwable;Ljava/lang/Object;Lkotlin/coroutines/CoroutineContext;)Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
    .locals 0

    .line 0
    invoke-static/range {p0 .. p5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->onUndeliveredElementReceiveCancellationConstructor$lambda$57$lambda$56$lambda$55(Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/selects/SelectInstance;Ljava/lang/Throwable;Ljava/lang/Object;Lkotlin/coroutines/CoroutineContext;)Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    move-result-object p0

    return-object p0
.end method

.method public static synthetic $r8$lambda$RGQ-VgAvWnoZmUCAtr48LHy5NVI(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/selects/SelectInstance;Ljava/lang/Object;Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;
    .locals 0

    .line 0
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->onUndeliveredElementReceiveCancellationConstructor$lambda$57$lambda$56(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/selects/SelectInstance;Ljava/lang/Object;Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;

    move-result-object p0

    return-object p0
.end method

.method public static synthetic $r8$lambda$cFjTbckZ8dFxJdDmoJhWmyFFbYA(Lkotlin/jvm/functions/Function1;Ljava/lang/Object;Ljava/lang/Throwable;Ljava/lang/Object;Lkotlin/coroutines/CoroutineContext;)Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
    .locals 0

    .line 0
    invoke-static {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->bindCancellationFun$lambda$89(Lkotlin/jvm/functions/Function1;Ljava/lang/Object;Ljava/lang/Throwable;Ljava/lang/Object;Lkotlin/coroutines/CoroutineContext;)Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    move-result-object p0

    return-object p0
.end method

.method static constructor <clinit>()V
    .locals 3

    .line 0
    const-string v0, "sendersAndCloseStatus$volatile"

    const-class v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;

    invoke-static {v1, v0}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->newUpdater(Ljava/lang/Class;Ljava/lang/String;)Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->sendersAndCloseStatus$volatile$FU:Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    const-string v0, "receivers$volatile"

    invoke-static {v1, v0}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->newUpdater(Ljava/lang/Class;Ljava/lang/String;)Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->receivers$volatile$FU:Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    const-string v0, "bufferEnd$volatile"

    invoke-static {v1, v0}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->newUpdater(Ljava/lang/Class;Ljava/lang/String;)Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->bufferEnd$volatile$FU:Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    const-string v0, "completedExpandBuffersAndPauseFlag$volatile"

    invoke-static {v1, v0}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->newUpdater(Ljava/lang/Class;Ljava/lang/String;)Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->completedExpandBuffersAndPauseFlag$volatile$FU:Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    const-string v0, "sendSegment$volatile"

    const-class v2, Ljava/lang/Object;

    invoke-static {v1, v2, v0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->newUpdater(Ljava/lang/Class;Ljava/lang/Class;Ljava/lang/String;)Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->sendSegment$volatile$FU:Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    const-string v0, "receiveSegment$volatile"

    invoke-static {v1, v2, v0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->newUpdater(Ljava/lang/Class;Ljava/lang/Class;Ljava/lang/String;)Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->receiveSegment$volatile$FU:Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    const-string v0, "bufferEndSegment$volatile"

    invoke-static {v1, v2, v0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->newUpdater(Ljava/lang/Class;Ljava/lang/Class;Ljava/lang/String;)Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->bufferEndSegment$volatile$FU:Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    const-string v0, "_closeCause$volatile"

    invoke-static {v1, v2, v0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->newUpdater(Ljava/lang/Class;Ljava/lang/Class;Ljava/lang/String;)Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->_closeCause$volatile$FU:Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    const-string v0, "closeHandler$volatile"

    invoke-static {v1, v2, v0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->newUpdater(Ljava/lang/Class;Ljava/lang/Class;Ljava/lang/String;)Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->closeHandler$volatile$FU:Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    return-void
.end method

.method public constructor <init>(ILkotlin/jvm/functions/Function1;)V
    .locals 8

    .line 33
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 38
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->capacity:I

    .line 39
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->onUndeliveredElement:Lkotlin/jvm/functions/Function1;

    if-ltz p1, :cond_2

    .line 65
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$initialBufferEnd(I)J

    move-result-wide v0

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->bufferEnd$volatile:J

    .line 84
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getBufferEndCounter()J

    move-result-wide v0

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->completedExpandBuffersAndPauseFlag$volatile:J

    .line 95
    new-instance v2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    const/4 v5, 0x0

    const/4 v7, 0x3

    const-wide/16 v3, 0x0

    move-object v6, p0

    invoke-direct/range {v2 .. v7}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;-><init>(JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;I)V

    .line 96
    iput-object v2, v6, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->sendSegment$volatile:Ljava/lang/Object;

    .line 97
    iput-object v2, v6, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->receiveSegment$volatile:Ljava/lang/Object;

    .line 102
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->isRendezvousOrUnlimited()Z

    move-result p1

    if-eqz p1, :cond_0

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getNULL_SEGMENT$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    move-result-object v2

    const-string p1, "null cannot be cast to non-null type kotlinx.coroutines.channels.ChannelSegment<E of kotlinx.coroutines.channels.BufferedChannel>"

    invoke-static {v2, p1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    :cond_0
    iput-object v2, v6, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->bufferEndSegment$volatile:Ljava/lang/Object;

    if-eqz p2, :cond_1

    .line 1562
    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$$ExternalSyntheticLambda0;

    invoke-direct {p1, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$$ExternalSyntheticLambda0;-><init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;)V

    goto :goto_0

    :cond_1
    const/4 p1, 0x0

    .line 1561
    :goto_0
    iput-object p1, v6, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->onUndeliveredElementReceiveCancellationConstructor:Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;

    .line 1754
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getNO_CLOSE_CAUSE$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p1

    iput-object p1, v6, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->_closeCause$volatile:Ljava/lang/Object;

    return-void

    :cond_2
    move-object v6, p0

    .line 43
    new-instance p2, Ljava/lang/StringBuilder;

    invoke-direct {p2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v0, "Invalid channel capacity: "

    invoke-virtual {p2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p1, ", should be >=0"

    invoke-virtual {p2, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    new-instance p2, Ljava/lang/IllegalArgumentException;

    invoke-virtual {p1}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {p2, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p2
.end method

.method public static final synthetic access$bindCancellationFun(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lkotlin/jvm/functions/Function1;Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;
    .locals 0

    .line 33
    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->bindCancellationFun(Lkotlin/jvm/functions/Function1;Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;

    move-result-object p0

    return-object p0
.end method

.method public static final synthetic access$bindCancellationFunResult(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lkotlin/jvm/functions/Function1;)Lkotlin/reflect/KFunction;
    .locals 0

    .line 33
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->bindCancellationFunResult(Lkotlin/jvm/functions/Function1;)Lkotlin/reflect/KFunction;

    move-result-object p0

    return-object p0
.end method

.method public static final synthetic access$findSegmentReceive(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;
    .locals 0

    .line 33
    invoke-direct {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->findSegmentReceive(JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    move-result-object p0

    return-object p0
.end method

.method public static final synthetic access$findSegmentSend(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;
    .locals 0

    .line 33
    invoke-direct {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->findSegmentSend(JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    move-result-object p0

    return-object p0
.end method

.method public static final synthetic access$getReceiveException(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;)Ljava/lang/Throwable;
    .locals 0

    .line 33
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getReceiveException()Ljava/lang/Throwable;

    move-result-object p0

    return-object p0
.end method

.method public static final synthetic access$getReceiveSegment$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;
    .locals 1

    .line 33
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getReceiveSegment$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    return-object v0
.end method

.method public static final synthetic access$getReceivers$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;
    .locals 1

    .line 33
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getReceivers$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v0

    return-object v0
.end method

.method public static final synthetic access$getSendSegment$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;
    .locals 1

    .line 33
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendSegment$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    return-object v0
.end method

.method public static final synthetic access$getSendersAndCloseStatus$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;
    .locals 1

    .line 33
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendersAndCloseStatus$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v0

    return-object v0
.end method

.method public static final synthetic access$isClosedForSend0(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;J)Z
    .locals 0

    .line 33
    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->isClosedForSend0(J)Z

    move-result p0

    return p0
.end method

.method public static final synthetic access$onCancellationChannelResultImplDoNotCall-5_sEAP8(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Ljava/lang/Throwable;Ljava/lang/Object;Lkotlin/coroutines/CoroutineContext;)V
    .locals 0

    .line 33
    invoke-direct {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->onCancellationChannelResultImplDoNotCall-5_sEAP8(Ljava/lang/Throwable;Ljava/lang/Object;Lkotlin/coroutines/CoroutineContext;)V

    return-void
.end method

.method public static final synthetic access$onCancellationImplDoNotCall(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Ljava/lang/Throwable;Ljava/lang/Object;Lkotlin/coroutines/CoroutineContext;)V
    .locals 0

    .line 33
    invoke-direct {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->onCancellationImplDoNotCall(Ljava/lang/Throwable;Ljava/lang/Object;Lkotlin/coroutines/CoroutineContext;)V

    return-void
.end method

.method public static final synthetic access$onClosedReceiveCatchingOnNoWaiterSuspend(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;)V
    .locals 0

    .line 33
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->onClosedReceiveCatchingOnNoWaiterSuspend(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;)V

    return-void
.end method

.method public static final synthetic access$onClosedSendOnNoWaiterSuspend(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;)V
    .locals 0

    .line 33
    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->onClosedSendOnNoWaiterSuspend(Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;)V

    return-void
.end method

.method public static final synthetic access$prepareReceiverForSuspension(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;I)V
    .locals 0

    .line 33
    invoke-direct {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->prepareReceiverForSuspension(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;I)V

    return-void
.end method

.method public static final synthetic access$prepareSenderForSuspension(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;I)V
    .locals 0

    .line 33
    invoke-direct {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->prepareSenderForSuspension(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;I)V

    return-void
.end method

.method public static final synthetic access$receiveCatchingOnNoWaiterSuspend-GKJJFZk(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;IJLkotlin/coroutines/Continuation;)Ljava/lang/Object;
    .locals 0

    .line 33
    invoke-direct/range {p0 .. p5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->receiveCatchingOnNoWaiterSuspend-GKJJFZk(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;IJLkotlin/coroutines/Continuation;)Ljava/lang/Object;

    move-result-object p0

    return-object p0
.end method

.method public static final synthetic access$updateCellReceive(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;IJLjava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 33
    invoke-direct/range {p0 .. p5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->updateCellReceive(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;IJLjava/lang/Object;)Ljava/lang/Object;

    move-result-object p0

    return-object p0
.end method

.method public static final synthetic access$updateCellSend(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;ILjava/lang/Object;JLjava/lang/Object;Z)I
    .locals 0

    .line 33
    invoke-direct/range {p0 .. p7}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->updateCellSend(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;ILjava/lang/Object;JLjava/lang/Object;Z)I

    move-result p0

    return p0
.end method

.method private final bindCancellationFun(Lkotlin/jvm/functions/Function1;Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;
    .locals 1

    .line 2782
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$$ExternalSyntheticLambda1;

    invoke-direct {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$$ExternalSyntheticLambda1;-><init>(Lkotlin/jvm/functions/Function1;Ljava/lang/Object;)V

    return-object v0
.end method

.method private final bindCancellationFun(Lkotlin/jvm/functions/Function1;)Lkotlin/reflect/KFunction;
    .locals 0

    .line 2784
    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$bindCancellationFun$2;

    invoke-direct {p1, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$bindCancellationFun$2;-><init>(Ljava/lang/Object;)V

    return-object p1
.end method

.method private static final bindCancellationFun$lambda$89(Lkotlin/jvm/functions/Function1;Ljava/lang/Object;Ljava/lang/Throwable;Ljava/lang/Object;Lkotlin/coroutines/CoroutineContext;)Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
    .locals 0

    .line 2782
    invoke-static {p0, p1, p4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/OnUndeliveredElementKt;->callUndeliveredElement(Lkotlin/jvm/functions/Function1;Ljava/lang/Object;Lkotlin/coroutines/CoroutineContext;)V

    sget-object p0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    return-object p0
.end method

.method private final bindCancellationFunResult(Lkotlin/jvm/functions/Function1;)Lkotlin/reflect/KFunction;
    .locals 0

    .line 2767
    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$bindCancellationFunResult$1;

    invoke-direct {p1, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$bindCancellationFunResult$1;-><init>(Ljava/lang/Object;)V

    return-object p1
.end method

.method private final bufferOrRendezvousSend(J)Z
    .locals 4

    .line 634
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getBufferEndCounter()J

    move-result-wide v0

    cmp-long v0, p1, v0

    if-ltz v0, :cond_1

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getReceiversCounter$kotlinx_coroutines_core()J

    move-result-wide v0

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->capacity:I

    int-to-long v2, v2

    add-long/2addr v0, v2

    cmp-long p1, p1, v0

    if-gez p1, :cond_0

    goto :goto_0

    :cond_0
    const/4 p1, 0x0

    return p1

    :cond_1
    :goto_0
    const/4 p1, 0x1

    return p1
.end method

.method private final cancelSuspendedReceiveRequests(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;J)V
    .locals 8

    const/4 v0, 0x0

    const/4 v1, 0x1

    .line 2148
    invoke-static {v0, v1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/InlineList;->constructor-impl$default(Ljava/lang/Object;ILkotlin/jvm/internal/DefaultConstructorMarker;)Ljava/lang/Object;

    move-result-object v0

    :goto_0
    const/4 v2, -0x1

    if-eqz p1, :cond_6

    .line 2151
    sget v3, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->SEGMENT_SIZE:I

    sub-int/2addr v3, v1

    :goto_1
    if-ge v2, v3, :cond_5

    .line 2153
    iget-wide v4, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    sget v6, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->SEGMENT_SIZE:I

    int-to-long v6, v6

    mul-long/2addr v4, v6

    int-to-long v6, v3

    add-long/2addr v4, v6

    cmp-long v4, v4, p2

    if-ltz v4, :cond_6

    .line 2156
    :cond_0
    invoke-virtual {p1, v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->getState$kotlinx_coroutines_core(I)Ljava/lang/Object;

    move-result-object v4

    if-eqz v4, :cond_3

    .line 2158
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getIN_BUFFER$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v5

    if-ne v4, v5, :cond_1

    goto :goto_2

    .line 2164
    :cond_1
    instance-of v5, v4, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/WaiterEB;

    if-eqz v5, :cond_2

    .line 2165
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->getCHANNEL_CLOSED()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v5

    invoke-virtual {p1, v3, v4, v5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->casState$kotlinx_coroutines_core(ILjava/lang/Object;Ljava/lang/Object;)Z

    move-result v5

    if-eqz v5, :cond_0

    .line 2166
    check-cast v4, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/WaiterEB;

    iget-object v4, v4, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/WaiterEB;->waiter:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;

    invoke-static {v0, v4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/InlineList;->plus-FjFbRPM(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    .line 2167
    invoke-virtual {p1, v3, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->onCancelledRequest(IZ)V

    goto :goto_3

    .line 2171
    :cond_2
    instance-of v5, v4, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;

    if-eqz v5, :cond_4

    .line 2172
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->getCHANNEL_CLOSED()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v5

    invoke-virtual {p1, v3, v4, v5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->casState$kotlinx_coroutines_core(ILjava/lang/Object;Ljava/lang/Object;)Z

    move-result v5

    if-eqz v5, :cond_0

    .line 2173
    invoke-static {v0, v4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/InlineList;->plus-FjFbRPM(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    .line 2174
    invoke-virtual {p1, v3, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->onCancelledRequest(IZ)V

    goto :goto_3

    .line 2159
    :cond_3
    :goto_2
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->getCHANNEL_CLOSED()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v5

    invoke-virtual {p1, v3, v4, v5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->casState$kotlinx_coroutines_core(ILjava/lang/Object;Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_0

    .line 2160
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->onSlotCleaned()V

    :cond_4
    :goto_3
    add-int/lit8 v3, v3, -0x1

    goto :goto_1

    .line 2183
    :cond_5
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->getPrev()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    goto :goto_0

    :cond_6
    if-eqz v0, :cond_8

    .line 4192
    instance-of p1, v0, Ljava/util/ArrayList;

    if-nez p1, :cond_7

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;

    .line 2186
    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->resumeReceiverOnClosedChannel(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;)V

    return-void

    .line 4194
    :cond_7
    const-string p1, "null cannot be cast to non-null type java.util.ArrayList<E of kotlinx.coroutines.internal.InlineList>"

    invoke-static {v0, p1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast v0, Ljava/util/ArrayList;

    .line 4195
    invoke-virtual {v0}, Ljava/util/ArrayList;->size()I

    move-result p1

    sub-int/2addr p1, v1

    :goto_4
    if-ge v2, p1, :cond_8

    .line 4196
    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object p2

    check-cast p2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;

    .line 2186
    invoke-direct {p0, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->resumeReceiverOnClosedChannel(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;)V

    add-int/lit8 p1, p1, -0x1

    goto :goto_4

    :cond_8
    return-void
.end method

.method private final closeLinkedList()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;
    .locals 6

    .line 1986
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getBufferEndSegment$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendSegment$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v1

    .line 1987
    invoke-virtual {v1, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    iget-wide v2, v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    move-object v4, v0

    check-cast v4, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    iget-wide v4, v4, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    cmp-long v2, v2, v4

    if-lez v2, :cond_0

    move-object v0, v1

    :cond_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getReceiveSegment$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v1

    .line 1988
    invoke-virtual {v1, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    iget-wide v2, v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    move-object v4, v0

    check-cast v4, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    iget-wide v4, v4, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    cmp-long v2, v2, v4

    if-lez v2, :cond_1

    move-object v0, v1

    .line 1991
    :cond_1
    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListKt;->close(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    return-object v0
.end method

.method private final completeCancel(J)V
    .locals 0

    .line 1975
    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->completeClose(J)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    move-result-object p1

    .line 1978
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->removeUnprocessedElements(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;)V

    return-void
.end method

.method private final completeClose(J)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;
    .locals 5

    .line 1946
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->closeLinkedList()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    move-result-object v0

    .line 1956
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->isConflatedDropOldest()Z

    move-result v1

    if-eqz v1, :cond_0

    .line 1957
    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->markAllEmptyCellsAsClosed(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;)J

    move-result-wide v1

    const-wide/16 v3, -0x1

    cmp-long v3, v1, v3

    if-eqz v3, :cond_0

    .line 1959
    invoke-virtual {p0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->dropFirstElementUntilTheSpecifiedCellIsInTheBuffer(J)V

    .line 1963
    :cond_0
    invoke-direct {p0, v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->cancelSuspendedReceiveRequests(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;J)V

    return-object v0
.end method

.method private final completeCloseOrCancel()V
    .locals 0

    .line 1935
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->isClosedForSend()Z

    return-void
.end method

.method private final expandBuffer()V
    .locals 13

    .line 1193
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->isRendezvousOrUnlimited()Z

    move-result v0

    if-eqz v0, :cond_0

    return-void

    :cond_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getBufferEndSegment$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    .line 1196
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    move-object v4, v0

    .line 1198
    :goto_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getBufferEnd$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v0

    .line 1201
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->getAndIncrement(Ljava/lang/Object;)J

    move-result-wide v5

    .line 1202
    sget v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->SEGMENT_SIZE:I

    int-to-long v1, v0

    div-long v2, v5, v1

    .line 1210
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendersCounter$kotlinx_coroutines_core()J

    move-result-wide v7

    cmp-long v1, v7, v5

    const/4 v7, 0x0

    const/4 v8, 0x1

    const-wide/16 v9, 0x0

    if-gtz v1, :cond_2

    .line 1213
    iget-wide v0, v4, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    cmp-long v0, v0, v2

    if-gez v0, :cond_1

    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->getNext()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;

    move-result-object v0

    if-eqz v0, :cond_1

    .line 1214
    invoke-direct {p0, v2, v3, v4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->moveSegmentBufferEndToSpecifiedOrLast(JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;)V

    .line 1216
    :cond_1
    invoke-static {p0, v9, v10, v8, v7}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->incCompletedExpandBufferAttempts$default(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;JILjava/lang/Object;)V

    return-void

    .line 1221
    :cond_2
    iget-wide v11, v4, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    cmp-long v1, v11, v2

    if-eqz v1, :cond_4

    move-object v1, p0

    .line 1222
    invoke-direct/range {v1 .. v6}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->findSegmentBufferEnd(JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;J)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    move-result-object v2

    if-nez v2, :cond_3

    goto :goto_0

    :cond_3
    move-object v4, v2

    goto :goto_1

    :cond_4
    move-object v1, p0

    :goto_1
    int-to-long v2, v0

    .line 1233
    rem-long v2, v5, v2

    long-to-int v0, v2

    .line 1234
    invoke-direct {p0, v4, v0, v5, v6}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->updateCellExpandBuffer(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;IJ)Z

    move-result v0

    if-eqz v0, :cond_5

    .line 1242
    invoke-static {p0, v9, v10, v8, v7}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->incCompletedExpandBufferAttempts$default(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;JILjava/lang/Object;)V

    return-void

    .line 1248
    :cond_5
    invoke-static {p0, v9, v10, v8, v7}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->incCompletedExpandBufferAttempts$default(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;JILjava/lang/Object;)V

    goto :goto_0
.end method

.method private final findSegmentBufferEnd(JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;J)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;
    .locals 14

    move-wide v2, p1

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getBufferEndSegment$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    .line 2498
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->createSegmentFunction()Lkotlin/reflect/KFunction;

    move-result-object v4

    check-cast v4, Lkotlin/jvm/functions/Function2;

    move-object/from16 v5, p3

    .line 4236
    :goto_0
    invoke-static {v5, v2, v3, v4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListKt;->findSegmentInternal(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;JLkotlin/jvm/functions/Function2;)Ljava/lang/Object;

    move-result-object v6

    .line 4237
    invoke-static {v6}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/SegmentOrClosed;->isClosed-impl(Ljava/lang/Object;)Z

    move-result v7

    if-nez v7, :cond_4

    invoke-static {v6}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/SegmentOrClosed;->getSegment-impl(Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;

    move-result-object v7

    :cond_0
    :goto_1
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v8

    check-cast v8, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;

    .line 4238
    iget-wide v9, v8, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    iget-wide v11, v7, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    cmp-long v9, v9, v11

    if-ltz v9, :cond_1

    goto :goto_2

    .line 4239
    :cond_1
    invoke-virtual {v7}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->tryIncPointers$kotlinx_coroutines_core()Z

    move-result v9

    if-nez v9, :cond_2

    goto :goto_0

    .line 4240
    :cond_2
    invoke-static {v0, p0, v8, v7}, Landroidx/concurrent/futures/AbstractResolvableFuture$SafeAtomicHelper$$ExternalSyntheticBackportWithForwarding0;->m(Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v9

    if-eqz v9, :cond_3

    .line 4241
    invoke-virtual {v8}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->decPointers$kotlinx_coroutines_core()Z

    move-result v0

    if-eqz v0, :cond_4

    invoke-virtual {v8}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->remove()V

    goto :goto_2

    .line 4244
    :cond_3
    invoke-virtual {v7}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->decPointers$kotlinx_coroutines_core()Z

    move-result v8

    if-eqz v8, :cond_0

    invoke-virtual {v7}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->remove()V

    goto :goto_1

    .line 2499
    :cond_4
    :goto_2
    invoke-static {v6}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/SegmentOrClosed;->isClosed-impl(Ljava/lang/Object;)Z

    move-result v0

    const/4 v7, 0x1

    const-wide/16 v8, 0x0

    const/4 v10, 0x0

    if-eqz v0, :cond_5

    .line 2504
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->completeCloseOrCancel()V

    .line 2507
    invoke-direct/range {p0 .. p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->moveSegmentBufferEndToSpecifiedOrLast(JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;)V

    .line 2510
    invoke-static {p0, v8, v9, v7, v10}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->incCompletedExpandBufferAttempts$default(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;JILjava/lang/Object;)V

    return-object v10

    .line 2514
    :cond_5
    invoke-static {v6}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/SegmentOrClosed;->getSegment-impl(Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;

    move-result-object v0

    move-object v6, v0

    check-cast v6, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    .line 2516
    iget-wide v4, v6, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    cmp-long v0, v4, v2

    if-lez v0, :cond_7

    .line 2522
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getBufferEnd$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v0

    const-wide/16 v2, 0x1

    add-long v2, p4, v2

    iget-wide v4, v6, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    sget v11, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->SEGMENT_SIZE:I

    int-to-long v12, v11

    mul-long/2addr v4, v12

    move-object v1, p0

    invoke-virtual/range {v0 .. v5}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->compareAndSet(Ljava/lang/Object;JJ)Z

    move-result v0

    if-eqz v0, :cond_6

    .line 2523
    iget-wide v2, v6, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    int-to-long v4, v11

    mul-long/2addr v2, v4

    sub-long v2, v2, p4

    invoke-direct {p0, v2, v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->incCompletedExpandBufferAttempts(J)V

    goto :goto_3

    .line 2525
    :cond_6
    invoke-static {p0, v8, v9, v7, v10}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->incCompletedExpandBufferAttempts$default(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;JILjava/lang/Object;)V

    :goto_3
    return-object v10

    :cond_7
    return-object v6
.end method

.method private final findSegmentReceive(JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;
    .locals 9

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getReceiveSegment$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    .line 2449
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->createSegmentFunction()Lkotlin/reflect/KFunction;

    move-result-object v1

    check-cast v1, Lkotlin/jvm/functions/Function2;

    .line 4217
    :goto_0
    invoke-static {p3, p1, p2, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListKt;->findSegmentInternal(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;JLkotlin/jvm/functions/Function2;)Ljava/lang/Object;

    move-result-object v2

    .line 4218
    invoke-static {v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/SegmentOrClosed;->isClosed-impl(Ljava/lang/Object;)Z

    move-result v3

    if-nez v3, :cond_4

    invoke-static {v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/SegmentOrClosed;->getSegment-impl(Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;

    move-result-object v3

    :cond_0
    :goto_1
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;

    .line 4219
    iget-wide v5, v4, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    iget-wide v7, v3, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    cmp-long v5, v5, v7

    if-ltz v5, :cond_1

    goto :goto_2

    .line 4220
    :cond_1
    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->tryIncPointers$kotlinx_coroutines_core()Z

    move-result v5

    if-nez v5, :cond_2

    goto :goto_0

    .line 4221
    :cond_2
    invoke-static {v0, p0, v4, v3}, Landroidx/concurrent/futures/AbstractResolvableFuture$SafeAtomicHelper$$ExternalSyntheticBackportWithForwarding0;->m(Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v5

    if-eqz v5, :cond_3

    .line 4222
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->decPointers$kotlinx_coroutines_core()Z

    move-result v0

    if-eqz v0, :cond_4

    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->remove()V

    goto :goto_2

    .line 4225
    :cond_3
    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->decPointers$kotlinx_coroutines_core()Z

    move-result v4

    if-eqz v4, :cond_0

    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->remove()V

    goto :goto_1

    .line 2450
    :cond_4
    :goto_2
    invoke-static {v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/SegmentOrClosed;->isClosed-impl(Ljava/lang/Object;)Z

    move-result v0

    const/4 v1, 0x0

    if-eqz v0, :cond_6

    .line 2455
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->completeCloseOrCancel()V

    .line 2461
    iget-wide p1, p3, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    sget v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->SEGMENT_SIZE:I

    int-to-long v2, v0

    mul-long/2addr p1, v2

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendersCounter$kotlinx_coroutines_core()J

    move-result-wide v2

    cmp-long p1, p1, v2

    if-gez p1, :cond_5

    invoke-virtual {p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->cleanPrev()V

    :cond_5
    return-object v1

    .line 2466
    :cond_6
    invoke-static {v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/SegmentOrClosed;->getSegment-impl(Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;

    move-result-object p3

    check-cast p3, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    .line 2468
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->isRendezvousOrUnlimited()Z

    move-result v0

    if-nez v0, :cond_9

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getBufferEndCounter()J

    move-result-wide v2

    sget v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->SEGMENT_SIZE:I

    int-to-long v4, v0

    div-long/2addr v2, v4

    cmp-long v0, p1, v2

    if-gtz v0, :cond_9

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getBufferEndSegment$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    :cond_7
    :goto_3
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;

    .line 4227
    iget-wide v3, v2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    iget-wide v5, p3, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    cmp-long v3, v3, v5

    if-gez v3, :cond_9

    .line 4228
    invoke-virtual {p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->tryIncPointers$kotlinx_coroutines_core()Z

    move-result v3

    if-eqz v3, :cond_9

    .line 4229
    invoke-static {v0, p0, v2, p3}, Landroidx/concurrent/futures/AbstractResolvableFuture$SafeAtomicHelper$$ExternalSyntheticBackportWithForwarding0;->m(Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_8

    .line 4230
    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->decPointers$kotlinx_coroutines_core()Z

    move-result v0

    if-eqz v0, :cond_9

    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->remove()V

    goto :goto_4

    .line 4233
    :cond_8
    invoke-virtual {p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->decPointers$kotlinx_coroutines_core()Z

    move-result v2

    if-eqz v2, :cond_7

    invoke-virtual {p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->remove()V

    goto :goto_3

    .line 2472
    :cond_9
    :goto_4
    iget-wide v2, p3, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    cmp-long p1, v2, p1

    if-lez p1, :cond_b

    .line 2476
    sget p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->SEGMENT_SIZE:I

    int-to-long v4, p1

    mul-long/2addr v2, v4

    invoke-direct {p0, v2, v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->updateReceiversCounterIfLower(J)V

    .line 2482
    iget-wide v2, p3, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    int-to-long p1, p1

    mul-long/2addr v2, p1

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendersCounter$kotlinx_coroutines_core()J

    move-result-wide p1

    cmp-long p1, v2, p1

    if-gez p1, :cond_a

    invoke-virtual {p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->cleanPrev()V

    :cond_a
    return-object v1

    :cond_b
    return-object p3
.end method

.method private final findSegmentSend(JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;
    .locals 9

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendSegment$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    .line 2394
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->createSegmentFunction()Lkotlin/reflect/KFunction;

    move-result-object v1

    check-cast v1, Lkotlin/jvm/functions/Function2;

    .line 4206
    :goto_0
    invoke-static {p3, p1, p2, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListKt;->findSegmentInternal(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;JLkotlin/jvm/functions/Function2;)Ljava/lang/Object;

    move-result-object v2

    .line 4207
    invoke-static {v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/SegmentOrClosed;->isClosed-impl(Ljava/lang/Object;)Z

    move-result v3

    if-nez v3, :cond_4

    invoke-static {v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/SegmentOrClosed;->getSegment-impl(Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;

    move-result-object v3

    :cond_0
    :goto_1
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;

    .line 4208
    iget-wide v5, v4, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    iget-wide v7, v3, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    cmp-long v5, v5, v7

    if-ltz v5, :cond_1

    goto :goto_2

    .line 4209
    :cond_1
    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->tryIncPointers$kotlinx_coroutines_core()Z

    move-result v5

    if-nez v5, :cond_2

    goto :goto_0

    .line 4210
    :cond_2
    invoke-static {v0, p0, v4, v3}, Landroidx/concurrent/futures/AbstractResolvableFuture$SafeAtomicHelper$$ExternalSyntheticBackportWithForwarding0;->m(Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v5

    if-eqz v5, :cond_3

    .line 4211
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->decPointers$kotlinx_coroutines_core()Z

    move-result v0

    if-eqz v0, :cond_4

    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->remove()V

    goto :goto_2

    .line 4214
    :cond_3
    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->decPointers$kotlinx_coroutines_core()Z

    move-result v4

    if-eqz v4, :cond_0

    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->remove()V

    goto :goto_1

    .line 2395
    :cond_4
    :goto_2
    invoke-static {v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/SegmentOrClosed;->isClosed-impl(Ljava/lang/Object;)Z

    move-result v0

    const/4 v1, 0x0

    if-eqz v0, :cond_6

    .line 2400
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->completeCloseOrCancel()V

    .line 2406
    iget-wide p1, p3, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    sget v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->SEGMENT_SIZE:I

    int-to-long v2, v0

    mul-long/2addr p1, v2

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getReceiversCounter$kotlinx_coroutines_core()J

    move-result-wide v2

    cmp-long p1, p1, v2

    if-gez p1, :cond_5

    invoke-virtual {p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->cleanPrev()V

    :cond_5
    return-object v1

    .line 2411
    :cond_6
    invoke-static {v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/SegmentOrClosed;->getSegment-impl(Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;

    move-result-object p3

    check-cast p3, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    .line 2413
    iget-wide v2, p3, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    cmp-long p1, v2, p1

    if-lez p1, :cond_8

    .line 2417
    sget p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->SEGMENT_SIZE:I

    int-to-long v4, p1

    mul-long/2addr v2, v4

    invoke-direct {p0, v2, v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->updateSendersCounterIfLower(J)V

    .line 2423
    iget-wide v2, p3, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    int-to-long p1, p1

    mul-long/2addr v2, p1

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getReceiversCounter$kotlinx_coroutines_core()J

    move-result-wide p1

    cmp-long p1, v2, p1

    if-gez p1, :cond_7

    invoke-virtual {p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->cleanPrev()V

    :cond_7
    return-object v1

    :cond_8
    return-object p3
.end method

.method private static final synthetic getBufferEnd$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;
    .locals 1

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->bufferEnd$volatile$FU:Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    return-object v0
.end method

.method private final getBufferEndCounter()J
    .locals 2

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getBufferEnd$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v0

    .line 69
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->get(Ljava/lang/Object;)J

    move-result-wide v0

    return-wide v0
.end method

.method private static final synthetic getBufferEndSegment$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;
    .locals 1

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->bufferEndSegment$volatile$FU:Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    return-object v0
.end method

.method private static final synthetic getCloseHandler$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;
    .locals 1

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->closeHandler$volatile$FU:Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    return-object v0
.end method

.method private static final synthetic getCompletedExpandBuffersAndPauseFlag$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;
    .locals 1

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->completedExpandBuffersAndPauseFlag$volatile$FU:Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    return-object v0
.end method

.method private final getReceiveException()Ljava/lang/Throwable;
    .locals 2

    .line 1762
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getCloseCause()Ljava/lang/Throwable;

    move-result-object v0

    if-nez v0, :cond_0

    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ClosedReceiveChannelException;

    const-string v1, "Channel was closed"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ClosedReceiveChannelException;-><init>(Ljava/lang/String;)V

    :cond_0
    return-object v0
.end method

.method private static final synthetic getReceiveSegment$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;
    .locals 1

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->receiveSegment$volatile$FU:Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    return-object v0
.end method

.method private static final synthetic getReceivers$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;
    .locals 1

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->receivers$volatile$FU:Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    return-object v0
.end method

.method private static final synthetic getSendSegment$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;
    .locals 1

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->sendSegment$volatile$FU:Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    return-object v0
.end method

.method private static final synthetic getSendersAndCloseStatus$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;
    .locals 1

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->sendersAndCloseStatus$volatile$FU:Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    return-object v0
.end method

.method private static final synthetic get_closeCause$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;
    .locals 1

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->_closeCause$volatile$FU:Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    return-object v0
.end method

.method private final incCompletedExpandBufferAttempts(J)V
    .locals 4

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getCompletedExpandBuffersAndPauseFlag$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v0

    .line 1390
    invoke-virtual {v0, p0, p1, p2}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->addAndGet(Ljava/lang/Object;J)J

    move-result-wide p1

    const-wide/high16 v0, 0x4000000000000000L    # 2.0

    and-long/2addr p1, v0

    const-wide/16 v2, 0x0

    cmp-long p1, p1, v2

    if-eqz p1, :cond_0

    .line 1396
    :goto_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getCompletedExpandBuffersAndPauseFlag$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object p1

    invoke-virtual {p1, p0}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->get(Ljava/lang/Object;)J

    move-result-wide p1

    and-long/2addr p1, v0

    cmp-long p1, p1, v2

    if-eqz p1, :cond_0

    goto :goto_0

    :cond_0
    return-void
.end method

.method static synthetic incCompletedExpandBufferAttempts$default(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;JILjava/lang/Object;)V
    .locals 0

    if-nez p4, :cond_1

    and-int/lit8 p3, p3, 0x1

    if-eqz p3, :cond_0

    const-wide/16 p1, 0x1

    .line 1388
    :cond_0
    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->incCompletedExpandBufferAttempts(J)V

    return-void

    :cond_1
    new-instance p0, Ljava/lang/UnsupportedOperationException;

    const-string p1, "Super calls with default arguments not supported in this target, function: incCompletedExpandBufferAttempts"

    invoke-direct {p0, p1}, Ljava/lang/UnsupportedOperationException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method private final invokeCloseHandler()V
    .locals 3

    .line 1841
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getCloseHandler$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    :cond_0
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    if-nez v1, :cond_1

    .line 1846
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getCLOSE_HANDLER_CLOSED$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v2

    goto :goto_0

    .line 1850
    :cond_1
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getCLOSE_HANDLER_INVOKED$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v2

    .line 1851
    :goto_0
    invoke-static {v0, p0, v1, v2}, Landroidx/concurrent/futures/AbstractResolvableFuture$SafeAtomicHelper$$ExternalSyntheticBackportWithForwarding0;->m(Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_0

    if-nez v1, :cond_2

    return-void

    :cond_2
    const/4 v0, 0x1

    .line 1855
    invoke-static {v1, v0}, Lkotlin/jvm/internal/TypeIntrinsics;->beforeCheckcastToFunctionOfArity(Ljava/lang/Object;I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lkotlin/jvm/functions/Function1;

    .line 1856
    check-cast v1, Lkotlin/jvm/functions/Function1;

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getCloseCause()Ljava/lang/Throwable;

    move-result-object v0

    invoke-interface {v1, v0}, Lkotlin/jvm/functions/Function1;->invoke(Ljava/lang/Object;)Ljava/lang/Object;

    return-void
.end method

.method private final isCellNonEmpty(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;IJ)Z
    .locals 4

    .line 2328
    :cond_0
    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->getState$kotlinx_coroutines_core(I)Ljava/lang/Object;

    move-result-object v0

    const/4 v1, 0x0

    if-eqz v0, :cond_a

    .line 2331
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getIN_BUFFER$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v2

    if-ne v0, v2, :cond_1

    goto :goto_0

    .line 2342
    :cond_1
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->BUFFERED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    const/4 p2, 0x1

    if-ne v0, p1, :cond_2

    return p2

    .line 2344
    :cond_2
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getINTERRUPTED_SEND$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p1

    if-ne v0, p1, :cond_3

    return v1

    .line 2346
    :cond_3
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->getCHANNEL_CLOSED()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p1

    if-ne v0, p1, :cond_4

    return v1

    .line 2349
    :cond_4
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getDONE_RCV$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p1

    if-ne v0, p1, :cond_5

    return v1

    .line 2352
    :cond_5
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getPOISONED$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p1

    if-ne v0, p1, :cond_6

    return v1

    .line 2356
    :cond_6
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getRESUMING_BY_EB$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p1

    if-ne v0, p1, :cond_7

    return p2

    .line 2360
    :cond_7
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getRESUMING_BY_RCV$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p1

    if-ne v0, p1, :cond_8

    return v1

    .line 2371
    :cond_8
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getReceiversCounter$kotlinx_coroutines_core()J

    move-result-wide v2

    cmp-long p1, p3, v2

    if-nez p1, :cond_9

    return p2

    :cond_9
    return v1

    .line 2333
    :cond_a
    :goto_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getPOISONED$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v2

    invoke-virtual {p1, p2, v0, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->casState$kotlinx_coroutines_core(ILjava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 2337
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->expandBuffer()V

    return v1
.end method

.method private final isClosed(JZ)Z
    .locals 6

    const/16 v0, 0x3c

    shr-long v0, p1, v0

    long-to-int v0, v0

    const/4 v1, 0x0

    if-eqz v0, :cond_4

    const/4 v2, 0x1

    if-eq v0, v2, :cond_4

    const/4 v3, 0x2

    const-wide v4, 0xfffffffffffffffL

    if-eq v0, v3, :cond_1

    const/4 p3, 0x3

    if-ne v0, p3, :cond_0

    and-long/2addr p1, v4

    .line 2252
    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->completeCancel(J)V

    return v2

    .line 2255
    :cond_0
    new-instance p1, Ljava/lang/StringBuilder;

    invoke-direct {p1}, Ljava/lang/StringBuilder;-><init>()V

    const-string p2, "unexpected close status: "

    invoke-virtual {p1, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p1, v0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {p1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    new-instance p2, Ljava/lang/IllegalStateException;

    invoke-virtual {p1}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {p2, p1}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw p2

    :cond_1
    and-long/2addr p1, v4

    .line 2242
    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->completeClose(J)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    if-eqz p3, :cond_3

    .line 2246
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->hasElements$kotlinx_coroutines_core()Z

    move-result p1

    if-nez p1, :cond_2

    return v2

    :cond_2
    return v1

    :cond_3
    return v2

    :cond_4
    return v1
.end method

.method private final isClosedForReceive0(J)Z
    .locals 1

    const/4 v0, 0x1

    .line 2224
    invoke-direct {p0, p1, p2, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->isClosed(JZ)Z

    move-result p1

    return p1
.end method

.method private final isClosedForSend0(J)Z
    .locals 1

    const/4 v0, 0x0

    .line 2217
    invoke-direct {p0, p1, p2, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->isClosed(JZ)Z

    move-result p1

    return p1
.end method

.method private final isRendezvousOrUnlimited()Z
    .locals 4

    .line 87
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getBufferEndCounter()J

    move-result-wide v0

    const-wide/16 v2, 0x0

    cmp-long v2, v0, v2

    if-eqz v2, :cond_1

    const-wide v2, 0x7fffffffffffffffL

    cmp-long v0, v0, v2

    if-nez v0, :cond_0

    goto :goto_0

    :cond_0
    const/4 v0, 0x0

    return v0

    :cond_1
    :goto_0
    const/4 v0, 0x1

    return v0
.end method

.method private final markAllEmptyCellsAsClosed(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;)J
    .locals 7

    .line 2007
    :cond_0
    sget v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->SEGMENT_SIZE:I

    add-int/lit8 v0, v0, -0x1

    :goto_0
    const-wide/16 v1, -0x1

    const/4 v3, -0x1

    if-ge v3, v0, :cond_5

    .line 2009
    iget-wide v3, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    sget v5, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->SEGMENT_SIZE:I

    int-to-long v5, v5

    mul-long/2addr v3, v5

    int-to-long v5, v0

    add-long/2addr v3, v5

    .line 2010
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getReceiversCounter$kotlinx_coroutines_core()J

    move-result-wide v5

    cmp-long v5, v3, v5

    if-gez v5, :cond_1

    return-wide v1

    .line 2013
    :cond_1
    invoke-virtual {p1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->getState$kotlinx_coroutines_core(I)Ljava/lang/Object;

    move-result-object v1

    if-eqz v1, :cond_3

    .line 2016
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getIN_BUFFER$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v2

    if-ne v1, v2, :cond_2

    goto :goto_1

    .line 2024
    :cond_2
    sget-object v2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->BUFFERED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    if-ne v1, v2, :cond_4

    return-wide v3

    .line 2018
    :cond_3
    :goto_1
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->getCHANNEL_CLOSED()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v2

    invoke-virtual {p1, v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->casState$kotlinx_coroutines_core(ILjava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_1

    .line 2019
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->onSlotCleaned()V

    :cond_4
    add-int/lit8 v0, v0, -0x1

    goto :goto_0

    .line 2031
    :cond_5
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->getPrev()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    if-nez p1, :cond_0

    return-wide v1
.end method

.method private final markCancellationStarted()V
    .locals 6

    .line 1924
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendersAndCloseStatus$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v0

    :cond_0
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->get(Ljava/lang/Object;)J

    move-result-wide v2

    const/16 v1, 0x3c

    shr-long v4, v2, v1

    long-to-int v1, v4

    if-nez v1, :cond_1

    const-wide v4, 0xfffffffffffffffL

    and-long/2addr v4, v2

    const/4 v1, 0x1

    .line 1927
    invoke-static {v4, v5, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$constructSendersAndCloseStatus(JI)J

    move-result-wide v4

    move-object v1, p0

    .line 1928
    invoke-virtual/range {v0 .. v5}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->compareAndSet(Ljava/lang/Object;JJ)Z

    move-result v2

    if-eqz v2, :cond_0

    :cond_1
    return-void
.end method

.method private final markCancelled()V
    .locals 6

    .line 1913
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendersAndCloseStatus$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v0

    :cond_0
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->get(Ljava/lang/Object;)J

    move-result-wide v2

    const-wide v4, 0xfffffffffffffffL

    and-long/2addr v4, v2

    const/4 v1, 0x3

    .line 1915
    invoke-static {v4, v5, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$constructSendersAndCloseStatus(JI)J

    move-result-wide v4

    move-object v1, p0

    invoke-virtual/range {v0 .. v5}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->compareAndSet(Ljava/lang/Object;JJ)Z

    move-result v2

    if-eqz v2, :cond_0

    return-void
.end method

.method private final markClosed()V
    .locals 7

    .line 1896
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendersAndCloseStatus$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v0

    :cond_0
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->get(Ljava/lang/Object;)J

    move-result-wide v2

    const/16 v1, 0x3c

    shr-long v4, v2, v1

    long-to-int v1, v4

    const-wide v4, 0xfffffffffffffffL

    if-eqz v1, :cond_2

    const/4 v6, 0x1

    if-eq v1, v6, :cond_1

    goto :goto_2

    :cond_1
    and-long/2addr v4, v2

    const/4 v1, 0x3

    .line 1902
    invoke-static {v4, v5, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$constructSendersAndCloseStatus(JI)J

    move-result-wide v4

    :goto_0
    move-object v1, p0

    goto :goto_1

    :cond_2
    and-long/2addr v4, v2

    const/4 v1, 0x2

    .line 1900
    invoke-static {v4, v5, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$constructSendersAndCloseStatus(JI)J

    move-result-wide v4

    goto :goto_0

    .line 1904
    :goto_1
    invoke-virtual/range {v0 .. v5}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->compareAndSet(Ljava/lang/Object;JJ)Z

    move-result v2

    if-eqz v2, :cond_0

    :goto_2
    return-void
.end method

.method private final moveSegmentBufferEndToSpecifiedOrLast(JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;)V
    .locals 4

    .line 2546
    :goto_0
    iget-wide v0, p3, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    cmp-long v0, v0, p1

    if-gez v0, :cond_1

    .line 2547
    invoke-virtual {p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->getNext()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    if-nez v0, :cond_0

    goto :goto_1

    :cond_0
    move-object p3, v0

    goto :goto_0

    .line 2553
    :cond_1
    :goto_1
    invoke-virtual {p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->isRemoved()Z

    move-result p1

    if-eqz p1, :cond_3

    .line 2554
    invoke-virtual {p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->getNext()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    if-nez p1, :cond_2

    goto :goto_2

    :cond_2
    move-object p3, p1

    goto :goto_1

    .line 2559
    :cond_3
    :goto_2
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getBufferEndSegment$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object p1

    :cond_4
    :goto_3
    invoke-virtual {p1, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p2

    check-cast p2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;

    .line 4246
    iget-wide v0, p2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    iget-wide v2, p3, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    cmp-long v0, v0, v2

    if-ltz v0, :cond_5

    return-void

    .line 4247
    :cond_5
    invoke-virtual {p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->tryIncPointers$kotlinx_coroutines_core()Z

    move-result v0

    if-nez v0, :cond_6

    goto :goto_1

    .line 4248
    :cond_6
    invoke-static {p1, p0, p2, p3}, Landroidx/concurrent/futures/AbstractResolvableFuture$SafeAtomicHelper$$ExternalSyntheticBackportWithForwarding0;->m(Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_8

    .line 4249
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->decPointers$kotlinx_coroutines_core()Z

    move-result p1

    if-eqz p1, :cond_7

    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->remove()V

    :cond_7
    return-void

    .line 4252
    :cond_8
    invoke-virtual {p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->decPointers$kotlinx_coroutines_core()Z

    move-result p2

    if-eqz p2, :cond_4

    invoke-virtual {p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->remove()V

    goto :goto_3
.end method

.method private final onCancellationChannelResultImplDoNotCall-5_sEAP8(Ljava/lang/Throwable;Ljava/lang/Object;Lkotlin/coroutines/CoroutineContext;)V
    .locals 0

    .line 2777
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->onUndeliveredElement:Lkotlin/jvm/functions/Function1;

    invoke-static {p1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-static {p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;->getOrNull-impl(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p2

    invoke-static {p2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-static {p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/OnUndeliveredElementKt;->callUndeliveredElement(Lkotlin/jvm/functions/Function1;Ljava/lang/Object;Lkotlin/coroutines/CoroutineContext;)V

    return-void
.end method

.method private final onCancellationImplDoNotCall(Ljava/lang/Throwable;Ljava/lang/Object;Lkotlin/coroutines/CoroutineContext;)V
    .locals 0

    .line 2792
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->onUndeliveredElement:Lkotlin/jvm/functions/Function1;

    invoke-static {p1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-static {p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/OnUndeliveredElementKt;->callUndeliveredElement(Lkotlin/jvm/functions/Function1;Ljava/lang/Object;Lkotlin/coroutines/CoroutineContext;)V

    return-void
.end method

.method private final onClosedReceiveCatchingOnNoWaiterSuspend(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;)V
    .locals 2

    .line 779
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/Result$Companion;

    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;->Companion:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getCloseCause()Ljava/lang/Throwable;

    move-result-object v1

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;->closed-JP2dKIU(Ljava/lang/Throwable;)Ljava/lang/Object;

    move-result-object v0

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;->box-impl(Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;

    move-result-object v0

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->constructor-impl(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    invoke-interface {p1, v0}, Lkotlin/coroutines/Continuation;->resumeWith(Ljava/lang/Object;)V

    return-void
.end method

.method private final onClosedSend(Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;
    .locals 4

    .line 3195
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    invoke-static {p2}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->intercepted(Lkotlin/coroutines/Continuation;)Lkotlin/coroutines/Continuation;

    move-result-object v1

    const/4 v2, 0x1

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;-><init>(Lkotlin/coroutines/Continuation;I)V

    .line 3201
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->initCancellability()V

    .line 132
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->onUndeliveredElement:Lkotlin/jvm/functions/Function1;

    if-eqz v1, :cond_0

    const/4 v2, 0x2

    const/4 v3, 0x0

    invoke-static {v1, p1, v3, v2, v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/OnUndeliveredElementKt;->callUndeliveredElementCatchingException$default(Lkotlin/jvm/functions/Function1;Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/UndeliveredElementException;ILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/UndeliveredElementException;

    move-result-object p1

    if-eqz p1, :cond_0

    .line 134
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendException()Ljava/lang/Throwable;

    move-result-object v1

    invoke-static {p1, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/ExceptionsKt;->addSuppressed(Ljava/lang/Throwable;Ljava/lang/Throwable;)V

    .line 3203
    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/Result$Companion;

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/ResultKt;->createFailure(Ljava/lang/Throwable;)Ljava/lang/Object;

    move-result-object p1

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->constructor-impl(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    invoke-interface {v0, p1}, Lkotlin/coroutines/Continuation;->resumeWith(Ljava/lang/Object;)V

    goto :goto_0

    .line 138
    :cond_0
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendException()Ljava/lang/Throwable;

    move-result-object p1

    .line 3207
    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/Result$Companion;

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/ResultKt;->createFailure(Ljava/lang/Throwable;)Ljava/lang/Object;

    move-result-object p1

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->constructor-impl(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    invoke-interface {v0, p1}, Lkotlin/coroutines/Continuation;->resumeWith(Ljava/lang/Object;)V

    .line 3211
    :goto_0
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->getResult()Ljava/lang/Object;

    move-result-object p1

    .line 3194
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->getCOROUTINE_SUSPENDED()Ljava/lang/Object;

    move-result-object v0

    if-ne p1, v0, :cond_1

    invoke-static {p2}, Lkotlin/coroutines/jvm/internal/DebugProbesKt;->probeCoroutineSuspended(Lkotlin/coroutines/Continuation;)V

    :cond_1
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->getCOROUTINE_SUSPENDED()Ljava/lang/Object;

    move-result-object p2

    if-ne p1, p2, :cond_2

    return-object p1

    .line 3212
    :cond_2
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    return-object p1
.end method

.method private final onClosedSendOnNoWaiterSuspend(Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;)V
    .locals 2

    .line 179
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->onUndeliveredElement:Lkotlin/jvm/functions/Function1;

    if-eqz v0, :cond_0

    invoke-interface {p2}, Lkotlin/coroutines/Continuation;->getContext()Lkotlin/coroutines/CoroutineContext;

    move-result-object v1

    invoke-static {v0, p1, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/OnUndeliveredElementKt;->callUndeliveredElement(Lkotlin/jvm/functions/Function1;Ljava/lang/Object;Lkotlin/coroutines/CoroutineContext;)V

    .line 180
    :cond_0
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendException()Ljava/lang/Throwable;

    move-result-object p1

    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/Result$Companion;

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/ResultKt;->createFailure(Ljava/lang/Throwable;)Ljava/lang/Object;

    move-result-object p1

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->constructor-impl(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    invoke-interface {p2, p1}, Lkotlin/coroutines/Continuation;->resumeWith(Ljava/lang/Object;)V

    return-void
.end method

.method private static final onUndeliveredElementReceiveCancellationConstructor$lambda$57$lambda$56(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/selects/SelectInstance;Ljava/lang/Object;Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;
    .locals 0

    .line 1563
    new-instance p2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$$ExternalSyntheticLambda2;

    invoke-direct {p2, p3, p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$$ExternalSyntheticLambda2;-><init>(Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/selects/SelectInstance;)V

    return-object p2
.end method

.method private static final onUndeliveredElementReceiveCancellationConstructor$lambda$57$lambda$56$lambda$55(Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/selects/SelectInstance;Ljava/lang/Throwable;Ljava/lang/Object;Lkotlin/coroutines/CoroutineContext;)Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
    .locals 0

    .line 1564
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->getCHANNEL_CLOSED()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p3

    if-eq p0, p3, :cond_0

    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->onUndeliveredElement:Lkotlin/jvm/functions/Function1;

    invoke-interface {p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/selects/SelectInstance;->getContext()Lkotlin/coroutines/CoroutineContext;

    move-result-object p2

    invoke-static {p1, p0, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/OnUndeliveredElementKt;->callUndeliveredElement(Lkotlin/jvm/functions/Function1;Ljava/lang/Object;Lkotlin/coroutines/CoroutineContext;)V

    .line 1565
    :cond_0
    sget-object p0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    return-object p0
.end method

.method private final prepareReceiverForSuspension(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;I)V
    .locals 0

    .line 736
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->onReceiveEnqueued()V

    .line 737
    invoke-interface {p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;->invokeOnCancellation(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;I)V

    return-void
.end method

.method private final prepareSenderForSuspension(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;I)V
    .locals 1

    .line 175
    sget v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->SEGMENT_SIZE:I

    add-int/2addr p3, v0

    invoke-interface {p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;->invokeOnCancellation(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;I)V

    return-void
.end method

.method static synthetic receiveCatching-JP2dKIU$suspendImpl(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;
    .locals 13

    instance-of v0, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$receiveCatching$1;

    if-eqz v0, :cond_0

    move-object v0, p1

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$receiveCatching$1;

    iget v1, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$receiveCatching$1;->label:I

    const/high16 v2, -0x80000000

    and-int v3, v1, v2

    if-eqz v3, :cond_0

    sub-int/2addr v1, v2

    iput v1, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$receiveCatching$1;->label:I

    :goto_0
    move-object v6, v0

    goto :goto_1

    :cond_0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$receiveCatching$1;

    invoke-direct {v0, p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$receiveCatching$1;-><init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lkotlin/coroutines/Continuation;)V

    goto :goto_0

    :goto_1
    iget-object p1, v6, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$receiveCatching$1;->result:Ljava/lang/Object;

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->getCOROUTINE_SUSPENDED()Ljava/lang/Object;

    move-result-object v0

    .line 751
    iget v1, v6, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$receiveCatching$1;->label:I

    const/4 v2, 0x1

    if-eqz v1, :cond_2

    if-ne v1, v2, :cond_1

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/ResultKt;->throwOnFailure(Ljava/lang/Object;)V

    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;->unbox-impl()Ljava/lang/Object;

    move-result-object p0

    return-object p0

    :cond_1
    new-instance p0, Ljava/lang/IllegalStateException;

    const-string p1, "call to \'resume\' before \'invoke\' with coroutine"

    invoke-direct {p0, p1}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw p0

    :cond_2
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/ResultKt;->throwOnFailure(Ljava/lang/Object;)V

    .line 752
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$getReceiveSegment$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object p1

    .line 3792
    invoke-virtual {p1, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    .line 3796
    :goto_2
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->isClosedForReceive()Z

    move-result v1

    if-eqz v1, :cond_3

    .line 758
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;->Companion:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getCloseCause()Ljava/lang/Throwable;

    move-result-object p0

    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;->closed-JP2dKIU(Ljava/lang/Throwable;)Ljava/lang/Object;

    move-result-object p0

    return-object p0

    .line 3796
    :cond_3
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$getReceivers$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v1

    .line 3799
    invoke-virtual {v1, p0}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->getAndIncrement(Ljava/lang/Object;)J

    move-result-wide v4

    .line 3801
    sget v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->SEGMENT_SIZE:I

    int-to-long v7, v1

    div-long v7, v4, v7

    int-to-long v9, v1

    .line 3802
    rem-long v9, v4, v9

    long-to-int v3, v9

    .line 3805
    iget-wide v9, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    cmp-long v1, v9, v7

    if-eqz v1, :cond_5

    .line 3807
    invoke-static {p0, v7, v8, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$findSegmentReceive(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    move-result-object v1

    if-nez v1, :cond_4

    goto :goto_2

    :cond_4
    move-object v8, v1

    goto :goto_3

    :cond_5
    move-object v8, p1

    :goto_3
    const/4 v12, 0x0

    move-object v7, p0

    move v9, v3

    move-wide v10, v4

    .line 3814
    invoke-static/range {v7 .. v12}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$updateCellReceive(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;IJLjava/lang/Object;)Ljava/lang/Object;

    move-result-object p0

    move-object v1, v7

    .line 3816
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getSUSPEND$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p1

    if-eq p0, p1, :cond_a

    .line 3822
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getFAILED$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p1

    if-ne p0, p1, :cond_7

    .line 3829
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendersCounter$kotlinx_coroutines_core()J

    move-result-wide p0

    cmp-long p0, v4, p0

    if-gez p0, :cond_6

    invoke-virtual {v8}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->cleanPrev()V

    :cond_6
    move-object p0, v1

    move-object p1, v8

    goto :goto_2

    .line 3832
    :cond_7
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getSUSPEND_NO_WAITER$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p1

    if-ne p0, p1, :cond_9

    .line 759
    iput v2, v6, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$receiveCatching$1;->label:I

    move-object v2, v8

    invoke-direct/range {v1 .. v6}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->receiveCatchingOnNoWaiterSuspend-GKJJFZk(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;IJLkotlin/coroutines/Continuation;)Ljava/lang/Object;

    move-result-object p0

    if-ne p0, v0, :cond_8

    return-object v0

    :cond_8
    return-object p0

    .line 3841
    :cond_9
    invoke-virtual {v8}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->cleanPrev()V

    .line 755
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;->Companion:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;

    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;->success-JP2dKIU(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p0

    return-object p0

    .line 3820
    :cond_a
    new-instance p0, Ljava/lang/IllegalStateException;

    .line 757
    const-string p1, "unexpected"

    invoke-direct {p0, p1}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method private final receiveCatchingOnNoWaiterSuspend-GKJJFZk(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;IJLkotlin/coroutines/Continuation;)Ljava/lang/Object;
    .locals 10

    instance-of v0, p5, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$receiveCatchingOnNoWaiterSuspend$1;

    if-eqz v0, :cond_0

    move-object v0, p5

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$receiveCatchingOnNoWaiterSuspend$1;

    iget v1, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$receiveCatchingOnNoWaiterSuspend$1;->label:I

    const/high16 v2, -0x80000000

    and-int v3, v1, v2

    if-eqz v3, :cond_0

    sub-int/2addr v1, v2

    iput v1, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$receiveCatchingOnNoWaiterSuspend$1;->label:I

    goto :goto_0

    :cond_0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$receiveCatchingOnNoWaiterSuspend$1;

    invoke-direct {v0, p0, p5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$receiveCatchingOnNoWaiterSuspend$1;-><init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lkotlin/coroutines/Continuation;)V

    :goto_0
    iget-object p5, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$receiveCatchingOnNoWaiterSuspend$1;->result:Ljava/lang/Object;

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->getCOROUTINE_SUSPENDED()Ljava/lang/Object;

    move-result-object v1

    .line 762
    iget v2, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$receiveCatchingOnNoWaiterSuspend$1;->label:I

    const/4 v3, 0x1

    if-eqz v2, :cond_2

    if-ne v2, v3, :cond_1

    iget-object p1, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$receiveCatchingOnNoWaiterSuspend$1;->L$1:Ljava/lang/Object;

    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    iget-object p1, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$receiveCatchingOnNoWaiterSuspend$1;->L$0:Ljava/lang/Object;

    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;

    invoke-static {p5}, Lcom/scanflow/datacapture/barinternal/kotlin/ResultKt;->throwOnFailure(Ljava/lang/Object;)V

    move-object v2, p0

    goto/16 :goto_7

    :cond_1
    new-instance p1, Ljava/lang/IllegalStateException;

    const-string p2, "call to \'resume\' before \'invoke\' with coroutine"

    invoke-direct {p1, p2}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw p1

    :cond_2
    invoke-static {p5}, Lcom/scanflow/datacapture/barinternal/kotlin/ResultKt;->throwOnFailure(Ljava/lang/Object;)V

    .line 3844
    iput-object p0, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$receiveCatchingOnNoWaiterSuspend$1;->L$0:Ljava/lang/Object;

    iput-object p1, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$receiveCatchingOnNoWaiterSuspend$1;->L$1:Ljava/lang/Object;

    iput p2, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$receiveCatchingOnNoWaiterSuspend$1;->I$0:I

    iput-wide p3, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$receiveCatchingOnNoWaiterSuspend$1;->J$0:J

    iput v3, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$receiveCatchingOnNoWaiterSuspend$1;->label:I

    .line 3845
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->intercepted(Lkotlin/coroutines/Continuation;)Lkotlin/coroutines/Continuation;

    move-result-object p5

    invoke-static {p5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationKt;->getOrCreateCancellableContinuation(Lkotlin/coroutines/Continuation;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    move-result-object p5

    .line 767
    :try_start_0
    new-instance v7, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ReceiveCatching;

    const-string v2, "null cannot be cast to non-null type kotlinx.coroutines.CancellableContinuationImpl<kotlinx.coroutines.channels.ChannelResult<E of kotlinx.coroutines.channels.BufferedChannel>>"

    invoke-static {p5, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-direct {v7, p5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ReceiveCatching;-><init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;)V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_1

    move-object v2, p0

    move-object v3, p1

    move v4, p2

    move-wide v5, p3

    .line 3848
    :try_start_1
    invoke-static/range {v2 .. v7}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$updateCellReceive(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;IJLjava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    .line 3850
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getSUSPEND$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p2

    if-ne p1, p2, :cond_3

    .line 3851
    invoke-static {p0, v7, v3, v4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$prepareReceiverForSuspension(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;I)V

    goto/16 :goto_6

    :catchall_0
    move-exception v0

    :goto_1
    move-object p1, v0

    goto/16 :goto_8

    .line 3853
    :cond_3
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getFAILED$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p2

    const/4 p3, 0x0

    if-ne p1, p2, :cond_d

    .line 3854
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendersCounter$kotlinx_coroutines_core()J

    move-result-wide p1

    cmp-long p1, v5, p1

    if-gez p1, :cond_4

    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->cleanPrev()V

    .line 3856
    :cond_4
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$getReceiveSegment$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object p1

    .line 3861
    invoke-virtual {p1, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    .line 3865
    :goto_2
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->isClosedForReceive()Z

    move-result p2

    if-eqz p2, :cond_5

    .line 774
    invoke-static {p0, p5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$onClosedReceiveCatchingOnNoWaiterSuspend(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;)V

    goto/16 :goto_6

    .line 3865
    :cond_5
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$getReceivers$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object p2

    .line 3868
    invoke-virtual {p2, p0}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->getAndIncrement(Ljava/lang/Object;)J

    move-result-wide v5

    .line 3870
    sget p2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->SEGMENT_SIZE:I

    int-to-long v3, p2

    div-long v3, v5, v3

    int-to-long v8, p2

    .line 3871
    rem-long v8, v5, v8

    long-to-int p2, v8

    .line 3874
    iget-wide v8, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    cmp-long p4, v8, v3

    if-eqz p4, :cond_7

    .line 3876
    invoke-static {p0, v3, v4, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$findSegmentReceive(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    move-result-object p4

    if-nez p4, :cond_6

    goto :goto_2

    :cond_6
    move-object v3, p4

    :goto_3
    move v4, p2

    goto :goto_4

    :cond_7
    move-object v3, p1

    goto :goto_3

    .line 3883
    :goto_4
    invoke-static/range {v2 .. v7}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$updateCellReceive(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;IJLjava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    move-object p4, v3

    .line 3885
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getSUSPEND$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p2

    if-ne p1, p2, :cond_8

    .line 3888
    invoke-static {p0, v7, p4, v4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$prepareReceiverForSuspension(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;I)V

    goto :goto_6

    .line 3891
    :cond_8
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getFAILED$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p2

    if-ne p1, p2, :cond_a

    .line 3898
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendersCounter$kotlinx_coroutines_core()J

    move-result-wide p1

    cmp-long p1, v5, p1

    if-gez p1, :cond_9

    invoke-virtual {p4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->cleanPrev()V

    :cond_9
    move-object p1, p4

    goto :goto_2

    .line 3901
    :cond_a
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getSUSPEND_NO_WAITER$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p2

    if-eq p1, p2, :cond_c

    .line 3906
    invoke-virtual {p4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->cleanPrev()V

    .line 772
    sget-object p2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;->Companion:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;

    invoke-virtual {p2, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;->success-JP2dKIU(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;->box-impl(Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;

    move-result-object p1

    iget-object p2, v2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->onUndeliveredElement:Lkotlin/jvm/functions/Function1;

    if-eqz p2, :cond_b

    invoke-static {p0, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$bindCancellationFunResult(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lkotlin/jvm/functions/Function1;)Lkotlin/reflect/KFunction;

    move-result-object p3

    :cond_b
    check-cast p3, Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;

    :goto_5
    invoke-virtual {p5, p1, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->resume(Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;)V

    goto :goto_6

    .line 3904
    :cond_c
    new-instance p1, Ljava/lang/IllegalStateException;

    .line 3905
    const-string p2, "unexpected"

    invoke-direct {p1, p2}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw p1

    .line 3909
    :cond_d
    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->cleanPrev()V

    .line 772
    sget-object p2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;->Companion:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;

    invoke-virtual {p2, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;->success-JP2dKIU(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;->box-impl(Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;

    move-result-object p1

    iget-object p2, v2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->onUndeliveredElement:Lkotlin/jvm/functions/Function1;

    if-eqz p2, :cond_e

    invoke-static {p0, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$bindCancellationFunResult(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lkotlin/jvm/functions/Function1;)Lkotlin/reflect/KFunction;

    move-result-object p3

    :cond_e
    check-cast p3, Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    goto :goto_5

    .line 3921
    :goto_6
    invoke-virtual {p5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->getResult()Ljava/lang/Object;

    move-result-object p5

    .line 3844
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->getCOROUTINE_SUSPENDED()Ljava/lang/Object;

    move-result-object p1

    if-ne p5, p1, :cond_f

    invoke-static {v0}, Lkotlin/coroutines/jvm/internal/DebugProbesKt;->probeCoroutineSuspended(Lkotlin/coroutines/Continuation;)V

    :cond_f
    if-ne p5, v1, :cond_10

    return-object v1

    .line 3922
    :cond_10
    :goto_7
    check-cast p5, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;

    invoke-virtual {p5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;->unbox-impl()Ljava/lang/Object;

    move-result-object p1

    return-object p1

    :catchall_1
    move-exception v0

    move-object v2, p0

    goto/16 :goto_1

    .line 3918
    :goto_8
    invoke-virtual {p5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->releaseClaimedReusableContinuation$kotlinx_coroutines_core()V

    .line 3919
    throw p1
.end method

.method private final removeUnprocessedElements(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;)V
    .locals 11

    .line 2046
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->onUndeliveredElement:Lkotlin/jvm/functions/Function1;

    const/4 v1, 0x0

    const/4 v2, 0x1

    .line 2054
    invoke-static {v1, v2, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/InlineList;->constructor-impl$default(Ljava/lang/Object;ILkotlin/jvm/internal/DefaultConstructorMarker;)Ljava/lang/Object;

    move-result-object v3

    .line 2057
    :cond_0
    sget v4, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->SEGMENT_SIZE:I

    sub-int/2addr v4, v2

    :goto_0
    const/4 v5, -0x1

    if-ge v5, v4, :cond_b

    .line 2059
    iget-wide v6, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    sget v8, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->SEGMENT_SIZE:I

    int-to-long v8, v8

    mul-long/2addr v6, v8

    int-to-long v8, v4

    add-long/2addr v6, v8

    .line 2063
    :cond_1
    invoke-virtual {p1, v4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->getState$kotlinx_coroutines_core(I)Ljava/lang/Object;

    move-result-object v8

    .line 2066
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getDONE_RCV$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v9

    if-eq v8, v9, :cond_c

    .line 2068
    sget-object v9, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->BUFFERED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    if-ne v8, v9, :cond_3

    .line 2070
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getReceiversCounter$kotlinx_coroutines_core()J

    move-result-wide v9

    cmp-long v9, v6, v9

    if-ltz v9, :cond_c

    .line 2072
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->getCHANNEL_CLOSED()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v9

    invoke-virtual {p1, v4, v8, v9}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->casState$kotlinx_coroutines_core(ILjava/lang/Object;Ljava/lang/Object;)Z

    move-result v8

    if-eqz v8, :cond_1

    if-eqz v0, :cond_2

    .line 2075
    invoke-virtual {p1, v4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->getElement$kotlinx_coroutines_core(I)Ljava/lang/Object;

    move-result-object v5

    .line 2076
    invoke-static {v0, v5, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/OnUndeliveredElementKt;->callUndeliveredElementCatchingException(Lkotlin/jvm/functions/Function1;Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/UndeliveredElementException;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/UndeliveredElementException;

    move-result-object v1

    .line 2080
    :cond_2
    invoke-virtual {p1, v4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->cleanElement$kotlinx_coroutines_core(I)V

    .line 2081
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->onSlotCleaned()V

    goto/16 :goto_4

    .line 2086
    :cond_3
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getIN_BUFFER$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v9

    if-eq v8, v9, :cond_a

    if-nez v8, :cond_4

    goto :goto_3

    .line 2095
    :cond_4
    instance-of v9, v8, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;

    if-nez v9, :cond_7

    instance-of v9, v8, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/WaiterEB;

    if-eqz v9, :cond_5

    goto :goto_1

    .line 2119
    :cond_5
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getRESUMING_BY_EB$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v9

    if-eq v8, v9, :cond_c

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getRESUMING_BY_RCV$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v9

    if-ne v8, v9, :cond_6

    goto :goto_5

    .line 2122
    :cond_6
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getRESUMING_BY_EB$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v9

    if-eq v8, v9, :cond_1

    goto :goto_4

    .line 2097
    :cond_7
    :goto_1
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getReceiversCounter$kotlinx_coroutines_core()J

    move-result-wide v9

    cmp-long v9, v6, v9

    if-ltz v9, :cond_c

    .line 2099
    instance-of v9, v8, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/WaiterEB;

    if-eqz v9, :cond_8

    move-object v9, v8

    check-cast v9, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/WaiterEB;

    iget-object v9, v9, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/WaiterEB;->waiter:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;

    goto :goto_2

    .line 2100
    :cond_8
    move-object v9, v8

    check-cast v9, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;

    .line 2102
    :goto_2
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->getCHANNEL_CLOSED()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v10

    invoke-virtual {p1, v4, v8, v10}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->casState$kotlinx_coroutines_core(ILjava/lang/Object;Ljava/lang/Object;)Z

    move-result v8

    if-eqz v8, :cond_1

    if-eqz v0, :cond_9

    .line 2105
    invoke-virtual {p1, v4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->getElement$kotlinx_coroutines_core(I)Ljava/lang/Object;

    move-result-object v5

    .line 2106
    invoke-static {v0, v5, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/OnUndeliveredElementKt;->callUndeliveredElementCatchingException(Lkotlin/jvm/functions/Function1;Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/UndeliveredElementException;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/UndeliveredElementException;

    move-result-object v1

    .line 2109
    :cond_9
    invoke-static {v3, v9}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/InlineList;->plus-FjFbRPM(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v3

    .line 2112
    invoke-virtual {p1, v4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->cleanElement$kotlinx_coroutines_core(I)V

    .line 2113
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->onSlotCleaned()V

    goto :goto_4

    .line 2088
    :cond_a
    :goto_3
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->getCHANNEL_CLOSED()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v9

    invoke-virtual {p1, v4, v8, v9}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->casState$kotlinx_coroutines_core(ILjava/lang/Object;Ljava/lang/Object;)Z

    move-result v8

    if-eqz v8, :cond_1

    .line 2090
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->onSlotCleaned()V

    :goto_4
    add-int/lit8 v4, v4, -0x1

    goto/16 :goto_0

    .line 2128
    :cond_b
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->getPrev()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    if-nez p1, :cond_0

    :cond_c
    :goto_5
    if-eqz v3, :cond_e

    .line 4181
    instance-of p1, v3, Ljava/util/ArrayList;

    if-nez p1, :cond_d

    check-cast v3, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;

    .line 2131
    invoke-direct {p0, v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->resumeSenderOnCancelledChannel(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;)V

    goto :goto_7

    .line 4183
    :cond_d
    const-string p1, "null cannot be cast to non-null type java.util.ArrayList<E of kotlinx.coroutines.internal.InlineList>"

    invoke-static {v3, p1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast v3, Ljava/util/ArrayList;

    .line 4184
    invoke-virtual {v3}, Ljava/util/ArrayList;->size()I

    move-result p1

    sub-int/2addr p1, v2

    :goto_6
    if-ge v5, p1, :cond_e

    .line 4185
    invoke-virtual {v3, p1}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;

    .line 2131
    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->resumeSenderOnCancelledChannel(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;)V

    add-int/lit8 p1, p1, -0x1

    goto :goto_6

    :cond_e
    :goto_7
    if-nez v1, :cond_f

    return-void

    .line 2133
    :cond_f
    throw v1
.end method

.method private final resumeReceiverOnClosedChannel(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;)V
    .locals 1

    const/4 v0, 0x1

    .line 2193
    invoke-direct {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->resumeWaiterOnClosedChannel(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;Z)V

    return-void
.end method

.method private final resumeSenderOnCancelledChannel(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;)V
    .locals 1

    const/4 v0, 0x0

    .line 2199
    invoke-direct {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->resumeWaiterOnClosedChannel(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;Z)V

    return-void
.end method

.method private final resumeWaiterOnClosedChannel(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;Z)V
    .locals 2

    .line 2204
    instance-of v0, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;

    if-eqz v0, :cond_1

    check-cast p1, Lkotlin/coroutines/Continuation;

    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/Result$Companion;

    if-eqz p2, :cond_0

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getReceiveException()Ljava/lang/Throwable;

    move-result-object p2

    goto :goto_0

    :cond_0
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendException()Ljava/lang/Throwable;

    move-result-object p2

    :goto_0
    invoke-static {p2}, Lcom/scanflow/datacapture/barinternal/kotlin/ResultKt;->createFailure(Ljava/lang/Throwable;)Ljava/lang/Object;

    move-result-object p2

    invoke-static {p2}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->constructor-impl(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p2

    invoke-interface {p1, p2}, Lkotlin/coroutines/Continuation;->resumeWith(Ljava/lang/Object;)V

    return-void

    .line 2205
    :cond_1
    instance-of p2, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ReceiveCatching;

    if-eqz p2, :cond_2

    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ReceiveCatching;

    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ReceiveCatching;->cont:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    sget-object p2, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/Result$Companion;

    sget-object p2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;->Companion:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getCloseCause()Ljava/lang/Throwable;

    move-result-object v0

    invoke-virtual {p2, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;->closed-JP2dKIU(Ljava/lang/Throwable;)Ljava/lang/Object;

    move-result-object p2

    invoke-static {p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;->box-impl(Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;

    move-result-object p2

    invoke-static {p2}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->constructor-impl(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p2

    invoke-interface {p1, p2}, Lkotlin/coroutines/Continuation;->resumeWith(Ljava/lang/Object;)V

    return-void

    .line 2206
    :cond_2
    instance-of p2, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;

    if-eqz p2, :cond_3

    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;->tryResumeHasNextOnClosedChannel()V

    return-void

    .line 2207
    :cond_3
    new-instance p2, Ljava/lang/IllegalStateException;

    .line 2208
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "Unexpected waiter: "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-virtual {p1}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {p2, p1}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw p2
.end method

.method static synthetic send$suspendImpl(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;
    .locals 13

    .line 110
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$getSendSegment$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    .line 3119
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    .line 3120
    :cond_0
    :goto_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$getSendersAndCloseStatus$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v1

    .line 3123
    invoke-virtual {v1, p0}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->getAndIncrement(Ljava/lang/Object;)J

    move-result-wide v1

    const-wide v3, 0xfffffffffffffffL

    and-long v9, v1, v3

    .line 3126
    invoke-static {p0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$isClosedForSend0(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;J)Z

    move-result v12

    .line 3128
    sget v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->SEGMENT_SIZE:I

    int-to-long v2, v1

    div-long v2, v9, v2

    int-to-long v4, v1

    .line 3129
    rem-long v4, v9, v4

    long-to-int v7, v4

    .line 3132
    iget-wide v4, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    cmp-long v1, v4, v2

    if-eqz v1, :cond_2

    .line 3134
    invoke-static {p0, v2, v3, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$findSegmentSend(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    move-result-object v1

    if-nez v1, :cond_1

    if-eqz v12, :cond_0

    .line 123
    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->onClosedSend(Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;

    move-result-object p0

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->getCOROUTINE_SUSPENDED()Ljava/lang/Object;

    move-result-object p1

    if-ne p0, p1, :cond_9

    return-object p0

    :cond_1
    move-object v6, v1

    goto :goto_1

    :cond_2
    move-object v6, v0

    :goto_1
    const/4 v11, 0x0

    move-object v5, p0

    move-object v8, p1

    .line 3150
    invoke-static/range {v5 .. v12}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$updateCellSend(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;ILjava/lang/Object;JLjava/lang/Object;Z)I

    move-result p0

    if-eqz p0, :cond_8

    const/4 p1, 0x1

    if-eq p0, p1, :cond_9

    const/4 p1, 0x2

    if-eq p0, p1, :cond_7

    const/4 p1, 0x3

    if-eq p0, p1, :cond_6

    const/4 p1, 0x4

    if-eq p0, p1, :cond_4

    const/4 p1, 0x5

    if-eq p0, p1, :cond_3

    goto :goto_2

    .line 3187
    :cond_3
    invoke-virtual {v6}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->cleanPrev()V

    :goto_2
    move-object p0, v5

    move-object v0, v6

    move-object p1, v8

    goto :goto_0

    .line 3180
    :cond_4
    invoke-virtual {v5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getReceiversCounter$kotlinx_coroutines_core()J

    move-result-wide p0

    cmp-long p0, v9, p0

    if-gez p0, :cond_5

    invoke-virtual {v6}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->cleanPrev()V

    .line 123
    :cond_5
    invoke-direct {v5, v8, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->onClosedSend(Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;

    move-result-object p0

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->getCOROUTINE_SUSPENDED()Ljava/lang/Object;

    move-result-object p1

    if-ne p0, p1, :cond_9

    return-object p0

    :cond_6
    move-object v11, p2

    .line 127
    invoke-direct/range {v5 .. v11}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->sendOnNoWaiterSuspend(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;ILjava/lang/Object;JLkotlin/coroutines/Continuation;)Ljava/lang/Object;

    move-result-object p0

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->getCOROUTINE_SUSPENDED()Ljava/lang/Object;

    move-result-object p1

    if-ne p0, p1, :cond_9

    return-object p0

    :cond_7
    move-object v11, p2

    if-eqz v12, :cond_9

    .line 3169
    invoke-virtual {v6}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->onSlotCleaned()V

    .line 123
    invoke-direct {v5, v8, v11}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->onClosedSend(Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;

    move-result-object p0

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->getCOROUTINE_SUSPENDED()Ljava/lang/Object;

    move-result-object p1

    if-ne p0, p1, :cond_9

    return-object p0

    .line 3156
    :cond_8
    invoke-virtual {v6}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->cleanPrev()V

    .line 3193
    :cond_9
    sget-object p0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    return-object p0
.end method

.method private final sendOnNoWaiterSuspend(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;ILjava/lang/Object;JLkotlin/coroutines/Continuation;)Ljava/lang/Object;
    .locals 16

    .line 3214
    invoke-static/range {p6 .. p6}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->intercepted(Lkotlin/coroutines/Continuation;)Lkotlin/coroutines/Continuation;

    move-result-object v0

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationKt;->getOrCreateCancellableContinuation(Lkotlin/coroutines/Continuation;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    move-result-object v7

    const/4 v8, 0x0

    move-object/from16 v1, p0

    move-object/from16 v2, p1

    move/from16 v3, p2

    move-object/from16 v4, p3

    move-wide/from16 v5, p4

    .line 3217
    :try_start_0
    invoke-static/range {v1 .. v8}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$updateCellSend(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;ILjava/lang/Object;JLjava/lang/Object;Z)I

    move-result v0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    if-eqz v0, :cond_10

    const/4 v9, 0x1

    if-eq v0, v9, :cond_f

    const/4 v10, 0x2

    if-eq v0, v10, :cond_e

    const/4 v11, 0x4

    if-eq v0, v11, :cond_d

    const-string v12, "unexpected"

    const/4 v13, 0x5

    if-ne v0, v13, :cond_c

    .line 3233
    :try_start_1
    invoke-virtual/range {p1 .. p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->cleanPrev()V

    .line 3235
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$getSendSegment$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    .line 3240
    invoke-virtual {v0, v1}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    .line 3241
    :goto_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$getSendersAndCloseStatus$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v2

    .line 3244
    invoke-virtual {v2, v1}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->getAndIncrement(Ljava/lang/Object;)J

    move-result-wide v2

    const-wide v5, 0xfffffffffffffffL

    and-long/2addr v5, v2

    .line 3247
    invoke-static {v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$isClosedForSend0(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;J)Z

    move-result v8

    .line 3249
    sget v2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->SEGMENT_SIZE:I

    int-to-long v14, v2

    div-long v14, v5, v14

    int-to-long v2, v2

    .line 3250
    rem-long v2, v5, v2

    long-to-int v3, v2

    move-object/from16 p4, v12

    .line 3253
    iget-wide v11, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    cmp-long v2, v11, v14

    if-eqz v2, :cond_2

    .line 3255
    invoke-static {v1, v14, v15, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$findSegmentSend(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    move-result-object v2

    if-nez v2, :cond_3

    if-eqz v8, :cond_1

    .line 162
    :cond_0
    :goto_1
    invoke-static {v1, v4, v7}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$onClosedSendOnNoWaiterSuspend(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;)V

    goto/16 :goto_5

    :catchall_0
    move-exception v0

    goto/16 :goto_6

    :cond_1
    move-object/from16 v12, p4

    const/4 v11, 0x4

    goto :goto_0

    :cond_2
    move-object v2, v0

    .line 3271
    :cond_3
    invoke-static/range {v1 .. v8}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$updateCellSend(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;ILjava/lang/Object;JLjava/lang/Object;Z)I

    move-result v0

    if-eqz v0, :cond_b

    if-eq v0, v9, :cond_a

    if-eq v0, v10, :cond_7

    const/4 v3, 0x3

    if-eq v0, v3, :cond_6

    const/4 v3, 0x4

    if-eq v0, v3, :cond_5

    if-eq v0, v13, :cond_4

    goto :goto_2

    .line 3303
    :cond_4
    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->cleanPrev()V

    :goto_2
    move-object/from16 v12, p4

    move-object v0, v2

    move v11, v3

    goto :goto_0

    .line 3296
    :cond_5
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getReceiversCounter$kotlinx_coroutines_core()J

    move-result-wide v8

    cmp-long v0, v5, v8

    if-gez v0, :cond_0

    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->cleanPrev()V

    goto :goto_1

    .line 3309
    :cond_6
    new-instance v0, Ljava/lang/IllegalStateException;

    move-object/from16 v2, p4

    .line 3310
    invoke-direct {v0, v2}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw v0

    :cond_7
    if-eqz v8, :cond_8

    .line 3290
    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->onSlotCleaned()V

    goto :goto_1

    :cond_8
    if-eqz v7, :cond_9

    move-object v0, v7

    goto :goto_3

    :cond_9
    const/4 v0, 0x0

    :goto_3
    if-eqz v0, :cond_11

    .line 3293
    invoke-static {v1, v0, v2, v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$prepareSenderForSuspension(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;I)V

    goto :goto_5

    .line 159
    :cond_a
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/Result$Companion;

    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->constructor-impl(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    :goto_4
    invoke-interface {v7, v0}, Lkotlin/coroutines/Continuation;->resumeWith(Ljava/lang/Object;)V

    goto :goto_5

    .line 3277
    :cond_b
    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->cleanPrev()V

    .line 159
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/Result$Companion;

    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->constructor-impl(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    goto :goto_4

    :cond_c
    move-object v2, v12

    .line 3310
    new-instance v0, Ljava/lang/IllegalStateException;

    .line 3311
    invoke-direct {v0, v2}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 3229
    :cond_d
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getReceiversCounter$kotlinx_coroutines_core()J

    move-result-wide v2

    cmp-long v0, p4, v2

    if-gez v0, :cond_0

    invoke-virtual/range {p1 .. p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->cleanPrev()V

    goto :goto_1

    :cond_e
    move-object/from16 v2, p1

    move/from16 v3, p2

    .line 3226
    invoke-static {v1, v7, v2, v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$prepareSenderForSuspension(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;I)V

    goto :goto_5

    .line 159
    :cond_f
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/Result$Companion;

    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->constructor-impl(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    goto :goto_4

    :cond_10
    move-object/from16 v2, p1

    .line 3219
    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->cleanPrev()V

    .line 159
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/Result$Companion;

    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->constructor-impl(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    goto :goto_4

    .line 3320
    :cond_11
    :goto_5
    invoke-virtual {v7}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->getResult()Ljava/lang/Object;

    move-result-object v0

    .line 3213
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->getCOROUTINE_SUSPENDED()Ljava/lang/Object;

    move-result-object v2

    if-ne v0, v2, :cond_12

    invoke-static/range {p6 .. p6}, Lkotlin/coroutines/jvm/internal/DebugProbesKt;->probeCoroutineSuspended(Lkotlin/coroutines/Continuation;)V

    :cond_12
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->getCOROUTINE_SUSPENDED()Ljava/lang/Object;

    move-result-object v2

    if-ne v0, v2, :cond_13

    return-object v0

    .line 3321
    :cond_13
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    return-object v0

    .line 3317
    :goto_6
    invoke-virtual {v7}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;->releaseClaimedReusableContinuation$kotlinx_coroutines_core()V

    .line 3318
    throw v0
.end method

.method private final shouldSendSuspend(J)Z
    .locals 2

    .line 624
    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->isClosedForSend0(J)Z

    move-result v0

    if-eqz v0, :cond_0

    const/4 p1, 0x0

    return p1

    :cond_0
    const-wide v0, 0xfffffffffffffffL

    and-long/2addr p1, v0

    .line 626
    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->bufferOrRendezvousSend(J)Z

    move-result p1

    xor-int/lit8 p1, p1, 0x1

    return p1
.end method

.method private final tryResumeReceiver(Ljava/lang/Object;Ljava/lang/Object;)Z
    .locals 2

    .line 656
    instance-of v0, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ReceiveCatching;

    const/4 v1, 0x0

    if-eqz v0, :cond_1

    .line 657
    const-string v0, "null cannot be cast to non-null type kotlinx.coroutines.channels.ReceiveCatching<E of kotlinx.coroutines.channels.BufferedChannel>"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ReceiveCatching;

    .line 658
    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ReceiveCatching;->cont:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImpl;

    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;->Companion:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;

    invoke-virtual {v0, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;->success-JP2dKIU(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p2

    invoke-static {p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;->box-impl(Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;

    move-result-object p2

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->onUndeliveredElement:Lkotlin/jvm/functions/Function1;

    if-eqz v0, :cond_0

    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->bindCancellationFunResult(Lkotlin/jvm/functions/Function1;)Lkotlin/reflect/KFunction;

    move-result-object v1

    :cond_0
    check-cast v1, Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;

    invoke-static {p1, p2, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$tryResume0(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;)Z

    move-result p1

    return p1

    .line 660
    :cond_1
    instance-of v0, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;

    if-eqz v0, :cond_2

    .line 661
    const-string v0, "null cannot be cast to non-null type kotlinx.coroutines.channels.BufferedChannel.BufferedChannelIterator<E of kotlinx.coroutines.channels.BufferedChannel>"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;

    .line 662
    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;->tryResumeHasNext(Ljava/lang/Object;)Z

    move-result p1

    return p1

    .line 664
    :cond_2
    instance-of v0, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;

    if-eqz v0, :cond_4

    .line 665
    const-string v0, "null cannot be cast to non-null type kotlinx.coroutines.CancellableContinuation<E of kotlinx.coroutines.channels.BufferedChannel>"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;

    .line 666
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->onUndeliveredElement:Lkotlin/jvm/functions/Function1;

    if-eqz v0, :cond_3

    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->bindCancellationFun(Lkotlin/jvm/functions/Function1;)Lkotlin/reflect/KFunction;

    move-result-object v1

    :cond_3
    check-cast v1, Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;

    invoke-static {p1, p2, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$tryResume0(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;)Z

    move-result p1

    return p1

    :cond_4
    new-instance p2, Ljava/lang/IllegalStateException;

    .line 668
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "Unexpected receiver type: "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-virtual {p1}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {p2, p1}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw p2
.end method

.method private final tryResumeSender(Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;I)Z
    .locals 1

    .line 1168
    instance-of p2, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;

    if-eqz p2, :cond_0

    .line 1170
    const-string p2, "null cannot be cast to non-null type kotlinx.coroutines.CancellableContinuation<kotlin.Unit>"

    invoke-static {p1, p2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;

    .line 1171
    sget-object p2, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    const/4 p3, 0x2

    const/4 v0, 0x0

    invoke-static {p1, p2, v0, p3, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->tryResume0$default(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;ILjava/lang/Object;)Z

    move-result p1

    return p1

    .line 1182
    :cond_0
    new-instance p2, Ljava/lang/IllegalStateException;

    .line 1183
    new-instance p3, Ljava/lang/StringBuilder;

    invoke-direct {p3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v0, "Unexpected waiter: "

    invoke-virtual {p3, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p3, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {p3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-virtual {p1}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {p2, p1}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw p2
.end method

.method private final updateCellExpandBuffer(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;IJ)Z
    .locals 3

    .line 1265
    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->getState$kotlinx_coroutines_core(I)Ljava/lang/Object;

    move-result-object v0

    .line 1266
    instance-of v1, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;

    if-eqz v1, :cond_1

    .line 1274
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getReceivers$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v1

    invoke-virtual {v1, p0}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->get(Ljava/lang/Object;)J

    move-result-wide v1

    cmp-long v1, p3, v1

    if-ltz v1, :cond_1

    .line 1280
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getRESUMING_BY_EB$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v1

    invoke-virtual {p1, p2, v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->casState$kotlinx_coroutines_core(ILjava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_1

    .line 1281
    invoke-direct {p0, v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->tryResumeSender(Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;I)Z

    move-result p3

    if-eqz p3, :cond_0

    .line 1284
    sget-object p3, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->BUFFERED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    invoke-virtual {p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->setState$kotlinx_coroutines_core(ILjava/lang/Object;)V

    const/4 p1, 0x1

    return p1

    .line 1288
    :cond_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getINTERRUPTED_SEND$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p3

    invoke-virtual {p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->setState$kotlinx_coroutines_core(ILjava/lang/Object;)V

    const/4 p3, 0x0

    .line 1289
    invoke-virtual {p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->onCancelledRequest(IZ)V

    return p3

    .line 1295
    :cond_1
    invoke-direct {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->updateCellExpandBufferSlow(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;IJ)Z

    move-result p1

    return p1
.end method

.method private final updateCellExpandBufferSlow(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;IJ)Z
    .locals 6

    .line 1311
    :cond_0
    :goto_0
    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->getState$kotlinx_coroutines_core(I)Ljava/lang/Object;

    move-result-object v0

    .line 1314
    instance-of v1, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;

    const/4 v2, 0x0

    const/4 v3, 0x1

    if-eqz v1, :cond_3

    .line 1322
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getReceivers$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v1

    invoke-virtual {v1, p0}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->get(Ljava/lang/Object;)J

    move-result-wide v4

    cmp-long v1, p3, v4

    if-gez v1, :cond_1

    .line 1333
    new-instance v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/WaiterEB;

    move-object v2, v0

    check-cast v2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;

    invoke-direct {v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/WaiterEB;-><init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;)V

    invoke-virtual {p1, p2, v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->casState$kotlinx_coroutines_core(ILjava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    return v3

    .line 1341
    :cond_1
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getRESUMING_BY_EB$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v1

    invoke-virtual {p1, p2, v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->casState$kotlinx_coroutines_core(ILjava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_0

    .line 1342
    invoke-direct {p0, v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->tryResumeSender(Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;I)Z

    move-result p3

    if-eqz p3, :cond_2

    .line 1345
    sget-object p3, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->BUFFERED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    invoke-virtual {p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->setState$kotlinx_coroutines_core(ILjava/lang/Object;)V

    return v3

    .line 1349
    :cond_2
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getINTERRUPTED_SEND$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p3

    invoke-virtual {p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->setState$kotlinx_coroutines_core(ILjava/lang/Object;)V

    .line 1350
    invoke-virtual {p1, p2, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->onCancelledRequest(IZ)V

    return v2

    .line 1357
    :cond_3
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getINTERRUPTED_SEND$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v1

    if-ne v0, v1, :cond_4

    return v2

    :cond_4
    if-nez v0, :cond_5

    .line 1363
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getIN_BUFFER$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v1

    invoke-virtual {p1, p2, v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->casState$kotlinx_coroutines_core(ILjava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    return v3

    .line 1366
    :cond_5
    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->BUFFERED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    if-ne v0, v1, :cond_6

    return v3

    .line 1368
    :cond_6
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getPOISONED$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v1

    if-eq v0, v1, :cond_a

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getDONE_RCV$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v1

    if-eq v0, v1, :cond_a

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getINTERRUPTED_RCV$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v1

    if-ne v0, v1, :cond_7

    goto :goto_1

    .line 1371
    :cond_7
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->getCHANNEL_CLOSED()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v1

    if-ne v0, v1, :cond_8

    return v3

    .line 1375
    :cond_8
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getRESUMING_BY_RCV$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v1

    if-ne v0, v1, :cond_9

    goto :goto_0

    :cond_9
    new-instance p1, Ljava/lang/IllegalStateException;

    .line 1376
    new-instance p2, Ljava/lang/StringBuilder;

    invoke-direct {p2}, Ljava/lang/StringBuilder;-><init>()V

    const-string p3, "Unexpected cell state: "

    invoke-virtual {p2, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {p2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p2

    invoke-virtual {p2}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object p2

    invoke-direct {p1, p2}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw p1

    :cond_a
    :goto_1
    return v3
.end method

.method private final updateCellReceive(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;IJLjava/lang/Object;)Ljava/lang/Object;
    .locals 6

    .line 1019
    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->getState$kotlinx_coroutines_core(I)Ljava/lang/Object;

    move-result-object v0

    if-nez v0, :cond_2

    .line 1022
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendersAndCloseStatus$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v1

    .line 1027
    invoke-virtual {v1, p0}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->get(Ljava/lang/Object;)J

    move-result-wide v1

    const-wide v3, 0xfffffffffffffffL

    and-long/2addr v1, v3

    cmp-long v1, p3, v1

    if-ltz v1, :cond_1

    if-nez p5, :cond_0

    .line 1033
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getSUSPEND_NO_WAITER$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p1

    return-object p1

    .line 1036
    :cond_0
    invoke-virtual {p1, p2, v0, p5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->casState$kotlinx_coroutines_core(ILjava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_1

    .line 1039
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->expandBuffer()V

    .line 1040
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getSUSPEND$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p1

    return-object p1

    :cond_1
    move-object v0, p0

    move-object v1, p1

    move v2, p2

    move-wide v3, p3

    move-object v5, p5

    goto :goto_0

    .line 1045
    :cond_2
    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->BUFFERED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    if-ne v0, v1, :cond_1

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getDONE_RCV$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v1

    invoke-virtual {p1, p2, v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->casState$kotlinx_coroutines_core(ILjava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_1

    .line 1047
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->expandBuffer()V

    .line 1048
    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->retrieveElement$kotlinx_coroutines_core(I)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 1051
    :goto_0
    invoke-direct/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->updateCellReceiveSlow(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;IJLjava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method

.method private final updateCellReceiveSlow(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;IJLjava/lang/Object;)Ljava/lang/Object;
    .locals 5

    .line 1068
    :cond_0
    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->getState$kotlinx_coroutines_core(I)Ljava/lang/Object;

    move-result-object v0

    if-eqz v0, :cond_9

    .line 1071
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getIN_BUFFER$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v1

    if-ne v0, v1, :cond_1

    goto/16 :goto_0

    .line 1105
    :cond_1
    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->BUFFERED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    if-ne v0, v1, :cond_2

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getDONE_RCV$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v1

    invoke-virtual {p1, p2, v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->casState$kotlinx_coroutines_core(ILjava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 1107
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->expandBuffer()V

    .line 1108
    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->retrieveElement$kotlinx_coroutines_core(I)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 1111
    :cond_2
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getINTERRUPTED_SEND$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v1

    if-ne v0, v1, :cond_3

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getFAILED$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p1

    return-object p1

    .line 1114
    :cond_3
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getPOISONED$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v1

    if-ne v0, v1, :cond_4

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getFAILED$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p1

    return-object p1

    .line 1116
    :cond_4
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->getCHANNEL_CLOSED()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v1

    if-ne v0, v1, :cond_5

    .line 1120
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->expandBuffer()V

    .line 1121
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getFAILED$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p1

    return-object p1

    .line 1128
    :cond_5
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getRESUMING_BY_EB$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v1

    if-eq v0, v1, :cond_0

    .line 1135
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getRESUMING_BY_RCV$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v1

    invoke-virtual {p1, p2, v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->casState$kotlinx_coroutines_core(ILjava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_0

    .line 1137
    instance-of p3, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/WaiterEB;

    if-eqz p3, :cond_6

    .line 1139
    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/WaiterEB;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/WaiterEB;->waiter:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;

    .line 1140
    :cond_6
    invoke-direct {p0, v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->tryResumeSender(Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;I)Z

    move-result p4

    if-eqz p4, :cond_7

    .line 1148
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getDONE_RCV$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p3

    invoke-virtual {p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->setState$kotlinx_coroutines_core(ILjava/lang/Object;)V

    .line 1149
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->expandBuffer()V

    .line 1150
    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->retrieveElement$kotlinx_coroutines_core(I)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 1156
    :cond_7
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getINTERRUPTED_SEND$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p4

    invoke-virtual {p1, p2, p4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->setState$kotlinx_coroutines_core(ILjava/lang/Object;)V

    const/4 p4, 0x0

    .line 1157
    invoke-virtual {p1, p2, p4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->onCancelledRequest(IZ)V

    if-eqz p3, :cond_8

    .line 1158
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->expandBuffer()V

    .line 1159
    :cond_8
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getFAILED$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p1

    return-object p1

    .line 1071
    :cond_9
    :goto_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendersAndCloseStatus$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v1

    .line 1076
    invoke-virtual {v1, p0}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->get(Ljava/lang/Object;)J

    move-result-wide v1

    const-wide v3, 0xfffffffffffffffL

    and-long/2addr v1, v3

    cmp-long v1, p3, v1

    if-gez v1, :cond_a

    .line 1081
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getPOISONED$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v1

    invoke-virtual {p1, p2, v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->casState$kotlinx_coroutines_core(ILjava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 1085
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->expandBuffer()V

    .line 1086
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getFAILED$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p1

    return-object p1

    :cond_a
    if-nez p5, :cond_b

    .line 1093
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getSUSPEND_NO_WAITER$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p1

    return-object p1

    .line 1096
    :cond_b
    invoke-virtual {p1, p2, v0, p5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->casState$kotlinx_coroutines_core(ILjava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 1099
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->expandBuffer()V

    .line 1100
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getSUSPEND$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p1

    return-object p1
.end method

.method private final updateCellSend(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;ILjava/lang/Object;JLjava/lang/Object;Z)I
    .locals 4

    .line 442
    invoke-virtual {p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->storeElement$kotlinx_coroutines_core(ILjava/lang/Object;)V

    if-eqz p7, :cond_0

    .line 443
    invoke-direct/range {p0 .. p7}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->updateCellSendSlow(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;ILjava/lang/Object;JLjava/lang/Object;Z)I

    move-result p1

    move-object p2, p0

    return p1

    :cond_0
    move v0, p7

    move-object p7, p6

    move-wide p5, p4

    move-object p4, p3

    move-object p3, p0

    .line 445
    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->getState$kotlinx_coroutines_core(I)Ljava/lang/Object;

    move-result-object v1

    const/4 v2, 0x1

    if-nez v1, :cond_4

    .line 452
    invoke-direct {p0, p5, p6}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->bufferOrRendezvousSend(J)Z

    move-result v1

    const/4 v3, 0x0

    if-eqz v1, :cond_2

    .line 454
    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->BUFFERED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    invoke-virtual {p1, p2, v3, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->casState$kotlinx_coroutines_core(ILjava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_1

    return v2

    :cond_1
    move-object p3, p4

    move-wide p4, p5

    move-object p6, p7

    move p7, v0

    goto :goto_0

    :cond_2
    if-nez p7, :cond_3

    const/4 p1, 0x3

    return p1

    .line 468
    :cond_3
    invoke-virtual {p1, p2, v3, p7}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->casState$kotlinx_coroutines_core(ILjava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_1

    const/4 p1, 0x2

    return p1

    .line 473
    :cond_4
    instance-of v3, v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;

    if-eqz v3, :cond_1

    .line 476
    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->cleanElement$kotlinx_coroutines_core(I)V

    .line 478
    invoke-direct {p0, v1, p4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->tryResumeReceiver(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result p4

    if-eqz p4, :cond_5

    .line 480
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getDONE_RCV$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p4

    invoke-virtual {p1, p2, p4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->setState$kotlinx_coroutines_core(ILjava/lang/Object;)V

    .line 481
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->onReceiveDequeued()V

    const/4 p1, 0x0

    return p1

    .line 488
    :cond_5
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getINTERRUPTED_RCV$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p4

    invoke-virtual {p1, p2, p4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->getAndSetState$kotlinx_coroutines_core(ILjava/lang/Object;)Ljava/lang/Object;

    move-result-object p4

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getINTERRUPTED_RCV$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p5

    if-eq p4, p5, :cond_6

    .line 489
    invoke-virtual {p1, p2, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->onCancelledRequest(IZ)V

    :cond_6
    const/4 p1, 0x5

    return p1

    .line 495
    :goto_0
    invoke-direct/range {p0 .. p7}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->updateCellSendSlow(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;ILjava/lang/Object;JLjava/lang/Object;Z)I

    move-result p1

    return p1
.end method

.method private final updateCellSendSlow(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;ILjava/lang/Object;JLjava/lang/Object;Z)I
    .locals 5

    .line 519
    :cond_0
    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->getState$kotlinx_coroutines_core(I)Ljava/lang/Object;

    move-result-object v0

    const/4 v1, 0x4

    const/4 v2, 0x0

    const/4 v3, 0x1

    if-nez v0, :cond_4

    .line 526
    invoke-direct {p0, p4, p5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->bufferOrRendezvousSend(J)Z

    move-result v0

    const/4 v4, 0x0

    if-eqz v0, :cond_1

    if-nez p7, :cond_1

    .line 528
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->BUFFERED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    invoke-virtual {p1, p2, v4, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->casState$kotlinx_coroutines_core(ILjava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    return v3

    :cond_1
    if-eqz p7, :cond_2

    .line 539
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getINTERRUPTED_SEND$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v0

    invoke-virtual {p1, p2, v4, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->casState$kotlinx_coroutines_core(ILjava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 540
    invoke-virtual {p1, p2, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->onCancelledRequest(IZ)V

    return v1

    :cond_2
    if-nez p6, :cond_3

    const/4 p1, 0x3

    return p1

    .line 546
    :cond_3
    invoke-virtual {p1, p2, v4, p6}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->casState$kotlinx_coroutines_core(ILjava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    const/4 p1, 0x2

    return p1

    .line 551
    :cond_4
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getIN_BUFFER$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v4

    if-ne v0, v4, :cond_5

    .line 553
    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->BUFFERED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    invoke-virtual {p1, p2, v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->casState$kotlinx_coroutines_core(ILjava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    return v3

    .line 559
    :cond_5
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getINTERRUPTED_RCV$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p4

    const/4 p5, 0x5

    if-ne v0, p4, :cond_6

    .line 561
    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->cleanElement$kotlinx_coroutines_core(I)V

    return p5

    .line 565
    :cond_6
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getPOISONED$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p4

    if-ne v0, p4, :cond_7

    .line 567
    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->cleanElement$kotlinx_coroutines_core(I)V

    return p5

    .line 571
    :cond_7
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->getCHANNEL_CLOSED()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p4

    if-ne v0, p4, :cond_8

    .line 575
    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->cleanElement$kotlinx_coroutines_core(I)V

    .line 576
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->completeCloseOrCancel()V

    return v1

    .line 584
    :cond_8
    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->cleanElement$kotlinx_coroutines_core(I)V

    .line 588
    instance-of p4, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/WaiterEB;

    if-eqz p4, :cond_9

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/WaiterEB;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/WaiterEB;->waiter:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;

    .line 590
    :cond_9
    invoke-direct {p0, v0, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->tryResumeReceiver(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result p3

    if-eqz p3, :cond_a

    .line 592
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getDONE_RCV$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p3

    invoke-virtual {p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->setState$kotlinx_coroutines_core(ILjava/lang/Object;)V

    .line 593
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->onReceiveDequeued()V

    return v2

    .line 600
    :cond_a
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getINTERRUPTED_RCV$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p3

    invoke-virtual {p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->getAndSetState$kotlinx_coroutines_core(ILjava/lang/Object;)Ljava/lang/Object;

    move-result-object p3

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getINTERRUPTED_RCV$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p4

    if-eq p3, p4, :cond_b

    .line 601
    invoke-virtual {p1, p2, v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->onCancelledRequest(IZ)V

    :cond_b
    return p5
.end method

.method private final updateReceiversCounterIfLower(J)V
    .locals 7

    .line 2585
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getReceivers$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v0

    :goto_0
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->get(Ljava/lang/Object;)J

    move-result-wide v3

    cmp-long v1, v3, p1

    if-ltz v1, :cond_0

    goto :goto_1

    .line 2588
    :cond_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getReceivers$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v1

    move-object v2, p0

    move-wide v5, p1

    invoke-virtual/range {v1 .. v6}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->compareAndSet(Ljava/lang/Object;JJ)Z

    move-result p1

    if-eqz p1, :cond_1

    :goto_1
    return-void

    :cond_1
    move-wide p1, v5

    goto :goto_0
.end method

.method private final updateSendersCounterIfLower(J)V
    .locals 7

    .line 2570
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendersAndCloseStatus$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v0

    :cond_0
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->get(Ljava/lang/Object;)J

    move-result-wide v3

    const-wide v1, 0xfffffffffffffffL

    and-long/2addr v1, v3

    cmp-long v5, v1, p1

    if-ltz v5, :cond_1

    goto :goto_0

    :cond_1
    const/16 v5, 0x3c

    shr-long v5, v3, v5

    long-to-int v5, v5

    .line 2574
    invoke-static {v1, v2, v5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$constructSendersAndCloseStatus(JI)J

    move-result-wide v5

    .line 2575
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendersAndCloseStatus$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v1

    move-object v2, p0

    invoke-virtual/range {v1 .. v6}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->compareAndSet(Ljava/lang/Object;JJ)Z

    move-result v1

    if-eqz v1, :cond_0

    :goto_0
    return-void
.end method


# virtual methods
.method public final cancel(Ljava/util/concurrent/CancellationException;)V
    .locals 0

    .line 1795
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->cancelImpl$kotlinx_coroutines_core(Ljava/lang/Throwable;)Z

    return-void
.end method

.method public cancelImpl$kotlinx_coroutines_core(Ljava/lang/Throwable;)Z
    .locals 1

    if-nez p1, :cond_0

    .line 1798
    new-instance p1, Ljava/util/concurrent/CancellationException;

    const-string v0, "Channel was cancelled"

    invoke-direct {p1, v0}, Ljava/util/concurrent/CancellationException;-><init>(Ljava/lang/String;)V

    :cond_0
    const/4 v0, 0x1

    invoke-virtual {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->closeOrCancelImpl(Ljava/lang/Throwable;Z)Z

    move-result p1

    return p1
.end method

.method public close(Ljava/lang/Throwable;)Z
    .locals 1

    const/4 v0, 0x0

    .line 1787
    invoke-virtual {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->closeOrCancelImpl(Ljava/lang/Throwable;Z)Z

    move-result p1

    return p1
.end method

.method protected closeOrCancelImpl(Ljava/lang/Throwable;Z)Z
    .locals 2

    if-eqz p2, :cond_0

    .line 1821
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->markCancellationStarted()V

    :cond_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->get_closeCause$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    .line 1824
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getNO_CLOSE_CAUSE$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v1

    invoke-static {v0, p0, v1, p1}, Landroidx/concurrent/futures/AbstractResolvableFuture$SafeAtomicHelper$$ExternalSyntheticBackportWithForwarding0;->m(Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result p1

    if-eqz p2, :cond_1

    .line 1826
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->markCancelled()V

    goto :goto_0

    :cond_1
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->markClosed()V

    .line 1828
    :goto_0
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->completeCloseOrCancel()V

    .line 1832
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->onClosedIdempotent()V

    if-eqz p1, :cond_2

    .line 1833
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->invokeCloseHandler()V

    :cond_2
    return p1
.end method

.method protected final dropFirstElementUntilTheSpecifiedCellIsInTheBuffer(J)V
    .locals 10

    .line 827
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getReceiveSegment$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    .line 830
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    .line 831
    :cond_0
    :goto_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getReceivers$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v1

    .line 834
    invoke-virtual {v1, p0}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->get(Ljava/lang/Object;)J

    move-result-wide v4

    .line 835
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->capacity:I

    int-to-long v1, v1

    add-long/2addr v1, v4

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getBufferEndCounter()J

    move-result-wide v6

    invoke-static {v1, v2, v6, v7}, Ljava/lang/Math;->max(JJ)J

    move-result-wide v1

    cmp-long v1, p1, v1

    if-gez v1, :cond_1

    return-void

    .line 838
    :cond_1
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getReceivers$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v2

    const-wide/16 v6, 0x1

    add-long/2addr v6, v4

    move-object v3, p0

    invoke-virtual/range {v2 .. v7}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->compareAndSet(Ljava/lang/Object;JJ)Z

    move-result v1

    move-object v2, v3

    if-eqz v1, :cond_0

    .line 840
    sget v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->SEGMENT_SIZE:I

    int-to-long v6, v1

    div-long v6, v4, v6

    int-to-long v8, v1

    .line 841
    rem-long v8, v4, v8

    long-to-int v1, v8

    .line 844
    iget-wide v8, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    cmp-long v3, v8, v6

    if-eqz v3, :cond_2

    .line 846
    invoke-direct {p0, v6, v7, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->findSegmentReceive(JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    move-result-object v3

    if-nez v3, :cond_3

    goto :goto_0

    :cond_2
    move-object v3, v0

    :cond_3
    const/4 v7, 0x0

    move-wide v5, v4

    move v4, v1

    .line 856
    invoke-direct/range {v2 .. v7}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->updateCellReceive(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;IJLjava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    move-wide v4, v5

    .line 858
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getFAILED$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v1

    if-ne v0, v1, :cond_4

    .line 862
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendersCounter$kotlinx_coroutines_core()J

    move-result-wide v0

    cmp-long v0, v4, v0

    if-gez v0, :cond_6

    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->cleanPrev()V

    goto :goto_1

    .line 867
    :cond_4
    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->cleanPrev()V

    .line 869
    iget-object v1, v2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->onUndeliveredElement:Lkotlin/jvm/functions/Function1;

    if-eqz v1, :cond_6

    const/4 v4, 0x2

    const/4 v5, 0x0

    invoke-static {v1, v0, v5, v4, v5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/OnUndeliveredElementKt;->callUndeliveredElementCatchingException$default(Lkotlin/jvm/functions/Function1;Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/UndeliveredElementException;ILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/UndeliveredElementException;

    move-result-object v0

    if-nez v0, :cond_5

    goto :goto_1

    :cond_5
    throw v0

    :cond_6
    :goto_1
    move-object v0, v3

    goto :goto_0
.end method

.method protected final getCloseCause()Ljava/lang/Throwable;
    .locals 1

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->get_closeCause$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    .line 1756
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/Throwable;

    return-object v0
.end method

.method public final getReceiversCounter$kotlinx_coroutines_core()J
    .locals 2

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getReceivers$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v0

    .line 68
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->get(Ljava/lang/Object;)J

    move-result-wide v0

    return-wide v0
.end method

.method protected final getSendException()Ljava/lang/Throwable;
    .locals 2

    .line 1759
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getCloseCause()Ljava/lang/Throwable;

    move-result-object v0

    if-nez v0, :cond_0

    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ClosedSendChannelException;

    const-string v1, "Channel was closed"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ClosedSendChannelException;-><init>(Ljava/lang/String;)V

    :cond_0
    return-object v0
.end method

.method public final getSendersCounter$kotlinx_coroutines_core()J
    .locals 4

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendersAndCloseStatus$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v0

    .line 67
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->get(Ljava/lang/Object;)J

    move-result-wide v0

    const-wide v2, 0xfffffffffffffffL

    and-long/2addr v0, v2

    return-wide v0
.end method

.method public final hasElements$kotlinx_coroutines_core()Z
    .locals 9

    .line 2280
    :cond_0
    :goto_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getReceiveSegment$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    .line 2282
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    .line 2284
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getReceiversCounter$kotlinx_coroutines_core()J

    move-result-wide v3

    .line 2285
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendersCounter$kotlinx_coroutines_core()J

    move-result-wide v1

    cmp-long v1, v1, v3

    const/4 v2, 0x0

    if-gtz v1, :cond_1

    return v2

    .line 2291
    :cond_1
    sget v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->SEGMENT_SIZE:I

    int-to-long v5, v1

    div-long v5, v3, v5

    .line 2292
    iget-wide v7, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    cmp-long v7, v7, v5

    if-eqz v7, :cond_2

    .line 2294
    invoke-direct {p0, v5, v6, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->findSegmentReceive(JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    move-result-object v0

    if-nez v0, :cond_2

    .line 2300
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getReceiveSegment$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    iget-wide v0, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    cmp-long v0, v0, v5

    if-gez v0, :cond_0

    return v2

    .line 2302
    :cond_2
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->cleanPrev()V

    int-to-long v1, v1

    .line 2304
    rem-long v1, v3, v1

    long-to-int v1, v1

    .line 2305
    invoke-direct {p0, v0, v1, v3, v4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->isCellNonEmpty(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;IJ)Z

    move-result v0

    if-eqz v0, :cond_3

    const/4 v0, 0x1

    return v0

    :cond_3
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getReceivers$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v1

    const-wide/16 v5, 0x1

    add-long/2addr v5, v3

    move-object v2, p0

    .line 2307
    invoke-virtual/range {v1 .. v6}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->compareAndSet(Ljava/lang/Object;JJ)Z

    goto :goto_0
.end method

.method public invokeOnClose(Lkotlin/jvm/functions/Function1;)V
    .locals 4

    .line 1861
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getCloseHandler$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    const/4 v1, 0x0

    invoke-static {v0, p0, v1, p1}, Landroidx/concurrent/futures/AbstractResolvableFuture$SafeAtomicHelper$$ExternalSyntheticBackportWithForwarding0;->m(Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    return-void

    .line 1859
    :cond_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getCloseHandler$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    :cond_1
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    .line 1872
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getCLOSE_HANDLER_CLOSED$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v2

    if-ne v1, v2, :cond_2

    .line 1876
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getCloseHandler$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v1

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getCLOSE_HANDLER_CLOSED$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v2

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getCLOSE_HANDLER_INVOKED$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v3

    invoke-static {v1, p0, v2, v3}, Landroidx/concurrent/futures/AbstractResolvableFuture$SafeAtomicHelper$$ExternalSyntheticBackportWithForwarding0;->m(Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_1

    .line 1877
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getCloseCause()Ljava/lang/Throwable;

    move-result-object v0

    invoke-interface {p1, v0}, Lkotlin/jvm/functions/Function1;->invoke(Ljava/lang/Object;)Ljava/lang/Object;

    return-void

    .line 1881
    :cond_2
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getCLOSE_HANDLER_INVOKED$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p1

    if-ne v1, p1, :cond_3

    new-instance p1, Ljava/lang/IllegalStateException;

    const-string v0, "Another handler was already registered and successfully invoked"

    invoke-direct {p1, v0}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw p1

    :cond_3
    new-instance p1, Ljava/lang/IllegalStateException;

    .line 1882
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Another handler is already registered: "

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-direct {p1, v0}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public isClosedForReceive()Z
    .locals 2

    .line 2221
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendersAndCloseStatus$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v0

    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->get(Ljava/lang/Object;)J

    move-result-wide v0

    invoke-direct {p0, v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->isClosedForReceive0(J)Z

    move-result v0

    return v0
.end method

.method public isClosedForSend()Z
    .locals 2

    .line 2214
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendersAndCloseStatus$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v0

    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->get(Ljava/lang/Object;)J

    move-result-wide v0

    invoke-direct {p0, v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->isClosedForSend0(J)Z

    move-result v0

    return v0
.end method

.method protected isConflatedDropOldest()Z
    .locals 1

    .line 1938
    const/4 v0, 0x0

    return v0
.end method

.method public iterator()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelIterator;
    .locals 1

    .line 1573
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$BufferedChannelIterator;-><init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;)V

    return-object v0
.end method

.method protected onClosedIdempotent()V
    .locals 0

    .line 1784
    return-void
.end method

.method protected onReceiveDequeued()V
    .locals 0

    .line 684
    return-void
.end method

.method protected onReceiveEnqueued()V
    .locals 0

    .line 678
    return-void
.end method

.method public receiveCatching-JP2dKIU(Lkotlin/coroutines/Continuation;)Ljava/lang/Object;
    .locals 0

    .line 0
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->receiveCatching-JP2dKIU$suspendImpl(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method

.method public send(Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;
    .locals 0

    .line 0
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->send$suspendImpl(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method

.method public toString()Ljava/lang/String;
    .locals 17

    move-object/from16 v0, p0

    .line 2597
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendersAndCloseStatus$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v2

    .line 2599
    invoke-virtual {v2, v0}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->get(Ljava/lang/Object;)J

    move-result-wide v2

    const/16 v4, 0x3c

    shr-long/2addr v2, v4

    long-to-int v2, v2

    const/4 v3, 0x3

    const/4 v4, 0x2

    if-eq v2, v4, :cond_1

    if-eq v2, v3, :cond_0

    goto :goto_0

    .line 2601
    :cond_0
    const-string v2, "cancelled,"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    goto :goto_0

    .line 2600
    :cond_1
    const-string v2, "closed,"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 2604
    :goto_0
    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "capacity="

    invoke-virtual {v2, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget v5, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->capacity:I

    invoke-virtual {v2, v5}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const/16 v5, 0x2c

    invoke-virtual {v2, v5}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 2606
    const-string v2, "data=["

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 2607
    new-array v2, v3, [Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getReceiveSegment$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v3

    invoke-virtual {v3, v0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v3

    const/4 v6, 0x0

    aput-object v3, v2, v6

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendSegment$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v3

    invoke-virtual {v3, v0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v3

    const/4 v7, 0x1

    aput-object v3, v2, v7

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getBufferEndSegment$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v3

    invoke-virtual {v3, v0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v3

    aput-object v3, v2, v4

    invoke-static {v2}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->listOf([Ljava/lang/Object;)Ljava/util/List;

    move-result-object v2

    check-cast v2, Ljava/lang/Iterable;

    .line 4257
    new-instance v3, Ljava/util/ArrayList;

    invoke-direct {v3}, Ljava/util/ArrayList;-><init>()V

    .line 4258
    invoke-interface {v2}, Ljava/lang/Iterable;->iterator()Ljava/util/Iterator;

    move-result-object v2

    :cond_2
    :goto_1
    invoke-interface {v2}, Ljava/util/Iterator;->hasNext()Z

    move-result v4

    if-eqz v4, :cond_3

    invoke-interface {v2}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v4

    move-object v8, v4

    check-cast v8, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    .line 2608
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getNULL_SEGMENT$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    move-result-object v9

    if-eq v8, v9, :cond_2

    .line 4258
    invoke-interface {v3, v4}, Ljava/util/Collection;->add(Ljava/lang/Object;)Z

    goto :goto_1

    .line 4260
    :cond_3
    invoke-interface {v3}, Ljava/lang/Iterable;->iterator()Ljava/util/Iterator;

    move-result-object v2

    .line 4261
    invoke-interface {v2}, Ljava/util/Iterator;->hasNext()Z

    move-result v3

    if-eqz v3, :cond_16

    .line 4262
    invoke-interface {v2}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v3

    .line 4263
    invoke-interface {v2}, Ljava/util/Iterator;->hasNext()Z

    move-result v4

    if-nez v4, :cond_4

    goto :goto_2

    .line 4264
    :cond_4
    move-object v4, v3

    check-cast v4, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    .line 2609
    iget-wide v8, v4, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    .line 4266
    :cond_5
    invoke-interface {v2}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v4

    .line 4267
    move-object v10, v4

    check-cast v10, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    .line 2609
    iget-wide v10, v10, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    cmp-long v12, v8, v10

    if-lez v12, :cond_6

    move-object v3, v4

    move-wide v8, v10

    .line 4272
    :cond_6
    invoke-interface {v2}, Ljava/util/Iterator;->hasNext()Z

    move-result v4

    if-nez v4, :cond_5

    .line 2609
    :goto_2
    check-cast v3, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    .line 2610
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getReceiversCounter$kotlinx_coroutines_core()J

    move-result-wide v10

    .line 2611
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendersCounter$kotlinx_coroutines_core()J

    move-result-wide v12

    .line 2614
    :goto_3
    sget v2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->SEGMENT_SIZE:I

    move v4, v6

    :goto_4
    if-ge v4, v2, :cond_13

    .line 2615
    iget-wide v8, v3, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    sget v14, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->SEGMENT_SIZE:I

    int-to-long v14, v14

    mul-long/2addr v8, v14

    int-to-long v14, v4

    add-long/2addr v8, v14

    cmp-long v14, v8, v12

    if-ltz v14, :cond_8

    cmp-long v15, v8, v10

    if-gez v15, :cond_7

    goto :goto_5

    :cond_7
    move/from16 v16, v7

    goto/16 :goto_9

    .line 2617
    :cond_8
    :goto_5
    invoke-virtual {v3, v4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->getState$kotlinx_coroutines_core(I)Ljava/lang/Object;

    move-result-object v15

    .line 2618
    invoke-virtual {v3, v4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->getElement$kotlinx_coroutines_core(I)Ljava/lang/Object;

    move-result-object v6

    move/from16 v16, v7

    .line 2620
    instance-of v7, v15, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;

    if-eqz v7, :cond_b

    cmp-long v7, v8, v10

    if-gez v7, :cond_9

    if-ltz v14, :cond_9

    .line 2622
    const-string v7, "receive"

    goto/16 :goto_7

    :cond_9
    if-gez v14, :cond_a

    if-ltz v7, :cond_a

    .line 2623
    const-string v7, "send"

    goto/16 :goto_7

    .line 2624
    :cond_a
    const-string v7, "cont"

    goto/16 :goto_7

    .line 2634
    :cond_b
    instance-of v7, v15, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ReceiveCatching;

    if-eqz v7, :cond_c

    const-string v7, "receiveCatching"

    goto/16 :goto_7

    .line 2636
    :cond_c
    instance-of v7, v15, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/WaiterEB;

    if-eqz v7, :cond_d

    new-instance v7, Ljava/lang/StringBuilder;

    invoke-direct {v7}, Ljava/lang/StringBuilder;-><init>()V

    const-string v8, "EB("

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v7, v15}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const/16 v8, 0x29

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v7}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v7

    goto :goto_7

    .line 2637
    :cond_d
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getRESUMING_BY_RCV$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v7

    invoke-static {v15, v7}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v7

    if-nez v7, :cond_10

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getRESUMING_BY_EB$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v7

    invoke-static {v15, v7}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v7

    if-eqz v7, :cond_e

    goto :goto_6

    :cond_e
    if-eqz v15, :cond_12

    .line 2638
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getIN_BUFFER$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v7

    invoke-static {v15, v7}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v7

    if-nez v7, :cond_12

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getDONE_RCV$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v7

    invoke-static {v15, v7}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v7

    if-nez v7, :cond_12

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getPOISONED$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v7

    invoke-static {v15, v7}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v7

    if-nez v7, :cond_12

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getINTERRUPTED_RCV$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v7

    invoke-static {v15, v7}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v7

    if-nez v7, :cond_12

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getINTERRUPTED_SEND$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v7

    invoke-static {v15, v7}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v7

    if-nez v7, :cond_12

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->getCHANNEL_CLOSED()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v7

    invoke-static {v15, v7}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v7

    if-eqz v7, :cond_f

    goto :goto_8

    .line 2639
    :cond_f
    invoke-virtual {v15}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v7

    goto :goto_7

    .line 2637
    :cond_10
    :goto_6
    const-string v7, "resuming_sender"

    :goto_7
    if-eqz v6, :cond_11

    .line 2642
    new-instance v8, Ljava/lang/StringBuilder;

    invoke-direct {v8}, Ljava/lang/StringBuilder;-><init>()V

    const/16 v9, 0x28

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v8, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v8, v5}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v8, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v6, "),"

    invoke-virtual {v8, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v1, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    goto :goto_8

    .line 2644
    :cond_11
    new-instance v6, Ljava/lang/StringBuilder;

    invoke-direct {v6}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v6, v5}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v6}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v1, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    :cond_12
    :goto_8
    add-int/lit8 v4, v4, 0x1

    move/from16 v7, v16

    const/4 v6, 0x0

    goto/16 :goto_4

    :cond_13
    move/from16 v16, v7

    .line 2648
    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->getNext()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;

    move-result-object v2

    move-object v3, v2

    check-cast v3, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    if-nez v3, :cond_15

    .line 2650
    :goto_9
    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->last(Ljava/lang/CharSequence;)C

    move-result v2

    if-ne v2, v5, :cond_14

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->length()I

    move-result v2

    add-int/lit8 v2, v2, -0x1

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->deleteCharAt(I)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, "deleteCharAt(...)"

    invoke-static {v2, v3}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    .line 2651
    :cond_14
    const-string v2, "]"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 2653
    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    return-object v1

    :cond_15
    move/from16 v7, v16

    const/4 v6, 0x0

    goto/16 :goto_3

    .line 4261
    :cond_16
    new-instance v1, Ljava/util/NoSuchElementException;

    invoke-direct {v1}, Ljava/util/NoSuchElementException;-><init>()V

    throw v1
.end method

.method public tryReceive-PtdJZtk()Ljava/lang/Object;
    .locals 9

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getReceivers$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v0

    .line 784
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->get(Ljava/lang/Object;)J

    move-result-wide v0

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendersAndCloseStatus$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v2

    .line 785
    invoke-virtual {v2, p0}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->get(Ljava/lang/Object;)J

    move-result-wide v2

    .line 787
    invoke-direct {p0, v2, v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->isClosedForReceive0(J)Z

    move-result v4

    if-eqz v4, :cond_0

    .line 788
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;->Companion:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getCloseCause()Ljava/lang/Throwable;

    move-result-object v1

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;->closed-JP2dKIU(Ljava/lang/Throwable;)Ljava/lang/Object;

    move-result-object v0

    return-object v0

    :cond_0
    const-wide v4, 0xfffffffffffffffL

    and-long/2addr v2, v4

    cmp-long v0, v0, v2

    if-ltz v0, :cond_1

    .line 792
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;->Companion:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;->failure-PtdJZtk()Ljava/lang/Object;

    move-result-object v0

    return-object v0

    .line 803
    :cond_1
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getINTERRUPTED_RCV$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v6

    .line 3924
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$getReceiveSegment$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    .line 3929
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    .line 3933
    :goto_0
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->isClosedForReceive()Z

    move-result v1

    if-eqz v1, :cond_2

    .line 816
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;->Companion:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getCloseCause()Ljava/lang/Throwable;

    move-result-object v1

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;->closed-JP2dKIU(Ljava/lang/Throwable;)Ljava/lang/Object;

    move-result-object v0

    return-object v0

    .line 3933
    :cond_2
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$getReceivers$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v1

    .line 3936
    invoke-virtual {v1, p0}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->getAndIncrement(Ljava/lang/Object;)J

    move-result-wide v4

    .line 3938
    sget v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->SEGMENT_SIZE:I

    int-to-long v2, v1

    div-long v2, v4, v2

    int-to-long v7, v1

    .line 3939
    rem-long v7, v4, v7

    long-to-int v1, v7

    .line 3942
    iget-wide v7, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    cmp-long v7, v7, v2

    if-eqz v7, :cond_4

    .line 3944
    invoke-static {p0, v2, v3, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$findSegmentReceive(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    move-result-object v2

    if-nez v2, :cond_3

    goto :goto_0

    :cond_3
    :goto_1
    move v3, v1

    move-object v1, p0

    goto :goto_2

    :cond_4
    move-object v2, v0

    goto :goto_1

    .line 3951
    :goto_2
    invoke-static/range {v1 .. v6}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$updateCellReceive(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;IJLjava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    .line 3953
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getSUSPEND$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v7

    if-ne v0, v7, :cond_7

    .line 3956
    instance-of v0, v6, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;

    if-eqz v0, :cond_5

    check-cast v6, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;

    goto :goto_3

    :cond_5
    const/4 v6, 0x0

    :goto_3
    if-eqz v6, :cond_6

    invoke-static {p0, v6, v2, v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$prepareReceiverForSuspension(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;I)V

    .line 811
    :cond_6
    invoke-virtual {p0, v4, v5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->waitExpandBufferCompletion$kotlinx_coroutines_core(J)V

    .line 812
    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->onSlotCleaned()V

    .line 813
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;->Companion:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;->failure-PtdJZtk()Ljava/lang/Object;

    move-result-object v0

    return-object v0

    .line 3959
    :cond_7
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getFAILED$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v3

    if-ne v0, v3, :cond_9

    .line 3966
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendersCounter$kotlinx_coroutines_core()J

    move-result-wide v7

    cmp-long v0, v4, v7

    if-gez v0, :cond_8

    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->cleanPrev()V

    :cond_8
    move-object v0, v2

    goto :goto_0

    .line 3969
    :cond_9
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getSUSPEND_NO_WAITER$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v3

    if-eq v0, v3, :cond_a

    .line 3974
    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->cleanPrev()V

    .line 805
    sget-object v2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;->Companion:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;

    invoke-virtual {v2, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;->success-JP2dKIU(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    return-object v0

    .line 3972
    :cond_a
    new-instance v0, Ljava/lang/IllegalStateException;

    .line 3973
    const-string v2, "unexpected"

    invoke-direct {v0, v2}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method public trySend-JP2dKIU(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 11

    .line 185
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendersAndCloseStatus$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v0

    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->get(Ljava/lang/Object;)J

    move-result-wide v0

    invoke-direct {p0, v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->shouldSendSuspend(J)Z

    move-result v0

    if-eqz v0, :cond_0

    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;->Companion:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;->failure-PtdJZtk()Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 194
    :cond_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getINTERRUPTED_SEND$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object v6

    .line 3324
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$getSendSegment$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    .line 3329
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    .line 3330
    :cond_1
    :goto_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$getSendersAndCloseStatus$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v1

    .line 3333
    invoke-virtual {v1, p0}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->getAndIncrement(Ljava/lang/Object;)J

    move-result-wide v1

    const-wide v3, 0xfffffffffffffffL

    and-long v4, v1, v3

    .line 3336
    invoke-static {p0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$isClosedForSend0(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;J)Z

    move-result v7

    .line 3338
    sget v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->SEGMENT_SIZE:I

    int-to-long v2, v1

    div-long v2, v4, v2

    int-to-long v8, v1

    .line 3339
    rem-long v8, v4, v8

    long-to-int v1, v8

    .line 3342
    iget-wide v8, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    cmp-long v8, v8, v2

    if-eqz v8, :cond_3

    .line 3344
    invoke-static {p0, v2, v3, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$findSegmentSend(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    move-result-object v2

    if-nez v2, :cond_2

    if-eqz v7, :cond_1

    .line 206
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;->Companion:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendException()Ljava/lang/Throwable;

    move-result-object v0

    invoke-virtual {p1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;->closed-JP2dKIU(Ljava/lang/Throwable;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    :cond_2
    move-object v0, v2

    move v2, v1

    move-object v1, v0

    move-object v0, p0

    move-object v3, p1

    goto :goto_1

    :cond_3
    move-object v3, p1

    move v2, v1

    move-object v1, v0

    move-object v0, p0

    .line 3360
    :goto_1
    invoke-static/range {v0 .. v7}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$updateCellSend(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;ILjava/lang/Object;JLjava/lang/Object;Z)I

    move-result p1

    move-object v10, v1

    move-object v1, v0

    move-object v0, v10

    if-eqz p1, :cond_d

    const/4 v8, 0x1

    if-eq p1, v8, :cond_c

    const/4 v8, 0x2

    if-eq p1, v8, :cond_8

    const/4 v2, 0x3

    if-eq p1, v2, :cond_7

    const/4 v2, 0x4

    if-eq p1, v2, :cond_5

    const/4 v2, 0x5

    if-eq p1, v2, :cond_4

    goto :goto_2

    .line 3397
    :cond_4
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->cleanPrev()V

    :goto_2
    move-object p1, v3

    goto :goto_0

    .line 3390
    :cond_5
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getReceiversCounter$kotlinx_coroutines_core()J

    move-result-wide v2

    cmp-long p1, v4, v2

    if-gez p1, :cond_6

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->cleanPrev()V

    .line 206
    :cond_6
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;->Companion:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendException()Ljava/lang/Throwable;

    move-result-object v0

    invoke-virtual {p1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;->closed-JP2dKIU(Ljava/lang/Throwable;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 3403
    :cond_7
    new-instance p1, Ljava/lang/IllegalStateException;

    .line 3404
    const-string v0, "unexpected"

    invoke-direct {p1, v0}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw p1

    :cond_8
    if-eqz v7, :cond_9

    .line 3379
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->onSlotCleaned()V

    .line 206
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;->Companion:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendException()Ljava/lang/Throwable;

    move-result-object v0

    invoke-virtual {p1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;->closed-JP2dKIU(Ljava/lang/Throwable;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 3382
    :cond_9
    instance-of p1, v6, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;

    if-eqz p1, :cond_a

    check-cast v6, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;

    goto :goto_3

    :cond_a
    const/4 v6, 0x0

    :goto_3
    if-eqz v6, :cond_b

    invoke-static {p0, v6, v0, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$prepareSenderForSuspension(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;I)V

    .line 202
    :cond_b
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->onSlotCleaned()V

    .line 203
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;->Companion:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;->failure-PtdJZtk()Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 197
    :cond_c
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;->Companion:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;

    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    invoke-virtual {p1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;->success-JP2dKIU(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 3366
    :cond_d
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->cleanPrev()V

    .line 197
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;->Companion:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;

    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    invoke-virtual {p1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;->success-JP2dKIU(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method

.method protected final trySendDropOldest-JP2dKIU(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 12

    .line 358
    sget-object v6, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->BUFFERED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    .line 3498
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$getSendSegment$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    .line 3503
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    .line 3504
    :cond_0
    :goto_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$getSendersAndCloseStatus$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v1

    .line 3507
    invoke-virtual {v1, p0}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->getAndIncrement(Ljava/lang/Object;)J

    move-result-wide v1

    const-wide v3, 0xfffffffffffffffL

    and-long v4, v1, v3

    .line 3510
    invoke-static {p0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$isClosedForSend0(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;J)Z

    move-result v7

    .line 3512
    sget v8, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->SEGMENT_SIZE:I

    int-to-long v1, v8

    div-long v1, v4, v1

    int-to-long v9, v8

    .line 3513
    rem-long v9, v4, v9

    long-to-int v3, v9

    .line 3516
    iget-wide v9, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    cmp-long v9, v9, v1

    if-eqz v9, :cond_2

    .line 3518
    invoke-static {p0, v1, v2, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$findSegmentSend(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    move-result-object v1

    if-nez v1, :cond_1

    if-eqz v7, :cond_0

    .line 370
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;->Companion:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendException()Ljava/lang/Throwable;

    move-result-object v0

    invoke-virtual {p1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;->closed-JP2dKIU(Ljava/lang/Throwable;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    :cond_1
    move-object v0, p0

    move v2, v3

    :goto_1
    move-object v3, p1

    goto :goto_2

    :cond_2
    move-object v1, v0

    move v2, v3

    move-object v0, p0

    goto :goto_1

    .line 3534
    :goto_2
    invoke-static/range {v0 .. v7}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$updateCellSend(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;ILjava/lang/Object;JLjava/lang/Object;Z)I

    move-result p1

    move-object v11, v1

    move-object v1, v0

    move-object v0, v11

    if-eqz p1, :cond_c

    const/4 v9, 0x1

    if-eq p1, v9, :cond_b

    const/4 v9, 0x2

    if-eq p1, v9, :cond_7

    const/4 v2, 0x3

    if-eq p1, v2, :cond_6

    const/4 v2, 0x4

    if-eq p1, v2, :cond_4

    const/4 v2, 0x5

    if-eq p1, v2, :cond_3

    goto :goto_3

    .line 3571
    :cond_3
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->cleanPrev()V

    :goto_3
    move-object p1, v3

    goto :goto_0

    .line 3564
    :cond_4
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getReceiversCounter$kotlinx_coroutines_core()J

    move-result-wide v2

    cmp-long p1, v4, v2

    if-gez p1, :cond_5

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->cleanPrev()V

    .line 370
    :cond_5
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;->Companion:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendException()Ljava/lang/Throwable;

    move-result-object v0

    invoke-virtual {p1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;->closed-JP2dKIU(Ljava/lang/Throwable;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 3577
    :cond_6
    new-instance p1, Ljava/lang/IllegalStateException;

    .line 3578
    const-string v0, "unexpected"

    invoke-direct {p1, v0}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw p1

    :cond_7
    if-eqz v7, :cond_8

    .line 3553
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->onSlotCleaned()V

    .line 370
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;->Companion:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getSendException()Ljava/lang/Throwable;

    move-result-object v0

    invoke-virtual {p1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;->closed-JP2dKIU(Ljava/lang/Throwable;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 3556
    :cond_8
    instance-of p1, v6, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;

    if-eqz p1, :cond_9

    check-cast v6, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;

    goto :goto_4

    :cond_9
    const/4 v6, 0x0

    :goto_4
    if-eqz v6, :cond_a

    invoke-static {p0, v6, v0, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->access$prepareSenderForSuspension(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Waiter;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;I)V

    .line 366
    :cond_a
    iget-wide v3, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    int-to-long v5, v8

    mul-long/2addr v3, v5

    int-to-long v5, v2

    add-long/2addr v3, v5

    invoke-virtual {p0, v3, v4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->dropFirstElementUntilTheSpecifiedCellIsInTheBuffer(J)V

    .line 367
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;->Companion:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;

    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    invoke-virtual {p1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;->success-JP2dKIU(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 361
    :cond_b
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;->Companion:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;

    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    invoke-virtual {p1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;->success-JP2dKIU(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 3540
    :cond_c
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ConcurrentLinkedListNode;->cleanPrev()V

    .line 361
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult;->Companion:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;

    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    invoke-virtual {p1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelResult$Companion;->success-JP2dKIU(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method

.method public final waitExpandBufferCompletion$kotlinx_coroutines_core(J)V
    .locals 18

    move-object/from16 v1, p0

    .line 1413
    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->isRendezvousOrUnlimited()Z

    move-result v0

    if-eqz v0, :cond_0

    goto/16 :goto_6

    .line 1417
    :cond_0
    :goto_0
    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getBufferEndCounter()J

    move-result-wide v2

    cmp-long v0, v2, p1

    if-lez v0, :cond_8

    .line 1422
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$getEXPAND_BUFFER_COMPLETION_WAIT_ITERATIONS$p()I

    move-result v0

    const/4 v6, 0x0

    move v2, v6

    :goto_1
    const-wide v7, 0x3fffffffffffffffL    # 1.9999999999999998

    if-ge v2, v0, :cond_2

    .line 1424
    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getBufferEndCounter()J

    move-result-wide v3

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getCompletedExpandBuffersAndPauseFlag$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v5

    .line 1426
    invoke-virtual {v5, v1}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->get(Ljava/lang/Object;)J

    move-result-wide v9

    and-long/2addr v7, v9

    cmp-long v5, v3, v7

    if-nez v5, :cond_1

    .line 1432
    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getBufferEndCounter()J

    move-result-wide v7

    cmp-long v3, v3, v7

    if-nez v3, :cond_1

    goto :goto_6

    :cond_1
    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    .line 1410
    :cond_2
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getCompletedExpandBuffersAndPauseFlag$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v0

    :goto_2
    invoke-virtual {v0, v1}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->get(Ljava/lang/Object;)J

    move-result-wide v2

    and-long v4, v2, v7

    const/4 v9, 0x1

    .line 1436
    invoke-static {v4, v5, v9}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$constructEBCompletedAndPauseFlag(JZ)J

    move-result-wide v4

    invoke-virtual/range {v0 .. v5}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->compareAndSet(Ljava/lang/Object;JJ)Z

    move-result v2

    if-eqz v2, :cond_7

    .line 1441
    :goto_3
    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getBufferEndCounter()J

    move-result-wide v2

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getCompletedExpandBuffersAndPauseFlag$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v0

    .line 1444
    invoke-virtual {v0, v1}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->get(Ljava/lang/Object;)J

    move-result-wide v4

    and-long v10, v4, v7

    const-wide/high16 v12, 0x4000000000000000L    # 2.0

    and-long/2addr v12, v4

    const-wide/16 v14, 0x0

    cmp-long v0, v12, v14

    if-eqz v0, :cond_3

    move v0, v9

    goto :goto_4

    :cond_3
    move v0, v6

    :goto_4
    cmp-long v12, v2, v10

    if-nez v12, :cond_5

    .line 1450
    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getBufferEndCounter()J

    move-result-wide v12

    cmp-long v2, v2, v12

    if-nez v2, :cond_5

    .line 1410
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getCompletedExpandBuffersAndPauseFlag$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v0

    :goto_5
    invoke-virtual {v0, v1}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->get(Ljava/lang/Object;)J

    move-result-wide v2

    and-long v4, v2, v7

    .line 1453
    invoke-static {v4, v5, v6}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$constructEBCompletedAndPauseFlag(JZ)J

    move-result-wide v4

    invoke-virtual/range {v0 .. v5}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->compareAndSet(Ljava/lang/Object;JJ)Z

    move-result v2

    move-object v1, v0

    if-eqz v2, :cond_4

    :goto_6
    return-void

    :cond_4
    move-object v0, v1

    move-object/from16 v1, p0

    goto :goto_5

    :cond_5
    if-nez v0, :cond_6

    .line 1460
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->getCompletedExpandBuffersAndPauseFlag$volatile$FU()Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;

    move-result-object v0

    .line 1463
    invoke-static {v10, v11, v9}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->access$constructEBCompletedAndPauseFlag(JZ)J

    move-result-wide v1

    move-wide/from16 v16, v4

    move-wide v4, v1

    move-wide/from16 v2, v16

    move-object/from16 v1, p0

    invoke-virtual/range {v0 .. v5}, Ljava/util/concurrent/atomic/AtomicLongFieldUpdater;->compareAndSet(Ljava/lang/Object;JJ)Z

    goto :goto_3

    :cond_6
    move-object/from16 v1, p0

    goto :goto_3

    :cond_7
    move-object/from16 v1, p0

    goto :goto_2

    :cond_8
    move-object/from16 v1, p0

    goto/16 :goto_0
.end method
