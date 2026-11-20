.class public final synthetic Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher$Key$$ExternalSyntheticLambda0;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Lkotlin/jvm/functions/Function1;


# direct methods
.method public synthetic constructor <init>()V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public final invoke(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 0
    check-cast p1, Lkotlin/coroutines/CoroutineContext$Element;

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher$Key;->$r8$lambda$HSgR_zVE6qGoA2I3Sp8kQHzwvIY(Lkotlin/coroutines/CoroutineContext$Element;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;

    move-result-object p1

    return-object p1
.end method
