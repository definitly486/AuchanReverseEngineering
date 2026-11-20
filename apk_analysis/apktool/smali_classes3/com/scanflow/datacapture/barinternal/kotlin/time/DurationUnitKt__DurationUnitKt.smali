.class abstract Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnitKt__DurationUnitKt;
.super Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnitKt__DurationUnitJvmKt;
.source "DurationUnit.kt"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnitKt__DurationUnitKt$WhenMappings;
    }
.end annotation


# direct methods
.method public static final convertDurationUnitToMilliseconds(JLcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;)J
    .locals 2

    const-string v0, "unit"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 72
    invoke-static {p2}, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnitKt__DurationUnitKt;->getMillisMultiplier$DurationUnitKt__DurationUnitKt(Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;)J

    move-result-wide v0

    invoke-static {p0, p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnitKt__DurationUnitKt;->multiplyNonNegativeWithoutOverflow$DurationUnitKt__DurationUnitKt(JJ)J

    move-result-wide p0

    return-wide p0
.end method

.method private static final getMillisMultiplier$DurationUnitKt__DurationUnitKt(Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;)J
    .locals 3

    .line 105
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnitKt__DurationUnitKt$WhenMappings;->$EnumSwitchMapping$0:[I

    invoke-virtual {p0}, Ljava/lang/Enum;->ordinal()I

    move-result v1

    aget v0, v0, v1

    const/4 v1, 0x1

    if-eq v0, v1, :cond_4

    const/4 v1, 0x2

    if-eq v0, v1, :cond_3

    const/4 v1, 0x3

    if-eq v0, v1, :cond_2

    const/4 v1, 0x4

    if-eq v0, v1, :cond_1

    const/4 v1, 0x5

    if-ne v0, v1, :cond_0

    const-wide/16 v0, 0x1

    return-wide v0

    .line 110
    :cond_0
    new-instance v0, Ljava/lang/IllegalStateException;

    .line 111
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Wrong unit for millisMultiplier: "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    invoke-virtual {p0}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object p0

    invoke-direct {v0, p0}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw v0

    :cond_1
    const-wide/16 v0, 0x3e8

    return-wide v0

    :cond_2
    const-wide/32 v0, 0xea60

    return-wide v0

    :cond_3
    const-wide/32 v0, 0x36ee80

    return-wide v0

    :cond_4
    const-wide/32 v0, 0x5265c00

    return-wide v0
.end method

.method private static final multiplyNonNegativeWithoutOverflow$DurationUnitKt__DurationUnitKt(JJ)J
    .locals 5

    const-wide/16 v0, 0x0

    cmp-long v2, p0, v0

    if-nez v2, :cond_0

    return-wide v0

    :cond_0
    const-wide/16 v0, 0x1

    cmp-long v2, p0, v0

    const-wide v3, 0x3fffffffffffffffL    # 1.9999999999999998

    if-nez v2, :cond_1

    .line 88
    invoke-static {p2, p3, v3, v4}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/RangesKt;->coerceAtMost(JJ)J

    move-result-wide p0

    return-wide p0

    :cond_1
    cmp-long v0, p2, v0

    if-nez v0, :cond_2

    .line 89
    invoke-static {p0, p1, v3, v4}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/RangesKt;->coerceAtMost(JJ)J

    move-result-wide p0

    return-wide p0

    .line 91
    :cond_2
    invoke-static {p0, p1}, Ljava/lang/Long;->numberOfLeadingZeros(J)I

    move-result v0

    rsub-int v0, v0, 0x80

    invoke-static {p2, p3}, Ljava/lang/Long;->numberOfLeadingZeros(J)I

    move-result v1

    sub-int/2addr v0, v1

    const/16 v1, 0x3f

    if-ge v0, v1, :cond_3

    mul-long/2addr p0, p2

    return-wide p0

    :cond_3
    if-le v0, v1, :cond_4

    return-wide v3

    :cond_4
    mul-long/2addr p0, p2

    .line 95
    invoke-static {p0, p1, v3, v4}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/RangesKt;->coerceAtMost(JJ)J

    move-result-wide p0

    return-wide p0
.end method
