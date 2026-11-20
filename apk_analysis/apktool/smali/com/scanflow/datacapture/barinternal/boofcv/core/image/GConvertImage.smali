.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GConvertImage;
.super Ljava/lang/Object;
.source "GConvertImage.java"


# direct methods
.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;
    .locals 2

    .line 229
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getImageType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v0

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->getDataType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    move-result-object v0

    .line 230
    sget-object v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->U8:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    if-ne v0, v1, :cond_0

    .line 231
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;

    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/ConvertImage;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    move-result-object p0

    return-object p0

    .line 232
    :cond_0
    sget-object v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->S8:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    if-ne v0, v1, :cond_1

    .line 233
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS8;

    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;

    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/ConvertImage;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;

    move-result-object p0

    return-object p0

    .line 234
    :cond_1
    sget-object v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->U16:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    if-ne v0, v1, :cond_2

    .line 235
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU16;

    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/ConvertImage;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    move-result-object p0

    return-object p0

    .line 236
    :cond_2
    sget-object v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->S16:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    if-ne v0, v1, :cond_3

    .line 237
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS16;

    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;

    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/ConvertImage;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;

    move-result-object p0

    return-object p0

    .line 238
    :cond_3
    sget-object v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->S32:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    if-ne v0, v1, :cond_4

    .line 239
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS32;

    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;

    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/ConvertImage;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;

    move-result-object p0

    return-object p0

    .line 240
    :cond_4
    sget-object v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->S64:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    if-ne v0, v1, :cond_5

    .line 241
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;

    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;

    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/ConvertImage;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;

    move-result-object p0

    return-object p0

    .line 242
    :cond_5
    sget-object v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->F32:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    if-ne v0, v1, :cond_6

    .line 243
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;

    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/ConvertImage;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    move-result-object p0

    return-object p0

    .line 244
    :cond_6
    sget-object v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->F64:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    if-ne v0, v1, :cond_7

    .line 245
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;

    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/ConvertImage;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    move-result-object p0

    return-object p0

    .line 247
    :cond_7
    new-instance p0, Ljava/lang/IllegalArgumentException;

    new-instance p1, Ljava/lang/StringBuilder;

    invoke-direct {p1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "Unknown image type: "

    invoke-virtual {p1, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {p1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;
    .locals 2

    .line 198
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBandType()Ljava/lang/Class;

    move-result-object v0

    .line 199
    const-class v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    if-ne v0, v1, :cond_0

    .line 200
    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/ConvertImage;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    move-result-object p0

    return-object p0

    .line 201
    :cond_0
    const-class v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;

    if-ne v0, v1, :cond_1

    .line 202
    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;

    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/ConvertImage;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;

    move-result-object p0

    return-object p0

    .line 203
    :cond_1
    const-class v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    if-ne v0, v1, :cond_2

    .line 204
    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/ConvertImage;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    move-result-object p0

    return-object p0

    .line 205
    :cond_2
    const-class v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;

    if-ne v0, v1, :cond_3

    .line 206
    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;

    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/ConvertImage;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;

    move-result-object p0

    return-object p0

    .line 207
    :cond_3
    const-class v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;

    if-ne v0, v1, :cond_4

    .line 208
    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;

    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/ConvertImage;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;

    move-result-object p0

    return-object p0

    .line 209
    :cond_4
    const-class v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;

    if-ne v0, v1, :cond_5

    .line 210
    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;

    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/ConvertImage;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;

    move-result-object p0

    return-object p0

    .line 211
    :cond_5
    const-class v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    if-ne v0, v1, :cond_6

    .line 212
    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/ConvertImage;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    move-result-object p0

    return-object p0

    .line 213
    :cond_6
    const-class v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    if-ne v0, v1, :cond_7

    .line 214
    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/ConvertImage;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    move-result-object p0

    return-object p0

    .line 216
    :cond_7
    new-instance p0, Ljava/lang/IllegalArgumentException;

    invoke-virtual {v0}, Ljava/lang/Class;->getSimpleName()Ljava/lang/String;

    move-result-object p1

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "Unknown image type: "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method public static convert(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V
    .locals 11

    .line 56
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getImageType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v0

    .line 57
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getImageType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v1

    .line 59
    instance-of v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    const/4 v3, 0x0

    const/4 v4, 0x0

    const-class v5, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/ConvertImage;

    const-string v6, " to "

    const-string v7, "Unknown conversion. "

    const-string v8, "convert"

    if-eqz v2, :cond_4

    .line 60
    move-object v0, p0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    .line 61
    instance-of v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    if-eqz v1, :cond_1

    .line 62
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v1

    if-ne v0, v1, :cond_0

    .line 63
    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->setTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    return-void

    .line 66
    :cond_0
    :try_start_0
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v1

    filled-new-array {v0, v1}, [Ljava/lang/Class;

    move-result-object v0

    invoke-virtual {v5, v8, v0}, Ljava/lang/Class;->getMethod(Ljava/lang/String;[Ljava/lang/Class;)Ljava/lang/reflect/Method;

    move-result-object v0

    .line 67
    filled-new-array {p0, p1}, [Ljava/lang/Object;

    move-result-object v1

    invoke-virtual {v0, v4, v1}, Ljava/lang/reflect/Method;->invoke(Ljava/lang/Object;[Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    return-void

    .line 69
    :catch_0
    new-instance v0, Ljava/lang/IllegalArgumentException;

    .line 70
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object p0

    invoke-virtual {p0}, Ljava/lang/Class;->getSimpleName()Ljava/lang/String;

    move-result-object p0

    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object p1

    invoke-virtual {p1}, Ljava/lang/Class;->getSimpleName()Ljava/lang/String;

    move-result-object p1

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    invoke-direct {v0, p0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 73
    :cond_1
    instance-of v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;

    if-eqz v1, :cond_2

    .line 74
    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;

    .line 75
    :goto_0
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getNumBands()I

    move-result v0

    if-ge v3, v0, :cond_c

    .line 76
    invoke-virtual {p1, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v0

    invoke-static {p0, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GConvertImage;->convert(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    add-int/lit8 v3, v3, 0x1

    goto :goto_0

    .line 78
    :cond_2
    instance-of v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;

    if-eqz v1, :cond_3

    .line 79
    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;

    .line 80
    :goto_1
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getNumBands()I

    move-result p0

    if-ge v3, p0, :cond_c

    .line 81
    invoke-static {v0, v3, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/GImageMiscOps;->insertBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageMultiBand;)V

    add-int/lit8 v3, v3, 0x1

    goto :goto_1

    .line 84
    :cond_3
    new-instance v0, Ljava/lang/IllegalArgumentException;

    .line 85
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object p0

    invoke-virtual {p0}, Ljava/lang/Class;->getSimpleName()Ljava/lang/String;

    move-result-object p0

    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object p1

    invoke-virtual {p1}, Ljava/lang/Class;->getSimpleName()Ljava/lang/String;

    move-result-object p1

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    invoke-direct {v0, p0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 87
    :cond_4
    instance-of v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;

    if-eqz v2, :cond_6

    instance-of v9, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;

    if-eqz v9, :cond_6

    .line 88
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v1

    if-ne v0, v1, :cond_5

    .line 89
    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->setTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    return-void

    .line 92
    :cond_5
    :try_start_1
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v1

    filled-new-array {v0, v1}, [Ljava/lang/Class;

    move-result-object v0

    invoke-virtual {v5, v8, v0}, Ljava/lang/Class;->getMethod(Ljava/lang/String;[Ljava/lang/Class;)Ljava/lang/reflect/Method;

    move-result-object v0

    .line 93
    filled-new-array {p0, p1}, [Ljava/lang/Object;

    move-result-object v1

    invoke-virtual {v0, v4, v1}, Ljava/lang/reflect/Method;->invoke(Ljava/lang/Object;[Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_1

    return-void

    .line 95
    :catch_1
    new-instance v0, Ljava/lang/IllegalArgumentException;

    .line 96
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object p0

    invoke-virtual {p0}, Ljava/lang/Class;->getSimpleName()Ljava/lang/String;

    move-result-object p0

    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object p1

    invoke-virtual {p1}, Ljava/lang/Class;->getSimpleName()Ljava/lang/String;

    move-result-object p1

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    invoke-direct {v0, p0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 99
    :cond_6
    instance-of v9, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;

    if-eqz v9, :cond_8

    instance-of v10, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    if-eqz v10, :cond_8

    .line 100
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;

    .line 101
    move-object v0, p1

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    .line 103
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getImageType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v1

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->getDataType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    move-result-object v1

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->getDataType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    move-result-object v2

    if-eq v1, v2, :cond_7

    .line 104
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    .line 105
    iget p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    .line 106
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getImageType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v2

    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->getDataType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    move-result-object v2

    invoke-static {v2, v1, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GeneralizedImageOps;->createSingleBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p1

    .line 107
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GConvertImage;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    .line 108
    invoke-static {p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GConvertImage;->convert(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    return-void

    .line 110
    :cond_7
    invoke-static {p0, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GConvertImage;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    return-void

    :cond_8
    if-eqz v9, :cond_a

    .line 112
    instance-of v10, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;

    if-eqz v10, :cond_a

    .line 114
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->getDataType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    move-result-object v2

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->getDataType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    move-result-object v3

    if-ne v2, v3, :cond_9

    goto :goto_2

    .line 117
    :cond_9
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->getDataType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    move-result-object v0

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->getDataType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    move-result-object v1

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v2, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v8

    .line 120
    :goto_2
    :try_start_2
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v1

    filled-new-array {v0, v1}, [Ljava/lang/Class;

    move-result-object v0

    invoke-virtual {v5, v8, v0}, Ljava/lang/Class;->getMethod(Ljava/lang/String;[Ljava/lang/Class;)Ljava/lang/reflect/Method;

    move-result-object v0

    .line 121
    filled-new-array {p0, p1}, [Ljava/lang/Object;

    move-result-object v1

    invoke-virtual {v0, v4, v1}, Ljava/lang/reflect/Method;->invoke(Ljava/lang/Object;[Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_2
    .catch Ljava/lang/Exception; {:try_start_2 .. :try_end_2} :catch_2

    return-void

    .line 123
    :catch_2
    new-instance v0, Ljava/lang/IllegalArgumentException;

    .line 124
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object p0

    invoke-virtual {p0}, Ljava/lang/Class;->getSimpleName()Ljava/lang/String;

    move-result-object p0

    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object p1

    invoke-virtual {p1}, Ljava/lang/Class;->getSimpleName()Ljava/lang/String;

    move-result-object p1

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    invoke-direct {v0, p0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0

    :cond_a
    if-eqz v9, :cond_d

    .line 126
    instance-of v9, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;

    if-eqz v9, :cond_d

    .line 127
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;

    .line 128
    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;

    .line 130
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBandType()Ljava/lang/Class;

    move-result-object v0

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBandType()Ljava/lang/Class;

    move-result-object v1

    if-ne v0, v1, :cond_b

    .line 131
    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->setTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;

    return-void

    .line 133
    :cond_b
    :goto_3
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getNumBands()I

    move-result v0

    if-ge v3, v0, :cond_c

    .line 134
    invoke-virtual {p0, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v0

    invoke-virtual {p1, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v1

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GConvertImage;->convert(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    add-int/lit8 v3, v3, 0x1

    goto :goto_3

    :cond_c
    return-void

    :cond_d
    if-eqz v2, :cond_f

    .line 137
    instance-of v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;

    if-eqz v3, :cond_f

    .line 139
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->getDataType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    move-result-object v2

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->getDataType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    move-result-object v3

    if-ne v2, v3, :cond_e

    goto :goto_4

    .line 142
    :cond_e
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->getDataType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    move-result-object v0

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->getDataType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    move-result-object v1

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v2, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v8

    .line 145
    :goto_4
    :try_start_3
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v1

    filled-new-array {v0, v1}, [Ljava/lang/Class;

    move-result-object v0

    invoke-virtual {v5, v8, v0}, Ljava/lang/Class;->getMethod(Ljava/lang/String;[Ljava/lang/Class;)Ljava/lang/reflect/Method;

    move-result-object v0

    .line 146
    filled-new-array {p0, p1}, [Ljava/lang/Object;

    move-result-object v1

    invoke-virtual {v0, v4, v1}, Ljava/lang/reflect/Method;->invoke(Ljava/lang/Object;[Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_3
    .catch Ljava/lang/Exception; {:try_start_3 .. :try_end_3} :catch_3

    return-void

    .line 148
    :catch_3
    new-instance v0, Ljava/lang/IllegalArgumentException;

    .line 149
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object p0

    invoke-virtual {p0}, Ljava/lang/Class;->getSimpleName()Ljava/lang/String;

    move-result-object p0

    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object p1

    invoke-virtual {p1}, Ljava/lang/Class;->getSimpleName()Ljava/lang/String;

    move-result-object p1

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    invoke-direct {v0, p0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0

    :cond_f
    if-eqz v2, :cond_11

    .line 151
    instance-of v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    if-eqz v0, :cond_11

    .line 152
    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;

    .line 153
    move-object v0, p1

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    .line 155
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getImageType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v1

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->getDataType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    move-result-object v1

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->getDataType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    move-result-object v2

    if-eq v1, v2, :cond_10

    .line 156
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    .line 157
    iget p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    .line 158
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getImageType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v2

    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->getDataType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    move-result-object v2

    invoke-static {v2, v1, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GeneralizedImageOps;->createSingleBand(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p1

    .line 159
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GConvertImage;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    .line 160
    invoke-static {p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GConvertImage;->convert(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    return-void

    .line 162
    :cond_10
    invoke-static {p0, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GConvertImage;->average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    return-void

    .line 165
    :cond_11
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object p0

    invoke-virtual {p0}, Ljava/lang/Class;->getSimpleName()Ljava/lang/String;

    move-result-object p0

    .line 166
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object p1

    invoke-virtual {p1}, Ljava/lang/Class;->getSimpleName()Ljava/lang/String;

    move-result-object p1

    .line 167
    new-instance v0, Ljava/lang/IllegalArgumentException;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Don\'t know how to convert between input types. "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string p0, " "

    invoke-virtual {v1, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    invoke-direct {v0, p0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0
.end method
