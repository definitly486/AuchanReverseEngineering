.class public final synthetic Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/android/HandlerContext$$ExternalSyntheticLambda2;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/android/HandlerContext;

.field public final synthetic f$1:Ljava/lang/Runnable;


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/android/HandlerContext;Ljava/lang/Runnable;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/android/HandlerContext$$ExternalSyntheticLambda2;->f$0:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/android/HandlerContext;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/android/HandlerContext$$ExternalSyntheticLambda2;->f$1:Ljava/lang/Runnable;

    return-void
.end method


# virtual methods
.method public final dispose()V
    .locals 2

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/android/HandlerContext$$ExternalSyntheticLambda2;->f$0:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/android/HandlerContext;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/android/HandlerContext$$ExternalSyntheticLambda2;->f$1:Ljava/lang/Runnable;

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/android/HandlerContext;->$r8$lambda$AXU9Ipeju1KWZ01G6KHwtONG4Wk(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/android/HandlerContext;Ljava/lang/Runnable;)V

    return-void
.end method
