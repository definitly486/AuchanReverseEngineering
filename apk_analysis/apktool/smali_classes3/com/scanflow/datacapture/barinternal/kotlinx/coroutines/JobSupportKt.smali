.class public abstract Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupportKt;
.super Ljava/lang/Object;
.source "JobSupport.kt"


# static fields
.field private static final COMPLETING_ALREADY:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

.field private static final COMPLETING_RETRY:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

.field public static final COMPLETING_WAITING_CHILDREN:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

.field private static final EMPTY_ACTIVE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Empty;

.field private static final EMPTY_NEW:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Empty;

.field private static final SEALED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

.field private static final TOO_LATE_TO_CANCEL:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 1399
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    const-string v1, "COMPLETING_ALREADY"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;-><init>(Ljava/lang/String;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupportKt;->COMPLETING_ALREADY:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    .line 1401
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    const-string v1, "COMPLETING_WAITING_CHILDREN"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;-><init>(Ljava/lang/String;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupportKt;->COMPLETING_WAITING_CHILDREN:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    .line 1402
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    const-string v1, "COMPLETING_RETRY"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;-><init>(Ljava/lang/String;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupportKt;->COMPLETING_RETRY:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    .line 1403
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    const-string v1, "TOO_LATE_TO_CANCEL"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;-><init>(Ljava/lang/String;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupportKt;->TOO_LATE_TO_CANCEL:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    .line 1409
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    const-string v1, "SEALED"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;-><init>(Ljava/lang/String;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupportKt;->SEALED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    .line 1410
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Empty;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Empty;-><init>(Z)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupportKt;->EMPTY_NEW:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Empty;

    .line 1411
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Empty;

    const/4 v1, 0x1

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Empty;-><init>(Z)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupportKt;->EMPTY_ACTIVE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Empty;

    return-void
.end method

.method public static final synthetic access$getCOMPLETING_ALREADY$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;
    .locals 1

    .line 1
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupportKt;->COMPLETING_ALREADY:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    return-object v0
.end method

.method public static final synthetic access$getCOMPLETING_RETRY$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;
    .locals 1

    .line 1
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupportKt;->COMPLETING_RETRY:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    return-object v0
.end method

.method public static final synthetic access$getEMPTY_ACTIVE$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Empty;
    .locals 1

    .line 1
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupportKt;->EMPTY_ACTIVE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Empty;

    return-object v0
.end method

.method public static final synthetic access$getEMPTY_NEW$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Empty;
    .locals 1

    .line 1
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupportKt;->EMPTY_NEW:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Empty;

    return-object v0
.end method

.method public static final synthetic access$getSEALED$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;
    .locals 1

    .line 1
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupportKt;->SEALED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    return-object v0
.end method

.method public static final synthetic access$getTOO_LATE_TO_CANCEL$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;
    .locals 1

    .line 1
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupportKt;->TOO_LATE_TO_CANCEL:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    return-object v0
.end method

.method public static final boxIncomplete(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 1

    .line 1394
    instance-of v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Incomplete;

    if-eqz v0, :cond_0

    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/IncompleteStateBox;

    check-cast p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Incomplete;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/IncompleteStateBox;-><init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Incomplete;)V

    return-object v0

    :cond_0
    return-object p0
.end method

.method public static final unboxState(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 1

    .line 1395
    instance-of v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/IncompleteStateBox;

    if-eqz v0, :cond_0

    move-object v0, p0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/IncompleteStateBox;

    goto :goto_0

    :cond_0
    const/4 v0, 0x0

    :goto_0
    if-eqz v0, :cond_2

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/IncompleteStateBox;->state:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Incomplete;

    if-nez v0, :cond_1

    goto :goto_1

    :cond_1
    return-object v0

    :cond_2
    :goto_1
    return-object p0
.end method
