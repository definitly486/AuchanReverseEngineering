.class public final Lcom/scanflow/datacapture/core/source/super_resolution/c;
.super Ljava/lang/Object;
.source "SourceFile"

# interfaces
.implements Lcom/scanflow/datacapture/core/source/super_resolution/b;


# instance fields
.field public final a:[F

.field public final b:[F


# direct methods
.method public constructor <init>()V
    .locals 2

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const/4 v0, 0x3

    new-array v1, v0, [F

    fill-array-data v1, :array_0

    iput-object v1, p0, Lcom/scanflow/datacapture/core/source/super_resolution/c;->a:[F

    new-array v0, v0, [F

    fill-array-data v0, :array_1

    iput-object v0, p0, Lcom/scanflow/datacapture/core/source/super_resolution/c;->b:[F

    return-void

    nop

    :array_0
    .array-data 4
        0x3ea90000
        0x3ea90000
        0x3ea90000
    .end array-data

    :array_1
    .array-data 4
        0x3e6df8bf
        0x3e663a8c
        0x3e6b793b
    .end array-data
.end method


# virtual methods
.method public final a([Lorg/tensorflow/lite/support/tensorbuffer/TensorBuffer;)[Lcom/scanflow/datacapture/core/source/super_resolution/EnhancementResult;
    .locals 16

    move-object/from16 v0, p0

    const/4 v1, 0x0

    .line 1
    aget-object v2, p1, v1

    invoke-virtual {v2}, Lorg/tensorflow/lite/support/tensorbuffer/TensorBuffer;->getShape()[I

    move-result-object v2

    const/4 v3, 0x1

    aget v11, v2, v3

    aget-object v2, p1, v1

    invoke-virtual {v2}, Lorg/tensorflow/lite/support/tensorbuffer/TensorBuffer;->getShape()[I

    move-result-object v2

    const/4 v4, 0x2

    aget v7, v2, v4

    mul-int v2, v7, v11

    aget-object v5, p1, v1

    invoke-virtual {v5}, Lorg/tensorflow/lite/support/tensorbuffer/TensorBuffer;->getFloatArray()[F

    move-result-object v5

    move-object v6, v5

    new-array v5, v2, [I

    move v8, v1

    :goto_0
    mul-int/lit8 v9, v2, 0x3

    if-ge v8, v9, :cond_0

    aget v9, v6, v8

    iget-object v10, v0, Lcom/scanflow/datacapture/core/source/super_resolution/c;->b:[F

    aget v10, v10, v1

    mul-float/2addr v9, v10

    iget-object v10, v0, Lcom/scanflow/datacapture/core/source/super_resolution/c;->a:[F

    aget v10, v10, v1

    add-float/2addr v9, v10

    const/4 v10, 0x0

    invoke-static {v9, v10}, Ljava/lang/Math;->max(FF)F

    move-result v9

    const/high16 v12, 0x3f800000    # 1.0f

    invoke-static {v9, v12}, Ljava/lang/Math;->min(FF)F

    move-result v9

    const/high16 v13, 0x437f0000    # 255.0f

    mul-float/2addr v9, v13

    add-int/lit8 v14, v8, 0x1

    aget v14, v6, v14

    iget-object v15, v0, Lcom/scanflow/datacapture/core/source/super_resolution/c;->b:[F

    aget v15, v15, v3

    mul-float/2addr v14, v15

    iget-object v15, v0, Lcom/scanflow/datacapture/core/source/super_resolution/c;->a:[F

    aget v15, v15, v3

    add-float/2addr v14, v15

    invoke-static {v14, v10}, Ljava/lang/Math;->max(FF)F

    move-result v14

    invoke-static {v14, v12}, Ljava/lang/Math;->min(FF)F

    move-result v14

    mul-float/2addr v14, v13

    add-int/lit8 v15, v8, 0x2

    aget v15, v6, v15

    iget-object v1, v0, Lcom/scanflow/datacapture/core/source/super_resolution/c;->b:[F

    aget v1, v1, v4

    mul-float/2addr v15, v1

    iget-object v1, v0, Lcom/scanflow/datacapture/core/source/super_resolution/c;->a:[F

    aget v1, v1, v4

    add-float/2addr v15, v1

    invoke-static {v15, v10}, Ljava/lang/Math;->max(FF)F

    move-result v1

    invoke-static {v1, v12}, Ljava/lang/Math;->min(FF)F

    move-result v1

    mul-float/2addr v1, v13

    div-int/lit8 v10, v8, 0x3

    float-to-int v9, v9

    shl-int/lit8 v9, v9, 0x10

    const/high16 v12, -0x1000000

    or-int/2addr v9, v12

    float-to-int v12, v14

    shl-int/lit8 v12, v12, 0x8

    or-int/2addr v9, v12

    float-to-int v1, v1

    or-int/2addr v1, v9

    aput v1, v5, v10

    add-int/lit8 v8, v8, 0x3

    const/4 v1, 0x0

    goto :goto_0

    :cond_0
    sget-object v1, Landroid/graphics/Bitmap$Config;->ARGB_8888:Landroid/graphics/Bitmap$Config;

    invoke-static {v7, v11, v1}, Landroid/graphics/Bitmap;->createBitmap(IILandroid/graphics/Bitmap$Config;)Landroid/graphics/Bitmap;

    move-result-object v4

    const/4 v8, 0x0

    const/4 v9, 0x0

    const/4 v6, 0x0

    move v10, v7

    invoke-virtual/range {v4 .. v11}, Landroid/graphics/Bitmap;->setPixels([IIIIIII)V

    new-instance v1, Lcom/scanflow/datacapture/core/source/super_resolution/EnhancementResult;

    filled-new-array {v4}, [Landroid/graphics/Bitmap;

    move-result-object v2

    invoke-direct {v1, v2}, Lcom/scanflow/datacapture/core/source/super_resolution/EnhancementResult;-><init>([Landroid/graphics/Bitmap;)V

    filled-new-array {v1}, [Lcom/scanflow/datacapture/core/source/super_resolution/EnhancementResult;

    move-result-object v1

    return-object v1
.end method
