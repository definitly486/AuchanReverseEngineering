.class public final synthetic Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSource$$ExternalSyntheticLambda5;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioStreamFactory;


# direct methods
.method public synthetic constructor <init>()V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public final create(Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings;Landroid/content/Context;)Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioStream;
    .locals 1

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioStreamImpl;

    invoke-direct {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioStreamImpl;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings;Landroid/content/Context;)V

    return-object v0
.end method
