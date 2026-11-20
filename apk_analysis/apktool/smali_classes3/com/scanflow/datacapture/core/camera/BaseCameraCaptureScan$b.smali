.class public final Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$b;
.super Ljava/lang/Object;
.source "SourceFile"

# interfaces
.implements Lretrofit2/Callback;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a(Ljava/lang/String;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = null
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Object;",
        "Lretrofit2/Callback<",
        "Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;",
        ">;"
    }
.end annotation


# instance fields
.field public final synthetic a:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan<",
            "TT;>;"
        }
    .end annotation
.end field

.field public final synthetic b:Lcom/scanflow/datacapture/model/DeviceInfo;

.field public final synthetic c:Ljava/lang/String;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;Lcom/scanflow/datacapture/model/DeviceInfo;Ljava/lang/String;)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan<",
            "TT;>;",
            "Lcom/scanflow/datacapture/model/DeviceInfo;",
            "Ljava/lang/String;",
            ")V"
        }
    .end annotation

    .line 0
    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$b;->a:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    iput-object p2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$b;->b:Lcom/scanflow/datacapture/model/DeviceInfo;

    iput-object p3, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$b;->c:Ljava/lang/String;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public final onFailure(Lretrofit2/Call;Ljava/lang/Throwable;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lretrofit2/Call<",
            "Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;",
            ">;",
            "Ljava/lang/Throwable;",
            ")V"
        }
    .end annotation

    const-string v0, "call"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string p1, "t"

    invoke-static {p2, p1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iget-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$b;->a:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    const/4 p2, 0x0

    .line 1
    iput-boolean p2, p1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->q0:Z

    .line 2
    invoke-virtual {p1}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a()V

    return-void
.end method

.method public final onResponse(Lretrofit2/Call;Lretrofit2/Response;)V
    .locals 9
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lretrofit2/Call<",
            "Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;",
            ">;",
            "Lretrofit2/Response<",
            "Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;",
            ">;)V"
        }
    .end annotation

    const-string v0, "call"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string p1, "response"

    invoke-static {p2, p1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iget-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$b;->a:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    const/4 v0, 0x0

    .line 1
    iput-boolean v0, p1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->q0:Z

    .line 2
    invoke-virtual {p2}, Lretrofit2/Response;->code()I

    move-result p1

    const/16 v0, 0xc8

    if-ne p1, v0, :cond_0

    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/GlobalScope;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/GlobalScope;

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Dispatchers;->getIO()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;

    move-result-object p1

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$b;->a:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    .line 3
    iget-object v0, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->n0:Lkotlin/coroutines/AbstractCoroutineContextElement;

    .line 4
    invoke-virtual {p1, v0}, Lkotlin/coroutines/AbstractCoroutineContextElement;->plus(Lkotlin/coroutines/CoroutineContext;)Lkotlin/coroutines/CoroutineContext;

    move-result-object v2

    new-instance v3, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$b$a;

    iget-object v5, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$b;->b:Lcom/scanflow/datacapture/model/DeviceInfo;

    iget-object v6, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$b;->c:Ljava/lang/String;

    iget-object v7, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$b;->a:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    const/4 v8, 0x0

    move-object v4, p2

    invoke-direct/range {v3 .. v8}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$b$a;-><init>(Lretrofit2/Response;Lcom/scanflow/datacapture/model/DeviceInfo;Ljava/lang/String;Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;Lkotlin/coroutines/Continuation;)V

    const/4 v5, 0x2

    const/4 v6, 0x0

    move-object v4, v3

    const/4 v3, 0x0

    invoke-static/range {v1 .. v6}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/BuildersKt;->launch$default(Lkotlinx/coroutines/CoroutineScope;Lkotlin/coroutines/CoroutineContext;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;Lkotlin/jvm/functions/Function2;ILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;

    return-void

    :cond_0
    iget-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$b;->a:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    .line 5
    invoke-virtual {p1}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a()V

    return-void
.end method
