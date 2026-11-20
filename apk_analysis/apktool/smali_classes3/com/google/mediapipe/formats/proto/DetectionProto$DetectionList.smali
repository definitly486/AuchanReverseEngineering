.class public final Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "DetectionProto.java"

# interfaces
.implements Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionListOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/formats/proto/DetectionProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "DetectionList"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;",
        "Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList$Builder;",
        ">;",
        "Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionListOrBuilder;"
    }
.end annotation


# static fields
.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;

.field public static final DETECTION_FIELD_NUMBER:I = 0x1

.field private static volatile PARSER:Lcom/google/protobuf/Parser;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;",
            ">;"
        }
    .end annotation
.end field


# instance fields
.field private detection_:Lcom/google/protobuf/Internal$ProtobufList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Internal$ProtobufList<",
            "Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;",
            ">;"
        }
    .end annotation
.end field

.field private memoizedIsInitialized:B


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 2911
    new-instance v0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;

    invoke-direct {v0}, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;-><init>()V

    .line 2914
    sput-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;

    .line 2915
    const-class v1, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    .line 2553
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    const/4 v0, 0x2

    .line 2855
    iput-byte v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->memoizedIsInitialized:B

    .line 2554
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->detection_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method static synthetic access$4500()Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;
    .locals 1

    .line 2548
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;

    return-object v0
.end method

.method static synthetic access$4600(Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;ILcom/google/mediapipe/formats/proto/DetectionProto$Detection;)V
    .locals 0

    .line 2548
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->setDetection(ILcom/google/mediapipe/formats/proto/DetectionProto$Detection;)V

    return-void
.end method

.method static synthetic access$4700(Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;)V
    .locals 0

    .line 2548
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->addDetection(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;)V

    return-void
.end method

.method static synthetic access$4800(Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;ILcom/google/mediapipe/formats/proto/DetectionProto$Detection;)V
    .locals 0

    .line 2548
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->addDetection(ILcom/google/mediapipe/formats/proto/DetectionProto$Detection;)V

    return-void
.end method

.method static synthetic access$4900(Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;Ljava/lang/Iterable;)V
    .locals 0

    .line 2548
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->addAllDetection(Ljava/lang/Iterable;)V

    return-void
.end method

.method static synthetic access$5000(Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;)V
    .locals 0

    .line 2548
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->clearDetection()V

    return-void
.end method

.method static synthetic access$5100(Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;I)V
    .locals 0

    .line 2548
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->removeDetection(I)V

    return-void
.end method

.method private addAllDetection(Ljava/lang/Iterable;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "+",
            "Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;",
            ">;)V"
        }
    .end annotation

    .line 2632
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->ensureDetectionIsMutable()V

    .line 2633
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->detection_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-static {p1, v0}, Lcom/google/protobuf/AbstractMessageLite;->addAll(Ljava/lang/Iterable;Ljava/util/List;)V

    return-void
.end method

.method private addDetection(ILcom/google/mediapipe/formats/proto/DetectionProto$Detection;)V
    .locals 1

    .line 2623
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 2624
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->ensureDetectionIsMutable()V

    .line 2625
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->detection_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->add(ILjava/lang/Object;)V

    return-void
.end method

.method private addDetection(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;)V
    .locals 1

    .line 2614
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 2615
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->ensureDetectionIsMutable()V

    .line 2616
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->detection_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private clearDetection()V
    .locals 1

    .line 2640
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->detection_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method private ensureDetectionIsMutable()V
    .locals 2

    .line 2594
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->detection_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 2595
    invoke-interface {v0}, Lcom/google/protobuf/Internal$ProtobufList;->isModifiable()Z

    move-result v1

    if-nez v1, :cond_0

    .line 2597
    invoke-static {v0}, Lcom/google/protobuf/GeneratedMessageLite;->mutableCopy(Lcom/google/protobuf/Internal$ProtobufList;)Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->detection_:Lcom/google/protobuf/Internal$ProtobufList;

    :cond_0
    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;
    .locals 1

    .line 2920
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;

    return-object v0
.end method

.method public static newBuilder()Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList$Builder;
    .locals 1

    .line 2727
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;)Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList$Builder;
    .locals 1

    .line 2730
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;
    .locals 1

    .line 2703
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;
    .locals 1

    .line 2710
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;
    .locals 1

    .line 2666
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;
    .locals 1

    .line 2673
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;
    .locals 1

    .line 2715
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;
    .locals 1

    .line 2722
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;
    .locals 1

    .line 2690
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;
    .locals 1

    .line 2697
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;
    .locals 1

    .line 2653
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;
    .locals 1

    .line 2660
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;
    .locals 1

    .line 2678
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;
    .locals 1

    .line 2685
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;",
            ">;"
        }
    .end annotation

    .line 2926
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private removeDetection(I)V
    .locals 1

    .line 2646
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->ensureDetectionIsMutable()V

    .line 2647
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->detection_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->remove(I)Ljava/lang/Object;

    return-void
.end method

.method private setDetection(ILcom/google/mediapipe/formats/proto/DetectionProto$Detection;)V
    .locals 1

    .line 2606
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 2607
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->ensureDetectionIsMutable()V

    .line 2608
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->detection_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->set(ILjava/lang/Object;)Ljava/lang/Object;

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 2861
    sget-object p3, Lcom/google/mediapipe/formats/proto/DetectionProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p3, p1

    const/4 p3, 0x0

    packed-switch p1, :pswitch_data_0

    .line 2904
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

    .line 2900
    iput-byte p1, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->memoizedIsInitialized:B

    return-object p3

    .line 2897
    :pswitch_1
    iget-byte p1, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->memoizedIsInitialized:B

    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 2882
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_2

    .line 2884
    const-class p2, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;

    monitor-enter p2

    .line 2885
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 2887
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 2890
    sput-object p1, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_1

    :catchall_0
    move-exception p1

    goto :goto_2

    .line 2892
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

    .line 2879
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;

    return-object p1

    .line 2869
    :pswitch_4
    const-string p1, "detection_"

    const-class p2, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    filled-new-array {p1, p2}, [Ljava/lang/Object;

    move-result-object p1

    .line 2873
    const-string p2, "\u0001\u0001\u0000\u0000\u0001\u0001\u0001\u0000\u0001\u0001\u0001\u041b"

    .line 2875
    sget-object p3, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;

    invoke-static {p3, p2, p1}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 2866
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList$Builder;

    invoke-direct {p1, p3}, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList$Builder;-><init>(Lcom/google/mediapipe/formats/proto/DetectionProto$1;)V

    return-object p1

    .line 2863
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;

    invoke-direct {p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;-><init>()V

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

    .line 2548
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getDetection(I)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;
    .locals 1

    .line 2584
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->detection_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    return-object p1
.end method

.method public getDetectionCount()I
    .locals 1

    .line 2577
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->detection_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    return v0
.end method

.method public getDetectionList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;",
            ">;"
        }
    .end annotation

    .line 2563
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->detection_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public getDetectionOrBuilder(I)Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionOrBuilder;
    .locals 1

    .line 2591
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->detection_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionOrBuilder;

    return-object p1
.end method

.method public getDetectionOrBuilderList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "+",
            "Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionOrBuilder;",
            ">;"
        }
    .end annotation

    .line 2570
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionList;->detection_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public bridge synthetic newBuilderForType()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 2548
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 2548
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
