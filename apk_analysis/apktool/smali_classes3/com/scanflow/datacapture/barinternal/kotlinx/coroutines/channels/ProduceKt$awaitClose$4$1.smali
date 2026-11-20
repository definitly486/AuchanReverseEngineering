.class final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ProduceKt$awaitClose$4$1;
.super Ljava/lang/Object;
.source "Produce.kt"

# interfaces
.implements Lkotlin/jvm/functions/Function1;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ProduceKt;->awaitClose(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ProducerScope;Lkotlin/jvm/functions/Function0;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x18
    name = null
.end annotation


# instance fields
.field final synthetic $cont:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;


# direct methods
.method constructor <init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;)V
    .locals 0

    .line 0
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ProduceKt$awaitClose$4$1;->$cont:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public bridge synthetic invoke(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 64
    check-cast p1, Ljava/lang/Throwable;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ProduceKt$awaitClose$4$1;->invoke(Ljava/lang/Throwable;)V

    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    return-object p1
.end method

.method public final invoke(Ljava/lang/Throwable;)V
    .locals 1

    .line 65
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ProduceKt$awaitClose$4$1;->$cont:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;

    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/Result$Companion;

    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->constructor-impl(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    invoke-interface {p1, v0}, Lkotlin/coroutines/Continuation;->resumeWith(Ljava/lang/Object;)V

    return-void
.end method
