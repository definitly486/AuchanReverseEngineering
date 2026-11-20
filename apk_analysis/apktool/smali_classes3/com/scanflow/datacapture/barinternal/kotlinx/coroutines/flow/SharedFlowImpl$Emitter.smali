.class final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/SharedFlowImpl$Emitter;
.super Ljava/lang/Object;
.source "SharedFlow.kt"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/SharedFlowImpl;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x1a
    name = "Emitter"
.end annotation


# instance fields
.field public final cont:Lkotlin/coroutines/Continuation;

.field public final flow:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/SharedFlowImpl;

.field public index:J

.field public final value:Ljava/lang/Object;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/SharedFlowImpl;JLjava/lang/Object;Lkotlin/coroutines/Continuation;)V
    .locals 0

    .line 717
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 718
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/SharedFlowImpl$Emitter;->flow:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/SharedFlowImpl;

    .line 719
    iput-wide p2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/SharedFlowImpl$Emitter;->index:J

    .line 720
    iput-object p4, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/SharedFlowImpl$Emitter;->value:Ljava/lang/Object;

    .line 721
    iput-object p5, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/SharedFlowImpl$Emitter;->cont:Lkotlin/coroutines/Continuation;

    return-void
.end method


# virtual methods
.method public dispose()V
    .locals 1

    .line 723
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/SharedFlowImpl$Emitter;->flow:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/SharedFlowImpl;

    invoke-static {v0, p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/SharedFlowImpl;->access$cancelEmitter(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/SharedFlowImpl;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/SharedFlowImpl$Emitter;)V

    return-void
.end method
