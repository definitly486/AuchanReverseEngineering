.class public final Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "RasterizationProto.java"

# interfaces
.implements Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$RasterizationOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Rasterization"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;,
        Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$IntervalOrBuilder;,
        Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;",
        "Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Builder;",
        ">;",
        "Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$RasterizationOrBuilder;"
    }
.end annotation


# static fields
.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;

.field public static final INTERVAL_FIELD_NUMBER:I = 0x1

.field private static volatile PARSER:Lcom/google/protobuf/Parser;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;",
            ">;"
        }
    .end annotation
.end field


# instance fields
.field private interval_:Lcom/google/protobuf/Internal$ProtobufList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Internal$ProtobufList<",
            "Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;",
            ">;"
        }
    .end annotation
.end field

.field private memoizedIsInitialized:B


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 1024
    new-instance v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;

    invoke-direct {v0}, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;-><init>()V

    .line 1027
    sput-object v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;

    .line 1028
    const-class v1, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    .line 67
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    const/4 v0, 0x2

    .line 968
    iput-byte v0, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->memoizedIsInitialized:B

    .line 68
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->interval_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method static synthetic access$1000(Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;)V
    .locals 0

    .line 62
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->addInterval(Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;)V

    return-void
.end method

.method static synthetic access$1100(Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;ILcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;)V
    .locals 0

    .line 62
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->addInterval(ILcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;)V

    return-void
.end method

.method static synthetic access$1200(Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;Ljava/lang/Iterable;)V
    .locals 0

    .line 62
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->addAllInterval(Ljava/lang/Iterable;)V

    return-void
.end method

.method static synthetic access$1300(Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;)V
    .locals 0

    .line 62
    invoke-direct {p0}, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->clearInterval()V

    return-void
.end method

.method static synthetic access$1400(Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;I)V
    .locals 0

    .line 62
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->removeInterval(I)V

    return-void
.end method

.method static synthetic access$800()Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;
    .locals 1

    .line 62
    sget-object v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;

    return-object v0
.end method

.method static synthetic access$900(Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;ILcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;)V
    .locals 0

    .line 62
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->setInterval(ILcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;)V

    return-void
.end method

.method private addAllInterval(Ljava/lang/Iterable;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "+",
            "Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;",
            ">;)V"
        }
    .end annotation

    .line 644
    invoke-direct {p0}, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->ensureIntervalIsMutable()V

    .line 645
    iget-object v0, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->interval_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-static {p1, v0}, Lcom/google/protobuf/AbstractMessageLite;->addAll(Ljava/lang/Iterable;Ljava/util/List;)V

    return-void
.end method

.method private addInterval(ILcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;)V
    .locals 1

    .line 628
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 629
    invoke-direct {p0}, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->ensureIntervalIsMutable()V

    .line 630
    iget-object v0, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->interval_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->add(ILjava/lang/Object;)V

    return-void
.end method

.method private addInterval(Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;)V
    .locals 1

    .line 612
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 613
    invoke-direct {p0}, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->ensureIntervalIsMutable()V

    .line 614
    iget-object v0, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->interval_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private clearInterval()V
    .locals 1

    .line 659
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->interval_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method private ensureIntervalIsMutable()V
    .locals 2

    .line 578
    iget-object v0, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->interval_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 579
    invoke-interface {v0}, Lcom/google/protobuf/Internal$ProtobufList;->isModifiable()Z

    move-result v1

    if-nez v1, :cond_0

    .line 581
    invoke-static {v0}, Lcom/google/protobuf/GeneratedMessageLite;->mutableCopy(Lcom/google/protobuf/Internal$ProtobufList;)Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->interval_:Lcom/google/protobuf/Internal$ProtobufList;

    :cond_0
    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;
    .locals 1

    .line 1033
    sget-object v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;

    return-object v0
.end method

.method public static newBuilder()Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Builder;
    .locals 1

    .line 753
    sget-object v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;)Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Builder;
    .locals 1

    .line 756
    sget-object v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;
    .locals 1

    .line 729
    sget-object v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;
    .locals 1

    .line 736
    sget-object v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;
    .locals 1

    .line 692
    sget-object v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;
    .locals 1

    .line 699
    sget-object v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;
    .locals 1

    .line 741
    sget-object v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;
    .locals 1

    .line 748
    sget-object v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;
    .locals 1

    .line 716
    sget-object v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;
    .locals 1

    .line 723
    sget-object v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;
    .locals 1

    .line 679
    sget-object v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;
    .locals 1

    .line 686
    sget-object v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;
    .locals 1

    .line 704
    sget-object v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;
    .locals 1

    .line 711
    sget-object v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;",
            ">;"
        }
    .end annotation

    .line 1039
    sget-object v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private removeInterval(I)V
    .locals 1

    .line 672
    invoke-direct {p0}, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->ensureIntervalIsMutable()V

    .line 673
    iget-object v0, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->interval_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->remove(I)Ljava/lang/Object;

    return-void
.end method

.method private setInterval(ILcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;)V
    .locals 1

    .line 597
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 598
    invoke-direct {p0}, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->ensureIntervalIsMutable()V

    .line 599
    iget-object v0, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->interval_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->set(ILjava/lang/Object;)Ljava/lang/Object;

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 974
    sget-object p3, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p3, p1

    const/4 p3, 0x0

    packed-switch p1, :pswitch_data_0

    .line 1017
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

    .line 1013
    iput-byte p1, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->memoizedIsInitialized:B

    return-object p3

    .line 1010
    :pswitch_1
    iget-byte p1, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->memoizedIsInitialized:B

    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 995
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_2

    .line 997
    const-class p2, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;

    monitor-enter p2

    .line 998
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 1000
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 1003
    sput-object p1, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_1

    :catchall_0
    move-exception p1

    goto :goto_2

    .line 1005
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

    .line 992
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;

    return-object p1

    .line 982
    :pswitch_4
    const-string p1, "interval_"

    const-class p2, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

    filled-new-array {p1, p2}, [Ljava/lang/Object;

    move-result-object p1

    .line 986
    const-string p2, "\u0001\u0001\u0000\u0000\u0001\u0001\u0001\u0000\u0001\u0001\u0001\u041b"

    .line 988
    sget-object p3, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;

    invoke-static {p3, p2, p1}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 979
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Builder;

    invoke-direct {p1, p3}, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Builder;-><init>(Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$1;)V

    return-object p1

    .line 976
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;

    invoke-direct {p1}, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;-><init>()V

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

    .line 62
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getInterval(I)Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;
    .locals 1

    .line 561
    iget-object v0, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->interval_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

    return-object p1
.end method

.method public getIntervalCount()I
    .locals 1

    .line 547
    iget-object v0, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->interval_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    return v0
.end method

.method public getIntervalList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;",
            ">;"
        }
    .end annotation

    .line 519
    iget-object v0, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->interval_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public getIntervalOrBuilder(I)Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$IntervalOrBuilder;
    .locals 1

    .line 575
    iget-object v0, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->interval_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$IntervalOrBuilder;

    return-object p1
.end method

.method public getIntervalOrBuilderList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "+",
            "Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$IntervalOrBuilder;",
            ">;"
        }
    .end annotation

    .line 533
    iget-object v0, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;->interval_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public bridge synthetic newBuilderForType()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 62
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 62
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
