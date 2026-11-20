.class final Lcom/google/mediapipe/tasks/vision/core/AutoValue_ImageProcessingOptions$Builder;
.super Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions$Builder;
.source "AutoValue_ImageProcessingOptions.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/tasks/vision/core/AutoValue_ImageProcessingOptions;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x18
    name = "Builder"
.end annotation


# instance fields
.field private regionOfInterest:Ljava/util/Optional;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Optional<",
            "Landroid/graphics/RectF;",
            ">;"
        }
    .end annotation
.end field

.field private rotationDegrees:Ljava/lang/Integer;


# direct methods
.method constructor <init>()V
    .locals 1

    .line 64
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions$Builder;-><init>()V

    .line 62
    invoke-static {}, Ljava/util/Optional;->empty()Ljava/util/Optional;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/tasks/vision/core/AutoValue_ImageProcessingOptions$Builder;->regionOfInterest:Ljava/util/Optional;

    return-void
.end method


# virtual methods
.method autoBuild()Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions;
    .locals 4

    .line 79
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/core/AutoValue_ImageProcessingOptions$Builder;->rotationDegrees:Ljava/lang/Integer;

    const-string v1, ""

    if-nez v0, :cond_0

    .line 80
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, " rotationDegrees"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    .line 82
    :cond_0
    invoke-virtual {v1}, Ljava/lang/String;->isEmpty()Z

    move-result v0

    if-eqz v0, :cond_1

    .line 85
    new-instance v0, Lcom/google/mediapipe/tasks/vision/core/AutoValue_ImageProcessingOptions;

    iget-object v1, p0, Lcom/google/mediapipe/tasks/vision/core/AutoValue_ImageProcessingOptions$Builder;->regionOfInterest:Ljava/util/Optional;

    iget-object v2, p0, Lcom/google/mediapipe/tasks/vision/core/AutoValue_ImageProcessingOptions$Builder;->rotationDegrees:Ljava/lang/Integer;

    .line 87
    invoke-virtual {v2}, Ljava/lang/Integer;->intValue()I

    move-result v2

    const/4 v3, 0x0

    invoke-direct {v0, v1, v2, v3}, Lcom/google/mediapipe/tasks/vision/core/AutoValue_ImageProcessingOptions;-><init>(Ljava/util/Optional;ILcom/google/mediapipe/tasks/vision/core/AutoValue_ImageProcessingOptions$1;)V

    return-object v0

    .line 83
    :cond_1
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

.method public setRegionOfInterest(Landroid/graphics/RectF;)Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions$Builder;
    .locals 0

    .line 68
    invoke-static {p1}, Ljava/util/Optional;->of(Ljava/lang/Object;)Ljava/util/Optional;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/core/AutoValue_ImageProcessingOptions$Builder;->regionOfInterest:Ljava/util/Optional;

    return-object p0
.end method

.method public setRotationDegrees(I)Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions$Builder;
    .locals 0

    .line 73
    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/core/AutoValue_ImageProcessingOptions$Builder;->rotationDegrees:Ljava/lang/Integer;

    return-object p0
.end method
