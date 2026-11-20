.class public final Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "DetectionProto.java"

# interfaces
.implements Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/formats/proto/DetectionProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Detection"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;,
        Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetectionOrBuilder;,
        Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;",
        "Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;",
        ">;",
        "Lcom/google/mediapipe/formats/proto/DetectionProto$DetectionOrBuilder;"
    }
.end annotation


# static fields
.field public static final ASSOCIATED_DETECTIONS_FIELD_NUMBER:I = 0x8

.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

.field public static final DETECTION_ID_FIELD_NUMBER:I = 0x7

.field public static final DISPLAY_NAME_FIELD_NUMBER:I = 0x9

.field public static final FEATURE_TAG_FIELD_NUMBER:I = 0x5

.field public static final LABEL_FIELD_NUMBER:I = 0x1

.field public static final LABEL_ID_FIELD_NUMBER:I = 0x2

.field public static final LOCATION_DATA_FIELD_NUMBER:I = 0x4

.field private static volatile PARSER:Lcom/google/protobuf/Parser; = null
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;",
            ">;"
        }
    .end annotation
.end field

.field public static final SCORE_FIELD_NUMBER:I = 0x3

.field public static final TIMESTAMP_USEC_FIELD_NUMBER:I = 0xa

.field public static final TRACK_ID_FIELD_NUMBER:I = 0x6


# instance fields
.field private associatedDetections_:Lcom/google/protobuf/Internal$ProtobufList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Internal$ProtobufList<",
            "Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;",
            ">;"
        }
    .end annotation
.end field

.field private bitField0_:I

.field private detectionId_:J

.field private displayName_:Lcom/google/protobuf/Internal$ProtobufList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Internal$ProtobufList<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field private featureTag_:Ljava/lang/String;

.field private labelIdMemoizedSerializedSize:I

.field private labelId_:Lcom/google/protobuf/Internal$IntList;

.field private label_:Lcom/google/protobuf/Internal$ProtobufList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Internal$ProtobufList<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field private locationData_:Lcom/google/mediapipe/formats/proto/LocationDataProto$LocationData;

.field private memoizedIsInitialized:B

.field private scoreMemoizedSerializedSize:I

.field private score_:Lcom/google/protobuf/Internal$FloatList;

.field private timestampUsec_:J

.field private trackId_:Ljava/lang/String;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 2504
    new-instance v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-direct {v0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;-><init>()V

    .line 2507
    sput-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    .line 2508
    const-class v1, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    .line 279
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    const/4 v0, -0x1

    .line 808
    iput v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->labelIdMemoizedSerializedSize:I

    .line 879
    iput v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->scoreMemoizedSerializedSize:I

    const/4 v0, 0x2

    .line 2436
    iput-byte v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->memoizedIsInitialized:B

    .line 280
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->label_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 281
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyIntList()Lcom/google/protobuf/Internal$IntList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->labelId_:Lcom/google/protobuf/Internal$IntList;

    .line 282
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyFloatList()Lcom/google/protobuf/Internal$FloatList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->score_:Lcom/google/protobuf/Internal$FloatList;

    .line 283
    const-string v0, ""

    iput-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->featureTag_:Ljava/lang/String;

    .line 284
    iput-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->trackId_:Ljava/lang/String;

    .line 285
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->associatedDetections_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 286
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->displayName_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method static synthetic access$1000(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;)V
    .locals 0

    .line 274
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->clearLabel()V

    return-void
.end method

.method static synthetic access$1100(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 274
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->addLabelBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method static synthetic access$1200(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;II)V
    .locals 0

    .line 274
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->setLabelId(II)V

    return-void
.end method

.method static synthetic access$1300(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;I)V
    .locals 0

    .line 274
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->addLabelId(I)V

    return-void
.end method

.method static synthetic access$1400(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;Ljava/lang/Iterable;)V
    .locals 0

    .line 274
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->addAllLabelId(Ljava/lang/Iterable;)V

    return-void
.end method

.method static synthetic access$1500(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;)V
    .locals 0

    .line 274
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->clearLabelId()V

    return-void
.end method

.method static synthetic access$1600(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;IF)V
    .locals 0

    .line 274
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->setScore(IF)V

    return-void
.end method

.method static synthetic access$1700(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;F)V
    .locals 0

    .line 274
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->addScore(F)V

    return-void
.end method

.method static synthetic access$1800(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;Ljava/lang/Iterable;)V
    .locals 0

    .line 274
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->addAllScore(Ljava/lang/Iterable;)V

    return-void
.end method

.method static synthetic access$1900(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;)V
    .locals 0

    .line 274
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->clearScore()V

    return-void
.end method

.method static synthetic access$2000(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;Lcom/google/mediapipe/formats/proto/LocationDataProto$LocationData;)V
    .locals 0

    .line 274
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->setLocationData(Lcom/google/mediapipe/formats/proto/LocationDataProto$LocationData;)V

    return-void
.end method

.method static synthetic access$2100(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;Lcom/google/mediapipe/formats/proto/LocationDataProto$LocationData;)V
    .locals 0

    .line 274
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->mergeLocationData(Lcom/google/mediapipe/formats/proto/LocationDataProto$LocationData;)V

    return-void
.end method

.method static synthetic access$2200(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;)V
    .locals 0

    .line 274
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->clearLocationData()V

    return-void
.end method

.method static synthetic access$2300(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;Ljava/lang/String;)V
    .locals 0

    .line 274
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->setFeatureTag(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$2400(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;)V
    .locals 0

    .line 274
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->clearFeatureTag()V

    return-void
.end method

.method static synthetic access$2500(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 274
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->setFeatureTagBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method static synthetic access$2600(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;Ljava/lang/String;)V
    .locals 0

    .line 274
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->setTrackId(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$2700(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;)V
    .locals 0

    .line 274
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->clearTrackId()V

    return-void
.end method

.method static synthetic access$2800(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 274
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->setTrackIdBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method static synthetic access$2900(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;J)V
    .locals 0

    .line 274
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->setDetectionId(J)V

    return-void
.end method

.method static synthetic access$3000(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;)V
    .locals 0

    .line 274
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->clearDetectionId()V

    return-void
.end method

.method static synthetic access$3100(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;ILcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;)V
    .locals 0

    .line 274
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->setAssociatedDetections(ILcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;)V

    return-void
.end method

.method static synthetic access$3200(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;)V
    .locals 0

    .line 274
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->addAssociatedDetections(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;)V

    return-void
.end method

.method static synthetic access$3300(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;ILcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;)V
    .locals 0

    .line 274
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->addAssociatedDetections(ILcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;)V

    return-void
.end method

.method static synthetic access$3400(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;Ljava/lang/Iterable;)V
    .locals 0

    .line 274
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->addAllAssociatedDetections(Ljava/lang/Iterable;)V

    return-void
.end method

.method static synthetic access$3500(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;)V
    .locals 0

    .line 274
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->clearAssociatedDetections()V

    return-void
.end method

.method static synthetic access$3600(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;I)V
    .locals 0

    .line 274
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->removeAssociatedDetections(I)V

    return-void
.end method

.method static synthetic access$3700(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;ILjava/lang/String;)V
    .locals 0

    .line 274
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->setDisplayName(ILjava/lang/String;)V

    return-void
.end method

.method static synthetic access$3800(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;Ljava/lang/String;)V
    .locals 0

    .line 274
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->addDisplayName(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$3900(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;Ljava/lang/Iterable;)V
    .locals 0

    .line 274
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->addAllDisplayName(Ljava/lang/Iterable;)V

    return-void
.end method

.method static synthetic access$4000(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;)V
    .locals 0

    .line 274
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->clearDisplayName()V

    return-void
.end method

.method static synthetic access$4100(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 274
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->addDisplayNameBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method static synthetic access$4200(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;J)V
    .locals 0

    .line 274
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->setTimestampUsec(J)V

    return-void
.end method

.method static synthetic access$4300(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;)V
    .locals 0

    .line 274
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->clearTimestampUsec()V

    return-void
.end method

.method static synthetic access$600()Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;
    .locals 1

    .line 274
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    return-object v0
.end method

.method static synthetic access$700(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;ILjava/lang/String;)V
    .locals 0

    .line 274
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->setLabel(ILjava/lang/String;)V

    return-void
.end method

.method static synthetic access$800(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;Ljava/lang/String;)V
    .locals 0

    .line 274
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->addLabel(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$900(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;Ljava/lang/Iterable;)V
    .locals 0

    .line 274
    invoke-direct {p0, p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->addAllLabel(Ljava/lang/Iterable;)V

    return-void
.end method

.method private addAllAssociatedDetections(Ljava/lang/Iterable;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "+",
            "Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;",
            ">;)V"
        }
    .end annotation

    .line 1276
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->ensureAssociatedDetectionsIsMutable()V

    .line 1277
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->associatedDetections_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-static {p1, v0}, Lcom/google/protobuf/AbstractMessageLite;->addAll(Ljava/lang/Iterable;Ljava/util/List;)V

    return-void
.end method

.method private addAllDisplayName(Ljava/lang/Iterable;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "Ljava/lang/String;",
            ">;)V"
        }
    .end annotation

    .line 1401
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->ensureDisplayNameIsMutable()V

    .line 1402
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->displayName_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-static {p1, v0}, Lcom/google/protobuf/AbstractMessageLite;->addAll(Ljava/lang/Iterable;Ljava/util/List;)V

    return-void
.end method

.method private addAllLabel(Ljava/lang/Iterable;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "Ljava/lang/String;",
            ">;)V"
        }
    .end annotation

    .line 752
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->ensureLabelIsMutable()V

    .line 753
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->label_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-static {p1, v0}, Lcom/google/protobuf/AbstractMessageLite;->addAll(Ljava/lang/Iterable;Ljava/util/List;)V

    return-void
.end method

.method private addAllLabelId(Ljava/lang/Iterable;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "+",
            "Ljava/lang/Integer;",
            ">;)V"
        }
    .end annotation

    .line 840
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->ensureLabelIdIsMutable()V

    .line 841
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->labelId_:Lcom/google/protobuf/Internal$IntList;

    invoke-static {p1, v0}, Lcom/google/protobuf/AbstractMessageLite;->addAll(Ljava/lang/Iterable;Ljava/util/List;)V

    return-void
.end method

.method private addAllScore(Ljava/lang/Iterable;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Iterable<",
            "+",
            "Ljava/lang/Float;",
            ">;)V"
        }
    .end annotation

    .line 911
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->ensureScoreIsMutable()V

    .line 912
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->score_:Lcom/google/protobuf/Internal$FloatList;

    invoke-static {p1, v0}, Lcom/google/protobuf/AbstractMessageLite;->addAll(Ljava/lang/Iterable;Ljava/util/List;)V

    return-void
.end method

.method private addAssociatedDetections(ILcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;)V
    .locals 1

    .line 1267
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 1268
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->ensureAssociatedDetectionsIsMutable()V

    .line 1269
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->associatedDetections_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->add(ILjava/lang/Object;)V

    return-void
.end method

.method private addAssociatedDetections(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;)V
    .locals 1

    .line 1258
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 1259
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->ensureAssociatedDetectionsIsMutable()V

    .line 1260
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->associatedDetections_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private addDisplayName(Ljava/lang/String;)V
    .locals 1

    .line 1386
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 1387
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->ensureDisplayNameIsMutable()V

    .line 1388
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->displayName_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private addDisplayNameBytes(Lcom/google/protobuf/ByteString;)V
    .locals 1

    .line 1427
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->ensureDisplayNameIsMutable()V

    .line 1428
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->displayName_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private addLabel(Ljava/lang/String;)V
    .locals 1

    .line 738
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 739
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->ensureLabelIsMutable()V

    .line 740
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->label_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private addLabelBytes(Lcom/google/protobuf/ByteString;)V
    .locals 1

    .line 776
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->ensureLabelIsMutable()V

    .line 777
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->label_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private addLabelId(I)V
    .locals 1

    .line 831
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->ensureLabelIdIsMutable()V

    .line 832
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->labelId_:Lcom/google/protobuf/Internal$IntList;

    invoke-interface {v0, p1}, Lcom/google/protobuf/Internal$IntList;->addInt(I)V

    return-void
.end method

.method private addScore(F)V
    .locals 1

    .line 902
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->ensureScoreIsMutable()V

    .line 903
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->score_:Lcom/google/protobuf/Internal$FloatList;

    invoke-interface {v0, p1}, Lcom/google/protobuf/Internal$FloatList;->addFloat(F)V

    return-void
.end method

.method private clearAssociatedDetections()V
    .locals 1

    .line 1284
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->associatedDetections_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method private clearDetectionId()V
    .locals 2

    .line 1196
    iget v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->bitField0_:I

    and-int/lit8 v0, v0, -0x9

    iput v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->bitField0_:I

    const-wide/16 v0, 0x0

    .line 1197
    iput-wide v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->detectionId_:J

    return-void
.end method

.method private clearDisplayName()V
    .locals 1

    .line 1414
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->displayName_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method private clearFeatureTag()V
    .locals 1

    .line 1054
    iget v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->bitField0_:I

    and-int/lit8 v0, v0, -0x3

    iput v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->bitField0_:I

    .line 1055
    invoke-static {}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->getDefaultInstance()Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    move-result-object v0

    invoke-virtual {v0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->getFeatureTag()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->featureTag_:Ljava/lang/String;

    return-void
.end method

.method private clearLabel()V
    .locals 1

    .line 764
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyProtobufList()Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->label_:Lcom/google/protobuf/Internal$ProtobufList;

    return-void
.end method

.method private clearLabelId()V
    .locals 1

    .line 848
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyIntList()Lcom/google/protobuf/Internal$IntList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->labelId_:Lcom/google/protobuf/Internal$IntList;

    return-void
.end method

.method private clearLocationData()V
    .locals 1

    const/4 v0, 0x0

    .line 984
    iput-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->locationData_:Lcom/google/mediapipe/formats/proto/LocationDataProto$LocationData;

    .line 985
    iget v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->bitField0_:I

    and-int/lit8 v0, v0, -0x2

    iput v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->bitField0_:I

    return-void
.end method

.method private clearScore()V
    .locals 1

    .line 919
    invoke-static {}, Lcom/google/protobuf/GeneratedMessageLite;->emptyFloatList()Lcom/google/protobuf/Internal$FloatList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->score_:Lcom/google/protobuf/Internal$FloatList;

    return-void
.end method

.method private clearTimestampUsec()V
    .locals 2

    .line 1481
    iget v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->bitField0_:I

    and-int/lit8 v0, v0, -0x11

    iput v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->bitField0_:I

    const-wide/16 v0, 0x0

    .line 1482
    iput-wide v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->timestampUsec_:J

    return-void
.end method

.method private clearTrackId()V
    .locals 1

    .line 1133
    iget v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->bitField0_:I

    and-int/lit8 v0, v0, -0x5

    iput v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->bitField0_:I

    .line 1134
    invoke-static {}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->getDefaultInstance()Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    move-result-object v0

    invoke-virtual {v0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->getTrackId()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->trackId_:Ljava/lang/String;

    return-void
.end method

.method private ensureAssociatedDetectionsIsMutable()V
    .locals 2

    .line 1238
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->associatedDetections_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 1239
    invoke-interface {v0}, Lcom/google/protobuf/Internal$ProtobufList;->isModifiable()Z

    move-result v1

    if-nez v1, :cond_0

    .line 1241
    invoke-static {v0}, Lcom/google/protobuf/GeneratedMessageLite;->mutableCopy(Lcom/google/protobuf/Internal$ProtobufList;)Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->associatedDetections_:Lcom/google/protobuf/Internal$ProtobufList;

    :cond_0
    return-void
.end method

.method private ensureDisplayNameIsMutable()V
    .locals 2

    .line 1353
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->displayName_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 1354
    invoke-interface {v0}, Lcom/google/protobuf/Internal$ProtobufList;->isModifiable()Z

    move-result v1

    if-nez v1, :cond_0

    .line 1356
    invoke-static {v0}, Lcom/google/protobuf/GeneratedMessageLite;->mutableCopy(Lcom/google/protobuf/Internal$ProtobufList;)Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->displayName_:Lcom/google/protobuf/Internal$ProtobufList;

    :cond_0
    return-void
.end method

.method private ensureLabelIdIsMutable()V
    .locals 2

    .line 810
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->labelId_:Lcom/google/protobuf/Internal$IntList;

    .line 811
    invoke-interface {v0}, Lcom/google/protobuf/Internal$ProtobufList;->isModifiable()Z

    move-result v1

    if-nez v1, :cond_0

    .line 813
    invoke-static {v0}, Lcom/google/protobuf/GeneratedMessageLite;->mutableCopy(Lcom/google/protobuf/Internal$IntList;)Lcom/google/protobuf/Internal$IntList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->labelId_:Lcom/google/protobuf/Internal$IntList;

    :cond_0
    return-void
.end method

.method private ensureLabelIsMutable()V
    .locals 2

    .line 707
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->label_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 708
    invoke-interface {v0}, Lcom/google/protobuf/Internal$ProtobufList;->isModifiable()Z

    move-result v1

    if-nez v1, :cond_0

    .line 710
    invoke-static {v0}, Lcom/google/protobuf/GeneratedMessageLite;->mutableCopy(Lcom/google/protobuf/Internal$ProtobufList;)Lcom/google/protobuf/Internal$ProtobufList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->label_:Lcom/google/protobuf/Internal$ProtobufList;

    :cond_0
    return-void
.end method

.method private ensureScoreIsMutable()V
    .locals 2

    .line 881
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->score_:Lcom/google/protobuf/Internal$FloatList;

    .line 882
    invoke-interface {v0}, Lcom/google/protobuf/Internal$ProtobufList;->isModifiable()Z

    move-result v1

    if-nez v1, :cond_0

    .line 884
    invoke-static {v0}, Lcom/google/protobuf/GeneratedMessageLite;->mutableCopy(Lcom/google/protobuf/Internal$FloatList;)Lcom/google/protobuf/Internal$FloatList;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->score_:Lcom/google/protobuf/Internal$FloatList;

    :cond_0
    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;
    .locals 1

    .line 2513
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    return-object v0
.end method

.method private mergeLocationData(Lcom/google/mediapipe/formats/proto/LocationDataProto$LocationData;)V
    .locals 2

    .line 967
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 968
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->locationData_:Lcom/google/mediapipe/formats/proto/LocationDataProto$LocationData;

    if-eqz v0, :cond_0

    .line 969
    invoke-static {}, Lcom/google/mediapipe/formats/proto/LocationDataProto$LocationData;->getDefaultInstance()Lcom/google/mediapipe/formats/proto/LocationDataProto$LocationData;

    move-result-object v1

    if-eq v0, v1, :cond_0

    .line 970
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->locationData_:Lcom/google/mediapipe/formats/proto/LocationDataProto$LocationData;

    .line 971
    invoke-static {v0}, Lcom/google/mediapipe/formats/proto/LocationDataProto$LocationData;->newBuilder(Lcom/google/mediapipe/formats/proto/LocationDataProto$LocationData;)Lcom/google/mediapipe/formats/proto/LocationDataProto$LocationData$Builder;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/formats/proto/LocationDataProto$LocationData$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/formats/proto/LocationDataProto$LocationData;

    iput-object p1, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->locationData_:Lcom/google/mediapipe/formats/proto/LocationDataProto$LocationData;

    goto :goto_0

    .line 973
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->locationData_:Lcom/google/mediapipe/formats/proto/LocationDataProto$LocationData;

    .line 975
    :goto_0
    iget p1, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->bitField0_:I

    or-int/lit8 p1, p1, 0x1

    iput p1, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->bitField0_:I

    return-void
.end method

.method public static newBuilder()Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1

    .line 1562
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;
    .locals 1

    .line 1565
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;
    .locals 1

    .line 1538
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;
    .locals 1

    .line 1545
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;
    .locals 1

    .line 1501
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;
    .locals 1

    .line 1508
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;
    .locals 1

    .line 1550
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;
    .locals 1

    .line 1557
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;
    .locals 1

    .line 1525
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;
    .locals 1

    .line 1532
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;
    .locals 1

    .line 1488
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;
    .locals 1

    .line 1495
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;
    .locals 1

    .line 1513
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;
    .locals 1

    .line 1520
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;",
            ">;"
        }
    .end annotation

    .line 2519
    sget-object v0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private removeAssociatedDetections(I)V
    .locals 1

    .line 1290
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->ensureAssociatedDetectionsIsMutable()V

    .line 1291
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->associatedDetections_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->remove(I)Ljava/lang/Object;

    return-void
.end method

.method private setAssociatedDetections(ILcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;)V
    .locals 1

    .line 1250
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 1251
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->ensureAssociatedDetectionsIsMutable()V

    .line 1252
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->associatedDetections_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->set(ILjava/lang/Object;)Ljava/lang/Object;

    return-void
.end method

.method private setDetectionId(J)V
    .locals 1

    .line 1185
    iget v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->bitField0_:I

    or-int/lit8 v0, v0, 0x8

    iput v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->bitField0_:I

    .line 1186
    iput-wide p1, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->detectionId_:J

    return-void
.end method

.method private setDisplayName(ILjava/lang/String;)V
    .locals 1

    .line 1371
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 1372
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->ensureDisplayNameIsMutable()V

    .line 1373
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->displayName_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->set(ILjava/lang/Object;)Ljava/lang/Object;

    return-void
.end method

.method private setFeatureTag(Ljava/lang/String;)V
    .locals 1

    .line 1041
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 1042
    iget v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->bitField0_:I

    or-int/lit8 v0, v0, 0x2

    iput v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->bitField0_:I

    .line 1043
    iput-object p1, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->featureTag_:Ljava/lang/String;

    return-void
.end method

.method private setFeatureTagBytes(Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 1068
    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->featureTag_:Ljava/lang/String;

    .line 1069
    iget p1, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->bitField0_:I

    or-int/lit8 p1, p1, 0x2

    iput p1, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->bitField0_:I

    return-void
.end method

.method private setLabel(ILjava/lang/String;)V
    .locals 1

    .line 724
    invoke-virtual {p2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 725
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->ensureLabelIsMutable()V

    .line 726
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->label_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->set(ILjava/lang/Object;)Ljava/lang/Object;

    return-void
.end method

.method private setLabelId(II)V
    .locals 1

    .line 823
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->ensureLabelIdIsMutable()V

    .line 824
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->labelId_:Lcom/google/protobuf/Internal$IntList;

    invoke-interface {v0, p1, p2}, Lcom/google/protobuf/Internal$IntList;->setInt(II)I

    return-void
.end method

.method private setLocationData(Lcom/google/mediapipe/formats/proto/LocationDataProto$LocationData;)V
    .locals 0

    .line 954
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 955
    iput-object p1, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->locationData_:Lcom/google/mediapipe/formats/proto/LocationDataProto$LocationData;

    .line 956
    iget p1, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->bitField0_:I

    or-int/lit8 p1, p1, 0x1

    iput p1, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->bitField0_:I

    return-void
.end method

.method private setScore(IF)V
    .locals 1

    .line 894
    invoke-direct {p0}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->ensureScoreIsMutable()V

    .line 895
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->score_:Lcom/google/protobuf/Internal$FloatList;

    invoke-interface {v0, p1, p2}, Lcom/google/protobuf/Internal$FloatList;->setFloat(IF)F

    return-void
.end method

.method private setTimestampUsec(J)V
    .locals 1

    .line 1469
    iget v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->bitField0_:I

    or-int/lit8 v0, v0, 0x10

    iput v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->bitField0_:I

    .line 1470
    iput-wide p1, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->timestampUsec_:J

    return-void
.end method

.method private setTrackId(Ljava/lang/String;)V
    .locals 1

    .line 1121
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 1122
    iget v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->bitField0_:I

    or-int/lit8 v0, v0, 0x4

    iput v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->bitField0_:I

    .line 1123
    iput-object p1, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->trackId_:Ljava/lang/String;

    return-void
.end method

.method private setTrackIdBytes(Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 1146
    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->trackId_:Ljava/lang/String;

    .line 1147
    iget p1, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->bitField0_:I

    or-int/lit8 p1, p1, 0x4

    iput p1, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->bitField0_:I

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 12

    .line 2442
    sget-object p3, Lcom/google/mediapipe/formats/proto/DetectionProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p3, p1

    const/4 p3, 0x0

    packed-switch p1, :pswitch_data_0

    .line 2497
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

    .line 2493
    iput-byte p1, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->memoizedIsInitialized:B

    return-object p3

    .line 2490
    :pswitch_1
    iget-byte p1, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->memoizedIsInitialized:B

    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 2475
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_2

    .line 2477
    const-class p2, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    monitor-enter p2

    .line 2478
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 2480
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 2483
    sput-object p1, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_1

    :catchall_0
    move-exception v0

    move-object p1, v0

    goto :goto_2

    .line 2485
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

    .line 2472
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    return-object p1

    .line 2450
    :pswitch_4
    const-string v0, "bitField0_"

    const-string v1, "label_"

    const-string v2, "labelId_"

    const-string v3, "score_"

    const-string v4, "locationData_"

    const-string v5, "featureTag_"

    const-string v6, "trackId_"

    const-string v7, "detectionId_"

    const-string v8, "associatedDetections_"

    const-class v9, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    const-string v10, "displayName_"

    const-string v11, "timestampUsec_"

    filled-new-array/range {v0 .. v11}, [Ljava/lang/Object;

    move-result-object p1

    .line 2464
    const-string p2, "\u0001\n\u0000\u0001\u0001\n\n\u0000\u0005\u0001\u0001\u001a\u0002\'\u0003$\u0004\u1409\u0000\u0005\u1008\u0001\u0006\u1008\u0002\u0007\u1002\u0003\u0008\u001b\t\u001a\n\u1002\u0004"

    .line 2468
    sget-object p3, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->DEFAULT_INSTANCE:Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-static {p3, p2, p1}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 2447
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;

    invoke-direct {p1, p3}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$Builder;-><init>(Lcom/google/mediapipe/formats/proto/DetectionProto$1;)V

    return-object p1

    .line 2444
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;

    invoke-direct {p1}, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;-><init>()V

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

.method public getAssociatedDetections(I)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;
    .locals 1

    .line 1228
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->associatedDetections_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;

    return-object p1
.end method

.method public getAssociatedDetectionsCount()I
    .locals 1

    .line 1221
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->associatedDetections_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    return v0
.end method

.method public getAssociatedDetectionsList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetection;",
            ">;"
        }
    .end annotation

    .line 1207
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->associatedDetections_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public getAssociatedDetectionsOrBuilder(I)Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetectionOrBuilder;
    .locals 1

    .line 1235
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->associatedDetections_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetectionOrBuilder;

    return-object p1
.end method

.method public getAssociatedDetectionsOrBuilderList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "+",
            "Lcom/google/mediapipe/formats/proto/DetectionProto$Detection$AssociatedDetectionOrBuilder;",
            ">;"
        }
    .end annotation

    .line 1214
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->associatedDetections_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public bridge synthetic getDefaultInstanceForType()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 274
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getDetectionId()J
    .locals 2

    .line 1174
    iget-wide v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->detectionId_:J

    return-wide v0
.end method

.method public getDisplayName(I)Ljava/lang/String;
    .locals 1

    .line 1334
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->displayName_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/lang/String;

    return-object p1
.end method

.method public getDisplayNameBytes(I)Lcom/google/protobuf/ByteString;
    .locals 1

    .line 1349
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->displayName_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 1350
    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/lang/String;

    .line 1349
    invoke-static {p1}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object p1

    return-object p1
.end method

.method public getDisplayNameCount()I
    .locals 1

    .line 1320
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->displayName_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    return v0
.end method

.method public getDisplayNameList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .line 1307
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->displayName_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public getFeatureTag()Ljava/lang/String;
    .locals 1

    .line 1014
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->featureTag_:Ljava/lang/String;

    return-object v0
.end method

.method public getFeatureTagBytes()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 1028
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->featureTag_:Ljava/lang/String;

    invoke-static {v0}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object v0

    return-object v0
.end method

.method public getLabel(I)Ljava/lang/String;
    .locals 1

    .line 689
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->label_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/lang/String;

    return-object p1
.end method

.method public getLabelBytes(I)Lcom/google/protobuf/ByteString;
    .locals 1

    .line 703
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->label_:Lcom/google/protobuf/Internal$ProtobufList;

    .line 704
    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/lang/String;

    .line 703
    invoke-static {p1}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object p1

    return-object p1
.end method

.method public getLabelCount()I
    .locals 1

    .line 676
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->label_:Lcom/google/protobuf/Internal$ProtobufList;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    return v0
.end method

.method public getLabelId(I)I
    .locals 1

    .line 806
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->labelId_:Lcom/google/protobuf/Internal$IntList;

    invoke-interface {v0, p1}, Lcom/google/protobuf/Internal$IntList;->getInt(I)I

    move-result p1

    return p1
.end method

.method public getLabelIdCount()I
    .locals 1

    .line 797
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->labelId_:Lcom/google/protobuf/Internal$IntList;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    return v0
.end method

.method public getLabelIdList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Ljava/lang/Integer;",
            ">;"
        }
    .end annotation

    .line 789
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->labelId_:Lcom/google/protobuf/Internal$IntList;

    return-object v0
.end method

.method public getLabelList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .line 664
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->label_:Lcom/google/protobuf/Internal$ProtobufList;

    return-object v0
.end method

.method public getLocationData()Lcom/google/mediapipe/formats/proto/LocationDataProto$LocationData;
    .locals 1

    .line 944
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->locationData_:Lcom/google/mediapipe/formats/proto/LocationDataProto$LocationData;

    if-nez v0, :cond_0

    invoke-static {}, Lcom/google/mediapipe/formats/proto/LocationDataProto$LocationData;->getDefaultInstance()Lcom/google/mediapipe/formats/proto/LocationDataProto$LocationData;

    move-result-object v0

    :cond_0
    return-object v0
.end method

.method public getScore(I)F
    .locals 1

    .line 877
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->score_:Lcom/google/protobuf/Internal$FloatList;

    invoke-interface {v0, p1}, Lcom/google/protobuf/Internal$FloatList;->getFloat(I)F

    move-result p1

    return p1
.end method

.method public getScoreCount()I
    .locals 1

    .line 868
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->score_:Lcom/google/protobuf/Internal$FloatList;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    return v0
.end method

.method public getScoreList()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Ljava/lang/Float;",
            ">;"
        }
    .end annotation

    .line 860
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->score_:Lcom/google/protobuf/Internal$FloatList;

    return-object v0
.end method

.method public getTimestampUsec()J
    .locals 2

    .line 1457
    iget-wide v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->timestampUsec_:J

    return-wide v0
.end method

.method public getTrackId()Ljava/lang/String;
    .locals 1

    .line 1096
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->trackId_:Ljava/lang/String;

    return-object v0
.end method

.method public getTrackIdBytes()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 1109
    iget-object v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->trackId_:Ljava/lang/String;

    invoke-static {v0}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object v0

    return-object v0
.end method

.method public hasDetectionId()Z
    .locals 1

    .line 1162
    iget v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->bitField0_:I

    and-int/lit8 v0, v0, 0x8

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasFeatureTag()Z
    .locals 1

    .line 1001
    iget v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->bitField0_:I

    and-int/lit8 v0, v0, 0x2

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasLocationData()Z
    .locals 2

    .line 933
    iget v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->bitField0_:I

    const/4 v1, 0x1

    and-int/2addr v0, v1

    if-eqz v0, :cond_0

    return v1

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasTimestampUsec()Z
    .locals 1

    .line 1444
    iget v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->bitField0_:I

    and-int/lit8 v0, v0, 0x10

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasTrackId()Z
    .locals 1

    .line 1084
    iget v0, p0, Lcom/google/mediapipe/formats/proto/DetectionProto$Detection;->bitField0_:I

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

    .line 274
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 274
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
