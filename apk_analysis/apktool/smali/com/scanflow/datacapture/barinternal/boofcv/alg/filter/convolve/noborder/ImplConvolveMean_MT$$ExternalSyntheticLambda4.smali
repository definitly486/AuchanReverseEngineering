.class public final synthetic Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda4;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Ljava/util/function/IntConsumer;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

.field public final synthetic f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;

.field public final synthetic f$2:I

.field public final synthetic f$3:I

.field public final synthetic f$4:I

.field public final synthetic f$5:I


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;IIII)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda4;->f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda4;->f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;

    iput p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda4;->f$2:I

    iput p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda4;->f$3:I

    iput p5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda4;->f$4:I

    iput p6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda4;->f$5:I

    return-void
.end method


# virtual methods
.method public final accept(I)V
    .locals 7

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda4;->f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda4;->f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda4;->f$2:I

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda4;->f$3:I

    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda4;->f$4:I

    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda4;->f$5:I

    move v6, p1

    invoke-static/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT;->$r8$lambda$0nPwRzCUBJO8YZmLar1pHlIjqNA(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;IIIII)V

    return-void
.end method
