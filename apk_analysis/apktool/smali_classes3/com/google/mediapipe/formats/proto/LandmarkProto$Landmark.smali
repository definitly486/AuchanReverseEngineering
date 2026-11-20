.class public final Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "LandmarkProto.java"

# interfaces
.implements Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/formats/proto/LandmarkProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Landmark"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;",
        "Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark$Builder;",
        ">;",
        "Lcom/google/mediapipe/formats/proto/LandmarkProto$LandmarkOrBuilder;"
    }
.end annotation


# static fields
.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

.field private static volatile PARSER:Lcom/google/protobuf/Parser; = null
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;",
            ">;"
        }
    .end annotation
.end field

.field public static final PRESENCE_FIELD_NUMBER:I = 0x5

.field public static final VISIBILITY_FIELD_NUMBER:I = 0x4

.field public static final X_FIELD_NUMBER:I = 0x1

.field public static final Y_FIELD_NUMBER:I = 0x2

.field public static final Z_FIELD_NUMBER:I = 0x3


# instance fields
.field private bitField0_:I

.field private presence_:F

.field private visibility_:F

.field private x_:F

.field private y_:F

.field private z_:F


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 763
    new-instance v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

    invoke-direct {v0}, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;-><init>()V

    .line 766
    sput-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

    .line 767
    const-class v1, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 118
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    return-void
.end method

.method static synthetic access$000()Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;
    .locals 1

    .line 113
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

    return-object v0
.end method

.method static synthetic access$100(Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;F)V
    .locals 0

    .line 113
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->setX(F)V

    return-void
.end method

.method static synthetic access$1000(Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;)V
    .locals 0

    .line 113
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->clearPresence()V

    return-void
.end method

.method static synthetic access$200(Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;)V
    .locals 0

    .line 113
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->clearX()V

    return-void
.end method

.method static synthetic access$300(Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;F)V
    .locals 0

    .line 113
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->setY(F)V

    return-void
.end method

.method static synthetic access$400(Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;)V
    .locals 0

    .line 113
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->clearY()V

    return-void
.end method

.method static synthetic access$500(Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;F)V
    .locals 0

    .line 113
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->setZ(F)V

    return-void
.end method

.method static synthetic access$600(Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;)V
    .locals 0

    .line 113
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->clearZ()V

    return-void
.end method

.method static synthetic access$700(Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;F)V
    .locals 0

    .line 113
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->setVisibility(F)V

    return-void
.end method

.method static synthetic access$800(Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;)V
    .locals 0

    .line 113
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->clearVisibility()V

    return-void
.end method

.method static synthetic access$900(Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;F)V
    .locals 0

    .line 113
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->setPresence(F)V

    return-void
.end method

.method private clearPresence()V
    .locals 1

    .line 351
    iget v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->bitField0_:I

    and-int/lit8 v0, v0, -0x11

    iput v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->bitField0_:I

    const/4 v0, 0x0

    .line 352
    iput v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->presence_:F

    return-void
.end method

.method private clearVisibility()V
    .locals 1

    .line 285
    iget v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->bitField0_:I

    and-int/lit8 v0, v0, -0x9

    iput v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->bitField0_:I

    const/4 v0, 0x0

    .line 286
    iput v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->visibility_:F

    return-void
.end method

.method private clearX()V
    .locals 1

    .line 151
    iget v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->bitField0_:I

    and-int/lit8 v0, v0, -0x2

    iput v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->bitField0_:I

    const/4 v0, 0x0

    .line 152
    iput v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->x_:F

    return-void
.end method

.method private clearY()V
    .locals 1

    .line 185
    iget v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->bitField0_:I

    and-int/lit8 v0, v0, -0x3

    iput v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->bitField0_:I

    const/4 v0, 0x0

    .line 186
    iput v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->y_:F

    return-void
.end method

.method private clearZ()V
    .locals 1

    .line 219
    iget v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->bitField0_:I

    and-int/lit8 v0, v0, -0x5

    iput v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->bitField0_:I

    const/4 v0, 0x0

    .line 220
    iput v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->z_:F

    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;
    .locals 1

    .line 772
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

    return-object v0
.end method

.method public static newBuilder()Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark$Builder;
    .locals 1

    .line 432
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;)Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark$Builder;
    .locals 1

    .line 435
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;
    .locals 1

    .line 408
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;
    .locals 1

    .line 415
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;
    .locals 1

    .line 371
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;
    .locals 1

    .line 378
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;
    .locals 1

    .line 420
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;
    .locals 1

    .line 427
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;
    .locals 1

    .line 395
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;
    .locals 1

    .line 402
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;
    .locals 1

    .line 358
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;
    .locals 1

    .line 365
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;
    .locals 1

    .line 383
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;
    .locals 1

    .line 390
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;",
            ">;"
        }
    .end annotation

    .line 778
    sget-object v0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private setPresence(F)V
    .locals 1

    .line 336
    iget v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->bitField0_:I

    or-int/lit8 v0, v0, 0x10

    iput v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->bitField0_:I

    .line 337
    iput p1, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->presence_:F

    return-void
.end method

.method private setVisibility(F)V
    .locals 1

    .line 270
    iget v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->bitField0_:I

    or-int/lit8 v0, v0, 0x8

    iput v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->bitField0_:I

    .line 271
    iput p1, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->visibility_:F

    return-void
.end method

.method private setX(F)V
    .locals 1

    .line 144
    iget v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->bitField0_:I

    or-int/lit8 v0, v0, 0x1

    iput v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->bitField0_:I

    .line 145
    iput p1, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->x_:F

    return-void
.end method

.method private setY(F)V
    .locals 1

    .line 178
    iget v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->bitField0_:I

    or-int/lit8 v0, v0, 0x2

    iput v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->bitField0_:I

    .line 179
    iput p1, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->y_:F

    return-void
.end method

.method private setZ(F)V
    .locals 1

    .line 212
    iget v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->bitField0_:I

    or-int/lit8 v0, v0, 0x4

    iput v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->bitField0_:I

    .line 213
    iput p1, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->z_:F

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 6

    .line 709
    sget-object p2, Lcom/google/mediapipe/formats/proto/LandmarkProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p2, p1

    const/4 p2, 0x0

    packed-switch p1, :pswitch_data_0

    .line 756
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    invoke-direct {p1}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw p1

    :pswitch_0
    return-object p2

    :pswitch_1
    const/4 p1, 0x1

    .line 750
    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 735
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 737
    const-class p2, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

    monitor-enter p2

    .line 738
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_0

    .line 740
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 743
    sput-object p1, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_0

    :catchall_0
    move-exception v0

    move-object p1, v0

    goto :goto_1

    .line 745
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

    .line 732
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

    return-object p1

    .line 717
    :pswitch_4
    const-string v0, "bitField0_"

    const-string v1, "x_"

    const-string v2, "y_"

    const-string v3, "z_"

    const-string v4, "visibility_"

    const-string v5, "presence_"

    filled-new-array/range {v0 .. v5}, [Ljava/lang/Object;

    move-result-object p1

    .line 725
    const-string p2, "\u0001\u0005\u0000\u0001\u0001\u0005\u0005\u0000\u0000\u0000\u0001\u1001\u0000\u0002\u1001\u0001\u0003\u1001\u0002\u0004\u1001\u0003\u0005\u1001\u0004"

    .line 728
    sget-object p3, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

    invoke-static {p3, p2, p1}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 714
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark$Builder;

    invoke-direct {p1, p2}, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark$Builder;-><init>(Lcom/google/mediapipe/formats/proto/LandmarkProto$1;)V

    return-object p1

    .line 711
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;

    invoke-direct {p1}, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;-><init>()V

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

    .line 113
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getPresence()F
    .locals 1

    .line 321
    iget v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->presence_:F

    return v0
.end method

.method public getVisibility()F
    .locals 1

    .line 255
    iget v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->visibility_:F

    return v0
.end method

.method public getX()F
    .locals 1

    .line 137
    iget v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->x_:F

    return v0
.end method

.method public getY()F
    .locals 1

    .line 171
    iget v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->y_:F

    return v0
.end method

.method public getZ()F
    .locals 1

    .line 205
    iget v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->z_:F

    return v0
.end method

.method public hasPresence()Z
    .locals 1

    .line 305
    iget v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->bitField0_:I

    and-int/lit8 v0, v0, 0x10

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasVisibility()Z
    .locals 1

    .line 239
    iget v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->bitField0_:I

    and-int/lit8 v0, v0, 0x8

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasX()Z
    .locals 2

    .line 129
    iget v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->bitField0_:I

    const/4 v1, 0x1

    and-int/2addr v0, v1

    if-eqz v0, :cond_0

    return v1

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasY()Z
    .locals 1

    .line 163
    iget v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->bitField0_:I

    and-int/lit8 v0, v0, 0x2

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasZ()Z
    .locals 1

    .line 197
    iget v0, p0, Lcom/google/mediapipe/formats/proto/LandmarkProto$Landmark;->bitField0_:I

    and-int/lit8 v0, v0, 0x4

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public bridge synthetic newBuilderForType()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 113
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 113
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
