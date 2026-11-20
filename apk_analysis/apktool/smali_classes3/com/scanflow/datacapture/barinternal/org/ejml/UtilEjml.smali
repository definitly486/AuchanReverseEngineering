.class public abstract Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;
.super Ljava/lang/Object;
.source "UtilEjml.java"


# static fields
.field public static EPS:D

.field public static F_EPS:F

.field public static F_PI:F

.field public static F_PI2:F

.field public static F_PId2:F

.field public static PI:D

.field public static PI2:D

.field public static PId2:D

.field public static TESTP_F32:F

.field public static TESTP_F64:D

.field public static TEST_F32:F

.field public static TEST_F32_SQ:F

.field public static TEST_F64:D

.field public static TEST_F64_SQ:D

.field public static final ZERO_LENGTH_F32:[F

.field public static final ZERO_LENGTH_F64:[D

.field public static final ZERO_LENGTH_I32:[I

.field public static maxInverseSize:I


# direct methods
.method static constructor <clinit>()V
    .locals 4

    const-wide/high16 v0, -0x3fb6000000000000L    # -52.0

    const-wide/high16 v2, 0x4000000000000000L    # 2.0

    .line 42
    invoke-static {v2, v3, v0, v1}, Ljava/lang/Math;->pow(DD)D

    move-result-wide v0

    sput-wide v0, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->EPS:D

    const-wide/high16 v0, -0x3fcb000000000000L    # -21.0

    .line 43
    invoke-static {v2, v3, v0, v1}, Ljava/lang/Math;->pow(DD)D

    move-result-wide v0

    double-to-float v0, v0

    sput v0, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->F_EPS:F

    const-wide v0, 0x400921fb54442d18L    # Math.PI

    .line 45
    sput-wide v0, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->PI:D

    const-wide v0, 0x401921fb54442d18L    # 6.283185307179586

    .line 46
    sput-wide v0, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->PI2:D

    const-wide v0, 0x3ff921fb54442d18L    # 1.5707963267948966

    .line 47
    sput-wide v0, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->PId2:D

    const v0, 0x40490fdb    # (float)Math.PI

    .line 49
    sput v0, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->F_PI:F

    const v0, 0x40c90fdb

    .line 50
    sput v0, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->F_PI2:F

    const v0, 0x3fc90fdb

    .line 51
    sput v0, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->F_PId2:F

    const v0, 0x3a03126f    # 5.0E-4f

    .line 54
    sput v0, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->TEST_F32:F

    const-wide v1, 0x3e45798ee2308c3aL    # 1.0E-8

    .line 55
    sput-wide v1, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->TEST_F64:D

    const v1, 0x358637bd    # 1.0E-6f

    .line 56
    sput v1, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->TESTP_F32:F

    const-wide v1, 0x3d719799812dea11L    # 1.0E-12

    .line 57
    sput-wide v1, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->TESTP_F64:D

    float-to-double v0, v0

    .line 58
    invoke-static {v0, v1}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide v0

    double-to-float v0, v0

    sput v0, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->TEST_F32_SQ:F

    .line 59
    sget-wide v0, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->TEST_F64:D

    invoke-static {v0, v1}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide v0

    sput-wide v0, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->TEST_F64_SQ:D

    const/4 v0, 0x5

    .line 62
    sput v0, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->maxInverseSize:I

    const/4 v0, 0x0

    .line 64
    new-array v1, v0, [I

    sput-object v1, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->ZERO_LENGTH_I32:[I

    .line 65
    new-array v1, v0, [F

    sput-object v1, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->ZERO_LENGTH_F32:[F

    .line 66
    new-array v0, v0, [D

    sput-object v0, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->ZERO_LENGTH_F64:[D

    return-void
.end method

.method public static adjust(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DGrowArray;I)[D
    .locals 0

    if-nez p0, :cond_0

    .line 618
    new-instance p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DGrowArray;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DGrowArray;-><init>()V

    .line 619
    :cond_0
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DGrowArray;->reshape(I)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DGrowArray;

    .line 620
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DGrowArray;->data:[D

    return-object p0
.end method

.method public static adjust(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FGrowArray;I)[F
    .locals 0

    if-nez p0, :cond_0

    .line 627
    new-instance p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FGrowArray;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FGrowArray;-><init>()V

    .line 628
    :cond_0
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FGrowArray;->reshape(I)Lcom/scanflow/datacapture/barinternal/org/ejml/data/FGrowArray;

    .line 629
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FGrowArray;->data:[F

    return-object p0
.end method

.method public static adjust(Lcom/scanflow/datacapture/barinternal/org/ejml/data/IGrowArray;I)[I
    .locals 0

    if-nez p0, :cond_0

    .line 593
    new-instance p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/IGrowArray;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/IGrowArray;-><init>()V

    .line 594
    :cond_0
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/IGrowArray;->reshape(I)V

    .line 595
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/IGrowArray;->data:[I

    return-object p0
.end method

.method public static adjust(Lcom/scanflow/datacapture/barinternal/org/ejml/data/IGrowArray;II)[I
    .locals 0

    .line 599
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->adjust(Lcom/scanflow/datacapture/barinternal/org/ejml/data/IGrowArray;I)[I

    move-result-object p0

    const/4 p1, 0x0

    .line 600
    invoke-static {p0, p1, p2, p1}, Ljava/util/Arrays;->fill([IIII)V

    return-object p0
.end method

.method public static assertEq(II)V
    .locals 1

    .line 696
    const-string v0, ""

    invoke-static {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->assertEq(IILjava/lang/String;)V

    return-void
.end method

.method public static assertEq(IILjava/lang/String;)V
    .locals 2

    if-ne p0, p1, :cond_0

    return-void

    .line 704
    :cond_0
    new-instance v0, Ljava/lang/IllegalArgumentException;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, p0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p0, " != "

    invoke-virtual {v1, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p0, " "

    invoke-virtual {v1, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    invoke-direct {v0, p0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method public static assertShape(IILjava/lang/String;)V
    .locals 2

    if-ne p0, p1, :cond_0

    return-void

    .line 728
    :cond_0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, p0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p0, " != "

    invoke-virtual {v1, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p0, " "

    invoke-virtual {v1, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/MatrixDimensionException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method public static assertTrue(ZLjava/lang/String;)V
    .locals 0

    if-eqz p0, :cond_0

    return-void

    .line 712
    :cond_0
    new-instance p0, Ljava/lang/IllegalArgumentException;

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method public static checkSameInstance(Ljava/lang/Object;Ljava/lang/Object;)V
    .locals 0

    if-eq p0, p1, :cond_0

    return-void

    .line 70
    :cond_0
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Can\'t pass in the same instance"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method public static checkTooLarge(II)V
    .locals 4

    mul-int v0, p0, p1

    int-to-long v0, v0

    int-to-long v2, p0

    int-to-long p0, p1

    mul-long/2addr v2, p0

    cmp-long p0, v0, v2

    if-nez p0, :cond_0

    return-void

    .line 275
    :cond_0
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Matrix size exceeds the size of an integer"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method public static checkTooLargeComplex(II)V
    .locals 4

    mul-int/lit8 v0, p0, 0x2

    mul-int/2addr v0, p1

    int-to-long v0, v0

    int-to-long v2, p0

    int-to-long p0, p1

    mul-long/2addr v2, p0

    const-wide/16 p0, 0x2

    mul-long/2addr v2, p0

    cmp-long p0, v0, v2

    if-nez p0, :cond_0

    return-void

    .line 280
    :cond_0
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Matrix size exceeds the size of an integer"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method public static checkValidMatrixShape(II)V
    .locals 2

    if-ltz p0, :cond_1

    if-ltz p1, :cond_0

    .line 258
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->checkTooLarge(II)V

    return-void

    .line 257
    :cond_0
    new-instance p0, Ljava/lang/IllegalArgumentException;

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "Cols are negative: value="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0

    .line 255
    :cond_1
    new-instance p1, Ljava/lang/IllegalArgumentException;

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "Rows are negative: value="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, p0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    invoke-direct {p1, p0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public static checkValidMatrixShapeComplex(II)V
    .locals 2

    if-ltz p0, :cond_1

    if-ltz p1, :cond_0

    .line 270
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->checkTooLargeComplex(II)V

    return-void

    .line 269
    :cond_0
    new-instance p0, Ljava/lang/IllegalArgumentException;

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "Cols are negative: value="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0

    .line 267
    :cond_1
    new-instance p1, Ljava/lang/IllegalArgumentException;

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "Rows are negative: value="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, p0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    invoke-direct {p1, p0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public static fancyString(DLjava/text/DecimalFormat;II)Ljava/lang/String;
    .locals 6

    const/4 v3, 0x1

    move-wide v0, p0

    move-object v2, p2

    move v4, p3

    move v5, p4

    .line 553
    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->fancyString(DLjava/text/DecimalFormat;ZII)Ljava/lang/String;

    move-result-object p0

    return-object p0
.end method

.method public static fancyString(DLjava/text/DecimalFormat;ZII)Ljava/lang/String;
    .locals 6

    .line 561
    invoke-static {p0, p1}, Ljava/lang/Double;->doubleToRawLongBits(D)J

    move-result-wide v0

    const-wide/16 v2, 0x0

    cmp-long v0, v0, v2

    const/4 v1, 0x1

    if-gez v0, :cond_0

    move v0, v1

    goto :goto_0

    :cond_0
    const/4 v0, 0x0

    :goto_0
    const-wide/16 v2, 0x0

    cmpl-double v2, p0, v2

    if-nez v2, :cond_3

    if-eqz v0, :cond_1

    .line 564
    const-string p0, "-0"

    return-object p0

    :cond_1
    if-eqz p3, :cond_2

    const-string p0, " 0"

    return-object p0

    :cond_2
    const-string p0, "0"

    return-object p0

    :cond_3
    add-int/lit8 v2, p4, -0x1

    .line 567
    const-string v3, ""

    if-eqz v0, :cond_4

    goto :goto_1

    :cond_4
    if-eqz p3, :cond_5

    const-string v3, " "

    .line 568
    :cond_5
    :goto_1
    invoke-static {p0, p1}, Ljava/lang/Math;->abs(D)D

    move-result-wide v4

    .line 569
    invoke-static {v4, v5}, Ljava/lang/Math;->log10(D)D

    move-result-wide v4

    invoke-static {v4, v5}, Ljava/lang/Math;->floor(D)D

    move-result-wide v4

    double-to-int p3, v4

    if-ltz p3, :cond_6

    if-ge p3, v2, :cond_6

    add-int/lit8 p4, p4, -0x3

    sub-int/2addr p4, p3

    .line 571
    invoke-virtual {p2, p4}, Ljava/text/DecimalFormat;->setMaximumFractionDigits(I)V

    .line 572
    invoke-virtual {p2, p0, p1}, Ljava/text/NumberFormat;->format(D)Ljava/lang/String;

    move-result-object p0

    new-instance p1, Ljava/lang/StringBuilder;

    invoke-direct {p1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {p1, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p1, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    return-object p0

    :cond_6
    if-gez p3, :cond_7

    add-int v0, v2, p3

    if-le v0, p5, :cond_7

    add-int/lit8 p4, p4, -0x2

    .line 574
    invoke-virtual {p2, p4}, Ljava/text/DecimalFormat;->setMaximumFractionDigits(I)V

    .line 575
    invoke-virtual {p2, p0, p1}, Ljava/text/NumberFormat;->format(D)Ljava/lang/String;

    move-result-object p0

    new-instance p1, Ljava/lang/StringBuilder;

    invoke-direct {p1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {p1, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p1, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    return-object p0

    .line 577
    :cond_7
    invoke-static {p3}, Ljava/lang/Math;->abs(I)I

    move-result p2

    int-to-double p2, p2

    invoke-static {p2, p3}, Ljava/lang/Math;->log10(D)D

    move-result-wide p2

    double-to-int p2, p2

    add-int/2addr p2, v1

    sub-int/2addr v2, p5

    sub-int/2addr v2, p2

    .line 579
    invoke-static {p5, v2}, Ljava/lang/Math;->min(II)I

    move-result p2

    if-lez p2, :cond_8

    .line 581
    new-instance p3, Ljava/lang/StringBuilder;

    invoke-direct {p3}, Ljava/lang/StringBuilder;-><init>()V

    const-string p4, "%."

    invoke-virtual {p3, p4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p3, p2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p2, "E"

    invoke-virtual {p3, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p2

    invoke-static {p0, p1}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object p0

    filled-new-array {p0}, [Ljava/lang/Object;

    move-result-object p0

    invoke-static {p2, p0}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object p0

    new-instance p1, Ljava/lang/StringBuilder;

    invoke-direct {p1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {p1, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p1, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    return-object p0

    .line 583
    :cond_8
    invoke-static {p0, p1}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object p0

    filled-new-array {p0}, [Ljava/lang/Object;

    move-result-object p0

    const-string p1, "%.0E"

    invoke-static {p1, p0}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object p0

    new-instance p1, Ljava/lang/StringBuilder;

    invoke-direct {p1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {p1, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p1, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    return-object p0
.end method

.method public static reshapeOrDeclare(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;II)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;
    .locals 1

    if-nez p0, :cond_0

    .line 83
    new-instance p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;-><init>(II)V

    return-object p0

    .line 84
    :cond_0
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    if-ne v0, p1, :cond_2

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    if-eq v0, p2, :cond_1

    goto :goto_0

    :cond_1
    return-object p0

    .line 85
    :cond_2
    :goto_0
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->reshape(II)V

    return-object p0
.end method

.method public static reshapeOrDeclare(Lcom/scanflow/datacapture/barinternal/org/ejml/data/ReshapeMatrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ReshapeMatrix;II)Lcom/scanflow/datacapture/barinternal/org/ejml/data/ReshapeMatrix;
    .locals 0

    if-nez p0, :cond_0

    .line 185
    invoke-interface {p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->create(II)Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ReshapeMatrix;

    return-object p0

    .line 186
    :cond_0
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result p1

    if-ne p1, p2, :cond_2

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result p1

    if-eq p1, p3, :cond_1

    goto :goto_0

    :cond_1
    return-object p0

    .line 187
    :cond_2
    :goto_0
    invoke-interface {p0, p2, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/ReshapeMatrix;->reshape(II)V

    return-object p0
.end method

.method public static stringShapes(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Ljava/lang/String;
    .locals 4

    .line 520
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v0

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result p0

    .line 521
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v1

    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result p1

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "( "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string v0, "x"

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, p0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p0, " ) ( "

    invoke-virtual {v2, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p0, " )"

    invoke-virtual {v2, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    return-object p0
.end method
