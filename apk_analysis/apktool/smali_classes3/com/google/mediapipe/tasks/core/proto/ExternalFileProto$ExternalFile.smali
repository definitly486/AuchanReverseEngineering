.class public final Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "ExternalFileProto.java"

# interfaces
.implements Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFileOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "ExternalFile"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;",
        "Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile$Builder;",
        ">;",
        "Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFileOrBuilder;"
    }
.end annotation


# static fields
.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

.field public static final FILE_CONTENT_FIELD_NUMBER:I = 0x1

.field public static final FILE_DESCRIPTOR_META_FIELD_NUMBER:I = 0x3

.field public static final FILE_NAME_FIELD_NUMBER:I = 0x2

.field public static final FILE_POINTER_META_FIELD_NUMBER:I = 0x4

.field private static volatile PARSER:Lcom/google/protobuf/Parser;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;",
            ">;"
        }
    .end annotation
.end field


# instance fields
.field private bitField0_:I

.field private fileContent_:Lcom/google/protobuf/ByteString;

.field private fileDescriptorMeta_:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

.field private fileName_:Ljava/lang/String;

.field private filePointerMeta_:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FilePointerMeta;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 902
    new-instance v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    invoke-direct {v0}, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;-><init>()V

    .line 905
    sput-object v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    .line 906
    const-class v1, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    .line 135
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    .line 136
    sget-object v0, Lcom/google/protobuf/ByteString;->EMPTY:Lcom/google/protobuf/ByteString;

    iput-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->fileContent_:Lcom/google/protobuf/ByteString;

    .line 137
    const-string v0, ""

    iput-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->fileName_:Ljava/lang/String;

    return-void
.end method

.method static synthetic access$000()Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;
    .locals 1

    .line 130
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    return-object v0
.end method

.method static synthetic access$100(Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 130
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->setFileContent(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method static synthetic access$1000(Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FilePointerMeta;)V
    .locals 0

    .line 130
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->mergeFilePointerMeta(Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FilePointerMeta;)V

    return-void
.end method

.method static synthetic access$1100(Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;)V
    .locals 0

    .line 130
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->clearFilePointerMeta()V

    return-void
.end method

.method static synthetic access$200(Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;)V
    .locals 0

    .line 130
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->clearFileContent()V

    return-void
.end method

.method static synthetic access$300(Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;Ljava/lang/String;)V
    .locals 0

    .line 130
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->setFileName(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$400(Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;)V
    .locals 0

    .line 130
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->clearFileName()V

    return-void
.end method

.method static synthetic access$500(Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 130
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->setFileNameBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method static synthetic access$600(Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;)V
    .locals 0

    .line 130
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->setFileDescriptorMeta(Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;)V

    return-void
.end method

.method static synthetic access$700(Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;)V
    .locals 0

    .line 130
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->mergeFileDescriptorMeta(Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;)V

    return-void
.end method

.method static synthetic access$800(Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;)V
    .locals 0

    .line 130
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->clearFileDescriptorMeta()V

    return-void
.end method

.method static synthetic access$900(Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FilePointerMeta;)V
    .locals 0

    .line 130
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->setFilePointerMeta(Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FilePointerMeta;)V

    return-void
.end method

.method private clearFileContent()V
    .locals 1

    .line 187
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->bitField0_:I

    and-int/lit8 v0, v0, -0x2

    iput v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->bitField0_:I

    .line 188
    invoke-static {}, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->getDefaultInstance()Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    move-result-object v0

    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->getFileContent()Lcom/google/protobuf/ByteString;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->fileContent_:Lcom/google/protobuf/ByteString;

    return-void
.end method

.method private clearFileDescriptorMeta()V
    .locals 1

    const/4 v0, 0x0

    .line 336
    iput-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->fileDescriptorMeta_:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    .line 337
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->bitField0_:I

    and-int/lit8 v0, v0, -0x5

    iput v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->bitField0_:I

    return-void
.end method

.method private clearFileName()V
    .locals 1

    .line 252
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->bitField0_:I

    and-int/lit8 v0, v0, -0x3

    iput v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->bitField0_:I

    .line 253
    invoke-static {}, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->getDefaultInstance()Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    move-result-object v0

    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->getFileName()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->fileName_:Ljava/lang/String;

    return-void
.end method

.method private clearFilePointerMeta()V
    .locals 1

    const/4 v0, 0x0

    .line 422
    iput-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->filePointerMeta_:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FilePointerMeta;

    .line 423
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->bitField0_:I

    and-int/lit8 v0, v0, -0x9

    iput v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->bitField0_:I

    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;
    .locals 1

    .line 911
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    return-object v0
.end method

.method private mergeFileDescriptorMeta(Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;)V
    .locals 2

    .line 318
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 319
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->fileDescriptorMeta_:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    if-eqz v0, :cond_0

    .line 320
    invoke-static {}, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->getDefaultInstance()Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    move-result-object v1

    if-eq v0, v1, :cond_0

    .line 321
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->fileDescriptorMeta_:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    .line 322
    invoke-static {v0}, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->newBuilder(Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;)Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta$Builder;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    iput-object p1, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->fileDescriptorMeta_:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    goto :goto_0

    .line 324
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->fileDescriptorMeta_:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    .line 326
    :goto_0
    iget p1, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->bitField0_:I

    or-int/lit8 p1, p1, 0x4

    iput p1, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->bitField0_:I

    return-void
.end method

.method private mergeFilePointerMeta(Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FilePointerMeta;)V
    .locals 2

    .line 401
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 402
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->filePointerMeta_:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FilePointerMeta;

    if-eqz v0, :cond_0

    .line 403
    invoke-static {}, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FilePointerMeta;->getDefaultInstance()Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FilePointerMeta;

    move-result-object v1

    if-eq v0, v1, :cond_0

    .line 404
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->filePointerMeta_:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FilePointerMeta;

    .line 405
    invoke-static {v0}, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FilePointerMeta;->newBuilder(Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FilePointerMeta;)Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FilePointerMeta$Builder;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FilePointerMeta$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FilePointerMeta;

    iput-object p1, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->filePointerMeta_:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FilePointerMeta;

    goto :goto_0

    .line 407
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->filePointerMeta_:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FilePointerMeta;

    .line 409
    :goto_0
    iget p1, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->bitField0_:I

    or-int/lit8 p1, p1, 0x8

    iput p1, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->bitField0_:I

    return-void
.end method

.method public static newBuilder()Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile$Builder;
    .locals 1

    .line 503
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;)Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile$Builder;
    .locals 1

    .line 506
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;
    .locals 1

    .line 479
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;
    .locals 1

    .line 486
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;
    .locals 1

    .line 442
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;
    .locals 1

    .line 449
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;
    .locals 1

    .line 491
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;
    .locals 1

    .line 498
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;
    .locals 1

    .line 466
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;
    .locals 1

    .line 473
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;
    .locals 1

    .line 429
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;
    .locals 1

    .line 436
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;
    .locals 1

    .line 454
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;
    .locals 1

    .line 461
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;",
            ">;"
        }
    .end annotation

    .line 917
    sget-object v0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private setFileContent(Lcom/google/protobuf/ByteString;)V
    .locals 1

    .line 175
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 176
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->bitField0_:I

    or-int/lit8 v0, v0, 0x1

    iput v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->bitField0_:I

    .line 177
    iput-object p1, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->fileContent_:Lcom/google/protobuf/ByteString;

    return-void
.end method

.method private setFileDescriptorMeta(Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;)V
    .locals 0

    .line 304
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 305
    iput-object p1, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->fileDescriptorMeta_:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    .line 306
    iget p1, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->bitField0_:I

    or-int/lit8 p1, p1, 0x4

    iput p1, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->bitField0_:I

    return-void
.end method

.method private setFileName(Ljava/lang/String;)V
    .locals 1

    .line 240
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 241
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->bitField0_:I

    or-int/lit8 v0, v0, 0x2

    iput v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->bitField0_:I

    .line 242
    iput-object p1, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->fileName_:Ljava/lang/String;

    return-void
.end method

.method private setFileNameBytes(Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 265
    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->fileName_:Ljava/lang/String;

    .line 266
    iget p1, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->bitField0_:I

    or-int/lit8 p1, p1, 0x2

    iput p1, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->bitField0_:I

    return-void
.end method

.method private setFilePointerMeta(Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FilePointerMeta;)V
    .locals 0

    .line 384
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 385
    iput-object p1, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->filePointerMeta_:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FilePointerMeta;

    .line 386
    iget p1, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->bitField0_:I

    or-int/lit8 p1, p1, 0x8

    iput p1, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->bitField0_:I

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 2

    .line 849
    sget-object p2, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p2, p1

    const/4 p2, 0x0

    packed-switch p1, :pswitch_data_0

    .line 895
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    invoke-direct {p1}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw p1

    :pswitch_0
    return-object p2

    :pswitch_1
    const/4 p1, 0x1

    .line 889
    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 874
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 876
    const-class p2, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    monitor-enter p2

    .line 877
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_0

    .line 879
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 882
    sput-object p1, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 884
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

    .line 871
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    return-object p1

    .line 857
    :pswitch_4
    const-string p1, "bitField0_"

    const-string p2, "fileContent_"

    const-string p3, "fileName_"

    const-string v0, "fileDescriptorMeta_"

    const-string v1, "filePointerMeta_"

    filled-new-array {p1, p2, p3, v0, v1}, [Ljava/lang/Object;

    move-result-object p1

    .line 864
    const-string p2, "\u0001\u0004\u0000\u0001\u0001\u0004\u0004\u0000\u0000\u0000\u0001\u100a\u0000\u0002\u1008\u0001\u0003\u1009\u0002\u0004\u1009\u0003"

    .line 867
    sget-object p3, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    invoke-static {p3, p2, p1}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 854
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile$Builder;

    invoke-direct {p1, p2}, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile$Builder;-><init>(Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$1;)V

    return-object p1

    .line 851
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;

    invoke-direct {p1}, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;-><init>()V

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

    .line 130
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getFileContent()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 164
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->fileContent_:Lcom/google/protobuf/ByteString;

    return-object v0
.end method

.method public getFileDescriptorMeta()Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;
    .locals 1

    .line 293
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->fileDescriptorMeta_:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    if-nez v0, :cond_0

    invoke-static {}, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;->getDefaultInstance()Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FileDescriptorMeta;

    move-result-object v0

    :cond_0
    return-object v0
.end method

.method public getFileName()Ljava/lang/String;
    .locals 1

    .line 215
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->fileName_:Ljava/lang/String;

    return-object v0
.end method

.method public getFileNameBytes()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 228
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->fileName_:Ljava/lang/String;

    invoke-static {v0}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object v0

    return-object v0
.end method

.method public getFilePointerMeta()Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FilePointerMeta;
    .locals 1

    .line 370
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->filePointerMeta_:Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FilePointerMeta;

    if-nez v0, :cond_0

    invoke-static {}, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FilePointerMeta;->getDefaultInstance()Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$FilePointerMeta;

    move-result-object v0

    :cond_0
    return-object v0
.end method

.method public hasFileContent()Z
    .locals 2

    .line 152
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->bitField0_:I

    const/4 v1, 0x1

    and-int/2addr v0, v1

    if-eqz v0, :cond_0

    return v1

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasFileDescriptorMeta()Z
    .locals 1

    .line 281
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->bitField0_:I

    and-int/lit8 v0, v0, 0x4

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasFileName()Z
    .locals 1

    .line 203
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->bitField0_:I

    and-int/lit8 v0, v0, 0x2

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasFilePointerMeta()Z
    .locals 1

    .line 355
    iget v0, p0, Lcom/google/mediapipe/tasks/core/proto/ExternalFileProto$ExternalFile;->bitField0_:I

    and-int/lit8 v0, v0, 0x8

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public bridge synthetic newBuilderForType()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 130
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 130
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
