.class final Lcom/google/mediapipe/tasks/vision/core/AutoValue_ImageProcessingOptions;
.super Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions;
.source "AutoValue_ImageProcessingOptions.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/tasks/vision/core/AutoValue_ImageProcessingOptions$Builder;
    }
.end annotation


# instance fields
.field private final regionOfInterest:Ljava/util/Optional;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Optional<",
            "Landroid/graphics/RectF;",
            ">;"
        }
    .end annotation
.end field

.field private final rotationDegrees:I


# direct methods
.method private constructor <init>(Ljava/util/Optional;I)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/Optional<",
            "Landroid/graphics/RectF;",
            ">;I)V"
        }
    .end annotation

    .line 15
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions;-><init>()V

    .line 16
    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/core/AutoValue_ImageProcessingOptions;->regionOfInterest:Ljava/util/Optional;

    .line 17
    iput p2, p0, Lcom/google/mediapipe/tasks/vision/core/AutoValue_ImageProcessingOptions;->rotationDegrees:I

    return-void
.end method

.method synthetic constructor <init>(Ljava/util/Optional;ILcom/google/mediapipe/tasks/vision/core/AutoValue_ImageProcessingOptions$1;)V
    .locals 0

    .line 7
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/tasks/vision/core/AutoValue_ImageProcessingOptions;-><init>(Ljava/util/Optional;I)V

    return-void
.end method


# virtual methods
.method public equals(Ljava/lang/Object;)Z
    .locals 4

    const/4 v0, 0x1

    if-ne p1, p0, :cond_0

    return v0

    .line 43
    :cond_0
    instance-of v1, p1, Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions;

    const/4 v2, 0x0

    if-eqz v1, :cond_1

    .line 44
    check-cast p1, Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions;

    .line 45
    iget-object v1, p0, Lcom/google/mediapipe/tasks/vision/core/AutoValue_ImageProcessingOptions;->regionOfInterest:Ljava/util/Optional;

    invoke-virtual {p1}, Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions;->regionOfInterest()Ljava/util/Optional;

    move-result-object v3

    invoke-virtual {v1, v3}, Ljava/util/Optional;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_1

    iget v1, p0, Lcom/google/mediapipe/tasks/vision/core/AutoValue_ImageProcessingOptions;->rotationDegrees:I

    .line 46
    invoke-virtual {p1}, Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions;->rotationDegrees()I

    move-result p1

    if-ne v1, p1, :cond_1

    return v0

    :cond_1
    return v2
.end method

.method public hashCode()I
    .locals 2

    .line 55
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/core/AutoValue_ImageProcessingOptions;->regionOfInterest:Ljava/util/Optional;

    invoke-virtual {v0}, Ljava/util/Optional;->hashCode()I

    move-result v0

    const v1, 0xf4243

    xor-int/2addr v0, v1

    mul-int/2addr v0, v1

    .line 57
    iget v1, p0, Lcom/google/mediapipe/tasks/vision/core/AutoValue_ImageProcessingOptions;->rotationDegrees:I

    xor-int/2addr v0, v1

    return v0
.end method

.method public regionOfInterest()Ljava/util/Optional;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/Optional<",
            "Landroid/graphics/RectF;",
            ">;"
        }
    .end annotation

    .line 22
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/core/AutoValue_ImageProcessingOptions;->regionOfInterest:Ljava/util/Optional;

    return-object v0
.end method

.method public rotationDegrees()I
    .locals 1

    .line 27
    iget v0, p0, Lcom/google/mediapipe/tasks/vision/core/AutoValue_ImageProcessingOptions;->rotationDegrees:I

    return v0
.end method

.method public toString()Ljava/lang/String;
    .locals 2

    .line 32
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "ImageProcessingOptions{regionOfInterest="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/google/mediapipe/tasks/vision/core/AutoValue_ImageProcessingOptions;->regionOfInterest:Ljava/util/Optional;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v1, ", rotationDegrees="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget v1, p0, Lcom/google/mediapipe/tasks/vision/core/AutoValue_ImageProcessingOptions;->rotationDegrees:I

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string v1, "}"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
