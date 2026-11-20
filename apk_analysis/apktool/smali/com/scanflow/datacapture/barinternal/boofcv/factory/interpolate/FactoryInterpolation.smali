.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/factory/interpolate/FactoryInterpolation;
.super Ljava/lang/Object;
.source "FactoryInterpolation.java"


# direct methods
.method public static bilinearPixelS(Ljava/lang/Class;Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;)Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;
    .locals 2

    .line 173
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    if-ne p0, v0, :cond_0

    .line 174
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/impl/ImplBilinearPixel_F32;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/impl/ImplBilinearPixel_F32;-><init>()V

    goto :goto_0

    .line 175
    :cond_0
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    if-ne p0, v0, :cond_1

    .line 176
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/impl/ImplBilinearPixel_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/impl/ImplBilinearPixel_F64;-><init>()V

    goto :goto_0

    .line 177
    :cond_1
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    if-ne p0, v0, :cond_2

    .line 178
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/impl/ImplBilinearPixel_U8;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/impl/ImplBilinearPixel_U8;-><init>()V

    goto :goto_0

    .line 179
    :cond_2
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    if-ne p0, v0, :cond_3

    .line 180
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/impl/ImplBilinearPixel_U16;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/impl/ImplBilinearPixel_U16;-><init>()V

    goto :goto_0

    .line 181
    :cond_3
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;

    if-ne p0, v0, :cond_4

    .line 182
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/impl/ImplBilinearPixel_S16;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/impl/ImplBilinearPixel_S16;-><init>()V

    goto :goto_0

    .line 183
    :cond_4
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;

    if-ne p0, v0, :cond_6

    .line 184
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/impl/ImplBilinearPixel_S32;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/impl/ImplBilinearPixel_S32;-><init>()V

    :goto_0
    if-eqz p1, :cond_5

    .line 189
    invoke-static {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/border/FactoryImageBorder;->single(Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder;

    move-result-object p0

    invoke-interface {v0, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixel;->setBorder(Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder;)V

    :cond_5
    return-object v0

    .line 186
    :cond_6
    new-instance p1, Ljava/lang/RuntimeException;

    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/interpolate/FactoryInterpolation;->typeName(Ljava/lang/Class;)Ljava/lang/String;

    move-result-object p0

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "Unknown image type: "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    invoke-direct {p1, p0}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public static nearestNeighborPixelS(Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;
    .locals 3

    .line 303
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    if-ne p0, v0, :cond_0

    .line 304
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/impl/NearestNeighborPixel_F32;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/impl/NearestNeighborPixel_F32;-><init>()V

    return-object p0

    .line 305
    :cond_0
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    if-ne p0, v0, :cond_1

    .line 306
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/impl/NearestNeighborPixel_U8;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/impl/NearestNeighborPixel_U8;-><init>()V

    return-object p0

    .line 307
    :cond_1
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;

    if-ne p0, v0, :cond_2

    .line 308
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/impl/NearestNeighborPixel_S16;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/impl/NearestNeighborPixel_S16;-><init>()V

    return-object p0

    .line 309
    :cond_2
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    if-ne p0, v0, :cond_3

    .line 310
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/impl/NearestNeighborPixel_U16;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/impl/NearestNeighborPixel_U16;-><init>()V

    return-object p0

    .line 311
    :cond_3
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;

    if-ne p0, v0, :cond_4

    .line 312
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/impl/NearestNeighborPixel_S32;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/impl/NearestNeighborPixel_S32;-><init>()V

    return-object p0

    .line 314
    :cond_4
    new-instance v0, Ljava/lang/RuntimeException;

    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/interpolate/FactoryInterpolation;->typeName(Ljava/lang/Class;)Ljava/lang/String;

    move-result-object p0

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Unknown image type: "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    invoke-direct {v0, p0}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method private static typeName(Ljava/lang/Class;)Ljava/lang/String;
    .locals 0

    if-nez p0, :cond_0

    .line 280
    const-string p0, "null"

    return-object p0

    :cond_0
    invoke-virtual {p0}, Ljava/lang/Class;->getName()Ljava/lang/String;

    move-result-object p0

    return-object p0
.end method
