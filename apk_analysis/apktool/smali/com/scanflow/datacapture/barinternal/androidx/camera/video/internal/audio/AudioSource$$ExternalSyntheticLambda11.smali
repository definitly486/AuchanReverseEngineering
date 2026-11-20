.class public final synthetic Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSource$$ExternalSyntheticLambda11;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Ljava/lang/Runnable;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSource$AudioSourceCallback;

.field public final synthetic f$1:Ljava/lang/Throwable;


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSource$AudioSourceCallback;Ljava/lang/Throwable;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSource$$ExternalSyntheticLambda11;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSource$AudioSourceCallback;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSource$$ExternalSyntheticLambda11;->f$1:Ljava/lang/Throwable;

    return-void
.end method


# virtual methods
.method public final run()V
    .locals 2

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSource$$ExternalSyntheticLambda11;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSource$AudioSourceCallback;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSource$$ExternalSyntheticLambda11;->f$1:Ljava/lang/Throwable;

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSource;->$r8$lambda$4FCX9KwM5r0s3JnmkSxYsaIkQxk(Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSource$AudioSourceCallback;Ljava/lang/Throwable;)V

    return-void
.end method
