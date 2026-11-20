.class public final Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "BaseOptionsProto.java"

# interfaces
.implements Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptionsOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "BaseOptions"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;",
        "Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions$Builder;",
        ">;",
        "Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptionsOrBuilder;"
    }
.end annotation


# static fields
.field public static final ACCELERATION_FIELD_NUMBER:I = 0x3

.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

.field public static final GPU_ORIGIN_FIELD_NUMBER:I = 0x4

.field public static final MODEL_ASSET_FIELD_NUMBER:I = 0x1

.field private static volatile PARSER:Lcom/google/protobuf/Parser; = null
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;",
            ">;"
        }
    .end annotation
.end field

.field public static final USE_STREAM_MODE_FIELD_NUMBER:I = 0x2


# instance fields
.field private acceleration_:Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

.field private bitField0_:I

.field private gpuOrigin_:I

.field private modelAsset_:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

.field private useStreamMode_:Z


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 710
    new-instance v0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    invoke-direct {v0}, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;-><init>()V

    .line 713
    sput-object v0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    .line 714
    const-class v1, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    .line 100
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    const/4 v0, 0x2

    .line 101
    iput v0, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->gpuOrigin_:I

    return-void
.end method

.method static synthetic access$000()Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;
    .locals 1

    .line 95
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    return-object v0
.end method

.method static synthetic access$100(Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;)V
    .locals 0

    .line 95
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->setModelAsset(Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;)V

    return-void
.end method

.method static synthetic access$1000(Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;)V
    .locals 0

    .line 95
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->clearGpuOrigin()V

    return-void
.end method

.method static synthetic access$200(Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;)V
    .locals 0

    .line 95
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->mergeModelAsset(Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;)V

    return-void
.end method

.method static synthetic access$300(Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;)V
    .locals 0

    .line 95
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->clearModelAsset()V

    return-void
.end method

.method static synthetic access$400(Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;Z)V
    .locals 0

    .line 95
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->setUseStreamMode(Z)V

    return-void
.end method

.method static synthetic access$500(Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;)V
    .locals 0

    .line 95
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->clearUseStreamMode()V

    return-void
.end method

.method static synthetic access$600(Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;)V
    .locals 0

    .line 95
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->setAcceleration(Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;)V

    return-void
.end method

.method static synthetic access$700(Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;)V
    .locals 0

    .line 95
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->mergeAcceleration(Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;)V

    return-void
.end method

.method static synthetic access$800(Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;)V
    .locals 0

    .line 95
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->clearAcceleration()V

    return-void
.end method

.method static synthetic access$900(Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin$Mode;)V
    .locals 0

    .line 95
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->setGpuOrigin(Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin$Mode;)V

    return-void
.end method

.method private clearAcceleration()V
    .locals 1

    const/4 v0, 0x0

    .line 266
    iput-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->acceleration_:Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    .line 267
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->bitField0_:I

    and-int/lit8 v0, v0, -0x5

    iput v0, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->bitField0_:I

    return-void
.end method

.method private clearGpuOrigin()V
    .locals 1

    .line 317
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->bitField0_:I

    and-int/lit8 v0, v0, -0x9

    iput v0, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->bitField0_:I

    const/4 v0, 0x2

    .line 318
    iput v0, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->gpuOrigin_:I

    return-void
.end method

.method private clearModelAsset()V
    .locals 1

    const/4 v0, 0x0

    .line 146
    iput-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->modelAsset_:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    .line 147
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->bitField0_:I

    and-int/lit8 v0, v0, -0x2

    iput v0, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->bitField0_:I

    return-void
.end method

.method private clearUseStreamMode()V
    .locals 1

    .line 200
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->bitField0_:I

    and-int/lit8 v0, v0, -0x3

    iput v0, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->bitField0_:I

    const/4 v0, 0x0

    .line 201
    iput-boolean v0, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->useStreamMode_:Z

    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;
    .locals 1

    .line 719
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    return-object v0
.end method

.method private mergeAcceleration(Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;)V
    .locals 2

    .line 249
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 250
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->acceleration_:Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    if-eqz v0, :cond_0

    .line 251
    invoke-static {}, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->getDefaultInstance()Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    move-result-object v1

    if-eq v0, v1, :cond_0

    .line 252
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->acceleration_:Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    .line 253
    invoke-static {v0}, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->newBuilder(Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;)Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration$Builder;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    iput-object p1, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->acceleration_:Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    goto :goto_0

    .line 255
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->acceleration_:Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    .line 257
    :goto_0
    iget p1, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->bitField0_:I

    or-int/lit8 p1, p1, 0x4

    iput p1, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->bitField0_:I

    return-void
.end method

.method private mergeModelAsset(Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;)V
    .locals 2

    .line 133
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 134
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->modelAsset_:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    if-eqz v0, :cond_0

    .line 135
    invoke-static {}, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->getDefaultInstance()Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    move-result-object v1

    if-eq v0, v1, :cond_0

    .line 136
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->modelAsset_:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    .line 137
    invoke-static {v0}, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->newBuilder(Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;)Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile$Builder;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    iput-object p1, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->modelAsset_:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    goto :goto_0

    .line 139
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->modelAsset_:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    .line 141
    :goto_0
    iget p1, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->bitField0_:I

    or-int/lit8 p1, p1, 0x1

    iput p1, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->bitField0_:I

    return-void
.end method

.method public static newBuilder()Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions$Builder;
    .locals 1

    .line 398
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;)Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions$Builder;
    .locals 1

    .line 401
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;
    .locals 1

    .line 374
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;
    .locals 1

    .line 381
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;
    .locals 1

    .line 337
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;
    .locals 1

    .line 344
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;
    .locals 1

    .line 386
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;
    .locals 1

    .line 393
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;
    .locals 1

    .line 361
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;
    .locals 1

    .line 368
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;
    .locals 1

    .line 324
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;
    .locals 1

    .line 331
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;
    .locals 1

    .line 349
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;
    .locals 1

    .line 356
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;",
            ">;"
        }
    .end annotation

    .line 725
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private setAcceleration(Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;)V
    .locals 0

    .line 236
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 237
    iput-object p1, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->acceleration_:Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    .line 238
    iget p1, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->bitField0_:I

    or-int/lit8 p1, p1, 0x4

    iput p1, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->bitField0_:I

    return-void
.end method

.method private setGpuOrigin(Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin$Mode;)V
    .locals 0

    .line 306
    invoke-virtual {p1}, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin$Mode;->getNumber()I

    move-result p1

    iput p1, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->gpuOrigin_:I

    .line 307
    iget p1, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->bitField0_:I

    or-int/lit8 p1, p1, 0x8

    iput p1, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->bitField0_:I

    return-void
.end method

.method private setModelAsset(Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;)V
    .locals 0

    .line 124
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 125
    iput-object p1, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->modelAsset_:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    .line 126
    iget p1, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->bitField0_:I

    or-int/lit8 p1, p1, 0x1

    iput p1, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->bitField0_:I

    return-void
.end method

.method private setUseStreamMode(Z)V
    .locals 1

    .line 188
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->bitField0_:I

    or-int/lit8 v0, v0, 0x2

    iput v0, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->bitField0_:I

    .line 189
    iput-boolean p1, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->useStreamMode_:Z

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 6

    .line 656
    sget-object p2, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p2, p1

    const/4 p2, 0x0

    packed-switch p1, :pswitch_data_0

    .line 703
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    invoke-direct {p1}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw p1

    :pswitch_0
    return-object p2

    :pswitch_1
    const/4 p1, 0x1

    .line 697
    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 682
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 684
    const-class p2, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    monitor-enter p2

    .line 685
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_0

    .line 687
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 690
    sput-object p1, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_0

    :catchall_0
    move-exception v0

    move-object p1, v0

    goto :goto_1

    .line 692
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

    .line 679
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    return-object p1

    .line 664
    :pswitch_4
    const-string v0, "bitField0_"

    const-string v1, "modelAsset_"

    const-string v2, "useStreamMode_"

    const-string v3, "acceleration_"

    const-string v4, "gpuOrigin_"

    .line 670
    invoke-static {}, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin$Mode;->internalGetVerifier()Lcom/google/protobuf/Internal$EnumVerifier;

    move-result-object v5

    filled-new-array/range {v0 .. v5}, [Ljava/lang/Object;

    move-result-object p1

    .line 672
    const-string p2, "\u0001\u0004\u0000\u0001\u0001\u0004\u0004\u0000\u0000\u0000\u0001\u1009\u0000\u0002\u1007\u0001\u0003\u1009\u0002\u0004\u180c\u0003"

    .line 675
    sget-object p3, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    invoke-static {p3, p2, p1}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 661
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions$Builder;

    invoke-direct {p1, p2}, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions$Builder;-><init>(Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$1;)V

    return-object p1

    .line 658
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    invoke-direct {p1}, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;-><init>()V

    return-object p1

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

.method public getAcceleration()Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;
    .locals 1

    .line 226
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->acceleration_:Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    if-nez v0, :cond_0

    invoke-static {}, Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;->getDefaultInstance()Lcom/google/mediapipe/tasks/core/proto/AccelerationProto$Acceleration;

    move-result-object v0

    :cond_0
    return-object v0
.end method

.method public bridge synthetic getDefaultInstanceForType()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 95
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getGpuOrigin()Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin$Mode;
    .locals 1

    .line 294
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->gpuOrigin_:I

    invoke-static {v0}, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin$Mode;->forNumber(I)Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin$Mode;

    move-result-object v0

    if-nez v0, :cond_0

    .line 295
    sget-object v0, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin$Mode;->TOP_LEFT:Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin$Mode;

    :cond_0
    return-object v0
.end method

.method public getModelAsset()Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;
    .locals 1

    .line 118
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->modelAsset_:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    if-nez v0, :cond_0

    invoke-static {}, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->getDefaultInstance()Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    move-result-object v0

    :cond_0
    return-object v0
.end method

.method public getUseStreamMode()Z
    .locals 1

    .line 176
    iget-boolean v0, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->useStreamMode_:Z

    return v0
.end method

.method public hasAcceleration()Z
    .locals 1

    .line 215
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->bitField0_:I

    and-int/lit8 v0, v0, 0x4

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasGpuOrigin()Z
    .locals 1

    .line 282
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->bitField0_:I

    and-int/lit8 v0, v0, 0x8

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasModelAsset()Z
    .locals 2

    .line 111
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->bitField0_:I

    const/4 v1, 0x1

    and-int/2addr v0, v1

    if-eqz v0, :cond_0

    return v1

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasUseStreamMode()Z
    .locals 1

    .line 163
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->bitField0_:I

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
