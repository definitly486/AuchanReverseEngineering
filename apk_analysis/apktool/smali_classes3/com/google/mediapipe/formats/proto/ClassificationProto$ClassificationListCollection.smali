.class public final Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "ClassificationProto.java"

# interfaces
.implements Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollectionOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/formats/proto/ClassificationProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "ClassificationListCollection"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;",
        "Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection$Builder;",
        ">;",
        "Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollectionOrBuilder;"
    }
.end annotation


# static fields
.field public static final CLASSIFICATION_LIST_FIELD_NUMBER:I = 0x1

.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;

.field private static volatile PARSER:Lcom/google/protobuf/Parser;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;",
            ">;"
        }
    .end annotation
.end field


# instance fields
.field private classificationList_:Lcom/google/protobuf/Internal$ProtobufList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Internal$ProtobufList<",
            "Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;",
            ">;"
        }
    .end annotation
.end field


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 1615
    new-instance v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;

    invoke-direct {v0}, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;-><init>()V

    .line 1618
    sput-object v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;

    .line 1619
    const-class v1, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    .line 1259
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    .line 1260
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->classificationList_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method static synthetic access$2000()Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;
    .locals 1

    .line 1254
    sget-object v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;

    return-object v0
.end method

.method static synthetic access$2100(Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;ILcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;)V
    .locals 0

    .line 1254
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->setClassificationList(ILcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;)V

    return-void
.end method

.method static synthetic access$2200(Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;)V
    .locals 0

    .line 1254
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->addClassificationList(Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;)V

    return-void
.end method

.method static synthetic access$2300(Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;ILcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;)V
    .locals 0

    .line 1254
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->addClassificationList(ILcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;)V

    return-void
.end method

.method static synthetic access$2400(Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;Ljava/lang/Iterable;)V
    .locals 0

    .line 1254
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->addAllClassificationList(Ljava/lang/Iterable;)V

    return-void
.end method

.method static synthetic access$2500(Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;)V
    .locals 0

    .line 1254
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->clearClassificationList()V

    return-void
.end method

.method static synthetic access$2600(Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;I)V
    .locals 0

    .line 1254
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->removeClassificationList(I)V

    return-void
.end method

.method private addAllClassificationList(Ljava/lang/Iterable;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "+",
            "Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;",
            ">;)V"
        }
    .end annotation

    .line 1338
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->ensureClassificationListIsMutable()V

    .line 1339
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->classificationList_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-static {p1, v0}, Lcom/google/protobuf/AbstractMessageLite;->addAll(Ljava/lang/Iterable;Ljava/util/List;)V

    return-void
.end method

.method private addClassificationList(ILcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;)V
    .locals 1

    .line 1329
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 1330
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->ensureClassificationListIsMutable()V

    .line 1331
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->classificationList_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->add(ILjava/lang/Object;)V

    return-void
.end method

.method private addClassificationList(Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;)V
    .locals 1

    .line 1320
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 1321
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->ensureClassificationListIsMutable()V

    .line 1322
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->classificationList_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private clearClassificationList()V
    .locals 1

    .line 1346
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->classificationList_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method private ensureClassificationListIsMutable()V
    .locals 2

    .line 1300
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->classificationList_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 1301
    invoke-interface {v0}, Lcom/google/protobuf/Internal$ProtobufList;->isModifiable()Z

    move-result v1

    if-nez v1, :cond_0

    .line 1303
    invoke-static {v0}, Lcom/google/protobuf/GeneratedMessageLite;->mutableCopy(Lcom/google/protobuf/Internal$ProtobufList;)Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->classificationList_:Lcom/google/protobuf/Internal$ProtobufList;

    :cond_0
    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;
    .locals 1

    .line 1624
    sget-object v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;

    return-object v0
.end method

.method public static newBuilder()Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection$Builder;
    .locals 1

    .line 1433
    sget-object v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;)Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection$Builder;
    .locals 1

    .line 1436
    sget-object v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;
    .locals 1

    .line 1409
    sget-object v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;
    .locals 1

    .line 1416
    sget-object v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;
    .locals 1

    .line 1372
    sget-object v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;
    .locals 1

    .line 1379
    sget-object v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;
    .locals 1

    .line 1421
    sget-object v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;
    .locals 1

    .line 1428
    sget-object v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;
    .locals 1

    .line 1396
    sget-object v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;
    .locals 1

    .line 1403
    sget-object v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;
    .locals 1

    .line 1359
    sget-object v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;
    .locals 1

    .line 1366
    sget-object v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;
    .locals 1

    .line 1384
    sget-object v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;
    .locals 1

    .line 1391
    sget-object v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;",
            ">;"
        }
    .end annotation

    .line 1630
    sget-object v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private removeClassificationList(I)V
    .locals 1

    .line 1352
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->ensureClassificationListIsMutable()V

    .line 1353
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->classificationList_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->remove(I)Ljava/lang/Object;

    return-void
.end method

.method private setClassificationList(ILcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;)V
    .locals 1

    .line 1312
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 1313
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->ensureClassificationListIsMutable()V

    .line 1314
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->classificationList_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->set(ILjava/lang/Object;)Ljava/lang/Object;

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 1566
    sget-object p2, Lcom/google/mediapipe/formats/proto/ClassificationProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p2, p1

    const/4 p2, 0x0

    packed-switch p1, :pswitch_data_0

    .line 1608
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    invoke-direct {p1}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw p1

    :pswitch_0
    return-object p2

    :pswitch_1
    const/4 p1, 0x1

    .line 1602
    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 1587
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 1589
    const-class p2, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;

    monitor-enter p2

    .line 1590
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_0

    .line 1592
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 1595
    sput-object p1, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 1597
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

    .line 1584
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;

    return-object p1

    .line 1574
    :pswitch_4
    const-string p1, "classificationList_"

    const-class p2, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    filled-new-array {p1, p2}, [Ljava/lang/Object;

    move-result-object p1

    .line 1578
    const-string p2, "\u0001\u0001\u0000\u0000\u0001\u0001\u0001\u0000\u0001\u0000\u0001\u001b"

    .line 1580
    sget-object p3, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;

    invoke-static {p3, p2, p1}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 1571
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection$Builder;

    invoke-direct {p1, p2}, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection$Builder;-><init>(Lcom/google/mediapipe/formats/proto/ClassificationProto$1;)V

    return-object p1

    .line 1568
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;

    invoke-direct {p1}, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;-><init>()V

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

.method public getClassificationList(I)Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;
    .locals 1

    .line 1290
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->classificationList_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    return-object p1
.end method

.method public getClassificationListCount()I
    .locals 1

    .line 1283
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->classificationList_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    return v0
.end method

.method public getClassificationListList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;",
            ">;"
        }
    .end annotation

    .line 1269
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->classificationList_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public getClassificationListOrBuilder(I)Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListOrBuilder;
    .locals 1

    .line 1297
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->classificationList_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListOrBuilder;

    return-object p1
.end method

.method public getClassificationListOrBuilderList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "+",
            "Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListOrBuilder;",
            ">;"
        }
    .end annotation

    .line 1276
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListCollection;->classificationList_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public bridge synthetic getDefaultInstanceForType()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 1254
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic newBuilderForType()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 1254
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 1254
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
