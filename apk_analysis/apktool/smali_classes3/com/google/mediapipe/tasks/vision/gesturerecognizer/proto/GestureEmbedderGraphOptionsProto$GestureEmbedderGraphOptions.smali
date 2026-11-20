.class public final Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "GestureEmbedderGraphOptionsProto.java"

# interfaces
.implements Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptionsOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "GestureEmbedderGraphOptions"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;",
        "Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions$Builder;",
        ">;",
        "Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptionsOrBuilder;"
    }
.end annotation


# static fields
.field public static final BASE_OPTIONS_FIELD_NUMBER:I = 0x1

.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

.field public static final EXT_FIELD_NUMBER:I = 0x1c8a4bce

.field private static volatile PARSER:Lcom/google/protobuf/Parser;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;",
            ">;"
        }
    .end annotation
.end field

.field public static final ext:Lcom/google/protobuf/GeneratedMessageLite$GeneratedExtension;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/GeneratedMessageLite$GeneratedExtension<",
            "Lcom/google/mediapipe/proto/CalculatorOptionsProto$CalculatorOptions;",
            "Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;",
            ">;"
        }
    .end annotation
.end field


# instance fields
.field private baseOptions_:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

.field private bitField0_:I


# direct methods
.method static constructor <clinit>()V
    .locals 9

    .line 351
    new-instance v0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    invoke-direct {v0}, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;-><init>()V

    .line 354
    sput-object v0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    .line 355
    const-class v1, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 377
    invoke-static {}, Lcom/google/mediapipe/proto/CalculatorOptionsProto$CalculatorOptions;->getDefaultInstance()Lcom/google/mediapipe/proto/CalculatorOptionsProto$CalculatorOptions;

    move-result-object v2

    .line 378
    invoke-static {}, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->getDefaultInstance()Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    move-result-object v3

    .line 379
    invoke-static {}, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->getDefaultInstance()Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    move-result-object v4

    sget-object v7, Lcom/google/protobuf/WireFormat$FieldType;->MESSAGE:Lcom/google/protobuf/WireFormat$FieldType;

    const-class v8, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    const/4 v5, 0x0

    const v6, 0x1c8a4bce

    .line 376
    invoke-static/range {v2 .. v8}, Lcom/google/protobuf/GeneratedMessageLite;->newSingularGeneratedExtension(Lcom/google/protobuf/MessageLite;Ljava/lang/Object;Lcom/google/protobuf/MessageLite;Lcom/google/protobuf/Internal$EnumLiteMap;ILcom/google/protobuf/WireFormat$FieldType;Ljava/lang/Class;)Lcom/google/protobuf/GeneratedMessageLite$GeneratedExtension;

    move-result-object v0

    sput-object v0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->ext:Lcom/google/protobuf/GeneratedMessageLite$GeneratedExtension;

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 47
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    return-void
.end method

.method static synthetic access$000()Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;
    .locals 1

    .line 42
    sget-object v0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    return-object v0
.end method

.method static synthetic access$100(Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;)V
    .locals 0

    .line 42
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->setBaseOptions(Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;)V

    return-void
.end method

.method static synthetic access$200(Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;)V
    .locals 0

    .line 42
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->mergeBaseOptions(Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;)V

    return-void
.end method

.method static synthetic access$300(Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;)V
    .locals 0

    .line 42
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->clearBaseOptions()V

    return-void
.end method

.method private clearBaseOptions()V
    .locals 1

    const/4 v0, 0x0

    .line 117
    iput-object v0, p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->baseOptions_:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    .line 118
    iget v0, p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->bitField0_:I

    and-int/lit8 v0, v0, -0x2

    iput v0, p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->bitField0_:I

    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;
    .locals 1

    .line 360
    sget-object v0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    return-object v0
.end method

.method private mergeBaseOptions(Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;)V
    .locals 2

    .line 99
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 100
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->baseOptions_:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    if-eqz v0, :cond_0

    .line 101
    invoke-static {}, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->getDefaultInstance()Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    move-result-object v1

    if-eq v0, v1, :cond_0

    .line 102
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->baseOptions_:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    .line 103
    invoke-static {v0}, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->newBuilder(Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;)Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions$Builder;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->baseOptions_:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    goto :goto_0

    .line 105
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->baseOptions_:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    .line 107
    :goto_0
    iget p1, p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->bitField0_:I

    or-int/lit8 p1, p1, 0x1

    iput p1, p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->bitField0_:I

    return-void
.end method

.method public static newBuilder()Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions$Builder;
    .locals 1

    .line 198
    sget-object v0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;)Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions$Builder;
    .locals 1

    .line 201
    sget-object v0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;
    .locals 1

    .line 174
    sget-object v0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;
    .locals 1

    .line 181
    sget-object v0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;
    .locals 1

    .line 137
    sget-object v0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;
    .locals 1

    .line 144
    sget-object v0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;
    .locals 1

    .line 186
    sget-object v0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;
    .locals 1

    .line 193
    sget-object v0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;
    .locals 1

    .line 161
    sget-object v0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;
    .locals 1

    .line 168
    sget-object v0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;
    .locals 1

    .line 124
    sget-object v0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;
    .locals 1

    .line 131
    sget-object v0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;
    .locals 1

    .line 149
    sget-object v0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;
    .locals 1

    .line 156
    sget-object v0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;",
            ">;"
        }
    .end annotation

    .line 366
    sget-object v0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private setBaseOptions(Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;)V
    .locals 0

    .line 85
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 86
    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->baseOptions_:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    .line 87
    iget p1, p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->bitField0_:I

    or-int/lit8 p1, p1, 0x1

    iput p1, p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->bitField0_:I

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 302
    sget-object p2, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p2, p1

    const/4 p2, 0x0

    packed-switch p1, :pswitch_data_0

    .line 344
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    invoke-direct {p1}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw p1

    :pswitch_0
    return-object p2

    :pswitch_1
    const/4 p1, 0x1

    .line 338
    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 323
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 325
    const-class p2, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    monitor-enter p2

    .line 326
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_0

    .line 328
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 331
    sput-object p1, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 333
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

    .line 320
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    return-object p1

    .line 310
    :pswitch_4
    const-string p1, "bitField0_"

    const-string p2, "baseOptions_"

    filled-new-array {p1, p2}, [Ljava/lang/Object;

    move-result-object p1

    .line 314
    const-string p2, "\u0001\u0001\u0000\u0001\u0001\u0001\u0001\u0000\u0000\u0000\u0001\u1009\u0000"

    .line 316
    sget-object p3, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    invoke-static {p3, p2, p1}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 307
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions$Builder;

    invoke-direct {p1, p2}, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions$Builder;-><init>(Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$1;)V

    return-object p1

    .line 304
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;

    invoke-direct {p1}, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;-><init>()V

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

    .line 74
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->baseOptions_:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    if-nez v0, :cond_0

    invoke-static {}, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->getDefaultInstance()Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    move-result-object v0

    :cond_0
    return-object v0
.end method

.method public bridge synthetic getDefaultInstanceForType()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 42
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public hasBaseOptions()Z
    .locals 2

    .line 62
    iget v0, p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/proto/GestureEmbedderGraphOptionsProto$GestureEmbedderGraphOptions;->bitField0_:I

    const/4 v1, 0x1

    and-int/2addr v0, v1

    if-eqz v0, :cond_0

    return v1

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public bridge synthetic newBuilderForType()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 42
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 42
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
