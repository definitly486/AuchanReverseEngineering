.class public final synthetic Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/android/HandlerContext$$ExternalSyntheticLambda0;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Ljava/lang/Runnable;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;

.field public final synthetic f$1:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/android/HandlerContext;


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/android/HandlerContext;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/android/HandlerContext$$ExternalSyntheticLambda0;->f$0:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/android/HandlerContext$$ExternalSyntheticLambda0;->f$1:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/android/HandlerContext;

    return-void
.end method


# virtual methods
.method public final run()V
    .locals 2

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/android/HandlerContext$$ExternalSyntheticLambda0;->f$0:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/android/HandlerContext$$ExternalSyntheticLambda0;->f$1:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/android/HandlerContext;

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/android/HandlerContext;->$r8$lambda$1oICx0p9952ACqpdbT-DIvW6E9k(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuation;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/android/HandlerContext;)V

    return-void
.end method
