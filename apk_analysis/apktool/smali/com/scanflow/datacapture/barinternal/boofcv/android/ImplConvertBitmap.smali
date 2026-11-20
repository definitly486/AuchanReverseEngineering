.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/android/ImplConvertBitmap;
.super Ljava/lang/Object;
.source "ImplConvertBitmap.java"


# static fields
.field private static final table5:[I

.field private static final table6:[I


# direct methods
.method static constructor <clinit>()V
    .locals 6

    const/16 v0, 0x100

    .line 37
    new-array v1, v0, [I

    sput-object v1, Lcom/scanflow/datacapture/barinternal/boofcv/android/ImplConvertBitmap;->table5:[I

    .line 38
    new-array v0, v0, [I

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/android/ImplConvertBitmap;->table6:[I

    const/4 v0, 0x0

    .line 41
    :goto_0
    sget-object v1, Lcom/scanflow/datacapture/barinternal/boofcv/android/ImplConvertBitmap;->table5:[I

    array-length v2, v1

    if-ge v0, v2, :cond_0

    mul-int/lit8 v2, v0, 0x1f

    int-to-double v2, v2

    const-wide v4, 0x406fe00000000000L    # 255.0

    div-double/2addr v2, v4

    .line 43
    invoke-static {v2, v3}, Ljava/lang/Math;->round(D)J

    move-result-wide v2

    long-to-int v2, v2

    aput v2, v1, v0

    .line 44
    sget-object v1, Lcom/scanflow/datacapture/barinternal/boofcv/android/ImplConvertBitmap;->table6:[I

    mul-int/lit8 v2, v0, 0x3f

    int-to-double v2, v2

    div-double/2addr v2, v4

    invoke-static {v2, v3}, Ljava/lang/Math;->round(D)J

    move-result-wide v2

    long-to-int v2, v2

    aput v2, v1, v0

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static arrayToGray([BLandroid/graphics/Bitmap$Config;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
    .locals 12

    .line 453
    iget v0, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    .line 454
    iget v1, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    .line 458
    sget-object v2, Lcom/scanflow/datacapture/barinternal/boofcv/android/ImplConvertBitmap$1;->$SwitchMap$android$graphics$Bitmap$Config:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result v3

    aget v2, v2, v3

    const/4 v3, 0x1

    const/4 v4, 0x3

    const/4 v5, 0x0

    if-eq v2, v3, :cond_4

    const/4 v3, 0x2

    if-eq v2, v3, :cond_2

    if-eq v2, v4, :cond_1

    const/4 p0, 0x4

    if-eq v2, p0, :cond_0

    .line 499
    new-instance p0, Ljava/lang/RuntimeException;

    new-instance p2, Ljava/lang/StringBuilder;

    invoke-direct {p2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v0, "Unsupported format: "

    invoke-virtual {p2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {p2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {p0, p1}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw p0

    .line 496
    :cond_0
    new-instance p0, Ljava/lang/RuntimeException;

    const-string p1, "Isn\'t 4444 deprecated?"

    invoke-direct {p0, p1}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw p0

    .line 493
    :cond_1
    new-instance p0, Ljava/lang/RuntimeException;

    const-string p1, "ALPHA_8 seems to have some weired internal format and is not currently supported"

    invoke-direct {p0, p1}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw p0

    :cond_2
    move p1, v5

    move v2, p1

    :goto_0
    if-ge p1, v0, :cond_6

    .line 476
    iget v3, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v6, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v6, p1

    add-int/2addr v3, v6

    move v6, v5

    :goto_1
    if-ge v6, v1, :cond_3

    add-int/lit8 v7, v2, 0x1

    .line 479
    aget-byte v8, p0, v2

    and-int/lit16 v8, v8, 0xff

    add-int/lit8 v2, v2, 0x2

    aget-byte v7, p0, v7

    and-int/lit16 v7, v7, 0xff

    shl-int/lit8 v7, v7, 0x8

    or-int/2addr v7, v8

    shr-int/lit8 v8, v7, 0xb

    mul-int/lit16 v8, v8, 0x100

    .line 482
    div-int/lit8 v8, v8, 0x20

    and-int/lit16 v9, v7, 0x7e0

    shr-int/lit8 v9, v9, 0x5

    mul-int/lit16 v9, v9, 0x100

    .line 483
    div-int/lit8 v9, v9, 0x40

    and-int/lit8 v7, v7, 0x1f

    mul-int/lit16 v7, v7, 0x100

    .line 484
    div-int/lit8 v7, v7, 0x20

    .line 486
    iget-object v10, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v11, v3, 0x1

    add-int/2addr v8, v9

    add-int/2addr v8, v7

    div-int/2addr v8, v4

    int-to-byte v7, v8

    aput-byte v7, v10, v3

    add-int/lit8 v6, v6, 0x1

    move v3, v11

    goto :goto_1

    :cond_3
    add-int/lit8 p1, p1, 0x1

    goto :goto_0

    :cond_4
    move p1, v5

    :goto_2
    if-ge v5, v0, :cond_6

    .line 461
    iget v2, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v3, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v3, v5

    add-int/2addr v2, v3

    add-int v3, v2, v1

    :goto_3
    if-ge v2, v3, :cond_5

    add-int/lit8 v6, p1, 0x1

    .line 465
    aget-byte v7, p0, p1

    and-int/lit16 v7, v7, 0xff

    add-int/lit8 v8, p1, 0x2

    aget-byte v6, p0, v6

    and-int/lit16 v6, v6, 0xff

    add-int/2addr v7, v6

    aget-byte v6, p0, v8

    and-int/lit16 v6, v6, 0xff

    add-int/2addr v7, v6

    div-int/2addr v7, v4

    .line 467
    iget-object v6, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v8, v2, 0x1

    int-to-byte v7, v7

    aput-byte v7, v6, v2

    add-int/lit8 p1, p1, 0x4

    move v2, v8

    goto :goto_3

    :cond_5
    add-int/lit8 v5, v5, 0x1

    goto :goto_2

    :cond_6
    return-void
.end method
