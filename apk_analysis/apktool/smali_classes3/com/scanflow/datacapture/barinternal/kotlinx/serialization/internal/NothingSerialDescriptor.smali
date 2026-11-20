.class public final Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/NothingSerialDescriptor;
.super Ljava/lang/Object;
.source "NothingSerialDescriptor.kt"

# interfaces
.implements Lkotlinx/serialization/descriptors/SerialDescriptor;


# static fields
.field public static final INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/NothingSerialDescriptor;

.field private static final kind:Lkotlinx/serialization/descriptors/SerialKind;

.field private static final serialName:Ljava/lang/String;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/NothingSerialDescriptor;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/NothingSerialDescriptor;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/NothingSerialDescriptor;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/NothingSerialDescriptor;

    .line 15
    sget-object v0, Lkotlinx/serialization/descriptors/StructureKind$OBJECT;->INSTANCE:Lkotlinx/serialization/descriptors/StructureKind$OBJECT;

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/NothingSerialDescriptor;->kind:Lkotlinx/serialization/descriptors/SerialKind;

    .line 17
    const-string v0, "kotlin.Nothing"

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/NothingSerialDescriptor;->serialName:Ljava/lang/String;

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 14
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method private final error()Ljava/lang/Void;
    .locals 2

    .line 32
    new-instance v0, Ljava/lang/IllegalStateException;

    const-string v1, "Descriptor for type `kotlin.Nothing` does not have elements"

    invoke-direct {v0, v1}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw v0
.end method


# virtual methods
.method public equals(Ljava/lang/Object;)Z
    .locals 0

    .line 27
    if-ne p0, p1, :cond_0

    const/4 p1, 0x1

    return p1

    :cond_0
    const/4 p1, 0x0

    return p1
.end method

.method public getAnnotations()Ljava/util/List;
    .locals 1

    .line 14
    invoke-super {p0}, Lkotlinx/serialization/descriptors/SerialDescriptor;->getAnnotations()Ljava/util/List;

    move-result-object v0

    return-object v0
.end method

.method public getElementDescriptor(I)Lkotlinx/serialization/descriptors/SerialDescriptor;
    .locals 0

    .line 23
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/NothingSerialDescriptor;->error()Ljava/lang/Void;

    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p1
.end method

.method public getElementName(I)Ljava/lang/String;
    .locals 0

    .line 20
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/NothingSerialDescriptor;->error()Ljava/lang/Void;

    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p1
.end method

.method public getElementsCount()I
    .locals 1

    .line 19
    const/4 v0, 0x0

    return v0
.end method

.method public getKind()Lkotlinx/serialization/descriptors/SerialKind;
    .locals 1

    .line 15
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/NothingSerialDescriptor;->kind:Lkotlinx/serialization/descriptors/SerialKind;

    return-object v0
.end method

.method public getSerialName()Ljava/lang/String;
    .locals 1

    .line 17
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/NothingSerialDescriptor;->serialName:Ljava/lang/String;

    return-object v0
.end method

.method public hashCode()I
    .locals 2

    .line 30
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/NothingSerialDescriptor;->getSerialName()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/String;->hashCode()I

    move-result v0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/NothingSerialDescriptor;->getKind()Lkotlinx/serialization/descriptors/SerialKind;

    move-result-object v1

    invoke-virtual {v1}, Lkotlinx/serialization/descriptors/SerialKind;->hashCode()I

    move-result v1

    mul-int/lit8 v1, v1, 0x1f

    add-int/2addr v0, v1

    return v0
.end method

.method public isElementOptional(I)Z
    .locals 0

    .line 22
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/NothingSerialDescriptor;->error()Ljava/lang/Void;

    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p1
.end method

.method public isNullable()Z
    .locals 1

    .line 14
    invoke-super {p0}, Lkotlinx/serialization/descriptors/SerialDescriptor;->isNullable()Z

    move-result v0

    return v0
.end method

.method public toString()Ljava/lang/String;
    .locals 1

    .line 25
    const-string v0, "NothingSerialDescriptor"

    return-object v0
.end method
