.class public Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray$GSingle_F64;
.super Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray$GSingleBase;
.source "FactoryGImageGray.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x9
    name = "GSingle_F64"
.end annotation


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;)V
    .locals 0

    .line 547
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray$GSingleBase;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)V

    return-void
.end method


# virtual methods
.method public unsafe_getD(II)D
    .locals 2

    .line 562
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray$GSingleBase;->image:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-object v1, v0

    check-cast v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    iget-object v1, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;->data:[D

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    invoke-virtual {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p1

    aget-wide p1, v1, p1

    return-wide p1
.end method
