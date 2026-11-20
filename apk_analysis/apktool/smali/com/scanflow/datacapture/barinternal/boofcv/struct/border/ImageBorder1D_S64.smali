.class public Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder1D_S64;
.super Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder_S64;
.source "ImageBorder1D_S64.java"


# instance fields
.field colWrap:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderIndex1D;

.field rowWrap:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderIndex1D;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/FactoryBorderIndex1D;)V
    .locals 1

    .line 33
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder_S64;-><init>()V

    .line 34
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/FactoryBorderIndex1D;->newInstance()Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderIndex1D;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder1D_S64;->rowWrap:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderIndex1D;

    .line 35
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/FactoryBorderIndex1D;->newInstance()Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderIndex1D;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder1D_S64;->colWrap:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderIndex1D;

    return-void
.end method


# virtual methods
.method public setImage(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;)V
    .locals 2

    .line 55
    invoke-super {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder;->setImage(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 56
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder1D_S64;->colWrap:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderIndex1D;

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderIndex1D;->setLength(I)V

    .line 57
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder1D_S64;->rowWrap:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderIndex1D;

    iget p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderIndex1D;->setLength(I)V

    return-void
.end method

.method public bridge synthetic setImage(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V
    .locals 0

    .line 29
    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder1D_S64;->setImage(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;)V

    return-void
.end method
