.class public final Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "PacketGeneratorProto.java"

# interfaces
.implements Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfigOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/proto/PacketGeneratorProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "PacketGeneratorConfig"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;",
        "Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;",
        ">;",
        "Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfigOrBuilder;"
    }
.end annotation

.annotation runtime Ljava/lang/Deprecated;
.end annotation


# static fields
.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

.field public static final EXTERNAL_INPUT_FIELD_NUMBER:I = 0x3ea

.field public static final EXTERNAL_OUTPUT_FIELD_NUMBER:I = 0x3eb

.field public static final INPUT_SIDE_PACKET_FIELD_NUMBER:I = 0x2

.field public static final OPTIONS_FIELD_NUMBER:I = 0x4

.field public static final OUTPUT_SIDE_PACKET_FIELD_NUMBER:I = 0x3

.field public static final PACKET_GENERATOR_FIELD_NUMBER:I = 0x1

.field private static volatile PARSER:Lcom/google/protobuf/Parser;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;",
            ">;"
        }
    .end annotation
.end field


# instance fields
.field private bitField0_:I

.field private externalInput_:Lcom/google/protobuf/Internal$ProtobufList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Internal$ProtobufList<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field private externalOutput_:Lcom/google/protobuf/Internal$ProtobufList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Internal$ProtobufList<",
            "Ljava/lang/String;",
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

.field private memoizedIsInitialized:B

.field private options_:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

.field private outputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Internal$ProtobufList<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field private packetGenerator_:Ljava/lang/String;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 2131
    new-instance v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-direct {v0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;-><init>()V

    .line 2134
    sput-object v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    .line 2135
    const-class v1, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    .line 584
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    const/4 v0, 0x2

    .line 2069
    iput-byte v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->memoizedIsInitialized:B

    .line 585
    const-string v0, ""

    iput-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->packetGenerator_:Ljava/lang/String;

    .line 586
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 587
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->externalInput_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 588
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->outputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 589
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->externalOutput_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method static synthetic access$1000(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;Ljava/lang/Iterable;)V
    .locals 0

    .line 579
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->addAllInputSidePacket(Ljava/lang/Iterable;)V

    return-void
.end method

.method static synthetic access$1100(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;)V
    .locals 0

    .line 579
    invoke-direct {p0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->clearInputSidePacket()V

    return-void
.end method

.method static synthetic access$1200(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 579
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->addInputSidePacketBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method static synthetic access$1300(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;ILjava/lang/String;)V
    .locals 0

    .line 579
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->setExternalInput(ILjava/lang/String;)V

    return-void
.end method

.method static synthetic access$1400(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;Ljava/lang/String;)V
    .locals 0

    .line 579
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->addExternalInput(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$1500(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;Ljava/lang/Iterable;)V
    .locals 0

    .line 579
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->addAllExternalInput(Ljava/lang/Iterable;)V

    return-void
.end method

.method static synthetic access$1600(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;)V
    .locals 0

    .line 579
    invoke-direct {p0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->clearExternalInput()V

    return-void
.end method

.method static synthetic access$1700(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 579
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->addExternalInputBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method static synthetic access$1800(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;ILjava/lang/String;)V
    .locals 0

    .line 579
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->setOutputSidePacket(ILjava/lang/String;)V

    return-void
.end method

.method static synthetic access$1900(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;Ljava/lang/String;)V
    .locals 0

    .line 579
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->addOutputSidePacket(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$2000(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;Ljava/lang/Iterable;)V
    .locals 0

    .line 579
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->addAllOutputSidePacket(Ljava/lang/Iterable;)V

    return-void
.end method

.method static synthetic access$2100(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;)V
    .locals 0

    .line 579
    invoke-direct {p0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->clearOutputSidePacket()V

    return-void
.end method

.method static synthetic access$2200(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 579
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->addOutputSidePacketBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method static synthetic access$2300(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;ILjava/lang/String;)V
    .locals 0

    .line 579
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->setExternalOutput(ILjava/lang/String;)V

    return-void
.end method

.method static synthetic access$2400(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;Ljava/lang/String;)V
    .locals 0

    .line 579
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->addExternalOutput(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$2500(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;Ljava/lang/Iterable;)V
    .locals 0

    .line 579
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->addAllExternalOutput(Ljava/lang/Iterable;)V

    return-void
.end method

.method static synthetic access$2600(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;)V
    .locals 0

    .line 579
    invoke-direct {p0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->clearExternalOutput()V

    return-void
.end method

.method static synthetic access$2700(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 579
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->addExternalOutputBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method static synthetic access$2800(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;)V
    .locals 0

    .line 579
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->setOptions(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;)V

    return-void
.end method

.method static synthetic access$2900(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;)V
    .locals 0

    .line 579
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->mergeOptions(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;)V

    return-void
.end method

.method static synthetic access$3000(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;)V
    .locals 0

    .line 579
    invoke-direct {p0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->clearOptions()V

    return-void
.end method

.method static synthetic access$400()Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;
    .locals 1

    .line 579
    sget-object v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    return-object v0
.end method

.method static synthetic access$500(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;Ljava/lang/String;)V
    .locals 0

    .line 579
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->setPacketGenerator(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$600(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;)V
    .locals 0

    .line 579
    invoke-direct {p0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->clearPacketGenerator()V

    return-void
.end method

.method static synthetic access$700(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 579
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->setPacketGeneratorBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method static synthetic access$800(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;ILjava/lang/String;)V
    .locals 0

    .line 579
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->setInputSidePacket(ILjava/lang/String;)V

    return-void
.end method

.method static synthetic access$900(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;Ljava/lang/String;)V
    .locals 0

    .line 579
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->addInputSidePacket(Ljava/lang/String;)V

    return-void
.end method

.method private addAllExternalInput(Ljava/lang/Iterable;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "Ljava/lang/String;",
            ">;)V"
        }
    .end annotation

    .line 907
    invoke-direct {p0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->ensureExternalInputIsMutable()V

    .line 908
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->externalInput_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-static {p1, v0}, Lcom/google/protobuf/AbstractMessageLite;->addAll(Ljava/lang/Iterable;Ljava/util/List;)V

    return-void
.end method

.method private addAllExternalOutput(Ljava/lang/Iterable;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "Ljava/lang/String;",
            ">;)V"
        }
    .end annotation

    .line 1181
    invoke-direct {p0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->ensureExternalOutputIsMutable()V

    .line 1182
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->externalOutput_:Lcom/google/protobuf/Internal$ProtobufList;

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

    .line 777
    invoke-direct {p0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->ensureInputSidePacketIsMutable()V

    .line 778
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

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

    .line 1049
    invoke-direct {p0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->ensureOutputSidePacketIsMutable()V

    .line 1050
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->outputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-static {p1, v0}, Lcom/google/protobuf/AbstractMessageLite;->addAll(Ljava/lang/Iterable;Ljava/util/List;)V

    return-void
.end method

.method private addExternalInput(Ljava/lang/String;)V
    .locals 1

    .line 893
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 894
    invoke-direct {p0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->ensureExternalInputIsMutable()V

    .line 895
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->externalInput_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private addExternalInputBytes(Lcom/google/protobuf/ByteString;)V
    .locals 1

    .line 931
    invoke-direct {p0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->ensureExternalInputIsMutable()V

    .line 932
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->externalInput_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private addExternalOutput(Ljava/lang/String;)V
    .locals 1

    .line 1167
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 1168
    invoke-direct {p0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->ensureExternalOutputIsMutable()V

    .line 1169
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->externalOutput_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private addExternalOutputBytes(Lcom/google/protobuf/ByteString;)V
    .locals 1

    .line 1205
    invoke-direct {p0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->ensureExternalOutputIsMutable()V

    .line 1206
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->externalOutput_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private addInputSidePacket(Ljava/lang/String;)V
    .locals 1

    .line 762
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 763
    invoke-direct {p0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->ensureInputSidePacketIsMutable()V

    .line 764
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private addInputSidePacketBytes(Lcom/google/protobuf/ByteString;)V
    .locals 1

    .line 803
    invoke-direct {p0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->ensureInputSidePacketIsMutable()V

    .line 804
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private addOutputSidePacket(Ljava/lang/String;)V
    .locals 1

    .line 1033
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 1034
    invoke-direct {p0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->ensureOutputSidePacketIsMutable()V

    .line 1035
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->outputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private addOutputSidePacketBytes(Lcom/google/protobuf/ByteString;)V
    .locals 1

    .line 1077
    invoke-direct {p0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->ensureOutputSidePacketIsMutable()V

    .line 1078
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->outputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private clearExternalInput()V
    .locals 1

    .line 919
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->externalInput_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method private clearExternalOutput()V
    .locals 1

    .line 1193
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->externalOutput_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method private clearInputSidePacket()V
    .locals 1

    .line 790
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method private clearOptions()V
    .locals 1

    const/4 v0, 0x0

    .line 1271
    iput-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->options_:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    .line 1272
    iget v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->bitField0_:I

    and-int/lit8 v0, v0, -0x3

    iput v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->bitField0_:I

    return-void
.end method

.method private clearOutputSidePacket()V
    .locals 1

    .line 1063
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->outputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method private clearPacketGenerator()V
    .locals 1

    .line 653
    iget v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->bitField0_:I

    and-int/lit8 v0, v0, -0x2

    iput v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->bitField0_:I

    .line 654
    invoke-static {}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->getDefaultInstance()Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    move-result-object v0

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->getPacketGenerator()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->packetGenerator_:Ljava/lang/String;

    return-void
.end method

.method private ensureExternalInputIsMutable()V
    .locals 2

    .line 862
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->externalInput_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 863
    invoke-interface {v0}, Lcom/google/protobuf/Internal$ProtobufList;->isModifiable()Z

    move-result v1

    if-nez v1, :cond_0

    .line 865
    invoke-static {v0}, Lcom/google/protobuf/GeneratedMessageLite;->mutableCopy(Lcom/google/protobuf/Internal$ProtobufList;)Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->externalInput_:Lcom/google/protobuf/Internal$ProtobufList;

    :cond_0
    return-void
.end method

.method private ensureExternalOutputIsMutable()V
    .locals 2

    .line 1136
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->externalOutput_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 1137
    invoke-interface {v0}, Lcom/google/protobuf/Internal$ProtobufList;->isModifiable()Z

    move-result v1

    if-nez v1, :cond_0

    .line 1139
    invoke-static {v0}, Lcom/google/protobuf/GeneratedMessageLite;->mutableCopy(Lcom/google/protobuf/Internal$ProtobufList;)Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->externalOutput_:Lcom/google/protobuf/Internal$ProtobufList;

    :cond_0
    return-void
.end method

.method private ensureInputSidePacketIsMutable()V
    .locals 2

    .line 729
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 730
    invoke-interface {v0}, Lcom/google/protobuf/Internal$ProtobufList;->isModifiable()Z

    move-result v1

    if-nez v1, :cond_0

    .line 732
    invoke-static {v0}, Lcom/google/protobuf/GeneratedMessageLite;->mutableCopy(Lcom/google/protobuf/Internal$ProtobufList;)Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    :cond_0
    return-void
.end method

.method private ensureOutputSidePacketIsMutable()V
    .locals 2

    .line 998
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->outputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 999
    invoke-interface {v0}, Lcom/google/protobuf/Internal$ProtobufList;->isModifiable()Z

    move-result v1

    if-nez v1, :cond_0

    .line 1001
    invoke-static {v0}, Lcom/google/protobuf/GeneratedMessageLite;->mutableCopy(Lcom/google/protobuf/Internal$ProtobufList;)Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->outputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    :cond_0
    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;
    .locals 1

    .line 2140
    sget-object v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    return-object v0
.end method

.method private mergeOptions(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;)V
    .locals 2

    .line 1254
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 1255
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->options_:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    if-eqz v0, :cond_0

    .line 1256
    invoke-static {}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->getDefaultInstance()Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    move-result-object v1

    if-eq v0, v1, :cond_0

    .line 1257
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->options_:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    .line 1258
    invoke-static {v0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->newBuilder(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions$Builder;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$ExtendableBuilder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite$ExtendableMessage;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    iput-object p1, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->options_:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    goto :goto_0

    .line 1260
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->options_:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    .line 1262
    :goto_0
    iget p1, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->bitField0_:I

    or-int/lit8 p1, p1, 0x2

    iput p1, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->bitField0_:I

    return-void
.end method

.method public static newBuilder()Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;
    .locals 1

    .line 1352
    sget-object v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;
    .locals 1

    .line 1355
    sget-object v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;
    .locals 1

    .line 1328
    sget-object v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;
    .locals 1

    .line 1335
    sget-object v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;
    .locals 1

    .line 1291
    sget-object v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;
    .locals 1

    .line 1298
    sget-object v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;
    .locals 1

    .line 1340
    sget-object v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;
    .locals 1

    .line 1347
    sget-object v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;
    .locals 1

    .line 1315
    sget-object v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;
    .locals 1

    .line 1322
    sget-object v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;
    .locals 1

    .line 1278
    sget-object v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;
    .locals 1

    .line 1285
    sget-object v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;
    .locals 1

    .line 1303
    sget-object v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;
    .locals 1

    .line 1310
    sget-object v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;",
            ">;"
        }
    .end annotation

    .line 2146
    sget-object v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private setExternalInput(ILjava/lang/String;)V
    .locals 1

    .line 879
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 880
    invoke-direct {p0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->ensureExternalInputIsMutable()V

    .line 881
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->externalInput_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->set(ILjava/lang/Object;)Ljava/lang/Object;

    return-void
.end method

.method private setExternalOutput(ILjava/lang/String;)V
    .locals 1

    .line 1153
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 1154
    invoke-direct {p0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->ensureExternalOutputIsMutable()V

    .line 1155
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->externalOutput_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->set(ILjava/lang/Object;)Ljava/lang/Object;

    return-void
.end method

.method private setInputSidePacket(ILjava/lang/String;)V
    .locals 1

    .line 747
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 748
    invoke-direct {p0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->ensureInputSidePacketIsMutable()V

    .line 749
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->set(ILjava/lang/Object;)Ljava/lang/Object;

    return-void
.end method

.method private setOptions(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;)V
    .locals 0

    .line 1241
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 1242
    iput-object p1, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->options_:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    .line 1243
    iget p1, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->bitField0_:I

    or-int/lit8 p1, p1, 0x2

    iput p1, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->bitField0_:I

    return-void
.end method

.method private setOutputSidePacket(ILjava/lang/String;)V
    .locals 1

    .line 1017
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 1018
    invoke-direct {p0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->ensureOutputSidePacketIsMutable()V

    .line 1019
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->outputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->set(ILjava/lang/Object;)Ljava/lang/Object;

    return-void
.end method

.method private setPacketGenerator(Ljava/lang/String;)V
    .locals 1

    .line 641
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 642
    iget v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->bitField0_:I

    or-int/lit8 v0, v0, 0x1

    iput v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->bitField0_:I

    .line 643
    iput-object p1, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->packetGenerator_:Ljava/lang/String;

    return-void
.end method

.method private setPacketGeneratorBytes(Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 666
    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->packetGenerator_:Ljava/lang/String;

    .line 667
    iget p1, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->bitField0_:I

    or-int/lit8 p1, p1, 0x1

    iput p1, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->bitField0_:I

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 7

    .line 2075
    sget-object p3, Lcom/google/mediapipe/proto/PacketGeneratorProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p3, p1

    const/4 p3, 0x0

    packed-switch p1, :pswitch_data_0

    .line 2124
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    invoke-direct {p1}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw p1

    :pswitch_0
    if-nez p2, :cond_0

    const/4 p1, 0x0

    goto :goto_0

    :cond_0
    const/4 p1, 0x1

    :goto_0
    int-to-byte p1, p1

    .line 2120
    iput-byte p1, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->memoizedIsInitialized:B

    return-object p3

    .line 2117
    :pswitch_1
    iget-byte p1, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->memoizedIsInitialized:B

    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 2102
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_2

    .line 2104
    const-class p2, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    monitor-enter p2

    .line 2105
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 2107
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 2110
    sput-object p1, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_1

    :catchall_0
    move-exception v0

    move-object p1, v0

    goto :goto_2

    .line 2112
    :cond_1
    :goto_1
    monitor-exit p2

    return-object p1

    :goto_2
    monitor-exit p2
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw p1

    :cond_2
    return-object p1

    .line 2099
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    return-object p1

    .line 2083
    :pswitch_4
    const-string v0, "bitField0_"

    const-string v1, "packetGenerator_"

    const-string v2, "inputSidePacket_"

    const-string v3, "outputSidePacket_"

    const-string v4, "options_"

    const-string v5, "externalInput_"

    const-string v6, "externalOutput_"

    filled-new-array/range {v0 .. v6}, [Ljava/lang/Object;

    move-result-object p1

    .line 2092
    const-string p2, "\u0001\u0006\u0000\u0001\u0001\u03eb\u0006\u0000\u0004\u0001\u0001\u1008\u0000\u0002\u001a\u0003\u001a\u0004\u1409\u0001\u03ea\u001a\u03eb\u001a"

    .line 2095
    sget-object p3, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-static {p3, p2, p1}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 2080
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;

    invoke-direct {p1, p3}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig$Builder;-><init>(Lcom/google/mediapipe/proto/PacketGeneratorProto$1;)V

    return-object p1

    .line 2077
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;

    invoke-direct {p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;-><init>()V

    return-object p1

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

.method public bridge synthetic getDefaultInstanceForType()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 579
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getExternalInput(I)Ljava/lang/String;
    .locals 1

    .line 844
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->externalInput_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/lang/String;

    return-object p1
.end method

.method public getExternalInputBytes(I)Lcom/google/protobuf/ByteString;
    .locals 1

    .line 858
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->externalInput_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 859
    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/lang/String;

    .line 858
    invoke-static {p1}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object p1

    return-object p1
.end method

.method public getExternalInputCount()I
    .locals 1

    .line 831
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->externalInput_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    return v0
.end method

.method public getExternalInputList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .line 819
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->externalInput_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public getExternalOutput(I)Ljava/lang/String;
    .locals 1

    .line 1118
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->externalOutput_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/lang/String;

    return-object p1
.end method

.method public getExternalOutputBytes(I)Lcom/google/protobuf/ByteString;
    .locals 1

    .line 1132
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->externalOutput_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 1133
    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/lang/String;

    .line 1132
    invoke-static {p1}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object p1

    return-object p1
.end method

.method public getExternalOutputCount()I
    .locals 1

    .line 1105
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->externalOutput_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    return v0
.end method

.method public getExternalOutputList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .line 1093
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->externalOutput_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public getInputSidePacket(I)Ljava/lang/String;
    .locals 1

    .line 710
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/lang/String;

    return-object p1
.end method

.method public getInputSidePacketBytes(I)Lcom/google/protobuf/ByteString;
    .locals 1

    .line 725
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 726
    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/lang/String;

    .line 725
    invoke-static {p1}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object p1

    return-object p1
.end method

.method public getInputSidePacketCount()I
    .locals 1

    .line 696
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

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

    .line 683
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public getOptions()Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;
    .locals 1

    .line 1231
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->options_:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    if-nez v0, :cond_0

    invoke-static {}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->getDefaultInstance()Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    move-result-object v0

    :cond_0
    return-object v0
.end method

.method public getOutputSidePacket(I)Ljava/lang/String;
    .locals 1

    .line 978
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->outputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/lang/String;

    return-object p1
.end method

.method public getOutputSidePacketBytes(I)Lcom/google/protobuf/ByteString;
    .locals 1

    .line 994
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->outputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 995
    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/lang/String;

    .line 994
    invoke-static {p1}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object p1

    return-object p1
.end method

.method public getOutputSidePacketCount()I
    .locals 1

    .line 963
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->outputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

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

    .line 949
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->outputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public getPacketGenerator()Ljava/lang/String;
    .locals 1

    .line 616
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->packetGenerator_:Ljava/lang/String;

    return-object v0
.end method

.method public getPacketGeneratorBytes()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 629
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->packetGenerator_:Ljava/lang/String;

    invoke-static {v0}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object v0

    return-object v0
.end method

.method public hasOptions()Z
    .locals 1

    .line 1220
    iget v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->bitField0_:I

    and-int/lit8 v0, v0, 0x2

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasPacketGenerator()Z
    .locals 2

    .line 604
    iget v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorConfig;->bitField0_:I

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

    .line 579
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 579
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
