.class public abstract Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder_androidKt;
.super Ljava/lang/Object;
.source "SavedStateEncoder.android.kt"


# direct methods
.method public static final encodeFormatSpecificTypesOnPlatform(Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;Lkotlinx/serialization/SerializationStrategy;Ljava/lang/Object;)Z
    .locals 1

    const-string v0, "<this>"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "strategy"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 38
    invoke-interface {p1}, Lkotlinx/serialization/SerializationStrategy;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object p1

    .line 39
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->getPolymorphicCharSequenceDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 40
    sget-object p1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/CharSequenceSerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/CharSequenceSerializer;

    const-string v0, "null cannot be cast to non-null type kotlin.CharSequence"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast p2, Ljava/lang/CharSequence;

    invoke-virtual {p1, p0, p2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/CharSequenceSerializer;->serialize(Lkotlinx/serialization/encoding/Encoder;Ljava/lang/CharSequence;)V

    goto/16 :goto_5

    .line 41
    :cond_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->getPolymorphicParcelableDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_1

    .line 42
    sget-object p1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/DefaultParcelableSerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/DefaultParcelableSerializer;

    const-string v0, "null cannot be cast to non-null type android.os.Parcelable"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast p2, Landroid/os/Parcelable;

    invoke-virtual {p1, p0, p2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/ParcelableSerializer;->serialize(Lkotlinx/serialization/encoding/Encoder;Landroid/os/Parcelable;)V

    goto/16 :goto_5

    .line 43
    :cond_1
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->getPolymorphicJavaSerializableDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_2

    .line 44
    sget-object p1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/DefaultJavaSerializableSerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/DefaultJavaSerializableSerializer;

    const-string v0, "null cannot be cast to non-null type java.io.Serializable"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast p2, Ljava/io/Serializable;

    invoke-virtual {p1, p0, p2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/JavaSerializableSerializer;->serialize(Lkotlinx/serialization/encoding/Encoder;Ljava/io/Serializable;)V

    goto/16 :goto_5

    .line 45
    :cond_2
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->getPolymorphicIBinderDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_3

    sget-object p1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/IBinderSerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/IBinderSerializer;

    const-string v0, "null cannot be cast to non-null type android.os.IBinder"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast p2, Landroid/os/IBinder;

    invoke-virtual {p1, p0, p2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/IBinderSerializer;->serialize(Lkotlinx/serialization/encoding/Encoder;Landroid/os/IBinder;)V

    goto/16 :goto_5

    .line 46
    :cond_3
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->getCharSequenceArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_d

    .line 47
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->getPolymorphicCharSequenceArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_4

    goto/16 :goto_4

    .line 49
    :cond_4
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->getCharSequenceListDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_c

    .line 50
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->getPolymorphicCharSequenceListDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_5

    goto/16 :goto_3

    .line 52
    :cond_5
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->getParcelableArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_b

    .line 53
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->getPolymorphicParcelableArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_6

    goto :goto_2

    .line 55
    :cond_6
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->getParcelableListDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_a

    .line 56
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->getPolymorphicParcelableListDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_7

    goto :goto_1

    .line 58
    :cond_7
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->getSparseParcelableArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_9

    .line 59
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->getPolymorphicSparseParcelableArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_9

    .line 60
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->getNullablePolymorphicSparseParcelableArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result p1

    if-eqz p1, :cond_8

    goto :goto_0

    :cond_8
    const/4 p0, 0x0

    return p0

    .line 61
    :cond_9
    :goto_0
    sget-object p1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseParcelableArraySerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseParcelableArraySerializer;

    .line 63
    const-string v0, "null cannot be cast to non-null type android.util.SparseArray<android.os.Parcelable>"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast p2, Landroid/util/SparseArray;

    .line 61
    invoke-virtual {p1, p0, p2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseParcelableArraySerializer;->serialize(Lkotlinx/serialization/encoding/Encoder;Landroid/util/SparseArray;)V

    goto :goto_5

    .line 57
    :cond_a
    :goto_1
    sget-object p1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/ParcelableListSerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/ParcelableListSerializer;

    const-string v0, "null cannot be cast to non-null type kotlin.collections.List<android.os.Parcelable>"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast p2, Ljava/util/List;

    invoke-virtual {p1, p0, p2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/ParcelableListSerializer;->serialize(Lkotlinx/serialization/encoding/Encoder;Ljava/util/List;)V

    goto :goto_5

    .line 54
    :cond_b
    :goto_2
    sget-object p1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/ParcelableArraySerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/ParcelableArraySerializer;

    const-string v0, "null cannot be cast to non-null type kotlin.Array<android.os.Parcelable>"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast p2, [Landroid/os/Parcelable;

    invoke-virtual {p1, p0, p2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/ParcelableArraySerializer;->serialize(Lkotlinx/serialization/encoding/Encoder;[Landroid/os/Parcelable;)V

    goto :goto_5

    .line 51
    :cond_c
    :goto_3
    sget-object p1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/CharSequenceListSerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/CharSequenceListSerializer;

    const-string v0, "null cannot be cast to non-null type kotlin.collections.List<kotlin.CharSequence>"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast p2, Ljava/util/List;

    invoke-virtual {p1, p0, p2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/CharSequenceListSerializer;->serialize(Lkotlinx/serialization/encoding/Encoder;Ljava/util/List;)V

    goto :goto_5

    .line 48
    :cond_d
    :goto_4
    sget-object p1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/CharSequenceArraySerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/CharSequenceArraySerializer;

    const-string v0, "null cannot be cast to non-null type kotlin.Array<kotlin.CharSequence>"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast p2, [Ljava/lang/CharSequence;

    invoke-virtual {p1, p0, p2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/CharSequenceArraySerializer;->serialize(Lkotlinx/serialization/encoding/Encoder;[Ljava/lang/CharSequence;)V

    :goto_5
    const/4 p0, 0x1

    return p0
.end method
