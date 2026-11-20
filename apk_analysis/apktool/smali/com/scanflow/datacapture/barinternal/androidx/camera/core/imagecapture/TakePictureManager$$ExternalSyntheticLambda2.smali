.class public final synthetic Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/TakePictureManager$$ExternalSyntheticLambda2;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Ljava/lang/Runnable;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/TakePictureManager;


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/TakePictureManager;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/TakePictureManager$$ExternalSyntheticLambda2;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/TakePictureManager;

    return-void
.end method


# virtual methods
.method public final run()V
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/TakePictureManager$$ExternalSyntheticLambda2;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/TakePictureManager;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/TakePictureManager;->issueNextRequest()V

    return-void
.end method
