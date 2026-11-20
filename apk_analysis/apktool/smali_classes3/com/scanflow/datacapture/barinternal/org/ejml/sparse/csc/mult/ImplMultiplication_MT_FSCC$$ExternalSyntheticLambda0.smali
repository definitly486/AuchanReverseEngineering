.class public final synthetic Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/ImplMultiplication_MT_FSCC$$ExternalSyntheticLambda0;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntRangeObjectConsumer;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;

.field public final synthetic f$1:Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/ImplMultiplication_MT_FSCC$$ExternalSyntheticLambda0;->f$0:Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/ImplMultiplication_MT_FSCC$$ExternalSyntheticLambda0;->f$1:Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;

    return-void
.end method


# virtual methods
.method public final accept(Ljava/lang/Object;II)V
    .locals 2

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/ImplMultiplication_MT_FSCC$$ExternalSyntheticLambda0;->f$0:Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/ImplMultiplication_MT_FSCC$$ExternalSyntheticLambda0;->f$1:Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;

    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/Workspace_MT_FSCC;

    invoke-static {v0, v1, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/ImplMultiplication_MT_FSCC;->$r8$lambda$7c66ZP4n2dqp4sSNt5qn_2M53ps(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixSparseCSC;Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/Workspace_MT_FSCC;II)V

    return-void
.end method
