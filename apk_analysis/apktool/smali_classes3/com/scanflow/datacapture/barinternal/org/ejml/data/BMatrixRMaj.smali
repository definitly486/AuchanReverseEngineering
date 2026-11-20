.class public Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;
.super Ljava/lang/Object;
.source "BMatrixRMaj.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/org/ejml/data/ReshapeMatrix;


# instance fields
.field public data:[Z

.field public numCols:I

.field public numRows:I


# direct methods
.method public constructor <init>(II)V
    .locals 1

    .line 42
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    mul-int v0, p1, p2

    .line 43
    new-array v0, v0, [Z

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;->data:[Z

    .line 44
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;->numRows:I

    .line 45
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;->numCols:I

    return-void
.end method


# virtual methods
.method public copy()Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;
    .locals 3

    .line 140
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;->numRows:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;->numCols:I

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;-><init>(II)V

    .line 141
    invoke-virtual {v0, p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;->setTo(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)V

    return-object v0
.end method

.method public create(II)Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;
    .locals 1

    .line 180
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;

    invoke-direct {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;-><init>(II)V

    return-object v0
.end method

.method public bridge synthetic create(II)Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;
    .locals 0

    .line 28
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;->create(II)Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;

    move-result-object p1

    return-object p1
.end method

.method public get(II)Z
    .locals 3

    .line 69
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;->isInBounds(II)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 71
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;->data:[Z

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;->numCols:I

    mul-int/2addr p1, v1

    add-int/2addr p1, p2

    aget-boolean p1, v0, p1

    return p1

    .line 70
    :cond_0
    new-instance v0, Ljava/lang/IllegalArgumentException;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Out of matrix bounds. "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p1, " "

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {v0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method public getNumCols()I
    .locals 1

    .line 130
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;->numCols:I

    return v0
.end method

.method public getNumElements()I
    .locals 2

    .line 49
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;->numRows:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;->numCols:I

    mul-int/2addr v0, v1

    return v0
.end method

.method public getNumRows()I
    .locals 1

    .line 125
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;->numRows:I

    return v0
.end method

.method public getType()Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;
    .locals 1

    .line 185
    sget-object v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->UNSPECIFIED:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    return-object v0
.end method

.method public isInBounds(II)Z
    .locals 1

    if-ltz p2, :cond_0

    .line 96
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;->numCols:I

    if-ge p2, v0, :cond_0

    if-ltz p1, :cond_0

    iget p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;->numRows:I

    if-ge p1, p2, :cond_0

    const/4 p1, 0x1

    return p1

    :cond_0
    const/4 p1, 0x0

    return p1
.end method

.method public reshape(II)V
    .locals 2

    mul-int v0, p1, p2

    .line 116
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;->data:[Z

    array-length v1, v1

    if-ge v1, v0, :cond_0

    .line 117
    new-array v0, v0, [Z

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;->data:[Z

    .line 119
    :cond_0
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;->numRows:I

    .line 120
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;->numCols:I

    return-void
.end method

.method public set(IIZ)V
    .locals 2

    .line 75
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;->isInBounds(II)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 77
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;->data:[Z

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;->numCols:I

    mul-int/2addr p1, v1

    add-int/2addr p1, p2

    aput-boolean p3, v0, p1

    return-void

    .line 76
    :cond_0
    new-instance p3, Ljava/lang/IllegalArgumentException;

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "Out of matrix bounds. "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p1, " "

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, p2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {p3, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p3
.end method

.method public setTo(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)V
    .locals 3

    .line 147
    move-object v0, p1

    check-cast v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;

    .line 149
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v1

    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result p1

    invoke-virtual {p0, v1, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;->reshape(II)V

    .line 150
    iget-object p1, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;->data:[Z

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;->data:[Z

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/BMatrixRMaj;->getNumElements()I

    move-result v0

    const/4 v2, 0x0

    invoke-static {p1, v2, v1, v2, v0}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    return-void
.end method
