.class public final Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant$Companion;
.super Ljava/lang/Object;
.source "Instant.kt"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Companion"
.end annotation


# direct methods
.method private constructor <init>()V
    .locals 0

    .line 273
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public synthetic constructor <init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant$Companion;-><init>()V

    return-void
.end method


# virtual methods
.method public final fromEpochSeconds(JI)Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;
    .locals 2

    int-to-long v0, p3

    .line 356
    invoke-virtual {p0, p1, p2, v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant$Companion;->fromEpochSeconds(JJ)Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;

    move-result-object p1

    return-object p1
.end method

.method public final fromEpochSeconds(JJ)Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;
    .locals 10

    const-wide/32 v0, 0x3b9aca00

    .line 320
    div-long v2, p3, v0

    xor-long v4, p3, v0

    const-wide/16 v6, 0x0

    cmp-long v4, v4, v6

    if-gez v4, :cond_0

    mul-long v4, v2, v0

    cmp-long v4, v4, p3

    if-eqz v4, :cond_0

    const-wide/16 v4, -0x1

    add-long/2addr v2, v4

    :cond_0
    add-long v4, p1, v2

    xor-long v8, p1, v4

    cmp-long v8, v8, v6

    if-gez v8, :cond_2

    xor-long/2addr v2, p1

    cmp-long v2, v2, v6

    if-ltz v2, :cond_2

    cmp-long p1, p1, v6

    if-lez p1, :cond_1

    .line 321
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant$Companion;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant$Companion;->getMAX$kotlin_stdlib()Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;

    move-result-object p1

    return-object p1

    :cond_1
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant$Companion;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant$Companion;->getMIN$kotlin_stdlib()Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;

    move-result-object p1

    return-object p1

    :cond_2
    const-wide p1, -0x701cefeb9bec00L

    cmp-long p1, v4, p1

    if-gez p1, :cond_3

    .line 324
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant$Companion;->getMIN$kotlin_stdlib()Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;

    move-result-object p1

    return-object p1

    :cond_3
    const-wide p1, 0x701cd2fa9578ffL

    cmp-long p1, v4, p1

    if-lez p1, :cond_4

    .line 325
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant$Companion;->getMAX$kotlin_stdlib()Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;

    move-result-object p1

    return-object p1

    .line 327
    :cond_4
    rem-long/2addr p3, v0

    xor-long p1, p3, v0

    neg-long v2, p3

    or-long/2addr v2, p3

    and-long/2addr p1, v2

    const/16 v2, 0x3f

    shr-long/2addr p1, v2

    and-long/2addr p1, v0

    add-long/2addr p3, p1

    long-to-int p1, p3

    .line 328
    new-instance p2, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;

    invoke-direct {p2, v4, v5, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;-><init>(JI)V

    return-object p2
.end method

.method public final getMAX$kotlin_stdlib()Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;
    .locals 1

    .line 438
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;->access$getMAX$cp()Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;

    move-result-object v0

    return-object v0
.end method

.method public final getMIN$kotlin_stdlib()Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;
    .locals 1

    .line 437
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;->access$getMIN$cp()Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;

    move-result-object v0

    return-object v0
.end method

.method public final parse(Ljava/lang/CharSequence;)Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;
    .locals 1

    const-string v0, "input"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 386
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->access$parseIso(Ljava/lang/CharSequence;)Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult;

    move-result-object p1

    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult;->toInstant()Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;

    move-result-object p1

    return-object p1
.end method
