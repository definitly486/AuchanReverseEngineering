.class abstract Lcom/scanflow/datacapture/barinternal/kotlin/ranges/RangesKt___RangesKt;
.super Lcom/scanflow/datacapture/barinternal/kotlin/ranges/RangesKt__RangesKt;
.source "_Ranges.kt"


# direct methods
.method public static coerceAtLeast(FF)F
    .locals 1

    .line 1302
    cmpg-float v0, p0, p1

    if-gez v0, :cond_0

    return p1

    :cond_0
    return p0
.end method

.method public static coerceAtLeast(II)I
    .locals 0

    .line 1280
    if-ge p0, p1, :cond_0

    return p1

    :cond_0
    return p0
.end method

.method public static coerceAtLeast(JJ)J
    .locals 1

    .line 1291
    cmp-long v0, p0, p2

    if-gez v0, :cond_0

    return-wide p2

    :cond_0
    return-wide p0
.end method

.method public static coerceAtMost(FF)F
    .locals 1

    .line 1379
    cmpl-float v0, p0, p1

    if-lez v0, :cond_0

    return p1

    :cond_0
    return p0
.end method

.method public static coerceAtMost(II)I
    .locals 0

    .line 1357
    if-le p0, p1, :cond_0

    return p1

    :cond_0
    return p0
.end method

.method public static coerceAtMost(JJ)J
    .locals 1

    .line 1368
    cmp-long v0, p0, p2

    if-lez v0, :cond_0

    return-wide p2

    :cond_0
    return-wide p0
.end method

.method public static coerceIn(III)I
    .locals 2

    if-gt p1, p2, :cond_2

    if-ge p0, p1, :cond_0

    return p1

    :cond_0
    if-le p0, p2, :cond_1

    return p2

    :cond_1
    return p0

    .line 1449
    :cond_2
    new-instance p0, Ljava/lang/IllegalArgumentException;

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "Cannot coerce value to an empty range: maximum "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, p2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p2, " is less than minimum "

    invoke-virtual {v0, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const/16 p1, 0x2e

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method public static coerceIn(JJJ)J
    .locals 1

    cmp-long v0, p2, p4

    if-gtz v0, :cond_2

    cmp-long v0, p0, p2

    if-gez v0, :cond_0

    return-wide p2

    :cond_0
    cmp-long p2, p0, p4

    if-lez p2, :cond_1

    return-wide p4

    :cond_1
    return-wide p0

    .line 1463
    :cond_2
    new-instance p0, Ljava/lang/IllegalArgumentException;

    new-instance p1, Ljava/lang/StringBuilder;

    invoke-direct {p1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v0, "Cannot coerce value to an empty range: maximum "

    invoke-virtual {p1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p1, p4, p5}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    const-string p4, " is less than minimum "

    invoke-virtual {p1, p4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p1, p2, p3}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    const/16 p2, 0x2e

    invoke-virtual {p1, p2}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {p1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method public static downTo(II)Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntProgression;
    .locals 2

    .line 836
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntProgression;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntProgression$Companion;

    const/4 v1, -0x1

    invoke-virtual {v0, p0, p1, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntProgression$Companion;->fromClosedRange(III)Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntProgression;

    move-result-object p0

    return-object p0
.end method

.method public static step(Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntProgression;I)Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntProgression;
    .locals 3

    const-string v0, "<this>"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    if-lez p1, :cond_0

    const/4 v0, 0x1

    goto :goto_0

    :cond_0
    const/4 v0, 0x0

    .line 998
    :goto_0
    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v1

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/RangesKt__RangesKt;->checkStepIsPositive(ZLjava/lang/Number;)V

    .line 999
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntProgression;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntProgression$Companion;

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntProgression;->getFirst()I

    move-result v1

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntProgression;->getLast()I

    move-result v2

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntProgression;->getStep()I

    move-result p0

    if-lez p0, :cond_1

    goto :goto_1

    :cond_1
    neg-int p1, p1

    :goto_1
    invoke-virtual {v0, v1, v2, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntProgression$Companion;->fromClosedRange(III)Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntProgression;

    move-result-object p0

    return-object p0
.end method

.method public static until(II)Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;
    .locals 1

    const/high16 v0, -0x80000000

    if-gt p1, v0, :cond_0

    .line 1130
    sget-object p0, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange$Companion;

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange$Companion;->getEMPTY()Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;

    move-result-object p0

    return-object p0

    .line 1131
    :cond_0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;

    add-int/lit8 p1, p1, -0x1

    invoke-direct {v0, p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;-><init>(II)V

    return-object v0
.end method
