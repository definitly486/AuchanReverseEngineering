.class public abstract Lcom/scanflow/datacapture/barinternal/org/ejml/concurrency/EjmlConcurrency;
.super Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;
.source "EjmlConcurrency.java"


# static fields
.field public static ELEMENT_THRESHOLD:I = 0xc350

.field public static USE_CONCURRENT:Z = true


# direct methods
.method static constructor <clinit>()V
    .locals 0

    .line 34
    return-void
.end method

.method public static useConcurrent(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Z
    .locals 2

    .line 69
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/org/ejml/concurrency/EjmlConcurrency;->USE_CONCURRENT:Z

    const/4 v1, 0x0

    if-nez v0, :cond_0

    return v1

    .line 72
    :cond_0
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v0

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result p0

    mul-int/2addr v0, p0

    sget p0, Lcom/scanflow/datacapture/barinternal/org/ejml/concurrency/EjmlConcurrency;->ELEMENT_THRESHOLD:I

    if-le v0, p0, :cond_1

    const/4 p0, 0x1

    return p0

    :cond_1
    return v1
.end method

.method public static useConcurrent(Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixSparse;)Z
    .locals 2

    .line 58
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/org/ejml/concurrency/EjmlConcurrency;->USE_CONCURRENT:Z

    const/4 v1, 0x0

    if-nez v0, :cond_0

    return v1

    .line 61
    :cond_0
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixSparse;->getNonZeroLength()I

    move-result p0

    sget v0, Lcom/scanflow/datacapture/barinternal/org/ejml/concurrency/EjmlConcurrency;->ELEMENT_THRESHOLD:I

    if-le p0, v0, :cond_1

    const/4 p0, 0x1

    return p0

    :cond_1
    return v1
.end method
