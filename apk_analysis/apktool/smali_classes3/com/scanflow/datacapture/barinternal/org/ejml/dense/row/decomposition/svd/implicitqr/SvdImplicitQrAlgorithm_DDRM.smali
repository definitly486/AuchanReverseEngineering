.class public Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;
.super Ljava/lang/Object;
.source "SvdImplicitQrAlgorithm_DDRM.java"


# instance fields
.field protected N:I

.field protected Ut:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

.field protected Vt:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

.field bulge:D

.field c:D

.field protected diag:[D

.field protected eigenSmall:Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/eig/EigenvalueSmall_F64;

.field private exceptionalThresh:I

.field private fastValues:Z

.field private findingZeros:Z

.field followScript:Z

.field private maxIterations:I

.field protected maxValue:D

.field protected nextExceptional:I

.field protected numExceptional:I

.field protected numSplits:I

.field protected off:[D

.field protected rand:Ljava/util/Random;

.field s:D

.field protected splits:[I

.field steps:I

.field protected totalSteps:I

.field private values:[D

.field protected x1:I

.field protected x2:I


# direct methods
.method public constructor <init>()V
    .locals 3

    .line 125
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 54
    new-instance v0, Ljava/util/Random;

    const-wide/32 v1, 0x34671e

    invoke-direct {v0, v1, v2}, Ljava/util/Random;-><init>(J)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->rand:Ljava/util/Random;

    .line 72
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/eig/EigenvalueSmall_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/eig/EigenvalueSmall_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->eigenSmall:Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/eig/EigenvalueSmall_F64;

    const/16 v0, 0xf

    .line 98
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->exceptionalThresh:I

    mul-int/lit8 v0, v0, 0x64

    .line 99
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->maxIterations:I

    const/4 v0, 0x0

    .line 111
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->fastValues:Z

    return-void
.end method

.method private computeBulgeScale()D
    .locals 6

    .line 407
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->diag:[D

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->x1:I

    aget-wide v2, v0, v1

    .line 408
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->off:[D

    aget-wide v4, v0, v1

    .line 410
    invoke-static {v2, v3}, Ljava/lang/Math;->abs(D)D

    move-result-wide v0

    invoke-static {v4, v5}, Ljava/lang/Math;->abs(D)D

    move-result-wide v2

    invoke-static {v0, v1, v2, v3}, Ljava/lang/Math;->max(DD)D

    move-result-wide v0

    return-wide v0
.end method

.method private performDynamicStep()V
    .locals 13

    .line 273
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->findingZeros:Z

    if-eqz v0, :cond_1

    .line 274
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->steps:I

    const/4 v1, 0x6

    if-le v0, v1, :cond_0

    const/4 v0, 0x0

    .line 275
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->findingZeros:Z

    return-void

    .line 277
    :cond_0
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->computeBulgeScale()D

    move-result-wide v2

    const-wide/16 v4, 0x0

    const/4 v6, 0x0

    move-object v1, p0

    .line 278
    invoke-virtual/range {v1 .. v6}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->performImplicitSingleStep(DDZ)V

    return-void

    :cond_1
    move-object v1, p0

    .line 285
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->computeBulgeScale()D

    move-result-wide v8

    .line 287
    invoke-virtual {p0, v8, v9}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->selectWilkinsonShift(D)D

    move-result-wide v10

    const/4 v12, 0x0

    move-object v7, v1

    .line 289
    invoke-virtual/range {v7 .. v12}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->performImplicitSingleStep(DDZ)V

    return-void
.end method

.method private performScriptedStep()V
    .locals 6

    .line 298
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->computeBulgeScale()D

    move-result-wide v1

    .line 299
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->steps:I

    const/16 v3, 0xa

    if-le v0, v3, :cond_0

    const/4 v0, 0x0

    .line 301
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->followScript:Z

    return-void

    .line 304
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->values:[D

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->x2:I

    aget-wide v3, v0, v3

    div-double/2addr v3, v1

    mul-double/2addr v3, v3

    const/4 v5, 0x0

    move-object v0, p0

    .line 305
    invoke-virtual/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->performImplicitSingleStep(DDZ)V

    return-void
.end method

.method private pushRight(I)V
    .locals 6

    .line 670
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->isOffZero(I)Z

    move-result v0

    if-eqz v0, :cond_0

    goto :goto_1

    .line 675
    :cond_0
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->rotatorPushRight(I)V

    .line 676
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->N:I

    add-int/lit8 v0, v0, -0x2

    sub-int/2addr v0, p1

    const/4 v1, 0x0

    :goto_0
    if-ge v1, v0, :cond_1

    .line 677
    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->bulge:D

    const-wide/16 v4, 0x0

    cmpl-double v2, v2, v4

    if-eqz v2, :cond_1

    add-int/lit8 v2, v1, 0x2

    .line 678
    invoke-direct {p0, p1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->rotatorPushRight2(II)V

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_1
    :goto_1
    return-void
.end method

.method private rotatorPushRight(I)V
    .locals 13

    .line 687
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->off:[D

    aget-wide v1, v0, p1

    .line 688
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->diag:[D

    add-int/lit8 v6, p1, 0x1

    aget-wide v3, v0, v6

    neg-double v7, v1

    .line 690
    invoke-virtual {p0, v3, v4, v7, v8}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->computeRotator(DD)V

    .line 693
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->off:[D

    const-wide/16 v7, 0x0

    aput-wide v7, v0, p1

    .line 694
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->diag:[D

    move-wide v9, v7

    iget-wide v7, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->c:D

    mul-double/2addr v3, v7

    move-wide v11, v9

    iget-wide v9, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->s:D

    mul-double/2addr v1, v9

    sub-double/2addr v3, v1

    aput-wide v3, v5, v6

    add-int/lit8 v1, p1, 0x2

    .line 696
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->N:I

    if-ge v1, v2, :cond_0

    .line 697
    aget-wide v1, v0, v6

    mul-double v3, v1, v7

    .line 698
    aput-wide v3, v0, v6

    mul-double/2addr v1, v9

    .line 699
    iput-wide v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->bulge:D

    goto :goto_0

    .line 701
    :cond_0
    iput-wide v11, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->bulge:D

    .line 712
    :goto_0
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->Ut:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    if-eqz v4, :cond_1

    move-object v3, p0

    move v5, p1

    .line 713
    invoke-virtual/range {v3 .. v10}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->updateRotator(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;IIDD)V

    :cond_1
    return-void
.end method

.method private rotatorPushRight2(II)V
    .locals 11

    .line 726
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->bulge:D

    .line 727
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->diag:[D

    add-int v6, p1, p2

    aget-wide v3, v2, v6

    neg-double v7, v0

    .line 729
    invoke-virtual {p0, v3, v4, v7, v8}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->computeRotator(DD)V

    .line 731
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->diag:[D

    iget-wide v7, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->c:D

    mul-double/2addr v3, v7

    iget-wide v9, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->s:D

    mul-double/2addr v0, v9

    sub-double/2addr v3, v0

    aput-wide v3, p2, v6

    .line 733
    iget p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->N:I

    add-int/lit8 p2, p2, -0x1

    if-ge v6, p2, :cond_0

    .line 734
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->off:[D

    aget-wide v0, p2, v6

    mul-double v2, v0, v7

    .line 735
    aput-wide v2, p2, v6

    mul-double/2addr v0, v9

    .line 736
    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->bulge:D

    .line 747
    :cond_0
    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->Ut:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    if-eqz v4, :cond_1

    move-object v3, p0

    move v5, p1

    .line 748
    invoke-virtual/range {v3 .. v10}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->updateRotator(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;IIDD)V

    :cond_1
    return-void
.end method


# virtual methods
.method public _process()Z
    .locals 5

    .line 227
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->maxValue:D

    const-wide/16 v2, 0x0

    cmpl-double v0, v0, v2

    const/4 v1, 0x1

    if-nez v0, :cond_0

    return v1

    .line 229
    :cond_0
    :goto_0
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->x2:I

    if-ltz v0, :cond_6

    .line 231
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->steps:I

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->maxIterations:I

    if-le v2, v3, :cond_1

    const/4 v0, 0x0

    return v0

    .line 235
    :cond_1
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->x1:I

    if-ne v3, v0, :cond_2

    .line 239
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->resetSteps()V

    .line 240
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->nextSplit()Z

    move-result v0

    if-nez v0, :cond_0

    goto :goto_1

    .line 242
    :cond_2
    iget-boolean v4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->fastValues:Z

    if-eqz v4, :cond_3

    sub-int/2addr v0, v3

    if-ne v0, v1, :cond_3

    .line 244
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->resetSteps()V

    .line 245
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->x1:I

    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->eigenBB_2x2(I)V

    .line 246
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->x2:I

    invoke-virtual {p0, v0, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->setSubmatrix(II)V

    goto :goto_0

    .line 247
    :cond_3
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->nextExceptional:I

    if-lt v2, v0, :cond_4

    .line 248
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->exceptionShift()V

    goto :goto_0

    .line 251
    :cond_4
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->checkForAndHandleZeros()Z

    move-result v0

    if-nez v0, :cond_0

    .line 252
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->followScript:Z

    if-eqz v0, :cond_5

    .line 253
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->performScriptedStep()V

    goto :goto_0

    .line 255
    :cond_5
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->performDynamicStep()V

    goto :goto_0

    :cond_6
    :goto_1
    return v1
.end method

.method protected checkForAndHandleZeros()Z
    .locals 5

    .line 641
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->x2:I

    const/4 v1, 0x1

    sub-int/2addr v0, v1

    :goto_0
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->x1:I

    if-lt v0, v2, :cond_1

    .line 642
    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->isOffZero(I)Z

    move-result v2

    if-eqz v2, :cond_0

    .line 644
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->resetSteps()V

    .line 645
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->splits:[I

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->numSplits:I

    add-int/lit8 v4, v3, 0x1

    iput v4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->numSplits:I

    aput v0, v2, v3

    add-int/2addr v0, v1

    .line 646
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->x1:I

    return v1

    :cond_0
    add-int/lit8 v0, v0, -0x1

    goto :goto_0

    .line 652
    :cond_1
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->x2:I

    sub-int/2addr v0, v1

    :goto_1
    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->x1:I

    if-lt v0, v2, :cond_3

    .line 653
    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->isDiagonalZero(I)Z

    move-result v2

    if-eqz v2, :cond_2

    .line 655
    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->pushRight(I)V

    .line 656
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->resetSteps()V

    .line 657
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->splits:[I

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->numSplits:I

    add-int/lit8 v4, v3, 0x1

    iput v4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->numSplits:I

    aput v0, v2, v3

    add-int/2addr v0, v1

    .line 658
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->x1:I

    return v1

    :cond_2
    add-int/lit8 v0, v0, -0x1

    goto :goto_1

    :cond_3
    const/4 v0, 0x0

    return v0
.end method

.method protected computeRotator(DD)V
    .locals 4

    .line 474
    invoke-static {p1, p2}, Ljava/lang/Math;->abs(D)D

    move-result-wide v0

    invoke-static {p3, p4}, Ljava/lang/Math;->abs(D)D

    move-result-wide v2

    cmpg-double v0, v0, v2

    const-wide/high16 v1, 0x3ff0000000000000L    # 1.0

    if-gez v0, :cond_0

    div-double/2addr p1, p3

    mul-double p3, p1, p1

    add-double/2addr p3, v1

    .line 477
    invoke-static {p3, p4}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide p3

    div-double/2addr v1, p3

    .line 478
    iput-wide v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->s:D

    div-double/2addr p1, p3

    .line 479
    iput-wide p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->c:D

    return-void

    :cond_0
    div-double/2addr p3, p1

    mul-double p1, p3, p3

    add-double/2addr p1, v1

    .line 482
    invoke-static {p1, p2}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide p1

    div-double/2addr v1, p1

    .line 483
    iput-wide v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->c:D

    div-double/2addr p3, p1

    .line 484
    iput-wide p3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->s:D

    return-void
.end method

.method protected createBulge(IDDZ)V
    .locals 19

    move-object/from16 v0, p0

    .line 423
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->diag:[D

    aget-wide v2, v1, p1

    .line 424
    iget-object v4, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->off:[D

    aget-wide v5, v4, p1

    move-wide v7, v2

    add-int/lit8 v3, p1, 0x1

    .line 425
    aget-wide v9, v1, v3

    if-eqz p6, :cond_0

    .line 428
    invoke-static/range {p2 .. p3}, Ljava/lang/Math;->cos(D)D

    move-result-wide v1

    iput-wide v1, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->c:D

    .line 429
    invoke-static/range {p2 .. p3}, Ljava/lang/Math;->sin(D)D

    move-result-wide v1

    iput-wide v1, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->s:D

    goto :goto_0

    :cond_0
    div-double v1, v7, p4

    mul-double v11, v1, v1

    sub-double v11, v11, p2

    div-double v13, v5, p4

    mul-double/2addr v13, v1

    mul-double v1, v11, v11

    mul-double v15, v13, v13

    add-double/2addr v1, v15

    .line 435
    invoke-static {v1, v2}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide v1

    div-double/2addr v11, v1

    .line 437
    iput-wide v11, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->c:D

    div-double/2addr v13, v1

    .line 438
    iput-wide v13, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->s:D

    .line 442
    :goto_0
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->diag:[D

    move-wide v11, v5

    iget-wide v4, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->c:D

    mul-double v13, v7, v4

    move-wide v15, v7

    iget-wide v6, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->s:D

    mul-double v17, v11, v6

    add-double v13, v13, v17

    aput-wide v13, v1, p1

    .line 443
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->off:[D

    mul-double/2addr v11, v4

    mul-double v13, v15, v6

    sub-double/2addr v11, v13

    aput-wide v11, v2, p1

    mul-double v11, v9, v4

    .line 444
    aput-wide v11, v1, v3

    mul-double/2addr v9, v6

    .line 445
    iput-wide v9, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->bulge:D

    .line 454
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->Vt:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    if-eqz v1, :cond_1

    move/from16 v2, p1

    .line 455
    invoke-virtual/range {v0 .. v7}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->updateRotator(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;IIDD)V

    :cond_1
    return-void
.end method

.method protected eigenBB_2x2(I)V
    .locals 22

    move-object/from16 v0, p0

    .line 604
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->diag:[D

    aget-wide v2, v1, p1

    .line 605
    iget-object v4, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->off:[D

    aget-wide v5, v4, p1

    add-int/lit8 v4, p1, 0x1

    .line 606
    aget-wide v7, v1, v4

    .line 609
    invoke-static {v2, v3}, Ljava/lang/Math;->abs(D)D

    move-result-wide v9

    .line 610
    invoke-static {v5, v6}, Ljava/lang/Math;->abs(D)D

    move-result-wide v11

    .line 611
    invoke-static {v7, v8}, Ljava/lang/Math;->abs(D)D

    move-result-wide v13

    cmpl-double v1, v9, v11

    if-lez v1, :cond_0

    goto :goto_0

    :cond_0
    move-wide v9, v11

    :goto_0
    cmpl-double v1, v13, v9

    if-lez v1, :cond_1

    goto :goto_1

    :cond_1
    move-wide v13, v9

    :goto_1
    const-wide/16 v9, 0x0

    cmpl-double v1, v13, v9

    if-nez v1, :cond_2

    return-void

    :cond_2
    div-double/2addr v2, v13

    div-double/2addr v5, v13

    div-double/2addr v7, v13

    .line 625
    iget-object v15, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->eigenSmall:Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/eig/EigenvalueSmall_F64;

    mul-double v16, v2, v2

    mul-double v18, v2, v5

    mul-double/2addr v5, v5

    mul-double/2addr v7, v7

    add-double v20, v5, v7

    invoke-virtual/range {v15 .. v21}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/eig/EigenvalueSmall_F64;->symm2x2_fast(DDD)V

    .line 627
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->off:[D

    aput-wide v9, v1, p1

    .line 628
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->diag:[D

    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->eigenSmall:Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/eig/EigenvalueSmall_F64;

    iget-object v2, v2, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/eig/EigenvalueSmall_F64;->value0:Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;

    iget-wide v2, v2, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;->real:D

    invoke-static {v2, v3}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide v2

    mul-double/2addr v2, v13

    aput-wide v2, v1, p1

    .line 629
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->eigenSmall:Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/eig/EigenvalueSmall_F64;

    iget-object v1, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/eig/EigenvalueSmall_F64;->value1:Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;

    iget-wide v1, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;->real:D

    invoke-static {v1, v2}, Ljava/lang/Math;->signum(D)D

    move-result-wide v1

    .line 630
    iget-object v3, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->diag:[D

    mul-double/2addr v1, v13

    iget-object v5, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->eigenSmall:Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/eig/EigenvalueSmall_F64;

    iget-object v5, v5, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/eig/EigenvalueSmall_F64;->value1:Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;

    iget-wide v5, v5, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;->real:D

    invoke-static {v5, v6}, Ljava/lang/Math;->abs(D)D

    move-result-wide v5

    invoke-static {v5, v6}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide v5

    mul-double/2addr v1, v5

    aput-wide v1, v3, v4

    return-void
.end method

.method public exceptionShift()V
    .locals 13

    .line 762
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->numExceptional:I

    add-int/lit8 v0, v0, 0x1

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->numExceptional:I

    const-wide v1, 0x3fa999999999999aL    # 0.05

    int-to-double v3, v0

    mul-double/2addr v3, v1

    const-wide/high16 v0, 0x3ff0000000000000L    # 1.0

    cmpl-double v2, v3, v0

    if-lez v2, :cond_0

    move-wide v3, v0

    :cond_0
    const-wide/high16 v0, 0x4000000000000000L    # 2.0

    .line 766
    sget-wide v5, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->PI:D

    mul-double/2addr v5, v0

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->rand:Ljava/util/Random;

    invoke-virtual {v0}, Ljava/util/Random;->nextDouble()D

    move-result-wide v0

    const-wide/high16 v7, 0x3fe0000000000000L    # 0.5

    sub-double/2addr v0, v7

    mul-double/2addr v5, v0

    mul-double v10, v5, v3

    const-wide/16 v8, 0x0

    const/4 v12, 0x1

    move-object v7, p0

    .line 767
    invoke-virtual/range {v7 .. v12}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->performImplicitSingleStep(DDZ)V

    .line 770
    iget v0, v7, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->steps:I

    iget v1, v7, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->exceptionalThresh:I

    add-int/2addr v0, v1

    iput v0, v7, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->nextExceptional:I

    return-void
.end method

.method public getNumberOfSingularValues()I
    .locals 1

    .line 787
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->N:I

    return v0
.end method

.method public getSingularValue(I)D
    .locals 3

    .line 791
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->diag:[D

    aget-wide v1, v0, p1

    return-wide v1
.end method

.method public getSingularValues()[D
    .locals 1

    .line 799
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->diag:[D

    return-object v0
.end method

.method public incrementSteps()V
    .locals 1

    .line 310
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->steps:I

    add-int/lit8 v0, v0, 0x1

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->steps:I

    .line 311
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->totalSteps:I

    add-int/lit8 v0, v0, 0x1

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->totalSteps:I

    return-void
.end method

.method public initParam(II)V
    .locals 0

    if-gt p2, p1, :cond_2

    .line 191
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->N:I

    .line 193
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->splits:[I

    if-eqz p1, :cond_0

    array-length p1, p1

    if-ge p1, p2, :cond_1

    .line 194
    :cond_0
    new-array p1, p2, [I

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->splits:[I

    :cond_1
    const/4 p1, 0x0

    .line 197
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->x1:I

    add-int/lit8 p2, p2, -0x1

    .line 198
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->x2:I

    .line 200
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->steps:I

    .line 201
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->totalSteps:I

    .line 202
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->numSplits:I

    .line 203
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->numExceptional:I

    .line 204
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->exceptionalThresh:I

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->nextExceptional:I

    return-void

    .line 189
    :cond_2
    new-instance p1, Ljava/lang/RuntimeException;

    const-string p2, "Must be a square or tall matrix"

    invoke-direct {p1, p2}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public isDiagonalZero(I)Z
    .locals 6

    .line 323
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->diag:[D

    add-int/lit8 v1, p1, 0x1

    aget-wide v1, v0, v1

    invoke-static {v1, v2}, Ljava/lang/Math;->abs(D)D

    move-result-wide v0

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->off:[D

    aget-wide v3, v2, p1

    invoke-static {v3, v4}, Ljava/lang/Math;->abs(D)D

    move-result-wide v2

    add-double/2addr v0, v2

    .line 325
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->diag:[D

    aget-wide v3, v2, p1

    invoke-static {v3, v4}, Ljava/lang/Math;->abs(D)D

    move-result-wide v2

    sget-wide v4, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->EPS:D

    mul-double/2addr v0, v4

    cmpg-double p1, v2, v0

    if-gtz p1, :cond_0

    const/4 p1, 0x1

    return p1

    :cond_0
    const/4 p1, 0x0

    return p1
.end method

.method public isOffZero(I)Z
    .locals 6

    .line 315
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->diag:[D

    aget-wide v1, v0, p1

    invoke-static {v1, v2}, Ljava/lang/Math;->abs(D)D

    move-result-wide v0

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->diag:[D

    add-int/lit8 v3, p1, 0x1

    aget-wide v3, v2, v3

    invoke-static {v3, v4}, Ljava/lang/Math;->abs(D)D

    move-result-wide v2

    add-double/2addr v0, v2

    .line 317
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->off:[D

    aget-wide v3, v2, p1

    invoke-static {v3, v4}, Ljava/lang/Math;->abs(D)D

    move-result-wide v2

    sget-wide v4, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->EPS:D

    mul-double/2addr v0, v4

    cmpg-double p1, v2, v0

    if-gtz p1, :cond_0

    const/4 p1, 0x1

    return p1

    :cond_0
    const/4 p1, 0x0

    return p1
.end method

.method public nextSplit()Z
    .locals 5

    .line 339
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->numSplits:I

    const/4 v1, 0x0

    if-nez v0, :cond_0

    return v1

    .line 341
    :cond_0
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->splits:[I

    add-int/lit8 v3, v0, -0x1

    iput v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->numSplits:I

    aget v4, v2, v3

    iput v4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->x2:I

    const/4 v4, 0x1

    if-lez v3, :cond_1

    add-int/lit8 v0, v0, -0x2

    .line 343
    aget v0, v2, v0

    add-int/2addr v0, v4

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->x1:I

    goto :goto_0

    .line 345
    :cond_1
    iput v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->x1:I

    :goto_0
    return v4
.end method

.method public performImplicitSingleStep(DDZ)V
    .locals 7

    .line 358
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->x1:I

    move-object v0, p0

    move-wide v4, p1

    move-wide v2, p3

    move v6, p5

    invoke-virtual/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->createBulge(IDDZ)V

    .line 360
    iget p1, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->x1:I

    :goto_0
    iget p2, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->x2:I

    const/4 p3, 0x1

    sub-int/2addr p2, p3

    const-wide/16 p4, 0x0

    if-ge p1, p2, :cond_1

    iget-wide v1, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->bulge:D

    cmpl-double p2, v1, p4

    if-eqz p2, :cond_1

    .line 361
    invoke-virtual {p0, p1, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->removeBulgeLeft(IZ)V

    .line 362
    iget-wide v1, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->bulge:D

    cmpl-double p2, v1, p4

    if-nez p2, :cond_0

    goto :goto_1

    .line 364
    :cond_0
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->removeBulgeRight(I)V

    add-int/lit8 p1, p1, 0x1

    goto :goto_0

    .line 367
    :cond_1
    :goto_1
    iget-wide p1, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->bulge:D

    cmpl-double p1, p1, p4

    if-eqz p1, :cond_2

    .line 368
    iget p1, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->x2:I

    sub-int/2addr p1, p3

    const/4 p2, 0x0

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->removeBulgeLeft(IZ)V

    .line 370
    :cond_2
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->incrementSteps()V

    return-void
.end method

.method public process()Z
    .locals 1

    const/4 v0, 0x0

    .line 208
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->followScript:Z

    const/4 v0, 0x1

    .line 209
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->findingZeros:Z

    .line 211
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->_process()Z

    move-result v0

    return v0
.end method

.method protected removeBulgeLeft(IZ)V
    .locals 17

    move-object/from16 v0, p0

    .line 489
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->diag:[D

    aget-wide v2, v1, p1

    .line 490
    iget-object v4, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->off:[D

    aget-wide v5, v4, p1

    add-int/lit8 v4, p1, 0x1

    .line 491
    aget-wide v7, v1, v4

    .line 493
    iget-wide v9, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->bulge:D

    invoke-virtual {v0, v2, v3, v9, v10}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->computeRotator(DD)V

    .line 496
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->diag:[D

    move-wide v11, v2

    move v3, v4

    move-wide v9, v5

    iget-wide v4, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->c:D

    mul-double/2addr v11, v4

    move-wide v13, v7

    iget-wide v6, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->s:D

    move-object v8, v1

    iget-wide v1, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->bulge:D

    mul-double/2addr v1, v6

    add-double/2addr v11, v1

    aput-wide v11, v8, p1

    .line 497
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->off:[D

    mul-double v11, v4, v9

    mul-double v15, v6, v13

    add-double/2addr v11, v15

    aput-wide v11, v1, p1

    mul-double v11, v4, v13

    mul-double/2addr v9, v6

    sub-double/2addr v11, v9

    .line 498
    aput-wide v11, v8, v3

    if-eqz p2, :cond_0

    .line 501
    aget-wide v8, v1, v3

    mul-double v10, v6, v8

    .line 502
    iput-wide v10, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->bulge:D

    mul-double/2addr v8, v4

    .line 503
    aput-wide v8, v1, v3

    .line 513
    :cond_0
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->Ut:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    if-eqz v1, :cond_1

    move/from16 v2, p1

    .line 514
    invoke-virtual/range {v0 .. v7}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->updateRotator(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;IIDD)V

    :cond_1
    return-void
.end method

.method protected removeBulgeRight(I)V
    .locals 16

    move-object/from16 v0, p0

    .line 524
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->off:[D

    aget-wide v2, v1, p1

    .line 525
    iget-object v4, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->diag:[D

    add-int/lit8 v5, p1, 0x1

    aget-wide v6, v4, v5

    .line 526
    aget-wide v8, v1, v5

    .line 528
    iget-wide v10, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->bulge:D

    invoke-virtual {v0, v2, v3, v10, v11}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->computeRotator(DD)V

    .line 531
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->off:[D

    move-wide v10, v2

    move v2, v5

    iget-wide v4, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->c:D

    mul-double/2addr v10, v4

    iget-wide v12, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->bulge:D

    iget-wide v14, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->s:D

    mul-double/2addr v12, v14

    add-double/2addr v10, v12

    aput-wide v10, v1, p1

    .line 532
    iget-object v3, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->diag:[D

    mul-double v10, v6, v4

    mul-double v12, v8, v14

    add-double/2addr v10, v12

    aput-wide v10, v3, v2

    neg-double v6, v6

    mul-double/2addr v6, v14

    mul-double/2addr v8, v4

    add-double/2addr v6, v8

    .line 533
    aput-wide v6, v1, v2

    add-int/lit8 v1, p1, 0x2

    .line 535
    aget-wide v6, v3, v1

    mul-double v8, v6, v4

    .line 536
    aput-wide v8, v3, v1

    mul-double/2addr v6, v14

    .line 537
    iput-wide v6, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->bulge:D

    move v3, v1

    .line 546
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->Vt:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    if-eqz v1, :cond_0

    move-wide v6, v14

    .line 547
    invoke-virtual/range {v0 .. v7}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->updateRotator(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;IIDD)V

    :cond_0
    return-void
.end method

.method public resetSteps()V
    .locals 2

    const/4 v0, 0x0

    .line 329
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->steps:I

    .line 330
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->exceptionalThresh:I

    iput v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->nextExceptional:I

    .line 331
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->numExceptional:I

    return-void
.end method

.method public selectWilkinsonShift(D)D
    .locals 20

    move-object/from16 v0, p0

    .line 572
    iget v1, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->x2:I

    iget v2, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->x1:I

    sub-int v2, v1, v2

    const/4 v3, 0x1

    if-le v2, v3, :cond_0

    .line 573
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->diag:[D

    add-int/lit8 v4, v1, -0x1

    aget-wide v4, v2, v4

    div-double v4, v4, p1

    .line 574
    iget-object v6, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->off:[D

    add-int/lit8 v7, v1, -0x2

    aget-wide v7, v6, v7

    div-double v7, v7, p1

    .line 575
    aget-wide v9, v2, v1

    div-double v9, v9, p1

    sub-int/2addr v1, v3

    .line 576
    aget-wide v1, v6, v1

    div-double v1, v1, p1

    mul-double/2addr v7, v7

    mul-double v11, v4, v4

    add-double v14, v7, v11

    mul-double v6, v1, v1

    mul-double/2addr v9, v9

    add-double v18, v6, v9

    .line 581
    iget-object v13, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->eigenSmall:Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/eig/EigenvalueSmall_F64;

    mul-double v16, v1, v4

    invoke-virtual/range {v13 .. v19}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/eig/EigenvalueSmall_F64;->symm2x2_fast(DDD)V

    goto :goto_0

    .line 583
    :cond_0
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->diag:[D

    add-int/lit8 v3, v1, -0x1

    aget-wide v3, v2, v3

    div-double v3, v3, p1

    .line 584
    iget-object v5, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->off:[D

    add-int/lit8 v6, v1, -0x1

    aget-wide v6, v5, v6

    div-double v6, v6, p1

    .line 585
    aget-wide v1, v2, v1

    div-double v1, v1, p1

    mul-double v9, v3, v3

    mul-double v11, v6, v6

    mul-double/2addr v1, v1

    add-double v13, v11, v1

    .line 590
    iget-object v8, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->eigenSmall:Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/eig/EigenvalueSmall_F64;

    mul-double v11, v3, v6

    invoke-virtual/range {v8 .. v14}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/eig/EigenvalueSmall_F64;->symm2x2_fast(DDD)V

    move-wide/from16 v18, v13

    .line 594
    :goto_0
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->eigenSmall:Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/eig/EigenvalueSmall_F64;

    iget-object v1, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/eig/EigenvalueSmall_F64;->value0:Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;

    iget-wide v1, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;->real:D

    sub-double v1, v1, v18

    invoke-static {v1, v2}, Ljava/lang/Math;->abs(D)D

    move-result-wide v1

    .line 595
    iget-object v3, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->eigenSmall:Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/eig/EigenvalueSmall_F64;

    iget-object v3, v3, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/eig/EigenvalueSmall_F64;->value1:Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;

    iget-wide v3, v3, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;->real:D

    sub-double v3, v3, v18

    invoke-static {v3, v4}, Ljava/lang/Math;->abs(D)D

    move-result-wide v3

    cmpg-double v1, v1, v3

    if-gez v1, :cond_1

    .line 597
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->eigenSmall:Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/eig/EigenvalueSmall_F64;

    iget-object v1, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/eig/EigenvalueSmall_F64;->value0:Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;

    :goto_1
    iget-wide v1, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;->real:D

    return-wide v1

    :cond_1
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->eigenSmall:Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/eig/EigenvalueSmall_F64;

    iget-object v1, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/eig/EigenvalueSmall_F64;->value1:Lcom/scanflow/datacapture/barinternal/org/ejml/data/Complex_F64;

    goto :goto_1
.end method

.method public setFastValues(Z)V
    .locals 0

    .line 795
    iput-boolean p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->fastValues:Z

    return-void
.end method

.method public setMatrix(II[D[D)V
    .locals 6

    .line 147
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->initParam(II)V

    .line 148
    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->diag:[D

    .line 149
    iput-object p4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->off:[D

    .line 152
    array-length p1, p3

    if-gtz p1, :cond_0

    const-wide/16 p1, 0x0

    .line 153
    iput-wide p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->maxValue:D

    return-void

    :cond_0
    const/4 p1, 0x0

    .line 157
    aget-wide p1, p3, p1

    invoke-static {p1, p2}, Ljava/lang/Math;->abs(D)D

    move-result-wide p1

    iput-wide p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->maxValue:D

    const/4 p1, 0x1

    .line 158
    :goto_0
    iget p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->N:I

    if-ge p1, p2, :cond_3

    .line 159
    aget-wide v0, p3, p1

    invoke-static {v0, v1}, Ljava/lang/Math;->abs(D)D

    move-result-wide v0

    add-int/lit8 p2, p1, -0x1

    .line 160
    aget-wide v2, p4, p2

    invoke-static {v2, v3}, Ljava/lang/Math;->abs(D)D

    move-result-wide v2

    .line 162
    iget-wide v4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->maxValue:D

    cmpl-double p2, v0, v4

    if-lez p2, :cond_1

    .line 163
    invoke-static {v0, v1}, Ljava/lang/Math;->abs(D)D

    move-result-wide v0

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->maxValue:D

    .line 165
    :cond_1
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->maxValue:D

    cmpl-double p2, v2, v0

    if-lez p2, :cond_2

    .line 166
    invoke-static {v2, v3}, Ljava/lang/Math;->abs(D)D

    move-result-wide v0

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->maxValue:D

    :cond_2
    add-int/lit8 p1, p1, 0x1

    goto :goto_0

    :cond_3
    return-void
.end method

.method public setSubmatrix(II)V
    .locals 0

    .line 557
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->x1:I

    .line 558
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->x2:I

    return-void
.end method

.method public setUt(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)V
    .locals 0

    .line 132
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->Ut:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    return-void
.end method

.method public setVt(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)V
    .locals 0

    .line 140
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/decomposition/svd/implicitqr/SvdImplicitQrAlgorithm_DDRM;->Vt:Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    return-void
.end method

.method protected updateRotator(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;IIDD)V
    .locals 12

    move-wide/from16 v0, p6

    .line 385
    iget v2, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    mul-int/2addr p2, v2

    mul-int v3, p3, v2

    add-int/2addr v2, p2

    :goto_0
    if-eq p2, v2, :cond_0

    .line 399
    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->get(I)D

    move-result-wide v4

    .line 400
    invoke-virtual {p1, v3}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->get(I)D

    move-result-wide v6

    mul-double v8, p4, v4

    mul-double v10, v0, v6

    add-double/2addr v8, v10

    .line 401
    invoke-virtual {p1, p2, v8, v9}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->set(ID)D

    neg-double v8, v0

    mul-double/2addr v8, v4

    mul-double v6, v6, p4

    add-double/2addr v8, v6

    .line 402
    invoke-virtual {p1, v3, v8, v9}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->set(ID)D

    add-int/lit8 p2, p2, 0x1

    add-int/lit8 v3, v3, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method
