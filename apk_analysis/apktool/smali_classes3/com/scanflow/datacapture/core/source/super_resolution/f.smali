.class public final Lcom/scanflow/datacapture/core/source/super_resolution/f;
.super Ljava/lang/Object;
.source "SourceFile"

# interfaces
.implements Lcom/scanflow/datacapture/core/source/super_resolution/e;


# instance fields
.field public final a:[F

.field public final b:[F

.field public c:Lorg/tensorflow/lite/support/image/TensorImage;


# direct methods
.method public constructor <init>()V
    .locals 2

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    new-instance v0, Lorg/tensorflow/lite/support/image/TensorImage;

    sget-object v1, Lorg/tensorflow/lite/DataType;->FLOAT32:Lorg/tensorflow/lite/DataType;

    invoke-direct {v0, v1}, Lorg/tensorflow/lite/support/image/TensorImage;-><init>(Lorg/tensorflow/lite/DataType;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/core/source/super_resolution/f;->c:Lorg/tensorflow/lite/support/image/TensorImage;

    const/4 v0, 0x3

    new-array v1, v0, [F

    fill-array-data v1, :array_0

    iput-object v1, p0, Lcom/scanflow/datacapture/core/source/super_resolution/f;->a:[F

    new-array v0, v0, [F

    fill-array-data v0, :array_1

    iput-object v0, p0, Lcom/scanflow/datacapture/core/source/super_resolution/f;->b:[F

    return-void

    :array_0
    .array-data 4
        0x42a85700
        0x42a85700
        0x42a85700
    .end array-data

    :array_1
    .array-data 4
        0x426d0ac6
        0x42655451
        0x426a8dc2
    .end array-data
.end method


# virtual methods
.method public final a(Landroid/graphics/Bitmap;)Lorg/tensorflow/lite/support/tensorbuffer/TensorBuffer;
    .locals 4

    .line 1
    iget-object v0, p0, Lcom/scanflow/datacapture/core/source/super_resolution/f;->c:Lorg/tensorflow/lite/support/image/TensorImage;

    invoke-virtual {v0, p1}, Lorg/tensorflow/lite/support/image/TensorImage;->load(Landroid/graphics/Bitmap;)V

    invoke-virtual {p1}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v0

    invoke-virtual {p1}, Landroid/graphics/Bitmap;->getHeight()I

    move-result p1

    div-int/lit8 v1, v0, 0x4

    mul-int/lit8 v1, v1, 0x4

    div-int/lit8 v2, p1, 0x4

    mul-int/lit8 v2, v2, 0x4

    if-ne v1, v0, :cond_1

    if-eq v2, p1, :cond_0

    goto :goto_1

    :cond_0
    new-instance p1, Lorg/tensorflow/lite/support/image/ImageProcessor$Builder;

    invoke-direct {p1}, Lorg/tensorflow/lite/support/image/ImageProcessor$Builder;-><init>()V

    new-instance v0, Lorg/tensorflow/lite/support/common/ops/NormalizeOp;

    iget-object v1, p0, Lcom/scanflow/datacapture/core/source/super_resolution/f;->a:[F

    iget-object v2, p0, Lcom/scanflow/datacapture/core/source/super_resolution/f;->b:[F

    invoke-direct {v0, v1, v2}, Lorg/tensorflow/lite/support/common/ops/NormalizeOp;-><init>([F[F)V

    :goto_0
    invoke-virtual {p1, v0}, Lorg/tensorflow/lite/support/image/ImageProcessor$Builder;->add(Lorg/tensorflow/lite/support/common/TensorOperator;)Lorg/tensorflow/lite/support/image/ImageProcessor$Builder;

    move-result-object p1

    invoke-virtual {p1}, Lorg/tensorflow/lite/support/image/ImageProcessor$Builder;->build()Lorg/tensorflow/lite/support/image/ImageProcessor;

    move-result-object p1

    goto :goto_2

    :cond_1
    :goto_1
    new-instance p1, Lorg/tensorflow/lite/support/image/ImageProcessor$Builder;

    invoke-direct {p1}, Lorg/tensorflow/lite/support/image/ImageProcessor$Builder;-><init>()V

    new-instance v0, Lorg/tensorflow/lite/support/image/ops/ResizeOp;

    sget-object v3, Lorg/tensorflow/lite/support/image/ops/ResizeOp$ResizeMethod;->BILINEAR:Lorg/tensorflow/lite/support/image/ops/ResizeOp$ResizeMethod;

    invoke-direct {v0, v2, v1, v3}, Lorg/tensorflow/lite/support/image/ops/ResizeOp;-><init>(IILorg/tensorflow/lite/support/image/ops/ResizeOp$ResizeMethod;)V

    invoke-virtual {p1, v0}, Lorg/tensorflow/lite/support/image/ImageProcessor$Builder;->add(Lorg/tensorflow/lite/support/image/ImageOperator;)Lorg/tensorflow/lite/support/image/ImageProcessor$Builder;

    move-result-object p1

    new-instance v0, Lorg/tensorflow/lite/support/common/ops/NormalizeOp;

    iget-object v1, p0, Lcom/scanflow/datacapture/core/source/super_resolution/f;->a:[F

    iget-object v2, p0, Lcom/scanflow/datacapture/core/source/super_resolution/f;->b:[F

    invoke-direct {v0, v1, v2}, Lorg/tensorflow/lite/support/common/ops/NormalizeOp;-><init>([F[F)V

    goto :goto_0

    :goto_2
    iget-object v0, p0, Lcom/scanflow/datacapture/core/source/super_resolution/f;->c:Lorg/tensorflow/lite/support/image/TensorImage;

    invoke-virtual {p1, v0}, Lorg/tensorflow/lite/support/image/ImageProcessor;->process(Lorg/tensorflow/lite/support/image/TensorImage;)Lorg/tensorflow/lite/support/image/TensorImage;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/core/source/super_resolution/f;->c:Lorg/tensorflow/lite/support/image/TensorImage;

    invoke-virtual {p1}, Lorg/tensorflow/lite/support/image/TensorImage;->getTensorBuffer()Lorg/tensorflow/lite/support/tensorbuffer/TensorBuffer;

    move-result-object p1

    return-object p1
.end method
