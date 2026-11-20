.class public final Lcom/google/mediapipe/framework/AndroidPacketGetter;
.super Ljava/lang/Object;
.source "AndroidPacketGetter.java"


# direct methods
.method private constructor <init>()V
    .locals 0

    .line 195
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static copyGray8ToBitmap(Lcom/google/mediapipe/framework/Packet;Landroid/graphics/Bitmap;)V
    .locals 6

    .line 84
    invoke-virtual {p1}, Landroid/graphics/Bitmap;->isMutable()Z

    move-result v0

    const-string v1, "Input bitmap should be mutable."

    invoke-static {v0, v1}, Lcom/google/common/base/Preconditions;->checkArgument(ZLjava/lang/Object;)V

    .line 86
    invoke-virtual {p1}, Landroid/graphics/Bitmap;->getConfig()Landroid/graphics/Bitmap$Config;

    move-result-object v0

    sget-object v1, Landroid/graphics/Bitmap$Config;->ALPHA_8:Landroid/graphics/Bitmap$Config;

    const/4 v2, 0x0

    const/4 v3, 0x1

    if-ne v0, v1, :cond_0

    move v0, v3

    goto :goto_0

    :cond_0
    move v0, v2

    :goto_0
    const-string v1, "Input bitmap should be of type ALPHA_8."

    .line 85
    invoke-static {v0, v1}, Lcom/google/common/base/Preconditions;->checkArgument(ZLjava/lang/Object;)V

    .line 87
    invoke-static {p0}, Lcom/google/mediapipe/framework/PacketGetter;->getImageWidth(Lcom/google/mediapipe/framework/Packet;)I

    move-result v0

    .line 88
    invoke-static {p0}, Lcom/google/mediapipe/framework/PacketGetter;->getImageHeight(Lcom/google/mediapipe/framework/Packet;)I

    move-result v1

    .line 89
    invoke-virtual {p1}, Landroid/graphics/Bitmap;->getByteCount()I

    move-result v4

    mul-int v5, v0, v1

    if-ne v4, v5, :cond_1

    move v2, v3

    :cond_1
    const-string v3, "Input bitmap size mismatch."

    invoke-static {v2, v3}, Lcom/google/common/base/Preconditions;->checkArgument(ZLjava/lang/Object;)V

    .line 90
    invoke-static {p0, p1, v0, v1}, Lcom/google/mediapipe/framework/AndroidPacketGetter;->copyGray8ToBitmap(Lcom/google/mediapipe/framework/Packet;Landroid/graphics/Bitmap;II)V

    return-void
.end method

.method private static copyGray8ToBitmap(Lcom/google/mediapipe/framework/Packet;Landroid/graphics/Bitmap;II)V
    .locals 2

    mul-int v0, p2, p3

    .line 95
    invoke-static {v0}, Ljava/nio/ByteBuffer;->allocateDirect(I)Ljava/nio/ByteBuffer;

    move-result-object v0

    .line 96
    invoke-static {p0, v0}, Lcom/google/mediapipe/framework/PacketGetter;->getImageData(Lcom/google/mediapipe/framework/Packet;Ljava/nio/ByteBuffer;)Z

    move-result p0

    .line 100
    invoke-static {}, Ljava/util/Locale;->getDefault()Ljava/util/Locale;

    move-result-object v1

    .line 102
    invoke-static {p2}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p2

    .line 103
    invoke-static {p3}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p3

    filled-new-array {p2, p3}, [Ljava/lang/Object;

    move-result-object p2

    .line 99
    const-string p3, "Got error from getImageData, returning null Bitmap. Image width %d, height %d"

    invoke-static {v1, p3, p2}, Ljava/lang/String;->format(Ljava/util/Locale;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object p2

    .line 97
    invoke-static {p0, p2}, Lcom/google/common/base/Preconditions;->checkState(ZLjava/lang/Object;)V

    .line 104
    invoke-virtual {p1, v0}, Landroid/graphics/Bitmap;->copyPixelsFromBuffer(Ljava/nio/Buffer;)V

    return-void
.end method

.method public static copyRgbToBitmap(Lcom/google/mediapipe/framework/Packet;Landroid/graphics/Bitmap;)V
    .locals 6

    .line 129
    invoke-virtual {p1}, Landroid/graphics/Bitmap;->isMutable()Z

    move-result v0

    const-string v1, "Input bitmap should be mutable."

    invoke-static {v0, v1}, Lcom/google/common/base/Preconditions;->checkArgument(ZLjava/lang/Object;)V

    .line 131
    invoke-virtual {p1}, Landroid/graphics/Bitmap;->getConfig()Landroid/graphics/Bitmap$Config;

    move-result-object v0

    sget-object v1, Landroid/graphics/Bitmap$Config;->ARGB_8888:Landroid/graphics/Bitmap$Config;

    const/4 v2, 0x0

    const/4 v3, 0x1

    if-ne v0, v1, :cond_0

    move v0, v3

    goto :goto_0

    :cond_0
    move v0, v2

    :goto_0
    const-string v1, "Input bitmap should be of type ARGB_8888."

    .line 130
    invoke-static {v0, v1}, Lcom/google/common/base/Preconditions;->checkArgument(ZLjava/lang/Object;)V

    .line 132
    invoke-static {p0}, Lcom/google/mediapipe/framework/PacketGetter;->getImageWidth(Lcom/google/mediapipe/framework/Packet;)I

    move-result v0

    .line 133
    invoke-static {p0}, Lcom/google/mediapipe/framework/PacketGetter;->getImageHeight(Lcom/google/mediapipe/framework/Packet;)I

    move-result v1

    .line 134
    invoke-virtual {p1}, Landroid/graphics/Bitmap;->getByteCount()I

    move-result v4

    mul-int v5, v0, v1

    mul-int/lit8 v5, v5, 0x4

    if-ne v4, v5, :cond_1

    move v2, v3

    :cond_1
    const-string v3, "Input bitmap size mismatch."

    invoke-static {v2, v3}, Lcom/google/common/base/Preconditions;->checkArgument(ZLjava/lang/Object;)V

    .line 135
    invoke-static {p0, p1, v0, v1}, Lcom/google/mediapipe/framework/AndroidPacketGetter;->copyRgbToBitmap(Lcom/google/mediapipe/framework/Packet;Landroid/graphics/Bitmap;II)V

    return-void
.end method

.method private static copyRgbToBitmap(Lcom/google/mediapipe/framework/Packet;Landroid/graphics/Bitmap;II)V
    .locals 0

    mul-int/2addr p2, p3

    mul-int/lit8 p2, p2, 0x4

    .line 140
    invoke-static {p2}, Ljava/nio/ByteBuffer;->allocateDirect(I)Ljava/nio/ByteBuffer;

    move-result-object p2

    .line 141
    invoke-static {p0, p2}, Lcom/google/mediapipe/framework/PacketGetter;->getRgbaFromRgb(Lcom/google/mediapipe/framework/Packet;Ljava/nio/ByteBuffer;)Z

    .line 142
    invoke-virtual {p1, p2}, Landroid/graphics/Bitmap;->copyPixelsFromBuffer(Ljava/nio/Buffer;)V

    return-void
.end method

.method public static copyRgbaToBitmap(Lcom/google/mediapipe/framework/Packet;Landroid/graphics/Bitmap;)V
    .locals 6

    .line 168
    invoke-virtual {p1}, Landroid/graphics/Bitmap;->isMutable()Z

    move-result v0

    const-string v1, "Input bitmap should be mutable."

    invoke-static {v0, v1}, Lcom/google/common/base/Preconditions;->checkArgument(ZLjava/lang/Object;)V

    .line 170
    invoke-virtual {p1}, Landroid/graphics/Bitmap;->getConfig()Landroid/graphics/Bitmap$Config;

    move-result-object v0

    sget-object v1, Landroid/graphics/Bitmap$Config;->ARGB_8888:Landroid/graphics/Bitmap$Config;

    const/4 v2, 0x0

    const/4 v3, 0x1

    if-ne v0, v1, :cond_0

    move v0, v3

    goto :goto_0

    :cond_0
    move v0, v2

    :goto_0
    const-string v1, "Input bitmap should be of type ARGB_8888."

    .line 169
    invoke-static {v0, v1}, Lcom/google/common/base/Preconditions;->checkArgument(ZLjava/lang/Object;)V

    .line 171
    invoke-static {p0}, Lcom/google/mediapipe/framework/PacketGetter;->getImageWidth(Lcom/google/mediapipe/framework/Packet;)I

    move-result v0

    .line 172
    invoke-static {p0}, Lcom/google/mediapipe/framework/PacketGetter;->getImageHeight(Lcom/google/mediapipe/framework/Packet;)I

    move-result v1

    .line 173
    invoke-virtual {p1}, Landroid/graphics/Bitmap;->getByteCount()I

    move-result v4

    mul-int v5, v0, v1

    mul-int/lit8 v5, v5, 0x4

    if-ne v4, v5, :cond_1

    move v2, v3

    :cond_1
    const-string v3, "Input bitmap size mismatch."

    invoke-static {v2, v3}, Lcom/google/common/base/Preconditions;->checkArgument(ZLjava/lang/Object;)V

    .line 174
    invoke-static {p0, p1, v0, v1}, Lcom/google/mediapipe/framework/AndroidPacketGetter;->copyRgbaToBitmap(Lcom/google/mediapipe/framework/Packet;Landroid/graphics/Bitmap;II)V

    return-void
.end method

.method private static copyRgbaToBitmap(Lcom/google/mediapipe/framework/Packet;Landroid/graphics/Bitmap;II)V
    .locals 2

    mul-int v0, p2, p3

    mul-int/lit8 v0, v0, 0x4

    .line 180
    invoke-static {v0}, Ljava/nio/ByteBuffer;->allocateDirect(I)Ljava/nio/ByteBuffer;

    move-result-object v0

    .line 181
    invoke-static {}, Ljava/nio/ByteOrder;->nativeOrder()Ljava/nio/ByteOrder;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/nio/ByteBuffer;->order(Ljava/nio/ByteOrder;)Ljava/nio/ByteBuffer;

    .line 184
    invoke-static {p0, v0}, Lcom/google/mediapipe/framework/PacketGetter;->getImageData(Lcom/google/mediapipe/framework/Packet;Ljava/nio/ByteBuffer;)Z

    move-result p0

    .line 188
    invoke-static {}, Ljava/util/Locale;->getDefault()Ljava/util/Locale;

    move-result-object v1

    .line 190
    invoke-static {p2}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p2

    .line 191
    invoke-static {p3}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p3

    filled-new-array {p2, p3}, [Ljava/lang/Object;

    move-result-object p2

    .line 187
    const-string p3, "Got error from getImageData, returning null Bitmap. Image width %d, height %d"

    invoke-static {v1, p3, p2}, Ljava/lang/String;->format(Ljava/util/Locale;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object p2

    .line 185
    invoke-static {p0, p2}, Lcom/google/common/base/Preconditions;->checkState(ZLjava/lang/Object;)V

    .line 192
    invoke-virtual {p1, v0}, Landroid/graphics/Bitmap;->copyPixelsFromBuffer(Ljava/nio/Buffer;)V

    return-void
.end method

.method public static getBitmap(Lcom/google/mediapipe/framework/Packet;)Landroid/graphics/Bitmap;
    .locals 3

    .line 49
    invoke-static {p0}, Lcom/google/mediapipe/framework/PacketGetter;->getImageNumChannels(Lcom/google/mediapipe/framework/Packet;)I

    move-result v0

    const/4 v1, 0x1

    if-eq v0, v1, :cond_2

    const/4 v1, 0x3

    if-eq v0, v1, :cond_1

    const/4 v1, 0x4

    if-ne v0, v1, :cond_0

    .line 56
    invoke-static {p0}, Lcom/google/mediapipe/framework/AndroidPacketGetter;->getBitmapFromRgba(Lcom/google/mediapipe/framework/Packet;)Landroid/graphics/Bitmap;

    move-result-object p0

    return-object p0

    .line 58
    :cond_0
    new-instance p0, Ljava/lang/UnsupportedOperationException;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Unsupported number of channels: "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-direct {p0, v0}, Ljava/lang/UnsupportedOperationException;-><init>(Ljava/lang/String;)V

    throw p0

    .line 54
    :cond_1
    invoke-static {p0}, Lcom/google/mediapipe/framework/AndroidPacketGetter;->getBitmapFromRgb(Lcom/google/mediapipe/framework/Packet;)Landroid/graphics/Bitmap;

    move-result-object p0

    return-object p0

    .line 52
    :cond_2
    invoke-static {p0}, Lcom/google/mediapipe/framework/AndroidPacketGetter;->getBitmapFromGray8(Lcom/google/mediapipe/framework/Packet;)Landroid/graphics/Bitmap;

    move-result-object p0

    return-object p0
.end method

.method public static getBitmapFromGray8(Lcom/google/mediapipe/framework/Packet;)Landroid/graphics/Bitmap;
    .locals 3

    .line 69
    invoke-static {p0}, Lcom/google/mediapipe/framework/PacketGetter;->getImageWidth(Lcom/google/mediapipe/framework/Packet;)I

    move-result v0

    .line 70
    invoke-static {p0}, Lcom/google/mediapipe/framework/PacketGetter;->getImageHeight(Lcom/google/mediapipe/framework/Packet;)I

    move-result v1

    .line 71
    sget-object v2, Landroid/graphics/Bitmap$Config;->ALPHA_8:Landroid/graphics/Bitmap$Config;

    invoke-static {v0, v1, v2}, Landroid/graphics/Bitmap;->createBitmap(IILandroid/graphics/Bitmap$Config;)Landroid/graphics/Bitmap;

    move-result-object v2

    .line 72
    invoke-static {p0, v2, v0, v1}, Lcom/google/mediapipe/framework/AndroidPacketGetter;->copyGray8ToBitmap(Lcom/google/mediapipe/framework/Packet;Landroid/graphics/Bitmap;II)V

    return-object v2
.end method

.method public static getBitmapFromRgb(Lcom/google/mediapipe/framework/Packet;)Landroid/graphics/Bitmap;
    .locals 3

    .line 114
    invoke-static {p0}, Lcom/google/mediapipe/framework/PacketGetter;->getImageWidth(Lcom/google/mediapipe/framework/Packet;)I

    move-result v0

    .line 115
    invoke-static {p0}, Lcom/google/mediapipe/framework/PacketGetter;->getImageHeight(Lcom/google/mediapipe/framework/Packet;)I

    move-result v1

    .line 116
    sget-object v2, Landroid/graphics/Bitmap$Config;->ARGB_8888:Landroid/graphics/Bitmap$Config;

    invoke-static {v0, v1, v2}, Landroid/graphics/Bitmap;->createBitmap(IILandroid/graphics/Bitmap$Config;)Landroid/graphics/Bitmap;

    move-result-object v2

    .line 117
    invoke-static {p0, v2, v0, v1}, Lcom/google/mediapipe/framework/AndroidPacketGetter;->copyRgbToBitmap(Lcom/google/mediapipe/framework/Packet;Landroid/graphics/Bitmap;II)V

    return-object v2
.end method

.method public static getBitmapFromRgba(Lcom/google/mediapipe/framework/Packet;)Landroid/graphics/Bitmap;
    .locals 3

    .line 153
    invoke-static {p0}, Lcom/google/mediapipe/framework/PacketGetter;->getImageWidth(Lcom/google/mediapipe/framework/Packet;)I

    move-result v0

    .line 154
    invoke-static {p0}, Lcom/google/mediapipe/framework/PacketGetter;->getImageHeight(Lcom/google/mediapipe/framework/Packet;)I

    move-result v1

    .line 155
    sget-object v2, Landroid/graphics/Bitmap$Config;->ARGB_8888:Landroid/graphics/Bitmap$Config;

    invoke-static {v0, v1, v2}, Landroid/graphics/Bitmap;->createBitmap(IILandroid/graphics/Bitmap$Config;)Landroid/graphics/Bitmap;

    move-result-object v2

    .line 156
    invoke-static {p0, v2, v0, v1}, Lcom/google/mediapipe/framework/AndroidPacketGetter;->copyRgbaToBitmap(Lcom/google/mediapipe/framework/Packet;Landroid/graphics/Bitmap;II)V

    return-object v2
.end method
