.class public final Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$EntriesItr;
.super Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;
.source "MapBuilder.kt"

# interfaces
.implements Ljava/util/Iterator;
.implements Lkotlin/jvm/internal/markers/KMappedMarker;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "EntriesItr"
.end annotation


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;)V
    .locals 1

    const-string v0, "map"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 562
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;-><init>(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;)V

    return-void
.end method


# virtual methods
.method public next()Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$EntryRef;
    .locals 3

    .line 565
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->checkForComodification$kotlin_stdlib()V

    .line 566
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->getIndex$kotlin_stdlib()I

    move-result v0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->getMap$kotlin_stdlib()Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    move-result-object v1

    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;->access$getLength$p(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;)I

    move-result v1

    if-ge v0, v1, :cond_0

    .line 567
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->getIndex$kotlin_stdlib()I

    move-result v0

    add-int/lit8 v1, v0, 0x1

    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->setIndex$kotlin_stdlib(I)V

    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->setLastIndex$kotlin_stdlib(I)V

    .line 568
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$EntryRef;

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->getMap$kotlin_stdlib()Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    move-result-object v1

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->getLastIndex$kotlin_stdlib()I

    move-result v2

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$EntryRef;-><init>(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;I)V

    .line 569
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->initNext$kotlin_stdlib()V

    return-object v0

    .line 566
    :cond_0
    new-instance v0, Ljava/util/NoSuchElementException;

    invoke-direct {v0}, Ljava/util/NoSuchElementException;-><init>()V

    throw v0
.end method

.method public bridge synthetic next()Ljava/lang/Object;
    .locals 1

    .line 562
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$EntriesItr;->next()Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$EntryRef;

    move-result-object v0

    return-object v0
.end method

.method public final nextAppendString(Ljava/lang/StringBuilder;)V
    .locals 3

    const-string v0, "sb"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 582
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->getIndex$kotlin_stdlib()I

    move-result v0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->getMap$kotlin_stdlib()Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    move-result-object v1

    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;->access$getLength$p(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;)I

    move-result v1

    if-ge v0, v1, :cond_2

    .line 583
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->getIndex$kotlin_stdlib()I

    move-result v0

    add-int/lit8 v1, v0, 0x1

    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->setIndex$kotlin_stdlib(I)V

    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->setLastIndex$kotlin_stdlib(I)V

    .line 584
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->getMap$kotlin_stdlib()Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    move-result-object v0

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;->access$getKeysArray$p(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;)[Ljava/lang/Object;

    move-result-object v0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->getLastIndex$kotlin_stdlib()I

    move-result v1

    aget-object v0, v0, v1

    .line 585
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->getMap$kotlin_stdlib()Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    move-result-object v1

    const-string v2, "(this Map)"

    if-ne v0, v1, :cond_0

    invoke-virtual {p1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    goto :goto_0

    :cond_0
    invoke-virtual {p1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    :goto_0
    const/16 v0, 0x3d

    .line 586
    invoke-virtual {p1, v0}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    .line 587
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->getMap$kotlin_stdlib()Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    move-result-object v0

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;->access$getValuesArray$p(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;)[Ljava/lang/Object;

    move-result-object v0

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->getLastIndex$kotlin_stdlib()I

    move-result v1

    aget-object v0, v0, v1

    .line 588
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->getMap$kotlin_stdlib()Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    move-result-object v1

    if-ne v0, v1, :cond_1

    invoke-virtual {p1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    goto :goto_1

    :cond_1
    invoke-virtual {p1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    .line 589
    :goto_1
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->initNext$kotlin_stdlib()V

    return-void

    .line 582
    :cond_2
    new-instance p1, Ljava/util/NoSuchElementException;

    invoke-direct {p1}, Ljava/util/NoSuchElementException;-><init>()V

    throw p1
.end method

.method public final nextHashCode$kotlin_stdlib()I
    .locals 4

    .line 574
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->getIndex$kotlin_stdlib()I

    move-result v0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->getMap$kotlin_stdlib()Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    move-result-object v1

    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;->access$getLength$p(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;)I

    move-result v1

    if-ge v0, v1, :cond_2

    .line 575
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->getIndex$kotlin_stdlib()I

    move-result v0

    add-int/lit8 v1, v0, 0x1

    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->setIndex$kotlin_stdlib(I)V

    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->setLastIndex$kotlin_stdlib(I)V

    .line 576
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->getMap$kotlin_stdlib()Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    move-result-object v0

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;->access$getKeysArray$p(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;)[Ljava/lang/Object;

    move-result-object v0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->getLastIndex$kotlin_stdlib()I

    move-result v1

    aget-object v0, v0, v1

    const/4 v1, 0x0

    if-eqz v0, :cond_0

    invoke-virtual {v0}, Ljava/lang/Object;->hashCode()I

    move-result v0

    goto :goto_0

    :cond_0
    move v0, v1

    :goto_0
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->getMap$kotlin_stdlib()Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    move-result-object v2

    invoke-static {v2}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;->access$getValuesArray$p(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;)[Ljava/lang/Object;

    move-result-object v2

    invoke-static {v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->getLastIndex$kotlin_stdlib()I

    move-result v3

    aget-object v2, v2, v3

    if-eqz v2, :cond_1

    invoke-virtual {v2}, Ljava/lang/Object;->hashCode()I

    move-result v1

    :cond_1
    xor-int/2addr v0, v1

    .line 577
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->initNext$kotlin_stdlib()V

    return v0

    .line 574
    :cond_2
    new-instance v0, Ljava/util/NoSuchElementException;

    invoke-direct {v0}, Ljava/util/NoSuchElementException;-><init>()V

    throw v0
.end method
