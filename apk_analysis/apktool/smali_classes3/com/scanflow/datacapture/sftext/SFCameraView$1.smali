.class Lcom/scanflow/datacapture/sftext/SFCameraView$1;
.super Ljava/lang/Object;
.source "SourceFile"

# interfaces
.implements Landroid/animation/Animator$AnimatorListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/scanflow/datacapture/sftext/SFCameraView;->doFlipAnimation(Landroid/content/Context;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x1
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/scanflow/datacapture/sftext/SFCameraView;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/sftext/SFCameraView;)V
    .locals 0

    .line 0
    iput-object p1, p0, Lcom/scanflow/datacapture/sftext/SFCameraView$1;->this$0:Lcom/scanflow/datacapture/sftext/SFCameraView;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onAnimationCancel(Landroid/animation/Animator;)V
    .locals 0

    .line 0
    return-void
.end method

.method public onAnimationEnd(Landroid/animation/Animator;)V
    .locals 1

    .line 0
    iget-object p1, p0, Lcom/scanflow/datacapture/sftext/SFCameraView$1;->this$0:Lcom/scanflow/datacapture/sftext/SFCameraView;

    invoke-static {p1}, Lcom/scanflow/datacapture/sftext/SFCameraView;->access$000(Lcom/scanflow/datacapture/sftext/SFCameraView;)Landroid/widget/ImageView;

    move-result-object p1

    const/16 v0, 0x8

    invoke-virtual {p1, v0}, Landroid/widget/ImageView;->setVisibility(I)V

    return-void
.end method

.method public onAnimationRepeat(Landroid/animation/Animator;)V
    .locals 0

    .line 0
    return-void
.end method

.method public onAnimationStart(Landroid/animation/Animator;)V
    .locals 1

    .line 0
    iget-object p1, p0, Lcom/scanflow/datacapture/sftext/SFCameraView$1;->this$0:Lcom/scanflow/datacapture/sftext/SFCameraView;

    invoke-static {p1}, Lcom/scanflow/datacapture/sftext/SFCameraView;->access$000(Lcom/scanflow/datacapture/sftext/SFCameraView;)Landroid/widget/ImageView;

    move-result-object p1

    const/4 v0, 0x0

    invoke-virtual {p1, v0}, Landroid/widget/ImageView;->setVisibility(I)V

    return-void
.end method
