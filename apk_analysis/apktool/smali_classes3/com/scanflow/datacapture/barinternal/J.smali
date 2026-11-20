.class public final Lcom/scanflow/datacapture/barinternal/J;
.super Ljava/lang/Object;
.source "SourceFile"

# interfaces
.implements Landroid/view/View$OnLayoutChangeListener;


# instance fields
.field public final synthetic a:Lcom/scanflow/datacapture/barinternal/M;

.field public final synthetic b:Lcom/scanflow/ui/ar/BoundingBoxArOverlay;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/M;Lcom/scanflow/ui/ar/BoundingBoxArOverlay;)V
    .locals 0

    .line 1
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/J;->a:Lcom/scanflow/datacapture/barinternal/M;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/J;->b:Lcom/scanflow/ui/ar/BoundingBoxArOverlay;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public final onLayoutChange(Landroid/view/View;IIIIIIII)V
    .locals 0

    const-string p2, "view"

    invoke-static {p1, p2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {p1, p0}, Landroid/view/View;->removeOnLayoutChangeListener(Landroid/view/View$OnLayoutChangeListener;)V

    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/J;->a:Lcom/scanflow/datacapture/barinternal/M;

    .line 1
    iget-object p2, p2, Lcom/scanflow/datacapture/barinternal/M;->G:Lcom/scanflow/ui/ar/ArObjectTracker;

    .line 2
    new-instance p3, Lcom/scanflow/datacapture/barinternal/x;

    invoke-virtual {p1}, Landroid/view/View;->getWidth()I

    move-result p4

    invoke-virtual {p1}, Landroid/view/View;->getHeight()I

    move-result p1

    invoke-direct {p3, p4, p1}, Lcom/scanflow/datacapture/barinternal/x;-><init>(II)V

    invoke-virtual {p2, p3}, Lcom/scanflow/ui/ar/ArObjectTracker;->pipe(Lcom/scanflow/ui/ar/ArObjectTracker;)Lcom/scanflow/ui/ar/ArObjectTracker;

    move-result-object p1

    new-instance p2, Lcom/scanflow/datacapture/barinternal/w;

    invoke-direct {p2}, Lcom/scanflow/datacapture/barinternal/w;-><init>()V

    invoke-virtual {p1, p2}, Lcom/scanflow/ui/ar/ArObjectTracker;->pipe(Lcom/scanflow/ui/ar/ArObjectTracker;)Lcom/scanflow/ui/ar/ArObjectTracker;

    move-result-object p1

    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/J;->b:Lcom/scanflow/ui/ar/BoundingBoxArOverlay;

    invoke-virtual {p1, p2}, Lcom/scanflow/ui/ar/ArObjectTracker;->addTrackingListener(Lcom/scanflow/ui/ar/ArObjectTracker$ArObjectTrackingListener;)Lcom/scanflow/ui/ar/ArObjectTracker;

    return-void
.end method
