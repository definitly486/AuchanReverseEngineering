.class public final Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "ImageEmbedderGraphOptionsProto.java"

# interfaces
.implements Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptionsOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "ImageEmbedderGraphOptions"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;",
        "Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions$Builder;",
        ">;",
        "Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptionsOrBuilder;"
    }
.end annotation


# static fields
.field public static final BASE_OPTIONS_FIELD_NUMBER:I = 0x1

.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

.field public static final EMBEDDER_OPTIONS_FIELD_NUMBER:I = 0x2

.field public static final EXT_FIELD_NUMBER:I = 0x1c647f1b

.field private static volatile PARSER:Lcom/google/protobuf/Parser;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;",
            ">;"
        }
    .end annotation
.end field

.field public static final ext:Lcom/google/protobuf/GeneratedMessageLite$GeneratedExtension;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/GeneratedMessageLite$GeneratedExtension<",
            "Lcom/google/mediapipe/proto/CalculatorOptionsProto$CalculatorOptions;",
            "Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;",
            ">;"
        }
    .end annotation
.end field


# instance fields
.field private baseOptions_:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

.field private bitField0_:I

.field private embedderOptions_:Lcom/google/mediapipe/tasks/components/processors/proto/EmbedderOptionsProto$EmbedderOptions;


# direct methods
.method static constructor <clinit>()V
    .locals 9

    .line 522
    new-instance v0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    invoke-direct {v0}, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;-><init>()V

    .line 525
    sput-object v0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    .line 526
    const-class v1, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 548
    invoke-static {}, Lcom/google/mediapipe/proto/CalculatorOptionsProto$CalculatorOptions;->getDefaultInstance()Lcom/google/mediapipe/proto/CalculatorOptionsProto$CalculatorOptions;

    move-result-object v2

    .line 549
    invoke-static {}, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->getDefaultInstance()Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    move-result-object v3

    .line 550
    invoke-static {}, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->getDefaultInstance()Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    move-result-object v4

    sget-object v7, Lcom/google/protobuf/WireFormat$FieldType;->MESSAGE:Lcom/google/protobuf/WireFormat$FieldType;

    const-class v8, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    const/4 v5, 0x0

    const v6, 0x1c647f1b

    .line 547
    invoke-static/range {v2 .. v8}, Lcom/google/protobuf/GeneratedMessageLite;->newSingularGeneratedExtension(Lcom/google/protobuf/MessageLite;Ljava/lang/Object;Lcom/google/protobuf/MessageLite;Lcom/google/protobuf/Internal$EnumLiteMap;ILcom/google/protobuf/WireFormat$FieldType;Ljava/lang/Class;)Lcom/google/protobuf/GeneratedMessageLite$GeneratedExtension;

    move-result-object v0

    sput-object v0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->ext:Lcom/google/protobuf/GeneratedMessageLite$GeneratedExtension;

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 68
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    return-void
.end method

.method static synthetic access$000()Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;
    .locals 1

    .line 63
    sget-object v0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    return-object v0
.end method

.method static synthetic access$100(Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;)V
    .locals 0

    .line 63
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->setBaseOptions(Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;)V

    return-void
.end method

.method static synthetic access$200(Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;)V
    .locals 0

    .line 63
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->mergeBaseOptions(Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;)V

    return-void
.end method

.method static synthetic access$300(Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;)V
    .locals 0

    .line 63
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->clearBaseOptions()V

    return-void
.end method

.method static synthetic access$400(Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;Lcom/google/mediapipe/tasks/components/processors/proto/EmbedderOptionsProto$EmbedderOptions;)V
    .locals 0

    .line 63
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->setEmbedderOptions(Lcom/google/mediapipe/tasks/components/processors/proto/EmbedderOptionsProto$EmbedderOptions;)V

    return-void
.end method

.method static synthetic access$500(Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;Lcom/google/mediapipe/tasks/components/processors/proto/EmbedderOptionsProto$EmbedderOptions;)V
    .locals 0

    .line 63
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->mergeEmbedderOptions(Lcom/google/mediapipe/tasks/components/processors/proto/EmbedderOptionsProto$EmbedderOptions;)V

    return-void
.end method

.method static synthetic access$600(Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;)V
    .locals 0

    .line 63
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->clearEmbedderOptions()V

    return-void
.end method

.method private clearBaseOptions()V
    .locals 1

    const/4 v0, 0x0

    .line 138
    iput-object v0, p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->baseOptions_:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    .line 139
    iget v0, p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->bitField0_:I

    and-int/lit8 v0, v0, -0x2

    iput v0, p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->bitField0_:I

    return-void
.end method

.method private clearEmbedderOptions()V
    .locals 1

    const/4 v0, 0x0

    .line 209
    iput-object v0, p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->embedderOptions_:Lcom/google/mediapipe/tasks/components/processors/proto/EmbedderOptionsProto$EmbedderOptions;

    .line 210
    iget v0, p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->bitField0_:I

    and-int/lit8 v0, v0, -0x3

    iput v0, p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->bitField0_:I

    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;
    .locals 1

    .line 531
    sget-object v0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    return-object v0
.end method

.method private mergeBaseOptions(Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;)V
    .locals 2

    .line 120
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 121
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->baseOptions_:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    if-eqz v0, :cond_0

    .line 122
    invoke-static {}, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->getDefaultInstance()Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    move-result-object v1

    if-eq v0, v1, :cond_0

    .line 123
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->baseOptions_:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    .line 124
    invoke-static {v0}, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->newBuilder(Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;)Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions$Builder;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->baseOptions_:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    goto :goto_0

    .line 126
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->baseOptions_:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    .line 128
    :goto_0
    iget p1, p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->bitField0_:I

    or-int/lit8 p1, p1, 0x1

    iput p1, p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->bitField0_:I

    return-void
.end method

.method private mergeEmbedderOptions(Lcom/google/mediapipe/tasks/components/processors/proto/EmbedderOptionsProto$EmbedderOptions;)V
    .locals 2

    .line 191
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 192
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->embedderOptions_:Lcom/google/mediapipe/tasks/components/processors/proto/EmbedderOptionsProto$EmbedderOptions;

    if-eqz v0, :cond_0

    .line 193
    invoke-static {}, Lcom/google/mediapipe/tasks/components/processors/proto/EmbedderOptionsProto$EmbedderOptions;->getDefaultInstance()Lcom/google/mediapipe/tasks/components/processors/proto/EmbedderOptionsProto$EmbedderOptions;

    move-result-object v1

    if-eq v0, v1, :cond_0

    .line 194
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->embedderOptions_:Lcom/google/mediapipe/tasks/components/processors/proto/EmbedderOptionsProto$EmbedderOptions;

    .line 195
    invoke-static {v0}, Lcom/google/mediapipe/tasks/components/processors/proto/EmbedderOptionsProto$EmbedderOptions;->newBuilder(Lcom/google/mediapipe/tasks/components/processors/proto/EmbedderOptionsProto$EmbedderOptions;)Lcom/google/mediapipe/tasks/components/processors/proto/EmbedderOptionsProto$EmbedderOptions$Builder;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/components/processors/proto/EmbedderOptionsProto$EmbedderOptions$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/components/processors/proto/EmbedderOptionsProto$EmbedderOptions;

    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->embedderOptions_:Lcom/google/mediapipe/tasks/components/processors/proto/EmbedderOptionsProto$EmbedderOptions;

    goto :goto_0

    .line 197
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->embedderOptions_:Lcom/google/mediapipe/tasks/components/processors/proto/EmbedderOptionsProto$EmbedderOptions;

    .line 199
    :goto_0
    iget p1, p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->bitField0_:I

    or-int/lit8 p1, p1, 0x2

    iput p1, p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->bitField0_:I

    return-void
.end method

.method public static newBuilder()Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions$Builder;
    .locals 1

    .line 290
    sget-object v0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;)Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions$Builder;
    .locals 1

    .line 293
    sget-object v0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;
    .locals 1

    .line 266
    sget-object v0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;
    .locals 1

    .line 273
    sget-object v0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;
    .locals 1

    .line 229
    sget-object v0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;
    .locals 1

    .line 236
    sget-object v0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;
    .locals 1

    .line 278
    sget-object v0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;
    .locals 1

    .line 285
    sget-object v0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;
    .locals 1

    .line 253
    sget-object v0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;
    .locals 1

    .line 260
    sget-object v0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;
    .locals 1

    .line 216
    sget-object v0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;
    .locals 1

    .line 223
    sget-object v0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;
    .locals 1

    .line 241
    sget-object v0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;
    .locals 1

    .line 248
    sget-object v0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;",
            ">;"
        }
    .end annotation

    .line 537
    sget-object v0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private setBaseOptions(Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;)V
    .locals 0

    .line 106
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 107
    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->baseOptions_:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    .line 108
    iget p1, p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->bitField0_:I

    or-int/lit8 p1, p1, 0x1

    iput p1, p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->bitField0_:I

    return-void
.end method

.method private setEmbedderOptions(Lcom/google/mediapipe/tasks/components/processors/proto/EmbedderOptionsProto$EmbedderOptions;)V
    .locals 0

    .line 177
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 178
    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->embedderOptions_:Lcom/google/mediapipe/tasks/components/processors/proto/EmbedderOptionsProto$EmbedderOptions;

    .line 179
    iget p1, p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->bitField0_:I

    or-int/lit8 p1, p1, 0x2

    iput p1, p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->bitField0_:I

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 471
    sget-object p2, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p2, p1

    const/4 p2, 0x0

    packed-switch p1, :pswitch_data_0

    .line 515
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    invoke-direct {p1}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw p1

    :pswitch_0
    return-object p2

    :pswitch_1
    const/4 p1, 0x1

    .line 509
    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 494
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 496
    const-class p2, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    monitor-enter p2

    .line 497
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_0

    .line 499
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 502
    sput-object p1, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 504
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

    .line 491
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    return-object p1

    .line 479
    :pswitch_4
    const-string p1, "bitField0_"

    const-string p2, "baseOptions_"

    const-string p3, "embedderOptions_"

    filled-new-array {p1, p2, p3}, [Ljava/lang/Object;

    move-result-object p1

    .line 484
    const-string p2, "\u0001\u0002\u0000\u0001\u0001\u0002\u0002\u0000\u0000\u0000\u0001\u1009\u0000\u0002\u1009\u0001"

    .line 487
    sget-object p3, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    invoke-static {p3, p2, p1}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 476
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions$Builder;

    invoke-direct {p1, p2}, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions$Builder;-><init>(Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$1;)V

    return-object p1

    .line 473
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;

    invoke-direct {p1}, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;-><init>()V

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

.method public getBaseOptions()Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;
    .locals 1

    .line 95
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->baseOptions_:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    if-nez v0, :cond_0

    invoke-static {}, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->getDefaultInstance()Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    move-result-object v0

    :cond_0
    return-object v0
.end method

.method public bridge synthetic getDefaultInstanceForType()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 63
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getEmbedderOptions()Lcom/google/mediapipe/tasks/components/processors/proto/EmbedderOptionsProto$EmbedderOptions;
    .locals 1

    .line 166
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->embedderOptions_:Lcom/google/mediapipe/tasks/components/processors/proto/EmbedderOptionsProto$EmbedderOptions;

    if-nez v0, :cond_0

    invoke-static {}, Lcom/google/mediapipe/tasks/components/processors/proto/EmbedderOptionsProto$EmbedderOptions;->getDefaultInstance()Lcom/google/mediapipe/tasks/components/processors/proto/EmbedderOptionsProto$EmbedderOptions;

    move-result-object v0

    :cond_0
    return-object v0
.end method

.method public hasBaseOptions()Z
    .locals 2

    .line 83
    iget v0, p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->bitField0_:I

    const/4 v1, 0x1

    and-int/2addr v0, v1

    if-eqz v0, :cond_0

    return v1

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasEmbedderOptions()Z
    .locals 1

    .line 154
    iget v0, p0, Lcom/google/mediapipe/tasks/vision/imageembedder/proto/ImageEmbedderGraphOptionsProto$ImageEmbedderGraphOptions;->bitField0_:I

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

    .line 63
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 63
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
