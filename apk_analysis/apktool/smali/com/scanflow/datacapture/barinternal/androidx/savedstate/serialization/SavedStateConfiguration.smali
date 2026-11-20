.class public final Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;
.super Ljava/lang/Object;
.source "SavedStateConfiguration.kt"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration$Companion;
    }
.end annotation


# static fields
.field public static final Companion:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration$Companion;

.field public static final DEFAULT:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;


# instance fields
.field private final classDiscriminatorMode:I

.field private final encodeDefaults:Z

.field private final serializersModule:Lkotlinx/serialization/modules/SerializersModule;


# direct methods
.method static constructor <clinit>()V
    .locals 8

    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration$Companion;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration$Companion;-><init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;->Companion:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration$Companion;

    .line 112
    new-instance v2, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;

    const/4 v6, 0x7

    const/4 v7, 0x0

    const/4 v3, 0x0

    const/4 v4, 0x0

    const/4 v5, 0x0

    invoke-direct/range {v2 .. v7}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;-><init>(Lkotlinx/serialization/modules/SerializersModule;IZILkotlin/jvm/internal/DefaultConstructorMarker;)V

    sput-object v2, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;->DEFAULT:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;

    return-void
.end method

.method private constructor <init>(Lkotlinx/serialization/modules/SerializersModule;IZ)V
    .locals 0

    .line 44
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 45
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;->serializersModule:Lkotlinx/serialization/modules/SerializersModule;

    .line 46
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;->classDiscriminatorMode:I

    .line 48
    iput-boolean p3, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;->encodeDefaults:Z

    return-void
.end method

.method synthetic constructor <init>(Lkotlinx/serialization/modules/SerializersModule;IZILkotlin/jvm/internal/DefaultConstructorMarker;)V
    .locals 0

    and-int/lit8 p5, p4, 0x1

    if-eqz p5, :cond_0

    .line 45
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfigurationKt;->access$getDEFAULT_SERIALIZERS_MODULE$p()Lkotlinx/serialization/modules/SerializersModule;

    move-result-object p1

    :cond_0
    and-int/lit8 p5, p4, 0x2

    if-eqz p5, :cond_1

    const/4 p2, 0x2

    :cond_1
    and-int/lit8 p4, p4, 0x4

    if-eqz p4, :cond_2

    const/4 p3, 0x0

    .line 44
    :cond_2
    invoke-direct {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;-><init>(Lkotlinx/serialization/modules/SerializersModule;IZ)V

    return-void
.end method


# virtual methods
.method public final getClassDiscriminatorMode()I
    .locals 1

    .line 46
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;->classDiscriminatorMode:I

    return v0
.end method

.method public final getEncodeDefaults()Z
    .locals 1

    .line 48
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;->encodeDefaults:Z

    return v0
.end method

.method public final getSerializersModule()Lkotlinx/serialization/modules/SerializersModule;
    .locals 1

    .line 45
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/SavedStateConfiguration;->serializersModule:Lkotlinx/serialization/modules/SerializersModule;

    return-object v0
.end method
