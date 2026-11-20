.class public final synthetic Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda9;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Landroidx/lifecycle/Observer;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/ui/ar/BoundingBoxArOverlay;

.field public final synthetic f$1:Lcom/scanflow/datacapture/barinternal/M;


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/ui/ar/BoundingBoxArOverlay;Lcom/scanflow/datacapture/barinternal/M;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda9;->f$0:Lcom/scanflow/ui/ar/BoundingBoxArOverlay;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda9;->f$1:Lcom/scanflow/datacapture/barinternal/M;

    return-void
.end method


# virtual methods
.method public final onChanged(Ljava/lang/Object;)V
    .locals 2

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda9;->f$0:Lcom/scanflow/ui/ar/BoundingBoxArOverlay;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda9;->f$1:Lcom/scanflow/datacapture/barinternal/M;

    check-cast p1, Lcom/scanflow/ui/ar/ArOverlayView;

    invoke-static {v0, v1, p1}, Lcom/scanflow/datacapture/barinternal/M;->a(Lcom/scanflow/ui/ar/BoundingBoxArOverlay;Lcom/scanflow/datacapture/barinternal/M;Lcom/scanflow/ui/ar/ArOverlayView;)V

    return-void
.end method
