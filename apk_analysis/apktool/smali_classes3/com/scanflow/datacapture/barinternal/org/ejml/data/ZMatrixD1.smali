.class public abstract Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;
.super Ljava/lang/Object;
.source "ZMatrixD1.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrix;
.implements Lcom/scanflow/datacapture/barinternal/org/ejml/data/ReshapeMatrix;


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

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->data:[D

    return-void
.end method


# virtual methods
.method protected assignShape(II)V
    .locals 0

    .line 49
    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->checkValidMatrixShapeComplex(II)V

    .line 50
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numRows:I

    .line 51
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numCols:I

    return-void
.end method

.method public getNumCols()I
    .locals 1

    .line 111
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numCols:I

    return v0
.end method

.method public getNumRows()I
    .locals 1

    .line 103
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->numRows:I

    return v0
.end method
