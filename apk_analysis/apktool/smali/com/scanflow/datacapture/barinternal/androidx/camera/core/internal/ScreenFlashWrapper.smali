.class public final Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper;
.super Ljava/lang/Object;
.source "ScreenFlashWrapper.kt"

# interfaces
.implements Landroidx/camera/core/ImageCapture$ScreenFlash;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper$Companion;
    }
.end annotation


# static fields
.field public static final Companion:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper$Companion;


# instance fields
.field private isClearScreenFlashPending:Z

.field private final lock:Ljava/lang/Object;

.field private pendingListener:Landroidx/camera/core/ImageCapture$ScreenFlashListener;

.field private final screenFlash:Landroidx/camera/core/ImageCapture$ScreenFlash;


# direct methods
.method public static synthetic $r8$lambda$t_o_lKGGIvRKmzNXRdv2XQWSBSA(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper;)V
    .locals 0

    .line 0
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper;->apply$lambda$2(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper;)V

    return-void
.end method

.method static constructor <clinit>()V
    .locals 2

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper$Companion;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper$Companion;-><init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper;->Companion:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper$Companion;

    return-void
.end method

.method private constructor <init>(Landroidx/camera/core/ImageCapture$ScreenFlash;)V
    .locals 0

    .line 30
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper;->screenFlash:Landroidx/camera/core/ImageCapture$ScreenFlash;

    .line 31
    new-instance p1, Ljava/lang/Object;

    invoke-direct {p1}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper;->lock:Ljava/lang/Object;

    return-void
.end method

.method public synthetic constructor <init>(Landroidx/camera/core/ImageCapture$ScreenFlash;Lkotlin/jvm/internal/DefaultConstructorMarker;)V
    .locals 0

    .line 0
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper;-><init>(Landroidx/camera/core/ImageCapture$ScreenFlash;)V

    return-void
.end method

.method private static final apply$lambda$2(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper;)V
    .locals 3

    const-string v0, "this$0"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 49
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper;->lock:Ljava/lang/Object;

    monitor-enter v0

    .line 50
    :try_start_0
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper;->pendingListener:Landroidx/camera/core/ImageCapture$ScreenFlashListener;

    if-nez v1, :cond_0

    .line 51
    const-string v1, "ScreenFlashWrapper"

    const-string v2, "apply: pendingListener is null!"

    invoke-static {v1, v2}, Landroidx/camera/core/Logger;->w(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    :catchall_0
    move-exception p0

    goto :goto_1

    .line 53
    :cond_0
    :goto_0
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper;->completePendingScreenFlashListener()V

    .line 54
    sget-object p0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 49
    monitor-exit v0

    return-void

    :goto_1
    monitor-exit v0

    throw p0
.end method

.method private final completePendingScreenFlashClear()V
    .locals 3

    .line 80
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper;->lock:Ljava/lang/Object;

    monitor-enter v0

    .line 81
    :try_start_0
    iget-boolean v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper;->isClearScreenFlashPending:Z

    if-eqz v1, :cond_1

    .line 82
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper;->screenFlash:Landroidx/camera/core/ImageCapture$ScreenFlash;

    if-eqz v1, :cond_0

    invoke-interface {v1}, Landroidx/camera/core/ImageCapture$ScreenFlash;->clear()V

    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    goto :goto_0

    :catchall_0
    move-exception v1

    goto :goto_2

    :cond_0
    const/4 v1, 0x0

    :goto_0
    if-nez v1, :cond_2

    .line 84
    const-string v1, "ScreenFlashWrapper"

    const-string v2, "completePendingScreenFlashClear: screenFlash is null!"

    invoke-static {v1, v2}, Landroidx/camera/core/Logger;->e(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_1

    .line 87
    :cond_1
    const-string v1, "ScreenFlashWrapper"

    const-string v2, "completePendingScreenFlashClear: none pending!"

    invoke-static {v1, v2}, Landroidx/camera/core/Logger;->w(Ljava/lang/String;Ljava/lang/String;)V

    :cond_2
    :goto_1
    const/4 v1, 0x0

    .line 89
    iput-boolean v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper;->isClearScreenFlashPending:Z

    .line 90
    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 80
    monitor-exit v0

    return-void

    :goto_2
    monitor-exit v0

    throw v1
.end method

.method private final completePendingScreenFlashListener()V
    .locals 2

    .line 72
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper;->lock:Ljava/lang/Object;

    monitor-enter v0

    .line 73
    :try_start_0
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper;->pendingListener:Landroidx/camera/core/ImageCapture$ScreenFlashListener;

    if-eqz v1, :cond_0

    invoke-interface {v1}, Landroidx/camera/core/ImageCapture$ScreenFlashListener;->onCompleted()V

    goto :goto_0

    :catchall_0
    move-exception v1

    goto :goto_1

    :cond_0
    :goto_0
    const/4 v1, 0x0

    .line 74
    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper;->pendingListener:Landroidx/camera/core/ImageCapture$ScreenFlashListener;

    .line 75
    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 72
    monitor-exit v0

    return-void

    :goto_1
    monitor-exit v0

    throw v1
.end method

.method public static final from(Landroidx/camera/core/ImageCapture$ScreenFlash;)Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper;
    .locals 1

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper;->Companion:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper$Companion;

    invoke-virtual {v0, p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper$Companion;->from(Landroidx/camera/core/ImageCapture$ScreenFlash;)Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper;

    move-result-object p0

    return-object p0
.end method


# virtual methods
.method public apply(JLandroidx/camera/core/ImageCapture$ScreenFlashListener;)V
    .locals 2

    const-string v0, "screenFlashListener"

    invoke-static {p3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 43
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper;->lock:Ljava/lang/Object;

    monitor-enter v0

    const/4 v1, 0x1

    .line 44
    :try_start_0
    iput-boolean v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper;->isClearScreenFlashPending:Z

    .line 45
    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper;->pendingListener:Landroidx/camera/core/ImageCapture$ScreenFlashListener;

    .line 46
    sget-object p3, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 43
    monitor-exit v0

    .line 48
    iget-object p3, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper;->screenFlash:Landroidx/camera/core/ImageCapture$ScreenFlash;

    if-eqz p3, :cond_0

    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper$$ExternalSyntheticLambda0;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper$$ExternalSyntheticLambda0;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper;)V

    invoke-interface {p3, p1, p2, v0}, Landroidx/camera/core/ImageCapture$ScreenFlash;->apply(JLandroidx/camera/core/ImageCapture$ScreenFlashListener;)V

    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    goto :goto_0

    :cond_0
    const/4 p1, 0x0

    :goto_0
    if-nez p1, :cond_1

    .line 57
    const-string p1, "ScreenFlashWrapper"

    const-string p2, "apply: screenFlash is null!"

    invoke-static {p1, p2}, Landroidx/camera/core/Logger;->e(Ljava/lang/String;Ljava/lang/String;)V

    .line 59
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper;->completePendingScreenFlashListener()V

    :cond_1
    return-void

    :catchall_0
    move-exception p1

    .line 43
    monitor-exit v0

    throw p1
.end method

.method public clear()V
    .locals 0

    .line 64
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper;->completePendingScreenFlashClear()V

    return-void
.end method

.method public final completePendingTasks()V
    .locals 0

    .line 95
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper;->completePendingScreenFlashListener()V

    .line 96
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper;->completePendingScreenFlashClear()V

    return-void
.end method

.method public final getBaseScreenFlash()Landroidx/camera/core/ImageCapture$ScreenFlash;
    .locals 1

    .line 68
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/ScreenFlashWrapper;->screenFlash:Landroidx/camera/core/ImageCapture$ScreenFlash;

    return-object v0
.end method
