.class public final Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "RegionOfInterestProto.java"

# interfaces
.implements Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$PointOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Point"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;",
        "Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point$Builder;",
        ">;",
        "Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$PointOrBuilder;"
    }
.end annotation


# static fields
.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;

.field public static final NORMALIZED_FIELD_NUMBER:I = 0x3

.field private static volatile PARSER:Lcom/google/protobuf/Parser; = null
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;",
            ">;"
        }
    .end annotation
.end field

.field public static final X_FIELD_NUMBER:I = 0x1

.field public static final Y_FIELD_NUMBER:I = 0x2


# instance fields
.field private normalized_:Z

.field private x_:F

.field private y_:F


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 370
    new-instance v0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;

    invoke-direct {v0}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;-><init>()V

    .line 373
    sput-object v0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;

    .line 374
    const-class v1, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 47
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    return-void
.end method

.method static synthetic access$000()Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;
    .locals 1

    .line 42
    sget-object v0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;

    return-object v0
.end method

.method static synthetic access$100(Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;F)V
    .locals 0

    .line 42
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->setX(F)V

    return-void
.end method

.method static synthetic access$200(Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;)V
    .locals 0

    .line 42
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->clearX()V

    return-void
.end method

.method static synthetic access$300(Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;F)V
    .locals 0

    .line 42
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->setY(F)V

    return-void
.end method

.method static synthetic access$400(Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;)V
    .locals 0

    .line 42
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->clearY()V

    return-void
.end method

.method static synthetic access$500(Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;Z)V
    .locals 0

    .line 42
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->setNormalized(Z)V

    return-void
.end method

.method static synthetic access$600(Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;)V
    .locals 0

    .line 42
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->clearNormalized()V

    return-void
.end method

.method private clearNormalized()V
    .locals 1

    const/4 v0, 0x0

    .line 124
    iput-boolean v0, p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->normalized_:Z

    return-void
.end method

.method private clearX()V
    .locals 1

    const/4 v0, 0x0

    .line 72
    iput v0, p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->x_:F

    return-void
.end method

.method private clearY()V
    .locals 1

    const/4 v0, 0x0

    .line 98
    iput v0, p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->y_:F

    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;
    .locals 1

    .line 379
    sget-object v0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;

    return-object v0
.end method

.method public static newBuilder()Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point$Builder;
    .locals 1

    .line 204
    sget-object v0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;)Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point$Builder;
    .locals 1

    .line 207
    sget-object v0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;
    .locals 1

    .line 180
    sget-object v0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;
    .locals 1

    .line 187
    sget-object v0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;
    .locals 1

    .line 143
    sget-object v0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;
    .locals 1

    .line 150
    sget-object v0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;
    .locals 1

    .line 192
    sget-object v0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;
    .locals 1

    .line 199
    sget-object v0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;
    .locals 1

    .line 167
    sget-object v0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;
    .locals 1

    .line 174
    sget-object v0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;
    .locals 1

    .line 130
    sget-object v0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;
    .locals 1

    .line 137
    sget-object v0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;
    .locals 1

    .line 155
    sget-object v0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;
    .locals 1

    .line 162
    sget-object v0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;",
            ">;"
        }
    .end annotation

    .line 385
    sget-object v0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private setNormalized(Z)V
    .locals 0

    .line 117
    iput-boolean p1, p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->normalized_:Z

    return-void
.end method

.method private setX(F)V
    .locals 0

    .line 65
    iput p1, p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->x_:F

    return-void
.end method

.method private setY(F)V
    .locals 0

    .line 91
    iput p1, p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->y_:F

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 319
    sget-object p2, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p2, p1

    const/4 p2, 0x0

    packed-switch p1, :pswitch_data_0

    .line 363
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    invoke-direct {p1}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw p1

    :pswitch_0
    return-object p2

    :pswitch_1
    const/4 p1, 0x1

    .line 357
    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 342
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 344
    const-class p2, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;

    monitor-enter p2

    .line 345
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_0

    .line 347
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 350
    sput-object p1, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 352
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

    .line 339
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;

    return-object p1

    .line 327
    :pswitch_4
    const-string p1, "x_"

    const-string p2, "y_"

    const-string p3, "normalized_"

    filled-new-array {p1, p2, p3}, [Ljava/lang/Object;

    move-result-object p1

    .line 332
    const-string p2, "\u0000\u0003\u0000\u0000\u0001\u0003\u0003\u0000\u0000\u0000\u0001\u0001\u0002\u0001\u0003\u0007"

    .line 335
    sget-object p3, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;

    invoke-static {p3, p2, p1}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 324
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point$Builder;

    invoke-direct {p1, p2}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point$Builder;-><init>(Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$1;)V

    return-object p1

    .line 321
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;

    invoke-direct {p1}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;-><init>()V

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

    .line 42
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getNormalized()Z
    .locals 1

    .line 109
    iget-boolean v0, p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->normalized_:Z

    return v0
.end method

.method public getX()F
    .locals 1

    .line 57
    iget v0, p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->x_:F

    return v0
.end method

.method public getY()F
    .locals 1

    .line 83
    iget v0, p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$Point;->y_:F

    return v0
.end method

.method public bridge synthetic newBuilderForType()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 42
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 42
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
