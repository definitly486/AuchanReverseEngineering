.class final Lcom/google/mediapipe/tasks/vision/interactivesegmenter/AutoValue_InteractiveSegmenter_InteractiveSegmenterOptions$Builder;
.super Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$InteractiveSegmenterOptions$Builder;
.source "AutoValue_InteractiveSegmenter_InteractiveSegmenterOptions.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/tasks/vision/interactivesegmenter/AutoValue_InteractiveSegmenter_InteractiveSegmenterOptions;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x18
    name = "Builder"
.end annotation


# instance fields
.field private baseOptions:Lcom/google/mediapipe/tasks/core/BaseOptions;

.field private errorListener:Ljava/util/Optional;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Optional<",
            "Lcom/google/mediapipe/tasks/core/ErrorListener;",
            ">;"
        }
    .end annotation
.end field

.field private outputCategoryMask:Ljava/lang/Boolean;

.field private outputConfidenceMasks:Ljava/lang/Boolean;

.field private resultListener:Ljava/util/Optional;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Optional<",
            "Lcom/google/mediapipe/tasks/core/OutputHandler$ResultListener<",
            "Lcom/google/mediapipe/tasks/vision/imagesegmenter/ImageSegmenterResult;",
            "Lcom/google/mediapipe/framework/image/MPImage;",
            ">;>;"
        }
    .end annotation
.end field


# direct methods
.method constructor <init>()V
    .locals 1

    .line 110
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$InteractiveSegmenterOptions$Builder;-><init>()V

    .line 108
    invoke-static {}, Ljava/util/Optional;->empty()Ljava/util/Optional;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/AutoValue_InteractiveSegmenter_InteractiveSegmenterOptions$Builder;->resultListener:Ljava/util/Optional;

    .line 109
    invoke-static {}, Ljava/util/Optional;->empty()Ljava/util/Optional;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/AutoValue_InteractiveSegmenter_InteractiveSegmenterOptions$Builder;->errorListener:Ljava/util/Optional;

    return-void
.end method


# virtual methods
.method autoBuild()Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$InteractiveSegmenterOptions;
    .locals 9

    .line 143
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/AutoValue_InteractiveSegmenter_InteractiveSegmenterOptions$Builder;->baseOptions:Lcom/google/mediapipe/tasks/core/BaseOptions;

    const-string v1, ""

    if-nez v0, :cond_0

    .line 144
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, " baseOptions"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    .line 146
    :cond_0
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/AutoValue_InteractiveSegmenter_InteractiveSegmenterOptions$Builder;->outputConfidenceMasks:Ljava/lang/Boolean;

    if-nez v0, :cond_1

    .line 147
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, " outputConfidenceMasks"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    .line 149
    :cond_1
    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/AutoValue_InteractiveSegmenter_InteractiveSegmenterOptions$Builder;->outputCategoryMask:Ljava/lang/Boolean;

    if-nez v0, :cond_2

    .line 150
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, " outputCategoryMask"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    .line 152
    :cond_2
    invoke-virtual {v1}, Ljava/lang/String;->isEmpty()Z

    move-result v0

    if-eqz v0, :cond_3

    .line 155
    new-instance v2, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/AutoValue_InteractiveSegmenter_InteractiveSegmenterOptions;

    iget-object v3, p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/AutoValue_InteractiveSegmenter_InteractiveSegmenterOptions$Builder;->baseOptions:Lcom/google/mediapipe/tasks/core/BaseOptions;

    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/AutoValue_InteractiveSegmenter_InteractiveSegmenterOptions$Builder;->outputConfidenceMasks:Ljava/lang/Boolean;

    .line 157
    invoke-virtual {v0}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v4

    iget-object v0, p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/AutoValue_InteractiveSegmenter_InteractiveSegmenterOptions$Builder;->outputCategoryMask:Ljava/lang/Boolean;

    .line 158
    invoke-virtual {v0}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v5

    iget-object v6, p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/AutoValue_InteractiveSegmenter_InteractiveSegmenterOptions$Builder;->resultListener:Ljava/util/Optional;

    iget-object v7, p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/AutoValue_InteractiveSegmenter_InteractiveSegmenterOptions$Builder;->errorListener:Ljava/util/Optional;

    const/4 v8, 0x0

    invoke-direct/range {v2 .. v8}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/AutoValue_InteractiveSegmenter_InteractiveSegmenterOptions;-><init>(Lcom/google/mediapipe/tasks/core/BaseOptions;ZZLjava/util/Optional;Ljava/util/Optional;Lcom/google/mediapipe/tasks/vision/interactivesegmenter/AutoValue_InteractiveSegmenter_InteractiveSegmenterOptions$1;)V

    return-object v2

    .line 153
    :cond_3
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

.method public setBaseOptions(Lcom/google/mediapipe/tasks/core/BaseOptions;)Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$InteractiveSegmenterOptions$Builder;
    .locals 1

    if-eqz p1, :cond_0

    .line 117
    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/AutoValue_InteractiveSegmenter_InteractiveSegmenterOptions$Builder;->baseOptions:Lcom/google/mediapipe/tasks/core/BaseOptions;

    return-object p0

    .line 115
    :cond_0
    new-instance p1, Ljava/lang/NullPointerException;

    const-string v0, "Null baseOptions"

    invoke-direct {p1, v0}, Ljava/lang/NullPointerException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public setErrorListener(Lcom/google/mediapipe/tasks/core/ErrorListener;)Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$InteractiveSegmenterOptions$Builder;
    .locals 0

    .line 137
    invoke-static {p1}, Ljava/util/Optional;->of(Ljava/lang/Object;)Ljava/util/Optional;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/AutoValue_InteractiveSegmenter_InteractiveSegmenterOptions$Builder;->errorListener:Ljava/util/Optional;

    return-object p0
.end method

.method public setOutputCategoryMask(Z)Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$InteractiveSegmenterOptions$Builder;
    .locals 0

    .line 127
    invoke-static {p1}, Ljava/lang/Boolean;->valueOf(Z)Ljava/lang/Boolean;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/AutoValue_InteractiveSegmenter_InteractiveSegmenterOptions$Builder;->outputCategoryMask:Ljava/lang/Boolean;

    return-object p0
.end method

.method public setOutputConfidenceMasks(Z)Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$InteractiveSegmenterOptions$Builder;
    .locals 0

    .line 122
    invoke-static {p1}, Ljava/lang/Boolean;->valueOf(Z)Ljava/lang/Boolean;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/AutoValue_InteractiveSegmenter_InteractiveSegmenterOptions$Builder;->outputConfidenceMasks:Ljava/lang/Boolean;

    return-object p0
.end method

.method public setResultListener(Lcom/google/mediapipe/tasks/core/OutputHandler$ResultListener;)Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$InteractiveSegmenterOptions$Builder;
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/google/mediapipe/tasks/core/OutputHandler$ResultListener<",
            "Lcom/google/mediapipe/tasks/vision/imagesegmenter/ImageSegmenterResult;",
            "Lcom/google/mediapipe/framework/image/MPImage;",
            ">;)",
            "Lcom/google/mediapipe/tasks/vision/interactivesegmenter/InteractiveSegmenter$InteractiveSegmenterOptions$Builder;"
        }
    .end annotation

    .line 132
    invoke-static {p1}, Ljava/util/Optional;->of(Ljava/lang/Object;)Ljava/util/Optional;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/AutoValue_InteractiveSegmenter_InteractiveSegmenterOptions$Builder;->resultListener:Ljava/util/Optional;

    return-object p0
.end method
