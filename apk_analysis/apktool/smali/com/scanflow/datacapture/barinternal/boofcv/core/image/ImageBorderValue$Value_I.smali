.class public Lcom/scanflow/datacapture/barinternal/boofcv/core/image/ImageBorderValue$Value_I;
.super Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder_S32;
.source "ImageBorderValue.java"


# instance fields
.field public value:I


# direct methods
.method public constructor <init>(I)V
    .locals 0

    .line 168
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder_S32;-><init>()V

    .line 169
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/ImageBorderValue$Value_I;->value:I

    return-void
.end method


# virtual methods
.method public getOutside(II)I
    .locals 0

    .line 174
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/ImageBorderValue$Value_I;->value:I

    return p1
.end method
