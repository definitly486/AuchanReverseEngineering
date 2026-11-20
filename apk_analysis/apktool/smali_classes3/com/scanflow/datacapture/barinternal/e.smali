.class public abstract Lcom/scanflow/datacapture/barinternal/e;
.super Ljava/lang/Object;
.source "SourceFile"


# instance fields
.field public final a:Lcom/google/mediapipe/tasks/vision/imageclassifier/ImageClassifier;


# direct methods
.method public constructor <init>(Landroid/app/Activity;)V
    .locals 3

    .line 1
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    invoke-static {}, Lcom/google/mediapipe/tasks/core/BaseOptions;->builder()Lcom/google/mediapipe/tasks/core/BaseOptions$Builder;

    move-result-object v0

    const-string v1, "efficientnet-lite0-blur-v1.3.tflite"

    invoke-virtual {v0, v1}, Lcom/google/mediapipe/tasks/core/BaseOptions$Builder;->setModelAssetPath(Ljava/lang/String;)Lcom/google/mediapipe/tasks/core/BaseOptions$Builder;

    move-result-object v0

    const/4 v1, 0x1

    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/c;->a(I)I

    move-result v2

    if-eq v2, v1, :cond_1

    const/4 v1, 0x2

    if-eq v2, v1, :cond_0

    goto :goto_1

    :cond_0
    sget-object v1, Lcom/google/mediapipe/tasks/core/Delegate;->GPU:Lcom/google/mediapipe/tasks/core/Delegate;

    :goto_0
    invoke-virtual {v0, v1}, Lcom/google/mediapipe/tasks/core/BaseOptions$Builder;->setDelegate(Lcom/google/mediapipe/tasks/core/Delegate;)Lcom/google/mediapipe/tasks/core/BaseOptions$Builder;

    goto :goto_2

    :cond_1
    :goto_1
    sget-object v1, Lcom/google/mediapipe/tasks/core/Delegate;->CPU:Lcom/google/mediapipe/tasks/core/Delegate;

    goto :goto_0

    :goto_2
    invoke-static {}, Lcom/google/mediapipe/tasks/vision/imageclassifier/ImageClassifier$ImageClassifierOptions;->builder()Lcom/google/mediapipe/tasks/vision/imageclassifier/ImageClassifier$ImageClassifierOptions$Builder;

    move-result-object v1

    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/core/BaseOptions$Builder;->build()Lcom/google/mediapipe/tasks/core/BaseOptions;

    move-result-object v0

    invoke-virtual {v1, v0}, Lcom/google/mediapipe/tasks/vision/imageclassifier/ImageClassifier$ImageClassifierOptions$Builder;->setBaseOptions(Lcom/google/mediapipe/tasks/core/BaseOptions;)Lcom/google/mediapipe/tasks/vision/imageclassifier/ImageClassifier$ImageClassifierOptions$Builder;

    move-result-object v0

    const/4 v1, 0x3

    invoke-static {v1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v1

    invoke-virtual {v0, v1}, Lcom/google/mediapipe/tasks/vision/imageclassifier/ImageClassifier$ImageClassifierOptions$Builder;->setMaxResults(Ljava/lang/Integer;)Lcom/google/mediapipe/tasks/vision/imageclassifier/ImageClassifier$ImageClassifierOptions$Builder;

    move-result-object v0

    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/vision/imageclassifier/ImageClassifier$ImageClassifierOptions$Builder;->build()Lcom/google/mediapipe/tasks/vision/imageclassifier/ImageClassifier$ImageClassifierOptions;

    move-result-object v0

    invoke-static {p1, v0}, Lcom/google/mediapipe/tasks/vision/imageclassifier/ImageClassifier;->createFromOptions(Landroid/content/Context;Lcom/google/mediapipe/tasks/vision/imageclassifier/ImageClassifier$ImageClassifierOptions;)Lcom/google/mediapipe/tasks/vision/imageclassifier/ImageClassifier;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/e;->a:Lcom/google/mediapipe/tasks/vision/imageclassifier/ImageClassifier;

    const-string p1, "MediaPipeBlurClassifier"

    const-string v0, "Created MediaPipe Image Classifier successfully"

    invoke-static {p1, v0}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    return-void
.end method


# virtual methods
.method public final a(Landroid/graphics/Bitmap;I)Ljava/util/ArrayList;
    .locals 9

    const-string v0, "recognizeImage"

    invoke-static {v0}, Landroid/os/Trace;->beginSection(Ljava/lang/String;)V

    new-instance v0, Lcom/google/mediapipe/framework/image/BitmapImageBuilder;

    invoke-direct {v0, p1}, Lcom/google/mediapipe/framework/image/BitmapImageBuilder;-><init>(Landroid/graphics/Bitmap;)V

    invoke-virtual {v0}, Lcom/google/mediapipe/framework/image/BitmapImageBuilder;->build()Lcom/google/mediapipe/framework/image/MPImage;

    move-result-object v0

    invoke-virtual {p1}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v1

    invoke-virtual {p1}, Landroid/graphics/Bitmap;->getHeight()I

    move-result p1

    invoke-static {v1, p1}, Ljava/lang/Math;->min(II)I

    move-result v2

    invoke-static {}, Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions;->builder()Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions$Builder;

    move-result-object v3

    invoke-virtual {v3, p2}, Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions$Builder;->setRotationDegrees(I)Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions$Builder;

    move-result-object p2

    new-instance v3, Landroid/graphics/RectF;

    sub-int v4, v1, v2

    int-to-float v4, v4

    const/high16 v5, 0x40000000    # 2.0f

    div-float/2addr v4, v5

    int-to-float v6, v1

    div-float/2addr v4, v6

    sub-int v7, p1, v2

    int-to-float v7, v7

    div-float/2addr v7, v5

    int-to-float v8, p1

    div-float/2addr v7, v8

    add-int/2addr v1, v2

    int-to-float v1, v1

    div-float/2addr v1, v5

    div-float/2addr v1, v6

    add-int/2addr p1, v2

    int-to-float p1, p1

    div-float/2addr p1, v5

    div-float/2addr p1, v8

    invoke-direct {v3, v4, v7, v1, p1}, Landroid/graphics/RectF;-><init>(FFFF)V

    invoke-virtual {p2, v3}, Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions$Builder;->setRegionOfInterest(Landroid/graphics/RectF;)Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions$Builder;

    move-result-object p1

    invoke-virtual {p1}, Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions$Builder;->build()Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions;

    move-result-object p1

    const-string p2, "runInference"

    invoke-static {p2}, Landroid/os/Trace;->beginSection(Ljava/lang/String;)V

    invoke-static {}, Landroid/os/SystemClock;->uptimeMillis()J

    move-result-wide v1

    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/e;->a:Lcom/google/mediapipe/tasks/vision/imageclassifier/ImageClassifier;

    invoke-virtual {p2, v0, p1}, Lcom/google/mediapipe/tasks/vision/imageclassifier/ImageClassifier;->classify(Lcom/google/mediapipe/framework/image/MPImage;Lcom/google/mediapipe/tasks/vision/core/ImageProcessingOptions;)Lcom/google/mediapipe/tasks/vision/imageclassifier/ImageClassifierResult;

    move-result-object p1

    invoke-static {}, Landroid/os/SystemClock;->uptimeMillis()J

    move-result-wide v3

    invoke-static {}, Landroid/os/Trace;->endSection()V

    new-instance p2, Ljava/lang/StringBuilder;

    const-string v0, "Inference completed in: "

    invoke-direct {p2, v0}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    sub-long/2addr v3, v1

    invoke-virtual {p2, v3, v4}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    const-string v0, "ms"

    invoke-virtual {p2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p2

    const-string v0, "MediaPipeBlurClassifier"

    invoke-static {v0, p2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    invoke-static {}, Landroid/os/Trace;->endSection()V

    .line 1
    new-instance p2, Ljava/util/ArrayList;

    invoke-direct {p2}, Ljava/util/ArrayList;-><init>()V

    invoke-virtual {p1}, Lcom/google/mediapipe/tasks/vision/imageclassifier/ImageClassifierResult;->classificationResult()Lcom/google/mediapipe/tasks/components/containers/ClassificationResult;

    move-result-object v0

    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/components/containers/ClassificationResult;->classifications()Ljava/util/List;

    move-result-object v0

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    if-lez v0, :cond_0

    invoke-virtual {p1}, Lcom/google/mediapipe/tasks/vision/imageclassifier/ImageClassifierResult;->classificationResult()Lcom/google/mediapipe/tasks/components/containers/ClassificationResult;

    move-result-object p1

    invoke-virtual {p1}, Lcom/google/mediapipe/tasks/components/containers/ClassificationResult;->classifications()Ljava/util/List;

    move-result-object p1

    const/4 v0, 0x0

    invoke-interface {p1, v0}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/tasks/components/containers/Classifications;

    invoke-virtual {p1}, Lcom/google/mediapipe/tasks/components/containers/Classifications;->categories()Ljava/util/List;

    move-result-object p1

    invoke-interface {p1}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object p1

    :goto_0
    invoke-interface {p1}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-interface {p1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/tasks/components/containers/Category;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/d;

    new-instance v2, Ljava/lang/StringBuilder;

    const-string v3, ""

    invoke-direct {v2, v3}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/components/containers/Category;->index()I

    move-result v3

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/components/containers/Category;->categoryName()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/components/containers/Category;->score()F

    move-result v0

    invoke-static {v0}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v0

    invoke-direct {v1, v2, v3, v0}, Lcom/scanflow/datacapture/barinternal/d;-><init>(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Float;)V

    invoke-virtual {p2, v1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    goto :goto_0

    :cond_0
    return-object p2
.end method
