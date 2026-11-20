.class abstract Lcom/google/mediapipe/framework/image/$AutoValue_MPImageProperties;
.super Lcom/google/mediapipe/framework/image/MPImageProperties;
.source "$AutoValue_MPImageProperties.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/framework/image/$AutoValue_MPImageProperties$Builder;
    }
.end annotation


# instance fields
.field private final imageFormat:I

.field private final storageType:I


# direct methods
.method constructor <init>(II)V
    .locals 0

    .line 12
    invoke-direct {p0}, Lcom/google/mediapipe/framework/image/MPImageProperties;-><init>()V

    .line 13
    iput p1, p0, Lcom/google/mediapipe/framework/image/$AutoValue_MPImageProperties;->imageFormat:I

    .line 14
    iput p2, p0, Lcom/google/mediapipe/framework/image/$AutoValue_MPImageProperties;->storageType:I

    return-void
.end method


# virtual methods
.method public equals(Ljava/lang/Object;)Z
    .locals 4

    const/4 v0, 0x1

    if-ne p1, p0, :cond_0

    return v0

    .line 42
    :cond_0
    instance-of v1, p1, Lcom/google/mediapipe/framework/image/MPImageProperties;

    const/4 v2, 0x0

    if-eqz v1, :cond_1

    .line 43
    check-cast p1, Lcom/google/mediapipe/framework/image/MPImageProperties;

    .line 44
    iget v1, p0, Lcom/google/mediapipe/framework/image/$AutoValue_MPImageProperties;->imageFormat:I

    invoke-virtual {p1}, Lcom/google/mediapipe/framework/image/MPImageProperties;->getImageFormat()I

    move-result v3

    if-ne v1, v3, :cond_1

    iget v1, p0, Lcom/google/mediapipe/framework/image/$AutoValue_MPImageProperties;->storageType:I

    .line 45
    invoke-virtual {p1}, Lcom/google/mediapipe/framework/image/MPImageProperties;->getStorageType()I

    move-result p1

    if-ne v1, p1, :cond_1

    return v0

    :cond_1
    return v2
.end method

.method public getImageFormat()I
    .locals 1

    .line 20
    iget v0, p0, Lcom/google/mediapipe/framework/image/$AutoValue_MPImageProperties;->imageFormat:I

    return v0
.end method

.method public getStorageType()I
    .locals 1

    .line 26
    iget v0, p0, Lcom/google/mediapipe/framework/image/$AutoValue_MPImageProperties;->storageType:I

    return v0
.end method

.method public hashCode()I
    .locals 2

    .line 54
    iget v0, p0, Lcom/google/mediapipe/framework/image/$AutoValue_MPImageProperties;->imageFormat:I

    const v1, 0xf4243

    xor-int/2addr v0, v1

    mul-int/2addr v0, v1

    .line 56
    iget v1, p0, Lcom/google/mediapipe/framework/image/$AutoValue_MPImageProperties;->storageType:I

    xor-int/2addr v0, v1

    return v0
.end method

.method public toString()Ljava/lang/String;
    .locals 2

    .line 31
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "MPImageProperties{imageFormat="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget v1, p0, Lcom/google/mediapipe/framework/image/$AutoValue_MPImageProperties;->imageFormat:I

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string v1, ", storageType="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget v1, p0, Lcom/google/mediapipe/framework/image/$AutoValue_MPImageProperties;->storageType:I

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string v1, "}"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
