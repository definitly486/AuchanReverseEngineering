.class Lcom/google/mediapipe/framework/image/$AutoValue_MPImageProperties$Builder;
.super Lcom/google/mediapipe/framework/image/MPImageProperties$Builder;
.source "$AutoValue_MPImageProperties.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/framework/image/$AutoValue_MPImageProperties;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x8
    name = "Builder"
.end annotation


# instance fields
.field private imageFormat:Ljava/lang/Integer;

.field private storageType:Ljava/lang/Integer;


# direct methods
.method constructor <init>()V
    .locals 0

    .line 63
    invoke-direct {p0}, Lcom/google/mediapipe/framework/image/MPImageProperties$Builder;-><init>()V

    return-void
.end method


# virtual methods
.method build()Lcom/google/mediapipe/framework/image/MPImageProperties;
    .locals 4

    .line 78
    iget-object v0, p0, Lcom/google/mediapipe/framework/image/$AutoValue_MPImageProperties$Builder;->imageFormat:Ljava/lang/Integer;

    const-string v1, ""

    if-nez v0, :cond_0

    .line 79
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, " imageFormat"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    .line 81
    :cond_0
    iget-object v0, p0, Lcom/google/mediapipe/framework/image/$AutoValue_MPImageProperties$Builder;->storageType:Ljava/lang/Integer;

    if-nez v0, :cond_1

    .line 82
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, " storageType"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    .line 84
    :cond_1
    invoke-virtual {v1}, Ljava/lang/String;->isEmpty()Z

    move-result v0

    if-eqz v0, :cond_2

    .line 87
    new-instance v0, Lcom/google/mediapipe/framework/image/AutoValue_MPImageProperties;

    iget-object v1, p0, Lcom/google/mediapipe/framework/image/$AutoValue_MPImageProperties$Builder;->imageFormat:Ljava/lang/Integer;

    .line 88
    invoke-virtual {v1}, Ljava/lang/Integer;->intValue()I

    move-result v1

    iget-object v2, p0, Lcom/google/mediapipe/framework/image/$AutoValue_MPImageProperties$Builder;->storageType:Ljava/lang/Integer;

    .line 89
    invoke-virtual {v2}, Ljava/lang/Integer;->intValue()I

    move-result v2

    invoke-direct {v0, v1, v2}, Lcom/google/mediapipe/framework/image/AutoValue_MPImageProperties;-><init>(II)V

    return-object v0

    .line 85
    :cond_2
    new-instance v0, Ljava/lang/IllegalStateException;

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "Missing required properties:"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method setImageFormat(I)Lcom/google/mediapipe/framework/image/MPImageProperties$Builder;
    .locals 0

    .line 67
    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/framework/image/$AutoValue_MPImageProperties$Builder;->imageFormat:Ljava/lang/Integer;

    return-object p0
.end method

.method setStorageType(I)Lcom/google/mediapipe/framework/image/MPImageProperties$Builder;
    .locals 0

    .line 72
    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/framework/image/$AutoValue_MPImageProperties$Builder;->storageType:Ljava/lang/Integer;

    return-object p0
.end method
