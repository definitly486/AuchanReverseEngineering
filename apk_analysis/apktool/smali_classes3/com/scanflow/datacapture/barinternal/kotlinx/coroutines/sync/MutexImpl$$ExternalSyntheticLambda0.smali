.class public final synthetic Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$$ExternalSyntheticLambda0;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl;


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$$ExternalSyntheticLambda0;->f$0:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl;

    return-void
.end method


# virtual methods
.method public final invoke(Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl$$ExternalSyntheticLambda0;->f$0:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl;

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/a/a$$ExternalSyntheticThrowCCEIfNotNull0;->m(Ljava/lang/Object;)V

    const/4 p1, 0x0

    invoke-static {v0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl;->$r8$lambda$hXfiaGlaae8gqVy2P3Q0OlfdWok(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/MutexImpl;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/selects/SelectInstance;Ljava/lang/Object;Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;

    move-result-object p1

    return-object p1
.end method
