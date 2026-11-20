.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;
.super Ljava/lang/Object;
.source "ReedSolomonCodes_U8.java"


# instance fields
.field err_eval:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

.field err_loc_prime_tmp:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

.field errorLocations:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

.field errorLocatorPoly:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

.field errorX:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

.field generator:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

.field generatorBase:I

.field math:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps_U8;

.field syndromes:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

.field tmp0:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

.field tmp1:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;


# direct methods
.method public constructor <init>(III)V
    .locals 1

    .line 66
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 40
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->generator:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    .line 42
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->tmp0:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    .line 43
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->tmp1:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    .line 45
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->errorLocations:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    .line 46
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->errorLocatorPoly:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    .line 47
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->syndromes:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    .line 50
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->err_eval:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    .line 51
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->errorX:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    .line 52
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->err_loc_prime_tmp:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    if-ltz p3, :cond_0

    const/4 v0, 0x1

    if-gt p3, v0, :cond_0

    .line 69
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps_U8;

    invoke-direct {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps_U8;-><init>(II)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->math:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps_U8;

    .line 70
    iput p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->generatorBase:I

    return-void

    .line 68
    :cond_0
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string p2, "generatorBase must be 0 or 1"

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method private removeLeadingZeros(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;)V
    .locals 5

    const/4 v0, 0x0

    .line 191
    :goto_0
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    if-ge v0, v1, :cond_1

    .line 192
    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    aget-byte v1, v1, v0

    if-eqz v1, :cond_0

    goto :goto_1

    :cond_0
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_1
    :goto_1
    move v1, v0

    .line 195
    :goto_2
    iget v2, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    if-ge v1, v2, :cond_2

    .line 196
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    sub-int v3, v1, v0

    aget-byte v4, v2, v1

    aput-byte v4, v2, v3

    add-int/lit8 v1, v1, 0x1

    goto :goto_2

    :cond_2
    sub-int/2addr v2, v0

    .line 198
    iput v2, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    return-void
.end method

.method private syndromeLength()I
    .locals 1

    .line 371
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->generator:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    iget v0, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    add-int/lit8 v0, v0, -0x1

    return v0
.end method


# virtual methods
.method computeSyndromes(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;)V
    .locals 5

    .line 120
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    iget v1, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    add-int/2addr v0, v1

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->math:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps_U8;

    iget v1, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->num_values:I

    if-gt v0, v1, :cond_1

    .line 122
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->syndromeLength()I

    move-result v0

    invoke-virtual {p3, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->resize(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    const/4 v0, 0x0

    .line 123
    :goto_0
    iget v1, p3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    if-ge v0, v1, :cond_0

    .line 124
    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->generatorPower(I)I

    move-result v1

    .line 125
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->math:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps_U8;

    invoke-virtual {v2, p1, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps_U8;->polyEval(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;I)I

    move-result v2

    .line 126
    iget-object v3, p3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->math:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps_U8;

    invoke-virtual {v4, v2, p2, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps_U8;->polyEvalContinue(ILcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;I)I

    move-result v1

    int-to-byte v1, v1

    aput-byte v1, v3, v0

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    return-void

    .line 121
    :cond_1
    new-instance p1, Ljava/lang/IllegalArgumentException;

    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->math:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps_U8;

    iget p2, p2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->num_values:I

    new-instance p3, Ljava/lang/StringBuilder;

    invoke-direct {p3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v0, "Combined size of input and ecc is larger than "

    invoke-virtual {p3, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p3, p2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {p3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p2

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public correct(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;)Z
    .locals 7

    .line 97
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->syndromes:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    invoke-virtual {p0, p1, p2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->computeSyndromes(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;)V

    .line 98
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->syndromes:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->errorLocatorPoly:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    invoke-virtual {p0, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->findErrorLocatorPolynomialBM(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;)V

    .line 99
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->errorLocatorPoly:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    iget v2, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    add-int/2addr v1, v2

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->errorLocations:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {p0, v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->findErrorLocations_BruteForce(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;ILcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)Z

    move-result v0

    if-nez v0, :cond_0

    const/4 p1, 0x0

    return p1

    .line 106
    :cond_0
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    iget p2, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    add-int v3, v0, p2

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->syndromes:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->errorLocatorPoly:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->errorLocations:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    move-object v1, p0

    move-object v2, p1

    invoke-virtual/range {v1 .. v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->correctErrors(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;ILcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)V

    const/4 p1, 0x1

    return p1
.end method

.method correctErrors(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;ILcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)V
    .locals 8

    .line 259
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->err_eval:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    invoke-virtual {p0, p3, p4, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->findErrorEvaluator(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;)V

    .line 262
    iget-object p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->errorX:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    invoke-virtual {p3}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    move-result-object p3

    iget p4, p5, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    const/4 v0, 0x0

    invoke-virtual {p3, p4, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->resize(IB)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    move p3, v0

    .line 263
    :goto_0
    iget p4, p5, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    const/4 v1, 0x1

    if-ge p3, p4, :cond_0

    .line 264
    iget-object p4, p5, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->data:[I

    aget p4, p4, p3

    sub-int p4, p2, p4

    sub-int/2addr p4, v1

    .line 265
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->errorX:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    iget-object v1, v1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->math:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps_U8;

    const/4 v3, 0x2

    invoke-virtual {v2, v3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->power(II)I

    move-result p4

    int-to-byte p4, p4

    aput-byte p4, v1, p3

    add-int/lit8 p3, p3, 0x1

    goto :goto_0

    .line 272
    :cond_0
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->err_loc_prime_tmp:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    iget-object p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->errorX:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    iget p3, p3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    invoke-virtual {p2, p3}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->resize(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    move p2, v0

    .line 275
    :goto_1
    iget-object p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->errorX:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    iget p4, p3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    if-ge p2, p4, :cond_6

    .line 276
    iget-object p3, p3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    aget-byte p3, p3, p2

    and-int/lit16 p3, p3, 0xff

    .line 277
    iget-object p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->math:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps_U8;

    invoke-virtual {p4, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->inverse(I)I

    move-result p4

    .line 280
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->err_loc_prime_tmp:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    iput v0, v2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    move v2, v0

    .line 281
    :goto_2
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->errorX:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    iget v4, v3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    if-ge v2, v4, :cond_2

    if-ne p2, v2, :cond_1

    goto :goto_3

    .line 284
    :cond_1
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->err_loc_prime_tmp:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    iget-object v5, v4, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    iget v6, v4, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    add-int/lit8 v7, v6, 0x1

    iput v7, v4, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->math:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps_U8;

    iget-object v3, v3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    aget-byte v3, v3, v2

    and-int/lit16 v3, v3, 0xff

    .line 285
    invoke-virtual {v4, p4, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->multiply(II)I

    move-result v3

    invoke-static {v1, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldOps;->subtract(II)I

    move-result v3

    int-to-byte v3, v3

    aput-byte v3, v5, v6

    :goto_3
    add-int/lit8 v2, v2, 0x1

    goto :goto_2

    :cond_2
    move v2, v0

    move v3, v1

    .line 289
    :goto_4
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->err_loc_prime_tmp:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    iget v5, v4, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    if-ge v2, v5, :cond_3

    .line 290
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->math:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps_U8;

    iget-object v4, v4, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    aget-byte v4, v4, v2

    and-int/lit16 v4, v4, 0xff

    invoke-virtual {v5, v3, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->multiply(II)I

    move-result v3

    add-int/lit8 v2, v2, 0x1

    goto :goto_4

    .line 293
    :cond_3
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->math:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps_U8;

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->err_eval:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    invoke-virtual {v2, v4, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps_U8;->polyEval_S(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;I)I

    move-result v2

    .line 294
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->math:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps_U8;

    invoke-virtual {v4, p3, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->power(II)I

    move-result p3

    invoke-virtual {v4, p3, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->multiply(II)I

    move-result p3

    .line 297
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->math:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps_U8;

    invoke-virtual {v2, p3, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->divide(II)I

    move-result p3

    .line 298
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->generatorBase:I

    if-eqz v2, :cond_4

    .line 299
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->math:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps_U8;

    invoke-virtual {v2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->multiply(II)I

    move-result p3

    .line 303
    :cond_4
    invoke-virtual {p5, p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->get(I)I

    move-result p4

    .line 304
    iget v2, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    if-ge p4, v2, :cond_5

    .line 305
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    aget-byte v3, v2, p4

    and-int/lit16 v3, v3, 0xff

    xor-int/2addr p3, v3

    int-to-byte p3, p3

    aput-byte p3, v2, p4

    :cond_5
    add-int/lit8 p2, p2, 0x1

    goto/16 :goto_1

    :cond_6
    return-void
.end method

.method findErrorEvaluator(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;)V
    .locals 5

    .line 318
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->math:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps_U8;

    invoke-virtual {v0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps_U8;->polyMult_flipA(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;)V

    .line 319
    iget p1, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    add-int/lit8 p1, p1, -0x1

    .line 320
    iget v0, p3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    sub-int/2addr v0, p1

    const/4 v1, 0x0

    move v2, v1

    :goto_0
    if-ge v2, p1, :cond_0

    .line 322
    iget-object v3, p3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    add-int v4, v2, v0

    aget-byte v4, v3, v4

    aput-byte v4, v3, v2

    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    .line 324
    :cond_0
    iget-object v0, p3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    aput-byte v1, v0, p1

    .line 325
    iget p1, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    iput p1, p3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    .line 328
    :goto_1
    iget p1, p3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    div-int/lit8 p2, p1, 0x2

    if-ge v1, p2, :cond_1

    sub-int/2addr p1, v1

    add-int/lit8 p1, p1, -0x1

    .line 330
    iget-object p2, p3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    aget-byte v0, p2, v1

    .line 331
    aget-byte v2, p2, p1

    aput-byte v2, p2, v1

    int-to-byte v0, v0

    .line 332
    aput-byte v0, p2, p1

    add-int/lit8 v1, v1, 0x1

    goto :goto_1

    :cond_1
    return-void
.end method

.method public findErrorLocations_BruteForce(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;ILcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;)Z
    .locals 5

    const/4 v0, 0x0

    .line 236
    invoke-virtual {p3, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->resize(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    move v1, v0

    :goto_0
    const/4 v2, 0x1

    if-ge v1, p2, :cond_1

    .line 238
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->math:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps_U8;

    const/4 v4, 0x2

    invoke-virtual {v3, v4, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->power(II)I

    move-result v4

    invoke-virtual {v3, p1, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps_U8;->polyEval_S(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;I)I

    move-result v3

    if-nez v3, :cond_0

    sub-int v3, p2, v1

    sub-int/2addr v3, v2

    .line 239
    invoke-virtual {p3, v3}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->add(I)V

    :cond_0
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    .line 244
    :cond_1
    iget p2, p3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    iget p1, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    sub-int/2addr p1, v2

    if-ne p2, p1, :cond_2

    return v2

    :cond_2
    return v0
.end method

.method findErrorLocatorPolynomialBM(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;)V
    .locals 12

    .line 141
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->err_eval:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    .line 143
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    const/4 v2, 0x1

    add-int/2addr v1, v2

    invoke-virtual {p0, p2, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->initToOne(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;I)V

    .line 144
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    add-int/2addr v1, v2

    invoke-virtual {p0, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->initToOne(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;I)V

    .line 146
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->errorX:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    .line 147
    iget v3, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    invoke-virtual {v1, v3}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->resize(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    const/4 v3, 0x0

    move v5, v2

    move v4, v3

    .line 153
    :goto_0
    iget v6, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    if-ge v4, v6, :cond_3

    .line 156
    iget-object v6, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    aget-byte v6, v6, v4

    and-int/lit16 v6, v6, 0xff

    move v7, v2

    .line 158
    :goto_1
    iget v8, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    if-ge v7, v8, :cond_0

    .line 159
    iget-object v9, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->math:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps_U8;

    iget-object v10, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    sub-int/2addr v8, v7

    sub-int/2addr v8, v2

    aget-byte v8, v10, v8

    and-int/lit16 v8, v8, 0xff

    iget-object v10, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    sub-int v11, v4, v7

    aget-byte v10, v10, v11

    and-int/lit16 v10, v10, 0xff

    invoke-virtual {v9, v8, v10}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->multiply(II)I

    move-result v8

    xor-int/2addr v6, v8

    add-int/lit8 v7, v7, 0x1

    goto :goto_1

    .line 163
    :cond_0
    iget-object v7, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    iget v8, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    add-int/lit8 v9, v8, 0x1

    iput v9, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    aput-byte v3, v7, v8

    if-eqz v6, :cond_2

    .line 169
    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->math:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps_U8;

    invoke-virtual {v7, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->inverse(I)I

    move-result v8

    invoke-virtual {v7, v6, v8}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->multiply(II)I

    move-result v7

    .line 170
    iget-object v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->math:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps_U8;

    invoke-virtual {v8, p2, v0, v7, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps_U8;->polyAddScaleB(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;ILcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;)V

    .line 172
    iget v7, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    iget v8, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    if-gt v7, v8, :cond_1

    goto :goto_2

    .line 177
    :cond_1
    invoke-virtual {v0, p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->setTo(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    move v5, v6

    .line 182
    :goto_2
    invoke-virtual {p2, v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->setTo(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    :cond_2
    add-int/lit8 v4, v4, 0x1

    goto :goto_0

    .line 186
    :cond_3
    invoke-direct {p0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->removeLeadingZeros(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;)V

    return-void
.end method

.method public generator(I)V
    .locals 6

    .line 347
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->generator:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    add-int/lit8 v1, p1, 0x1

    invoke-virtual {p0, v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->initToOne(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;I)V

    .line 350
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->tmp1:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    const/4 v1, 0x2

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->resize(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    .line 351
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->tmp1:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    const/4 v1, 0x0

    const/4 v2, 0x1

    aput-byte v2, v0, v1

    :goto_0
    if-ge v1, p1, :cond_0

    .line 353
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->tmp1:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->generatorPower(I)I

    move-result v3

    int-to-byte v3, v3

    aput-byte v3, v0, v2

    .line 354
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->math:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps_U8;

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->generator:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->tmp1:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->tmp0:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    invoke-virtual {v0, v3, v4, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps_U8;->polyMult(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;)V

    .line 355
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->generator:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->tmp0:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    invoke-virtual {v0, v3}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->setTo(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method

.method generatorPower(I)I
    .locals 2

    .line 367
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->math:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps_U8;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->generatorBase:I

    add-int/2addr p1, v1

    const/4 v1, 0x2

    invoke-virtual {v0, v1, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/GaliosFieldTableOps;->power(II)I

    move-result p1

    return p1
.end method

.method public getTotalErrors()I
    .locals 1

    .line 376
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/ReedSolomonCodes_U8;->errorLocations:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    iget v0, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    return v0
.end method

.method initToOne(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;I)V
    .locals 1

    .line 360
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;

    .line 361
    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->reserve(I)V

    const/4 p2, 0x1

    .line 362
    iput p2, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->size:I

    .line 363
    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;->data:[B

    const/4 v0, 0x0

    aput-byte p2, p1, v0

    return-void
.end method
