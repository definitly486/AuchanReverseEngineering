.class final Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult;
.super Ljava/lang/Object;
.source "Regex.kt"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/kotlin/text/MatchResult;


# instance fields
.field private groupValues_:Ljava/util/List;

.field private final groups:Lcom/scanflow/datacapture/barinternal/kotlin/text/MatchGroupCollection;

.field private final input:Ljava/lang/CharSequence;

.field private final matcher:Ljava/util/regex/Matcher;


# direct methods
.method public constructor <init>(Ljava/util/regex/Matcher;Ljava/lang/CharSequence;)V
    .locals 1

    const-string v0, "matcher"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "input"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 373
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult;->matcher:Ljava/util/regex/Matcher;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult;->input:Ljava/lang/CharSequence;

    .line 380
    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult$groups$1;

    invoke-direct {p1, p0}, Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult$groups$1;-><init>(Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult;)V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult;->groups:Lcom/scanflow/datacapture/barinternal/kotlin/text/MatchGroupCollection;

    return-void
.end method

.method public static final synthetic access$getMatchResult(Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult;)Ljava/util/regex/MatchResult;
    .locals 0

    .line 373
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult;->getMatchResult()Ljava/util/regex/MatchResult;

    move-result-object p0

    return-object p0
.end method

.method private final getMatchResult()Ljava/util/regex/MatchResult;
    .locals 1

    .line 374
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult;->matcher:Ljava/util/regex/Matcher;

    return-object v0
.end method


# virtual methods
.method public getGroupValues()Ljava/util/List;
    .locals 1

    .line 402
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult;->groupValues_:Ljava/util/List;

    if-nez v0, :cond_0

    .line 403
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult$groupValues$1;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult$groupValues$1;-><init>(Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult;->groupValues_:Ljava/util/List;

    .line 408
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult;->groupValues_:Ljava/util/List;

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    return-object v0
.end method
