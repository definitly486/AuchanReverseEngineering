.class public final Lcom/scanflow/datacapture/barinternal/kotlin/sequences/DropSequence;
.super Ljava/lang/Object;
.source "Sequences.kt"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;
.implements Lcom/scanflow/datacapture/barinternal/kotlin/sequences/DropTakeSequence;


# instance fields
.field private final count:I

.field private final sequence:Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;I)V
    .locals 1

    const-string v0, "sequence"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 529
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 530
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/DropSequence;->sequence:Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;

    .line 531
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/DropSequence;->count:I

    if-ltz p2, :cond_0

    return-void

    .line 534
    :cond_0
    new-instance p1, Ljava/lang/StringBuilder;

    invoke-direct {p1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v0, "count must be non-negative, but was "

    invoke-virtual {p1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p1, p2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const/16 p2, 0x2e

    invoke-virtual {p1, p2}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {p1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    new-instance p2, Ljava/lang/IllegalArgumentException;

    invoke-virtual {p1}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {p2, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p2
.end method

.method public static final synthetic access$getCount$p(Lcom/scanflow/datacapture/barinternal/kotlin/sequences/DropSequence;)I
    .locals 0

    .line 529
    iget p0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/DropSequence;->count:I

    return p0
.end method

.method public static final synthetic access$getSequence$p(Lcom/scanflow/datacapture/barinternal/kotlin/sequences/DropSequence;)Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;
    .locals 0

    .line 529
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/DropSequence;->sequence:Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;

    return-object p0
.end method


# virtual methods
.method public drop(I)Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;
    .locals 2

    .line 537
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/DropSequence;->count:I

    add-int/2addr v0, p1

    if-gez v0, :cond_0

    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/DropSequence;

    invoke-direct {v0, p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/DropSequence;-><init>(Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;I)V

    return-object v0

    :cond_0
    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/DropSequence;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/DropSequence;->sequence:Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;

    invoke-direct {p1, v1, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/DropSequence;-><init>(Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;I)V

    return-object p1
.end method

.method public iterator()Ljava/util/Iterator;
    .locals 1

    .line 540
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/DropSequence$iterator$1;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/DropSequence$iterator$1;-><init>(Lcom/scanflow/datacapture/barinternal/kotlin/sequences/DropSequence;)V

    return-object v0
.end method
