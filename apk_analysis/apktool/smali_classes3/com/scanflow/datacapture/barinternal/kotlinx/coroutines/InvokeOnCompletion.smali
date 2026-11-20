.class final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/InvokeOnCompletion;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobNode;
.source "JobSupport.kt"


# instance fields
.field private final handler:Lkotlin/jvm/functions/Function1;


# direct methods
.method public constructor <init>(Lkotlin/jvm/functions/Function1;)V
    .locals 0

    .line 1532
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobNode;-><init>()V

    .line 1531
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/InvokeOnCompletion;->handler:Lkotlin/jvm/functions/Function1;

    return-void
.end method


# virtual methods
.method public getOnCancelling()Z
    .locals 1

    .line 1533
    const/4 v0, 0x0

    return v0
.end method

.method public invoke(Ljava/lang/Throwable;)V
    .locals 1

    .line 1534
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/InvokeOnCompletion;->handler:Lkotlin/jvm/functions/Function1;

    invoke-interface {v0, p1}, Lkotlin/jvm/functions/Function1;->invoke(Ljava/lang/Object;)Ljava/lang/Object;

    return-void
.end method
