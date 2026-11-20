.class final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ResumeOnCompletion;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobNode;
.source "JobSupport.kt"


# instance fields
.field private final continuation:Lkotlin/coroutines/Continuation;


# direct methods
.method public constructor <init>(Lkotlin/coroutines/Continuation;)V
    .locals 0

    .line 1539
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobNode;-><init>()V

    .line 1538
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ResumeOnCompletion;->continuation:Lkotlin/coroutines/Continuation;

    return-void
.end method


# virtual methods
.method public getOnCancelling()Z
    .locals 1

    .line 1540
    const/4 v0, 0x0

    return v0
.end method

.method public invoke(Ljava/lang/Throwable;)V
    .locals 1

    .line 1541
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ResumeOnCompletion;->continuation:Lkotlin/coroutines/Continuation;

    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/Result$Companion;

    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->constructor-impl(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    invoke-interface {p1, v0}, Lkotlin/coroutines/Continuation;->resumeWith(Ljava/lang/Object;)V

    return-void
.end method
