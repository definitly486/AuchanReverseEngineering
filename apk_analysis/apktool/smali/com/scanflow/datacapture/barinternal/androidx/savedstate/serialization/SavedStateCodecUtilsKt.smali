.class public abstract Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtilsKt;
.super Ljava/lang/Object;
.source "SavedStateCodecUtils.kt"


# static fields
.field private static final booleanArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

.field private static final charArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

.field private static final doubleArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

.field private static final floatArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

.field private static final intArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

.field private static final intListDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

.field private static final longArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

.field private static final stringArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

.field private static final stringListDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 31
    sget-object v0, Lkotlin/jvm/internal/IntCompanionObject;->INSTANCE:Lkotlin/jvm/internal/IntCompanionObject;

    invoke-static {v0}, Lkotlinx/serialization/builtins/BuiltinSerializersKt;->serializer(Lkotlin/jvm/internal/IntCompanionObject;)Lkotlinx/serialization/KSerializer;

    move-result-object v0

    invoke-static {v0}, Lkotlinx/serialization/builtins/BuiltinSerializersKt;->ListSerializer(Lkotlinx/serialization/KSerializer;)Lkotlinx/serialization/KSerializer;

    move-result-object v0

    invoke-interface {v0}, Lkotlinx/serialization/KSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtilsKt;->intListDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    .line 32
    sget-object v0, Lkotlin/jvm/internal/StringCompanionObject;->INSTANCE:Lkotlin/jvm/internal/StringCompanionObject;

    invoke-static {v0}, Lkotlinx/serialization/builtins/BuiltinSerializersKt;->serializer(Lkotlin/jvm/internal/StringCompanionObject;)Lkotlinx/serialization/KSerializer;

    move-result-object v1

    invoke-static {v1}, Lkotlinx/serialization/builtins/BuiltinSerializersKt;->ListSerializer(Lkotlinx/serialization/KSerializer;)Lkotlinx/serialization/KSerializer;

    move-result-object v1

    invoke-interface {v1}, Lkotlinx/serialization/KSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v1

    sput-object v1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtilsKt;->stringListDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    .line 33
    invoke-static {}, Lkotlinx/serialization/builtins/BuiltinSerializersKt;->BooleanArraySerializer()Lkotlinx/serialization/KSerializer;

    move-result-object v1

    invoke-interface {v1}, Lkotlinx/serialization/KSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v1

    sput-object v1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtilsKt;->booleanArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    .line 34
    invoke-static {}, Lkotlinx/serialization/builtins/BuiltinSerializersKt;->CharArraySerializer()Lkotlinx/serialization/KSerializer;

    move-result-object v1

    invoke-interface {v1}, Lkotlinx/serialization/KSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v1

    sput-object v1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtilsKt;->charArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    .line 35
    invoke-static {}, Lkotlinx/serialization/builtins/BuiltinSerializersKt;->DoubleArraySerializer()Lkotlinx/serialization/KSerializer;

    move-result-object v1

    invoke-interface {v1}, Lkotlinx/serialization/KSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v1

    sput-object v1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtilsKt;->doubleArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    .line 36
    invoke-static {}, Lkotlinx/serialization/builtins/BuiltinSerializersKt;->FloatArraySerializer()Lkotlinx/serialization/KSerializer;

    move-result-object v1

    invoke-interface {v1}, Lkotlinx/serialization/KSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v1

    sput-object v1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtilsKt;->floatArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    .line 37
    invoke-static {}, Lkotlinx/serialization/builtins/BuiltinSerializersKt;->IntArraySerializer()Lkotlinx/serialization/KSerializer;

    move-result-object v1

    invoke-interface {v1}, Lkotlinx/serialization/KSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v1

    sput-object v1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtilsKt;->intArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    .line 38
    invoke-static {}, Lkotlinx/serialization/builtins/BuiltinSerializersKt;->LongArraySerializer()Lkotlinx/serialization/KSerializer;

    move-result-object v1

    invoke-interface {v1}, Lkotlinx/serialization/KSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v1

    sput-object v1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtilsKt;->longArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    .line 40
    invoke-static {v0}, Lkotlinx/serialization/builtins/BuiltinSerializersKt;->serializer(Lkotlin/jvm/internal/StringCompanionObject;)Lkotlinx/serialization/KSerializer;

    move-result-object v0

    const-class v1, Ljava/lang/String;

    invoke-static {v1}, Lkotlin/jvm/internal/Reflection;->getOrCreateKotlinClass(Ljava/lang/Class;)Lkotlin/reflect/KClass;

    move-result-object v1

    .line 42
    invoke-static {v1, v0}, Lkotlinx/serialization/builtins/BuiltinSerializersKt;->ArraySerializer(Lkotlin/reflect/KClass;Lkotlinx/serialization/KSerializer;)Lkotlinx/serialization/KSerializer;

    move-result-object v0

    .line 40
    invoke-interface {v0}, Lkotlinx/serialization/KSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtilsKt;->stringArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-void
.end method

.method public static final getBooleanArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 33
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtilsKt;->booleanArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-object v0
.end method

.method public static final getCharArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 34
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtilsKt;->charArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-object v0
.end method

.method public static final getDoubleArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 35
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtilsKt;->doubleArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-object v0
.end method

.method public static final getFloatArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 36
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtilsKt;->floatArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-object v0
.end method

.method public static final getIntArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 37
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtilsKt;->intArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-object v0
.end method

.method public static final getIntListDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 31
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtilsKt;->intListDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-object v0
.end method

.method public static final getLongArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 38
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtilsKt;->longArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-object v0
.end method

.method public static final getStringArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 39
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtilsKt;->stringArrayDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-object v0
.end method

.method public static final getStringListDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 32
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtilsKt;->stringListDescriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-object v0
.end method
