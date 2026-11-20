.class public abstract Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/misc/ImplCommonOps_DDRM;
.super Ljava/lang/Object;
.source "ImplCommonOps_DDRM.java"


# direct methods
.method public static elementMaxAbs(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ElementLocation;)D
    .locals 6

    .line 70
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;->getNumElements()I

    move-result p1

    const-wide/16 v0, 0x0

    const/4 v2, 0x0

    :goto_0
    if-ge v2, p1, :cond_1

    .line 75
    invoke-virtual {p0, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->get(I)D

    move-result-wide v3

    invoke-static {v3, v4}, Ljava/lang/Math;->abs(D)D

    move-result-wide v3

    cmpl-double v5, v3, v0

    if-lez v5, :cond_0

    move-wide v0, v3

    :cond_0
    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    :cond_1
    return-wide v0
.end method

.method public static extract(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;IILcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;IIII)V
    .locals 5

    const/4 v0, 0x0

    :goto_0
    if-ge v0, p6, :cond_0

    add-int v1, v0, p1

    .line 42
    invoke-virtual {p0, v1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->getIndex(II)I

    move-result v1

    add-int v2, v0, p4

    .line 43
    invoke-virtual {p3, v2, p5}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->getIndex(II)I

    move-result v2

    .line 44
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    iget-object v4, p3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    invoke-static {v3, v1, v4, v2, p7}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method
