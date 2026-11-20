.class final Landroidx/collection/MutableMapWrapper;
.super Landroidx/collection/MapWrapper;
.source "ScatterMap.kt"

# interfaces
.implements Ljava/util/Map;
.implements Lcom/scanflow/datacapture/barinternal/kotlin/jvm/internal/markers/KMutableMap;


# instance fields
.field private _entries:Landroidx/collection/MutableEntries;

.field private _keys:Landroidx/collection/MutableKeys;

.field private _values:Landroidx/collection/MutableValues;

.field private final parent:Landroidx/collection/MutableScatterMap;


# direct methods
.method public constructor <init>(Landroidx/collection/MutableScatterMap;)V
    .locals 1

    const-string v0, "parent"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 1763
    invoke-direct {p0, p1}, Landroidx/collection/MapWrapper;-><init>(Landroidx/collection/ScatterMap;)V

    .line 1762
    iput-object p1, p0, Landroidx/collection/MutableMapWrapper;->parent:Landroidx/collection/MutableScatterMap;

    return-void
.end method


# virtual methods
.method public clear()V
    .locals 1

    .line 1777
    iget-object v0, p0, Landroidx/collection/MutableMapWrapper;->parent:Landroidx/collection/MutableScatterMap;

    invoke-virtual {v0}, Landroidx/collection/MutableScatterMap;->clear()V

    return-void
.end method

.method public getEntries()Ljava/util/Set;
    .locals 2

    .line 1767
    iget-object v0, p0, Landroidx/collection/MutableMapWrapper;->_entries:Landroidx/collection/MutableEntries;

    if-eqz v0, :cond_0

    return-object v0

    :cond_0
    new-instance v0, Landroidx/collection/MutableEntries;

    iget-object v1, p0, Landroidx/collection/MutableMapWrapper;->parent:Landroidx/collection/MutableScatterMap;

    invoke-direct {v0, v1}, Landroidx/collection/MutableEntries;-><init>(Landroidx/collection/MutableScatterMap;)V

    iput-object v0, p0, Landroidx/collection/MutableMapWrapper;->_entries:Landroidx/collection/MutableEntries;

    return-object v0
.end method

.method public getKeys()Ljava/util/Set;
    .locals 2

    .line 1771
    iget-object v0, p0, Landroidx/collection/MutableMapWrapper;->_keys:Landroidx/collection/MutableKeys;

    if-eqz v0, :cond_0

    return-object v0

    :cond_0
    new-instance v0, Landroidx/collection/MutableKeys;

    iget-object v1, p0, Landroidx/collection/MutableMapWrapper;->parent:Landroidx/collection/MutableScatterMap;

    invoke-direct {v0, v1}, Landroidx/collection/MutableKeys;-><init>(Landroidx/collection/MutableScatterMap;)V

    iput-object v0, p0, Landroidx/collection/MutableMapWrapper;->_keys:Landroidx/collection/MutableKeys;

    return-object v0
.end method

.method public getValues()Ljava/util/Collection;
    .locals 2

    .line 1775
    iget-object v0, p0, Landroidx/collection/MutableMapWrapper;->_values:Landroidx/collection/MutableValues;

    if-eqz v0, :cond_0

    return-object v0

    :cond_0
    new-instance v0, Landroidx/collection/MutableValues;

    iget-object v1, p0, Landroidx/collection/MutableMapWrapper;->parent:Landroidx/collection/MutableScatterMap;

    invoke-direct {v0, v1}, Landroidx/collection/MutableValues;-><init>(Landroidx/collection/MutableScatterMap;)V

    iput-object v0, p0, Landroidx/collection/MutableMapWrapper;->_values:Landroidx/collection/MutableValues;

    return-object v0
.end method

.method public put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 1

    .line 1785
    iget-object v0, p0, Landroidx/collection/MutableMapWrapper;->parent:Landroidx/collection/MutableScatterMap;

    invoke-virtual {v0, p1, p2}, Landroidx/collection/MutableScatterMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method

.method public putAll(Ljava/util/Map;)V
    .locals 3

    const-string v0, "from"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 1789
    invoke-interface {p1}, Ljava/util/Map;->entrySet()Ljava/util/Set;

    move-result-object p1

    invoke-interface {p1}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object p1

    :goto_0
    invoke-interface {p1}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-interface {p1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/util/Map$Entry;

    .line 1782
    invoke-interface {v0}, Ljava/util/Map$Entry;->getKey()Ljava/lang/Object;

    move-result-object v1

    invoke-interface {v0}, Ljava/util/Map$Entry;->getValue()Ljava/lang/Object;

    move-result-object v0

    iget-object v2, p0, Landroidx/collection/MutableMapWrapper;->parent:Landroidx/collection/MutableScatterMap;

    invoke-virtual {v2, v1, v0}, Landroidx/collection/MutableScatterMap;->set(Ljava/lang/Object;Ljava/lang/Object;)V

    goto :goto_0

    :cond_0
    return-void
.end method

.method public remove(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 1

    .line 1779
    iget-object v0, p0, Landroidx/collection/MutableMapWrapper;->parent:Landroidx/collection/MutableScatterMap;

    invoke-virtual {v0, p1}, Landroidx/collection/MutableScatterMap;->remove(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method
