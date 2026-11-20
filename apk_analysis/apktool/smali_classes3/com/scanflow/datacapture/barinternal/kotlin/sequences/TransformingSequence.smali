.class public final Lcom/scanflow/datacapture/barinternal/kotlin/sequences/TransformingSequence;
.super Ljava/lang/Object;
.source "Sequences.kt"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;


# instance fields
.field private final sequence:Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;

.field private final transformer:Lkotlin/jvm/functions/Function1;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;Lkotlin/jvm/functions/Function1;)V
    .locals 1

    const-string v0, "sequence"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "transformer"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 238
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 239
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/TransformingSequence;->sequence:Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/TransformingSequence;->transformer:Lkotlin/jvm/functions/Function1;

    return-void
.end method

.method public static final synthetic access$getSequence$p(Lcom/scanflow/datacapture/barinternal/kotlin/sequences/TransformingSequence;)Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;
    .locals 0

    .line 238
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/TransformingSequence;->sequence:Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;

    return-object p0
.end method

.method public static final synthetic access$getTransformer$p(Lcom/scanflow/datacapture/barinternal/kotlin/sequences/TransformingSequence;)Lkotlin/jvm/functions/Function1;
    .locals 0

    .line 238
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/TransformingSequence;->transformer:Lkotlin/jvm/functions/Function1;

    return-object p0
.end method


# virtual methods
.method public iterator()Ljava/util/Iterator;
    .locals 1

    .line 240
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/TransformingSequence$iterator$1;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/TransformingSequence$iterator$1;-><init>(Lcom/scanflow/datacapture/barinternal/kotlin/sequences/TransformingSequence;)V

    return-object v0
.end method
