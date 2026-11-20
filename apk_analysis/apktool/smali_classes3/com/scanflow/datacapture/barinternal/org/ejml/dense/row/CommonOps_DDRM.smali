.class public abstract Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/CommonOps_DDRM;
.super Ljava/lang/Object;
.source "CommonOps_DDRM.java"


# direct methods
.method public static divide(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;D)V
    .locals 5

    .line 2356
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;->getNumElements()I

    move-result v0

    const/4 v1, 0x0

    :goto_0
    if-ge v1, v0, :cond_0

    .line 2359
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    aget-wide v3, v2, v1

    div-double/2addr v3, p1

    aput-wide v3, v2, v1

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static elementMaxAbs(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;)D
    .locals 2

    const/4 v0, 0x0

    .line 1449
    invoke-static {p0, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/misc/ImplCommonOps_DDRM;->elementMaxAbs(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ElementLocation;)D

    move-result-wide v0

    return-wide v0
.end method

.method public static extract(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;IIII)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;
    .locals 9

    if-le p2, p1, :cond_1

    if-ltz p1, :cond_1

    .line 1210
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    if-gt p2, v0, :cond_1

    if-le p4, p3, :cond_0

    if-ltz p3, :cond_0

    .line 1212
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    if-gt p4, v0, :cond_0

    sub-int v8, p4, p3

    sub-int v7, p2, p1

    .line 1218
    new-instance v4, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-direct {v4, v7, v8}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;-><init>(II)V

    const/4 v5, 0x0

    const/4 v6, 0x0

    move-object v1, p0

    move v2, p1

    move v3, p3

    .line 1220
    invoke-static/range {v1 .. v8}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/misc/ImplCommonOps_DDRM;->extract(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;IILcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;IIII)V

    return-object v4

    .line 1213
    :cond_0
    new-instance p0, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;

    const-string p1, "srcX1 <= srcX0 || srcX0 < 0 || srcX1 > src.numCols"

    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;-><init>(Ljava/lang/String;)V

    throw p0

    .line 1211
    :cond_1
    new-instance p0, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;

    const-string p1, "srcY1 <= srcY0 || srcY0 < 0 || srcY1 > src.numRows"

    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method public static extract(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;IIIILcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;II)V
    .locals 4

    if-lt p2, p1, :cond_4

    if-ltz p1, :cond_4

    .line 1133
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v0

    if-gt p2, v0, :cond_4

    if-lt p4, p3, :cond_3

    if-ltz p3, :cond_3

    .line 1135
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v0

    if-gt p4, v0, :cond_3

    sub-int/2addr p4, p3

    sub-int/2addr p2, p1

    add-int v0, p6, p2

    .line 1141
    invoke-interface {p5}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v1

    const-string v2, " < "

    if-gt v0, v1, :cond_2

    add-int v0, p7, p4

    .line 1143
    invoke-interface {p5}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v1

    if-gt v0, v1, :cond_1

    .line 1147
    instance-of v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    if-eqz v0, :cond_0

    instance-of v0, p5, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    if-eqz v0, :cond_0

    .line 1148
    check-cast p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    check-cast p5, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    move v3, p6

    move p6, p2

    move p2, p3

    move-object p3, p5

    move p5, p7

    move p7, p4

    move p4, v3

    invoke-static/range {p0 .. p7}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/misc/ImplCommonOps_DDRM;->extract(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;IILcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;IIII)V

    return-void

    :cond_0
    move v3, p6

    move p6, p2

    move p2, p3

    move-object p3, p5

    move p5, p7

    move p7, p4

    move p4, v3

    .line 1150
    invoke-static/range {p0 .. p7}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/misc/ImplCommonOps_DDMA;->extract(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;IILcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;IIII)V

    return-void

    :cond_1
    move-object p3, p5

    .line 1144
    new-instance p0, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;

    invoke-interface {p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result p1

    new-instance p2, Ljava/lang/StringBuilder;

    invoke-direct {p2}, Ljava/lang/StringBuilder;-><init>()V

    const-string p3, "dst is too small in columns. "

    invoke-virtual {p2, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {p2, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2, v0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {p2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;-><init>(Ljava/lang/String;)V

    throw p0

    :cond_2
    move-object p3, p5

    .line 1142
    new-instance p0, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;

    invoke-interface {p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result p1

    new-instance p2, Ljava/lang/StringBuilder;

    invoke-direct {p2}, Ljava/lang/StringBuilder;-><init>()V

    const-string p3, "dst is too small in rows. "

    invoke-virtual {p2, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {p2, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2, v0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {p2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;-><init>(Ljava/lang/String;)V

    throw p0

    :cond_3
    move-object p3, p5

    .line 1136
    new-instance p1, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;

    invoke-static {p0, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->stringShapes(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Ljava/lang/String;

    move-result-object p0

    new-instance p2, Ljava/lang/StringBuilder;

    invoke-direct {p2}, Ljava/lang/StringBuilder;-><init>()V

    const-string p3, "srcX1 < srcX0 || srcX0 < 0 || srcX1 > src.numCols. "

    invoke-virtual {p2, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    invoke-direct {p1, p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;-><init>(Ljava/lang/String;)V

    throw p1

    :cond_4
    move-object p3, p5

    .line 1134
    new-instance p1, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;

    invoke-static {p0, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->stringShapes(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Ljava/lang/String;

    move-result-object p0

    new-instance p2, Ljava/lang/StringBuilder;

    invoke-direct {p2}, Ljava/lang/StringBuilder;-><init>()V

    const-string p3, "srcY1 < srcY0 || srcY0 < 0 || srcY1 > src.numRows. "

    invoke-virtual {p2, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    invoke-direct {p1, p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public static fill(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;D)V
    .locals 2

    .line 2460
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    const/4 v1, 0x0

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;->getNumElements()I

    move-result p0

    invoke-static {v0, v1, p0, p1, p2}, Ljava/util/Arrays;->fill([DIID)V

    return-void
.end method

.method public static identity(II)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;
    .locals 3

    .line 996
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-direct {v0, p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;-><init>(II)V

    if-ge p0, p1, :cond_0

    goto :goto_0

    :cond_0
    move p0, p1

    :goto_0
    const/4 p1, 0x0

    :goto_1
    if-ge p1, p0, :cond_1

    const-wide/high16 v1, 0x3ff0000000000000L    # 1.0

    .line 1001
    invoke-virtual {v0, p1, p1, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->set(IID)V

    add-int/lit8 p1, p1, 0x1

    goto :goto_1

    :cond_1
    return-object v0
.end method

.method public static insert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;II)V
    .locals 8

    .line 1406
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v2

    const/4 v3, 0x0

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v4

    const/4 v1, 0x0

    move-object v0, p0

    move-object v5, p1

    move v6, p2

    move v7, p3

    invoke-static/range {v0 .. v7}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/CommonOps_DDRM;->extract(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;IIIILcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;II)V

    return-void
.end method

.method public static mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;
    .locals 2

    .line 80
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    invoke-static {p2, p0, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->reshapeOrDeclare(Lcom/scanflow/datacapture/barinternal/org/ejml/data/ReshapeMatrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ReshapeMatrix;II)Lcom/scanflow/datacapture/barinternal/org/ejml/data/ReshapeMatrix;

    move-result-object p2

    check-cast p2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;

    .line 81
    invoke-static {p0, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->checkSameInstance(Ljava/lang/Object;Ljava/lang/Object;)V

    .line 82
    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->checkSameInstance(Ljava/lang/Object;Ljava/lang/Object;)V

    .line 84
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    const/4 v1, 0x1

    if-ne v0, v1, :cond_0

    .line 85
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixVectorMult_DDRM;->mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;)V

    return-object p2

    .line 86
    :cond_0
    sget v1, Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters;->MULT_COLUMN_SWITCH:I

    if-lt v0, v1, :cond_1

    .line 87
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_DDRM;->mult_reorder(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;)V

    return-object p2

    .line 89
    :cond_1
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_DDRM;->mult_small(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;)V

    return-object p2
.end method

.method public static multTransB(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;
    .locals 2

    .line 200
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    invoke-static {p2, p0, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->reshapeOrDeclare(Lcom/scanflow/datacapture/barinternal/org/ejml/data/ReshapeMatrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ReshapeMatrix;II)Lcom/scanflow/datacapture/barinternal/org/ejml/data/ReshapeMatrix;

    move-result-object p2

    check-cast p2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;

    .line 201
    invoke-static {p0, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->checkSameInstance(Ljava/lang/Object;Ljava/lang/Object;)V

    .line 202
    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->checkSameInstance(Ljava/lang/Object;Ljava/lang/Object;)V

    .line 204
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    const/4 v1, 0x1

    if-ne v0, v1, :cond_0

    .line 205
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixVectorMult_DDRM;->mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;)V

    return-object p2

    .line 207
    :cond_0
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_DDRM;->multTransB(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;)V

    return-object p2
.end method

.method public static scale(DLcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;)V
    .locals 5

    .line 2271
    invoke-interface {p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;->getNumElements()I

    move-result v0

    const/4 v1, 0x0

    :goto_0
    if-ge v1, v0, :cond_0

    .line 2274
    iget-object v2, p2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    aget-wide v3, v2, v1

    mul-double/2addr v3, p0

    aput-wide v3, v2, v1

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static setIdentity(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;)V
    .locals 6

    .line 957
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    if-ge v0, v1, :cond_0

    goto :goto_0

    :cond_0
    move v0, v1

    .line 959
    :goto_0
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;->getNumElements()I

    move-result v2

    const-wide/16 v3, 0x0

    const/4 v5, 0x0

    invoke-static {v1, v5, v2, v3, v4}, Ljava/util/Arrays;->fill([DIID)V

    move v1, v5

    :goto_1
    if-ge v5, v0, :cond_1

    .line 963
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    const-wide/high16 v3, 0x3ff0000000000000L    # 1.0

    aput-wide v3, v2, v1

    add-int/lit8 v5, v5, 0x1

    .line 962
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    add-int/lit8 v2, v2, 0x1

    add-int/2addr v1, v2

    goto :goto_1

    :cond_1
    return-void
.end method

.method public static transpose(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;
    .locals 2

    .line 664
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    invoke-static {p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->reshapeOrDeclare(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;II)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    move-result-object p1

    .line 666
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    sget v1, Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters;->TRANSPOSE_SWITCH:I

    if-le v0, v1, :cond_0

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    if-le v0, v1, :cond_0

    .line 668
    sget v0, Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters;->BLOCK_WIDTH:I

    invoke-static {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/misc/TransposeAlgs_DDRM;->block(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;I)V

    return-object p1

    .line 670
    :cond_0
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/misc/TransposeAlgs_DDRM;->standard(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;)V

    return-object p1
.end method

.method public static transpose(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)V
    .locals 3

    .line 642
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    if-ne v0, v1, :cond_0

    .line 643
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/misc/TransposeAlgs_DDRM;->square(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;)V

    return-void

    .line 645
    :cond_0
    new-instance v2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-direct {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;-><init>(II)V

    .line 646
    invoke-static {p0, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/CommonOps_DDRM;->transpose(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    .line 647
    invoke-virtual {p0, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->setTo(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;)V

    return-void
.end method
