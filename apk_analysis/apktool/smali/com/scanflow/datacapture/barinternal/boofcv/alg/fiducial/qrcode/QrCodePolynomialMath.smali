.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePolynomialMath;
.super Ljava/lang/Object;
.source "QrCodePolynomialMath.java"


# direct methods
.method public static bitPolyModulus(IIII)I
    .locals 2

    .line 169
    sub-int/2addr p2, p3

    const/4 v0, 0x1

    sub-int/2addr p3, v0

    :goto_0
    if-ltz p3, :cond_1

    add-int v1, p3, p2

    shl-int v1, v0, v1

    and-int/2addr v1, p0

    if-eqz v1, :cond_0

    shl-int v1, p1, p3

    xor-int/2addr p0, v1

    :cond_0
    add-int/lit8 p3, p3, -0x1

    goto :goto_0

    :cond_1
    return p0
.end method

.method public static checkFormatBits(I)Z
    .locals 3

    const/16 v0, 0xf

    const/4 v1, 0x5

    const/16 v2, 0x537

    .line 97
    invoke-static {p0, v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePolynomialMath;->bitPolyModulus(IIII)I

    move-result p0

    if-nez p0, :cond_0

    const/4 p0, 0x1

    return p0

    :cond_0
    const/4 p0, 0x0

    return p0
.end method

.method public static checkVersionBits(I)Z
    .locals 3

    const/16 v0, 0x12

    const/4 v1, 0x6

    const/16 v2, 0x1f25

    .line 58
    invoke-static {p0, v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePolynomialMath;->bitPolyModulus(IIII)I

    move-result p0

    if-nez p0, :cond_0

    const/4 p0, 0x1

    return p0

    :cond_0
    const/4 p0, 0x0

    return p0
.end method

.method public static correctDCH(IIIII)I
    .locals 7

    sub-int v0, p3, p4

    const/16 v1, 0xff

    const/4 v2, -0x1

    const/4 v3, 0x0

    move v4, v2

    :goto_0
    if-ge v3, p0, :cond_2

    shl-int v5, v3, v0

    .line 143
    invoke-static {v5, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePolynomialMath;->bitPolyModulus(IIII)I

    move-result v6

    xor-int/2addr v5, v6

    xor-int/2addr v5, p1

    .line 145
    invoke-static {v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/descriptor/DescriptorDistance;->hamming(I)I

    move-result v5

    if-ge v5, v1, :cond_0

    move v4, v3

    move v1, v5

    goto :goto_1

    :cond_0
    if-ne v5, v1, :cond_1

    move v4, v2

    :cond_1
    :goto_1
    add-int/lit8 v3, v3, 0x1

    goto :goto_0

    :cond_2
    return v4
.end method

.method public static correctFormatBits(I)I
    .locals 4

    const/16 v0, 0xf

    const/4 v1, 0x5

    const/16 v2, 0x20

    const/16 v3, 0x537

    .line 120
    invoke-static {v2, p0, v3, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePolynomialMath;->correctDCH(IIIII)I

    move-result p0

    return p0
.end method

.method public static correctVersionBits(I)I
    .locals 4

    const/16 v0, 0x12

    const/4 v1, 0x6

    const/16 v2, 0x40

    const/16 v3, 0x1f25

    .line 68
    invoke-static {v2, p0, v3, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodePolynomialMath;->correctDCH(IIIII)I

    move-result p0

    return p0
.end method

.method public static decodeFormatMessage(ILcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)V
    .locals 1

    shr-int/lit8 v0, p0, 0x3

    .line 109
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;->lookup(I)Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;

    move-result-object v0

    iput-object v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->error:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;

    and-int/lit8 p0, p0, 0x7

    .line 110
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeMaskPattern;->lookupMask(I)Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeMaskPattern;

    move-result-object p0

    iput-object p0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->mask:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeMaskPattern;

    return-void
.end method
