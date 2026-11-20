.class public final Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "MediaPipeLoggingProto.java"

# interfaces
.implements Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfoOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/proto/MediaPipeLoggingProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "SystemInfo"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;",
        "Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo$Builder;",
        ">;",
        "Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfoOrBuilder;"
    }
.end annotation


# static fields
.field public static final APP_ID_FIELD_NUMBER:I = 0x2

.field public static final APP_VERSION_FIELD_NUMBER:I = 0x3

.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

.field public static final MEDIAPIPE_VERSION_FIELD_NUMBER:I = 0x4

.field private static volatile PARSER:Lcom/google/protobuf/Parser; = null
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;",
            ">;"
        }
    .end annotation
.end field

.field public static final PLATFORM_FIELD_NUMBER:I = 0x1


# instance fields
.field private appId_:Ljava/lang/String;

.field private appVersion_:Ljava/lang/String;

.field private bitField0_:I

.field private mediapipeVersion_:Ljava/lang/String;

.field private platform_:I


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 1404
    new-instance v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    invoke-direct {v0}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;-><init>()V

    .line 1407
    sput-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    .line 1408
    const-class v1, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    .line 648
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    .line 649
    const-string v0, ""

    iput-object v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->appId_:Ljava/lang/String;

    .line 650
    iput-object v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->appVersion_:Ljava/lang/String;

    .line 651
    iput-object v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->mediapipeVersion_:Ljava/lang/String;

    return-void
.end method

.method static synthetic access$1000(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;)V
    .locals 0

    .line 643
    invoke-direct {p0}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->clearPlatform()V

    return-void
.end method

.method static synthetic access$1100(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;Ljava/lang/String;)V
    .locals 0

    .line 643
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->setAppId(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$1200(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;)V
    .locals 0

    .line 643
    invoke-direct {p0}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->clearAppId()V

    return-void
.end method

.method static synthetic access$1300(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 643
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->setAppIdBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method static synthetic access$1400(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;Ljava/lang/String;)V
    .locals 0

    .line 643
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->setAppVersion(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$1500(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;)V
    .locals 0

    .line 643
    invoke-direct {p0}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->clearAppVersion()V

    return-void
.end method

.method static synthetic access$1600(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 643
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->setAppVersionBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method static synthetic access$1700(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;Ljava/lang/String;)V
    .locals 0

    .line 643
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->setMediapipeVersion(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$1800(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;)V
    .locals 0

    .line 643
    invoke-direct {p0}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->clearMediapipeVersion()V

    return-void
.end method

.method static synthetic access$1900(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 643
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->setMediapipeVersionBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method static synthetic access$800()Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;
    .locals 1

    .line 643
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    return-object v0
.end method

.method static synthetic access$900(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$Platform;)V
    .locals 0

    .line 643
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->setPlatform(Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$Platform;)V

    return-void
.end method

.method private clearAppId()V
    .locals 1

    .line 771
    iget v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->bitField0_:I

    and-int/lit8 v0, v0, -0x3

    iput v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->bitField0_:I

    .line 772
    invoke-static {}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->getDefaultInstance()Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    move-result-object v0

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->getAppId()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->appId_:Ljava/lang/String;

    return-void
.end method

.method private clearAppVersion()V
    .locals 1

    .line 850
    iget v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->bitField0_:I

    and-int/lit8 v0, v0, -0x5

    iput v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->bitField0_:I

    .line 851
    invoke-static {}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->getDefaultInstance()Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    move-result-object v0

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->getAppVersion()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->appVersion_:Ljava/lang/String;

    return-void
.end method

.method private clearMediapipeVersion()V
    .locals 1

    .line 928
    iget v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->bitField0_:I

    and-int/lit8 v0, v0, -0x9

    iput v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->bitField0_:I

    .line 929
    invoke-static {}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->getDefaultInstance()Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    move-result-object v0

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->getMediapipeVersion()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->mediapipeVersion_:Ljava/lang/String;

    return-void
.end method

.method private clearPlatform()V
    .locals 1

    .line 701
    iget v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->bitField0_:I

    and-int/lit8 v0, v0, -0x2

    iput v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->bitField0_:I

    const/4 v0, 0x0

    .line 702
    iput v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->platform_:I

    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;
    .locals 1

    .line 1413
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    return-object v0
.end method

.method public static newBuilder()Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo$Builder;
    .locals 1

    .line 1022
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo$Builder;
    .locals 1

    .line 1025
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;
    .locals 1

    .line 998
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;
    .locals 1

    .line 1005
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;
    .locals 1

    .line 961
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;
    .locals 1

    .line 968
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;
    .locals 1

    .line 1010
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;
    .locals 1

    .line 1017
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;
    .locals 1

    .line 985
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;
    .locals 1

    .line 992
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;
    .locals 1

    .line 948
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;
    .locals 1

    .line 955
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;
    .locals 1

    .line 973
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;
    .locals 1

    .line 980
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;",
            ">;"
        }
    .end annotation

    .line 1419
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private setAppId(Ljava/lang/String;)V
    .locals 1

    .line 758
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 759
    iget v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->bitField0_:I

    or-int/lit8 v0, v0, 0x2

    iput v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->bitField0_:I

    .line 760
    iput-object p1, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->appId_:Ljava/lang/String;

    return-void
.end method

.method private setAppIdBytes(Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 785
    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->appId_:Ljava/lang/String;

    .line 786
    iget p1, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->bitField0_:I

    or-int/lit8 p1, p1, 0x2

    iput p1, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->bitField0_:I

    return-void
.end method

.method private setAppVersion(Ljava/lang/String;)V
    .locals 1

    .line 838
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 839
    iget v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->bitField0_:I

    or-int/lit8 v0, v0, 0x4

    iput v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->bitField0_:I

    .line 840
    iput-object p1, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->appVersion_:Ljava/lang/String;

    return-void
.end method

.method private setAppVersionBytes(Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 863
    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->appVersion_:Ljava/lang/String;

    .line 864
    iget p1, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->bitField0_:I

    or-int/lit8 p1, p1, 0x4

    iput p1, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->bitField0_:I

    return-void
.end method

.method private setMediapipeVersion(Ljava/lang/String;)V
    .locals 1

    .line 916
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 917
    iget v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->bitField0_:I

    or-int/lit8 v0, v0, 0x8

    iput v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->bitField0_:I

    .line 918
    iput-object p1, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->mediapipeVersion_:Ljava/lang/String;

    return-void
.end method

.method private setMediapipeVersionBytes(Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 941
    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->mediapipeVersion_:Ljava/lang/String;

    .line 942
    iget p1, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->bitField0_:I

    or-int/lit8 p1, p1, 0x8

    iput p1, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->bitField0_:I

    return-void
.end method

.method private setPlatform(Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$Platform;)V
    .locals 0

    .line 690
    invoke-virtual {p1}, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$Platform;->getNumber()I

    move-result p1

    iput p1, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->platform_:I

    .line 691
    iget p1, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->bitField0_:I

    or-int/lit8 p1, p1, 0x1

    iput p1, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->bitField0_:I

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 6

    .line 1350
    sget-object p2, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p2, p1

    const/4 p2, 0x0

    packed-switch p1, :pswitch_data_0

    .line 1397
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    invoke-direct {p1}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw p1

    :pswitch_0
    return-object p2

    :pswitch_1
    const/4 p1, 0x1

    .line 1391
    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 1376
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 1378
    const-class p2, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    monitor-enter p2

    .line 1379
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_0

    .line 1381
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 1384
    sput-object p1, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_0

    :catchall_0
    move-exception v0

    move-object p1, v0

    goto :goto_1

    .line 1386
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

    .line 1373
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    return-object p1

    .line 1358
    :pswitch_4
    const-string v0, "bitField0_"

    const-string v1, "platform_"

    .line 1361
    invoke-static {}, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$Platform;->internalGetVerifier()Lcom/google/protobuf/Internal$EnumVerifier;

    move-result-object v2

    const-string v3, "appId_"

    const-string v4, "appVersion_"

    const-string v5, "mediapipeVersion_"

    filled-new-array/range {v0 .. v5}, [Ljava/lang/Object;

    move-result-object p1

    .line 1366
    const-string p2, "\u0001\u0004\u0000\u0001\u0001\u0004\u0004\u0000\u0000\u0000\u0001\u180c\u0000\u0002\u1008\u0001\u0003\u1008\u0002\u0004\u1008\u0003"

    .line 1369
    sget-object p3, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    invoke-static {p3, p2, p1}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 1355
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo$Builder;

    invoke-direct {p1, p2}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo$Builder;-><init>(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$1;)V

    return-object p1

    .line 1352
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    invoke-direct {p1}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;-><init>()V

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

.method public getAppId()Ljava/lang/String;
    .locals 1

    .line 731
    iget-object v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->appId_:Ljava/lang/String;

    return-object v0
.end method

.method public getAppIdBytes()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 745
    iget-object v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->appId_:Ljava/lang/String;

    invoke-static {v0}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object v0

    return-object v0
.end method

.method public getAppVersion()Ljava/lang/String;
    .locals 1

    .line 813
    iget-object v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->appVersion_:Ljava/lang/String;

    return-object v0
.end method

.method public getAppVersionBytes()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 826
    iget-object v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->appVersion_:Ljava/lang/String;

    invoke-static {v0}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic getDefaultInstanceForType()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 643
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getMediapipeVersion()Ljava/lang/String;
    .locals 1

    .line 891
    iget-object v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->mediapipeVersion_:Ljava/lang/String;

    return-object v0
.end method

.method public getMediapipeVersionBytes()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 904
    iget-object v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->mediapipeVersion_:Ljava/lang/String;

    invoke-static {v0}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object v0

    return-object v0
.end method

.method public getPlatform()Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$Platform;
    .locals 1

    .line 678
    iget v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->platform_:I

    invoke-static {v0}, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$Platform;->forNumber(I)Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$Platform;

    move-result-object v0

    if-nez v0, :cond_0

    .line 679
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$Platform;->PLATFORM_UNKNOWN:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$Platform;

    :cond_0
    return-object v0
.end method

.method public hasAppId()Z
    .locals 1

    .line 718
    iget v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->bitField0_:I

    and-int/lit8 v0, v0, 0x2

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasAppVersion()Z
    .locals 1

    .line 801
    iget v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->bitField0_:I

    and-int/lit8 v0, v0, 0x4

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasMediapipeVersion()Z
    .locals 1

    .line 879
    iget v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->bitField0_:I

    and-int/lit8 v0, v0, 0x8

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasPlatform()Z
    .locals 2

    .line 666
    iget v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->bitField0_:I

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

    .line 643
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 643
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
