.class public Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder1D_F64;
.super Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder_F64;
.source "ImageBorder1D_F64.java"


# instance fields
.field colWrap:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderIndex1D;

.field rowWrap:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderIndex1D;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/FactoryBorderIndex1D;)V
    .locals 1

    .line 33
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder_F64;-><init>()V

    .line 34
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/FactoryBorderIndex1D;->newInstance()Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderIndex1D;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder1D_F64;->rowWrap:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderIndex1D;

    .line 35
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/FactoryBorderIndex1D;->newInstance()Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderIndex1D;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder1D_F64;->colWrap:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderIndex1D;

    return-void
.end method


# virtual methods
.method public getOutside(II)D
    .locals 2

    .line 61
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder;->image:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder1D_F64;->colWrap:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderIndex1D;

    invoke-virtual {v1, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderIndex1D;->getIndex(I)I

    move-result p1

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder1D_F64;->rowWrap:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderIndex1D;

    invoke-virtual {v1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderIndex1D;->getIndex(I)I

    move-result p2

    invoke-virtual {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;->get(II)D

    move-result-wide p1

    return-wide p1
.end method

.method public setImage(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;)V
    .locals 2

    .line 49
    invoke-super {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder;->setImage(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 50
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder1D_F64;->colWrap:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderIndex1D;

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderIndex1D;->setLength(I)V

    .line 51
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder1D_F64;->rowWrap:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderIndex1D;

    iget p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderIndex1D;->setLength(I)V

    return-void
.end method

.method public bridge synthetic setImage(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V
    .locals 0

    .line 29
    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder1D_F64;->setImage(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;)V

    return-void
.end method
