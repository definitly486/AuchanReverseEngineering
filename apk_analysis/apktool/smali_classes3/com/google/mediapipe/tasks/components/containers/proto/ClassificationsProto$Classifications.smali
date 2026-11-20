.class public final Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "ClassificationsProto.java"

# interfaces
.implements Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationsOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Classifications"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;",
        "Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications$Builder;",
        ">;",
        "Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$ClassificationsOrBuilder;"
    }
.end annotation


# static fields
.field public static final CLASSIFICATION_LIST_FIELD_NUMBER:I = 0x4

.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

.field public static final HEAD_INDEX_FIELD_NUMBER:I = 0x2

.field public static final HEAD_NAME_FIELD_NUMBER:I = 0x3

.field private static volatile PARSER:Lcom/google/protobuf/Parser;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;",
            ">;"
        }
    .end annotation
.end field


# instance fields
.field private bitField0_:I

.field private classificationList_:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

.field private headIndex_:I

.field private headName_:Ljava/lang/String;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 698
    new-instance v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    invoke-direct {v0}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;-><init>()V

    .line 701
    sput-object v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    .line 702
    const-class v1, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    .line 104
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    .line 105
    const-string v0, ""

    iput-object v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->headName_:Ljava/lang/String;

    return-void
.end method

.method static synthetic access$000()Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;
    .locals 1

    .line 99
    sget-object v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    return-object v0
.end method

.method static synthetic access$100(Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;)V
    .locals 0

    .line 99
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->setClassificationList(Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;)V

    return-void
.end method

.method static synthetic access$200(Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;)V
    .locals 0

    .line 99
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->mergeClassificationList(Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;)V

    return-void
.end method

.method static synthetic access$300(Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;)V
    .locals 0

    .line 99
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->clearClassificationList()V

    return-void
.end method

.method static synthetic access$400(Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;I)V
    .locals 0

    .line 99
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->setHeadIndex(I)V

    return-void
.end method

.method static synthetic access$500(Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;)V
    .locals 0

    .line 99
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->clearHeadIndex()V

    return-void
.end method

.method static synthetic access$600(Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;Ljava/lang/String;)V
    .locals 0

    .line 99
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->setHeadName(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$700(Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;)V
    .locals 0

    .line 99
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->clearHeadName()V

    return-void
.end method

.method static synthetic access$800(Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 99
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->setHeadNameBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method private clearClassificationList()V
    .locals 1

    const/4 v0, 0x0

    .line 170
    iput-object v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->classificationList_:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    .line 171
    iget v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->bitField0_:I

    and-int/lit8 v0, v0, -0x2

    iput v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->bitField0_:I

    return-void
.end method

.method private clearHeadIndex()V
    .locals 1

    .line 224
    iget v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->bitField0_:I

    and-int/lit8 v0, v0, -0x3

    iput v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->bitField0_:I

    const/4 v0, 0x0

    .line 225
    iput v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->headIndex_:I

    return-void
.end method

.method private clearHeadName()V
    .locals 1

    .line 299
    iget v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->bitField0_:I

    and-int/lit8 v0, v0, -0x5

    iput v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->bitField0_:I

    .line 300
    invoke-static {}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->getDefaultInstance()Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    move-result-object v0

    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->getHeadName()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->headName_:Ljava/lang/String;

    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;
    .locals 1

    .line 707
    sget-object v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    return-object v0
.end method

.method private mergeClassificationList(Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;)V
    .locals 2

    .line 153
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 154
    iget-object v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->classificationList_:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    if-eqz v0, :cond_0

    .line 155
    invoke-static {}, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->getDefaultInstance()Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    move-result-object v1

    if-eq v0, v1, :cond_0

    .line 156
    iget-object v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->classificationList_:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    .line 157
    invoke-static {v0}, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->newBuilder(Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;)Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList$Builder;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    iput-object p1, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->classificationList_:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    goto :goto_0

    .line 159
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->classificationList_:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    .line 161
    :goto_0
    iget p1, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->bitField0_:I

    or-int/lit8 p1, p1, 0x1

    iput p1, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->bitField0_:I

    return-void
.end method

.method public static newBuilder()Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications$Builder;
    .locals 1

    .line 395
    sget-object v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;)Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications$Builder;
    .locals 1

    .line 398
    sget-object v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;
    .locals 1

    .line 371
    sget-object v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;
    .locals 1

    .line 378
    sget-object v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;
    .locals 1

    .line 334
    sget-object v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;
    .locals 1

    .line 341
    sget-object v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;
    .locals 1

    .line 383
    sget-object v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;
    .locals 1

    .line 390
    sget-object v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;
    .locals 1

    .line 358
    sget-object v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;
    .locals 1

    .line 365
    sget-object v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;
    .locals 1

    .line 321
    sget-object v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;
    .locals 1

    .line 328
    sget-object v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;
    .locals 1

    .line 346
    sget-object v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;
    .locals 1

    .line 353
    sget-object v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;",
            ">;"
        }
    .end annotation

    .line 713
    sget-object v0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private setClassificationList(Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;)V
    .locals 0

    .line 140
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 141
    iput-object p1, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->classificationList_:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    .line 142
    iget p1, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->bitField0_:I

    or-int/lit8 p1, p1, 0x1

    iput p1, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->bitField0_:I

    return-void
.end method

.method private setHeadIndex(I)V
    .locals 1

    .line 212
    iget v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->bitField0_:I

    or-int/lit8 v0, v0, 0x2

    iput v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->bitField0_:I

    .line 213
    iput p1, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->headIndex_:I

    return-void
.end method

.method private setHeadName(Ljava/lang/String;)V
    .locals 1

    .line 285
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 286
    iget v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->bitField0_:I

    or-int/lit8 v0, v0, 0x4

    iput v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->bitField0_:I

    .line 287
    iput-object p1, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->headName_:Ljava/lang/String;

    return-void
.end method

.method private setHeadNameBytes(Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 314
    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->headName_:Ljava/lang/String;

    .line 315
    iget p1, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->bitField0_:I

    or-int/lit8 p1, p1, 0x4

    iput p1, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->bitField0_:I

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 1

    .line 646
    sget-object p2, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p2, p1

    const/4 p2, 0x0

    packed-switch p1, :pswitch_data_0

    .line 691
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    invoke-direct {p1}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw p1

    :pswitch_0
    return-object p2

    :pswitch_1
    const/4 p1, 0x1

    .line 685
    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 670
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 672
    const-class p2, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    monitor-enter p2

    .line 673
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_0

    .line 675
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 678
    sput-object p1, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 680
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

    .line 667
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    return-object p1

    .line 654
    :pswitch_4
    const-string p1, "bitField0_"

    const-string p2, "headIndex_"

    const-string p3, "headName_"

    const-string v0, "classificationList_"

    filled-new-array {p1, p2, p3, v0}, [Ljava/lang/Object;

    move-result-object p1

    .line 660
    const-string p2, "\u0001\u0003\u0000\u0001\u0002\u0004\u0003\u0000\u0000\u0000\u0002\u1004\u0001\u0003\u1008\u0002\u0004\u1009\u0000"

    .line 663
    sget-object p3, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    invoke-static {p3, p2, p1}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 651
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications$Builder;

    invoke-direct {p1, p2}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications$Builder;-><init>(Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$1;)V

    return-object p1

    .line 648
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;

    invoke-direct {p1}, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;-><init>()V

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

.method public getClassificationList()Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;
    .locals 1

    .line 130
    iget-object v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->classificationList_:Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    if-nez v0, :cond_0

    invoke-static {}, Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;->getDefaultInstance()Lcom/google/mediapipe/formats/proto/ClassificationProto$ClassificationList;

    move-result-object v0

    :cond_0
    return-object v0
.end method

.method public bridge synthetic getDefaultInstanceForType()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 99
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getHeadIndex()I
    .locals 1

    .line 200
    iget v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->headIndex_:I

    return v0
.end method

.method public getHeadName()Ljava/lang/String;
    .locals 1

    .line 256
    iget-object v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->headName_:Ljava/lang/String;

    return-object v0
.end method

.method public getHeadNameBytes()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 271
    iget-object v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->headName_:Ljava/lang/String;

    invoke-static {v0}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object v0

    return-object v0
.end method

.method public hasClassificationList()Z
    .locals 2

    .line 119
    iget v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->bitField0_:I

    const/4 v1, 0x1

    and-int/2addr v0, v1

    if-eqz v0, :cond_0

    return v1

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasHeadIndex()Z
    .locals 1

    .line 187
    iget v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->bitField0_:I

    and-int/lit8 v0, v0, 0x2

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasHeadName()Z
    .locals 1

    .line 242
    iget v0, p0, Lcom/google/mediapipe/tasks/components/containers/proto/ClassificationsProto$Classifications;->bitField0_:I

    and-int/lit8 v0, v0, 0x4

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public bridge synthetic newBuilderForType()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 99
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 99
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
