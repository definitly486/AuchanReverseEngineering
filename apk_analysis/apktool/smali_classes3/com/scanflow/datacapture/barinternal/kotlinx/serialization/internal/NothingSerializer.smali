.class public final Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/NothingSerializer;
.super Ljava/lang/Object;
.source "BuiltInSerializers.kt"

# interfaces
.implements Lkotlinx/serialization/KSerializer;


# static fields
.field public static final INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/NothingSerializer;

.field private static final descriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/NothingSerializer;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/NothingSerializer;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/NothingSerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/NothingSerializer;

    .line 33
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/NothingSerialDescriptor;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/NothingSerialDescriptor;

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/NothingSerializer;->descriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 31
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public bridge synthetic deserialize(Lkotlinx/serialization/encoding/Decoder;)Ljava/lang/Object;
    .locals 0

    .line 31
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/NothingSerializer;->deserialize(Lkotlinx/serialization/encoding/Decoder;)Ljava/lang/Void;

    move-result-object p1

    return-object p1
.end method

.method public deserialize(Lkotlinx/serialization/encoding/Decoder;)Ljava/lang/Void;
    .locals 1

    const-string v0, "decoder"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 40
    new-instance p1, Lkotlinx/serialization/SerializationException;

    const-string v0, "\'kotlin.Nothing\' does not have instances"

    invoke-direct {p1, v0}, Lkotlinx/serialization/SerializationException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 33
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/NothingSerializer;->descriptor:Lkotlinx/serialization/descriptors/SerialDescriptor;

    return-object v0
.end method

.method public bridge synthetic serialize(Lkotlinx/serialization/encoding/Encoder;Ljava/lang/Object;)V
    .locals 0

    .line 31
    check-cast p2, Ljava/lang/Void;

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/NothingSerializer;->serialize(Lkotlinx/serialization/encoding/Encoder;Ljava/lang/Void;)V

    return-void
.end method

.method public serialize(Lkotlinx/serialization/encoding/Encoder;Ljava/lang/Void;)V
    .locals 1

    const-string v0, "encoder"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string p1, "value"

    invoke-static {p2, p1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 36
    new-instance p1, Lkotlinx/serialization/SerializationException;

    const-string p2, "\'kotlin.Nothing\' cannot be serialized"

    invoke-direct {p1, p2}, Lkotlinx/serialization/SerializationException;-><init>(Ljava/lang/String;)V

    throw p1
.end method
