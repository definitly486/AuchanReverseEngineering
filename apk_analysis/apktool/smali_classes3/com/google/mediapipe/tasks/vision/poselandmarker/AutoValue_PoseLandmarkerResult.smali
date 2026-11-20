.class final Lcom/google/mediapipe/tasks/vision/poselandmarker/AutoValue_PoseLandmarkerResult;
.super Lcom/google/mediapipe/tasks/vision/poselandmarker/PoseLandmarkerResult;
.source "AutoValue_PoseLandmarkerResult.java"


# instance fields
.field private final landmarks:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List<",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/tasks/components/containers/NormalizedLandmark;",
            ">;>;"
        }
    .end annotation
.end field

.field private final segmentationMasks:Ljava/util/Optional;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Optional<",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/framework/image/MPImage;",
            ">;>;"
        }
    .end annotation
.end field

.field private final timestampMs:J

.field private final worldLandmarks:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List<",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/tasks/components/containers/Landmark;",
            ">;>;"
        }
    .end annotation
.end field


# direct methods
.method constructor <init>(JLjava/util/List;Ljava/util/List;Ljava/util/Optional;)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(J",
            "Ljava/util/List<",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/tasks/components/containers/NormalizedLandmark;",
            ">;>;",
            "Ljava/util/List<",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/tasks/components/containers/Landmark;",
            ">;>;",
            "Ljava/util/Optional<",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/framework/image/MPImage;",
            ">;>;)V"
        }
    .end annotation

    .line 24
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/vision/poselandmarker/PoseLandmarkerResult;-><init>()V

    .line 25
    iput-wide p1, p0, Lcom/google/mediapipe/tasks/vision/poselandmarker/AutoValue_PoseLandmarkerResult;->timestampMs:J

    if-eqz p3, :cond_2

    .line 29
    iput-object p3, p0, Lcom/google/mediapipe/tasks/vision/poselandmarker/AutoValue_PoseLandmarkerResult;->landmarks:Ljava/util/List;

    if-eqz p4, :cond_1

    .line 33
    iput-object p4, p0, Lcom/google/mediapipe/tasks/vision/poselandmarker/AutoValue_PoseLandmarkerResult;->worldLandmarks:Ljava/util/List;

    if-eqz p5, :cond_0

    .line 37
    iput-object p5, p0, Lcom/google/mediapipe/tasks/vision/poselandmarker/AutoValue_PoseLandmarkerResult;->segmentationMasks:Ljava/util/Optional;

    return-void

    .line 35
    :cond_0
    new-instance p1, Ljava/lang/NullPointerException;

    const-string p2, "Null segmentationMasks"

    invoke-direct {p1, p2}, Ljava/lang/NullPointerException;-><init>(Ljava/lang/String;)V

    throw p1

    .line 31
    :cond_1
    new-instance p1, Ljava/lang/NullPointerException;

    const-string p2, "Null worldLandmarks"

    invoke-direct {p1, p2}, Ljava/lang/NullPointerException;-><init>(Ljava/lang/String;)V

    throw p1

    .line 27
    :cond_2
    new-instance p1, Ljava/lang/NullPointerException;

    const-string p2, "Null landmarks"

    invoke-direct {p1, p2}, Ljava/lang/NullPointerException;-><init>(Ljava/lang/String;)V

    throw p1
.end method


# virtual methods
.method public equals(Ljava/lang/Object;)Z
    .locals 7

    const/4 v0, 0x1

    if-ne p1, p0, :cond_0

    return v0

    .line 75
    :cond_0
    instance-of v1, p1, Lcom/google/mediapipe/tasks/vision/poselandmarker/PoseLandmarkerResult;

    const/4 v2, 0x0

    if-eqz v1, :cond_1

    .line 76
    check-cast p1, Lcom/google/mediapipe/tasks/vision/poselandmarker/PoseLandmarkerResult;

    .line 77
    iget-wide v3, p0, Lcom/google/mediapipe/tasks/vision/poselandmarker/AutoValue_PoseLandmarkerResult;->timestampMs:J

    invoke-virtual {p1}, Lcom/google/mediapipe/tasks/vision/poselandmarker/PoseLandmarkerResult;->timestampMs()J

    move-result-wide v5

    cmp-long v1, v3, v5

    if-nez v1, :cond_1

    iget-object v1, p0, Lcom/google/mediapipe/tasks/vision/poselandmarker/AutoValue_PoseLandmarkerResult;->landmarks:Ljava/util/List;

    .line 78
    invoke-virtual {p1}, Lcom/google/mediapipe/tasks/vision/poselandmarker/PoseLandmarkerResult;->landmarks()Ljava/util/List;

    move-result-object v3

    invoke-interface {v1, v3}, Ljava/util/List;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_1

    iget-object v1, p0, Lcom/google/mediapipe/tasks/vision/poselandmarker/AutoValue_PoseLandmarkerResult;->worldLandmarks:Ljava/util/List;

    .line 79
    invoke-virtual {p1}, Lcom/google/mediapipe/tasks/vision/poselandmarker/PoseLandmarkerResult;->worldLandmarks()Ljava/util/List;

    move-result-object v3

    invoke-interface {v1, v3}, Ljava/util/List;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_1

    iget-object v1, p0, Lcom/google/mediapipe/tasks/vision/poselandmarker/AutoValue_PoseLandmarkerResult;->segmentationMasks:Ljava/util/Optional;

    .line 80
    invoke-virtual {p1}, Lcom/google/mediapipe/tasks/vision/poselandmarker/PoseLandmarkerResult;->segmentationMasks()Ljava/util/Optional;

    move-result-object p1

    invoke-virtual {v1, p1}, Ljava/util/Optional;->equals(Ljava/lang/Object;)Z

    move-result p1

    if-eqz p1, :cond_1

    return v0

    :cond_1
    return v2
.end method

.method public hashCode()I
    .locals 4

    .line 89
    iget-wide v0, p0, Lcom/google/mediapipe/tasks/vision/poselandmarker/AutoValue_PoseLandmarkerResult;->timestampMs:J

    const/16 v2, 0x20

    ushr-long v2, v0, v2

    xor-long/2addr v0, v2

    long-to-int v0, v0

    const v1, 0xf4243

    xor-int/2addr v0, v1

    mul-int/2addr v0, v1

    .line 91
    iget-object v2, p0, Lcom/google/mediapipe/tasks/vision/poselandmarker/AutoValue_PoseLandmarkerResult;->landmarks:Ljava/util/List;

    invoke-interface {v2}, Ljava/util/List;->hashCode()I

    move-result v2

    xor-int/2addr v0, v2

    mul-int/2addr v0, v1

    .line 93
    iget-object v2, p0, Lcom/google/mediapipe/tasks/vision/poselandmarker/AutoValue_PoseLandmarkerResult;->worldLandmarks:Ljava/util/List;

    invoke-interface {v2}, Ljava/util/List;->hashCode()I

    move-result v2

    xor-int/2addr v0, v2

    mul-int/2addr v0, v1

    .line 95
    iget-object v1, p0, Lcom/google/mediapipe/tasks/vision/poselandmarker/AutoValue_PoseLandmarkerResult;->segmentationMasks:Ljava/util/Optional;

    invoke-virtual {v1}, Ljava/util/Optional;->hashCode()I

    move-result v1

    xor-int/2addr v0, v1

    return v0
.end method

.method public landmarks()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/tasks/components/containers/NormalizedLandmark;",
            ">;>;"
        }
    .end annotation

    .line 47
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/poselandmarker/AutoValue_PoseLandmarkerResult;->landmarks:Ljava/util/List;

    return-object v0
.end method

.method public segmentationMasks()Ljava/util/Optional;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/Optional<",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/framework/image/MPImage;",
            ">;>;"
        }
    .end annotation

    .line 57
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/poselandmarker/AutoValue_PoseLandmarkerResult;->segmentationMasks:Ljava/util/Optional;

    return-object v0
.end method

.method public timestampMs()J
    .locals 2

    .line 42
    iget-wide v0, p0, Lcom/google/mediapipe/tasks/vision/poselandmarker/AutoValue_PoseLandmarkerResult;->timestampMs:J

    return-wide v0
.end method

.method public toString()Ljava/lang/String;
    .locals 3

    .line 62
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "PoseLandmarkerResult{timestampMs="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-wide v1, p0, Lcom/google/mediapipe/tasks/vision/poselandmarker/AutoValue_PoseLandmarkerResult;->timestampMs:J

    invoke-virtual {v0, v1, v2}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    const-string v1, ", landmarks="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/google/mediapipe/tasks/vision/poselandmarker/AutoValue_PoseLandmarkerResult;->landmarks:Ljava/util/List;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v1, ", worldLandmarks="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/google/mediapipe/tasks/vision/poselandmarker/AutoValue_PoseLandmarkerResult;->worldLandmarks:Ljava/util/List;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v1, ", segmentationMasks="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/google/mediapipe/tasks/vision/poselandmarker/AutoValue_PoseLandmarkerResult;->segmentationMasks:Ljava/util/Optional;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v1, "}"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public worldLandmarks()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/tasks/components/containers/Landmark;",
            ">;>;"
        }
    .end annotation

    .line 52
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/poselandmarker/AutoValue_PoseLandmarkerResult;->worldLandmarks:Ljava/util/List;

    return-object v0
.end method
