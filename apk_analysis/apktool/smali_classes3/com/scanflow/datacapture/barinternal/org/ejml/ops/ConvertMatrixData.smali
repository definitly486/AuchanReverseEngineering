.class public abstract Lcom/scanflow/datacapture/barinternal/org/ejml/ops/ConvertMatrixData;
.super Ljava/lang/Object;
.source "ConvertMatrixData.java"


# direct methods
.method public static convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrix;)V
    .locals 8

    .line 126
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v0

    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v1

    if-ne v0, v1, :cond_3

    .line 128
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v0

    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v1

    if-ne v0, v1, :cond_2

    const/4 v0, 0x0

    move v2, v0

    .line 131
    :goto_0
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v1

    if-ge v2, v1, :cond_1

    move v3, v0

    .line 132
    :goto_1
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v1

    if-ge v3, v1, :cond_0

    .line 133
    invoke-interface {p0, v2, v3}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrix;->getReal(II)F

    move-result v1

    float-to-double v4, v1

    invoke-interface {p0, v2, v3}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrix;->getImag(II)F

    move-result v1

    float-to-double v6, v1

    move-object v1, p1

    invoke-interface/range {v1 .. v7}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrix;->set(IIDD)V

    add-int/lit8 v3, v3, 0x1

    goto :goto_1

    :cond_0
    move-object v1, p1

    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    :cond_1
    return-void

    .line 129
    :cond_2
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Number of columns do not match"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0

    .line 127
    :cond_3
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Number of rows do not match"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method public static convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;)V
    .locals 2

    .line 160
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a11:D

    double-to-float v0, v0

    iput v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a11:F

    .line 161
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a12:D

    double-to-float v0, v0

    iput v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a12:F

    .line 162
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a13:D

    double-to-float v0, v0

    iput v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a13:F

    .line 163
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a21:D

    double-to-float v0, v0

    iput v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a21:F

    .line 164
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a22:D

    double-to-float v0, v0

    iput v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a22:F

    .line 165
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a23:D

    double-to-float v0, v0

    iput v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a23:F

    .line 166
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a31:D

    double-to-float v0, v0

    iput v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a31:F

    .line 167
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a32:D

    double-to-float v0, v0

    iput v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a32:F

    .line 168
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a33:D

    double-to-float p0, v0

    iput p0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a33:F

    return-void
.end method

.method public static convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrix;)V
    .locals 5

    .line 61
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v0

    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v1

    if-ne v0, v1, :cond_3

    .line 63
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v0

    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v1

    if-ne v0, v1, :cond_2

    const/4 v0, 0x0

    move v1, v0

    .line 66
    :goto_0
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v2

    if-ge v1, v2, :cond_1

    move v2, v0

    .line 67
    :goto_1
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v3

    if-ge v2, v3, :cond_0

    .line 68
    invoke-interface {p0, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;->unsafe_get(II)D

    move-result-wide v3

    double-to-float v3, v3

    const/4 v4, 0x0

    invoke-interface {p1, v1, v2, v3, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrix;->set(IIFF)V

    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    :cond_0
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_1
    return-void

    .line 64
    :cond_2
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Number of columns do not match"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0

    .line 62
    :cond_3
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Number of rows do not match"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method public static convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;)V
    .locals 5

    .line 35
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v0

    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v1

    if-ne v0, v1, :cond_3

    .line 37
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v0

    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v1

    if-ne v0, v1, :cond_2

    const/4 v0, 0x0

    move v1, v0

    .line 40
    :goto_0
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v2

    if-ge v1, v2, :cond_1

    move v2, v0

    .line 41
    :goto_1
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v3

    if-ge v2, v3, :cond_0

    .line 42
    invoke-interface {p0, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;->unsafe_get(II)D

    move-result-wide v3

    double-to-float v3, v3

    invoke-interface {p1, v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;->unsafe_set(IIF)V

    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    :cond_0
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_1
    return-void

    .line 38
    :cond_2
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Number of columns do not match"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0

    .line 36
    :cond_3
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Number of rows do not match"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method public static convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrix;)V
    .locals 8

    .line 48
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v0

    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v1

    if-ne v0, v1, :cond_3

    .line 50
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v0

    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v1

    if-ne v0, v1, :cond_2

    const/4 v0, 0x0

    move v2, v0

    .line 53
    :goto_0
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v1

    if-ge v2, v1, :cond_1

    move v3, v0

    .line 54
    :goto_1
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v1

    if-ge v3, v1, :cond_0

    .line 55
    invoke-interface {p0, v2, v3}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;->unsafe_get(II)D

    move-result-wide v4

    const-wide/16 v6, 0x0

    move-object v1, p1

    invoke-interface/range {v1 .. v7}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrix;->set(IIDD)V

    add-int/lit8 v3, v3, 0x1

    goto :goto_1

    :cond_0
    move-object v1, p1

    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    :cond_1
    return-void

    .line 51
    :cond_2
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Number of columns do not match"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0

    .line 49
    :cond_3
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Number of rows do not match"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method public static convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;)V
    .locals 6

    .line 139
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;->getNumElements()I

    move-result v0

    const/4 v1, 0x0

    :goto_0
    if-ge v1, v0, :cond_0

    .line 141
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->data:[F

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    aget-wide v4, v3, v1

    double-to-float v3, v4

    aput v3, v2, v1

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;)V
    .locals 8

    .line 319
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;->getNumElements()I

    move-result v0

    const/4 v1, 0x0

    move v2, v1

    :goto_0
    if-ge v1, v0, :cond_0

    .line 321
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->data:[D

    add-int/lit8 v4, v2, 0x1

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    aget-wide v6, v5, v1

    aput-wide v6, v3, v2

    add-int/lit8 v2, v2, 0x2

    const-wide/16 v5, 0x0

    .line 322
    aput-wide v5, v3, v4

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;Lorg/ejml/data/CMatrixRMaj;)V
    .locals 8

    .line 327
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;->getNumElements()I

    move-result v0

    const/4 v1, 0x0

    move v2, v1

    :goto_0
    if-ge v1, v0, :cond_0

    .line 329
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrixD1;->data:[F

    add-int/lit8 v4, v2, 0x1

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    aget-wide v6, v5, v1

    double-to-float v5, v6

    aput v5, v3, v2

    add-int/lit8 v2, v2, 0x2

    const/4 v5, 0x0

    .line 330
    aput v5, v3, v4

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrix;)V
    .locals 5

    .line 100
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v0

    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v1

    if-ne v0, v1, :cond_3

    .line 102
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v0

    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v1

    if-ne v0, v1, :cond_2

    const/4 v0, 0x0

    move v1, v0

    .line 105
    :goto_0
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v2

    if-ge v1, v2, :cond_1

    move v2, v0

    .line 106
    :goto_1
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v3

    if-ge v2, v3, :cond_0

    .line 107
    invoke-interface {p0, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;->unsafe_get(II)F

    move-result v3

    const/4 v4, 0x0

    invoke-interface {p1, v1, v2, v3, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrix;->set(IIFF)V

    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    :cond_0
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_1
    return-void

    .line 103
    :cond_2
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Number of columns do not match"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0

    .line 101
    :cond_3
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Number of rows do not match"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method public static convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;)V
    .locals 5

    .line 74
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v0

    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v1

    if-ne v0, v1, :cond_3

    .line 76
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v0

    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v1

    if-ne v0, v1, :cond_2

    const/4 v0, 0x0

    move v1, v0

    .line 79
    :goto_0
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v2

    if-ge v1, v2, :cond_1

    move v2, v0

    .line 80
    :goto_1
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v3

    if-ge v2, v3, :cond_0

    .line 81
    invoke-interface {p0, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;->unsafe_get(II)F

    move-result v3

    float-to-double v3, v3

    invoke-interface {p1, v1, v2, v3, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;->unsafe_set(IID)V

    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    :cond_0
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_1
    return-void

    .line 77
    :cond_2
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Number of columns do not match"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0

    .line 75
    :cond_3
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Number of rows do not match"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method public static convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrix;)V
    .locals 8

    .line 87
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v0

    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v1

    if-ne v0, v1, :cond_3

    .line 89
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v0

    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v1

    if-ne v0, v1, :cond_2

    const/4 v0, 0x0

    move v2, v0

    .line 92
    :goto_0
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v1

    if-ge v2, v1, :cond_1

    move v3, v0

    .line 93
    :goto_1
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v1

    if-ge v3, v1, :cond_0

    .line 94
    invoke-interface {p0, v2, v3}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;->unsafe_get(II)F

    move-result v1

    float-to-double v4, v1

    const-wide/16 v6, 0x0

    move-object v1, p1

    invoke-interface/range {v1 .. v7}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrix;->set(IIDD)V

    add-int/lit8 v3, v3, 0x1

    goto :goto_1

    :cond_0
    move-object v1, p1

    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    :cond_1
    return-void

    .line 90
    :cond_2
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Number of columns do not match"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0

    .line 88
    :cond_3
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Number of rows do not match"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method public static convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)V
    .locals 5

    .line 146
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;->getNumElements()I

    move-result v0

    const/4 v1, 0x0

    :goto_0
    if-ge v1, v0, :cond_0

    .line 148
    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->data:[F

    aget v3, v3, v1

    float-to-double v3, v3

    aput-wide v3, v2, v1

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;)V
    .locals 7

    .line 335
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;->getNumElements()I

    move-result v0

    const/4 v1, 0x0

    move v2, v1

    :goto_0
    if-ge v1, v0, :cond_0

    .line 337
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixD1;->data:[D

    add-int/lit8 v4, v2, 0x1

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->data:[F

    aget v5, v5, v1

    float-to-double v5, v5

    aput-wide v5, v3, v2

    add-int/lit8 v2, v2, 0x2

    const-wide/16 v5, 0x0

    .line 338
    aput-wide v5, v3, v4

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;Lorg/ejml/data/CMatrixRMaj;)V
    .locals 6

    .line 343
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;->getNumElements()I

    move-result v0

    const/4 v1, 0x0

    move v2, v1

    :goto_0
    if-ge v1, v0, :cond_0

    .line 345
    iget-object v3, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrixD1;->data:[F

    add-int/lit8 v4, v2, 0x1

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->data:[F

    aget v5, v5, v1

    aput v5, v3, v2

    add-int/lit8 v2, v2, 0x2

    const/4 v5, 0x0

    .line 346
    aput v5, v3, v4

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrix;)V
    .locals 6

    .line 113
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v0

    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v1

    if-ne v0, v1, :cond_3

    .line 115
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v0

    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v1

    if-ne v0, v1, :cond_2

    const/4 v0, 0x0

    move v1, v0

    .line 118
    :goto_0
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v2

    if-ge v1, v2, :cond_1

    move v2, v0

    .line 119
    :goto_1
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v3

    if-ge v2, v3, :cond_0

    .line 120
    invoke-interface {p0, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrix;->getReal(II)D

    move-result-wide v3

    double-to-float v3, v3

    invoke-interface {p0, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrix;->getImag(II)D

    move-result-wide v4

    double-to-float v4, v4

    invoke-interface {p1, v1, v2, v3, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/CMatrix;->set(IIFF)V

    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    :cond_0
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_1
    return-void

    .line 116
    :cond_2
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Number of columns do not match"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0

    .line 114
    :cond_3
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Number of rows do not match"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method
