.class public final synthetic Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda1;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Ljava/util/function/IntConsumer;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

.field public final synthetic f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

.field public final synthetic f$2:I

.field public final synthetic f$3:I

.field public final synthetic f$4:F


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;IIF)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda1;->f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda1;->f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iput p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda1;->f$2:I

    iput p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda1;->f$3:I

    iput p5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda1;->f$4:F

    return-void
.end method


# virtual methods
.method public final accept(I)V
    .locals 6

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda1;->f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda1;->f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda1;->f$2:I

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda1;->f$3:I

    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda1;->f$4:F

    move v5, p1

    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT;->$r8$lambda$HsJRtBlB-TyrGjeIrXsVP6FDqQo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;IIFI)V

    return-void
.end method
