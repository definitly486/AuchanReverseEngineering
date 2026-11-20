.class Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;
.super Ljava/lang/Object;
.source "ThresholdLocalOtsu.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = "ApplyHelper"
.end annotation


# instance fields
.field histogram:[I

.field otsu:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;

.field final synthetic this$0:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;


# direct methods
.method static bridge synthetic -$$Nest$mapplyToBlock(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;IIIILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
    .locals 0

    .line 0
    invoke-direct/range {p0 .. p6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->applyToBlock(IIIILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    return-void
.end method

.method constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;)V
    .locals 8

    .line 178
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->this$0:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const/16 v0, 0x100

    .line 179
    new-array v0, v0, [I

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->histogram:[I

    .line 180
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->-$$Nest$fgetuseOtsu2(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;)Z

    move-result v2

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->-$$Nest$fgettuning(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;)D

    move-result-wide v3

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->-$$Nest$fgetdown(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;)Z

    move-result v5

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->-$$Nest$fgetscale(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;)D

    move-result-wide v6

    invoke-direct/range {v1 .. v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;-><init>(ZDZD)V

    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->otsu:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;

    return-void
.end method

.method private applyToBlock(IIIILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
    .locals 16

    move-object/from16 v0, p0

    move-object/from16 v1, p5

    move-object/from16 v2, p6

    .line 185
    iget-object v3, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->otsu:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;

    iget-boolean v3, v3, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;->down:Z

    xor-int/lit8 v4, v3, 0x1

    move/from16 v5, p2

    move/from16 v6, p4

    :goto_0
    if-ge v5, v6, :cond_2

    .line 194
    iget v7, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v8, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v8, v5

    add-int/2addr v7, v8

    add-int v7, v7, p1

    .line 195
    iget v8, v2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v9, v2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v9, v5

    add-int/2addr v8, v9

    add-int v8, v8, p1

    sub-int v9, p3, p1

    add-int/2addr v9, v8

    :goto_1
    if-ge v8, v9, :cond_1

    .line 198
    iget-object v10, v2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v11, v8, 0x1

    iget-object v12, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v13, v7, 0x1

    aget-byte v7, v12, v7

    and-int/lit16 v7, v7, 0xff

    int-to-double v14, v7

    iget-object v7, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->otsu:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;

    iget-wide v0, v7, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;->threshold:D

    cmpg-double v0, v14, v0

    if-gtz v0, :cond_0

    move v0, v3

    goto :goto_2

    :cond_0
    move v0, v4

    :goto_2
    aput-byte v0, v10, v8

    move-object/from16 v0, p0

    move-object/from16 v1, p5

    move v8, v11

    move v7, v13

    goto :goto_1

    :cond_1
    add-int/lit8 v5, v5, 0x1

    move-object/from16 v0, p0

    move-object/from16 v1, p5

    goto :goto_0

    :cond_2
    return-void
.end method


# virtual methods
.method computeHistogram(IILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
    .locals 7

    .line 205
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->histogram:[I

    const/4 v1, 0x0

    invoke-static {v0, v1}, Ljava/util/Arrays;->fill([II)V

    move v0, v1

    .line 206
    :goto_0
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->this$0:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;

    iget v3, v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->regionWidth:I

    if-ge v0, v3, :cond_1

    .line 207
    iget v2, p3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    add-int v3, p2, v0

    iget v4, p3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v3, v4

    add-int/2addr v2, v3

    add-int/2addr v2, p1

    move v3, v1

    .line 208
    :goto_1
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->this$0:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;

    iget v4, v4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->regionWidth:I

    if-ge v3, v4, :cond_0

    .line 209
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->histogram:[I

    iget-object v5, p3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v6, v2, 0x1

    aget-byte v2, v5, v2

    and-int/lit16 v2, v2, 0xff

    aget v5, v4, v2

    add-int/lit8 v5, v5, 0x1

    aput v5, v4, v2

    add-int/lit8 v3, v3, 0x1

    move v2, v6

    goto :goto_1

    :cond_0
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    .line 212
    :cond_1
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->otsu:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;

    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->histogram:[I

    array-length p3, p2

    iget v0, v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->numPixels:I

    invoke-virtual {p1, p2, p3, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;->compute([III)V

    return-void
.end method

.method updateHistogramX(IILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
    .locals 5

    if-gtz p1, :cond_0

    return-void

    .line 217
    :cond_0
    iget v0, p3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, p3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr p2, v1

    add-int/2addr v0, p2

    add-int/2addr v0, p1

    add-int/lit8 v0, v0, -0x1

    const/4 p1, 0x0

    .line 218
    :goto_0
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->this$0:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;

    iget v1, p2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->regionWidth:I

    if-ge p1, v1, :cond_1

    .line 219
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->histogram:[I

    iget-object v2, p3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aget-byte v3, v2, v0

    and-int/lit16 v3, v3, 0xff

    aget v4, p2, v3

    add-int/lit8 v4, v4, -0x1

    aput v4, p2, v3

    add-int/2addr v1, v0

    .line 220
    aget-byte v1, v2, v1

    and-int/lit16 v1, v1, 0xff

    aget v2, p2, v1

    add-int/lit8 v2, v2, 0x1

    aput v2, p2, v1

    .line 221
    iget p2, p3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int/2addr v0, p2

    add-int/lit8 p1, p1, 0x1

    goto :goto_0

    .line 223
    :cond_1
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->otsu:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;

    iget-object p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->histogram:[I

    array-length v0, p3

    iget p2, p2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->numPixels:I

    invoke-virtual {p1, p3, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;->compute([III)V

    return-void
.end method

.method updateHistogramY(IILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
    .locals 7

    if-gtz p2, :cond_0

    return-void

    .line 228
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->this$0:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;

    iget v0, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->regionWidth:I

    iget v1, p3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v0, v1

    const/4 v1, 0x0

    .line 229
    :goto_0
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->this$0:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;

    iget v3, v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->regionWidth:I

    if-ge v1, v3, :cond_1

    .line 230
    iget v2, p3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    add-int/lit8 v3, p2, -0x1

    iget v4, p3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v3, v4

    add-int/2addr v2, v3

    add-int/2addr v2, p1

    add-int/2addr v2, v1

    .line 231
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->histogram:[I

    iget-object v4, p3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aget-byte v5, v4, v2

    and-int/lit16 v5, v5, 0xff

    aget v6, v3, v5

    add-int/lit8 v6, v6, -0x1

    aput v6, v3, v5

    add-int/2addr v2, v0

    .line 232
    aget-byte v2, v4, v2

    and-int/lit16 v2, v2, 0xff

    aget v4, v3, v2

    add-int/lit8 v4, v4, 0x1

    aput v4, v3, v2

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    .line 234
    :cond_1
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->otsu:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;

    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu$ApplyHelper;->histogram:[I

    array-length p3, p2

    iget v0, v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu;->numPixels:I

    invoke-virtual {p1, p2, p3, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ComputeOtsu;->compute([III)V

    return-void
.end method
