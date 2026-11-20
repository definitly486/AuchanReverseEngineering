.class public Lcom/scanflow/datacapture/barinternal/boofcv/core/image/ImageBorderValue$Value_F32;
.super Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder_F32;
.source "ImageBorderValue.java"


# instance fields
.field public value:F


# direct methods
.method public constructor <init>(F)V
    .locals 0

    .line 140
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder_F32;-><init>()V

    .line 141
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/ImageBorderValue$Value_F32;->value:F

    return-void
.end method


# virtual methods
.method public getOutside(II)F
    .locals 0

    .line 146
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/ImageBorderValue$Value_F32;->value:F

    return p1
.end method
