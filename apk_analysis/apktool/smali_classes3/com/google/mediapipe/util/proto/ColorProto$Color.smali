.class public final Lcom/google/mediapipe/util/proto/ColorProto$Color;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "ColorProto.java"

# interfaces
.implements Lcom/google/mediapipe/util/proto/ColorProto$ColorOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/util/proto/ColorProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Color"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/util/proto/ColorProto$Color$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/util/proto/ColorProto$Color;",
        "Lcom/google/mediapipe/util/proto/ColorProto$Color$Builder;",
        ">;",
        "Lcom/google/mediapipe/util/proto/ColorProto$ColorOrBuilder;"
    }
.end annotation


# static fields
.field public static final B_FIELD_NUMBER:I = 0x3

.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$Color;

.field public static final G_FIELD_NUMBER:I = 0x2

.field private static volatile PARSER:Lcom/google/protobuf/Parser; = null
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/util/proto/ColorProto$Color;",
            ">;"
        }
    .end annotation
.end field

.field public static final R_FIELD_NUMBER:I = 0x1


# instance fields
.field private b_:I

.field private bitField0_:I

.field private g_:I

.field private r_:I


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 427
    new-instance v0, Lcom/google/mediapipe/util/proto/ColorProto$Color;

    invoke-direct {v0}, Lcom/google/mediapipe/util/proto/ColorProto$Color;-><init>()V

    .line 430
    sput-object v0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$Color;

    .line 431
    const-class v1, Lcom/google/mediapipe/util/proto/ColorProto$Color;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 58
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    return-void
.end method

.method static synthetic access$000()Lcom/google/mediapipe/util/proto/ColorProto$Color;
    .locals 1

    .line 53
    sget-object v0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$Color;

    return-object v0
.end method

.method static synthetic access$100(Lcom/google/mediapipe/util/proto/ColorProto$Color;I)V
    .locals 0

    .line 53
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/ColorProto$Color;->setR(I)V

    return-void
.end method

.method static synthetic access$200(Lcom/google/mediapipe/util/proto/ColorProto$Color;)V
    .locals 0

    .line 53
    invoke-direct {p0}, Lcom/google/mediapipe/util/proto/ColorProto$Color;->clearR()V

    return-void
.end method

.method static synthetic access$300(Lcom/google/mediapipe/util/proto/ColorProto$Color;I)V
    .locals 0

    .line 53
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/ColorProto$Color;->setG(I)V

    return-void
.end method

.method static synthetic access$400(Lcom/google/mediapipe/util/proto/ColorProto$Color;)V
    .locals 0

    .line 53
    invoke-direct {p0}, Lcom/google/mediapipe/util/proto/ColorProto$Color;->clearG()V

    return-void
.end method

.method static synthetic access$500(Lcom/google/mediapipe/util/proto/ColorProto$Color;I)V
    .locals 0

    .line 53
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/ColorProto$Color;->setB(I)V

    return-void
.end method

.method static synthetic access$600(Lcom/google/mediapipe/util/proto/ColorProto$Color;)V
    .locals 0

    .line 53
    invoke-direct {p0}, Lcom/google/mediapipe/util/proto/ColorProto$Color;->clearB()V

    return-void
.end method

.method private clearB()V
    .locals 1

    .line 159
    iget v0, p0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->bitField0_:I

    and-int/lit8 v0, v0, -0x5

    iput v0, p0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->bitField0_:I

    const/4 v0, 0x0

    .line 160
    iput v0, p0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->b_:I

    return-void
.end method

.method private clearG()V
    .locals 1

    .line 125
    iget v0, p0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->bitField0_:I

    and-int/lit8 v0, v0, -0x3

    iput v0, p0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->bitField0_:I

    const/4 v0, 0x0

    .line 126
    iput v0, p0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->g_:I

    return-void
.end method

.method private clearR()V
    .locals 1

    .line 91
    iget v0, p0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->bitField0_:I

    and-int/lit8 v0, v0, -0x2

    iput v0, p0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->bitField0_:I

    const/4 v0, 0x0

    .line 92
    iput v0, p0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->r_:I

    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/util/proto/ColorProto$Color;
    .locals 1

    .line 436
    sget-object v0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$Color;

    return-object v0
.end method

.method public static newBuilder()Lcom/google/mediapipe/util/proto/ColorProto$Color$Builder;
    .locals 1

    .line 240
    sget-object v0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$Color;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/util/proto/ColorProto$Color$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/util/proto/ColorProto$Color;)Lcom/google/mediapipe/util/proto/ColorProto$Color$Builder;
    .locals 1

    .line 243
    sget-object v0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$Color;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/ColorProto$Color$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/util/proto/ColorProto$Color;
    .locals 1

    .line 216
    sget-object v0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$Color;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/ColorProto$Color;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/util/proto/ColorProto$Color;
    .locals 1

    .line 223
    sget-object v0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$Color;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/ColorProto$Color;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/util/proto/ColorProto$Color;
    .locals 1

    .line 179
    sget-object v0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$Color;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/ColorProto$Color;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/util/proto/ColorProto$Color;
    .locals 1

    .line 186
    sget-object v0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$Color;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/ColorProto$Color;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/util/proto/ColorProto$Color;
    .locals 1

    .line 228
    sget-object v0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$Color;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/ColorProto$Color;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/util/proto/ColorProto$Color;
    .locals 1

    .line 235
    sget-object v0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$Color;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/ColorProto$Color;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/util/proto/ColorProto$Color;
    .locals 1

    .line 203
    sget-object v0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$Color;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/ColorProto$Color;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/util/proto/ColorProto$Color;
    .locals 1

    .line 210
    sget-object v0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$Color;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/ColorProto$Color;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/util/proto/ColorProto$Color;
    .locals 1

    .line 166
    sget-object v0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$Color;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/ColorProto$Color;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/util/proto/ColorProto$Color;
    .locals 1

    .line 173
    sget-object v0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$Color;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/ColorProto$Color;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/util/proto/ColorProto$Color;
    .locals 1

    .line 191
    sget-object v0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$Color;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/ColorProto$Color;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/util/proto/ColorProto$Color;
    .locals 1

    .line 198
    sget-object v0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$Color;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/ColorProto$Color;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/util/proto/ColorProto$Color;",
            ">;"
        }
    .end annotation

    .line 442
    sget-object v0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$Color;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private setB(I)V
    .locals 1

    .line 152
    iget v0, p0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->bitField0_:I

    or-int/lit8 v0, v0, 0x4

    iput v0, p0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->bitField0_:I

    .line 153
    iput p1, p0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->b_:I

    return-void
.end method

.method private setG(I)V
    .locals 1

    .line 118
    iget v0, p0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->bitField0_:I

    or-int/lit8 v0, v0, 0x2

    iput v0, p0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->bitField0_:I

    .line 119
    iput p1, p0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->g_:I

    return-void
.end method

.method private setR(I)V
    .locals 1

    .line 84
    iget v0, p0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->bitField0_:I

    or-int/lit8 v0, v0, 0x1

    iput v0, p0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->bitField0_:I

    .line 85
    iput p1, p0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->r_:I

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 1

    .line 375
    sget-object p2, Lcom/google/mediapipe/util/proto/ColorProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p2, p1

    const/4 p2, 0x0

    packed-switch p1, :pswitch_data_0

    .line 420
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    invoke-direct {p1}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw p1

    :pswitch_0
    return-object p2

    :pswitch_1
    const/4 p1, 0x1

    .line 414
    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 399
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/util/proto/ColorProto$Color;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 401
    const-class p2, Lcom/google/mediapipe/util/proto/ColorProto$Color;

    monitor-enter p2

    .line 402
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/util/proto/ColorProto$Color;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_0

    .line 404
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/util/proto/ColorProto$Color;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$Color;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 407
    sput-object p1, Lcom/google/mediapipe/util/proto/ColorProto$Color;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 409
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

    .line 396
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/util/proto/ColorProto$Color;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$Color;

    return-object p1

    .line 383
    :pswitch_4
    const-string p1, "bitField0_"

    const-string p2, "r_"

    const-string p3, "g_"

    const-string v0, "b_"

    filled-new-array {p1, p2, p3, v0}, [Ljava/lang/Object;

    move-result-object p1

    .line 389
    const-string p2, "\u0001\u0003\u0000\u0001\u0001\u0003\u0003\u0000\u0000\u0000\u0001\u1004\u0000\u0002\u1004\u0001\u0003\u1004\u0002"

    .line 392
    sget-object p3, Lcom/google/mediapipe/util/proto/ColorProto$Color;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$Color;

    invoke-static {p3, p2, p1}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 380
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/util/proto/ColorProto$Color$Builder;

    invoke-direct {p1, p2}, Lcom/google/mediapipe/util/proto/ColorProto$Color$Builder;-><init>(Lcom/google/mediapipe/util/proto/ColorProto$1;)V

    return-object p1

    .line 377
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/util/proto/ColorProto$Color;

    invoke-direct {p1}, Lcom/google/mediapipe/util/proto/ColorProto$Color;-><init>()V

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

.method public getB()I
    .locals 1

    .line 145
    iget v0, p0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->b_:I

    return v0
.end method

.method public bridge synthetic getDefaultInstanceForType()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 53
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getG()I
    .locals 1

    .line 111
    iget v0, p0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->g_:I

    return v0
.end method

.method public getR()I
    .locals 1

    .line 77
    iget v0, p0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->r_:I

    return v0
.end method

.method public hasB()Z
    .locals 1

    .line 137
    iget v0, p0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->bitField0_:I

    and-int/lit8 v0, v0, 0x4

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasG()Z
    .locals 1

    .line 103
    iget v0, p0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->bitField0_:I

    and-int/lit8 v0, v0, 0x2

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasR()Z
    .locals 2

    .line 69
    iget v0, p0, Lcom/google/mediapipe/util/proto/ColorProto$Color;->bitField0_:I

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

    .line 53
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 53
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
