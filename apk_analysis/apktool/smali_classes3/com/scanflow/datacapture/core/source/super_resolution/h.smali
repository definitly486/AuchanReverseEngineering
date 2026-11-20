.class public abstract Lcom/scanflow/datacapture/core/source/super_resolution/h;
.super Ljava/lang/Object;
.source "SourceFile"


# static fields
.field private static final TAG:Ljava/lang/String; = "h"


# instance fields
.field protected context:Landroid/content/Context;

.field private gpuDelegate:Lorg/tensorflow/lite/gpu/GpuDelegate;

.field protected labels:[Ljava/lang/String;

.field protected model:Lcom/scanflow/datacapture/core/source/super_resolution/a;

.field private final modelsMap:Ljava/util/Map;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Map<",
            "Ljava/lang/String;",
            "Lcom/scanflow/datacapture/core/source/super_resolution/a;",
            ">;"
        }
    .end annotation
.end field

.field private nnApiDelegate:Lorg/tensorflow/lite/nnapi/NnApiDelegate;

.field protected tflite:Lorg/tensorflow/lite/Interpreter;

.field protected tfliteOutputs:[Lorg/tensorflow/lite/support/tensorbuffer/TensorBuffer;


# direct methods
.method public constructor <init>(Ljava/util/Map;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/Map<",
            "Ljava/lang/String;",
            "Lcom/scanflow/datacapture/core/source/super_resolution/a;",
            ">;)V"
        }
    .end annotation

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const/4 v0, 0x0

    iput-object v0, p0, Lcom/scanflow/datacapture/core/source/super_resolution/h;->gpuDelegate:Lorg/tensorflow/lite/gpu/GpuDelegate;

    iput-object v0, p0, Lcom/scanflow/datacapture/core/source/super_resolution/h;->nnApiDelegate:Lorg/tensorflow/lite/nnapi/NnApiDelegate;

    iput-object p1, p0, Lcom/scanflow/datacapture/core/source/super_resolution/h;->modelsMap:Ljava/util/Map;

    return-void
.end method


# virtual methods
.method public getAllModels()Ljava/util/Set;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/Set<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/source/super_resolution/h;->modelsMap:Ljava/util/Map;

    invoke-interface {v0}, Ljava/util/Map;->keySet()Ljava/util/Set;

    move-result-object v0

    return-object v0
.end method

.method public getContext()Landroid/content/Context;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/source/super_resolution/h;->context:Landroid/content/Context;

    return-object v0
.end method

.method public init(Landroid/content/Context;Ljava/lang/String;Lcom/scanflow/datacapture/core/source/super_resolution/Device;I)Z
    .locals 3

    iput-object p1, p0, Lcom/scanflow/datacapture/core/source/super_resolution/h;->context:Landroid/content/Context;

    invoke-virtual {p1}, Landroid/content/Context;->getApplicationContext()Landroid/content/Context;

    move-result-object p1

    check-cast p1, Landroid/app/Application;

    const/4 v0, 0x0

    iput-object v0, p0, Lcom/scanflow/datacapture/core/source/super_resolution/h;->tflite:Lorg/tensorflow/lite/Interpreter;

    iget-object v0, p0, Lcom/scanflow/datacapture/core/source/super_resolution/h;->modelsMap:Ljava/util/Map;

    invoke-interface {v0, p2}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p2

    check-cast p2, Lcom/scanflow/datacapture/core/source/super_resolution/a;

    iput-object p2, p0, Lcom/scanflow/datacapture/core/source/super_resolution/h;->model:Lcom/scanflow/datacapture/core/source/super_resolution/a;

    const/4 v0, 0x0

    if-nez p2, :cond_0

    return v0

    :cond_0
    :try_start_0
    new-instance p2, Lorg/tensorflow/lite/Interpreter$Options;

    invoke-direct {p2}, Lorg/tensorflow/lite/Interpreter$Options;-><init>()V

    sget-object v1, Lcom/scanflow/datacapture/core/source/super_resolution/h$a;->a:[I

    invoke-virtual {p3}, Ljava/lang/Enum;->ordinal()I

    move-result p3

    aget p3, v1, p3

    const/4 v1, 0x1

    if-eq p3, v1, :cond_2

    const/4 v2, 0x2

    if-eq p3, v2, :cond_1

    goto :goto_1

    :cond_1
    new-instance p3, Lorg/tensorflow/lite/gpu/GpuDelegate;

    invoke-direct {p3}, Lorg/tensorflow/lite/gpu/GpuDelegate;-><init>()V

    iput-object p3, p0, Lcom/scanflow/datacapture/core/source/super_resolution/h;->gpuDelegate:Lorg/tensorflow/lite/gpu/GpuDelegate;

    goto :goto_0

    :catch_0
    move-exception p1

    goto :goto_3

    :cond_2
    new-instance p3, Lorg/tensorflow/lite/nnapi/NnApiDelegate;

    invoke-direct {p3}, Lorg/tensorflow/lite/nnapi/NnApiDelegate;-><init>()V

    iput-object p3, p0, Lcom/scanflow/datacapture/core/source/super_resolution/h;->nnApiDelegate:Lorg/tensorflow/lite/nnapi/NnApiDelegate;

    :goto_0
    invoke-virtual {p2, p3}, Lorg/tensorflow/lite/Interpreter$Options;->addDelegate(Lorg/tensorflow/lite/Delegate;)Lorg/tensorflow/lite/Interpreter$Options;

    :goto_1
    iget-object p3, p0, Lcom/scanflow/datacapture/core/source/super_resolution/h;->model:Lcom/scanflow/datacapture/core/source/super_resolution/a;

    .line 1
    iget-object p3, p3, Lcom/scanflow/datacapture/core/source/super_resolution/a;->a:Ljava/lang/String;

    .line 2
    invoke-static {p1, p3}, Lorg/tensorflow/lite/support/common/FileUtil;->loadMappedFile(Landroid/content/Context;Ljava/lang/String;)Ljava/nio/MappedByteBuffer;

    move-result-object p3

    invoke-virtual {p2, p4}, Lorg/tensorflow/lite/Interpreter$Options;->setNumThreads(I)Lorg/tensorflow/lite/Interpreter$Options;

    new-instance p4, Lorg/tensorflow/lite/Interpreter;

    invoke-direct {p4, p3, p2}, Lorg/tensorflow/lite/Interpreter;-><init>(Ljava/nio/ByteBuffer;Lorg/tensorflow/lite/Interpreter$Options;)V

    iput-object p4, p0, Lcom/scanflow/datacapture/core/source/super_resolution/h;->tflite:Lorg/tensorflow/lite/Interpreter;

    new-instance p2, Ljava/util/ArrayList;

    iget-object p3, p0, Lcom/scanflow/datacapture/core/source/super_resolution/h;->tflite:Lorg/tensorflow/lite/Interpreter;

    invoke-virtual {p3}, Lorg/tensorflow/lite/Interpreter;->getOutputTensorCount()I

    move-result p3

    invoke-direct {p2, p3}, Ljava/util/ArrayList;-><init>(I)V

    move p3, v0

    :goto_2
    iget-object p4, p0, Lcom/scanflow/datacapture/core/source/super_resolution/h;->tflite:Lorg/tensorflow/lite/Interpreter;

    invoke-virtual {p4}, Lorg/tensorflow/lite/Interpreter;->getOutputTensorCount()I

    move-result p4

    if-ge p3, p4, :cond_3

    iget-object p4, p0, Lcom/scanflow/datacapture/core/source/super_resolution/h;->tflite:Lorg/tensorflow/lite/Interpreter;

    invoke-virtual {p4, p3}, Lorg/tensorflow/lite/Interpreter;->getOutputTensor(I)Lorg/tensorflow/lite/Tensor;

    move-result-object p4

    invoke-interface {p4}, Lorg/tensorflow/lite/Tensor;->shape()[I

    move-result-object p4

    iget-object v2, p0, Lcom/scanflow/datacapture/core/source/super_resolution/h;->tflite:Lorg/tensorflow/lite/Interpreter;

    invoke-virtual {v2, p3}, Lorg/tensorflow/lite/Interpreter;->getOutputTensor(I)Lorg/tensorflow/lite/Tensor;

    move-result-object v2

    invoke-interface {v2}, Lorg/tensorflow/lite/Tensor;->dataType()Lorg/tensorflow/lite/DataType;

    move-result-object v2

    invoke-static {p4, v2}, Lorg/tensorflow/lite/support/tensorbuffer/TensorBuffer;->createFixedSize([ILorg/tensorflow/lite/DataType;)Lorg/tensorflow/lite/support/tensorbuffer/TensorBuffer;

    move-result-object p4

    invoke-virtual {p2, p4}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    add-int/lit8 p3, p3, 0x1

    goto :goto_2

    :cond_3
    new-array p3, v0, [Lorg/tensorflow/lite/support/tensorbuffer/TensorBuffer;

    invoke-virtual {p2, p3}, Ljava/util/ArrayList;->toArray([Ljava/lang/Object;)[Ljava/lang/Object;

    move-result-object p2

    check-cast p2, [Lorg/tensorflow/lite/support/tensorbuffer/TensorBuffer;

    iput-object p2, p0, Lcom/scanflow/datacapture/core/source/super_resolution/h;->tfliteOutputs:[Lorg/tensorflow/lite/support/tensorbuffer/TensorBuffer;

    iget-object p2, p0, Lcom/scanflow/datacapture/core/source/super_resolution/h;->model:Lcom/scanflow/datacapture/core/source/super_resolution/a;

    .line 3
    iget-object p2, p2, Lcom/scanflow/datacapture/core/source/super_resolution/a;->b:Ljava/lang/String;

    if-eqz p2, :cond_4

    .line 4
    invoke-static {p1, p2}, Lorg/tensorflow/lite/support/common/FileUtil;->loadLabels(Landroid/content/Context;Ljava/lang/String;)Ljava/util/List;

    move-result-object p1

    new-array p2, v0, [Ljava/lang/String;

    invoke-interface {p1, p2}, Ljava/util/List;->toArray([Ljava/lang/Object;)[Ljava/lang/Object;

    move-result-object p1

    check-cast p1, [Ljava/lang/String;

    iput-object p1, p0, Lcom/scanflow/datacapture/core/source/super_resolution/h;->labels:[Ljava/lang/String;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    :cond_4
    return v1

    :goto_3
    invoke-virtual {p0}, Lcom/scanflow/datacapture/core/source/super_resolution/h;->release()Z

    invoke-virtual {p1}, Ljava/lang/Throwable;->printStackTrace()V

    return v0
.end method

.method public process([Landroid/graphics/Bitmap;I)Lcom/scanflow/datacapture/core/source/super_resolution/ProcessResult;
    .locals 19

    move-object/from16 v1, p0

    move-object/from16 v0, p1

    iget-object v2, v1, Lcom/scanflow/datacapture/core/source/super_resolution/h;->model:Lcom/scanflow/datacapture/core/source/super_resolution/a;

    .line 1
    iget v2, v2, Lcom/scanflow/datacapture/core/source/super_resolution/a;->c:I

    const/4 v3, 0x1

    const/4 v4, 0x0

    if-ne v2, v3, :cond_0

    .line 2
    iget-object v2, v1, Lcom/scanflow/datacapture/core/source/super_resolution/h;->tflite:Lorg/tensorflow/lite/Interpreter;

    if-nez v2, :cond_0

    return-object v4

    :cond_0
    :try_start_0
    new-instance v6, Ljava/util/ArrayList;

    invoke-direct {v6}, Ljava/util/ArrayList;-><init>()V

    invoke-static {}, Landroid/os/SystemClock;->uptimeMillis()J

    move-result-wide v2

    array-length v5, v0

    const-wide/16 v8, 0x0

    move-wide v10, v8

    move-wide v12, v10

    const/4 v14, 0x0

    :goto_0
    if-ge v14, v5, :cond_2

    aget-object v8, v0, v14

    iget-object v9, v1, Lcom/scanflow/datacapture/core/source/super_resolution/h;->model:Lcom/scanflow/datacapture/core/source/super_resolution/a;

    .line 3
    iget-object v9, v9, Lcom/scanflow/datacapture/core/source/super_resolution/a;->d:Lcom/scanflow/datacapture/core/source/super_resolution/e;

    .line 4
    invoke-interface {v9, v8}, Lcom/scanflow/datacapture/core/source/super_resolution/e;->a(Landroid/graphics/Bitmap;)Lorg/tensorflow/lite/support/tensorbuffer/TensorBuffer;

    move-result-object v9

    invoke-static {}, Landroid/os/SystemClock;->uptimeMillis()J

    move-result-wide v10

    sub-long/2addr v10, v2

    invoke-virtual {v9}, Lorg/tensorflow/lite/support/tensorbuffer/TensorBuffer;->getBuffer()Ljava/nio/ByteBuffer;

    move-result-object v9

    filled-new-array {v9}, [Ljava/lang/Object;

    move-result-object v9

    new-instance v12, Ljava/util/HashMap;

    invoke-direct {v12}, Ljava/util/HashMap;-><init>()V

    iget-object v13, v1, Lcom/scanflow/datacapture/core/source/super_resolution/h;->tfliteOutputs:[Lorg/tensorflow/lite/support/tensorbuffer/TensorBuffer;

    array-length v15, v13
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_1

    move-object/from16 p2, v4

    const/4 v4, 0x0

    const/16 v16, 0x0

    :goto_1
    if-ge v4, v15, :cond_1

    :try_start_1
    aget-object v17, v13, v4

    add-int/lit8 v18, v16, 0x1

    invoke-static/range {v16 .. v16}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v7

    invoke-virtual/range {v17 .. v17}, Lorg/tensorflow/lite/support/tensorbuffer/TensorBuffer;->getBuffer()Ljava/nio/ByteBuffer;

    move-result-object v16

    invoke-virtual/range {v16 .. v16}, Ljava/nio/ByteBuffer;->rewind()Ljava/nio/Buffer;

    move-result-object v0

    invoke-virtual {v12, v7, v0}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    add-int/lit8 v4, v4, 0x1

    move-object/from16 v0, p1

    move/from16 v16, v18

    goto :goto_1

    :catch_0
    move-exception v0

    goto/16 :goto_2

    :cond_1
    invoke-static {}, Landroid/os/SystemClock;->uptimeMillis()J

    move-result-wide v15

    iget-object v0, v1, Lcom/scanflow/datacapture/core/source/super_resolution/h;->tflite:Lorg/tensorflow/lite/Interpreter;

    invoke-virtual {v0, v9, v12}, Lorg/tensorflow/lite/Interpreter;->runForMultipleInputsOutputs([Ljava/lang/Object;Ljava/util/Map;)V

    invoke-static {}, Landroid/os/SystemClock;->uptimeMillis()J

    move-result-wide v12

    sub-long v15, v12, v15

    iget-object v0, v1, Lcom/scanflow/datacapture/core/source/super_resolution/h;->tfliteOutputs:[Lorg/tensorflow/lite/support/tensorbuffer/TensorBuffer;

    iget-object v4, v1, Lcom/scanflow/datacapture/core/source/super_resolution/h;->model:Lcom/scanflow/datacapture/core/source/super_resolution/a;

    .line 5
    iget-object v4, v4, Lcom/scanflow/datacapture/core/source/super_resolution/a;->e:Lcom/scanflow/datacapture/core/source/super_resolution/b;

    .line 6
    invoke-virtual {v8}, Landroid/graphics/Bitmap;->getWidth()I

    invoke-virtual {v8}, Landroid/graphics/Bitmap;->getHeight()I

    invoke-interface {v4, v0}, Lcom/scanflow/datacapture/core/source/super_resolution/b;->a([Lorg/tensorflow/lite/support/tensorbuffer/TensorBuffer;)[Lcom/scanflow/datacapture/core/source/super_resolution/EnhancementResult;

    move-result-object v0

    invoke-static {v0}, Ljava/util/Arrays;->asList([Ljava/lang/Object;)Ljava/util/List;

    move-result-object v0

    invoke-virtual {v6, v0}, Ljava/util/ArrayList;->addAll(Ljava/util/Collection;)Z

    add-int/lit8 v14, v14, 0x1

    move-object/from16 v0, p1

    move-object/from16 v4, p2

    move-wide v8, v12

    move-wide v12, v15

    goto :goto_0

    :catch_1
    move-exception v0

    move-object/from16 p2, v4

    goto :goto_2

    :cond_2
    move-object/from16 p2, v4

    invoke-static {}, Landroid/os/SystemClock;->uptimeMillis()J

    move-result-wide v4

    sub-long/2addr v4, v8

    invoke-static {}, Landroid/os/SystemClock;->uptimeMillis()J

    move-result-wide v7

    sub-long/2addr v7, v2

    sget-object v0, Lcom/scanflow/datacapture/core/source/super_resolution/h;->TAG:Ljava/lang/String;

    const-string v2, "Total time %d ms."

    invoke-static {v7, v8}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v3

    filled-new-array {v3}, [Ljava/lang/Object;

    move-result-object v3

    invoke-static {v2, v3}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    invoke-static {v0, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    const-string v2, "preProcess time %d ms."

    invoke-static {v10, v11}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v3

    filled-new-array {v3}, [Ljava/lang/Object;

    move-result-object v3

    invoke-static {v2, v3}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    invoke-static {v0, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    const-string v2, "postProcess time %d ms."

    invoke-static {v4, v5}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v3

    filled-new-array {v3}, [Ljava/lang/Object;

    move-result-object v3

    invoke-static {v2, v3}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    invoke-static {v0, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    const-string v2, "Inference time %d ms."

    invoke-static {v12, v13}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v3

    filled-new-array {v3}, [Ljava/lang/Object;

    move-result-object v3

    invoke-static {v2, v3}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    invoke-static {v0, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    new-instance v5, Lcom/scanflow/datacapture/core/source/super_resolution/ProcessResult;

    move-wide v10, v7

    iget-object v7, v1, Lcom/scanflow/datacapture/core/source/super_resolution/h;->labels:[Ljava/lang/String;

    move-wide v8, v12

    invoke-direct/range {v5 .. v11}, Lcom/scanflow/datacapture/core/source/super_resolution/ProcessResult;-><init>(Ljava/util/List;[Ljava/lang/String;JJ)V
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_0

    return-object v5

    :goto_2
    sget-object v2, Lcom/scanflow/datacapture/core/source/super_resolution/h;->TAG:Ljava/lang/String;

    const-string v3, "beginning of stacktrace:"

    invoke-static {v2, v3}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    invoke-virtual {v0}, Ljava/lang/Throwable;->printStackTrace()V

    return-object p2
.end method

.method public release()Z
    .locals 2

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/source/super_resolution/h;->tflite:Lorg/tensorflow/lite/Interpreter;

    const/4 v1, 0x0

    if-eqz v0, :cond_0

    invoke-virtual {v0}, Lorg/tensorflow/lite/Interpreter;->close()V

    iput-object v1, p0, Lcom/scanflow/datacapture/core/source/super_resolution/h;->tflite:Lorg/tensorflow/lite/Interpreter;

    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/source/super_resolution/h;->gpuDelegate:Lorg/tensorflow/lite/gpu/GpuDelegate;

    if-eqz v0, :cond_1

    invoke-virtual {v0}, Lorg/tensorflow/lite/gpu/GpuDelegate;->close()V

    iput-object v1, p0, Lcom/scanflow/datacapture/core/source/super_resolution/h;->gpuDelegate:Lorg/tensorflow/lite/gpu/GpuDelegate;

    :cond_1
    iget-object v0, p0, Lcom/scanflow/datacapture/core/source/super_resolution/h;->nnApiDelegate:Lorg/tensorflow/lite/nnapi/NnApiDelegate;

    if-eqz v0, :cond_2

    invoke-virtual {v0}, Lorg/tensorflow/lite/nnapi/NnApiDelegate;->close()V

    iput-object v1, p0, Lcom/scanflow/datacapture/core/source/super_resolution/h;->nnApiDelegate:Lorg/tensorflow/lite/nnapi/NnApiDelegate;

    :cond_2
    iput-object v1, p0, Lcom/scanflow/datacapture/core/source/super_resolution/h;->tfliteOutputs:[Lorg/tensorflow/lite/support/tensorbuffer/TensorBuffer;

    const/4 v0, 0x1

    return v0
.end method
