.class Lcom/scanflow/datacapture/sfdocument/SFCameraView$1;
.super Ljava/lang/Object;
.source "SourceFile"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/scanflow/datacapture/sfdocument/SFCameraView;->setExpiredVisibility(Ljava/lang/Boolean;Ljava/lang/String;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x1
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/scanflow/datacapture/sfdocument/SFCameraView;

.field final synthetic val$isVisible:Ljava/lang/Boolean;

.field final synthetic val$message:Ljava/lang/String;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/sfdocument/SFCameraView;Ljava/lang/Boolean;Ljava/lang/String;)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()V"
        }
    .end annotation

    .line 0
    iput-object p1, p0, Lcom/scanflow/datacapture/sfdocument/SFCameraView$1;->this$0:Lcom/scanflow/datacapture/sfdocument/SFCameraView;

    iput-object p2, p0, Lcom/scanflow/datacapture/sfdocument/SFCameraView$1;->val$isVisible:Ljava/lang/Boolean;

    iput-object p3, p0, Lcom/scanflow/datacapture/sfdocument/SFCameraView$1;->val$message:Ljava/lang/String;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 2

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/sfdocument/SFCameraView$1;->val$isVisible:Ljava/lang/Boolean;

    invoke-virtual {v0}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v0

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/scanflow/datacapture/sfdocument/SFCameraView$1;->this$0:Lcom/scanflow/datacapture/sfdocument/SFCameraView;

    invoke-static {v0}, Lcom/scanflow/datacapture/sfdocument/SFCameraView;->access$000(Lcom/scanflow/datacapture/sfdocument/SFCameraView;)Landroid/widget/TextView;

    move-result-object v0

    iget-object v1, p0, Lcom/scanflow/datacapture/sfdocument/SFCameraView$1;->val$message:Ljava/lang/String;

    invoke-virtual {v0, v1}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    iget-object v0, p0, Lcom/scanflow/datacapture/sfdocument/SFCameraView$1;->this$0:Lcom/scanflow/datacapture/sfdocument/SFCameraView;

    invoke-static {v0}, Lcom/scanflow/datacapture/sfdocument/SFCameraView;->access$000(Lcom/scanflow/datacapture/sfdocument/SFCameraView;)Landroid/widget/TextView;

    move-result-object v0

    const/4 v1, 0x0

    :goto_0
    invoke-virtual {v0, v1}, Landroid/view/View;->setVisibility(I)V

    return-void

    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/sfdocument/SFCameraView$1;->this$0:Lcom/scanflow/datacapture/sfdocument/SFCameraView;

    invoke-static {v0}, Lcom/scanflow/datacapture/sfdocument/SFCameraView;->access$000(Lcom/scanflow/datacapture/sfdocument/SFCameraView;)Landroid/widget/TextView;

    move-result-object v0

    const/16 v1, 0x8

    goto :goto_0
.end method
