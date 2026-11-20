.class Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSource$AudioStreamCallback;
.super Ljava/lang/Object;
.source "AudioSource.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioStream$AudioStreamCallback;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSource;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = "AudioStreamCallback"
.end annotation


# instance fields
.field final synthetic this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSource;


# direct methods
.method constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSource;)V
    .locals 0

    .line 201
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSource$AudioStreamCallback;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSource;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onSilenceStateChanged(Z)V
    .locals 2

    .line 205
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSource$AudioStreamCallback;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSource;

    iput-boolean p1, v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSource;->mAudioStreamSilenced:Z

    .line 206
    iget-object p1, v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSource;->mState:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSource$InternalState;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSource$InternalState;->STARTED:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSource$InternalState;

    if-ne p1, v1, :cond_0

    .line 207
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSource;->notifySilenced()V

    :cond_0
    return-void
.end method
