.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/NearestNeighborPixelS;
.super Ljava/lang/Object;
.source "NearestNeighborPixelS.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/InterpolatePixelS;


# instance fields
.field protected border:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder;

.field protected height:I

.field protected orig:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

.field protected stride:I

.field protected width:I


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 30
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public setBorder(Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder;)V
    .locals 0

    .line 39
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/NearestNeighborPixelS;->border:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder;

    return-void
.end method

.method public setImage(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)V
    .locals 1

    .line 44
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/NearestNeighborPixelS;->border:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder;

    if-eqz v0, :cond_0

    .line 45
    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder;->setImage(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 46
    :cond_0
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/NearestNeighborPixelS;->orig:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    .line 47
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getStride()I

    move-result p1

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/NearestNeighborPixelS;->stride:I

    .line 48
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/NearestNeighborPixelS;->orig:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result p1

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/NearestNeighborPixelS;->width:I

    .line 49
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/NearestNeighborPixelS;->orig:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result p1

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/NearestNeighborPixelS;->height:I

    return-void
.end method
