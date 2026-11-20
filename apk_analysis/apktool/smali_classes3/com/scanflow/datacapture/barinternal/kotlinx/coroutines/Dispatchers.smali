.class public final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Dispatchers;
.super Ljava/lang/Object;
.source "Dispatchers.kt"


# static fields
.field private static final Default:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;

.field public static final INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Dispatchers;

.field private static final Unconfined:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Dispatchers;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Dispatchers;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Dispatchers;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Dispatchers;

    .line 16
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/DefaultScheduler;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/DefaultScheduler;

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Dispatchers;->Default:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;

    .line 22
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Unconfined;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Unconfined;

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Dispatchers;->Unconfined:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 14
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static final getDefault()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;
    .locals 1

    .line 15
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Dispatchers;->Default:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;

    return-object v0
.end method

.method public static final getIO()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;
    .locals 1

    .line 64
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/DefaultIoScheduler;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/DefaultIoScheduler;

    return-object v0
.end method

.method public static final getMain()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/MainCoroutineDispatcher;
    .locals 1

    .line 19
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/MainDispatcherLoader;->dispatcher:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/MainCoroutineDispatcher;

    return-object v0
.end method
