.class public final Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;
.super Lkotlinx/serialization/encoding/AbstractEncoder;
.source "SavedStateEncoder.kt"


# instance fields
.field private final configuration:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;

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

    .line 82
    invoke-direct {p0}, Lkotlinx/serialization/encoding/AbstractEncoder;-><init>()V

    .line 80
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->savedState:Landroid/os/Bundle;

    .line 81
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->configuration:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;

    .line 84
    const-string p1, ""

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->key:Ljava/lang/String;

    .line 87
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;->getSerializersModule()Lkotlinx/serialization/modules/SerializersModule;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->serializersModule:Lkotlinx/serialization/modules/SerializersModule;

    return-void
.end method

.method private final checkDiscriminatorCollisions(Landroid/os/Bundle;Ljava/lang/String;)V
    .locals 3

    .line 107
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->configuration:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;->getClassDiscriminatorMode()I

    move-result v0

    const/4 v1, 0x1

    if-ne v0, v1, :cond_1

    .line 282
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 108
    const-string v1, "type"

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->contains-impl(Landroid/os/Bundle;Ljava/lang/String;)Z

    move-result v0

    .line 109
    invoke-static {p2, v1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v2

    if-eqz v0, :cond_1

    if-nez v2, :cond_0

    goto :goto_0

    .line 283
    :cond_0
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object p1

    .line 111
    invoke-static {p1, v1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->getString-impl(Landroid/os/Bundle;Ljava/lang/String;)Ljava/lang/String;

    move-result-object p1

    .line 112
    new-instance v0, Ljava/lang/IllegalArgumentException;

    .line 113
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "SavedStateEncoder for "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string p1, " has property \'"

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string p1, "\' that conflicts with the class discriminator. You can rename a property with @SerialName annotation."

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    .line 112
    invoke-direct {v0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0

    :cond_1
    :goto_0
    return-void
.end method

.method private final encodeBooleanArray([Z)V
    .locals 2

    .line 174
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->savedState:Landroid/os/Bundle;

    .line 297
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 174
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->key:Ljava/lang/String;

    invoke-static {v0, v1, p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->putBooleanArray-impl(Landroid/os/Bundle;Ljava/lang/String;[Z)V

    return-void
.end method

.method private final encodeCharArray([C)V
    .locals 2

    .line 178
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->savedState:Landroid/os/Bundle;

    .line 298
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 178
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->key:Ljava/lang/String;

    invoke-static {v0, v1, p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->putCharArray-impl(Landroid/os/Bundle;Ljava/lang/String;[C)V

    return-void
.end method

.method private final encodeDoubleArray([D)V
    .locals 2

    .line 182
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->savedState:Landroid/os/Bundle;

    .line 299
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 182
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->key:Ljava/lang/String;

    invoke-static {v0, v1, p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->putDoubleArray-impl(Landroid/os/Bundle;Ljava/lang/String;[D)V

    return-void
.end method

.method private final encodeFloatArray([F)V
    .locals 2

    .line 186
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->savedState:Landroid/os/Bundle;

    .line 300
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 186
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->key:Ljava/lang/String;

    invoke-static {v0, v1, p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->putFloatArray-impl(Landroid/os/Bundle;Ljava/lang/String;[F)V

    return-void
.end method

.method private final encodeFormatSpecificTypes(Lkotlinx/serialization/SerializationStrategy;Ljava/lang/Object;)Z
    .locals 1

    .line 254
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder_androidKt;->encodeFormatSpecificTypesOnPlatform(Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;Lkotlinx/serialization/SerializationStrategy;Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_9

    .line 256
    invoke-interface {p1}, Lkotlinx/serialization/SerializationStrategy;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object p1

    .line 257
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtilsKt;->getIntListDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    const-string p1, "null cannot be cast to non-null type kotlin.collections.List<kotlin.Int>"

    invoke-static {p2, p1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast p2, Ljava/util/List;

    invoke-direct {p0, p2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->encodeIntList(Ljava/util/List;)V

    goto/16 :goto_0

    .line 258
    :cond_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtilsKt;->getStringListDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_1

    const-string p1, "null cannot be cast to non-null type kotlin.collections.List<kotlin.String>"

    invoke-static {p2, p1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast p2, Ljava/util/List;

    invoke-direct {p0, p2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->encodeStringList(Ljava/util/List;)V

    goto/16 :goto_0

    .line 259
    :cond_1
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtilsKt;->getBooleanArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_2

    const-string p1, "null cannot be cast to non-null type kotlin.BooleanArray"

    invoke-static {p2, p1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast p2, [Z

    invoke-direct {p0, p2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->encodeBooleanArray([Z)V

    goto/16 :goto_0

    .line 260
    :cond_2
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtilsKt;->getCharArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_3

    const-string p1, "null cannot be cast to non-null type kotlin.CharArray"

    invoke-static {p2, p1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast p2, [C

    invoke-direct {p0, p2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->encodeCharArray([C)V

    goto :goto_0

    .line 261
    :cond_3
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtilsKt;->getDoubleArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_4

    const-string p1, "null cannot be cast to non-null type kotlin.DoubleArray"

    invoke-static {p2, p1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast p2, [D

    invoke-direct {p0, p2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->encodeDoubleArray([D)V

    goto :goto_0

    .line 262
    :cond_4
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtilsKt;->getFloatArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_5

    const-string p1, "null cannot be cast to non-null type kotlin.FloatArray"

    invoke-static {p2, p1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast p2, [F

    invoke-direct {p0, p2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->encodeFloatArray([F)V

    goto :goto_0

    .line 263
    :cond_5
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtilsKt;->getIntArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_6

    const-string p1, "null cannot be cast to non-null type kotlin.IntArray"

    invoke-static {p2, p1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast p2, [I

    invoke-direct {p0, p2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->encodeIntArray([I)V

    goto :goto_0

    .line 264
    :cond_6
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtilsKt;->getLongArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_7

    const-string p1, "null cannot be cast to non-null type kotlin.LongArray"

    invoke-static {p2, p1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast p2, [J

    invoke-direct {p0, p2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->encodeLongArray([J)V

    goto :goto_0

    .line 265
    :cond_7
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateCodecUtilsKt;->getStringArrayDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result p1

    if-eqz p1, :cond_8

    const-string p1, "null cannot be cast to non-null type kotlin.Array<kotlin.String>"

    invoke-static {p2, p1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast p2, [Ljava/lang/String;

    invoke-direct {p0, p2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->encodeStringArray([Ljava/lang/String;)V

    goto :goto_0

    :cond_8
    const/4 p1, 0x0

    return p1

    :cond_9
    :goto_0
    const/4 p1, 0x1

    return p1
.end method

.method private final encodeIntArray([I)V
    .locals 2

    .line 190
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->savedState:Landroid/os/Bundle;

    .line 301
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 190
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->key:Ljava/lang/String;

    invoke-static {v0, v1, p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->putIntArray-impl(Landroid/os/Bundle;Ljava/lang/String;[I)V

    return-void
.end method

.method private final encodeIntList(Ljava/util/List;)V
    .locals 2

    .line 166
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->savedState:Landroid/os/Bundle;

    .line 295
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 166
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->key:Ljava/lang/String;

    invoke-static {v0, v1, p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->putIntList-impl(Landroid/os/Bundle;Ljava/lang/String;Ljava/util/List;)V

    return-void
.end method

.method private final encodeLongArray([J)V
    .locals 2

    .line 194
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->savedState:Landroid/os/Bundle;

    .line 302
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 194
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->key:Ljava/lang/String;

    invoke-static {v0, v1, p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->putLongArray-impl(Landroid/os/Bundle;Ljava/lang/String;[J)V

    return-void
.end method

.method private final encodeStringArray([Ljava/lang/String;)V
    .locals 2

    .line 198
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->savedState:Landroid/os/Bundle;

    .line 303
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 198
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->key:Ljava/lang/String;

    invoke-static {v0, v1, p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->putStringArray-impl(Landroid/os/Bundle;Ljava/lang/String;[Ljava/lang/String;)V

    return-void
.end method

.method private final encodeStringList(Ljava/util/List;)V
    .locals 2

    .line 170
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->savedState:Landroid/os/Bundle;

    .line 296
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 170
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->key:Ljava/lang/String;

    invoke-static {v0, v1, p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->putStringList-impl(Landroid/os/Bundle;Ljava/lang/String;Ljava/util/List;)V

    return-void
.end method

.method private final putClassDiscriminatorIfRequired(Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;Lkotlinx/serialization/descriptors/SerialDescriptor;Landroid/os/Bundle;)V
    .locals 2

    .line 225
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;->getClassDiscriminatorMode()I

    move-result p1

    const/4 v0, 0x1

    if-eq p1, v0, :cond_0

    goto :goto_0

    .line 327
    :cond_0
    invoke-static {p3}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object p1

    .line 229
    const-string v0, "type"

    invoke-static {p1, v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->contains-impl(Landroid/os/Bundle;Ljava/lang/String;)Z

    move-result p1

    if-eqz p1, :cond_1

    goto :goto_0

    .line 233
    :cond_1
    invoke-interface {p2}, Lkotlinx/serialization/descriptors/SerialDescriptor;->getKind()Lkotlinx/serialization/descriptors/SerialKind;

    move-result-object p1

    sget-object v1, Lkotlinx/serialization/descriptors/StructureKind$CLASS;->INSTANCE:Lkotlinx/serialization/descriptors/StructureKind$CLASS;

    invoke-static {p1, v1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result p1

    if-nez p1, :cond_3

    invoke-interface {p2}, Lkotlinx/serialization/descriptors/SerialDescriptor;->getKind()Lkotlinx/serialization/descriptors/SerialKind;

    move-result-object p1

    sget-object v1, Lkotlinx/serialization/descriptors/StructureKind$OBJECT;->INSTANCE:Lkotlinx/serialization/descriptors/StructureKind$OBJECT;

    invoke-static {p1, v1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result p1

    if-eqz p1, :cond_2

    goto :goto_1

    :cond_2
    :goto_0
    return-void

    .line 328
    :cond_3
    :goto_1
    invoke-static {p3}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object p1

    .line 234
    invoke-interface {p2}, Lkotlinx/serialization/descriptors/SerialDescriptor;->getSerialName()Ljava/lang/String;

    move-result-object p2

    invoke-static {p1, v0, p2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->putString-impl(Landroid/os/Bundle;Ljava/lang/String;Ljava/lang/String;)V

    return-void
.end method


# virtual methods
.method public beginStructure(Lkotlinx/serialization/descriptors/SerialDescriptor;)Lkotlinx/serialization/encoding/CompositeEncoder;
    .locals 5

    const-string v0, "descriptor"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 207
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->key:Ljava/lang/String;

    const-string v1, ""

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 208
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->configuration:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->savedState:Landroid/os/Bundle;

    invoke-direct {p0, v0, p1, v1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->putClassDiscriminatorIfRequired(Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;Lkotlinx/serialization/descriptors/SerialDescriptor;Landroid/os/Bundle;)V

    return-object p0

    .line 305
    :cond_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/MapsKt;->emptyMap()Ljava/util/Map;

    move-result-object v0

    .line 306
    invoke-interface {v0}, Ljava/util/Map;->isEmpty()Z

    move-result v1

    const/4 v2, 0x0

    if-eqz v1, :cond_1

    .line 307
    new-array v0, v2, [Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    goto :goto_1

    .line 310
    :cond_1
    new-instance v1, Ljava/util/ArrayList;

    invoke-interface {v0}, Ljava/util/Map;->size()I

    move-result v3

    invoke-direct {v1, v3}, Ljava/util/ArrayList;-><init>(I)V

    .line 311
    invoke-interface {v0}, Ljava/util/Map;->entrySet()Ljava/util/Set;

    move-result-object v0

    invoke-interface {v0}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object v0

    :goto_0
    invoke-interface {v0}, Ljava/util/Iterator;->hasNext()Z

    move-result v3

    if-eqz v3, :cond_2

    invoke-interface {v0}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/util/Map$Entry;

    .line 312
    invoke-interface {v3}, Ljava/util/Map$Entry;->getKey()Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Ljava/lang/String;

    invoke-interface {v3}, Ljava/util/Map$Entry;->getValue()Ljava/lang/Object;

    move-result-object v3

    .line 309
    invoke-static {v4, v3}, Lcom/scanflow/datacapture/barinternal/kotlin/TuplesKt;->to(Ljava/lang/Object;Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    move-result-object v3

    .line 312
    invoke-interface {v1, v3}, Ljava/util/Collection;->add(Ljava/lang/Object;)Z

    goto :goto_0

    .line 315
    :cond_2
    new-array v0, v2, [Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    invoke-interface {v1, v0}, Ljava/util/Collection;->toArray([Ljava/lang/Object;)[Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    .line 322
    :goto_1
    array-length v1, v0

    invoke-static {v0, v1}, Ljava/util/Arrays;->copyOf([Ljava/lang/Object;I)[Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/core/os/BundleKt;->bundleOf([Lcom/scanflow/datacapture/barinternal/kotlin/Pair;)Landroid/os/Bundle;

    move-result-object v0

    .line 324
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    .line 212
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->savedState:Landroid/os/Bundle;

    .line 326
    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v1

    .line 212
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->key:Ljava/lang/String;

    invoke-static {v1, v2, v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->putSavedState-impl(Landroid/os/Bundle;Ljava/lang/String;Landroid/os/Bundle;)V

    .line 213
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->configuration:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;

    invoke-direct {p0, v1, p1, v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->putClassDiscriminatorIfRequired(Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;Lkotlinx/serialization/descriptors/SerialDescriptor;Landroid/os/Bundle;)V

    .line 214
    new-instance p1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->configuration:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;

    invoke-direct {p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;-><init>(Landroid/os/Bundle;Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;)V

    return-object p1
.end method

.method public encodeBoolean(Z)V
    .locals 2

    .line 122
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->savedState:Landroid/os/Bundle;

    .line 284
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 122
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->key:Ljava/lang/String;

    invoke-static {v0, v1, p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->putBoolean-impl(Landroid/os/Bundle;Ljava/lang/String;Z)V

    return-void
.end method

.method public encodeByte(B)V
    .locals 2

    .line 126
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->savedState:Landroid/os/Bundle;

    .line 285
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 126
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->key:Ljava/lang/String;

    invoke-static {v0, v1, p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->putInt-impl(Landroid/os/Bundle;Ljava/lang/String;I)V

    return-void
.end method

.method public encodeChar(C)V
    .locals 2

    .line 150
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->savedState:Landroid/os/Bundle;

    .line 291
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 150
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->key:Ljava/lang/String;

    invoke-static {v0, v1, p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->putChar-impl(Landroid/os/Bundle;Ljava/lang/String;C)V

    return-void
.end method

.method public encodeDouble(D)V
    .locals 2

    .line 146
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->savedState:Landroid/os/Bundle;

    .line 290
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 146
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->key:Ljava/lang/String;

    invoke-static {v0, v1, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->putDouble-impl(Landroid/os/Bundle;Ljava/lang/String;D)V

    return-void
.end method

.method public encodeElement(Lkotlinx/serialization/descriptors/SerialDescriptor;I)Z
    .locals 1

    const-string v0, "descriptor"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 97
    invoke-interface {p1, p2}, Lkotlinx/serialization/descriptors/SerialDescriptor;->getElementName(I)Ljava/lang/String;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->key:Ljava/lang/String;

    .line 98
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->savedState:Landroid/os/Bundle;

    invoke-direct {p0, p2, p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->checkDiscriminatorCollisions(Landroid/os/Bundle;Ljava/lang/String;)V

    const/4 p1, 0x1

    return p1
.end method

.method public encodeEnum(Lkotlinx/serialization/descriptors/SerialDescriptor;I)V
    .locals 1

    const-string v0, "enumDescriptor"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 158
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->savedState:Landroid/os/Bundle;

    .line 293
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object p1

    .line 158
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->key:Ljava/lang/String;

    invoke-static {p1, v0, p2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->putInt-impl(Landroid/os/Bundle;Ljava/lang/String;I)V

    return-void
.end method

.method public encodeFloat(F)V
    .locals 2

    .line 142
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->savedState:Landroid/os/Bundle;

    .line 289
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 142
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->key:Ljava/lang/String;

    invoke-static {v0, v1, p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->putFloat-impl(Landroid/os/Bundle;Ljava/lang/String;F)V

    return-void
.end method

.method public encodeInt(I)V
    .locals 2

    .line 134
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->savedState:Landroid/os/Bundle;

    .line 287
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 134
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->key:Ljava/lang/String;

    invoke-static {v0, v1, p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->putInt-impl(Landroid/os/Bundle;Ljava/lang/String;I)V

    return-void
.end method

.method public encodeLong(J)V
    .locals 2

    .line 138
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->savedState:Landroid/os/Bundle;

    .line 288
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 138
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->key:Ljava/lang/String;

    invoke-static {v0, v1, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->putLong-impl(Landroid/os/Bundle;Ljava/lang/String;J)V

    return-void
.end method

.method public encodeNull()V
    .locals 2

    .line 162
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->savedState:Landroid/os/Bundle;

    .line 294
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 162
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->key:Ljava/lang/String;

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->putNull-impl(Landroid/os/Bundle;Ljava/lang/String;)V

    return-void
.end method

.method public encodeSerializableValue(Lkotlinx/serialization/SerializationStrategy;Ljava/lang/Object;)V
    .locals 1

    const-string v0, "serializer"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 239
    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->encodeFormatSpecificTypes(Lkotlinx/serialization/SerializationStrategy;Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_0

    .line 241
    invoke-super {p0, p1, p2}, Lkotlinx/serialization/encoding/AbstractEncoder;->encodeSerializableValue(Lkotlinx/serialization/SerializationStrategy;Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method public encodeShort(S)V
    .locals 2

    .line 130
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->savedState:Landroid/os/Bundle;

    .line 286
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 130
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->key:Ljava/lang/String;

    invoke-static {v0, v1, p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->putInt-impl(Landroid/os/Bundle;Ljava/lang/String;I)V

    return-void
.end method

.method public encodeString(Ljava/lang/String;)V
    .locals 2

    const-string v0, "value"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 154
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->savedState:Landroid/os/Bundle;

    .line 292
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 154
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->key:Ljava/lang/String;

    invoke-static {v0, v1, p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->putString-impl(Landroid/os/Bundle;Ljava/lang/String;Ljava/lang/String;)V

    return-void
.end method

.method public final getKey$savedstate_release()Ljava/lang/String;
    .locals 1

    .line 84
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->key:Ljava/lang/String;

    return-object v0
.end method

.method public final getSavedState$savedstate_release()Landroid/os/Bundle;
    .locals 1

    .line 80
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->savedState:Landroid/os/Bundle;

    return-object v0
.end method

.method public getSerializersModule()Lkotlinx/serialization/modules/SerializersModule;
    .locals 1

    .line 87
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->serializersModule:Lkotlinx/serialization/modules/SerializersModule;

    return-object v0
.end method

.method public shouldEncodeElementDefault(Lkotlinx/serialization/descriptors/SerialDescriptor;I)Z
    .locals 0

    const-string p2, "descriptor"

    invoke-static {p1, p2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 90
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->configuration:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;->getEncodeDefaults()Z

    move-result p1

    return p1
.end method
