.class public final Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/SetBuilder;
.super Lcom/scanflow/datacapture/barinternal/kotlin/collections/AbstractMutableSet;
.source "SetBuilder.kt"

# interfaces
.implements Ljava/util/Set;
.implements Ljava/io/Serializable;
.implements Lkotlin/jvm/internal/markers/KMappedMarker;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/SetBuilder$Companion;
    }
.end annotation


# static fields
.field private static final Companion:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/SetBuilder$Companion;

.field private static final Empty:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/SetBuilder;


# instance fields
.field private final backing:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/SetBuilder$Companion;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/SetBuilder$Companion;-><init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/SetBuilder;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/SetBuilder$Companion;

    .line 16
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/SetBuilder;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Companion;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Companion;->getEmpty$kotlin_stdlib()Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    move-result-object v1

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/SetBuilder;-><init>(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/SetBuilder;->Empty:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/SetBuilder;

    return-void
.end method

.method public constructor <init>()V
    .locals 1

    .line 19
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;-><init>()V

    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/SetBuilder;-><init>(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;)V

    return-void
.end method

.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;)V
    .locals 1

    const-string v0, "backing"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 12
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/AbstractMutableSet;-><init>()V

    .line 13
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/SetBuilder;->backing:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    return-void
.end method


# virtual methods
.method public add(Ljava/lang/Object;)Z
    .locals 1

    .line 40
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/SetBuilder;->backing:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;->addKey$kotlin_stdlib(Ljava/lang/Object;)I

    move-result p1

    if-ltz p1, :cond_0

    const/4 p1, 0x1

    return p1

    :cond_0
    const/4 p1, 0x0

    return p1
.end method

.method public addAll(Ljava/util/Collection;)Z
    .locals 1

    const-string v0, "elements"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 45
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/SetBuilder;->backing:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;->checkIsMutable$kotlin_stdlib()V

    .line 46
    invoke-super {p0, p1}, Ljava/util/AbstractCollection;->addAll(Ljava/util/Collection;)Z

    move-result p1

    return p1
.end method

.method public final build()Ljava/util/Set;
    .locals 1

    .line 24
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/SetBuilder;->backing:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;->build()Ljava/util/Map;

    .line 25
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/AbstractMutableSet;->size()I

    move-result v0

    if-lez v0, :cond_0

    return-object p0

    :cond_0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/SetBuilder;->Empty:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/SetBuilder;

    return-object v0
.end method

.method public clear()V
    .locals 1

    .line 39
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/SetBuilder;->backing:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;->clear()V

    return-void
.end method

.method public contains(Ljava/lang/Object;)Z
    .locals 1

    .line 38
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/SetBuilder;->backing:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;->containsKey(Ljava/lang/Object;)Z

    move-result p1

    return p1
.end method

.method public getSize()I
    .locals 1

    .line 36
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/SetBuilder;->backing:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;->size()I

    move-result v0

    return v0
.end method

.method public isEmpty()Z
    .locals 1

    .line 37
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/SetBuilder;->backing:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;->isEmpty()Z

    move-result v0

    return v0
.end method

.method public iterator()Ljava/util/Iterator;
    .locals 1

    .line 42
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/SetBuilder;->backing:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;->keysIterator$kotlin_stdlib()Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$KeysItr;

    move-result-object v0

    return-object v0
.end method

.method public remove(Ljava/lang/Object;)Z
    .locals 1

    .line 41
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/SetBuilder;->backing:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;->removeKey$kotlin_stdlib(Ljava/lang/Object;)Z

    move-result p1

    return p1
.end method

.method public removeAll(Ljava/util/Collection;)Z
    .locals 1

    const-string v0, "elements"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 50
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/SetBuilder;->backing:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;->checkIsMutable$kotlin_stdlib()V

    .line 51
    invoke-super {p0, p1}, Ljava/util/AbstractCollection;->removeAll(Ljava/util/Collection;)Z

    move-result p1

    return p1
.end method

.method public retainAll(Ljava/util/Collection;)Z
    .locals 1

    const-string v0, "elements"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 55
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/SetBuilder;->backing:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;->checkIsMutable$kotlin_stdlib()V

    .line 56
    invoke-super {p0, p1}, Ljava/util/AbstractCollection;->retainAll(Ljava/util/Collection;)Z

    move-result p1

    return p1
.end method
