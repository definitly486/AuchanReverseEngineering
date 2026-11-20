.class public final synthetic Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput$$ExternalSyntheticLambda6;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Ljava/lang/Runnable;


# instance fields
.field public final synthetic f$0:Landroidx/camera/core/impl/Observable$Observer;

.field public final synthetic f$1:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/BufferProvider$State;


# direct methods
.method public synthetic constructor <init>(Landroidx/camera/core/impl/Observable$Observer;Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/BufferProvider$State;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput$$ExternalSyntheticLambda6;->f$0:Landroidx/camera/core/impl/Observable$Observer;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput$$ExternalSyntheticLambda6;->f$1:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/BufferProvider$State;

    return-void
.end method


# virtual methods
.method public final run()V
    .locals 2

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput$$ExternalSyntheticLambda6;->f$0:Landroidx/camera/core/impl/Observable$Observer;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput$$ExternalSyntheticLambda6;->f$1:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/BufferProvider$State;

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;->$r8$lambda$KCoKy14w-Y3vZPvGVYd7l0C5yVs(Landroidx/camera/core/impl/Observable$Observer;Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/BufferProvider$State;)V

    return-void
.end method
