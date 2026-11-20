.class public final Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UIntSerializer;
.super Ljava/lang/Object;
.source "ValueClasses.kt"

# interfaces
.implements Lkotlinx/serialization/KSerializer;


# static fields
.field public static final INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UIntSerializer;

.field private static final descriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UIntSerializer;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UIntSerializer;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UIntSerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UIntSerializer;

    .line 14
    sget-object v0, Lkotlin/jvm/internal/IntCompanionObject;->INSTANCE:Lkotlin/jvm/internal/IntCompanionObject;

    invoke-static {v0}, Lkotlinx/serialization/builtins/BuiltinSerializersKt;->serializer(Lkotlin/jvm/internal/IntCompanionObject;)Lkotlinx/serialization/KSerializer;

    move-result-object v0

    const-string v1, "kotlin.UInt"

    invoke-static {v1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/InlineClassDescriptorKt;->InlinePrimitiveDescriptor(Ljava/lang/String;Lkotlinx/serialization/KSerializer;)Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UIntSerializer;->descriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 12
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public bridge synthetic deserialize(Lkotlinx/serialization/encoding/Decoder;)Ljava/lang/Object;
    .locals 0

    .line 12
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UIntSerializer;->deserialize-OGnWXxg(Lkotlinx/serialization/encoding/Decoder;)I

    move-result p1

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/UInt;->box-impl(I)Lcom/scanflow/datacapture/barinternal/kotlin/UInt;

    move-result-object p1

    return-object p1
.end method

.method public deserialize-OGnWXxg(Lkotlinx/serialization/encoding/Decoder;)I
    .locals 1

    const-string v0, "decoder"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 21
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UIntSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    invoke-interface {p1, v0}, Lkotlinx/serialization/encoding/Decoder;->decodeInline(Lkotlinx/serialization/descriptors/SerialDescriptor;)Lkotlinx/serialization/encoding/Decoder;

    move-result-object p1

    invoke-interface {p1}, Lkotlinx/serialization/encoding/Decoder;->decodeInt()I

    move-result p1

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/UInt;->constructor-impl(I)I

    move-result p1

    return p1
.end method

.method public getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 14
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UIntSerializer;->descriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-object v0
.end method

.method public bridge synthetic serialize(Lkotlinx/serialization/encoding/Encoder;Ljava/lang/Object;)V
    .locals 0

    .line 12
    check-cast p2, Lcom/scanflow/datacapture/barinternal/kotlin/UInt;

    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/kotlin/UInt;->unbox-impl()I

    move-result p2

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UIntSerializer;->serialize-Qn1smSk(Lkotlinx/serialization/encoding/Encoder;I)V

    return-void
.end method

.method public serialize-Qn1smSk(Lkotlinx/serialization/encoding/Encoder;I)V
    .locals 1

    const-string v0, "encoder"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 17
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UIntSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    invoke-interface {p1, v0}, Lkotlinx/serialization/encoding/Encoder;->encodeInline(Lkotlinx/serialization/descriptors/SerialDescriptor;)Lkotlinx/serialization/encoding/Encoder;

    move-result-object p1

    invoke-interface {p1, p2}, Lkotlinx/serialization/encoding/Encoder;->encodeInt(I)V

    return-void
.end method
