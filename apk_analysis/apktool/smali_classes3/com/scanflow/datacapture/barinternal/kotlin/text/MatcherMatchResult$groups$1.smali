.class public final Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult$groups$1;
.super Lcom/scanflow/datacapture/barinternal/kotlin/collections/AbstractCollection;
.source "Regex.kt"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/kotlin/text/MatchGroupCollection;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult;-><init>(Ljava/util/regex/Matcher;Ljava/lang/CharSequence;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult;


# direct methods
.method public static synthetic $r8$lambda$6qTiT2TOre74mkZ4SBVT0fE9ajA(Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult$groups$1;I)Lcom/scanflow/datacapture/barinternal/kotlin/text/MatchGroup;
    .locals 0

    .line 0
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult$groups$1;->iterator$lambda$0(Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult$groups$1;I)Lcom/scanflow/datacapture/barinternal/kotlin/text/MatchGroup;

    move-result-object p0

    return-object p0
.end method

.method constructor <init>(Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult;)V
    .locals 0

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult$groups$1;->this$0:Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult;

    .line 380
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/AbstractCollection;-><init>()V

    return-void
.end method

.method private static final iterator$lambda$0(Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult$groups$1;I)Lcom/scanflow/datacapture/barinternal/kotlin/text/MatchGroup;
    .locals 0

    .line 384
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult$groups$1;->get(I)Lcom/scanflow/datacapture/barinternal/kotlin/text/MatchGroup;

    move-result-object p0

    return-object p0
.end method


# virtual methods
.method public bridge contains(Lcom/scanflow/datacapture/barinternal/kotlin/text/MatchGroup;)Z
    .locals 0

    .line 380
    invoke-super {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/AbstractCollection;->contains(Ljava/lang/Object;)Z

    move-result p1

    return p1
.end method

.method public final bridge contains(Ljava/lang/Object;)Z
    .locals 1

    if-nez p1, :cond_0

    const/4 v0, 0x1

    goto :goto_0

    .line 380
    :cond_0
    instance-of v0, p1, Lcom/scanflow/datacapture/barinternal/kotlin/text/MatchGroup;

    :goto_0
    if-nez v0, :cond_1

    const/4 p1, 0x0

    return p1

    :cond_1
    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlin/text/MatchGroup;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult$groups$1;->contains(Lcom/scanflow/datacapture/barinternal/kotlin/text/MatchGroup;)Z

    move-result p1

    return p1
.end method

.method public get(I)Lcom/scanflow/datacapture/barinternal/kotlin/text/MatchGroup;
    .locals 3

    .line 386
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult$groups$1;->this$0:Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult;->access$getMatchResult(Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult;)Ljava/util/regex/MatchResult;

    move-result-object v0

    invoke-static {v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/text/RegexKt;->access$range(Ljava/util/regex/MatchResult;I)Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;

    move-result-object v0

    .line 387
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;->getStart()Ljava/lang/Integer;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Integer;->intValue()I

    move-result v1

    if-ltz v1, :cond_0

    .line 388
    new-instance v1, Lcom/scanflow/datacapture/barinternal/kotlin/text/MatchGroup;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult$groups$1;->this$0:Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult;

    invoke-static {v2}, Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult;->access$getMatchResult(Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult;)Ljava/util/regex/MatchResult;

    move-result-object v2

    invoke-interface {v2, p1}, Ljava/util/regex/MatchResult;->group(I)Ljava/lang/String;

    move-result-object p1

    const-string v2, "group(...)"

    invoke-static {p1, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-direct {v1, p1, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/text/MatchGroup;-><init>(Ljava/lang/String;Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;)V

    return-object v1

    :cond_0
    const/4 p1, 0x0

    return-object p1
.end method

.method public getSize()I
    .locals 1

    .line 381
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult$groups$1;->this$0:Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult;->access$getMatchResult(Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult;)Ljava/util/regex/MatchResult;

    move-result-object v0

    invoke-interface {v0}, Ljava/util/regex/MatchResult;->groupCount()I

    move-result v0

    add-int/lit8 v0, v0, 0x1

    return v0
.end method

.method public isEmpty()Z
    .locals 1

    .line 382
    const/4 v0, 0x0

    return v0
.end method

.method public iterator()Ljava/util/Iterator;
    .locals 2

    .line 384
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->getIndices(Ljava/util/Collection;)Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;

    move-result-object v0

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->asSequence(Ljava/lang/Iterable;)Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;

    move-result-object v0

    new-instance v1, Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult$groups$1$$ExternalSyntheticLambda0;

    invoke-direct {v1, p0}, Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult$groups$1$$ExternalSyntheticLambda0;-><init>(Lcom/scanflow/datacapture/barinternal/kotlin/text/MatcherMatchResult$groups$1;)V

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/SequencesKt;->map(Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;Lkotlin/jvm/functions/Function1;)Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;

    move-result-object v0

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;->iterator()Ljava/util/Iterator;

    move-result-object v0

    return-object v0
.end method
