.class public final synthetic Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$$ExternalSyntheticLambda2;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;


# instance fields
.field public final synthetic f$0:Ljava/lang/Object;

.field public final synthetic f$1:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;


# direct methods
.method public synthetic constructor <init>(Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/selects/SelectInstance;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$$ExternalSyntheticLambda2;->f$0:Ljava/lang/Object;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$$ExternalSyntheticLambda2;->f$1:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;

    return-void
.end method


# virtual methods
.method public final invoke(Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 6

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$$ExternalSyntheticLambda2;->f$0:Ljava/lang/Object;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel$$ExternalSyntheticLambda2;->f$1:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;

    move-object v3, p1

    check-cast v3, Ljava/lang/Throwable;

    move-object v5, p3

    check-cast v5, Lkotlin/coroutines/CoroutineContext;

    const/4 v2, 0x0

    move-object v4, p2

    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;->$r8$lambda$4YtRDnxWiAY_lEFg7xfxub3g44Y(Ljava/lang/Object;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferedChannel;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/selects/SelectInstance;Ljava/lang/Throwable;Ljava/lang/Object;Lkotlin/coroutines/CoroutineContext;)Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    move-result-object p1

    return-object p1
.end method
