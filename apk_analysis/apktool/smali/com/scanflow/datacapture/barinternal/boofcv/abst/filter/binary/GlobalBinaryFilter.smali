.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalBinaryFilter;
.super Ljava/lang/Object;
.source "GlobalBinaryFilter.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalBinaryFilter$Entropy;,
        Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalBinaryFilter$Huang;,
        Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalBinaryFilter$Li;,
        Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalBinaryFilter$Otsu;
    }
.end annotation


# instance fields
.field down:Z

.field inputType:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

.field maxValue:D

.field minValue:D

.field scale:D


# direct methods
.method protected constructor <init>(DDDZLcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;)V
    .locals 0

    .line 49
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 50
    iput-wide p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalBinaryFilter;->minValue:D

    .line 51
    iput-wide p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalBinaryFilter;->maxValue:D

    .line 52
    iput-boolean p7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalBinaryFilter;->down:Z

    .line 53
    iput-wide p5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalBinaryFilter;->scale:D

    .line 54
    iput-object p8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalBinaryFilter;->inputType:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    return-void
.end method


# virtual methods
.method abstract computeThreshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)D
.end method

.method public getInputType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;
    .locals 1

    .line 66
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalBinaryFilter;->inputType:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    return-object v0
.end method

.method public process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
    .locals 5

    .line 59
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalBinaryFilter;->down:Z

    if-eqz v0, :cond_0

    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalBinaryFilter;->scale:D

    goto :goto_0

    :cond_0
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalBinaryFilter;->scale:D

    const-wide/16 v2, 0x0

    cmpg-double v4, v0, v2

    if-gtz v4, :cond_1

    move-wide v0, v2

    goto :goto_0

    :cond_1
    const-wide/high16 v2, 0x3ff0000000000000L    # 1.0

    div-double v0, v2, v0

    .line 60
    :goto_0
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalBinaryFilter;->computeThreshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)D

    move-result-wide v2

    mul-double/2addr v2, v0

    .line 61
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/GlobalBinaryFilter;->down:Z

    invoke-static {p1, p2, v2, v3, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/GThresholdImageOps;->threshold(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;DZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    return-void
.end method
