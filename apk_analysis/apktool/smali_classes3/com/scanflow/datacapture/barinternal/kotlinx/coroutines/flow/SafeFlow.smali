.class final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/SafeFlow;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/AbstractFlow;
.source "Builders.kt"


# instance fields
.field private final block:Lkotlin/jvm/functions/Function2;


# direct methods
.method public constructor <init>(Lkotlin/jvm/functions/Function2;)V
    .locals 0

    .line 55
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/AbstractFlow;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/SafeFlow;->block:Lkotlin/jvm/functions/Function2;

    return-void
.end method


# virtual methods
.method public collectSafely(Lkotlinx/coroutines/flow/FlowCollector;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;
    .locals 1

    .line 57
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/SafeFlow;->block:Lkotlin/jvm/functions/Function2;

    invoke-interface {v0, p1, p2}, Lkotlin/jvm/functions/Function2;->invoke(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->getCOROUTINE_SUSPENDED()Ljava/lang/Object;

    move-result-object p2

    if-ne p1, p2, :cond_0

    return-object p1

    :cond_0
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    return-object p1
.end method
