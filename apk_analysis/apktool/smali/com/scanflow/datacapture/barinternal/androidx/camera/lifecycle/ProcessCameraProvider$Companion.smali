.class public final Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider$Companion;
.super Ljava/lang/Object;
.source "ProcessCameraProvider.kt"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Companion"
.end annotation


# direct methods
.method public static synthetic $r8$lambda$1GtIzncz4245_HpTJbEZFoVqMQY(Lkotlin/jvm/functions/Function1;Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;
    .locals 0

    .line 0
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider$Companion;->getInstance$lambda$0(Lkotlin/jvm/functions/Function1;Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;

    move-result-object p0

    return-object p0
.end method

.method private constructor <init>()V
    .locals 0

    .line 909
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public synthetic constructor <init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider$Companion;-><init>()V

    return-void
.end method

.method private static final getInstance$lambda$0(Lkotlin/jvm/functions/Function1;Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;
    .locals 1

    const-string v0, "$tmp0"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 952
    invoke-interface {p0, p1}, Lkotlin/jvm/functions/Function1;->invoke(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;

    return-object p0
.end method


# virtual methods
.method public final getInstance(Landroid/content/Context;)Lcom/google/common/util/concurrent/ListenableFuture;
    .locals 2

    const-string v0, "context"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 949
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/core/util/Preconditions;->checkNotNull(Ljava/lang/Object;)Ljava/lang/Object;

    .line 951
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->access$getSAppInstance$cp()Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;

    move-result-object v0

    invoke-static {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->access$getOrCreateCameraXInstance(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;Landroid/content/Context;)Lcom/google/common/util/concurrent/ListenableFuture;

    move-result-object v0

    .line 950
    new-instance v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider$Companion$getInstance$1;

    invoke-direct {v1, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider$Companion$getInstance$1;-><init>(Landroid/content/Context;)V

    .line 952
    new-instance p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider$Companion$$ExternalSyntheticLambda0;

    invoke-direct {p1, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider$Companion$$ExternalSyntheticLambda0;-><init>(Lkotlin/jvm/functions/Function1;)V

    .line 957
    invoke-static {}, Landroidx/camera/core/impl/utils/executor/CameraXExecutors;->directExecutor()Ljava/util/concurrent/Executor;

    move-result-object v1

    .line 950
    invoke-static {v0, p1, v1}, Landroidx/camera/core/impl/utils/futures/Futures;->transform(Lcom/google/common/util/concurrent/ListenableFuture;Landroidx/arch/core/util/Function;Ljava/util/concurrent/Executor;)Lcom/google/common/util/concurrent/ListenableFuture;

    move-result-object p1

    .line 952
    const-string v0, "context: Context): Liste\u2026tExecutor()\n            )"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    return-object p1
.end method
