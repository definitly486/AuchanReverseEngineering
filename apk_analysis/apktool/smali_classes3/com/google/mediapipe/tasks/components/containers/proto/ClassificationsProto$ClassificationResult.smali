.class public final Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "ClassificationsProto.java"

# interfaces
.implements Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResultOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "ClassificationResult"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;",
        "Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult$Builder;",
        ">;",
        "Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResultOrBuilder;"
    }
.end annotation


# static fields
.field public static final CLASSIFICATIONS_FIELD_NUMBER:I = 0x1

.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

.field private static volatile PARSER:Lcom/google/protobuf/Parser; = null
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;",
            ">;"
        }
    .end annotation
.end field

.field public static final TIMESTAMP_MS_FIELD_NUMBER:I = 0x2


# instance fields
.field private bitField0_:I

.field private classifications_:Lcom/google/protobuf/Internal$ProtobufList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Internal$ProtobufList<",
            "Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;",
            ">;"
        }
    .end annotation
.end field

.field private timestampMs_:J


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 1418
    new-instance v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    invoke-direct {v0}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;-><init>()V

    .line 1421
    sput-object v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    .line 1422
    const-class v1, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    .line 793
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    .line 794
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->classifications_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method static synthetic access$1000()Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;
    .locals 1

    .line 788
    sget-object v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    return-object v0
.end method

.method static synthetic access$1100(Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;ILcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;)V
    .locals 0

    .line 788
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->setClassifications(ILcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;)V

    return-void
.end method

.method static synthetic access$1200(Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;)V
    .locals 0

    .line 788
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->addClassifications(Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;)V

    return-void
.end method

.method static synthetic access$1300(Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;ILcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;)V
    .locals 0

    .line 788
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->addClassifications(ILcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;)V

    return-void
.end method

.method static synthetic access$1400(Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;Ljava/lang/Iterable;)V
    .locals 0

    .line 788
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->addAllClassifications(Ljava/lang/Iterable;)V

    return-void
.end method

.method static synthetic access$1500(Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;)V
    .locals 0

    .line 788
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->clearClassifications()V

    return-void
.end method

.method static synthetic access$1600(Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;I)V
    .locals 0

    .line 788
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->removeClassifications(I)V

    return-void
.end method

.method static synthetic access$1700(Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;J)V
    .locals 0

    .line 788
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->setTimestampMs(J)V

    return-void
.end method

.method static synthetic access$1800(Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;)V
    .locals 0

    .line 788
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->clearTimestampMs()V

    return-void
.end method

.method private addAllClassifications(Ljava/lang/Iterable;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "+",
            "Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;",
            ">;)V"
        }
    .end annotation

    .line 918
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->ensureClassificationsIsMutable()V

    .line 919
    iget-object v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->classifications_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-static {p1, v0}, Lcom/google/protobuf/AbstractMessageLite;->addAll(Ljava/lang/Iterable;Ljava/util/List;)V

    return-void
.end method

.method private addClassifications(ILcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;)V
    .locals 1

    .line 904
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 905
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->ensureClassificationsIsMutable()V

    .line 906
    iget-object v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->classifications_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->add(ILjava/lang/Object;)V

    return-void
.end method

.method private addClassifications(Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;)V
    .locals 1

    .line 890
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 891
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->ensureClassificationsIsMutable()V

    .line 892
    iget-object v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->classifications_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private clearClassifications()V
    .locals 1

    .line 931
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->classifications_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method private clearTimestampMs()V
    .locals 2

    .line 1016
    iget v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->bitField0_:I

    and-int/lit8 v0, v0, -0x2

    iput v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->bitField0_:I

    const-wide/16 v0, 0x0

    .line 1017
    iput-wide v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->timestampMs_:J

    return-void
.end method

.method private ensureClassificationsIsMutable()V
    .locals 2

    .line 860
    iget-object v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->classifications_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 861
    invoke-interface {v0}, Lcom/google/protobuf/Internal$ProtobufList;->isModifiable()Z

    move-result v1

    if-nez v1, :cond_0

    .line 863
    invoke-static {v0}, Lcom/google/protobuf/GeneratedMessageLite;->mutableCopy(Lcom/google/protobuf/Internal$ProtobufList;)Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->classifications_:Lcom/google/protobuf/Internal$ProtobufList;

    :cond_0
    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;
    .locals 1

    .line 1427
    sget-object v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    return-object v0
.end method

.method public static newBuilder()Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult$Builder;
    .locals 1

    .line 1097
    sget-object v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;)Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult$Builder;
    .locals 1

    .line 1100
    sget-object v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;
    .locals 1

    .line 1073
    sget-object v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;
    .locals 1

    .line 1080
    sget-object v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;
    .locals 1

    .line 1036
    sget-object v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;
    .locals 1

    .line 1043
    sget-object v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;
    .locals 1

    .line 1085
    sget-object v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;
    .locals 1

    .line 1092
    sget-object v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;
    .locals 1

    .line 1060
    sget-object v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;
    .locals 1

    .line 1067
    sget-object v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;
    .locals 1

    .line 1023
    sget-object v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;
    .locals 1

    .line 1030
    sget-object v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;
    .locals 1

    .line 1048
    sget-object v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;
    .locals 1

    .line 1055
    sget-object v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;",
            ">;"
        }
    .end annotation

    .line 1433
    sget-object v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private removeClassifications(I)V
    .locals 1

    .line 942
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->ensureClassificationsIsMutable()V

    .line 943
    iget-object v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->classifications_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->remove(I)Ljava/lang/Object;

    return-void
.end method

.method private setClassifications(ILcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;)V
    .locals 1

    .line 877
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 878
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->ensureClassificationsIsMutable()V

    .line 879
    iget-object v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->classifications_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->set(ILjava/lang/Object;)Ljava/lang/Object;

    return-void
.end method

.method private setTimestampMs(J)V
    .locals 1

    .line 999
    iget v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->bitField0_:I

    or-int/lit8 v0, v0, 0x1

    iput v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->bitField0_:I

    .line 1000
    iput-wide p1, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->timestampMs_:J

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 1

    .line 1366
    sget-object p2, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p2, p1

    const/4 p2, 0x0

    packed-switch p1, :pswitch_data_0

    .line 1411
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    invoke-direct {p1}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw p1

    :pswitch_0
    return-object p2

    :pswitch_1
    const/4 p1, 0x1

    .line 1405
    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 1390
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 1392
    const-class p2, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    monitor-enter p2

    .line 1393
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_0

    .line 1395
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 1398
    sput-object p1, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 1400
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

    .line 1387
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    return-object p1

    .line 1374
    :pswitch_4
    const-string p1, "bitField0_"

    const-string p2, "classifications_"

    const-class p3, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    const-string v0, "timestampMs_"

    filled-new-array {p1, p2, p3, v0}, [Ljava/lang/Object;

    move-result-object p1

    .line 1380
    const-string p2, "\u0001\u0002\u0000\u0001\u0001\u0002\u0002\u0000\u0001\u0000\u0001\u001b\u0002\u1002\u0000"

    .line 1383
    sget-object p3, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    invoke-static {p3, p2, p1}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 1371
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult$Builder;

    invoke-direct {p1, p2}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult$Builder;-><init>(Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$1;)V

    return-object p1

    .line 1368
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;

    invoke-direct {p1}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;-><init>()V

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

.method public getClassifications(I)Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;
    .locals 1

    .line 845
    iget-object v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->classifications_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    return-object p1
.end method

.method public getClassificationsCount()I
    .locals 1

    .line 833
    iget-object v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->classifications_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    return v0
.end method

.method public getClassificationsList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;",
            ">;"
        }
    .end annotation

    .line 809
    iget-object v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->classifications_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public getClassificationsOrBuilder(I)Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationsOrBuilder;
    .locals 1

    .line 857
    iget-object v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->classifications_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationsOrBuilder;

    return-object p1
.end method

.method public getClassificationsOrBuilderList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "+",
            "Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationsOrBuilder;",
            ">;"
        }
    .end annotation

    .line 821
    iget-object v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->classifications_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public bridge synthetic getDefaultInstanceForType()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 788
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getTimestampMs()J
    .locals 2

    .line 982
    iget-wide v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->timestampMs_:J

    return-wide v0
.end method

.method public hasTimestampMs()Z
    .locals 2

    .line 964
    iget v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationResult;->bitField0_:I

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

    .line 788
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 788
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
