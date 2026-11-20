.class public final Lcom/scanflow/datacapture/barinternal/kotlin/sequences/SequencesKt___SequencesKt$asIterable$$inlined$Iterable$1;
.super Ljava/lang/Object;
.source "Iterables.kt"

# interfaces
.implements Ljava/lang/Iterable;
.implements Lkotlin/jvm/internal/markers/KMappedMarker;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/scanflow/datacapture/barinternal/kotlin/sequences/SequencesKt___SequencesKt;->asIterable(Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;)Ljava/lang/Iterable;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = null
.end annotation


# instance fields
.field final synthetic $this_asIterable$inlined:Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;)V
    .locals 0

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/SequencesKt___SequencesKt$asIterable$$inlined$Iterable$1;->$this_asIterable$inlined:Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;

    .line 16
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public iterator()Ljava/util/Iterator;
    .locals 1

    .line 71
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/SequencesKt___SequencesKt$asIterable$$inlined$Iterable$1;->$this_asIterable$inlined:Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;->iterator()Ljava/util/Iterator;

    move-result-object v0

    return-object v0
.end method
