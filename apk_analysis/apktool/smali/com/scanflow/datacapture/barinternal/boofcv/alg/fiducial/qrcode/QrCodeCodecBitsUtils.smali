.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;
.super Ljava/lang/Object;
.source "QrCodeCodecBitsUtils.java"


# static fields
.field static final asciiEncoder:Ljava/nio/charset/CharsetEncoder;


# instance fields
.field public defaultEncoding:Ljava/lang/String;

.field encodingEci:Ljava/lang/String;

.field public failureCause:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

.field forceEncoding:Ljava/lang/String;

.field public selectedByteEncoding:Ljava/lang/String;

.field verbose:Ljava/io/PrintStream;

.field public final workString:Ljava/lang/StringBuilder;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 66
    const-string v0, "ISO-8859-1"

    invoke-static {v0}, Ljava/nio/charset/Charset;->forName(Ljava/lang/String;)Ljava/nio/charset/Charset;

    move-result-object v0

    invoke-virtual {v0}, Ljava/nio/charset/Charset;->newEncoder()Ljava/nio/charset/CharsetEncoder;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->asciiEncoder:Ljava/nio/charset/CharsetEncoder;

    return-void
.end method

.method public constructor <init>(Ljava/lang/String;Ljava/lang/String;)V
    .locals 1

    .line 70
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 45
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->NONE:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->failureCause:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    .line 46
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->workString:Ljava/lang/StringBuilder;

    .line 49
    const-string v0, ""

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->selectedByteEncoding:Ljava/lang/String;

    const/4 v0, 0x0

    .line 68
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->verbose:Ljava/io/PrintStream;

    .line 71
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->forceEncoding:Ljava/lang/String;

    .line 72
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->defaultEncoding:Ljava/lang/String;

    return-void
.end method

.method public static flipBits8(I)B
    .locals 3

    .line 327
    const/4 v0, 0x0

    move v1, v0

    :goto_0
    const/16 v2, 0x8

    if-ge v0, v2, :cond_0

    shl-int/lit8 v1, v1, 0x1

    and-int/lit8 v2, p0, 0x1

    or-int/2addr v1, v2

    shr-int/lit8 p0, p0, 0x1

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    int-to-byte p0, v1

    return p0
.end method

.method public static flipBits8(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;)V
    .locals 1

    .line 323
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    iget p0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    invoke-static {v0, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->flipBits8([BI)V

    return-void
.end method

.method public static flipBits8([BI)V
    .locals 2

    const/4 v0, 0x0

    :goto_0
    if-ge v0, p1, :cond_0

    .line 318
    aget-byte v1, p0, v0

    and-int/lit16 v1, v1, 0xff

    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->flipBits8(I)B

    move-result v1

    aput-byte v1, p0, v0

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method

.method private selectByteEncoding([B)Ljava/lang/String;
    .locals 1

    .line 215
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->encodingEci:Ljava/lang/String;

    if-eqz v0, :cond_0

    return-object v0

    .line 218
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->forceEncoding:Ljava/lang/String;

    if-eqz v0, :cond_1

    return-object v0

    .line 221
    :cond_1
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/EciEncoding;->isValidUTF8([B)Z

    move-result p1

    if-eqz p1, :cond_2

    .line 222
    const-string p1, "UTF8"

    return-object p1

    .line 224
    :cond_2
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->defaultEncoding:Ljava/lang/String;

    return-object p1
.end method

.method public static valueToAlphanumeric(I)C
    .locals 3

    if-ltz p0, :cond_0

    const/16 v0, 0x2d

    if-ge p0, v0, :cond_0

    .line 339
    const-string v0, "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ $%*+-./:"

    invoke-virtual {v0, p0}, Ljava/lang/String;->charAt(I)C

    move-result p0

    return p0

    .line 338
    :cond_0
    new-instance v0, Ljava/lang/RuntimeException;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Alphanumeric: Value out of range. value="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    invoke-direct {v0, p0}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw v0
.end method


# virtual methods
.method public decodeAlphanumeric(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;II)I
    .locals 4

    const/4 v0, 0x1

    .line 137
    invoke-virtual {p1, p2, p3, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->read(IIZ)I

    move-result v1

    add-int/2addr p2, p3

    :goto_0
    const/4 p3, 0x2

    const/4 v2, -0x1

    if-lt v1, p3, :cond_2

    .line 141
    iget p3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->size:I

    add-int/lit8 v3, p2, 0xb

    if-ge p3, v3, :cond_1

    .line 142
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->verbose:Ljava/io/PrintStream;

    if-eqz p1, :cond_0

    invoke-static {p3}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p2

    filled-new-array {p2}, [Ljava/lang/Object;

    move-result-object p2

    const-string p3, "overflow: alphanumeric data.size=%d\n"

    invoke-virtual {p1, p3, p2}, Ljava/io/PrintStream;->printf(Ljava/lang/String;[Ljava/lang/Object;)Ljava/io/PrintStream;

    .line 143
    :cond_0
    sget-object p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->MESSAGE_OVERFLOW:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->failureCause:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    return v2

    :cond_1
    const/16 p3, 0xb

    .line 146
    invoke-virtual {p1, p2, p3, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->read(IIZ)I

    move-result p2

    .line 149
    div-int/lit8 p3, p2, 0x2d

    mul-int/lit8 v2, p3, 0x2d

    sub-int/2addr p2, v2

    .line 152
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->workString:Ljava/lang/StringBuilder;

    invoke-static {p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->valueToAlphanumeric(I)C

    move-result p3

    invoke-virtual {v2, p3}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    .line 153
    iget-object p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->workString:Ljava/lang/StringBuilder;

    invoke-static {p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->valueToAlphanumeric(I)C

    move-result p2

    invoke-virtual {p3, p2}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    add-int/lit8 v1, v1, -0x2

    move p2, v3

    goto :goto_0

    :cond_2
    if-ne v1, v0, :cond_4

    .line 158
    iget p3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->size:I

    add-int/lit8 v1, p2, 0x6

    if-ge p3, v1, :cond_3

    .line 159
    sget-object p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->MESSAGE_OVERFLOW:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->failureCause:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    return v2

    :cond_3
    const/4 p3, 0x6

    .line 162
    invoke-virtual {p1, p2, p3, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->read(IIZ)I

    move-result p1

    .line 164
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->workString:Ljava/lang/StringBuilder;

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->valueToAlphanumeric(I)C

    move-result p1

    invoke-virtual {p2, p1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    return v1

    :cond_4
    return p2
.end method

.method public decodeByte(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;II)I
    .locals 6

    const/4 v0, 0x1

    .line 176
    invoke-virtual {p1, p2, p3, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->read(IIZ)I

    move-result v1

    add-int/2addr p2, p3

    mul-int/lit8 p3, v1, 0x8

    .line 179
    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->size:I

    sub-int v3, v2, p2

    const/4 v4, -0x1

    if-le p3, v3, :cond_1

    .line 180
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->verbose:Ljava/io/PrintStream;

    if-eqz p1, :cond_0

    invoke-static {v2}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p2

    filled-new-array {p2}, [Ljava/lang/Object;

    move-result-object p2

    const-string p3, "overflow: byte data.size=%d\n"

    invoke-virtual {p1, p3, p2}, Ljava/io/PrintStream;->printf(Ljava/lang/String;[Ljava/lang/Object;)Ljava/io/PrintStream;

    .line 181
    :cond_0
    sget-object p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->MESSAGE_OVERFLOW:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->failureCause:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    return v4

    .line 185
    :cond_1
    new-array p3, v1, [B

    const/4 v2, 0x0

    move v3, v2

    :goto_0
    if-ge v3, v1, :cond_2

    const/16 v5, 0x8

    .line 188
    invoke-virtual {p1, p2, v5, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->read(IIZ)I

    move-result v5

    int-to-byte v5, v5

    aput-byte v5, p3, v3

    add-int/lit8 p2, p2, 0x8

    add-int/lit8 v3, v3, 0x1

    goto :goto_0

    .line 192
    :cond_2
    invoke-direct {p0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->selectByteEncoding([B)Ljava/lang/String;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->selectedByteEncoding:Ljava/lang/String;

    .line 194
    :try_start_0
    const-string v0, "binary"

    invoke-virtual {p1, v0}, Ljava/lang/String;->equalsIgnoreCase(Ljava/lang/String;)Z

    move-result p1

    if-eqz p1, :cond_4

    .line 197
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->workString:Ljava/lang/StringBuilder;

    invoke-virtual {p1}, Ljava/lang/StringBuilder;->length()I

    move-result v0

    add-int/2addr v0, v1

    invoke-virtual {p1, v0}, Ljava/lang/StringBuilder;->ensureCapacity(I)V

    :goto_1
    if-ge v2, v1, :cond_3

    .line 199
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->workString:Ljava/lang/StringBuilder;

    aget-byte v0, p3, v2

    and-int/lit16 v0, v0, 0xff

    int-to-char v0, v0

    invoke-virtual {p1, v0}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    :cond_3
    return p2

    .line 202
    :cond_4
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->workString:Ljava/lang/StringBuilder;

    new-instance v0, Ljava/lang/String;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->selectedByteEncoding:Ljava/lang/String;

    invoke-direct {v0, p3, v1}, Ljava/lang/String;-><init>([BLjava/lang/String;)V

    invoke-virtual {p1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;
    :try_end_0
    .catch Ljava/io/UnsupportedEncodingException; {:try_start_0 .. :try_end_0} :catch_0

    return p2

    .line 205
    :catch_0
    sget-object p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->STRING_ENCODING_UNAVAILABLE:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->failureCause:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    return v4
.end method

.method public decodeKanji(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;II)I
    .locals 6

    const/4 v0, 0x1

    .line 234
    invoke-virtual {p1, p2, p3, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->read(IIZ)I

    move-result v1

    add-int/2addr p2, p3

    mul-int/lit8 p3, v1, 0x2

    .line 237
    new-array p3, p3, [B

    const/4 v2, 0x0

    :goto_0
    const/4 v3, -0x1

    if-ge v2, v1, :cond_3

    .line 240
    iget v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->size:I

    add-int/lit8 v5, p2, 0xd

    if-ge v4, v5, :cond_1

    .line 241
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->verbose:Ljava/io/PrintStream;

    if-eqz p1, :cond_0

    invoke-static {v4}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p2

    filled-new-array {p2}, [Ljava/lang/Object;

    move-result-object p2

    const-string p3, "overflow: kanji data.size=%d\n"

    invoke-virtual {p1, p3, p2}, Ljava/io/PrintStream;->printf(Ljava/lang/String;[Ljava/lang/Object;)Ljava/io/PrintStream;

    .line 242
    :cond_0
    sget-object p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->MESSAGE_OVERFLOW:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->failureCause:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    return v3

    :cond_1
    const/16 v3, 0xd

    .line 245
    invoke-virtual {p1, p2, v3, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->read(IIZ)I

    move-result p2

    .line 248
    div-int/lit16 v3, p2, 0xc0

    shl-int/lit8 v3, v3, 0x8

    rem-int/lit16 p2, p2, 0xc0

    or-int/2addr p2, v3

    const/16 v3, 0x1f00

    if-ge p2, v3, :cond_2

    const v3, 0x8140

    :goto_1
    add-int/2addr p2, v3

    goto :goto_2

    :cond_2
    const v3, 0xc140

    goto :goto_1

    :goto_2
    mul-int/lit8 v3, v2, 0x2

    shr-int/lit8 v4, p2, 0x8

    int-to-byte v4, v4

    .line 257
    aput-byte v4, p3, v3

    add-int/2addr v3, v0

    int-to-byte p2, p2

    .line 258
    aput-byte p2, p3, v3

    add-int/lit8 v2, v2, 0x1

    move p2, v5

    goto :goto_0

    .line 263
    :cond_3
    :try_start_0
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->workString:Ljava/lang/StringBuilder;

    new-instance v0, Ljava/lang/String;

    const-string v1, "Shift_JIS"

    invoke-direct {v0, p3, v1}, Ljava/lang/String;-><init>([BLjava/lang/String;)V

    invoke-virtual {p1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;
    :try_end_0
    .catch Ljava/io/UnsupportedEncodingException; {:try_start_0 .. :try_end_0} :catch_0

    return p2

    .line 265
    :catch_0
    sget-object p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->KANJI_UNAVAILABLE:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->failureCause:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    return v3
.end method

.method public decodeNumeric(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;II)I
    .locals 5

    const/4 v0, 0x1

    .line 82
    invoke-virtual {p1, p2, p3, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->read(IIZ)I

    move-result v1

    add-int/2addr p2, p3

    :goto_0
    const/4 p3, 0x3

    const/4 v2, -0x1

    if-lt v1, p3, :cond_2

    .line 86
    iget p3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->size:I

    add-int/lit8 v3, p2, 0xa

    if-ge p3, v3, :cond_1

    .line 87
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->verbose:Ljava/io/PrintStream;

    if-eqz p1, :cond_0

    invoke-static {p3}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p2

    filled-new-array {p2}, [Ljava/lang/Object;

    move-result-object p2

    const-string p3, "overflow: numeric data.size=%d\n"

    invoke-virtual {p1, p3, p2}, Ljava/io/PrintStream;->printf(Ljava/lang/String;[Ljava/lang/Object;)Ljava/io/PrintStream;

    .line 88
    :cond_0
    sget-object p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->MESSAGE_OVERFLOW:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->failureCause:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    return v2

    :cond_1
    const/16 p3, 0xa

    .line 91
    invoke-virtual {p1, p2, p3, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->read(IIZ)I

    move-result p2

    .line 94
    div-int/lit8 p3, p2, 0x64

    mul-int/lit8 v2, p3, 0x64

    sub-int/2addr p2, v2

    .line 95
    div-int/lit8 v2, p2, 0xa

    mul-int/lit8 v4, v2, 0xa

    sub-int/2addr p2, v4

    .line 98
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->workString:Ljava/lang/StringBuilder;

    add-int/lit8 p3, p3, 0x30

    int-to-char p3, p3

    invoke-virtual {v4, p3}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    .line 99
    iget-object p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->workString:Ljava/lang/StringBuilder;

    add-int/lit8 v2, v2, 0x30

    int-to-char v2, v2

    invoke-virtual {p3, v2}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    .line 100
    iget-object p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->workString:Ljava/lang/StringBuilder;

    add-int/lit8 p2, p2, 0x30

    int-to-char p2, p2

    invoke-virtual {p3, p2}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    add-int/lit8 v1, v1, -0x3

    move p2, v3

    goto :goto_0

    :cond_2
    const/4 p3, 0x2

    if-ne v1, p3, :cond_4

    .line 106
    iget p3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->size:I

    add-int/lit8 v1, p2, 0x7

    if-ge p3, v1, :cond_3

    .line 107
    sget-object p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->MESSAGE_OVERFLOW:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->failureCause:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    return v2

    :cond_3
    const/4 p3, 0x7

    .line 110
    invoke-virtual {p1, p2, p3, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->read(IIZ)I

    move-result p1

    .line 113
    div-int/lit8 p2, p1, 0xa

    mul-int/lit8 p3, p2, 0xa

    sub-int/2addr p1, p3

    .line 115
    iget-object p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->workString:Ljava/lang/StringBuilder;

    add-int/lit8 p2, p2, 0x30

    int-to-char p2, p2

    invoke-virtual {p3, p2}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    .line 116
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->workString:Ljava/lang/StringBuilder;

    add-int/lit8 p1, p1, 0x30

    int-to-char p1, p1

    invoke-virtual {p2, p1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    return v1

    :cond_4
    if-ne v1, v0, :cond_6

    .line 118
    iget p3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->size:I

    add-int/lit8 v1, p2, 0x4

    if-ge p3, v1, :cond_5

    .line 119
    sget-object p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->MESSAGE_OVERFLOW:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->failureCause:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    return v2

    :cond_5
    const/4 p3, 0x4

    .line 122
    invoke-virtual {p1, p2, p3, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PackedBits8;->read(IIZ)I

    move-result p1

    .line 124
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodecBitsUtils;->workString:Ljava/lang/StringBuilder;

    add-int/lit8 p1, p1, 0x30

    int-to-char p1, p1

    invoke-virtual {p2, p1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    return v1

    :cond_6
    return p2
.end method
