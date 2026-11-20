.class public abstract Lcom/scanflow/datacapture/barinternal/kotlin/random/AbstractPlatformRandom;
.super Lcom/scanflow/datacapture/barinternal/kotlin/random/Random;
.source "PlatformRandom.kt"


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 35
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/random/Random;-><init>()V

    return-void
.end method


# virtual methods
.method public abstract getImpl()Ljava/util/Random;
.end method

.method public nextInt(I)I
    .locals 1

    .line 42
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/random/AbstractPlatformRandom;->getImpl()Ljava/util/Random;

    move-result-object v0

    invoke-virtual {v0, p1}, Ljava/util/Random;->nextInt(I)I

    move-result p1

    return p1
.end method
