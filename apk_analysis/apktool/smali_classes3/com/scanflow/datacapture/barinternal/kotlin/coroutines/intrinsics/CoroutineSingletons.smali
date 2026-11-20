.class public final enum Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/CoroutineSingletons;
.super Ljava/lang/Enum;
.source "Intrinsics.kt"


# static fields
.field private static final synthetic $ENTRIES:Lkotlin/enums/EnumEntries;

.field private static final synthetic $VALUES:[Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/CoroutineSingletons;

.field public static final enum COROUTINE_SUSPENDED:Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/CoroutineSingletons;

.field public static final enum RESUMED:Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/CoroutineSingletons;

.field public static final enum UNDECIDED:Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/CoroutineSingletons;


# direct methods
.method private static final synthetic $values()[Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/CoroutineSingletons;
    .locals 3

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/CoroutineSingletons;->COROUTINE_SUSPENDED:Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/CoroutineSingletons;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/CoroutineSingletons;->UNDECIDED:Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/CoroutineSingletons;

    sget-object v2, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/CoroutineSingletons;->RESUMED:Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/CoroutineSingletons;

    filled-new-array {v0, v1, v2}, [Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/CoroutineSingletons;

    move-result-object v0

    return-object v0
.end method

.method static constructor <clinit>()V
    .locals 3

    .line 64
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/CoroutineSingletons;

    const-string v1, "COROUTINE_SUSPENDED"

    const/4 v2, 0x0

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/CoroutineSingletons;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/CoroutineSingletons;->COROUTINE_SUSPENDED:Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/CoroutineSingletons;

    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/CoroutineSingletons;

    const-string v1, "UNDECIDED"

    const/4 v2, 0x1

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/CoroutineSingletons;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/CoroutineSingletons;->UNDECIDED:Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/CoroutineSingletons;

    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/CoroutineSingletons;

    const-string v1, "RESUMED"

    const/4 v2, 0x2

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/CoroutineSingletons;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/CoroutineSingletons;->RESUMED:Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/CoroutineSingletons;

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/CoroutineSingletons;->$values()[Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/CoroutineSingletons;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/CoroutineSingletons;->$VALUES:[Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/CoroutineSingletons;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/enums/EnumEntriesKt;->enumEntries([Ljava/lang/Enum;)Lkotlin/enums/EnumEntries;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/CoroutineSingletons;->$ENTRIES:Lkotlin/enums/EnumEntries;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;I)V
    .locals 0

    .line 62
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    return-void
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/CoroutineSingletons;
    .locals 1

    .line 0
    const-class v0, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/CoroutineSingletons;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/CoroutineSingletons;

    return-object p0
.end method

.method public static values()[Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/CoroutineSingletons;
    .locals 1

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/CoroutineSingletons;->$VALUES:[Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/CoroutineSingletons;

    invoke-virtual {v0}, Ljava/lang/Object;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/CoroutineSingletons;

    return-object v0
.end method
