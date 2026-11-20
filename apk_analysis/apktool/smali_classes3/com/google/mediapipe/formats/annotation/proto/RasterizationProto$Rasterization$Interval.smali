.class public final Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "RasterizationProto.java"

# interfaces
.implements Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$IntervalOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Interval"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;",
        "Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval$Builder;",
        ">;",
        "Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$IntervalOrBuilder;"
    }
.end annotation


# static fields
.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

.field public static final LEFT_X_FIELD_NUMBER:I = 0x2

.field private static volatile PARSER:Lcom/google/protobuf/Parser; = null
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;",
            ">;"
        }
    .end annotation
.end field

.field public static final RIGHT_X_FIELD_NUMBER:I = 0x3

.field public static final Y_FIELD_NUMBER:I = 0x1


# instance fields
.field private bitField0_:I

.field private leftX_:I

.field private memoizedIsInitialized:B

.field private rightX_:I

.field private y_:I


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 486
    new-instance v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

    invoke-direct {v0}, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;-><init>()V

    .line 489
    sput-object v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

    .line 490
    const-class v1, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    .line 115
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    const/4 v0, 0x2

    .line 427
    iput-byte v0, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->memoizedIsInitialized:B

    return-void
.end method

.method static synthetic access$000()Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;
    .locals 1

    .line 110
    sget-object v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

    return-object v0
.end method

.method static synthetic access$100(Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;I)V
    .locals 0

    .line 110
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->setY(I)V

    return-void
.end method

.method static synthetic access$200(Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;)V
    .locals 0

    .line 110
    invoke-direct {p0}, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->clearY()V

    return-void
.end method

.method static synthetic access$300(Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;I)V
    .locals 0

    .line 110
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->setLeftX(I)V

    return-void
.end method

.method static synthetic access$400(Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;)V
    .locals 0

    .line 110
    invoke-direct {p0}, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->clearLeftX()V

    return-void
.end method

.method static synthetic access$500(Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;I)V
    .locals 0

    .line 110
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->setRightX(I)V

    return-void
.end method

.method static synthetic access$600(Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;)V
    .locals 0

    .line 110
    invoke-direct {p0}, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->clearRightX()V

    return-void
.end method

.method private clearLeftX()V
    .locals 1

    .line 182
    iget v0, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->bitField0_:I

    and-int/lit8 v0, v0, -0x3

    iput v0, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->bitField0_:I

    const/4 v0, 0x0

    .line 183
    iput v0, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->leftX_:I

    return-void
.end method

.method private clearRightX()V
    .locals 1

    .line 216
    iget v0, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->bitField0_:I

    and-int/lit8 v0, v0, -0x5

    iput v0, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->bitField0_:I

    const/4 v0, 0x0

    .line 217
    iput v0, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->rightX_:I

    return-void
.end method

.method private clearY()V
    .locals 1

    .line 148
    iget v0, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->bitField0_:I

    and-int/lit8 v0, v0, -0x2

    iput v0, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->bitField0_:I

    const/4 v0, 0x0

    .line 149
    iput v0, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->y_:I

    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;
    .locals 1

    .line 495
    sget-object v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

    return-object v0
.end method

.method public static newBuilder()Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval$Builder;
    .locals 1

    .line 297
    sget-object v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;)Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval$Builder;
    .locals 1

    .line 300
    sget-object v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;
    .locals 1

    .line 273
    sget-object v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;
    .locals 1

    .line 280
    sget-object v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;
    .locals 1

    .line 236
    sget-object v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;
    .locals 1

    .line 243
    sget-object v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;
    .locals 1

    .line 285
    sget-object v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;
    .locals 1

    .line 292
    sget-object v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;
    .locals 1

    .line 260
    sget-object v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;
    .locals 1

    .line 267
    sget-object v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;
    .locals 1

    .line 223
    sget-object v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;
    .locals 1

    .line 230
    sget-object v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;
    .locals 1

    .line 248
    sget-object v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;
    .locals 1

    .line 255
    sget-object v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;",
            ">;"
        }
    .end annotation

    .line 501
    sget-object v0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private setLeftX(I)V
    .locals 1

    .line 175
    iget v0, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->bitField0_:I

    or-int/lit8 v0, v0, 0x2

    iput v0, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->bitField0_:I

    .line 176
    iput p1, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->leftX_:I

    return-void
.end method

.method private setRightX(I)V
    .locals 1

    .line 209
    iget v0, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->bitField0_:I

    or-int/lit8 v0, v0, 0x4

    iput v0, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->bitField0_:I

    .line 210
    iput p1, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->rightX_:I

    return-void
.end method

.method private setY(I)V
    .locals 1

    .line 141
    iget v0, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->bitField0_:I

    or-int/lit8 v0, v0, 0x1

    iput v0, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->bitField0_:I

    .line 142
    iput p1, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->y_:I

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 1

    .line 433
    sget-object p3, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p3, p1

    const/4 p3, 0x0

    packed-switch p1, :pswitch_data_0

    .line 479
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

    .line 475
    iput-byte p1, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->memoizedIsInitialized:B

    return-object p3

    .line 472
    :pswitch_1
    iget-byte p1, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->memoizedIsInitialized:B

    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 457
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_2

    .line 459
    const-class p2, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

    monitor-enter p2

    .line 460
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 462
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 465
    sput-object p1, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_1

    :catchall_0
    move-exception p1

    goto :goto_2

    .line 467
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

    .line 454
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

    return-object p1

    .line 441
    :pswitch_4
    const-string p1, "bitField0_"

    const-string p2, "y_"

    const-string p3, "leftX_"

    const-string v0, "rightX_"

    filled-new-array {p1, p2, p3, v0}, [Ljava/lang/Object;

    move-result-object p1

    .line 447
    const-string p2, "\u0001\u0003\u0000\u0001\u0001\u0003\u0003\u0000\u0000\u0003\u0001\u1504\u0000\u0002\u1504\u0001\u0003\u1504\u0002"

    .line 450
    sget-object p3, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

    invoke-static {p3, p2, p1}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 438
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval$Builder;

    invoke-direct {p1, p3}, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval$Builder;-><init>(Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$1;)V

    return-object p1

    .line 435
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;

    invoke-direct {p1}, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;-><init>()V

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

    .line 110
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getLeftX()I
    .locals 1

    .line 168
    iget v0, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->leftX_:I

    return v0
.end method

.method public getRightX()I
    .locals 1

    .line 202
    iget v0, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->rightX_:I

    return v0
.end method

.method public getY()I
    .locals 1

    .line 134
    iget v0, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->y_:I

    return v0
.end method

.method public hasLeftX()Z
    .locals 1

    .line 160
    iget v0, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->bitField0_:I

    and-int/lit8 v0, v0, 0x2

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasRightX()Z
    .locals 1

    .line 194
    iget v0, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->bitField0_:I

    and-int/lit8 v0, v0, 0x4

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasY()Z
    .locals 2

    .line 126
    iget v0, p0, Lcom/google/mediapipe/formats/annotation/proto/RasterizationProto$Rasterization$Interval;->bitField0_:I

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

    .line 110
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 110
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
