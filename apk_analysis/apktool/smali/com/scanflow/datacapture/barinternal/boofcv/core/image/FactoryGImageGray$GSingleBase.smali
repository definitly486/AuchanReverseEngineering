.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray$GSingleBase;
.super Ljava/lang/Object;
.source "FactoryGImageGray.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GImageGray;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x409
    name = "GSingleBase"
.end annotation


# instance fields
.field protected image:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;


# direct methods
.method protected constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)V
    .locals 0

    .line 606
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 607
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray$GSingleBase;->image:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    return-void
.end method


# virtual methods
.method public getHeight()I
    .locals 1

    .line 622
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray$GSingleBase;->image:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result v0

    return v0
.end method

.method public getWidth()I
    .locals 1

    .line 617
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray$GSingleBase;->image:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v0

    return v0
.end method

.method public wrap(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)V
    .locals 0

    .line 612
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/FactoryGImageGray$GSingleBase;->image:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    return-void
.end method
