.class public final enum Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;
.super Ljava/lang/Enum;
.source "CoroutineStart.kt"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart$WhenMappings;
    }
.end annotation


# static fields
.field private static final synthetic $ENTRIES:Lkotlin/enums/EnumEntries;

.field private static final synthetic $VALUES:[Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;

.field public static final enum ATOMIC:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;

.field public static final enum DEFAULT:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;

.field public static final enum LAZY:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;

.field public static final enum UNDISPATCHED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;


# direct methods
.method private static final synthetic $values()[Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;
    .locals 4

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;->DEFAULT:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;->LAZY:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;

    sget-object v2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;->ATOMIC:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;

    sget-object v3, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;->UNDISPATCHED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;

    filled-new-array {v0, v1, v2, v3}, [Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;

    move-result-object v0

    return-object v0
.end method

.method static constructor <clinit>()V
    .locals 3

    .line 78
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;

    const-string v1, "DEFAULT"

    const/4 v2, 0x0

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;->DEFAULT:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;

    .line 163
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;

    const-string v1, "LAZY"

    const/4 v2, 0x1

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;->LAZY:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;

    .line 240
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;

    const-string v1, "ATOMIC"

    const/4 v2, 0x2

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;->ATOMIC:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;

    .line 343
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;

    const-string v1, "UNDISPATCHED"

    const/4 v2, 0x3

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;->UNDISPATCHED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;->$values()[Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;->$VALUES:[Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/enums/EnumEntriesKt;->enumEntries([Ljava/lang/Enum;)Lkotlin/enums/EnumEntries;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;->$ENTRIES:Lkotlin/enums/EnumEntries;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;I)V
    .locals 0

    .line 23
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    return-void
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;
    .locals 1

    const-class v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object p0

    .line 371
    check-cast p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;

    return-object p0
.end method

.method public static values()[Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;
    .locals 1

    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;->$VALUES:[Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;

    invoke-virtual {v0}, Ljava/lang/Object;->clone()Ljava/lang/Object;

    move-result-object v0

    .line 371
    check-cast v0, [Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;

    return-object v0
.end method


# virtual methods
.method public final invoke(Lkotlin/jvm/functions/Function2;Ljava/lang/Object;Lkotlin/coroutines/Continuation;)V
    .locals 2

    .line 357
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart$WhenMappings;->$EnumSwitchMapping$0:[I

    invoke-virtual {p0}, Ljava/lang/Enum;->ordinal()I

    move-result v1

    aget v0, v0, v1

    const/4 v1, 0x1

    if-eq v0, v1, :cond_3

    const/4 v1, 0x2

    if-eq v0, v1, :cond_2

    const/4 v1, 0x3

    if-eq v0, v1, :cond_1

    const/4 p1, 0x4

    if-ne v0, p1, :cond_0

    return-void

    :cond_0
    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlin/NoWhenBranchMatchedException;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/NoWhenBranchMatchedException;-><init>()V

    throw p1

    .line 360
    :cond_1
    invoke-static {p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/intrinsics/UndispatchedKt;->startCoroutineUndispatched(Lkotlin/jvm/functions/Function2;Ljava/lang/Object;Lkotlin/coroutines/Continuation;)V

    return-void

    .line 359
    :cond_2
    invoke-static {p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/ContinuationKt;->startCoroutine(Lkotlin/jvm/functions/Function2;Ljava/lang/Object;Lkotlin/coroutines/Continuation;)V

    return-void

    .line 358
    :cond_3
    invoke-static {p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/intrinsics/CancellableKt;->startCoroutineCancellable(Lkotlin/jvm/functions/Function2;Ljava/lang/Object;Lkotlin/coroutines/Continuation;)V

    return-void
.end method

.method public final isLazy()Z
    .locals 1

    .line 370
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;->LAZY:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;

    if-ne p0, v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method
