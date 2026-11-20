.class public abstract Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/SemaphoreKt;
.super Ljava/lang/Object;
.source "Semaphore.kt"


# static fields
.field private static final BROKEN:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

.field private static final CANCELLED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

.field private static final MAX_SPIN_CYCLES:I

.field private static final PERMIT:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

.field private static final SEGMENT_SIZE:I

.field private static final TAKEN:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;


# direct methods
.method static constructor <clinit>()V
    .locals 8

    const/16 v4, 0xc

    const/4 v5, 0x0

    .line 390
    const-string v0, "kotlinx.coroutines.semaphore.maxSpinCycles"

    const/16 v1, 0x64

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/SystemPropsKt;->systemProp$default(Ljava/lang/String;IIIILjava/lang/Object;)I

    move-result v0

    sput v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/SemaphoreKt;->MAX_SPIN_CYCLES:I

    .line 391
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    const-string v1, "PERMIT"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;-><init>(Ljava/lang/String;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/SemaphoreKt;->PERMIT:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    .line 392
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    const-string v1, "TAKEN"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;-><init>(Ljava/lang/String;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/SemaphoreKt;->TAKEN:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    .line 393
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    const-string v1, "BROKEN"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;-><init>(Ljava/lang/String;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/SemaphoreKt;->BROKEN:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    .line 394
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    const-string v1, "CANCELLED"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;-><init>(Ljava/lang/String;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/SemaphoreKt;->CANCELLED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    const/16 v6, 0xc

    const/4 v7, 0x0

    .line 395
    const-string v2, "kotlinx.coroutines.semaphore.segmentSize"

    const/16 v3, 0x10

    const/4 v4, 0x0

    const/4 v5, 0x0

    invoke-static/range {v2 .. v7}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/SystemPropsKt;->systemProp$default(Ljava/lang/String;IIIILjava/lang/Object;)I

    move-result v0

    sput v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/SemaphoreKt;->SEGMENT_SIZE:I

    return-void
.end method

.method public static final Semaphore(II)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/Semaphore;
    .locals 1

    .line 68
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/SemaphoreImpl;

    invoke-direct {v0, p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/SemaphoreImpl;-><init>(II)V

    return-object v0
.end method

.method public static synthetic Semaphore$default(IIILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/Semaphore;
    .locals 0

    and-int/lit8 p2, p2, 0x2

    if-eqz p2, :cond_0

    const/4 p1, 0x0

    .line 67
    :cond_0
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/SemaphoreKt;->Semaphore(II)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/Semaphore;

    move-result-object p0

    return-object p0
.end method

.method public static final synthetic access$createSegment(JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/SemaphoreSegment;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/SemaphoreSegment;
    .locals 0

    .line 1
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/SemaphoreKt;->createSegment(JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/SemaphoreSegment;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/SemaphoreSegment;

    move-result-object p0

    return-object p0
.end method

.method public static final synthetic access$getBROKEN$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;
    .locals 1

    .line 1
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/SemaphoreKt;->BROKEN:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    return-object v0
.end method

.method public static final synthetic access$getCANCELLED$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;
    .locals 1

    .line 1
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/SemaphoreKt;->CANCELLED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    return-object v0
.end method

.method public static final synthetic access$getMAX_SPIN_CYCLES$p()I
    .locals 1

    .line 1
    sget v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/SemaphoreKt;->MAX_SPIN_CYCLES:I

    return v0
.end method

.method public static final synthetic access$getPERMIT$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;
    .locals 1

    .line 1
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/SemaphoreKt;->PERMIT:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    return-object v0
.end method

.method public static final synthetic access$getSEGMENT_SIZE$p()I
    .locals 1

    .line 1
    sget v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/SemaphoreKt;->SEGMENT_SIZE:I

    return v0
.end method

.method public static final synthetic access$getTAKEN$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;
    .locals 1

    .line 1
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/SemaphoreKt;->TAKEN:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    return-object v0
.end method

.method private static final createSegment(JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/SemaphoreSegment;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/SemaphoreSegment;
    .locals 2

    .line 359
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/SemaphoreSegment;

    const/4 v1, 0x0

    invoke-direct {v0, p0, p1, p2, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/SemaphoreSegment;-><init>(JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/SemaphoreSegment;I)V

    return-object v0
.end method
