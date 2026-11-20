.class public final Lcom/scanflow/datacapture/barinternal/K;
.super Lkotlin/coroutines/jvm/internal/SuspendLambda;
.source "SourceFile"

# interfaces
.implements Lkotlin/jvm/functions/Function2;


# instance fields
.field public synthetic a:Ljava/lang/Object;

.field public final synthetic b:Ljava/util/ArrayList;

.field public final synthetic c:Lcom/scanflow/datacapture/barinternal/M;

.field public final synthetic d:Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;


# direct methods
.method public constructor <init>(Ljava/util/ArrayList;Lcom/scanflow/datacapture/barinternal/M;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;Lkotlin/coroutines/Continuation;)V
    .locals 0

    .line 1
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/K;->b:Ljava/util/ArrayList;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/K;->c:Lcom/scanflow/datacapture/barinternal/M;

    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/K;->d:Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;

    const/4 p1, 0x2

    invoke-direct {p0, p1, p4}, Lkotlin/coroutines/jvm/internal/SuspendLambda;-><init>(ILkotlin/coroutines/Continuation;)V

    return-void
.end method

.method public static final a(Ljava/util/ArrayList;Ljava/util/ArrayList;ILcom/scanflow/datacapture/barinternal/M;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;Lcom/scanflow/datacapture/barinternal/B;Lkotlinx/coroutines/CoroutineScope;Lcom/google/android/gms/tasks/Task;)V
    .locals 33

    move-object/from16 v0, p0

    const-string v1, "processModelResultZxing"

    invoke-virtual/range {p7 .. p7}, Lcom/google/android/gms/tasks/Task;->isSuccessful()Z

    move-result v2

    if-eqz v2, :cond_9

    invoke-virtual/range {p7 .. p7}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Ljava/util/List;

    invoke-interface {v2}, Ljava/util/List;->size()I

    move-result v2

    if-lez v2, :cond_9

    invoke-virtual/range {p7 .. p7}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Ljava/util/List;

    const/4 v4, 0x0

    invoke-interface {v2, v4}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/google/mlkit/vision/barcode/common/Barcode;

    invoke-virtual {v2}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getFormat()I

    move-result v2

    const/16 v5, 0x100

    if-eq v2, v5, :cond_8

    invoke-virtual/range {p7 .. p7}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Ljava/util/List;

    invoke-interface {v2, v4}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/google/mlkit/vision/barcode/common/Barcode;

    invoke-virtual {v2}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getCornerPoints()[Landroid/graphics/Point;

    move-result-object v2

    if-eqz v2, :cond_a

    aget-object v5, v2, v4

    iget v6, v5, Landroid/graphics/Point;->x:I

    int-to-double v6, v6

    iget v5, v5, Landroid/graphics/Point;->y:I

    int-to-double v8, v5

    const/4 v5, 0x1

    aget-object v10, v2, v5

    iget v11, v10, Landroid/graphics/Point;->x:I

    int-to-double v11, v11

    iget v10, v10, Landroid/graphics/Point;->y:I

    int-to-double v13, v10

    invoke-virtual/range {p3 .. p3}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    sub-double/2addr v11, v6

    const/4 v6, 0x2

    move v7, v4

    int-to-double v3, v6

    .line 1
    invoke-static {v11, v12, v3, v4}, Ljava/lang/Math;->pow(DD)D

    move-result-wide v10

    sub-double/2addr v13, v8

    invoke-static {v13, v14, v3, v4}, Ljava/lang/Math;->pow(DD)D

    move-result-wide v8

    add-double/2addr v8, v10

    invoke-static {v8, v9}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide v8

    .line 2
    aget-object v10, v2, v5

    iget v11, v10, Landroid/graphics/Point;->x:I

    int-to-double v11, v11

    iget v10, v10, Landroid/graphics/Point;->y:I

    int-to-double v13, v10

    aget-object v10, v2, v6

    iget v15, v10, Landroid/graphics/Point;->x:I

    move/from16 v16, v6

    move/from16 v17, v7

    int-to-double v6, v15

    iget v10, v10, Landroid/graphics/Point;->y:I

    move v15, v5

    move-wide/from16 v18, v6

    int-to-double v5, v10

    sub-double v10, v18, v11

    .line 3
    invoke-static {v10, v11, v3, v4}, Ljava/lang/Math;->pow(DD)D

    move-result-wide v10

    sub-double/2addr v5, v13

    invoke-static {v5, v6, v3, v4}, Ljava/lang/Math;->pow(DD)D

    move-result-wide v3

    add-double/2addr v3, v10

    invoke-static {v3, v4}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide v3

    .line 4
    new-instance v5, Ljava/lang/StringBuilder;

    const-string v6, "Calculate Distance - "

    invoke-direct {v5, v6}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v5, v8, v9}, Ljava/lang/StringBuilder;->append(D)Ljava/lang/StringBuilder;

    const/16 v6, 0x20

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v5, v3, v4}, Ljava/lang/StringBuilder;->append(D)Ljava/lang/StringBuilder;

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    const-string v6, "SFBarcode"

    invoke-static {v6, v5}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    cmpl-double v3, v8, v3

    if-lez v3, :cond_0

    new-instance v3, Landroid/graphics/Point;

    aget-object v4, v2, v17

    iget v5, v4, Landroid/graphics/Point;->x:I

    iget v4, v4, Landroid/graphics/Point;->y:I

    invoke-direct {v3, v5, v4}, Landroid/graphics/Point;-><init>(II)V

    new-instance v4, Landroid/graphics/Point;

    aget-object v2, v2, v15

    iget v5, v2, Landroid/graphics/Point;->x:I

    iget v2, v2, Landroid/graphics/Point;->y:I

    invoke-direct {v4, v5, v2}, Landroid/graphics/Point;-><init>(II)V

    :goto_0
    invoke-static {v3, v4}, Lcom/scanflow/datacapture/barinternal/M;->a(Landroid/graphics/Point;Landroid/graphics/Point;)D

    move-result-wide v2

    move-object/from16 v4, p5

    goto :goto_1

    :cond_0
    new-instance v3, Landroid/graphics/Point;

    aget-object v4, v2, v15

    iget v5, v4, Landroid/graphics/Point;->x:I

    iget v4, v4, Landroid/graphics/Point;->y:I

    invoke-direct {v3, v5, v4}, Landroid/graphics/Point;-><init>(II)V

    new-instance v4, Landroid/graphics/Point;

    aget-object v2, v2, v16

    iget v5, v2, Landroid/graphics/Point;->x:I

    iget v2, v2, Landroid/graphics/Point;->y:I

    invoke-direct {v4, v5, v2}, Landroid/graphics/Point;-><init>(II)V

    goto :goto_0

    .line 5
    :goto_1
    iget-object v4, v4, Lcom/scanflow/datacapture/barinternal/B;->b:Landroid/graphics/Bitmap;

    .line 6
    const-string v5, "croppedBitmap"

    invoke-static {v4, v5}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {v4}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v7

    add-int/lit8 v7, v7, 0x32

    invoke-virtual {v4}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v8

    add-int/lit8 v8, v8, 0x32

    sget-object v9, Landroid/graphics/Bitmap$Config;->ARGB_8888:Landroid/graphics/Bitmap$Config;

    invoke-static {v7, v8, v9}, Landroid/graphics/Bitmap;->createBitmap(IILandroid/graphics/Bitmap$Config;)Landroid/graphics/Bitmap;

    move-result-object v7

    const-string v8, "createBitmap(...)"

    invoke-static {v7, v8}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v9, Landroid/graphics/Canvas;

    invoke-direct {v9, v7}, Landroid/graphics/Canvas;-><init>(Landroid/graphics/Bitmap;)V

    sget-object v10, Landroid/graphics/PorterDuff$Mode;->LIGHTEN:Landroid/graphics/PorterDuff$Mode;

    const/4 v11, -0x1

    invoke-virtual {v9, v11, v10}, Landroid/graphics/Canvas;->drawColor(ILandroid/graphics/PorterDuff$Mode;)V

    new-instance v10, Landroid/graphics/Paint;

    invoke-direct {v10}, Landroid/graphics/Paint;-><init>()V

    invoke-virtual {v10, v15}, Landroid/graphics/Paint;->setAntiAlias(Z)V

    invoke-virtual {v10, v15}, Landroid/graphics/Paint;->setFilterBitmap(Z)V

    invoke-virtual {v10, v15}, Landroid/graphics/Paint;->setDither(Z)V

    const/16 v11, 0x19

    int-to-float v11, v11

    invoke-virtual {v9, v4, v11, v11, v10}, Landroid/graphics/Canvas;->drawBitmap(Landroid/graphics/Bitmap;FFLandroid/graphics/Paint;)V

    double-to-float v2, v2

    .line 7
    invoke-static {v7, v5}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v3, Landroid/graphics/Matrix;

    invoke-direct {v3}, Landroid/graphics/Matrix;-><init>()V

    invoke-virtual {v3, v2}, Landroid/graphics/Matrix;->postRotate(F)Z

    invoke-virtual {v7}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v2

    invoke-virtual {v7}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v4

    invoke-static {v7, v2, v4, v15}, Landroid/graphics/Bitmap;->createScaledBitmap(Landroid/graphics/Bitmap;IIZ)Landroid/graphics/Bitmap;

    move-result-object v2

    const-string v4, "createScaledBitmap(...)"

    invoke-static {v2, v4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {v2}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v21

    invoke-virtual {v2}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v22

    const/16 v20, 0x0

    const/16 v24, 0x1

    const/16 v19, 0x0

    move-object/from16 v18, v2

    move-object/from16 v23, v3

    invoke-static/range {v18 .. v24}, Landroid/graphics/Bitmap;->createBitmap(Landroid/graphics/Bitmap;IIIILandroid/graphics/Matrix;Z)Landroid/graphics/Bitmap;

    move-result-object v2

    invoke-static {v2, v8}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    .line 8
    invoke-virtual/range {p7 .. p7}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/util/List;

    move/from16 v7, v17

    invoke-interface {v3, v7}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Lcom/google/mlkit/vision/barcode/common/Barcode;

    invoke-virtual {v3}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getFormat()I

    move-result v3

    move/from16 v4, v16

    if-ne v3, v4, :cond_5

    sget-object v3, Lcom/scanflow/datacapture/barinternal/l;->a:Lcom/google/mlkit/vision/barcode/BarcodeScanner;

    const-string v3, "decodeZxing - Started"

    invoke-static {v6, v3}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    new-instance v3, Ljava/util/ArrayList;

    invoke-direct {v3}, Ljava/util/ArrayList;-><init>()V

    invoke-virtual {v2}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v3

    invoke-virtual {v2}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v4

    mul-int/2addr v4, v3

    new-array v3, v4, [I

    invoke-virtual {v2}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v28

    invoke-virtual {v2}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v31

    invoke-virtual {v2}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v32

    const/16 v29, 0x0

    const/16 v30, 0x0

    const/16 v27, 0x0

    move-object/from16 v25, v2

    move-object/from16 v26, v3

    invoke-virtual/range {v25 .. v32}, Landroid/graphics/Bitmap;->getPixels([IIIIIII)V

    move-object/from16 v2, v26

    new-instance v3, Lcom/google/zxing/RGBLuminanceSource;

    invoke-virtual/range {v25 .. v25}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v4

    invoke-virtual/range {v25 .. v25}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v5

    invoke-direct {v3, v4, v5, v2}, Lcom/google/zxing/RGBLuminanceSource;-><init>(II[I)V

    new-instance v2, Lcom/google/zxing/common/HybridBinarizer;

    invoke-direct {v2, v3}, Lcom/google/zxing/common/HybridBinarizer;-><init>(Lcom/google/zxing/LuminanceSource;)V

    new-instance v4, Lcom/google/zxing/MultiFormatReader;

    invoke-direct {v4}, Lcom/google/zxing/MultiFormatReader;-><init>()V

    new-instance v5, Ljava/util/HashMap;

    invoke-direct {v5}, Ljava/util/HashMap;-><init>()V

    sget-object v8, Lcom/google/zxing/DecodeHintType;->PURE_BARCODE:Lcom/google/zxing/DecodeHintType;

    sget-object v9, Ljava/lang/Boolean;->TRUE:Ljava/lang/Boolean;

    invoke-virtual {v5, v8, v9}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    invoke-virtual {v4, v5}, Lcom/google/zxing/MultiFormatReader;->setHints(Ljava/util/Map;)V

    :try_start_0
    new-instance v8, Lcom/google/zxing/BinaryBitmap;

    invoke-direct {v8, v2}, Lcom/google/zxing/BinaryBitmap;-><init>(Lcom/google/zxing/Binarizer;)V

    invoke-virtual {v4, v8, v5}, Lcom/google/zxing/MultiFormatReader;->decode(Lcom/google/zxing/BinaryBitmap;Ljava/util/Map;)Lcom/google/zxing/Result;

    move-result-object v2

    if-nez v2, :cond_1

    new-instance v2, Lcom/google/zxing/BinaryBitmap;

    new-instance v8, Lcom/google/zxing/common/GlobalHistogramBinarizer;

    invoke-direct {v8, v3}, Lcom/google/zxing/common/GlobalHistogramBinarizer;-><init>(Lcom/google/zxing/LuminanceSource;)V

    invoke-direct {v2, v8}, Lcom/google/zxing/BinaryBitmap;-><init>(Lcom/google/zxing/Binarizer;)V

    invoke-virtual {v4, v2, v5}, Lcom/google/zxing/MultiFormatReader;->decode(Lcom/google/zxing/BinaryBitmap;Ljava/util/Map;)Lcom/google/zxing/Result;

    move-result-object v2
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_1
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    goto :goto_2

    :catchall_0
    move-exception v0

    goto/16 :goto_8

    :cond_1
    :goto_2
    invoke-virtual {v4}, Lcom/google/zxing/MultiFormatReader;->reset()V

    if-nez v2, :cond_3

    invoke-virtual {v3}, Lcom/google/zxing/LuminanceSource;->invert()Lcom/google/zxing/LuminanceSource;

    move-result-object v2

    :try_start_1
    new-instance v3, Lcom/google/zxing/common/HybridBinarizer;

    invoke-direct {v3, v2}, Lcom/google/zxing/common/HybridBinarizer;-><init>(Lcom/google/zxing/LuminanceSource;)V

    new-instance v5, Lcom/google/zxing/BinaryBitmap;

    invoke-direct {v5, v3}, Lcom/google/zxing/BinaryBitmap;-><init>(Lcom/google/zxing/Binarizer;)V

    invoke-virtual {v4, v5}, Lcom/google/zxing/MultiFormatReader;->decodeWithState(Lcom/google/zxing/BinaryBitmap;)Lcom/google/zxing/Result;

    move-result-object v3

    if-nez v3, :cond_2

    new-instance v3, Lcom/google/zxing/BinaryBitmap;

    new-instance v5, Lcom/google/zxing/common/GlobalHistogramBinarizer;

    invoke-direct {v5, v2}, Lcom/google/zxing/common/GlobalHistogramBinarizer;-><init>(Lcom/google/zxing/LuminanceSource;)V

    invoke-direct {v3, v5}, Lcom/google/zxing/BinaryBitmap;-><init>(Lcom/google/zxing/Binarizer;)V

    invoke-virtual {v4, v3}, Lcom/google/zxing/MultiFormatReader;->decodeWithState(Lcom/google/zxing/BinaryBitmap;)Lcom/google/zxing/Result;

    move-result-object v2

    goto :goto_3

    :catchall_1
    move-exception v0

    goto :goto_4

    :cond_2
    move-object v2, v3

    :goto_3
    const-string v3, "White_points_inverted"

    invoke-virtual {v2}, Lcom/google/zxing/Result;->getResultPoints()[Lcom/google/zxing/ResultPoint;

    move-result-object v5

    const/4 v7, 0x0

    aget-object v5, v5, v7

    invoke-virtual {v5}, Lcom/google/zxing/ResultPoint;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-static {v3, v5}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_0
    .catchall {:try_start_1 .. :try_end_1} :catchall_1

    invoke-virtual {v4}, Lcom/google/zxing/MultiFormatReader;->reset()V

    goto :goto_5

    :catch_0
    :try_start_2
    const-string v2, "Exception - 1"

    invoke-static {v1, v2}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_2
    .catchall {:try_start_2 .. :try_end_2} :catchall_1

    goto :goto_7

    :goto_4
    invoke-virtual {v4}, Lcom/google/zxing/MultiFormatReader;->reset()V

    throw v0

    :cond_3
    :goto_5
    invoke-virtual {v2}, Lcom/google/zxing/Result;->getText()Ljava/lang/String;

    move-result-object v3

    if-eqz v3, :cond_4

    const-string v4, "decodeZxing - "

    invoke-virtual {v4, v3}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    invoke-static {v1, v3}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    :cond_4
    const-string v1, "decodeZxing - Completed"

    invoke-static {v6, v1}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    invoke-virtual {v2}, Lcom/google/zxing/Result;->getText()Ljava/lang/String;

    move-result-object v1

    :goto_6
    const/4 v7, 0x0

    goto :goto_9

    :catch_1
    :try_start_3
    const-string v2, "Exception - 0"

    invoke-static {v1, v2}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_3
    .catchall {:try_start_3 .. :try_end_3} :catchall_0

    :goto_7
    invoke-virtual {v4}, Lcom/google/zxing/MultiFormatReader;->reset()V

    const/4 v1, 0x0

    goto :goto_6

    :goto_8
    invoke-virtual {v4}, Lcom/google/zxing/MultiFormatReader;->reset()V

    throw v0

    :cond_5
    invoke-virtual/range {p7 .. p7}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Ljava/util/List;

    const/4 v7, 0x0

    invoke-interface {v1, v7}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/google/mlkit/vision/barcode/common/Barcode;

    invoke-virtual {v1}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getDisplayValue()Ljava/lang/String;

    move-result-object v1

    :goto_9
    new-instance v2, Ljava/lang/StringBuilder;

    const-string v3, "MLOutput After- "

    invoke-direct {v2, v3}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual/range {p7 .. p7}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/util/List;

    invoke-interface {v3, v7}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Lcom/google/mlkit/vision/barcode/common/Barcode;

    invoke-virtual {v3}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getDisplayValue()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v3, "  format: "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual/range {p7 .. p7}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/util/List;

    invoke-interface {v3, v7}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Lcom/google/mlkit/vision/barcode/common/Barcode;

    invoke-virtual {v3}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getFormat()I

    move-result v3

    invoke-static {v3}, Lcom/scanflow/datacapture/barinternal/M;->a(I)Lcom/scanflow/datacapture/utils/BarcodeFormat;

    move-result-object v3

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v3, " zxingOutput: "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v6, v2}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    if-eqz v1, :cond_7

    const-string v2, "zxingOutputBatch"

    invoke-static {v2, v1}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    invoke-virtual {v1}, Ljava/lang/String;->length()I

    move-result v2

    if-nez v2, :cond_6

    new-instance v1, Lcom/scanflow/datacapture/barinternal/C;

    const/4 v2, 0x0

    invoke-direct {v1, v2, v2, v2}, Lcom/scanflow/datacapture/barinternal/C;-><init>(Landroid/graphics/RectF;Lcom/google/mlkit/vision/barcode/common/Barcode;Ljava/lang/String;)V

    invoke-virtual {v0, v1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    goto :goto_a

    :cond_6
    new-instance v2, Lcom/scanflow/datacapture/barinternal/C;

    invoke-virtual/range {p1 .. p2}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Lcom/scanflow/datacapture/barinternal/B;

    .line 9
    iget-object v3, v3, Lcom/scanflow/datacapture/barinternal/B;->a:Landroid/graphics/RectF;

    .line 10
    invoke-virtual/range {p7 .. p7}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Ljava/util/List;

    const/4 v7, 0x0

    invoke-interface {v4, v7}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Lcom/google/mlkit/vision/barcode/common/Barcode;

    invoke-direct {v2, v3, v4, v1}, Lcom/scanflow/datacapture/barinternal/C;-><init>(Landroid/graphics/RectF;Lcom/google/mlkit/vision/barcode/common/Barcode;Ljava/lang/String;)V

    invoke-virtual {v0, v2}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    goto :goto_a

    :cond_7
    new-instance v1, Lcom/scanflow/datacapture/barinternal/C;

    const/4 v2, 0x0

    invoke-direct {v1, v2, v2, v2}, Lcom/scanflow/datacapture/barinternal/C;-><init>(Landroid/graphics/RectF;Lcom/google/mlkit/vision/barcode/common/Barcode;Ljava/lang/String;)V

    invoke-virtual {v0, v1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    goto :goto_a

    :cond_8
    new-instance v1, Lcom/scanflow/datacapture/barinternal/C;

    invoke-virtual/range {p1 .. p2}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/B;

    .line 11
    iget-object v2, v2, Lcom/scanflow/datacapture/barinternal/B;->a:Landroid/graphics/RectF;

    .line 12
    invoke-virtual/range {p7 .. p7}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/util/List;

    const/4 v7, 0x0

    invoke-interface {v3, v7}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Lcom/google/mlkit/vision/barcode/common/Barcode;

    const/4 v4, 0x0

    invoke-direct {v1, v2, v3, v4}, Lcom/scanflow/datacapture/barinternal/C;-><init>(Landroid/graphics/RectF;Lcom/google/mlkit/vision/barcode/common/Barcode;Ljava/lang/String;)V

    invoke-virtual {v0, v1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    goto :goto_a

    :cond_9
    const/4 v4, 0x0

    new-instance v1, Lcom/scanflow/datacapture/barinternal/C;

    invoke-virtual/range {p1 .. p2}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/B;

    .line 13
    iget-object v2, v2, Lcom/scanflow/datacapture/barinternal/B;->a:Landroid/graphics/RectF;

    .line 14
    invoke-direct {v1, v2, v4, v4}, Lcom/scanflow/datacapture/barinternal/C;-><init>(Landroid/graphics/RectF;Lcom/google/mlkit/vision/barcode/common/Barcode;Ljava/lang/String;)V

    invoke-virtual {v0, v1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    :cond_a
    :goto_a
    invoke-virtual {v0}, Ljava/util/ArrayList;->size()I

    move-result v1

    invoke-virtual/range {p1 .. p1}, Ljava/util/ArrayList;->size()I

    move-result v2

    if-ne v1, v2, :cond_b

    move-object/from16 v1, p3

    move-object/from16 v2, p4

    invoke-virtual {v1, v0, v2}, Lcom/scanflow/datacapture/barinternal/M;->a(Ljava/util/ArrayList;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;)V

    :cond_b
    return-void
.end method


# virtual methods
.method public final create(Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Lkotlin/coroutines/Continuation;
    .locals 4

    .line 1
    new-instance v0, Lcom/scanflow/datacapture/barinternal/K;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/K;->b:Ljava/util/ArrayList;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/K;->c:Lcom/scanflow/datacapture/barinternal/M;

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/K;->d:Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;

    invoke-direct {v0, v1, v2, v3, p2}, Lcom/scanflow/datacapture/barinternal/K;-><init>(Ljava/util/ArrayList;Lcom/scanflow/datacapture/barinternal/M;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;Lkotlin/coroutines/Continuation;)V

    iput-object p1, v0, Lcom/scanflow/datacapture/barinternal/K;->a:Ljava/lang/Object;

    return-object v0
.end method

.method public final invoke(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    check-cast p1, Lkotlinx/coroutines/CoroutineScope;

    check-cast p2, Lkotlin/coroutines/Continuation;

    .line 1
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/K;->create(Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Lkotlin/coroutines/Continuation;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/K;

    sget-object p2, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/K;->invokeSuspend(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method

.method public final invokeSuspend(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 11

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->getCOROUTINE_SUSPENDED()Ljava/lang/Object;

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/ResultKt;->throwOnFailure(Ljava/lang/Object;)V

    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/K;->a:Ljava/lang/Object;

    move-object v7, p1

    check-cast v7, Lkotlinx/coroutines/CoroutineScope;

    new-instance v1, Ljava/util/ArrayList;

    invoke-direct {v1}, Ljava/util/ArrayList;-><init>()V

    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/K;->b:Ljava/util/ArrayList;

    invoke-interface {p1}, Ljava/lang/Iterable;->iterator()Ljava/util/Iterator;

    move-result-object p1

    const/4 v8, 0x0

    move v3, v8

    :goto_0
    invoke-interface {p1}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_0

    add-int/lit8 v9, v3, 0x1

    invoke-interface {p1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    move-object v6, v0

    check-cast v6, Lcom/scanflow/datacapture/barinternal/B;

    .line 1
    iget-object v0, v6, Lcom/scanflow/datacapture/barinternal/B;->b:Landroid/graphics/Bitmap;

    .line 2
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/t;->a(Landroid/graphics/Bitmap;)Landroid/graphics/Bitmap;

    move-result-object v0

    invoke-static {v0, v8}, Lcom/google/mlkit/vision/common/InputImage;->fromBitmap(Landroid/graphics/Bitmap;I)Lcom/google/mlkit/vision/common/InputImage;

    move-result-object v0

    const-string v2, "fromBitmap(...)"

    invoke-static {v0, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v2, Landroid/graphics/Canvas;

    .line 3
    iget-object v4, v6, Lcom/scanflow/datacapture/barinternal/B;->b:Landroid/graphics/Bitmap;

    .line 4
    invoke-direct {v2, v4}, Landroid/graphics/Canvas;-><init>(Landroid/graphics/Bitmap;)V

    .line 5
    sget-object v2, Lcom/scanflow/datacapture/barinternal/l;->a:Lcom/google/mlkit/vision/barcode/BarcodeScanner;

    .line 6
    invoke-interface {v2, v0}, Lcom/google/mlkit/vision/barcode/BarcodeScanner;->process(Lcom/google/mlkit/vision/common/InputImage;)Lcom/google/android/gms/tasks/Task;

    move-result-object v10

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/K;->b:Ljava/util/ArrayList;

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/K;->c:Lcom/scanflow/datacapture/barinternal/M;

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/K;->d:Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;

    new-instance v0, Lcom/scanflow/datacapture/barinternal/K$$ExternalSyntheticLambda0;

    invoke-direct/range {v0 .. v7}, Lcom/scanflow/datacapture/barinternal/K$$ExternalSyntheticLambda0;-><init>(Ljava/util/ArrayList;Ljava/util/ArrayList;ILcom/scanflow/datacapture/barinternal/M;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;Lcom/scanflow/datacapture/barinternal/B;Lkotlinx/coroutines/CoroutineScope;)V

    invoke-virtual {v10, v0}, Lcom/google/android/gms/tasks/Task;->addOnCompleteListener(Lcom/google/android/gms/tasks/OnCompleteListener;)Lcom/google/android/gms/tasks/Task;

    move v3, v9

    goto :goto_0

    :cond_0
    return-object v1
.end method
