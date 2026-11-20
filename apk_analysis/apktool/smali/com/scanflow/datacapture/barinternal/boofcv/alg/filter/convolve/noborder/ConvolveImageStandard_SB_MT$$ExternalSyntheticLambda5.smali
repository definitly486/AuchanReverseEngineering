.class public final synthetic Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda5;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Ljava/util/function/IntConsumer;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;

.field public final synthetic f$1:I

.field public final synthetic f$2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

.field public final synthetic f$3:I

.field public final synthetic f$4:I

.field public final synthetic f$5:[S

.field public final synthetic f$6:[I

.field public final synthetic f$7:[S

.field public final synthetic f$8:I

.field public final synthetic f$9:I


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;II[S[I[SII)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda5;->f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;

    iput p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda5;->f$1:I

    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda5;->f$2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    iput p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda5;->f$3:I

    iput p5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda5;->f$4:I

    iput-object p6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda5;->f$5:[S

    iput-object p7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda5;->f$6:[I

    iput-object p8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda5;->f$7:[S

    iput p9, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda5;->f$8:I

    iput p10, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda5;->f$9:I

    return-void
.end method


# virtual methods
.method public final accept(I)V
    .locals 11

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda5;->f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda5;->f$1:I

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda5;->f$2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda5;->f$3:I

    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda5;->f$4:I

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda5;->f$5:[S

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda5;->f$6:[I

    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda5;->f$7:[S

    iget v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda5;->f$8:I

    iget v9, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda5;->f$9:I

    move v10, p1

    invoke-static/range {v0 .. v10}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT;->$r8$lambda$e4rDyyEbyojip-b3SYDz09JSCsU(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;II[S[I[SIII)V

    return-void
.end method
