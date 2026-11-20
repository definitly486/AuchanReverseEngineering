.class public Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalFixedBinaryFilter;
.super Ljava/lang/Object;
.source "GlobalFixedBinaryFilter.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;


# instance fields
.field down:Z

.field inputType:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

.field threshold:D


# direct methods
.method public constructor <init>(DZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;)V
    .locals 0

    .line 43
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 44
    iput-wide p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalFixedBinaryFilter;->threshold:D

    .line 45
    iput-boolean p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalFixedBinaryFilter;->down:Z

    .line 46
    iput-object p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalFixedBinaryFilter;->inputType:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    return-void
.end method


# virtual methods
.method public getInputType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;
    .locals 1

    .line 56
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalFixedBinaryFilter;->inputType:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    return-object v0
.end method

.method public bridge synthetic process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
    .locals 0

    .line 33
    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalFixedBinaryFilter;->process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    return-void
.end method

.method public process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
    .locals 3

    .line 51
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalFixedBinaryFilter;->threshold:D

    iget-boolean v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalFixedBinaryFilter;->down:Z

    invoke-static {p1, p2, v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/GThresholdImageOps;->threshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;DZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    return-void
.end method
