.class public abstract Lcom/google/mediapipe/tasks/vision/poselandmarker/PoseLandmarker$PoseLandmarkerOptions$Builder;
.super Ljava/lang/Object;
.source "PoseLandmarker.java"


# annotations
.annotation build Lcom/google/auto/value/AutoValue$Builder;
.end annotation

.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/tasks/vision/poselandmarker/PoseLandmarker$PoseLandmarkerOptions;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x409
    name = "Builder"
.end annotation


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 383
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method abstract autoBuild()Lcom/google/mediapipe/tasks/vision/poselandmarker/PoseLandmarker$PoseLandmarkerOptions;
.end method

.method public final build()Lcom/google/mediapipe/tasks/vision/poselandmarker/PoseLandmarker$PoseLandmarkerOptions;
    .locals 3

    .line 435
    invoke-virtual {p0}, Lcom/google/mediapipe/tasks/vision/poselandmarker/PoseLandmarker$PoseLandmarkerOptions$Builder;->autoBuild()Lcom/google/mediapipe/tasks/vision/poselandmarker/PoseLandmarker$PoseLandmarkerOptions;

    move-result-object v0

    .line 436
    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/vision/poselandmarker/PoseLandmarker$PoseLandmarkerOptions;->runningMode()Lcom/google/mediapipe/tasks/vision/core/RunningMode;

    move-result-object v1

    sget-object v2, Lcom/google/mediapipe/tasks/vision/core/RunningMode;->LIVE_STREAM:Lcom/google/mediapipe/tasks/vision/core/RunningMode;

    if-ne v1, v2, :cond_1

    .line 437
    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/vision/poselandmarker/PoseLandmarker$PoseLandmarkerOptions;->resultListener()Ljava/util/Optional;

    move-result-object v1

    invoke-virtual {v1}, Ljava/util/Optional;->isPresent()Z

    move-result v1

    if-eqz v1, :cond_0

    goto :goto_0

    .line 438
    :cond_0
    new-instance v0, Ljava/lang/IllegalArgumentException;

    const-string v1, "The pose landmarker is in the live stream mode, a user-defined result listener must be provided in PoseLandmarkerOptions."

    invoke-direct {v0, v1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 442
    :cond_1
    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/vision/poselandmarker/PoseLandmarker$PoseLandmarkerOptions;->resultListener()Ljava/util/Optional;

    move-result-object v1

    invoke-virtual {v1}, Ljava/util/Optional;->isPresent()Z

    move-result v1

    if-nez v1, :cond_2

    :goto_0
    return-object v0

    .line 443
    :cond_2
    new-instance v0, Ljava/lang/IllegalArgumentException;

    const-string v1, "The pose landmarker is in the image or the video mode, a user-defined result listener shouldn\'t be provided in PoseLandmarkerOptions."

    invoke-direct {v0, v1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method public abstract setBaseOptions(Lcom/google/mediapipe/tasks/core/BaseOptions;)Lcom/google/mediapipe/tasks/vision/poselandmarker/PoseLandmarker$PoseLandmarkerOptions$Builder;
.end method

.method public abstract setErrorListener(Lcom/google/mediapipe/tasks/core/ErrorListener;)Lcom/google/mediapipe/tasks/vision/poselandmarker/PoseLandmarker$PoseLandmarkerOptions$Builder;
.end method

.method public abstract setMinPoseDetectionConfidence(Ljava/lang/Float;)Lcom/google/mediapipe/tasks/vision/poselandmarker/PoseLandmarker$PoseLandmarkerOptions$Builder;
.end method

.method public abstract setMinPosePresenceConfidence(Ljava/lang/Float;)Lcom/google/mediapipe/tasks/vision/poselandmarker/PoseLandmarker$PoseLandmarkerOptions$Builder;
.end method

.method public abstract setMinTrackingConfidence(Ljava/lang/Float;)Lcom/google/mediapipe/tasks/vision/poselandmarker/PoseLandmarker$PoseLandmarkerOptions$Builder;
.end method

.method public abstract setNumPoses(Ljava/lang/Integer;)Lcom/google/mediapipe/tasks/vision/poselandmarker/PoseLandmarker$PoseLandmarkerOptions$Builder;
.end method

.method public abstract setOutputSegmentationMasks(Z)Lcom/google/mediapipe/tasks/vision/poselandmarker/PoseLandmarker$PoseLandmarkerOptions$Builder;
.end method

.method public abstract setResultListener(Lcom/google/mediapipe/tasks/core/OutputHandler$ResultListener;)Lcom/google/mediapipe/tasks/vision/poselandmarker/PoseLandmarker$PoseLandmarkerOptions$Builder;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/google/mediapipe/tasks/core/OutputHandler$ResultListener<",
            "Lcom/google/mediapipe/tasks/vision/poselandmarker/PoseLandmarkerResult;",
            "Lcom/google/mediapipe/framework/image/MPImage;",
            ">;)",
            "Lcom/google/mediapipe/tasks/vision/poselandmarker/PoseLandmarker$PoseLandmarkerOptions$Builder;"
        }
    .end annotation
.end method

.method public abstract setRunningMode(Lcom/google/mediapipe/tasks/vision/core/RunningMode;)Lcom/google/mediapipe/tasks/vision/poselandmarker/PoseLandmarker$PoseLandmarkerOptions$Builder;
.end method
