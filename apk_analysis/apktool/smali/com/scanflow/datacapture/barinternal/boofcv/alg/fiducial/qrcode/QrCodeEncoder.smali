.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeEncoder;
.super Ljava/lang/Object;
.source "QrCodeEncoder.java"


# direct methods
.method private static getLengthBits(IIII)I
    .locals 1

    .line 231
    const/16 v0, 0xa

    if-ge p0, v0, :cond_0

    return p1

    :cond_0
    const/16 p1, 0x1b

    if-ge p0, p1, :cond_1

    return p2

    :cond_1
    return p3
.end method

.method public static getLengthBitsAlphanumeric(I)I
    .locals 3

    const/16 v0, 0xb

    const/16 v1, 0xd

    const/16 v2, 0x9

    .line 214
    invoke-static {p0, v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeEncoder;->getLengthBits(IIII)I

    move-result p0

    return p0
.end method

.method public static getLengthBitsBytes(I)I
    .locals 2

    const/16 v0, 0x8

    const/16 v1, 0x10

    .line 218
    invoke-static {p0, v0, v1, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeEncoder;->getLengthBits(IIII)I

    move-result p0

    return p0
.end method

.method public static getLengthBitsKanji(I)I
    .locals 3

    const/16 v0, 0xa

    const/16 v1, 0xc

    const/16 v2, 0x8

    .line 222
    invoke-static {p0, v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeEncoder;->getLengthBits(IIII)I

    move-result p0

    return p0
.end method

.method public static getLengthBitsNumeric(I)I
    .locals 3

    const/16 v0, 0xc

    const/16 v1, 0xe

    const/16 v2, 0xa

    .line 210
    invoke-static {p0, v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeEncoder;->getLengthBits(IIII)I

    move-result p0

    return p0
.end method
