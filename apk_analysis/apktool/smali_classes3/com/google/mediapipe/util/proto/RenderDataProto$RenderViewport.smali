.class public final Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "RenderDataProto.java"

# interfaces
.implements Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewportOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/util/proto/RenderDataProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "RenderViewport"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;",
        "Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport$Builder;",
        ">;",
        "Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewportOrBuilder;"
    }
.end annotation


# static fields
.field public static final COMPOSE_ON_VIDEO_FIELD_NUMBER:I = 0x4

.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

.field public static final HEIGHT_PX_FIELD_NUMBER:I = 0x3

.field public static final ID_FIELD_NUMBER:I = 0x1

.field private static volatile PARSER:Lcom/google/protobuf/Parser; = null
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;",
            ">;"
        }
    .end annotation
.end field

.field public static final WIDTH_PX_FIELD_NUMBER:I = 0x2


# instance fields
.field private bitField0_:I

.field private composeOnVideo_:Z

.field private heightPx_:I

.field private id_:Ljava/lang/String;

.field private widthPx_:I


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 11537
    new-instance v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    invoke-direct {v0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;-><init>()V

    .line 11540
    sput-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    .line 11541
    const-class v1, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    .line 10874
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    .line 10875
    const-string v0, ""

    iput-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->id_:Ljava/lang/String;

    return-void
.end method

.method static synthetic access$19900()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;
    .locals 1

    .line 10869
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    return-object v0
.end method

.method static synthetic access$20000(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;Ljava/lang/String;)V
    .locals 0

    .line 10869
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->setId(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$20100(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;)V
    .locals 0

    .line 10869
    invoke-direct {p0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->clearId()V

    return-void
.end method

.method static synthetic access$20200(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 10869
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->setIdBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method static synthetic access$20300(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;I)V
    .locals 0

    .line 10869
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->setWidthPx(I)V

    return-void
.end method

.method static synthetic access$20400(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;)V
    .locals 0

    .line 10869
    invoke-direct {p0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->clearWidthPx()V

    return-void
.end method

.method static synthetic access$20500(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;I)V
    .locals 0

    .line 10869
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->setHeightPx(I)V

    return-void
.end method

.method static synthetic access$20600(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;)V
    .locals 0

    .line 10869
    invoke-direct {p0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->clearHeightPx()V

    return-void
.end method

.method static synthetic access$20700(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;Z)V
    .locals 0

    .line 10869
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->setComposeOnVideo(Z)V

    return-void
.end method

.method static synthetic access$20800(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;)V
    .locals 0

    .line 10869
    invoke-direct {p0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->clearComposeOnVideo()V

    return-void
.end method

.method private clearComposeOnVideo()V
    .locals 1

    .line 11118
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->bitField0_:I

    and-int/lit8 v0, v0, -0x9

    iput v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->bitField0_:I

    const/4 v0, 0x0

    .line 11119
    iput-boolean v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->composeOnVideo_:Z

    return-void
.end method

.method private clearHeightPx()V
    .locals 1

    .line 11064
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->bitField0_:I

    and-int/lit8 v0, v0, -0x5

    iput v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->bitField0_:I

    const/4 v0, 0x0

    .line 11065
    iput v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->heightPx_:I

    return-void
.end method

.method private clearId()V
    .locals 1

    .line 10939
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->bitField0_:I

    and-int/lit8 v0, v0, -0x2

    iput v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->bitField0_:I

    .line 10940
    invoke-static {}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->getDefaultInstance()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    move-result-object v0

    invoke-virtual {v0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->getId()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->id_:Ljava/lang/String;

    return-void
.end method

.method private clearWidthPx()V
    .locals 1

    .line 11030
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->bitField0_:I

    and-int/lit8 v0, v0, -0x3

    iput v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->bitField0_:I

    const/4 v0, 0x0

    .line 11031
    iput v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->widthPx_:I

    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;
    .locals 1

    .line 11546
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    return-object v0
.end method

.method public static newBuilder()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport$Builder;
    .locals 1

    .line 11199
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport$Builder;
    .locals 1

    .line 11202
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;
    .locals 1

    .line 11175
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;
    .locals 1

    .line 11182
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;
    .locals 1

    .line 11138
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;
    .locals 1

    .line 11145
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;
    .locals 1

    .line 11187
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;
    .locals 1

    .line 11194
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;
    .locals 1

    .line 11162
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;
    .locals 1

    .line 11169
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;
    .locals 1

    .line 11125
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;
    .locals 1

    .line 11132
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;
    .locals 1

    .line 11150
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;
    .locals 1

    .line 11157
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;",
            ">;"
        }
    .end annotation

    .line 11552
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private setComposeOnVideo(Z)V
    .locals 1

    .line 11106
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->bitField0_:I

    or-int/lit8 v0, v0, 0x8

    iput v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->bitField0_:I

    .line 11107
    iput-boolean p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->composeOnVideo_:Z

    return-void
.end method

.method private setHeightPx(I)V
    .locals 1

    .line 11057
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->bitField0_:I

    or-int/lit8 v0, v0, 0x4

    iput v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->bitField0_:I

    .line 11058
    iput p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->heightPx_:I

    return-void
.end method

.method private setId(Ljava/lang/String;)V
    .locals 1

    .line 10927
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 10928
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->bitField0_:I

    or-int/lit8 v0, v0, 0x1

    iput v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->bitField0_:I

    .line 10929
    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->id_:Ljava/lang/String;

    return-void
.end method

.method private setIdBytes(Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 10952
    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->id_:Ljava/lang/String;

    .line 10953
    iget p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->bitField0_:I

    or-int/lit8 p1, p1, 0x1

    iput p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->bitField0_:I

    return-void
.end method

.method private setWidthPx(I)V
    .locals 1

    .line 11012
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->bitField0_:I

    or-int/lit8 v0, v0, 0x2

    iput v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->bitField0_:I

    .line 11013
    iput p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->widthPx_:I

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 2

    .line 11484
    sget-object p2, Lcom/google/mediapipe/util/proto/RenderDataProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p2, p1

    const/4 p2, 0x0

    packed-switch p1, :pswitch_data_0

    .line 11530
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    invoke-direct {p1}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw p1

    :pswitch_0
    return-object p2

    :pswitch_1
    const/4 p1, 0x1

    .line 11524
    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 11509
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 11511
    const-class p2, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    monitor-enter p2

    .line 11512
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_0

    .line 11514
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 11517
    sput-object p1, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 11519
    :cond_0
    :goto_0
    monitor-exit p2

    return-object p1

    :goto_1
    monitor-exit p2
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw p1

    :cond_1
    return-object p1

    .line 11506
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    return-object p1

    .line 11492
    :pswitch_4
    const-string p1, "bitField0_"

    const-string p2, "id_"

    const-string p3, "widthPx_"

    const-string v0, "heightPx_"

    const-string v1, "composeOnVideo_"

    filled-new-array {p1, p2, p3, v0, v1}, [Ljava/lang/Object;

    move-result-object p1

    .line 11499
    const-string p2, "\u0001\u0004\u0000\u0001\u0001\u0004\u0004\u0000\u0000\u0000\u0001\u1008\u0000\u0002\u1004\u0001\u0003\u1004\u0002\u0004\u1007\u0003"

    .line 11502
    sget-object p3, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    invoke-static {p3, p2, p1}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 11489
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport$Builder;

    invoke-direct {p1, p2}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport$Builder;-><init>(Lcom/google/mediapipe/util/proto/RenderDataProto$1;)V

    return-object p1

    .line 11486
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    invoke-direct {p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;-><init>()V

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

.method public getComposeOnVideo()Z
    .locals 1

    .line 11094
    iget-boolean v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->composeOnVideo_:Z

    return v0
.end method

.method public bridge synthetic getDefaultInstanceForType()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 10869
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getHeightPx()I
    .locals 1

    .line 11050
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->heightPx_:I

    return v0
.end method

.method public getId()Ljava/lang/String;
    .locals 1

    .line 10902
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->id_:Ljava/lang/String;

    return-object v0
.end method

.method public getIdBytes()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 10915
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->id_:Ljava/lang/String;

    invoke-static {v0}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object v0

    return-object v0
.end method

.method public getWidthPx()I
    .locals 1

    .line 10994
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->widthPx_:I

    return v0
.end method

.method public hasComposeOnVideo()Z
    .locals 1

    .line 11081
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->bitField0_:I

    and-int/lit8 v0, v0, 0x8

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasHeightPx()Z
    .locals 1

    .line 11042
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->bitField0_:I

    and-int/lit8 v0, v0, 0x4

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasId()Z
    .locals 2

    .line 10890
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->bitField0_:I

    const/4 v1, 0x1

    and-int/2addr v0, v1

    if-eqz v0, :cond_0

    return v1

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasWidthPx()Z
    .locals 1

    .line 10975
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->bitField0_:I

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

    .line 10869
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 10869
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
