.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/BaseConfigPolyline;
.super Ljava/lang/Object;
.source "BaseConfigPolyline.java"

# interfaces
.implements Ljava/io/Serializable;


# instance fields
.field public convex:Z

.field public loops:Z

.field public maximumSides:I

.field public minimumSides:I


# direct methods
.method public constructor <init>()V
    .locals 2

    .line 27
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const/4 v0, 0x1

    .line 31
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/BaseConfigPolyline;->loops:Z

    const/4 v1, 0x3

    .line 36
    iput v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/BaseConfigPolyline;->minimumSides:I

    const v1, 0x7fffffff

    .line 41
    iput v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/BaseConfigPolyline;->maximumSides:I

    .line 46
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/shapes/polyline/BaseConfigPolyline;->convex:Z

    return-void
.end method
