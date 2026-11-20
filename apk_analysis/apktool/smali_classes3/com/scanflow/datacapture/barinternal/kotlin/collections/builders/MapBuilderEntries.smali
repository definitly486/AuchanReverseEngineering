.class public final Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilderEntries;
.super Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/AbstractMapBuilderEntrySet;
.source "MapBuilder.kt"


# instance fields
.field private final backing:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;)V
    .locals 1

    const-string v0, "backing"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 690
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/AbstractMapBuilderEntrySet;-><init>()V

    .line 691
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilderEntries;->backing:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    return-void
.end method


# virtual methods
.method public bridge synthetic add(Ljava/lang/Object;)Z
    .locals 0

    .line 690
    check-cast p1, Ljava/util/Map$Entry;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilderEntries;->add(Ljava/util/Map$Entry;)Z

    move-result p1

    return p1
.end method

.method public add(Ljava/util/Map$Entry;)Z
    .locals 1

    const-string v0, "element"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 698
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    invoke-direct {p1}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw p1
.end method

.method public addAll(Ljava/util/Collection;)Z
    .locals 1

    const-string v0, "elements"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 699
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    invoke-direct {p1}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw p1
.end method

.method public clear()V
    .locals 1

    .line 697
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilderEntries;->backing:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;->clear()V

    return-void
.end method

.method public containsAll(Ljava/util/Collection;)Z
    .locals 1

    const-string v0, "elements"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 702
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilderEntries;->backing:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;->containsAllEntries$kotlin_stdlib(Ljava/util/Collection;)Z

    move-result p1

    return p1
.end method

.method public containsEntry(Ljava/util/Map$Entry;)Z
    .locals 1

    const-string v0, "element"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 696
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilderEntries;->backing:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;->containsEntry$kotlin_stdlib(Ljava/util/Map$Entry;)Z

    move-result p1

    return p1
.end method

.method public getSize()I
    .locals 1

    .line 694
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilderEntries;->backing:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;->size()I

    move-result v0

    return v0
.end method

.method public isEmpty()Z
    .locals 1

    .line 695
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilderEntries;->backing:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;->isEmpty()Z

    move-result v0

    return v0
.end method

.method public iterator()Ljava/util/Iterator;
    .locals 1

    .line 701
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilderEntries;->backing:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;->entriesIterator$kotlin_stdlib()Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$EntriesItr;

    move-result-object v0

    return-object v0
.end method

.method public remove(Ljava/util/Map$Entry;)Z
    .locals 1

    const-string v0, "element"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 700
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilderEntries;->backing:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;->removeEntry$kotlin_stdlib(Ljava/util/Map$Entry;)Z

    move-result p1

    return p1
.end method

.method public removeAll(Ljava/util/Collection;)Z
    .locals 1

    const-string v0, "elements"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 705
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilderEntries;->backing:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;->checkIsMutable$kotlin_stdlib()V

    .line 706
    invoke-super {p0, p1}, Ljava/util/AbstractCollection;->removeAll(Ljava/util/Collection;)Z

    move-result p1

    return p1
.end method

.method public retainAll(Ljava/util/Collection;)Z
    .locals 1

    const-string v0, "elements"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 710
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilderEntries;->backing:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;->checkIsMutable$kotlin_stdlib()V

    .line 711
    invoke-super {p0, p1}, Ljava/util/AbstractCollection;->retainAll(Ljava/util/Collection;)Z

    move-result p1

    return p1
.end method
