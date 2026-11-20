.class public final Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "CalculatorProto.java"

# interfaces
.implements Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfoOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/proto/CalculatorProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "InputStreamInfo"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;",
        "Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo$Builder;",
        ">;",
        "Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfoOrBuilder;"
    }
.end annotation


# static fields
.field public static final BACK_EDGE_FIELD_NUMBER:I = 0x2

.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;

.field private static volatile PARSER:Lcom/google/protobuf/Parser; = null
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;",
            ">;"
        }
    .end annotation
.end field

.field public static final TAG_INDEX_FIELD_NUMBER:I = 0x1


# instance fields
.field private backEdge_:Z

.field private tagIndex_:Ljava/lang/String;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 3441
    new-instance v0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;

    invoke-direct {v0}, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;-><init>()V

    .line 3444
    sput-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;

    .line 3445
    const-class v1, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    .line 2910
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    .line 2911
    const-string v0, ""

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->tagIndex_:Ljava/lang/String;

    return-void
.end method

.method static synthetic access$4000()Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;
    .locals 1

    .line 2905
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;

    return-object v0
.end method

.method static synthetic access$4100(Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;Ljava/lang/String;)V
    .locals 0

    .line 2905
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->setTagIndex(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$4200(Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;)V
    .locals 0

    .line 2905
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->clearTagIndex()V

    return-void
.end method

.method static synthetic access$4300(Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 2905
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->setTagIndexBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method static synthetic access$4400(Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;Z)V
    .locals 0

    .line 2905
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->setBackEdge(Z)V

    return-void
.end method

.method static synthetic access$4500(Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;)V
    .locals 0

    .line 2905
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->clearBackEdge()V

    return-void
.end method

.method private clearBackEdge()V
    .locals 1

    const/4 v0, 0x0

    .line 3093
    iput-boolean v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->backEdge_:Z

    return-void
.end method

.method private clearTagIndex()V
    .locals 1

    .line 3011
    invoke-static {}, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->getDefaultInstance()Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;

    move-result-object v0

    invoke-virtual {v0}, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->getTagIndex()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->tagIndex_:Ljava/lang/String;

    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;
    .locals 1

    .line 3450
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;

    return-object v0
.end method

.method public static newBuilder()Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo$Builder;
    .locals 1

    .line 3173
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;)Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo$Builder;
    .locals 1

    .line 3176
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;
    .locals 1

    .line 3149
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;
    .locals 1

    .line 3156
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;
    .locals 1

    .line 3112
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;
    .locals 1

    .line 3119
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;
    .locals 1

    .line 3161
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;
    .locals 1

    .line 3168
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;
    .locals 1

    .line 3136
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;
    .locals 1

    .line 3143
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;
    .locals 1

    .line 3099
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;
    .locals 1

    .line 3106
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;
    .locals 1

    .line 3124
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;
    .locals 1

    .line 3131
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;",
            ">;"
        }
    .end annotation

    .line 3456
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private setBackEdge(Z)V
    .locals 0

    .line 3076
    iput-boolean p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->backEdge_:Z

    return-void
.end method

.method private setTagIndex(Ljava/lang/String;)V
    .locals 0

    .line 2986
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 2988
    iput-object p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->tagIndex_:Ljava/lang/String;

    return-void
.end method

.method private setTagIndexBytes(Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 3035
    invoke-static {p1}, Lcom/google/protobuf/AbstractMessageLite;->checkByteStringIsUtf8(Lcom/google/protobuf/ByteString;)V

    .line 3036
    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->tagIndex_:Ljava/lang/String;

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 3391
    sget-object p2, Lcom/google/mediapipe/proto/CalculatorProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p2, p1

    const/4 p2, 0x0

    packed-switch p1, :pswitch_data_0

    .line 3434
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    invoke-direct {p1}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw p1

    :pswitch_0
    return-object p2

    :pswitch_1
    const/4 p1, 0x1

    .line 3428
    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 3413
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 3415
    const-class p2, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;

    monitor-enter p2

    .line 3416
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_0

    .line 3418
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 3421
    sput-object p1, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 3423
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

    .line 3410
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;

    return-object p1

    .line 3399
    :pswitch_4
    const-string p1, "tagIndex_"

    const-string p2, "backEdge_"

    filled-new-array {p1, p2}, [Ljava/lang/Object;

    move-result-object p1

    .line 3403
    const-string p2, "\u0000\u0002\u0000\u0000\u0001\u0002\u0002\u0000\u0000\u0000\u0001\u0208\u0002\u0007"

    .line 3406
    sget-object p3, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;

    invoke-static {p3, p2, p1}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 3396
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo$Builder;

    invoke-direct {p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo$Builder;-><init>(Lcom/google/mediapipe/proto/CalculatorProto$1;)V

    return-object p1

    .line 3393
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;

    invoke-direct {p1}, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;-><init>()V

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

.method public getBackEdge()Z
    .locals 1

    .line 3058
    iget-boolean v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->backEdge_:Z

    return v0
.end method

.method public bridge synthetic getDefaultInstanceForType()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 2905
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getTagIndex()Ljava/lang/String;
    .locals 1

    .line 2937
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->tagIndex_:Ljava/lang/String;

    return-object v0
.end method

.method public getTagIndexBytes()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 2962
    iget-object v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$InputStreamInfo;->tagIndex_:Ljava/lang/String;

    invoke-static {v0}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic newBuilderForType()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 2905
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 2905
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
