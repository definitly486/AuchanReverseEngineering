.class public final Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "CalculatorProto.java"

# interfaces
.implements Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfigOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/proto/CalculatorProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "ProfilerConfig"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;",
        "Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;",
        ">;",
        "Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfigOrBuilder;"
    }
.end annotation


# static fields
.field public static final CALCULATOR_FILTER_FIELD_NUMBER:I = 0x12

.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

.field public static final ENABLE_INPUT_OUTPUT_LATENCY_FIELD_NUMBER:I = 0x3

.field public static final ENABLE_PROFILER_FIELD_NUMBER:I = 0x4

.field public static final ENABLE_STREAM_LATENCY_FIELD_NUMBER:I = 0x5

.field public static final HISTOGRAM_INTERVAL_SIZE_USEC_FIELD_NUMBER:I = 0x1

.field public static final NUM_HISTOGRAM_INTERVALS_FIELD_NUMBER:I = 0x2

.field private static volatile PARSER:Lcom/google/protobuf/Parser; = null
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;",
            ">;"
        }
    .end annotation
.end field

.field public static final TRACE_ENABLED_FIELD_NUMBER:I = 0x10

.field public static final TRACE_EVENT_TYPES_DISABLED_FIELD_NUMBER:I = 0x8

.field public static final TRACE_LOG_CAPACITY_FIELD_NUMBER:I = 0x7

.field public static final TRACE_LOG_COUNT_FIELD_NUMBER:I = 0xa

.field public static final TRACE_LOG_DISABLED_FIELD_NUMBER:I = 0xf

.field public static final TRACE_LOG_DURATION_EVENTS_FIELD_NUMBER:I = 0xd

.field public static final TRACE_LOG_INSTANT_EVENTS_FIELD_NUMBER:I = 0x11

.field public static final TRACE_LOG_INTERVAL_COUNT_FIELD_NUMBER:I = 0xe

.field public static final TRACE_LOG_INTERVAL_USEC_FIELD_NUMBER:I = 0xb

.field public static final TRACE_LOG_MARGIN_USEC_FIELD_NUMBER:I = 0xc

.field public static final TRACE_LOG_PATH_FIELD_NUMBER:I = 0x9

.field public static final USE_PACKET_TIMESTAMP_FOR_ADDED_PACKET_FIELD_NUMBER:I = 0x6


# instance fields
.field private calculatorFilter_:Ljava/lang/String;

.field private enableInputOutputLatency_:Z

.field private enableProfiler_:Z

.field private enableStreamLatency_:Z

.field private histogramIntervalSizeUsec_:J

.field private numHistogramIntervals_:J

.field private traceEnabled_:Z

.field private traceEventTypesDisabledMemoizedSerializedSize:I

.field private traceEventTypesDisabled_:Lcom/google/protobuf/Internal$IntList;

.field private traceLogCapacity_:J

.field private traceLogCount_:I

.field private traceLogDisabled_:Z

.field private traceLogDurationEvents_:Z

.field private traceLogInstantEvents_:Z

.field private traceLogIntervalCount_:I

.field private traceLogIntervalUsec_:J

.field private traceLogMarginUsec_:J

.field private traceLogPath_:Ljava/lang/String;

.field private usePacketTimestampForAddedPacket_:Z


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 5701
    new-instance v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-direct {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;-><init>()V

    .line 5704
    sput-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    .line 5705
    const-class v1, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    .line 3722
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    const/4 v0, -0x1

    .line 4075
    iput v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceEventTypesDisabledMemoizedSerializedSize:I

    .line 3723
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyIntList()Lcom/google/protobuf/Internal$IntList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceEventTypesDisabled_:Lcom/google/protobuf/Internal$IntList;

    .line 3724
    const-string v0, ""

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceLogPath_:Ljava/lang/String;

    .line 3725
    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->calculatorFilter_:Ljava/lang/String;

    return-void
.end method

.method static synthetic access$4700()Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;
    .locals 1

    .line 3717
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    return-object v0
.end method

.method static synthetic access$4800(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;J)V
    .locals 0

    .line 3717
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->setHistogramIntervalSizeUsec(J)V

    return-void
.end method

.method static synthetic access$4900(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V
    .locals 0

    .line 3717
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->clearHistogramIntervalSizeUsec()V

    return-void
.end method

.method static synthetic access$5000(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;J)V
    .locals 0

    .line 3717
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->setNumHistogramIntervals(J)V

    return-void
.end method

.method static synthetic access$5100(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V
    .locals 0

    .line 3717
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->clearNumHistogramIntervals()V

    return-void
.end method

.method static synthetic access$5200(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;Z)V
    .locals 0

    .line 3717
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->setEnableInputOutputLatency(Z)V

    return-void
.end method

.method static synthetic access$5300(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V
    .locals 0

    .line 3717
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->clearEnableInputOutputLatency()V

    return-void
.end method

.method static synthetic access$5400(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;Z)V
    .locals 0

    .line 3717
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->setEnableProfiler(Z)V

    return-void
.end method

.method static synthetic access$5500(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V
    .locals 0

    .line 3717
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->clearEnableProfiler()V

    return-void
.end method

.method static synthetic access$5600(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;Z)V
    .locals 0

    .line 3717
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->setEnableStreamLatency(Z)V

    return-void
.end method

.method static synthetic access$5700(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V
    .locals 0

    .line 3717
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->clearEnableStreamLatency()V

    return-void
.end method

.method static synthetic access$5800(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;Z)V
    .locals 0

    .line 3717
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->setUsePacketTimestampForAddedPacket(Z)V

    return-void
.end method

.method static synthetic access$5900(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V
    .locals 0

    .line 3717
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->clearUsePacketTimestampForAddedPacket()V

    return-void
.end method

.method static synthetic access$6000(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;J)V
    .locals 0

    .line 3717
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->setTraceLogCapacity(J)V

    return-void
.end method

.method static synthetic access$6100(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V
    .locals 0

    .line 3717
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->clearTraceLogCapacity()V

    return-void
.end method

.method static synthetic access$6200(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;II)V
    .locals 0

    .line 3717
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->setTraceEventTypesDisabled(II)V

    return-void
.end method

.method static synthetic access$6300(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;I)V
    .locals 0

    .line 3717
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->addTraceEventTypesDisabled(I)V

    return-void
.end method

.method static synthetic access$6400(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;Ljava/lang/Iterable;)V
    .locals 0

    .line 3717
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->addAllTraceEventTypesDisabled(Ljava/lang/Iterable;)V

    return-void
.end method

.method static synthetic access$6500(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V
    .locals 0

    .line 3717
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->clearTraceEventTypesDisabled()V

    return-void
.end method

.method static synthetic access$6600(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;Ljava/lang/String;)V
    .locals 0

    .line 3717
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->setTraceLogPath(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$6700(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V
    .locals 0

    .line 3717
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->clearTraceLogPath()V

    return-void
.end method

.method static synthetic access$6800(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 3717
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->setTraceLogPathBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method static synthetic access$6900(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;I)V
    .locals 0

    .line 3717
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->setTraceLogCount(I)V

    return-void
.end method

.method static synthetic access$7000(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V
    .locals 0

    .line 3717
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->clearTraceLogCount()V

    return-void
.end method

.method static synthetic access$7100(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;J)V
    .locals 0

    .line 3717
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->setTraceLogIntervalUsec(J)V

    return-void
.end method

.method static synthetic access$7200(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V
    .locals 0

    .line 3717
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->clearTraceLogIntervalUsec()V

    return-void
.end method

.method static synthetic access$7300(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;J)V
    .locals 0

    .line 3717
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->setTraceLogMarginUsec(J)V

    return-void
.end method

.method static synthetic access$7400(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V
    .locals 0

    .line 3717
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->clearTraceLogMarginUsec()V

    return-void
.end method

.method static synthetic access$7500(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;Z)V
    .locals 0

    .line 3717
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->setTraceLogDurationEvents(Z)V

    return-void
.end method

.method static synthetic access$7600(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V
    .locals 0

    .line 3717
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->clearTraceLogDurationEvents()V

    return-void
.end method

.method static synthetic access$7700(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;I)V
    .locals 0

    .line 3717
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->setTraceLogIntervalCount(I)V

    return-void
.end method

.method static synthetic access$7800(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V
    .locals 0

    .line 3717
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->clearTraceLogIntervalCount()V

    return-void
.end method

.method static synthetic access$7900(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;Z)V
    .locals 0

    .line 3717
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->setTraceLogDisabled(Z)V

    return-void
.end method

.method static synthetic access$8000(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V
    .locals 0

    .line 3717
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->clearTraceLogDisabled()V

    return-void
.end method

.method static synthetic access$8100(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;Z)V
    .locals 0

    .line 3717
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->setTraceEnabled(Z)V

    return-void
.end method

.method static synthetic access$8200(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V
    .locals 0

    .line 3717
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->clearTraceEnabled()V

    return-void
.end method

.method static synthetic access$8300(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;Z)V
    .locals 0

    .line 3717
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->setTraceLogInstantEvents(Z)V

    return-void
.end method

.method static synthetic access$8400(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V
    .locals 0

    .line 3717
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->clearTraceLogInstantEvents()V

    return-void
.end method

.method static synthetic access$8500(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;Ljava/lang/String;)V
    .locals 0

    .line 3717
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->setCalculatorFilter(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$8600(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V
    .locals 0

    .line 3717
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->clearCalculatorFilter()V

    return-void
.end method

.method static synthetic access$8700(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 3717
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->setCalculatorFilterBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method private addAllTraceEventTypesDisabled(Ljava/lang/Iterable;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "+",
            "Ljava/lang/Integer;",
            ">;)V"
        }
    .end annotation

    .line 4119
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->ensureTraceEventTypesDisabledIsMutable()V

    .line 4120
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceEventTypesDisabled_:Lcom/google/protobuf/Internal$IntList;

    invoke-static {p1, v0}, Lcom/google/protobuf/AbstractMessageLite;->addAll(Ljava/lang/Iterable;Ljava/util/List;)V

    return-void
.end method

.method private addTraceEventTypesDisabled(I)V
    .locals 1

    .line 4106
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->ensureTraceEventTypesDisabledIsMutable()V

    .line 4107
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceEventTypesDisabled_:Lcom/google/protobuf/Internal$IntList;

    invoke-interface {v0, p1}, Lcom/google/protobuf/Internal$IntList;->addInt(I)V

    return-void
.end method

.method private clearCalculatorFilter()V
    .locals 1

    .line 4593
    invoke-static {}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->getDefaultInstance()Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    move-result-object v0

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->getCalculatorFilter()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->calculatorFilter_:Ljava/lang/String;

    return-void
.end method

.method private clearEnableInputOutputLatency()V
    .locals 1

    const/4 v0, 0x0

    .line 3862
    iput-boolean v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->enableInputOutputLatency_:Z

    return-void
.end method

.method private clearEnableProfiler()V
    .locals 1

    const/4 v0, 0x0

    .line 3900
    iput-boolean v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->enableProfiler_:Z

    return-void
.end method

.method private clearEnableStreamLatency()V
    .locals 1

    const/4 v0, 0x0

    .line 3944
    iput-boolean v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->enableStreamLatency_:Z

    return-void
.end method

.method private clearHistogramIntervalSizeUsec()V
    .locals 2

    const-wide/16 v0, 0x0

    .line 3768
    iput-wide v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->histogramIntervalSizeUsec_:J

    return-void
.end method

.method private clearNumHistogramIntervals()V
    .locals 2

    const-wide/16 v0, 0x0

    .line 3809
    iput-wide v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->numHistogramIntervals_:J

    return-void
.end method

.method private clearTraceEnabled()V
    .locals 1

    const/4 v0, 0x0

    .line 4499
    iput-boolean v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceEnabled_:Z

    return-void
.end method

.method private clearTraceEventTypesDisabled()V
    .locals 1

    .line 4131
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyIntList()Lcom/google/protobuf/Internal$IntList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceEventTypesDisabled_:Lcom/google/protobuf/Internal$IntList;

    return-void
.end method

.method private clearTraceLogCapacity()V
    .locals 2

    const-wide/16 v0, 0x0

    .line 4032
    iput-wide v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceLogCapacity_:J

    return-void
.end method

.method private clearTraceLogCount()V
    .locals 1

    const/4 v0, 0x0

    .line 4247
    iput v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceLogCount_:I

    return-void
.end method

.method private clearTraceLogDisabled()V
    .locals 1

    const/4 v0, 0x0

    .line 4461
    iput-boolean v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceLogDisabled_:Z

    return-void
.end method

.method private clearTraceLogDurationEvents()V
    .locals 1

    const/4 v0, 0x0

    .line 4376
    iput-boolean v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceLogDurationEvents_:Z

    return-void
.end method

.method private clearTraceLogInstantEvents()V
    .locals 1

    const/4 v0, 0x0

    .line 4540
    iput-boolean v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceLogInstantEvents_:Z

    return-void
.end method

.method private clearTraceLogIntervalCount()V
    .locals 1

    const/4 v0, 0x0

    .line 4420
    iput v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceLogIntervalCount_:I

    return-void
.end method

.method private clearTraceLogIntervalUsec()V
    .locals 2

    const-wide/16 v0, 0x0

    .line 4288
    iput-wide v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceLogIntervalUsec_:J

    return-void
.end method

.method private clearTraceLogMarginUsec()V
    .locals 2

    const-wide/16 v0, 0x0

    .line 4332
    iput-wide v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceLogMarginUsec_:J

    return-void
.end method

.method private clearTraceLogPath()V
    .locals 1

    .line 4188
    invoke-static {}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->getDefaultInstance()Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    move-result-object v0

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->getTraceLogPath()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceLogPath_:Ljava/lang/String;

    return-void
.end method

.method private clearUsePacketTimestampForAddedPacket()V
    .locals 1

    const/4 v0, 0x0

    .line 3991
    iput-boolean v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->usePacketTimestampForAddedPacket_:Z

    return-void
.end method

.method private ensureTraceEventTypesDisabledIsMutable()V
    .locals 2

    .line 4077
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceEventTypesDisabled_:Lcom/google/protobuf/Internal$IntList;

    .line 4078
    invoke-interface {v0}, Lcom/google/protobuf/Internal$ProtobufList;->isModifiable()Z

    move-result v1

    if-nez v1, :cond_0

    .line 4080
    invoke-static {v0}, Lcom/google/protobuf/GeneratedMessageLite;->mutableCopy(Lcom/google/protobuf/Internal$IntList;)Lcom/google/protobuf/Internal$IntList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceEventTypesDisabled_:Lcom/google/protobuf/Internal$IntList;

    :cond_0
    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;
    .locals 1

    .line 5710
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    return-object v0
.end method

.method public static newBuilder()Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1

    .line 4687
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;
    .locals 1

    .line 4690
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;
    .locals 1

    .line 4663
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;
    .locals 1

    .line 4670
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;
    .locals 1

    .line 4626
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;
    .locals 1

    .line 4633
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;
    .locals 1

    .line 4675
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;
    .locals 1

    .line 4682
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;
    .locals 1

    .line 4650
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;
    .locals 1

    .line 4657
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;
    .locals 1

    .line 4613
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;
    .locals 1

    .line 4620
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;
    .locals 1

    .line 4638
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;
    .locals 1

    .line 4645
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;",
            ">;"
        }
    .end annotation

    .line 5716
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private setCalculatorFilter(Ljava/lang/String;)V
    .locals 0

    .line 4580
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 4582
    iput-object p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->calculatorFilter_:Ljava/lang/String;

    return-void
.end method

.method private setCalculatorFilterBytes(Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 4605
    invoke-static {p1}, Lcom/google/protobuf/AbstractMessageLite;->checkByteStringIsUtf8(Lcom/google/protobuf/ByteString;)V

    .line 4606
    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->calculatorFilter_:Ljava/lang/String;

    return-void
.end method

.method private setEnableInputOutputLatency(Z)V
    .locals 0

    .line 3846
    iput-boolean p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->enableInputOutputLatency_:Z

    return-void
.end method

.method private setEnableProfiler(Z)V
    .locals 0

    .line 3889
    iput-boolean p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->enableProfiler_:Z

    return-void
.end method

.method private setEnableStreamLatency(Z)V
    .locals 0

    .line 3931
    iput-boolean p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->enableStreamLatency_:Z

    return-void
.end method

.method private setHistogramIntervalSizeUsec(J)V
    .locals 0

    .line 3755
    iput-wide p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->histogramIntervalSizeUsec_:J

    return-void
.end method

.method private setNumHistogramIntervals(J)V
    .locals 0

    .line 3797
    iput-wide p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->numHistogramIntervals_:J

    return-void
.end method

.method private setTraceEnabled(Z)V
    .locals 0

    .line 4488
    iput-boolean p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceEnabled_:Z

    return-void
.end method

.method private setTraceEventTypesDisabled(II)V
    .locals 1

    .line 4094
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->ensureTraceEventTypesDisabledIsMutable()V

    .line 4095
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceEventTypesDisabled_:Lcom/google/protobuf/Internal$IntList;

    invoke-interface {v0, p1, p2}, Lcom/google/protobuf/Internal$IntList;->setInt(II)I

    return-void
.end method

.method private setTraceLogCapacity(J)V
    .locals 0

    .line 4020
    iput-wide p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceLogCapacity_:J

    return-void
.end method

.method private setTraceLogCount(I)V
    .locals 0

    .line 4234
    iput p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceLogCount_:I

    return-void
.end method

.method private setTraceLogDisabled(Z)V
    .locals 0

    .line 4449
    iput-boolean p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceLogDisabled_:Z

    return-void
.end method

.method private setTraceLogDurationEvents(Z)V
    .locals 0

    .line 4363
    iput-boolean p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceLogDurationEvents_:Z

    return-void
.end method

.method private setTraceLogInstantEvents(Z)V
    .locals 0

    .line 4528
    iput-boolean p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceLogInstantEvents_:Z

    return-void
.end method

.method private setTraceLogIntervalCount(I)V
    .locals 0

    .line 4407
    iput p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceLogIntervalCount_:I

    return-void
.end method

.method private setTraceLogIntervalUsec(J)V
    .locals 0

    .line 4276
    iput-wide p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceLogIntervalUsec_:J

    return-void
.end method

.method private setTraceLogMarginUsec(J)V
    .locals 0

    .line 4319
    iput-wide p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceLogMarginUsec_:J

    return-void
.end method

.method private setTraceLogPath(Ljava/lang/String;)V
    .locals 0

    .line 4174
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 4176
    iput-object p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceLogPath_:Ljava/lang/String;

    return-void
.end method

.method private setTraceLogPathBytes(Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 4201
    invoke-static {p1}, Lcom/google/protobuf/AbstractMessageLite;->checkByteStringIsUtf8(Lcom/google/protobuf/ByteString;)V

    .line 4202
    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceLogPath_:Ljava/lang/String;

    return-void
.end method

.method private setUsePacketTimestampForAddedPacket(Z)V
    .locals 0

    .line 3977
    iput-boolean p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->usePacketTimestampForAddedPacket_:Z

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 20

    .line 5633
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual/range {p1 .. p1}, Ljava/lang/Enum;->ordinal()I

    move-result v1

    aget v0, v0, v1

    const/4 v1, 0x0

    packed-switch v0, :pswitch_data_0

    .line 5694
    new-instance v0, Ljava/lang/UnsupportedOperationException;

    invoke-direct {v0}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw v0

    :pswitch_0
    return-object v1

    :pswitch_1
    const/4 v0, 0x1

    .line 5688
    invoke-static {v0}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object v0

    return-object v0

    .line 5673
    :pswitch_2
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->PARSER:Lcom/google/protobuf/Parser;

    if-nez v0, :cond_1

    .line 5675
    const-class v1, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    monitor-enter v1

    .line 5676
    :try_start_0
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->PARSER:Lcom/google/protobuf/Parser;

    if-nez v0, :cond_0

    .line 5678
    new-instance v0, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object v2, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-direct {v0, v2}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 5681
    sput-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_0

    :catchall_0
    move-exception v0

    goto :goto_1

    .line 5683
    :cond_0
    :goto_0
    monitor-exit v1

    return-object v0

    :goto_1
    monitor-exit v1
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0

    :cond_1
    return-object v0

    .line 5670
    :pswitch_3
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    return-object v0

    .line 5641
    :pswitch_4
    const-string v2, "histogramIntervalSizeUsec_"

    const-string v3, "numHistogramIntervals_"

    const-string v4, "enableInputOutputLatency_"

    const-string v5, "enableProfiler_"

    const-string v6, "enableStreamLatency_"

    const-string v7, "usePacketTimestampForAddedPacket_"

    const-string v8, "traceLogCapacity_"

    const-string v9, "traceEventTypesDisabled_"

    const-string v10, "traceLogPath_"

    const-string v11, "traceLogCount_"

    const-string v12, "traceLogIntervalUsec_"

    const-string v13, "traceLogMarginUsec_"

    const-string v14, "traceLogDurationEvents_"

    const-string v15, "traceLogIntervalCount_"

    const-string v16, "traceLogDisabled_"

    const-string v17, "traceEnabled_"

    const-string v18, "traceLogInstantEvents_"

    const-string v19, "calculatorFilter_"

    filled-new-array/range {v2 .. v19}, [Ljava/lang/Object;

    move-result-object v0

    .line 5661
    const-string v1, "\u0000\u0012\u0000\u0000\u0001\u0012\u0012\u0000\u0001\u0000\u0001\u0002\u0002\u0002\u0003\u0007\u0004\u0007\u0005\u0007\u0006\u0007\u0007\u0002\u0008\'\t\u0208\n\u0004\u000b\u0002\u000c\u0002\r\u0007\u000e\u0004\u000f\u0007\u0010\u0007\u0011\u0007\u0012\u0208"

    .line 5666
    sget-object v2, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-static {v2, v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    return-object v0

    .line 5638
    :pswitch_5
    new-instance v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;

    invoke-direct {v0, v1}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;-><init>(Lcom/google/mediapipe/proto/CalculatorProto$1;)V

    return-object v0

    .line 5635
    :pswitch_6
    new-instance v0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    invoke-direct {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;-><init>()V

    return-object v0

    nop

    :pswitch_data_0
    .packed-switch 0x1
        :pswitch_6
        :pswitch_5
        :pswitch_4
        :pswitch_3
        :pswitch_2
        :pswitch_1
        :pswitch_0
    .end packed-switch
.end method

.method public getCalculatorFilter()Ljava/lang/String;
    .locals 1

    .line 4555
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->calculatorFilter_:Ljava/lang/String;

    return-object v0
.end method

.method public getCalculatorFilterBytes()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 4568
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->calculatorFilter_:Ljava/lang/String;

    invoke-static {v0}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic getDefaultInstanceForType()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 3717
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getEnableInputOutputLatency()Z
    .locals 1
    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .line 3829
    iget-boolean v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->enableInputOutputLatency_:Z

    return v0
.end method

.method public getEnableProfiler()Z
    .locals 1

    .line 3877
    iget-boolean v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->enableProfiler_:Z

    return v0
.end method

.method public getEnableStreamLatency()Z
    .locals 1

    .line 3917
    iget-boolean v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->enableStreamLatency_:Z

    return v0
.end method

.method public getHistogramIntervalSizeUsec()J
    .locals 2

    .line 3741
    iget-wide v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->histogramIntervalSizeUsec_:J

    return-wide v0
.end method

.method public getNumHistogramIntervals()J
    .locals 2

    .line 3784
    iget-wide v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->numHistogramIntervals_:J

    return-wide v0
.end method

.method public getTraceEnabled()Z
    .locals 1

    .line 4476
    iget-boolean v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceEnabled_:Z

    return v0
.end method

.method public getTraceEventTypesDisabled(I)I
    .locals 1

    .line 4073
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceEventTypesDisabled_:Lcom/google/protobuf/Internal$IntList;

    invoke-interface {v0, p1}, Lcom/google/protobuf/Internal$IntList;->getInt(I)I

    move-result p1

    return p1
.end method

.method public getTraceEventTypesDisabledCount()I
    .locals 1

    .line 4060
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceEventTypesDisabled_:Lcom/google/protobuf/Internal$IntList;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    return v0
.end method

.method public getTraceEventTypesDisabledList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Ljava/lang/Integer;",
            ">;"
        }
    .end annotation

    .line 4048
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceEventTypesDisabled_:Lcom/google/protobuf/Internal$IntList;

    return-object v0
.end method

.method public getTraceLogCapacity()J
    .locals 2

    .line 4007
    iget-wide v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceLogCapacity_:J

    return-wide v0
.end method

.method public getTraceLogCount()I
    .locals 1

    .line 4220
    iget v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceLogCount_:I

    return v0
.end method

.method public getTraceLogDisabled()Z
    .locals 1

    .line 4436
    iget-boolean v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceLogDisabled_:Z

    return v0
.end method

.method public getTraceLogDurationEvents()Z
    .locals 1
    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .line 4349
    iget-boolean v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceLogDurationEvents_:Z

    return v0
.end method

.method public getTraceLogInstantEvents()Z
    .locals 1

    .line 4515
    iget-boolean v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceLogInstantEvents_:Z

    return v0
.end method

.method public getTraceLogIntervalCount()I
    .locals 1

    .line 4393
    iget v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceLogIntervalCount_:I

    return v0
.end method

.method public getTraceLogIntervalUsec()J
    .locals 2

    .line 4263
    iget-wide v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceLogIntervalUsec_:J

    return-wide v0
.end method

.method public getTraceLogMarginUsec()J
    .locals 2

    .line 4305
    iget-wide v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceLogMarginUsec_:J

    return-wide v0
.end method

.method public getTraceLogPath()Ljava/lang/String;
    .locals 1

    .line 4147
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceLogPath_:Ljava/lang/String;

    return-object v0
.end method

.method public getTraceLogPathBytes()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 4161
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->traceLogPath_:Ljava/lang/String;

    invoke-static {v0}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object v0

    return-object v0
.end method

.method public getUsePacketTimestampForAddedPacket()Z
    .locals 1

    .line 3962
    iget-boolean v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->usePacketTimestampForAddedPacket_:Z

    return v0
.end method

.method public bridge synthetic newBuilderForType()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 3717
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 3717
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
