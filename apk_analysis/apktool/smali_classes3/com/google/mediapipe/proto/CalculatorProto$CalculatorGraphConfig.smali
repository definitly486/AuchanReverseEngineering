.class public final Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "CalculatorProto.java"

# interfaces
.implements Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfigOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/proto/CalculatorProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "CalculatorGraphConfig"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Node;,
        Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$NodeOrBuilder;,
        Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;",
        "Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;",
        ">;",
        "Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfigOrBuilder;"
    }
.end annotation


# static fields
.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

.field public static final EXECUTOR_FIELD_NUMBER:I = 0xe

.field public static final GRAPH_OPTIONS_FIELD_NUMBER:I = 0x3ea

.field public static final INPUT_SIDE_PACKET_FIELD_NUMBER:I = 0x10

.field public static final INPUT_STREAM_FIELD_NUMBER:I = 0xa

.field public static final INPUT_STREAM_HANDLER_FIELD_NUMBER:I = 0xc

.field public static final MAX_QUEUE_SIZE_FIELD_NUMBER:I = 0xb

.field public static final NODE_FIELD_NUMBER:I = 0x1

.field public static final NUM_THREADS_FIELD_NUMBER:I = 0x8

.field public static final OPTIONS_FIELD_NUMBER:I = 0x3e9

.field public static final OUTPUT_SIDE_PACKET_FIELD_NUMBER:I = 0x11

.field public static final OUTPUT_STREAM_FIELD_NUMBER:I = 0xf

.field public static final OUTPUT_STREAM_HANDLER_FIELD_NUMBER:I = 0xd

.field public static final PACKAGE_FIELD_NUMBER:I = 0x13

.field public static final PACKET_FACTORY_FIELD_NUMBER:I = 0x6

.field public static final PACKET_GENERATOR_FIELD_NUMBER:I = 0x7

.field private static volatile PARSER:Lcom/google/protobuf/Parser; = null
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;",
            ">;"
        }
    .end annotation
.end field

.field public static final PROFILER_CONFIG_FIELD_NUMBER:I = 0x12

.field public static final REPORT_DEADLOCK_FIELD_NUMBER:I = 0x15

.field public static final RUNTIME_INFO_FIELD_NUMBER:I = 0x16

.field public static final STATUS_HANDLER_FIELD_NUMBER:I = 0x9

.field public static final TYPE_FIELD_NUMBER:I = 0x14


# instance fields
.field private bitField0_:I

.field private executor_:Lcom/google/protobuf/Internal$ProtobufList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Internal$ProtobufList<",
            "Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;",
            ">;"
        }
    .end annotation
.end field

.field private graphOptions_:Lcom/google/protobuf/Internal$ProtobufList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Internal$ProtobufList<",
            "Lcom/google/protobuf/Any;",
            ">;"
        }
    .end annotation
.end field

.field private inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Internal$ProtobufList<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field private inputStreamHandler_:Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

.field private inputStream_:Lcom/google/protobuf/Internal$ProtobufList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Internal$ProtobufList<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field private maxQueueSize_:I

.field private memoizedIsInitialized:B

.field private node_:Lcom/google/protobuf/Internal$ProtobufList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Internal$ProtobufList<",
            "Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Node;",
            ">;"
        }
    .end annotation
.end field

.field private numThreads_:I

.field private options_:Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

.field private outputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Internal$ProtobufList<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field private outputStreamHandler_:Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

.field private outputStream_:Lcom/google/protobuf/Internal$ProtobufList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Internal$ProtobufList<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field private package_:Ljava/lang/String;

.field private packetFactory_:Lcom/google/protobuf/Internal$ProtobufList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Internal$ProtobufList<",
            "Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;",
            ">;"
        }
    .end annotation
.end field

.field private packetGenerator_:Lcom/google/protobuf/Internal$ProtobufList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Internal$ProtobufList<",
            "Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;",
            ">;"
        }
    .end annotation
.end field

.field private profilerConfig_:Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

.field private reportDeadlock_:Z

.field private runtimeInfo_:Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

.field private statusHandler_:Lcom/google/protobuf/Internal$ProtobufList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Internal$ProtobufList<",
            "Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;",
            ">;"
        }
    .end annotation
.end field

.field private type_:Ljava/lang/String;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 16369
    new-instance v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-direct {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;-><init>()V

    .line 16372
    sput-object v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    .line 16373
    const-class v1, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    .line 6748
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    const/4 v0, 0x2

    .line 16285
    iput-byte v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->memoizedIsInitialized:B

    .line 6749
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->node_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 6750
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->packetFactory_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 6751
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->packetGenerator_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 6752
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->statusHandler_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 6753
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->inputStream_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 6754
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->outputStream_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 6755
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 6756
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->outputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 6757
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->executor_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 6758
    const-string v0, ""

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->package_:Ljava/lang/String;

    .line 6759
    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->type_:Ljava/lang/String;

    .line 6760
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->graphOptions_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method static synthetic access$16600()Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;
    .locals 1

    .line 6743
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    return-object v0
.end method

.method static synthetic access$16700(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Node;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->setNode(ILcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Node;)V

    return-void
.end method

.method static synthetic access$16800(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Node;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->addNode(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Node;)V

    return-void
.end method

.method static synthetic access$16900(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Node;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->addNode(ILcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Node;)V

    return-void
.end method

.method static synthetic access$17000(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Ljava/lang/Iterable;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->addAllNode(Ljava/lang/Iterable;)V

    return-void
.end method

.method static synthetic access$17100(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->clearNode()V

    return-void
.end method

.method static synthetic access$17200(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;I)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->removeNode(I)V

    return-void
.end method

.method static synthetic access$17300(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->setPacketFactory(ILcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;)V

    return-void
.end method

.method static synthetic access$17400(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->addPacketFactory(Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;)V

    return-void
.end method

.method static synthetic access$17500(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->addPacketFactory(ILcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;)V

    return-void
.end method

.method static synthetic access$17600(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Ljava/lang/Iterable;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->addAllPacketFactory(Ljava/lang/Iterable;)V

    return-void
.end method

.method static synthetic access$17700(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->clearPacketFactory()V

    return-void
.end method

.method static synthetic access$17800(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;I)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->removePacketFactory(I)V

    return-void
.end method

.method static synthetic access$17900(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->setPacketGenerator(ILcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;)V

    return-void
.end method

.method static synthetic access$18000(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->addPacketGenerator(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;)V

    return-void
.end method

.method static synthetic access$18100(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->addPacketGenerator(ILcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;)V

    return-void
.end method

.method static synthetic access$18200(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Ljava/lang/Iterable;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->addAllPacketGenerator(Ljava/lang/Iterable;)V

    return-void
.end method

.method static synthetic access$18300(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->clearPacketGenerator()V

    return-void
.end method

.method static synthetic access$18400(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;I)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->removePacketGenerator(I)V

    return-void
.end method

.method static synthetic access$18500(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;I)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->setNumThreads(I)V

    return-void
.end method

.method static synthetic access$18600(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->clearNumThreads()V

    return-void
.end method

.method static synthetic access$18700(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->setStatusHandler(ILcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;)V

    return-void
.end method

.method static synthetic access$18800(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->addStatusHandler(Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;)V

    return-void
.end method

.method static synthetic access$18900(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->addStatusHandler(ILcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;)V

    return-void
.end method

.method static synthetic access$19000(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Ljava/lang/Iterable;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->addAllStatusHandler(Ljava/lang/Iterable;)V

    return-void
.end method

.method static synthetic access$19100(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->clearStatusHandler()V

    return-void
.end method

.method static synthetic access$19200(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;I)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->removeStatusHandler(I)V

    return-void
.end method

.method static synthetic access$19300(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILjava/lang/String;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->setInputStream(ILjava/lang/String;)V

    return-void
.end method

.method static synthetic access$19400(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Ljava/lang/String;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->addInputStream(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$19500(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Ljava/lang/Iterable;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->addAllInputStream(Ljava/lang/Iterable;)V

    return-void
.end method

.method static synthetic access$19600(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->clearInputStream()V

    return-void
.end method

.method static synthetic access$19700(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->addInputStreamBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method static synthetic access$19800(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILjava/lang/String;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->setOutputStream(ILjava/lang/String;)V

    return-void
.end method

.method static synthetic access$19900(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Ljava/lang/String;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->addOutputStream(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$20000(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Ljava/lang/Iterable;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->addAllOutputStream(Ljava/lang/Iterable;)V

    return-void
.end method

.method static synthetic access$20100(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->clearOutputStream()V

    return-void
.end method

.method static synthetic access$20200(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->addOutputStreamBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method static synthetic access$20300(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILjava/lang/String;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->setInputSidePacket(ILjava/lang/String;)V

    return-void
.end method

.method static synthetic access$20400(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Ljava/lang/String;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->addInputSidePacket(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$20500(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Ljava/lang/Iterable;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->addAllInputSidePacket(Ljava/lang/Iterable;)V

    return-void
.end method

.method static synthetic access$20600(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->clearInputSidePacket()V

    return-void
.end method

.method static synthetic access$20700(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->addInputSidePacketBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method static synthetic access$20800(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILjava/lang/String;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->setOutputSidePacket(ILjava/lang/String;)V

    return-void
.end method

.method static synthetic access$20900(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Ljava/lang/String;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->addOutputSidePacket(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$21000(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Ljava/lang/Iterable;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->addAllOutputSidePacket(Ljava/lang/Iterable;)V

    return-void
.end method

.method static synthetic access$21100(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->clearOutputSidePacket()V

    return-void
.end method

.method static synthetic access$21200(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->addOutputSidePacketBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method static synthetic access$21300(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;I)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->setMaxQueueSize(I)V

    return-void
.end method

.method static synthetic access$21400(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->clearMaxQueueSize()V

    return-void
.end method

.method static synthetic access$21500(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Z)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->setReportDeadlock(Z)V

    return-void
.end method

.method static synthetic access$21600(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->clearReportDeadlock()V

    return-void
.end method

.method static synthetic access$21700(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->setRuntimeInfo(Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;)V

    return-void
.end method

.method static synthetic access$21800(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->mergeRuntimeInfo(Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;)V

    return-void
.end method

.method static synthetic access$21900(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->clearRuntimeInfo()V

    return-void
.end method

.method static synthetic access$22000(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->setInputStreamHandler(Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;)V

    return-void
.end method

.method static synthetic access$22100(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->mergeInputStreamHandler(Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;)V

    return-void
.end method

.method static synthetic access$22200(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->clearInputStreamHandler()V

    return-void
.end method

.method static synthetic access$22300(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->setOutputStreamHandler(Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;)V

    return-void
.end method

.method static synthetic access$22400(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->mergeOutputStreamHandler(Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;)V

    return-void
.end method

.method static synthetic access$22500(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->clearOutputStreamHandler()V

    return-void
.end method

.method static synthetic access$22600(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->setExecutor(ILcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;)V

    return-void
.end method

.method static synthetic access$22700(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->addExecutor(Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;)V

    return-void
.end method

.method static synthetic access$22800(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->addExecutor(ILcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;)V

    return-void
.end method

.method static synthetic access$22900(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Ljava/lang/Iterable;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->addAllExecutor(Ljava/lang/Iterable;)V

    return-void
.end method

.method static synthetic access$23000(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->clearExecutor()V

    return-void
.end method

.method static synthetic access$23100(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;I)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->removeExecutor(I)V

    return-void
.end method

.method static synthetic access$23200(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->setProfilerConfig(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V

    return-void
.end method

.method static synthetic access$23300(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->mergeProfilerConfig(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V

    return-void
.end method

.method static synthetic access$23400(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->clearProfilerConfig()V

    return-void
.end method

.method static synthetic access$23500(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Ljava/lang/String;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->setPackage(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$23600(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->clearPackage()V

    return-void
.end method

.method static synthetic access$23700(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->setPackageBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method static synthetic access$23800(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Ljava/lang/String;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->setType(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$23900(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->clearType()V

    return-void
.end method

.method static synthetic access$24000(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->setTypeBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method static synthetic access$24100(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->setOptions(Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)V

    return-void
.end method

.method static synthetic access$24200(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->mergeOptions(Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)V

    return-void
.end method

.method static synthetic access$24300(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->clearOptions()V

    return-void
.end method

.method static synthetic access$24400(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILcom/google/protobuf/Any;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->setGraphOptions(ILcom/google/protobuf/Any;)V

    return-void
.end method

.method static synthetic access$24500(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Lcom/google/protobuf/Any;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->addGraphOptions(Lcom/google/protobuf/Any;)V

    return-void
.end method

.method static synthetic access$24600(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;ILcom/google/protobuf/Any;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->addGraphOptions(ILcom/google/protobuf/Any;)V

    return-void
.end method

.method static synthetic access$24700(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;Ljava/lang/Iterable;)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->addAllGraphOptions(Ljava/lang/Iterable;)V

    return-void
.end method

.method static synthetic access$24800(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)V
    .locals 0

    .line 6743
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->clearGraphOptions()V

    return-void
.end method

.method static synthetic access$24900(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;I)V
    .locals 0

    .line 6743
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->removeGraphOptions(I)V

    return-void
.end method

.method private addAllExecutor(Ljava/lang/Iterable;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "+",
            "Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;",
            ">;)V"
        }
    .end annotation

    .line 13207
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensureExecutorIsMutable()V

    .line 13208
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->executor_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-static {p1, v0}, Lcom/google/protobuf/AbstractMessageLite;->addAll(Ljava/lang/Iterable;Ljava/util/List;)V

    return-void
.end method

.method private addAllGraphOptions(Ljava/lang/Iterable;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "+",
            "Lcom/google/protobuf/Any;",
            ">;)V"
        }
    .end annotation

    .line 13651
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensureGraphOptionsIsMutable()V

    .line 13652
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->graphOptions_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-static {p1, v0}, Lcom/google/protobuf/AbstractMessageLite;->addAll(Ljava/lang/Iterable;Ljava/util/List;)V

    return-void
.end method

.method private addAllInputSidePacket(Ljava/lang/Iterable;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "Ljava/lang/String;",
            ">;)V"
        }
    .end annotation

    .line 12524
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensureInputSidePacketIsMutable()V

    .line 12525
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-static {p1, v0}, Lcom/google/protobuf/AbstractMessageLite;->addAll(Ljava/lang/Iterable;Ljava/util/List;)V

    return-void
.end method

.method private addAllInputStream(Ljava/lang/Iterable;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "Ljava/lang/String;",
            ">;)V"
        }
    .end annotation

    .line 12260
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensureInputStreamIsMutable()V

    .line 12261
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->inputStream_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-static {p1, v0}, Lcom/google/protobuf/AbstractMessageLite;->addAll(Ljava/lang/Iterable;Ljava/util/List;)V

    return-void
.end method

.method private addAllNode(Ljava/lang/Iterable;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "+",
            "Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Node;",
            ">;)V"
        }
    .end annotation

    .line 11429
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensureNodeIsMutable()V

    .line 11430
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->node_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-static {p1, v0}, Lcom/google/protobuf/AbstractMessageLite;->addAll(Ljava/lang/Iterable;Ljava/util/List;)V

    return-void
.end method

.method private addAllOutputSidePacket(Ljava/lang/Iterable;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "Ljava/lang/String;",
            ">;)V"
        }
    .end annotation

    .line 12653
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensureOutputSidePacketIsMutable()V

    .line 12654
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->outputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-static {p1, v0}, Lcom/google/protobuf/AbstractMessageLite;->addAll(Ljava/lang/Iterable;Ljava/util/List;)V

    return-void
.end method

.method private addAllOutputStream(Ljava/lang/Iterable;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "Ljava/lang/String;",
            ">;)V"
        }
    .end annotation

    .line 12395
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensureOutputStreamIsMutable()V

    .line 12396
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->outputStream_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-static {p1, v0}, Lcom/google/protobuf/AbstractMessageLite;->addAll(Ljava/lang/Iterable;Ljava/util/List;)V

    return-void
.end method

.method private addAllPacketFactory(Ljava/lang/Iterable;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "+",
            "Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;",
            ">;)V"
        }
    .end annotation

    .line 11594
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensurePacketFactoryIsMutable()V

    .line 11595
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->packetFactory_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-static {p1, v0}, Lcom/google/protobuf/AbstractMessageLite;->addAll(Ljava/lang/Iterable;Ljava/util/List;)V

    return-void
.end method

.method private addAllPacketGenerator(Ljava/lang/Iterable;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "+",
            "Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;",
            ">;)V"
        }
    .end annotation

    .line 11828
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensurePacketGeneratorIsMutable()V

    .line 11829
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->packetGenerator_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-static {p1, v0}, Lcom/google/protobuf/AbstractMessageLite;->addAll(Ljava/lang/Iterable;Ljava/util/List;)V

    return-void
.end method

.method private addAllStatusHandler(Ljava/lang/Iterable;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "+",
            "Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;",
            ">;)V"
        }
    .end annotation

    .line 12099
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensureStatusHandlerIsMutable()V

    .line 12100
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->statusHandler_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-static {p1, v0}, Lcom/google/protobuf/AbstractMessageLite;->addAll(Ljava/lang/Iterable;Ljava/util/List;)V

    return-void
.end method

.method private addExecutor(ILcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;)V
    .locals 1

    .line 13189
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 13190
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensureExecutorIsMutable()V

    .line 13191
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->executor_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->add(ILjava/lang/Object;)V

    return-void
.end method

.method private addExecutor(Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;)V
    .locals 1

    .line 13171
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 13172
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensureExecutorIsMutable()V

    .line 13173
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->executor_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private addGraphOptions(ILcom/google/protobuf/Any;)V
    .locals 1

    .line 13638
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 13639
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensureGraphOptionsIsMutable()V

    .line 13640
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->graphOptions_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->add(ILjava/lang/Object;)V

    return-void
.end method

.method private addGraphOptions(Lcom/google/protobuf/Any;)V
    .locals 1

    .line 13625
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 13626
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensureGraphOptionsIsMutable()V

    .line 13627
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->graphOptions_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private addInputSidePacket(Ljava/lang/String;)V
    .locals 1

    .line 12510
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 12511
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensureInputSidePacketIsMutable()V

    .line 12512
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private addInputSidePacketBytes(Lcom/google/protobuf/ByteString;)V
    .locals 1

    .line 12548
    invoke-static {p1}, Lcom/google/protobuf/AbstractMessageLite;->checkByteStringIsUtf8(Lcom/google/protobuf/ByteString;)V

    .line 12549
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensureInputSidePacketIsMutable()V

    .line 12550
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private addInputStream(Ljava/lang/String;)V
    .locals 1

    .line 12243
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 12244
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensureInputStreamIsMutable()V

    .line 12245
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->inputStream_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private addInputStreamBytes(Lcom/google/protobuf/ByteString;)V
    .locals 1

    .line 12290
    invoke-static {p1}, Lcom/google/protobuf/AbstractMessageLite;->checkByteStringIsUtf8(Lcom/google/protobuf/ByteString;)V

    .line 12291
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensureInputStreamIsMutable()V

    .line 12292
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->inputStream_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private addNode(ILcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Node;)V
    .locals 1

    .line 11416
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 11417
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensureNodeIsMutable()V

    .line 11418
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->node_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->add(ILjava/lang/Object;)V

    return-void
.end method

.method private addNode(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Node;)V
    .locals 1

    .line 11403
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 11404
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensureNodeIsMutable()V

    .line 11405
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->node_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private addOutputSidePacket(Ljava/lang/String;)V
    .locals 1

    .line 12639
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 12640
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensureOutputSidePacketIsMutable()V

    .line 12641
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->outputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private addOutputSidePacketBytes(Lcom/google/protobuf/ByteString;)V
    .locals 1

    .line 12677
    invoke-static {p1}, Lcom/google/protobuf/AbstractMessageLite;->checkByteStringIsUtf8(Lcom/google/protobuf/ByteString;)V

    .line 12678
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensureOutputSidePacketIsMutable()V

    .line 12679
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->outputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private addOutputStream(Ljava/lang/String;)V
    .locals 1

    .line 12381
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 12382
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensureOutputStreamIsMutable()V

    .line 12383
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->outputStream_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private addOutputStreamBytes(Lcom/google/protobuf/ByteString;)V
    .locals 1

    .line 12419
    invoke-static {p1}, Lcom/google/protobuf/AbstractMessageLite;->checkByteStringIsUtf8(Lcom/google/protobuf/ByteString;)V

    .line 12420
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensureOutputStreamIsMutable()V

    .line 12421
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->outputStream_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private addPacketFactory(ILcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;)V
    .locals 1

    .line 11578
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 11579
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensurePacketFactoryIsMutable()V

    .line 11580
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->packetFactory_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->add(ILjava/lang/Object;)V

    return-void
.end method

.method private addPacketFactory(Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;)V
    .locals 1

    .line 11562
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 11563
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensurePacketFactoryIsMutable()V

    .line 11564
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->packetFactory_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private addPacketGenerator(ILcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;)V
    .locals 1

    .line 11805
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 11806
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensurePacketGeneratorIsMutable()V

    .line 11807
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->packetGenerator_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->add(ILjava/lang/Object;)V

    return-void
.end method

.method private addPacketGenerator(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;)V
    .locals 1

    .line 11782
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 11783
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensurePacketGeneratorIsMutable()V

    .line 11784
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->packetGenerator_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private addStatusHandler(ILcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;)V
    .locals 1

    .line 12079
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 12080
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensureStatusHandlerIsMutable()V

    .line 12081
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->statusHandler_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->add(ILjava/lang/Object;)V

    return-void
.end method

.method private addStatusHandler(Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;)V
    .locals 1

    .line 12059
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 12060
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensureStatusHandlerIsMutable()V

    .line 12061
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->statusHandler_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private clearExecutor()V
    .locals 1

    .line 13224
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->executor_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method private clearGraphOptions()V
    .locals 1

    .line 13663
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->graphOptions_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method private clearInputSidePacket()V
    .locals 1

    .line 12536
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method private clearInputStream()V
    .locals 1

    .line 12275
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->inputStream_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method private clearInputStreamHandler()V
    .locals 1

    const/4 v0, 0x0

    .line 12970
    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->inputStreamHandler_:Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    .line 12971
    iget v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->bitField0_:I

    and-int/lit8 v0, v0, -0x3

    iput v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->bitField0_:I

    return-void
.end method

.method private clearMaxQueueSize()V
    .locals 1

    const/4 v0, 0x0

    .line 12750
    iput v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->maxQueueSize_:I

    return-void
.end method

.method private clearNode()V
    .locals 1

    .line 11441
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->node_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method private clearNumThreads()V
    .locals 1

    const/4 v0, 0x0

    .line 11921
    iput v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->numThreads_:I

    return-void
.end method

.method private clearOptions()V
    .locals 1

    const/4 v0, 0x0

    .line 13535
    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->options_:Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    .line 13536
    iget v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->bitField0_:I

    and-int/lit8 v0, v0, -0x11

    iput v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->bitField0_:I

    return-void
.end method

.method private clearOutputSidePacket()V
    .locals 1

    .line 12665
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->outputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method private clearOutputStream()V
    .locals 1

    .line 12407
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->outputStream_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method private clearOutputStreamHandler()V
    .locals 1

    const/4 v0, 0x0

    .line 13046
    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->outputStreamHandler_:Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    .line 13047
    iget v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->bitField0_:I

    and-int/lit8 v0, v0, -0x5

    iput v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->bitField0_:I

    return-void
.end method

.method private clearPackage()V
    .locals 1

    .line 13382
    invoke-static {}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getDefaultInstance()Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    move-result-object v0

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getPackage()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->package_:Ljava/lang/String;

    return-void
.end method

.method private clearPacketFactory()V
    .locals 1

    .line 11609
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->packetFactory_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method private clearPacketGenerator()V
    .locals 1

    .line 11850
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->packetGenerator_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method private clearProfilerConfig()V
    .locals 1

    const/4 v0, 0x0

    .line 13320
    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->profilerConfig_:Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    .line 13321
    iget v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->bitField0_:I

    and-int/lit8 v0, v0, -0x9

    iput v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->bitField0_:I

    return-void
.end method

.method private clearReportDeadlock()V
    .locals 1

    const/4 v0, 0x0

    .line 12794
    iput-boolean v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->reportDeadlock_:Z

    return-void
.end method

.method private clearRuntimeInfo()V
    .locals 1

    const/4 v0, 0x0

    .line 12864
    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->runtimeInfo_:Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    .line 12865
    iget v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->bitField0_:I

    and-int/lit8 v0, v0, -0x2

    iput v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->bitField0_:I

    return-void
.end method

.method private clearStatusHandler()V
    .locals 1

    .line 12118
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->statusHandler_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method private clearType()V
    .locals 1

    .line 13455
    invoke-static {}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getDefaultInstance()Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    move-result-object v0

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->getType()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->type_:Ljava/lang/String;

    return-void
.end method

.method private ensureExecutorIsMutable()V
    .locals 2

    .line 13133
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->executor_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 13134
    invoke-interface {v0}, Lcom/google/protobuf/Internal$ProtobufList;->isModifiable()Z

    move-result v1

    if-nez v1, :cond_0

    .line 13136
    invoke-static {v0}, Lcom/google/protobuf/GeneratedMessageLite;->mutableCopy(Lcom/google/protobuf/Internal$ProtobufList;)Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->executor_:Lcom/google/protobuf/Internal$ProtobufList;

    :cond_0
    return-void
.end method

.method private ensureGraphOptionsIsMutable()V
    .locals 2

    .line 13597
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->graphOptions_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 13598
    invoke-interface {v0}, Lcom/google/protobuf/Internal$ProtobufList;->isModifiable()Z

    move-result v1

    if-nez v1, :cond_0

    .line 13600
    invoke-static {v0}, Lcom/google/protobuf/GeneratedMessageLite;->mutableCopy(Lcom/google/protobuf/Internal$ProtobufList;)Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->graphOptions_:Lcom/google/protobuf/Internal$ProtobufList;

    :cond_0
    return-void
.end method

.method private ensureInputSidePacketIsMutable()V
    .locals 2

    .line 12479
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 12480
    invoke-interface {v0}, Lcom/google/protobuf/Internal$ProtobufList;->isModifiable()Z

    move-result v1

    if-nez v1, :cond_0

    .line 12482
    invoke-static {v0}, Lcom/google/protobuf/GeneratedMessageLite;->mutableCopy(Lcom/google/protobuf/Internal$ProtobufList;)Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    :cond_0
    return-void
.end method

.method private ensureInputStreamIsMutable()V
    .locals 2

    .line 12206
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->inputStream_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 12207
    invoke-interface {v0}, Lcom/google/protobuf/Internal$ProtobufList;->isModifiable()Z

    move-result v1

    if-nez v1, :cond_0

    .line 12209
    invoke-static {v0}, Lcom/google/protobuf/GeneratedMessageLite;->mutableCopy(Lcom/google/protobuf/Internal$ProtobufList;)Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->inputStream_:Lcom/google/protobuf/Internal$ProtobufList;

    :cond_0
    return-void
.end method

.method private ensureNodeIsMutable()V
    .locals 2

    .line 11375
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->node_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 11376
    invoke-interface {v0}, Lcom/google/protobuf/Internal$ProtobufList;->isModifiable()Z

    move-result v1

    if-nez v1, :cond_0

    .line 11378
    invoke-static {v0}, Lcom/google/protobuf/GeneratedMessageLite;->mutableCopy(Lcom/google/protobuf/Internal$ProtobufList;)Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->node_:Lcom/google/protobuf/Internal$ProtobufList;

    :cond_0
    return-void
.end method

.method private ensureOutputSidePacketIsMutable()V
    .locals 2

    .line 12608
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->outputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 12609
    invoke-interface {v0}, Lcom/google/protobuf/Internal$ProtobufList;->isModifiable()Z

    move-result v1

    if-nez v1, :cond_0

    .line 12611
    invoke-static {v0}, Lcom/google/protobuf/GeneratedMessageLite;->mutableCopy(Lcom/google/protobuf/Internal$ProtobufList;)Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->outputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    :cond_0
    return-void
.end method

.method private ensureOutputStreamIsMutable()V
    .locals 2

    .line 12350
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->outputStream_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 12351
    invoke-interface {v0}, Lcom/google/protobuf/Internal$ProtobufList;->isModifiable()Z

    move-result v1

    if-nez v1, :cond_0

    .line 12353
    invoke-static {v0}, Lcom/google/protobuf/GeneratedMessageLite;->mutableCopy(Lcom/google/protobuf/Internal$ProtobufList;)Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->outputStream_:Lcom/google/protobuf/Internal$ProtobufList;

    :cond_0
    return-void
.end method

.method private ensurePacketFactoryIsMutable()V
    .locals 2

    .line 11528
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->packetFactory_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 11529
    invoke-interface {v0}, Lcom/google/protobuf/Internal$ProtobufList;->isModifiable()Z

    move-result v1

    if-nez v1, :cond_0

    .line 11531
    invoke-static {v0}, Lcom/google/protobuf/GeneratedMessageLite;->mutableCopy(Lcom/google/protobuf/Internal$ProtobufList;)Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->packetFactory_:Lcom/google/protobuf/Internal$ProtobufList;

    :cond_0
    return-void
.end method

.method private ensurePacketGeneratorIsMutable()V
    .locals 2

    .line 11734
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->packetGenerator_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 11735
    invoke-interface {v0}, Lcom/google/protobuf/Internal$ProtobufList;->isModifiable()Z

    move-result v1

    if-nez v1, :cond_0

    .line 11737
    invoke-static {v0}, Lcom/google/protobuf/GeneratedMessageLite;->mutableCopy(Lcom/google/protobuf/Internal$ProtobufList;)Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->packetGenerator_:Lcom/google/protobuf/Internal$ProtobufList;

    :cond_0
    return-void
.end method

.method private ensureStatusHandlerIsMutable()V
    .locals 2

    .line 12017
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->statusHandler_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 12018
    invoke-interface {v0}, Lcom/google/protobuf/Internal$ProtobufList;->isModifiable()Z

    move-result v1

    if-nez v1, :cond_0

    .line 12020
    invoke-static {v0}, Lcom/google/protobuf/GeneratedMessageLite;->mutableCopy(Lcom/google/protobuf/Internal$ProtobufList;)Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->statusHandler_:Lcom/google/protobuf/Internal$ProtobufList;

    :cond_0
    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;
    .locals 1

    .line 16378
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    return-object v0
.end method

.method private mergeInputStreamHandler(Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;)V
    .locals 2

    .line 12945
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 12946
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->inputStreamHandler_:Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    if-eqz v0, :cond_0

    .line 12947
    invoke-static {}, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->getDefaultInstance()Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    move-result-object v1

    if-eq v0, v1, :cond_0

    .line 12948
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->inputStreamHandler_:Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    .line 12949
    invoke-static {v0}, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->newBuilder(Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;)Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig$Builder;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    iput-object p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->inputStreamHandler_:Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    goto :goto_0

    .line 12951
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->inputStreamHandler_:Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    .line 12953
    :goto_0
    iget p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->bitField0_:I

    or-int/lit8 p1, p1, 0x2

    iput p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->bitField0_:I

    return-void
.end method

.method private mergeOptions(Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)V
    .locals 2

    .line 13518
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 13519
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->options_:Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    if-eqz v0, :cond_0

    .line 13520
    invoke-static {}, Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;->getDefaultInstance()Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    move-result-object v1

    if-eq v0, v1, :cond_0

    .line 13521
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->options_:Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    .line 13522
    invoke-static {v0}, Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;->newBuilder(Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions$Builder;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$ExtendableBuilder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite$ExtendableMessage;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    iput-object p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->options_:Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    goto :goto_0

    .line 13524
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->options_:Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    .line 13526
    :goto_0
    iget p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->bitField0_:I

    or-int/lit8 p1, p1, 0x10

    iput p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->bitField0_:I

    return-void
.end method

.method private mergeOutputStreamHandler(Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;)V
    .locals 2

    .line 13027
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 13028
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->outputStreamHandler_:Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    if-eqz v0, :cond_0

    .line 13029
    invoke-static {}, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->getDefaultInstance()Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    move-result-object v1

    if-eq v0, v1, :cond_0

    .line 13030
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->outputStreamHandler_:Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    .line 13031
    invoke-static {v0}, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->newBuilder(Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;)Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig$Builder;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    iput-object p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->outputStreamHandler_:Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    goto :goto_0

    .line 13033
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->outputStreamHandler_:Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    .line 13035
    :goto_0
    iget p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->bitField0_:I

    or-int/lit8 p1, p1, 0x4

    iput p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->bitField0_:I

    return-void
.end method

.method private mergeProfilerConfig(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V
    .locals 2

    .line 13300
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 13301
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->profilerConfig_:Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    if-eqz v0, :cond_0

    .line 13302
    invoke-static {}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->getDefaultInstance()Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    move-result-object v1

    if-eq v0, v1, :cond_0

    .line 13303
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->profilerConfig_:Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    .line 13304
    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->newBuilder(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    iput-object p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->profilerConfig_:Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    goto :goto_0

    .line 13306
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->profilerConfig_:Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    .line 13308
    :goto_0
    iget p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->bitField0_:I

    or-int/lit8 p1, p1, 0x8

    iput p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->bitField0_:I

    return-void
.end method

.method private mergeRuntimeInfo(Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;)V
    .locals 2

    .line 12846
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 12847
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->runtimeInfo_:Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    if-eqz v0, :cond_0

    .line 12848
    invoke-static {}, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;->getDefaultInstance()Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    move-result-object v1

    if-eq v0, v1, :cond_0

    .line 12849
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->runtimeInfo_:Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    .line 12850
    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;->newBuilder(Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;)Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig$Builder;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    iput-object p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->runtimeInfo_:Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    goto :goto_0

    .line 12852
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->runtimeInfo_:Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    .line 12854
    :goto_0
    iget p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->bitField0_:I

    or-int/lit8 p1, p1, 0x1

    iput p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->bitField0_:I

    return-void
.end method

.method public static newBuilder()Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 13754
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;
    .locals 1

    .line 13757
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;
    .locals 1

    .line 13730
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;
    .locals 1

    .line 13737
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;
    .locals 1

    .line 13693
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;
    .locals 1

    .line 13700
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;
    .locals 1

    .line 13742
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;
    .locals 1

    .line 13749
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;
    .locals 1

    .line 13717
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;
    .locals 1

    .line 13724
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;
    .locals 1

    .line 13680
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;
    .locals 1

    .line 13687
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;
    .locals 1

    .line 13705
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;
    .locals 1

    .line 13712
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;",
            ">;"
        }
    .end annotation

    .line 16384
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private removeExecutor(I)V
    .locals 1

    .line 13239
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensureExecutorIsMutable()V

    .line 13240
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->executor_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->remove(I)Ljava/lang/Object;

    return-void
.end method

.method private removeGraphOptions(I)V
    .locals 1

    .line 13673
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensureGraphOptionsIsMutable()V

    .line 13674
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->graphOptions_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->remove(I)Ljava/lang/Object;

    return-void
.end method

.method private removeNode(I)V
    .locals 1

    .line 11451
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensureNodeIsMutable()V

    .line 11452
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->node_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->remove(I)Ljava/lang/Object;

    return-void
.end method

.method private removePacketFactory(I)V
    .locals 1

    .line 11622
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensurePacketFactoryIsMutable()V

    .line 11623
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->packetFactory_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->remove(I)Ljava/lang/Object;

    return-void
.end method

.method private removePacketGenerator(I)V
    .locals 1

    .line 11870
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensurePacketGeneratorIsMutable()V

    .line 11871
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->packetGenerator_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->remove(I)Ljava/lang/Object;

    return-void
.end method

.method private removeStatusHandler(I)V
    .locals 1

    .line 12135
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensureStatusHandlerIsMutable()V

    .line 12136
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->statusHandler_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->remove(I)Ljava/lang/Object;

    return-void
.end method

.method private setExecutor(ILcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;)V
    .locals 1

    .line 13154
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 13155
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensureExecutorIsMutable()V

    .line 13156
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->executor_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->set(ILjava/lang/Object;)Ljava/lang/Object;

    return-void
.end method

.method private setGraphOptions(ILcom/google/protobuf/Any;)V
    .locals 1

    .line 13613
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 13614
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensureGraphOptionsIsMutable()V

    .line 13615
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->graphOptions_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->set(ILjava/lang/Object;)Ljava/lang/Object;

    return-void
.end method

.method private setInputSidePacket(ILjava/lang/String;)V
    .locals 1

    .line 12496
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 12497
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensureInputSidePacketIsMutable()V

    .line 12498
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->set(ILjava/lang/Object;)Ljava/lang/Object;

    return-void
.end method

.method private setInputStream(ILjava/lang/String;)V
    .locals 1

    .line 12226
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 12227
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensureInputStreamIsMutable()V

    .line 12228
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->inputStream_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->set(ILjava/lang/Object;)Ljava/lang/Object;

    return-void
.end method

.method private setInputStreamHandler(Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;)V
    .locals 0

    .line 12924
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 12925
    iput-object p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->inputStreamHandler_:Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    .line 12926
    iget p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->bitField0_:I

    or-int/lit8 p1, p1, 0x2

    iput p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->bitField0_:I

    return-void
.end method

.method private setMaxQueueSize(I)V
    .locals 0

    .line 12728
    iput p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->maxQueueSize_:I

    return-void
.end method

.method private setNode(ILcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Node;)V
    .locals 1

    .line 11391
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 11392
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensureNodeIsMutable()V

    .line 11393
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->node_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->set(ILjava/lang/Object;)Ljava/lang/Object;

    return-void
.end method

.method private setNumThreads(I)V
    .locals 0

    .line 11906
    iput p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->numThreads_:I

    return-void
.end method

.method private setOptions(Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)V
    .locals 0

    .line 13505
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 13506
    iput-object p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->options_:Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    .line 13507
    iget p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->bitField0_:I

    or-int/lit8 p1, p1, 0x10

    iput p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->bitField0_:I

    return-void
.end method

.method private setOutputSidePacket(ILjava/lang/String;)V
    .locals 1

    .line 12625
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 12626
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensureOutputSidePacketIsMutable()V

    .line 12627
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->outputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->set(ILjava/lang/Object;)Ljava/lang/Object;

    return-void
.end method

.method private setOutputStream(ILjava/lang/String;)V
    .locals 1

    .line 12367
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 12368
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensureOutputStreamIsMutable()V

    .line 12369
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->outputStream_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->set(ILjava/lang/Object;)Ljava/lang/Object;

    return-void
.end method

.method private setOutputStreamHandler(Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;)V
    .locals 0

    .line 13012
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 13013
    iput-object p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->outputStreamHandler_:Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    .line 13014
    iget p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->bitField0_:I

    or-int/lit8 p1, p1, 0x4

    iput p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->bitField0_:I

    return-void
.end method

.method private setPackage(Ljava/lang/String;)V
    .locals 0

    .line 13367
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 13369
    iput-object p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->package_:Ljava/lang/String;

    return-void
.end method

.method private setPackageBytes(Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 13396
    invoke-static {p1}, Lcom/google/protobuf/AbstractMessageLite;->checkByteStringIsUtf8(Lcom/google/protobuf/ByteString;)V

    .line 13397
    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->package_:Ljava/lang/String;

    return-void
.end method

.method private setPacketFactory(ILcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;)V
    .locals 1

    .line 11547
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 11548
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensurePacketFactoryIsMutable()V

    .line 11549
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->packetFactory_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->set(ILjava/lang/Object;)Ljava/lang/Object;

    return-void
.end method

.method private setPacketGenerator(ILcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;)V
    .locals 1

    .line 11760
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 11761
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensurePacketGeneratorIsMutable()V

    .line 11762
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->packetGenerator_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->set(ILjava/lang/Object;)Ljava/lang/Object;

    return-void
.end method

.method private setProfilerConfig(Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;)V
    .locals 0

    .line 13284
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 13285
    iput-object p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->profilerConfig_:Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    .line 13286
    iget p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->bitField0_:I

    or-int/lit8 p1, p1, 0x8

    iput p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->bitField0_:I

    return-void
.end method

.method private setReportDeadlock(Z)V
    .locals 0

    .line 12781
    iput-boolean p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->reportDeadlock_:Z

    return-void
.end method

.method private setRuntimeInfo(Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;)V
    .locals 0

    .line 12832
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 12833
    iput-object p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->runtimeInfo_:Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    .line 12834
    iget p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->bitField0_:I

    or-int/lit8 p1, p1, 0x1

    iput p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->bitField0_:I

    return-void
.end method

.method private setStatusHandler(ILcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;)V
    .locals 1

    .line 12040
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 12041
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->ensureStatusHandlerIsMutable()V

    .line 12042
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->statusHandler_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->set(ILjava/lang/Object;)Ljava/lang/Object;

    return-void
.end method

.method private setType(Ljava/lang/String;)V
    .locals 0

    .line 13441
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 13443
    iput-object p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->type_:Ljava/lang/String;

    return-void
.end method

.method private setTypeBytes(Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 13468
    invoke-static {p1}, Lcom/google/protobuf/AbstractMessageLite;->checkByteStringIsUtf8(Lcom/google/protobuf/ByteString;)V

    .line 13469
    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->type_:Ljava/lang/String;

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 29

    move-object/from16 v1, p0

    .line 16291
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual/range {p1 .. p1}, Ljava/lang/Enum;->ordinal()I

    move-result v2

    aget v0, v0, v2

    const/4 v2, 0x0

    packed-switch v0, :pswitch_data_0

    .line 16362
    new-instance v0, Ljava/lang/UnsupportedOperationException;

    invoke-direct {v0}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw v0

    :pswitch_0
    if-nez p2, :cond_0

    const/4 v0, 0x0

    goto :goto_0

    :cond_0
    const/4 v0, 0x1

    :goto_0
    int-to-byte v0, v0

    .line 16358
    iput-byte v0, v1, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->memoizedIsInitialized:B

    return-object v2

    .line 16355
    :pswitch_1
    iget-byte v0, v1, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->memoizedIsInitialized:B

    invoke-static {v0}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object v0

    return-object v0

    .line 16340
    :pswitch_2
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->PARSER:Lcom/google/protobuf/Parser;

    if-nez v0, :cond_2

    .line 16342
    const-class v2, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    monitor-enter v2

    .line 16343
    :try_start_0
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->PARSER:Lcom/google/protobuf/Parser;

    if-nez v0, :cond_1

    .line 16345
    new-instance v0, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object v3, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-direct {v0, v3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 16348
    sput-object v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_1

    :catchall_0
    move-exception v0

    goto :goto_2

    .line 16350
    :cond_1
    :goto_1
    monitor-exit v2

    return-object v0

    :goto_2
    monitor-exit v2
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0

    :cond_2
    return-object v0

    .line 16337
    :pswitch_3
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    return-object v0

    .line 16299
    :pswitch_4
    const-string v2, "bitField0_"

    const-string v3, "node_"

    const-class v4, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Node;

    const-string v5, "packetFactory_"

    const-class v6, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    const-string v7, "packetGenerator_"

    const-class v8, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    const-string v9, "numThreads_"

    const-string v10, "statusHandler_"

    const-class v11, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    const-string v12, "inputStream_"

    const-string v13, "maxQueueSize_"

    const-string v14, "inputStreamHandler_"

    const-string v15, "outputStreamHandler_"

    const-string v16, "executor_"

    const-class v17, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    const-string v18, "outputStream_"

    const-string v19, "inputSidePacket_"

    const-string v20, "outputSidePacket_"

    const-string v21, "profilerConfig_"

    const-string v22, "package_"

    const-string v23, "type_"

    const-string v24, "reportDeadlock_"

    const-string v25, "runtimeInfo_"

    const-string v26, "options_"

    const-string v27, "graphOptions_"

    const-class v28, Lcom/google/protobuf/Any;

    filled-new-array/range {v2 .. v28}, [Ljava/lang/Object;

    move-result-object v0

    .line 16328
    const-string v2, "\u0000\u0014\u0000\u0001\u0001\u03ea\u0014\u0000\n\u0008\u0001\u041b\u0006\u041b\u0007\u041b\u0008\u0004\t\u041b\n\u021a\u000b\u0004\u000c\u1409\u0001\r\u1409\u0002\u000e\u041b\u000f\u021a\u0010\u021a\u0011\u021a\u0012\u1009\u0003\u0013\u0208\u0014\u0208\u0015\u0007\u0016\u1009\u0000\u03e9\u1409\u0004\u03ea\u001b"

    .line 16333
    sget-object v3, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-static {v3, v2, v0}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    return-object v0

    .line 16296
    :pswitch_5
    new-instance v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;

    invoke-direct {v0, v2}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Builder;-><init>(Lcom/google/mediapipe/proto/CalculatorProto$1;)V

    return-object v0

    .line 16293
    :pswitch_6
    new-instance v0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;

    invoke-direct {v0}, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;-><init>()V

    return-object v0

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

.method public bridge synthetic getDefaultInstanceForType()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 6743
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getExecutor(I)Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;
    .locals 1

    .line 13114
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->executor_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    return-object p1
.end method

.method public getExecutorCount()I
    .locals 1

    .line 13098
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->executor_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    return v0
.end method

.method public getExecutorList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;",
            ">;"
        }
    .end annotation

    .line 13066
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->executor_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public getExecutorOrBuilder(I)Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfigOrBuilder;
    .locals 1

    .line 13130
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->executor_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfigOrBuilder;

    return-object p1
.end method

.method public getExecutorOrBuilderList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "+",
            "Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfigOrBuilder;",
            ">;"
        }
    .end annotation

    .line 13082
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->executor_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public getGraphOptions(I)Lcom/google/protobuf/Any;
    .locals 1

    .line 13583
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->graphOptions_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/protobuf/Any;

    return-object p1
.end method

.method public getGraphOptionsCount()I
    .locals 1

    .line 13572
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->graphOptions_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    return v0
.end method

.method public getGraphOptionsList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Lcom/google/protobuf/Any;",
            ">;"
        }
    .end annotation

    .line 13550
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->graphOptions_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public getGraphOptionsOrBuilder(I)Lcom/google/protobuf/AnyOrBuilder;
    .locals 1

    .line 13594
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->graphOptions_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/protobuf/AnyOrBuilder;

    return-object p1
.end method

.method public getGraphOptionsOrBuilderList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "+",
            "Lcom/google/protobuf/AnyOrBuilder;",
            ">;"
        }
    .end annotation

    .line 13561
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->graphOptions_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public getInputSidePacket(I)Ljava/lang/String;
    .locals 1

    .line 12461
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/lang/String;

    return-object p1
.end method

.method public getInputSidePacketBytes(I)Lcom/google/protobuf/ByteString;
    .locals 1

    .line 12475
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 12476
    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/lang/String;

    .line 12475
    invoke-static {p1}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object p1

    return-object p1
.end method

.method public getInputSidePacketCount()I
    .locals 1

    .line 12448
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    return v0
.end method

.method public getInputSidePacketList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .line 12436
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public getInputStream(I)Ljava/lang/String;
    .locals 1

    .line 12185
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->inputStream_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/lang/String;

    return-object p1
.end method

.method public getInputStreamBytes(I)Lcom/google/protobuf/ByteString;
    .locals 1

    .line 12202
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->inputStream_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 12203
    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/lang/String;

    .line 12202
    invoke-static {p1}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object p1

    return-object p1
.end method

.method public getInputStreamCount()I
    .locals 1

    .line 12169
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->inputStream_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    return v0
.end method

.method public getInputStreamHandler()Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;
    .locals 1

    .line 12906
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->inputStreamHandler_:Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    if-nez v0, :cond_0

    invoke-static {}, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->getDefaultInstance()Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    move-result-object v0

    :cond_0
    return-object v0
.end method

.method public getInputStreamList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .line 12154
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->inputStream_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public getMaxQueueSize()I
    .locals 1

    .line 12705
    iget v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->maxQueueSize_:I

    return v0
.end method

.method public getNode(I)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Node;
    .locals 1

    .line 11361
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->node_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Node;

    return-object p1
.end method

.method public getNodeCount()I
    .locals 1

    .line 11350
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->node_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    return v0
.end method

.method public getNodeList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$Node;",
            ">;"
        }
    .end annotation

    .line 11328
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->node_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public getNodeOrBuilder(I)Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$NodeOrBuilder;
    .locals 1

    .line 11372
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->node_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$NodeOrBuilder;

    return-object p1
.end method

.method public getNodeOrBuilderList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "+",
            "Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig$NodeOrBuilder;",
            ">;"
        }
    .end annotation

    .line 11339
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->node_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public getNumThreads()I
    .locals 1

    .line 11890
    iget v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->numThreads_:I

    return v0
.end method

.method public getOptions()Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;
    .locals 1

    .line 13495
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->options_:Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    if-nez v0, :cond_0

    invoke-static {}, Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;->getDefaultInstance()Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    move-result-object v0

    :cond_0
    return-object v0
.end method

.method public getOutputSidePacket(I)Ljava/lang/String;
    .locals 1

    .line 12590
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->outputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/lang/String;

    return-object p1
.end method

.method public getOutputSidePacketBytes(I)Lcom/google/protobuf/ByteString;
    .locals 1

    .line 12604
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->outputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 12605
    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/lang/String;

    .line 12604
    invoke-static {p1}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object p1

    return-object p1
.end method

.method public getOutputSidePacketCount()I
    .locals 1

    .line 12577
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->outputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    return v0
.end method

.method public getOutputSidePacketList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .line 12565
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->outputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public getOutputStream(I)Ljava/lang/String;
    .locals 1

    .line 12332
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->outputStream_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/lang/String;

    return-object p1
.end method

.method public getOutputStreamBytes(I)Lcom/google/protobuf/ByteString;
    .locals 1

    .line 12346
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->outputStream_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 12347
    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/lang/String;

    .line 12346
    invoke-static {p1}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object p1

    return-object p1
.end method

.method public getOutputStreamCount()I
    .locals 1

    .line 12319
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->outputStream_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    return v0
.end method

.method public getOutputStreamHandler()Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;
    .locals 1

    .line 13000
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->outputStreamHandler_:Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    if-nez v0, :cond_0

    invoke-static {}, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->getDefaultInstance()Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    move-result-object v0

    :cond_0
    return-object v0
.end method

.method public getOutputStreamList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .line 12307
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->outputStream_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public getPackage()Ljava/lang/String;
    .locals 1

    .line 13338
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->package_:Ljava/lang/String;

    return-object v0
.end method

.method public getPackageBytes()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 13353
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->package_:Ljava/lang/String;

    invoke-static {v0}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object v0

    return-object v0
.end method

.method public getPacketFactory(I)Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;
    .locals 1

    .line 11511
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->packetFactory_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    return-object p1
.end method

.method public getPacketFactoryCount()I
    .locals 1

    .line 11497
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->packetFactory_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    return v0
.end method

.method public getPacketFactoryList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;",
            ">;"
        }
    .end annotation

    .line 11469
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->packetFactory_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public getPacketFactoryOrBuilder(I)Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfigOrBuilder;
    .locals 1

    .line 11525
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->packetFactory_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfigOrBuilder;

    return-object p1
.end method

.method public getPacketFactoryOrBuilderList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "+",
            "Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfigOrBuilder;",
            ">;"
        }
    .end annotation

    .line 11483
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->packetFactory_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public getPacketGenerator(I)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;
    .locals 1
    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .line 11710
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->packetGenerator_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    return-object p1
.end method

.method public getPacketGeneratorCount()I
    .locals 1
    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .line 11689
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->packetGenerator_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    return v0
.end method

.method public getPacketGeneratorList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;",
            ">;"
        }
    .end annotation

    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .line 11647
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->packetGenerator_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public getPacketGeneratorOrBuilder(I)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfigOrBuilder;
    .locals 1
    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .line 11731
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->packetGenerator_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfigOrBuilder;

    return-object p1
.end method

.method public getPacketGeneratorOrBuilderList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "+",
            "Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfigOrBuilder;",
            ">;"
        }
    .end annotation

    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .line 11668
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->packetGenerator_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public getProfilerConfig()Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;
    .locals 1

    .line 13271
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->profilerConfig_:Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    if-nez v0, :cond_0

    invoke-static {}, Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;->getDefaultInstance()Lcom/google/mediapipe/proto/CalculatorProto$ProfilerConfig;

    move-result-object v0

    :cond_0
    return-object v0
.end method

.method public getReportDeadlock()Z
    .locals 1

    .line 12767
    iget-boolean v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->reportDeadlock_:Z

    return v0
.end method

.method public getRuntimeInfo()Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;
    .locals 1

    .line 12821
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->runtimeInfo_:Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    if-nez v0, :cond_0

    invoke-static {}, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;->getDefaultInstance()Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    move-result-object v0

    :cond_0
    return-object v0
.end method

.method public getStatusHandler(I)Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;
    .locals 1

    .line 11996
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->statusHandler_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    return-object p1
.end method

.method public getStatusHandlerCount()I
    .locals 1

    .line 11978
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->statusHandler_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    return v0
.end method

.method public getStatusHandlerList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;",
            ">;"
        }
    .end annotation

    .line 11942
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->statusHandler_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public getStatusHandlerOrBuilder(I)Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfigOrBuilder;
    .locals 1

    .line 12014
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->statusHandler_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfigOrBuilder;

    return-object p1
.end method

.method public getStatusHandlerOrBuilderList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "+",
            "Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfigOrBuilder;",
            ">;"
        }
    .end annotation

    .line 11960
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->statusHandler_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public getType()Ljava/lang/String;
    .locals 1

    .line 13414
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->type_:Ljava/lang/String;

    return-object v0
.end method

.method public getTypeBytes()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 13428
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->type_:Ljava/lang/String;

    invoke-static {v0}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object v0

    return-object v0
.end method

.method public hasInputStreamHandler()Z
    .locals 1

    .line 12887
    iget v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->bitField0_:I

    and-int/lit8 v0, v0, 0x2

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasOptions()Z
    .locals 1

    .line 13484
    iget v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->bitField0_:I

    and-int/lit8 v0, v0, 0x10

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasOutputStreamHandler()Z
    .locals 1

    .line 12987
    iget v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->bitField0_:I

    and-int/lit8 v0, v0, 0x4

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasProfilerConfig()Z
    .locals 1

    .line 13257
    iget v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->bitField0_:I

    and-int/lit8 v0, v0, 0x8

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasRuntimeInfo()Z
    .locals 2

    .line 12809
    iget v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$CalculatorGraphConfig;->bitField0_:I

    const/4 v1, 0x1

    and-int/2addr v0, v1

    if-eqz v0, :cond_0

    return v1

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public bridge synthetic newBuilderForType()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 6743
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 6743
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
