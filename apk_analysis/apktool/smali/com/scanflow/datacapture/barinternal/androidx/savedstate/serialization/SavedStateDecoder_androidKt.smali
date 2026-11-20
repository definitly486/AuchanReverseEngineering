.class public abstract Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder_androidKt;
.super Ljava/lang/Object;
.source "SavedStateDecoder.android.kt"


# direct methods
.method public static final decodeFormatSpecificTypesOnPlatform(Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;Lkotlinx/serialization/DeserializationStrategy;)Ljava/lang/Object;
    .locals 2

    const-string v0, "<this>"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "strategy"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 42
    invoke-interface {p1}, Lkotlinx/serialization/DeserializationStrategy;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    .line 43
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->getPolymorphicCharSequenceDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v1

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_0

    sget-object p1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/CharSequenceSerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/CharSequenceSerializer;

    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/CharSequenceSerializer;->deserialize(Lkotlinx/serialization/encoding/Decoder;)Ljava/lang/CharSequence;

    move-result-object p0

    return-object p0

    .line 44
    :cond_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->getPolymorphicParcelableDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v1

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_1

    sget-object p1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/DefaultParcelableSerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/DefaultParcelableSerializer;

    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/ParcelableSerializer;->deserialize(Lkotlinx/serialization/encoding/Decoder;)Landroid/os/Parcelable;

    move-result-object p0

    return-object p0

    .line 45
    :cond_1
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->getPolymorphicJavaSerializableDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v1

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_2

    sget-object p1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/DefaultJavaSerializableSerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/DefaultJavaSerializableSerializer;

    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/JavaSerializableSerializer;->deserialize(Lkotlinx/serialization/encoding/Decoder;)Ljava/io/Serializable;

    move-result-object p0

    return-object p0

    .line 46
    :cond_2
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->getPolymorphicIBinderDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v1

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_3

    sget-object p1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/IBinderSerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/IBinderSerializer;

    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/IBinderSerializer;->deserialize(Lkotlinx/serialization/encoding/Decoder;)Landroid/os/IBinder;

    move-result-object p0

    return-object p0

    .line 47
    :cond_3
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->getCharSequenceArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v1

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_d

    .line 48
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->getPolymorphicCharSequenceArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v1

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_4

    goto/16 :goto_3

    .line 49
    :cond_4
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->getCharSequenceListDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v1

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_c

    .line 50
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->getPolymorphicCharSequenceListDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v1

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_5

    goto/16 :goto_2

    .line 51
    :cond_5
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->getParcelableArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v1

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_6

    .line 52
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/ParcelableArraySerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/ParcelableArraySerializer;

    invoke-virtual {v0, p0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/ParcelableArraySerializer;->deserialize(Lkotlinx/serialization/encoding/Decoder;)[Landroid/os/Parcelable;

    move-result-object p0

    .line 53
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder_androidKt;->getArrayKClass(Lkotlinx/serialization/DeserializationStrategy;)Lkotlin/reflect/KClass;

    move-result-object p1

    .line 54
    array-length v0, p0

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/jvm/JvmClassMappingKt;->getJavaClass(Lkotlin/reflect/KClass;)Ljava/lang/Class;

    move-result-object p1

    invoke-static {p0, v0, p1}, Ljava/util/Arrays;->copyOf([Ljava/lang/Object;ILjava/lang/Class;)[Ljava/lang/Object;

    move-result-object p0

    return-object p0

    .line 56
    :cond_6
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->getPolymorphicParcelableArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object p1

    invoke-static {v0, p1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result p1

    if-eqz p1, :cond_7

    sget-object p1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/ParcelableArraySerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/ParcelableArraySerializer;

    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/ParcelableArraySerializer;->deserialize(Lkotlinx/serialization/encoding/Decoder;)[Landroid/os/Parcelable;

    move-result-object p0

    return-object p0

    .line 57
    :cond_7
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->getParcelableListDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object p1

    invoke-static {v0, p1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result p1

    if-nez p1, :cond_b

    .line 58
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->getPolymorphicParcelableListDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object p1

    invoke-static {v0, p1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result p1

    if-eqz p1, :cond_8

    goto :goto_1

    .line 59
    :cond_8
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->getSparseParcelableArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object p1

    invoke-static {v0, p1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result p1

    if-nez p1, :cond_a

    .line 60
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->getPolymorphicSparseParcelableArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object p1

    invoke-static {v0, p1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result p1

    if-nez p1, :cond_a

    .line 61
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->getNullablePolymorphicSparseParcelableArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object p1

    invoke-static {v0, p1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result p1

    if-eqz p1, :cond_9

    goto :goto_0

    :cond_9
    const/4 p0, 0x0

    return-object p0

    .line 62
    :cond_a
    :goto_0
    sget-object p1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseParcelableArraySerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseParcelableArraySerializer;

    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseParcelableArraySerializer;->deserialize(Lkotlinx/serialization/encoding/Decoder;)Landroid/util/SparseArray;

    move-result-object p0

    return-object p0

    .line 58
    :cond_b
    :goto_1
    sget-object p1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/ParcelableListSerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/ParcelableListSerializer;

    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/ParcelableListSerializer;->deserialize(Lkotlinx/serialization/encoding/Decoder;)Ljava/util/List;

    move-result-object p0

    return-object p0

    .line 50
    :cond_c
    :goto_2
    sget-object p1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/CharSequenceListSerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/CharSequenceListSerializer;

    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/CharSequenceListSerializer;->deserialize(Lkotlinx/serialization/encoding/Decoder;)Ljava/util/List;

    move-result-object p0

    return-object p0

    .line 48
    :cond_d
    :goto_3
    sget-object p1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/CharSequenceArraySerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/CharSequenceArraySerializer;

    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/CharSequenceArraySerializer;->deserialize(Lkotlinx/serialization/encoding/Decoder;)[Ljava/lang/CharSequence;

    move-result-object p0

    return-object p0
.end method

.method private static final getArrayKClass(Lkotlinx/serialization/DeserializationStrategy;)Lkotlin/reflect/KClass;
    .locals 1

    .line 75
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/EmptyArrayDecoder;->INSTANCE:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/EmptyArrayDecoder;

    invoke-interface {p0, v0}, Lkotlinx/serialization/DeserializationStrategy;->deserialize(Lkotlinx/serialization/encoding/Decoder;)Ljava/lang/Object;

    move-result-object p0

    invoke-static {p0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object p0

    invoke-static {p0}, Lkotlin/jvm/internal/Reflection;->getOrCreateKotlinClass(Ljava/lang/Class;)Lkotlin/reflect/KClass;

    move-result-object p0

    return-object p0
.end method
