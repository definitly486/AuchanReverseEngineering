.class public abstract Lcom/scanflow/datacapture/barinternal/kotlin/text/RegexKt;
.super Ljava/lang/Object;
.source "Regex.kt"


# direct methods
.method public static final synthetic access$findNext(Ljava/util/regex/Matcher;ILjava/lang/CharSequence;)Lcom/scanflow/datacapture/barinternal/kotlin/text/MatchResult;
    .locals 0

    .line 1
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlin/text/RegexKt;->findNext(Ljava/util/regex/Matcher;ILjava/lang/CharSequence;)Lcom/scanflow/datacapture/barinternal/kotlin/text/MatchResult;

    move-result-object p0

    return-object p0
.end method

.method public static final synthetic access$range(Ljava/util/regex/MatchResult;I)Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;
    .locals 0

    .line 1
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/text/RegexKt;->range(Ljava/util/regex/MatchResult;I)Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;

    move-result-object p0

    return-object p0
.end method

.method private static final findNext(Ljava/util/regex/Matcher;ILjava/lang/CharSequence;)Lcom/scanflow/datacapture/barinternal/kotlin/text/MatchResult;
    .locals 0

    .line 366
    invoke-virtual {p0, p1}, Ljava/util/regex/Matcher;->find(I)Z

    move-result p1

    if-nez p1, :cond_0

    const/4 p0, 0x0

    return-object p0

    :cond_0
    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult;

    invoke-direct {p1, p0, p2}, Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult;-><init>(Ljava/util/regex/Matcher;Ljava/lang/CharSequence;)V

    return-object p1
.end method

.method private static final range(Ljava/util/regex/MatchResult;I)Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;
    .locals 1

    .line 419
    invoke-interface {p0, p1}, Ljava/util/regex/MatchResult;->start(I)I

    move-result v0

    invoke-interface {p0, p1}, Ljava/util/regex/MatchResult;->end(I)I

    move-result p0

    invoke-static {v0, p0}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/RangesKt;->until(II)Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;

    move-result-object p0

    return-object p0
.end method
