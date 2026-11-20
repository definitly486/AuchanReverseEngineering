.class public final Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "CalculatorProto.java"

# interfaces
.implements Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSetOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/proto/CalculatorProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "InputCollectionSet"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;",
        "Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet$Builder;",
        ">;",
        "Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSetOrBuilder;"
    }
.end annotation


# static fields
.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;

.field public static final INPUT_COLLECTION_FIELD_NUMBER:I = 0x1

.field private static volatile PARSER:Lcom/google/protobuf/Parser;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;",
            ">;"
        }
    .end annotation
.end field


# instance fields
.field private inputCollection_:Lcom/google/protobuf/Internal$ProtobufList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Internal$ProtobufList<",
            "Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;",
            ">;"
        }
    .end annotation
.end field


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 2815
    new-instance v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;

    invoke-direct {v0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;-><init>()V

    .line 2818
    sput-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;

    .line 2819
    const-class v1, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    .line 2459
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    .line 2460
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->inputCollection_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method static synthetic access$3200()Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;
    .locals 1

    .line 2454
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;

    return-object v0
.end method

.method static synthetic access$3300(Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;ILcom/google/mediapipe/proto/CalculatorProto$InputCollection;)V
    .locals 0

    .line 2454
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->setInputCollection(ILcom/google/mediapipe/proto/CalculatorProto$InputCollection;)V

    return-void
.end method

.method static synthetic access$3400(Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;)V
    .locals 0

    .line 2454
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->addInputCollection(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;)V

    return-void
.end method

.method static synthetic access$3500(Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;ILcom/google/mediapipe/proto/CalculatorProto$InputCollection;)V
    .locals 0

    .line 2454
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->addInputCollection(ILcom/google/mediapipe/proto/CalculatorProto$InputCollection;)V

    return-void
.end method

.method static synthetic access$3600(Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;Ljava/lang/Iterable;)V
    .locals 0

    .line 2454
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->addAllInputCollection(Ljava/lang/Iterable;)V

    return-void
.end method

.method static synthetic access$3700(Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;)V
    .locals 0

    .line 2454
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->clearInputCollection()V

    return-void
.end method

.method static synthetic access$3800(Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;I)V
    .locals 0

    .line 2454
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->removeInputCollection(I)V

    return-void
.end method

.method private addAllInputCollection(Ljava/lang/Iterable;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "+",
            "Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;",
            ">;)V"
        }
    .end annotation

    .line 2538
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->ensureInputCollectionIsMutable()V

    .line 2539
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->inputCollection_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-static {p1, v0}, Lcom/google/protobuf/AbstractMessageLite;->addAll(Ljava/lang/Iterable;Ljava/util/List;)V

    return-void
.end method

.method private addInputCollection(ILcom/google/mediapipe/proto/CalculatorProto$InputCollection;)V
    .locals 1

    .line 2529
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 2530
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->ensureInputCollectionIsMutable()V

    .line 2531
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->inputCollection_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->add(ILjava/lang/Object;)V

    return-void
.end method

.method private addInputCollection(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;)V
    .locals 1

    .line 2520
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 2521
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->ensureInputCollectionIsMutable()V

    .line 2522
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->inputCollection_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private clearInputCollection()V
    .locals 1

    .line 2546
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->inputCollection_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method private ensureInputCollectionIsMutable()V
    .locals 2

    .line 2500
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->inputCollection_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 2501
    invoke-interface {v0}, Lcom/google/protobuf/Internal$ProtobufList;->isModifiable()Z

    move-result v1

    if-nez v1, :cond_0

    .line 2503
    invoke-static {v0}, Lcom/google/protobuf/GeneratedMessageLite;->mutableCopy(Lcom/google/protobuf/Internal$ProtobufList;)Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->inputCollection_:Lcom/google/protobuf/Internal$ProtobufList;

    :cond_0
    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;
    .locals 1

    .line 2824
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;

    return-object v0
.end method

.method public static newBuilder()Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet$Builder;
    .locals 1

    .line 2633
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;)Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet$Builder;
    .locals 1

    .line 2636
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;
    .locals 1

    .line 2609
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;
    .locals 1

    .line 2616
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;
    .locals 1

    .line 2572
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;
    .locals 1

    .line 2579
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;
    .locals 1

    .line 2621
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;
    .locals 1

    .line 2628
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;
    .locals 1

    .line 2596
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;
    .locals 1

    .line 2603
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;
    .locals 1

    .line 2559
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;
    .locals 1

    .line 2566
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;
    .locals 1

    .line 2584
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;
    .locals 1

    .line 2591
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;",
            ">;"
        }
    .end annotation

    .line 2830
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private removeInputCollection(I)V
    .locals 1

    .line 2552
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->ensureInputCollectionIsMutable()V

    .line 2553
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->inputCollection_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->remove(I)Ljava/lang/Object;

    return-void
.end method

.method private setInputCollection(ILcom/google/mediapipe/proto/CalculatorProto$InputCollection;)V
    .locals 1

    .line 2512
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 2513
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->ensureInputCollectionIsMutable()V

    .line 2514
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->inputCollection_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->set(ILjava/lang/Object;)Ljava/lang/Object;

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 2766
    sget-object p2, Lcom/google/mediapipe/proto/CalculatorProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p2, p1

    const/4 p2, 0x0

    packed-switch p1, :pswitch_data_0

    .line 2808
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    invoke-direct {p1}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw p1

    :pswitch_0
    return-object p2

    :pswitch_1
    const/4 p1, 0x1

    .line 2802
    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 2787
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 2789
    const-class p2, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;

    monitor-enter p2

    .line 2790
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_0

    .line 2792
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 2795
    sput-object p1, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 2797
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

    .line 2784
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;

    return-object p1

    .line 2774
    :pswitch_4
    const-string p1, "inputCollection_"

    const-class p2, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    filled-new-array {p1, p2}, [Ljava/lang/Object;

    move-result-object p1

    .line 2778
    const-string p2, "\u0000\u0001\u0000\u0000\u0001\u0001\u0001\u0000\u0001\u0000\u0001\u001b"

    .line 2780
    sget-object p3, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;

    invoke-static {p3, p2, p1}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 2771
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet$Builder;

    invoke-direct {p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet$Builder;-><init>(Lcom/google/mediapipe/proto/CalculatorProto$1;)V

    return-object p1

    .line 2768
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;

    invoke-direct {p1}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;-><init>()V

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

    .line 2454
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getInputCollection(I)Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;
    .locals 1

    .line 2490
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->inputCollection_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    return-object p1
.end method

.method public getInputCollectionCount()I
    .locals 1

    .line 2483
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->inputCollection_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    return v0
.end method

.method public getInputCollectionList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;",
            ">;"
        }
    .end annotation

    .line 2469
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->inputCollection_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public getInputCollectionOrBuilder(I)Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionOrBuilder;
    .locals 1

    .line 2497
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->inputCollection_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionOrBuilder;

    return-object p1
.end method

.method public getInputCollectionOrBuilderList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "+",
            "Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionOrBuilder;",
            ">;"
        }
    .end annotation

    .line 2476
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionSet;->inputCollection_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public bridge synthetic newBuilderForType()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 2454
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 2454
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
