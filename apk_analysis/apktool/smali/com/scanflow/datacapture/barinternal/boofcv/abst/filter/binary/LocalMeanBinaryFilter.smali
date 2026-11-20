.class public Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/LocalMeanBinaryFilter;
.super Ljava/lang/Object;
.source "LocalMeanBinaryFilter.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;


# instance fields
.field down:Z

.field inputType:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

.field regionWidth:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

.field scale:D

.field work1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

.field work2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

.field work3:Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;DZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;)V
    .locals 0

    .line 52
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 53
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/LocalMeanBinaryFilter;->regionWidth:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    .line 54
    iput-wide p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/LocalMeanBinaryFilter;->scale:D

    .line 55
    iput-boolean p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/LocalMeanBinaryFilter;->down:Z

    .line 56
    iput-object p5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/LocalMeanBinaryFilter;->inputType:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    const/4 p1, 0x1

    .line 57
    invoke-virtual {p5, p1, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->createImage(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    move-result-object p2

    check-cast p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/LocalMeanBinaryFilter;->work1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    .line 58
    invoke-virtual {p5, p1, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->createImage(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/LocalMeanBinaryFilter;->work2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    .line 59
    invoke-static {p5}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GeneralizedImageOps;->createGrowArray(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;)Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/LocalMeanBinaryFilter;->work3:Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;

    return-void
.end method


# virtual methods
.method public getInputType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;
    .locals 1

    .line 71
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/LocalMeanBinaryFilter;->inputType:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    return-object v0
.end method

.method public bridge synthetic process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
    .locals 0

    .line 36
    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/LocalMeanBinaryFilter;->process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    return-void
.end method

.method public process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
    .locals 12

    .line 64
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/LocalMeanBinaryFilter;->work1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-virtual {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(II)V

    .line 65
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/LocalMeanBinaryFilter;->work2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-virtual {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(II)V

    .line 66
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/LocalMeanBinaryFilter;->regionWidth:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    iget-wide v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/LocalMeanBinaryFilter;->scale:D

    iget-boolean v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/LocalMeanBinaryFilter;->down:Z

    iget-object v9, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/LocalMeanBinaryFilter;->work1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    iget-object v10, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/LocalMeanBinaryFilter;->work2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    iget-object v11, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/LocalMeanBinaryFilter;->work3:Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;

    move-object v3, p1

    move-object v4, p2

    invoke-static/range {v3 .. v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/GThresholdImageOps;->localMean(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;DZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    return-void
.end method
