.class final synthetic Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobKt__JobKt$invokeOnCompletion$1;
.super Lkotlin/jvm/internal/FunctionReferenceImpl;
.source "Job.kt"

# interfaces
.implements Lkotlin/jvm/functions/Function1;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobKt__JobKt;->invokeOnCompletion(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;ZLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobNode;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x1000
    name = null
.end annotation


# direct methods
.method constructor <init>(Ljava/lang/Object;)V
    .locals 7

    .line 0
    const-string v5, "invoke(Ljava/lang/Throwable;)V"

    const/4 v6, 0x0

    const/4 v1, 0x1

    const-class v3, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobNode;

    const-string v4, "invoke"

    move-object v0, p0

    move-object v2, p1

    invoke-direct/range {v0 .. v6}, Lkotlin/jvm/internal/FunctionReferenceImpl;-><init>(ILjava/lang/Object;Ljava/lang/Class;Ljava/lang/String;Ljava/lang/String;I)V

    return-void
.end method


# virtual methods
.method public bridge synthetic invoke(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 371
    check-cast p1, Ljava/lang/Throwable;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobKt__JobKt$invokeOnCompletion$1;->invoke(Ljava/lang/Throwable;)V

    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    return-object p1
.end method

.method public final invoke(Ljava/lang/Throwable;)V
    .locals 1

    .line 371
    iget-object v0, p0, Lkotlin/jvm/internal/CallableReference;->receiver:Ljava/lang/Object;

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobNode;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobNode;->invoke(Ljava/lang/Throwable;)V

    return-void
.end method
