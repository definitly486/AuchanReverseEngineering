.class public final Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SizeFSerializer;
.super Ljava/lang/Object;
.source "BuiltInSerializer.android.kt"

# interfaces
.implements Lkotlinx/serialization/KSerializer;


# static fields
.field public static final INSTANCE:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SizeFSerializer;

.field private static final descriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;


# direct methods
.method static constructor <clinit>()V
    .locals 4

    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SizeFSerializer;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SizeFSerializer;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SizeFSerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SizeFSerializer;

    const/4 v0, 0x0

    .line 83
    new-array v0, v0, [Lkotlinx/serialization/descriptors/SerialDescriptor;

    const/4 v1, 0x0

    const/4 v2, 0x4

    const-string v3, "android.util.SizeF"

    invoke-static {v3, v0, v1, v2, v1}, Lkotlinx/serialization/descriptors/SerialDescriptorsKt;->buildClassSerialDescriptor$default(Ljava/lang/String;[Lkotlinx/serialization/descriptors/SerialDescriptor;Lkotlin/jvm/functions/Function1;ILjava/lang/Object;)Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SizeFSerializer;->descriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 81
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public deserialize(Lkotlinx/serialization/encoding/Decoder;)Landroid/util/SizeF;
    .locals 1

    const-string v0, "decoder"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 93
    instance-of v0, p1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;

    if-eqz v0, :cond_0

    .line 96
    check-cast p1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->getSavedState$savedstate_release()Landroid/os/Bundle;

    move-result-object v0

    .line 424
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 96
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->getKey$savedstate_release()Ljava/lang/String;

    move-result-object p1

    invoke-static {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->getSizeF-impl(Landroid/os/Bundle;Ljava/lang/String;)Landroid/util/SizeF;

    move-result-object p1

    return-object p1

    .line 94
    :cond_0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SizeFSerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SizeFSerializer;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SizeFSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    invoke-interface {v0}, Lkotlinx/serialization/descriptors/SerialDescriptor;->getSerialName()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/BuiltInSerializerKt;->decoderErrorMessage(Ljava/lang/String;Lkotlinx/serialization/encoding/Decoder;)Ljava/lang/String;

    move-result-object p1

    .line 93
    new-instance v0, Ljava/lang/IllegalArgumentException;

    invoke-virtual {p1}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {v0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method public bridge synthetic deserialize(Lkotlinx/serialization/encoding/Decoder;)Ljava/lang/Object;
    .locals 0

    .line 81
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SizeFSerializer;->deserialize(Lkotlinx/serialization/encoding/Decoder;)Landroid/util/SizeF;

    move-result-object p1

    return-object p1
.end method

.method public getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 83
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SizeFSerializer;->descriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-object v0
.end method

.method public serialize(Lkotlinx/serialization/encoding/Encoder;Landroid/util/SizeF;)V
    .locals 1

    const-string v0, "encoder"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "value"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 86
    instance-of v0, p1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;

    if-eqz v0, :cond_0

    .line 89
    check-cast p1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->getSavedState$savedstate_release()Landroid/os/Bundle;

    move-result-object v0

    .line 423
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 89
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->getKey$savedstate_release()Ljava/lang/String;

    move-result-object p1

    invoke-static {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->putSizeF-impl(Landroid/os/Bundle;Ljava/lang/String;Landroid/util/SizeF;)V

    return-void

    .line 87
    :cond_0
    sget-object p2, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SizeFSerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SizeFSerializer;

    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SizeFSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object p2

    invoke-interface {p2}, Lkotlinx/serialization/descriptors/SerialDescriptor;->getSerialName()Ljava/lang/String;

    move-result-object p2

    invoke-static {p2, p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/BuiltInSerializerKt;->encoderErrorMessage(Ljava/lang/String;Lkotlinx/serialization/encoding/Encoder;)Ljava/lang/String;

    move-result-object p1

    .line 86
    new-instance p2, Ljava/lang/IllegalArgumentException;

    invoke-virtual {p1}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {p2, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p2
.end method

.method public bridge synthetic serialize(Lkotlinx/serialization/encoding/Encoder;Ljava/lang/Object;)V
    .locals 0

    .line 81
    check-cast p2, Landroid/util/SizeF;

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SizeFSerializer;->serialize(Lkotlinx/serialization/encoding/Encoder;Landroid/util/SizeF;)V

    return-void
.end method
