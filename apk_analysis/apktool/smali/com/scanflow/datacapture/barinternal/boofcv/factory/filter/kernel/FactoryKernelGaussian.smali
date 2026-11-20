.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/kernel/FactoryKernelGaussian;
.super Ljava/lang/Object;
.source "FactoryKernelGaussian.java"


# static fields
.field public static MIN_FRAC:F = 0.01f

.field public static MIN_FRACD:D = 0.01


# direct methods
.method static constructor <clinit>()V
    .locals 0

    .line 41
    return-void
.end method

.method public static gaussian(IZIDI)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;
    .locals 4

    const/4 v0, 0x0

    if-gtz p5, :cond_0

    .line 119
    invoke-static {p3, p4, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/kernel/FactoryKernelGaussian;->radiusForSigma(DI)I

    move-result p5

    goto :goto_0

    :cond_0
    const-wide/16 v1, 0x0

    cmpg-double v1, p3, v1

    if-gtz v1, :cond_1

    int-to-double p3, p5

    .line 121
    invoke-static {p3, p4, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/kernel/FactoryKernelGaussian;->sigmaForRadius(DI)D

    move-result-wide p3

    :cond_1
    :goto_0
    const/4 v0, 0x2

    const/16 v1, 0x40

    const/16 v2, 0x20

    const/4 v3, 0x1

    if-ne p0, v0, :cond_6

    if-ne p2, v2, :cond_3

    .line 125
    invoke-static {p3, p4, p5, v3, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/kernel/FactoryKernelGaussian;->gaussian2D_F32(DIZZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel2D_F32;

    move-result-object p0

    if-eqz p1, :cond_2

    return-object p0

    .line 128
    :cond_2
    sget p1, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/kernel/FactoryKernelGaussian;->MIN_FRAC:F

    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/kernel/KernelMath;->convert(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel2D_F32;F)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel2D_S32;

    move-result-object p0

    return-object p0

    :cond_3
    if-ne p2, v1, :cond_5

    .line 130
    invoke-static {p3, p4, p5, v3, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/kernel/FactoryKernelGaussian;->gaussian2D_F64(DIZZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel2D_F64;

    move-result-object p0

    if-eqz p1, :cond_4

    return-object p0

    .line 134
    :cond_4
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "64bit int kernels supported"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0

    .line 136
    :cond_5
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Bits must be 32 or 64"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0

    :cond_6
    if-ne p0, v3, :cond_b

    if-ne p2, v2, :cond_8

    .line 140
    invoke-static {p3, p4, p5, v3, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/kernel/FactoryKernelGaussian;->gaussian1D_F32(DIZZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;

    move-result-object p0

    if-eqz p1, :cond_7

    return-object p0

    .line 143
    :cond_7
    sget p1, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/kernel/FactoryKernelGaussian;->MIN_FRAC:F

    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/kernel/KernelMath;->convert(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;F)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;

    move-result-object p0

    return-object p0

    :cond_8
    if-ne p2, v1, :cond_a

    .line 145
    invoke-static {p3, p4, p5, v3, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/kernel/FactoryKernelGaussian;->gaussian1D_F64(DIZZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F64;

    move-result-object p0

    if-eqz p1, :cond_9

    return-object p0

    .line 148
    :cond_9
    sget-wide p1, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/kernel/FactoryKernelGaussian;->MIN_FRACD:D

    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/kernel/KernelMath;->convert(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F64;D)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;

    move-result-object p0

    return-object p0

    .line 150
    :cond_a
    new-instance p0, Ljava/lang/IllegalArgumentException;

    new-instance p1, Ljava/lang/StringBuilder;

    invoke-direct {p1}, Ljava/lang/StringBuilder;-><init>()V

    const-string p3, "Bits must be 32 or 64 not "

    invoke-virtual {p1, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p1, p2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {p1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0

    .line 153
    :cond_b
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "DOF not supported"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method public static gaussian(Ljava/lang/Class;DI)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;
    .locals 7

    .line 52
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;

    if-ne v0, p0, :cond_0

    const/4 v2, 0x1

    const/16 v3, 0x20

    const/4 v1, 0x1

    move-wide v4, p1

    move v6, p3

    .line 53
    invoke-static/range {v1 .. v6}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/kernel/FactoryKernelGaussian;->gaussian(IZIDI)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;

    move-result-object p0

    return-object p0

    :cond_0
    move-wide v3, p1

    move v5, p3

    .line 54
    const-class p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F64;

    if-ne p1, p0, :cond_1

    const/4 v1, 0x1

    const/16 v2, 0x40

    const/4 v0, 0x1

    .line 55
    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/kernel/FactoryKernelGaussian;->gaussian(IZIDI)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;

    move-result-object p0

    return-object p0

    .line 56
    :cond_1
    const-class p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;

    if-ne p1, p0, :cond_2

    const/4 v1, 0x0

    const/16 v2, 0x20

    const/4 v0, 0x1

    .line 57
    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/kernel/FactoryKernelGaussian;->gaussian(IZIDI)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;

    move-result-object p0

    return-object p0

    .line 58
    :cond_2
    const-class p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel2D_S32;

    if-ne p1, p0, :cond_3

    const/4 v1, 0x0

    const/16 v2, 0x20

    const/4 v0, 0x2

    .line 59
    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/kernel/FactoryKernelGaussian;->gaussian(IZIDI)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;

    move-result-object p0

    return-object p0

    .line 60
    :cond_3
    const-class p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel2D_F32;

    if-ne p1, p0, :cond_4

    const/4 v1, 0x1

    const/16 v2, 0x20

    const/4 v0, 0x2

    .line 61
    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/kernel/FactoryKernelGaussian;->gaussian(IZIDI)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;

    move-result-object p0

    return-object p0

    .line 62
    :cond_4
    const-class p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel2D_F64;

    if-ne p1, p0, :cond_5

    const/4 v1, 0x1

    const/16 v2, 0x40

    const/4 v0, 0x2

    .line 63
    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/kernel/FactoryKernelGaussian;->gaussian(IZIDI)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;

    move-result-object p0

    return-object p0

    .line 65
    :cond_5
    new-instance p1, Ljava/lang/RuntimeException;

    invoke-virtual {p0}, Ljava/lang/Class;->getSimpleName()Ljava/lang/String;

    move-result-object p0

    new-instance p2, Ljava/lang/StringBuilder;

    invoke-direct {p2}, Ljava/lang/StringBuilder;-><init>()V

    const-string p3, "Unknown kernel type. "

    invoke-virtual {p2, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    invoke-direct {p1, p0}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method protected static gaussian1D_F32(DIZZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;
    .locals 10

    const/4 v0, 0x0

    if-eqz p3, :cond_0

    .line 215
    new-instance p3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;

    mul-int/lit8 v1, p2, 0x2

    add-int/lit8 v1, v1, 0x1

    invoke-direct {p3, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;-><init>(I)V

    move v1, p2

    :goto_0
    neg-int v2, p2

    if-lt v1, v2, :cond_1

    .line 218
    iget-object v2, p3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->data:[F

    add-int/lit8 v3, v0, 0x1

    const-wide/16 v4, 0x0

    int-to-double v8, v1

    move-wide v6, p0

    invoke-static/range {v4 .. v9}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/stats/UtilGaussian;->computePDF(DDD)D

    move-result-wide p0

    double-to-float p0, p0

    aput p0, v2, v0

    add-int/lit8 v1, v1, -0x1

    move v0, v3

    move-wide p0, v6

    goto :goto_0

    :cond_0
    move-wide v6, p0

    .line 221
    new-instance p3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;

    mul-int/lit8 p0, p2, 0x2

    invoke-direct {p3, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;-><init>(I)V

    move p0, p2

    :goto_1
    neg-int p1, p2

    if-le p0, p1, :cond_1

    .line 224
    iget-object p1, p3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->data:[F

    add-int/lit8 v1, v0, 0x1

    int-to-double v2, p0

    const-wide/high16 v4, 0x3fe0000000000000L    # 0.5

    sub-double v8, v2, v4

    const-wide/16 v4, 0x0

    invoke-static/range {v4 .. v9}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/stats/UtilGaussian;->computePDF(DDD)D

    move-result-wide v2

    double-to-float v2, v2

    aput v2, p1, v0

    add-int/lit8 p0, p0, -0x1

    move v0, v1

    goto :goto_1

    :cond_1
    if-eqz p4, :cond_2

    .line 228
    invoke-static {p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/kernel/KernelMath;->normalizeSumToOne(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;)V

    :cond_2
    return-object p3
.end method

.method protected static gaussian1D_F64(DIZZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F64;
    .locals 10

    const/4 v0, 0x0

    if-eqz p3, :cond_0

    .line 237
    new-instance p3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F64;

    mul-int/lit8 v1, p2, 0x2

    add-int/lit8 v1, v1, 0x1

    invoke-direct {p3, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F64;-><init>(I)V

    move v1, p2

    :goto_0
    neg-int v2, p2

    if-lt v1, v2, :cond_1

    .line 240
    iget-object v2, p3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F64;->data:[D

    add-int/lit8 v3, v0, 0x1

    const-wide/16 v4, 0x0

    int-to-double v8, v1

    move-wide v6, p0

    invoke-static/range {v4 .. v9}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/stats/UtilGaussian;->computePDF(DDD)D

    move-result-wide p0

    aput-wide p0, v2, v0

    add-int/lit8 v1, v1, -0x1

    move v0, v3

    move-wide p0, v6

    goto :goto_0

    :cond_0
    move-wide v6, p0

    .line 243
    new-instance p3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F64;

    mul-int/lit8 p0, p2, 0x2

    invoke-direct {p3, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F64;-><init>(I)V

    move p0, p2

    :goto_1
    neg-int p1, p2

    if-le p0, p1, :cond_1

    .line 246
    iget-object p1, p3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F64;->data:[D

    add-int/lit8 v1, v0, 0x1

    int-to-double v2, p0

    const-wide/high16 v4, 0x3fe0000000000000L    # 0.5

    sub-double v8, v2, v4

    const-wide/16 v4, 0x0

    invoke-static/range {v4 .. v9}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/stats/UtilGaussian;->computePDF(DDD)D

    move-result-wide v2

    aput-wide v2, p1, v0

    add-int/lit8 p0, p0, -0x1

    move v0, v1

    goto :goto_1

    :cond_1
    if-eqz p4, :cond_2

    .line 250
    invoke-static {p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/kernel/KernelMath;->normalizeSumToOne(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F64;)V

    :cond_2
    return-object p3
.end method

.method public static gaussian2D_F32(DIZZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel2D_F32;
    .locals 1

    const/4 v0, 0x0

    .line 265
    invoke-static {p0, p1, p2, p3, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/kernel/FactoryKernelGaussian;->gaussian1D_F32(DIZZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;

    move-result-object p0

    .line 266
    invoke-static {p0, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/kernel/KernelMath;->convolve2D(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel2D_F32;

    move-result-object p0

    if-eqz p4, :cond_0

    .line 269
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/kernel/KernelMath;->normalizeSumToOne(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel2D_F32;)V

    :cond_0
    return-object p0
.end method

.method public static gaussian2D_F64(DIZZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel2D_F64;
    .locals 1

    const/4 v0, 0x0

    .line 293
    invoke-static {p0, p1, p2, p3, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/filter/kernel/FactoryKernelGaussian;->gaussian1D_F64(DIZZ)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F64;

    move-result-object p0

    .line 294
    invoke-static {p0, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/kernel/KernelMath;->convolve2D(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F64;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel2D_F64;

    move-result-object p0

    if-eqz p4, :cond_0

    .line 297
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/kernel/KernelMath;->normalizeSumToOne(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel2D_F64;)V

    :cond_0
    return-object p0
.end method

.method public static radiusForSigma(DI)I
    .locals 4

    const-wide/16 v0, 0x0

    cmpg-double v0, p0, v0

    if-lez v0, :cond_0

    const-wide v0, 0x3fe999999999999aL    # 0.8

    int-to-double v2, p2

    mul-double/2addr v2, v0

    const-wide/high16 v0, 0x4014000000000000L    # 5.0

    add-double/2addr v2, v0

    mul-double/2addr v2, p0

    const-wide/high16 p0, 0x3ff0000000000000L    # 1.0

    sub-double/2addr v2, p0

    const-wide/high16 p0, 0x4000000000000000L    # 2.0

    div-double/2addr v2, p0

    .line 403
    invoke-static {v2, v3}, Ljava/lang/Math;->ceil(D)D

    move-result-wide p0

    double-to-int p0, p0

    return p0

    .line 401
    :cond_0
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Sigma must be > 0"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method public static sigmaForRadius(DI)D
    .locals 4

    const-wide/16 v0, 0x0

    cmpg-double v0, p0, v0

    if-lez v0, :cond_0

    const-wide/high16 v0, 0x4000000000000000L    # 2.0

    mul-double/2addr p0, v0

    const-wide/high16 v0, 0x3ff0000000000000L    # 1.0

    add-double/2addr p0, v0

    const-wide v0, 0x3fe999999999999aL    # 0.8

    int-to-double v2, p2

    mul-double/2addr v2, v0

    const-wide/high16 v0, 0x4014000000000000L    # 5.0

    add-double/2addr v2, v0

    div-double/2addr p0, v2

    return-wide p0

    .line 385
    :cond_0
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Radius must be > 0"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method
