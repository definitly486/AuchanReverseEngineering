.class public final synthetic Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$MediaCodecCallback$$ExternalSyntheticLambda2;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Ljava/lang/Runnable;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$MediaCodecCallback;

.field public final synthetic f$1:Landroid/media/MediaCodec$CodecException;


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$MediaCodecCallback;Landroid/media/MediaCodec$CodecException;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$MediaCodecCallback$$ExternalSyntheticLambda2;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$MediaCodecCallback;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$MediaCodecCallback$$ExternalSyntheticLambda2;->f$1:Landroid/media/MediaCodec$CodecException;

    return-void
.end method


# virtual methods
.method public final run()V
    .locals 2

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$MediaCodecCallback$$ExternalSyntheticLambda2;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$MediaCodecCallback;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$MediaCodecCallback$$ExternalSyntheticLambda2;->f$1:Landroid/media/MediaCodec$CodecException;

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$MediaCodecCallback;->$r8$lambda$g43hEEX-R3BRPNfYtRnuf5VF1qQ(Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$MediaCodecCallback;Landroid/media/MediaCodec$CodecException;)V

    return-void
.end method
