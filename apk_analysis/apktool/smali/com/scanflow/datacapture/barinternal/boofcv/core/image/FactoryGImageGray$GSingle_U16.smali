.class public Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray$GSingle_U16;
.super Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray$GSingleBaseInt;
.source "FactoryGImageGray.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x9
    name = "GSingle_U16"
.end annotation


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;)V
    .locals 0

    .line 337
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray$GSingleBaseInt;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)V

    return-void
.end method


# virtual methods
.method public unsafe_getD(II)D
    .locals 1

    .line 347
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray$GSingleBase;->image:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    invoke-virtual {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;->unsafe_get(II)I

    move-result p1

    int-to-double p1, p1

    return-wide p1
.end method
