.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;
.super Ljava/lang/Object;
.source "PackedBits8.java"


# instance fields
.field public data:[B

.field public size:I


# direct methods
.method public constructor <init>()V
    .locals 1

    .line 49
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const/4 v0, 0x1

    .line 32
    new-array v0, v0, [B

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->data:[B

    return-void
.end method


# virtual methods
.method public arrayLength()I
    .locals 2

    .line 246
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->size:I

    rem-int/lit8 v1, v0, 0x8

    if-nez v1, :cond_0

    .line 247
    div-int/lit8 v0, v0, 0x8

    return v0

    .line 249
    :cond_0
    div-int/lit8 v0, v0, 0x8

    add-int/lit8 v0, v0, 0x1

    return v0
.end method

.method public get(I)I
    .locals 2

    .line 73
    div-int/lit8 v0, p1, 0x8

    .line 74
    rem-int/lit8 p1, p1, 0x8

    .line 76
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->data:[B

    aget-byte v0, v1, v0

    const/4 v1, 0x1

    shl-int/2addr v1, p1

    and-int/2addr v0, v1

    shr-int p1, v0, p1

    return p1
.end method

.method public read(IIZ)I
    .locals 3

    if-ltz p2, :cond_4

    const/16 v0, 0x20

    if-gt p2, v0, :cond_4

    add-int v0, p1, p2

    .line 183
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->size:I

    if-gt v0, v1, :cond_3

    const/4 v0, 0x0

    if-eqz p3, :cond_1

    move p3, v0

    :goto_0
    if-ge v0, p2, :cond_0

    add-int v1, p1, v0

    .line 191
    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->get(I)I

    move-result v1

    sub-int v2, p2, v0

    add-int/lit8 v2, v2, -0x1

    shl-int/2addr v1, v2

    or-int/2addr p3, v1

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    return p3

    :cond_1
    move p3, v0

    :goto_1
    if-ge v0, p2, :cond_2

    add-int v1, p1, v0

    .line 195
    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->get(I)I

    move-result v1

    shl-int/2addr v1, v0

    or-int/2addr p3, v1

    add-int/lit8 v0, v0, 0x1

    goto :goto_1

    :cond_2
    return p3

    .line 184
    :cond_3
    new-instance p3, Ljava/lang/IllegalArgumentException;

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->size:I

    sub-int/2addr v0, p1

    new-instance p1, Ljava/lang/StringBuilder;

    invoke-direct {p1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "Attempting to read past the end. length="

    invoke-virtual {p1, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p1, p2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p2, " remaining="

    invoke-virtual {p1, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p1, v0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {p1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {p3, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p3

    .line 182
    :cond_4
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string p2, "Length can\'t exceed 32"

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public resize(I)V
    .locals 1

    .line 207
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->size:I

    .line 208
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->arrayLength()I

    move-result p1

    .line 209
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->data:[B

    array-length v0, v0

    if-ge v0, p1, :cond_0

    .line 210
    new-array p1, p1, [B

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->data:[B

    :cond_0
    return-void
.end method

.method public set(II)V
    .locals 4

    .line 81
    div-int/lit8 v0, p1, 0x8

    .line 82
    rem-int/lit8 p1, p1, 0x8

    .line 84
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->data:[B

    aget-byte v2, v1, v0

    neg-int p2, p2

    xor-int/2addr p2, v2

    const/4 v3, 0x1

    shl-int p1, v3, p1

    and-int/2addr p1, p2

    int-to-byte p1, p1

    xor-int/2addr p1, v2

    int-to-byte p1, p1

    aput-byte p1, v1, v0

    return-void
.end method

.method public zero()V
    .locals 3

    .line 236
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->data:[B

    const/4 v1, 0x0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->arrayLength()I

    move-result v2

    invoke-static {v0, v1, v2, v1}, Ljava/util/Arrays;->fill([BIIB)V

    return-void
.end method
