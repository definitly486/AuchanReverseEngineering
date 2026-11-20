.class public Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;
.super Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;
.source "ZMatrixRMaj.java"


# direct methods
.method public constructor <init>(II)V
    .locals 0

    .line 89
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;-><init>()V

    .line 90
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->assignShape(II)V

    mul-int/2addr p1, p2

    mul-int/lit8 p1, p1, 0x2

    .line 91
    new-array p1, p1, [D

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->data:[D

    return-void
.end method

.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;)V
    .locals 2

    .line 79
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numRows:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numCols:I

    invoke-direct {p0, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;-><init>(II)V

    .line 80
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;->setTo(Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;)V

    return-void
.end method


# virtual methods
.method public bridge synthetic copy()Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;
    .locals 1

    .line 32
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;->copy()Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;

    move-result-object v0

    return-object v0
.end method

.method public copy()Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;
    .locals 1

    .line 167
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;-><init>(Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;)V

    return-object v0
.end method

.method public bridge synthetic create(II)Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;
    .locals 0

    .line 32
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;->create(II)Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;

    move-result-object p1

    return-object p1
.end method

.method public create(II)Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;
    .locals 1

    .line 246
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;

    invoke-direct {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;-><init>(II)V

    return-object v0
.end method

.method public get(IILcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;)V
    .locals 2

    .line 111
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numCols:I

    mul-int/2addr p1, v0

    mul-int/lit8 p1, p1, 0x2

    mul-int/lit8 p2, p2, 0x2

    add-int/2addr p1, p2

    .line 112
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->data:[D

    aget-wide v0, p2, p1

    iput-wide v0, p3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;->real:D

    add-int/lit8 p1, p1, 0x1

    .line 113
    aget-wide p1, p2, p1

    iput-wide p1, p3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;->imaginary:D

    return-void
.end method

.method public getDataLength()I
    .locals 2

    .line 153
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numRows:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numCols:I

    mul-int/2addr v0, v1

    mul-int/lit8 v0, v0, 0x2

    return v0
.end method

.method public getImag(II)D
    .locals 2

    .line 143
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->data:[D

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numCols:I

    mul-int/2addr p1, v1

    add-int/2addr p1, p2

    mul-int/lit8 p1, p1, 0x2

    add-int/lit8 p1, p1, 0x1

    aget-wide p1, v0, p1

    return-wide p1
.end method

.method public getReal(II)D
    .locals 2

    .line 133
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->data:[D

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numCols:I

    mul-int/2addr p1, v1

    add-int/2addr p1, p2

    mul-int/lit8 p1, p1, 0x2

    aget-wide p1, v0, p1

    return-wide p1
.end method

.method public getRowStride()I
    .locals 1

    .line 199
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numCols:I

    mul-int/lit8 v0, v0, 0x2

    return v0
.end method

.method public getType()Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;
    .locals 1

    .line 251
    sget-object v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->ZDRM:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    return-object v0
.end method

.method public reshape(II)V
    .locals 0

    .line 101
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->assignShape(II)V

    mul-int/2addr p1, p2

    mul-int/lit8 p1, p1, 0x2

    .line 104
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->data:[D

    array-length p2, p2

    if-le p1, p2, :cond_0

    .line 105
    new-array p1, p1, [D

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->data:[D

    :cond_0
    return-void
.end method

.method public set(IIDD)V
    .locals 1

    .line 118
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numCols:I

    mul-int/2addr p1, v0

    mul-int/lit8 p1, p1, 0x2

    mul-int/lit8 p2, p2, 0x2

    add-int/2addr p1, p2

    .line 119
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->data:[D

    aput-wide p3, p2, p1

    add-int/lit8 p1, p1, 0x1

    .line 120
    aput-wide p5, p2, p1

    return-void
.end method

.method public setTo(Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;)V
    .locals 5

    .line 157
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numRows:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numCols:I

    invoke-virtual {p0, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;->reshape(II)V

    .line 158
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numCols:I

    mul-int/lit8 v0, v0, 0x2

    const/4 v1, 0x0

    .line 159
    :goto_0
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numRows:I

    if-ge v1, v2, :cond_0

    .line 160
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numCols:I

    mul-int/2addr v2, v1

    mul-int/lit8 v2, v2, 0x2

    .line 161
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->data:[D

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->data:[D

    invoke-static {v3, v2, v4, v2, v0}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method
