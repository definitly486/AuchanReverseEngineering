.class public final synthetic Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda0;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Ljava/util/function/IntConsumer;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;

.field public final synthetic f$1:I

.field public final synthetic f$10:I

.field public final synthetic f$2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

.field public final synthetic f$3:I

.field public final synthetic f$4:[B

.field public final synthetic f$5:I

.field public final synthetic f$6:I

.field public final synthetic f$7:I

.field public final synthetic f$8:[B

.field public final synthetic f$9:I


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I[BIII[BII)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda0;->f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;

    iput p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda0;->f$1:I

    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda0;->f$2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    iput p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda0;->f$3:I

    iput-object p5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda0;->f$4:[B

    iput p6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda0;->f$5:I

    iput p7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda0;->f$6:I

    iput p8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda0;->f$7:I

    iput-object p9, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda0;->f$8:[B

    iput p10, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda0;->f$9:I

    iput p11, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda0;->f$10:I

    return-void
.end method


# virtual methods
.method public final accept(I)V
    .locals 12

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda0;->f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda0;->f$1:I

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda0;->f$2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda0;->f$3:I

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda0;->f$4:[B

    iget v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda0;->f$5:I

    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda0;->f$6:I

    iget v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda0;->f$7:I

    iget-object v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda0;->f$8:[B

    iget v9, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda0;->f$9:I

    iget v10, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div$$ExternalSyntheticLambda0;->f$10:I

    move v11, p1

    invoke-static/range {v0 .. v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U8_I8_Div;->$r8$lambda$spRpiw8VmuRjZ-FAfmCn5cMjolo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I[BIII[BIII)V

    return-void
.end method
