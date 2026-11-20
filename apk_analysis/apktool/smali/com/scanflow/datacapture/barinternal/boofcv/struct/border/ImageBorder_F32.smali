.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder_F32;
.super Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder;
.source "ImageBorder_F32.java"


# direct methods
.method protected constructor <init>()V
    .locals 0

    .line 36
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder;-><init>()V

    return-void
.end method


# virtual methods
.method public get(II)F
    .locals 1

    .line 46
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder;->image:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    invoke-virtual {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->isInBounds(II)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 47
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder;->image:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    invoke-virtual {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->get(II)F

    move-result p1

    return p1

    .line 49
    :cond_0
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder_F32;->getOutside(II)F

    move-result p1

    return p1
.end method

.method public abstract getOutside(II)F
.end method
