.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;
.super Ljava/lang/Object;
.source "ContourTracerBase.java"


# instance fields
.field protected binary:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

.field protected dir:I

.field protected indexBinary:I

.field protected nextDirection:[I

.field protected offsetsBinary:[I

.field protected final rule:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;

.field protected final ruleN:I

.field protected x:I

.field protected y:I


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;)V
    .locals 3

    .line 57
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 58
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->rule:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;

    .line 60
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;->EIGHT:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;

    const/4 v1, 0x0

    if-ne v0, p1, :cond_1

    const/16 p1, 0x8

    .line 63
    new-array v0, p1, [I

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->nextDirection:[I

    :goto_0
    if-ge v1, p1, :cond_0

    .line 65
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->nextDirection:[I

    add-int/lit8 v2, v1, 0x4

    rem-int/2addr v2, p1

    add-int/lit8 v2, v2, 0x2

    rem-int/2addr v2, p1

    aput v2, v0, v1

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    .line 66
    :cond_0
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->ruleN:I

    goto :goto_2

    .line 67
    :cond_1
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;->FOUR:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;

    if-ne v0, p1, :cond_3

    const/4 p1, 0x4

    .line 68
    new-array v0, p1, [I

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->nextDirection:[I

    :goto_1
    if-ge v1, p1, :cond_2

    .line 70
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->nextDirection:[I

    add-int/lit8 v2, v1, 0x2

    rem-int/2addr v2, p1

    add-int/lit8 v2, v2, 0x1

    rem-int/2addr v2, p1

    aput v2, v0, v1

    add-int/lit8 v1, v1, 0x1

    goto :goto_1

    .line 71
    :cond_2
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->ruleN:I

    .line 76
    :goto_2
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->ruleN:I

    new-array p1, p1, [I

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->offsetsBinary:[I

    return-void

    .line 73
    :cond_3
    new-instance v0, Ljava/lang/IllegalArgumentException;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Connectivity rule must be 4 or 8 not "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {v0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method private setOffsets4([II)V
    .locals 2

    const/4 v0, 0x0

    const/4 v1, 0x1

    .line 108
    aput v1, p1, v0

    .line 109
    aput p2, p1, v1

    const/4 v0, 0x2

    const/4 v1, -0x1

    .line 110
    aput v1, p1, v0

    const/4 v0, 0x3

    neg-int p2, p2

    .line 111
    aput p2, p1, v0

    return-void
.end method

.method private setOffsets8([II)V
    .locals 3

    const/4 v0, 0x0

    const/4 v1, 0x1

    .line 96
    aput v1, p1, v0

    add-int/lit8 v0, p2, 0x1

    .line 97
    aput v0, p1, v1

    const/4 v0, 0x2

    .line 98
    aput p2, p1, v0

    add-int/lit8 v0, p2, -0x1

    const/4 v2, 0x3

    .line 99
    aput v0, p1, v2

    const/4 v0, 0x4

    const/4 v2, -0x1

    .line 100
    aput v2, p1, v0

    rsub-int/lit8 v0, p2, -0x1

    const/4 v2, 0x5

    .line 101
    aput v0, p1, v2

    const/4 v0, 0x6

    neg-int v2, p2

    .line 102
    aput v2, p1, v0

    const/4 v0, 0x7

    sub-int/2addr v1, p2

    .line 103
    aput v1, p1, v0

    return-void
.end method


# virtual methods
.method public setInputs(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
    .locals 2

    .line 85
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->binary:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    .line 87
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->rule:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;->EIGHT:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;

    if-ne v0, v1, :cond_0

    .line 88
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->offsetsBinary:[I

    iget p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    invoke-direct {p0, v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->setOffsets8([II)V

    return-void

    .line 90
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->offsetsBinary:[I

    iget p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    invoke-direct {p0, v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourTracerBase;->setOffsets4([II)V

    return-void
.end method
