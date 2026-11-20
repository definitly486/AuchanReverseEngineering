.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/EciEncoding;
.super Ljava/lang/Object;
.source "EciEncoding.java"


# direct methods
.method public static getEciCharacterSet(I)Ljava/lang/String;
    .locals 3

    const/16 v0, 0xaa

    if-eq p0, v0, :cond_0

    packed-switch p0, :pswitch_data_0

    packed-switch p0, :pswitch_data_1

    .line 98
    new-instance v0, Ljava/lang/IllegalArgumentException;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Unknown ECI designator "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    invoke-direct {v0, p0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 97
    :pswitch_0
    const-string p0, "EUC_KR"

    return-object p0

    .line 96
    :pswitch_1
    const-string p0, "GB18030"

    return-object p0

    .line 95
    :pswitch_2
    const-string p0, "Big5"

    return-object p0

    .line 93
    :pswitch_3
    const-string p0, "UTF8"

    return-object p0

    .line 92
    :pswitch_4
    const-string p0, "UnicodeBigUnmarked"

    return-object p0

    .line 91
    :pswitch_5
    const-string p0, "Cp1256"

    return-object p0

    .line 90
    :pswitch_6
    const-string p0, "Cp1252"

    return-object p0

    .line 89
    :pswitch_7
    const-string p0, "Cp1251"

    return-object p0

    .line 88
    :pswitch_8
    const-string p0, "Cp1250"

    return-object p0

    .line 87
    :pswitch_9
    const-string p0, "SJIS"

    return-object p0

    .line 86
    :pswitch_a
    const-string p0, "ISO8859_16"

    return-object p0

    .line 85
    :pswitch_b
    const-string p0, "ISO8859_15"

    return-object p0

    .line 84
    :pswitch_c
    const-string p0, "ISO8859_14"

    return-object p0

    .line 83
    :pswitch_d
    const-string p0, "ISO8859_13"

    return-object p0

    .line 82
    :pswitch_e
    const-string p0, "ISO8859_12"

    return-object p0

    .line 81
    :pswitch_f
    const-string p0, "ISO8859_11"

    return-object p0

    .line 80
    :pswitch_10
    const-string p0, "ISO8859_10"

    return-object p0

    .line 79
    :pswitch_11
    const-string p0, "ISO8859_9"

    return-object p0

    .line 78
    :pswitch_12
    const-string p0, "ISO8859_8"

    return-object p0

    .line 77
    :pswitch_13
    const-string p0, "ISO8859_7"

    return-object p0

    .line 76
    :pswitch_14
    const-string p0, "ISO8859_6"

    return-object p0

    .line 75
    :pswitch_15
    const-string p0, "ISO8859_5"

    return-object p0

    .line 74
    :pswitch_16
    const-string p0, "ISO8859_4"

    return-object p0

    .line 73
    :pswitch_17
    const-string p0, "ISO8859_3"

    return-object p0

    .line 72
    :pswitch_18
    const-string p0, "ISO8859_2"

    return-object p0

    .line 71
    :pswitch_19
    const-string p0, "ISO8859_1"

    return-object p0

    .line 70
    :pswitch_1a
    const-string p0, "Cp437"

    return-object p0

    .line 94
    :cond_0
    :pswitch_1b
    const-string p0, "ASCII"

    return-object p0

    nop

    :pswitch_data_0
    .packed-switch 0x0
        :pswitch_1a
        :pswitch_19
        :pswitch_1a
        :pswitch_19
        :pswitch_18
        :pswitch_17
        :pswitch_16
        :pswitch_15
        :pswitch_14
        :pswitch_13
        :pswitch_12
        :pswitch_11
        :pswitch_10
        :pswitch_f
        :pswitch_e
        :pswitch_d
        :pswitch_c
        :pswitch_b
        :pswitch_a
    .end packed-switch

    :pswitch_data_1
    .packed-switch 0x14
        :pswitch_9
        :pswitch_8
        :pswitch_7
        :pswitch_6
        :pswitch_5
        :pswitch_4
        :pswitch_3
        :pswitch_1b
        :pswitch_2
        :pswitch_1
        :pswitch_0
    .end packed-switch
.end method

.method public static isValidUTF8([B)Z
    .locals 8

    const/4 v0, 0x0

    move v1, v0

    .line 37
    :cond_0
    array-length v2, p0

    if-ge v1, v2, :cond_6

    .line 40
    aget-byte v2, p0, v1

    and-int/lit16 v2, v2, 0xff

    shr-int/lit8 v3, v2, 0x3

    const/16 v4, 0x1e

    const/4 v5, 0x2

    const/4 v6, 0x6

    const/4 v7, 0x1

    if-ne v3, v4, :cond_1

    const/4 v2, 0x4

    goto :goto_0

    :cond_1
    shr-int/lit8 v3, v2, 0x4

    const/16 v4, 0xe

    if-ne v3, v4, :cond_2

    const/4 v2, 0x3

    goto :goto_0

    :cond_2
    shr-int/lit8 v3, v2, 0x5

    if-ne v3, v6, :cond_3

    move v2, v5

    goto :goto_0

    :cond_3
    shr-int/lit8 v2, v2, 0x7

    if-nez v2, :cond_6

    move v2, v7

    :goto_0
    move v3, v7

    :goto_1
    if-ge v3, v2, :cond_5

    add-int v4, v1, v3

    .line 54
    aget-byte v4, p0, v4

    and-int/lit16 v4, v4, 0xff

    shr-int/2addr v4, v6

    if-eq v4, v5, :cond_4

    return v0

    :cond_4
    add-int/lit8 v3, v3, 0x1

    goto :goto_1

    :cond_5
    add-int/2addr v1, v2

    .line 58
    array-length v2, p0

    if-ne v1, v2, :cond_0

    return v7

    :cond_6
    return v0
.end method
