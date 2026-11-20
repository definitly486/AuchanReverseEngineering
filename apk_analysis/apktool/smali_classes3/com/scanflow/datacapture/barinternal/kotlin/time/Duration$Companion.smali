.class public final Lcom/scanflow/datacapture/barinternal/kotlin/time/Duration$Companion;
.super Ljava/lang/Object;
.source "Duration.kt"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/kotlin/time/Duration;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Companion"
.end annotation


# direct methods
.method private constructor <init>()V
    .locals 0

    .line 46
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public synthetic constructor <init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/time/Duration$Companion;-><init>()V

    return-void
.end method


# virtual methods
.method public final fromRawValue-UwyO8pc$kotlin_stdlib(J)J
    .locals 7

    .line 48
    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlin/time/Duration;->constructor-impl(J)J

    move-result-wide p1

    .line 49
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationJvmKt;->getDurationAssertionsEnabled()Z

    move-result v0

    if-eqz v0, :cond_6

    .line 50
    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlin/time/Duration;->access$isInNanos-impl(J)Z

    move-result v0

    if-eqz v0, :cond_1

    .line 51
    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlin/time/Duration;->access$getValue-impl(J)J

    move-result-wide v0

    const-wide v2, -0x3ffffffffffa14bfL    # -2.0000000001722644

    cmp-long v2, v2, v0

    if-gtz v2, :cond_0

    const-wide v2, 0x3ffffffffffa14c0L    # 1.999999999913868

    cmp-long v0, v0, v2

    if-gez v0, :cond_0

    return-wide p1

    :cond_0
    new-instance v0, Ljava/lang/AssertionError;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlin/time/Duration;->access$getValue-impl(J)J

    move-result-wide p1

    invoke-virtual {v1, p1, p2}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    const-string p1, " ns is out of nanoseconds range"

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {v0, p1}, Ljava/lang/AssertionError;-><init>(Ljava/lang/Object;)V

    throw v0

    .line 53
    :cond_1
    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlin/time/Duration;->access$getValue-impl(J)J

    move-result-wide v0

    const-wide v2, -0x3fffffffffffffffL    # -2.0000000000000004

    cmp-long v4, v2, v0

    const-wide v5, 0x3fffffffffffffffL    # 1.9999999999999998

    if-gez v4, :cond_2

    cmp-long v0, v0, v5

    if-gez v0, :cond_2

    goto :goto_0

    :cond_2
    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlin/time/Duration;->access$getValue-impl(J)J

    move-result-wide v0

    cmp-long v4, v0, v5

    if-eqz v4, :cond_4

    cmp-long v0, v0, v2

    if-nez v0, :cond_3

    goto :goto_0

    :cond_3
    new-instance v0, Ljava/lang/AssertionError;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlin/time/Duration;->access$getValue-impl(J)J

    move-result-wide p1

    invoke-virtual {v1, p1, p2}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    const-string p1, " ms is out of milliseconds range"

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {v0, p1}, Ljava/lang/AssertionError;-><init>(Ljava/lang/Object;)V

    throw v0

    .line 54
    :cond_4
    :goto_0
    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlin/time/Duration;->access$getValue-impl(J)J

    move-result-wide v0

    const-wide v2, -0x431bde82d7aL

    cmp-long v2, v2, v0

    if-gtz v2, :cond_6

    const-wide v2, 0x431bde82d7bL

    cmp-long v0, v0, v2

    if-ltz v0, :cond_5

    return-wide p1

    :cond_5
    new-instance v0, Ljava/lang/AssertionError;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlin/time/Duration;->access$getValue-impl(J)J

    move-result-wide p1

    invoke-virtual {v1, p1, p2}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    const-string p1, " ms is denormalized"

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {v0, p1}, Ljava/lang/AssertionError;-><init>(Ljava/lang/Object;)V

    throw v0

    :cond_6
    return-wide p1
.end method

.method public final getINFINITE-UwyO8pc()J
    .locals 2

    .line 64
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/time/Duration;->access$getINFINITE$cp()J

    move-result-wide v0

    return-wide v0
.end method

.method public final getINVALID-UwyO8pc$kotlin_stdlib()J
    .locals 2

    .line 69
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/time/Duration;->access$getINVALID$cp()J

    move-result-wide v0

    return-wide v0
.end method

.method public final parseIsoString-UwyO8pc(Ljava/lang/String;)J
    .locals 4

    const-string v0, "value"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const/4 v0, 0x4

    const/4 v1, 0x0

    const/4 v2, 0x1

    const/4 v3, 0x0

    .line 320
    :try_start_0
    invoke-static {p1, v2, v3, v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationKt;->parseDuration$default(Ljava/lang/String;ZZILjava/lang/Object;)J

    move-result-wide v0

    sget-object v2, Lcom/scanflow/datacapture/barinternal/kotlin/time/Duration;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/time/Duration$Companion;

    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/kotlin/time/Duration$Companion;->getINVALID-UwyO8pc$kotlin_stdlib()J

    move-result-wide v2

    invoke-static {v0, v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/kotlin/time/Duration;->equals-impl0(JJ)Z

    move-result v2

    if-nez v2, :cond_0

    return-wide v0

    :cond_0
    const-string v0, "invariant failed"

    new-instance v1, Ljava/lang/IllegalStateException;

    invoke-direct {v1, v0}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw v1
    :try_end_0
    .catch Ljava/lang/IllegalArgumentException; {:try_start_0 .. :try_end_0} :catch_0

    :catch_0
    move-exception v0

    .line 322
    new-instance v1, Ljava/lang/IllegalArgumentException;

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "Invalid ISO duration string format: \'"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string p1, "\'."

    invoke-virtual {v2, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {v1, p1, v0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;Ljava/lang/Throwable;)V

    throw v1
.end method
