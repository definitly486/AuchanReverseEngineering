.class public final Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "LandmarkProto.java"

# interfaces
.implements Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/formats/proto/LandmarkProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "LandmarkList"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;",
        "Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList$Builder;",
        ">;",
        "Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkListOrBuilder;"
    }
.end annotation


# static fields
.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

.field public static final LANDMARK_FIELD_NUMBER:I = 0x1

.field private static volatile PARSER:Lcom/google/protobuf/Parser;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;",
            ">;"
        }
    .end annotation
.end field


# instance fields
.field private landmark_:Lcom/google/protobuf/Internal$ProtobufList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Internal$ProtobufList<",
            "Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;",
            ">;"
        }
    .end annotation
.end field


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 1168
    new-instance v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    invoke-direct {v0}, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;-><init>()V

    .line 1171
    sput-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    .line 1172
    const-class v1, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    .line 812
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    .line 813
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->landmark_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method static synthetic access$1200()Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;
    .locals 1

    .line 807
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    return-object v0
.end method

.method static synthetic access$1300(Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;ILcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;)V
    .locals 0

    .line 807
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->setLandmark(ILcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;)V

    return-void
.end method

.method static synthetic access$1400(Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;)V
    .locals 0

    .line 807
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->addLandmark(Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;)V

    return-void
.end method

.method static synthetic access$1500(Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;ILcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;)V
    .locals 0

    .line 807
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->addLandmark(ILcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;)V

    return-void
.end method

.method static synthetic access$1600(Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;Ljava/lang/Iterable;)V
    .locals 0

    .line 807
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->addAllLandmark(Ljava/lang/Iterable;)V

    return-void
.end method

.method static synthetic access$1700(Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;)V
    .locals 0

    .line 807
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->clearLandmark()V

    return-void
.end method

.method static synthetic access$1800(Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;I)V
    .locals 0

    .line 807
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->removeLandmark(I)V

    return-void
.end method

.method private addAllLandmark(Ljava/lang/Iterable;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "+",
            "Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;",
            ">;)V"
        }
    .end annotation

    .line 891
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->ensureLandmarkIsMutable()V

    .line 892
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->landmark_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-static {p1, v0}, Lcom/google/protobuf/AbstractMessageLite;->addAll(Ljava/lang/Iterable;Ljava/util/List;)V

    return-void
.end method

.method private addLandmark(ILcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;)V
    .locals 1

    .line 882
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 883
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->ensureLandmarkIsMutable()V

    .line 884
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->landmark_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->add(ILjava/lang/Object;)V

    return-void
.end method

.method private addLandmark(Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;)V
    .locals 1

    .line 873
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 874
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->ensureLandmarkIsMutable()V

    .line 875
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->landmark_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private clearLandmark()V
    .locals 1

    .line 899
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->landmark_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method private ensureLandmarkIsMutable()V
    .locals 2

    .line 853
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->landmark_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 854
    invoke-interface {v0}, Lcom/google/protobuf/Internal$ProtobufList;->isModifiable()Z

    move-result v1

    if-nez v1, :cond_0

    .line 856
    invoke-static {v0}, Lcom/google/protobuf/GeneratedMessageLite;->mutableCopy(Lcom/google/protobuf/Internal$ProtobufList;)Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->landmark_:Lcom/google/protobuf/Internal$ProtobufList;

    :cond_0
    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;
    .locals 1

    .line 1177
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    return-object v0
.end method

.method public static newBuilder()Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList$Builder;
    .locals 1

    .line 986
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;)Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList$Builder;
    .locals 1

    .line 989
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;
    .locals 1

    .line 962
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;
    .locals 1

    .line 969
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;
    .locals 1

    .line 925
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;
    .locals 1

    .line 932
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;
    .locals 1

    .line 974
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;
    .locals 1

    .line 981
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;
    .locals 1

    .line 949
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;
    .locals 1

    .line 956
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;
    .locals 1

    .line 912
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;
    .locals 1

    .line 919
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;
    .locals 1

    .line 937
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;
    .locals 1

    .line 944
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;",
            ">;"
        }
    .end annotation

    .line 1183
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private removeLandmark(I)V
    .locals 1

    .line 905
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->ensureLandmarkIsMutable()V

    .line 906
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->landmark_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->remove(I)Ljava/lang/Object;

    return-void
.end method

.method private setLandmark(ILcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;)V
    .locals 1

    .line 865
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 866
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->ensureLandmarkIsMutable()V

    .line 867
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->landmark_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->set(ILjava/lang/Object;)Ljava/lang/Object;

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 1119
    sget-object p2, Lcom/google/mediapipe/formats/proto/LandmarkProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p2, p1

    const/4 p2, 0x0

    packed-switch p1, :pswitch_data_0

    .line 1161
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    invoke-direct {p1}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw p1

    :pswitch_0
    return-object p2

    :pswitch_1
    const/4 p1, 0x1

    .line 1155
    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 1140
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 1142
    const-class p2, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    monitor-enter p2

    .line 1143
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_0

    .line 1145
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 1148
    sput-object p1, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 1150
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

    .line 1137
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    return-object p1

    .line 1127
    :pswitch_4
    const-string p1, "landmark_"

    const-class p2, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

    filled-new-array {p1, p2}, [Ljava/lang/Object;

    move-result-object p1

    .line 1131
    const-string p2, "\u0001\u0001\u0000\u0000\u0001\u0001\u0001\u0000\u0001\u0000\u0001\u001b"

    .line 1133
    sget-object p3, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    invoke-static {p3, p2, p1}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 1124
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList$Builder;

    invoke-direct {p1, p2}, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList$Builder;-><init>(Lcom/google/mediapipe/formats/proto/LandmarkProto$1;)V

    return-object p1

    .line 1121
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;

    invoke-direct {p1}, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;-><init>()V

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

    .line 807
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getLandmark(I)Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;
    .locals 1

    .line 843
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->landmark_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

    return-object p1
.end method

.method public getLandmarkCount()I
    .locals 1

    .line 836
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->landmark_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    return v0
.end method

.method public getLandmarkList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;",
            ">;"
        }
    .end annotation

    .line 822
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->landmark_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public getLandmarkOrBuilder(I)Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkOrBuilder;
    .locals 1

    .line 850
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->landmark_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkOrBuilder;

    return-object p1
.end method

.method public getLandmarkOrBuilderList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "+",
            "Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkOrBuilder;",
            ">;"
        }
    .end annotation

    .line 829
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkList;->landmark_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public bridge synthetic newBuilderForType()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 807
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 807
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
