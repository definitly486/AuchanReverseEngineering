.class public interface abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderCallback;
.super Ljava/lang/Object;
.source "EncoderCallback.java"


# static fields
.field public static final EMPTY:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderCallback;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 66
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderCallback$1;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderCallback$1;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderCallback;->EMPTY:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderCallback;

    return-void
.end method


# virtual methods
.method public abstract onEncodeError(Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncodeException;)V
.end method

.method public onEncodePaused()V
    .locals 0

    .line 40
    return-void
.end method

.method public abstract onEncodeStart()V
.end method

.method public abstract onEncodeStop()V
.end method

.method public abstract onEncodedData(Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncodedData;)V
.end method

.method public abstract onOutputConfigUpdate(Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/OutputConfig;)V
.end method
