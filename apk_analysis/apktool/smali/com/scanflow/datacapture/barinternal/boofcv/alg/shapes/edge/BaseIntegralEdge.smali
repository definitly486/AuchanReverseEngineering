.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/BaseIntegralEdge;
.super Ljava/lang/Object;
.source "BaseIntegralEdge.java"


# instance fields
.field imageType:Ljava/lang/Class;

.field protected integral:Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/ImageLineIntegral;

.field protected integralImage:Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GImageGray;


# direct methods
.method public constructor <init>(Ljava/lang/Class;)V
    .locals 1

    .line 45
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 46
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/BaseIntegralEdge;->imageType:Ljava/lang/Class;

    .line 47
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/ImageLineIntegral;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/ImageLineIntegral;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/BaseIntegralEdge;->integral:Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/ImageLineIntegral;

    .line 48
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray;->create(Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GImageGray;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/BaseIntegralEdge;->integralImage:Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GImageGray;

    return-void
.end method


# virtual methods
.method public setImage(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)V
    .locals 1

    .line 72
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/BaseIntegralEdge;->integralImage:Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GImageGray;

    invoke-interface {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GImageGray;->wrap(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)V

    .line 73
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/BaseIntegralEdge;->integral:Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/ImageLineIntegral;

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/edge/BaseIntegralEdge;->integralImage:Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GImageGray;

    invoke-virtual {p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/interpolate/ImageLineIntegral;->setImage(Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GImageGray;)V

    return-void
.end method
