.class public final synthetic Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT$$ExternalSyntheticLambda0;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Ljava/util/function/IntConsumer;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT;

.field public final synthetic f$1:I

.field public final synthetic f$2:I

.field public final synthetic f$3:I

.field public final synthetic f$4:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT;IIILcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT$$ExternalSyntheticLambda0;->f$0:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT;

    iput p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT$$ExternalSyntheticLambda0;->f$1:I

    iput p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT$$ExternalSyntheticLambda0;->f$2:I

    iput p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT$$ExternalSyntheticLambda0;->f$3:I

    iput-object p5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT$$ExternalSyntheticLambda0;->f$4:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    return-void
.end method


# virtual methods
.method public final accept(I)V
    .locals 6

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT$$ExternalSyntheticLambda0;->f$0:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT$$ExternalSyntheticLambda0;->f$1:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT$$ExternalSyntheticLambda0;->f$2:I

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT$$ExternalSyntheticLambda0;->f$3:I

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT$$ExternalSyntheticLambda0;->f$4:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move v5, p1

    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT;->$r8$lambda$A_SfUZzdujV7dIxQsb6nOmjL2zo(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT;IIILcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;I)V

    return-void
.end method
