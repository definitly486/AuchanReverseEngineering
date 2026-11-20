.class public final Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "StreamHandlerProto.java"

# interfaces
.implements Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfigOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/proto/StreamHandlerProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "OutputStreamHandlerConfig"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;",
        "Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig$Builder;",
        ">;",
        "Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfigOrBuilder;"
    }
.end annotation


# static fields
.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

.field public static final INPUT_SIDE_PACKET_FIELD_NUMBER:I = 0x2

.field public static final OPTIONS_FIELD_NUMBER:I = 0x3

.field public static final OUTPUT_STREAM_HANDLER_FIELD_NUMBER:I = 0x1

.field private static volatile PARSER:Lcom/google/protobuf/Parser;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;",
            ">;"
        }
    .end annotation
.end field


# instance fields
.field private bitField0_:I

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

.field private options_:Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

.field private outputStreamHandler_:Ljava/lang/String;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 1403
    new-instance v0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    invoke-direct {v0}, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;-><init>()V

    .line 1406
    sput-object v0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    .line 1407
    const-class v1, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    .line 666
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    const/4 v0, 0x2

    .line 1344
    iput-byte v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->memoizedIsInitialized:B

    .line 667
    const-string v0, "InOrderOutputStreamHandler"

    iput-object v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->outputStreamHandler_:Ljava/lang/String;

    .line 668
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method static synthetic access$1000(Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;)V
    .locals 0

    .line 661
    invoke-direct {p0}, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->clearOutputStreamHandler()V

    return-void
.end method

.method static synthetic access$1100(Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 661
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->setOutputStreamHandlerBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method static synthetic access$1200(Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;ILjava/lang/String;)V
    .locals 0

    .line 661
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->setInputSidePacket(ILjava/lang/String;)V

    return-void
.end method

.method static synthetic access$1300(Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;Ljava/lang/String;)V
    .locals 0

    .line 661
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->addInputSidePacket(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$1400(Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;Ljava/lang/Iterable;)V
    .locals 0

    .line 661
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->addAllInputSidePacket(Ljava/lang/Iterable;)V

    return-void
.end method

.method static synthetic access$1500(Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;)V
    .locals 0

    .line 661
    invoke-direct {p0}, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->clearInputSidePacket()V

    return-void
.end method

.method static synthetic access$1600(Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 661
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->addInputSidePacketBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method static synthetic access$1700(Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)V
    .locals 0

    .line 661
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->setOptions(Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)V

    return-void
.end method

.method static synthetic access$1800(Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)V
    .locals 0

    .line 661
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->mergeOptions(Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)V

    return-void
.end method

.method static synthetic access$1900(Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;)V
    .locals 0

    .line 661
    invoke-direct {p0}, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->clearOptions()V

    return-void
.end method

.method static synthetic access$800()Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;
    .locals 1

    .line 661
    sget-object v0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    return-object v0
.end method

.method static synthetic access$900(Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;Ljava/lang/String;)V
    .locals 0

    .line 661
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->setOutputStreamHandler(Ljava/lang/String;)V

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

    .line 856
    invoke-direct {p0}, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->ensureInputSidePacketIsMutable()V

    .line 857
    iget-object v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-static {p1, v0}, Lcom/google/protobuf/AbstractMessageLite;->addAll(Ljava/lang/Iterable;Ljava/util/List;)V

    return-void
.end method

.method private addInputSidePacket(Ljava/lang/String;)V
    .locals 1

    .line 841
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 842
    invoke-direct {p0}, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->ensureInputSidePacketIsMutable()V

    .line 843
    iget-object v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private addInputSidePacketBytes(Lcom/google/protobuf/ByteString;)V
    .locals 1

    .line 882
    invoke-direct {p0}, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->ensureInputSidePacketIsMutable()V

    .line 883
    iget-object v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private clearInputSidePacket()V
    .locals 1

    .line 869
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method private clearOptions()V
    .locals 1

    const/4 v0, 0x0

    .line 948
    iput-object v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->options_:Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    .line 949
    iget v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->bitField0_:I

    and-int/lit8 v0, v0, -0x3

    iput v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->bitField0_:I

    return-void
.end method

.method private clearOutputStreamHandler()V
    .locals 1

    .line 732
    iget v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->bitField0_:I

    and-int/lit8 v0, v0, -0x2

    iput v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->bitField0_:I

    .line 733
    invoke-static {}, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->getDefaultInstance()Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    move-result-object v0

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->getOutputStreamHandler()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->outputStreamHandler_:Ljava/lang/String;

    return-void
.end method

.method private ensureInputSidePacketIsMutable()V
    .locals 2

    .line 808
    iget-object v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 809
    invoke-interface {v0}, Lcom/google/protobuf/Internal$ProtobufList;->isModifiable()Z

    move-result v1

    if-nez v1, :cond_0

    .line 811
    invoke-static {v0}, Lcom/google/protobuf/GeneratedMessageLite;->mutableCopy(Lcom/google/protobuf/Internal$ProtobufList;)Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    :cond_0
    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;
    .locals 1

    .line 1412
    sget-object v0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    return-object v0
.end method

.method private mergeOptions(Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)V
    .locals 2

    .line 931
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 932
    iget-object v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->options_:Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    if-eqz v0, :cond_0

    .line 933
    invoke-static {}, Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;->getDefaultInstance()Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    move-result-object v1

    if-eq v0, v1, :cond_0

    .line 934
    iget-object v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->options_:Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    .line 935
    invoke-static {v0}, Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;->newBuilder(Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions$Builder;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$ExtendableBuilder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite$ExtendableMessage;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    iput-object p1, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->options_:Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    goto :goto_0

    .line 937
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->options_:Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    .line 939
    :goto_0
    iget p1, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->bitField0_:I

    or-int/lit8 p1, p1, 0x2

    iput p1, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->bitField0_:I

    return-void
.end method

.method public static newBuilder()Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig$Builder;
    .locals 1

    .line 1029
    sget-object v0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;)Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig$Builder;
    .locals 1

    .line 1032
    sget-object v0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;
    .locals 1

    .line 1005
    sget-object v0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;
    .locals 1

    .line 1012
    sget-object v0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;
    .locals 1

    .line 968
    sget-object v0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;
    .locals 1

    .line 975
    sget-object v0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;
    .locals 1

    .line 1017
    sget-object v0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;
    .locals 1

    .line 1024
    sget-object v0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;
    .locals 1

    .line 992
    sget-object v0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;
    .locals 1

    .line 999
    sget-object v0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;
    .locals 1

    .line 955
    sget-object v0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;
    .locals 1

    .line 962
    sget-object v0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;
    .locals 1

    .line 980
    sget-object v0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;
    .locals 1

    .line 987
    sget-object v0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;",
            ">;"
        }
    .end annotation

    .line 1418
    sget-object v0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private setInputSidePacket(ILjava/lang/String;)V
    .locals 1

    .line 826
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 827
    invoke-direct {p0}, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->ensureInputSidePacketIsMutable()V

    .line 828
    iget-object v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->set(ILjava/lang/Object;)Ljava/lang/Object;

    return-void
.end method

.method private setOptions(Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)V
    .locals 0

    .line 918
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 919
    iput-object p1, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->options_:Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    .line 920
    iget p1, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->bitField0_:I

    or-int/lit8 p1, p1, 0x2

    iput p1, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->bitField0_:I

    return-void
.end method

.method private setOutputStreamHandler(Ljava/lang/String;)V
    .locals 1

    .line 720
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 721
    iget v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->bitField0_:I

    or-int/lit8 v0, v0, 0x1

    iput v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->bitField0_:I

    .line 722
    iput-object p1, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->outputStreamHandler_:Ljava/lang/String;

    return-void
.end method

.method private setOutputStreamHandlerBytes(Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 745
    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->outputStreamHandler_:Ljava/lang/String;

    .line 746
    iget p1, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->bitField0_:I

    or-int/lit8 p1, p1, 0x1

    iput p1, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->bitField0_:I

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 1

    .line 1350
    sget-object p3, Lcom/google/mediapipe/proto/StreamHandlerProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p3, p1

    const/4 p3, 0x0

    packed-switch p1, :pswitch_data_0

    .line 1396
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

    .line 1392
    iput-byte p1, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->memoizedIsInitialized:B

    return-object p3

    .line 1389
    :pswitch_1
    iget-byte p1, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->memoizedIsInitialized:B

    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 1374
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_2

    .line 1376
    const-class p2, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    monitor-enter p2

    .line 1377
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 1379
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 1382
    sput-object p1, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_1

    :catchall_0
    move-exception p1

    goto :goto_2

    .line 1384
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

    .line 1371
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    return-object p1

    .line 1358
    :pswitch_4
    const-string p1, "bitField0_"

    const-string p2, "outputStreamHandler_"

    const-string p3, "inputSidePacket_"

    const-string v0, "options_"

    filled-new-array {p1, p2, p3, v0}, [Ljava/lang/Object;

    move-result-object p1

    .line 1364
    const-string p2, "\u0001\u0003\u0000\u0001\u0001\u0003\u0003\u0000\u0001\u0001\u0001\u1008\u0000\u0002\u001a\u0003\u1409\u0001"

    .line 1367
    sget-object p3, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    invoke-static {p3, p2, p1}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 1355
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig$Builder;

    invoke-direct {p1, p3}, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig$Builder;-><init>(Lcom/google/mediapipe/proto/StreamHandlerProto$1;)V

    return-object p1

    .line 1352
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;

    invoke-direct {p1}, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;-><init>()V

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

    .line 661
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getInputSidePacket(I)Ljava/lang/String;
    .locals 1

    .line 789
    iget-object v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/lang/String;

    return-object p1
.end method

.method public getInputSidePacketBytes(I)Lcom/google/protobuf/ByteString;
    .locals 1

    .line 804
    iget-object v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 805
    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/lang/String;

    .line 804
    invoke-static {p1}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object p1

    return-object p1
.end method

.method public getInputSidePacketCount()I
    .locals 1

    .line 775
    iget-object v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

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

    .line 762
    iget-object v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public getOptions()Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;
    .locals 1

    .line 908
    iget-object v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->options_:Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    if-nez v0, :cond_0

    invoke-static {}, Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;->getDefaultInstance()Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    move-result-object v0

    :cond_0
    return-object v0
.end method

.method public getOutputStreamHandler()Ljava/lang/String;
    .locals 1

    .line 695
    iget-object v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->outputStreamHandler_:Ljava/lang/String;

    return-object v0
.end method

.method public getOutputStreamHandlerBytes()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 708
    iget-object v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->outputStreamHandler_:Ljava/lang/String;

    invoke-static {v0}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object v0

    return-object v0
.end method

.method public hasOptions()Z
    .locals 1

    .line 897
    iget v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->bitField0_:I

    and-int/lit8 v0, v0, 0x2

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasOutputStreamHandler()Z
    .locals 2

    .line 683
    iget v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$OutputStreamHandlerConfig;->bitField0_:I

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

    .line 661
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 661
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
