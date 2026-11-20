.class public final Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "DetectionProto.java"

# interfaces
.implements Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetectionOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "AssociatedDetection"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;",
        "Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection$Builder;",
        ">;",
        "Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetectionOrBuilder;"
    }
.end annotation


# static fields
.field public static final CONFIDENCE_FIELD_NUMBER:I = 0x2

.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

.field public static final ID_FIELD_NUMBER:I = 0x1

.field private static volatile PARSER:Lcom/google/protobuf/Parser;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;",
            ">;"
        }
    .end annotation
.end field


# instance fields
.field private bitField0_:I

.field private confidence_:F

.field private id_:I


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 632
    new-instance v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    invoke-direct {v0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;-><init>()V

    .line 635
    sput-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    .line 636
    const-class v1, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 328
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    return-void
.end method

.method static synthetic access$000()Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;
    .locals 1

    .line 323
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    return-object v0
.end method

.method static synthetic access$100(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;I)V
    .locals 0

    .line 323
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->setId(I)V

    return-void
.end method

.method static synthetic access$200(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;)V
    .locals 0

    .line 323
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->clearId()V

    return-void
.end method

.method static synthetic access$300(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;F)V
    .locals 0

    .line 323
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->setConfidence(F)V

    return-void
.end method

.method static synthetic access$400(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;)V
    .locals 0

    .line 323
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->clearConfidence()V

    return-void
.end method

.method private clearConfidence()V
    .locals 1

    .line 395
    iget v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->bitField0_:I

    and-int/lit8 v0, v0, -0x3

    iput v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->bitField0_:I

    const/4 v0, 0x0

    .line 396
    iput v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->confidence_:F

    return-void
.end method

.method private clearId()V
    .locals 1

    .line 361
    iget v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->bitField0_:I

    and-int/lit8 v0, v0, -0x2

    iput v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->bitField0_:I

    const/4 v0, 0x0

    .line 362
    iput v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->id_:I

    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;
    .locals 1

    .line 641
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    return-object v0
.end method

.method public static newBuilder()Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection$Builder;
    .locals 1

    .line 476
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection$Builder;
    .locals 1

    .line 479
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;
    .locals 1

    .line 452
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;
    .locals 1

    .line 459
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;
    .locals 1

    .line 415
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;
    .locals 1

    .line 422
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;
    .locals 1

    .line 464
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;
    .locals 1

    .line 471
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;
    .locals 1

    .line 439
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;
    .locals 1

    .line 446
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;
    .locals 1

    .line 402
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;
    .locals 1

    .line 409
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;
    .locals 1

    .line 427
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;
    .locals 1

    .line 434
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;",
            ">;"
        }
    .end annotation

    .line 647
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private setConfidence(F)V
    .locals 1

    .line 388
    iget v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->bitField0_:I

    or-int/lit8 v0, v0, 0x2

    iput v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->bitField0_:I

    .line 389
    iput p1, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->confidence_:F

    return-void
.end method

.method private setId(I)V
    .locals 1

    .line 354
    iget v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->bitField0_:I

    or-int/lit8 v0, v0, 0x1

    iput v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->bitField0_:I

    .line 355
    iput p1, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->id_:I

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 581
    sget-object p2, Lcom/google/mediapipe/formats/proto/DetectionProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p2, p1

    const/4 p2, 0x0

    packed-switch p1, :pswitch_data_0

    .line 625
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    invoke-direct {p1}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw p1

    :pswitch_0
    return-object p2

    :pswitch_1
    const/4 p1, 0x1

    .line 619
    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 604
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 606
    const-class p2, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    monitor-enter p2

    .line 607
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_0

    .line 609
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 612
    sput-object p1, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 614
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

    .line 601
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    return-object p1

    .line 589
    :pswitch_4
    const-string p1, "bitField0_"

    const-string p2, "id_"

    const-string p3, "confidence_"

    filled-new-array {p1, p2, p3}, [Ljava/lang/Object;

    move-result-object p1

    .line 594
    const-string p2, "\u0001\u0002\u0000\u0001\u0001\u0002\u0002\u0000\u0000\u0000\u0001\u1004\u0000\u0002\u1001\u0001"

    .line 597
    sget-object p3, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    invoke-static {p3, p2, p1}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 586
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection$Builder;

    invoke-direct {p1, p2}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection$Builder;-><init>(Lcom/google/mediapipe/formats/proto/DetectionProto$1;)V

    return-object p1

    .line 583
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    invoke-direct {p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;-><init>()V

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

.method public getConfidence()F
    .locals 1

    .line 381
    iget v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->confidence_:F

    return v0
.end method

.method public bridge synthetic getDefaultInstanceForType()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 323
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getId()I
    .locals 1

    .line 347
    iget v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->id_:I

    return v0
.end method

.method public hasConfidence()Z
    .locals 1

    .line 373
    iget v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->bitField0_:I

    and-int/lit8 v0, v0, 0x2

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasId()Z
    .locals 2

    .line 339
    iget v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;->bitField0_:I

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

    .line 323
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 323
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
