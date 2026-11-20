.class abstract Landroidx/vectordrawable/graphics/drawable/VectorDrawableCompat$VPath;
.super Landroidx/vectordrawable/graphics/drawable/VectorDrawableCompat$VObject;
.source "VectorDrawableCompat.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Landroidx/vectordrawable/graphics/drawable/VectorDrawableCompat;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x40a
    name = "VPath"
.end annotation


# instance fields
.field mChangingConfigurations:I

.field mFillRule:I

.field protected mNodes:[Lcom/scanflow/datacapture/barinternal/androidx/core/graphics/PathParser$PathDataNode;

.field mPathName:Ljava/lang/String;


# direct methods
.method constructor <init>()V
    .locals 1

    const/4 v0, 0x0

    .line 1705
    invoke-direct {p0, v0}, Landroidx/vectordrawable/graphics/drawable/VectorDrawableCompat$VObject;-><init>(Landroidx/vectordrawable/graphics/drawable/VectorDrawableCompat$1;)V

    .line 1699
    iput-object v0, p0, Landroidx/vectordrawable/graphics/drawable/VectorDrawableCompat$VPath;->mNodes:[Lcom/scanflow/datacapture/barinternal/androidx/core/graphics/PathParser$PathDataNode;

    const/4 v0, 0x0

    .line 1702
    iput v0, p0, Landroidx/vectordrawable/graphics/drawable/VectorDrawableCompat$VPath;->mFillRule:I

    return-void
.end method

.method constructor <init>(Landroidx/vectordrawable/graphics/drawable/VectorDrawableCompat$VPath;)V
    .locals 1

    const/4 v0, 0x0

    .line 1732
    invoke-direct {p0, v0}, Landroidx/vectordrawable/graphics/drawable/VectorDrawableCompat$VObject;-><init>(Landroidx/vectordrawable/graphics/drawable/VectorDrawableCompat$1;)V

    .line 1699
    iput-object v0, p0, Landroidx/vectordrawable/graphics/drawable/VectorDrawableCompat$VPath;->mNodes:[Lcom/scanflow/datacapture/barinternal/androidx/core/graphics/PathParser$PathDataNode;

    const/4 v0, 0x0

    .line 1702
    iput v0, p0, Landroidx/vectordrawable/graphics/drawable/VectorDrawableCompat$VPath;->mFillRule:I

    .line 1733
    iget-object v0, p1, Landroidx/vectordrawable/graphics/drawable/VectorDrawableCompat$VPath;->mPathName:Ljava/lang/String;

    iput-object v0, p0, Landroidx/vectordrawable/graphics/drawable/VectorDrawableCompat$VPath;->mPathName:Ljava/lang/String;

    .line 1734
    iget v0, p1, Landroidx/vectordrawable/graphics/drawable/VectorDrawableCompat$VPath;->mChangingConfigurations:I

    iput v0, p0, Landroidx/vectordrawable/graphics/drawable/VectorDrawableCompat$VPath;->mChangingConfigurations:I

    .line 1735
    iget-object p1, p1, Landroidx/vectordrawable/graphics/drawable/VectorDrawableCompat$VPath;->mNodes:[Lcom/scanflow/datacapture/barinternal/androidx/core/graphics/PathParser$PathDataNode;

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/core/graphics/PathParser;->deepCopyNodes([Lcom/scanflow/datacapture/barinternal/androidx/core/graphics/PathParser$PathDataNode;)[Lcom/scanflow/datacapture/barinternal/androidx/core/graphics/PathParser$PathDataNode;

    move-result-object p1

    iput-object p1, p0, Landroidx/vectordrawable/graphics/drawable/VectorDrawableCompat$VPath;->mNodes:[Lcom/scanflow/datacapture/barinternal/androidx/core/graphics/PathParser$PathDataNode;

    return-void
.end method


# virtual methods
.method public getPathData()[Lcom/scanflow/datacapture/barinternal/androidx/core/graphics/PathParser$PathDataNode;
    .locals 1

    .line 1765
    iget-object v0, p0, Landroidx/vectordrawable/graphics/drawable/VectorDrawableCompat$VPath;->mNodes:[Lcom/scanflow/datacapture/barinternal/androidx/core/graphics/PathParser$PathDataNode;

    return-object v0
.end method

.method public getPathName()Ljava/lang/String;
    .locals 1

    .line 1746
    iget-object v0, p0, Landroidx/vectordrawable/graphics/drawable/VectorDrawableCompat$VPath;->mPathName:Ljava/lang/String;

    return-object v0
.end method

.method public isClipPath()Z
    .locals 1

    .line 0
    const/4 v0, 0x0

    return v0
.end method

.method public setPathData([Lcom/scanflow/datacapture/barinternal/androidx/core/graphics/PathParser$PathDataNode;)V
    .locals 1

    .line 1770
    iget-object v0, p0, Landroidx/vectordrawable/graphics/drawable/VectorDrawableCompat$VPath;->mNodes:[Lcom/scanflow/datacapture/barinternal/androidx/core/graphics/PathParser$PathDataNode;

    invoke-static {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/core/graphics/PathParser;->canMorph([Lcom/scanflow/datacapture/barinternal/androidx/core/graphics/PathParser$PathDataNode;[Lcom/scanflow/datacapture/barinternal/androidx/core/graphics/PathParser$PathDataNode;)Z

    move-result v0

    if-nez v0, :cond_0

    .line 1772
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/core/graphics/PathParser;->deepCopyNodes([Lcom/scanflow/datacapture/barinternal/androidx/core/graphics/PathParser$PathDataNode;)[Lcom/scanflow/datacapture/barinternal/androidx/core/graphics/PathParser$PathDataNode;

    move-result-object p1

    iput-object p1, p0, Landroidx/vectordrawable/graphics/drawable/VectorDrawableCompat$VPath;->mNodes:[Lcom/scanflow/datacapture/barinternal/androidx/core/graphics/PathParser$PathDataNode;

    return-void

    .line 1774
    :cond_0
    iget-object v0, p0, Landroidx/vectordrawable/graphics/drawable/VectorDrawableCompat$VPath;->mNodes:[Lcom/scanflow/datacapture/barinternal/androidx/core/graphics/PathParser$PathDataNode;

    invoke-static {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/core/graphics/PathParser;->updateNodes([Lcom/scanflow/datacapture/barinternal/androidx/core/graphics/PathParser$PathDataNode;[Lcom/scanflow/datacapture/barinternal/androidx/core/graphics/PathParser$PathDataNode;)V

    return-void
.end method

.method public toPath(Landroid/graphics/Path;)V
    .locals 1

    .line 1739
    invoke-virtual {p1}, Landroid/graphics/Path;->reset()V

    .line 1740
    iget-object v0, p0, Landroidx/vectordrawable/graphics/drawable/VectorDrawableCompat$VPath;->mNodes:[Lcom/scanflow/datacapture/barinternal/androidx/core/graphics/PathParser$PathDataNode;

    if-eqz v0, :cond_0

    .line 1741
    invoke-static {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/core/graphics/PathParser;->nodesToPath([Lcom/scanflow/datacapture/barinternal/androidx/core/graphics/PathParser$PathDataNode;Landroid/graphics/Path;)V

    :cond_0
    return-void
.end method
