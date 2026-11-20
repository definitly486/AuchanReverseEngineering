.class public final synthetic Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda9;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Ljava/util/function/IntConsumer;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

.field public final synthetic f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

.field public final synthetic f$10:[F

.field public final synthetic f$2:I

.field public final synthetic f$3:I

.field public final synthetic f$4:[F

.field public final synthetic f$5:F

.field public final synthetic f$6:F

.field public final synthetic f$7:F

.field public final synthetic f$8:F

.field public final synthetic f$9:F


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;II[FFFFFF[F)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda9;->f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda9;->f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iput p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda9;->f$2:I

    iput p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda9;->f$3:I

    iput-object p5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda9;->f$4:[F

    iput p6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda9;->f$5:F

    iput p7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda9;->f$6:F

    iput p8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda9;->f$7:F

    iput p9, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda9;->f$8:F

    iput p10, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda9;->f$9:F

    iput-object p11, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda9;->f$10:[F

    return-void
.end method


# virtual methods
.method public final accept(I)V
    .locals 12

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda9;->f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda9;->f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda9;->f$2:I

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda9;->f$3:I

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda9;->f$4:[F

    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda9;->f$5:F

    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda9;->f$6:F

    iget v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda9;->f$7:F

    iget v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda9;->f$8:F

    iget v9, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda9;->f$9:F

    iget-object v10, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32$$ExternalSyntheticLambda9;->f$10:[F

    move v11, p1

    invoke-static/range {v0 .. v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_F32_F32;->$r8$lambda$WcLprpi05aRbSuN8lgkehHU-oNE(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;II[FFFFFF[FI)V

    return-void
.end method
