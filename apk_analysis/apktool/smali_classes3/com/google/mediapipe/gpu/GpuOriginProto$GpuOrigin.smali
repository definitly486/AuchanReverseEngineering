.class public final Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "GpuOriginProto.java"

# interfaces
.implements Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOriginOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/gpu/GpuOriginProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "GpuOrigin"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin$Builder;,
        Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin$Mode;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;",
        "Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin$Builder;",
        ">;",
        "Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOriginOrBuilder;"
    }
.end annotation


# static fields
.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;

.field private static volatile PARSER:Lcom/google/protobuf/Parser;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;",
            ">;"
        }
    .end annotation
.end field


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 302
    new-instance v0, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;

    invoke-direct {v0}, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;-><init>()V

    .line 305
    sput-object v0, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;->DEFAULT_INSTANCE:Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;

    .line 306
    const-class v1, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 25
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    return-void
.end method

.method static synthetic access$000()Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;
    .locals 1

    .line 20
    sget-object v0, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;->DEFAULT_INSTANCE:Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;

    return-object v0
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;
    .locals 1

    .line 311
    sget-object v0, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;->DEFAULT_INSTANCE:Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;

    return-object v0
.end method

.method public static newBuilder()Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin$Builder;
    .locals 1

    .line 230
    sget-object v0, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;->DEFAULT_INSTANCE:Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;)Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin$Builder;
    .locals 1

    .line 233
    sget-object v0, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;->DEFAULT_INSTANCE:Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;
    .locals 1

    .line 206
    sget-object v0, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;->DEFAULT_INSTANCE:Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;
    .locals 1

    .line 213
    sget-object v0, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;->DEFAULT_INSTANCE:Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;
    .locals 1

    .line 169
    sget-object v0, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;->DEFAULT_INSTANCE:Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;
    .locals 1

    .line 176
    sget-object v0, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;->DEFAULT_INSTANCE:Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;
    .locals 1

    .line 218
    sget-object v0, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;->DEFAULT_INSTANCE:Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;
    .locals 1

    .line 225
    sget-object v0, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;->DEFAULT_INSTANCE:Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;
    .locals 1

    .line 193
    sget-object v0, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;->DEFAULT_INSTANCE:Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;
    .locals 1

    .line 200
    sget-object v0, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;->DEFAULT_INSTANCE:Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;
    .locals 1

    .line 156
    sget-object v0, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;->DEFAULT_INSTANCE:Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;
    .locals 1

    .line 163
    sget-object v0, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;->DEFAULT_INSTANCE:Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;
    .locals 1

    .line 181
    sget-object v0, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;->DEFAULT_INSTANCE:Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;
    .locals 1

    .line 188
    sget-object v0, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;->DEFAULT_INSTANCE:Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;",
            ">;"
        }
    .end annotation

    .line 317
    sget-object v0, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;->DEFAULT_INSTANCE:Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 257
    sget-object p2, Lcom/google/mediapipe/gpu/GpuOriginProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p2, p1

    const/4 p2, 0x0

    packed-switch p1, :pswitch_data_0

    .line 295
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    invoke-direct {p1}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw p1

    :pswitch_0
    return-object p2

    :pswitch_1
    const/4 p1, 0x1

    .line 289
    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 274
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 276
    const-class p2, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;

    monitor-enter p2

    .line 277
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_0

    .line 279
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;->DEFAULT_INSTANCE:Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 282
    sput-object p1, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 284
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

    .line 271
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;->DEFAULT_INSTANCE:Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;

    return-object p1

    .line 265
    :pswitch_4
    const-string p1, "\u0000\u0000"

    .line 267
    sget-object p3, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;->DEFAULT_INSTANCE:Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;

    invoke-static {p3, p1, p2}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 262
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin$Builder;

    invoke-direct {p1, p2}, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin$Builder;-><init>(Lcom/google/mediapipe/gpu/GpuOriginProto$1;)V

    return-object p1

    .line 259
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;

    invoke-direct {p1}, Lcom/google/mediapipe/gpu/GpuOriginProto$GpuOrigin;-><init>()V

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

    .line 20
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic newBuilderForType()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 20
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 20
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
