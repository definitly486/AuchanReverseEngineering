.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;
.super Ljava/lang/Object;
.source "QrCodeDecoderImage.java"


# instance fields
.field alignmentLocator:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeAlignmentPatternLocator;

.field bits:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;

.field public considerTransposed:Z

.field decoder:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;

.field failures:Ljava/util/List;

.field grid:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

.field gridReader:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;

.field intensityBits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;

.field storageQR:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

.field successes:Ljava/util/List;

.field tempTranspose:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;


# direct methods
.method public constructor <init>(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Class;)V
    .locals 3

    .line 76
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const/4 v0, 0x1

    .line 50
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->considerTransposed:Z

    .line 52
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage$$ExternalSyntheticLambda0;

    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage$$ExternalSyntheticLambda0;-><init>()V

    new-instance v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage$$ExternalSyntheticLambda1;

    invoke-direct {v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage$$ExternalSyntheticLambda1;-><init>()V

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;-><init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/Factory;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DProcess;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->storageQR:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 55
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->successes:Ljava/util/List;

    .line 58
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->failures:Ljava/util/List;

    .line 61
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->bits:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;

    .line 64
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->grid:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    .line 65
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->tempTranspose:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    .line 71
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->intensityBits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;

    .line 77
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;

    invoke-direct {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->decoder:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;

    .line 78
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;

    invoke-direct {p1, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;-><init>(Ljava/lang/Class;)V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->gridReader:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;

    .line 79
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeAlignmentPatternLocator;

    invoke-direct {p1, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeAlignmentPatternLocator;-><init>(Ljava/lang/Class;)V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->alignmentLocator:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeAlignmentPatternLocator;

    return-void
.end method

.method private bitIntensityToBitValue(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;Ljava/util/List;)V
    .locals 20

    move-object/from16 v0, p0

    move-object/from16 v1, p1

    .line 435
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->getNumberOfModules()I

    move-result v2

    int-to-float v2, v2

    const/high16 v3, 0x3f800000    # 1.0f

    sub-float/2addr v2, v3

    .line 436
    iget-wide v4, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->threshCorner:D

    double-to-float v4, v4

    .line 437
    iget-wide v5, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->threshRight:D

    double-to-float v5, v5

    .line 438
    iget-wide v6, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->threshDown:D

    double-to-float v6, v6

    .line 439
    iget-wide v7, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->threshDownRight:D

    double-to-float v7, v7

    const/4 v8, 0x0

    move v9, v8

    .line 441
    :goto_0
    iget-object v10, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->intensityBits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;

    iget v10, v10, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;->size:I

    if-ge v9, v10, :cond_6

    .line 442
    div-int/lit8 v10, v9, 0x5

    move-object/from16 v11, p2

    .line 444
    invoke-interface {v11, v10}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v12

    check-cast v12, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 446
    iget v13, v12, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    int-to-float v14, v13

    div-float/2addr v14, v2

    .line 447
    iget v12, v12, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    int-to-float v15, v12

    div-float/2addr v15, v2

    sub-float v16, v3, v14

    sub-float v17, v3, v15

    mul-float v18, v16, v17

    mul-float v18, v18, v4

    const/16 v19, 0x0

    add-float v18, v18, v19

    mul-float v17, v17, v14

    mul-float v17, v17, v5

    add-float v18, v18, v17

    mul-float/2addr v14, v15

    mul-float/2addr v14, v7

    add-float v18, v18, v14

    mul-float v16, v16, v15

    mul-float v16, v16, v6

    add-float v18, v18, v16

    .line 457
    iget-object v14, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->intensityBits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;

    iget-object v14, v14, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;->data:[F

    add-int/lit8 v15, v9, 0x1

    aget v16, v14, v9

    cmpg-float v16, v16, v18

    const/16 v17, 0x1

    if-gez v16, :cond_0

    move/from16 v16, v17

    goto :goto_1

    :cond_0
    move/from16 v16, v8

    :goto_1
    add-int/lit8 v19, v9, 0x2

    .line 458
    aget v15, v14, v15

    cmpg-float v15, v15, v18

    if-gez v15, :cond_1

    move/from16 v15, v17

    goto :goto_2

    :cond_1
    move v15, v8

    :goto_2
    add-int v16, v16, v15

    add-int/lit8 v15, v9, 0x3

    .line 459
    aget v19, v14, v19

    cmpg-float v19, v19, v18

    if-gez v19, :cond_2

    move/from16 v19, v17

    goto :goto_3

    :cond_2
    move/from16 v19, v8

    :goto_3
    add-int v16, v16, v19

    add-int/lit8 v19, v9, 0x4

    .line 460
    aget v15, v14, v15

    cmpg-float v15, v15, v18

    if-gez v15, :cond_3

    move/from16 v15, v17

    goto :goto_4

    :cond_3
    move v15, v8

    :goto_4
    add-int v16, v16, v15

    add-int/lit8 v9, v9, 0x5

    .line 461
    aget v14, v14, v19

    cmpg-float v14, v14, v18

    if-gez v14, :cond_4

    move/from16 v14, v17

    goto :goto_5

    :cond_4
    move v14, v8

    :goto_5
    add-int v14, v16, v14

    const/4 v15, 0x3

    if-lt v14, v15, :cond_5

    move/from16 v14, v17

    goto :goto_6

    :cond_5
    move v14, v8

    .line 465
    :goto_6
    iget-object v15, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->bits:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;

    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->mask:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeMaskPattern;

    invoke-virtual {v3, v12, v13, v14}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeMaskPattern;->apply(III)I

    move-result v3

    invoke-virtual {v15, v10, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->set(II)V

    const/high16 v3, 0x3f800000    # 1.0f

    goto/16 :goto_0

    :cond_6
    return-void
.end method

.method static computeBoundingBox(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)V
    .locals 7

    .line 210
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->bounds:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    const/4 v1, 0x0

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v0

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppCorner:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v2, v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v1

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    .line 211
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->bounds:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    const/4 v1, 0x1

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v0

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppRight:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v2, v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v2

    invoke-virtual {v0, v2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    .line 212
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppRight:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    .line 213
    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v0

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppRight:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    const/4 v2, 0x2

    invoke-virtual {v1, v2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v1

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppDown:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    const/4 v4, 0x3

    .line 214
    invoke-virtual {v3, v4}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v3

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppDown:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v5, v2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v5

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->bounds:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v6, v2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v2

    .line 212
    invoke-static {v0, v1, v3, v5, v2}, Lcom/scanflow/datacapture/barinternal/georegression/metric/Intersection2D_F64;->intersection(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    .line 215
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->bounds:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v0, v4}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v0

    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppDown:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {p0, v4}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object p0

    invoke-virtual {v0, p0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    return-void
.end method

.method private decode(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)Z
    .locals 2

    .line 227
    invoke-direct {p0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->extractFormatInfo(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)Z

    move-result v0

    const/4 v1, 0x0

    if-nez v0, :cond_0

    .line 228
    sget-object p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->FORMAT:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    iput-object p1, p2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->failureCause:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    return v1

    .line 231
    :cond_0
    invoke-virtual {p0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->extractVersionInfo(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)Z

    move-result v0

    if-nez v0, :cond_1

    .line 232
    sget-object p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->VERSION:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    iput-object p1, p2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->failureCause:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    return v1

    .line 235
    :cond_1
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->alignmentLocator:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeAlignmentPatternLocator;

    invoke-virtual {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeAlignmentPatternLocator;->process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)Z

    move-result p1

    if-nez p1, :cond_2

    .line 236
    sget-object p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->ALIGNMENT:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    iput-object p1, p2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->failureCause:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    return v1

    .line 243
    :cond_2
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->gridReader:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;

    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->setMarker(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)V

    .line 244
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->gridReader:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->getTransformGrid()Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;

    move-result-object p1

    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->addAllFeatures(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)V

    move p1, v1

    :goto_0
    const/4 v0, 0x6

    if-ge p1, v0, :cond_6

    if-lez p1, :cond_3

    .line 248
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->gridReader:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->getTransformGrid()Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;

    move-result-object v0

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->removeFeatureWithLargestError()Z

    move-result v0

    if-nez v0, :cond_3

    goto :goto_2

    .line 254
    :cond_3
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->gridReader:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->getTransformGrid()Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;

    move-result-object v0

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->computeTransform()V

    .line 255
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->NONE:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    iput-object v0, p2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->failureCause:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    .line 256
    invoke-direct {p0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->readRawData(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)Z

    move-result v0

    if-nez v0, :cond_4

    .line 257
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->READING_BITS:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    iput-object v0, p2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->failureCause:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    goto :goto_1

    .line 261
    :cond_4
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->decoder:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;

    invoke-virtual {v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->applyErrorCorrection(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)Z

    move-result v0

    if-nez v0, :cond_5

    .line 262
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->ERROR_CORRECTION:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    iput-object v0, p2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->failureCause:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    :goto_1
    add-int/lit8 p1, p1, 0x1

    goto :goto_0

    :cond_5
    const/4 v1, 0x1

    :cond_6
    :goto_2
    if-eqz v1, :cond_7

    .line 273
    sget-object p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->NONE:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    iput-object p1, p2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->failureCause:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    .line 277
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->decoder:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;

    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->decodeMessage(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)Z

    .line 282
    :cond_7
    iget-object p1, p2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->Hinv:Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;

    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->gridReader:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;

    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->getTransformGrid()Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;

    move-result-object p2

    iget-object p2, p2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridToPixel;->Hinv:Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;

    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;

    return v1
.end method

.method private extractFormatInfo(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)Z
    .locals 4

    const/4 v0, 0x0

    move v1, v0

    :goto_0
    const/4 v2, 0x2

    if-ge v1, v2, :cond_3

    if-nez v1, :cond_0

    .line 296
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->readFormatRegion0(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)Z

    goto :goto_1

    .line 298
    :cond_0
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->readFormatRegion1(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)Z

    .line 299
    :goto_1
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->bits:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;

    const/16 v3, 0xf

    invoke-virtual {v2, v0, v3, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->read(IIZ)I

    move-result v2

    xor-int/lit16 v2, v2, 0x5412

    .line 303
    invoke-static {v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePolynomialMath;->checkFormatBits(I)Z

    move-result v3

    if-eqz v3, :cond_1

    shr-int/lit8 v2, v2, 0xa

    goto :goto_2

    .line 306
    :cond_1
    invoke-static {v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePolynomialMath;->correctFormatBits(I)I

    move-result v2

    :goto_2
    if-ltz v2, :cond_2

    .line 309
    invoke-static {v2, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePolynomialMath;->decodeFormatMessage(ILcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)V

    const/4 p1, 0x1

    return p1

    :cond_2
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_3
    return v0
.end method

.method private read(III)V
    .locals 1

    .line 477
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->gridReader:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;

    invoke-virtual {v0, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->readBit(II)I

    move-result p2

    const/4 p3, -0x1

    if-ne p2, p3, :cond_0

    const/4 p2, 0x0

    .line 483
    :cond_0
    iget-object p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->bits:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;

    invoke-virtual {p3, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->set(II)V

    return-void
.end method

.method private readBitIntensityAndThresholdDownRight(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;Ljava/util/List;)F
    .locals 8

    .line 398
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->getNumberOfModules()I

    move-result p1

    .line 399
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->intensityBits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;

    invoke-interface {p2}, Ljava/util/List;->size()I

    move-result v1

    mul-int/lit8 v1, v1, 0x5

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;->reserve(I)V

    .line 400
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->intensityBits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;

    add-int/lit8 p1, p1, -0xa

    const/16 v0, 0x8

    .line 403
    invoke-static {v0, p1}, Ljava/lang/Math;->max(II)I

    move-result p1

    const/4 v0, 0x0

    const/4 v1, 0x0

    move v2, v1

    .line 411
    :goto_0
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->bits:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;

    iget v3, v3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->size:I

    if-ge v1, v3, :cond_2

    .line 412
    invoke-interface {p2, v1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    .line 413
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->gridReader:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;

    iget v5, v3, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    iget v6, v3, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->intensityBits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;

    invoke-virtual {v4, v5, v6, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->readBitIntensity(IILcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;)V

    .line 416
    iget v4, v3, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->x:I

    if-ge v4, p1, :cond_0

    iget v3, v3, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->y:I

    if-ge v3, p1, :cond_0

    goto :goto_2

    :cond_0
    add-int/lit8 v2, v2, 0x5

    .line 420
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->intensityBits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;

    iget v3, v3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;->size:I

    add-int/lit8 v3, v3, -0x5

    :goto_1
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->intensityBits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;

    iget v5, v4, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;->size:I

    if-ge v3, v5, :cond_1

    .line 421
    iget-object v4, v4, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;->data:[F

    aget v4, v4, v3

    add-float/2addr v0, v4

    add-int/lit8 v3, v3, 0x1

    goto :goto_1

    :cond_1
    :goto_2
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_2
    int-to-float p1, v2

    div-float/2addr v0, p1

    return v0
.end method

.method private readRawData(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)Z
    .locals 3

    .line 366
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->VERSION_INFO:[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->version:I

    aget-object v0, v0, v1

    .line 368
    iget v0, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->codewords:I

    new-array v1, v0, [B

    iput-object v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->rawbits:[B

    .line 371
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->bits:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;

    mul-int/lit8 v0, v0, 0x8

    invoke-virtual {v1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->resize(I)V

    .line 374
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->LOCATION_BITS:[Ljava/util/List;

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->version:I

    aget-object v0, v0, v1

    .line 378
    invoke-direct {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->readBitIntensityAndThresholdDownRight(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;Ljava/util/List;)F

    move-result v1

    float-to-double v1, v1

    iput-wide v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->threshDownRight:D

    .line 381
    invoke-direct {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->bitIntensityToBitValue(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;Ljava/util/List;)V

    .line 384
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->bits:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->data:[B

    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->rawbits:[B

    array-length v1, p1

    const/4 v2, 0x0

    invoke-static {v0, v2, p1, v2, v1}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    const/4 p1, 0x1

    return p1
.end method

.method private readVersionRegion0(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)Z
    .locals 4

    .line 591
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->gridReader:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;

    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppRight:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    iget-wide v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->threshRight:D

    double-to-float p1, v2

    invoke-virtual {v0, v1, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->setSquare(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;F)V

    .line 593
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->bits:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;

    const/16 v0, 0x12

    invoke-virtual {p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->resize(I)V

    .line 594
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->bits:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->zero()V

    const/4 p1, 0x0

    :goto_0
    if-ge p1, v0, :cond_0

    .line 596
    div-int/lit8 v1, p1, 0x3

    .line 597
    rem-int/lit8 v2, p1, 0x3

    add-int/lit8 v2, v2, -0x4

    .line 598
    invoke-direct {p0, p1, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->read(III)V

    add-int/lit8 p1, p1, 0x1

    goto :goto_0

    :cond_0
    const/4 p1, 0x1

    return p1
.end method

.method private readVersionRegion1(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)Z
    .locals 4

    .line 611
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->gridReader:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;

    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppDown:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    iget-wide v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->threshDown:D

    double-to-float p1, v2

    invoke-virtual {v0, v1, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->setSquare(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;F)V

    .line 613
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->bits:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;

    const/16 v0, 0x12

    invoke-virtual {p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->resize(I)V

    .line 614
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->bits:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->zero()V

    const/4 p1, 0x0

    :goto_0
    if-ge p1, v0, :cond_0

    .line 616
    rem-int/lit8 v1, p1, 0x3

    .line 617
    div-int/lit8 v2, p1, 0x3

    add-int/lit8 v1, v1, -0x4

    .line 618
    invoke-direct {p0, p1, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->read(III)V

    add-int/lit8 p1, p1, 0x1

    goto :goto_0

    :cond_0
    const/4 p1, 0x1

    return p1
.end method

.method static rotateUntilAt(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;II)V
    .locals 0

    :goto_0
    if-eq p1, p2, :cond_0

    .line 200
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/georegression/geometry/UtilPolygons2D_F64;->shiftDown(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;)V

    add-int/lit8 p1, p1, 0x1

    .line 201
    rem-int/lit8 p1, p1, 0x4

    goto :goto_0

    :cond_0
    return-void
.end method

.method static setPositionPatterns(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PositionPatternNode;IILcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)V
    .locals 3

    .line 179
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->edges:[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;

    aget-object v0, v0, p1

    invoke-virtual {v0, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;->destination(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;)Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PositionPatternNode;

    .line 180
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->edges:[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;

    aget-object p2, v1, p2

    invoke-virtual {p2, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;->destination(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;)Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;

    move-result-object p2

    check-cast p2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PositionPatternNode;

    .line 181
    iget-object v1, p3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppRight:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->square:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v1, v2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    .line 182
    iget-object v1, p3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppCorner:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->square:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v1, v2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    .line 183
    iget-object v1, p3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppDown:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    iget-object v2, p2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->square:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v1, v2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    .line 185
    iget-wide v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PositionPatternNode;->grayThreshold:D

    iput-wide v1, p3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->threshRight:D

    .line 186
    iget-wide v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PositionPatternNode;->grayThreshold:D

    iput-wide v1, p3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->threshCorner:D

    .line 187
    iget-wide v1, p2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PositionPatternNode;->grayThreshold:D

    iput-wide v1, p3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->threshDown:D

    .line 190
    invoke-virtual {v0, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->findEdgeIndex(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;)I

    move-result v0

    .line 191
    invoke-virtual {p2, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->findEdgeIndex(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;)I

    move-result p0

    .line 193
    iget-object p2, p3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppRight:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    const/4 v1, 0x3

    invoke-static {p2, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->rotateUntilAt(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;II)V

    .line 194
    iget-object p2, p3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppCorner:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    const/4 v0, 0x1

    invoke-static {p2, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->rotateUntilAt(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;II)V

    .line 195
    iget-object p1, p3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppDown:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    const/4 p2, 0x0

    invoke-static {p1, p0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->rotateUntilAt(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;II)V

    return-void
.end method

.method public static transposeCorners(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;)V
    .locals 7

    const/4 v0, 0x1

    .line 154
    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v1

    iget-wide v1, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    .line 155
    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v3

    iget-wide v3, v3, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    .line 157
    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v0

    const/4 v5, 0x3

    invoke-virtual {p0, v5}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v6

    invoke-virtual {v0, v6}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    .line 158
    invoke-virtual {p0, v5}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object p0

    invoke-virtual {p0, v1, v2, v3, v4}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->setTo(DD)Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;

    return-void
.end method


# virtual methods
.method decodeVersion()I
    .locals 3

    .line 527
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->bits:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;

    const/4 v1, 0x0

    const/16 v2, 0x12

    invoke-virtual {v0, v1, v2, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->read(IIZ)I

    move-result v0

    .line 530
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePolynomialMath;->checkVersionBits(I)Z

    move-result v1

    if-eqz v1, :cond_0

    shr-int/lit8 v0, v0, 0xc

    goto :goto_0

    .line 533
    :cond_0
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePolynomialMath;->correctVersionBits(I)I

    move-result v0

    :goto_0
    const/16 v1, 0x28

    if-gt v0, v1, :cond_2

    const/4 v1, 0x7

    if-ge v0, v1, :cond_1

    goto :goto_1

    :cond_1
    return v0

    :cond_2
    :goto_1
    const/4 v0, -0x1

    return v0
.end method

.method estimateVersionBySize(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)I
    .locals 17

    move-object/from16 v0, p0

    move-object/from16 v1, p1

    .line 548
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->gridReader:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;

    const/4 v3, 0x0

    invoke-virtual {v2, v1, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->setMarkerUnknownVersion(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;F)V

    .line 551
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->gridReader:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;

    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppRight:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    const/4 v4, 0x0

    invoke-virtual {v3, v4}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v3

    iget-object v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->grid:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-virtual {v2, v3, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->imageToGrid(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)V

    .line 555
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->grid:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide v5, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    iget-wide v2, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    div-double/2addr v5, v2

    invoke-static {v5, v6}, Ljava/lang/Math;->abs(D)D

    move-result-wide v2

    const-wide v5, 0x3fd3333333333333L    # 0.3

    cmpl-double v2, v2, v5

    const/4 v3, -0x1

    if-ltz v2, :cond_0

    return v3

    .line 558
    :cond_0
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->grid:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide v7, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    const-wide/high16 v9, 0x401c000000000000L    # 7.0

    add-double/2addr v7, v9

    const-wide/high16 v11, 0x4031000000000000L    # 17.0

    sub-double/2addr v7, v11

    const-wide/high16 v13, 0x4010000000000000L    # 4.0

    div-double/2addr v7, v13

    .line 560
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->gridReader:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;

    iget-object v1, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppDown:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v1, v4}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v1

    iget-object v4, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->grid:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-virtual {v2, v1, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->imageToGrid(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)V

    .line 562
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->grid:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move v2, v3

    iget-wide v3, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    move/from16 p1, v2

    move-wide v15, v3

    iget-wide v2, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    div-double v3, v15, v2

    invoke-static {v3, v4}, Ljava/lang/Math;->abs(D)D

    move-result-wide v1

    cmpl-double v1, v1, v5

    if-ltz v1, :cond_1

    return p1

    .line 565
    :cond_1
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->grid:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide v1, v1, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    add-double/2addr v1, v9

    sub-double/2addr v1, v11

    div-double/2addr v1, v13

    add-double v3, v7, v1

    const-wide/high16 v5, 0x4000000000000000L    # 2.0

    div-double/2addr v3, v5

    const-wide/high16 v9, 0x3fe0000000000000L    # 0.5

    add-double/2addr v3, v9

    double-to-int v3, v3

    sub-double/2addr v7, v1

    .line 569
    invoke-static {v7, v8}, Ljava/lang/Math;->abs(D)D

    move-result-wide v1

    cmpg-double v4, v1, v5

    if-gtz v4, :cond_2

    goto :goto_0

    :cond_2
    const/4 v4, 0x7

    if-ge v3, v4, :cond_3

    return p1

    :cond_3
    int-to-double v4, v3

    div-double/2addr v1, v4

    const-wide v4, 0x3fd999999999999aL    # 0.4

    cmpl-double v1, v1, v4

    if-lez v1, :cond_4

    return p1

    :cond_4
    :goto_0
    return v3
.end method

.method extractVersionInfo(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)Z
    .locals 4

    .line 493
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->estimateVersionBySize(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)I

    move-result v0

    const/4 v1, 0x7

    const/4 v2, -0x1

    const/4 v3, 0x1

    if-lt v0, v1, :cond_3

    .line 497
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->readVersionRegion0(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)Z

    .line 498
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->decodeVersion()I

    move-result v0

    .line 499
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->readVersionRegion1(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)Z

    .line 500
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->decodeVersion()I

    move-result v1

    if-ge v0, v3, :cond_0

    if-ge v1, v3, :cond_0

    goto :goto_0

    :cond_0
    if-ge v0, v3, :cond_1

    move v0, v1

    goto :goto_1

    :cond_1
    if-ge v1, v3, :cond_2

    goto :goto_1

    :cond_2
    if-eq v0, v1, :cond_4

    goto :goto_0

    :cond_3
    if-gtz v0, :cond_4

    :goto_0
    move v0, v2

    .line 517
    :cond_4
    :goto_1
    iput v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->version:I

    if-lt v0, v3, :cond_5

    const/16 p1, 0x28

    if-gt v0, p1, :cond_5

    return v3

    :cond_5
    const/4 p1, 0x0

    return p1
.end method

.method public getDecoder()Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;
    .locals 1

    .line 43
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->decoder:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;

    return-object v0
.end method

.method public getSuccesses()Ljava/util/List;
    .locals 1

    .line 55
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->successes:Ljava/util/List;

    return-object v0
.end method

.method public process(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)V
    .locals 8

    .line 89
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->gridReader:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;

    invoke-virtual {v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->setImage(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)V

    .line 90
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->storageQR:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 91
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->successes:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->clear()V

    .line 92
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->failures:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->clear()V

    const/4 v0, 0x0

    move v1, v0

    .line 94
    :goto_0
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v2

    if-ge v1, v2, :cond_7

    .line 95
    invoke-interface {p1, v1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PositionPatternNode;

    const/4 v3, 0x3

    move v4, v3

    move v3, v0

    :goto_1
    const/4 v5, 0x4

    if-ge v3, v5, :cond_6

    .line 98
    iget-object v5, v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->edges:[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;

    aget-object v6, v5, v4

    if-eqz v6, :cond_5

    aget-object v5, v5, v3

    if-eqz v5, :cond_5

    .line 99
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->storageQR:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v5}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->grow()Ljava/lang/Object;

    move-result-object v5

    check-cast v5, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;

    .line 101
    invoke-static {v2, v4, v3, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->setPositionPatterns(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PositionPatternNode;IILcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)V

    .line 102
    invoke-static {v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->computeBoundingBox(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)V

    .line 105
    invoke-direct {p0, p2, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->decode(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)Z

    move-result v4

    if-eqz v4, :cond_1

    .line 106
    iget-object v4, v5, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->failureCause:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    sget-object v6, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->NONE:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    if-ne v4, v6, :cond_0

    .line 107
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->successes:Ljava/util/List;

    invoke-interface {v4, v5}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    goto :goto_3

    .line 109
    :cond_0
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->failures:Ljava/util/List;

    invoke-interface {v4, v5}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    goto :goto_3

    .line 114
    :cond_1
    iget-boolean v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->considerTransposed:Z

    if-eqz v4, :cond_2

    .line 115
    invoke-virtual {p0, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->transposePositionPatterns(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)V

    .line 116
    invoke-direct {p0, p2, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->decode(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)Z

    move-result v4

    goto :goto_2

    :cond_2
    move v4, v0

    :goto_2
    if-eqz v4, :cond_4

    const/4 v4, 0x1

    .line 120
    iput-boolean v4, v5, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->bitsTransposed:Z

    .line 121
    iget-object v4, v5, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->failureCause:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    sget-object v6, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->NONE:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    if-ne v4, v6, :cond_3

    .line 122
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->successes:Ljava/util/List;

    invoke-interface {v4, v5}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    goto :goto_3

    .line 124
    :cond_3
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->failures:Ljava/util/List;

    invoke-interface {v4, v5}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    goto :goto_3

    .line 127
    :cond_4
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->failures:Ljava/util/List;

    invoke-interface {v4, v5}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    :cond_5
    :goto_3
    add-int/lit8 v4, v3, 0x1

    move v7, v4

    move v4, v3

    move v3, v7

    goto :goto_1

    :cond_6
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_7
    return-void
.end method

.method final readFormatRegion0(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)Z
    .locals 4

    .line 321
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->gridReader:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;

    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppCorner:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    iget-wide v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->threshCorner:D

    double-to-float p1, v2

    invoke-virtual {v0, v1, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->setSquare(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;F)V

    .line 323
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->bits:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;

    const/16 v0, 0xf

    invoke-virtual {p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->resize(I)V

    .line 324
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->bits:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->zero()V

    const/4 p1, 0x0

    move v0, p1

    :goto_0
    const/4 v1, 0x6

    const/16 v2, 0x8

    if-ge v0, v1, :cond_0

    .line 326
    invoke-direct {p0, v0, v0, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->read(III)V

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    const/4 v0, 0x7

    .line 329
    invoke-direct {p0, v1, v0, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->read(III)V

    .line 330
    invoke-direct {p0, v0, v2, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->read(III)V

    .line 331
    invoke-direct {p0, v2, v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->read(III)V

    :goto_1
    if-ge p1, v1, :cond_1

    add-int/lit8 v0, p1, 0x9

    rsub-int/lit8 v3, p1, 0x5

    .line 334
    invoke-direct {p0, v0, v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->read(III)V

    add-int/lit8 p1, p1, 0x1

    goto :goto_1

    :cond_1
    const/4 p1, 0x1

    return p1
.end method

.method final readFormatRegion1(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)Z
    .locals 6

    .line 345
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->gridReader:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;

    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppRight:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    iget-wide v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->threshRight:D

    double-to-float v2, v2

    invoke-virtual {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->setSquare(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;F)V

    .line 347
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->bits:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;

    const/16 v1, 0xf

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->resize(I)V

    .line 348
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->bits:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->zero()V

    const/4 v0, 0x0

    move v1, v0

    :goto_0
    const/16 v2, 0x8

    if-ge v1, v2, :cond_0

    rsub-int/lit8 v3, v1, 0x6

    .line 350
    invoke-direct {p0, v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->read(III)V

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    .line 353
    :cond_0
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->gridReader:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;

    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppDown:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    iget-wide v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->threshDown:D

    double-to-float p1, v4

    invoke-virtual {v1, v3, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->setSquare(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;F)V

    :goto_1
    const/4 p1, 0x7

    if-ge v0, p1, :cond_1

    add-int/lit8 p1, v0, 0x8

    .line 356
    invoke-direct {p0, p1, v0, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->read(III)V

    add-int/lit8 v0, v0, 0x1

    goto :goto_1

    :cond_1
    const/4 p1, 0x1

    return p1
.end method

.method transposePositionPatterns(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)V
    .locals 2

    .line 143
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->tempTranspose:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppDown:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    .line 144
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppDown:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppRight:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    .line 145
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppRight:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->tempTranspose:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    .line 147
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppCorner:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->transposeCorners(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;)V

    .line 148
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppRight:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->transposeCorners(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;)V

    .line 149
    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppDown:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderImage;->transposeCorners(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;)V

    return-void
.end method
