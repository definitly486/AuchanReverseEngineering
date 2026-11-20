.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray;
.super Ljava/lang/Object;
.source "FactoryGImageGray.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray$GSingle_U8;,
        Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray$GSingle_S8;,
        Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray$GSingle_U16;,
        Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray$GSingle_S16;,
        Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray$GSingle_S32;,
        Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray$GSingle_I64;,
        Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray$GSingle_F32;,
        Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray$GSingle_F64;,
        Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray$GSingleBase;,
        Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray$GSingleBaseInt;
    }
.end annotation


# direct methods
.method public static create(Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GImageGray;
    .locals 3

    .line 37
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    const/4 v1, 0x0

    if-ne p0, v0, :cond_0

    .line 38
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray$GSingle_U8;

    invoke-direct {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray$GSingle_U8;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    return-object p0

    .line 39
    :cond_0
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;

    if-ne p0, v0, :cond_1

    .line 40
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray$GSingle_S8;

    invoke-direct {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray$GSingle_S8;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;)V

    return-object p0

    .line 41
    :cond_1
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    if-ne p0, v0, :cond_2

    .line 42
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray$GSingle_U16;

    invoke-direct {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray$GSingle_U16;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;)V

    return-object p0

    .line 43
    :cond_2
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;

    if-ne p0, v0, :cond_3

    .line 44
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray$GSingle_S16;

    invoke-direct {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray$GSingle_S16;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;)V

    return-object p0

    .line 45
    :cond_3
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;

    if-ne p0, v0, :cond_4

    .line 46
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray$GSingle_S32;

    invoke-direct {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray$GSingle_S32;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;)V

    return-object p0

    .line 47
    :cond_4
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;

    if-ne p0, v0, :cond_5

    .line 48
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray$GSingle_I64;

    invoke-direct {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray$GSingle_I64;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;)V

    return-object p0

    .line 49
    :cond_5
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    if-ne p0, v0, :cond_6

    .line 50
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray$GSingle_F32;

    invoke-direct {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray$GSingle_F32;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    return-object p0

    .line 51
    :cond_6
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    if-ne p0, v0, :cond_7

    .line 52
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray$GSingle_F64;

    invoke-direct {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray$GSingle_F64;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;)V

    return-object p0

    .line 54
    :cond_7
    new-instance v0, Ljava/lang/IllegalArgumentException;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Unknown image type: "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    invoke-direct {v0, p0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0
.end method
