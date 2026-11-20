.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder;
.super Ljava/lang/Object;
.source "ImageBorder.java"


# instance fields
.field protected image:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;


# direct methods
.method protected constructor <init>()V
    .locals 0

    .line 38
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public setImage(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V
    .locals 0

    .line 41
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder;->image:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    return-void
.end method
