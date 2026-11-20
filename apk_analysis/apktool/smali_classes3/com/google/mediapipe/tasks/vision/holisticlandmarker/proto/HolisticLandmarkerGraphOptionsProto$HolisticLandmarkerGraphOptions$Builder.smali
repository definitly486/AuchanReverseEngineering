.class public final Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions$Builder;
.super Lcom/google/protobuf/GeneratedMessageLite$Builder;
.source "HolisticLandmarkerGraphOptionsProto.java"

# interfaces
.implements Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptionsOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Builder"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite$Builder<",
        "Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;",
        "Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions$Builder;",
        ">;",
        "Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptionsOrBuilder;"
    }
.end annotation


# direct methods
.method private constructor <init>()V
    .locals 1

    .line 723
    invoke-static {}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->access$000()Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    move-result-object v0

    invoke-direct {p0, v0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method synthetic constructor <init>(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$1;)V
    .locals 0

    .line 716
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions$Builder;-><init>()V

    return-void
.end method


# virtual methods
.method public bridge synthetic build()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 716
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic buildPartial()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 716
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic clear()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 716
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clear()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public clearBaseOptions()Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions$Builder;
    .locals 1

    .line 799
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 800
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-static {v0}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->access$300(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;)V

    return-object p0
.end method

.method public clearFaceDetectorGraphOptions()Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions$Builder;
    .locals 1

    .line 1012
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1013
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-static {v0}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->access$1200(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;)V

    return-object p0
.end method

.method public clearFaceLandmarksDetectorGraphOptions()Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions$Builder;
    .locals 1

    .line 1083
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1084
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-static {v0}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->access$1500(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;)V

    return-object p0
.end method

.method public clearHandLandmarksDetectorGraphOptions()Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions$Builder;
    .locals 1

    .line 870
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 871
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-static {v0}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->access$600(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;)V

    return-object p0
.end method

.method public clearHandRoiRefinementGraphOptions()Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions$Builder;
    .locals 1

    .line 941
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 942
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-static {v0}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->access$900(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;)V

    return-object p0
.end method

.method public clearPoseDetectorGraphOptions()Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions$Builder;
    .locals 1

    .line 1154
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1155
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-static {v0}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->access$1800(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;)V

    return-object p0
.end method

.method public clearPoseLandmarksDetectorGraphOptions()Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions$Builder;
    .locals 1

    .line 1225
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1226
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-static {v0}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->access$2100(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;)V

    return-object p0
.end method

.method public bridge synthetic clone()Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 1

    .line 716
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clone()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic clone()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 716
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clone()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic clone()Ljava/lang/Object;
    .locals 1

    .line 716
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->clone()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public getBaseOptions()Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;
    .locals 1

    .line 749
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->getBaseOptions()Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic getDefaultInstanceForType()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 716
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getFaceDetectorGraphOptions()Lcom/google/mediapipe/tasks/vision/facedetector/proto/FaceDetectorGraphOptionsProto$FaceDetectorGraphOptions;
    .locals 1

    .line 966
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->getFaceDetectorGraphOptions()Lcom/google/mediapipe/tasks/vision/facedetector/proto/FaceDetectorGraphOptionsProto$FaceDetectorGraphOptions;

    move-result-object v0

    return-object v0
.end method

.method public getFaceLandmarksDetectorGraphOptions()Lcom/google/mediapipe/tasks/vision/facelandmarker/proto/FaceLandmarksDetectorGraphOptionsProto$FaceLandmarksDetectorGraphOptions;
    .locals 1

    .line 1037
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->getFaceLandmarksDetectorGraphOptions()Lcom/google/mediapipe/tasks/vision/facelandmarker/proto/FaceLandmarksDetectorGraphOptionsProto$FaceLandmarksDetectorGraphOptions;

    move-result-object v0

    return-object v0
.end method

.method public getHandLandmarksDetectorGraphOptions()Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandLandmarksDetectorGraphOptionsProto$HandLandmarksDetectorGraphOptions;
    .locals 1

    .line 824
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->getHandLandmarksDetectorGraphOptions()Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandLandmarksDetectorGraphOptionsProto$HandLandmarksDetectorGraphOptions;

    move-result-object v0

    return-object v0
.end method

.method public getHandRoiRefinementGraphOptions()Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandRoiRefinementGraphOptionsProto$HandRoiRefinementGraphOptions;
    .locals 1

    .line 895
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->getHandRoiRefinementGraphOptions()Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandRoiRefinementGraphOptionsProto$HandRoiRefinementGraphOptions;

    move-result-object v0

    return-object v0
.end method

.method public getPoseDetectorGraphOptions()Lcom/google/mediapipe/tasks/vision/posedetector/proto/PoseDetectorGraphOptionsProto$PoseDetectorGraphOptions;
    .locals 1

    .line 1108
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->getPoseDetectorGraphOptions()Lcom/google/mediapipe/tasks/vision/posedetector/proto/PoseDetectorGraphOptionsProto$PoseDetectorGraphOptions;

    move-result-object v0

    return-object v0
.end method

.method public getPoseLandmarksDetectorGraphOptions()Lcom/google/mediapipe/tasks/vision/poselandmarker/proto/PoseLandmarksDetectorGraphOptionsProto$PoseLandmarksDetectorGraphOptions;
    .locals 1

    .line 1179
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->getPoseLandmarksDetectorGraphOptions()Lcom/google/mediapipe/tasks/vision/poselandmarker/proto/PoseLandmarksDetectorGraphOptionsProto$PoseLandmarksDetectorGraphOptions;

    move-result-object v0

    return-object v0
.end method

.method public hasBaseOptions()Z
    .locals 1

    .line 737
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->hasBaseOptions()Z

    move-result v0

    return v0
.end method

.method public hasFaceDetectorGraphOptions()Z
    .locals 1

    .line 955
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->hasFaceDetectorGraphOptions()Z

    move-result v0

    return v0
.end method

.method public hasFaceLandmarksDetectorGraphOptions()Z
    .locals 1

    .line 1026
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->hasFaceLandmarksDetectorGraphOptions()Z

    move-result v0

    return v0
.end method

.method public hasHandLandmarksDetectorGraphOptions()Z
    .locals 1

    .line 813
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->hasHandLandmarksDetectorGraphOptions()Z

    move-result v0

    return v0
.end method

.method public hasHandRoiRefinementGraphOptions()Z
    .locals 1

    .line 884
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->hasHandRoiRefinementGraphOptions()Z

    move-result v0

    return v0
.end method

.method public hasPoseDetectorGraphOptions()Z
    .locals 1

    .line 1097
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->hasPoseDetectorGraphOptions()Z

    move-result v0

    return v0
.end method

.method public hasPoseLandmarksDetectorGraphOptions()Z
    .locals 1

    .line 1168
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->hasPoseLandmarksDetectorGraphOptions()Z

    move-result v0

    return v0
.end method

.method protected bridge synthetic internalMergeFrom(Lcom/google/protobuf/AbstractMessageLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 716
    check-cast p1, Lcom/google/protobuf/GeneratedMessageLite;

    invoke-super {p0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->internalMergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public mergeBaseOptions(Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;)Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions$Builder;
    .locals 1

    .line 787
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 788
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->access$200(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;)V

    return-object p0
.end method

.method public mergeFaceDetectorGraphOptions(Lcom/google/mediapipe/tasks/vision/facedetector/proto/FaceDetectorGraphOptionsProto$FaceDetectorGraphOptions;)Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions$Builder;
    .locals 1

    .line 1001
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1002
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->access$1100(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;Lcom/google/mediapipe/tasks/vision/facedetector/proto/FaceDetectorGraphOptionsProto$FaceDetectorGraphOptions;)V

    return-object p0
.end method

.method public mergeFaceLandmarksDetectorGraphOptions(Lcom/google/mediapipe/tasks/vision/facelandmarker/proto/FaceLandmarksDetectorGraphOptionsProto$FaceLandmarksDetectorGraphOptions;)Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions$Builder;
    .locals 1

    .line 1072
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1073
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->access$1400(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;Lcom/google/mediapipe/tasks/vision/facelandmarker/proto/FaceLandmarksDetectorGraphOptionsProto$FaceLandmarksDetectorGraphOptions;)V

    return-object p0
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 716
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BII)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 716
    invoke-super {p0, p1, p2, p3}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BII)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;
    .locals 0

    .line 716
    invoke-super {p0, p1, p2, p3, p4}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 716
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 716
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 716
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 716
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Lcom/google/protobuf/MessageLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 716
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/MessageLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Ljava/io/InputStream;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 716
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Ljava/io/InputStream;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 716
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([B)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 716
    invoke-super {p0, p1}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom([B)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BII)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 716
    invoke-super {p0, p1, p2, p3}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BII)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 716
    invoke-super {p0, p1, p2, p3, p4}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom([BIILcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic mergeFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/MessageLite$Builder;
    .locals 0

    .line 716
    invoke-super {p0, p1, p2}, Lcom/google/protobuf/AbstractMessageLite$Builder;->mergeFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/AbstractMessageLite$Builder;

    move-result-object p1

    return-object p1
.end method

.method public mergeHandLandmarksDetectorGraphOptions(Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandLandmarksDetectorGraphOptionsProto$HandLandmarksDetectorGraphOptions;)Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions$Builder;
    .locals 1

    .line 859
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 860
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->access$500(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandLandmarksDetectorGraphOptionsProto$HandLandmarksDetectorGraphOptions;)V

    return-object p0
.end method

.method public mergeHandRoiRefinementGraphOptions(Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandRoiRefinementGraphOptionsProto$HandRoiRefinementGraphOptions;)Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions$Builder;
    .locals 1

    .line 930
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 931
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->access$800(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandRoiRefinementGraphOptionsProto$HandRoiRefinementGraphOptions;)V

    return-object p0
.end method

.method public mergePoseDetectorGraphOptions(Lcom/google/mediapipe/tasks/vision/posedetector/proto/PoseDetectorGraphOptionsProto$PoseDetectorGraphOptions;)Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions$Builder;
    .locals 1

    .line 1143
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1144
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->access$1700(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;Lcom/google/mediapipe/tasks/vision/posedetector/proto/PoseDetectorGraphOptionsProto$PoseDetectorGraphOptions;)V

    return-object p0
.end method

.method public mergePoseLandmarksDetectorGraphOptions(Lcom/google/mediapipe/tasks/vision/poselandmarker/proto/PoseLandmarksDetectorGraphOptionsProto$PoseLandmarksDetectorGraphOptions;)Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions$Builder;
    .locals 1

    .line 1214
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1215
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->access$2000(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;Lcom/google/mediapipe/tasks/vision/poselandmarker/proto/PoseLandmarksDetectorGraphOptionsProto$PoseLandmarksDetectorGraphOptions;)V

    return-object p0
.end method

.method public setBaseOptions(Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions$Builder;)Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions$Builder;
    .locals 1

    .line 774
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 775
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->access$100(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;)V

    return-object p0
.end method

.method public setBaseOptions(Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;)Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions$Builder;
    .locals 1

    .line 760
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 761
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->access$100(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;Lcom/google/mediapipe/tasks/core/proto/BaseOptionsProto$BaseOptions;)V

    return-object p0
.end method

.method public setFaceDetectorGraphOptions(Lcom/google/mediapipe/tasks/vision/facedetector/proto/FaceDetectorGraphOptionsProto$FaceDetectorGraphOptions$Builder;)Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions$Builder;
    .locals 1

    .line 989
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 990
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/vision/facedetector/proto/FaceDetectorGraphOptionsProto$FaceDetectorGraphOptions;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->access$1000(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;Lcom/google/mediapipe/tasks/vision/facedetector/proto/FaceDetectorGraphOptionsProto$FaceDetectorGraphOptions;)V

    return-object p0
.end method

.method public setFaceDetectorGraphOptions(Lcom/google/mediapipe/tasks/vision/facedetector/proto/FaceDetectorGraphOptionsProto$FaceDetectorGraphOptions;)Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions$Builder;
    .locals 1

    .line 976
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 977
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->access$1000(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;Lcom/google/mediapipe/tasks/vision/facedetector/proto/FaceDetectorGraphOptionsProto$FaceDetectorGraphOptions;)V

    return-object p0
.end method

.method public setFaceLandmarksDetectorGraphOptions(Lcom/google/mediapipe/tasks/vision/facelandmarker/proto/FaceLandmarksDetectorGraphOptionsProto$FaceLandmarksDetectorGraphOptions$Builder;)Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions$Builder;
    .locals 1

    .line 1060
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1061
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/vision/facelandmarker/proto/FaceLandmarksDetectorGraphOptionsProto$FaceLandmarksDetectorGraphOptions;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->access$1300(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;Lcom/google/mediapipe/tasks/vision/facelandmarker/proto/FaceLandmarksDetectorGraphOptionsProto$FaceLandmarksDetectorGraphOptions;)V

    return-object p0
.end method

.method public setFaceLandmarksDetectorGraphOptions(Lcom/google/mediapipe/tasks/vision/facelandmarker/proto/FaceLandmarksDetectorGraphOptionsProto$FaceLandmarksDetectorGraphOptions;)Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions$Builder;
    .locals 1

    .line 1047
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1048
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->access$1300(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;Lcom/google/mediapipe/tasks/vision/facelandmarker/proto/FaceLandmarksDetectorGraphOptionsProto$FaceLandmarksDetectorGraphOptions;)V

    return-object p0
.end method

.method public setHandLandmarksDetectorGraphOptions(Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandLandmarksDetectorGraphOptionsProto$HandLandmarksDetectorGraphOptions$Builder;)Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions$Builder;
    .locals 1

    .line 847
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 848
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandLandmarksDetectorGraphOptionsProto$HandLandmarksDetectorGraphOptions;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->access$400(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandLandmarksDetectorGraphOptionsProto$HandLandmarksDetectorGraphOptions;)V

    return-object p0
.end method

.method public setHandLandmarksDetectorGraphOptions(Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandLandmarksDetectorGraphOptionsProto$HandLandmarksDetectorGraphOptions;)Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions$Builder;
    .locals 1

    .line 834
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 835
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->access$400(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandLandmarksDetectorGraphOptionsProto$HandLandmarksDetectorGraphOptions;)V

    return-object p0
.end method

.method public setHandRoiRefinementGraphOptions(Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandRoiRefinementGraphOptionsProto$HandRoiRefinementGraphOptions$Builder;)Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions$Builder;
    .locals 1

    .line 918
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 919
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandRoiRefinementGraphOptionsProto$HandRoiRefinementGraphOptions;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->access$700(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandRoiRefinementGraphOptionsProto$HandRoiRefinementGraphOptions;)V

    return-object p0
.end method

.method public setHandRoiRefinementGraphOptions(Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandRoiRefinementGraphOptionsProto$HandRoiRefinementGraphOptions;)Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions$Builder;
    .locals 1

    .line 905
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 906
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->access$700(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;Lcom/google/mediapipe/tasks/vision/handlandmarker/proto/HandRoiRefinementGraphOptionsProto$HandRoiRefinementGraphOptions;)V

    return-object p0
.end method

.method public setPoseDetectorGraphOptions(Lcom/google/mediapipe/tasks/vision/posedetector/proto/PoseDetectorGraphOptionsProto$PoseDetectorGraphOptions$Builder;)Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions$Builder;
    .locals 1

    .line 1131
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1132
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/vision/posedetector/proto/PoseDetectorGraphOptionsProto$PoseDetectorGraphOptions;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->access$1600(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;Lcom/google/mediapipe/tasks/vision/posedetector/proto/PoseDetectorGraphOptionsProto$PoseDetectorGraphOptions;)V

    return-object p0
.end method

.method public setPoseDetectorGraphOptions(Lcom/google/mediapipe/tasks/vision/posedetector/proto/PoseDetectorGraphOptionsProto$PoseDetectorGraphOptions;)Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions$Builder;
    .locals 1

    .line 1118
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1119
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->access$1600(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;Lcom/google/mediapipe/tasks/vision/posedetector/proto/PoseDetectorGraphOptionsProto$PoseDetectorGraphOptions;)V

    return-object p0
.end method

.method public setPoseLandmarksDetectorGraphOptions(Lcom/google/mediapipe/tasks/vision/poselandmarker/proto/PoseLandmarksDetectorGraphOptionsProto$PoseLandmarksDetectorGraphOptions$Builder;)Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions$Builder;
    .locals 1

    .line 1202
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1203
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/vision/poselandmarker/proto/PoseLandmarksDetectorGraphOptionsProto$PoseLandmarksDetectorGraphOptions;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->access$1900(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;Lcom/google/mediapipe/tasks/vision/poselandmarker/proto/PoseLandmarksDetectorGraphOptionsProto$PoseLandmarksDetectorGraphOptions;)V

    return-object p0
.end method

.method public setPoseLandmarksDetectorGraphOptions(Lcom/google/mediapipe/tasks/vision/poselandmarker/proto/PoseLandmarksDetectorGraphOptionsProto$PoseLandmarksDetectorGraphOptions;)Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions$Builder;
    .locals 1

    .line 1189
    invoke-virtual {p0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->copyOnWrite()V

    .line 1190
    iget-object v0, p0, Lcom/google/protobuf/GeneratedMessageLite$Builder;->instance:Lcom/google/protobuf/GeneratedMessageLite;

    check-cast v0, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;

    invoke-static {v0, p1}, Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;->access$1900(Lcom/google/mediapipe/tasks/vision/holisticlandmarker/proto/HolisticLandmarkerGraphOptionsProto$HolisticLandmarkerGraphOptions;Lcom/google/mediapipe/tasks/vision/poselandmarker/proto/PoseLandmarksDetectorGraphOptionsProto$PoseLandmarksDetectorGraphOptions;)V

    return-object p0
.end method
