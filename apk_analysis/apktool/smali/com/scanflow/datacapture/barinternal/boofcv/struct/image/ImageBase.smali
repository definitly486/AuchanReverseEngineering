.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;
.super Ljava/lang/Object;
.source "ImageBase.java"

# interfaces
.implements Ljava/io/Serializable;
.implements Ljava/lang/Cloneable;


# instance fields
.field public height:I

.field public imageType:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

.field public startIndex:I

.field public stride:I

.field public subImage:Z

.field public width:I


# direct methods
.method public constructor <init>()V
    .locals 1

    .line 33
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const/4 v0, 0x0

    .line 45
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->subImage:Z

    return-void
.end method


# virtual methods
.method public clone()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;
    .locals 1

    .line 234
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->createSameShape()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    move-result-object v0

    .line 236
    invoke-virtual {v0, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->setTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    return-object v0
.end method

.method public bridge synthetic clone()Ljava/lang/Object;
    .locals 1

    .line 32
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->clone()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    move-result-object v0

    return-object v0
.end method

.method public abstract createNew(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;
.end method

.method public createSameShape()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;
    .locals 2

    .line 175
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-virtual {p0, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->createNew(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    move-result-object v0

    return-object v0
.end method

.method public getHeight()I
    .locals 1

    .line 42
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    return v0
.end method

.method public getImageType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;
    .locals 1

    .line 165
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->imageType:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    return-object v0
.end method

.method public getIndex(II)I
    .locals 2

    .line 136
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p2, v1

    add-int/2addr v0, p2

    add-int/2addr v0, p1

    return v0
.end method

.method public getStartIndex()I
    .locals 1

    .line 35
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    return v0
.end method

.method public getStride()I
    .locals 1

    .line 37
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    return v0
.end method

.method public getWidth()I
    .locals 1

    .line 40
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    return v0
.end method

.method public final isInBounds(II)Z
    .locals 1

    if-ltz p1, :cond_0

    .line 132
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge p1, v0, :cond_0

    if-ltz p2, :cond_0

    iget p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge p2, p1, :cond_0

    const/4 p1, 0x1

    return p1

    :cond_0
    const/4 p1, 0x0

    return p1
.end method

.method public isSubimage()Z
    .locals 1

    .line 121
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->subImage:Z

    return v0
.end method

.method public abstract reshape(II)V
.end method

.method public reshapeTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V
    .locals 1

    .line 103
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-virtual {p0, v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->reshape(II)V

    return-void
.end method

.method public abstract setTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;
.end method
