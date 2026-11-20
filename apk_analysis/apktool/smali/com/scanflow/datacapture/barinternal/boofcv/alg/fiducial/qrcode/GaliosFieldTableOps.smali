.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;
.super Ljava/lang/Object;
.source "GaliosFieldTableOps.java"


# instance fields
.field protected exp:[I

.field protected log:[I

.field protected max_value:I

.field protected numBits:I

.field protected num_values:I

.field protected primitive:I


# direct methods
.method public constructor <init>(II)V
    .locals 5

    .line 46
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const/4 v0, 0x1

    if-lt p1, v0, :cond_3

    const/16 v1, 0x10

    if-gt p1, v1, :cond_3

    .line 50
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->numBits:I

    .line 51
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->primitive:I

    const/4 v1, 0x0

    .line 52
    iput v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->max_value:I

    move v2, v1

    :goto_0
    if-ge v2, p1, :cond_0

    .line 54
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->max_value:I

    shl-int v4, v0, v2

    or-int/2addr v3, v4

    iput v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->max_value:I

    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    .line 56
    :cond_0
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->max_value:I

    add-int/2addr p1, v0

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->num_values:I

    .line 58
    new-array v2, p1, [I

    iput-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->log:[I

    const/4 v2, 0x2

    mul-int/2addr p1, v2

    .line 59
    new-array p1, p1, [I

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->exp:[I

    move p1, v1

    .line 63
    :goto_1
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->max_value:I

    if-ge p1, v3, :cond_1

    .line 64
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->exp:[I

    aput v0, v3, p1

    .line 65
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->log:[I

    aput p1, v3, v0

    .line 66
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->num_values:I

    invoke-static {v0, v2, p2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldOps;->multiply(IIII)I

    move-result v0

    add-int/lit8 p1, p1, 0x1

    goto :goto_1

    .line 69
    :cond_1
    :goto_2
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->num_values:I

    if-ge v1, p1, :cond_2

    .line 70
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->exp:[I

    iget p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->max_value:I

    add-int/2addr p2, v1

    aget v0, p1, v1

    aput v0, p1, p2

    add-int/lit8 v1, v1, 0x1

    goto :goto_2

    :cond_2
    return-void

    .line 48
    :cond_3
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string p2, "Degree must be more than 1 and less than or equal to 16"

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method


# virtual methods
.method public divide(II)I
    .locals 3

    if-eqz p2, :cond_1

    if-nez p1, :cond_0

    const/4 p1, 0x0

    return p1

    .line 93
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->exp:[I

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->log:[I

    aget p1, v1, p1

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->max_value:I

    add-int/2addr p1, v2

    aget p2, v1, p2

    sub-int/2addr p1, p2

    aget p1, v0, p1

    return p1

    .line 89
    :cond_1
    new-instance p1, Ljava/lang/ArithmeticException;

    const-string p2, "Divide by zero"

    invoke-direct {p1, p2}, Ljava/lang/ArithmeticException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public inverse(I)I
    .locals 3

    .line 114
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->exp:[I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->max_value:I

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->log:[I

    aget p1, v2, p1

    sub-int/2addr v1, p1

    aget p1, v0, v1

    return p1
.end method

.method public multiply(II)I
    .locals 2

    if-eqz p1, :cond_1

    if-nez p2, :cond_0

    goto :goto_0

    .line 80
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->exp:[I

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->log:[I

    aget p1, v1, p1

    aget p2, v1, p2

    add-int/2addr p1, p2

    aget p1, v0, p1

    return p1

    :cond_1
    :goto_0
    const/4 p1, 0x0

    return p1
.end method

.method public power(II)I
    .locals 2

    .line 100
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->exp:[I

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->log:[I

    aget p1, v1, p1

    mul-int/2addr p1, p2

    iget p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->max_value:I

    rem-int/2addr p1, p2

    aget p1, v0, p1

    return p1
.end method
