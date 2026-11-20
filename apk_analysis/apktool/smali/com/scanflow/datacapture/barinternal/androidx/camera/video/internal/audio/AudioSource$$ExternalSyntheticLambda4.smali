.class public final synthetic Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSource$$ExternalSyntheticLambda4;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Ljava/lang/Runnable;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSource;

.field public final synthetic f$1:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/BufferProvider;


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSource;Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/BufferProvider;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSource$$ExternalSyntheticLambda4;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSource;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSource$$ExternalSyntheticLambda4;->f$1:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/BufferProvider;

    return-void
.end method


# virtual methods
.method public final run()V
    .locals 2

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSource$$ExternalSyntheticLambda4;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSource;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSource$$ExternalSyntheticLambda4;->f$1:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/BufferProvider;

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSource;->$r8$lambda$6kVduMcBJfgxc7WMTpK-tmRKvag(Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSource;Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/BufferProvider;)V

    return-void
.end method
