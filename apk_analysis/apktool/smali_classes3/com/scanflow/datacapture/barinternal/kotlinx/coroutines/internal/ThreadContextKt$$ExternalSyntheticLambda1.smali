.class public final synthetic Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadContextKt$$ExternalSyntheticLambda1;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Lkotlin/jvm/functions/Function2;


# direct methods
.method public synthetic constructor <init>()V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public final invoke(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 0
    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ThreadContextElement;

    check-cast p2, Lkotlin/coroutines/CoroutineContext$Element;

    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadContextKt;->$r8$lambda$BWRz50x54qs2OVxeNX6EXirG04g(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ThreadContextElement;Lkotlin/coroutines/CoroutineContext$Element;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ThreadContextElement;

    move-result-object p1

    return-object p1
.end method
