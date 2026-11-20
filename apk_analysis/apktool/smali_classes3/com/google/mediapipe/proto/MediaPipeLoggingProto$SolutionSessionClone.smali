.class public final Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "MediaPipeLoggingProto.java"

# interfaces
.implements Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionCloneOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/proto/MediaPipeLoggingProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "SolutionSessionClone"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;",
        "Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone$Builder;",
        ">;",
        "Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionCloneOrBuilder;"
    }
.end annotation


# static fields
.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

.field public static final GRAPH_NAME_FIELD_NUMBER:I = 0x2

.field public static final INIT_LATENCY_MS_FIELD_NUMBER:I = 0x3

.field public static final MODE_FIELD_NUMBER:I = 0x1

.field private static volatile PARSER:Lcom/google/protobuf/Parser;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;",
            ">;"
        }
    .end annotation
.end field


# instance fields
.field private bitField0_:I

.field private graphName_:Ljava/lang/String;

.field private initLatencyMs_:J

.field private mode_:I


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 4179
    new-instance v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

    invoke-direct {v0}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;-><init>()V

    .line 4182
    sput-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

    .line 4183
    const-class v1, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    .line 3638
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    .line 3639
    const-string v0, ""

    iput-object v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->graphName_:Ljava/lang/String;

    return-void
.end method

.method static synthetic access$5800()Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;
    .locals 1

    .line 3633
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

    return-object v0
.end method

.method static synthetic access$5900(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;)V
    .locals 0

    .line 3633
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->setMode(Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;)V

    return-void
.end method

.method static synthetic access$6000(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;)V
    .locals 0

    .line 3633
    invoke-direct {p0}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->clearMode()V

    return-void
.end method

.method static synthetic access$6100(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;Ljava/lang/String;)V
    .locals 0

    .line 3633
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->setGraphName(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$6200(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;)V
    .locals 0

    .line 3633
    invoke-direct {p0}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->clearGraphName()V

    return-void
.end method

.method static synthetic access$6300(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 3633
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->setGraphNameBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method static synthetic access$6400(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;J)V
    .locals 0

    .line 3633
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->setInitLatencyMs(J)V

    return-void
.end method

.method static synthetic access$6500(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;)V
    .locals 0

    .line 3633
    invoke-direct {p0}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->clearInitLatencyMs()V

    return-void
.end method

.method private clearGraphName()V
    .locals 1

    .line 3759
    iget v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->bitField0_:I

    and-int/lit8 v0, v0, -0x3

    iput v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->bitField0_:I

    .line 3760
    invoke-static {}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->getDefaultInstance()Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

    move-result-object v0

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->getGraphName()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->graphName_:Ljava/lang/String;

    return-void
.end method

.method private clearInitLatencyMs()V
    .locals 2

    .line 3823
    iget v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->bitField0_:I

    and-int/lit8 v0, v0, -0x5

    iput v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->bitField0_:I

    const-wide/16 v0, 0x0

    .line 3824
    iput-wide v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->initLatencyMs_:J

    return-void
.end method

.method private clearMode()V
    .locals 1

    .line 3689
    iget v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->bitField0_:I

    and-int/lit8 v0, v0, -0x2

    iput v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->bitField0_:I

    const/4 v0, 0x0

    .line 3690
    iput v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->mode_:I

    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;
    .locals 1

    .line 4188
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

    return-object v0
.end method

.method public static newBuilder()Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone$Builder;
    .locals 1

    .line 3904
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone$Builder;
    .locals 1

    .line 3907
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;
    .locals 1

    .line 3880
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;
    .locals 1

    .line 3887
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;
    .locals 1

    .line 3843
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;
    .locals 1

    .line 3850
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;
    .locals 1

    .line 3892
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;
    .locals 1

    .line 3899
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;
    .locals 1

    .line 3867
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;
    .locals 1

    .line 3874
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;
    .locals 1

    .line 3830
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;
    .locals 1

    .line 3837
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;
    .locals 1

    .line 3855
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;
    .locals 1

    .line 3862
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;",
            ">;"
        }
    .end annotation

    .line 4194
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private setGraphName(Ljava/lang/String;)V
    .locals 1

    .line 3746
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 3747
    iget v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->bitField0_:I

    or-int/lit8 v0, v0, 0x2

    iput v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->bitField0_:I

    .line 3748
    iput-object p1, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->graphName_:Ljava/lang/String;

    return-void
.end method

.method private setGraphNameBytes(Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 3773
    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->graphName_:Ljava/lang/String;

    .line 3774
    iget p1, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->bitField0_:I

    or-int/lit8 p1, p1, 0x2

    iput p1, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->bitField0_:I

    return-void
.end method

.method private setInitLatencyMs(J)V
    .locals 1

    .line 3812
    iget v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->bitField0_:I

    or-int/lit8 v0, v0, 0x4

    iput v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->bitField0_:I

    .line 3813
    iput-wide p1, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->initLatencyMs_:J

    return-void
.end method

.method private setMode(Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;)V
    .locals 0

    .line 3678
    invoke-virtual {p1}, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->getNumber()I

    move-result p1

    iput p1, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->mode_:I

    .line 3679
    iget p1, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->bitField0_:I

    or-int/lit8 p1, p1, 0x1

    iput p1, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->bitField0_:I

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 2

    .line 4126
    sget-object p2, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p2, p1

    const/4 p2, 0x0

    packed-switch p1, :pswitch_data_0

    .line 4172
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    invoke-direct {p1}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw p1

    :pswitch_0
    return-object p2

    :pswitch_1
    const/4 p1, 0x1

    .line 4166
    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 4151
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 4153
    const-class p2, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

    monitor-enter p2

    .line 4154
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_0

    .line 4156
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 4159
    sput-object p1, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 4161
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

    .line 4148
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

    return-object p1

    .line 4134
    :pswitch_4
    const-string p1, "bitField0_"

    const-string p2, "mode_"

    .line 4137
    invoke-static {}, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->internalGetVerifier()Lcom/google/protobuf/Internal$EnumVerifier;

    move-result-object p3

    const-string v0, "graphName_"

    const-string v1, "initLatencyMs_"

    filled-new-array {p1, p2, p3, v0, v1}, [Ljava/lang/Object;

    move-result-object p1

    .line 4141
    const-string p2, "\u0001\u0003\u0000\u0001\u0001\u0003\u0003\u0000\u0000\u0000\u0001\u180c\u0000\u0002\u1008\u0001\u0003\u1003\u0002"

    .line 4144
    sget-object p3, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

    invoke-static {p3, p2, p1}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 4131
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone$Builder;

    invoke-direct {p1, p2}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone$Builder;-><init>(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$1;)V

    return-object p1

    .line 4128
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

    invoke-direct {p1}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;-><init>()V

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

    .line 3633
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getGraphName()Ljava/lang/String;
    .locals 1

    .line 3719
    iget-object v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->graphName_:Ljava/lang/String;

    return-object v0
.end method

.method public getGraphNameBytes()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 3733
    iget-object v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->graphName_:Ljava/lang/String;

    invoke-static {v0}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object v0

    return-object v0
.end method

.method public getInitLatencyMs()J
    .locals 2

    .line 3801
    iget-wide v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->initLatencyMs_:J

    return-wide v0
.end method

.method public getMode()Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;
    .locals 1

    .line 3666
    iget v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->mode_:I

    invoke-static {v0}, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->forNumber(I)Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    move-result-object v0

    if-nez v0, :cond_0

    .line 3667
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->MODE_UNKNOWN:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    :cond_0
    return-object v0
.end method

.method public hasGraphName()Z
    .locals 1

    .line 3706
    iget v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->bitField0_:I

    and-int/lit8 v0, v0, 0x2

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasInitLatencyMs()Z
    .locals 1

    .line 3789
    iget v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->bitField0_:I

    and-int/lit8 v0, v0, 0x4

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasMode()Z
    .locals 2

    .line 3654
    iget v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->bitField0_:I

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

    .line 3633
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 3633
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
