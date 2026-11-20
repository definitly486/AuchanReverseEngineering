.class public Lcom/scanflow/datacapture/barinternal/boofcv/core/image/ImageBorderValue$Value_F64;
.super Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder_F64;
.source "ImageBorderValue.java"


# instance fields
.field public value:D


# direct methods
.method public constructor <init>(D)V
    .locals 0

    .line 112
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder_F64;-><init>()V

    .line 113
    iput-wide p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/ImageBorderValue$Value_F64;->value:D

    return-void
.end method


# virtual methods
.method public getOutside(II)D
    .locals 0

    .line 118
    iget-wide p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/ImageBorderValue$Value_F64;->value:D

    return-wide p1
.end method
