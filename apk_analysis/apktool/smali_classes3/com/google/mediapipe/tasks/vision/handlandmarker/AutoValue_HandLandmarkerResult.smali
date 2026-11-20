.class final Lcom/google/mediapipe/tasks/vision/handlandmarker/AutoValue_HandLandmarkerResult;
.super Lcom/google/mediapipe/tasks/vision/handlandmarker/HandLandmarkerResult;
.source "AutoValue_HandLandmarkerResult.java"


# instance fields
.field private final handedness:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List<",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/tasks/components/containers/Category;",
            ">;>;"
        }
    .end annotation
.end field

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
.method constructor <init>(JLjava/util/List;Ljava/util/List;Ljava/util/List;)V
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
            "Ljava/util/List<",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/tasks/components/containers/Category;",
            ">;>;)V"
        }
    .end annotation

    .line 23
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/vision/handlandmarker/HandLandmarkerResult;-><init>()V

    .line 24
    iput-wide p1, p0, Lcom/google/mediapipe/tasks/vision/handlandmarker/AutoValue_HandLandmarkerResult;->timestampMs:J

    if-eqz p3, :cond_2

    .line 28
    iput-object p3, p0, Lcom/google/mediapipe/tasks/vision/handlandmarker/AutoValue_HandLandmarkerResult;->landmarks:Ljava/util/List;

    if-eqz p4, :cond_1

    .line 32
    iput-object p4, p0, Lcom/google/mediapipe/tasks/vision/handlandmarker/AutoValue_HandLandmarkerResult;->worldLandmarks:Ljava/util/List;

    if-eqz p5, :cond_0

    .line 36
    iput-object p5, p0, Lcom/google/mediapipe/tasks/vision/handlandmarker/AutoValue_HandLandmarkerResult;->handedness:Ljava/util/List;

    return-void

    .line 34
    :cond_0
    new-instance p1, Ljava/lang/NullPointerException;

    const-string p2, "Null handedness"

    invoke-direct {p1, p2}, Ljava/lang/NullPointerException;-><init>(Ljava/lang/String;)V

    throw p1

    .line 30
    :cond_1
    new-instance p1, Ljava/lang/NullPointerException;

    const-string p2, "Null worldLandmarks"

    invoke-direct {p1, p2}, Ljava/lang/NullPointerException;-><init>(Ljava/lang/String;)V

    throw p1

    .line 26
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

    .line 74
    :cond_0
    instance-of v1, p1, Lcom/google/mediapipe/tasks/vision/handlandmarker/HandLandmarkerResult;

    const/4 v2, 0x0

    if-eqz v1, :cond_1

    .line 75
    check-cast p1, Lcom/google/mediapipe/tasks/vision/handlandmarker/HandLandmarkerResult;

    .line 76
    iget-wide v3, p0, Lcom/google/mediapipe/tasks/vision/handlandmarker/AutoValue_HandLandmarkerResult;->timestampMs:J

    invoke-virtual {p1}, Lcom/google/mediapipe/tasks/vision/handlandmarker/HandLandmarkerResult;->timestampMs()J

    move-result-wide v5

    cmp-long v1, v3, v5

    if-nez v1, :cond_1

    iget-object v1, p0, Lcom/google/mediapipe/tasks/vision/handlandmarker/AutoValue_HandLandmarkerResult;->landmarks:Ljava/util/List;

    .line 77
    invoke-virtual {p1}, Lcom/google/mediapipe/tasks/vision/handlandmarker/HandLandmarkerResult;->landmarks()Ljava/util/List;

    move-result-object v3

    invoke-interface {v1, v3}, Ljava/util/List;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_1

    iget-object v1, p0, Lcom/google/mediapipe/tasks/vision/handlandmarker/AutoValue_HandLandmarkerResult;->worldLandmarks:Ljava/util/List;

    .line 78
    invoke-virtual {p1}, Lcom/google/mediapipe/tasks/vision/handlandmarker/HandLandmarkerResult;->worldLandmarks()Ljava/util/List;

    move-result-object v3

    invoke-interface {v1, v3}, Ljava/util/List;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_1

    iget-object v1, p0, Lcom/google/mediapipe/tasks/vision/handlandmarker/AutoValue_HandLandmarkerResult;->handedness:Ljava/util/List;

    .line 79
    invoke-virtual {p1}, Lcom/google/mediapipe/tasks/vision/handlandmarker/HandLandmarkerResult;->handedness()Ljava/util/List;

    move-result-object p1

    invoke-interface {v1, p1}, Ljava/util/List;->equals(Ljava/lang/Object;)Z

    move-result p1

    if-eqz p1, :cond_1

    return v0

    :cond_1
    return v2
.end method

.method public handedness()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/tasks/components/containers/Category;",
            ">;>;"
        }
    .end annotation

    .line 56
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/handlandmarker/AutoValue_HandLandmarkerResult;->handedness:Ljava/util/List;

    return-object v0
.end method

.method public hashCode()I
    .locals 4

    .line 88
    iget-wide v0, p0, Lcom/google/mediapipe/tasks/vision/handlandmarker/AutoValue_HandLandmarkerResult;->timestampMs:J

    const/16 v2, 0x20

    ushr-long v2, v0, v2

    xor-long/2addr v0, v2

    long-to-int v0, v0

    const v1, 0xf4243

    xor-int/2addr v0, v1

    mul-int/2addr v0, v1

    .line 90
    iget-object v2, p0, Lcom/google/mediapipe/tasks/vision/handlandmarker/AutoValue_HandLandmarkerResult;->landmarks:Ljava/util/List;

    invoke-interface {v2}, Ljava/util/List;->hashCode()I

    move-result v2

    xor-int/2addr v0, v2

    mul-int/2addr v0, v1

    .line 92
    iget-object v2, p0, Lcom/google/mediapipe/tasks/vision/handlandmarker/AutoValue_HandLandmarkerResult;->worldLandmarks:Ljava/util/List;

    invoke-interface {v2}, Ljava/util/List;->hashCode()I

    move-result v2

    xor-int/2addr v0, v2

    mul-int/2addr v0, v1

    .line 94
    iget-object v1, p0, Lcom/google/mediapipe/tasks/vision/handlandmarker/AutoValue_HandLandmarkerResult;->handedness:Ljava/util/List;

    invoke-interface {v1}, Ljava/util/List;->hashCode()I

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

    .line 46
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/handlandmarker/AutoValue_HandLandmarkerResult;->landmarks:Ljava/util/List;

    return-object v0
.end method

.method public timestampMs()J
    .locals 2

    .line 41
    iget-wide v0, p0, Lcom/google/mediapipe/tasks/vision/handlandmarker/AutoValue_HandLandmarkerResult;->timestampMs:J

    return-wide v0
.end method

.method public toString()Ljava/lang/String;
    .locals 3

    .line 61
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "HandLandmarkerResult{timestampMs="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-wide v1, p0, Lcom/google/mediapipe/tasks/vision/handlandmarker/AutoValue_HandLandmarkerResult;->timestampMs:J

    invoke-virtual {v0, v1, v2}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    const-string v1, ", landmarks="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/google/mediapipe/tasks/vision/handlandmarker/AutoValue_HandLandmarkerResult;->landmarks:Ljava/util/List;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v1, ", worldLandmarks="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/google/mediapipe/tasks/vision/handlandmarker/AutoValue_HandLandmarkerResult;->worldLandmarks:Ljava/util/List;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v1, ", handedness="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/google/mediapipe/tasks/vision/handlandmarker/AutoValue_HandLandmarkerResult;->handedness:Ljava/util/List;

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

    .line 51
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/handlandmarker/AutoValue_HandLandmarkerResult;->worldLandmarks:Ljava/util/List;

    return-object v0
.end method
