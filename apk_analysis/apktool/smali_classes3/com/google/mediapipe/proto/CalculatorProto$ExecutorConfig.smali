.class public final Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "CalculatorProto.java"

# interfaces
.implements Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfigOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/proto/CalculatorProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "ExecutorConfig"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;",
        "Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig$Builder;",
        ">;",
        "Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfigOrBuilder;"
    }
.end annotation


# static fields
.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

.field public static final NAME_FIELD_NUMBER:I = 0x1

.field public static final OPTIONS_FIELD_NUMBER:I = 0x3

.field private static volatile PARSER:Lcom/google/protobuf/Parser; = null
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;",
            ">;"
        }
    .end annotation
.end field

.field public static final TYPE_FIELD_NUMBER:I = 0x2


# instance fields
.field private bitField0_:I

.field private memoizedIsInitialized:B

.field private name_:Ljava/lang/String;

.field private options_:Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

.field private type_:Ljava/lang/String;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 907
    new-instance v0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    invoke-direct {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;-><init>()V

    .line 910
    sput-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    .line 911
    const-class v1, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    .line 128
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    const/4 v0, 0x2

    .line 848
    iput-byte v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->memoizedIsInitialized:B

    .line 129
    const-string v0, ""

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->name_:Ljava/lang/String;

    .line 130
    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->type_:Ljava/lang/String;

    return-void
.end method

.method static synthetic access$000()Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;
    .locals 1

    .line 123
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    return-object v0
.end method

.method static synthetic access$100(Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;Ljava/lang/String;)V
    .locals 0

    .line 123
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->setName(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$200(Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;)V
    .locals 0

    .line 123
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->clearName()V

    return-void
.end method

.method static synthetic access$300(Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 123
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->setNameBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method static synthetic access$400(Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;Ljava/lang/String;)V
    .locals 0

    .line 123
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->setType(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$500(Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;)V
    .locals 0

    .line 123
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->clearType()V

    return-void
.end method

.method static synthetic access$600(Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 123
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->setTypeBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method static synthetic access$700(Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)V
    .locals 0

    .line 123
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->setOptions(Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)V

    return-void
.end method

.method static synthetic access$800(Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)V
    .locals 0

    .line 123
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->mergeOptions(Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)V

    return-void
.end method

.method static synthetic access$900(Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;)V
    .locals 0

    .line 123
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->clearOptions()V

    return-void
.end method

.method private clearName()V
    .locals 1

    .line 207
    invoke-static {}, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->getDefaultInstance()Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    move-result-object v0

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->getName()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->name_:Ljava/lang/String;

    return-void
.end method

.method private clearOptions()V
    .locals 1

    const/4 v0, 0x0

    .line 429
    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->options_:Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    .line 430
    iget v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->bitField0_:I

    and-int/lit8 v0, v0, -0x2

    iput v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->bitField0_:I

    return-void
.end method

.method private clearType()V
    .locals 1

    .line 324
    invoke-static {}, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->getDefaultInstance()Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    move-result-object v0

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->getType()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->type_:Ljava/lang/String;

    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;
    .locals 1

    .line 916
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    return-object v0
.end method

.method private mergeOptions(Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)V
    .locals 2

    .line 409
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 410
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->options_:Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    if-eqz v0, :cond_0

    .line 411
    invoke-static {}, Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;->getDefaultInstance()Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    move-result-object v1

    if-eq v0, v1, :cond_0

    .line 412
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->options_:Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    .line 413
    invoke-static {v0}, Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;->newBuilder(Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions$Builder;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$ExtendableBuilder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite$ExtendableMessage;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    iput-object p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->options_:Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    goto :goto_0

    .line 415
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->options_:Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    .line 417
    :goto_0
    iget p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->bitField0_:I

    or-int/lit8 p1, p1, 0x1

    iput p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->bitField0_:I

    return-void
.end method

.method public static newBuilder()Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig$Builder;
    .locals 1

    .line 510
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;)Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig$Builder;
    .locals 1

    .line 513
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;
    .locals 1

    .line 486
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;
    .locals 1

    .line 493
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;
    .locals 1

    .line 449
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;
    .locals 1

    .line 456
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;
    .locals 1

    .line 498
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;
    .locals 1

    .line 505
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;
    .locals 1

    .line 473
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;
    .locals 1

    .line 480
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;
    .locals 1

    .line 436
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;
    .locals 1

    .line 443
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;
    .locals 1

    .line 461
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;
    .locals 1

    .line 468
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;",
            ">;"
        }
    .end annotation

    .line 922
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private setName(Ljava/lang/String;)V
    .locals 0

    .line 188
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 190
    iput-object p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->name_:Ljava/lang/String;

    return-void
.end method

.method private setNameBytes(Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 225
    invoke-static {p1}, Lcom/google/protobuf/AbstractMessageLite;->checkByteStringIsUtf8(Lcom/google/protobuf/ByteString;)V

    .line 226
    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->name_:Ljava/lang/String;

    return-void
.end method

.method private setOptions(Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)V
    .locals 0

    .line 393
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 394
    iput-object p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->options_:Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    .line 395
    iget p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->bitField0_:I

    or-int/lit8 p1, p1, 0x1

    iput p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->bitField0_:I

    return-void
.end method

.method private setType(Ljava/lang/String;)V
    .locals 0

    .line 300
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 302
    iput-object p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->type_:Ljava/lang/String;

    return-void
.end method

.method private setTypeBytes(Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 347
    invoke-static {p1}, Lcom/google/protobuf/AbstractMessageLite;->checkByteStringIsUtf8(Lcom/google/protobuf/ByteString;)V

    .line 348
    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->type_:Ljava/lang/String;

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 1

    .line 854
    sget-object p3, Lcom/google/mediapipe/proto/CalculatorProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p3, p1

    const/4 p3, 0x0

    packed-switch p1, :pswitch_data_0

    .line 900
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

    .line 896
    iput-byte p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->memoizedIsInitialized:B

    return-object p3

    .line 893
    :pswitch_1
    iget-byte p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->memoizedIsInitialized:B

    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 878
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_2

    .line 880
    const-class p2, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    monitor-enter p2

    .line 881
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 883
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 886
    sput-object p1, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_1

    :catchall_0
    move-exception p1

    goto :goto_2

    .line 888
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

    .line 875
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    return-object p1

    .line 862
    :pswitch_4
    const-string p1, "bitField0_"

    const-string p2, "name_"

    const-string p3, "type_"

    const-string v0, "options_"

    filled-new-array {p1, p2, p3, v0}, [Ljava/lang/Object;

    move-result-object p1

    .line 868
    const-string p2, "\u0000\u0003\u0000\u0001\u0001\u0003\u0003\u0000\u0000\u0001\u0001\u0208\u0002\u0208\u0003\u1409\u0000"

    .line 871
    sget-object p3, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    invoke-static {p3, p2, p1}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 859
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig$Builder;

    invoke-direct {p1, p3}, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig$Builder;-><init>(Lcom/google/mediapipe/proto/CalculatorProto$1;)V

    return-object p1

    .line 856
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;

    invoke-direct {p1}, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;-><init>()V

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

    .line 123
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getName()Ljava/lang/String;
    .locals 1

    .line 151
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->name_:Ljava/lang/String;

    return-object v0
.end method

.method public getNameBytes()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 170
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->name_:Ljava/lang/String;

    invoke-static {v0}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object v0

    return-object v0
.end method

.method public getOptions()Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;
    .locals 1

    .line 380
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->options_:Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    if-nez v0, :cond_0

    invoke-static {}, Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;->getDefaultInstance()Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    move-result-object v0

    :cond_0
    return-object v0
.end method

.method public getType()Ljava/lang/String;
    .locals 1

    .line 253
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->type_:Ljava/lang/String;

    return-object v0
.end method

.method public getTypeBytes()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 277
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->type_:Ljava/lang/String;

    invoke-static {v0}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object v0

    return-object v0
.end method

.method public hasOptions()Z
    .locals 2

    .line 366
    iget v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$ExecutorConfig;->bitField0_:I

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

    .line 123
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 123
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
