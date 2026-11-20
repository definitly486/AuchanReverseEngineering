.class public final Lcom/scanflow/datacapture/barinternal/kotlin/random/Random$Default;
.super Lcom/scanflow/datacapture/barinternal/kotlin/random/Random;
.source "Random.kt"

# interfaces
.implements Ljava/io/Serializable;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/kotlin/random/Random;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Default"
.end annotation


# direct methods
.method private constructor <init>()V
    .locals 0

    .line 274
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/random/Random;-><init>()V

    return-void
.end method

.method public synthetic constructor <init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/random/Random$Default;-><init>()V

    return-void
.end method


# virtual methods
.method public nextInt(I)I
    .locals 1

    .line 289
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/random/Random;->access$getDefaultRandom$cp()Lcom/scanflow/datacapture/barinternal/kotlin/random/Random;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/random/Random;->nextInt(I)I

    move-result p1

    return p1
.end method
