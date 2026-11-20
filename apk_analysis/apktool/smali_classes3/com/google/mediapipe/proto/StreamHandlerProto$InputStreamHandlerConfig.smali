.class public final Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "StreamHandlerProto.java"

# interfaces
.implements Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfigOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/proto/StreamHandlerProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "InputStreamHandlerConfig"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;",
        "Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig$Builder;",
        ">;",
        "Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfigOrBuilder;"
    }
.end annotation


# static fields
.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

.field public static final INPUT_STREAM_HANDLER_FIELD_NUMBER:I = 0x1

.field public static final OPTIONS_FIELD_NUMBER:I = 0x3

.field private static volatile PARSER:Lcom/google/protobuf/Parser;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;",
            ">;"
        }
    .end annotation
.end field


# instance fields
.field private bitField0_:I

.field private inputStreamHandler_:Ljava/lang/String;

.field private memoizedIsInitialized:B

.field private options_:Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 538
    new-instance v0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    invoke-direct {v0}, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;-><init>()V

    .line 541
    sput-object v0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    .line 542
    const-class v1, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    .line 77
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    const/4 v0, 0x2

    .line 480
    iput-byte v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->memoizedIsInitialized:B

    .line 78
    const-string v0, "DefaultInputStreamHandler"

    iput-object v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->inputStreamHandler_:Ljava/lang/String;

    return-void
.end method

.method static synthetic access$000()Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;
    .locals 1

    .line 72
    sget-object v0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    return-object v0
.end method

.method static synthetic access$100(Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;Ljava/lang/String;)V
    .locals 0

    .line 72
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->setInputStreamHandler(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$200(Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;)V
    .locals 0

    .line 72
    invoke-direct {p0}, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->clearInputStreamHandler()V

    return-void
.end method

.method static synthetic access$300(Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 72
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->setInputStreamHandlerBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method static synthetic access$400(Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)V
    .locals 0

    .line 72
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->setOptions(Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)V

    return-void
.end method

.method static synthetic access$500(Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)V
    .locals 0

    .line 72
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->mergeOptions(Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)V

    return-void
.end method

.method static synthetic access$600(Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;)V
    .locals 0

    .line 72
    invoke-direct {p0}, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->clearOptions()V

    return-void
.end method

.method private clearInputStreamHandler()V
    .locals 1

    .line 142
    iget v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->bitField0_:I

    and-int/lit8 v0, v0, -0x2

    iput v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->bitField0_:I

    .line 143
    invoke-static {}, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->getDefaultInstance()Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    move-result-object v0

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->getInputStreamHandler()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->inputStreamHandler_:Ljava/lang/String;

    return-void
.end method

.method private clearOptions()V
    .locals 1

    const/4 v0, 0x0

    .line 221
    iput-object v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->options_:Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    .line 222
    iget v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->bitField0_:I

    and-int/lit8 v0, v0, -0x3

    iput v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->bitField0_:I

    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;
    .locals 1

    .line 547
    sget-object v0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    return-object v0
.end method

.method private mergeOptions(Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)V
    .locals 2

    .line 204
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 205
    iget-object v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->options_:Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    if-eqz v0, :cond_0

    .line 206
    invoke-static {}, Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;->getDefaultInstance()Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    move-result-object v1

    if-eq v0, v1, :cond_0

    .line 207
    iget-object v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->options_:Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    .line 208
    invoke-static {v0}, Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;->newBuilder(Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions$Builder;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$ExtendableBuilder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite$ExtendableMessage;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    iput-object p1, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->options_:Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    goto :goto_0

    .line 210
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->options_:Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    .line 212
    :goto_0
    iget p1, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->bitField0_:I

    or-int/lit8 p1, p1, 0x2

    iput p1, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->bitField0_:I

    return-void
.end method

.method public static newBuilder()Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig$Builder;
    .locals 1

    .line 302
    sget-object v0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;)Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig$Builder;
    .locals 1

    .line 305
    sget-object v0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;
    .locals 1

    .line 278
    sget-object v0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;
    .locals 1

    .line 285
    sget-object v0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;
    .locals 1

    .line 241
    sget-object v0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;
    .locals 1

    .line 248
    sget-object v0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;
    .locals 1

    .line 290
    sget-object v0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;
    .locals 1

    .line 297
    sget-object v0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;
    .locals 1

    .line 265
    sget-object v0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;
    .locals 1

    .line 272
    sget-object v0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;
    .locals 1

    .line 228
    sget-object v0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;
    .locals 1

    .line 235
    sget-object v0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;
    .locals 1

    .line 253
    sget-object v0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;
    .locals 1

    .line 260
    sget-object v0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;",
            ">;"
        }
    .end annotation

    .line 553
    sget-object v0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private setInputStreamHandler(Ljava/lang/String;)V
    .locals 1

    .line 130
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 131
    iget v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->bitField0_:I

    or-int/lit8 v0, v0, 0x1

    iput v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->bitField0_:I

    .line 132
    iput-object p1, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->inputStreamHandler_:Ljava/lang/String;

    return-void
.end method

.method private setInputStreamHandlerBytes(Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 155
    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->inputStreamHandler_:Ljava/lang/String;

    .line 156
    iget p1, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->bitField0_:I

    or-int/lit8 p1, p1, 0x1

    iput p1, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->bitField0_:I

    return-void
.end method

.method private setOptions(Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;)V
    .locals 0

    .line 191
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 192
    iput-object p1, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->options_:Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    .line 193
    iget p1, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->bitField0_:I

    or-int/lit8 p1, p1, 0x2

    iput p1, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->bitField0_:I

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 486
    sget-object p3, Lcom/google/mediapipe/proto/StreamHandlerProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p3, p1

    const/4 p3, 0x0

    packed-switch p1, :pswitch_data_0

    .line 531
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

    .line 527
    iput-byte p1, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->memoizedIsInitialized:B

    return-object p3

    .line 524
    :pswitch_1
    iget-byte p1, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->memoizedIsInitialized:B

    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 509
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_2

    .line 511
    const-class p2, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    monitor-enter p2

    .line 512
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 514
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 517
    sput-object p1, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_1

    :catchall_0
    move-exception p1

    goto :goto_2

    .line 519
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

    .line 506
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    return-object p1

    .line 494
    :pswitch_4
    const-string p1, "bitField0_"

    const-string p2, "inputStreamHandler_"

    const-string p3, "options_"

    filled-new-array {p1, p2, p3}, [Ljava/lang/Object;

    move-result-object p1

    .line 499
    const-string p2, "\u0001\u0002\u0000\u0001\u0001\u0003\u0002\u0000\u0000\u0001\u0001\u1008\u0000\u0003\u1409\u0001"

    .line 502
    sget-object p3, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    invoke-static {p3, p2, p1}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 491
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig$Builder;

    invoke-direct {p1, p3}, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig$Builder;-><init>(Lcom/google/mediapipe/proto/StreamHandlerProto$1;)V

    return-object p1

    .line 488
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;

    invoke-direct {p1}, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;-><init>()V

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

    .line 72
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getInputStreamHandler()Ljava/lang/String;
    .locals 1

    .line 105
    iget-object v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->inputStreamHandler_:Ljava/lang/String;

    return-object v0
.end method

.method public getInputStreamHandlerBytes()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 118
    iget-object v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->inputStreamHandler_:Ljava/lang/String;

    invoke-static {v0}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object v0

    return-object v0
.end method

.method public getOptions()Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;
    .locals 1

    .line 181
    iget-object v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->options_:Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    if-nez v0, :cond_0

    invoke-static {}, Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;->getDefaultInstance()Lcom/google/mediapipe/proto/MediaPipeOptionsProto$MediaPipeOptions;

    move-result-object v0

    :cond_0
    return-object v0
.end method

.method public hasInputStreamHandler()Z
    .locals 2

    .line 93
    iget v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->bitField0_:I

    const/4 v1, 0x1

    and-int/2addr v0, v1

    if-eqz v0, :cond_0

    return v1

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasOptions()Z
    .locals 1

    .line 170
    iget v0, p0, Lcom/google/mediapipe/proto/StreamHandlerProto$InputStreamHandlerConfig;->bitField0_:I

    and-int/lit8 v0, v0, 0x2

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public bridge synthetic newBuilderForType()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 72
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 72
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
