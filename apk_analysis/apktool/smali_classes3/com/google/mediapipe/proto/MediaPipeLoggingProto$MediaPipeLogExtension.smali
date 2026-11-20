.class public final Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "MediaPipeLoggingProto.java"

# interfaces
.implements Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtensionOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/proto/MediaPipeLoggingProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "MediaPipeLogExtension"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;",
        "Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension$Builder;",
        ">;",
        "Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtensionOrBuilder;"
    }
.end annotation


# static fields
.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;

.field private static volatile PARSER:Lcom/google/protobuf/Parser; = null
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;",
            ">;"
        }
    .end annotation
.end field

.field public static final SOLUTION_EVENT_FIELD_NUMBER:I = 0x2

.field public static final SYSTEM_INFO_FIELD_NUMBER:I = 0x1


# instance fields
.field private bitField0_:I

.field private solutionEvent_:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent;

.field private systemInfo_:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 508
    new-instance v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;

    invoke-direct {v0}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;-><init>()V

    .line 511
    sput-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;

    .line 512
    const-class v1, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 65
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    return-void
.end method

.method static synthetic access$000()Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;
    .locals 1

    .line 60
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;

    return-object v0
.end method

.method static synthetic access$100(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;)V
    .locals 0

    .line 60
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->setSystemInfo(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;)V

    return-void
.end method

.method static synthetic access$200(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;)V
    .locals 0

    .line 60
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->mergeSystemInfo(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;)V

    return-void
.end method

.method static synthetic access$300(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;)V
    .locals 0

    .line 60
    invoke-direct {p0}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->clearSystemInfo()V

    return-void
.end method

.method static synthetic access$400(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent;)V
    .locals 0

    .line 60
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->setSolutionEvent(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent;)V

    return-void
.end method

.method static synthetic access$500(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent;)V
    .locals 0

    .line 60
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->mergeSolutionEvent(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent;)V

    return-void
.end method

.method static synthetic access$600(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;)V
    .locals 0

    .line 60
    invoke-direct {p0}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->clearSolutionEvent()V

    return-void
.end method

.method private clearSolutionEvent()V
    .locals 1

    const/4 v0, 0x0

    .line 201
    iput-object v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->solutionEvent_:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent;

    .line 202
    iget v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->bitField0_:I

    and-int/lit8 v0, v0, -0x3

    iput v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->bitField0_:I

    return-void
.end method

.method private clearSystemInfo()V
    .locals 1

    const/4 v0, 0x0

    .line 135
    iput-object v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->systemInfo_:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    .line 136
    iget v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->bitField0_:I

    and-int/lit8 v0, v0, -0x2

    iput v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->bitField0_:I

    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;
    .locals 1

    .line 517
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;

    return-object v0
.end method

.method private mergeSolutionEvent(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent;)V
    .locals 2

    .line 184
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 185
    iget-object v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->solutionEvent_:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent;

    if-eqz v0, :cond_0

    .line 186
    invoke-static {}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent;->getDefaultInstance()Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent;

    move-result-object v1

    if-eq v0, v1, :cond_0

    .line 187
    iget-object v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->solutionEvent_:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent;

    .line 188
    invoke-static {v0}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent;->newBuilder(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent$Builder;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent;

    iput-object p1, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->solutionEvent_:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent;

    goto :goto_0

    .line 190
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->solutionEvent_:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent;

    .line 192
    :goto_0
    iget p1, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->bitField0_:I

    or-int/lit8 p1, p1, 0x2

    iput p1, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->bitField0_:I

    return-void
.end method

.method private mergeSystemInfo(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;)V
    .locals 2

    .line 117
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 118
    iget-object v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->systemInfo_:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    if-eqz v0, :cond_0

    .line 119
    invoke-static {}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->getDefaultInstance()Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    move-result-object v1

    if-eq v0, v1, :cond_0

    .line 120
    iget-object v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->systemInfo_:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    .line 121
    invoke-static {v0}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->newBuilder(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo$Builder;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    iput-object p1, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->systemInfo_:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    goto :goto_0

    .line 123
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->systemInfo_:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    .line 125
    :goto_0
    iget p1, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->bitField0_:I

    or-int/lit8 p1, p1, 0x1

    iput p1, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->bitField0_:I

    return-void
.end method

.method public static newBuilder()Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension$Builder;
    .locals 1

    .line 282
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension$Builder;
    .locals 1

    .line 285
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;
    .locals 1

    .line 258
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;
    .locals 1

    .line 265
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;
    .locals 1

    .line 221
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;
    .locals 1

    .line 228
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;
    .locals 1

    .line 270
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;
    .locals 1

    .line 277
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;
    .locals 1

    .line 245
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;
    .locals 1

    .line 252
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;
    .locals 1

    .line 208
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;
    .locals 1

    .line 215
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;
    .locals 1

    .line 233
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;
    .locals 1

    .line 240
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;",
            ">;"
        }
    .end annotation

    .line 523
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private setSolutionEvent(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent;)V
    .locals 0

    .line 171
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 172
    iput-object p1, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->solutionEvent_:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent;

    .line 173
    iget p1, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->bitField0_:I

    or-int/lit8 p1, p1, 0x2

    iput p1, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->bitField0_:I

    return-void
.end method

.method private setSystemInfo(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;)V
    .locals 0

    .line 103
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 104
    iput-object p1, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->systemInfo_:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    .line 105
    iget p1, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->bitField0_:I

    or-int/lit8 p1, p1, 0x1

    iput p1, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->bitField0_:I

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 457
    sget-object p2, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p2, p1

    const/4 p2, 0x0

    packed-switch p1, :pswitch_data_0

    .line 501
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    invoke-direct {p1}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw p1

    :pswitch_0
    return-object p2

    :pswitch_1
    const/4 p1, 0x1

    .line 495
    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 480
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 482
    const-class p2, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;

    monitor-enter p2

    .line 483
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_0

    .line 485
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 488
    sput-object p1, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 490
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

    .line 477
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;

    return-object p1

    .line 465
    :pswitch_4
    const-string p1, "bitField0_"

    const-string p2, "systemInfo_"

    const-string p3, "solutionEvent_"

    filled-new-array {p1, p2, p3}, [Ljava/lang/Object;

    move-result-object p1

    .line 470
    const-string p2, "\u0001\u0002\u0000\u0001\u0001\u0002\u0002\u0000\u0000\u0000\u0001\u1009\u0000\u0002\u1009\u0001"

    .line 473
    sget-object p3, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;

    invoke-static {p3, p2, p1}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 462
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension$Builder;

    invoke-direct {p1, p2}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension$Builder;-><init>(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$1;)V

    return-object p1

    .line 459
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;

    invoke-direct {p1}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;-><init>()V

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

    .line 60
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getSolutionEvent()Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent;
    .locals 1

    .line 161
    iget-object v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->solutionEvent_:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent;

    if-nez v0, :cond_0

    invoke-static {}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent;->getDefaultInstance()Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent;

    move-result-object v0

    :cond_0
    return-object v0
.end method

.method public getSystemInfo()Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;
    .locals 1

    .line 92
    iget-object v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->systemInfo_:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    if-nez v0, :cond_0

    invoke-static {}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->getDefaultInstance()Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    move-result-object v0

    :cond_0
    return-object v0
.end method

.method public hasSolutionEvent()Z
    .locals 1

    .line 150
    iget v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->bitField0_:I

    and-int/lit8 v0, v0, 0x2

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasSystemInfo()Z
    .locals 2

    .line 80
    iget v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->bitField0_:I

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

    .line 60
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 60
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
