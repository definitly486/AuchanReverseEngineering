.class final Landroidx/room/CoroutinesRoom$Companion$execute$4$1;
.super Ljava/lang/Object;
.source "CoroutinesRoom.android.kt"

# interfaces
.implements Lkotlin/jvm/functions/Function1;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Landroidx/room/CoroutinesRoom$Companion;->execute(Landroidx/room/RoomDatabase;ZLandroid/os/CancellationSignal;Ljava/util/concurrent/Callable;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x18
    name = null
.end annotation


# instance fields
.field final synthetic $cancellationSignal:Landroid/os/CancellationSignal;

.field final synthetic $job:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;


# direct methods
.method constructor <init>(Landroid/os/CancellationSignal;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;)V
    .locals 0

    .line 0
    iput-object p1, p0, Landroidx/room/CoroutinesRoom$Companion$execute$4$1;->$cancellationSignal:Landroid/os/CancellationSignal;

    iput-object p2, p0, Landroidx/room/CoroutinesRoom$Companion$execute$4$1;->$job:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public bridge synthetic invoke(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 75
    check-cast p1, Ljava/lang/Throwable;

    invoke-virtual {p0, p1}, Landroidx/room/CoroutinesRoom$Companion$execute$4$1;->invoke(Ljava/lang/Throwable;)V

    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    return-object p1
.end method

.method public final invoke(Ljava/lang/Throwable;)V
    .locals 2

    .line 76
    iget-object p1, p0, Landroidx/room/CoroutinesRoom$Companion$execute$4$1;->$cancellationSignal:Landroid/os/CancellationSignal;

    if-eqz p1, :cond_0

    invoke-virtual {p1}, Landroid/os/CancellationSignal;->cancel()V

    .line 77
    :cond_0
    iget-object p1, p0, Landroidx/room/CoroutinesRoom$Companion$execute$4$1;->$job:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;

    const/4 v0, 0x1

    const/4 v1, 0x0

    invoke-static {p1, v1, v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job$DefaultImpls;->cancel$default(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;Ljava/util/concurrent/CancellationException;ILjava/lang/Object;)V

    return-void
.end method
