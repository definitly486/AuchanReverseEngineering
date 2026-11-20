.class public Lorg/ejml/data/CMatrixRMaj;
.super Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrixD1;
.source "CMatrixRMaj.java"


# direct methods
.method public constructor <init>(II)V
    .locals 0

    .line 91
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrixD1;-><init>()V

    .line 92
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrixD1;->assignShape(II)V

    mul-int/2addr p1, p2

    mul-int/lit8 p1, p1, 0x2

    .line 93
    new-array p1, p1, [F

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrixD1;->data:[F

    return-void
.end method

.method public constructor <init>(Lorg/ejml/data/CMatrixRMaj;)V
    .locals 2

    .line 81
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrixD1;->numRows:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrixD1;->numCols:I

    invoke-direct {p0, v0, v1}, Lorg/ejml/data/CMatrixRMaj;-><init>(II)V

    .line 82
    invoke-virtual {p0, p1}, Lorg/ejml/data/CMatrixRMaj;->setTo(Lorg/ejml/data/CMatrixRMaj;)V

    return-void
.end method


# virtual methods
.method public bridge synthetic copy()Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;
    .locals 1

    .line 33
    invoke-virtual {p0}, Lorg/ejml/data/CMatrixRMaj;->copy()Lorg/ejml/data/CMatrixRMaj;

    move-result-object v0

    return-object v0
.end method

.method public copy()Lorg/ejml/data/CMatrixRMaj;
    .locals 1

    .line 169
    new-instance v0, Lorg/ejml/data/CMatrixRMaj;

    invoke-direct {v0, p0}, Lorg/ejml/data/CMatrixRMaj;-><init>(Lorg/ejml/data/CMatrixRMaj;)V

    return-object v0
.end method

.method public bridge synthetic create(II)Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;
    .locals 0

    .line 33
    invoke-virtual {p0, p1, p2}, Lorg/ejml/data/CMatrixRMaj;->create(II)Lorg/ejml/data/CMatrixRMaj;

    move-result-object p1

    return-object p1
.end method

.method public create(II)Lorg/ejml/data/CMatrixRMaj;
    .locals 1

    .line 248
    new-instance v0, Lorg/ejml/data/CMatrixRMaj;

    invoke-direct {v0, p1, p2}, Lorg/ejml/data/CMatrixRMaj;-><init>(II)V

    return-object v0
.end method

.method public get(IILcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F32;)V
    .locals 1

    .line 113
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrixD1;->numCols:I

    mul-int/2addr p1, v0

    mul-int/lit8 p1, p1, 0x2

    mul-int/lit8 p2, p2, 0x2

    add-int/2addr p1, p2

    .line 114
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrixD1;->data:[F

    aget v0, p2, p1

    iput v0, p3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F32;->real:F

    add-int/lit8 p1, p1, 0x1

    .line 115
    aget p1, p2, p1

    iput p1, p3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F32;->imaginary:F

    return-void
.end method

.method public getImag(II)F
    .locals 2

    .line 145
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrixD1;->data:[F

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrixD1;->numCols:I

    mul-int/2addr p1, v1

    add-int/2addr p1, p2

    mul-int/lit8 p1, p1, 0x2

    add-int/lit8 p1, p1, 0x1

    aget p1, v0, p1

    return p1
.end method

.method public getReal(II)F
    .locals 2

    .line 135
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrixD1;->data:[F

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrixD1;->numCols:I

    mul-int/2addr p1, v1

    add-int/2addr p1, p2

    mul-int/lit8 p1, p1, 0x2

    aget p1, v0, p1

    return p1
.end method

.method public getType()Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;
    .locals 1

    .line 253
    sget-object v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->CDRM:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    return-object v0
.end method

.method public reshape(II)V
    .locals 0

    .line 103
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrixD1;->assignShape(II)V

    mul-int/2addr p1, p2

    mul-int/lit8 p1, p1, 0x2

    .line 106
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrixD1;->data:[F

    array-length p2, p2

    if-le p1, p2, :cond_0

    .line 107
    new-array p1, p1, [F

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrixD1;->data:[F

    :cond_0
    return-void
.end method

.method public set(IIFF)V
    .locals 1

    .line 120
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrixD1;->numCols:I

    mul-int/2addr p1, v0

    mul-int/lit8 p1, p1, 0x2

    mul-int/lit8 p2, p2, 0x2

    add-int/2addr p1, p2

    .line 121
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrixD1;->data:[F

    aput p3, p2, p1

    add-int/lit8 p1, p1, 0x1

    .line 122
    aput p4, p2, p1

    return-void
.end method

.method public setTo(Lorg/ejml/data/CMatrixRMaj;)V
    .locals 5

    .line 159
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrixD1;->numRows:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrixD1;->numCols:I

    invoke-virtual {p0, v0, v1}, Lorg/ejml/data/CMatrixRMaj;->reshape(II)V

    .line 160
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrixD1;->numCols:I

    mul-int/lit8 v0, v0, 0x2

    const/4 v1, 0x0

    .line 161
    :goto_0
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrixD1;->numRows:I

    if-ge v1, v2, :cond_0

    .line 162
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrixD1;->numCols:I

    mul-int/2addr v2, v1

    mul-int/lit8 v2, v2, 0x2

    .line 163
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrixD1;->data:[F

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrixD1;->data:[F

    invoke-static {v3, v2, v4, v2, v0}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method
