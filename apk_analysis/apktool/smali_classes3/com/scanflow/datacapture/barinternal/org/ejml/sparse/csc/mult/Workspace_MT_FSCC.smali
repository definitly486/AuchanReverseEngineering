.class public Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/Workspace_MT_FSCC;
.super Ljava/lang/Object;
.source "Workspace_MT_FSCC.java"


# instance fields
.field public final gw:Lcom/scanflow/datacapture/barinternal/org/ejml/data/IGrowArray;

.field public final gx:Lcom/scanflow/datacapture/barinternal/org/ejml/data/FGrowArray;

.field public final mat:Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;


# direct methods
.method public constructor <init>()V
    .locals 2

    .line 32
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 33
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/IGrowArray;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/IGrowArray;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/Workspace_MT_FSCC;->gw:Lcom/scanflow/datacapture/barinternal/org/ejml/data/IGrowArray;

    .line 34
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FGrowArray;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FGrowArray;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/Workspace_MT_FSCC;->gx:Lcom/scanflow/datacapture/barinternal/org/ejml/data/FGrowArray;

    .line 35
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;

    const/4 v1, 0x1

    invoke-direct {v0, v1, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;-><init>(II)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/Workspace_MT_FSCC;->mat:Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;

    return-void
.end method
