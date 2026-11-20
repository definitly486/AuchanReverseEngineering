.class public final Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UByteArrayBuilder;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArrayBuilder;
.source "PrimitiveArraysSerializers.kt"


# instance fields
.field private buffer:[B

.field private position:I


# direct methods
.method private constructor <init>([B)V
    .locals 1

    const-string v0, "bufferWithData"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 446
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArrayBuilder;-><init>()V

    .line 448
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UByteArrayBuilder;->buffer:[B

    .line 449
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/UByteArray;->getSize-impl([B)I

    move-result p1

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UByteArrayBuilder;->position:I

    const/16 p1, 0xa

    .line 453
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UByteArrayBuilder;->ensureCapacity$kotlinx_serialization_core(I)V

    return-void
.end method

.method public synthetic constructor <init>([BLkotlin/jvm/internal/DefaultConstructorMarker;)V
    .locals 0

    .line 0
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UByteArrayBuilder;-><init>([B)V

    return-void
.end method


# virtual methods
.method public final append-7apg3OU$kotlinx_serialization_core(B)V
    .locals 3

    const/4 v0, 0x1

    const/4 v1, 0x0

    const/4 v2, 0x0

    .line 462
    invoke-static {p0, v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArrayBuilder;->ensureCapacity$kotlinx_serialization_core$default(Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/PrimitiveArrayBuilder;IILjava/lang/Object;)V

    .line 463
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UByteArrayBuilder;->buffer:[B

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UByteArrayBuilder;->getPosition$kotlinx_serialization_core()I

    move-result v1

    add-int/lit8 v2, v1, 0x1

    iput v2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UByteArrayBuilder;->position:I

    invoke-static {v0, v1, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/UByteArray;->set-VurrAj0([BIB)V

    return-void
.end method

.method public bridge synthetic build$kotlinx_serialization_core()Ljava/lang/Object;
    .locals 1

    .line 441
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UByteArrayBuilder;->build-TcUX1vc$kotlinx_serialization_core()[B

    move-result-object v0

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/UByteArray;->box-impl([B)Lcom/scanflow/datacapture/barinternal/kotlin/UByteArray;

    move-result-object v0

    return-object v0
.end method

.method public build-TcUX1vc$kotlinx_serialization_core()[B
    .locals 2

    .line 466
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UByteArrayBuilder;->buffer:[B

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UByteArrayBuilder;->getPosition$kotlinx_serialization_core()I

    move-result v1

    invoke-static {v0, v1}, Ljava/util/Arrays;->copyOf([BI)[B

    move-result-object v0

    const-string v1, "copyOf(...)"

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/UByteArray;->constructor-impl([B)[B

    move-result-object v0

    return-object v0
.end method

.method public ensureCapacity$kotlinx_serialization_core(I)V
    .locals 2

    .line 457
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UByteArrayBuilder;->buffer:[B

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/UByteArray;->getSize-impl([B)I

    move-result v0

    if-ge v0, p1, :cond_0

    .line 458
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UByteArrayBuilder;->buffer:[B

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/UByteArray;->getSize-impl([B)I

    move-result v1

    mul-int/lit8 v1, v1, 0x2

    invoke-static {p1, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/RangesKt;->coerceAtLeast(II)I

    move-result p1

    invoke-static {v0, p1}, Ljava/util/Arrays;->copyOf([BI)[B

    move-result-object p1

    const-string v0, "copyOf(...)"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/UByteArray;->constructor-impl([B)[B

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UByteArrayBuilder;->buffer:[B

    :cond_0
    return-void
.end method

.method public getPosition$kotlinx_serialization_core()I
    .locals 1

    .line 449
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/UByteArrayBuilder;->position:I

    return v0
.end method
