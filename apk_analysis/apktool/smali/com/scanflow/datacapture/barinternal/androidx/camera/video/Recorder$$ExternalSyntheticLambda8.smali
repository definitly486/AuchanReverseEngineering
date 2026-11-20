.class public final synthetic Lcom/scanflow/datacapture/barinternal/androidx/camera/video/Recorder$$ExternalSyntheticLambda8;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderFactory;


# direct methods
.method public synthetic constructor <init>()V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public final createEncoder(Ljava/util/concurrent/Executor;Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderConfig;)Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/Encoder;
    .locals 1

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl;

    invoke-direct {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl;-><init>(Ljava/util/concurrent/Executor;Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderConfig;)V

    return-object v0
.end method
