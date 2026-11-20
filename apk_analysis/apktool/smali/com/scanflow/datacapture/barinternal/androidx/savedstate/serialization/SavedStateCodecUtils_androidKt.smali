.class public abstract Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;
.super Ljava/lang/Object;
.source "SavedStateCodecUtils.android.kt"


# static fields
.field private static final charSequenceArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

.field private static final charSequenceListDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

.field private static final nullablePolymorphicSparseParcelableArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

.field private static final parcelableArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

.field private static final parcelableListDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

.field private static final polymorphicCharSequenceArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

.field private static final polymorphicCharSequenceDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

.field private static final polymorphicCharSequenceListDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

.field private static final polymorphicIBinderDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

.field private static final polymorphicJavaSerializableDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

.field private static final polymorphicParcelableArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

.field private static final polymorphicParcelableDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

.field private static final polymorphicParcelableListDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

.field private static final polymorphicSparseParcelableArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

.field private static final sparseParcelableArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;


# direct methods
.method static constructor <clinit>()V
    .locals 6

    .line 32
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;

    const-class v1, Ljava/lang/CharSequence;

    invoke-static {v1}, Lkotlin/jvm/internal/Reflection;->getOrCreateKotlinClass(Ljava/lang/Class;)Lkotlin/reflect/KClass;

    move-result-object v2

    invoke-direct {v0, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;-><init>(Lkotlin/reflect/KClass;)V

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->polymorphicCharSequenceDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    .line 34
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;

    const-class v2, Landroid/os/Parcelable;

    invoke-static {v2}, Lkotlin/jvm/internal/Reflection;->getOrCreateKotlinClass(Ljava/lang/Class;)Lkotlin/reflect/KClass;

    move-result-object v3

    invoke-direct {v0, v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;-><init>(Lkotlin/reflect/KClass;)V

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->polymorphicParcelableDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    .line 37
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;

    const-class v3, Ljava/io/Serializable;

    invoke-static {v3}, Lkotlin/jvm/internal/Reflection;->getOrCreateKotlinClass(Ljava/lang/Class;)Lkotlin/reflect/KClass;

    move-result-object v3

    invoke-direct {v0, v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;-><init>(Lkotlin/reflect/KClass;)V

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->polymorphicJavaSerializableDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    .line 39
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;

    const-class v3, Landroid/os/IBinder;

    invoke-static {v3}, Lkotlin/jvm/internal/Reflection;->getOrCreateKotlinClass(Ljava/lang/Class;)Lkotlin/reflect/KClass;

    move-result-object v3

    invoke-direct {v0, v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;-><init>(Lkotlin/reflect/KClass;)V

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->polymorphicIBinderDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    .line 42
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/DefaultParcelableSerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/DefaultParcelableSerializer;

    invoke-static {v2}, Lkotlin/jvm/internal/Reflection;->getOrCreateKotlinClass(Ljava/lang/Class;)Lkotlin/reflect/KClass;

    move-result-object v3

    .line 68
    invoke-static {v3, v0}, Lkotlinx/serialization/builtins/BuiltinSerializersKt;->ArraySerializer(Lkotlin/reflect/KClass;Lkotlinx/serialization/KSerializer;)Lkotlinx/serialization/KSerializer;

    move-result-object v3

    .line 42
    invoke-interface {v3}, Lkotlinx/serialization/KSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v3

    sput-object v3, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->parcelableArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    .line 45
    new-instance v3, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;

    invoke-static {v2}, Lkotlin/jvm/internal/Reflection;->getOrCreateKotlinClass(Ljava/lang/Class;)Lkotlin/reflect/KClass;

    move-result-object v4

    invoke-direct {v3, v4}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;-><init>(Lkotlin/reflect/KClass;)V

    invoke-static {v2}, Lkotlin/jvm/internal/Reflection;->getOrCreateKotlinClass(Ljava/lang/Class;)Lkotlin/reflect/KClass;

    move-result-object v4

    .line 69
    invoke-static {v4, v3}, Lkotlinx/serialization/builtins/BuiltinSerializersKt;->ArraySerializer(Lkotlin/reflect/KClass;Lkotlinx/serialization/KSerializer;)Lkotlinx/serialization/KSerializer;

    move-result-object v3

    .line 45
    invoke-interface {v3}, Lkotlinx/serialization/KSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v3

    sput-object v3, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->polymorphicParcelableArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    .line 47
    invoke-static {v0}, Lkotlinx/serialization/builtins/BuiltinSerializersKt;->ListSerializer(Lkotlinx/serialization/KSerializer;)Lkotlinx/serialization/KSerializer;

    move-result-object v3

    invoke-interface {v3}, Lkotlinx/serialization/KSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v3

    sput-object v3, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->parcelableListDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    .line 49
    new-instance v3, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;

    invoke-static {v2}, Lkotlin/jvm/internal/Reflection;->getOrCreateKotlinClass(Ljava/lang/Class;)Lkotlin/reflect/KClass;

    move-result-object v4

    invoke-direct {v3, v4}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;-><init>(Lkotlin/reflect/KClass;)V

    invoke-static {v3}, Lkotlinx/serialization/builtins/BuiltinSerializersKt;->ListSerializer(Lkotlinx/serialization/KSerializer;)Lkotlinx/serialization/KSerializer;

    move-result-object v3

    invoke-interface {v3}, Lkotlinx/serialization/KSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v3

    sput-object v3, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->polymorphicParcelableListDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    .line 52
    sget-object v3, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/CharSequenceSerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/CharSequenceSerializer;

    invoke-static {v1}, Lkotlin/jvm/internal/Reflection;->getOrCreateKotlinClass(Ljava/lang/Class;)Lkotlin/reflect/KClass;

    move-result-object v4

    .line 70
    invoke-static {v4, v3}, Lkotlinx/serialization/builtins/BuiltinSerializersKt;->ArraySerializer(Lkotlin/reflect/KClass;Lkotlinx/serialization/KSerializer;)Lkotlinx/serialization/KSerializer;

    move-result-object v4

    .line 52
    invoke-interface {v4}, Lkotlinx/serialization/KSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v4

    sput-object v4, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->charSequenceArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    .line 55
    new-instance v4, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;

    invoke-static {v1}, Lkotlin/jvm/internal/Reflection;->getOrCreateKotlinClass(Ljava/lang/Class;)Lkotlin/reflect/KClass;

    move-result-object v5

    invoke-direct {v4, v5}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;-><init>(Lkotlin/reflect/KClass;)V

    invoke-static {v1}, Lkotlin/jvm/internal/Reflection;->getOrCreateKotlinClass(Ljava/lang/Class;)Lkotlin/reflect/KClass;

    move-result-object v5

    .line 71
    invoke-static {v5, v4}, Lkotlinx/serialization/builtins/BuiltinSerializersKt;->ArraySerializer(Lkotlin/reflect/KClass;Lkotlinx/serialization/KSerializer;)Lkotlinx/serialization/KSerializer;

    move-result-object v4

    .line 55
    invoke-interface {v4}, Lkotlinx/serialization/KSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v4

    sput-object v4, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->polymorphicCharSequenceArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    .line 57
    invoke-static {v3}, Lkotlinx/serialization/builtins/BuiltinSerializersKt;->ListSerializer(Lkotlinx/serialization/KSerializer;)Lkotlinx/serialization/KSerializer;

    move-result-object v3

    invoke-interface {v3}, Lkotlinx/serialization/KSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v3

    sput-object v3, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->charSequenceListDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    .line 59
    new-instance v3, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;

    invoke-static {v1}, Lkotlin/jvm/internal/Reflection;->getOrCreateKotlinClass(Ljava/lang/Class;)Lkotlin/reflect/KClass;

    move-result-object v1

    invoke-direct {v3, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;-><init>(Lkotlin/reflect/KClass;)V

    invoke-static {v3}, Lkotlinx/serialization/builtins/BuiltinSerializersKt;->ListSerializer(Lkotlinx/serialization/KSerializer;)Lkotlinx/serialization/KSerializer;

    move-result-object v1

    invoke-interface {v1}, Lkotlinx/serialization/KSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v1

    sput-object v1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->polymorphicCharSequenceListDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    .line 62
    new-instance v1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer;

    invoke-direct {v1, v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer;-><init>(Lkotlinx/serialization/KSerializer;)V

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->sparseParcelableArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    .line 64
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;

    invoke-static {v2}, Lkotlin/jvm/internal/Reflection;->getOrCreateKotlinClass(Ljava/lang/Class;)Lkotlin/reflect/KClass;

    move-result-object v3

    invoke-direct {v1, v3}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;-><init>(Lkotlin/reflect/KClass;)V

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer;-><init>(Lkotlinx/serialization/KSerializer;)V

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->polymorphicSparseParcelableArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    .line 66
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;

    invoke-static {v2}, Lkotlin/jvm/internal/Reflection;->getOrCreateKotlinClass(Ljava/lang/Class;)Lkotlin/reflect/KClass;

    move-result-object v2

    invoke-direct {v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/PolymorphicSerializer;-><init>(Lkotlin/reflect/KClass;)V

    invoke-static {v1}, Lkotlinx/serialization/builtins/BuiltinSerializersKt;->getNullable(Lkotlinx/serialization/KSerializer;)Lkotlinx/serialization/KSerializer;

    move-result-object v1

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer;-><init>(Lkotlinx/serialization/KSerializer;)V

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SparseArraySerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->nullablePolymorphicSparseParcelableArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-void
.end method

.method public static final getCharSequenceArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 51
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->charSequenceArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-object v0
.end method

.method public static final getCharSequenceListDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 57
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->charSequenceListDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-object v0
.end method

.method public static final getNullablePolymorphicSparseParcelableArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 65
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->nullablePolymorphicSparseParcelableArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-object v0
.end method

.method public static final getParcelableArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 41
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->parcelableArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-object v0
.end method

.method public static final getParcelableListDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 47
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->parcelableListDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-object v0
.end method

.method public static final getPolymorphicCharSequenceArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 53
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->polymorphicCharSequenceArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-object v0
.end method

.method public static final getPolymorphicCharSequenceDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 31
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->polymorphicCharSequenceDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-object v0
.end method

.method public static final getPolymorphicCharSequenceListDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 58
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->polymorphicCharSequenceListDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-object v0
.end method

.method public static final getPolymorphicIBinderDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 39
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->polymorphicIBinderDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-object v0
.end method

.method public static final getPolymorphicJavaSerializableDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 36
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->polymorphicJavaSerializableDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-object v0
.end method

.method public static final getPolymorphicParcelableArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 43
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->polymorphicParcelableArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-object v0
.end method

.method public static final getPolymorphicParcelableDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 34
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->polymorphicParcelableDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-object v0
.end method

.method public static final getPolymorphicParcelableListDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 48
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->polymorphicParcelableListDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-object v0
.end method

.method public static final getPolymorphicSparseParcelableArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 63
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->polymorphicSparseParcelableArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-object v0
.end method

.method public static final getSparseParcelableArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 61
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtils_androidKt;->sparseParcelableArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-object v0
.end method
