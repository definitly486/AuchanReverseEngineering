.class public abstract Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixVectorMult_FDRM;
.super Ljava/lang/Object;
.source "MatrixVectorMult_FDRM.java"


# direct methods
.method public static mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;)V
    .locals 9

    .line 65
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numRows:I

    const-string v1, "A and B are not compatible"

    const/4 v2, 0x1

    if-ne v0, v2, :cond_1

    .line 66
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numCols:I

    iget v3, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numCols:I

    if-ne v0, v3, :cond_0

    goto :goto_0

    .line 67
    :cond_0
    new-instance p0, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;

    invoke-direct {p0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;-><init>(Ljava/lang/String;)V

    throw p0

    .line 69
    :cond_1
    iget v3, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numCols:I

    if-ne v3, v2, :cond_6

    .line 70
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numCols:I

    if-ne v3, v0, :cond_5

    .line 76
    :goto_0
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numRows:I

    invoke-virtual {p2, v0, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->reshape(II)V

    .line 78
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numCols:I

    if-nez v0, :cond_2

    const/4 p0, 0x0

    .line 79
    invoke-static {p2, p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/CommonOps_FDRM;->fill(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;F)V

    return-void

    :cond_2
    const/4 v0, 0x0

    .line 85
    invoke-virtual {p1, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->get(I)F

    move-result v1

    move v3, v0

    move v4, v3

    .line 86
    :goto_1
    iget v5, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numRows:I

    if-ge v0, v5, :cond_4

    add-int/lit8 v5, v3, 0x1

    .line 87
    invoke-virtual {p0, v3}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->get(I)F

    move-result v3

    mul-float/2addr v3, v1

    move v6, v2

    .line 89
    :goto_2
    iget v7, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numCols:I

    if-ge v6, v7, :cond_3

    add-int/lit8 v7, v5, 0x1

    .line 90
    invoke-virtual {p0, v5}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->get(I)F

    move-result v5

    invoke-virtual {p1, v6}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->get(I)F

    move-result v8

    mul-float/2addr v5, v8

    add-float/2addr v3, v5

    add-int/lit8 v6, v6, 0x1

    move v5, v7

    goto :goto_2

    :cond_3
    add-int/lit8 v6, v4, 0x1

    .line 93
    invoke-virtual {p2, v4, v3}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->set(IF)F

    add-int/lit8 v0, v0, 0x1

    move v3, v5

    move v4, v6

    goto :goto_1

    :cond_4
    return-void

    .line 71
    :cond_5
    new-instance p0, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;

    invoke-direct {p0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;-><init>(Ljava/lang/String;)V

    throw p0

    .line 74
    :cond_6
    new-instance p0, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;

    const-string p1, "B is not a vector"

    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;-><init>(Ljava/lang/String;)V

    throw p0
.end method
