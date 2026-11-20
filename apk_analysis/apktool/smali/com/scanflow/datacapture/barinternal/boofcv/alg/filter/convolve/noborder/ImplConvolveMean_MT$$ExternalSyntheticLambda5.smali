.class public final synthetic Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda5;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntRangeObjectConsumer;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

.field public final synthetic f$1:I

.field public final synthetic f$2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;

.field public final synthetic f$3:I

.field public final synthetic f$4:I

.field public final synthetic f$5:I

.field public final synthetic f$6:I

.field public final synthetic f$7:I


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;IIIII)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda5;->f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    iput p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda5;->f$1:I

    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda5;->f$2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;

    iput p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda5;->f$3:I

    iput p5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda5;->f$4:I

    iput p6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda5;->f$5:I

    iput p7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda5;->f$6:I

    iput p8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda5;->f$7:I

    return-void
.end method


# virtual methods
.method public final accept(Ljava/lang/Object;II)V
    .locals 11

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda5;->f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda5;->f$1:I

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda5;->f$2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda5;->f$3:I

    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda5;->f$4:I

    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda5;->f$5:I

    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda5;->f$6:I

    iget v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT$$ExternalSyntheticLambda5;->f$7:I

    move-object v8, p1

    check-cast v8, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    move v9, p2

    move v10, p3

    invoke-static/range {v0 .. v10}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ImplConvolveMean_MT;->$r8$lambda$_-Xg89S-iGt0uRugWER9D5wwEMA(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;IIIIILcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;II)V

    return-void
.end method
