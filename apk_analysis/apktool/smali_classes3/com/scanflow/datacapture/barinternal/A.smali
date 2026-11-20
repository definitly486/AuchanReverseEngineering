.class public final Lcom/scanflow/datacapture/barinternal/A;
.super Lkotlin/coroutines/jvm/internal/SuspendLambda;
.source "SourceFile"

# interfaces
.implements Lkotlin/jvm/functions/Function2;


# instance fields
.field public synthetic a:Ljava/lang/Object;

.field public final synthetic b:Ljava/util/ArrayList;

.field public final synthetic c:Lcom/scanflow/datacapture/barcode/b;


# direct methods
.method public constructor <init>(Ljava/util/ArrayList;Lcom/scanflow/datacapture/barcode/b;Lkotlin/coroutines/Continuation;)V
    .locals 0

    .line 1
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/A;->b:Ljava/util/ArrayList;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/A;->c:Lcom/scanflow/datacapture/barcode/b;

    const/4 p1, 0x2

    invoke-direct {p0, p1, p3}, Lkotlin/coroutines/jvm/internal/SuspendLambda;-><init>(ILkotlin/coroutines/Continuation;)V

    return-void
.end method

.method public static final a(Ljava/util/ArrayList;Ljava/util/ArrayList;ILcom/scanflow/datacapture/barcode/b;Lcom/scanflow/datacapture/barinternal/B;Lkotlinx/coroutines/CoroutineScope;Lcom/google/android/gms/tasks/Task;)V
    .locals 33

    move-object/from16 v0, p0

    move-object/from16 v1, p3

    const-string v2, "processModelResultZxing"

    invoke-virtual/range {p6 .. p6}, Lcom/google/android/gms/tasks/Task;->isSuccessful()Z

    move-result v3

    const/4 v5, 0x2

    if-eqz v3, :cond_a

    invoke-virtual/range {p6 .. p6}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/util/List;

    invoke-interface {v3}, Ljava/util/List;->size()I

    move-result v3

    if-lez v3, :cond_a

    invoke-virtual/range {p6 .. p6}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/util/List;

    const/4 v7, 0x0

    invoke-interface {v3, v7}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Lcom/google/mlkit/vision/barcode/common/Barcode;

    invoke-virtual {v3}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getFormat()I

    move-result v3

    const/16 v8, 0x100

    if-eq v3, v8, :cond_9

    invoke-virtual/range {p6 .. p6}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/util/List;

    invoke-interface {v3, v7}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Lcom/google/mlkit/vision/barcode/common/Barcode;

    invoke-virtual {v3}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getCornerPoints()[Landroid/graphics/Point;

    move-result-object v3

    if-eqz v3, :cond_6

    aget-object v8, v3, v7

    iget v9, v8, Landroid/graphics/Point;->x:I

    int-to-double v9, v9

    iget v8, v8, Landroid/graphics/Point;->y:I

    int-to-double v11, v8

    const/4 v8, 0x1

    aget-object v13, v3, v8

    iget v14, v13, Landroid/graphics/Point;->x:I

    int-to-double v14, v14

    iget v13, v13, Landroid/graphics/Point;->y:I

    move/from16 v16, v7

    int-to-double v6, v13

    invoke-virtual {v1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    sub-double/2addr v14, v9

    int-to-double v9, v5

    .line 1
    invoke-static {v14, v15, v9, v10}, Ljava/lang/Math;->pow(DD)D

    move-result-wide v13

    sub-double/2addr v6, v11

    invoke-static {v6, v7, v9, v10}, Ljava/lang/Math;->pow(DD)D

    move-result-wide v6

    add-double/2addr v6, v13

    invoke-static {v6, v7}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide v6

    .line 2
    aget-object v11, v3, v8

    iget v12, v11, Landroid/graphics/Point;->x:I

    int-to-double v12, v12

    iget v11, v11, Landroid/graphics/Point;->y:I

    int-to-double v14, v11

    aget-object v11, v3, v5

    move/from16 v17, v5

    iget v5, v11, Landroid/graphics/Point;->x:I

    int-to-double v4, v5

    iget v11, v11, Landroid/graphics/Point;->y:I

    move-object/from16 v18, v3

    move-wide/from16 v19, v4

    int-to-double v3, v11

    sub-double v11, v19, v12

    .line 3
    invoke-static {v11, v12, v9, v10}, Ljava/lang/Math;->pow(DD)D

    move-result-wide v11

    sub-double/2addr v3, v14

    invoke-static {v3, v4, v9, v10}, Ljava/lang/Math;->pow(DD)D

    move-result-wide v3

    add-double/2addr v3, v11

    invoke-static {v3, v4}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide v3

    .line 4
    new-instance v5, Ljava/lang/StringBuilder;

    const-string v9, "Calculate Distance - "

    invoke-direct {v5, v9}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v5, v6, v7}, Ljava/lang/StringBuilder;->append(D)Ljava/lang/StringBuilder;

    const/16 v9, 0x20

    invoke-virtual {v5, v9}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v5, v3, v4}, Ljava/lang/StringBuilder;->append(D)Ljava/lang/StringBuilder;

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    const-string v9, "SFBarcode"

    invoke-static {v9, v5}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    cmpl-double v3, v6, v3

    if-lez v3, :cond_0

    new-instance v3, Landroid/graphics/Point;

    aget-object v4, v18, v16

    iget v5, v4, Landroid/graphics/Point;->x:I

    iget v4, v4, Landroid/graphics/Point;->y:I

    invoke-direct {v3, v5, v4}, Landroid/graphics/Point;-><init>(II)V

    new-instance v4, Landroid/graphics/Point;

    aget-object v5, v18, v8

    iget v6, v5, Landroid/graphics/Point;->x:I

    iget v5, v5, Landroid/graphics/Point;->y:I

    invoke-direct {v4, v6, v5}, Landroid/graphics/Point;-><init>(II)V

    :goto_0
    invoke-static {v3, v4}, Lcom/scanflow/datacapture/barcode/b;->a(Landroid/graphics/Point;Landroid/graphics/Point;)D

    move-result-wide v3

    move-object/from16 v5, p4

    goto :goto_1

    :cond_0
    new-instance v3, Landroid/graphics/Point;

    aget-object v4, v18, v8

    iget v5, v4, Landroid/graphics/Point;->x:I

    iget v4, v4, Landroid/graphics/Point;->y:I

    invoke-direct {v3, v5, v4}, Landroid/graphics/Point;-><init>(II)V

    new-instance v4, Landroid/graphics/Point;

    aget-object v5, v18, v17

    iget v6, v5, Landroid/graphics/Point;->x:I

    iget v5, v5, Landroid/graphics/Point;->y:I

    invoke-direct {v4, v6, v5}, Landroid/graphics/Point;-><init>(II)V

    goto :goto_0

    .line 5
    :goto_1
    iget-object v5, v5, Lcom/scanflow/datacapture/barinternal/B;->b:Landroid/graphics/Bitmap;

    .line 6
    const-string v6, "croppedBitmap"

    invoke-static {v5, v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {v5}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v7

    add-int/lit8 v7, v7, 0x32

    invoke-virtual {v5}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v10

    add-int/lit8 v10, v10, 0x32

    sget-object v11, Landroid/graphics/Bitmap$Config;->ARGB_8888:Landroid/graphics/Bitmap$Config;

    invoke-static {v7, v10, v11}, Landroid/graphics/Bitmap;->createBitmap(IILandroid/graphics/Bitmap$Config;)Landroid/graphics/Bitmap;

    move-result-object v7

    const-string v10, "createBitmap(...)"

    invoke-static {v7, v10}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v11, Landroid/graphics/Canvas;

    invoke-direct {v11, v7}, Landroid/graphics/Canvas;-><init>(Landroid/graphics/Bitmap;)V

    sget-object v12, Landroid/graphics/PorterDuff$Mode;->LIGHTEN:Landroid/graphics/PorterDuff$Mode;

    const/4 v13, -0x1

    invoke-virtual {v11, v13, v12}, Landroid/graphics/Canvas;->drawColor(ILandroid/graphics/PorterDuff$Mode;)V

    new-instance v12, Landroid/graphics/Paint;

    invoke-direct {v12}, Landroid/graphics/Paint;-><init>()V

    invoke-virtual {v12, v8}, Landroid/graphics/Paint;->setAntiAlias(Z)V

    invoke-virtual {v12, v8}, Landroid/graphics/Paint;->setFilterBitmap(Z)V

    invoke-virtual {v12, v8}, Landroid/graphics/Paint;->setDither(Z)V

    const/16 v13, 0x19

    int-to-float v13, v13

    invoke-virtual {v11, v5, v13, v13, v12}, Landroid/graphics/Canvas;->drawBitmap(Landroid/graphics/Bitmap;FFLandroid/graphics/Paint;)V

    double-to-float v3, v3

    .line 7
    invoke-static {v7, v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v4, Landroid/graphics/Matrix;

    invoke-direct {v4}, Landroid/graphics/Matrix;-><init>()V

    invoke-virtual {v4, v3}, Landroid/graphics/Matrix;->postRotate(F)Z

    invoke-virtual {v7}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v3

    invoke-virtual {v7}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v5

    invoke-static {v7, v3, v5, v8}, Landroid/graphics/Bitmap;->createScaledBitmap(Landroid/graphics/Bitmap;IIZ)Landroid/graphics/Bitmap;

    move-result-object v3

    const-string v5, "createScaledBitmap(...)"

    invoke-static {v3, v5}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {v3}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v21

    invoke-virtual {v3}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v22

    const/16 v20, 0x0

    const/16 v24, 0x1

    const/16 v19, 0x0

    move-object/from16 v18, v3

    move-object/from16 v23, v4

    invoke-static/range {v18 .. v24}, Landroid/graphics/Bitmap;->createBitmap(Landroid/graphics/Bitmap;IIIILandroid/graphics/Matrix;Z)Landroid/graphics/Bitmap;

    move-result-object v3

    invoke-static {v3, v10}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    .line 8
    invoke-virtual/range {p6 .. p6}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Ljava/util/List;

    move/from16 v5, v16

    invoke-interface {v4, v5}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Lcom/google/mlkit/vision/barcode/common/Barcode;

    invoke-virtual {v4}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getFormat()I

    move-result v4

    move/from16 v5, v17

    if-ne v4, v5, :cond_5

    sget-object v4, Lcom/scanflow/datacapture/barinternal/l;->a:Lcom/google/mlkit/vision/barcode/BarcodeScanner;

    const-string v4, "decodeZxing - Started"

    invoke-static {v9, v4}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    new-instance v4, Ljava/util/ArrayList;

    invoke-direct {v4}, Ljava/util/ArrayList;-><init>()V

    invoke-virtual {v3}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v4

    invoke-virtual {v3}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v5

    mul-int/2addr v5, v4

    new-array v4, v5, [I

    invoke-virtual {v3}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v28

    invoke-virtual {v3}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v31

    invoke-virtual {v3}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v32

    const/16 v29, 0x0

    const/16 v30, 0x0

    const/16 v27, 0x0

    move-object/from16 v25, v3

    move-object/from16 v26, v4

    invoke-virtual/range {v25 .. v32}, Landroid/graphics/Bitmap;->getPixels([IIIIIII)V

    move-object/from16 v3, v26

    new-instance v4, Lcom/google/zxing/RGBLuminanceSource;

    invoke-virtual/range {v25 .. v25}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v5

    invoke-virtual/range {v25 .. v25}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v6

    invoke-direct {v4, v5, v6, v3}, Lcom/google/zxing/RGBLuminanceSource;-><init>(II[I)V

    new-instance v3, Lcom/google/zxing/common/HybridBinarizer;

    invoke-direct {v3, v4}, Lcom/google/zxing/common/HybridBinarizer;-><init>(Lcom/google/zxing/LuminanceSource;)V

    new-instance v5, Lcom/google/zxing/MultiFormatReader;

    invoke-direct {v5}, Lcom/google/zxing/MultiFormatReader;-><init>()V

    new-instance v6, Ljava/util/HashMap;

    invoke-direct {v6}, Ljava/util/HashMap;-><init>()V

    sget-object v7, Lcom/google/zxing/DecodeHintType;->PURE_BARCODE:Lcom/google/zxing/DecodeHintType;

    sget-object v8, Ljava/lang/Boolean;->TRUE:Ljava/lang/Boolean;

    invoke-virtual {v6, v7, v8}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    invoke-virtual {v5, v6}, Lcom/google/zxing/MultiFormatReader;->setHints(Ljava/util/Map;)V

    :try_start_0
    new-instance v7, Lcom/google/zxing/BinaryBitmap;

    invoke-direct {v7, v3}, Lcom/google/zxing/BinaryBitmap;-><init>(Lcom/google/zxing/Binarizer;)V

    invoke-virtual {v5, v7, v6}, Lcom/google/zxing/MultiFormatReader;->decode(Lcom/google/zxing/BinaryBitmap;Ljava/util/Map;)Lcom/google/zxing/Result;

    move-result-object v3

    if-nez v3, :cond_1

    new-instance v3, Lcom/google/zxing/BinaryBitmap;

    new-instance v7, Lcom/google/zxing/common/GlobalHistogramBinarizer;

    invoke-direct {v7, v4}, Lcom/google/zxing/common/GlobalHistogramBinarizer;-><init>(Lcom/google/zxing/LuminanceSource;)V

    invoke-direct {v3, v7}, Lcom/google/zxing/BinaryBitmap;-><init>(Lcom/google/zxing/Binarizer;)V

    invoke-virtual {v5, v3, v6}, Lcom/google/zxing/MultiFormatReader;->decode(Lcom/google/zxing/BinaryBitmap;Ljava/util/Map;)Lcom/google/zxing/Result;

    move-result-object v3
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_1
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    goto :goto_2

    :catchall_0
    move-exception v0

    goto/16 :goto_7

    :cond_1
    :goto_2
    invoke-virtual {v5}, Lcom/google/zxing/MultiFormatReader;->reset()V

    if-nez v3, :cond_3

    invoke-virtual {v4}, Lcom/google/zxing/LuminanceSource;->invert()Lcom/google/zxing/LuminanceSource;

    move-result-object v3

    :try_start_1
    new-instance v4, Lcom/google/zxing/common/HybridBinarizer;

    invoke-direct {v4, v3}, Lcom/google/zxing/common/HybridBinarizer;-><init>(Lcom/google/zxing/LuminanceSource;)V

    new-instance v6, Lcom/google/zxing/BinaryBitmap;

    invoke-direct {v6, v4}, Lcom/google/zxing/BinaryBitmap;-><init>(Lcom/google/zxing/Binarizer;)V

    invoke-virtual {v5, v6}, Lcom/google/zxing/MultiFormatReader;->decodeWithState(Lcom/google/zxing/BinaryBitmap;)Lcom/google/zxing/Result;

    move-result-object v4

    if-nez v4, :cond_2

    new-instance v4, Lcom/google/zxing/BinaryBitmap;

    new-instance v6, Lcom/google/zxing/common/GlobalHistogramBinarizer;

    invoke-direct {v6, v3}, Lcom/google/zxing/common/GlobalHistogramBinarizer;-><init>(Lcom/google/zxing/LuminanceSource;)V

    invoke-direct {v4, v6}, Lcom/google/zxing/BinaryBitmap;-><init>(Lcom/google/zxing/Binarizer;)V

    invoke-virtual {v5, v4}, Lcom/google/zxing/MultiFormatReader;->decodeWithState(Lcom/google/zxing/BinaryBitmap;)Lcom/google/zxing/Result;

    move-result-object v3

    goto :goto_3

    :catchall_1
    move-exception v0

    goto :goto_4

    :cond_2
    move-object v3, v4

    :goto_3
    const-string v4, "White_points_inverted"

    invoke-virtual {v3}, Lcom/google/zxing/Result;->getResultPoints()[Lcom/google/zxing/ResultPoint;

    move-result-object v6

    const/16 v16, 0x0

    aget-object v6, v6, v16

    invoke-virtual {v6}, Lcom/google/zxing/ResultPoint;->toString()Ljava/lang/String;

    move-result-object v6

    invoke-static {v4, v6}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_0
    .catchall {:try_start_1 .. :try_end_1} :catchall_1

    invoke-virtual {v5}, Lcom/google/zxing/MultiFormatReader;->reset()V

    goto :goto_5

    :catch_0
    :try_start_2
    const-string v3, "Exception - 1"

    invoke-static {v2, v3}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_2
    .catchall {:try_start_2 .. :try_end_2} :catchall_1

    goto :goto_6

    :goto_4
    invoke-virtual {v5}, Lcom/google/zxing/MultiFormatReader;->reset()V

    throw v0

    :cond_3
    :goto_5
    invoke-virtual {v3}, Lcom/google/zxing/Result;->getText()Ljava/lang/String;

    move-result-object v4

    if-eqz v4, :cond_4

    const-string v5, "decodeZxing - "

    invoke-virtual {v5, v4}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    invoke-static {v2, v4}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    :cond_4
    const-string v2, "decodeZxing - Completed"

    invoke-static {v9, v2}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    invoke-virtual {v3}, Lcom/google/zxing/Result;->getText()Ljava/lang/String;

    move-result-object v2

    goto :goto_8

    :catch_1
    :try_start_3
    const-string v3, "Exception - 0"

    invoke-static {v2, v3}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_3
    .catchall {:try_start_3 .. :try_end_3} :catchall_0

    :goto_6
    invoke-virtual {v5}, Lcom/google/zxing/MultiFormatReader;->reset()V

    const/4 v2, 0x0

    goto :goto_8

    :goto_7
    invoke-virtual {v5}, Lcom/google/zxing/MultiFormatReader;->reset()V

    throw v0

    :cond_5
    invoke-virtual/range {p6 .. p6}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Ljava/util/List;

    const/4 v5, 0x0

    invoke-interface {v2, v5}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/google/mlkit/vision/barcode/common/Barcode;

    invoke-virtual {v2}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getDisplayValue()Ljava/lang/String;

    move-result-object v2

    :goto_8
    if-eqz v2, :cond_8

    const-string v3, "zxingOutputBatch"

    invoke-static {v3, v2}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    invoke-virtual {v2}, Ljava/lang/String;->length()I

    move-result v3

    if-nez v3, :cond_7

    new-instance v2, Lcom/scanflow/datacapture/barinternal/C;

    const/4 v3, 0x0

    invoke-direct {v2, v3, v3, v3}, Lcom/scanflow/datacapture/barinternal/C;-><init>(Landroid/graphics/RectF;Lcom/google/mlkit/vision/barcode/common/Barcode;Ljava/lang/String;)V

    invoke-virtual {v0, v2}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    :cond_6
    :goto_9
    const/4 v5, 0x0

    goto :goto_a

    :cond_7
    new-instance v3, Lcom/scanflow/datacapture/barinternal/C;

    invoke-virtual/range {p1 .. p2}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Lcom/scanflow/datacapture/barinternal/B;

    .line 9
    iget-object v4, v4, Lcom/scanflow/datacapture/barinternal/B;->a:Landroid/graphics/RectF;

    .line 10
    invoke-virtual/range {p6 .. p6}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v5

    check-cast v5, Ljava/util/List;

    const/4 v6, 0x0

    invoke-interface {v5, v6}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v5

    check-cast v5, Lcom/google/mlkit/vision/barcode/common/Barcode;

    invoke-direct {v3, v4, v5, v2}, Lcom/scanflow/datacapture/barinternal/C;-><init>(Landroid/graphics/RectF;Lcom/google/mlkit/vision/barcode/common/Barcode;Ljava/lang/String;)V

    invoke-virtual {v0, v3}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    goto :goto_9

    :cond_8
    new-instance v2, Lcom/scanflow/datacapture/barinternal/C;

    const/4 v3, 0x0

    invoke-direct {v2, v3, v3, v3}, Lcom/scanflow/datacapture/barinternal/C;-><init>(Landroid/graphics/RectF;Lcom/google/mlkit/vision/barcode/common/Barcode;Ljava/lang/String;)V

    invoke-virtual {v0, v2}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    goto :goto_9

    :cond_9
    new-instance v2, Lcom/scanflow/datacapture/barinternal/C;

    invoke-virtual/range {p1 .. p2}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Lcom/scanflow/datacapture/barinternal/B;

    .line 11
    iget-object v3, v3, Lcom/scanflow/datacapture/barinternal/B;->a:Landroid/graphics/RectF;

    .line 12
    invoke-virtual/range {p6 .. p6}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Ljava/util/List;

    const/4 v5, 0x0

    invoke-interface {v4, v5}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Lcom/google/mlkit/vision/barcode/common/Barcode;

    const/4 v5, 0x0

    invoke-direct {v2, v3, v4, v5}, Lcom/scanflow/datacapture/barinternal/C;-><init>(Landroid/graphics/RectF;Lcom/google/mlkit/vision/barcode/common/Barcode;Ljava/lang/String;)V

    invoke-virtual {v0, v2}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    goto :goto_a

    :cond_a
    const/4 v5, 0x0

    new-instance v2, Lcom/scanflow/datacapture/barinternal/C;

    invoke-virtual/range {p1 .. p2}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Lcom/scanflow/datacapture/barinternal/B;

    .line 13
    iget-object v3, v3, Lcom/scanflow/datacapture/barinternal/B;->a:Landroid/graphics/RectF;

    .line 14
    invoke-direct {v2, v3, v5, v5}, Lcom/scanflow/datacapture/barinternal/C;-><init>(Landroid/graphics/RectF;Lcom/google/mlkit/vision/barcode/common/Barcode;Ljava/lang/String;)V

    invoke-virtual {v0, v2}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    :goto_a
    invoke-virtual {v0}, Ljava/util/ArrayList;->size()I

    move-result v2

    invoke-virtual/range {p1 .. p1}, Ljava/util/ArrayList;->size()I

    move-result v3

    if-ne v2, v3, :cond_18

    invoke-virtual {v1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 15
    const-string v2, "batchScanningResultList"

    invoke-static {v0, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {v0}, Ljava/util/ArrayList;->size()I

    move-result v2

    if-lez v2, :cond_17

    new-instance v2, Ljava/util/ArrayList;

    invoke-direct {v2}, Ljava/util/ArrayList;-><init>()V

    iget-object v3, v1, Lcom/scanflow/datacapture/barcode/b;->o:Ljava/util/LinkedList;

    invoke-virtual {v3}, Ljava/util/LinkedList;->clear()V

    invoke-virtual {v0}, Ljava/util/ArrayList;->iterator()Ljava/util/Iterator;

    move-result-object v0

    const-string v3, "iterator(...)"

    invoke-static {v0, v3}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    :cond_b
    :goto_b
    invoke-interface {v0}, Ljava/util/Iterator;->hasNext()Z

    move-result v3

    if-eqz v3, :cond_16

    invoke-interface {v0}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v3

    const-string v4, "next(...)"

    invoke-static {v3, v4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast v3, Lcom/scanflow/datacapture/barinternal/C;

    new-instance v10, Ljava/util/ArrayList;

    invoke-direct {v10}, Ljava/util/ArrayList;-><init>()V

    .line 16
    iget-object v4, v3, Lcom/scanflow/datacapture/barinternal/C;->b:Lcom/google/mlkit/vision/barcode/common/Barcode;

    if-eqz v4, :cond_b

    .line 17
    iget-object v6, v3, Lcom/scanflow/datacapture/barinternal/C;->c:Ljava/lang/String;

    if-nez v6, :cond_c

    .line 18
    invoke-virtual {v4}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getDisplayValue()Ljava/lang/String;

    move-result-object v6

    if-eqz v6, :cond_b

    invoke-virtual {v4}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getDisplayValue()Ljava/lang/String;

    move-result-object v6

    invoke-static {v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {v6}, Ljava/lang/String;->length()I

    move-result v6

    if-nez v6, :cond_c

    goto :goto_b

    :cond_c
    new-instance v6, Lcom/scanflow/datacapture/model/ScanResultSuccess;

    .line 19
    iget-object v7, v3, Lcom/scanflow/datacapture/barinternal/C;->c:Ljava/lang/String;

    if-eqz v7, :cond_d

    goto :goto_c

    .line 20
    :cond_d
    invoke-virtual {v4}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getDisplayValue()Ljava/lang/String;

    move-result-object v11

    invoke-static {v11}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    const/4 v15, 0x4

    const/16 v16, 0x0

    const-string v12, "\u001d"

    const-string v13, " "

    const/4 v14, 0x0

    invoke-static/range {v11 .. v16}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->replace$default(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ZILjava/lang/Object;)Ljava/lang/String;

    move-result-object v7

    invoke-static {v7}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->trimStart(Ljava/lang/CharSequence;)Ljava/lang/CharSequence;

    move-result-object v7

    invoke-virtual {v7}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v7

    :goto_c
    invoke-virtual {v4}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getFormat()I

    move-result v8

    invoke-static {v8}, Lcom/scanflow/datacapture/barcode/b;->a(I)Lcom/scanflow/datacapture/utils/BarcodeFormat;

    move-result-object v8

    .line 21
    iget-object v11, v3, Lcom/scanflow/datacapture/barinternal/C;->a:Landroid/graphics/RectF;

    .line 22
    invoke-static {v11}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    iget-object v12, v1, Lcom/scanflow/datacapture/barcode/b;->q:Ljava/lang/String;

    const/4 v9, 0x0

    invoke-direct/range {v6 .. v12}, Lcom/scanflow/datacapture/model/ScanResultSuccess;-><init>(Ljava/lang/String;Lcom/scanflow/datacapture/utils/BarcodeFormat;ZLjava/util/ArrayList;Landroid/graphics/RectF;Ljava/lang/String;)V

    invoke-virtual {v2, v6}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    new-instance v6, Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;

    invoke-virtual {v4}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getDisplayValue()Ljava/lang/String;

    move-result-object v7

    invoke-static {v7}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {v4}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getFormat()I

    move-result v8

    invoke-static {v8}, Lcom/scanflow/datacapture/barcode/b;->a(I)Lcom/scanflow/datacapture/utils/BarcodeFormat;

    move-result-object v8

    invoke-virtual {v8}, Ljava/lang/Enum;->name()Ljava/lang/String;

    move-result-object v8

    invoke-direct {v6, v7, v8}, Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    new-instance v7, Lcom/scanflow/datacapture/barinternal/b;

    invoke-virtual {v4}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getDisplayValue()Ljava/lang/String;

    move-result-object v8

    invoke-static {v8}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {v4}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getFormat()I

    move-result v4

    invoke-static {v4}, Lcom/scanflow/datacapture/barcode/b;->a(I)Lcom/scanflow/datacapture/utils/BarcodeFormat;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/Enum;->name()Ljava/lang/String;

    move-result-object v4

    const/high16 v9, 0x3f000000    # 0.5f

    .line 23
    iget-object v10, v3, Lcom/scanflow/datacapture/barinternal/C;->a:Landroid/graphics/RectF;

    .line 24
    invoke-direct {v7, v8, v4, v9, v10}, Lcom/scanflow/datacapture/barinternal/b;-><init>(Ljava/lang/String;Ljava/lang/String;FLandroid/graphics/RectF;)V

    iget-boolean v4, v1, Lcom/scanflow/datacapture/barcode/b;->h:Z

    if-eqz v4, :cond_f

    iget-object v4, v1, Lcom/scanflow/datacapture/barcode/b;->p:Ljava/util/HashSet;

    invoke-virtual {v4, v6}, Ljava/util/HashSet;->contains(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_e

    goto :goto_d

    .line 26
    :cond_e
    const-string v4, "#FFFFFF"

    invoke-static {v4}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result v4

    goto :goto_e

    .line 24
    :cond_f
    :goto_d
    const-string v4, "#1ab3fb"

    invoke-static {v4}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result v4

    .line 25
    :goto_e
    iput v4, v7, Lcom/scanflow/datacapture/barinternal/b;->f:I

    .line 27
    iget-object v4, v3, Lcom/scanflow/datacapture/barinternal/C;->b:Lcom/google/mlkit/vision/barcode/common/Barcode;

    .line 28
    invoke-virtual {v4}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getFormat()I

    move-result v4

    const/4 v6, 0x2

    if-ne v4, v6, :cond_10

    .line 29
    iget-object v4, v3, Lcom/scanflow/datacapture/barinternal/C;->c:Ljava/lang/String;

    goto :goto_f

    .line 30
    :cond_10
    iget-object v4, v3, Lcom/scanflow/datacapture/barinternal/C;->b:Lcom/google/mlkit/vision/barcode/common/Barcode;

    if-eqz v4, :cond_11

    .line 31
    invoke-virtual {v4}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getDisplayValue()Ljava/lang/String;

    move-result-object v4

    goto :goto_f

    :cond_11
    move-object v4, v5

    :goto_f
    if-eqz v4, :cond_15

    .line 32
    iget-object v8, v3, Lcom/scanflow/datacapture/barinternal/C;->a:Landroid/graphics/RectF;

    if-eqz v8, :cond_12

    .line 33
    invoke-virtual {v4}, Ljava/lang/String;->length()I

    move-result v8

    if-nez v8, :cond_13

    :cond_12
    const/16 v9, 0x20

    goto :goto_10

    :cond_13
    iget-object v8, v1, Lcom/scanflow/datacapture/barcode/b;->n:Ljava/util/HashSet;

    invoke-virtual {v8, v4}, Ljava/util/HashSet;->contains(Ljava/lang/Object;)Z

    move-result v8

    if-eqz v8, :cond_14

    iget-boolean v8, v1, Lcom/scanflow/datacapture/barcode/b;->h:Z

    if-eqz v8, :cond_12

    :cond_14
    new-instance v8, Ljava/lang/StringBuilder;

    const-string v9, "scannedMatrixDataList.contains(it): "

    invoke-direct {v8, v9}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    iget-object v9, v1, Lcom/scanflow/datacapture/barcode/b;->n:Ljava/util/HashSet;

    invoke-virtual {v9, v4}, Ljava/util/HashSet;->contains(Ljava/lang/Object;)Z

    move-result v9

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    const/16 v9, 0x20

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    iget-boolean v10, v1, Lcom/scanflow/datacapture/barcode/b;->h:Z

    invoke-virtual {v8, v10}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v8

    const-string v10, "batchScanningResult"

    invoke-static {v10, v8}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    new-instance v8, Ljava/lang/StringBuilder;

    const-string v11, "batchScanningResult: "

    invoke-direct {v8, v11}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    .line 34
    iget-object v11, v3, Lcom/scanflow/datacapture/barinternal/C;->a:Landroid/graphics/RectF;

    .line 35
    invoke-virtual {v8, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    .line 36
    iget-object v3, v3, Lcom/scanflow/datacapture/barinternal/C;->c:Ljava/lang/String;

    .line 37
    invoke-virtual {v8, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v10, v3}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    :goto_10
    iget-object v3, v1, Lcom/scanflow/datacapture/barcode/b;->n:Ljava/util/HashSet;

    invoke-virtual {v3, v4}, Ljava/util/HashSet;->add(Ljava/lang/Object;)Z

    goto :goto_11

    :cond_15
    const/16 v9, 0x20

    :goto_11
    iget-object v3, v1, Lcom/scanflow/datacapture/barcode/b;->o:Ljava/util/LinkedList;

    invoke-virtual {v3, v7}, Ljava/util/LinkedList;->add(Ljava/lang/Object;)Z

    goto/16 :goto_b

    :cond_16
    iget-object v0, v1, Lcom/scanflow/datacapture/barcode/b;->a:Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;

    if-eqz v0, :cond_18

    invoke-interface {v0, v2}, Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;->onBatchScanResultSuccess(Ljava/util/ArrayList;)V

    goto :goto_12

    :cond_17
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barcode/b;->a()V

    :cond_18
    :goto_12
    return-void
.end method


# virtual methods
.method public final create(Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Lkotlin/coroutines/Continuation;
    .locals 3

    .line 1
    new-instance v0, Lcom/scanflow/datacapture/barinternal/A;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/A;->b:Ljava/util/ArrayList;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/A;->c:Lcom/scanflow/datacapture/barcode/b;

    invoke-direct {v0, v1, v2, p2}, Lcom/scanflow/datacapture/barinternal/A;-><init>(Ljava/util/ArrayList;Lcom/scanflow/datacapture/barcode/b;Lkotlin/coroutines/Continuation;)V

    iput-object p1, v0, Lcom/scanflow/datacapture/barinternal/A;->a:Ljava/lang/Object;

    return-object v0
.end method

.method public final invoke(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    check-cast p1, Lkotlinx/coroutines/CoroutineScope;

    check-cast p2, Lkotlin/coroutines/Continuation;

    .line 1
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/A;->create(Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Lkotlin/coroutines/Continuation;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/A;

    sget-object p2, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/A;->invokeSuspend(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method

.method public final invokeSuspend(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 10

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->getCOROUTINE_SUSPENDED()Ljava/lang/Object;

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/ResultKt;->throwOnFailure(Ljava/lang/Object;)V

    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/A;->a:Ljava/lang/Object;

    move-object v6, p1

    check-cast v6, Lkotlinx/coroutines/CoroutineScope;

    new-instance v1, Ljava/util/ArrayList;

    invoke-direct {v1}, Ljava/util/ArrayList;-><init>()V

    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/A;->b:Ljava/util/ArrayList;

    invoke-interface {p1}, Ljava/lang/Iterable;->iterator()Ljava/util/Iterator;

    move-result-object p1

    const/4 v7, 0x0

    move v3, v7

    :goto_0
    invoke-interface {p1}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_0

    add-int/lit8 v8, v3, 0x1

    invoke-interface {p1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    move-object v5, v0

    check-cast v5, Lcom/scanflow/datacapture/barinternal/B;

    .line 1
    iget-object v0, v5, Lcom/scanflow/datacapture/barinternal/B;->b:Landroid/graphics/Bitmap;

    .line 2
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/t;->a(Landroid/graphics/Bitmap;)Landroid/graphics/Bitmap;

    move-result-object v0

    invoke-static {v0, v7}, Lcom/google/mlkit/vision/common/InputImage;->fromBitmap(Landroid/graphics/Bitmap;I)Lcom/google/mlkit/vision/common/InputImage;

    move-result-object v0

    const-string v2, "fromBitmap(...)"

    invoke-static {v0, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v2, Landroid/graphics/Canvas;

    .line 3
    iget-object v4, v5, Lcom/scanflow/datacapture/barinternal/B;->b:Landroid/graphics/Bitmap;

    .line 4
    invoke-direct {v2, v4}, Landroid/graphics/Canvas;-><init>(Landroid/graphics/Bitmap;)V

    .line 5
    sget-object v2, Lcom/scanflow/datacapture/barinternal/l;->a:Lcom/google/mlkit/vision/barcode/BarcodeScanner;

    .line 6
    invoke-interface {v2, v0}, Lcom/google/mlkit/vision/barcode/BarcodeScanner;->process(Lcom/google/mlkit/vision/common/InputImage;)Lcom/google/android/gms/tasks/Task;

    move-result-object v9

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/A;->b:Ljava/util/ArrayList;

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/A;->c:Lcom/scanflow/datacapture/barcode/b;

    new-instance v0, Lcom/scanflow/datacapture/barinternal/A$$ExternalSyntheticLambda0;

    invoke-direct/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/A$$ExternalSyntheticLambda0;-><init>(Ljava/util/ArrayList;Ljava/util/ArrayList;ILcom/scanflow/datacapture/barcode/b;Lcom/scanflow/datacapture/barinternal/B;Lkotlinx/coroutines/CoroutineScope;)V

    invoke-virtual {v9, v0}, Lcom/google/android/gms/tasks/Task;->addOnCompleteListener(Lcom/google/android/gms/tasks/OnCompleteListener;)Lcom/google/android/gms/tasks/Task;

    move v3, v8

    goto :goto_0

    :cond_0
    return-object v1
.end method
