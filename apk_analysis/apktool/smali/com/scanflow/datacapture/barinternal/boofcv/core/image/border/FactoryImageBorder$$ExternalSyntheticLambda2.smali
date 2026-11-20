.class public final synthetic Lcom/scanflow/datacapture/barinternal/boofcv/core/image/border/FactoryImageBorder$$ExternalSyntheticLambda2;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/FactoryBorderIndex1D;


# direct methods
.method public synthetic constructor <init>()V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public final newInstance()Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderIndex1D;
    .locals 1

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/border/BorderIndex1D_Wrap;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/border/BorderIndex1D_Wrap;-><init>()V

    return-object v0
.end method
