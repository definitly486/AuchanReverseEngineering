.class public final Lcom/scanflow/datacapture/core/camera/manager/BeepManager;
.super Ljava/lang/Object;
.source "SourceFile"

# interfaces
.implements Landroid/media/MediaPlayer$OnErrorListener;
.implements Ljava/io/Closeable;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/core/camera/manager/BeepManager$Companion;
    }
.end annotation


# static fields
.field public static final Companion:Lcom/scanflow/datacapture/core/camera/manager/BeepManager$Companion;

.field private static final VIBRATE_DURATION:J = 0xc8L


# instance fields
.field private final beepResource:Ljava/lang/Integer;

.field private final context:Landroid/content/Context;

.field private mediaPlayer:Landroid/media/MediaPlayer;

.field private playBeep:Z

.field private vibrate:Z

.field private vibrator:Landroid/os/Vibrator;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/core/camera/manager/BeepManager$Companion;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/core/camera/manager/BeepManager$Companion;-><init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V

    sput-object v0, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->Companion:Lcom/scanflow/datacapture/core/camera/manager/BeepManager$Companion;

    return-void
.end method

.method public constructor <init>(Landroid/content/Context;Ljava/lang/Integer;)V
    .locals 1

    .line 0
    const-string v0, "context"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->context:Landroid/content/Context;

    iput-object p2, p0, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->beepResource:Ljava/lang/Integer;

    invoke-direct {p0}, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->updatePrefs()V

    return-void
.end method

.method private final buildMediaPlayer(Landroid/content/Context;Ljava/lang/Integer;)Landroid/media/MediaPlayer;
    .locals 7

    .line 0
    new-instance v1, Landroid/media/MediaPlayer;

    invoke-direct {v1}, Landroid/media/MediaPlayer;-><init>()V

    if-eqz p2, :cond_0

    :try_start_0
    invoke-virtual {p2}, Ljava/lang/Integer;->intValue()I

    move-result p2

    goto :goto_0

    :catch_0
    move-exception v0

    move-object p1, v0

    goto :goto_1

    :cond_0
    sget p2, Lcom/scanflow/datacapture/R$raw;->beep:I

    :goto_0
    invoke-virtual {p1}, Landroid/content/Context;->getResources()Landroid/content/res/Resources;

    move-result-object p1

    invoke-virtual {p1, p2}, Landroid/content/res/Resources;->openRawResourceFd(I)Landroid/content/res/AssetFileDescriptor;

    move-result-object p1

    invoke-virtual {p1}, Landroid/content/res/AssetFileDescriptor;->getFileDescriptor()Ljava/io/FileDescriptor;

    move-result-object v2

    invoke-virtual {p1}, Landroid/content/res/AssetFileDescriptor;->getStartOffset()J

    move-result-wide v3

    invoke-virtual {p1}, Landroid/content/res/AssetFileDescriptor;->getLength()J

    move-result-wide v5

    invoke-virtual/range {v1 .. v6}, Landroid/media/MediaPlayer;->setDataSource(Ljava/io/FileDescriptor;JJ)V

    invoke-virtual {v1, p0}, Landroid/media/MediaPlayer;->setOnErrorListener(Landroid/media/MediaPlayer$OnErrorListener;)V

    const/4 p1, 0x3

    invoke-virtual {v1, p1}, Landroid/media/MediaPlayer;->setAudioStreamType(I)V

    const/4 p1, 0x0

    invoke-virtual {v1, p1}, Landroid/media/MediaPlayer;->setLooping(Z)V

    invoke-virtual {v1}, Landroid/media/MediaPlayer;->prepare()V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    return-object v1

    :goto_1
    sget-object p2, Lcom/scanflow/datacapture/utils/LogUtils;->Companion:Lcom/scanflow/datacapture/utils/LogUtils$Companion;

    invoke-virtual {p2, p1}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->w(Ljava/lang/Throwable;)V

    invoke-virtual {v1}, Landroid/media/MediaPlayer;->release()V

    const/4 p1, 0x0

    return-object p1
.end method

.method private final declared-synchronized updatePrefs()V
    .locals 2

    .line 0
    monitor-enter p0

    :try_start_0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->mediaPlayer:Landroid/media/MediaPlayer;

    if-nez v0, :cond_0

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->context:Landroid/content/Context;

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->beepResource:Ljava/lang/Integer;

    invoke-direct {p0, v0, v1}, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->buildMediaPlayer(Landroid/content/Context;Ljava/lang/Integer;)Landroid/media/MediaPlayer;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->mediaPlayer:Landroid/media/MediaPlayer;

    goto :goto_0

    :catchall_0
    move-exception v0

    goto :goto_1

    :cond_0
    :goto_0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->vibrator:Landroid/os/Vibrator;

    if-nez v0, :cond_1

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->context:Landroid/content/Context;

    const-string v1, "vibrator"

    invoke-virtual {v0, v1}, Landroid/content/Context;->getSystemService(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v0

    const-string v1, "null cannot be cast to non-null type android.os.Vibrator"

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast v0, Landroid/os/Vibrator;

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->vibrator:Landroid/os/Vibrator;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    :cond_1
    monitor-exit p0

    return-void

    :goto_1
    :try_start_1
    monitor-exit p0
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    throw v0
.end method


# virtual methods
.method public declared-synchronized close()V
    .locals 2

    .line 0
    monitor-enter p0

    :try_start_0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->mediaPlayer:Landroid/media/MediaPlayer;

    if-eqz v0, :cond_0

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {v0}, Landroid/media/MediaPlayer;->release()V

    const/4 v0, 0x0

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->mediaPlayer:Landroid/media/MediaPlayer;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    goto :goto_0

    :catchall_0
    move-exception v0

    goto :goto_1

    :catch_0
    move-exception v0

    :try_start_1
    sget-object v1, Lcom/scanflow/datacapture/utils/LogUtils;->Companion:Lcom/scanflow/datacapture/utils/LogUtils$Companion;

    invoke-virtual {v1, v0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->e(Ljava/lang/Throwable;)V
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    :cond_0
    :goto_0
    monitor-exit p0

    return-void

    :goto_1
    :try_start_2
    monitor-exit p0
    :try_end_2
    .catchall {:try_start_2 .. :try_end_2} :catchall_0

    throw v0
.end method

.method public declared-synchronized onError(Landroid/media/MediaPlayer;II)Z
    .locals 0

    .line 0
    monitor-enter p0

    :try_start_0
    const-string p2, "mp"

    invoke-static {p1, p2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {p0}, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->close()V

    invoke-direct {p0}, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->updatePrefs()V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit p0

    const/4 p1, 0x1

    return p1

    :catchall_0
    move-exception p1

    :try_start_1
    monitor-exit p0
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    throw p1
.end method

.method public final declared-synchronized playBeepSoundAndVibrate()V
    .locals 3

    .line 0
    monitor-enter p0

    :try_start_0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->playBeep:Z

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->mediaPlayer:Landroid/media/MediaPlayer;

    if-eqz v0, :cond_0

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {v0}, Landroid/media/MediaPlayer;->start()V

    goto :goto_0

    :catchall_0
    move-exception v0

    goto :goto_1

    :cond_0
    :goto_0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->vibrate:Z

    if-eqz v0, :cond_1

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->vibrator:Landroid/os/Vibrator;

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    const-wide/16 v1, 0xc8

    invoke-virtual {v0, v1, v2}, Landroid/os/Vibrator;->vibrate(J)V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    :cond_1
    monitor-exit p0

    return-void

    :goto_1
    :try_start_1
    monitor-exit p0
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    throw v0
.end method

.method public final setPlayBeep(Z)V
    .locals 0

    .line 0
    iput-boolean p1, p0, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->playBeep:Z

    return-void
.end method

.method public final setVibrate(Z)V
    .locals 0

    .line 0
    iput-boolean p1, p0, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->vibrate:Z

    return-void
.end method
