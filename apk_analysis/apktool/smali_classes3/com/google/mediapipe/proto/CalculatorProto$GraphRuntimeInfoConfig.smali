.class public final Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "CalculatorProto.java"

# interfaces
.implements Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfigOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/proto/CalculatorProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "GraphRuntimeInfoConfig"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;",
        "Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig$Builder;",
        ">;",
        "Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfigOrBuilder;"
    }
.end annotation


# static fields
.field public static final CAPTURE_PERIOD_MSEC_FIELD_NUMBER:I = 0x2

.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

.field public static final ENABLE_GRAPH_RUNTIME_INFO_FIELD_NUMBER:I = 0x1

.field private static volatile PARSER:Lcom/google/protobuf/Parser;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;",
            ">;"
        }
    .end annotation
.end field


# instance fields
.field private capturePeriodMsec_:I

.field private enableGraphRuntimeInfo_:Z


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 6087
    new-instance v0, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    invoke-direct {v0}, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;-><init>()V

    .line 6090
    sput-object v0, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    .line 6091
    const-class v1, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 5761
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    return-void
.end method

.method static synthetic access$8900()Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;
    .locals 1

    .line 5756
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    return-object v0
.end method

.method static synthetic access$9000(Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;Z)V
    .locals 0

    .line 5756
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;->setEnableGraphRuntimeInfo(Z)V

    return-void
.end method

.method static synthetic access$9100(Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;)V
    .locals 0

    .line 5756
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;->clearEnableGraphRuntimeInfo()V

    return-void
.end method

.method static synthetic access$9200(Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;I)V
    .locals 0

    .line 5756
    invoke-direct {p0, p1}, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;->setCapturePeriodMsec(I)V

    return-void
.end method

.method static synthetic access$9300(Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;)V
    .locals 0

    .line 5756
    invoke-direct {p0}, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;->clearCapturePeriodMsec()V

    return-void
.end method

.method private clearCapturePeriodMsec()V
    .locals 1

    const/4 v0, 0x0

    .line 5839
    iput v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;->capturePeriodMsec_:I

    return-void
.end method

.method private clearEnableGraphRuntimeInfo()V
    .locals 1

    const/4 v0, 0x0

    .line 5798
    iput-boolean v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;->enableGraphRuntimeInfo_:Z

    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;
    .locals 1

    .line 6096
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    return-object v0
.end method

.method public static newBuilder()Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig$Builder;
    .locals 1

    .line 5919
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;)Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig$Builder;
    .locals 1

    .line 5922
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;
    .locals 1

    .line 5895
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;
    .locals 1

    .line 5902
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;
    .locals 1

    .line 5858
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;
    .locals 1

    .line 5865
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;
    .locals 1

    .line 5907
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;
    .locals 1

    .line 5914
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;
    .locals 1

    .line 5882
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;
    .locals 1

    .line 5889
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;
    .locals 1

    .line 5845
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;
    .locals 1

    .line 5852
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;
    .locals 1

    .line 5870
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;
    .locals 1

    .line 5877
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;",
            ">;"
        }
    .end annotation

    .line 6102
    sget-object v0, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private setCapturePeriodMsec(I)V
    .locals 0

    .line 5827
    iput p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;->capturePeriodMsec_:I

    return-void
.end method

.method private setEnableGraphRuntimeInfo(Z)V
    .locals 0

    .line 5787
    iput-boolean p1, p0, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;->enableGraphRuntimeInfo_:Z

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 6037
    sget-object p2, Lcom/google/mediapipe/proto/CalculatorProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p2, p1

    const/4 p2, 0x0

    packed-switch p1, :pswitch_data_0

    .line 6080
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    invoke-direct {p1}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw p1

    :pswitch_0
    return-object p2

    :pswitch_1
    const/4 p1, 0x1

    .line 6074
    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 6059
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 6061
    const-class p2, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    monitor-enter p2

    .line 6062
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_0

    .line 6064
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 6067
    sput-object p1, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 6069
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

    .line 6056
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    return-object p1

    .line 6045
    :pswitch_4
    const-string p1, "enableGraphRuntimeInfo_"

    const-string p2, "capturePeriodMsec_"

    filled-new-array {p1, p2}, [Ljava/lang/Object;

    move-result-object p1

    .line 6049
    const-string p2, "\u0000\u0002\u0000\u0000\u0001\u0002\u0002\u0000\u0000\u0000\u0001\u0007\u0002\u000b"

    .line 6052
    sget-object p3, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;->DEFAULT_INSTANCE:Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    invoke-static {p3, p2, p1}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 6042
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig$Builder;

    invoke-direct {p1, p2}, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig$Builder;-><init>(Lcom/google/mediapipe/proto/CalculatorProto$1;)V

    return-object p1

    .line 6039
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;

    invoke-direct {p1}, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;-><init>()V

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

.method public getCapturePeriodMsec()I
    .locals 1

    .line 5814
    iget v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;->capturePeriodMsec_:I

    return v0
.end method

.method public bridge synthetic getDefaultInstanceForType()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 5756
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getEnableGraphRuntimeInfo()Z
    .locals 1

    .line 5775
    iget-boolean v0, p0, Lcom/google/mediapipe/proto/CalculatorProto$GraphRuntimeInfoConfig;->enableGraphRuntimeInfo_:Z

    return v0
.end method

.method public bridge synthetic newBuilderForType()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 5756
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 5756
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
