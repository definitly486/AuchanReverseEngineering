.class public final synthetic Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_ZDRM$$ExternalSyntheticLambda0;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Ljava/util/function/IntConsumer;


# instance fields
.field public final synthetic f$0:I

.field public final synthetic f$1:I

.field public final synthetic f$2:Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;

.field public final synthetic f$3:Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;

.field public final synthetic f$4:Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;


# direct methods
.method public synthetic constructor <init>(IILcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_ZDRM$$ExternalSyntheticLambda0;->f$0:I

    iput p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_ZDRM$$ExternalSyntheticLambda0;->f$1:I

    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_ZDRM$$ExternalSyntheticLambda0;->f$2:Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;

    iput-object p4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_ZDRM$$ExternalSyntheticLambda0;->f$3:Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;

    iput-object p5, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_ZDRM$$ExternalSyntheticLambda0;->f$4:Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;

    return-void
.end method


# virtual methods
.method public final accept(I)V
    .locals 6

    .line 0
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_ZDRM$$ExternalSyntheticLambda0;->f$0:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_ZDRM$$ExternalSyntheticLambda0;->f$1:I

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_ZDRM$$ExternalSyntheticLambda0;->f$2:Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_ZDRM$$ExternalSyntheticLambda0;->f$3:Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_ZDRM$$ExternalSyntheticLambda0;->f$4:Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;

    move v5, p1

    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_ZDRM;->$r8$lambda$aa_0xnb2uPQKdVjb_e7EGSSZep0(IILcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;I)V

    return-void
.end method
