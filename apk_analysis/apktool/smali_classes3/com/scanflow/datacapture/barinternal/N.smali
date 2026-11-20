.class public final Lcom/scanflow/datacapture/barinternal/N;
.super Ljava/lang/Object;
.source "SourceFile"


# instance fields
.field public final a:Ljava/io/File;

.field public b:Lcom/google/mediapipe/tasks/vision/objectdetector/ObjectDetector;

.field public final c:Landroid/content/Context;


# direct methods
.method public constructor <init>(Landroid/content/Context;Ljava/io/File;)V
    .locals 0

    .line 1
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/N;->c:Landroid/content/Context;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/N;->a:Ljava/io/File;

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/N;->a()V

    return-void
.end method


# virtual methods
.method public final a(Landroid/graphics/Bitmap;)Ljava/util/ArrayList;
    .locals 8

    .line 1
    const-string v0, "recognizeImage"

    invoke-static {v0}, Landroid/os/Trace;->beginSection(Ljava/lang/String;)V

    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/N;->b:Lcom/google/mediapipe/tasks/vision/objectdetector/ObjectDetector;

    if-nez v1, :cond_0

    return-object v0

    :cond_0
    new-instance v1, Lcom/google/mediapipe/framework/image/BitmapImageBuilder;

    invoke-direct {v1, p1}, Lcom/google/mediapipe/framework/image/BitmapImageBuilder;-><init>(Landroid/graphics/Bitmap;)V

    invoke-virtual {v1}, Lcom/google/mediapipe/framework/image/BitmapImageBuilder;->build()Lcom/google/mediapipe/framework/image/MPImage;

    move-result-object p1

    :try_start_0
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/N;->b:Lcom/google/mediapipe/tasks/vision/objectdetector/ObjectDetector;

    invoke-virtual {v1, p1}, Lcom/google/mediapipe/tasks/vision/objectdetector/ObjectDetector;->detect(Lcom/google/mediapipe/framework/image/MPImage;)Lcom/google/mediapipe/tasks/vision/objectdetector/ObjectDetectorResult;

    move-result-object p1

    invoke-virtual {p1}, Lcom/google/mediapipe/tasks/vision/objectdetector/ObjectDetectionResult;->detections()Ljava/util/List;

    move-result-object p1

    invoke-interface {p1}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object p1

    const/4 v1, 0x0

    move v2, v1

    :cond_1
    :goto_0
    invoke-interface {p1}, Ljava/util/Iterator;->hasNext()Z

    move-result v3

    if-eqz v3, :cond_3

    invoke-interface {p1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Lcom/google/mediapipe/tasks/components/containers/Detection;

    invoke-virtual {v3}, Lcom/google/mediapipe/tasks/components/containers/Detection;->categories()Ljava/util/List;

    move-result-object v4

    if-eqz v4, :cond_1

    invoke-interface {v4}, Ljava/util/List;->isEmpty()Z

    move-result v5

    if-eqz v5, :cond_2

    goto :goto_0

    :cond_2
    new-instance v5, Lcom/scanflow/datacapture/barinternal/b;

    new-instance v6, Ljava/lang/StringBuilder;

    invoke-direct {v6}, Ljava/lang/StringBuilder;-><init>()V

    const-string v7, ""

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    add-int/lit8 v7, v2, 0x1

    invoke-virtual {v6, v2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v6}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-interface {v4, v1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Lcom/google/mediapipe/tasks/components/containers/Category;

    invoke-virtual {v6}, Lcom/google/mediapipe/tasks/components/containers/Category;->categoryName()Ljava/lang/String;

    move-result-object v6

    invoke-interface {v4, v1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Lcom/google/mediapipe/tasks/components/containers/Category;

    invoke-virtual {v4}, Lcom/google/mediapipe/tasks/components/containers/Category;->score()F

    move-result v4

    invoke-virtual {v3}, Lcom/google/mediapipe/tasks/components/containers/Detection;->boundingBox()Landroid/graphics/RectF;

    move-result-object v3

    invoke-direct {v5, v2, v6, v4, v3}, Lcom/scanflow/datacapture/barinternal/b;-><init>(Ljava/lang/String;Ljava/lang/String;FLandroid/graphics/RectF;)V

    invoke-virtual {v0, v5}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    move v2, v7

    goto :goto_0

    :catch_0
    move-exception p1

    invoke-virtual {p1}, Ljava/lang/Throwable;->printStackTrace()V

    :cond_3
    invoke-static {}, Landroid/os/Trace;->endSection()V

    return-object v0
.end method

.method public final a()V
    .locals 8

    .line 2
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/N;->b:Lcom/google/mediapipe/tasks/vision/objectdetector/ObjectDetector;

    if-eqz v0, :cond_0

    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/vision/core/BaseVisionTaskApi;->close()V

    const/4 v0, 0x0

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/N;->b:Lcom/google/mediapipe/tasks/vision/objectdetector/ObjectDetector;

    :cond_0
    :try_start_0
    new-instance v0, Ljava/io/FileInputStream;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/N;->a:Ljava/io/File;

    invoke-direct {v0, v1}, Ljava/io/FileInputStream;-><init>(Ljava/io/File;)V

    invoke-virtual {v0}, Ljava/io/FileInputStream;->getChannel()Ljava/nio/channels/FileChannel;

    move-result-object v2

    sget-object v3, Ljava/nio/channels/FileChannel$MapMode;->READ_ONLY:Ljava/nio/channels/FileChannel$MapMode;

    invoke-virtual {v2}, Ljava/nio/channels/FileChannel;->size()J

    move-result-wide v6

    const-wide/16 v4, 0x0

    invoke-virtual/range {v2 .. v7}, Ljava/nio/channels/FileChannel;->map(Ljava/nio/channels/FileChannel$MapMode;JJ)Ljava/nio/MappedByteBuffer;

    move-result-object v0

    invoke-static {}, Lcom/google/mediapipe/tasks/core/BaseOptions;->builder()Lcom/google/mediapipe/tasks/core/BaseOptions$Builder;

    move-result-object v1

    invoke-virtual {v1, v0}, Lcom/google/mediapipe/tasks/core/BaseOptions$Builder;->setModelAssetBuffer(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/tasks/core/BaseOptions$Builder;

    move-result-object v0

    sget-object v1, Lcom/google/mediapipe/tasks/core/Delegate;->CPU:Lcom/google/mediapipe/tasks/core/Delegate;

    invoke-virtual {v0, v1}, Lcom/google/mediapipe/tasks/core/BaseOptions$Builder;->setDelegate(Lcom/google/mediapipe/tasks/core/Delegate;)Lcom/google/mediapipe/tasks/core/BaseOptions$Builder;

    invoke-static {}, Lcom/google/mediapipe/tasks/vision/objectdetector/ObjectDetector$ObjectDetectorOptions;->builder()Lcom/google/mediapipe/tasks/vision/objectdetector/ObjectDetector$ObjectDetectorOptions$Builder;

    move-result-object v1

    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/core/BaseOptions$Builder;->build()Lcom/google/mediapipe/tasks/core/BaseOptions;

    move-result-object v0

    invoke-virtual {v1, v0}, Lcom/google/mediapipe/tasks/vision/objectdetector/ObjectDetector$ObjectDetectorOptions$Builder;->setBaseOptions(Lcom/google/mediapipe/tasks/core/BaseOptions;)Lcom/google/mediapipe/tasks/vision/objectdetector/ObjectDetector$ObjectDetectorOptions$Builder;

    move-result-object v0

    sget-object v1, Lcom/google/mediapipe/tasks/vision/core/RunningMode;->IMAGE:Lcom/google/mediapipe/tasks/vision/core/RunningMode;

    invoke-virtual {v0, v1}, Lcom/google/mediapipe/tasks/vision/objectdetector/ObjectDetector$ObjectDetectorOptions$Builder;->setRunningMode(Lcom/google/mediapipe/tasks/vision/core/RunningMode;)Lcom/google/mediapipe/tasks/vision/objectdetector/ObjectDetector$ObjectDetectorOptions$Builder;

    move-result-object v0

    const/16 v1, 0x2d

    invoke-static {v1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v1

    invoke-virtual {v0, v1}, Lcom/google/mediapipe/tasks/vision/objectdetector/ObjectDetector$ObjectDetectorOptions$Builder;->setMaxResults(Ljava/lang/Integer;)Lcom/google/mediapipe/tasks/vision/objectdetector/ObjectDetector$ObjectDetectorOptions$Builder;

    move-result-object v0

    const v1, 0x3e4ccccd    # 0.2f

    invoke-static {v1}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v1

    invoke-virtual {v0, v1}, Lcom/google/mediapipe/tasks/vision/objectdetector/ObjectDetector$ObjectDetectorOptions$Builder;->setScoreThreshold(Ljava/lang/Float;)Lcom/google/mediapipe/tasks/vision/objectdetector/ObjectDetector$ObjectDetectorOptions$Builder;

    move-result-object v0

    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/vision/objectdetector/ObjectDetector$ObjectDetectorOptions$Builder;->build()Lcom/google/mediapipe/tasks/vision/objectdetector/ObjectDetector$ObjectDetectorOptions;

    move-result-object v0

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/N;->c:Landroid/content/Context;

    invoke-static {v1, v0}, Lcom/google/mediapipe/tasks/vision/objectdetector/ObjectDetector;->createFromOptions(Landroid/content/Context;Lcom/google/mediapipe/tasks/vision/objectdetector/ObjectDetector$ObjectDetectorOptions;)Lcom/google/mediapipe/tasks/vision/objectdetector/ObjectDetector;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/N;->b:Lcom/google/mediapipe/tasks/vision/objectdetector/ObjectDetector;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    return-void

    :catch_0
    move-exception v0

    invoke-virtual {v0}, Ljava/lang/Throwable;->printStackTrace()V

    return-void
.end method
