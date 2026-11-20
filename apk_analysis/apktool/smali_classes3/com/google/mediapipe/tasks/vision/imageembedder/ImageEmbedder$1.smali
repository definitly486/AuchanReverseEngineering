.class Lcom/google/mediapipe/tasks/vision/imageembedder/ImageEmbedder$1;
.super Ljava/lang/Object;
.source "ImageEmbedder.java"

# interfaces
.implements Lcom/google/mediapipe/tasks/core/OutputHandler$OutputPacketConverter;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/google/mediapipe/tasks/vision/imageembedder/ImageEmbedder;->createFromOptions(Landroid/content/Context;Lcom/google/mediapipe/tasks/vision/imageembedder/ImageEmbedder$ImageEmbedderOptions;)Lcom/google/mediapipe/tasks/vision/imageembedder/ImageEmbedder;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Object;",
        "Lcom/google/mediapipe/tasks/core/OutputHandler$OutputPacketConverter<",
        "Lcom/google/mediapipe/tasks/vision/imageembedder/ImageEmbedderResult;",
        "Lcom/google/mediapipe/framework/image/MPImage;",
        ">;"
    }
.end annotation


# instance fields
.field final synthetic val$options:Lcom/google/mediapipe/tasks/vision/imageembedder/ImageEmbedder$ImageEmbedderOptions;


# direct methods
.method constructor <init>(Lcom/google/mediapipe/tasks/vision/imageembedder/ImageEmbedder$ImageEmbedderOptions;)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()V"
        }
    .end annotation

    .line 154
    iput-object p1, p0, Lcom/google/mediapipe/tasks/vision/imageembedder/ImageEmbedder$1;->val$options:Lcom/google/mediapipe/tasks/vision/imageembedder/ImageEmbedder$ImageEmbedderOptions;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public convertToTaskInput(Ljava/util/List;)Lcom/google/mediapipe/framework/image/MPImage;
    .locals 2
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/framework/Packet;",
            ">;)",
            "Lcom/google/mediapipe/framework/image/MPImage;"
        }
    .end annotation

    .line 173
    new-instance v0, Lcom/google/mediapipe/framework/image/BitmapImageBuilder;

    const/4 v1, 0x1

    .line 174
    invoke-interface {p1, v1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/framework/Packet;

    invoke-static {p1}, Lcom/google/mediapipe/framework/AndroidPacketGetter;->getBitmap(Lcom/google/mediapipe/framework/Packet;)Landroid/graphics/Bitmap;

    move-result-object p1

    invoke-direct {v0, p1}, Lcom/google/mediapipe/framework/image/BitmapImageBuilder;-><init>(Landroid/graphics/Bitmap;)V

    .line 175
    invoke-virtual {v0}, Lcom/google/mediapipe/framework/image/BitmapImageBuilder;->build()Lcom/google/mediapipe/framework/image/MPImage;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic convertToTaskInput(Ljava/util/List;)Ljava/lang/Object;
    .locals 0

    .line 154
    invoke-virtual {p0, p1}, Lcom/google/mediapipe/tasks/vision/imageembedder/ImageEmbedder$1;->convertToTaskInput(Ljava/util/List;)Lcom/google/mediapipe/framework/image/MPImage;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic convertToTaskResult(Ljava/util/List;)Lcom/google/mediapipe/tasks/core/TaskResult;
    .locals 0

    .line 154
    invoke-virtual {p0, p1}, Lcom/google/mediapipe/tasks/vision/imageembedder/ImageEmbedder$1;->convertToTaskResult(Ljava/util/List;)Lcom/google/mediapipe/tasks/vision/imageembedder/ImageEmbedderResult;

    move-result-object p1

    return-object p1
.end method

.method public convertToTaskResult(Ljava/util/List;)Lcom/google/mediapipe/tasks/vision/imageembedder/ImageEmbedderResult;
    .locals 4
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/List<",
            "Lcom/google/mediapipe/framework/Packet;",
            ">;)",
            "Lcom/google/mediapipe/tasks/vision/imageembedder/ImageEmbedderResult;"
        }
    .end annotation

    const/4 v0, 0x0

    .line 161
    :try_start_0
    invoke-interface {p1, v0}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/google/mediapipe/framework/Packet;

    .line 162
    invoke-static {}, Lcom/google/mediapipe/tasks/components/containers/proto/EmbeddingsProto$EmbeddingResult;->getDefaultInstance()Lcom/google/mediapipe/tasks/components/containers/proto/EmbeddingsProto$EmbeddingResult;

    move-result-object v2

    .line 160
    invoke-static {v1, v2}, Lcom/google/mediapipe/framework/PacketGetter;->getProto(Lcom/google/mediapipe/framework/Packet;Lcom/google/protobuf/MessageLite;)Lcom/google/protobuf/MessageLite;

    move-result-object v1

    check-cast v1, Lcom/google/mediapipe/tasks/components/containers/proto/EmbeddingsProto$EmbeddingResult;

    .line 159
    invoke-static {v1}, Lcom/google/mediapipe/tasks/components/containers/EmbeddingResult;->createFromProto(Lcom/google/mediapipe/tasks/components/containers/proto/EmbeddingsProto$EmbeddingResult;)Lcom/google/mediapipe/tasks/components/containers/EmbeddingResult;

    move-result-object v1

    iget-object v2, p0, Lcom/google/mediapipe/tasks/vision/imageembedder/ImageEmbedder$1;->val$options:Lcom/google/mediapipe/tasks/vision/imageembedder/ImageEmbedder$ImageEmbedderOptions;

    .line 164
    invoke-virtual {v2}, Lcom/google/mediapipe/tasks/vision/imageembedder/ImageEmbedder$ImageEmbedderOptions;->runningMode()Lcom/google/mediapipe/tasks/vision/core/RunningMode;

    move-result-object v2

    invoke-interface {p1, v0}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/framework/Packet;

    .line 163
    invoke-static {v2, p1}, Lcom/google/mediapipe/tasks/vision/core/BaseVisionTaskApi;->generateResultTimestampMs(Lcom/google/mediapipe/tasks/vision/core/RunningMode;Lcom/google/mediapipe/framework/Packet;)J

    move-result-wide v2

    .line 158
    invoke-static {v1, v2, v3}, Lcom/google/mediapipe/tasks/vision/imageembedder/ImageEmbedderResult;->create(Lcom/google/mediapipe/tasks/components/containers/EmbeddingResult;J)Lcom/google/mediapipe/tasks/vision/imageembedder/ImageEmbedderResult;

    move-result-object p1
    :try_end_0
    .catch Ljava/io/IOException; {:try_start_0 .. :try_end_0} :catch_0

    return-object p1

    :catch_0
    move-exception p1

    .line 166
    new-instance v0, Lcom/google/mediapipe/framework/MediaPipeException;

    sget-object v1, Lcom/google/mediapipe/framework/MediaPipeException$StatusCode;->INTERNAL:Lcom/google/mediapipe/framework/MediaPipeException$StatusCode;

    .line 167
    invoke-virtual {v1}, Ljava/lang/Enum;->ordinal()I

    move-result v1

    invoke-virtual {p1}, Ljava/lang/Throwable;->getMessage()Ljava/lang/String;

    move-result-object p1

    invoke-direct {v0, v1, p1}, Lcom/google/mediapipe/framework/MediaPipeException;-><init>(ILjava/lang/String;)V

    throw v0
.end method
