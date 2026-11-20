.class public final Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UnitSerializer;
.super Ljava/lang/Object;
.source "Primitives.kt"

# interfaces
.implements Lkotlinx/serialization/KSerializer;


# static fields
.field public static final INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UnitSerializer;


# instance fields
.field private final synthetic $$delegate_0:Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ObjectSerializer;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UnitSerializer;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UnitSerializer;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UnitSerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UnitSerializer;

    return-void
.end method

.method private constructor <init>()V
    .locals 3

    .line 68
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 69
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ObjectSerializer;

    const-string v1, "kotlin.Unit"

    sget-object v2, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ObjectSerializer;-><init>(Ljava/lang/String;Ljava/lang/Object;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UnitSerializer;->$$delegate_0:Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ObjectSerializer;

    return-void
.end method


# virtual methods
.method public bridge synthetic deserialize(Lkotlinx/serialization/encoding/Decoder;)Ljava/lang/Object;
    .locals 0

    .line 68
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UnitSerializer;->deserialize(Lkotlinx/serialization/encoding/Decoder;)V

    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    return-object p1
.end method

.method public deserialize(Lkotlinx/serialization/encoding/Decoder;)V
    .locals 1

    .line 0
    const-string v0, "decoder"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UnitSerializer;->$$delegate_0:Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ObjectSerializer;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ObjectSerializer;->deserialize(Lkotlinx/serialization/encoding/Decoder;)Ljava/lang/Object;

    return-void
.end method

.method public getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UnitSerializer;->$$delegate_0:Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ObjectSerializer;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ObjectSerializer;->getDescriptor()Lkotlinx/serialization/descriptors/SerialDescriptor;

    move-result-object v0

    return-object v0
.end method

.method public serialize(Lkotlinx/serialization/encoding/Encoder;Lcom/scanflow/datacapture/barinternal/kotlin/Unit;)V
    .locals 1

    .line 0
    const-string v0, "encoder"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "value"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UnitSerializer;->$$delegate_0:Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ObjectSerializer;

    invoke-virtual {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ObjectSerializer;->serialize(Lkotlinx/serialization/encoding/Encoder;Ljava/lang/Object;)V

    return-void
.end method

.method public bridge synthetic serialize(Lkotlinx/serialization/encoding/Encoder;Ljava/lang/Object;)V
    .locals 0

    .line 68
    check-cast p2, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UnitSerializer;->serialize(Lkotlinx/serialization/encoding/Encoder;Lcom/scanflow/datacapture/barinternal/kotlin/Unit;)V

    return-void
.end method
