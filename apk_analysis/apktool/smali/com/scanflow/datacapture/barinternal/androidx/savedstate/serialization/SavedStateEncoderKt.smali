.class public abstract Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoderKt;
.super Ljava/lang/Object;
.source "SavedStateEncoder.kt"


# direct methods
.method public static final encodeToSavedState(Lkotlinx/serialization/SerializationStrategy;Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;)Landroid/os/Bundle;
    .locals 5

    const-string v0, "serializer"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "value"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "configuration"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 283
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/MapsKt;->emptyMap()Ljava/util/Map;

    move-result-object v0

    .line 284
    invoke-interface {v0}, Ljava/util/Map;->isEmpty()Z

    move-result v1

    const/4 v2, 0x0

    if-eqz v1, :cond_0

    .line 285
    new-array v0, v2, [Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    goto :goto_1

    .line 288
    :cond_0
    new-instance v1, Ljava/util/ArrayList;

    invoke-interface {v0}, Ljava/util/Map;->size()I

    move-result v3

    invoke-direct {v1, v3}, Ljava/util/ArrayList;-><init>(I)V

    .line 289
    invoke-interface {v0}, Ljava/util/Map;->entrySet()Ljava/util/Set;

    move-result-object v0

    invoke-interface {v0}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object v0

    :goto_0
    invoke-interface {v0}, Ljava/util/Iterator;->hasNext()Z

    move-result v3

    if-eqz v3, :cond_1

    invoke-interface {v0}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/util/Map$Entry;

    .line 290
    invoke-interface {v3}, Ljava/util/Map$Entry;->getKey()Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Ljava/lang/String;

    invoke-interface {v3}, Ljava/util/Map$Entry;->getValue()Ljava/lang/Object;

    move-result-object v3

    .line 287
    invoke-static {v4, v3}, Lcom/scanflow/datacapture/barinternal/kotlin/TuplesKt;->to(Ljava/lang/Object;Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    move-result-object v3

    .line 290
    invoke-interface {v1, v3}, Ljava/util/Collection;->add(Ljava/lang/Object;)Z

    goto :goto_0

    .line 293
    :cond_1
    new-array v0, v2, [Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    invoke-interface {v1, v0}, Ljava/util/Collection;->toArray([Ljava/lang/Object;)[Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    .line 300
    :goto_1
    array-length v1, v0

    invoke-static {v0, v1}, Ljava/util/Arrays;->copyOf([Ljava/lang/Object;I)[Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/core/os/BundleKt;->bundleOf([Lcom/scanflow/datacapture/barinternal/kotlin/Pair;)Landroid/os/Bundle;

    move-result-object v0

    .line 302
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    .line 68
    new-instance v1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;

    invoke-direct {v1, v0, p2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;-><init>(Landroid/os/Bundle;Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;)V

    invoke-virtual {v1, p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->encodeSerializableValue(Lkotlinx/serialization/SerializationStrategy;Ljava/lang/Object;)V

    return-object v0
.end method
