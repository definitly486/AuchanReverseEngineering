.class public abstract Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;
.super Ljava/lang/Object;
.source "DMatrixD1.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/org/ejml/data/ReshapeMatrix;
.implements Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;


# instance fields
.field public data:[D

.field public numCols:I

.field public numRows:I


# direct methods
.method public constructor <init>()V
    .locals 1

    .line 32
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 36
    sget-object v0, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->ZERO_LENGTH_F64:[D

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    return-void
.end method


# virtual methods
.method protected assignShape(II)V
    .locals 0

    .line 49
    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->checkValidMatrixShape(II)V

    .line 50
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    .line 51
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    return-void
.end method

.method public get(I)D
    .locals 3

    .line 104
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    aget-wide v1, v0, p1

    return-wide v1
.end method

.method public getNumCols()I
    .locals 1

    .line 273
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    return v0
.end method

.method public getNumRows()I
    .locals 1

    .line 265
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    return v0
.end method

.method public reshape(II)V
    .locals 1

    const/4 v0, 0x0

    .line 231
    invoke-virtual {p0, p1, p2, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->reshape(IIZ)V

    return-void
.end method

.method public abstract reshape(IIZ)V
.end method

.method public set(ID)D
    .locals 1

    .line 116
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    aput-wide p2, v0, p1

    return-wide p2
.end method

.method public setTo(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;)V
    .locals 3

    .line 89
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    invoke-virtual {p0, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->reshape(II)V

    .line 91
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;->getNumElements()I

    move-result v0

    .line 93
    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    const/4 v1, 0x0

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    invoke-static {p1, v1, v2, v1, v0}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    return-void
.end method
