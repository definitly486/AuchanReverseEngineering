.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder_F64;
.super Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder;
.source "ImageBorder_F64.java"


# direct methods
.method protected constructor <init>()V
    .locals 0

    .line 34
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder;-><init>()V

    return-void
.end method


# virtual methods
.method public get(II)D
    .locals 1

    .line 44
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder;->image:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    invoke-virtual {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->isInBounds(II)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 45
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder;->image:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    invoke-virtual {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;->get(II)D

    move-result-wide p1

    return-wide p1

    .line 47
    :cond_0
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder_F64;->getOutside(II)D

    move-result-wide p1

    return-wide p1
.end method

.method public abstract getOutside(II)D
.end method
