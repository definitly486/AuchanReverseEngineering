.class public final Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "ClassificationProto.java"

# interfaces
.implements Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/formats/proto/ClassificationProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "ClassificationList"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;",
        "Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList$Builder;",
        ">;",
        "Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationListOrBuilder;"
    }
.end annotation


# static fields
.field public static final CLASSIFICATION_FIELD_NUMBER:I = 0x1

.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

.field private static volatile PARSER:Lcom/google/protobuf/Parser;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;",
            ">;"
        }
    .end annotation
.end field


# instance fields
.field private classification_:Lcom/google/protobuf/Internal$ProtobufList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Internal$ProtobufList<",
            "Lcom/google/mediapipe/formats/proto/ClassificationProto$Classification;",
            ">;"
        }
    .end annotation
.end field


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 1210
    new-instance v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    invoke-direct {v0}, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;-><init>()V

    .line 1213
    sput-object v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    .line 1214
    const-class v1, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    .line 854
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    .line 855
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->classification_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method static synthetic access$1200()Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;
    .locals 1

    .line 849
    sget-object v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    return-object v0
.end method

.method static synthetic access$1300(Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;ILcom/google/mediapipe/formats/proto/ClassificationProto$Classification;)V
    .locals 0

    .line 849
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->setClassification(ILcom/google/mediapipe/formats/proto/ClassificationProto$Classification;)V

    return-void
.end method

.method static synthetic access$1400(Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;Lcom/google/mediapipe/formats/proto/ClassificationProto$Classification;)V
    .locals 0

    .line 849
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->addClassification(Lcom/google/mediapipe/formats/proto/ClassificationProto$Classification;)V

    return-void
.end method

.method static synthetic access$1500(Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;ILcom/google/mediapipe/formats/proto/ClassificationProto$Classification;)V
    .locals 0

    .line 849
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->addClassification(ILcom/google/mediapipe/formats/proto/ClassificationProto$Classification;)V

    return-void
.end method

.method static synthetic access$1600(Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;Ljava/lang/Iterable;)V
    .locals 0

    .line 849
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->addAllClassification(Ljava/lang/Iterable;)V

    return-void
.end method

.method static synthetic access$1700(Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;)V
    .locals 0

    .line 849
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->clearClassification()V

    return-void
.end method

.method static synthetic access$1800(Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;I)V
    .locals 0

    .line 849
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->removeClassification(I)V

    return-void
.end method

.method private addAllClassification(Ljava/lang/Iterable;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "+",
            "Lcom/google/mediapipe/formats/proto/ClassificationProto$Classification;",
            ">;)V"
        }
    .end annotation

    .line 933
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->ensureClassificationIsMutable()V

    .line 934
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->classification_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-static {p1, v0}, Lcom/google/protobuf/AbstractMessageLite;->addAll(Ljava/lang/Iterable;Ljava/util/List;)V

    return-void
.end method

.method private addClassification(ILcom/google/mediapipe/formats/proto/ClassificationProto$Classification;)V
    .locals 1

    .line 924
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 925
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->ensureClassificationIsMutable()V

    .line 926
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->classification_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->add(ILjava/lang/Object;)V

    return-void
.end method

.method private addClassification(Lcom/google/mediapipe/formats/proto/ClassificationProto$Classification;)V
    .locals 1

    .line 915
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 916
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->ensureClassificationIsMutable()V

    .line 917
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->classification_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private clearClassification()V
    .locals 1

    .line 941
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->classification_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method private ensureClassificationIsMutable()V
    .locals 2

    .line 895
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->classification_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 896
    invoke-interface {v0}, Lcom/google/protobuf/Internal$ProtobufList;->isModifiable()Z

    move-result v1

    if-nez v1, :cond_0

    .line 898
    invoke-static {v0}, Lcom/google/protobuf/GeneratedMessageLite;->mutableCopy(Lcom/google/protobuf/Internal$ProtobufList;)Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->classification_:Lcom/google/protobuf/Internal$ProtobufList;

    :cond_0
    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;
    .locals 1

    .line 1219
    sget-object v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    return-object v0
.end method

.method public static newBuilder()Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList$Builder;
    .locals 1

    .line 1028
    sget-object v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;)Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList$Builder;
    .locals 1

    .line 1031
    sget-object v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;
    .locals 1

    .line 1004
    sget-object v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;
    .locals 1

    .line 1011
    sget-object v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;
    .locals 1

    .line 967
    sget-object v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;
    .locals 1

    .line 974
    sget-object v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;
    .locals 1

    .line 1016
    sget-object v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;
    .locals 1

    .line 1023
    sget-object v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;
    .locals 1

    .line 991
    sget-object v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;
    .locals 1

    .line 998
    sget-object v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;
    .locals 1

    .line 954
    sget-object v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;
    .locals 1

    .line 961
    sget-object v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;
    .locals 1

    .line 979
    sget-object v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;
    .locals 1

    .line 986
    sget-object v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;",
            ">;"
        }
    .end annotation

    .line 1225
    sget-object v0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private removeClassification(I)V
    .locals 1

    .line 947
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->ensureClassificationIsMutable()V

    .line 948
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->classification_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->remove(I)Ljava/lang/Object;

    return-void
.end method

.method private setClassification(ILcom/google/mediapipe/formats/proto/ClassificationProto$Classification;)V
    .locals 1

    .line 907
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 908
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->ensureClassificationIsMutable()V

    .line 909
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->classification_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->set(ILjava/lang/Object;)Ljava/lang/Object;

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 1161
    sget-object p2, Lcom/google/mediapipe/formats/proto/ClassificationProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p2, p1

    const/4 p2, 0x0

    packed-switch p1, :pswitch_data_0

    .line 1203
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    invoke-direct {p1}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw p1

    :pswitch_0
    return-object p2

    :pswitch_1
    const/4 p1, 0x1

    .line 1197
    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 1182
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 1184
    const-class p2, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    monitor-enter p2

    .line 1185
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_0

    .line 1187
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 1190
    sput-object p1, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 1192
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

    .line 1179
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    return-object p1

    .line 1169
    :pswitch_4
    const-string p1, "classification_"

    const-class p2, Lcom/google/mediapipe/formats/proto/ClassificationProto$Classification;

    filled-new-array {p1, p2}, [Ljava/lang/Object;

    move-result-object p1

    .line 1173
    const-string p2, "\u0001\u0001\u0000\u0000\u0001\u0001\u0001\u0000\u0001\u0000\u0001\u001b"

    .line 1175
    sget-object p3, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    invoke-static {p3, p2, p1}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 1166
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList$Builder;

    invoke-direct {p1, p2}, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList$Builder;-><init>(Lcom/google/mediapipe/formats/proto/ClassificationProto$1;)V

    return-object p1

    .line 1163
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    invoke-direct {p1}, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;-><init>()V

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

.method public getClassification(I)Lcom/google/mediapipe/formats/proto/ClassificationProto$Classification;
    .locals 1

    .line 885
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->classification_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/formats/proto/ClassificationProto$Classification;

    return-object p1
.end method

.method public getClassificationCount()I
    .locals 1

    .line 878
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->classification_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    return v0
.end method

.method public getClassificationList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/formats/proto/ClassificationProto$Classification;",
            ">;"
        }
    .end annotation

    .line 864
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->classification_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public getClassificationOrBuilder(I)Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationOrBuilder;
    .locals 1

    .line 892
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->classification_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationOrBuilder;

    return-object p1
.end method

.method public getClassificationOrBuilderList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "+",
            "Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationOrBuilder;",
            ">;"
        }
    .end annotation

    .line 871
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->classification_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public bridge synthetic getDefaultInstanceForType()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 849
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic newBuilderForType()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 849
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 849
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
