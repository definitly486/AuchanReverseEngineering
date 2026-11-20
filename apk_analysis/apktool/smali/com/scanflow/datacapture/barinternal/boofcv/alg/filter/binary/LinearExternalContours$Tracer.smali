.class Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours$Tracer;
.super Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;
.source "LinearExternalContours.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = "Tracer"
.end annotation


# instance fields
.field public maxContourLengthPixels:I

.field final synthetic this$0:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;)V
    .locals 0

    .line 170
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours$Tracer;->this$0:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;

    .line 171
    invoke-direct {p0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;)V

    const p1, 0x7fffffff

    .line 168
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours$Tracer;->maxContourLengthPixels:I

    return-void
.end method

.method private moveToNext()V
    .locals 3

    .line 303
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->indexBinary:I

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->offsetsBinary:[I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->dir:I

    aget v1, v1, v2

    add-int/2addr v0, v1

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->indexBinary:I

    .line 305
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->binary:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    iget v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    sub-int/2addr v0, v2

    .line 306
    iget v1, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    rem-int v2, v0, v1

    iput v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->x:I

    .line 307
    div-int/2addr v0, v1

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->y:I

    return-void
.end method

.method private searchNotOne4()Z
    .locals 6

    .line 258
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->binary:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->indexBinary:I

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->offsetsBinary:[I

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->dir:I

    aget v4, v2, v3

    add-int/2addr v4, v1

    aget-byte v4, v0, v4

    const/4 v5, 0x1

    if-eqz v4, :cond_0

    return v5

    :cond_0
    add-int/2addr v3, v5

    .line 260
    rem-int/lit8 v3, v3, 0x4

    iput v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->dir:I

    .line 261
    aget v4, v2, v3

    add-int/2addr v4, v1

    aget-byte v4, v0, v4

    if-eqz v4, :cond_1

    return v5

    :cond_1
    add-int/2addr v3, v5

    .line 263
    rem-int/lit8 v3, v3, 0x4

    iput v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->dir:I

    .line 264
    aget v4, v2, v3

    add-int/2addr v4, v1

    aget-byte v4, v0, v4

    if-eqz v4, :cond_2

    return v5

    :cond_2
    add-int/2addr v3, v5

    .line 266
    rem-int/lit8 v3, v3, 0x4

    iput v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->dir:I

    .line 267
    aget v2, v2, v3

    add-int/2addr v1, v2

    aget-byte v0, v0, v1

    if-eqz v0, :cond_3

    return v5

    :cond_3
    add-int/2addr v3, v5

    .line 269
    rem-int/lit8 v3, v3, 0x4

    iput v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->dir:I

    const/4 v0, 0x0

    return v0
.end method

.method private searchNotOne8()Z
    .locals 6

    .line 274
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->binary:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->indexBinary:I

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->offsetsBinary:[I

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->dir:I

    aget v4, v2, v3

    add-int/2addr v4, v1

    aget-byte v4, v0, v4

    const/4 v5, 0x1

    if-eqz v4, :cond_0

    return v5

    :cond_0
    add-int/2addr v3, v5

    .line 276
    rem-int/lit8 v3, v3, 0x8

    iput v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->dir:I

    .line 277
    aget v4, v2, v3

    add-int/2addr v4, v1

    aget-byte v4, v0, v4

    if-eqz v4, :cond_1

    return v5

    :cond_1
    add-int/2addr v3, v5

    .line 279
    rem-int/lit8 v3, v3, 0x8

    iput v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->dir:I

    .line 280
    aget v4, v2, v3

    add-int/2addr v4, v1

    aget-byte v4, v0, v4

    if-eqz v4, :cond_2

    return v5

    :cond_2
    add-int/2addr v3, v5

    .line 282
    rem-int/lit8 v3, v3, 0x8

    iput v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->dir:I

    .line 283
    aget v4, v2, v3

    add-int/2addr v4, v1

    aget-byte v4, v0, v4

    if-eqz v4, :cond_3

    return v5

    :cond_3
    add-int/2addr v3, v5

    .line 285
    rem-int/lit8 v3, v3, 0x8

    iput v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->dir:I

    .line 286
    aget v4, v2, v3

    add-int/2addr v4, v1

    aget-byte v4, v0, v4

    if-eqz v4, :cond_4

    return v5

    :cond_4
    add-int/2addr v3, v5

    .line 288
    rem-int/lit8 v3, v3, 0x8

    iput v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->dir:I

    .line 289
    aget v4, v2, v3

    add-int/2addr v4, v1

    aget-byte v4, v0, v4

    if-eqz v4, :cond_5

    return v5

    :cond_5
    add-int/2addr v3, v5

    .line 291
    rem-int/lit8 v3, v3, 0x8

    iput v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->dir:I

    .line 292
    aget v4, v2, v3

    add-int/2addr v4, v1

    aget-byte v4, v0, v4

    if-eqz v4, :cond_6

    return v5

    :cond_6
    add-int/2addr v3, v5

    .line 294
    rem-int/lit8 v3, v3, 0x8

    iput v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->dir:I

    .line 295
    aget v2, v2, v3

    add-int/2addr v1, v2

    aget-byte v0, v0, v1

    if-eqz v0, :cond_7

    return v5

    :cond_7
    add-int/2addr v3, v5

    .line 297
    rem-int/lit8 v3, v3, 0x8

    iput v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->dir:I

    const/4 v0, 0x0

    return v0
.end method

.method private searchNotZero()Z
    .locals 2

    .line 251
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->ruleN:I

    const/4 v1, 0x4

    if-ne v0, v1, :cond_0

    .line 252
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours$Tracer;->searchNotOne4()Z

    move-result v0

    return v0

    .line 254
    :cond_0
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours$Tracer;->searchNotOne8()Z

    move-result v0

    return v0
.end method


# virtual methods
.method public trace(IIZ)Z
    .locals 8

    const/4 v0, 0x3

    const/4 v1, 0x7

    const/4 v2, 0x6

    const/4 v3, 0x0

    if-eqz p3, :cond_2

    .line 179
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->binary:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    invoke-virtual {v4, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v4

    iput v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->indexBinary:I

    .line 180
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->rule:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;

    sget-object v6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;->EIGHT:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;

    if-ne v5, v6, :cond_1

    .line 181
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->binary:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    iget-object v5, v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->offsetsBinary:[I

    const/4 v7, 0x5

    aget v7, v6, v7

    add-int/2addr v7, v4

    aget-byte v7, v5, v7

    if-nez v7, :cond_0

    aget v7, v6, v2

    add-int/2addr v7, v4

    aget-byte v7, v5, v7

    if-nez v7, :cond_0

    aget v6, v6, v1

    add-int/2addr v4, v6

    aget-byte v4, v5, v4

    if-eqz v4, :cond_2

    :cond_0
    :goto_0
    move p3, v3

    goto :goto_1

    .line 187
    :cond_1
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->binary:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    iget-object v5, v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->offsetsBinary:[I

    aget v6, v6, v0

    add-int/2addr v4, v6

    aget-byte v4, v5, v4

    if-eqz v4, :cond_2

    goto :goto_0

    :cond_2
    :goto_1
    const/4 v4, -0x1

    if-eqz p3, :cond_3

    .line 194
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours$Tracer;->this$0:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;

    invoke-static {v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->-$$Nest$fgetmaxContourLengthPixels(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;)I

    move-result v5

    iput v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours$Tracer;->maxContourLengthPixels:I

    goto :goto_2

    .line 196
    :cond_3
    iput v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours$Tracer;->maxContourLengthPixels:I

    .line 200
    :goto_2
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours$Tracer;->this$0:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;

    invoke-static {v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->-$$Nest$fgetstoragePoints(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;

    move-result-object v5

    invoke-virtual {v5}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->grow()V

    .line 201
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->rule:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;

    sget-object v6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;->EIGHT:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;

    if-ne v5, v6, :cond_5

    if-eqz p3, :cond_4

    goto :goto_3

    :cond_4
    move v1, v2

    .line 202
    :goto_3
    iput v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->dir:I

    goto :goto_4

    :cond_5
    if-eqz p3, :cond_6

    move v0, v3

    .line 204
    :cond_6
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->dir:I

    .line 206
    :goto_4
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->x:I

    .line 207
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->y:I

    .line 211
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->binary:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    invoke-virtual {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v0

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->indexBinary:I

    .line 213
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours$Tracer;->this$0:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->-$$Nest$fgetstoragePoints(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;

    move-result-object v0

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->x:I

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours$Tracer;->this$0:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;

    invoke-static {v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->-$$Nest$fgetadjustX(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;)I

    move-result v2

    sub-int/2addr v1, v2

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->y:I

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours$Tracer;->this$0:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;

    invoke-static {v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->-$$Nest$fgetadjustY(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;)I

    move-result v5

    sub-int/2addr v2, v5

    invoke-virtual {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->addPointToTail(II)V

    .line 214
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->binary:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->indexBinary:I

    const/4 v2, -0x2

    aput-byte v2, v0, v1

    .line 217
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours$Tracer;->searchNotZero()Z

    move-result v0

    if-nez v0, :cond_7

    const/4 p1, 0x1

    return p1

    .line 220
    :cond_7
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->dir:I

    .line 221
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours$Tracer;->moveToNext()V

    .line 222
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->nextDirection:[I

    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->dir:I

    aget v1, v1, v5

    iput v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->dir:I

    .line 225
    :goto_5
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours$Tracer;->searchNotZero()Z

    .line 227
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->binary:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    iget-object v1, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->indexBinary:I

    aget-byte v6, v1, v5

    if-eq v6, v2, :cond_8

    .line 228
    aput-byte v4, v1, v5

    goto :goto_6

    .line 230
    :cond_8
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->x:I

    if-ne v1, p1, :cond_c

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->y:I

    if-eq v1, p2, :cond_9

    goto :goto_7

    .line 234
    :cond_9
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->dir:I

    if-ne v1, v0, :cond_a

    return p3

    .line 238
    :cond_a
    :goto_6
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours$Tracer;->this$0:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;

    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->-$$Nest$fgetstoragePoints(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;

    move-result-object v1

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->sizeOfTail()I

    move-result v1

    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours$Tracer;->maxContourLengthPixels:I

    if-gt v1, v5, :cond_b

    .line 239
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours$Tracer;->this$0:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;

    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->-$$Nest$fgetstoragePoints(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;

    move-result-object v1

    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->x:I

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours$Tracer;->this$0:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;

    invoke-static {v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->-$$Nest$fgetadjustX(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;)I

    move-result v6

    sub-int/2addr v5, v6

    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->y:I

    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours$Tracer;->this$0:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;

    invoke-static {v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->-$$Nest$fgetadjustY(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;)I

    move-result v7

    sub-int/2addr v6, v7

    invoke-virtual {v1, v5, v6}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->addPointToTail(II)V

    .line 241
    :cond_b
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours$Tracer;->moveToNext()V

    .line 242
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->nextDirection:[I

    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->dir:I

    aget v1, v1, v5

    iput v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->dir:I

    goto :goto_5

    :cond_c
    :goto_7
    return v3
.end method
