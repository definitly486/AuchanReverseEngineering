.class public abstract Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;
.super Ljava/lang/Object;
.source "BufferedChannel.kt"


# static fields
.field public static final BUFFERED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

.field private static final CHANNEL_CLOSED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

.field private static final CLOSE_HANDLER_CLOSED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

.field private static final CLOSE_HANDLER_INVOKED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

.field private static final DONE_RCV:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

.field private static final EXPAND_BUFFER_COMPLETION_WAIT_ITERATIONS:I

.field private static final FAILED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

.field private static final INTERRUPTED_RCV:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

.field private static final INTERRUPTED_SEND:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

.field private static final IN_BUFFER:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

.field private static final NO_CLOSE_CAUSE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

.field private static final NO_RECEIVE_RESULT:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

.field private static final NULL_SEGMENT:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

.field private static final POISONED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

.field private static final RESUMING_BY_EB:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

.field private static final RESUMING_BY_RCV:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

.field public static final SEGMENT_SIZE:I

.field private static final SUSPEND:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

.field private static final SUSPEND_NO_WAITER:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;


# direct methods
.method static constructor <clinit>()V
    .locals 7

    .line 2932
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    const/4 v4, 0x0

    const/4 v5, 0x0

    const-wide/16 v1, -0x1

    const/4 v3, 0x0

    invoke-direct/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;-><init>(JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->NULL_SEGMENT:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    const/16 v5, 0xc

    const/4 v6, 0x0

    .line 2938
    const-string v1, "kotlinx.coroutines.bufferedChannel.segmentSize"

    const/16 v2, 0x20

    const/4 v3, 0x0

    const/4 v4, 0x0

    invoke-static/range {v1 .. v6}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/SystemPropsKt;->systemProp$default(Ljava/lang/String;IIIILjava/lang/Object;)I

    move-result v0

    sput v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->SEGMENT_SIZE:I

    .line 2945
    const-string v1, "kotlinx.coroutines.bufferedChannel.expandBufferCompletionWaitIterations"

    const/16 v2, 0x2710

    invoke-static/range {v1 .. v6}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/SystemPropsKt;->systemProp$default(Ljava/lang/String;IIIILjava/lang/Object;)I

    move-result v0

    sput v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->EXPAND_BUFFER_COMPLETION_WAIT_ITERATIONS:I

    .line 2982
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    const-string v1, "BUFFERED"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;-><init>(Ljava/lang/String;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->BUFFERED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    .line 2985
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    const-string v1, "SHOULD_BUFFER"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;-><init>(Ljava/lang/String;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->IN_BUFFER:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    .line 2990
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    const-string v1, "S_RESUMING_BY_RCV"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;-><init>(Ljava/lang/String;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->RESUMING_BY_RCV:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    .line 2995
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    const-string v1, "RESUMING_BY_EB"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;-><init>(Ljava/lang/String;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->RESUMING_BY_EB:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    .line 3000
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    const-string v1, "POISONED"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;-><init>(Ljava/lang/String;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->POISONED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    .line 3003
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    const-string v1, "DONE_RCV"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;-><init>(Ljava/lang/String;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->DONE_RCV:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    .line 3005
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    const-string v1, "INTERRUPTED_SEND"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;-><init>(Ljava/lang/String;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->INTERRUPTED_SEND:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    .line 3007
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    const-string v1, "INTERRUPTED_RCV"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;-><init>(Ljava/lang/String;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->INTERRUPTED_RCV:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    .line 3009
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    const-string v1, "CHANNEL_CLOSED"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;-><init>(Ljava/lang/String;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->CHANNEL_CLOSED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    .line 3039
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    const-string v1, "SUSPEND"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;-><init>(Ljava/lang/String;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->SUSPEND:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    .line 3040
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    const-string v1, "SUSPEND_NO_WAITER"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;-><init>(Ljava/lang/String;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->SUSPEND_NO_WAITER:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    .line 3041
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    const-string v1, "FAILED"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;-><init>(Ljava/lang/String;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->FAILED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    .line 3057
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    const-string v1, "NO_RECEIVE_RESULT"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;-><init>(Ljava/lang/String;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->NO_RECEIVE_RESULT:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    .line 3064
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    const-string v1, "CLOSE_HANDLER_CLOSED"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;-><init>(Ljava/lang/String;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->CLOSE_HANDLER_CLOSED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    .line 3065
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    const-string v1, "CLOSE_HANDLER_INVOKED"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;-><init>(Ljava/lang/String;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->CLOSE_HANDLER_INVOKED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    .line 3072
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    const-string v1, "NO_CLOSE_CAUSE"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;-><init>(Ljava/lang/String;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->NO_CLOSE_CAUSE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    return-void
.end method

.method public static final synthetic access$constructEBCompletedAndPauseFlag(JZ)J
    .locals 0

    .line 1
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->constructEBCompletedAndPauseFlag(JZ)J

    move-result-wide p0

    return-wide p0
.end method

.method public static final synthetic access$constructSendersAndCloseStatus(JI)J
    .locals 0

    .line 1
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->constructSendersAndCloseStatus(JI)J

    move-result-wide p0

    return-wide p0
.end method

.method public static final synthetic access$createSegment(JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;
    .locals 0

    .line 1
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->createSegment(JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    move-result-object p0

    return-object p0
.end method

.method public static final synthetic access$getCLOSE_HANDLER_CLOSED$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;
    .locals 1

    .line 1
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->CLOSE_HANDLER_CLOSED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    return-object v0
.end method

.method public static final synthetic access$getCLOSE_HANDLER_INVOKED$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;
    .locals 1

    .line 1
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->CLOSE_HANDLER_INVOKED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    return-object v0
.end method

.method public static final synthetic access$getDONE_RCV$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;
    .locals 1

    .line 1
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->DONE_RCV:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    return-object v0
.end method

.method public static final synthetic access$getEXPAND_BUFFER_COMPLETION_WAIT_ITERATIONS$p()I
    .locals 1

    .line 1
    sget v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->EXPAND_BUFFER_COMPLETION_WAIT_ITERATIONS:I

    return v0
.end method

.method public static final synthetic access$getFAILED$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;
    .locals 1

    .line 1
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->FAILED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    return-object v0
.end method

.method public static final synthetic access$getINTERRUPTED_RCV$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;
    .locals 1

    .line 1
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->INTERRUPTED_RCV:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    return-object v0
.end method

.method public static final synthetic access$getINTERRUPTED_SEND$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;
    .locals 1

    .line 1
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->INTERRUPTED_SEND:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    return-object v0
.end method

.method public static final synthetic access$getIN_BUFFER$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;
    .locals 1

    .line 1
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->IN_BUFFER:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    return-object v0
.end method

.method public static final synthetic access$getNO_CLOSE_CAUSE$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;
    .locals 1

    .line 1
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->NO_CLOSE_CAUSE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    return-object v0
.end method

.method public static final synthetic access$getNO_RECEIVE_RESULT$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;
    .locals 1

    .line 1
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->NO_RECEIVE_RESULT:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    return-object v0
.end method

.method public static final synthetic access$getNULL_SEGMENT$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;
    .locals 1

    .line 1
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->NULL_SEGMENT:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    return-object v0
.end method

.method public static final synthetic access$getPOISONED$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;
    .locals 1

    .line 1
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->POISONED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    return-object v0
.end method

.method public static final synthetic access$getRESUMING_BY_EB$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;
    .locals 1

    .line 1
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->RESUMING_BY_EB:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    return-object v0
.end method

.method public static final synthetic access$getRESUMING_BY_RCV$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;
    .locals 1

    .line 1
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->RESUMING_BY_RCV:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    return-object v0
.end method

.method public static final synthetic access$getSUSPEND$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;
    .locals 1

    .line 1
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->SUSPEND:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    return-object v0
.end method

.method public static final synthetic access$getSUSPEND_NO_WAITER$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;
    .locals 1

    .line 1
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->SUSPEND_NO_WAITER:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    return-object v0
.end method

.method public static final synthetic access$initialBufferEnd(I)J
    .locals 2

    .line 1
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->initialBufferEnd(I)J

    move-result-wide v0

    return-wide v0
.end method

.method public static final synthetic access$tryResume0(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;)Z
    .locals 0

    .line 1
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->tryResume0(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;)Z

    move-result p0

    return p0
.end method

.method private static final constructEBCompletedAndPauseFlag(JZ)J
    .locals 2

    .line 3115
    if-eqz p2, :cond_0

    const-wide/high16 v0, 0x4000000000000000L    # 2.0

    goto :goto_0

    :cond_0
    const-wide/16 v0, 0x0

    :goto_0
    add-long/2addr v0, p0

    return-wide v0
.end method

.method private static final constructSendersAndCloseStatus(JI)J
    .locals 2

    .line 3102
    int-to-long v0, p2

    const/16 p2, 0x3c

    shl-long/2addr v0, p2

    add-long/2addr v0, p0

    return-wide v0
.end method

.method private static final createSegment(JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;
    .locals 6

    .line 2926
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;

    .line 2929
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;->getChannel()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;

    move-result-object v4

    const/4 v5, 0x0

    move-wide v1, p0

    move-object v3, p2

    .line 2926
    invoke-direct/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;-><init>(JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ChannelSegment;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;I)V

    return-object v0
.end method

.method public static final createSegmentFunction()Lkotlin/reflect/KFunction;
    .locals 1

    .line 2924
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt$createSegmentFunction$1;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt$createSegmentFunction$1;

    return-object v0
.end method

.method public static final getCHANNEL_CLOSED()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;
    .locals 1

    .line 3009
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->CHANNEL_CLOSED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    return-object v0
.end method

.method private static final initialBufferEnd(I)J
    .locals 2

    .line 2969
    if-eqz p0, :cond_1

    const v0, 0x7fffffff

    if-eq p0, v0, :cond_0

    int-to-long v0, p0

    return-wide v0

    :cond_0
    const-wide v0, 0x7fffffffffffffffL

    return-wide v0

    :cond_1
    const-wide/16 v0, 0x0

    return-wide v0
.end method

.method private static final tryResume0(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;)Z
    .locals 1

    const/4 v0, 0x0

    .line 2955
    invoke-interface {p0, p1, v0, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;->tryResume(Ljava/lang/Object;Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;)Ljava/lang/Object;

    move-result-object p1

    if-eqz p1, :cond_0

    .line 2957
    invoke-interface {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;->completeResume(Ljava/lang/Object;)V

    const/4 p0, 0x1

    return p0

    :cond_0
    const/4 p0, 0x0

    return p0
.end method

.method static synthetic tryResume0$default(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;ILjava/lang/Object;)Z
    .locals 0

    and-int/lit8 p3, p3, 0x2

    if-eqz p3, :cond_0

    const/4 p2, 0x0

    .line 2951
    :cond_0
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannelKt;->tryResume0(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;)Z

    move-result p0

    return p0
.end method
