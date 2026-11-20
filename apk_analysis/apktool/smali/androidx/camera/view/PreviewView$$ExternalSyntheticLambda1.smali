.class public final synthetic Landroidx/camera/view/PreviewView$$ExternalSyntheticLambda1;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/androidx/camera/view/impl/ZoomGestureDetector$OnZoomGestureListener;


# instance fields
.field public final synthetic f$0:Landroidx/camera/view/PreviewView;


# direct methods
.method public synthetic constructor <init>(Landroidx/camera/view/PreviewView;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Landroidx/camera/view/PreviewView$$ExternalSyntheticLambda1;->f$0:Landroidx/camera/view/PreviewView;

    return-void
.end method


# virtual methods
.method public final onZoomEvent(Lcom/scanflow/datacapture/barinternal/androidx/camera/view/impl/ZoomGestureDetector$ZoomEvent;)Z
    .locals 1

    .line 0
    iget-object v0, p0, Landroidx/camera/view/PreviewView$$ExternalSyntheticLambda1;->f$0:Landroidx/camera/view/PreviewView;

    invoke-static {v0, p1}, Landroidx/camera/view/PreviewView;->$r8$lambda$OeiknK9N23br6LsLCi8sso60u20(Landroidx/camera/view/PreviewView;Lcom/scanflow/datacapture/barinternal/androidx/camera/view/impl/ZoomGestureDetector$ZoomEvent;)Z

    move-result p1

    return p1
.end method
