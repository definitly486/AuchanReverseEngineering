.class public final synthetic Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_ZDRM$$ExternalSyntheticLambda1;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Ljava/util/function/IntConsumer;


# instance fields
.field public final synthetic f$0:I

.field public final synthetic f$1:I

.field public final synthetic f$2:I

.field public final synthetic f$3:Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;

.field public final synthetic f$4:Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;

.field public final synthetic f$5:Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;

.field public final synthetic f$6:I


# direct methods
.method public synthetic constructor <init>(IIILcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;I)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_ZDRM$$ExternalSyntheticLambda1;->f$0:I

    iput p2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_ZDRM$$ExternalSyntheticLambda1;->f$1:I

    iput p3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_ZDRM$$ExternalSyntheticLambda1;->f$2:I

    iput-object p4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_ZDRM$$ExternalSyntheticLambda1;->f$3:Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;

    iput-object p5, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_ZDRM$$ExternalSyntheticLambda1;->f$4:Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;

    iput-object p6, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_ZDRM$$ExternalSyntheticLambda1;->f$5:Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;

    iput p7, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_ZDRM$$ExternalSyntheticLambda1;->f$6:I

    return-void
.end method


# virtual methods
.method public final accept(I)V
    .locals 8

    .line 0
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_ZDRM$$ExternalSyntheticLambda1;->f$0:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_ZDRM$$ExternalSyntheticLambda1;->f$1:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_ZDRM$$ExternalSyntheticLambda1;->f$2:I

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_ZDRM$$ExternalSyntheticLambda1;->f$3:Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_ZDRM$$ExternalSyntheticLambda1;->f$4:Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_ZDRM$$ExternalSyntheticLambda1;->f$5:Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;

    iget v6, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_ZDRM$$ExternalSyntheticLambda1;->f$6:I

    move v7, p1

    invoke-static/range {v0 .. v7}, Lcom/scanflow/datacapture/barinternal/org/ejml/dense/row/mult/MatrixMatrixMult_MT_ZDRM;->$r8$lambda$1YauJERjRxWy3_B7m63We9q4eq8(IIILcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;Lcom/scanflow/datacapture/barinternal/org/ejml/data/ZMatrixRMaj;II)V

    return-void
.end method
