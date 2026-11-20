.class public final synthetic Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$$ExternalSyntheticLambda1;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Landroidx/core/util/Consumer;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$$ExternalSyntheticLambda1;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;

    return-void
.end method


# virtual methods
.method public final accept(Ljava/lang/Object;)V
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$$ExternalSyntheticLambda1;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;

    check-cast p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$InputPacket;

    invoke-static {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;->$r8$lambda$EI5MKd_Nwbt-kM8O4-wtsjxa9o4(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$InputPacket;)V

    return-void
.end method
