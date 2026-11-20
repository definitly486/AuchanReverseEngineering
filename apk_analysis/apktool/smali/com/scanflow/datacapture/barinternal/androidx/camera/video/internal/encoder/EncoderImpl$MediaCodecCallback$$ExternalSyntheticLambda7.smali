.class public final synthetic Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$MediaCodecCallback$$ExternalSyntheticLambda7;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Ljava/lang/Runnable;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderCallback;

.field public final synthetic f$1:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncodedDataImpl;


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderCallback;Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncodedDataImpl;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$MediaCodecCallback$$ExternalSyntheticLambda7;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderCallback;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$MediaCodecCallback$$ExternalSyntheticLambda7;->f$1:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncodedDataImpl;

    return-void
.end method


# virtual methods
.method public final run()V
    .locals 2

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$MediaCodecCallback$$ExternalSyntheticLambda7;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderCallback;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$MediaCodecCallback$$ExternalSyntheticLambda7;->f$1:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncodedDataImpl;

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$MediaCodecCallback;->$r8$lambda$CHtPesz-XW0b9cKf1jMLIXb3eFI(Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderCallback;Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncodedDataImpl;)V

    return-void
.end method
