.class public final Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$b$a;
.super Lkotlin/coroutines/jvm/internal/SuspendLambda;
.source "SourceFile"

# interfaces
.implements Lkotlin/jvm/functions/Function2;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$b;->onResponse(Lretrofit2/Call;Lretrofit2/Response;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = null
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lkotlin/coroutines/jvm/internal/SuspendLambda;",
        "Lkotlin/jvm/functions/Function2<",
        "Lkotlinx/coroutines/CoroutineScope;",
        "Lkotlin/coroutines/Continuation<",
        "-",
        "Lcom/scanflow/datacapture/barinternal/kotlin/Unit;",
        ">;",
        "Ljava/lang/Object;",
        ">;"
    }
.end annotation

.annotation runtime Lkotlin/coroutines/jvm/internal/DebugMetadata;
    c = "com.scanflow.datacapture.core.camera.BaseCameraCaptureScan$checkLicenseValidation$1$onResponse$1"
    f = "BaseCameraCaptureScan.kt"
    l = {}
    m = "invokeSuspend"
.end annotation


# instance fields
.field public synthetic a:Ljava/lang/Object;

.field public final synthetic b:Lretrofit2/Response;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lretrofit2/Response<",
            "Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;",
            ">;"
        }
    .end annotation
.end field

.field public final synthetic c:Lcom/scanflow/datacapture/model/DeviceInfo;

.field public final synthetic d:Ljava/lang/String;

.field public final synthetic e:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan<",
            "TT;>;"
        }
    .end annotation
.end field


# direct methods
.method public constructor <init>(Lretrofit2/Response;Lcom/scanflow/datacapture/model/DeviceInfo;Ljava/lang/String;Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;Lkotlin/coroutines/Continuation;)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lretrofit2/Response<",
            "Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;",
            ">;",
            "Lcom/scanflow/datacapture/model/DeviceInfo;",
            "Ljava/lang/String;",
            "Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan<",
            "TT;>;",
            "Lkotlin/coroutines/Continuation<",
            "-",
            "Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$b$a;",
            ">;)V"
        }
    .end annotation

    .line 0
    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$b$a;->b:Lretrofit2/Response;

    iput-object p2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$b$a;->c:Lcom/scanflow/datacapture/model/DeviceInfo;

    iput-object p3, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$b$a;->d:Ljava/lang/String;

    iput-object p4, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$b$a;->e:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    const/4 p1, 0x2

    invoke-direct {p0, p1, p5}, Lkotlin/coroutines/jvm/internal/SuspendLambda;-><init>(ILkotlin/coroutines/Continuation;)V

    return-void
.end method


# virtual methods
.method public final create(Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Lkotlin/coroutines/Continuation;
    .locals 6
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Object;",
            "Lkotlin/coroutines/Continuation<",
            "*>;)",
            "Lkotlin/coroutines/Continuation<",
            "Lcom/scanflow/datacapture/barinternal/kotlin/Unit;",
            ">;"
        }
    .end annotation

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$b$a;

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$b$a;->b:Lretrofit2/Response;

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$b$a;->c:Lcom/scanflow/datacapture/model/DeviceInfo;

    iget-object v3, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$b$a;->d:Ljava/lang/String;

    iget-object v4, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$b$a;->e:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    move-object v5, p2

    invoke-direct/range {v0 .. v5}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$b$a;-><init>(Lretrofit2/Response;Lcom/scanflow/datacapture/model/DeviceInfo;Ljava/lang/String;Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;Lkotlin/coroutines/Continuation;)V

    iput-object p1, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$b$a;->a:Ljava/lang/Object;

    return-object v0
.end method

.method public final invoke(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    check-cast p1, Lkotlinx/coroutines/CoroutineScope;

    check-cast p2, Lkotlin/coroutines/Continuation;

    .line 1
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$b$a;->create(Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Lkotlin/coroutines/Continuation;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$b$a;

    sget-object p2, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$b$a;->invokeSuspend(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method

.method public final invokeSuspend(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 4

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->getCOROUTINE_SUSPENDED()Ljava/lang/Object;

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/ResultKt;->throwOnFailure(Ljava/lang/Object;)V

    iget-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$b$a;->a:Ljava/lang/Object;

    check-cast p1, Lkotlinx/coroutines/CoroutineScope;

    iget-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$b$a;->b:Lretrofit2/Response;

    invoke-virtual {p1}, Lretrofit2/Response;->body()Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;

    if-eqz p1, :cond_1

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$b$a;->c:Lcom/scanflow/datacapture/model/DeviceInfo;

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$b$a;->d:Ljava/lang/String;

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$b$a;->e:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    invoke-virtual {p1, v0}, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->setDeviceInfo(Lcom/scanflow/datacapture/model/DeviceInfo;)V

    invoke-virtual {p1, v1}, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->setApikey(Ljava/lang/String;)V

    sget v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->E0:I

    .line 1
    invoke-virtual {v2, p1}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a(Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;)V

    .line 2
    invoke-virtual {p1}, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->getStatus()Ljava/lang/String;

    move-result-object v0

    const-string v1, "Success"

    const/4 v3, 0x1

    invoke-static {v0, v1, v3}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->equals(Ljava/lang/String;Ljava/lang/String;Z)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 3
    iget-object v0, v2, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->x:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnLicenseValidationCallback;

    if-eqz v0, :cond_2

    .line 4
    invoke-virtual {p1}, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->getMessage()Ljava/lang/String;

    move-result-object p1

    invoke-interface {v0, p1}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnLicenseValidationCallback;->onLicenseSuccess(Ljava/lang/String;)V

    goto :goto_0

    .line 5
    :cond_0
    iget-object v0, v2, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->x:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnLicenseValidationCallback;

    if-eqz v0, :cond_2

    .line 6
    invoke-virtual {p1}, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->getMessage()Ljava/lang/String;

    move-result-object p1

    invoke-interface {v0, p1}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnLicenseValidationCallback;->onLicenseFailure(Ljava/lang/String;)V

    goto :goto_0

    :cond_1
    iget-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$b$a;->e:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    sget v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->E0:I

    .line 7
    invoke-virtual {p1}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a()V

    .line 8
    :cond_2
    :goto_0
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    return-object p1
.end method
