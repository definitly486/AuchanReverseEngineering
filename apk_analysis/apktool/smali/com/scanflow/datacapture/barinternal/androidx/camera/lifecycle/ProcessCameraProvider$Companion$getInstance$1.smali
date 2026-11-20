.class final Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider$Companion$getInstance$1;
.super Lkotlin/jvm/internal/Lambda;
.source "ProcessCameraProvider.kt"

# interfaces
.implements Lkotlin/jvm/functions/Function1;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider$Companion;->getInstance(Landroid/content/Context;)Lcom/google/common/util/concurrent/ListenableFuture;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x18
    name = null
.end annotation


# instance fields
.field final synthetic $context:Landroid/content/Context;


# direct methods
.method constructor <init>(Landroid/content/Context;)V
    .locals 0

    .line 0
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider$Companion$getInstance$1;->$context:Landroid/content/Context;

    const/4 p1, 0x1

    invoke-direct {p0, p1}, Lkotlin/jvm/internal/Lambda;-><init>(I)V

    return-void
.end method


# virtual methods
.method public final invoke(Landroidx/camera/core/CameraX;)Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;
    .locals 2

    .line 953
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->access$getSAppInstance$cp()Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;

    move-result-object v0

    const-string v1, "cameraX"

    invoke-static {p1, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-static {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->access$setCameraX(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;Landroidx/camera/core/CameraX;)V

    .line 954
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->access$getSAppInstance$cp()Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;

    move-result-object p1

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider$Companion$getInstance$1;->$context:Landroid/content/Context;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/impl/utils/ContextUtil;->getApplicationContext(Landroid/content/Context;)Landroid/content/Context;

    move-result-object v0

    const-string v1, "getApplicationContext(context)"

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-static {p1, v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->access$setContext(Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;Landroid/content/Context;)V

    .line 955
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->access$getSAppInstance$cp()Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic invoke(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 950
    check-cast p1, Landroidx/camera/core/CameraX;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider$Companion$getInstance$1;->invoke(Landroidx/camera/core/CameraX;)Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;

    move-result-object p1

    return-object p1
.end method
