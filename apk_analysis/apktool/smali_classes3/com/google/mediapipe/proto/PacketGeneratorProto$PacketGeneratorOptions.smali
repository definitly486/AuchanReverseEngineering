.class public final Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;
.super Lcom/google/protobuf/GeneratedMessageLite$ExtendableMessage;
.source "PacketGeneratorProto.java"

# interfaces
.implements Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptionsOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/proto/PacketGeneratorProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "PacketGeneratorOptions"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite$ExtendableMessage<",
        "Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;",
        "Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions$Builder;",
        ">;",
        "Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptionsOrBuilder;"
    }
.end annotation

.annotation runtime Ljava/lang/Deprecated;
.end annotation


# static fields
.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

.field public static final MERGE_FIELDS_FIELD_NUMBER:I = 0x1

.field private static volatile PARSER:Lcom/google/protobuf/Parser;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;",
            ">;"
        }
    .end annotation
.end field


# instance fields
.field private bitField0_:I

.field private memoizedIsInitialized:B

.field private mergeFields_:Z


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 325
    new-instance v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    invoke-direct {v0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;-><init>()V

    .line 328
    sput-object v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    .line 329
    const-class v1, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    .line 52
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite$ExtendableMessage;-><init>()V

    const/4 v0, 0x2

    .line 269
    iput-byte v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->memoizedIsInitialized:B

    const/4 v0, 0x1

    .line 53
    iput-boolean v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->mergeFields_:Z

    return-void
.end method

.method static synthetic access$000()Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;
    .locals 1

    .line 47
    sget-object v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    return-object v0
.end method

.method static synthetic access$100(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;Z)V
    .locals 0

    .line 47
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->setMergeFields(Z)V

    return-void
.end method

.method static synthetic access$200(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;)V
    .locals 0

    .line 47
    invoke-direct {p0}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->clearMergeFields()V

    return-void
.end method

.method private clearMergeFields()V
    .locals 1

    .line 106
    iget v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->bitField0_:I

    and-int/lit8 v0, v0, -0x2

    iput v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->bitField0_:I

    const/4 v0, 0x1

    .line 107
    iput-boolean v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->mergeFields_:Z

    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;
    .locals 1

    .line 334
    sget-object v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    return-object v0
.end method

.method public static newBuilder()Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions$Builder;
    .locals 1

    .line 187
    sget-object v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions$Builder;
    .locals 1

    .line 190
    sget-object v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;
    .locals 1

    .line 163
    sget-object v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;
    .locals 1

    .line 170
    sget-object v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;
    .locals 1

    .line 126
    sget-object v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;
    .locals 1

    .line 133
    sget-object v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;
    .locals 1

    .line 175
    sget-object v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;
    .locals 1

    .line 182
    sget-object v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;
    .locals 1

    .line 150
    sget-object v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;
    .locals 1

    .line 157
    sget-object v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;
    .locals 1

    .line 113
    sget-object v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;
    .locals 1

    .line 120
    sget-object v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;
    .locals 1

    .line 138
    sget-object v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;
    .locals 1

    .line 145
    sget-object v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;",
            ">;"
        }
    .end annotation

    .line 340
    sget-object v0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private setMergeFields(Z)V
    .locals 1

    .line 94
    iget v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->bitField0_:I

    or-int/lit8 v0, v0, 0x1

    iput v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->bitField0_:I

    .line 95
    iput-boolean p1, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->mergeFields_:Z

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 275
    sget-object p3, Lcom/google/mediapipe/proto/PacketGeneratorProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p3, p1

    const/4 p3, 0x0

    packed-switch p1, :pswitch_data_0

    .line 318
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    invoke-direct {p1}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw p1

    :pswitch_0
    if-nez p2, :cond_0

    const/4 p1, 0x0

    goto :goto_0

    :cond_0
    const/4 p1, 0x1

    :goto_0
    int-to-byte p1, p1

    .line 314
    iput-byte p1, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->memoizedIsInitialized:B

    return-object p3

    .line 311
    :pswitch_1
    iget-byte p1, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->memoizedIsInitialized:B

    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 296
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_2

    .line 298
    const-class p2, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    monitor-enter p2

    .line 299
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 301
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 304
    sput-object p1, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_1

    :catchall_0
    move-exception p1

    goto :goto_2

    .line 306
    :cond_1
    :goto_1
    monitor-exit p2

    return-object p1

    :goto_2
    monitor-exit p2
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw p1

    :cond_2
    return-object p1

    .line 293
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    return-object p1

    .line 283
    :pswitch_4
    const-string p1, "bitField0_"

    const-string p2, "mergeFields_"

    filled-new-array {p1, p2}, [Ljava/lang/Object;

    move-result-object p1

    .line 287
    const-string p2, "\u0001\u0001\u0000\u0001\u0001\u0001\u0001\u0000\u0000\u0000\u0001\u1007\u0000"

    .line 289
    sget-object p3, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    invoke-static {p3, p2, p1}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 280
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions$Builder;

    invoke-direct {p1, p3}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions$Builder;-><init>(Lcom/google/mediapipe/proto/PacketGeneratorProto$1;)V

    return-object p1

    .line 277
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;

    invoke-direct {p1}, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;-><init>()V

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

.method public bridge synthetic getDefaultInstanceForType()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 47
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getMergeFields()Z
    .locals 1

    .line 82
    iget-boolean v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->mergeFields_:Z

    return v0
.end method

.method public hasMergeFields()Z
    .locals 2

    .line 69
    iget v0, p0, Lcom/google/mediapipe/proto/PacketGeneratorProto$PacketGeneratorOptions;->bitField0_:I

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

    .line 47
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 47
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
