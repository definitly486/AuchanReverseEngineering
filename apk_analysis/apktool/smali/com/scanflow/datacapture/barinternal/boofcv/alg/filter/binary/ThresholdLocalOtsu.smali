.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;
.super Ljava/lang/Object;
.source "ThresholdLocalOtsu.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;
    }
.end annotation


# instance fields
.field private final down:Z

.field helpers:Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack;

.field imageType:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

.field numPixels:I

.field regionWidth:I

.field regionWidthLength:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

.field private final scale:D

.field private final tuning:D

.field private final useOtsu2:Z


# direct methods
.method public static synthetic $r8$lambda$XG_-ZRSFmmuDVB2y8CiM5vm4n3U(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;)Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;
    .locals 1

    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 58
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;)V

    return-object v0
.end method

.method static bridge synthetic -$$Nest$fgetdown(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;)Z
    .locals 0

    .line 0
    iget-boolean p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->down:Z

    return p0
.end method

.method static bridge synthetic -$$Nest$fgetscale(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;)D
    .locals 2

    .line 0
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->scale:D

    return-wide v0
.end method

.method static bridge synthetic -$$Nest$fgettuning(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;)D
    .locals 2

    .line 0
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->tuning:D

    return-wide v0
.end method

.method static bridge synthetic -$$Nest$fgetuseOtsu2(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;)Z
    .locals 0

    .line 0
    iget-boolean p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->useOtsu2:Z

    return p0
.end method

.method public constructor <init>(ZLcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;DDZ)V
    .locals 2

    .line 66
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 43
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->single(Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->imageType:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    .line 58
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$$ExternalSyntheticLambda0;

    invoke-direct {v1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$$ExternalSyntheticLambda0;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;)V

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack$Factory;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->helpers:Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack;

    .line 67
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->regionWidthLength:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    .line 68
    iput-boolean p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->useOtsu2:Z

    .line 69
    iput-wide p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->tuning:D

    .line 70
    iput-wide p5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->scale:D

    .line 71
    iput-boolean p7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->down:Z

    return-void
.end method


# virtual methods
.method applyToBorder(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;IIIILcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;)V
    .locals 13

    move/from16 v7, p4

    move/from16 v8, p6

    move-object/from16 v0, p7

    const/4 v9, 0x0

    .line 136
    invoke-virtual {v0, v9, v9, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->computeHistogram(IILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    add-int/lit8 v3, p5, 0x1

    add-int/lit8 v4, p3, 0x1

    const/4 v1, 0x0

    const/4 v2, 0x0

    move-object v5, p1

    move-object v6, p2

    .line 137
    invoke-static/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->-$$Nest$mapplyToBlock(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;IIIILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    move v10, v3

    move v11, v4

    move v1, v10

    :goto_0
    if-ge v1, v8, :cond_0

    sub-int v2, v1, p5

    .line 140
    invoke-virtual {v0, v2, v9, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->updateHistogramX(IILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    add-int/lit8 v3, v1, 0x1

    const/4 v2, 0x0

    move-object v5, p1

    move-object v6, p2

    move/from16 v4, p3

    .line 141
    invoke-static/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->-$$Nest$mapplyToBlock(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;IIIILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    move v1, v3

    goto :goto_0

    :cond_0
    sub-int v12, v8, p5

    .line 144
    invoke-virtual {v0, v12, v9, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->updateHistogramX(IILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    const/4 v2, 0x0

    .line 145
    iget v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    move-object v5, p1

    move-object v6, p2

    move v1, v8

    move v4, v11

    invoke-static/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->-$$Nest$mapplyToBlock(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;IIIILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    move v2, v11

    :goto_1
    if-ge v2, v7, :cond_1

    sub-int v1, v2, p3

    .line 149
    invoke-virtual {v0, v12, v1, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->updateHistogramY(IILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    .line 150
    iget v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/lit8 v4, v2, 0x1

    move-object v5, p1

    move-object v6, p2

    move/from16 v1, p6

    invoke-static/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->-$$Nest$mapplyToBlock(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;IIIILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    move v2, v4

    goto :goto_1

    :cond_1
    sub-int v8, v7, p3

    .line 154
    invoke-virtual {v0, v12, v8, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->updateHistogramY(IILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    .line 155
    iget v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    move-object v5, p1

    move-object v6, p2

    move/from16 v1, p6

    move v2, v7

    invoke-static/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->-$$Nest$mapplyToBlock(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;IIIILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    move v12, v1

    .line 160
    invoke-virtual {v0, v9, v9, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->computeHistogram(IILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    move v2, v11

    :goto_2
    if-ge v2, v7, :cond_2

    sub-int v1, v2, p3

    .line 163
    invoke-virtual {v0, v9, v1, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->updateHistogramY(IILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    add-int/lit8 v4, v2, 0x1

    const/4 v1, 0x0

    move-object v5, p1

    move-object v6, p2

    move/from16 v3, p5

    .line 164
    invoke-static/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->-$$Nest$mapplyToBlock(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;IIIILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    move v2, v4

    goto :goto_2

    .line 168
    :cond_2
    invoke-virtual {v0, v9, v8, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->updateHistogramY(IILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    const/4 v1, 0x0

    .line 169
    iget v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    move-object v5, p1

    move-object v6, p2

    move v2, v7

    move v3, v10

    invoke-static/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->-$$Nest$mapplyToBlock(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;IIIILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    :goto_3
    move v1, v3

    if-ge v1, v12, :cond_3

    sub-int v2, v1, p5

    .line 173
    invoke-virtual {v0, v2, v8, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->updateHistogramX(IILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    add-int/lit8 v3, v1, 0x1

    .line 174
    iget v4, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    move-object v5, p1

    move-object v6, p2

    move/from16 v2, p4

    invoke-static/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->-$$Nest$mapplyToBlock(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;IIIILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    move-object/from16 v0, p7

    goto :goto_3

    :cond_3
    return-void
.end method

.method public getInputType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;
    .locals 1

    .line 240
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->imageType:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    return-object v0
.end method

.method public process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
    .locals 11

    .line 82
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-virtual {p2, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(II)V

    .line 84
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->regionWidthLength:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-static {v1, v2}, Ljava/lang/Math;->min(II)I

    move-result v1

    int-to-double v1, v1

    invoke-virtual {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->computeI(D)I

    move-result v0

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->regionWidth:I

    .line 86
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-lt v1, v0, :cond_0

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v2, v0, :cond_1

    .line 87
    :cond_0
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    invoke-static {v1, v0}, Ljava/lang/Math;->min(II)I

    move-result v0

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->regionWidth:I

    .line 90
    :cond_1
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->regionWidth:I

    mul-int v1, v0, v0

    iput v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->numPixels:I

    .line 92
    div-int/lit8 v6, v0, 0x2

    .line 93
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    sub-int v2, v0, v6

    sub-int v8, v1, v2

    .line 94
    div-int/lit8 v5, v0, 0x2

    .line 95
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    sub-int/2addr v0, v5

    sub-int v7, v1, v0

    .line 98
    iget-boolean v9, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->down:Z

    xor-int/lit8 v10, v9, 0x1

    move-object v2, p0

    move-object v3, p1

    move-object v4, p2

    .line 106
    invoke-virtual/range {v2 .. v10}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;IIIIBB)V

    return-void
.end method

.method protected process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;IIIIBB)V
    .locals 16

    move-object/from16 v0, p0

    move-object/from16 v1, p1

    move-object/from16 v2, p2

    .line 111
    iget-object v3, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->helpers:Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack;

    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack;->pop()Ljava/lang/Object;

    move-result-object v3

    move-object v7, v3

    check-cast v7, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;

    move/from16 v3, p4

    :goto_0
    move/from16 v4, p6

    if-ge v3, v4, :cond_3

    .line 113
    iget v5, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v6, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v6, v3

    add-int/2addr v5, v6

    add-int v5, v5, p3

    .line 114
    iget v6, v2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v8, v2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v8, v3

    add-int/2addr v6, v8

    add-int v6, v6, p3

    sub-int v8, v3, p4

    const/4 v9, 0x0

    .line 116
    invoke-virtual {v7, v9, v8, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->computeHistogram(IILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    .line 117
    iget-object v9, v2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v10, v6, 0x1

    iget-object v11, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v12, v5, 0x1

    aget-byte v5, v11, v5

    and-int/lit16 v5, v5, 0xff

    int-to-double v13, v5

    iget-object v5, v7, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->otsu:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;

    move v11, v3

    iget-wide v3, v5, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;->threshold:D

    cmpg-double v3, v13, v3

    if-gtz v3, :cond_0

    move/from16 v3, p7

    goto :goto_1

    :cond_0
    move/from16 v3, p8

    :goto_1
    aput-byte v3, v9, v6

    add-int/lit8 v3, p3, 0x1

    move/from16 v6, p5

    :goto_2
    if-ge v3, v6, :cond_2

    sub-int v4, v3, p3

    .line 120
    invoke-virtual {v7, v4, v8, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->updateHistogramX(IILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    .line 121
    iget-object v4, v2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v5, v10, 0x1

    iget-object v9, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v13, v12, 0x1

    aget-byte v9, v9, v12

    and-int/lit16 v9, v9, 0xff

    int-to-double v14, v9

    iget-object v9, v7, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->otsu:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;

    iget-wide v0, v9, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;->threshold:D

    cmpg-double v0, v14, v0

    if-gtz v0, :cond_1

    move/from16 v0, p7

    goto :goto_3

    :cond_1
    move/from16 v0, p8

    :goto_3
    aput-byte v0, v4, v10

    add-int/lit8 v3, v3, 0x1

    move-object/from16 v0, p0

    move-object/from16 v1, p1

    move v10, v5

    move v12, v13

    goto :goto_2

    :cond_2
    add-int/lit8 v3, v11, 0x1

    move-object/from16 v0, p0

    move-object/from16 v1, p1

    goto :goto_0

    :cond_3
    move/from16 v5, p3

    move/from16 v3, p4

    move/from16 v6, p5

    .line 126
    invoke-virtual/range {v0 .. v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->applyToBorder(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;IIIILcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;)V

    .line 127
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->helpers:Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack;

    invoke-virtual {v1, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack;->recycle(Ljava/lang/Object;)V

    return-void
.end method

.method public bridge synthetic process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
    .locals 0

    .line 40
    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    return-void
.end method
