.class public final synthetic Lcom/scanflow/datacapture/barinternal/androidx/camera/video/Recorder$$ExternalSyntheticLambda10;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Ljava/lang/Runnable;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/Encoder;


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/Encoder;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/Recorder$$ExternalSyntheticLambda10;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/Encoder;

    return-void
.end method


# virtual methods
.method public final run()V
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/Recorder$$ExternalSyntheticLambda10;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/Encoder;

    invoke-static {v0}, Landroidx/camera/video/Recorder;->$r8$lambda$Y4lQg3Rn1j1jpHn_onqcNwD10mw(Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/Encoder;)V

    return-void
.end method
