.class public final Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "LandmarkProto.java"

# interfaces
.implements Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollectionOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/formats/proto/LandmarkProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "LandmarkListCollection"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;",
        "Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection$Builder;",
        ">;",
        "Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollectionOrBuilder;"
    }
.end annotation


# static fields
.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;

.field public static final LANDMARK_LIST_FIELD_NUMBER:I = 0x1

.field private static volatile PARSER:Lcom/google/protobuf/Parser;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;",
            ">;"
        }
    .end annotation
.end field


# instance fields
.field private landmarkList_:Lcom/google/protobuf/Internal$ProtobufList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Internal$ProtobufList<",
            "Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;",
            ">;"
        }
    .end annotation
.end field


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 1573
    new-instance v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;

    invoke-direct {v0}, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;-><init>()V

    .line 1576
    sput-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;

    .line 1577
    const-class v1, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    .line 1217
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    .line 1218
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->landmarkList_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method static synthetic access$2000()Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;
    .locals 1

    .line 1212
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;

    return-object v0
.end method

.method static synthetic access$2100(Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;ILcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;)V
    .locals 0

    .line 1212
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->setLandmarkList(ILcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;)V

    return-void
.end method

.method static synthetic access$2200(Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;)V
    .locals 0

    .line 1212
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->addLandmarkList(Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;)V

    return-void
.end method

.method static synthetic access$2300(Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;ILcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;)V
    .locals 0

    .line 1212
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->addLandmarkList(ILcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;)V

    return-void
.end method

.method static synthetic access$2400(Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;Ljava/lang/Iterable;)V
    .locals 0

    .line 1212
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->addAllLandmarkList(Ljava/lang/Iterable;)V

    return-void
.end method

.method static synthetic access$2500(Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;)V
    .locals 0

    .line 1212
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->clearLandmarkList()V

    return-void
.end method

.method static synthetic access$2600(Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;I)V
    .locals 0

    .line 1212
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->removeLandmarkList(I)V

    return-void
.end method

.method private addAllLandmarkList(Ljava/lang/Iterable;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "+",
            "Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;",
            ">;)V"
        }
    .end annotation

    .line 1296
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->ensureLandmarkListIsMutable()V

    .line 1297
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->landmarkList_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-static {p1, v0}, Lcom/google/protobuf/AbstractMessageLite;->addAll(Ljava/lang/Iterable;Ljava/util/List;)V

    return-void
.end method

.method private addLandmarkList(ILcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;)V
    .locals 1

    .line 1287
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 1288
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->ensureLandmarkListIsMutable()V

    .line 1289
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->landmarkList_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->add(ILjava/lang/Object;)V

    return-void
.end method

.method private addLandmarkList(Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;)V
    .locals 1

    .line 1278
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 1279
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->ensureLandmarkListIsMutable()V

    .line 1280
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->landmarkList_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private clearLandmarkList()V
    .locals 1

    .line 1304
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->landmarkList_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method private ensureLandmarkListIsMutable()V
    .locals 2

    .line 1258
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->landmarkList_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 1259
    invoke-interface {v0}, Lcom/google/protobuf/Internal$ProtobufList;->isModifiable()Z

    move-result v1

    if-nez v1, :cond_0

    .line 1261
    invoke-static {v0}, Lcom/google/protobuf/GeneratedMessageLite;->mutableCopy(Lcom/google/protobuf/Internal$ProtobufList;)Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->landmarkList_:Lcom/google/protobuf/Internal$ProtobufList;

    :cond_0
    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;
    .locals 1

    .line 1582
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;

    return-object v0
.end method

.method public static newBuilder()Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection$Builder;
    .locals 1

    .line 1391
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;)Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection$Builder;
    .locals 1

    .line 1394
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;
    .locals 1

    .line 1367
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;
    .locals 1

    .line 1374
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;
    .locals 1

    .line 1330
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;
    .locals 1

    .line 1337
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;
    .locals 1

    .line 1379
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;
    .locals 1

    .line 1386
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;
    .locals 1

    .line 1354
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;
    .locals 1

    .line 1361
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;
    .locals 1

    .line 1317
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;
    .locals 1

    .line 1324
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;
    .locals 1

    .line 1342
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;
    .locals 1

    .line 1349
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;",
            ">;"
        }
    .end annotation

    .line 1588
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private removeLandmarkList(I)V
    .locals 1

    .line 1310
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->ensureLandmarkListIsMutable()V

    .line 1311
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->landmarkList_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->remove(I)Ljava/lang/Object;

    return-void
.end method

.method private setLandmarkList(ILcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;)V
    .locals 1

    .line 1270
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 1271
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->ensureLandmarkListIsMutable()V

    .line 1272
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->landmarkList_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->set(ILjava/lang/Object;)Ljava/lang/Object;

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 1524
    sget-object p2, Lcom/google/mediapipe/formats/proto/LandmarkProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p2, p1

    const/4 p2, 0x0

    packed-switch p1, :pswitch_data_0

    .line 1566
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    invoke-direct {p1}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw p1

    :pswitch_0
    return-object p2

    :pswitch_1
    const/4 p1, 0x1

    .line 1560
    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 1545
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 1547
    const-class p2, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;

    monitor-enter p2

    .line 1548
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_0

    .line 1550
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 1553
    sput-object p1, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 1555
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

    .line 1542
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;

    return-object p1

    .line 1532
    :pswitch_4
    const-string p1, "landmarkList_"

    const-class p2, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    filled-new-array {p1, p2}, [Ljava/lang/Object;

    move-result-object p1

    .line 1536
    const-string p2, "\u0001\u0001\u0000\u0000\u0001\u0001\u0001\u0000\u0001\u0000\u0001\u001b"

    .line 1538
    sget-object p3, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;

    invoke-static {p3, p2, p1}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 1529
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection$Builder;

    invoke-direct {p1, p2}, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection$Builder;-><init>(Lcom/google/mediapipe/formats/proto/LandmarkProto$1;)V

    return-object p1

    .line 1526
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;

    invoke-direct {p1}, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;-><init>()V

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

    .line 1212
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getLandmarkList(I)Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;
    .locals 1

    .line 1248
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->landmarkList_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    return-object p1
.end method

.method public getLandmarkListCount()I
    .locals 1

    .line 1241
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->landmarkList_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    return v0
.end method

.method public getLandmarkListList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;",
            ">;"
        }
    .end annotation

    .line 1227
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->landmarkList_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public getLandmarkListOrBuilder(I)Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListOrBuilder;
    .locals 1

    .line 1255
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->landmarkList_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListOrBuilder;

    return-object p1
.end method

.method public getLandmarkListOrBuilderList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "+",
            "Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListOrBuilder;",
            ">;"
        }
    .end annotation

    .line 1234
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListCollection;->landmarkList_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public bridge synthetic newBuilderForType()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 1212
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 1212
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
