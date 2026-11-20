.class public abstract Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;
.super Ljava/lang/Object;
.source "FMatrixD1.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/org/ejml/data/ReshapeMatrix;
.implements Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;


# instance fields
.field public data:[F

.field public numCols:I

.field public numRows:I


# direct methods
.method public constructor <init>()V
    .locals 1

    .line 34
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 38
    sget-object v0, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->ZERO_LENGTH_F32:[F

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->data:[F

    return-void
.end method


# virtual methods
.method protected assignShape(II)V
    .locals 0

    .line 51
    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->checkValidMatrixShape(II)V

    .line 52
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numRows:I

    .line 53
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numCols:I

    return-void
.end method

.method public get(I)F
    .locals 1

    .line 106
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->data:[F

    aget p1, v0, p1

    return p1
.end method

.method public getNumCols()I
    .locals 1

    .line 275
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numCols:I

    return v0
.end method

.method public getNumRows()I
    .locals 1

    .line 267
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numRows:I

    return v0
.end method

.method public reshape(II)V
    .locals 1

    const/4 v0, 0x0

    .line 233
    invoke-virtual {p0, p1, p2, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->reshape(IIZ)V

    return-void
.end method

.method public abstract reshape(IIZ)V
.end method

.method public set(IF)F
    .locals 1

    .line 118
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->data:[F

    aput p2, v0, p1

    return p2
.end method
