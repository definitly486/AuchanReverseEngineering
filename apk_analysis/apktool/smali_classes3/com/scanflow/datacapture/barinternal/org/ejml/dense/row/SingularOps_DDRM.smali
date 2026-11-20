.class public abstract Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/SingularOps_DDRM;
.super Ljava/lang/Object;
.source "SingularOps_DDRM.java"


# direct methods
.method public static descendingOrder(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;Z[DILcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;Z)V
    .locals 9

    const/4 v0, 0x0

    :goto_0
    if-ge v0, p3, :cond_6

    const/4 v1, -0x1

    const-wide/high16 v2, -0x4010000000000000L    # -1.0

    move v4, v0

    move v5, v1

    :goto_1
    if-ge v4, p3, :cond_1

    .line 282
    aget-wide v6, p2, v4

    cmpl-double v8, v6, v2

    if-lez v8, :cond_0

    move v5, v4

    move-wide v2, v6

    :cond_0
    add-int/lit8 v4, v4, 0x1

    goto :goto_1

    :cond_1
    if-ne v5, v0, :cond_2

    goto :goto_2

    :cond_2
    if-ne v5, v1, :cond_3

    goto :goto_3

    .line 299
    :cond_3
    aget-wide v6, p2, v0

    .line 300
    aput-wide v2, p2, v0

    .line 301
    aput-wide v6, p2, v5

    if-eqz p4, :cond_4

    .line 304
    invoke-static {p4, p5, v0, v5}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/SingularOps_DDRM;->swapRowOrCol(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;ZII)V

    :cond_4
    if-eqz p0, :cond_5

    .line 308
    invoke-static {p0, p1, v0, v5}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/SingularOps_DDRM;->swapRowOrCol(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;ZII)V

    :cond_5
    :goto_2
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_6
    :goto_3
    return-void
.end method

.method private static swapRowOrCol(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;ZII)V
    .locals 5

    const/4 v0, 0x0

    if-eqz p1, :cond_0

    .line 352
    :goto_0
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    if-ge v0, p1, :cond_1

    .line 353
    invoke-virtual {p0, p2, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->get(II)D

    move-result-wide v1

    .line 354
    invoke-virtual {p0, p3, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->get(II)D

    move-result-wide v3

    invoke-virtual {p0, p2, v0, v3, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    .line 355
    invoke-virtual {p0, p3, v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    .line 359
    :cond_0
    :goto_1
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    if-ge v0, p1, :cond_1

    .line 360
    invoke-virtual {p0, v0, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->get(II)D

    move-result-wide v1

    .line 361
    invoke-virtual {p0, v0, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->get(II)D

    move-result-wide v3

    invoke-virtual {p0, v0, p2, v3, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    .line 362
    invoke-virtual {p0, v0, p3, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    add-int/lit8 v0, v0, 0x1

    goto :goto_1

    :cond_1
    return-void
.end method
