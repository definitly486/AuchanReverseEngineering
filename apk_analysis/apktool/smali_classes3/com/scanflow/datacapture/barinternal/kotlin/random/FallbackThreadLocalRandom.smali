.class public final Lcom/scanflow/datacapture/barinternal/kotlin/random/FallbackThreadLocalRandom;
.super Lcom/scanflow/datacapture/barinternal/kotlin/random/AbstractPlatformRandom;
.source "PlatformRandom.kt"


# instance fields
.field private final implStorage:Lcom/scanflow/datacapture/barinternal/kotlin/random/FallbackThreadLocalRandom$implStorage$1;


# direct methods
.method public constructor <init>()V
    .locals 1

    .line 51
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/random/AbstractPlatformRandom;-><init>()V

    .line 52
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/random/FallbackThreadLocalRandom$implStorage$1;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/random/FallbackThreadLocalRandom$implStorage$1;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/random/FallbackThreadLocalRandom;->implStorage:Lcom/scanflow/datacapture/barinternal/kotlin/random/FallbackThreadLocalRandom$implStorage$1;

    return-void
.end method


# virtual methods
.method public getImpl()Ljava/util/Random;
    .locals 2

    .line 57
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/random/FallbackThreadLocalRandom;->implStorage:Lcom/scanflow/datacapture/barinternal/kotlin/random/FallbackThreadLocalRandom$implStorage$1;

    invoke-virtual {v0}, Ljava/lang/ThreadLocal;->get()Ljava/lang/Object;

    move-result-object v0

    const-string v1, "get(...)"

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast v0, Ljava/util/Random;

    return-object v0
.end method
