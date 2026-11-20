.class public final Lcom/google/mediapipe/formats/proto/RectProto$Rect;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "RectProto.java"

# interfaces
.implements Lcom/google/mediapipe/formats/proto/RectProto$RectOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/formats/proto/RectProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Rect"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/formats/proto/RectProto$Rect$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/formats/proto/RectProto$Rect;",
        "Lcom/google/mediapipe/formats/proto/RectProto$Rect$Builder;",
        ">;",
        "Lcom/google/mediapipe/formats/proto/RectProto$RectOrBuilder;"
    }
.end annotation


# static fields
.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/RectProto$Rect;

.field public static final HEIGHT_FIELD_NUMBER:I = 0x3

.field private static volatile PARSER:Lcom/google/protobuf/Parser; = null
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/formats/proto/RectProto$Rect;",
            ">;"
        }
    .end annotation
.end field

.field public static final RECT_ID_FIELD_NUMBER:I = 0x6

.field public static final ROTATION_FIELD_NUMBER:I = 0x5

.field public static final WIDTH_FIELD_NUMBER:I = 0x4

.field public static final X_CENTER_FIELD_NUMBER:I = 0x1

.field public static final Y_CENTER_FIELD_NUMBER:I = 0x2


# instance fields
.field private bitField0_:I

.field private height_:I

.field private memoizedIsInitialized:B

.field private rectId_:J

.field private rotation_:F

.field private width_:I

.field private xCenter_:I

.field private yCenter_:I


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 854
    new-instance v0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;

    invoke-direct {v0}, Lcom/google/mediapipe/formats/proto/RectProto$Rect;-><init>()V

    .line 857
    sput-object v0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/RectProto$Rect;

    .line 858
    const-class v1, Lcom/google/mediapipe/formats/proto/RectProto$Rect;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    .line 129
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    const/4 v0, 0x2

    .line 791
    iput-byte v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->memoizedIsInitialized:B

    return-void
.end method

.method static synthetic access$000()Lcom/google/mediapipe/formats/proto/RectProto$Rect;
    .locals 1

    .line 124
    sget-object v0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/RectProto$Rect;

    return-object v0
.end method

.method static synthetic access$100(Lcom/google/mediapipe/formats/proto/RectProto$Rect;I)V
    .locals 0

    .line 124
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->setXCenter(I)V

    return-void
.end method

.method static synthetic access$1000(Lcom/google/mediapipe/formats/proto/RectProto$Rect;)V
    .locals 0

    .line 124
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->clearRotation()V

    return-void
.end method

.method static synthetic access$1100(Lcom/google/mediapipe/formats/proto/RectProto$Rect;J)V
    .locals 0

    .line 124
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->setRectId(J)V

    return-void
.end method

.method static synthetic access$1200(Lcom/google/mediapipe/formats/proto/RectProto$Rect;)V
    .locals 0

    .line 124
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->clearRectId()V

    return-void
.end method

.method static synthetic access$200(Lcom/google/mediapipe/formats/proto/RectProto$Rect;)V
    .locals 0

    .line 124
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->clearXCenter()V

    return-void
.end method

.method static synthetic access$300(Lcom/google/mediapipe/formats/proto/RectProto$Rect;I)V
    .locals 0

    .line 124
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->setYCenter(I)V

    return-void
.end method

.method static synthetic access$400(Lcom/google/mediapipe/formats/proto/RectProto$Rect;)V
    .locals 0

    .line 124
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->clearYCenter()V

    return-void
.end method

.method static synthetic access$500(Lcom/google/mediapipe/formats/proto/RectProto$Rect;I)V
    .locals 0

    .line 124
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->setHeight(I)V

    return-void
.end method

.method static synthetic access$600(Lcom/google/mediapipe/formats/proto/RectProto$Rect;)V
    .locals 0

    .line 124
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->clearHeight()V

    return-void
.end method

.method static synthetic access$700(Lcom/google/mediapipe/formats/proto/RectProto$Rect;I)V
    .locals 0

    .line 124
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->setWidth(I)V

    return-void
.end method

.method static synthetic access$800(Lcom/google/mediapipe/formats/proto/RectProto$Rect;)V
    .locals 0

    .line 124
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->clearWidth()V

    return-void
.end method

.method static synthetic access$900(Lcom/google/mediapipe/formats/proto/RectProto$Rect;F)V
    .locals 0

    .line 124
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->setRotation(F)V

    return-void
.end method

.method private clearHeight()V
    .locals 1

    .line 266
    iget v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->bitField0_:I

    and-int/lit8 v0, v0, -0x5

    iput v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->bitField0_:I

    const/4 v0, 0x0

    .line 267
    iput v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->height_:I

    return-void
.end method

.method private clearRectId()V
    .locals 2

    .line 400
    iget v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->bitField0_:I

    and-int/lit8 v0, v0, -0x21

    iput v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->bitField0_:I

    const-wide/16 v0, 0x0

    .line 401
    iput-wide v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->rectId_:J

    return-void
.end method

.method private clearRotation()V
    .locals 1

    .line 350
    iget v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->bitField0_:I

    and-int/lit8 v0, v0, -0x11

    iput v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->bitField0_:I

    const/4 v0, 0x0

    .line 351
    iput v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->rotation_:F

    return-void
.end method

.method private clearWidth()V
    .locals 1

    .line 300
    iget v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->bitField0_:I

    and-int/lit8 v0, v0, -0x9

    iput v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->bitField0_:I

    const/4 v0, 0x0

    .line 301
    iput v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->width_:I

    return-void
.end method

.method private clearXCenter()V
    .locals 1

    .line 182
    iget v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->bitField0_:I

    and-int/lit8 v0, v0, -0x2

    iput v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->bitField0_:I

    const/4 v0, 0x0

    .line 183
    iput v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->xCenter_:I

    return-void
.end method

.method private clearYCenter()V
    .locals 1

    .line 216
    iget v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->bitField0_:I

    and-int/lit8 v0, v0, -0x3

    iput v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->bitField0_:I

    const/4 v0, 0x0

    .line 217
    iput v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->yCenter_:I

    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/formats/proto/RectProto$Rect;
    .locals 1

    .line 863
    sget-object v0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/RectProto$Rect;

    return-object v0
.end method

.method public static newBuilder()Lcom/google/mediapipe/formats/proto/RectProto$Rect$Builder;
    .locals 1

    .line 481
    sget-object v0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/RectProto$Rect;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/formats/proto/RectProto$Rect$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/formats/proto/RectProto$Rect;)Lcom/google/mediapipe/formats/proto/RectProto$Rect$Builder;
    .locals 1

    .line 484
    sget-object v0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/RectProto$Rect;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/formats/proto/RectProto$Rect;
    .locals 1

    .line 457
    sget-object v0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/RectProto$Rect;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/RectProto$Rect;
    .locals 1

    .line 464
    sget-object v0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/RectProto$Rect;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/formats/proto/RectProto$Rect;
    .locals 1

    .line 420
    sget-object v0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/RectProto$Rect;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/RectProto$Rect;
    .locals 1

    .line 427
    sget-object v0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/RectProto$Rect;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/formats/proto/RectProto$Rect;
    .locals 1

    .line 469
    sget-object v0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/RectProto$Rect;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/RectProto$Rect;
    .locals 1

    .line 476
    sget-object v0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/RectProto$Rect;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/formats/proto/RectProto$Rect;
    .locals 1

    .line 444
    sget-object v0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/RectProto$Rect;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/RectProto$Rect;
    .locals 1

    .line 451
    sget-object v0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/RectProto$Rect;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/formats/proto/RectProto$Rect;
    .locals 1

    .line 407
    sget-object v0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/RectProto$Rect;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/RectProto$Rect;
    .locals 1

    .line 414
    sget-object v0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/RectProto$Rect;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/formats/proto/RectProto$Rect;
    .locals 1

    .line 432
    sget-object v0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/RectProto$Rect;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/RectProto$Rect;
    .locals 1

    .line 439
    sget-object v0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/RectProto$Rect;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/formats/proto/RectProto$Rect;",
            ">;"
        }
    .end annotation

    .line 869
    sget-object v0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/RectProto$Rect;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private setHeight(I)V
    .locals 1

    .line 255
    iget v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->bitField0_:I

    or-int/lit8 v0, v0, 0x4

    iput v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->bitField0_:I

    .line 256
    iput p1, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->height_:I

    return-void
.end method

.method private setRectId(J)V
    .locals 1

    .line 389
    iget v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->bitField0_:I

    or-int/lit8 v0, v0, 0x20

    iput v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->bitField0_:I

    .line 390
    iput-wide p1, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->rectId_:J

    return-void
.end method

.method private setRotation(F)V
    .locals 1

    .line 339
    iget v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->bitField0_:I

    or-int/lit8 v0, v0, 0x10

    iput v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->bitField0_:I

    .line 340
    iput p1, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->rotation_:F

    return-void
.end method

.method private setWidth(I)V
    .locals 1

    .line 293
    iget v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->bitField0_:I

    or-int/lit8 v0, v0, 0x8

    iput v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->bitField0_:I

    .line 294
    iput p1, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->width_:I

    return-void
.end method

.method private setXCenter(I)V
    .locals 1

    .line 170
    iget v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->bitField0_:I

    or-int/lit8 v0, v0, 0x1

    iput v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->bitField0_:I

    .line 171
    iput p1, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->xCenter_:I

    return-void
.end method

.method private setYCenter(I)V
    .locals 1

    .line 209
    iget v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->bitField0_:I

    or-int/lit8 v0, v0, 0x2

    iput v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->bitField0_:I

    .line 210
    iput p1, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->yCenter_:I

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 7

    .line 797
    sget-object p3, Lcom/google/mediapipe/formats/proto/RectProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p3, p1

    const/4 p3, 0x0

    packed-switch p1, :pswitch_data_0

    .line 847
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

    .line 843
    iput-byte p1, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->memoizedIsInitialized:B

    return-object p3

    .line 840
    :pswitch_1
    iget-byte p1, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->memoizedIsInitialized:B

    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 825
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_2

    .line 827
    const-class p2, Lcom/google/mediapipe/formats/proto/RectProto$Rect;

    monitor-enter p2

    .line 828
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 830
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/RectProto$Rect;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 833
    sput-object p1, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_1

    :catchall_0
    move-exception v0

    move-object p1, v0

    goto :goto_2

    .line 835
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

    .line 822
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/RectProto$Rect;

    return-object p1

    .line 805
    :pswitch_4
    const-string v0, "bitField0_"

    const-string v1, "xCenter_"

    const-string v2, "yCenter_"

    const-string v3, "height_"

    const-string v4, "width_"

    const-string v5, "rotation_"

    const-string v6, "rectId_"

    filled-new-array/range {v0 .. v6}, [Ljava/lang/Object;

    move-result-object p1

    .line 814
    const-string p2, "\u0001\u0006\u0000\u0001\u0001\u0006\u0006\u0000\u0000\u0004\u0001\u1504\u0000\u0002\u1504\u0001\u0003\u1504\u0002\u0004\u1504\u0003\u0005\u1001\u0004\u0006\u1002\u0005"

    .line 818
    sget-object p3, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/RectProto$Rect;

    invoke-static {p3, p2, p1}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 802
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/formats/proto/RectProto$Rect$Builder;

    invoke-direct {p1, p3}, Lcom/google/mediapipe/formats/proto/RectProto$Rect$Builder;-><init>(Lcom/google/mediapipe/formats/proto/RectProto$1;)V

    return-object p1

    .line 799
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/formats/proto/RectProto$Rect;

    invoke-direct {p1}, Lcom/google/mediapipe/formats/proto/RectProto$Rect;-><init>()V

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

    .line 124
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getHeight()I
    .locals 1

    .line 244
    iget v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->height_:I

    return v0
.end method

.method public getRectId()J
    .locals 2

    .line 378
    iget-wide v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->rectId_:J

    return-wide v0
.end method

.method public getRotation()F
    .locals 1

    .line 328
    iget v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->rotation_:F

    return v0
.end method

.method public getWidth()I
    .locals 1

    .line 286
    iget v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->width_:I

    return v0
.end method

.method public getXCenter()I
    .locals 1

    .line 158
    iget v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->xCenter_:I

    return v0
.end method

.method public getYCenter()I
    .locals 1

    .line 202
    iget v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->yCenter_:I

    return v0
.end method

.method public hasHeight()Z
    .locals 1

    .line 232
    iget v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->bitField0_:I

    and-int/lit8 v0, v0, 0x4

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasRectId()Z
    .locals 1

    .line 366
    iget v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->bitField0_:I

    and-int/lit8 v0, v0, 0x20

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasRotation()Z
    .locals 1

    .line 316
    iget v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->bitField0_:I

    and-int/lit8 v0, v0, 0x10

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasWidth()Z
    .locals 1

    .line 278
    iget v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->bitField0_:I

    and-int/lit8 v0, v0, 0x8

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasXCenter()Z
    .locals 2

    .line 145
    iget v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->bitField0_:I

    const/4 v1, 0x1

    and-int/2addr v0, v1

    if-eqz v0, :cond_0

    return v1

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasYCenter()Z
    .locals 1

    .line 194
    iget v0, p0, Lcom/google/mediapipe/formats/proto/RectProto$Rect;->bitField0_:I

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

    .line 124
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 124
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
