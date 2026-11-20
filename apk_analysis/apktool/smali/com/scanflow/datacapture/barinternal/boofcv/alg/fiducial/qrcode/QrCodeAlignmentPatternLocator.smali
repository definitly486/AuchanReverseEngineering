.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeAlignmentPatternLocator;
.super Ljava/lang/Object;
.source "QrCodeAlignmentPatternLocator.java"


# instance fields
.field arrayX:[F

.field arrayY:[F

.field private final lookup:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArray;

.field qr:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;

.field reader:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;

.field samples:[F

.field threshold:F


# direct methods
.method public constructor <init>(Ljava/lang/Class;)V
    .locals 2

    .line 53
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 41
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArray;

    const-class v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArray;-><init>(Ljava/lang/Class;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeAlignmentPatternLocator;->lookup:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArray;

    const/16 v0, 0xc

    .line 46
    new-array v1, v0, [F

    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeAlignmentPatternLocator;->arrayX:[F

    .line 47
    new-array v0, v0, [F

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeAlignmentPatternLocator;->arrayY:[F

    const/16 v0, 0x9

    .line 150
    new-array v0, v0, [F

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeAlignmentPatternLocator;->samples:[F

    .line 54
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;

    invoke-direct {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;-><init>(Ljava/lang/Class;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeAlignmentPatternLocator;->reader:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;

    return-void
.end method


# virtual methods
.method centerOnSquare(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;FF)Z
    .locals 18

    move-object/from16 v0, p0

    move-object/from16 v1, p1

    const/high16 v2, 0x3f800000    # 1.0f

    const v3, 0x7f7fffff    # Float.MAX_VALUE

    move/from16 v5, p2

    move/from16 v6, p3

    move v7, v6

    move v10, v2

    move v8, v3

    const/4 v9, 0x0

    move v3, v5

    :goto_0
    const/16 v11, 0xa

    if-ge v9, v11, :cond_3

    const/4 v11, 0x0

    :goto_1
    const/4 v13, 0x3

    if-ge v11, v13, :cond_1

    sub-float v14, v3, v2

    int-to-float v15, v11

    add-float/2addr v14, v15

    const/4 v15, 0x0

    :goto_2
    if-ge v15, v13, :cond_0

    sub-float v16, v6, v2

    int-to-float v2, v15

    add-float v2, v16, v2

    const/16 v16, 0x0

    .line 168
    iget-object v4, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeAlignmentPatternLocator;->samples:[F

    mul-int/lit8 v17, v11, 0x3

    add-int v17, v17, v15

    const/16 p2, 0x1

    iget-object v12, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeAlignmentPatternLocator;->reader:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;

    invoke-virtual {v12, v14, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->read(FF)F

    move-result v2

    aput v2, v4, v17

    add-int/lit8 v15, v15, 0x1

    const/high16 v2, 0x3f800000    # 1.0f

    goto :goto_2

    :cond_0
    const/16 p2, 0x1

    const/16 v16, 0x0

    add-int/lit8 v11, v11, 0x1

    const/high16 v2, 0x3f800000    # 1.0f

    goto :goto_1

    :cond_1
    const/16 p2, 0x1

    const/16 v16, 0x0

    .line 172
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeAlignmentPatternLocator;->samples:[F

    const/4 v4, 0x2

    aget v4, v2, v4

    const/4 v11, 0x5

    aget v11, v2, v11

    add-float/2addr v11, v4

    const/16 v12, 0x8

    aget v12, v2, v12

    add-float/2addr v11, v12

    aget v14, v2, v16

    aget v13, v2, v13

    add-float/2addr v13, v14

    const/4 v15, 0x6

    aget v15, v2, v15

    add-float/2addr v13, v15

    sub-float/2addr v11, v13

    const/4 v13, 0x7

    .line 173
    aget v13, v2, v13

    add-float/2addr v15, v13

    add-float/2addr v15, v12

    aget v2, v2, p2

    add-float/2addr v14, v2

    add-float/2addr v14, v4

    sub-float/2addr v15, v14

    mul-float v2, v11, v11

    mul-float v4, v15, v15

    add-float/2addr v2, v4

    float-to-double v12, v2

    .line 175
    invoke-static {v12, v13}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide v12

    double-to-float v2, v12

    cmpl-float v4, v8, v2

    if-lez v4, :cond_2

    move v8, v2

    move v5, v3

    move v7, v6

    goto :goto_3

    :cond_2
    const/high16 v3, 0x3f400000    # 0.75f

    mul-float/2addr v10, v3

    :goto_3
    const/4 v3, 0x0

    cmpl-float v3, v2, v3

    if-lez v3, :cond_4

    mul-float/2addr v11, v10

    div-float/2addr v11, v2

    add-float v6, v7, v11

    mul-float/2addr v15, v10

    div-float/2addr v15, v2

    add-float v3, v5, v15

    add-int/lit8 v9, v9, 0x1

    const/high16 v2, 0x3f800000    # 1.0f

    goto/16 :goto_0

    :cond_3
    const/16 p2, 0x1

    .line 195
    :cond_4
    iget-object v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;->moduleFound:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    float-to-double v3, v7

    iput-wide v3, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    float-to-double v5, v5

    .line 196
    iput-wide v5, v2, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    .line 198
    iget-object v7, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeAlignmentPatternLocator;->reader:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;

    double-to-float v2, v5

    float-to-double v8, v2

    double-to-float v2, v3

    float-to-double v10, v2

    iget-object v12, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;->pixel:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-virtual/range {v7 .. v12}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->gridToImage(DDLcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)V

    return p2
.end method

.method initializePatterns(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)V
    .locals 6

    .line 87
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->VERSION_INFO:[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->version:I

    aget-object v0, v0, v1

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->alignment:[I

    .line 88
    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->alignment:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 89
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeAlignmentPatternLocator;->lookup:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArray;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArray;->reset()V

    const/4 v1, 0x0

    move v2, v1

    .line 90
    :goto_0
    array-length v3, v0

    if-ge v2, v3, :cond_4

    move v3, v1

    .line 91
    :goto_1
    array-length v4, v0

    if-ge v3, v4, :cond_3

    if-nez v2, :cond_0

    if-nez v3, :cond_0

    goto :goto_2

    :cond_0
    if-nez v2, :cond_1

    .line 95
    array-length v4, v0

    add-int/lit8 v4, v4, -0x1

    if-ne v3, v4, :cond_1

    goto :goto_2

    .line 97
    :cond_1
    array-length v4, v0

    add-int/lit8 v4, v4, -0x1

    if-ne v2, v4, :cond_2

    if-nez v3, :cond_2

    .line 101
    :goto_2
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeAlignmentPatternLocator;->lookup:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArray;

    const/4 v5, 0x0

    invoke-virtual {v4, v5}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArray;->add(Ljava/lang/Object;)V

    goto :goto_3

    .line 103
    :cond_2
    iget-object v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->alignment:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->grow()Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;

    .line 104
    aget v5, v0, v3

    iput v5, v4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;->moduleX:I

    .line 105
    aget v5, v0, v2

    iput v5, v4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;->moduleY:I

    .line 106
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeAlignmentPatternLocator;->lookup:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArray;

    invoke-virtual {v5, v4}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArray;->add(Ljava/lang/Object;)V

    :goto_3
    add-int/lit8 v3, v3, 0x1

    goto :goto_1

    :cond_3
    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    :cond_4
    return-void
.end method

.method localizePositionPatterns([I)Z
    .locals 14

    .line 113
    array-length p1, p1

    const/4 v0, 0x0

    move v1, v0

    :goto_0
    if-ge v1, p1, :cond_6

    move v2, v0

    :goto_1
    if-ge v2, p1, :cond_5

    .line 117
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeAlignmentPatternLocator;->lookup:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArray;

    mul-int v4, v1, p1

    add-int/2addr v4, v2

    invoke-virtual {v3, v4}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->get(I)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;

    if-nez v3, :cond_0

    goto :goto_3

    :cond_0
    const-wide/16 v5, 0x0

    const-wide/high16 v7, 0x3fe0000000000000L    # 0.5

    if-lez v1, :cond_1

    .line 125
    iget-object v9, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeAlignmentPatternLocator;->lookup:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArray;

    add-int/lit8 v10, v1, -0x1

    mul-int/2addr v10, p1

    add-int/2addr v10, v2

    invoke-virtual {v9, v10}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->get(I)Ljava/lang/Object;

    move-result-object v9

    check-cast v9, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;

    if-eqz v9, :cond_1

    .line 127
    iget v10, v9, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;->moduleY:I

    int-to-double v10, v10

    add-double/2addr v10, v7

    iget-object v9, v9, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;->moduleFound:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide v12, v9, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    sub-double/2addr v10, v12

    goto :goto_2

    :cond_1
    move-wide v10, v5

    :goto_2
    if-lez v2, :cond_2

    .line 130
    iget-object v9, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeAlignmentPatternLocator;->lookup:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArray;

    add-int/lit8 v4, v4, -0x1

    invoke-virtual {v9, v4}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->get(I)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;

    if-eqz v4, :cond_2

    .line 132
    iget v5, v4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;->moduleX:I

    int-to-double v5, v5

    add-double/2addr v5, v7

    iget-object v4, v4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;->moduleFound:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide v12, v4, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    sub-double/2addr v5, v12

    .line 135
    :cond_2
    iget v4, v3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;->moduleY:I

    int-to-double v12, v4

    add-double/2addr v12, v7

    add-double/2addr v12, v10

    double-to-float v4, v12

    iget v9, v3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;->moduleX:I

    int-to-double v9, v9

    add-double/2addr v9, v7

    add-double/2addr v9, v5

    double-to-float v5, v9

    invoke-virtual {p0, v3, v4, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeAlignmentPatternLocator;->centerOnSquare(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;FF)Z

    move-result v4

    if-nez v4, :cond_3

    return v0

    .line 142
    :cond_3
    iget-object v4, v3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;->moduleFound:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    iget-wide v5, v4, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    double-to-float v5, v5

    iget-wide v6, v4, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    double-to-float v4, v6

    invoke-virtual {p0, v3, v5, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeAlignmentPatternLocator;->meanshift(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;FF)Z

    move-result v3

    if-nez v3, :cond_4

    return v0

    :cond_4
    :goto_3
    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    :cond_5
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_6
    const/4 p1, 0x1

    return p1
.end method

.method meanshift(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;FF)Z
    .locals 20

    move-object/from16 v0, p0

    move-object/from16 v1, p1

    const/high16 v2, 0x3f800000    # 1.0f

    move/from16 v4, p3

    move v5, v2

    const/4 v6, 0x0

    move/from16 v2, p2

    :goto_0
    const/16 v7, 0xa

    if-ge v6, v7, :cond_3

    const/4 v7, 0x0

    move v8, v7

    move v9, v8

    const/4 v10, 0x0

    :goto_1
    const/16 v11, 0x8

    if-ge v10, v11, :cond_2

    int-to-float v12, v10

    const/high16 v13, 0x40400000    # 3.0f

    mul-float/2addr v12, v13

    const/high16 v14, 0x40e00000    # 7.0f

    div-float/2addr v12, v14

    const/high16 v15, -0x40400000    # -1.5f

    add-float/2addr v12, v15

    add-float v3, v2, v12

    move/from16 p2, v13

    const/4 v13, 0x0

    :goto_2
    if-ge v13, v11, :cond_1

    int-to-float v11, v13

    mul-float v11, v11, p2

    div-float/2addr v11, v14

    add-float/2addr v11, v15

    add-float v14, v4, v11

    .line 254
    iget-object v15, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeAlignmentPatternLocator;->reader:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;

    invoke-virtual {v15, v3, v14}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->read(FF)F

    move-result v14

    mul-float v15, v11, v11

    mul-float v16, v12, v12

    add-float v15, v15, v16

    move/from16 v16, v5

    move/from16 v17, v6

    float-to-double v5, v15

    .line 255
    invoke-static {v5, v6}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide v5

    double-to-float v5, v5

    float-to-double v5, v5

    const-wide/high16 v18, 0x3fe0000000000000L    # 0.5

    cmpl-double v5, v5, v18

    if-lez v5, :cond_0

    .line 257
    iget v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeAlignmentPatternLocator;->threshold:F

    sub-float/2addr v14, v5

    goto :goto_3

    :cond_0
    iget v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeAlignmentPatternLocator;->threshold:F

    sub-float v14, v5, v14

    :goto_3
    const/high16 v5, -0x3ee00000    # -10.0f

    invoke-static {v5, v14}, Ljava/lang/Math;->max(FF)F

    move-result v5

    .line 258
    invoke-static {v5}, Ljava/lang/Math;->abs(F)F

    move-result v6

    add-float/2addr v8, v6

    mul-float/2addr v11, v5

    add-float/2addr v7, v11

    mul-float/2addr v5, v12

    add-float/2addr v9, v5

    add-int/lit8 v13, v13, 0x1

    move/from16 v5, v16

    move/from16 v6, v17

    const/16 v11, 0x8

    const/high16 v14, 0x40e00000    # 7.0f

    const/high16 v15, -0x40400000    # -1.5f

    goto :goto_2

    :cond_1
    move/from16 v16, v5

    move/from16 v17, v6

    add-int/lit8 v10, v10, 0x1

    goto :goto_1

    :cond_2
    move/from16 v16, v5

    move/from16 v17, v6

    mul-float v5, v16, v7

    div-float/2addr v5, v8

    add-float/2addr v4, v5

    mul-float v5, v16, v9

    div-float/2addr v5, v8

    add-float/2addr v2, v5

    const v3, 0x3f333333    # 0.7f

    mul-float v5, v16, v3

    add-int/lit8 v6, v17, 0x1

    goto :goto_0

    .line 271
    :cond_3
    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;->moduleFound:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    float-to-double v4, v4

    iput-wide v4, v3, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    float-to-double v6, v2

    .line 272
    iput-wide v6, v3, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    .line 274
    iget-object v8, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeAlignmentPatternLocator;->reader:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;

    double-to-float v2, v6

    float-to-double v9, v2

    double-to-float v2, v4

    float-to-double v11, v2

    iget-object v13, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;->pixel:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    invoke-virtual/range {v8 .. v13}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->gridToImage(DDLcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)V

    const/4 v1, 0x1

    return v1
.end method

.method public process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)Z
    .locals 2

    .line 61
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeAlignmentPatternLocator;->qr:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;

    .line 63
    iget-object v0, p2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->alignment:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 65
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeAlignmentPatternLocator;->reader:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->setImage(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)V

    .line 66
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeAlignmentPatternLocator;->reader:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;

    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeBinaryGridReader;->setMarker(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)V

    .line 68
    iget-wide v0, p2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->threshCorner:D

    double-to-float p1, v0

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeAlignmentPatternLocator;->threshold:F

    .line 70
    invoke-virtual {p0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeAlignmentPatternLocator;->initializePatterns(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)V

    .line 73
    iget p1, p2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->version:I

    const/4 p2, 0x1

    if-gt p1, p2, :cond_0

    return p2

    .line 75
    :cond_0
    sget-object p2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->VERSION_INFO:[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    aget-object p1, p2, p1

    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->alignment:[I

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeAlignmentPatternLocator;->localizePositionPatterns([I)Z

    move-result p1

    return p1
.end method
