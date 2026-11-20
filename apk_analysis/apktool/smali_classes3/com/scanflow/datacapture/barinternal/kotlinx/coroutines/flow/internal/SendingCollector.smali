.class public final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/internal/SendingCollector;
.super Ljava/lang/Object;
.source "SendingCollector.kt"

# interfaces
.implements Lkotlinx/coroutines/flow/FlowCollector;


# instance fields
.field private final channel:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/SendChannel;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/SendChannel;)V
    .locals 0

    .line 12
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 13
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/internal/SendingCollector;->channel:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/SendChannel;

    return-void
.end method


# virtual methods
.method public emit(Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;
    .locals 1

    .line 15
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/internal/SendingCollector;->channel:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/SendChannel;

    invoke-interface {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/SendChannel;->send(Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;

    move-result-object p1

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->getCOROUTINE_SUSPENDED()Ljava/lang/Object;

    move-result-object p2

    if-ne p1, p2, :cond_0

    return-object p1

    :cond_0
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    return-object p1
.end method
