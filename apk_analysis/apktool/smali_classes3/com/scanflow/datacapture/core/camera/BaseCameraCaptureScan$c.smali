.class public final Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$c;
.super Ljava/lang/Object;
.source "SourceFile"

# interfaces
.implements Landroid/view/View$OnLayoutChangeListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->b()V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = null
.end annotation


# instance fields
.field public final synthetic a:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan<",
            "TT;>;"
        }
    .end annotation
.end field


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan<",
            "TT;>;)V"
        }
    .end annotation

    .line 0
    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$c;->a:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public final onLayoutChange(Landroid/view/View;IIIIIIII)V
    .locals 0

    .line 0
    const-string p2, "view"

    invoke-static {p1, p2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iget-object p2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$c;->a:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    invoke-virtual {p1}, Landroid/view/View;->getWidth()I

    move-result p3

    if-lez p3, :cond_0

    invoke-virtual {p1}, Landroid/view/View;->getHeight()I

    move-result p3

    if-lez p3, :cond_0

    invoke-virtual {p2}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->f()V

    invoke-virtual {p1, p0}, Landroid/view/View;->removeOnLayoutChangeListener(Landroid/view/View$OnLayoutChangeListener;)V

    :cond_0
    return-void
.end method
