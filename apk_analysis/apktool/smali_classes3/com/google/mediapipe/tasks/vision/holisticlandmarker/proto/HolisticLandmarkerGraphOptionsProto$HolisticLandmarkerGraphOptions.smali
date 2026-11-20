.class public final Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "HolisticLandmarkerGraphOptionsProto.java"

# interfaces
.implements Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptionsOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "HolisticLandmarkerGraphOptions"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;",
        "Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions$Builder;",
        ">;",
        "Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptionsOrBuilder;"
    }
.end annotation


# static fields
.field public static final BASE_OPTIONS_FIELD_NUMBER:I = 0x1

.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

.field public static final FACE_DETECTOR_GRAPH_OPTIONS_FIELD_NUMBER:I = 0x4

.field public static final FACE_LANDMARKS_DETECTOR_GRAPH_OPTIONS_FIELD_NUMBER:I = 0x5

.field public static final HAND_LANDMARKS_DETECTOR_GRAPH_OPTIONS_FIELD_NUMBER:I = 0x2

.field public static final HAND_ROI_REFINEMENT_GRAPH_OPTIONS_FIELD_NUMBER:I = 0x3

.field private static volatile PARSER:Lcom/google/protobuf/Parser; = null
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;",
            ">;"
        }
    .end annotation
.end field

.field public static final POSE_DETECTOR_GRAPH_OPTIONS_FIELD_NUMBER:I = 0x6

.field public static final POSE_LANDMARKS_DETECTOR_GRAPH_OPTIONS_FIELD_NUMBER:I = 0x7


# instance fields
.field private baseOptions_:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

.field private bitField0_:I

.field private faceDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/facedetector/proto/FaceDetectorGraphOptionsProto$FaceDetectorGraphOptions;

.field private faceLandmarksDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/facelandmarker/proto/FaceLandmarksDetectorGraphOptionsProto$FaceLandmarksDetectorGraphOptions;

.field private handLandmarksDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandLandmarksDetectorGraphOptionsProto$HandLandmarksDetectorGraphOptions;

.field private handRoiRefinementGraphOptions_:Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandRoiRefinementGraphOptionsProto$HandRoiRefinementGraphOptions;

.field private poseDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/posedetector/proto/PoseDetectorGraphOptionsProto$PoseDetectorGraphOptions;

.field private poseLandmarksDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/poselandmarker/proto/PoseLandmarksDetectorGraphOptionsProto$PoseLandmarksDetectorGraphOptions;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 1294
    new-instance v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-direct {v0}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;-><init>()V

    .line 1297
    sput-object v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    .line 1298
    const-class v1, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 160
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    return-void
.end method

.method static synthetic access$000()Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;
    .locals 1

    .line 155
    sget-object v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    return-object v0
.end method

.method static synthetic access$100(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;)V
    .locals 0

    .line 155
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->setBaseOptions(Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;)V

    return-void
.end method

.method static synthetic access$1000(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;Lcom/google/mediapipe/tasks/vision/facedetector/proto/FaceDetectorGraphOptionsProto$FaceDetectorGraphOptions;)V
    .locals 0

    .line 155
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->setFaceDetectorGraphOptions(Lcom/google/mediapipe/tasks/vision/facedetector/proto/FaceDetectorGraphOptionsProto$FaceDetectorGraphOptions;)V

    return-void
.end method

.method static synthetic access$1100(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;Lcom/google/mediapipe/tasks/vision/facedetector/proto/FaceDetectorGraphOptionsProto$FaceDetectorGraphOptions;)V
    .locals 0

    .line 155
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->mergeFaceDetectorGraphOptions(Lcom/google/mediapipe/tasks/vision/facedetector/proto/FaceDetectorGraphOptionsProto$FaceDetectorGraphOptions;)V

    return-void
.end method

.method static synthetic access$1200(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;)V
    .locals 0

    .line 155
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->clearFaceDetectorGraphOptions()V

    return-void
.end method

.method static synthetic access$1300(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;Lcom/google/mediapipe/tasks/vision/facelandmarker/proto/FaceLandmarksDetectorGraphOptionsProto$FaceLandmarksDetectorGraphOptions;)V
    .locals 0

    .line 155
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->setFaceLandmarksDetectorGraphOptions(Lcom/google/mediapipe/tasks/vision/facelandmarker/proto/FaceLandmarksDetectorGraphOptionsProto$FaceLandmarksDetectorGraphOptions;)V

    return-void
.end method

.method static synthetic access$1400(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;Lcom/google/mediapipe/tasks/vision/facelandmarker/proto/FaceLandmarksDetectorGraphOptionsProto$FaceLandmarksDetectorGraphOptions;)V
    .locals 0

    .line 155
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->mergeFaceLandmarksDetectorGraphOptions(Lcom/google/mediapipe/tasks/vision/facelandmarker/proto/FaceLandmarksDetectorGraphOptionsProto$FaceLandmarksDetectorGraphOptions;)V

    return-void
.end method

.method static synthetic access$1500(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;)V
    .locals 0

    .line 155
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->clearFaceLandmarksDetectorGraphOptions()V

    return-void
.end method

.method static synthetic access$1600(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;Lcom/google/mediapipe/tasks/vision/posedetector/proto/PoseDetectorGraphOptionsProto$PoseDetectorGraphOptions;)V
    .locals 0

    .line 155
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->setPoseDetectorGraphOptions(Lcom/google/mediapipe/tasks/vision/posedetector/proto/PoseDetectorGraphOptionsProto$PoseDetectorGraphOptions;)V

    return-void
.end method

.method static synthetic access$1700(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;Lcom/google/mediapipe/tasks/vision/posedetector/proto/PoseDetectorGraphOptionsProto$PoseDetectorGraphOptions;)V
    .locals 0

    .line 155
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->mergePoseDetectorGraphOptions(Lcom/google/mediapipe/tasks/vision/posedetector/proto/PoseDetectorGraphOptionsProto$PoseDetectorGraphOptions;)V

    return-void
.end method

.method static synthetic access$1800(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;)V
    .locals 0

    .line 155
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->clearPoseDetectorGraphOptions()V

    return-void
.end method

.method static synthetic access$1900(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;Lcom/google/mediapipe/tasks/vision/poselandmarker/proto/PoseLandmarksDetectorGraphOptionsProto$PoseLandmarksDetectorGraphOptions;)V
    .locals 0

    .line 155
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->setPoseLandmarksDetectorGraphOptions(Lcom/google/mediapipe/tasks/vision/poselandmarker/proto/PoseLandmarksDetectorGraphOptionsProto$PoseLandmarksDetectorGraphOptions;)V

    return-void
.end method

.method static synthetic access$200(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;)V
    .locals 0

    .line 155
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->mergeBaseOptions(Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;)V

    return-void
.end method

.method static synthetic access$2000(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;Lcom/google/mediapipe/tasks/vision/poselandmarker/proto/PoseLandmarksDetectorGraphOptionsProto$PoseLandmarksDetectorGraphOptions;)V
    .locals 0

    .line 155
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->mergePoseLandmarksDetectorGraphOptions(Lcom/google/mediapipe/tasks/vision/poselandmarker/proto/PoseLandmarksDetectorGraphOptionsProto$PoseLandmarksDetectorGraphOptions;)V

    return-void
.end method

.method static synthetic access$2100(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;)V
    .locals 0

    .line 155
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->clearPoseLandmarksDetectorGraphOptions()V

    return-void
.end method

.method static synthetic access$300(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;)V
    .locals 0

    .line 155
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->clearBaseOptions()V

    return-void
.end method

.method static synthetic access$400(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandLandmarksDetectorGraphOptionsProto$HandLandmarksDetectorGraphOptions;)V
    .locals 0

    .line 155
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->setHandLandmarksDetectorGraphOptions(Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandLandmarksDetectorGraphOptionsProto$HandLandmarksDetectorGraphOptions;)V

    return-void
.end method

.method static synthetic access$500(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandLandmarksDetectorGraphOptionsProto$HandLandmarksDetectorGraphOptions;)V
    .locals 0

    .line 155
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->mergeHandLandmarksDetectorGraphOptions(Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandLandmarksDetectorGraphOptionsProto$HandLandmarksDetectorGraphOptions;)V

    return-void
.end method

.method static synthetic access$600(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;)V
    .locals 0

    .line 155
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->clearHandLandmarksDetectorGraphOptions()V

    return-void
.end method

.method static synthetic access$700(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandRoiRefinementGraphOptionsProto$HandRoiRefinementGraphOptions;)V
    .locals 0

    .line 155
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->setHandRoiRefinementGraphOptions(Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandRoiRefinementGraphOptionsProto$HandRoiRefinementGraphOptions;)V

    return-void
.end method

.method static synthetic access$800(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandRoiRefinementGraphOptionsProto$HandRoiRefinementGraphOptions;)V
    .locals 0

    .line 155
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->mergeHandRoiRefinementGraphOptions(Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandRoiRefinementGraphOptionsProto$HandRoiRefinementGraphOptions;)V

    return-void
.end method

.method static synthetic access$900(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;)V
    .locals 0

    .line 155
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->clearHandRoiRefinementGraphOptions()V

    return-void
.end method

.method private clearBaseOptions()V
    .locals 1

    const/4 v0, 0x0

    .line 230
    iput-object v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->baseOptions_:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    .line 231
    iget v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    and-int/lit8 v0, v0, -0x2

    iput v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    return-void
.end method

.method private clearFaceDetectorGraphOptions()V
    .locals 1

    const/4 v0, 0x0

    .line 428
    iput-object v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->faceDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/facedetector/proto/FaceDetectorGraphOptionsProto$FaceDetectorGraphOptions;

    .line 429
    iget v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    and-int/lit8 v0, v0, -0x9

    iput v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    return-void
.end method

.method private clearFaceLandmarksDetectorGraphOptions()V
    .locals 1

    const/4 v0, 0x0

    .line 494
    iput-object v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->faceLandmarksDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/facelandmarker/proto/FaceLandmarksDetectorGraphOptionsProto$FaceLandmarksDetectorGraphOptions;

    .line 495
    iget v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    and-int/lit8 v0, v0, -0x11

    iput v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    return-void
.end method

.method private clearHandLandmarksDetectorGraphOptions()V
    .locals 1

    const/4 v0, 0x0

    .line 296
    iput-object v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->handLandmarksDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandLandmarksDetectorGraphOptionsProto$HandLandmarksDetectorGraphOptions;

    .line 297
    iget v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    and-int/lit8 v0, v0, -0x3

    iput v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    return-void
.end method

.method private clearHandRoiRefinementGraphOptions()V
    .locals 1

    const/4 v0, 0x0

    .line 362
    iput-object v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->handRoiRefinementGraphOptions_:Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandRoiRefinementGraphOptionsProto$HandRoiRefinementGraphOptions;

    .line 363
    iget v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    and-int/lit8 v0, v0, -0x5

    iput v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    return-void
.end method

.method private clearPoseDetectorGraphOptions()V
    .locals 1

    const/4 v0, 0x0

    .line 560
    iput-object v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->poseDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/posedetector/proto/PoseDetectorGraphOptionsProto$PoseDetectorGraphOptions;

    .line 561
    iget v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    and-int/lit8 v0, v0, -0x21

    iput v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    return-void
.end method

.method private clearPoseLandmarksDetectorGraphOptions()V
    .locals 1

    const/4 v0, 0x0

    .line 626
    iput-object v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->poseLandmarksDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/poselandmarker/proto/PoseLandmarksDetectorGraphOptionsProto$PoseLandmarksDetectorGraphOptions;

    .line 627
    iget v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    and-int/lit8 v0, v0, -0x41

    iput v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;
    .locals 1

    .line 1303
    sget-object v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    return-object v0
.end method

.method private mergeBaseOptions(Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;)V
    .locals 2

    .line 212
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 213
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->baseOptions_:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    if-eqz v0, :cond_0

    .line 214
    invoke-static {}, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->getDefaultInstance()Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    move-result-object v1

    if-eq v0, v1, :cond_0

    .line 215
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->baseOptions_:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    .line 216
    invoke-static {v0}, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->newBuilder(Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;)Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions$Builder;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->baseOptions_:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    goto :goto_0

    .line 218
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->baseOptions_:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    .line 220
    :goto_0
    iget p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    or-int/lit8 p1, p1, 0x1

    iput p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    return-void
.end method

.method private mergeFaceDetectorGraphOptions(Lcom/google/mediapipe/tasks/vision/facedetector/proto/FaceDetectorGraphOptionsProto$FaceDetectorGraphOptions;)V
    .locals 2

    .line 411
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 412
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->faceDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/facedetector/proto/FaceDetectorGraphOptionsProto$FaceDetectorGraphOptions;

    if-eqz v0, :cond_0

    .line 413
    invoke-static {}, Lcom/google/mediapipe/tasks/vision/facedetector/proto/FaceDetectorGraphOptionsProto$FaceDetectorGraphOptions;->getDefaultInstance()Lcom/google/mediapipe/tasks/vision/facedetector/proto/FaceDetectorGraphOptionsProto$FaceDetectorGraphOptions;

    move-result-object v1

    if-eq v0, v1, :cond_0

    .line 414
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->faceDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/facedetector/proto/FaceDetectorGraphOptionsProto$FaceDetectorGraphOptions;

    .line 415
    invoke-static {v0}, Lcom/google/mediapipe/tasks/vision/facedetector/proto/FaceDetectorGraphOptionsProto$FaceDetectorGraphOptions;->newBuilder(Lcom/google/mediapipe/tasks/vision/facedetector/proto/FaceDetectorGraphOptionsProto$FaceDetectorGraphOptions;)Lcom/google/mediapipe/tasks/vision/facedetector/proto/FaceDetectorGraphOptionsProto$FaceDetectorGraphOptions$Builder;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/vision/facedetector/proto/FaceDetectorGraphOptionsProto$FaceDetectorGraphOptions$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/vision/facedetector/proto/FaceDetectorGraphOptionsProto$FaceDetectorGraphOptions;

    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->faceDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/facedetector/proto/FaceDetectorGraphOptionsProto$FaceDetectorGraphOptions;

    goto :goto_0

    .line 417
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->faceDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/facedetector/proto/FaceDetectorGraphOptionsProto$FaceDetectorGraphOptions;

    .line 419
    :goto_0
    iget p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    or-int/lit8 p1, p1, 0x8

    iput p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    return-void
.end method

.method private mergeFaceLandmarksDetectorGraphOptions(Lcom/google/mediapipe/tasks/vision/facelandmarker/proto/FaceLandmarksDetectorGraphOptionsProto$FaceLandmarksDetectorGraphOptions;)V
    .locals 2

    .line 477
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 478
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->faceLandmarksDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/facelandmarker/proto/FaceLandmarksDetectorGraphOptionsProto$FaceLandmarksDetectorGraphOptions;

    if-eqz v0, :cond_0

    .line 479
    invoke-static {}, Lcom/google/mediapipe/tasks/vision/facelandmarker/proto/FaceLandmarksDetectorGraphOptionsProto$FaceLandmarksDetectorGraphOptions;->getDefaultInstance()Lcom/google/mediapipe/tasks/vision/facelandmarker/proto/FaceLandmarksDetectorGraphOptionsProto$FaceLandmarksDetectorGraphOptions;

    move-result-object v1

    if-eq v0, v1, :cond_0

    .line 480
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->faceLandmarksDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/facelandmarker/proto/FaceLandmarksDetectorGraphOptionsProto$FaceLandmarksDetectorGraphOptions;

    .line 481
    invoke-static {v0}, Lcom/google/mediapipe/tasks/vision/facelandmarker/proto/FaceLandmarksDetectorGraphOptionsProto$FaceLandmarksDetectorGraphOptions;->newBuilder(Lcom/google/mediapipe/tasks/vision/facelandmarker/proto/FaceLandmarksDetectorGraphOptionsProto$FaceLandmarksDetectorGraphOptions;)Lcom/google/mediapipe/tasks/vision/facelandmarker/proto/FaceLandmarksDetectorGraphOptionsProto$FaceLandmarksDetectorGraphOptions$Builder;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/vision/facelandmarker/proto/FaceLandmarksDetectorGraphOptionsProto$FaceLandmarksDetectorGraphOptions$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/vision/facelandmarker/proto/FaceLandmarksDetectorGraphOptionsProto$FaceLandmarksDetectorGraphOptions;

    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->faceLandmarksDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/facelandmarker/proto/FaceLandmarksDetectorGraphOptionsProto$FaceLandmarksDetectorGraphOptions;

    goto :goto_0

    .line 483
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->faceLandmarksDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/facelandmarker/proto/FaceLandmarksDetectorGraphOptionsProto$FaceLandmarksDetectorGraphOptions;

    .line 485
    :goto_0
    iget p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    or-int/lit8 p1, p1, 0x10

    iput p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    return-void
.end method

.method private mergeHandLandmarksDetectorGraphOptions(Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandLandmarksDetectorGraphOptionsProto$HandLandmarksDetectorGraphOptions;)V
    .locals 2

    .line 279
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 280
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->handLandmarksDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandLandmarksDetectorGraphOptionsProto$HandLandmarksDetectorGraphOptions;

    if-eqz v0, :cond_0

    .line 281
    invoke-static {}, Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandLandmarksDetectorGraphOptionsProto$HandLandmarksDetectorGraphOptions;->getDefaultInstance()Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandLandmarksDetectorGraphOptionsProto$HandLandmarksDetectorGraphOptions;

    move-result-object v1

    if-eq v0, v1, :cond_0

    .line 282
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->handLandmarksDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandLandmarksDetectorGraphOptionsProto$HandLandmarksDetectorGraphOptions;

    .line 283
    invoke-static {v0}, Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandLandmarksDetectorGraphOptionsProto$HandLandmarksDetectorGraphOptions;->newBuilder(Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandLandmarksDetectorGraphOptionsProto$HandLandmarksDetectorGraphOptions;)Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandLandmarksDetectorGraphOptionsProto$HandLandmarksDetectorGraphOptions$Builder;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandLandmarksDetectorGraphOptionsProto$HandLandmarksDetectorGraphOptions$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandLandmarksDetectorGraphOptionsProto$HandLandmarksDetectorGraphOptions;

    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->handLandmarksDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandLandmarksDetectorGraphOptionsProto$HandLandmarksDetectorGraphOptions;

    goto :goto_0

    .line 285
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->handLandmarksDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandLandmarksDetectorGraphOptionsProto$HandLandmarksDetectorGraphOptions;

    .line 287
    :goto_0
    iget p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    or-int/lit8 p1, p1, 0x2

    iput p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    return-void
.end method

.method private mergeHandRoiRefinementGraphOptions(Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandRoiRefinementGraphOptionsProto$HandRoiRefinementGraphOptions;)V
    .locals 2

    .line 345
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 346
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->handRoiRefinementGraphOptions_:Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandRoiRefinementGraphOptionsProto$HandRoiRefinementGraphOptions;

    if-eqz v0, :cond_0

    .line 347
    invoke-static {}, Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandRoiRefinementGraphOptionsProto$HandRoiRefinementGraphOptions;->getDefaultInstance()Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandRoiRefinementGraphOptionsProto$HandRoiRefinementGraphOptions;

    move-result-object v1

    if-eq v0, v1, :cond_0

    .line 348
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->handRoiRefinementGraphOptions_:Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandRoiRefinementGraphOptionsProto$HandRoiRefinementGraphOptions;

    .line 349
    invoke-static {v0}, Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandRoiRefinementGraphOptionsProto$HandRoiRefinementGraphOptions;->newBuilder(Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandRoiRefinementGraphOptionsProto$HandRoiRefinementGraphOptions;)Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandRoiRefinementGraphOptionsProto$HandRoiRefinementGraphOptions$Builder;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandRoiRefinementGraphOptionsProto$HandRoiRefinementGraphOptions$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandRoiRefinementGraphOptionsProto$HandRoiRefinementGraphOptions;

    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->handRoiRefinementGraphOptions_:Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandRoiRefinementGraphOptionsProto$HandRoiRefinementGraphOptions;

    goto :goto_0

    .line 351
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->handRoiRefinementGraphOptions_:Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandRoiRefinementGraphOptionsProto$HandRoiRefinementGraphOptions;

    .line 353
    :goto_0
    iget p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    or-int/lit8 p1, p1, 0x4

    iput p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    return-void
.end method

.method private mergePoseDetectorGraphOptions(Lcom/google/mediapipe/tasks/vision/posedetector/proto/PoseDetectorGraphOptionsProto$PoseDetectorGraphOptions;)V
    .locals 2

    .line 543
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 544
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->poseDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/posedetector/proto/PoseDetectorGraphOptionsProto$PoseDetectorGraphOptions;

    if-eqz v0, :cond_0

    .line 545
    invoke-static {}, Lcom/google/mediapipe/tasks/vision/posedetector/proto/PoseDetectorGraphOptionsProto$PoseDetectorGraphOptions;->getDefaultInstance()Lcom/google/mediapipe/tasks/vision/posedetector/proto/PoseDetectorGraphOptionsProto$PoseDetectorGraphOptions;

    move-result-object v1

    if-eq v0, v1, :cond_0

    .line 546
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->poseDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/posedetector/proto/PoseDetectorGraphOptionsProto$PoseDetectorGraphOptions;

    .line 547
    invoke-static {v0}, Lcom/google/mediapipe/tasks/vision/posedetector/proto/PoseDetectorGraphOptionsProto$PoseDetectorGraphOptions;->newBuilder(Lcom/google/mediapipe/tasks/vision/posedetector/proto/PoseDetectorGraphOptionsProto$PoseDetectorGraphOptions;)Lcom/google/mediapipe/tasks/vision/posedetector/proto/PoseDetectorGraphOptionsProto$PoseDetectorGraphOptions$Builder;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/vision/posedetector/proto/PoseDetectorGraphOptionsProto$PoseDetectorGraphOptions$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/vision/posedetector/proto/PoseDetectorGraphOptionsProto$PoseDetectorGraphOptions;

    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->poseDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/posedetector/proto/PoseDetectorGraphOptionsProto$PoseDetectorGraphOptions;

    goto :goto_0

    .line 549
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->poseDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/posedetector/proto/PoseDetectorGraphOptionsProto$PoseDetectorGraphOptions;

    .line 551
    :goto_0
    iget p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    or-int/lit8 p1, p1, 0x20

    iput p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    return-void
.end method

.method private mergePoseLandmarksDetectorGraphOptions(Lcom/google/mediapipe/tasks/vision/poselandmarker/proto/PoseLandmarksDetectorGraphOptionsProto$PoseLandmarksDetectorGraphOptions;)V
    .locals 2

    .line 609
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 610
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->poseLandmarksDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/poselandmarker/proto/PoseLandmarksDetectorGraphOptionsProto$PoseLandmarksDetectorGraphOptions;

    if-eqz v0, :cond_0

    .line 611
    invoke-static {}, Lcom/google/mediapipe/tasks/vision/poselandmarker/proto/PoseLandmarksDetectorGraphOptionsProto$PoseLandmarksDetectorGraphOptions;->getDefaultInstance()Lcom/google/mediapipe/tasks/vision/poselandmarker/proto/PoseLandmarksDetectorGraphOptionsProto$PoseLandmarksDetectorGraphOptions;

    move-result-object v1

    if-eq v0, v1, :cond_0

    .line 612
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->poseLandmarksDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/poselandmarker/proto/PoseLandmarksDetectorGraphOptionsProto$PoseLandmarksDetectorGraphOptions;

    .line 613
    invoke-static {v0}, Lcom/google/mediapipe/tasks/vision/poselandmarker/proto/PoseLandmarksDetectorGraphOptionsProto$PoseLandmarksDetectorGraphOptions;->newBuilder(Lcom/google/mediapipe/tasks/vision/poselandmarker/proto/PoseLandmarksDetectorGraphOptionsProto$PoseLandmarksDetectorGraphOptions;)Lcom/google/mediapipe/tasks/vision/poselandmarker/proto/PoseLandmarksDetectorGraphOptionsProto$PoseLandmarksDetectorGraphOptions$Builder;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/vision/poselandmarker/proto/PoseLandmarksDetectorGraphOptionsProto$PoseLandmarksDetectorGraphOptions$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/vision/poselandmarker/proto/PoseLandmarksDetectorGraphOptionsProto$PoseLandmarksDetectorGraphOptions;

    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->poseLandmarksDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/poselandmarker/proto/PoseLandmarksDetectorGraphOptionsProto$PoseLandmarksDetectorGraphOptions;

    goto :goto_0

    .line 615
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->poseLandmarksDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/poselandmarker/proto/PoseLandmarksDetectorGraphOptionsProto$PoseLandmarksDetectorGraphOptions;

    .line 617
    :goto_0
    iget p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    or-int/lit8 p1, p1, 0x40

    iput p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    return-void
.end method

.method public static newBuilder()Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions$Builder;
    .locals 1

    .line 707
    sget-object v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;)Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions$Builder;
    .locals 1

    .line 710
    sget-object v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;
    .locals 1

    .line 683
    sget-object v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;
    .locals 1

    .line 690
    sget-object v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;
    .locals 1

    .line 646
    sget-object v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;
    .locals 1

    .line 653
    sget-object v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;
    .locals 1

    .line 695
    sget-object v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;
    .locals 1

    .line 702
    sget-object v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;
    .locals 1

    .line 670
    sget-object v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;
    .locals 1

    .line 677
    sget-object v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;
    .locals 1

    .line 633
    sget-object v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;
    .locals 1

    .line 640
    sget-object v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;
    .locals 1

    .line 658
    sget-object v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;
    .locals 1

    .line 665
    sget-object v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;",
            ">;"
        }
    .end annotation

    .line 1309
    sget-object v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private setBaseOptions(Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;)V
    .locals 0

    .line 198
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 199
    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->baseOptions_:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    .line 200
    iget p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    or-int/lit8 p1, p1, 0x1

    iput p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    return-void
.end method

.method private setFaceDetectorGraphOptions(Lcom/google/mediapipe/tasks/vision/facedetector/proto/FaceDetectorGraphOptionsProto$FaceDetectorGraphOptions;)V
    .locals 0

    .line 398
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 399
    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->faceDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/facedetector/proto/FaceDetectorGraphOptionsProto$FaceDetectorGraphOptions;

    .line 400
    iget p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    or-int/lit8 p1, p1, 0x8

    iput p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    return-void
.end method

.method private setFaceLandmarksDetectorGraphOptions(Lcom/google/mediapipe/tasks/vision/facelandmarker/proto/FaceLandmarksDetectorGraphOptionsProto$FaceLandmarksDetectorGraphOptions;)V
    .locals 0

    .line 464
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 465
    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->faceLandmarksDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/facelandmarker/proto/FaceLandmarksDetectorGraphOptionsProto$FaceLandmarksDetectorGraphOptions;

    .line 466
    iget p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    or-int/lit8 p1, p1, 0x10

    iput p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    return-void
.end method

.method private setHandLandmarksDetectorGraphOptions(Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandLandmarksDetectorGraphOptionsProto$HandLandmarksDetectorGraphOptions;)V
    .locals 0

    .line 266
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 267
    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->handLandmarksDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandLandmarksDetectorGraphOptionsProto$HandLandmarksDetectorGraphOptions;

    .line 268
    iget p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    or-int/lit8 p1, p1, 0x2

    iput p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    return-void
.end method

.method private setHandRoiRefinementGraphOptions(Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandRoiRefinementGraphOptionsProto$HandRoiRefinementGraphOptions;)V
    .locals 0

    .line 332
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 333
    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->handRoiRefinementGraphOptions_:Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandRoiRefinementGraphOptionsProto$HandRoiRefinementGraphOptions;

    .line 334
    iget p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    or-int/lit8 p1, p1, 0x4

    iput p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    return-void
.end method

.method private setPoseDetectorGraphOptions(Lcom/google/mediapipe/tasks/vision/posedetector/proto/PoseDetectorGraphOptionsProto$PoseDetectorGraphOptions;)V
    .locals 0

    .line 530
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 531
    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->poseDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/posedetector/proto/PoseDetectorGraphOptionsProto$PoseDetectorGraphOptions;

    .line 532
    iget p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    or-int/lit8 p1, p1, 0x20

    iput p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    return-void
.end method

.method private setPoseLandmarksDetectorGraphOptions(Lcom/google/mediapipe/tasks/vision/poselandmarker/proto/PoseLandmarksDetectorGraphOptionsProto$PoseLandmarksDetectorGraphOptions;)V
    .locals 0

    .line 596
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 597
    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->poseLandmarksDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/poselandmarker/proto/PoseLandmarksDetectorGraphOptionsProto$PoseLandmarksDetectorGraphOptions;

    .line 598
    iget p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    or-int/lit8 p1, p1, 0x40

    iput p1, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 8

    .line 1237
    sget-object p2, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p2, p1

    const/4 p2, 0x0

    packed-switch p1, :pswitch_data_0

    .line 1287
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    invoke-direct {p1}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw p1

    :pswitch_0
    return-object p2

    :pswitch_1
    const/4 p1, 0x1

    .line 1281
    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 1266
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 1268
    const-class p2, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    monitor-enter p2

    .line 1269
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_0

    .line 1271
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 1274
    sput-object p1, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_0

    :catchall_0
    move-exception v0

    move-object p1, v0

    goto :goto_1

    .line 1276
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

    .line 1263
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    return-object p1

    .line 1245
    :pswitch_4
    const-string v0, "bitField0_"

    const-string v1, "baseOptions_"

    const-string v2, "handLandmarksDetectorGraphOptions_"

    const-string v3, "handRoiRefinementGraphOptions_"

    const-string v4, "faceDetectorGraphOptions_"

    const-string v5, "faceLandmarksDetectorGraphOptions_"

    const-string v6, "poseDetectorGraphOptions_"

    const-string v7, "poseLandmarksDetectorGraphOptions_"

    filled-new-array/range {v0 .. v7}, [Ljava/lang/Object;

    move-result-object p1

    .line 1255
    const-string p2, "\u0000\u0007\u0000\u0001\u0001\u0007\u0007\u0000\u0000\u0000\u0001\u1009\u0000\u0002\u1009\u0001\u0003\u1009\u0002\u0004\u1009\u0003\u0005\u1009\u0004\u0006\u1009\u0005\u0007\u1009\u0006"

    .line 1259
    sget-object p3, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->DEFAULT_INSTANCE:Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-static {p3, p2, p1}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 1242
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions$Builder;

    invoke-direct {p1, p2}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions$Builder;-><init>(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$1;)V

    return-object p1

    .line 1239
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-direct {p1}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;-><init>()V

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

.method public getBaseOptions()Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;
    .locals 1

    .line 187
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->baseOptions_:Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    if-nez v0, :cond_0

    invoke-static {}, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;->getDefaultInstance()Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    move-result-object v0

    :cond_0
    return-object v0
.end method

.method public bridge synthetic getDefaultInstanceForType()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 155
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getFaceDetectorGraphOptions()Lcom/google/mediapipe/tasks/vision/facedetector/proto/FaceDetectorGraphOptionsProto$FaceDetectorGraphOptions;
    .locals 1

    .line 388
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->faceDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/facedetector/proto/FaceDetectorGraphOptionsProto$FaceDetectorGraphOptions;

    if-nez v0, :cond_0

    invoke-static {}, Lcom/google/mediapipe/tasks/vision/facedetector/proto/FaceDetectorGraphOptionsProto$FaceDetectorGraphOptions;->getDefaultInstance()Lcom/google/mediapipe/tasks/vision/facedetector/proto/FaceDetectorGraphOptionsProto$FaceDetectorGraphOptions;

    move-result-object v0

    :cond_0
    return-object v0
.end method

.method public getFaceLandmarksDetectorGraphOptions()Lcom/google/mediapipe/tasks/vision/facelandmarker/proto/FaceLandmarksDetectorGraphOptionsProto$FaceLandmarksDetectorGraphOptions;
    .locals 1

    .line 454
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->faceLandmarksDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/facelandmarker/proto/FaceLandmarksDetectorGraphOptionsProto$FaceLandmarksDetectorGraphOptions;

    if-nez v0, :cond_0

    invoke-static {}, Lcom/google/mediapipe/tasks/vision/facelandmarker/proto/FaceLandmarksDetectorGraphOptionsProto$FaceLandmarksDetectorGraphOptions;->getDefaultInstance()Lcom/google/mediapipe/tasks/vision/facelandmarker/proto/FaceLandmarksDetectorGraphOptionsProto$FaceLandmarksDetectorGraphOptions;

    move-result-object v0

    :cond_0
    return-object v0
.end method

.method public getHandLandmarksDetectorGraphOptions()Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandLandmarksDetectorGraphOptionsProto$HandLandmarksDetectorGraphOptions;
    .locals 1

    .line 256
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->handLandmarksDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandLandmarksDetectorGraphOptionsProto$HandLandmarksDetectorGraphOptions;

    if-nez v0, :cond_0

    invoke-static {}, Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandLandmarksDetectorGraphOptionsProto$HandLandmarksDetectorGraphOptions;->getDefaultInstance()Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandLandmarksDetectorGraphOptionsProto$HandLandmarksDetectorGraphOptions;

    move-result-object v0

    :cond_0
    return-object v0
.end method

.method public getHandRoiRefinementGraphOptions()Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandRoiRefinementGraphOptionsProto$HandRoiRefinementGraphOptions;
    .locals 1

    .line 322
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->handRoiRefinementGraphOptions_:Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandRoiRefinementGraphOptionsProto$HandRoiRefinementGraphOptions;

    if-nez v0, :cond_0

    invoke-static {}, Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandRoiRefinementGraphOptionsProto$HandRoiRefinementGraphOptions;->getDefaultInstance()Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandRoiRefinementGraphOptionsProto$HandRoiRefinementGraphOptions;

    move-result-object v0

    :cond_0
    return-object v0
.end method

.method public getPoseDetectorGraphOptions()Lcom/google/mediapipe/tasks/vision/posedetector/proto/PoseDetectorGraphOptionsProto$PoseDetectorGraphOptions;
    .locals 1

    .line 520
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->poseDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/posedetector/proto/PoseDetectorGraphOptionsProto$PoseDetectorGraphOptions;

    if-nez v0, :cond_0

    invoke-static {}, Lcom/google/mediapipe/tasks/vision/posedetector/proto/PoseDetectorGraphOptionsProto$PoseDetectorGraphOptions;->getDefaultInstance()Lcom/google/mediapipe/tasks/vision/posedetector/proto/PoseDetectorGraphOptionsProto$PoseDetectorGraphOptions;

    move-result-object v0

    :cond_0
    return-object v0
.end method

.method public getPoseLandmarksDetectorGraphOptions()Lcom/google/mediapipe/tasks/vision/poselandmarker/proto/PoseLandmarksDetectorGraphOptionsProto$PoseLandmarksDetectorGraphOptions;
    .locals 1

    .line 586
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->poseLandmarksDetectorGraphOptions_:Lcom/google/mediapipe/tasks/vision/poselandmarker/proto/PoseLandmarksDetectorGraphOptionsProto$PoseLandmarksDetectorGraphOptions;

    if-nez v0, :cond_0

    invoke-static {}, Lcom/google/mediapipe/tasks/vision/poselandmarker/proto/PoseLandmarksDetectorGraphOptionsProto$PoseLandmarksDetectorGraphOptions;->getDefaultInstance()Lcom/google/mediapipe/tasks/vision/poselandmarker/proto/PoseLandmarksDetectorGraphOptionsProto$PoseLandmarksDetectorGraphOptions;

    move-result-object v0

    :cond_0
    return-object v0
.end method

.method public hasBaseOptions()Z
    .locals 2

    .line 175
    iget v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    const/4 v1, 0x1

    and-int/2addr v0, v1

    if-eqz v0, :cond_0

    return v1

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasFaceDetectorGraphOptions()Z
    .locals 1

    .line 377
    iget v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    and-int/lit8 v0, v0, 0x8

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasFaceLandmarksDetectorGraphOptions()Z
    .locals 1

    .line 443
    iget v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    and-int/lit8 v0, v0, 0x10

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasHandLandmarksDetectorGraphOptions()Z
    .locals 1

    .line 245
    iget v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    and-int/lit8 v0, v0, 0x2

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasHandRoiRefinementGraphOptions()Z
    .locals 1

    .line 311
    iget v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    and-int/lit8 v0, v0, 0x4

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasPoseDetectorGraphOptions()Z
    .locals 1

    .line 509
    iget v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    and-int/lit8 v0, v0, 0x20

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasPoseLandmarksDetectorGraphOptions()Z
    .locals 1

    .line 575
    iget v0, p0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->bitField0_:I

    and-int/lit8 v0, v0, 0x40

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public bridge synthetic newBuilderForType()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 155
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 155
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
