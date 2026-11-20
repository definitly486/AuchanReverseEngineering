.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps_U8;
.super Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;
.source "GaliosFieldTableOps_U8.java"


# direct methods
.method public constructor <init>(II)V
    .locals 0

    .line 41
    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;-><init>(II)V

    return-void
.end method


# virtual methods
.method public polyAddScaleB(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;ILcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;)V
    .locals 8

    .line 126
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    iget v1, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    invoke-static {v0, v1}, Ljava/lang/Math;->max(II)I

    move-result v0

    invoke-virtual {p4, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->resize(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    .line 129
    iget v0, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    sub-int/2addr v0, v1

    const/4 v1, 0x0

    invoke-static {v1, v0}, Ljava/lang/Math;->max(II)I

    move-result v0

    .line 130
    iget v2, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    iget v3, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    sub-int/2addr v2, v3

    invoke-static {v1, v2}, Ljava/lang/Math;->max(II)I

    move-result v2

    .line 131
    iget v3, p4, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    move v4, v1

    :goto_0
    if-ge v4, v2, :cond_0

    .line 134
    iget-object v5, p4, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    iget-object v6, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    aget-byte v6, v6, v4

    aput-byte v6, v5, v4

    add-int/lit8 v4, v4, 0x1

    goto :goto_0

    :cond_0
    :goto_1
    if-ge v1, v0, :cond_1

    .line 137
    iget-object v4, p4, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    iget-object v5, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    aget-byte v5, v5, v1

    and-int/lit16 v5, v5, 0xff

    invoke-virtual {p0, v5, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->multiply(II)I

    move-result v5

    int-to-byte v5, v5

    aput-byte v5, v4, v1

    add-int/lit8 v1, v1, 0x1

    goto :goto_1

    .line 139
    :cond_1
    invoke-static {v0, v2}, Ljava/lang/Math;->max(II)I

    move-result v1

    :goto_2
    if-ge v1, v3, :cond_2

    .line 140
    iget-object v4, p4, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    sub-int v6, v1, v0

    aget-byte v5, v5, v6

    and-int/lit16 v5, v5, 0xff

    iget-object v6, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    sub-int v7, v1, v2

    aget-byte v6, v6, v7

    and-int/lit16 v6, v6, 0xff

    invoke-virtual {p0, v6, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->multiply(II)I

    move-result v6

    xor-int/2addr v5, v6

    int-to-byte v5, v5

    aput-byte v5, v4, v1

    add-int/lit8 v1, v1, 0x1

    goto :goto_2

    :cond_2
    return-void
.end method

.method public polyEval(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;I)I
    .locals 3

    .line 210
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    const/4 v1, 0x0

    aget-byte v0, v0, v1

    and-int/lit16 v0, v0, 0xff

    const/4 v1, 0x1

    .line 212
    :goto_0
    iget v2, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    if-ge v1, v2, :cond_0

    .line 213
    invoke-virtual {p0, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->multiply(II)I

    move-result v0

    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    aget-byte v2, v2, v1

    and-int/lit16 v2, v2, 0xff

    xor-int/2addr v0, v2

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_0
    return v0
.end method

.method public polyEvalContinue(ILcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;I)I
    .locals 2

    const/4 v0, 0x0

    .line 251
    :goto_0
    iget v1, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    if-ge v0, v1, :cond_0

    .line 252
    invoke-virtual {p0, p1, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->multiply(II)I

    move-result p1

    iget-object v1, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    aget-byte v1, v1, v0

    and-int/lit16 v1, v1, 0xff

    xor-int/2addr p1, v1

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    return p1
.end method

.method public polyEval_S(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;I)I
    .locals 3

    .line 232
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    add-int/lit8 v2, v1, -0x1

    aget-byte v0, v0, v2

    and-int/lit16 v0, v0, 0xff

    add-int/lit8 v1, v1, -0x2

    :goto_0
    if-ltz v1, :cond_0

    .line 235
    invoke-virtual {p0, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->multiply(II)I

    move-result v0

    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    aget-byte v2, v2, v1

    and-int/lit16 v2, v2, 0xff

    xor-int/2addr v0, v2

    add-int/lit8 v1, v1, -0x1

    goto :goto_0

    :cond_0
    return v0
.end method

.method public polyMult(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;)V
    .locals 8

    .line 150
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    iget v1, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    add-int/2addr v0, v1

    add-int/lit8 v0, v0, -0x1

    invoke-virtual {p3, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->resize(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    .line 151
    invoke-virtual {p3}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->zero()V

    const/4 v0, 0x0

    move v1, v0

    .line 153
    :goto_0
    iget v2, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    if-ge v1, v2, :cond_1

    .line 154
    iget-object v2, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    aget-byte v2, v2, v1

    and-int/lit16 v2, v2, 0xff

    move v3, v0

    .line 155
    :goto_1
    iget v4, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    if-ge v3, v4, :cond_0

    .line 156
    iget-object v4, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    aget-byte v4, v4, v3

    and-int/lit16 v4, v4, 0xff

    .line 157
    iget-object v5, p3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    add-int v6, v3, v1

    aget-byte v7, v5, v6

    invoke-virtual {p0, v4, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->multiply(II)I

    move-result v4

    int-to-byte v4, v4

    xor-int/2addr v4, v7

    int-to-byte v4, v4

    aput-byte v4, v5, v6

    add-int/lit8 v3, v3, 0x1

    goto :goto_1

    :cond_0
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public polyMult_flipA(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;)V
    .locals 8

    .line 165
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    iget v1, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    add-int/2addr v0, v1

    add-int/lit8 v0, v0, -0x1

    invoke-virtual {p3, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->resize(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    .line 166
    invoke-virtual {p3}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->zero()V

    const/4 v0, 0x0

    move v1, v0

    .line 168
    :goto_0
    iget v2, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    if-ge v1, v2, :cond_1

    .line 169
    iget-object v2, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    aget-byte v2, v2, v1

    and-int/lit16 v2, v2, 0xff

    move v3, v0

    .line 170
    :goto_1
    iget v4, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    if-ge v3, v4, :cond_0

    .line 171
    iget-object v5, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    sub-int/2addr v4, v3

    add-int/lit8 v4, v4, -0x1

    aget-byte v4, v5, v4

    and-int/lit16 v4, v4, 0xff

    .line 172
    iget-object v5, p3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    add-int v6, v3, v1

    aget-byte v7, v5, v6

    invoke-virtual {p0, v4, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->multiply(II)I

    move-result v4

    int-to-byte v4, v4

    xor-int/2addr v4, v7

    int-to-byte v4, v4

    aput-byte v4, v5, v6

    add-int/lit8 v3, v3, 0x1

    goto :goto_1

    :cond_0
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method
