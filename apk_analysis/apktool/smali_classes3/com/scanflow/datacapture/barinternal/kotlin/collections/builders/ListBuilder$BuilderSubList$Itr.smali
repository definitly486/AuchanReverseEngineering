.class final Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;
.super Ljava/lang/Object;
.source "ListBuilder.kt"

# interfaces
.implements Ljava/util/ListIterator;
.implements Lkotlin/jvm/internal/markers/KMappedMarker;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x1a
    name = "Itr"
.end annotation


# instance fields
.field private expectedModCount:I

.field private index:I

.field private lastIndex:I

.field private final list:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;I)V
    .locals 1

    const-string v0, "list"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 564
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 565
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->list:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;

    .line 566
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->index:I

    const/4 p2, -0x1

    .line 568
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->lastIndex:I

    .line 569
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->access$getModCount$p$s1462993667(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;)I

    move-result p1

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->expectedModCount:I

    return-void
.end method

.method private final checkForComodification()V
    .locals 2

    .line 614
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->list:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->access$getRoot$p(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;)Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;

    move-result-object v0

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;->access$getModCount$p$s-2084097795(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;)I

    move-result v0

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->expectedModCount:I

    if-ne v0, v1, :cond_0

    return-void

    .line 615
    :cond_0
    new-instance v0, Ljava/util/ConcurrentModificationException;

    invoke-direct {v0}, Ljava/util/ConcurrentModificationException;-><init>()V

    throw v0
.end method


# virtual methods
.method public add(Ljava/lang/Object;)V
    .locals 3

    .line 598
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->checkForComodification()V

    .line 599
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->list:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->index:I

    add-int/lit8 v2, v1, 0x1

    iput v2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->index:I

    invoke-virtual {v0, v1, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->add(ILjava/lang/Object;)V

    const/4 p1, -0x1

    .line 600
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->lastIndex:I

    .line 601
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->list:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->access$getModCount$p$s1462993667(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;)I

    move-result p1

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->expectedModCount:I

    return-void
.end method

.method public hasNext()Z
    .locals 2

    .line 572
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->index:I

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->list:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;

    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->access$getLength$p(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;)I

    move-result v1

    if-ge v0, v1, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasPrevious()Z
    .locals 1

    .line 571
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->index:I

    if-lez v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public next()Ljava/lang/Object;
    .locals 3

    .line 585
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->checkForComodification()V

    .line 586
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->index:I

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->list:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;

    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->access$getLength$p(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;)I

    move-result v1

    if-ge v0, v1, :cond_0

    .line 587
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->index:I

    add-int/lit8 v1, v0, 0x1

    iput v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->index:I

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->lastIndex:I

    .line 588
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->list:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->access$getBacking$p(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;)[Ljava/lang/Object;

    move-result-object v0

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->list:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;

    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->access$getOffset$p(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;)I

    move-result v1

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->lastIndex:I

    add-int/2addr v1, v2

    aget-object v0, v0, v1

    return-object v0

    .line 586
    :cond_0
    new-instance v0, Ljava/util/NoSuchElementException;

    invoke-direct {v0}, Ljava/util/NoSuchElementException;-><init>()V

    throw v0
.end method

.method public nextIndex()I
    .locals 1

    .line 575
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->index:I

    return v0
.end method

.method public previous()Ljava/lang/Object;
    .locals 3

    .line 578
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->checkForComodification()V

    .line 579
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->index:I

    if-lez v0, :cond_0

    add-int/lit8 v0, v0, -0x1

    .line 580
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->index:I

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->lastIndex:I

    .line 581
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->list:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->access$getBacking$p(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;)[Ljava/lang/Object;

    move-result-object v0

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->list:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;

    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->access$getOffset$p(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;)I

    move-result v1

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->lastIndex:I

    add-int/2addr v1, v2

    aget-object v0, v0, v1

    return-object v0

    .line 579
    :cond_0
    new-instance v0, Ljava/util/NoSuchElementException;

    invoke-direct {v0}, Ljava/util/NoSuchElementException;-><init>()V

    throw v0
.end method

.method public previousIndex()I
    .locals 1

    .line 574
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->index:I

    add-int/lit8 v0, v0, -0x1

    return v0
.end method

.method public remove()V
    .locals 3

    .line 605
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->checkForComodification()V

    .line 606
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->lastIndex:I

    const/4 v1, -0x1

    if-eq v0, v1, :cond_0

    .line 607
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->list:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;

    invoke-virtual {v2, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->removeAt(I)Ljava/lang/Object;

    .line 608
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->lastIndex:I

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->index:I

    .line 609
    iput v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->lastIndex:I

    .line 610
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->list:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->access$getModCount$p$s1462993667(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;)I

    move-result v0

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->expectedModCount:I

    return-void

    .line 606
    :cond_0
    new-instance v0, Ljava/lang/IllegalStateException;

    const-string v1, "Call next() or previous() before removing element from the iterator."

    invoke-direct {v0, v1}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method public set(Ljava/lang/Object;)V
    .locals 2

    .line 592
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->checkForComodification()V

    .line 593
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->lastIndex:I

    const/4 v1, -0x1

    if-eq v0, v1, :cond_0

    .line 594
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;->list:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;

    invoke-virtual {v1, v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->set(ILjava/lang/Object;)Ljava/lang/Object;

    return-void

    .line 593
    :cond_0
    new-instance p1, Ljava/lang/IllegalStateException;

    const-string v0, "Call next() or previous() before replacing element from the iterator."

    invoke-direct {p1, v0}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw p1
.end method
