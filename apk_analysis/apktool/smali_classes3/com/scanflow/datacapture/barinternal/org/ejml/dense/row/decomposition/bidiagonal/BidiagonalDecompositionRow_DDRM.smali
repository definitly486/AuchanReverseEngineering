.class public Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;
.super Ljava/lang/Object;
.source "BidiagonalDecompositionRow_DDRM.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/org/ejml/interfaces/decomposition/BidiagonalDecomposition_F64;


# instance fields
.field private UBV:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

.field protected b:[D

.field private gammasU:[D

.field private gammasV:[D

.field private m:I

.field private min:I

.field private n:I

.field protected u:[D


# direct methods
.method public constructor <init>()V
    .locals 1

    const/4 v0, 0x1

    .line 68
    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;-><init>(I)V

    return-void
.end method

.method public constructor <init>(I)V
    .locals 1

    .line 58
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 60
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-direct {v0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;-><init>(I)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->UBV:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    .line 61
    new-array v0, p1, [D

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->gammasU:[D

    .line 62
    new-array v0, p1, [D

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->gammasV:[D

    .line 63
    new-array v0, p1, [D

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->b:[D

    .line 64
    new-array p1, p1, [D

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->u:[D

    return-void
.end method

.method private _decompose()Z
    .locals 2

    const/4 v0, 0x0

    .line 289
    :goto_0
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->min:I

    if-ge v0, v1, :cond_0

    .line 291
    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->computeU(I)V

    .line 294
    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->computeV(I)V

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    const/4 v0, 0x1

    return v0
.end method

.method public static handleU(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;ZZIII)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;
    .locals 0

    const/4 p4, 0x0

    if-eqz p2, :cond_3

    if-eqz p1, :cond_1

    if-nez p0, :cond_0

    .line 210
    new-instance p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-direct {p0, p5, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;-><init>(II)V

    return-object p0

    .line 212
    :cond_0
    invoke-virtual {p0, p5, p3, p4}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->reshape(IIZ)V

    return-object p0

    :cond_1
    if-nez p0, :cond_2

    .line 216
    new-instance p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-direct {p0, p3, p5}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;-><init>(II)V

    return-object p0

    .line 218
    :cond_2
    invoke-virtual {p0, p3, p5, p4}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->reshape(IIZ)V

    return-object p0

    :cond_3
    if-nez p0, :cond_4

    .line 222
    new-instance p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-direct {p0, p3, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;-><init>(II)V

    return-object p0

    .line 224
    :cond_4
    invoke-virtual {p0, p3, p3, p4}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->reshape(IIZ)V

    return-object p0
.end method

.method public static handleV(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;ZZIII)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;
    .locals 0

    if-le p4, p3, :cond_0

    add-int/lit8 p5, p5, 0x1

    :cond_0
    const/4 p3, 0x0

    if-eqz p2, :cond_4

    if-eqz p1, :cond_2

    if-nez p0, :cond_1

    .line 266
    new-instance p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-direct {p0, p5, p4}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;-><init>(II)V

    return-object p0

    .line 268
    :cond_1
    invoke-virtual {p0, p5, p4, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->reshape(IIZ)V

    return-object p0

    :cond_2
    if-nez p0, :cond_3

    .line 271
    new-instance p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-direct {p0, p4, p5}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;-><init>(II)V

    return-object p0

    .line 273
    :cond_3
    invoke-virtual {p0, p4, p5, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->reshape(IIZ)V

    return-object p0

    :cond_4
    if-nez p0, :cond_5

    .line 277
    new-instance p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-direct {p0, p4, p4}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;-><init>(II)V

    return-object p0

    .line 279
    :cond_5
    invoke-virtual {p0, p4, p4, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->reshape(IIZ)V

    return-object p0
.end method


# virtual methods
.method protected computeU(I)V
    .locals 13

    .line 303
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->UBV:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    iget-object v1, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    const-wide/16 v2, 0x0

    move v4, p1

    move-wide v9, v2

    .line 309
    :goto_0
    iget v6, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->m:I

    if-ge v4, v6, :cond_1

    .line 312
    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->u:[D

    iget v7, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->n:I

    mul-int/2addr v7, v4

    add-int/2addr v7, p1

    aget-wide v7, v1, v7

    aput-wide v7, v6, v4

    .line 313
    invoke-static {v7, v8}, Ljava/lang/Math;->abs(D)D

    move-result-wide v6

    cmpl-double v8, v6, v9

    if-lez v8, :cond_0

    move-wide v9, v6

    :cond_0
    add-int/lit8 v4, v4, 0x1

    goto :goto_0

    :cond_1
    cmpl-double v4, v9, v2

    if-lez v4, :cond_2

    .line 320
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->u:[D

    invoke-static {p1, v6, v2, v9, v10}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QrHelperFunctions_DDRM;->computeTauAndDivide(II[DD)D

    move-result-wide v11

    .line 324
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->u:[D

    aget-wide v2, v4, p1

    add-double v7, v2, v11

    move-object v5, v1

    add-int/lit8 v1, p1, 0x1

    .line 325
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->m:I

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->n:I

    move v6, p1

    invoke-static/range {v1 .. v8}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QrHelperFunctions_DDRM;->divideElements_Bcol(III[D[DID)V

    move-wide v2, v7

    move-object v7, v5

    .line 326
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->u:[D

    const-wide/high16 v5, 0x3ff0000000000000L    # 1.0

    aput-wide v5, v4, p1

    div-double/2addr v2, v11

    .line 329
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->gammasU:[D

    aput-wide v2, v4, p1

    move v4, v1

    .line 332
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->UBV:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    iget v6, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->m:I

    move-object v0, p0

    move v5, p1

    invoke-virtual/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->rank1UpdateMultR(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;DIII)V

    .line 334
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->n:I

    mul-int/2addr v1, p1

    add-int/2addr v1, p1

    neg-double v2, v11

    mul-double/2addr v2, v9

    aput-wide v2, v7, v1

    return-void

    .line 336
    :cond_2
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->gammasU:[D

    aput-wide v2, v1, p1

    return-void
.end method

.method protected computeV(I)V
    .locals 14

    .line 349
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->UBV:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    iget-object v4, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    .line 351
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->n:I

    mul-int v5, p1, v1

    add-int v2, v5, p1

    add-int/lit8 v9, v2, 0x1

    sub-int/2addr v1, p1

    add-int/lit8 v1, v1, -0x1

    .line 355
    invoke-static {v4, v9, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QrHelperFunctions_DDRM;->findMax([DII)D

    move-result-wide v6

    const-wide/16 v1, 0x0

    cmpl-double v3, v6, v1

    if-lez v3, :cond_0

    add-int/lit8 v2, p1, 0x1

    .line 360
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->n:I

    invoke-static/range {v2 .. v7}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QrHelperFunctions_DDRM;->computeTauAndDivide(II[DID)D

    move-result-wide v10

    move v1, v2

    move-wide v12, v6

    .line 363
    aget-wide v2, v4, v9

    add-double v7, v2, v10

    add-int/lit8 v2, p1, 0x2

    .line 364
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->n:I

    move v6, v5

    move-object v5, v4

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->u:[D

    invoke-static/range {v2 .. v8}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QrHelperFunctions_DDRM;->divideElements_Brow(II[D[DID)V

    move-wide v2, v7

    move-object v7, v5

    .line 366
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->u:[D

    const-wide/high16 v5, 0x3ff0000000000000L    # 1.0

    aput-wide v5, v4, v1

    div-double/2addr v2, v10

    .line 369
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->gammasV:[D

    aput-wide v2, v4, p1

    move v4, v1

    .line 374
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->UBV:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    iget v6, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->n:I

    move v5, v4

    move-object v0, p0

    invoke-virtual/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->rank1UpdateMultL(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;DIII)V

    neg-double v1, v10

    mul-double/2addr v1, v12

    .line 376
    aput-wide v1, v7, v9

    return-void

    .line 378
    :cond_0
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->gammasV:[D

    aput-wide v1, v3, p1

    return-void
.end method

.method public decompose(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)Z
    .locals 0

    .line 80
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->init(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)V

    .line 81
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->_decompose()Z

    move-result p1

    return p1
.end method

.method public bridge synthetic decompose(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Z
    .locals 0

    .line 34
    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->decompose(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)Z

    move-result p1

    return p1
.end method

.method public getDiagonal([D[D)V
    .locals 4

    .line 121
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->n:I

    if-gtz v0, :cond_0

    goto :goto_1

    .line 123
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->UBV:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    const/4 v1, 0x0

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->get(I)D

    move-result-wide v2

    aput-wide v2, p1, v1

    const/4 v0, 0x1

    .line 124
    :goto_0
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->n:I

    if-ge v0, v1, :cond_1

    .line 125
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->UBV:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-virtual {v1, v0, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->unsafe_get(II)D

    move-result-wide v1

    aput-wide v1, p1, v0

    add-int/lit8 v1, v0, -0x1

    .line 126
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->UBV:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-virtual {v2, v1, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->unsafe_get(II)D

    move-result-wide v2

    aput-wide v2, p2, v1

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_1
    :goto_1
    return-void
.end method

.method public getU(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;ZZ)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;
    .locals 9

    .line 183
    iget v4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->m:I

    iget v5, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->n:I

    iget v6, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->min:I

    move-object v1, p1

    move v2, p2

    move v3, p3

    invoke-static/range {v1 .. v6}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->handleU(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;ZZIII)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    move-result-object v1

    .line 184
    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/CommonOps_DDRM;->setIdentity(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;)V

    const/4 v2, 0x0

    .line 186
    :goto_0
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->m:I

    if-ge v2, v3, :cond_0

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->u:[D

    const-wide/16 v4, 0x0

    aput-wide v4, v3, v2

    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    .line 188
    :cond_0
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->min:I

    add-int/lit8 v2, v2, -0x1

    move v4, v2

    :goto_1
    if-ltz v4, :cond_3

    .line 189
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->u:[D

    const-wide/high16 v5, 0x3ff0000000000000L    # 1.0

    aput-wide v5, v2, v4

    add-int/lit8 v2, v4, 0x1

    .line 190
    :goto_2
    iget v6, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->m:I

    if-ge v2, v6, :cond_1

    .line 191
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->u:[D

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->UBV:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-virtual {v5, v2, v4}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->get(II)D

    move-result-wide v5

    aput-wide v5, v3, v2

    add-int/lit8 v2, v2, 0x1

    goto :goto_2

    :cond_1
    if-eqz p2, :cond_2

    .line 195
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->gammasU:[D

    aget-wide v7, v2, v4

    move v5, v4

    move-object v0, p0

    move-wide v2, v7

    invoke-virtual/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->rank1UpdateMultL(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;DIII)V

    goto :goto_3

    .line 197
    :cond_2
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->gammasU:[D

    aget-wide v7, v2, v4

    move v5, v4

    move-object v0, p0

    move-wide v2, v7

    invoke-virtual/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->rank1UpdateMultR(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;DIII)V

    :goto_3
    add-int/lit8 v4, v4, -0x1

    goto :goto_1

    :cond_3
    return-object v1
.end method

.method public bridge synthetic getU(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;ZZ)Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;
    .locals 0

    .line 34
    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-virtual {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->getU(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;ZZ)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    move-result-object p1

    return-object p1
.end method

.method public getV(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;ZZ)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;
    .locals 10

    .line 238
    iget v4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->m:I

    iget v5, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->n:I

    iget v6, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->min:I

    move-object v1, p1

    move v2, p2

    move v3, p3

    invoke-static/range {v1 .. v6}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->handleV(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;ZZIII)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    move-result-object v1

    .line 239
    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/CommonOps_DDRM;->setIdentity(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;)V

    .line 244
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->min:I

    add-int/lit8 v2, v2, -0x1

    move v7, v2

    :goto_0
    if-ltz v7, :cond_2

    .line 245
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->u:[D

    add-int/lit8 v4, v7, 0x1

    const-wide/high16 v5, 0x3ff0000000000000L    # 1.0

    aput-wide v5, v2, v4

    add-int/lit8 v2, v7, 0x2

    .line 246
    :goto_1
    iget v6, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->n:I

    if-ge v2, v6, :cond_0

    .line 247
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->u:[D

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->UBV:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-virtual {v5, v7, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->get(II)D

    move-result-wide v5

    aput-wide v5, v3, v2

    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    :cond_0
    if-eqz p2, :cond_1

    .line 250
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->gammasV:[D

    aget-wide v8, v2, v7

    move v5, v4

    move-object v0, p0

    move-wide v2, v8

    invoke-virtual/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->rank1UpdateMultL(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;DIII)V

    goto :goto_2

    .line 252
    :cond_1
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->gammasV:[D

    aget-wide v8, v2, v7

    move v5, v4

    move-object v0, p0

    move-wide v2, v8

    invoke-virtual/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->rank1UpdateMultR(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;DIII)V

    :goto_2
    add-int/lit8 v7, v7, -0x1

    goto :goto_0

    :cond_2
    return-object v1
.end method

.method public bridge synthetic getV(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;ZZ)Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;
    .locals 0

    .line 34
    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-virtual {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->getV(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;ZZ)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    move-result-object p1

    return-object p1
.end method

.method protected init(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)V
    .locals 1

    .line 90
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->UBV:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    .line 92
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->m:I

    .line 93
    iget p1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->n:I

    .line 95
    invoke-static {v0, p1}, Ljava/lang/Math;->min(II)I

    move-result p1

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->min:I

    .line 96
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->m:I

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->n:I

    invoke-static {p1, v0}, Ljava/lang/Math;->max(II)I

    move-result p1

    .line 98
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->b:[D

    array-length v0, v0

    add-int/lit8 p1, p1, 0x1

    if-ge v0, p1, :cond_0

    .line 99
    new-array v0, p1, [D

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->b:[D

    .line 100
    new-array p1, p1, [D

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->u:[D

    .line 102
    :cond_0
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->gammasU:[D

    array-length p1, p1

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->m:I

    if-ge p1, v0, :cond_1

    .line 103
    new-array p1, v0, [D

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->gammasU:[D

    .line 105
    :cond_1
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->gammasV:[D

    array-length p1, p1

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->n:I

    if-ge p1, v0, :cond_2

    .line 106
    new-array p1, v0, [D

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->gammasV:[D

    :cond_2
    return-void
.end method

.method protected rank1UpdateMultL(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;DIII)V
    .locals 7

    .line 341
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->u:[D

    move-object v0, p1

    move-wide v2, p2

    move v4, p4

    move v5, p5

    move v6, p6

    invoke-static/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QrHelperFunctions_DDRM;->rank1UpdateMultL(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;[DDIII)V

    return-void
.end method

.method protected rank1UpdateMultR(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;DIII)V
    .locals 8

    .line 345
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->u:[D

    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/bidiagonal/BidiagonalDecompositionRow_DDRM;->b:[D

    move-object v0, p1

    move-wide v2, p2

    move v4, p4

    move v5, p5

    move v6, p6

    invoke-static/range {v0 .. v7}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/qr/QrHelperFunctions_DDRM;->rank1UpdateMultR(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;[DDIII[D)V

    return-void
.end method
