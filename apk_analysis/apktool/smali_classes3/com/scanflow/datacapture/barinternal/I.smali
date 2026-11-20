.class public final Lcom/scanflow/datacapture/barinternal/I;
.super Ljava/lang/Object;
.source "SourceFile"

# interfaces
.implements Landroid/view/View$OnTouchListener;


# instance fields
.field public final synthetic a:Lcom/scanflow/datacapture/barinternal/M;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/M;)V
    .locals 0

    .line 1
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/I;->a:Lcom/scanflow/datacapture/barinternal/M;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public final onTouch(Landroid/view/View;Landroid/view/MotionEvent;)Z
    .locals 7

    if-eqz p2, :cond_0

    invoke-virtual {p2}, Landroid/view/MotionEvent;->getAction()I

    move-result v0

    invoke-static {v0}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v0

    goto :goto_0

    :cond_0
    const/4 v0, 0x0

    :goto_0
    const/4 v1, 0x0

    if-nez v0, :cond_1

    goto/16 :goto_4

    :cond_1
    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v0

    if-nez v0, :cond_7

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/I;->a:Lcom/scanflow/datacapture/barinternal/M;

    .line 1
    iget-boolean v0, v0, Lcom/scanflow/datacapture/barinternal/M;->d:Z

    if-eqz v0, :cond_7

    .line 2
    invoke-virtual {p2}, Landroid/view/MotionEvent;->getX()F

    move-result v0

    invoke-virtual {p2}, Landroid/view/MotionEvent;->getY()F

    move-result v2

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/I;->a:Lcom/scanflow/datacapture/barinternal/M;

    .line 3
    iget-object v3, v3, Lcom/scanflow/datacapture/barinternal/M;->F:Ljava/util/ArrayList;

    .line 5
    invoke-virtual {v3}, Ljava/util/ArrayList;->size()I

    move-result v4

    move v5, v1

    :goto_1
    if-ge v5, v4, :cond_3

    invoke-virtual {v3, v5}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Lcom/scanflow/ui/ar/ArObject;

    invoke-virtual {v6}, Lcom/scanflow/ui/ar/ArObject;->getBoundingBox()Landroid/graphics/RectF;

    move-result-object v6

    invoke-virtual {v6, v0, v2}, Landroid/graphics/RectF;->contains(FF)Z

    move-result v6

    if-eqz v6, :cond_2

    goto :goto_2

    :cond_2
    add-int/lit8 v5, v5, 0x1

    goto :goto_1

    :cond_3
    const/4 v5, -0x1

    :goto_2
    if-ltz v5, :cond_7

    .line 6
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/I;->a:Lcom/scanflow/datacapture/barinternal/M;

    .line 7
    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/M;->F:Ljava/util/ArrayList;

    .line 8
    invoke-virtual {v0, v5}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/ui/ar/ArObject;

    invoke-virtual {v0}, Lcom/scanflow/ui/ar/ArObject;->getDecodedResult()Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;

    move-result-object v0

    if-eqz v0, :cond_7

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/I;->a:Lcom/scanflow/datacapture/barinternal/M;

    .line 9
    iget-object v3, v2, Lcom/scanflow/datacapture/barinternal/M;->J:Ljava/util/HashSet;

    .line 10
    invoke-virtual {v3, v0}, Ljava/util/HashSet;->contains(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_4

    .line 11
    iget-object v3, v2, Lcom/scanflow/datacapture/barinternal/M;->J:Ljava/util/HashSet;

    .line 12
    invoke-virtual {v3, v0}, Ljava/util/HashSet;->remove(Ljava/lang/Object;)Z

    .line 13
    iget-object v3, v2, Lcom/scanflow/datacapture/barinternal/M;->P:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;

    if-eqz v3, :cond_6

    .line 14
    invoke-interface {v3, v0}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;->onOneofManyCodeRemoved(Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;)V

    goto :goto_3

    .line 15
    :cond_4
    iget-object v3, v2, Lcom/scanflow/datacapture/barinternal/M;->K:Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

    if-eqz v3, :cond_5

    .line 16
    invoke-virtual {v3}, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->playBeepSoundAndVibrate()V

    .line 17
    :cond_5
    iget-object v3, v2, Lcom/scanflow/datacapture/barinternal/M;->J:Ljava/util/HashSet;

    .line 18
    invoke-virtual {v3, v0}, Ljava/util/HashSet;->add(Ljava/lang/Object;)Z

    .line 19
    iget-object v3, v2, Lcom/scanflow/datacapture/barinternal/M;->P:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;

    if-eqz v3, :cond_6

    .line 20
    invoke-interface {v3, v0}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;->onOneofManyCodeSelected(Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;)V

    .line 21
    :cond_6
    :goto_3
    iget-object v0, v2, Lcom/scanflow/datacapture/barinternal/M;->P:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;

    if-eqz v0, :cond_7

    .line 22
    iget-object v2, v2, Lcom/scanflow/datacapture/barinternal/M;->J:Ljava/util/HashSet;

    .line 23
    invoke-interface {v0, v2}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;->onOneOfManyCodeResult(Ljava/util/HashSet;)V

    :cond_7
    :goto_4
    if-eqz p1, :cond_8

    invoke-virtual {p1, p2}, Landroid/view/View;->onTouchEvent(Landroid/view/MotionEvent;)Z

    move-result p1

    return p1

    :cond_8
    return v1
.end method
