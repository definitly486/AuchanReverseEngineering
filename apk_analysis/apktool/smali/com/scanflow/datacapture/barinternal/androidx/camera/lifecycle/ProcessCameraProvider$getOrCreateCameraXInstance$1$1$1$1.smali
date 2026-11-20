.class public final Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider$getOrCreateCameraXInstance$1$1$1$1;
.super Ljava/lang/Object;
.source "ProcessCameraProvider.kt"

# interfaces
.implements Landroidx/camera/core/impl/utils/futures/FutureCallback;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->getOrCreateCameraXInstance(Landroid/content/Context;)Lcom/google/common/util/concurrent/ListenableFuture;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = null
.end annotation


# instance fields
.field final synthetic $cameraX:Landroidx/camera/core/CameraX;

.field final synthetic $completer:Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;


# direct methods
.method constructor <init>(Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;Landroidx/camera/core/CameraX;)V
    .locals 0

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider$getOrCreateCameraXInstance$1$1$1$1;->$completer:Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider$getOrCreateCameraXInstance$1$1$1$1;->$cameraX:Landroidx/camera/core/CameraX;

    .line 809
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onFailure(Ljava/lang/Throwable;)V
    .locals 1

    const-string v0, "t"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 815
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider$getOrCreateCameraXInstance$1$1$1$1;->$completer:Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;

    invoke-virtual {v0, p1}, Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;->setException(Ljava/lang/Throwable;)Z

    return-void
.end method

.method public bridge synthetic onSuccess(Ljava/lang/Object;)V
    .locals 0

    .line 809
    check-cast p1, Ljava/lang/Void;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider$getOrCreateCameraXInstance$1$1$1$1;->onSuccess(Ljava/lang/Void;)V

    return-void
.end method

.method public onSuccess(Ljava/lang/Void;)V
    .locals 1

    .line 811
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider$getOrCreateCameraXInstance$1$1$1$1;->$completer:Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider$getOrCreateCameraXInstance$1$1$1$1;->$cameraX:Landroidx/camera/core/CameraX;

    invoke-virtual {p1, v0}, Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;->set(Ljava/lang/Object;)Z

    return-void
.end method
