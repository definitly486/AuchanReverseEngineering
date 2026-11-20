.class public final synthetic Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$SurfaceInput$$ExternalSyntheticLambda0;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Ljava/lang/Runnable;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/Encoder$SurfaceInput$OnSurfaceUpdateListener;

.field public final synthetic f$1:Landroid/view/Surface;


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/Encoder$SurfaceInput$OnSurfaceUpdateListener;Landroid/view/Surface;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$SurfaceInput$$ExternalSyntheticLambda0;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/Encoder$SurfaceInput$OnSurfaceUpdateListener;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$SurfaceInput$$ExternalSyntheticLambda0;->f$1:Landroid/view/Surface;

    return-void
.end method


# virtual methods
.method public final run()V
    .locals 2

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$SurfaceInput$$ExternalSyntheticLambda0;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/Encoder$SurfaceInput$OnSurfaceUpdateListener;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$SurfaceInput$$ExternalSyntheticLambda0;->f$1:Landroid/view/Surface;

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$SurfaceInput;->$r8$lambda$hrsG61kdwB8pQi_TMxm2MRrOpa4(Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/Encoder$SurfaceInput$OnSurfaceUpdateListener;Landroid/view/Surface;)V

    return-void
.end method
