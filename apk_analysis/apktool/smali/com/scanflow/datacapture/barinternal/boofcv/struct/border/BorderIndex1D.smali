.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderIndex1D;
.super Ljava/lang/Object;
.source "BorderIndex1D.java"


# instance fields
.field protected length:I


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 26
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public abstract getIndex(I)I
.end method

.method public setLength(I)V
    .locals 0

    .line 29
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderIndex1D;->length:I

    return-void
.end method
