.class public final Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "RenderDataProto.java"

# interfaces
.implements Lcom/google/mediapipe/util/proto/RenderDataProto$RenderDataOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/util/proto/RenderDataProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "RenderData"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;",
        "Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData$Builder;",
        ">;",
        "Lcom/google/mediapipe/util/proto/RenderDataProto$RenderDataOrBuilder;"
    }
.end annotation


# static fields
.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;

.field private static volatile PARSER:Lcom/google/protobuf/Parser; = null
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;",
            ">;"
        }
    .end annotation
.end field

.field public static final RENDER_ANNOTATIONS_FIELD_NUMBER:I = 0x1

.field public static final SCENE_CLASS_FIELD_NUMBER:I = 0x2

.field public static final SCENE_VIEWPORT_FIELD_NUMBER:I = 0x3


# instance fields
.field private bitField0_:I

.field private renderAnnotations_:Lcom/google/protobuf/Internal$ProtobufList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Internal$ProtobufList<",
            "Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;",
            ">;"
        }
    .end annotation
.end field

.field private sceneClass_:Ljava/lang/String;

.field private sceneViewport_:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 794
    new-instance v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;

    invoke-direct {v0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;-><init>()V

    .line 797
    sput-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;

    .line 798
    const-class v1, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    .line 100
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    .line 101
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->renderAnnotations_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 102
    const-string v0, ""

    iput-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->sceneClass_:Ljava/lang/String;

    return-void
.end method

.method static synthetic access$000()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;
    .locals 1

    .line 95
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;

    return-object v0
.end method

.method static synthetic access$100(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;ILcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;)V
    .locals 0

    .line 95
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->setRenderAnnotations(ILcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;)V

    return-void
.end method

.method static synthetic access$1000(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;)V
    .locals 0

    .line 95
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->setSceneViewport(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;)V

    return-void
.end method

.method static synthetic access$1100(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;)V
    .locals 0

    .line 95
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->mergeSceneViewport(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;)V

    return-void
.end method

.method static synthetic access$1200(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;)V
    .locals 0

    .line 95
    invoke-direct {p0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->clearSceneViewport()V

    return-void
.end method

.method static synthetic access$200(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;)V
    .locals 0

    .line 95
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->addRenderAnnotations(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;)V

    return-void
.end method

.method static synthetic access$300(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;ILcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;)V
    .locals 0

    .line 95
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->addRenderAnnotations(ILcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;)V

    return-void
.end method

.method static synthetic access$400(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;Ljava/lang/Iterable;)V
    .locals 0

    .line 95
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->addAllRenderAnnotations(Ljava/lang/Iterable;)V

    return-void
.end method

.method static synthetic access$500(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;)V
    .locals 0

    .line 95
    invoke-direct {p0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->clearRenderAnnotations()V

    return-void
.end method

.method static synthetic access$600(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;I)V
    .locals 0

    .line 95
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->removeRenderAnnotations(I)V

    return-void
.end method

.method static synthetic access$700(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;Ljava/lang/String;)V
    .locals 0

    .line 95
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->setSceneClass(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$800(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;)V
    .locals 0

    .line 95
    invoke-direct {p0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->clearSceneClass()V

    return-void
.end method

.method static synthetic access$900(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 95
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->setSceneClassBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method private addAllRenderAnnotations(Ljava/lang/Iterable;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "+",
            "Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;",
            ">;)V"
        }
    .end annotation

    .line 181
    invoke-direct {p0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->ensureRenderAnnotationsIsMutable()V

    .line 182
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->renderAnnotations_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-static {p1, v0}, Lcom/google/protobuf/AbstractMessageLite;->addAll(Ljava/lang/Iterable;Ljava/util/List;)V

    return-void
.end method

.method private addRenderAnnotations(ILcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;)V
    .locals 1

    .line 172
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 173
    invoke-direct {p0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->ensureRenderAnnotationsIsMutable()V

    .line 174
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->renderAnnotations_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->add(ILjava/lang/Object;)V

    return-void
.end method

.method private addRenderAnnotations(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;)V
    .locals 1

    .line 163
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 164
    invoke-direct {p0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->ensureRenderAnnotationsIsMutable()V

    .line 165
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->renderAnnotations_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private clearRenderAnnotations()V
    .locals 1

    .line 189
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->renderAnnotations_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method private clearSceneClass()V
    .locals 1

    .line 260
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->bitField0_:I

    and-int/lit8 v0, v0, -0x2

    iput v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->bitField0_:I

    .line 261
    invoke-static {}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->getDefaultInstance()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;

    move-result-object v0

    invoke-virtual {v0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->getSceneClass()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->sceneClass_:Ljava/lang/String;

    return-void
.end method

.method private clearSceneViewport()V
    .locals 1

    const/4 v0, 0x0

    .line 354
    iput-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->sceneViewport_:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    .line 355
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->bitField0_:I

    and-int/lit8 v0, v0, -0x3

    iput v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->bitField0_:I

    return-void
.end method

.method private ensureRenderAnnotationsIsMutable()V
    .locals 2

    .line 143
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->renderAnnotations_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 144
    invoke-interface {v0}, Lcom/google/protobuf/Internal$ProtobufList;->isModifiable()Z

    move-result v1

    if-nez v1, :cond_0

    .line 146
    invoke-static {v0}, Lcom/google/protobuf/GeneratedMessageLite;->mutableCopy(Lcom/google/protobuf/Internal$ProtobufList;)Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->renderAnnotations_:Lcom/google/protobuf/Internal$ProtobufList;

    :cond_0
    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;
    .locals 1

    .line 803
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;

    return-object v0
.end method

.method private mergeSceneViewport(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;)V
    .locals 2

    .line 334
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 335
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->sceneViewport_:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    if-eqz v0, :cond_0

    .line 336
    invoke-static {}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->getDefaultInstance()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    move-result-object v1

    if-eq v0, v1, :cond_0

    .line 337
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->sceneViewport_:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    .line 338
    invoke-static {v0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->newBuilder(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport$Builder;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->sceneViewport_:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    goto :goto_0

    .line 340
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->sceneViewport_:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    .line 342
    :goto_0
    iget p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->bitField0_:I

    or-int/lit8 p1, p1, 0x2

    iput p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->bitField0_:I

    return-void
.end method

.method public static newBuilder()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData$Builder;
    .locals 1

    .line 435
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData$Builder;
    .locals 1

    .line 438
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;
    .locals 1

    .line 411
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;
    .locals 1

    .line 418
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;
    .locals 1

    .line 374
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;
    .locals 1

    .line 381
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;
    .locals 1

    .line 423
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;
    .locals 1

    .line 430
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;
    .locals 1

    .line 398
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;
    .locals 1

    .line 405
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;
    .locals 1

    .line 361
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;
    .locals 1

    .line 368
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;
    .locals 1

    .line 386
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;
    .locals 1

    .line 393
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;",
            ">;"
        }
    .end annotation

    .line 809
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private removeRenderAnnotations(I)V
    .locals 1

    .line 195
    invoke-direct {p0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->ensureRenderAnnotationsIsMutable()V

    .line 196
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->renderAnnotations_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->remove(I)Ljava/lang/Object;

    return-void
.end method

.method private setRenderAnnotations(ILcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;)V
    .locals 1

    .line 155
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 156
    invoke-direct {p0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->ensureRenderAnnotationsIsMutable()V

    .line 157
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->renderAnnotations_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->set(ILjava/lang/Object;)Ljava/lang/Object;

    return-void
.end method

.method private setSceneClass(Ljava/lang/String;)V
    .locals 1

    .line 248
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 249
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->bitField0_:I

    or-int/lit8 v0, v0, 0x1

    iput v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->bitField0_:I

    .line 250
    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->sceneClass_:Ljava/lang/String;

    return-void
.end method

.method private setSceneClassBytes(Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 273
    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->sceneClass_:Ljava/lang/String;

    .line 274
    iget p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->bitField0_:I

    or-int/lit8 p1, p1, 0x1

    iput p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->bitField0_:I

    return-void
.end method

.method private setSceneViewport(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;)V
    .locals 0

    .line 318
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 319
    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->sceneViewport_:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    .line 320
    iget p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->bitField0_:I

    or-int/lit8 p1, p1, 0x2

    iput p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->bitField0_:I

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 2

    .line 741
    sget-object p2, Lcom/google/mediapipe/util/proto/RenderDataProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p2, p1

    const/4 p2, 0x0

    packed-switch p1, :pswitch_data_0

    .line 787
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    invoke-direct {p1}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw p1

    :pswitch_0
    return-object p2

    :pswitch_1
    const/4 p1, 0x1

    .line 781
    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 766
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 768
    const-class p2, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;

    monitor-enter p2

    .line 769
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_0

    .line 771
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 774
    sput-object p1, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 776
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

    .line 763
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;

    return-object p1

    .line 749
    :pswitch_4
    const-string p1, "bitField0_"

    const-string p2, "renderAnnotations_"

    const-class p3, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    const-string v0, "sceneClass_"

    const-string v1, "sceneViewport_"

    filled-new-array {p1, p2, p3, v0, v1}, [Ljava/lang/Object;

    move-result-object p1

    .line 756
    const-string p2, "\u0001\u0003\u0000\u0001\u0001\u0003\u0003\u0000\u0001\u0000\u0001\u001b\u0002\u1008\u0000\u0003\u1009\u0001"

    .line 759
    sget-object p3, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;

    invoke-static {p3, p2, p1}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 746
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData$Builder;

    invoke-direct {p1, p2}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData$Builder;-><init>(Lcom/google/mediapipe/util/proto/RenderDataProto$1;)V

    return-object p1

    .line 743
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;

    invoke-direct {p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;-><init>()V

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

    .line 95
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getRenderAnnotations(I)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;
    .locals 1

    .line 133
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->renderAnnotations_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    return-object p1
.end method

.method public getRenderAnnotationsCount()I
    .locals 1

    .line 126
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->renderAnnotations_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    return v0
.end method

.method public getRenderAnnotationsList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;",
            ">;"
        }
    .end annotation

    .line 112
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->renderAnnotations_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public getRenderAnnotationsOrBuilder(I)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotationOrBuilder;
    .locals 1

    .line 140
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->renderAnnotations_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotationOrBuilder;

    return-object p1
.end method

.method public getRenderAnnotationsOrBuilderList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "+",
            "Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotationOrBuilder;",
            ">;"
        }
    .end annotation

    .line 119
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->renderAnnotations_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public getSceneClass()Ljava/lang/String;
    .locals 1

    .line 223
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->sceneClass_:Ljava/lang/String;

    return-object v0
.end method

.method public getSceneClassBytes()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 236
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->sceneClass_:Ljava/lang/String;

    invoke-static {v0}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object v0

    return-object v0
.end method

.method public getSceneViewport()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;
    .locals 1

    .line 305
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->sceneViewport_:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    if-nez v0, :cond_0

    invoke-static {}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;->getDefaultInstance()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderViewport;

    move-result-object v0

    :cond_0
    return-object v0
.end method

.method public hasSceneClass()Z
    .locals 2

    .line 211
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->bitField0_:I

    const/4 v1, 0x1

    and-int/2addr v0, v1

    if-eqz v0, :cond_0

    return v1

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasSceneViewport()Z
    .locals 1

    .line 291
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderData;->bitField0_:I

    and-int/lit8 v0, v0, 0x2

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public bridge synthetic newBuilderForType()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 95
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 95
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
