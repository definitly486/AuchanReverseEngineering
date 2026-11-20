.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;
.super Ljava/lang/Object;
.source "QrCodeDecoderBits.java"


# instance fields
.field ecc:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

.field encodingEci:Ljava/lang/String;

.field public ignorePaddingBytes:Z

.field message:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

.field rscodes:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;

.field totalErrorBits:I

.field final utils:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;

.field verbose:Ljava/io/PrintStream;


# direct methods
.method public constructor <init>(Ljava/lang/String;Ljava/lang/String;)V
    .locals 4

    .line 68
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 43
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;

    const/16 v1, 0x8

    const/16 v2, 0x11d

    const/4 v3, 0x0

    invoke-direct {v0, v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;-><init>(III)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->rscodes:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;

    .line 45
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->message:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    .line 47
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->ecc:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    .line 60
    iput-boolean v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->ignorePaddingBytes:Z

    const/4 v0, 0x0

    .line 62
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->verbose:Ljava/io/PrintStream;

    .line 69
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;

    invoke-direct {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->utils:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;

    return-void
.end method

.method public static alignToBytes(I)I
    .locals 1

    .line 250
    rem-int/lit8 v0, p0, 0x8

    rsub-int/lit8 v0, v0, 0x8

    rem-int/lit8 v0, v0, 0x8

    add-int/2addr p0, v0

    return p0
.end method

.method private copyFromRawData([BLcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;III)V
    .locals 4

    const/4 v0, 0x0

    move v1, v0

    .line 134
    :goto_0
    iget v2, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    if-ge v1, v2, :cond_0

    .line 135
    iget-object v2, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    mul-int v3, v1, p5

    add-int/2addr v3, p4

    aget-byte v3, p1, v3

    aput-byte v3, v2, v1

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    .line 137
    :cond_0
    :goto_1
    iget p2, p3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    if-ge v0, p2, :cond_1

    .line 138
    iget-object p2, p3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    mul-int v1, v0, p5

    add-int/2addr v1, p4

    add-int/2addr v1, p6

    aget-byte v1, p1, v1

    aput-byte v1, p2, v0

    add-int/lit8 v0, v0, 0x1

    goto :goto_1

    :cond_1
    return-void
.end method

.method private decideMessageBits(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)I
    .locals 6

    .line 187
    const-string v0, ""

    iput-object v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->byteEncoding:Ljava/lang/String;

    .line 189
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;-><init>()V

    .line 190
    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->corrected:[B

    iput-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->data:[B

    .line 191
    array-length v1, v1

    mul-int/lit8 v1, v1, 0x8

    iput v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->size:I

    const/4 v1, 0x0

    :cond_0
    add-int/lit8 v2, v1, 0x4

    .line 194
    iget v3, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->size:I

    if-gt v2, v3, :cond_5

    const/4 v3, 0x1

    const/4 v4, 0x4

    .line 195
    invoke-virtual {v0, v1, v4, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->read(IIZ)I

    move-result v1

    if-nez v1, :cond_2

    .line 198
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->verbose:Ljava/io/PrintStream;

    if-eqz p1, :cond_1

    invoke-static {v2}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v1

    iget v0, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->size:I

    invoke-static {v0}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v0

    filled-new-array {v1, v0}, [Ljava/lang/Object;

    move-result-object v0

    const-string v1, "bit_loc=%d/%d escape mode\n"

    invoke-virtual {p1, v1, v0}, Ljava/io/PrintStream;->printf(Ljava/lang/String;[Ljava/lang/Object;)Ljava/io/PrintStream;

    :cond_1
    return v2

    .line 201
    :cond_2
    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->lookup(I)Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    move-result-object v1

    .line 203
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->verbose:Ljava/io/PrintStream;

    if-eqz v3, :cond_3

    invoke-static {v2}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v4

    iget v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->size:I

    invoke-static {v5}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v5

    filled-new-array {v4, v5, v1}, [Ljava/lang/Object;

    move-result-object v4

    const-string v5, "bit_loc=%d/%d mode=%s\n"

    invoke-virtual {v3, v5, v4}, Ljava/io/PrintStream;->printf(Ljava/lang/String;[Ljava/lang/Object;)Ljava/io/PrintStream;

    .line 205
    :cond_3
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->mode:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    invoke-direct {p0, v3, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->updateModeLogic(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;)Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    move-result-object v3

    iput-object v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->mode:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    .line 206
    sget-object v3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits$1;->$SwitchMap$boofcv$alg$fiducial$qrcode$QrCode$Mode:[I

    invoke-virtual {v1}, Ljava/lang/Enum;->ordinal()I

    move-result v1

    aget v1, v3, v1

    const/4 v3, -0x1

    packed-switch v1, :pswitch_data_0

    .line 223
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->UNKNOWN_MODE:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    iput-object v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->failureCause:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    return v3

    :pswitch_0
    move v1, v2

    goto :goto_0

    .line 217
    :pswitch_1
    invoke-virtual {p0, v0, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->decodeEci(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;I)I

    move-result v1

    goto :goto_0

    .line 216
    :pswitch_2
    invoke-direct {p0, p1, v0, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->decodeKanji(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;I)I

    move-result v1

    goto :goto_0

    .line 210
    :pswitch_3
    invoke-direct {p0, p1, v0, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->decodeByte(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;I)I

    move-result v1

    .line 212
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->byteEncoding:Ljava/lang/String;

    invoke-virtual {v2}, Ljava/lang/String;->isEmpty()Z

    move-result v2

    if-eqz v2, :cond_4

    .line 213
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->utils:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;

    iget-object v2, v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->selectedByteEncoding:Ljava/lang/String;

    iput-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->byteEncoding:Ljava/lang/String;

    goto :goto_0

    .line 208
    :pswitch_4
    invoke-direct {p0, p1, v0, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->decodeAlphanumeric(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;I)I

    move-result v1

    goto :goto_0

    .line 207
    :pswitch_5
    invoke-direct {p0, p1, v0, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->decodeNumeric(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;I)I

    move-result v1

    :cond_4
    :goto_0
    if-gez v1, :cond_0

    .line 229
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->utils:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->failureCause:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    iput-object v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->failureCause:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    return v3

    :cond_5
    return v1

    nop

    :pswitch_data_0
    .packed-switch 0x1
        :pswitch_5
        :pswitch_4
        :pswitch_3
        :pswitch_2
        :pswitch_1
        :pswitch_0
        :pswitch_0
    .end packed-switch
.end method

.method private decodeAlphanumeric(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;I)I
    .locals 1

    .line 303
    iget p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->version:I

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeEncoder;->getLengthBitsAlphanumeric(I)I

    move-result p1

    .line 304
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->utils:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;

    invoke-virtual {v0, p2, p3, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->decodeAlphanumeric(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;II)I

    move-result p1

    return p1
.end method

.method private decodeBlocks(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;IIIIII)Z
    .locals 8

    .line 112
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->message:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    invoke-virtual {v0, p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->resize(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    const/4 p2, 0x0

    move v0, p2

    :goto_0
    if-ge v0, p3, :cond_1

    .line 115
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->rawbits:[B

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->message:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->ecc:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    add-int v5, p5, v0

    move-object v1, p0

    move v7, p6

    move v6, p7

    invoke-direct/range {v1 .. v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->copyFromRawData([BLcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;III)V

    .line 117
    iget-object p6, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->message:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    invoke-static {p6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->flipBits8(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;)V

    .line 118
    iget-object p6, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->ecc:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    invoke-static {p6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->flipBits8(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;)V

    .line 120
    iget-object p6, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->rscodes:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;

    iget-object p7, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->message:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    iget-object v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->ecc:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    invoke-virtual {p6, p7, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->correct(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;)Z

    move-result p6

    if-nez p6, :cond_0

    return p2

    .line 123
    :cond_0
    iget p6, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->totalErrorBits:I

    iget-object p7, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->rscodes:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;

    invoke-virtual {p7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->getTotalErrors()I

    move-result p7

    add-int/2addr p6, p7

    iput p6, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->totalErrorBits:I

    .line 125
    iget-object p6, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->message:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    invoke-static {p6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->flipBits8(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;)V

    .line 126
    iget-object p6, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->message:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    iget-object p7, p6, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->corrected:[B

    iget p6, p6, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    invoke-static {p7, p2, v2, p4, p6}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    .line 127
    iget-object p6, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->message:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    iget p6, p6, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    add-int/2addr p4, p6

    add-int/lit8 v0, v0, 0x1

    move p7, v6

    move p6, v7

    goto :goto_0

    :cond_1
    move-object v1, p0

    const/4 p1, 0x1

    return p1
.end method

.method private decodeByte(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;I)I
    .locals 2

    .line 315
    iget p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->version:I

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeEncoder;->getLengthBitsBytes(I)I

    move-result p1

    .line 316
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->utils:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->encodingEci:Ljava/lang/String;

    iput-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->encodingEci:Ljava/lang/String;

    .line 317
    invoke-virtual {v0, p2, p3, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->decodeByte(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;II)I

    move-result p1

    return p1
.end method

.method private decodeKanji(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;I)I
    .locals 1

    .line 328
    iget p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->version:I

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeEncoder;->getLengthBitsKanji(I)I

    move-result p1

    .line 329
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->utils:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;

    invoke-virtual {v0, p2, p3, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->decodeKanji(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;II)I

    move-result p1

    return p1
.end method

.method private decodeNumeric(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;I)I
    .locals 1

    .line 291
    iget p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->version:I

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeEncoder;->getLengthBitsNumeric(I)I

    move-result p1

    .line 292
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->utils:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;

    invoke-virtual {v0, p2, p3, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->decodeNumeric(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;II)I

    move-result p1

    return p1
.end method

.method private updateModeLogic(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;)Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;
    .locals 1

    if-ne p1, p2, :cond_0

    return-object p1

    .line 242
    :cond_0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->UNKNOWN:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    if-ne p1, v0, :cond_1

    return-object p2

    .line 245
    :cond_1
    sget-object p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->MIXED:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    return-object p1
.end method


# virtual methods
.method public applyErrorCorrection(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)Z
    .locals 14

    .line 80
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->VERSION_INFO:[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->version:I

    aget-object v0, v0, v1

    .line 81
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->levels:Ljava/util/Map;

    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->error:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;

    invoke-interface {v1, v2}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$BlockInfo;

    invoke-static {v1}, Ljava/util/Objects;->requireNonNull(Ljava/lang/Object;)Ljava/lang/Object;

    .line 83
    iget v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$BlockInfo;->codewords:I

    .line 84
    iget v5, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$BlockInfo;->dataCodewords:I

    sub-int v3, v2, v5

    .line 86
    iget v6, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$BlockInfo;->blocks:I

    add-int/lit8 v1, v2, 0x1

    add-int/lit8 v11, v5, 0x1

    .line 90
    iget v0, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->codewords:I

    mul-int/2addr v2, v6

    sub-int/2addr v0, v2

    div-int/2addr v0, v1

    add-int v10, v6, v0

    mul-int v1, v5, v6

    mul-int v2, v11, v0

    add-int v9, v1, v2

    .line 94
    new-array v2, v9, [B

    iput-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->corrected:[B

    .line 96
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->ecc:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    invoke-virtual {v2, v3}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->resize(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    .line 97
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->rscodes:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;

    invoke-virtual {v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->generator(I)V

    const/4 v2, 0x0

    .line 99
    iput v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->totalErrorBits:I

    const/4 v7, 0x0

    const/4 v8, 0x0

    move-object v3, p0

    move-object v4, p1

    .line 100
    invoke-direct/range {v3 .. v10}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->decodeBlocks(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;IIIIII)Z

    move-result p1

    if-nez p1, :cond_0

    return v2

    :cond_0
    move-object v7, v4

    move v12, v9

    move v13, v10

    move v8, v11

    move v9, v0

    move v10, v1

    move v11, v6

    move-object v6, p0

    .line 103
    invoke-direct/range {v6 .. v13}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->decodeBlocks(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;IIIIII)Z

    move-result p1

    move-object v3, v6

    if-nez p1, :cond_1

    return v2

    .line 106
    :cond_1
    iget p1, v3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->totalErrorBits:I

    iput p1, v4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->totalBitErrors:I

    const/4 p1, 0x1

    return p1
.end method

.method checkPaddingBytes(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;I)Z
    .locals 7

    const/4 v0, 0x1

    move v1, v0

    .line 261
    :goto_0
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->corrected:[B

    array-length v3, v2

    if-ge p2, v3, :cond_3

    const/4 v3, 0x0

    const/16 v4, 0x37

    if-eqz v1, :cond_0

    .line 263
    aget-byte v2, v2, p2

    and-int/lit16 v2, v2, 0xff

    if-eq v4, v2, :cond_2

    return v3

    .line 266
    :cond_0
    aget-byte v2, v2, p2

    and-int/lit16 v5, v2, 0xff

    const/16 v6, 0x88

    if-eq v6, v5, :cond_2

    and-int/lit16 v1, v2, 0xff

    if-ne v4, v1, :cond_1

    move v1, v0

    goto :goto_1

    :cond_1
    return v3

    :cond_2
    :goto_1
    xor-int/2addr v1, v0

    add-int/lit8 p2, p2, 0x1

    goto :goto_0

    :cond_3
    return v0
.end method

.method decodeEci(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;I)I
    .locals 6

    const/16 v0, 0x8

    const/4 v1, 0x1

    .line 343
    invoke-virtual {p1, p2, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->read(IIZ)I

    move-result v2

    add-int/2addr p2, v0

    move v3, v1

    :goto_0
    rsub-int/lit8 v4, v3, 0x7

    shl-int v4, v1, v4

    and-int/2addr v4, v2

    if-eqz v4, :cond_0

    add-int/lit8 v3, v3, 0x1

    goto :goto_0

    :cond_0
    if-le v3, v1, :cond_1

    add-int/lit8 v4, v3, -0x1

    shl-int/2addr v2, v4

    shr-int/2addr v2, v4

    :cond_1
    move v4, v1

    :goto_1
    if-ge v4, v3, :cond_2

    shl-int/lit8 v2, v2, 0x8

    .line 360
    invoke-virtual {p1, p2, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->read(IIZ)I

    move-result v5

    or-int/2addr v2, v5

    add-int/lit8 p2, p2, 0x8

    add-int/lit8 v4, v4, 0x1

    goto :goto_1

    .line 364
    :cond_2
    invoke-static {v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/EciEncoding;->getEciCharacterSet(I)Ljava/lang/String;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->encodingEci:Ljava/lang/String;

    return p2
.end method

.method public decodeMessage(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)Z
    .locals 5

    .line 148
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->verbose:Ljava/io/PrintStream;

    const/4 v1, 0x0

    if-eqz v0, :cond_0

    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppCorner:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v2, v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v2

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "decodeMessage: qr.corner="

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v3, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v2}, Ljava/io/PrintStream;->println(Ljava/lang/String;)V

    :cond_0
    const/4 v0, 0x0

    .line 149
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->encodingEci:Ljava/lang/String;

    .line 151
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->utils:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->workString:Ljava/lang/StringBuilder;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->setLength(I)V

    .line 155
    :try_start_0
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->decideMessageBits(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)I

    move-result v0

    if-gez v0, :cond_1

    return v1

    .line 160
    :cond_1
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->alignToBytes(I)I

    move-result v0

    .line 161
    div-int/lit8 v0, v0, 0x8

    .line 164
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->utils:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;

    iget-object v2, v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->workString:Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    iput-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->message:Ljava/lang/String;

    .line 167
    iget-boolean v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->ignorePaddingBytes:Z

    if-nez v2, :cond_2

    invoke-virtual {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->checkPaddingBytes(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;I)Z

    move-result v0

    if-nez v0, :cond_2

    .line 168
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->READING_PADDING:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    iput-object v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->failureCause:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;
    :try_end_0
    .catch Ljava/lang/RuntimeException; {:try_start_0 .. :try_end_0} :catch_0

    return v1

    :catch_0
    move-exception v0

    goto :goto_0

    :cond_2
    const/4 p1, 0x1

    return p1

    .line 174
    :goto_0
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->verbose:Ljava/io/PrintStream;

    if-eqz v2, :cond_3

    .line 175
    invoke-virtual {v0, v2}, Ljava/lang/Throwable;->printStackTrace(Ljava/io/PrintStream;)V

    .line 177
    :cond_3
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->DECODING_MESSAGE:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    iput-object v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->failureCause:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    .line 178
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeDecoderBits;->utils:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->workString:Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->message:Ljava/lang/String;

    return v1
.end method
