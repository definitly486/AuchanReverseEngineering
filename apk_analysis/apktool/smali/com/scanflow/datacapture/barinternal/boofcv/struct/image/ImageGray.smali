.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;
.super Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;
.source "ImageGray.java"


# direct methods
.method protected constructor <init>()V
    .locals 1

    .line 79
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;-><init>()V

    .line 65
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->single(Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->imageType:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    return-void
.end method

.method protected constructor <init>(II)V
    .locals 1

    .line 75
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;-><init>()V

    .line 65
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->single(Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->imageType:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    .line 76
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->initialize(II)V

    return-void
.end method

.method public static create(Ljava/lang/Class;II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;
    .locals 1

    .line 202
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    if-ne p0, v0, :cond_0

    .line 203
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;-><init>(II)V

    return-object p0

    .line 204
    :cond_0
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;

    if-ne p0, v0, :cond_1

    .line 205
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;

    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;-><init>(II)V

    return-object p0

    .line 206
    :cond_1
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;

    if-ne p0, v0, :cond_2

    .line 207
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;

    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;-><init>(II)V

    return-object p0

    .line 208
    :cond_2
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    if-ne p0, v0, :cond_3

    .line 209
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;-><init>(II)V

    return-object p0

    .line 210
    :cond_3
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;

    if-ne p0, v0, :cond_4

    .line 211
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;

    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;-><init>(II)V

    return-object p0

    .line 212
    :cond_4
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;

    if-ne p0, v0, :cond_5

    .line 213
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;

    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;-><init>(II)V

    return-object p0

    .line 214
    :cond_5
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    if-ne p0, v0, :cond_6

    .line 215
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;-><init>(II)V

    return-object p0

    .line 216
    :cond_6
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    if-ne p0, v0, :cond_7

    .line 217
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;-><init>(II)V

    return-object p0

    .line 218
    :cond_7
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI;

    if-ne p0, v0, :cond_8

    .line 220
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;

    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;-><init>(II)V

    return-object p0

    .line 222
    :cond_8
    new-instance p1, Ljava/lang/IllegalArgumentException;

    new-instance p2, Ljava/lang/StringBuilder;

    invoke-direct {p2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v0, "Unknown type "

    invoke-virtual {p2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {p2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    invoke-direct {p1, p0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method


# virtual methods
.method protected abstract _getData()Ljava/lang/Object;
.end method

.method public abstract _setData(Ljava/lang/Object;)V
.end method

.method public abstract getDataType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;
.end method

.method protected initialize(II)V
    .locals 2

    .line 82
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->getDataType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    move-result-object v0

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->getDataType()Ljava/lang/Class;

    move-result-object v0

    mul-int v1, p1, p2

    invoke-static {v0, v1}, Ljava/lang/reflect/Array;->newInstance(Ljava/lang/Class;I)Ljava/lang/Object;

    move-result-object v0

    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->_setData(Ljava/lang/Object;)V

    const/4 v0, 0x0

    .line 83
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    .line 84
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    .line 85
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    .line 86
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    return-void
.end method

.method public reshape(II)V
    .locals 2

    .line 142
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ne v0, p1, :cond_0

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ne v0, p2, :cond_0

    return-void

    .line 144
    :cond_0
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->isSubimage()Z

    move-result v0

    if-nez v0, :cond_2

    .line 147
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->_getData()Ljava/lang/Object;

    move-result-object v0

    .line 149
    invoke-static {v0}, Ljava/lang/reflect/Array;->getLength(Ljava/lang/Object;)I

    move-result v0

    mul-int v1, p1, p2

    if-ge v0, v1, :cond_1

    .line 151
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->createNew(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    .line 152
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->_getData()Ljava/lang/Object;

    move-result-object v0

    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->_setData(Ljava/lang/Object;)V

    .line 155
    :cond_1
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    .line 156
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    .line 157
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    return-void

    .line 145
    :cond_2
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string p2, "Can\'t reshape sub-images"

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public reshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V
    .locals 1

    .line 164
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-virtual {p0, v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(II)V

    return-void
.end method

.method public bridge synthetic setTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;
    .locals 0

    .line 61
    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->setTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p1

    return-object p1
.end method

.method public setTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;
    .locals 6

    .line 176
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ne v0, v1, :cond_0

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-eq v0, v2, :cond_1

    .line 177
    :cond_0
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-virtual {p0, v1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(II)V

    .line 179
    :cond_1
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->isSubimage()Z

    move-result v0

    if-nez v0, :cond_2

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->isSubimage()Z

    move-result v0

    if-nez v0, :cond_2

    .line 180
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->_getData()Ljava/lang/Object;

    move-result-object v0

    iget p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->_getData()Ljava/lang/Object;

    move-result-object v1

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    mul-int/2addr v3, v4

    invoke-static {v0, p1, v1, v2, v3}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    return-object p0

    .line 182
    :cond_2
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    .line 183
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    const/4 v2, 0x0

    .line 184
    :goto_0
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v2, v3, :cond_3

    .line 185
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->_getData()Ljava/lang/Object;

    move-result-object v3

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->_getData()Ljava/lang/Object;

    move-result-object v4

    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    invoke-static {v3, v0, v4, v1, v5}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    .line 186
    iget v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int/2addr v0, v3

    .line 187
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int/2addr v1, v3

    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    :cond_3
    return-object p0
.end method

.method public subimage(IIIILcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;
    .locals 2

    if-ltz p1, :cond_3

    if-ltz p2, :cond_3

    if-lt p3, p1, :cond_2

    if-lt p4, p2, :cond_2

    .line 115
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-gt p3, v0, :cond_1

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-gt p4, v0, :cond_1

    if-nez p5, :cond_0

    const/4 p5, -0x1

    .line 119
    invoke-virtual {p0, p5, p5}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->createNew(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    move-result-object p5

    check-cast p5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    .line 122
    :cond_0
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->_getData()Ljava/lang/Object;

    move-result-object v0

    invoke-virtual {p5, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->_setData(Ljava/lang/Object;)V

    .line 123
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    invoke-static {v0, v1}, Ljava/lang/Math;->max(II)I

    move-result v0

    iput v0, p5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    sub-int/2addr p3, p1

    .line 124
    iput p3, p5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    sub-int/2addr p4, p2

    .line 125
    iput p4, p5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    .line 126
    iget p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p2, p4

    add-int/2addr p3, p2

    add-int/2addr p3, p1

    iput p3, p5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    const/4 p1, 0x1

    .line 127
    iput-boolean p1, p5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->subImage:Z

    .line 128
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->imageType:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    iput-object p1, p5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->imageType:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    return-object p5

    .line 116
    :cond_1
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string p2, "x1 or y1 is more than the width or height respectively"

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1

    .line 114
    :cond_2
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string p2, "x1 or y1 is less than x0 or y0 respectively"

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1

    .line 112
    :cond_3
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string p2, "x0 or y0 is less than zero"

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method
