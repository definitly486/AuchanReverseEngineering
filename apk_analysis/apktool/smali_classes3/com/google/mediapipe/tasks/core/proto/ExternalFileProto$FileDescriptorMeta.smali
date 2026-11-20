.class public final Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "ExternalFileProto.java"

# interfaces
.implements Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMetaOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "FileDescriptorMeta"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;",
        "Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta$Builder;",
        ">;",
        "Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMetaOrBuilder;"
    }
.end annotation


# static fields
.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

.field public static final FD_FIELD_NUMBER:I = 0x1

.field public static final LENGTH_FIELD_NUMBER:I = 0x2

.field public static final OFFSET_FIELD_NUMBER:I = 0x3

.field private static volatile PARSER:Lcom/google/protobuf/Parser;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;",
            ">;"
        }
    .end annotation
.end field


# instance fields
.field private bitField0_:I

.field private fd_:I

.field private length_:J

.field private offset_:J


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 1545
    new-instance v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    invoke-direct {v0}, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;-><init>()V

    .line 1548
    sput-object v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    .line 1549
    const-class v1, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 1011
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    return-void
.end method

.method static synthetic access$1300()Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;
    .locals 1

    .line 1006
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    return-object v0
.end method

.method static synthetic access$1400(Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;I)V
    .locals 0

    .line 1006
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->setFd(I)V

    return-void
.end method

.method static synthetic access$1500(Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;)V
    .locals 0

    .line 1006
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->clearFd()V

    return-void
.end method

.method static synthetic access$1600(Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;J)V
    .locals 0

    .line 1006
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->setLength(J)V

    return-void
.end method

.method static synthetic access$1700(Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;)V
    .locals 0

    .line 1006
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->clearLength()V

    return-void
.end method

.method static synthetic access$1800(Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;J)V
    .locals 0

    .line 1006
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->setOffset(J)V

    return-void
.end method

.method static synthetic access$1900(Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;)V
    .locals 0

    .line 1006
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->clearOffset()V

    return-void
.end method

.method private clearFd()V
    .locals 1

    .line 1060
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->bitField0_:I

    and-int/lit8 v0, v0, -0x2

    iput v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->bitField0_:I

    const/4 v0, 0x0

    .line 1061
    iput v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->fd_:I

    return-void
.end method

.method private clearLength()V
    .locals 2

    .line 1126
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->bitField0_:I

    and-int/lit8 v0, v0, -0x3

    iput v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->bitField0_:I

    const-wide/16 v0, 0x0

    .line 1127
    iput-wide v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->length_:J

    return-void
.end method

.method private clearOffset()V
    .locals 2

    .line 1192
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->bitField0_:I

    and-int/lit8 v0, v0, -0x5

    iput v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->bitField0_:I

    const-wide/16 v0, 0x0

    .line 1193
    iput-wide v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->offset_:J

    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;
    .locals 1

    .line 1554
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    return-object v0
.end method

.method public static newBuilder()Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta$Builder;
    .locals 1

    .line 1273
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;)Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta$Builder;
    .locals 1

    .line 1276
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;
    .locals 1

    .line 1249
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;
    .locals 1

    .line 1256
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;
    .locals 1

    .line 1212
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;
    .locals 1

    .line 1219
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;
    .locals 1

    .line 1261
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;
    .locals 1

    .line 1268
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;
    .locals 1

    .line 1236
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;
    .locals 1

    .line 1243
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;
    .locals 1

    .line 1199
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;
    .locals 1

    .line 1206
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;
    .locals 1

    .line 1224
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;
    .locals 1

    .line 1231
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;",
            ">;"
        }
    .end annotation

    .line 1560
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private setFd(I)V
    .locals 1

    .line 1049
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->bitField0_:I

    or-int/lit8 v0, v0, 0x1

    iput v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->bitField0_:I

    .line 1050
    iput p1, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->fd_:I

    return-void
.end method

.method private setLength(J)V
    .locals 1

    .line 1111
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->bitField0_:I

    or-int/lit8 v0, v0, 0x2

    iput v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->bitField0_:I

    .line 1112
    iput-wide p1, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->length_:J

    return-void
.end method

.method private setOffset(J)V
    .locals 1

    .line 1177
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->bitField0_:I

    or-int/lit8 v0, v0, 0x4

    iput v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->bitField0_:I

    .line 1178
    iput-wide p1, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->offset_:J

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 1

    .line 1493
    sget-object p2, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p2, p1

    const/4 p2, 0x0

    packed-switch p1, :pswitch_data_0

    .line 1538
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    invoke-direct {p1}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw p1

    :pswitch_0
    return-object p2

    :pswitch_1
    const/4 p1, 0x1

    .line 1532
    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 1517
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 1519
    const-class p2, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    monitor-enter p2

    .line 1520
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_0

    .line 1522
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 1525
    sput-object p1, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 1527
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

    .line 1514
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    return-object p1

    .line 1501
    :pswitch_4
    const-string p1, "bitField0_"

    const-string p2, "fd_"

    const-string p3, "length_"

    const-string v0, "offset_"

    filled-new-array {p1, p2, p3, v0}, [Ljava/lang/Object;

    move-result-object p1

    .line 1507
    const-string p2, "\u0001\u0003\u0000\u0001\u0001\u0003\u0003\u0000\u0000\u0000\u0001\u1004\u0000\u0002\u1002\u0001\u0003\u1002\u0002"

    .line 1510
    sget-object p3, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    invoke-static {p3, p2, p1}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 1498
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta$Builder;

    invoke-direct {p1, p2}, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta$Builder;-><init>(Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$1;)V

    return-object p1

    .line 1495
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    invoke-direct {p1}, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;-><init>()V

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

    .line 1006
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getFd()I
    .locals 1

    .line 1038
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->fd_:I

    return v0
.end method

.method public getLength()J
    .locals 2

    .line 1096
    iget-wide v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->length_:J

    return-wide v0
.end method

.method public getOffset()J
    .locals 2

    .line 1162
    iget-wide v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->offset_:J

    return-wide v0
.end method

.method public hasFd()Z
    .locals 2

    .line 1026
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->bitField0_:I

    const/4 v1, 0x1

    and-int/2addr v0, v1

    if-eqz v0, :cond_0

    return v1

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasLength()Z
    .locals 1

    .line 1080
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->bitField0_:I

    and-int/lit8 v0, v0, 0x2

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasOffset()Z
    .locals 1

    .line 1146
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->bitField0_:I

    and-int/lit8 v0, v0, 0x4

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public bridge synthetic newBuilderForType()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 1006
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 1006
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
