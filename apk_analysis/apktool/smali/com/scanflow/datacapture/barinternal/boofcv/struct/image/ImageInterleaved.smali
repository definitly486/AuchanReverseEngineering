.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;
.super Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageMultiBand;
.source "ImageInterleaved.java"


# instance fields
.field public numBands:I


# direct methods
.method protected constructor <init>()V
    .locals 2

    .line 66
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageMultiBand;-><init>()V

    const/4 v0, 0x0

    .line 45
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v1

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->il(ILjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->imageType:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    return-void
.end method

.method protected constructor <init>(III)V
    .locals 3

    .line 56
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageMultiBand;-><init>()V

    .line 45
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const/4 v1, 0x0

    invoke-static {v1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->il(ILjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->imageType:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    .line 57
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->getPrimitiveDataType()Ljava/lang/Class;

    move-result-object v0

    mul-int v2, p1, p2

    mul-int/2addr v2, p3

    invoke-static {v0, v2}, Ljava/lang/reflect/Array;->newInstance(Ljava/lang/Class;I)Ljava/lang/Object;

    move-result-object v0

    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->_setData(Ljava/lang/Object;)V

    .line 58
    iput v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    mul-int v0, p1, p3

    .line 59
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    .line 60
    iput p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->numBands:I

    .line 61
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    .line 62
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    .line 63
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->imageType:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    iput p3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->numBands:I

    return-void
.end method

.method public static create(Ljava/lang/Class;III)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;
    .locals 1

    .line 219
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;

    if-ne p0, v0, :cond_0

    .line 220
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;

    invoke-direct {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;-><init>(III)V

    return-object p0

    .line 221
    :cond_0
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS8;

    if-ne p0, v0, :cond_1

    .line 222
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS8;

    invoke-direct {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS8;-><init>(III)V

    return-object p0

    .line 223
    :cond_1
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU16;

    if-ne p0, v0, :cond_2

    .line 224
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU16;

    invoke-direct {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU16;-><init>(III)V

    return-object p0

    .line 225
    :cond_2
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS16;

    if-ne p0, v0, :cond_3

    .line 226
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS16;

    invoke-direct {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS16;-><init>(III)V

    return-object p0

    .line 227
    :cond_3
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS32;

    if-ne p0, v0, :cond_4

    .line 228
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS32;

    invoke-direct {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS32;-><init>(III)V

    return-object p0

    .line 229
    :cond_4
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;

    if-ne p0, v0, :cond_5

    .line 230
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;

    invoke-direct {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;-><init>(III)V

    return-object p0

    .line 231
    :cond_5
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;

    if-ne p0, v0, :cond_6

    .line 232
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;

    invoke-direct {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;-><init>(III)V

    return-object p0

    .line 233
    :cond_6
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;

    if-ne p0, v0, :cond_7

    .line 234
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;

    invoke-direct {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;-><init>(III)V

    return-object p0

    .line 236
    :cond_7
    new-instance p1, Ljava/lang/IllegalArgumentException;

    new-instance p2, Ljava/lang/StringBuilder;

    invoke-direct {p2}, Ljava/lang/StringBuilder;-><init>()V

    const-string p3, "Unknown type "

    invoke-virtual {p2, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {p2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    invoke-direct {p1, p0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method


# virtual methods
.method protected abstract _getData()Ljava/lang/Object;
.end method

.method protected abstract _setData(Ljava/lang/Object;)V
.end method

.method public getIndex(II)I
    .locals 2

    .line 131
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p2, v1

    add-int/2addr v0, p2

    iget p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->numBands:I

    mul-int/2addr p1, p2

    add-int/2addr v0, p1

    return v0
.end method

.method public getIndex(III)I
    .locals 2

    .line 135
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p2, v1

    add-int/2addr v0, p2

    iget p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->numBands:I

    mul-int/2addr p1, p2

    add-int/2addr v0, p1

    add-int/2addr v0, p3

    return v0
.end method

.method public getNumBands()I
    .locals 1

    .line 165
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->imageType:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->getNumBands()I

    move-result v0

    return v0
.end method

.method protected abstract getPrimitiveDataType()Ljava/lang/Class;
.end method

.method public reshape(II)V
    .locals 3

    .line 97
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ne v0, p1, :cond_0

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ne v0, p2, :cond_0

    return-void

    .line 100
    :cond_0
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->isSubimage()Z

    move-result v0

    if-nez v0, :cond_2

    .line 103
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->_getData()Ljava/lang/Object;

    move-result-object v0

    .line 105
    invoke-static {v0}, Ljava/lang/reflect/Array;->getLength(Ljava/lang/Object;)I

    move-result v0

    mul-int v1, p1, p2

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->numBands:I

    mul-int/2addr v1, v2

    if-ge v0, v1, :cond_1

    .line 106
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->createNew(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;

    .line 107
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->_getData()Ljava/lang/Object;

    move-result-object v0

    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->_setData(Ljava/lang/Object;)V

    .line 110
    :cond_1
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    .line 111
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    .line 112
    iget p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->numBands:I

    mul-int/2addr p1, p2

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    return-void

    .line 101
    :cond_2
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string p2, "Can\'t reshape sub-images"

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public reshape(III)V
    .locals 1

    .line 117
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->numBands:I

    if-eq v0, p3, :cond_1

    .line 118
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->isSubimage()Z

    move-result v0

    if-nez v0, :cond_0

    const/4 v0, -0x1

    .line 120
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->numBands:I

    .line 121
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    .line 122
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    .line 123
    invoke-virtual {p0, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->setNumberOfBands(I)V

    return-void

    .line 119
    :cond_0
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string p2, "Can\'t reshape sub-images"

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1

    .line 125
    :cond_1
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->reshape(II)V

    return-void
.end method

.method public final setNumberOfBands(I)V
    .locals 3

    .line 170
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->numBands:I

    if-ne v0, p1, :cond_0

    goto :goto_0

    .line 173
    :cond_0
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->isSubimage()Z

    move-result v0

    if-nez v0, :cond_3

    .line 176
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->imageType:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    iput p1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->numBands:I

    .line 177
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->numBands:I

    .line 178
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    mul-int/2addr v0, p1

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    .line 180
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->_getData()Ljava/lang/Object;

    move-result-object v0

    if-eqz v0, :cond_2

    .line 182
    invoke-static {v0}, Ljava/lang/reflect/Array;->getLength(Ljava/lang/Object;)I

    move-result v0

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    mul-int/2addr v1, v2

    mul-int/2addr v1, p1

    if-ge v0, v1, :cond_1

    goto :goto_1

    :cond_1
    :goto_0
    return-void

    .line 183
    :cond_2
    :goto_1
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-virtual {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->createNew(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;

    .line 184
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->_getData()Ljava/lang/Object;

    move-result-object p1

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->_setData(Ljava/lang/Object;)V

    return-void

    .line 174
    :cond_3
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string v0, "Can\'t reshape sub-images"

    invoke-direct {p1, v0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public bridge synthetic setTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;
    .locals 0

    .line 38
    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->setTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;

    move-result-object p1

    return-object p1
.end method

.method public setTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;
    .locals 7

    .line 146
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ne v0, v1, :cond_0

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ne v1, v2, :cond_0

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->numBands:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->numBands:I

    if-eq v1, v2, :cond_1

    .line 147
    :cond_0
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->numBands:I

    invoke-virtual {p0, v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->reshape(III)V

    .line 149
    :cond_1
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->isSubimage()Z

    move-result v0

    if-nez v0, :cond_2

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->isSubimage()Z

    move-result v0

    if-nez v0, :cond_2

    .line 150
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->_getData()Ljava/lang/Object;

    move-result-object v0

    iget p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->_getData()Ljava/lang/Object;

    move-result-object v1

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    mul-int/2addr v3, v4

    invoke-static {v0, p1, v1, v2, v3}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    return-object p0

    .line 152
    :cond_2
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    .line 153
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    const/4 v2, 0x0

    .line 154
    :goto_0
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v2, v3, :cond_3

    .line 155
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->_getData()Ljava/lang/Object;

    move-result-object v3

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->_getData()Ljava/lang/Object;

    move-result-object v4

    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->numBands:I

    mul-int/2addr v5, v6

    invoke-static {v3, v0, v4, v1, v5}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    .line 156
    iget v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int/2addr v0, v3

    .line 157
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int/2addr v1, v3

    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    :cond_3
    return-object p0
.end method

.method public toString()Ljava/lang/String;
    .locals 9

    .line 247
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Class;->getSimpleName()Ljava/lang/String;

    move-result-object v0

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->numBands:I

    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v4, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v0, " : w="

    invoke-virtual {v4, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v4, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string v0, ", h="

    invoke-virtual {v4, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v4, v2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string v0, ", c="

    invoke-virtual {v4, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v4, v3}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string v0, "\n"

    invoke-virtual {v4, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    const/4 v2, 0x0

    move v3, v2

    .line 248
    :goto_0
    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v3, v4, :cond_3

    .line 249
    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v5, v3

    add-int/2addr v4, v5

    move v5, v2

    .line 250
    :goto_1
    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v5, v6, :cond_2

    move v6, v2

    .line 251
    :goto_2
    iget v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->numBands:I

    if-ge v6, v7, :cond_0

    add-int/lit8 v7, v4, 0x1

    .line 252
    invoke-virtual {p0, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->toString_element(I)Ljava/lang/String;

    move-result-object v4

    new-instance v8, Ljava/lang/StringBuilder;

    invoke-direct {v8}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v8, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v8, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, " "

    invoke-virtual {v8, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    add-int/lit8 v6, v6, 0x1

    move v4, v7

    goto :goto_2

    .line 254
    :cond_0
    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/lit8 v6, v6, -0x1

    if-ge v5, v6, :cond_1

    .line 255
    new-instance v6, Ljava/lang/StringBuilder;

    invoke-direct {v6}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v6, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, ", "

    invoke-virtual {v6, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v6}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    :cond_1
    add-int/lit8 v5, v5, 0x1

    goto :goto_1

    .line 257
    :cond_2
    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v4, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v4, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    add-int/lit8 v3, v3, 0x1

    goto :goto_0

    :cond_3
    return-object v1
.end method

.method public abstract toString_element(I)Ljava/lang/String;
.end method
