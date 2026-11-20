.class public final synthetic Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda0;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Ljava/util/function/IntConsumer;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;

.field public final synthetic f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

.field public final synthetic f$10:[S

.field public final synthetic f$11:I

.field public final synthetic f$12:I

.field public final synthetic f$2:I

.field public final synthetic f$3:I

.field public final synthetic f$4:[S

.field public final synthetic f$5:I

.field public final synthetic f$6:I

.field public final synthetic f$7:I

.field public final synthetic f$8:I

.field public final synthetic f$9:I


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;II[SIIIII[SII)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda0;->f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda0;->f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    iput p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda0;->f$2:I

    iput p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda0;->f$3:I

    iput-object p5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda0;->f$4:[S

    iput p6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda0;->f$5:I

    iput p7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda0;->f$6:I

    iput p8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda0;->f$7:I

    iput p9, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda0;->f$8:I

    iput p10, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda0;->f$9:I

    iput-object p11, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda0;->f$10:[S

    iput p12, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda0;->f$11:I

    iput p13, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda0;->f$12:I

    return-void
.end method


# virtual methods
.method public final accept(I)V
    .locals 14

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda0;->f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda0;->f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda0;->f$2:I

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda0;->f$3:I

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda0;->f$4:[S

    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda0;->f$5:I

    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda0;->f$6:I

    iget v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda0;->f$7:I

    iget v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda0;->f$8:I

    iget v9, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda0;->f$9:I

    iget-object v10, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda0;->f$10:[S

    iget v11, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda0;->f$11:I

    iget v12, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda0;->f$12:I

    move v13, p1

    invoke-static/range {v0 .. v13}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div;->$r8$lambda$ktpLg4R6e5UEgn_ahvPnQK3glsg(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;II[SIIIII[SIII)V

    return-void
.end method
