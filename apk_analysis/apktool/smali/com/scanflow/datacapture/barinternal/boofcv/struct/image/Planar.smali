.class public Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;
.super Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageMultiBand;
.source "Planar.java"


# instance fields
.field public bands:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

.field public type:Ljava/lang/Class;


# direct methods
.method public constructor <init>(Ljava/lang/Class;III)V
    .locals 3

    .line 81
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageMultiBand;-><init>()V

    .line 82
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->type:Ljava/lang/Class;

    .line 83
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    .line 84
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    .line 85
    iput p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    .line 86
    invoke-static {p1, p4}, Ljava/lang/reflect/Array;->newInstance(Ljava/lang/Class;I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->bands:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    const/4 v0, 0x0

    :goto_0
    if-ge v0, p4, :cond_0

    .line 89
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->bands:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    invoke-static {p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->create(Ljava/lang/Class;II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v2

    aput-object v2, v1, v0

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    .line 91
    :cond_0
    invoke-static {p4, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->pl(ILjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->imageType:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    return-void
.end method


# virtual methods
.method public bridge synthetic createNew(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;
    .locals 0

    .line 61
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->createNew(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;

    move-result-object p1

    return-object p1
.end method

.method public createNew(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;
    .locals 3

    .line 263
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->type:Ljava/lang/Class;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->bands:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    array-length v2, v2

    invoke-direct {v0, v1, p1, p2, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;-><init>(Ljava/lang/Class;III)V

    return-object v0
.end method

.method public getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;
    .locals 4

    .line 132
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->bands:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    array-length v1, v0

    if-ge p1, v1, :cond_0

    if-ltz p1, :cond_0

    .line 135
    aget-object p1, v0, p1

    return-object p1

    .line 133
    :cond_0
    new-instance v0, Ljava/lang/IllegalArgumentException;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->bands:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    array-length v1, v1

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "The specified band is out of range. "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p1, " / "

    invoke-virtual {v2, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {v0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method public getBandType()Ljava/lang/Class;
    .locals 1

    .line 112
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->type:Ljava/lang/Class;

    return-object v0
.end method

.method public getNumBands()I
    .locals 1

    .line 122
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->bands:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    array-length v0, v0

    return v0
.end method

.method public reshape(II)V
    .locals 4

    .line 212
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ne v0, p1, :cond_0

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ne v0, p2, :cond_0

    return-void

    .line 215
    :cond_0
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->isSubimage()Z

    move-result v0

    if-nez v0, :cond_2

    const/4 v0, 0x0

    move v1, v0

    .line 218
    :goto_0
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->bands:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    array-length v3, v2

    if-ge v1, v3, :cond_1

    .line 219
    aget-object v2, v2, v1

    invoke-virtual {v2, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(II)V

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    .line 222
    :cond_1
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    .line 223
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    .line 224
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    .line 225
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    return-void

    .line 216
    :cond_2
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string p2, "Can\'t reshape subimage"

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public setNumberOfBands(I)V
    .locals 4

    .line 318
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->bands:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    array-length v0, v0

    if-ne p1, v0, :cond_0

    return-void

    .line 321
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->type:Ljava/lang/Class;

    invoke-static {v0, p1}, Ljava/lang/reflect/Array;->newInstance(Ljava/lang/Class;I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    .line 322
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->bands:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    array-length v1, v1

    invoke-static {p1, v1}, Ljava/lang/Math;->min(II)I

    move-result p1

    const/4 v1, 0x0

    :goto_0
    if-ge v1, p1, :cond_1

    .line 324
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->bands:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    aget-object v2, v2, v1

    aput-object v2, v0, v1

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    .line 326
    :cond_1
    :goto_1
    array-length v1, v0

    if-ge p1, v1, :cond_2

    .line 327
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->type:Ljava/lang/Class;

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-static {v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->create(Ljava/lang/Class;II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v1

    aput-object v1, v0, p1

    add-int/lit8 p1, p1, 0x1

    goto :goto_1

    .line 329
    :cond_2
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->bands:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    .line 330
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->imageType:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    array-length v0, v0

    iput v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->numBands:I

    return-void
.end method

.method public bridge synthetic setTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;
    .locals 0

    .line 61
    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->setTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;

    move-result-object p1

    return-object p1
.end method

.method public setTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;
    .locals 4

    .line 187
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ne v0, v1, :cond_0

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-eq v1, v2, :cond_1

    .line 188
    :cond_0
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-virtual {p0, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->reshape(II)V

    .line 189
    :cond_1
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBandType()Ljava/lang/Class;

    move-result-object v0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBandType()Ljava/lang/Class;

    move-result-object v1

    if-ne v0, v1, :cond_4

    .line 192
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getNumBands()I

    move-result v0

    .line 193
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getNumBands()I

    move-result v1

    if-eq v0, v1, :cond_2

    .line 194
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getNumBands()I

    move-result v1

    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->setNumberOfBands(I)V

    :cond_2
    const/4 v1, 0x0

    :goto_0
    if-ge v1, v0, :cond_3

    .line 198
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->bands:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    aget-object v2, v2, v1

    invoke-virtual {p1, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v3

    invoke-virtual {v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->setTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_3
    return-object p0

    .line 190
    :cond_4
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string v0, "The band type must be the same"

    invoke-direct {p1, v0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method
