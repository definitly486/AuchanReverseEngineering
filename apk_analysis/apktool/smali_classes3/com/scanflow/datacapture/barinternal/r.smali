.class public abstract Lcom/scanflow/datacapture/barinternal/r;
.super Ljava/lang/Object;
.source "SourceFile"


# direct methods
.method public static a(Landroid/graphics/Bitmap;)Landroid/graphics/Bitmap;
    .locals 18

    move-object/from16 v0, p0

    .line 1
    const-string v1, "inputBitmap"

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v1, "applyDotMatrixArea - Started"

    const-string v2, "DotMatrixPreProcessing"

    invoke-static {v2, v1}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    new-instance v1, Lorg/opencv/core/Mat;

    invoke-direct {v1}, Lorg/opencv/core/Mat;-><init>()V

    invoke-static {v0, v1}, Lorg/opencv/android/Utils;->bitmapToMat(Landroid/graphics/Bitmap;Lorg/opencv/core/Mat;)V

    new-instance v0, Lorg/opencv/core/Mat;

    invoke-direct {v0}, Lorg/opencv/core/Mat;-><init>()V

    const/4 v3, 0x6

    invoke-static {v1, v0, v3}, Lorg/opencv/imgproc/Imgproc;->cvtColor(Lorg/opencv/core/Mat;Lorg/opencv/core/Mat;I)V

    new-instance v4, Lorg/opencv/core/Mat;

    invoke-direct {v4}, Lorg/opencv/core/Mat;-><init>()V

    new-instance v1, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;

    const-wide/high16 v10, 0x4014000000000000L    # 5.0

    invoke-direct {v1, v10, v11, v10, v11}, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;-><init>(DD)V

    const-wide/16 v5, 0x0

    invoke-static {v0, v4, v1, v5, v6}, Lorg/opencv/imgproc/Imgproc;->GaussianBlur(Lorg/opencv/core/Mat;Lorg/opencv/core/Mat;Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;D)V

    new-instance v5, Lorg/opencv/core/Mat;

    invoke-direct {v5}, Lorg/opencv/core/Mat;-><init>()V

    const-wide/high16 v6, 0x4049000000000000L    # 50.0

    const-wide v8, 0x4062c00000000000L    # 150.0

    invoke-static/range {v4 .. v9}, Lorg/opencv/imgproc/Imgproc;->Canny(Lorg/opencv/core/Mat;Lorg/opencv/core/Mat;DD)V

    new-instance v1, Ljava/util/ArrayList;

    invoke-direct {v1}, Ljava/util/ArrayList;-><init>()V

    new-instance v4, Lorg/opencv/core/Mat;

    invoke-direct {v4}, Lorg/opencv/core/Mat;-><init>()V

    const/4 v6, 0x2

    const/4 v7, 0x0

    invoke-static {v5, v1, v4, v7, v6}, Lorg/opencv/imgproc/Imgproc;->findContours(Lorg/opencv/core/Mat;Ljava/util/List;Lorg/opencv/core/Mat;II)V

    new-instance v4, Ljava/util/ArrayList;

    invoke-direct {v4}, Ljava/util/ArrayList;-><init>()V

    invoke-virtual {v1}, Ljava/util/ArrayList;->size()I

    move-result v5

    move v6, v7

    :cond_0
    :goto_0
    if-ge v6, v5, :cond_1

    invoke-virtual {v1, v6}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v8

    add-int/lit8 v6, v6, 0x1

    move-object v9, v8

    check-cast v9, Lcom/scanflow/datacapture/barinternal/org/opencv/core/MatOfPoint;

    invoke-static {v9}, Lorg/opencv/imgproc/Imgproc;->contourArea(Lorg/opencv/core/Mat;)D

    move-result-wide v12

    cmpl-double v9, v12, v10

    if-lez v9, :cond_0

    invoke-virtual {v4, v8}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    goto :goto_0

    :cond_1
    invoke-virtual {v0}, Lorg/opencv/core/Mat;->size()Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;

    move-result-object v1

    sget v5, Lcom/scanflow/datacapture/barinternal/org/opencv/core/CvType;->CV_8UC3:I

    invoke-static {v1, v5}, Lorg/opencv/core/Mat;->zeros(Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;I)Lorg/opencv/core/Mat;

    move-result-object v1

    new-instance v8, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Scalar;

    const-wide v11, 0x406fe00000000000L    # 255.0

    const-wide v13, 0x406fe00000000000L    # 255.0

    const-wide v9, 0x406fe00000000000L    # 255.0

    invoke-direct/range {v8 .. v14}, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Scalar;-><init>(DDD)V

    const/4 v5, -0x1

    const/4 v6, 0x7

    invoke-static {v1, v4, v5, v8, v6}, Lorg/opencv/imgproc/Imgproc;->drawContours(Lorg/opencv/core/Mat;Ljava/util/List;ILcom/scanflow/datacapture/barinternal/org/opencv/core/Scalar;I)V

    new-instance v9, Lorg/opencv/core/Mat;

    invoke-direct {v9}, Lorg/opencv/core/Mat;-><init>()V

    invoke-static {v1, v9, v3}, Lorg/opencv/imgproc/Imgproc;->cvtColor(Lorg/opencv/core/Mat;Lorg/opencv/core/Mat;I)V

    new-instance v10, Lorg/opencv/core/Mat;

    invoke-direct {v10}, Lorg/opencv/core/Mat;-><init>()V

    const/4 v15, 0x0

    const-wide/high16 v11, 0x4060000000000000L    # 128.0

    invoke-static/range {v9 .. v15}, Lorg/opencv/imgproc/Imgproc;->threshold(Lorg/opencv/core/Mat;Lorg/opencv/core/Mat;DDI)D

    new-instance v11, Lorg/opencv/core/Mat;

    invoke-direct {v11}, Lorg/opencv/core/Mat;-><init>()V

    invoke-static {v10, v11}, Lorg/opencv/core/Core;->bitwise_not(Lorg/opencv/core/Mat;Lorg/opencv/core/Mat;)V

    new-instance v13, Lorg/opencv/core/Mat;

    invoke-direct {v13}, Lorg/opencv/core/Mat;-><init>()V

    new-instance v16, Lorg/opencv/core/Mat;

    invoke-direct/range {v16 .. v16}, Lorg/opencv/core/Mat;-><init>()V

    new-instance v14, Lorg/opencv/core/Mat;

    invoke-direct {v14}, Lorg/opencv/core/Mat;-><init>()V

    const/16 v15, 0x8

    move-object/from16 v12, v16

    const/16 v16, 0x4

    invoke-static/range {v11 .. v16}, Lorg/opencv/imgproc/Imgproc;->connectedComponentsWithStats(Lorg/opencv/core/Mat;Lorg/opencv/core/Mat;Lorg/opencv/core/Mat;Lorg/opencv/core/Mat;II)I

    move-result v1

    move-object/from16 v17, v11

    move-object v3, v13

    invoke-virtual {v0}, Lorg/opencv/core/Mat;->rows()I

    move-result v4

    invoke-virtual {v0}, Lorg/opencv/core/Mat;->cols()I

    move-result v13

    const/4 v0, 0x1

    move v14, v0

    :goto_1
    if-ge v14, v1, :cond_3

    const/4 v5, 0x4

    invoke-virtual {v3, v14, v5}, Lorg/opencv/core/Mat;->get(II)[D

    move-result-object v5

    aget-wide v8, v5, v7

    const-wide/high16 v5, 0x4024000000000000L    # 10.0

    cmpg-double v5, v8, v5

    if-gez v5, :cond_2

    new-instance v11, Lcom/scanflow/datacapture/barinternal/o;

    const/4 v15, 0x0

    move-object/from16 v16, v12

    move v12, v4

    invoke-direct/range {v11 .. v17}, Lcom/scanflow/datacapture/barinternal/o;-><init>(IIILkotlin/coroutines/Continuation;Lorg/opencv/core/Mat;Lorg/opencv/core/Mat;)V

    move-object v5, v11

    move-object/from16 v12, v16

    move-object/from16 v11, v17

    const/4 v6, 0x0

    invoke-static {v6, v5, v0, v6}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/BuildersKt;->runBlocking$default(Lkotlin/coroutines/CoroutineContext;Lkotlin/jvm/functions/Function2;ILjava/lang/Object;)Ljava/lang/Object;

    goto :goto_2

    :cond_2
    move-object/from16 v11, v17

    :goto_2
    add-int/lit8 v14, v14, 0x1

    move-object/from16 v17, v11

    goto :goto_1

    :cond_3
    move-object/from16 v11, v17

    invoke-virtual {v11}, Lorg/opencv/core/Mat;->size()Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;

    move-result-object v0

    iget-wide v0, v0, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;->width:D

    double-to-int v0, v0

    invoke-virtual {v11}, Lorg/opencv/core/Mat;->size()Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;

    move-result-object v1

    iget-wide v3, v1, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;->height:D

    double-to-int v1, v3

    sget-object v3, Landroid/graphics/Bitmap$Config;->ARGB_8888:Landroid/graphics/Bitmap$Config;

    invoke-static {v0, v1, v3}, Landroid/graphics/Bitmap;->createBitmap(IILandroid/graphics/Bitmap$Config;)Landroid/graphics/Bitmap;

    move-result-object v0

    const-string v1, "createBitmap(...)"

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-static {v11, v0}, Lorg/opencv/android/Utils;->matToBitmap(Lorg/opencv/core/Mat;Landroid/graphics/Bitmap;)V

    const-string v1, "applyDotMatrixArea - Completed"

    invoke-static {v2, v1}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    return-object v0
.end method

.method public static b(Landroid/graphics/Bitmap;)Landroid/graphics/Bitmap;
    .locals 17

    move-object/from16 v0, p0

    .line 1
    const-string v1, "inputBitmap"

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v1, "applyDotMatrixArea - Started"

    const-string v2, "DotMatrixPreProcessing"

    invoke-static {v2, v1}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    new-instance v1, Lorg/opencv/core/Mat;

    invoke-direct {v1}, Lorg/opencv/core/Mat;-><init>()V

    invoke-static {v0, v1}, Lorg/opencv/android/Utils;->bitmapToMat(Landroid/graphics/Bitmap;Lorg/opencv/core/Mat;)V

    new-instance v0, Lorg/opencv/core/Mat;

    invoke-direct {v0}, Lorg/opencv/core/Mat;-><init>()V

    const/16 v3, 0xb

    invoke-static {v1, v0, v3}, Lorg/opencv/imgproc/Imgproc;->cvtColor(Lorg/opencv/core/Mat;Lorg/opencv/core/Mat;I)V

    new-instance v4, Lorg/opencv/core/Mat;

    invoke-direct {v4}, Lorg/opencv/core/Mat;-><init>()V

    new-instance v3, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;

    const-wide/high16 v5, 0x4014000000000000L    # 5.0

    invoke-direct {v3, v5, v6, v5, v6}, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;-><init>(DD)V

    const-wide/16 v10, 0x0

    invoke-static {v0, v4, v3, v10, v11}, Lorg/opencv/imgproc/Imgproc;->GaussianBlur(Lorg/opencv/core/Mat;Lorg/opencv/core/Mat;Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;D)V

    new-instance v5, Lorg/opencv/core/Mat;

    invoke-direct {v5}, Lorg/opencv/core/Mat;-><init>()V

    const-wide/16 v6, 0x0

    const-wide/high16 v8, 0x4049000000000000L    # 50.0

    invoke-static/range {v4 .. v9}, Lorg/opencv/imgproc/Imgproc;->Canny(Lorg/opencv/core/Mat;Lorg/opencv/core/Mat;DD)V

    new-instance v3, Ljava/util/ArrayList;

    invoke-direct {v3}, Ljava/util/ArrayList;-><init>()V

    new-instance v4, Lorg/opencv/core/Mat;

    invoke-direct {v4}, Lorg/opencv/core/Mat;-><init>()V

    const/4 v6, 0x0

    const/4 v7, 0x2

    invoke-static {v5, v3, v4, v6, v7}, Lorg/opencv/imgproc/Imgproc;->findContours(Lorg/opencv/core/Mat;Ljava/util/List;Lorg/opencv/core/Mat;II)V

    new-instance v4, Ljava/util/ArrayList;

    invoke-direct {v4}, Ljava/util/ArrayList;-><init>()V

    invoke-virtual {v3}, Ljava/util/ArrayList;->size()I

    move-result v5

    move v8, v6

    :cond_0
    :goto_0
    if-ge v8, v5, :cond_1

    invoke-virtual {v3, v8}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v9

    add-int/lit8 v8, v8, 0x1

    move-object v12, v9

    check-cast v12, Lcom/scanflow/datacapture/barinternal/org/opencv/core/MatOfPoint;

    invoke-static {v12}, Lorg/opencv/imgproc/Imgproc;->contourArea(Lorg/opencv/core/Mat;)D

    move-result-wide v12

    cmpl-double v12, v12, v10

    if-lez v12, :cond_0

    invoke-virtual {v4, v9}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    goto :goto_0

    :cond_1
    invoke-virtual {v1}, Lorg/opencv/core/Mat;->size()Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;

    move-result-object v1

    sget v3, Lcom/scanflow/datacapture/barinternal/org/opencv/core/CvType;->CV_8UC1:I

    invoke-static {v1, v3}, Lorg/opencv/core/Mat;->zeros(Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;I)Lorg/opencv/core/Mat;

    move-result-object v8

    new-instance v1, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Scalar;

    const-wide v9, 0x406fe00000000000L    # 255.0

    invoke-direct {v1, v9, v10}, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Scalar;-><init>(D)V

    const/4 v3, -0x1

    invoke-static {v8, v4, v3, v1, v7}, Lorg/opencv/imgproc/Imgproc;->drawContours(Lorg/opencv/core/Mat;Ljava/util/List;ILcom/scanflow/datacapture/barinternal/org/opencv/core/Scalar;I)V

    new-instance v9, Lorg/opencv/core/Mat;

    invoke-direct {v9}, Lorg/opencv/core/Mat;-><init>()V

    const-wide v12, 0x406fe00000000000L    # 255.0

    const/4 v14, 0x0

    const-wide/high16 v10, 0x4060000000000000L    # 128.0

    invoke-static/range {v8 .. v14}, Lorg/opencv/imgproc/Imgproc;->threshold(Lorg/opencv/core/Mat;Lorg/opencv/core/Mat;DDI)D

    new-instance v1, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;

    const-wide/high16 v3, 0x3ff0000000000000L    # 1.0

    invoke-direct {v1, v3, v4, v3, v4}, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;-><init>(DD)V

    invoke-static {v6, v1}, Lorg/opencv/imgproc/Imgproc;->getStructuringElement(ILcom/scanflow/datacapture/barinternal/org/opencv/core/Size;)Lorg/opencv/core/Mat;

    move-result-object v1

    new-instance v3, Lorg/opencv/core/Mat;

    invoke-direct {v3}, Lorg/opencv/core/Mat;-><init>()V

    new-instance v4, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Point;

    const-wide/high16 v7, -0x4010000000000000L    # -1.0

    invoke-direct {v4, v7, v8, v7, v8}, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Point;-><init>(DD)V

    const/4 v5, 0x1

    invoke-static {v9, v3, v1, v4, v5}, Lorg/opencv/imgproc/Imgproc;->dilate(Lorg/opencv/core/Mat;Lorg/opencv/core/Mat;Lorg/opencv/core/Mat;Lcom/scanflow/datacapture/barinternal/org/opencv/core/Point;I)V

    new-instance v10, Lorg/opencv/core/Mat;

    invoke-direct {v10}, Lorg/opencv/core/Mat;-><init>()V

    invoke-static {v3, v10}, Lorg/opencv/core/Core;->bitwise_not(Lorg/opencv/core/Mat;Lorg/opencv/core/Mat;)V

    new-instance v15, Lorg/opencv/core/Mat;

    invoke-direct {v15}, Lorg/opencv/core/Mat;-><init>()V

    new-instance v12, Lorg/opencv/core/Mat;

    invoke-direct {v12}, Lorg/opencv/core/Mat;-><init>()V

    new-instance v13, Lorg/opencv/core/Mat;

    invoke-direct {v13}, Lorg/opencv/core/Mat;-><init>()V

    const/16 v14, 0x8

    move-object v11, v15

    const/4 v15, 0x4

    invoke-static/range {v10 .. v15}, Lorg/opencv/imgproc/Imgproc;->connectedComponentsWithStats(Lorg/opencv/core/Mat;Lorg/opencv/core/Mat;Lorg/opencv/core/Mat;Lorg/opencv/core/Mat;II)I

    move-result v1

    move-object/from16 v16, v10

    move-object v3, v12

    invoke-virtual {v0}, Lorg/opencv/core/Mat;->rows()I

    move-result v4

    invoke-virtual {v0}, Lorg/opencv/core/Mat;->cols()I

    move-result v12

    move v13, v5

    :goto_1
    if-ge v13, v1, :cond_3

    const/4 v0, 0x4

    invoke-virtual {v3, v13, v0}, Lorg/opencv/core/Mat;->get(II)[D

    move-result-object v0

    aget-wide v7, v0, v6

    const-wide v9, 0x4097700000000000L    # 1500.0

    cmpg-double v0, v7, v9

    if-gez v0, :cond_2

    new-instance v10, Lcom/scanflow/datacapture/barinternal/q;

    const/4 v14, 0x0

    move-object v15, v11

    move v11, v4

    invoke-direct/range {v10 .. v16}, Lcom/scanflow/datacapture/barinternal/q;-><init>(IIILkotlin/coroutines/Continuation;Lorg/opencv/core/Mat;Lorg/opencv/core/Mat;)V

    move-object v4, v10

    move v0, v11

    move-object v11, v15

    move-object/from16 v10, v16

    const/4 v7, 0x0

    invoke-static {v7, v4, v5, v7}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/BuildersKt;->runBlocking$default(Lkotlin/coroutines/CoroutineContext;Lkotlin/jvm/functions/Function2;ILjava/lang/Object;)Ljava/lang/Object;

    goto :goto_2

    :cond_2
    move v0, v4

    move-object/from16 v10, v16

    :goto_2
    add-int/lit8 v13, v13, 0x1

    move v4, v0

    move-object/from16 v16, v10

    goto :goto_1

    :cond_3
    move-object/from16 v10, v16

    invoke-virtual {v10}, Lorg/opencv/core/Mat;->size()Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;

    move-result-object v0

    iget-wide v0, v0, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;->width:D

    double-to-int v0, v0

    invoke-virtual {v10}, Lorg/opencv/core/Mat;->size()Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;

    move-result-object v1

    iget-wide v3, v1, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;->height:D

    double-to-int v1, v3

    sget-object v3, Landroid/graphics/Bitmap$Config;->ARGB_8888:Landroid/graphics/Bitmap$Config;

    invoke-static {v0, v1, v3}, Landroid/graphics/Bitmap;->createBitmap(IILandroid/graphics/Bitmap$Config;)Landroid/graphics/Bitmap;

    move-result-object v0

    const-string v1, "createBitmap(...)"

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-static {v10, v0}, Lorg/opencv/android/Utils;->matToBitmap(Lorg/opencv/core/Mat;Landroid/graphics/Bitmap;)V

    const-string v1, "applyDotMatrixArea - Completed"

    invoke-static {v2, v1}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    return-object v0
.end method
