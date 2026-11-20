.class abstract Lcom/scanflow/datacapture/barinternal/kotlin/sequences/SequencesKt__SequenceBuilderKt;
.super Ljava/lang/Object;
.source "SequenceBuilder.kt"


# direct methods
.method public static iterator(Lkotlin/jvm/functions/Function2;)Ljava/util/Iterator;
    .locals 1

    const-string v0, "block"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 37
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/SequenceBuilderIterator;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/SequenceBuilderIterator;-><init>()V

    .line 38
    invoke-static {p0, v0, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->createCoroutineUnintercepted(Lkotlin/jvm/functions/Function2;Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Lkotlin/coroutines/Continuation;

    move-result-object p0

    invoke-virtual {v0, p0}, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/SequenceBuilderIterator;->setNextStep(Lkotlin/coroutines/Continuation;)V

    return-object v0
.end method

.method public static sequence(Lkotlin/jvm/functions/Function2;)Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;
    .locals 1

    const-string v0, "block"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 26
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/SequencesKt__SequenceBuilderKt$sequence$$inlined$Sequence$1;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/SequencesKt__SequenceBuilderKt$sequence$$inlined$Sequence$1;-><init>(Lkotlin/jvm/functions/Function2;)V

    return-object v0
.end method
