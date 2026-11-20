.class abstract Lcom/scanflow/datacapture/barinternal/kotlin/sequences/SequencesKt__SequencesKt;
.super Lcom/scanflow/datacapture/barinternal/kotlin/sequences/SequencesKt__SequencesJVMKt;
.source "Sequences.kt"


# direct methods
.method public static synthetic $r8$lambda$8HblPkoO8vE-XEU8raYk3YnY_qE(Lkotlin/jvm/functions/Function0;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 0
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/SequencesKt__SequencesKt;->generateSequence$lambda$0$SequencesKt__SequencesKt(Lkotlin/jvm/functions/Function0;Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p0

    return-object p0
.end method

.method public static synthetic $r8$lambda$eiRiKARCOo2Ht_MuMlAffn7d6hs(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 0
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/SequencesKt__SequencesKt;->generateSequence$lambda$1$SequencesKt__SequencesKt(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p0

    return-object p0
.end method

.method public static asSequence(Ljava/util/Iterator;)Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;
    .locals 1

    const-string v0, "<this>"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 31
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/SequencesKt__SequencesKt$asSequence$$inlined$Sequence$1;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/SequencesKt__SequencesKt$asSequence$$inlined$Sequence$1;-><init>(Ljava/util/Iterator;)V

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/SequencesKt__SequencesKt;->constrainOnce(Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;)Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;

    move-result-object p0

    return-object p0
.end method

.method public static final constrainOnce(Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;)Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;
    .locals 1

    const-string v0, "<this>"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 677
    instance-of v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/ConstrainedOnceSequence;

    if-eqz v0, :cond_0

    return-object p0

    :cond_0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/ConstrainedOnceSequence;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/ConstrainedOnceSequence;-><init>(Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;)V

    return-object v0
.end method

.method public static generateSequence(Ljava/lang/Object;Lkotlin/jvm/functions/Function1;)Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;
    .locals 2

    const-string v0, "nextFunction"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    if-nez p0, :cond_0

    .line 711
    sget-object p0, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/EmptySequence;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/sequences/EmptySequence;

    return-object p0

    .line 713
    :cond_0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/GeneratorSequence;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/SequencesKt__SequencesKt$$ExternalSyntheticLambda0;

    invoke-direct {v1, p0}, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/SequencesKt__SequencesKt$$ExternalSyntheticLambda0;-><init>(Ljava/lang/Object;)V

    invoke-direct {v0, v1, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/GeneratorSequence;-><init>(Lkotlin/jvm/functions/Function0;Lkotlin/jvm/functions/Function1;)V

    return-object v0
.end method

.method public static generateSequence(Lkotlin/jvm/functions/Function0;)Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;
    .locals 2

    const-string v0, "nextFunction"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 692
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/GeneratorSequence;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/SequencesKt__SequencesKt$$ExternalSyntheticLambda1;

    invoke-direct {v1, p0}, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/SequencesKt__SequencesKt$$ExternalSyntheticLambda1;-><init>(Lkotlin/jvm/functions/Function0;)V

    invoke-direct {v0, p0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/GeneratorSequence;-><init>(Lkotlin/jvm/functions/Function0;Lkotlin/jvm/functions/Function1;)V

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/SequencesKt__SequencesKt;->constrainOnce(Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;)Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;

    move-result-object p0

    return-object p0
.end method

.method private static final generateSequence$lambda$0$SequencesKt__SequencesKt(Lkotlin/jvm/functions/Function0;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 1

    const-string v0, "it"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 692
    invoke-interface {p0}, Lkotlin/jvm/functions/Function0;->invoke()Ljava/lang/Object;

    move-result-object p0

    return-object p0
.end method

.method private static final generateSequence$lambda$1$SequencesKt__SequencesKt(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 713
    return-object p0
.end method
