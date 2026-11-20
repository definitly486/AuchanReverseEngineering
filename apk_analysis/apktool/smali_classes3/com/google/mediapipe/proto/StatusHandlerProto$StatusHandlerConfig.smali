.class public final Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "StatusHandlerProto.java"

# interfaces
.implements Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfigOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/proto/StatusHandlerProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "StatusHandlerConfig"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;",
        "Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig$Builder;",
        ">;",
        "Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfigOrBuilder;"
    }
.end annotation


# static fields
.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

.field public static final EXTERNAL_INPUT_FIELD_NUMBER:I = 0x3ea

.field public static final INPUT_SIDE_PACKET_FIELD_NUMBER:I = 0x2

.field public static final OPTIONS_FIELD_NUMBER:I = 0x3

.field private static volatile PARSER:Lcom/google/protobuf/Parser; = null
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;",
            ">;"
        }
    .end annotation
.end field

.field public static final STATUS_HANDLER_FIELD_NUMBER:I = 0x1


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

.field private statusHandler_:Ljava/lang/String;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 1224
    new-instance v0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    invoke-direct {v0}, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;-><init>()V

    .line 1227
    sput-object v0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    .line 1228
    const-class v1, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    .line 175
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    const/4 v0, 0x2

    .line 1164
    iput-byte v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->memoizedIsInitialized:B

    .line 176
    const-string v0, ""

    iput-object v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->statusHandler_:Ljava/lang/String;

    .line 177
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 178
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->externalInput_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method static synthetic access$000()Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;
    .locals 1

    .line 170
    sget-object v0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    return-object v0
.end method

.method static synthetic access$100(Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;Ljava/lang/String;)V
    .locals 0

    .line 170
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->setStatusHandler(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$1000(Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;Ljava/lang/String;)V
    .locals 0

    .line 170
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->addExternalInput(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$1100(Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;Ljava/lang/Iterable;)V
    .locals 0

    .line 170
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->addAllExternalInput(Ljava/lang/Iterable;)V

    return-void
.end method

.method static synthetic access$1200(Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;)V
    .locals 0

    .line 170
    invoke-direct {p0}, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->clearExternalInput()V

    return-void
.end method

.method static synthetic access$1300(Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 170
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->addExternalInputBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method static synthetic access$1400(Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)V
    .locals 0

    .line 170
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->setOptions(Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)V

    return-void
.end method

.method static synthetic access$1500(Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)V
    .locals 0

    .line 170
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->mergeOptions(Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)V

    return-void
.end method

.method static synthetic access$1600(Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;)V
    .locals 0

    .line 170
    invoke-direct {p0}, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->clearOptions()V

    return-void
.end method

.method static synthetic access$200(Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;)V
    .locals 0

    .line 170
    invoke-direct {p0}, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->clearStatusHandler()V

    return-void
.end method

.method static synthetic access$300(Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 170
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->setStatusHandlerBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method static synthetic access$400(Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;ILjava/lang/String;)V
    .locals 0

    .line 170
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->setInputSidePacket(ILjava/lang/String;)V

    return-void
.end method

.method static synthetic access$500(Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;Ljava/lang/String;)V
    .locals 0

    .line 170
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->addInputSidePacket(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$600(Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;Ljava/lang/Iterable;)V
    .locals 0

    .line 170
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->addAllInputSidePacket(Ljava/lang/Iterable;)V

    return-void
.end method

.method static synthetic access$700(Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;)V
    .locals 0

    .line 170
    invoke-direct {p0}, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->clearInputSidePacket()V

    return-void
.end method

.method static synthetic access$800(Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 170
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->addInputSidePacketBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method static synthetic access$900(Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;ILjava/lang/String;)V
    .locals 0

    .line 170
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->setExternalInput(ILjava/lang/String;)V

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

    .line 523
    invoke-direct {p0}, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->ensureExternalInputIsMutable()V

    .line 524
    iget-object v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->externalInput_:Lcom/google/protobuf/Internal$ProtobufList;

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

    .line 387
    invoke-direct {p0}, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->ensureInputSidePacketIsMutable()V

    .line 388
    iget-object v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-static {p1, v0}, Lcom/google/protobuf/AbstractMessageLite;->addAll(Ljava/lang/Iterable;Ljava/util/List;)V

    return-void
.end method

.method private addExternalInput(Ljava/lang/String;)V
    .locals 1

    .line 509
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 510
    invoke-direct {p0}, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->ensureExternalInputIsMutable()V

    .line 511
    iget-object v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->externalInput_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private addExternalInputBytes(Lcom/google/protobuf/ByteString;)V
    .locals 1

    .line 547
    invoke-direct {p0}, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->ensureExternalInputIsMutable()V

    .line 548
    iget-object v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->externalInput_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private addInputSidePacket(Ljava/lang/String;)V
    .locals 1

    .line 369
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 370
    invoke-direct {p0}, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->ensureInputSidePacketIsMutable()V

    .line 371
    iget-object v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private addInputSidePacketBytes(Lcom/google/protobuf/ByteString;)V
    .locals 1

    .line 419
    invoke-direct {p0}, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->ensureInputSidePacketIsMutable()V

    .line 420
    iget-object v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private clearExternalInput()V
    .locals 1

    .line 535
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->externalInput_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method private clearInputSidePacket()V
    .locals 1

    .line 403
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method private clearOptions()V
    .locals 1

    const/4 v0, 0x0

    .line 613
    iput-object v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->options_:Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    .line 614
    iget v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->bitField0_:I

    and-int/lit8 v0, v0, -0x3

    iput v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->bitField0_:I

    return-void
.end method

.method private clearStatusHandler()V
    .locals 1

    .line 242
    iget v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->bitField0_:I

    and-int/lit8 v0, v0, -0x2

    iput v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->bitField0_:I

    .line 243
    invoke-static {}, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->getDefaultInstance()Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    move-result-object v0

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->getStatusHandler()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->statusHandler_:Ljava/lang/String;

    return-void
.end method

.method private ensureExternalInputIsMutable()V
    .locals 2

    .line 478
    iget-object v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->externalInput_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 479
    invoke-interface {v0}, Lcom/google/protobuf/Internal$ProtobufList;->isModifiable()Z

    move-result v1

    if-nez v1, :cond_0

    .line 481
    invoke-static {v0}, Lcom/google/protobuf/GeneratedMessageLite;->mutableCopy(Lcom/google/protobuf/Internal$ProtobufList;)Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->externalInput_:Lcom/google/protobuf/Internal$ProtobufList;

    :cond_0
    return-void
.end method

.method private ensureInputSidePacketIsMutable()V
    .locals 2

    .line 330
    iget-object v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 331
    invoke-interface {v0}, Lcom/google/protobuf/Internal$ProtobufList;->isModifiable()Z

    move-result v1

    if-nez v1, :cond_0

    .line 333
    invoke-static {v0}, Lcom/google/protobuf/GeneratedMessageLite;->mutableCopy(Lcom/google/protobuf/Internal$ProtobufList;)Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    :cond_0
    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;
    .locals 1

    .line 1233
    sget-object v0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    return-object v0
.end method

.method private mergeOptions(Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)V
    .locals 2

    .line 596
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 597
    iget-object v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->options_:Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    if-eqz v0, :cond_0

    .line 598
    invoke-static {}, Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;->getDefaultInstance()Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    move-result-object v1

    if-eq v0, v1, :cond_0

    .line 599
    iget-object v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->options_:Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    .line 600
    invoke-static {v0}, Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;->newBuilder(Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions$Builder;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$ExtendableBuilder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite$ExtendableMessage;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    iput-object p1, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->options_:Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    goto :goto_0

    .line 602
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->options_:Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    .line 604
    :goto_0
    iget p1, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->bitField0_:I

    or-int/lit8 p1, p1, 0x2

    iput p1, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->bitField0_:I

    return-void
.end method

.method public static newBuilder()Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig$Builder;
    .locals 1

    .line 694
    sget-object v0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;)Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig$Builder;
    .locals 1

    .line 697
    sget-object v0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;
    .locals 1

    .line 670
    sget-object v0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;
    .locals 1

    .line 677
    sget-object v0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;
    .locals 1

    .line 633
    sget-object v0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;
    .locals 1

    .line 640
    sget-object v0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;
    .locals 1

    .line 682
    sget-object v0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;
    .locals 1

    .line 689
    sget-object v0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;
    .locals 1

    .line 657
    sget-object v0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;
    .locals 1

    .line 664
    sget-object v0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;
    .locals 1

    .line 620
    sget-object v0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;
    .locals 1

    .line 627
    sget-object v0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;
    .locals 1

    .line 645
    sget-object v0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;
    .locals 1

    .line 652
    sget-object v0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;",
            ">;"
        }
    .end annotation

    .line 1239
    sget-object v0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private setExternalInput(ILjava/lang/String;)V
    .locals 1

    .line 495
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 496
    invoke-direct {p0}, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->ensureExternalInputIsMutable()V

    .line 497
    iget-object v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->externalInput_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->set(ILjava/lang/Object;)Ljava/lang/Object;

    return-void
.end method

.method private setInputSidePacket(ILjava/lang/String;)V
    .locals 1

    .line 351
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 352
    invoke-direct {p0}, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->ensureInputSidePacketIsMutable()V

    .line 353
    iget-object v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->set(ILjava/lang/Object;)Ljava/lang/Object;

    return-void
.end method

.method private setOptions(Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)V
    .locals 0

    .line 583
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 584
    iput-object p1, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->options_:Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    .line 585
    iget p1, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->bitField0_:I

    or-int/lit8 p1, p1, 0x2

    iput p1, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->bitField0_:I

    return-void
.end method

.method private setStatusHandler(Ljava/lang/String;)V
    .locals 1

    .line 230
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 231
    iget v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->bitField0_:I

    or-int/lit8 v0, v0, 0x1

    iput v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->bitField0_:I

    .line 232
    iput-object p1, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->statusHandler_:Ljava/lang/String;

    return-void
.end method

.method private setStatusHandlerBytes(Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 255
    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->statusHandler_:Ljava/lang/String;

    .line 256
    iget p1, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->bitField0_:I

    or-int/lit8 p1, p1, 0x1

    iput p1, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->bitField0_:I

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 2

    .line 1170
    sget-object p3, Lcom/google/mediapipe/proto/StatusHandlerProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p3, p1

    const/4 p3, 0x0

    packed-switch p1, :pswitch_data_0

    .line 1217
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

    .line 1213
    iput-byte p1, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->memoizedIsInitialized:B

    return-object p3

    .line 1210
    :pswitch_1
    iget-byte p1, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->memoizedIsInitialized:B

    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 1195
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_2

    .line 1197
    const-class p2, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    monitor-enter p2

    .line 1198
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 1200
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 1203
    sput-object p1, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_1

    :catchall_0
    move-exception p1

    goto :goto_2

    .line 1205
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

    .line 1192
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    return-object p1

    .line 1178
    :pswitch_4
    const-string p1, "bitField0_"

    const-string p2, "statusHandler_"

    const-string p3, "inputSidePacket_"

    const-string v0, "options_"

    const-string v1, "externalInput_"

    filled-new-array {p1, p2, p3, v0, v1}, [Ljava/lang/Object;

    move-result-object p1

    .line 1185
    const-string p2, "\u0001\u0004\u0000\u0001\u0001\u03ea\u0004\u0000\u0002\u0001\u0001\u1008\u0000\u0002\u001a\u0003\u1409\u0001\u03ea\u001a"

    .line 1188
    sget-object p3, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    invoke-static {p3, p2, p1}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 1175
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig$Builder;

    invoke-direct {p1, p3}, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig$Builder;-><init>(Lcom/google/mediapipe/proto/StatusHandlerProto$1;)V

    return-object p1

    .line 1172
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;

    invoke-direct {p1}, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;-><init>()V

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

    .line 170
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getExternalInput(I)Ljava/lang/String;
    .locals 1

    .line 460
    iget-object v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->externalInput_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/lang/String;

    return-object p1
.end method

.method public getExternalInputBytes(I)Lcom/google/protobuf/ByteString;
    .locals 1

    .line 474
    iget-object v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->externalInput_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 475
    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/lang/String;

    .line 474
    invoke-static {p1}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object p1

    return-object p1
.end method

.method public getExternalInputCount()I
    .locals 1

    .line 447
    iget-object v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->externalInput_:Lcom/google/protobuf/Internal$ProtobufList;

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

    .line 435
    iget-object v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->externalInput_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public getInputSidePacket(I)Ljava/lang/String;
    .locals 1

    .line 308
    iget-object v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/lang/String;

    return-object p1
.end method

.method public getInputSidePacketBytes(I)Lcom/google/protobuf/ByteString;
    .locals 1

    .line 326
    iget-object v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 327
    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/lang/String;

    .line 326
    invoke-static {p1}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object p1

    return-object p1
.end method

.method public getInputSidePacketCount()I
    .locals 1

    .line 291
    iget-object v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

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

    .line 275
    iget-object v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->inputSidePacket_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public getOptions()Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;
    .locals 1

    .line 573
    iget-object v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->options_:Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    if-nez v0, :cond_0

    invoke-static {}, Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;->getDefaultInstance()Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    move-result-object v0

    :cond_0
    return-object v0
.end method

.method public getStatusHandler()Ljava/lang/String;
    .locals 1

    .line 205
    iget-object v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->statusHandler_:Ljava/lang/String;

    return-object v0
.end method

.method public getStatusHandlerBytes()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 218
    iget-object v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->statusHandler_:Ljava/lang/String;

    invoke-static {v0}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object v0

    return-object v0
.end method

.method public hasOptions()Z
    .locals 1

    .line 562
    iget v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->bitField0_:I

    and-int/lit8 v0, v0, 0x2

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasStatusHandler()Z
    .locals 2

    .line 193
    iget v0, p0, Lcom/google/mediapipe/proto/StatusHandlerProto$StatusHandlerConfig;->bitField0_:I

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

    .line 170
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 170
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
