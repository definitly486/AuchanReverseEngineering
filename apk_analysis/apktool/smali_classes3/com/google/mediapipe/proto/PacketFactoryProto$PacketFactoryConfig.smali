.class public final Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "PacketFactoryProto.java"

# interfaces
.implements Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfigOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/proto/PacketFactoryProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "PacketFactoryConfig"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;",
        "Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig$Builder;",
        ">;",
        "Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfigOrBuilder;"
    }
.end annotation


# static fields
.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

.field public static final EXTERNAL_OUTPUT_FIELD_NUMBER:I = 0x3ea

.field public static final OPTIONS_FIELD_NUMBER:I = 0x3

.field public static final OUTPUT_SIDE_PACKET_FIELD_NUMBER:I = 0x2

.field public static final PACKET_FACTORY_FIELD_NUMBER:I = 0x1

.field private static volatile PARSER:Lcom/google/protobuf/Parser;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;",
            ">;"
        }
    .end annotation
.end field


# instance fields
.field private bitField0_:I

.field private externalOutput_:Ljava/lang/String;

.field private memoizedIsInitialized:B

.field private options_:Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryOptions;

.field private outputSidePacket_:Ljava/lang/String;

.field private packetFactory_:Ljava/lang/String;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 1112
    new-instance v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-direct {v0}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;-><init>()V

    .line 1115
    sput-object v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    .line 1116
    const-class v1, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    .line 329
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    const/4 v0, 0x2

    .line 1052
    iput-byte v0, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->memoizedIsInitialized:B

    .line 330
    const-string v0, ""

    iput-object v0, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->packetFactory_:Ljava/lang/String;

    .line 331
    iput-object v0, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->outputSidePacket_:Ljava/lang/String;

    .line 332
    iput-object v0, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->externalOutput_:Ljava/lang/String;

    return-void
.end method

.method static synthetic access$1000(Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;)V
    .locals 0

    .line 324
    invoke-direct {p0}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->clearExternalOutput()V

    return-void
.end method

.method static synthetic access$1100(Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 324
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->setExternalOutputBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method static synthetic access$1200(Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryOptions;)V
    .locals 0

    .line 324
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->setOptions(Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryOptions;)V

    return-void
.end method

.method static synthetic access$1300(Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryOptions;)V
    .locals 0

    .line 324
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->mergeOptions(Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryOptions;)V

    return-void
.end method

.method static synthetic access$1400(Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;)V
    .locals 0

    .line 324
    invoke-direct {p0}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->clearOptions()V

    return-void
.end method

.method static synthetic access$200()Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;
    .locals 1

    .line 324
    sget-object v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    return-object v0
.end method

.method static synthetic access$300(Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;Ljava/lang/String;)V
    .locals 0

    .line 324
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->setPacketFactory(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$400(Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;)V
    .locals 0

    .line 324
    invoke-direct {p0}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->clearPacketFactory()V

    return-void
.end method

.method static synthetic access$500(Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 324
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->setPacketFactoryBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method static synthetic access$600(Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;Ljava/lang/String;)V
    .locals 0

    .line 324
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->setOutputSidePacket(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$700(Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;)V
    .locals 0

    .line 324
    invoke-direct {p0}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->clearOutputSidePacket()V

    return-void
.end method

.method static synthetic access$800(Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 324
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->setOutputSidePacketBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method static synthetic access$900(Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;Ljava/lang/String;)V
    .locals 0

    .line 324
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->setExternalOutput(Ljava/lang/String;)V

    return-void
.end method

.method private clearExternalOutput()V
    .locals 1

    .line 552
    iget v0, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->bitField0_:I

    and-int/lit8 v0, v0, -0x5

    iput v0, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->bitField0_:I

    .line 553
    invoke-static {}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->getDefaultInstance()Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    move-result-object v0

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->getExternalOutput()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->externalOutput_:Ljava/lang/String;

    return-void
.end method

.method private clearOptions()V
    .locals 1

    const/4 v0, 0x0

    .line 631
    iput-object v0, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->options_:Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryOptions;

    .line 632
    iget v0, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->bitField0_:I

    and-int/lit8 v0, v0, -0x9

    iput v0, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->bitField0_:I

    return-void
.end method

.method private clearOutputSidePacket()V
    .locals 1

    .line 474
    iget v0, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->bitField0_:I

    and-int/lit8 v0, v0, -0x3

    iput v0, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->bitField0_:I

    .line 475
    invoke-static {}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->getDefaultInstance()Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    move-result-object v0

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->getOutputSidePacket()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->outputSidePacket_:Ljava/lang/String;

    return-void
.end method

.method private clearPacketFactory()V
    .locals 1

    .line 396
    iget v0, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->bitField0_:I

    and-int/lit8 v0, v0, -0x2

    iput v0, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->bitField0_:I

    .line 397
    invoke-static {}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->getDefaultInstance()Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    move-result-object v0

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->getPacketFactory()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->packetFactory_:Ljava/lang/String;

    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;
    .locals 1

    .line 1121
    sget-object v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    return-object v0
.end method

.method private mergeOptions(Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryOptions;)V
    .locals 2

    .line 614
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 615
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->options_:Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryOptions;

    if-eqz v0, :cond_0

    .line 616
    invoke-static {}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryOptions;->getDefaultInstance()Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryOptions;

    move-result-object v1

    if-eq v0, v1, :cond_0

    .line 617
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->options_:Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryOptions;

    .line 618
    invoke-static {v0}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryOptions;->newBuilder(Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryOptions;)Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryOptions$Builder;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryOptions$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$ExtendableBuilder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite$ExtendableMessage;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryOptions;

    iput-object p1, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->options_:Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryOptions;

    goto :goto_0

    .line 620
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->options_:Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryOptions;

    .line 622
    :goto_0
    iget p1, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->bitField0_:I

    or-int/lit8 p1, p1, 0x8

    iput p1, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->bitField0_:I

    return-void
.end method

.method public static newBuilder()Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig$Builder;
    .locals 1

    .line 712
    sget-object v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;)Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig$Builder;
    .locals 1

    .line 715
    sget-object v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;
    .locals 1

    .line 688
    sget-object v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;
    .locals 1

    .line 695
    sget-object v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;
    .locals 1

    .line 651
    sget-object v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;
    .locals 1

    .line 658
    sget-object v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;
    .locals 1

    .line 700
    sget-object v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;
    .locals 1

    .line 707
    sget-object v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;
    .locals 1

    .line 675
    sget-object v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;
    .locals 1

    .line 682
    sget-object v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;
    .locals 1

    .line 638
    sget-object v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;
    .locals 1

    .line 645
    sget-object v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;
    .locals 1

    .line 663
    sget-object v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;
    .locals 1

    .line 670
    sget-object v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;",
            ">;"
        }
    .end annotation

    .line 1127
    sget-object v0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private setExternalOutput(Ljava/lang/String;)V
    .locals 1

    .line 540
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 541
    iget v0, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->bitField0_:I

    or-int/lit8 v0, v0, 0x4

    iput v0, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->bitField0_:I

    .line 542
    iput-object p1, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->externalOutput_:Ljava/lang/String;

    return-void
.end method

.method private setExternalOutputBytes(Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 565
    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->externalOutput_:Ljava/lang/String;

    .line 566
    iget p1, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->bitField0_:I

    or-int/lit8 p1, p1, 0x4

    iput p1, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->bitField0_:I

    return-void
.end method

.method private setOptions(Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryOptions;)V
    .locals 0

    .line 601
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 602
    iput-object p1, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->options_:Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryOptions;

    .line 603
    iget p1, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->bitField0_:I

    or-int/lit8 p1, p1, 0x8

    iput p1, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->bitField0_:I

    return-void
.end method

.method private setOutputSidePacket(Ljava/lang/String;)V
    .locals 1

    .line 462
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 463
    iget v0, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->bitField0_:I

    or-int/lit8 v0, v0, 0x2

    iput v0, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->bitField0_:I

    .line 464
    iput-object p1, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->outputSidePacket_:Ljava/lang/String;

    return-void
.end method

.method private setOutputSidePacketBytes(Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 487
    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->outputSidePacket_:Ljava/lang/String;

    .line 488
    iget p1, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->bitField0_:I

    or-int/lit8 p1, p1, 0x2

    iput p1, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->bitField0_:I

    return-void
.end method

.method private setPacketFactory(Ljava/lang/String;)V
    .locals 1

    .line 384
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 385
    iget v0, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->bitField0_:I

    or-int/lit8 v0, v0, 0x1

    iput v0, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->bitField0_:I

    .line 386
    iput-object p1, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->packetFactory_:Ljava/lang/String;

    return-void
.end method

.method private setPacketFactoryBytes(Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 409
    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->packetFactory_:Ljava/lang/String;

    .line 410
    iget p1, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->bitField0_:I

    or-int/lit8 p1, p1, 0x1

    iput p1, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->bitField0_:I

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 2

    .line 1058
    sget-object p3, Lcom/google/mediapipe/proto/PacketFactoryProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p3, p1

    const/4 p3, 0x0

    packed-switch p1, :pswitch_data_0

    .line 1105
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

    .line 1101
    iput-byte p1, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->memoizedIsInitialized:B

    return-object p3

    .line 1098
    :pswitch_1
    iget-byte p1, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->memoizedIsInitialized:B

    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 1083
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_2

    .line 1085
    const-class p2, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    monitor-enter p2

    .line 1086
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 1088
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 1091
    sput-object p1, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_1

    :catchall_0
    move-exception p1

    goto :goto_2

    .line 1093
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

    .line 1080
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    return-object p1

    .line 1066
    :pswitch_4
    const-string p1, "bitField0_"

    const-string p2, "packetFactory_"

    const-string p3, "outputSidePacket_"

    const-string v0, "options_"

    const-string v1, "externalOutput_"

    filled-new-array {p1, p2, p3, v0, v1}, [Ljava/lang/Object;

    move-result-object p1

    .line 1073
    const-string p2, "\u0001\u0004\u0000\u0001\u0001\u03ea\u0004\u0000\u0000\u0001\u0001\u1008\u0000\u0002\u1008\u0001\u0003\u1409\u0003\u03ea\u1008\u0002"

    .line 1076
    sget-object p3, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-static {p3, p2, p1}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 1063
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig$Builder;

    invoke-direct {p1, p3}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig$Builder;-><init>(Lcom/google/mediapipe/proto/PacketFactoryProto$1;)V

    return-object p1

    .line 1060
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;

    invoke-direct {p1}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;-><init>()V

    return-object p1

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

    .line 324
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getExternalOutput()Ljava/lang/String;
    .locals 1

    .line 515
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->externalOutput_:Ljava/lang/String;

    return-object v0
.end method

.method public getExternalOutputBytes()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 528
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->externalOutput_:Ljava/lang/String;

    invoke-static {v0}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object v0

    return-object v0
.end method

.method public getOptions()Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryOptions;
    .locals 1

    .line 591
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->options_:Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryOptions;

    if-nez v0, :cond_0

    invoke-static {}, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryOptions;->getDefaultInstance()Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryOptions;

    move-result-object v0

    :cond_0
    return-object v0
.end method

.method public getOutputSidePacket()Ljava/lang/String;
    .locals 1

    .line 437
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->outputSidePacket_:Ljava/lang/String;

    return-object v0
.end method

.method public getOutputSidePacketBytes()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 450
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->outputSidePacket_:Ljava/lang/String;

    invoke-static {v0}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object v0

    return-object v0
.end method

.method public getPacketFactory()Ljava/lang/String;
    .locals 1

    .line 359
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->packetFactory_:Ljava/lang/String;

    return-object v0
.end method

.method public getPacketFactoryBytes()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 372
    iget-object v0, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->packetFactory_:Ljava/lang/String;

    invoke-static {v0}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object v0

    return-object v0
.end method

.method public hasExternalOutput()Z
    .locals 1

    .line 503
    iget v0, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->bitField0_:I

    and-int/lit8 v0, v0, 0x4

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasOptions()Z
    .locals 1

    .line 580
    iget v0, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->bitField0_:I

    and-int/lit8 v0, v0, 0x8

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasOutputSidePacket()Z
    .locals 1

    .line 425
    iget v0, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->bitField0_:I

    and-int/lit8 v0, v0, 0x2

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasPacketFactory()Z
    .locals 2

    .line 347
    iget v0, p0, Lcom/google/mediapipe/proto/PacketFactoryProto$PacketFactoryConfig;->bitField0_:I

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

    .line 324
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 324
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
