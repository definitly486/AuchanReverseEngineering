.class final Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/EmptyArrayDecoder;
.super Lkotlinx/serialization/encoding/AbstractDecoder;
.source "SavedStateDecoder.android.kt"


# static fields
.field public static final INSTANCE:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/EmptyArrayDecoder;

.field private static final serializersModule:Lkotlinx/serialization/modules/SerializersModule;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/EmptyArrayDecoder;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/EmptyArrayDecoder;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/EmptyArrayDecoder;->INSTANCE:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/EmptyArrayDecoder;

    .line 83
    invoke-static {}, Lkotlinx/serialization/modules/SerializersModuleBuildersKt;->EmptySerializersModule()Lkotlinx/serialization/modules/SerializersModule;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/EmptyArrayDecoder;->serializersModule:Lkotlinx/serialization/modules/SerializersModule;

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 82
    invoke-direct {p0}, Lkotlinx/serialization/encoding/AbstractDecoder;-><init>()V

    return-void
.end method


# virtual methods
.method public decodeElementIndex(Lkotlinx/serialization/descriptors/SerialDescriptor;)I
    .locals 1

    .line 0
    const-string v0, "descriptor"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const/4 p1, -0x1

    return p1
.end method

.method public getSerializersModule()Lkotlinx/serialization/modules/SerializersModule;
    .locals 1

    .line 83
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/EmptyArrayDecoder;->serializersModule:Lkotlinx/serialization/modules/SerializersModule;

    return-object v0
.end method
