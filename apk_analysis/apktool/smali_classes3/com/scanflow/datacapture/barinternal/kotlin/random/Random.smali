.class public abstract Lcom/scanflow/datacapture/barinternal/kotlin/random/Random;
.super Ljava/lang/Object;
.source "Random.kt"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/kotlin/random/Random$Default;
    }
.end annotation


# static fields
.field public static final Default:Lcom/scanflow/datacapture/barinternal/kotlin/random/Random$Default;

.field private static final defaultRandom:Lcom/scanflow/datacapture/barinternal/kotlin/random/Random;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/random/Random$Default;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/random/Random$Default;-><init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/random/Random;->Default:Lcom/scanflow/datacapture/barinternal/kotlin/random/Random$Default;

    .line 275
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/internal/PlatformImplementationsKt;->IMPLEMENTATIONS:Lcom/scanflow/datacapture/barinternal/kotlin/internal/PlatformImplementations;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/internal/PlatformImplementations;->defaultPlatformRandom()Lcom/scanflow/datacapture/barinternal/kotlin/random/Random;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/random/Random;->defaultRandom:Lcom/scanflow/datacapture/barinternal/kotlin/random/Random;

    return-void
.end method

.method public constructor <init>()V
    .locals 0

    .line 21
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static final synthetic access$getDefaultRandom$cp()Lcom/scanflow/datacapture/barinternal/kotlin/random/Random;
    .locals 1

    .line 21
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/random/Random;->defaultRandom:Lcom/scanflow/datacapture/barinternal/kotlin/random/Random;

    return-object v0
.end method


# virtual methods
.method public abstract nextInt(I)I
.end method
