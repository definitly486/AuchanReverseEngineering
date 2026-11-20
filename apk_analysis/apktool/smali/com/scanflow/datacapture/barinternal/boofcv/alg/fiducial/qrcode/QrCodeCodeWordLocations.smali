.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodeWordLocations;
.super Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;
.source "QrCodeCodeWordLocations.java"


# instance fields
.field public bits:Ljava/util/List;


# direct methods
.method private constructor <init>(I)V
    .locals 0

    .line 60
    invoke-direct {p0, p1, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;-><init>(II)V

    .line 37
    new-instance p1, Ljava/util/ArrayList;

    invoke-direct {p1}, Ljava/util/ArrayList;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodeWordLocations;->bits:Ljava/util/List;

    return-void
.end method

.method private computeBitLocations(Z)V
    .locals 7

    .line 133
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;->numRows:I

    add-int/lit8 v1, v0, -0x1

    const/4 v2, -0x1

    move v3, v2

    move v2, v1

    :cond_0
    :goto_0
    if-lez v1, :cond_5

    const/4 v4, 0x6

    if-ne v1, v4, :cond_1

    if-nez p1, :cond_1

    add-int/lit8 v1, v1, -0x1

    .line 142
    :cond_1
    invoke-virtual {p0, v2, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;->get(II)Z

    move-result v4

    if-nez v4, :cond_2

    .line 143
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodeWordLocations;->bits:Ljava/util/List;

    new-instance v5, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    invoke-direct {v5, v1, v2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;-><init>(II)V

    invoke-interface {v4, v5}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    :cond_2
    add-int/lit8 v4, v1, -0x1

    .line 145
    invoke-virtual {p0, v2, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;->get(II)Z

    move-result v5

    if-nez v5, :cond_3

    .line 146
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodeWordLocations;->bits:Ljava/util/List;

    new-instance v6, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    invoke-direct {v6, v4, v2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;-><init>(II)V

    invoke-interface {v5, v6}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    :cond_3
    add-int/2addr v2, v3

    if-ltz v2, :cond_4

    if-lt v2, v0, :cond_0

    :cond_4
    neg-int v3, v3

    add-int/lit8 v1, v1, -0x2

    add-int/2addr v2, v3

    goto :goto_0

    :cond_5
    return-void
.end method

.method private featureMaskQrCode(I[IZ)V
    .locals 6

    const/4 v0, 0x0

    const/16 v1, 0x9

    .line 68
    invoke-direct {p0, v0, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodeWordLocations;->markSquare(III)V

    add-int/lit8 v2, p1, -0x8

    const/16 v3, 0x8

    .line 69
    invoke-direct {p0, v2, v0, v1, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodeWordLocations;->markRectangle(IIII)V

    .line 70
    invoke-direct {p0, v0, v2, v3, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodeWordLocations;->markRectangle(IIII)V

    add-int/lit8 v1, p1, -0x10

    const/4 v2, 0x6

    const/4 v4, 0x1

    .line 73
    invoke-direct {p0, v3, v2, v4, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodeWordLocations;->markRectangle(IIII)V

    .line 74
    invoke-direct {p0, v2, v3, v1, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodeWordLocations;->markRectangle(IIII)V

    if-eqz p3, :cond_0

    add-int/lit8 p1, p1, -0xb

    const/4 p3, 0x3

    .line 78
    invoke-direct {p0, p1, v0, v2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodeWordLocations;->markRectangle(IIII)V

    .line 79
    invoke-direct {p0, v0, p1, p3, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodeWordLocations;->markRectangle(IIII)V

    :cond_0
    move p1, v0

    .line 83
    :goto_0
    array-length p3, p2

    if-ge p1, p3, :cond_5

    .line 84
    aget p3, p2, p1

    move v1, v0

    .line 86
    :goto_1
    array-length v2, p2

    if-ge v1, v2, :cond_4

    if-nez p1, :cond_1

    if-nez v1, :cond_1

    goto :goto_2

    .line 89
    :cond_1
    array-length v2, p2

    sub-int/2addr v2, v4

    if-ne p1, v2, :cond_2

    if-nez v1, :cond_2

    goto :goto_2

    :cond_2
    if-nez p1, :cond_3

    .line 91
    array-length v2, p2

    sub-int/2addr v2, v4

    if-ne v1, v2, :cond_3

    goto :goto_2

    .line 94
    :cond_3
    aget v2, p2, v1

    add-int/lit8 v3, p3, -0x2

    add-int/lit8 v2, v2, -0x2

    const/4 v5, 0x5

    .line 95
    invoke-direct {p0, v3, v2, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodeWordLocations;->markSquare(III)V

    :goto_2
    add-int/lit8 v1, v1, 0x1

    goto :goto_1

    :cond_4
    add-int/lit8 p1, p1, 0x1

    goto :goto_0

    :cond_5
    return-void
.end method

.method private markRectangle(IIII)V
    .locals 6

    const/4 v0, 0x0

    move v1, v0

    :goto_0
    if-ge v1, p4, :cond_1

    move v2, v0

    :goto_1
    if-ge v2, p3, :cond_0

    add-int v3, p1, v1

    add-int v4, p2, v2

    const/4 v5, 0x1

    .line 123
    invoke-virtual {p0, v3, v4, v5}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;->set(IIZ)V

    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    :cond_0
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method private markSquare(III)V
    .locals 6

    const/4 v0, 0x0

    move v1, v0

    :goto_0
    if-ge v1, p3, :cond_1

    move v2, v0

    :goto_1
    if-ge v2, p3, :cond_0

    add-int v3, p1, v1

    add-int v4, p2, v2

    const/4 v5, 0x1

    .line 115
    invoke-virtual {p0, v3, v4, v5}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;->set(IIZ)V

    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    :cond_0
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static qrcode(I)Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodeWordLocations;
    .locals 4

    .line 40
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->totalModules(I)I

    move-result v0

    .line 41
    sget-object v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->VERSION_INFO:[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    aget-object v1, v1, p0

    iget-object v1, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->alignment:[I

    const/4 v2, 0x7

    const/4 v3, 0x0

    if-lt p0, v2, :cond_0

    const/4 p0, 0x1

    goto :goto_0

    :cond_0
    move p0, v3

    .line 44
    :goto_0
    new-instance v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodeWordLocations;

    invoke-direct {v2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodeWordLocations;-><init>(I)V

    .line 45
    invoke-direct {v2, v0, v1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodeWordLocations;->featureMaskQrCode(I[IZ)V

    .line 46
    invoke-direct {v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodeWordLocations;->computeBitLocations(Z)V

    return-object v2
.end method
