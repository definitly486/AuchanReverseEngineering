.class public final Lcom/scanflow/datacapture/sfidcard/SFIDCardOverlay$setIDCaptureOverlay$1$1;
.super Ljava/lang/Object;
.source "SourceFile"

# interfaces
.implements Landroid/view/SurfaceHolder$Callback;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/scanflow/datacapture/sfidcard/SFIDCardOverlay;->setIDCaptureOverlay(Landroid/view/SurfaceView;IIZ)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = null
.end annotation


# instance fields
.field final synthetic $DESIRED_HEIGHT_CROP_PERCENT:I

.field final synthetic $DESIRED_WIDTH_CROP_PERCENT:I

.field final synthetic $isFrontSide:Z

.field final synthetic $this_apply:Landroid/view/SurfaceView;


# direct methods
.method public constructor <init>(Landroid/view/SurfaceView;IIZ)V
    .locals 0

    .line 0
    iput-object p1, p0, Lcom/scanflow/datacapture/sfidcard/SFIDCardOverlay$setIDCaptureOverlay$1$1;->$this_apply:Landroid/view/SurfaceView;

    iput p2, p0, Lcom/scanflow/datacapture/sfidcard/SFIDCardOverlay$setIDCaptureOverlay$1$1;->$DESIRED_HEIGHT_CROP_PERCENT:I

    iput p3, p0, Lcom/scanflow/datacapture/sfidcard/SFIDCardOverlay$setIDCaptureOverlay$1$1;->$DESIRED_WIDTH_CROP_PERCENT:I

    iput-boolean p4, p0, Lcom/scanflow/datacapture/sfidcard/SFIDCardOverlay$setIDCaptureOverlay$1$1;->$isFrontSide:Z

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public surfaceChanged(Landroid/view/SurfaceHolder;III)V
    .locals 0

    .line 0
    const-string p2, "holder"

    invoke-static {p1, p2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iget-object p1, p0, Lcom/scanflow/datacapture/sfidcard/SFIDCardOverlay$setIDCaptureOverlay$1$1;->$this_apply:Landroid/view/SurfaceView;

    invoke-virtual {p1}, Landroid/view/View;->invalidate()V

    return-void
.end method

.method public surfaceCreated(Landroid/view/SurfaceHolder;)V
    .locals 5

    .line 0
    const-string v0, "holder"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iget-object v0, p0, Lcom/scanflow/datacapture/sfidcard/SFIDCardOverlay$setIDCaptureOverlay$1$1;->$this_apply:Landroid/view/SurfaceView;

    iget v1, p0, Lcom/scanflow/datacapture/sfidcard/SFIDCardOverlay$setIDCaptureOverlay$1$1;->$DESIRED_HEIGHT_CROP_PERCENT:I

    iget v2, p0, Lcom/scanflow/datacapture/sfidcard/SFIDCardOverlay$setIDCaptureOverlay$1$1;->$DESIRED_WIDTH_CROP_PERCENT:I

    iget-boolean v3, p0, Lcom/scanflow/datacapture/sfidcard/SFIDCardOverlay$setIDCaptureOverlay$1$1;->$isFrontSide:Z

    const/4 v4, 0x0

    invoke-virtual {v0, v4}, Landroid/view/View;->setWillNotDraw(Z)V

    sget-object v0, Lcom/scanflow/datacapture/sfidcard/SFIDCardOverlay;->INSTANCE:Lcom/scanflow/datacapture/sfidcard/SFIDCardOverlay;

    invoke-virtual {v0, p1, v1, v2, v3}, Lcom/scanflow/datacapture/sfidcard/SFIDCardOverlay;->drawOverlay(Landroid/view/SurfaceHolder;IIZ)V

    return-void
.end method

.method public surfaceDestroyed(Landroid/view/SurfaceHolder;)V
    .locals 1

    .line 0
    const-string v0, "holder"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    return-void
.end method
