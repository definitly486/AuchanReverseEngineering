.class public final Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SavedStateSerializer;
.super Ljava/lang/Object;
.source "BuiltInSerializer.kt"

# interfaces
.implements Lkotlinx/serialization/KSerializer;


# static fields
.field public static final INSTANCE:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SavedStateSerializer;

.field private static final descriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;


# direct methods
.method static constructor <clinit>()V
    .locals 4

    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SavedStateSerializer;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SavedStateSerializer;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SavedStateSerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SavedStateSerializer;

    const/4 v0, 0x0

    .line 47
    new-array v0, v0, [Lkotlinx/serialization/descriptors/SerialDescriptor;

    const/4 v1, 0x0

    const/4 v2, 0x4

    const-string v3, "androidx.savedstate.SavedState"

    invoke-static {v3, v0, v1, v2, v1}, Lkotlinx/serialization/descriptors/SerialDescriptorsKt;->buildClassSerialDescriptor$default(Ljava/lang/String;[Lkotlinx/serialization/descriptors/SerialDescriptor;Lkotlin/jvm/functions/Function1;ILjava/lang/Object;)Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SavedStateSerializer;->descriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 44
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public deserialize(Lkotlinx/serialization/encoding/Decoder;)Landroid/os/Bundle;
    .locals 2

    const-string v0, "decoder"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 63
    instance-of v0, p1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;

    if-eqz v0, :cond_1

    .line 66
    check-cast p1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;

    .line 67
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->getKey$savedstate_release()Ljava/lang/String;

    move-result-object v0

    const-string v1, ""

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 68
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->getSavedState$savedstate_release()Landroid/os/Bundle;

    move-result-object p1

    return-object p1

    .line 70
    :cond_0
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->getSavedState$savedstate_release()Landroid/os/Bundle;

    move-result-object v0

    .line 90
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 70
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateDecoder;->getKey$savedstate_release()Ljava/lang/String;

    move-result-object p1

    invoke-static {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->getSavedState-impl(Landroid/os/Bundle;Ljava/lang/String;)Landroid/os/Bundle;

    move-result-object p1

    return-object p1

    .line 64
    :cond_1
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SavedStateSerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SavedStateSerializer;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SavedStateSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    invoke-interface {v0}, Lkotlinx/serialization/descriptors/SerialDescriptor;->getSerialName()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/BuiltInSerializerKt;->decoderErrorMessage(Ljava/lang/String;Lkotlinx/serialization/encoding/Decoder;)Ljava/lang/String;

    move-result-object p1

    .line 63
    new-instance v0, Ljava/lang/IllegalArgumentException;

    invoke-virtual {p1}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {v0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method public bridge synthetic deserialize(Lkotlinx/serialization/encoding/Decoder;)Ljava/lang/Object;
    .locals 0

    .line 44
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SavedStateSerializer;->deserialize(Lkotlinx/serialization/encoding/Decoder;)Landroid/os/Bundle;

    move-result-object p1

    return-object p1
.end method

.method public getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 46
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SavedStateSerializer;->descriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-object v0
.end method

.method public serialize(Lkotlinx/serialization/encoding/Encoder;Landroid/os/Bundle;)V
    .locals 2

    const-string v0, "encoder"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "value"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 50
    instance-of v0, p1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;

    if-eqz v0, :cond_1

    .line 53
    check-cast p1, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;

    .line 54
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->getKey$savedstate_release()Ljava/lang/String;

    move-result-object v0

    const-string v1, ""

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 55
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->getSavedState$savedstate_release()Landroid/os/Bundle;

    move-result-object p1

    .line 88
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object p1

    .line 55
    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->putAll-impl(Landroid/os/Bundle;Landroid/os/Bundle;)V

    return-void

    .line 57
    :cond_0
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->getSavedState$savedstate_release()Landroid/os/Bundle;

    move-result-object v0

    .line 89
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v0

    .line 57
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateEncoder;->getKey$savedstate_release()Ljava/lang/String;

    move-result-object p1

    invoke-static {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateWriter;->putSavedState-impl(Landroid/os/Bundle;Ljava/lang/String;Landroid/os/Bundle;)V

    return-void

    .line 51
    :cond_1
    sget-object p2, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SavedStateSerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SavedStateSerializer;

    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SavedStateSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object p2

    invoke-interface {p2}, Lkotlinx/serialization/descriptors/SerialDescriptor;->getSerialName()Ljava/lang/String;

    move-result-object p2

    invoke-static {p2, p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/BuiltInSerializerKt;->encoderErrorMessage(Ljava/lang/String;Lkotlinx/serialization/encoding/Encoder;)Ljava/lang/String;

    move-result-object p1

    .line 50
    new-instance p2, Ljava/lang/IllegalArgumentException;

    invoke-virtual {p1}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {p2, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p2
.end method

.method public bridge synthetic serialize(Lkotlinx/serialization/encoding/Encoder;Ljava/lang/Object;)V
    .locals 0

    .line 44
    check-cast p2, Landroid/os/Bundle;

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/SavedStateSerializer;->serialize(Lkotlinx/serialization/encoding/Encoder;Landroid/os/Bundle;)V

    return-void
.end method
