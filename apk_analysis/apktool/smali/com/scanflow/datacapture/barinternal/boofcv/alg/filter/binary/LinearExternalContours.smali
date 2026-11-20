.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;
.super Ljava/lang/Object;
.source "LinearExternalContours.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours$Tracer;
    }
.end annotation


# instance fields
.field private adjustX:I

.field private adjustY:I

.field private maxContourLength:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

.field private maxContourLengthPixels:I

.field private minContourLength:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

.field private minContourLengthPixels:I

.field private final storagePoints:Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;

.field private tracer:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours$Tracer;


# direct methods
.method static bridge synthetic -$$Nest$fgetadjustX(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;)I
    .locals 0

    .line 0
    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->adjustX:I

    return p0
.end method

.method static bridge synthetic -$$Nest$fgetadjustY(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;)I
    .locals 0

    .line 0
    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->adjustY:I

    return p0
.end method

.method static bridge synthetic -$$Nest$fgetmaxContourLengthPixels(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;)I
    .locals 0

    .line 0
    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->maxContourLengthPixels:I

    return p0
.end method

.method static bridge synthetic -$$Nest$fgetstoragePoints(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;
    .locals 0

    .line 0
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->storagePoints:Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;

    return-object p0
.end method

.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;)V
    .locals 2

    .line 75
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const-wide/high16 v0, -0x4010000000000000L    # -1.0

    .line 61
    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->fixed(D)Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->maxContourLength:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    const-wide/16 v0, 0x0

    .line 63
    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->fixed(D)Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->minContourLength:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    .line 73
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->storagePoints:Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;

    .line 76
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours$Tracer;

    invoke-direct {v0, p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours$Tracer;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->tracer:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours$Tracer;

    return-void
.end method

.method static findNotZero([BII)I
    .locals 1

    :goto_0
    if-ge p1, p2, :cond_0

    .line 150
    aget-byte v0, p0, p1

    if-nez v0, :cond_0

    add-int/lit8 p1, p1, 0x1

    goto :goto_0

    :cond_0
    return p1
.end method

.method static findZero([BII)I
    .locals 1

    :goto_0
    if-ge p1, p2, :cond_0

    .line 160
    aget-byte v0, p0, p1

    if-eqz v0, :cond_0

    add-int/lit8 p1, p1, 0x1

    goto :goto_0

    :cond_0
    return p1
.end method


# virtual methods
.method public getExternalContours()Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;
    .locals 1

    .line 320
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->storagePoints:Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;

    return-object v0
.end method

.method public getMinContourLength()Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;
    .locals 1

    .line 63
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->minContourLength:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    return-object v0
.end method

.method public process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;II)V
    .locals 7

    .line 88
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->minContourLength:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    mul-int/2addr v1, v2

    int-to-double v1, v1

    invoke-static {v1, v2}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide v1

    invoke-virtual {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->computeNegMaxI(D)I

    move-result v0

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->minContourLengthPixels:I

    .line 89
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->maxContourLength:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    mul-int/2addr v1, v2

    int-to-double v1, v1

    invoke-static {v1, v2}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide v1

    invoke-virtual {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;->computeNegMaxI(D)I

    move-result v0

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->maxContourLengthPixels:I

    .line 90
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->adjustX:I

    .line 91
    iput p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->adjustY:I

    .line 92
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->storagePoints:Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;

    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->reset()V

    const/4 p2, 0x0

    const/4 p3, 0x1

    .line 93
    invoke-static {p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/ImageMiscOps;->fillBorder(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;II)V

    .line 95
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->tracer:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours$Tracer;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->setInputs(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    .line 96
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    move v1, p3

    .line 99
    :goto_0
    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    sub-int/2addr v2, p3

    if-ge v1, v2, :cond_6

    .line 101
    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v3, v1

    add-int/2addr v2, v3

    add-int/2addr v2, p3

    .line 103
    iget v3, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    add-int/2addr v3, v2

    add-int/lit8 v3, v3, -0x2

    move v4, p3

    .line 106
    :goto_1
    invoke-static {v0, v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->findNotZero([BII)I

    move-result v5

    sub-int/2addr v5, v2

    add-int/2addr v2, v5

    if-ne v2, v3, :cond_0

    goto :goto_3

    :cond_0
    add-int/2addr v4, v5

    .line 114
    aget-byte v5, v0, v2

    if-ne v5, p3, :cond_3

    .line 115
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->tracer:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours$Tracer;

    invoke-virtual {v5, v4, v1, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours$Tracer;->trace(IIZ)Z

    move-result v5

    if-eqz v5, :cond_2

    .line 116
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->storagePoints:Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;

    invoke-virtual {v5}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->sizeOfTail()I

    move-result v5

    .line 117
    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->minContourLengthPixels:I

    if-lt v5, v6, :cond_1

    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->maxContourLengthPixels:I

    if-lt v5, v6, :cond_3

    .line 118
    :cond_1
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->storagePoints:Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;

    invoke-virtual {v5}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->removeTail()V

    goto :goto_2

    .line 121
    :cond_2
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->storagePoints:Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;

    invoke-virtual {v5}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->removeTail()V

    .line 126
    :cond_3
    :goto_2
    invoke-static {v0, v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->findZero([BII)I

    move-result v5

    sub-int/2addr v5, v2

    add-int/2addr v2, v5

    if-ne v2, v3, :cond_4

    :goto_3
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_4
    add-int/2addr v4, v5

    add-int/lit8 v5, v2, -0x1

    .line 134
    aget-byte v6, v0, v5

    if-ne v6, p3, :cond_5

    .line 135
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->tracer:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours$Tracer;

    add-int/lit8 v6, v4, -0x1

    invoke-virtual {v5, v6, v1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours$Tracer;->trace(IIZ)Z

    .line 136
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->storagePoints:Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;

    invoke-virtual {v5}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->removeTail()V

    goto :goto_1

    :cond_5
    const/4 v6, -0x2

    .line 140
    aput-byte v6, v0, v5

    goto :goto_1

    :cond_6
    return-void
.end method

.method public setConnectRule(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;)V
    .locals 1

    .line 316
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours$Tracer;

    invoke-direct {v0, p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours$Tracer;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->tracer:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours$Tracer;

    return-void
.end method

.method public setMaxContourLength(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;)V
    .locals 0

    .line 61
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->maxContourLength:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    return-void
.end method

.method public setMinContourLength(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;)V
    .locals 0

    .line 63
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/LinearExternalContours;->minContourLength:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;

    return-void
.end method
