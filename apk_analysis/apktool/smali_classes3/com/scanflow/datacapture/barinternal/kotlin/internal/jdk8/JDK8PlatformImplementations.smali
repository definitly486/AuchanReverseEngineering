.class public Lcom/scanflow/datacapture/barinternal/kotlin/internal/jdk8/JDK8PlatformImplementations;
.super Lcom/scanflow/datacapture/barinternal/kotlin/internal/jdk7/JDK7PlatformImplementations;
.source "JDK8PlatformImplementations.kt"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/kotlin/internal/jdk8/JDK8PlatformImplementations$ReflectSdkVersion;
    }
.end annotation


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 27
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/internal/jdk7/JDK7PlatformImplementations;-><init>()V

    return-void
.end method

.method private final sdkIsNullOrAtLeast(I)Z
    .locals 1

    .line 40
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/internal/jdk8/JDK8PlatformImplementations$ReflectSdkVersion;->sdkVersion:Ljava/lang/Integer;

    if-eqz v0, :cond_1

    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v0

    if-lt v0, p1, :cond_0

    goto :goto_0

    :cond_0
    const/4 p1, 0x0

    return p1

    :cond_1
    :goto_0
    const/4 p1, 0x1

    return p1
.end method


# virtual methods
.method public defaultPlatformRandom()Lcom/scanflow/datacapture/barinternal/kotlin/random/Random;
    .locals 1

    const/16 v0, 0x22

    .line 58
    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/internal/jdk8/JDK8PlatformImplementations;->sdkIsNullOrAtLeast(I)Z

    move-result v0

    if-eqz v0, :cond_0

    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/random/jdk8/PlatformThreadLocalRandom;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/random/jdk8/PlatformThreadLocalRandom;-><init>()V

    return-object v0

    :cond_0
    invoke-super {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/internal/PlatformImplementations;->defaultPlatformRandom()Lcom/scanflow/datacapture/barinternal/kotlin/random/Random;

    move-result-object v0

    return-object v0
.end method
