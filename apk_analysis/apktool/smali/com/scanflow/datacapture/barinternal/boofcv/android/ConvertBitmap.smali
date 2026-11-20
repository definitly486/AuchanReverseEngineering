.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/android/ConvertBitmap;
.super Ljava/lang/Object;
.source "ConvertBitmap.java"


# direct methods
.method public static bitmapToGray(Landroid/graphics/Bitmap;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;
    .locals 2

    .line 136
    invoke-static {p0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/android/ConvertBitmap;->resizeStorage(Landroid/graphics/Bitmap;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    move-result-object p2

    if-nez p1, :cond_0

    .line 138
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    invoke-virtual {p0}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v0

    invoke-virtual {p0}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v1

    invoke-direct {p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;-><init>(II)V

    goto :goto_0

    .line 140
    :cond_0
    invoke-virtual {p0}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v0

    invoke-virtual {p0}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v1

    invoke-virtual {p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(II)V

    .line 143
    :goto_0
    iget-object v0, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    invoke-static {v0}, Ljava/nio/ByteBuffer;->wrap([B)Ljava/nio/ByteBuffer;

    move-result-object v0

    invoke-virtual {p0, v0}, Landroid/graphics/Bitmap;->copyPixelsToBuffer(Ljava/nio/Buffer;)V

    .line 145
    iget-object p2, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    invoke-virtual {p0}, Landroid/graphics/Bitmap;->getConfig()Landroid/graphics/Bitmap$Config;

    move-result-object p0

    invoke-static {p2, p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/android/ImplConvertBitmap;->arrayToGray([BLandroid/graphics/Bitmap$Config;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    return-object p1
.end method

.method public static resizeStorage(Landroid/graphics/Bitmap;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;
    .locals 2

    .line 53
    invoke-virtual {p0}, Landroid/graphics/Bitmap;->getConfig()Landroid/graphics/Bitmap$Config;

    move-result-object v0

    sget-object v1, Landroid/graphics/Bitmap$Config;->ARGB_8888:Landroid/graphics/Bitmap$Config;

    if-ne v0, v1, :cond_0

    const/4 v0, 0x4

    goto :goto_0

    :cond_0
    const/4 v0, 0x2

    .line 54
    :goto_0
    invoke-virtual {p0}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v1

    invoke-virtual {p0}, Landroid/graphics/Bitmap;->getHeight()I

    move-result p0

    mul-int/2addr v1, p0

    mul-int/2addr v1, v0

    if-nez p1, :cond_1

    .line 57
    new-instance p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    invoke-direct {p0, v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;-><init>(I)V

    return-object p0

    .line 59
    :cond_1
    invoke-virtual {p1, v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->resize(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    return-object p1
.end method
