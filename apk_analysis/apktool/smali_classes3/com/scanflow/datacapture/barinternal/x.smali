.class public final Lcom/scanflow/datacapture/barinternal/x;
.super Lcom/scanflow/ui/ar/ArObjectTracker;
.source "SourceFile"


# instance fields
.field public final a:I

.field public final b:I

.field public final c:Z


# direct methods
.method public constructor <init>(II)V
    .locals 0

    .line 1
    invoke-direct {p0}, Lcom/scanflow/ui/ar/ArObjectTracker;-><init>()V

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/x;->a:I

    iput p2, p0, Lcom/scanflow/datacapture/barinternal/x;->b:I

    const/4 p1, 0x0

    iput-boolean p1, p0, Lcom/scanflow/datacapture/barinternal/x;->c:Z

    return-void
.end method


# virtual methods
.method public final processObject(Lcom/scanflow/ui/ar/ArObject;)V
    .locals 11

    if-eqz p1, :cond_4

    .line 1
    invoke-virtual {p1}, Lcom/scanflow/ui/ar/ArObject;->getSourceRotationDegrees()I

    move-result v0

    if-eqz v0, :cond_2

    const/16 v1, 0x5a

    if-eq v0, v1, :cond_1

    const/16 v1, 0xb4

    if-eq v0, v1, :cond_2

    const/16 v1, 0x10e

    if-ne v0, v1, :cond_0

    goto :goto_0

    :cond_0
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string v0, "Unsupported rotation. Must be 0, 90, 180 or 270"

    invoke-direct {p1, v0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1

    :cond_1
    :goto_0
    new-instance v0, Landroid/util/Size;

    invoke-virtual {p1}, Lcom/scanflow/ui/ar/ArObject;->getSourceSize()Landroid/util/Size;

    move-result-object v1

    invoke-virtual {v1}, Landroid/util/Size;->getHeight()I

    move-result v1

    invoke-virtual {p1}, Lcom/scanflow/ui/ar/ArObject;->getSourceSize()Landroid/util/Size;

    move-result-object v2

    invoke-virtual {v2}, Landroid/util/Size;->getWidth()I

    move-result v2

    invoke-direct {v0, v1, v2}, Landroid/util/Size;-><init>(II)V

    goto :goto_1

    :cond_2
    invoke-virtual {p1}, Lcom/scanflow/ui/ar/ArObject;->getSourceSize()Landroid/util/Size;

    :goto_1
    invoke-virtual {p1}, Lcom/scanflow/ui/ar/ArObject;->getBoundingBox()Landroid/graphics/RectF;

    move-result-object v5

    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/x;->c:Z

    if-eqz v0, :cond_3

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/x;->a:I

    div-int/lit8 v0, v0, 0x2

    int-to-float v0, v0

    iget v1, v5, Landroid/graphics/RectF;->left:F

    sub-float v1, v0, v1

    add-float/2addr v1, v0

    iput v1, v5, Landroid/graphics/RectF;->left:F

    iget v1, v5, Landroid/graphics/RectF;->right:F

    sub-float/2addr v1, v0

    sub-float/2addr v0, v1

    iput v0, v5, Landroid/graphics/RectF;->right:F

    :cond_3
    new-instance v3, Lcom/scanflow/ui/ar/ArObject;

    invoke-virtual {p1}, Lcom/scanflow/ui/ar/ArObject;->component1()Ljava/lang/String;

    move-result-object v4

    new-instance v6, Landroid/util/Size;

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/x;->a:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/x;->b:I

    invoke-direct {v6, v0, v1}, Landroid/util/Size;-><init>(II)V

    invoke-virtual {p1}, Lcom/scanflow/ui/ar/ArObject;->component4()I

    move-result v7

    invoke-virtual {p1}, Lcom/scanflow/ui/ar/ArObject;->component5()I

    move-result v8

    invoke-virtual {p1}, Lcom/scanflow/ui/ar/ArObject;->component6()Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;

    move-result-object v9

    const/4 v10, 0x1

    invoke-direct/range {v3 .. v10}, Lcom/scanflow/ui/ar/ArObject;-><init>(Ljava/lang/String;Landroid/graphics/RectF;Landroid/util/Size;IILcom/scanflow/datacapture/model/OneOFManyCodesScanResults;Z)V

    invoke-super {p0, v3}, Lcom/scanflow/ui/ar/ArObjectTracker;->processObject(Lcom/scanflow/ui/ar/ArObject;)V

    return-void

    :cond_4
    const/4 p1, 0x0

    invoke-super {p0, p1}, Lcom/scanflow/ui/ar/ArObjectTracker;->processObject(Lcom/scanflow/ui/ar/ArObject;)V

    return-void
.end method
