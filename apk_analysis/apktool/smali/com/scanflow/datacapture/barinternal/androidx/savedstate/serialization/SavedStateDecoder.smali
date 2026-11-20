.class public final Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;
.super Lkotlinx/serialization/encoding/AbstractDecoder;
.source "SavedStateDecoder.kt"


# instance fields
.field private final configuration:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;

.field private index:I

.field private key:Ljava/lang/String;

.field private final savedState:Landroid/os/Bundle;

.field private final serializersModule:Lkotlinx/serialization/modules/SerializersModule;


# direct methods
.method public constructor <init>(Landroid/os/Bundle;Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;)V
    .locals 1

    const-string v0, "savedState"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "configuration"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 80
    invoke-direct {p0}, Lkotlinx/serialization/encoding/AbstractDecoder;-><init>()V

    .line 78
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->savedState:Landroid/os/Bundle;

    .line 79
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->configuration:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;

    .line 81
    const-string p1, ""

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->key:Ljava/lang/String;

    .line 86
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;->getSerializersModule()Lkotlinx/serialization/modules/SerializersModule;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->serializersModule:Lkotlinx/serialization/modules/SerializersModule;

    return-void
.end method

.method private final decodeBooleanArray()[Z
    .locals 2

    .line 145
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->savedState:Landroid/os/Bundle;

    .line 229
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 145
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->key:Ljava/lang/String;

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->getBooleanArray-impl(Landroid/os/Bundle;Ljava/lang/String;)[Z

    move-result-object v0

    return-object v0
.end method

.method private final decodeCharArray()[C
    .locals 2

    .line 149
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->savedState:Landroid/os/Bundle;

    .line 230
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 149
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->key:Ljava/lang/String;

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->getCharArray-impl(Landroid/os/Bundle;Ljava/lang/String;)[C

    move-result-object v0

    return-object v0
.end method

.method private final decodeDoubleArray()[D
    .locals 2

    .line 153
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->savedState:Landroid/os/Bundle;

    .line 231
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 153
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->key:Ljava/lang/String;

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->getDoubleArray-impl(Landroid/os/Bundle;Ljava/lang/String;)[D

    move-result-object v0

    return-object v0
.end method

.method private static final decodeElementIndex$hasDefaultValueDefined(Lkotlinx/serialization/descriptors/SerialDescriptor;I)Z
    .locals 0

    .line 98
    invoke-interface {p0, p1}, Lkotlinx/serialization/descriptors/SerialDescriptor;->isElementOptional(I)Z

    move-result p0

    return p0
.end method

.method private static final decodeElementIndex$presentInEncoding(Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;Lkotlinx/serialization/descriptors/SerialDescriptor;I)Z
    .locals 0

    .line 100
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->savedState:Landroid/os/Bundle;

    .line 238
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object p0

    .line 101
    invoke-interface {p1, p2}, Lkotlinx/serialization/descriptors/SerialDescriptor;->getElementName(I)Ljava/lang/String;

    move-result-object p1

    .line 102
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->contains-impl(Landroid/os/Bundle;Ljava/lang/String;)Z

    move-result p0

    return p0
.end method

.method private final decodeFloatArray()[F
    .locals 2

    .line 157
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->savedState:Landroid/os/Bundle;

    .line 232
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 157
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->key:Ljava/lang/String;

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->getFloatArray-impl(Landroid/os/Bundle;Ljava/lang/String;)[F

    move-result-object v0

    return-object v0
.end method

.method private final decodeFormatSpecificTypes(Lkotlinx/serialization/DeserializationStrategy;)Ljava/lang/Object;
    .locals 1

    .line 194
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder_androidKt;->decodeFormatSpecificTypesOnPlatform(Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;Lkotlinx/serialization/DeserializationStrategy;)Ljava/lang/Object;

    move-result-object v0

    if-nez v0, :cond_9

    .line 195
    invoke-interface {p1}, Lkotlinx/serialization/DeserializationStrategy;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object p1

    .line 196
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtilsKt;->getIntListDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->decodeIntList()Ljava/util/List;

    move-result-object p1

    return-object p1

    .line 197
    :cond_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtilsKt;->getStringListDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_1

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->decodeStringList()Ljava/util/List;

    move-result-object p1

    return-object p1

    .line 198
    :cond_1
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtilsKt;->getBooleanArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_2

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->decodeBooleanArray()[Z

    move-result-object p1

    return-object p1

    .line 199
    :cond_2
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtilsKt;->getCharArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_3

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->decodeCharArray()[C

    move-result-object p1

    return-object p1

    .line 200
    :cond_3
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtilsKt;->getDoubleArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_4

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->decodeDoubleArray()[D

    move-result-object p1

    return-object p1

    .line 201
    :cond_4
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtilsKt;->getFloatArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_5

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->decodeFloatArray()[F

    move-result-object p1

    return-object p1

    .line 202
    :cond_5
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtilsKt;->getIntArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_6

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->decodeIntArray()[I

    move-result-object p1

    return-object p1

    .line 203
    :cond_6
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtilsKt;->getLongArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_7

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->decodeLongArray()[J

    move-result-object p1

    return-object p1

    .line 204
    :cond_7
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtilsKt;->getStringArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result p1

    if-eqz p1, :cond_8

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->decodeStringArray()[Ljava/lang/String;

    move-result-object p1

    return-object p1

    :cond_8
    const/4 p1, 0x0

    return-object p1

    :cond_9
    return-object v0
.end method

.method private final decodeIntArray()[I
    .locals 2

    .line 161
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->savedState:Landroid/os/Bundle;

    .line 233
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 161
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->key:Ljava/lang/String;

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->getIntArray-impl(Landroid/os/Bundle;Ljava/lang/String;)[I

    move-result-object v0

    return-object v0
.end method

.method private final decodeIntList()Ljava/util/List;
    .locals 2

    .line 137
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->savedState:Landroid/os/Bundle;

    .line 227
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 137
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->key:Ljava/lang/String;

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->getIntList-impl(Landroid/os/Bundle;Ljava/lang/String;)Ljava/util/List;

    move-result-object v0

    return-object v0
.end method

.method private final decodeLongArray()[J
    .locals 2

    .line 165
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->savedState:Landroid/os/Bundle;

    .line 234
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 165
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->key:Ljava/lang/String;

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->getLongArray-impl(Landroid/os/Bundle;Ljava/lang/String;)[J

    move-result-object v0

    return-object v0
.end method

.method private final decodeStringArray()[Ljava/lang/String;
    .locals 2

    .line 169
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->savedState:Landroid/os/Bundle;

    .line 235
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 169
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->key:Ljava/lang/String;

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->getStringArray-impl(Landroid/os/Bundle;Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method private final decodeStringList()Ljava/util/List;
    .locals 2

    .line 141
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->savedState:Landroid/os/Bundle;

    .line 228
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 141
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->key:Ljava/lang/String;

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->getStringList-impl(Landroid/os/Bundle;Ljava/lang/String;)Ljava/util/List;

    move-result-object v0

    return-object v0
.end method


# virtual methods
.method public beginStructure(Lkotlinx/serialization/descriptors/SerialDescriptor;)Lkotlinx/serialization/encoding/CompositeDecoder;
    .locals 2

    const-string v0, "descriptor"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 173
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->key:Ljava/lang/String;

    const-string v0, ""

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result p1

    if-eqz p1, :cond_0

    return-object p0

    .line 177
    :cond_0
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->savedState:Landroid/os/Bundle;

    .line 236
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object p1

    .line 177
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->key:Ljava/lang/String;

    invoke-static {p1, v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->getSavedState-impl(Landroid/os/Bundle;Ljava/lang/String;)Landroid/os/Bundle;

    move-result-object p1

    .line 178
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->configuration:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;

    .line 176
    new-instance v1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;

    invoke-direct {v1, p1, v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;-><init>(Landroid/os/Bundle;Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;)V

    return-object v1
.end method

.method public decodeBoolean()Z
    .locals 2

    .line 116
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->savedState:Landroid/os/Bundle;

    .line 217
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 116
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->key:Ljava/lang/String;

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->getBoolean-impl(Landroid/os/Bundle;Ljava/lang/String;)Z

    move-result v0

    return v0
.end method

.method public decodeByte()B
    .locals 2

    .line 118
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->savedState:Landroid/os/Bundle;

    .line 218
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 118
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->key:Ljava/lang/String;

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->getInt-impl(Landroid/os/Bundle;Ljava/lang/String;)I

    move-result v0

    int-to-byte v0, v0

    return v0
.end method

.method public decodeChar()C
    .locals 2

    .line 130
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->savedState:Landroid/os/Bundle;

    .line 224
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 130
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->key:Ljava/lang/String;

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->getChar-impl(Landroid/os/Bundle;Ljava/lang/String;)C

    move-result v0

    return v0
.end method

.method public decodeDouble()D
    .locals 2

    .line 128
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->savedState:Landroid/os/Bundle;

    .line 223
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 128
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->key:Ljava/lang/String;

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->getDouble-impl(Landroid/os/Bundle;Ljava/lang/String;)D

    move-result-wide v0

    return-wide v0
.end method

.method public decodeElementIndex(Lkotlinx/serialization/descriptors/SerialDescriptor;)I
    .locals 2

    const-string v0, "descriptor"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 90
    invoke-interface {p1}, Lkotlinx/serialization/descriptors/SerialDescriptor;->getKind()Lkotlinx/serialization/descriptors/SerialKind;

    move-result-object v0

    sget-object v1, Lkotlinx/serialization/descriptors/StructureKind$LIST;->INSTANCE:Lkotlinx/serialization/descriptors/StructureKind$LIST;

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_1

    invoke-interface {p1}, Lkotlinx/serialization/descriptors/SerialDescriptor;->getKind()Lkotlinx/serialization/descriptors/SerialKind;

    move-result-object v0

    sget-object v1, Lkotlinx/serialization/descriptors/StructureKind$MAP;->INSTANCE:Lkotlinx/serialization/descriptors/StructureKind$MAP;

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    goto :goto_0

    .line 96
    :cond_0
    invoke-interface {p1}, Lkotlinx/serialization/descriptors/SerialDescriptor;->getElementsCount()I

    move-result v0

    goto :goto_1

    .line 92
    :cond_1
    :goto_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->savedState:Landroid/os/Bundle;

    .line 216
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 92
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->size-impl(Landroid/os/Bundle;)I

    move-result v0

    .line 105
    :goto_1
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->index:I

    if-ge v1, v0, :cond_2

    invoke-static {p1, v1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->decodeElementIndex$hasDefaultValueDefined(Lkotlinx/serialization/descriptors/SerialDescriptor;I)Z

    move-result v1

    if-eqz v1, :cond_2

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->index:I

    invoke-static {p0, p1, v1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->decodeElementIndex$presentInEncoding(Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;Lkotlinx/serialization/descriptors/SerialDescriptor;I)Z

    move-result v1

    if-nez v1, :cond_2

    .line 106
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->index:I

    add-int/lit8 v1, v1, 0x1

    iput v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->index:I

    goto :goto_1

    .line 108
    :cond_2
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->index:I

    if-ge v1, v0, :cond_3

    .line 109
    invoke-interface {p1, v1}, Lkotlinx/serialization/descriptors/SerialDescriptor;->getElementName(I)Ljava/lang/String;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->key:Ljava/lang/String;

    .line 110
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->index:I

    add-int/lit8 v0, p1, 0x1

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->index:I

    return p1

    :cond_3
    const/4 p1, -0x1

    return p1
.end method

.method public decodeEnum(Lkotlinx/serialization/descriptors/SerialDescriptor;)I
    .locals 1

    const-string v0, "enumDescriptor"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 134
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->savedState:Landroid/os/Bundle;

    .line 226
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object p1

    .line 134
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->key:Ljava/lang/String;

    invoke-static {p1, v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->getInt-impl(Landroid/os/Bundle;Ljava/lang/String;)I

    move-result p1

    return p1
.end method

.method public decodeFloat()F
    .locals 2

    .line 126
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->savedState:Landroid/os/Bundle;

    .line 222
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 126
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->key:Ljava/lang/String;

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->getFloat-impl(Landroid/os/Bundle;Ljava/lang/String;)F

    move-result v0

    return v0
.end method

.method public decodeInt()I
    .locals 2

    .line 122
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->savedState:Landroid/os/Bundle;

    .line 220
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 122
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->key:Ljava/lang/String;

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->getInt-impl(Landroid/os/Bundle;Ljava/lang/String;)I

    move-result v0

    return v0
.end method

.method public decodeLong()J
    .locals 2

    .line 124
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->savedState:Landroid/os/Bundle;

    .line 221
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 124
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->key:Ljava/lang/String;

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->getLong-impl(Landroid/os/Bundle;Ljava/lang/String;)J

    move-result-wide v0

    return-wide v0
.end method

.method public decodeNotNullMark()Z
    .locals 2

    .line 184
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->savedState:Landroid/os/Bundle;

    .line 237
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 184
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->key:Ljava/lang/String;

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->isNull-impl(Landroid/os/Bundle;Ljava/lang/String;)Z

    move-result v0

    xor-int/lit8 v0, v0, 0x1

    return v0
.end method

.method public decodeSerializableValue(Lkotlinx/serialization/DeserializationStrategy;)Ljava/lang/Object;
    .locals 1

    const-string v0, "deserializer"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 187
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->decodeFormatSpecificTypes(Lkotlinx/serialization/DeserializationStrategy;)Ljava/lang/Object;

    move-result-object v0

    if-nez v0, :cond_0

    .line 188
    invoke-super {p0, p1}, Lkotlinx/serialization/encoding/AbstractDecoder;->decodeSerializableValue(Lkotlinx/serialization/DeserializationStrategy;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    :cond_0
    return-object v0
.end method

.method public decodeShort()S
    .locals 2

    .line 120
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->savedState:Landroid/os/Bundle;

    .line 219
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 120
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->key:Ljava/lang/String;

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->getInt-impl(Landroid/os/Bundle;Ljava/lang/String;)I

    move-result v0

    int-to-short v0, v0

    return v0
.end method

.method public decodeString()Ljava/lang/String;
    .locals 2

    .line 132
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->savedState:Landroid/os/Bundle;

    .line 225
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 132
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->key:Ljava/lang/String;

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->getString-impl(Landroid/os/Bundle;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public final getKey$savedstate_release()Ljava/lang/String;
    .locals 1

    .line 81
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->key:Ljava/lang/String;

    return-object v0
.end method

.method public final getSavedState$savedstate_release()Landroid/os/Bundle;
    .locals 1

    .line 78
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->savedState:Landroid/os/Bundle;

    return-object v0
.end method

.method public getSerializersModule()Lkotlinx/serialization/modules/SerializersModule;
    .locals 1

    .line 86
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->serializersModule:Lkotlinx/serialization/modules/SerializersModule;

    return-object v0
.end method
