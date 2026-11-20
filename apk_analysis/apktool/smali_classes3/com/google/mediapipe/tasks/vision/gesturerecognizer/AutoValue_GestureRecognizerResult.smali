.class final Lcom/google/mediapipe/tasks/vision/gesturerecognizer/AutoValue_GestureRecognizerResult;
.super Lcom/google/mediapipe/tasks/vision/gesturerecognizer/GestureRecognizerResult;
.source "AutoValue_GestureRecognizerResult.java"


# instance fields
.field private final gestures:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List<",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/tasks/components/containers/Category;",
            ">;>;"
        }
    .end annotation
.end field

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
.method constructor <init>(JLjava/util/List;Ljava/util/List;Ljava/util/List;Ljava/util/List;)V
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
            ">;>;",
            "Ljava/util/List<",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/tasks/components/containers/Category;",
            ">;>;)V"
        }
    .end annotation

    .line 26
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/GestureRecognizerResult;-><init>()V

    .line 27
    iput-wide p1, p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/AutoValue_GestureRecognizerResult;->timestampMs:J

    if-eqz p3, :cond_3

    .line 31
    iput-object p3, p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/AutoValue_GestureRecognizerResult;->landmarks:Ljava/util/List;

    if-eqz p4, :cond_2

    .line 35
    iput-object p4, p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/AutoValue_GestureRecognizerResult;->worldLandmarks:Ljava/util/List;

    if-eqz p5, :cond_1

    .line 39
    iput-object p5, p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/AutoValue_GestureRecognizerResult;->handedness:Ljava/util/List;

    if-eqz p6, :cond_0

    .line 43
    iput-object p6, p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/AutoValue_GestureRecognizerResult;->gestures:Ljava/util/List;

    return-void

    .line 41
    :cond_0
    new-instance p1, Ljava/lang/NullPointerException;

    const-string p2, "Null gestures"

    invoke-direct {p1, p2}, Ljava/lang/NullPointerException;-><init>(Ljava/lang/String;)V

    throw p1

    .line 37
    :cond_1
    new-instance p1, Ljava/lang/NullPointerException;

    const-string p2, "Null handedness"

    invoke-direct {p1, p2}, Ljava/lang/NullPointerException;-><init>(Ljava/lang/String;)V

    throw p1

    .line 33
    :cond_2
    new-instance p1, Ljava/lang/NullPointerException;

    const-string p2, "Null worldLandmarks"

    invoke-direct {p1, p2}, Ljava/lang/NullPointerException;-><init>(Ljava/lang/String;)V

    throw p1

    .line 29
    :cond_3
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

    .line 87
    :cond_0
    instance-of v1, p1, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/GestureRecognizerResult;

    const/4 v2, 0x0

    if-eqz v1, :cond_1

    .line 88
    check-cast p1, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/GestureRecognizerResult;

    .line 89
    iget-wide v3, p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/AutoValue_GestureRecognizerResult;->timestampMs:J

    invoke-virtual {p1}, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/GestureRecognizerResult;->timestampMs()J

    move-result-wide v5

    cmp-long v1, v3, v5

    if-nez v1, :cond_1

    iget-object v1, p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/AutoValue_GestureRecognizerResult;->landmarks:Ljava/util/List;

    .line 90
    invoke-virtual {p1}, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/GestureRecognizerResult;->landmarks()Ljava/util/List;

    move-result-object v3

    invoke-interface {v1, v3}, Ljava/util/List;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_1

    iget-object v1, p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/AutoValue_GestureRecognizerResult;->worldLandmarks:Ljava/util/List;

    .line 91
    invoke-virtual {p1}, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/GestureRecognizerResult;->worldLandmarks()Ljava/util/List;

    move-result-object v3

    invoke-interface {v1, v3}, Ljava/util/List;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_1

    iget-object v1, p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/AutoValue_GestureRecognizerResult;->handedness:Ljava/util/List;

    .line 92
    invoke-virtual {p1}, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/GestureRecognizerResult;->handedness()Ljava/util/List;

    move-result-object v3

    invoke-interface {v1, v3}, Ljava/util/List;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_1

    iget-object v1, p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/AutoValue_GestureRecognizerResult;->gestures:Ljava/util/List;

    .line 93
    invoke-virtual {p1}, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/GestureRecognizerResult;->gestures()Ljava/util/List;

    move-result-object p1

    invoke-interface {v1, p1}, Ljava/util/List;->equals(Ljava/lang/Object;)Z

    move-result p1

    if-eqz p1, :cond_1

    return v0

    :cond_1
    return v2
.end method

.method public gestures()Ljava/util/List;
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

    .line 68
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/AutoValue_GestureRecognizerResult;->gestures:Ljava/util/List;

    return-object v0
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

    .line 63
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/AutoValue_GestureRecognizerResult;->handedness:Ljava/util/List;

    return-object v0
.end method

.method public hashCode()I
    .locals 4

    .line 102
    iget-wide v0, p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/AutoValue_GestureRecognizerResult;->timestampMs:J

    const/16 v2, 0x20

    ushr-long v2, v0, v2

    xor-long/2addr v0, v2

    long-to-int v0, v0

    const v1, 0xf4243

    xor-int/2addr v0, v1

    mul-int/2addr v0, v1

    .line 104
    iget-object v2, p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/AutoValue_GestureRecognizerResult;->landmarks:Ljava/util/List;

    invoke-interface {v2}, Ljava/util/List;->hashCode()I

    move-result v2

    xor-int/2addr v0, v2

    mul-int/2addr v0, v1

    .line 106
    iget-object v2, p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/AutoValue_GestureRecognizerResult;->worldLandmarks:Ljava/util/List;

    invoke-interface {v2}, Ljava/util/List;->hashCode()I

    move-result v2

    xor-int/2addr v0, v2

    mul-int/2addr v0, v1

    .line 108
    iget-object v2, p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/AutoValue_GestureRecognizerResult;->handedness:Ljava/util/List;

    invoke-interface {v2}, Ljava/util/List;->hashCode()I

    move-result v2

    xor-int/2addr v0, v2

    mul-int/2addr v0, v1

    .line 110
    iget-object v1, p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/AutoValue_GestureRecognizerResult;->gestures:Ljava/util/List;

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

    .line 53
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/AutoValue_GestureRecognizerResult;->landmarks:Ljava/util/List;

    return-object v0
.end method

.method public timestampMs()J
    .locals 2

    .line 48
    iget-wide v0, p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/AutoValue_GestureRecognizerResult;->timestampMs:J

    return-wide v0
.end method

.method public toString()Ljava/lang/String;
    .locals 3

    .line 73
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "GestureRecognizerResult{timestampMs="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-wide v1, p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/AutoValue_GestureRecognizerResult;->timestampMs:J

    invoke-virtual {v0, v1, v2}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    const-string v1, ", landmarks="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/AutoValue_GestureRecognizerResult;->landmarks:Ljava/util/List;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v1, ", worldLandmarks="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/AutoValue_GestureRecognizerResult;->worldLandmarks:Ljava/util/List;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v1, ", handedness="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/AutoValue_GestureRecognizerResult;->handedness:Ljava/util/List;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v1, ", gestures="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/AutoValue_GestureRecognizerResult;->gestures:Ljava/util/List;

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

    .line 58
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/gesturerecognizer/AutoValue_GestureRecognizerResult;->worldLandmarks:Ljava/util/List;

    return-object v0
.end method
