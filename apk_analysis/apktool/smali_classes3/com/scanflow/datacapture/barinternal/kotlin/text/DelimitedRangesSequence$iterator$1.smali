.class public final Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;
.super Ljava/lang/Object;
.source "Strings.kt"

# interfaces
.implements Ljava/util/Iterator;
.implements Lkotlin/jvm/internal/markers/KMappedMarker;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence;->iterator()Ljava/util/Iterator;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = null
.end annotation


# instance fields
.field private counter:I

.field private currentStartIndex:I

.field private nextItem:Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;

.field private nextSearchIndex:I

.field private nextState:I

.field final synthetic this$0:Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence;


# direct methods
.method constructor <init>(Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence;)V
    .locals 2

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;->this$0:Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence;

    .line 1216
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const/4 v0, -0x1

    .line 1217
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;->nextState:I

    .line 1218
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence;->access$getStartIndex$p(Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence;)I

    move-result v0

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence;->access$getInput$p(Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence;)Ljava/lang/CharSequence;

    move-result-object p1

    invoke-interface {p1}, Ljava/lang/CharSequence;->length()I

    move-result p1

    const/4 v1, 0x0

    invoke-static {v0, v1, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/RangesKt;->coerceIn(III)I

    move-result p1

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;->currentStartIndex:I

    .line 1219
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;->nextSearchIndex:I

    return-void
.end method

.method private final calcNext()V
    .locals 6

    .line 1224
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;->nextSearchIndex:I

    const/4 v1, 0x0

    if-gez v0, :cond_0

    .line 1225
    iput v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;->nextState:I

    const/4 v0, 0x0

    .line 1226
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;->nextItem:Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;

    return-void

    .line 1228
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;->this$0:Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence;->access$getLimit$p(Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence;)I

    move-result v0

    const/4 v2, -0x1

    const/4 v3, 0x1

    if-lez v0, :cond_1

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;->counter:I

    add-int/2addr v0, v3

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;->counter:I

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;->this$0:Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence;

    invoke-static {v4}, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence;->access$getLimit$p(Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence;)I

    move-result v4

    if-ge v0, v4, :cond_2

    :cond_1
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;->nextSearchIndex:I

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;->this$0:Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence;

    invoke-static {v4}, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence;->access$getInput$p(Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence;)Ljava/lang/CharSequence;

    move-result-object v4

    invoke-interface {v4}, Ljava/lang/CharSequence;->length()I

    move-result v4

    if-le v0, v4, :cond_3

    .line 1229
    :cond_2
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;->currentStartIndex:I

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;->this$0:Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence;

    invoke-static {v4}, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence;->access$getInput$p(Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence;)Ljava/lang/CharSequence;

    move-result-object v4

    invoke-static {v4}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt__StringsKt;->getLastIndex(Ljava/lang/CharSequence;)I

    move-result v4

    invoke-direct {v0, v1, v4}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;-><init>(II)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;->nextItem:Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;

    .line 1230
    iput v2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;->nextSearchIndex:I

    goto :goto_0

    .line 1232
    :cond_3
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;->this$0:Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence;->access$getGetNextMatch$p(Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence;)Lkotlin/jvm/functions/Function2;

    move-result-object v0

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;->this$0:Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence;

    invoke-static {v4}, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence;->access$getInput$p(Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence;)Ljava/lang/CharSequence;

    move-result-object v4

    iget v5, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;->nextSearchIndex:I

    invoke-static {v5}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v5

    invoke-interface {v0, v4, v5}, Lkotlin/jvm/functions/Function2;->invoke(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    if-nez v0, :cond_4

    .line 1234
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;->currentStartIndex:I

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;->this$0:Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence;

    invoke-static {v4}, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence;->access$getInput$p(Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence;)Ljava/lang/CharSequence;

    move-result-object v4

    invoke-static {v4}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt__StringsKt;->getLastIndex(Ljava/lang/CharSequence;)I

    move-result v4

    invoke-direct {v0, v1, v4}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;-><init>(II)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;->nextItem:Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;

    .line 1235
    iput v2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;->nextSearchIndex:I

    goto :goto_0

    .line 1237
    :cond_4
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;->component1()Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Ljava/lang/Number;

    invoke-virtual {v2}, Ljava/lang/Number;->intValue()I

    move-result v2

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;->component2()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/Number;

    invoke-virtual {v0}, Ljava/lang/Number;->intValue()I

    move-result v0

    .line 1238
    iget v4, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;->currentStartIndex:I

    invoke-static {v4, v2}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/RangesKt;->until(II)Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;

    move-result-object v4

    iput-object v4, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;->nextItem:Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;

    add-int/2addr v2, v0

    .line 1239
    iput v2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;->currentStartIndex:I

    if-nez v0, :cond_5

    move v1, v3

    :cond_5
    add-int/2addr v2, v1

    .line 1240
    iput v2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;->nextSearchIndex:I

    .line 1243
    :goto_0
    iput v3, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;->nextState:I

    return-void
.end method


# virtual methods
.method public hasNext()Z
    .locals 2

    .line 1260
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;->nextState:I

    const/4 v1, -0x1

    if-ne v0, v1, :cond_0

    .line 1261
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;->calcNext()V

    .line 1262
    :cond_0
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;->nextState:I

    const/4 v1, 0x1

    if-ne v0, v1, :cond_1

    return v1

    :cond_1
    const/4 v0, 0x0

    return v0
.end method

.method public next()Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;
    .locals 3

    .line 1248
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;->nextState:I

    const/4 v1, -0x1

    if-ne v0, v1, :cond_0

    .line 1249
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;->calcNext()V

    .line 1250
    :cond_0
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;->nextState:I

    if-eqz v0, :cond_1

    .line 1252
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;->nextItem:Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;

    const-string v2, "null cannot be cast to non-null type kotlin.ranges.IntRange"

    invoke-static {v0, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const/4 v2, 0x0

    .line 1254
    iput-object v2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;->nextItem:Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;

    .line 1255
    iput v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;->nextState:I

    return-object v0

    .line 1251
    :cond_1
    new-instance v0, Ljava/util/NoSuchElementException;

    invoke-direct {v0}, Ljava/util/NoSuchElementException;-><init>()V

    throw v0
.end method

.method public bridge synthetic next()Ljava/lang/Object;
    .locals 1

    .line 1216
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/text/DelimitedRangesSequence$iterator$1;->next()Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;

    move-result-object v0

    return-object v0
.end method

.method public remove()V
    .locals 2

    .line 0
    new-instance v0, Ljava/lang/UnsupportedOperationException;

    const-string v1, "Operation is not supported for read-only collection"

    invoke-direct {v0, v1}, Ljava/lang/UnsupportedOperationException;-><init>(Ljava/lang/String;)V

    throw v0
.end method
