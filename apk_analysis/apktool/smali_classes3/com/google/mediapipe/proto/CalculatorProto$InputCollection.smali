.class public final Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "CalculatorProto.java"

# interfaces
.implements Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/proto/CalculatorProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "InputCollection"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$InputType;,
        Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;",
        "Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$Builder;",
        ">;",
        "Lcom/google/mediapipe/proto/CalculatorProto$InputCollectionOrBuilder;"
    }
.end annotation


# static fields
.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

.field public static final EXTERNAL_INPUT_NAME_FIELD_NUMBER:I = 0x3ea

.field public static final FILE_NAME_FIELD_NUMBER:I = 0x4

.field public static final INPUT_TYPE_FIELD_NUMBER:I = 0x3

.field public static final NAME_FIELD_NUMBER:I = 0x1

.field private static volatile PARSER:Lcom/google/protobuf/Parser; = null
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;",
            ">;"
        }
    .end annotation
.end field

.field public static final SIDE_PACKET_NAME_FIELD_NUMBER:I = 0x2


# instance fields
.field private externalInputName_:Lcom/google/protobuf/Internal$ProtobufList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Internal$ProtobufList<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field private fileName_:Ljava/lang/String;

.field private inputType_:I

.field private name_:Ljava/lang/String;

.field private sidePacketName_:Lcom/google/protobuf/Internal$ProtobufList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Internal$ProtobufList<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 2410
    new-instance v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-direct {v0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;-><init>()V

    .line 2413
    sput-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    .line 2414
    const-class v1, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 2

    .line 1093
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    .line 1094
    const-string v0, ""

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->name_:Ljava/lang/String;

    .line 1095
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v1

    iput-object v1, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->sidePacketName_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 1096
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v1

    iput-object v1, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->externalInputName_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 1097
    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->fileName_:Ljava/lang/String;

    return-void
.end method

.method static synthetic access$1100()Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;
    .locals 1

    .line 1088
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    return-object v0
.end method

.method static synthetic access$1200(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;Ljava/lang/String;)V
    .locals 0

    .line 1088
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->setName(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$1300(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;)V
    .locals 0

    .line 1088
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->clearName()V

    return-void
.end method

.method static synthetic access$1400(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 1088
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->setNameBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method static synthetic access$1500(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;ILjava/lang/String;)V
    .locals 0

    .line 1088
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->setSidePacketName(ILjava/lang/String;)V

    return-void
.end method

.method static synthetic access$1600(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;Ljava/lang/String;)V
    .locals 0

    .line 1088
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->addSidePacketName(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$1700(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;Ljava/lang/Iterable;)V
    .locals 0

    .line 1088
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->addAllSidePacketName(Ljava/lang/Iterable;)V

    return-void
.end method

.method static synthetic access$1800(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;)V
    .locals 0

    .line 1088
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->clearSidePacketName()V

    return-void
.end method

.method static synthetic access$1900(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 1088
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->addSidePacketNameBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method static synthetic access$2000(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;ILjava/lang/String;)V
    .locals 0

    .line 1088
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->setExternalInputName(ILjava/lang/String;)V

    return-void
.end method

.method static synthetic access$2100(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;Ljava/lang/String;)V
    .locals 0

    .line 1088
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->addExternalInputName(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$2200(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;Ljava/lang/Iterable;)V
    .locals 0

    .line 1088
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->addAllExternalInputName(Ljava/lang/Iterable;)V

    return-void
.end method

.method static synthetic access$2300(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;)V
    .locals 0

    .line 1088
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->clearExternalInputName()V

    return-void
.end method

.method static synthetic access$2400(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 1088
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->addExternalInputNameBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method static synthetic access$2500(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;I)V
    .locals 0

    .line 1088
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->setInputTypeValue(I)V

    return-void
.end method

.method static synthetic access$2600(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$InputType;)V
    .locals 0

    .line 1088
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->setInputType(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$InputType;)V

    return-void
.end method

.method static synthetic access$2700(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;)V
    .locals 0

    .line 1088
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->clearInputType()V

    return-void
.end method

.method static synthetic access$2800(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;Ljava/lang/String;)V
    .locals 0

    .line 1088
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->setFileName(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$2900(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;)V
    .locals 0

    .line 1088
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->clearFileName()V

    return-void
.end method

.method static synthetic access$3000(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 1088
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->setFileNameBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method private addAllExternalInputName(Ljava/lang/Iterable;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "Ljava/lang/String;",
            ">;)V"
        }
    .end annotation

    .line 1592
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->ensureExternalInputNameIsMutable()V

    .line 1593
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->externalInputName_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-static {p1, v0}, Lcom/google/protobuf/AbstractMessageLite;->addAll(Ljava/lang/Iterable;Ljava/util/List;)V

    return-void
.end method

.method private addAllSidePacketName(Ljava/lang/Iterable;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "Ljava/lang/String;",
            ">;)V"
        }
    .end annotation

    .line 1461
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->ensureSidePacketNameIsMutable()V

    .line 1462
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->sidePacketName_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-static {p1, v0}, Lcom/google/protobuf/AbstractMessageLite;->addAll(Ljava/lang/Iterable;Ljava/util/List;)V

    return-void
.end method

.method private addExternalInputName(Ljava/lang/String;)V
    .locals 1

    .line 1578
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 1579
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->ensureExternalInputNameIsMutable()V

    .line 1580
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->externalInputName_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private addExternalInputNameBytes(Lcom/google/protobuf/ByteString;)V
    .locals 1

    .line 1616
    invoke-static {p1}, Lcom/google/protobuf/AbstractMessageLite;->checkByteStringIsUtf8(Lcom/google/protobuf/ByteString;)V

    .line 1617
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->ensureExternalInputNameIsMutable()V

    .line 1618
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->externalInputName_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private addSidePacketName(Ljava/lang/String;)V
    .locals 1

    .line 1446
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 1447
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->ensureSidePacketNameIsMutable()V

    .line 1448
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->sidePacketName_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private addSidePacketNameBytes(Lcom/google/protobuf/ByteString;)V
    .locals 1

    .line 1487
    invoke-static {p1}, Lcom/google/protobuf/AbstractMessageLite;->checkByteStringIsUtf8(Lcom/google/protobuf/ByteString;)V

    .line 1488
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->ensureSidePacketNameIsMutable()V

    .line 1489
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->sidePacketName_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private clearExternalInputName()V
    .locals 1

    .line 1604
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->externalInputName_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method private clearFileName()V
    .locals 1

    .line 1746
    invoke-static {}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->getDefaultInstance()Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    move-result-object v0

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->getFileName()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->fileName_:Ljava/lang/String;

    return-void
.end method

.method private clearInputType()V
    .locals 1

    const/4 v0, 0x0

    .line 1685
    iput v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->inputType_:I

    return-void
.end method

.method private clearName()V
    .locals 1

    .line 1337
    invoke-static {}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->getDefaultInstance()Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    move-result-object v0

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->getName()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->name_:Ljava/lang/String;

    return-void
.end method

.method private clearSidePacketName()V
    .locals 1

    .line 1474
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->sidePacketName_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method private ensureExternalInputNameIsMutable()V
    .locals 2

    .line 1547
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->externalInputName_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 1548
    invoke-interface {v0}, Lcom/google/protobuf/Internal$ProtobufList;->isModifiable()Z

    move-result v1

    if-nez v1, :cond_0

    .line 1550
    invoke-static {v0}, Lcom/google/protobuf/GeneratedMessageLite;->mutableCopy(Lcom/google/protobuf/Internal$ProtobufList;)Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->externalInputName_:Lcom/google/protobuf/Internal$ProtobufList;

    :cond_0
    return-void
.end method

.method private ensureSidePacketNameIsMutable()V
    .locals 2

    .line 1413
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->sidePacketName_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 1414
    invoke-interface {v0}, Lcom/google/protobuf/Internal$ProtobufList;->isModifiable()Z

    move-result v1

    if-nez v1, :cond_0

    .line 1416
    invoke-static {v0}, Lcom/google/protobuf/GeneratedMessageLite;->mutableCopy(Lcom/google/protobuf/Internal$ProtobufList;)Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->sidePacketName_:Lcom/google/protobuf/Internal$ProtobufList;

    :cond_0
    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;
    .locals 1

    .line 2419
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    return-object v0
.end method

.method public static newBuilder()Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$Builder;
    .locals 1

    .line 1842
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;)Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$Builder;
    .locals 1

    .line 1845
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;
    .locals 1

    .line 1818
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;
    .locals 1

    .line 1825
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;
    .locals 1

    .line 1781
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;
    .locals 1

    .line 1788
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;
    .locals 1

    .line 1830
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;
    .locals 1

    .line 1837
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;
    .locals 1

    .line 1805
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;
    .locals 1

    .line 1812
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;
    .locals 1

    .line 1768
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;
    .locals 1

    .line 1775
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;
    .locals 1

    .line 1793
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;
    .locals 1

    .line 1800
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;",
            ">;"
        }
    .end annotation

    .line 2425
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private setExternalInputName(ILjava/lang/String;)V
    .locals 1

    .line 1564
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 1565
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->ensureExternalInputNameIsMutable()V

    .line 1566
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->externalInputName_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->set(ILjava/lang/Object;)Ljava/lang/Object;

    return-void
.end method

.method private setFileName(Ljava/lang/String;)V
    .locals 0

    .line 1731
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 1733
    iput-object p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->fileName_:Ljava/lang/String;

    return-void
.end method

.method private setFileNameBytes(Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 1760
    invoke-static {p1}, Lcom/google/protobuf/AbstractMessageLite;->checkByteStringIsUtf8(Lcom/google/protobuf/ByteString;)V

    .line 1761
    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->fileName_:Ljava/lang/String;

    return-void
.end method

.method private setInputType(Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$InputType;)V
    .locals 0

    .line 1672
    invoke-virtual {p1}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$InputType;->getNumber()I

    move-result p1

    iput p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->inputType_:I

    return-void
.end method

.method private setInputTypeValue(I)V
    .locals 0

    .line 1660
    iput p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->inputType_:I

    return-void
.end method

.method private setName(Ljava/lang/String;)V
    .locals 0

    .line 1324
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 1326
    iput-object p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->name_:Ljava/lang/String;

    return-void
.end method

.method private setNameBytes(Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 1349
    invoke-static {p1}, Lcom/google/protobuf/AbstractMessageLite;->checkByteStringIsUtf8(Lcom/google/protobuf/ByteString;)V

    .line 1350
    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->name_:Ljava/lang/String;

    return-void
.end method

.method private setSidePacketName(ILjava/lang/String;)V
    .locals 1

    .line 1431
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 1432
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->ensureSidePacketNameIsMutable()V

    .line 1433
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->sidePacketName_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->set(ILjava/lang/Object;)Ljava/lang/Object;

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 2

    .line 2357
    sget-object p2, Lcom/google/mediapipe/proto/CalculatorProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p2, p1

    const/4 p2, 0x0

    packed-switch p1, :pswitch_data_0

    .line 2403
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    invoke-direct {p1}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw p1

    :pswitch_0
    return-object p2

    :pswitch_1
    const/4 p1, 0x1

    .line 2397
    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 2382
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 2384
    const-class p2, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    monitor-enter p2

    .line 2385
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_0

    .line 2387
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 2390
    sput-object p1, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 2392
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

    .line 2379
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    return-object p1

    .line 2365
    :pswitch_4
    const-string p1, "name_"

    const-string p2, "sidePacketName_"

    const-string p3, "inputType_"

    const-string v0, "fileName_"

    const-string v1, "externalInputName_"

    filled-new-array {p1, p2, p3, v0, v1}, [Ljava/lang/Object;

    move-result-object p1

    .line 2372
    const-string p2, "\u0000\u0005\u0000\u0000\u0001\u03ea\u0005\u0000\u0002\u0000\u0001\u0208\u0002\u021a\u0003\u000c\u0004\u0208\u03ea\u021a"

    .line 2375
    sget-object p3, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-static {p3, p2, p1}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 2362
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$Builder;

    invoke-direct {p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$Builder;-><init>(Lcom/google/mediapipe/proto/CalculatorProto$1;)V

    return-object p1

    .line 2359
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;

    invoke-direct {p1}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;-><init>()V

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

    .line 1088
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getExternalInputName(I)Ljava/lang/String;
    .locals 1

    .line 1529
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->externalInputName_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/lang/String;

    return-object p1
.end method

.method public getExternalInputNameBytes(I)Lcom/google/protobuf/ByteString;
    .locals 1

    .line 1543
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->externalInputName_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 1544
    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/lang/String;

    .line 1543
    invoke-static {p1}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object p1

    return-object p1
.end method

.method public getExternalInputNameCount()I
    .locals 1

    .line 1516
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->externalInputName_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    return v0
.end method

.method public getExternalInputNameList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .line 1504
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->externalInputName_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public getFileName()Ljava/lang/String;
    .locals 1

    .line 1702
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->fileName_:Ljava/lang/String;

    return-object v0
.end method

.method public getFileNameBytes()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 1717
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->fileName_:Ljava/lang/String;

    invoke-static {v0}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object v0

    return-object v0
.end method

.method public getInputType()Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$InputType;
    .locals 1

    .line 1647
    iget v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->inputType_:I

    invoke-static {v0}, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$InputType;->forNumber(I)Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$InputType;

    move-result-object v0

    if-nez v0, :cond_0

    .line 1648
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$InputType;->UNRECOGNIZED:Lcom/google/mediapipe/proto/CalculatorProto$InputCollection$InputType;

    :cond_0
    return-object v0
.end method

.method public getInputTypeValue()I
    .locals 1

    .line 1634
    iget v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->inputType_:I

    return v0
.end method

.method public getName()Ljava/lang/String;
    .locals 1

    .line 1299
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->name_:Ljava/lang/String;

    return-object v0
.end method

.method public getNameBytes()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 1312
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->name_:Ljava/lang/String;

    invoke-static {v0}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object v0

    return-object v0
.end method

.method public getSidePacketName(I)Ljava/lang/String;
    .locals 1

    .line 1394
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->sidePacketName_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/lang/String;

    return-object p1
.end method

.method public getSidePacketNameBytes(I)Lcom/google/protobuf/ByteString;
    .locals 1

    .line 1409
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->sidePacketName_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 1410
    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/lang/String;

    .line 1409
    invoke-static {p1}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object p1

    return-object p1
.end method

.method public getSidePacketNameCount()I
    .locals 1

    .line 1380
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->sidePacketName_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    return v0
.end method

.method public getSidePacketNameList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .line 1367
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputCollection;->sidePacketName_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public bridge synthetic newBuilderForType()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 1088
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 1088
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
