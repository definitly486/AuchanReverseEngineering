.class public Lcom/scanflow/datacapture/core/source/super_resolution/Enhancement;
.super Lcom/scanflow/datacapture/core/source/super_resolution/h;
.source "SourceFile"


# annotations
.annotation build Landroidx/annotation/Keep;
.end annotation


# static fields
.field private static final ENHANCEMENT_MODELS:Ljava/util/Map;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Map<",
            "Ljava/lang/String;",
            "Lcom/scanflow/datacapture/core/source/super_resolution/a;",
            ">;"
        }
    .end annotation
.end field

.field private static final TAG:Ljava/lang/String;


# instance fields
.field private final isDynamicInput:Z


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/core/source/super_resolution/Enhancement$a;

    invoke-direct {v0}, Lcom/scanflow/datacapture/core/source/super_resolution/Enhancement$a;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/core/source/super_resolution/Enhancement;->ENHANCEMENT_MODELS:Ljava/util/Map;

    const-string v0, "Enhancement"

    sput-object v0, Lcom/scanflow/datacapture/core/source/super_resolution/Enhancement;->TAG:Ljava/lang/String;

    return-void
.end method

.method public constructor <init>(Z)V
    .locals 1

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/core/source/super_resolution/Enhancement;->ENHANCEMENT_MODELS:Ljava/util/Map;

    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/core/source/super_resolution/h;-><init>(Ljava/util/Map;)V

    iput-boolean p1, p0, Lcom/scanflow/datacapture/core/source/super_resolution/Enhancement;->isDynamicInput:Z

    return-void
.end method


# virtual methods
.method public process([Landroid/graphics/Bitmap;I)Lcom/scanflow/datacapture/core/source/super_resolution/ProcessResult;
    .locals 13

    .line 0
    invoke-static {}, Landroid/os/SystemClock;->uptimeMillis()J

    move-result-wide v0

    iget-boolean v2, p0, Lcom/scanflow/datacapture/core/source/super_resolution/Enhancement;->isDynamicInput:Z

    const/4 v3, 0x0

    if-eqz v2, :cond_0

    iget-object v2, p0, Lcom/scanflow/datacapture/core/source/super_resolution/h;->tfliteOutputs:[Lorg/tensorflow/lite/support/tensorbuffer/TensorBuffer;

    aget-object v2, v2, v3

    invoke-virtual {v2}, Lorg/tensorflow/lite/support/tensorbuffer/TensorBuffer;->getShape()[I

    move-result-object v2

    aget-object v4, p1, v3

    invoke-virtual {v4}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v4

    div-int/lit8 v4, v4, 0x4

    mul-int/lit8 v4, v4, 0x4

    const/4 v5, 0x1

    aput v4, v2, v5

    aget-object v4, p1, v3

    invoke-virtual {v4}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v4

    div-int/lit8 v4, v4, 0x4

    mul-int/lit8 v4, v4, 0x4

    const/4 v5, 0x2

    aput v4, v2, v5

    iget-object v4, p0, Lcom/scanflow/datacapture/core/source/super_resolution/h;->tfliteOutputs:[Lorg/tensorflow/lite/support/tensorbuffer/TensorBuffer;

    aget-object v4, v4, v3

    invoke-virtual {v4}, Lorg/tensorflow/lite/support/tensorbuffer/TensorBuffer;->getDataType()Lorg/tensorflow/lite/DataType;

    move-result-object v4

    invoke-static {v2, v4}, Lorg/tensorflow/lite/support/tensorbuffer/TensorBuffer;->createFixedSize([ILorg/tensorflow/lite/DataType;)Lorg/tensorflow/lite/support/tensorbuffer/TensorBuffer;

    move-result-object v4

    filled-new-array {v4}, [Lorg/tensorflow/lite/support/tensorbuffer/TensorBuffer;

    move-result-object v4

    iput-object v4, p0, Lcom/scanflow/datacapture/core/source/super_resolution/h;->tfliteOutputs:[Lorg/tensorflow/lite/support/tensorbuffer/TensorBuffer;

    iget-object v4, p0, Lcom/scanflow/datacapture/core/source/super_resolution/h;->tflite:Lorg/tensorflow/lite/Interpreter;

    invoke-virtual {v4, v3, v2}, Lorg/tensorflow/lite/Interpreter;->resizeInput(I[I)V

    :cond_0
    invoke-super {p0, p1, p2}, Lcom/scanflow/datacapture/core/source/super_resolution/h;->process([Landroid/graphics/Bitmap;I)Lcom/scanflow/datacapture/core/source/super_resolution/ProcessResult;

    move-result-object p1

    if-nez p1, :cond_1

    const/4 p1, 0x0

    return-object p1

    :cond_1
    invoke-static {}, Landroid/os/SystemClock;->uptimeMillis()J

    move-result-wide v4

    sub-long v11, v4, v0

    new-instance v6, Lcom/scanflow/datacapture/core/source/super_resolution/ProcessResult;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/core/source/super_resolution/ProcessResult;->getResults()Ljava/util/List;

    move-result-object v7

    new-array v8, v3, [Ljava/lang/String;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/core/source/super_resolution/ProcessResult;->getInferenceTime()J

    move-result-wide v9

    invoke-direct/range {v6 .. v12}, Lcom/scanflow/datacapture/core/source/super_resolution/ProcessResult;-><init>(Ljava/util/List;[Ljava/lang/String;JJ)V

    return-object v6
.end method
