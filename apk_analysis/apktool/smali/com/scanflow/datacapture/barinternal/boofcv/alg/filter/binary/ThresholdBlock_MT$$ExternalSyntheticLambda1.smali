.class public final synthetic Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT$$ExternalSyntheticLambda1;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Ljava/util/function/IntConsumer;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT;

.field public final synthetic f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

.field public final synthetic f$2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT$$ExternalSyntheticLambda1;->f$0:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT$$ExternalSyntheticLambda1;->f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT$$ExternalSyntheticLambda1;->f$2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    return-void
.end method


# virtual methods
.method public final accept(I)V
    .locals 3

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT$$ExternalSyntheticLambda1;->f$0:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT$$ExternalSyntheticLambda1;->f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT$$ExternalSyntheticLambda1;->f$2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    invoke-static {v0, v1, v2, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT;->$r8$lambda$Pt3EE6LR3shwLSRXYi9R_MduhWY(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdBlock_MT;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I)V

    return-void
.end method
