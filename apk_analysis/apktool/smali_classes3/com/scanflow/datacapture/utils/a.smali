.class public final Lcom/scanflow/datacapture/utils/a;
.super Ljava/lang/Object;
.source "SourceFile"


# direct methods
.method public static a(Landroidx/camera/core/ImageProxy;)Landroid/graphics/Bitmap;
    .locals 18

    const-string v0, "image"

    move-object/from16 v1, p0

    invoke-static {v1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v0, Lcom/scanflow/datacapture/utils/FrameMetadata$Builder;

    invoke-direct {v0}, Lcom/scanflow/datacapture/utils/FrameMetadata$Builder;-><init>()V

    invoke-interface {v1}, Landroidx/camera/core/ImageProxy;->getWidth()I

    move-result v2

    invoke-virtual {v0, v2}, Lcom/scanflow/datacapture/utils/FrameMetadata$Builder;->setWidth(I)Lcom/scanflow/datacapture/utils/FrameMetadata$Builder;

    move-result-object v0

    invoke-interface {v1}, Landroidx/camera/core/ImageProxy;->getHeight()I

    move-result v2

    invoke-virtual {v0, v2}, Lcom/scanflow/datacapture/utils/FrameMetadata$Builder;->setHeight(I)Lcom/scanflow/datacapture/utils/FrameMetadata$Builder;

    move-result-object v0

    invoke-virtual {v0}, Lcom/scanflow/datacapture/utils/FrameMetadata$Builder;->build()Lcom/scanflow/datacapture/utils/FrameMetadata;

    move-result-object v0

    const-string v2, "build(...)"

    invoke-static {v0, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-interface {v1}, Landroidx/camera/core/ImageProxy;->getPlanes()[Landroidx/camera/core/ImageProxy$PlaneProxy;

    move-result-object v2

    const-string v3, "getPlanes(...)"

    invoke-static {v2, v3}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-interface {v1}, Landroidx/camera/core/ImageProxy;->getWidth()I

    move-result v5

    invoke-interface {v1}, Landroidx/camera/core/ImageProxy;->getHeight()I

    move-result v6

    mul-int v1, v5, v6

    .line 1
    div-int/lit8 v3, v1, 0x4

    const/4 v10, 0x2

    mul-int/2addr v3, v10

    add-int/2addr v3, v1

    new-array v7, v3, [B

    const/4 v3, 0x1

    .line 2
    aget-object v4, v2, v3

    invoke-interface {v4}, Landroidx/camera/core/ImageProxy$PlaneProxy;->getBuffer()Ljava/nio/ByteBuffer;

    move-result-object v4

    const-string v8, "getBuffer(...)"

    invoke-static {v4, v8}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    aget-object v9, v2, v10

    invoke-interface {v9}, Landroidx/camera/core/ImageProxy$PlaneProxy;->getBuffer()Ljava/nio/ByteBuffer;

    move-result-object v9

    invoke-static {v9, v8}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {v9}, Ljava/nio/Buffer;->position()I

    move-result v11

    invoke-virtual {v4}, Ljava/nio/Buffer;->limit()I

    move-result v12

    add-int/lit8 v13, v11, 0x1

    invoke-virtual {v9, v13}, Ljava/nio/ByteBuffer;->position(I)Ljava/nio/Buffer;

    add-int/lit8 v13, v12, -0x1

    invoke-virtual {v4, v13}, Ljava/nio/ByteBuffer;->limit(I)Ljava/nio/Buffer;

    invoke-virtual {v9}, Ljava/nio/Buffer;->remaining()I

    move-result v13

    mul-int/lit8 v14, v1, 0x2

    div-int/lit8 v14, v14, 0x4

    add-int/lit8 v15, v14, -0x2

    move/from16 p0, v10

    const/4 v10, 0x0

    if-ne v13, v15, :cond_0

    invoke-virtual {v9, v4}, Ljava/nio/ByteBuffer;->compareTo(Ljava/nio/ByteBuffer;)I

    move-result v13

    if-nez v13, :cond_0

    move v13, v3

    goto :goto_0

    :cond_0
    move v13, v10

    :goto_0
    invoke-virtual {v9, v11}, Ljava/nio/ByteBuffer;->position(I)Ljava/nio/Buffer;

    invoke-virtual {v4, v12}, Ljava/nio/ByteBuffer;->limit(I)Ljava/nio/Buffer;

    if-eqz v13, :cond_1

    .line 3
    aget-object v4, v2, v10

    invoke-interface {v4}, Landroidx/camera/core/ImageProxy$PlaneProxy;->getBuffer()Ljava/nio/ByteBuffer;

    move-result-object v4

    invoke-virtual {v4, v7, v10, v1}, Ljava/nio/ByteBuffer;->get([BII)Ljava/nio/ByteBuffer;

    aget-object v4, v2, v3

    invoke-interface {v4}, Landroidx/camera/core/ImageProxy$PlaneProxy;->getBuffer()Ljava/nio/ByteBuffer;

    move-result-object v4

    invoke-static {v4, v8}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    aget-object v2, v2, p0

    invoke-interface {v2}, Landroidx/camera/core/ImageProxy$PlaneProxy;->getBuffer()Ljava/nio/ByteBuffer;

    move-result-object v2

    invoke-static {v2, v8}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {v2, v7, v1, v3}, Ljava/nio/ByteBuffer;->get([BII)Ljava/nio/ByteBuffer;

    add-int/2addr v1, v3

    sub-int/2addr v14, v3

    invoke-virtual {v4, v7, v1, v14}, Ljava/nio/ByteBuffer;->get([BII)Ljava/nio/ByteBuffer;

    goto :goto_1

    :cond_1
    aget-object v4, v2, v10

    const/4 v8, 0x0

    const/4 v9, 0x1

    invoke-static/range {v4 .. v9}, Lcom/scanflow/datacapture/utils/a;->a(Landroidx/camera/core/ImageProxy$PlaneProxy;II[BII)V

    aget-object v4, v2, v3

    add-int/lit8 v8, v1, 0x1

    const/4 v9, 0x2

    invoke-static/range {v4 .. v9}, Lcom/scanflow/datacapture/utils/a;->a(Landroidx/camera/core/ImageProxy$PlaneProxy;II[BII)V

    aget-object v4, v2, p0

    move v8, v1

    invoke-static/range {v4 .. v9}, Lcom/scanflow/datacapture/utils/a;->a(Landroidx/camera/core/ImageProxy$PlaneProxy;II[BII)V

    :goto_1
    invoke-static {v7}, Ljava/nio/ByteBuffer;->wrap([B)Ljava/nio/ByteBuffer;

    move-result-object v1

    const-string v2, "wrap(...)"

    invoke-static {v1, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    .line 4
    const-string v2, "data"

    invoke-static {v1, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v2, "metadata"

    invoke-static {v0, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {v1}, Ljava/nio/ByteBuffer;->rewind()Ljava/nio/Buffer;

    invoke-virtual {v1}, Ljava/nio/Buffer;->limit()I

    move-result v2

    new-array v4, v2, [B

    invoke-virtual {v1, v4, v10, v2}, Ljava/nio/ByteBuffer;->get([BII)Ljava/nio/ByteBuffer;

    :try_start_0
    new-instance v3, Landroid/graphics/YuvImage;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/utils/FrameMetadata;->getWidth()I

    move-result v6

    invoke-virtual {v0}, Lcom/scanflow/datacapture/utils/FrameMetadata;->getHeight()I

    move-result v7

    const/4 v8, 0x0

    const/16 v5, 0x11

    invoke-direct/range {v3 .. v8}, Landroid/graphics/YuvImage;-><init>([BIII[I)V

    new-instance v1, Ljava/io/ByteArrayOutputStream;

    invoke-direct {v1}, Ljava/io/ByteArrayOutputStream;-><init>()V

    new-instance v2, Landroid/graphics/Rect;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/utils/FrameMetadata;->getWidth()I

    move-result v4

    invoke-virtual {v0}, Lcom/scanflow/datacapture/utils/FrameMetadata;->getHeight()I

    move-result v5

    invoke-direct {v2, v10, v10, v4, v5}, Landroid/graphics/Rect;-><init>(IIII)V

    const/16 v4, 0x50

    invoke-virtual {v3, v2, v4, v1}, Landroid/graphics/YuvImage;->compressToJpeg(Landroid/graphics/Rect;ILjava/io/OutputStream;)Z

    invoke-virtual {v1}, Ljava/io/ByteArrayOutputStream;->toByteArray()[B

    move-result-object v2

    invoke-virtual {v1}, Ljava/io/ByteArrayOutputStream;->size()I

    move-result v3

    invoke-static {v2, v10, v3}, Landroid/graphics/BitmapFactory;->decodeByteArray([BII)Landroid/graphics/Bitmap;

    move-result-object v11

    invoke-virtual {v1}, Ljava/io/ByteArrayOutputStream;->close()V

    invoke-static {v11}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {v0}, Lcom/scanflow/datacapture/utils/FrameMetadata;->getRotation()I

    move-result v0

    .line 5
    const-string v1, "bitmap"

    invoke-static {v11, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v1, Landroid/graphics/Matrix;

    invoke-direct {v1}, Landroid/graphics/Matrix;-><init>()V

    int-to-float v0, v0

    invoke-virtual {v1, v0}, Landroid/graphics/Matrix;->postRotate(F)Z

    const/high16 v0, 0x3f800000    # 1.0f

    invoke-virtual {v1, v0, v0}, Landroid/graphics/Matrix;->postScale(FF)Z

    invoke-virtual {v11}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v14

    invoke-virtual {v11}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v15

    const/16 v17, 0x1

    const/4 v12, 0x0

    const/4 v13, 0x0

    move-object/from16 v16, v1

    invoke-static/range {v11 .. v17}, Landroid/graphics/Bitmap;->createBitmap(Landroid/graphics/Bitmap;IIIILandroid/graphics/Matrix;Z)Landroid/graphics/Bitmap;

    move-result-object v0

    const-string v1, "createBitmap(...)"

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-static {v0, v11}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_2

    invoke-virtual {v11}, Landroid/graphics/Bitmap;->recycle()V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    :cond_2
    return-object v0

    :catch_0
    move-exception v0

    .line 6
    new-instance v1, Ljava/lang/StringBuilder;

    const-string v2, "Error: "

    invoke-direct {v1, v2}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v0}, Ljava/lang/Throwable;->getMessage()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    const-string v1, "VisionProcessorBase"

    invoke-static {v1, v0}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    const/4 v0, 0x0

    return-object v0
.end method

.method public static a(Landroidx/camera/core/ImageProxy$PlaneProxy;II[BII)V
    .locals 7

    .line 7
    invoke-interface {p0}, Landroidx/camera/core/ImageProxy$PlaneProxy;->getBuffer()Ljava/nio/ByteBuffer;

    move-result-object v0

    const-string v1, "getBuffer(...)"

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {v0}, Ljava/nio/ByteBuffer;->rewind()Ljava/nio/Buffer;

    invoke-virtual {v0}, Ljava/nio/Buffer;->limit()I

    move-result v1

    invoke-interface {p0}, Landroidx/camera/core/ImageProxy$PlaneProxy;->getRowStride()I

    move-result v2

    add-int/2addr v2, v1

    add-int/lit8 v2, v2, -0x1

    invoke-interface {p0}, Landroidx/camera/core/ImageProxy$PlaneProxy;->getRowStride()I

    move-result v1

    div-int/2addr v2, v1

    if-nez v2, :cond_0

    goto :goto_2

    :cond_0
    div-int/2addr p2, v2

    div-int/2addr p1, p2

    const/4 p2, 0x0

    move v1, p2

    move v3, v1

    :goto_0
    if-ge v1, v2, :cond_2

    move v4, p2

    move v5, v3

    :goto_1
    if-ge v4, p1, :cond_1

    invoke-virtual {v0, v5}, Ljava/nio/ByteBuffer;->get(I)B

    move-result v6

    aput-byte v6, p3, p4

    add-int/2addr p4, p5

    invoke-interface {p0}, Landroidx/camera/core/ImageProxy$PlaneProxy;->getPixelStride()I

    move-result v6

    add-int/2addr v5, v6

    add-int/lit8 v4, v4, 0x1

    goto :goto_1

    :cond_1
    invoke-interface {p0}, Landroidx/camera/core/ImageProxy$PlaneProxy;->getRowStride()I

    move-result v4

    add-int/2addr v3, v4

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_2
    :goto_2
    return-void
.end method
