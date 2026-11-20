.class public final Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilderValues;
.super Lcom/scanflow/datacapture/barinternal/kotlin/collections/AbstractMutableCollection;
.source "MapBuilder.kt"

# interfaces
.implements Ljava/util/Collection;
.implements Lkotlin/jvm/internal/markers/KMappedMarker;


# instance fields
.field private final backing:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;)V
    .locals 1

    const-string v0, "backing"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 660
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/AbstractMutableCollection;-><init>()V

    .line 661
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilderValues;->backing:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    return-void
.end method


# virtual methods
.method public add(Ljava/lang/Object;)Z
    .locals 0

    .line 667
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    invoke-direct {p1}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw p1
.end method

.method public addAll(Ljava/util/Collection;)Z
    .locals 1

    const-string v0, "elements"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 668
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    invoke-direct {p1}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw p1
.end method

.method public clear()V
    .locals 1

    .line 669
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilderValues;->backing:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;->clear()V

    return-void
.end method

.method public contains(Ljava/lang/Object;)Z
    .locals 1

    .line 666
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilderValues;->backing:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;->containsValue(Ljava/lang/Object;)Z

    move-result p1

    return p1
.end method

.method public getSize()I
    .locals 1

    .line 664
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilderValues;->backing:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;->size()I

    move-result v0

    return v0
.end method

.method public isEmpty()Z
    .locals 1

    .line 665
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilderValues;->backing:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;->isEmpty()Z

    move-result v0

    return v0
.end method

.method public iterator()Ljava/util/Iterator;
    .locals 1

    .line 670
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilderValues;->backing:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;->valuesIterator$kotlin_stdlib()Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$ValuesItr;

    move-result-object v0

    return-object v0
.end method

.method public remove(Ljava/lang/Object;)Z
    .locals 1

    .line 671
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilderValues;->backing:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;->removeValue$kotlin_stdlib(Ljava/lang/Object;)Z

    move-result p1

    return p1
.end method

.method public removeAll(Ljava/util/Collection;)Z
    .locals 1

    const-string v0, "elements"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 674
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilderValues;->backing:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;->checkIsMutable$kotlin_stdlib()V

    .line 675
    invoke-super {p0, p1}, Ljava/util/AbstractCollection;->removeAll(Ljava/util/Collection;)Z

    move-result p1

    return p1
.end method

.method public retainAll(Ljava/util/Collection;)Z
    .locals 1

    const-string v0, "elements"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 679
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilderValues;->backing:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;->checkIsMutable$kotlin_stdlib()V

    .line 680
    invoke-super {p0, p1}, Ljava/util/AbstractCollection;->retainAll(Ljava/util/Collection;)Z

    move-result p1

    return p1
.end method
