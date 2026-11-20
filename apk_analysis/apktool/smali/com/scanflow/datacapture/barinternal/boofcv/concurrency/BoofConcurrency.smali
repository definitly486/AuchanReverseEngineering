.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;
.super Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;
.source "BoofConcurrency.java"


# static fields
.field public static SMALL_IMAGE:I = 0x2710

.field public static USE_CONCURRENT:Z = true


# direct methods
.method static constructor <clinit>()V
    .locals 0

    .line 33
    return-void
.end method

.method public static isUseConcurrent()Z
    .locals 1

    .line 49
    sget-boolean v0, Lcom/scanflow/datacapture/barinternal/boofcv/concurrency/BoofConcurrency;->USE_CONCURRENT:Z

    return v0
.end method
