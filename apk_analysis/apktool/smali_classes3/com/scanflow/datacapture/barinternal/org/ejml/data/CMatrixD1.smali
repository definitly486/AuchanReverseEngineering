.class public abstract Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrixD1;
.super Ljava/lang/Object;
.source "CMatrixD1.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrix;
.implements Lcom/scanflow/datacapture/barinternal/org/ejml/data/ReshapeMatrix;


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

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrixD1;->data:[F

    return-void
.end method


# virtual methods
.method protected assignShape(II)V
    .locals 0

    .line 51
    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->checkValidMatrixShapeComplex(II)V

    .line 52
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrixD1;->numRows:I

    .line 53
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrixD1;->numCols:I

    return-void
.end method

.method public getNumCols()I
    .locals 1

    .line 113
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrixD1;->numCols:I

    return v0
.end method

.method public getNumRows()I
    .locals 1

    .line 105
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrixD1;->numRows:I

    return v0
.end method
