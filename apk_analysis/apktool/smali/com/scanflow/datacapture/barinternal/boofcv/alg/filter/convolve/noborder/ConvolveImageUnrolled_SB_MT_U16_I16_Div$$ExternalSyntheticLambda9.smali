.class public final synthetic Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Ljava/util/function/IntConsumer;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;

.field public final synthetic f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

.field public final synthetic f$10:I

.field public final synthetic f$11:I

.field public final synthetic f$12:I

.field public final synthetic f$13:I

.field public final synthetic f$14:I

.field public final synthetic f$15:I

.field public final synthetic f$16:[S

.field public final synthetic f$17:I

.field public final synthetic f$18:I

.field public final synthetic f$2:I

.field public final synthetic f$3:I

.field public final synthetic f$4:[S

.field public final synthetic f$5:I

.field public final synthetic f$6:I

.field public final synthetic f$7:I

.field public final synthetic f$8:I

.field public final synthetic f$9:I


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;II[SIIIIIIIIIII[SII)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9;->f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9;->f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    iput p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9;->f$2:I

    iput p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9;->f$3:I

    iput-object p5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9;->f$4:[S

    iput p6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9;->f$5:I

    iput p7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9;->f$6:I

    iput p8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9;->f$7:I

    iput p9, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9;->f$8:I

    iput p10, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9;->f$9:I

    iput p11, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9;->f$10:I

    iput p12, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9;->f$11:I

    iput p13, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9;->f$12:I

    iput p14, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9;->f$13:I

    iput p15, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9;->f$14:I

    move/from16 p1, p16

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9;->f$15:I

    move-object/from16 p1, p17

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9;->f$16:[S

    move/from16 p1, p18

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9;->f$17:I

    move/from16 p1, p19

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9;->f$18:I

    return-void
.end method


# virtual methods
.method public final accept(I)V
    .locals 21

    .line 0
    move-object/from16 v0, p0

    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9;->f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;

    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9;->f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    iget v3, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9;->f$2:I

    iget v4, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9;->f$3:I

    iget-object v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9;->f$4:[S

    iget v6, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9;->f$5:I

    iget v7, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9;->f$6:I

    iget v8, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9;->f$7:I

    iget v9, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9;->f$8:I

    iget v10, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9;->f$9:I

    iget v11, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9;->f$10:I

    iget v12, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9;->f$11:I

    iget v13, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9;->f$12:I

    iget v14, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9;->f$13:I

    iget v15, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9;->f$14:I

    move-object/from16 v16, v1

    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9;->f$15:I

    move/from16 v17, v1

    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9;->f$16:[S

    move-object/from16 v18, v1

    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9;->f$17:I

    move/from16 v19, v1

    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div$$ExternalSyntheticLambda9;->f$18:I

    move/from16 v20, v19

    move/from16 v19, v1

    move-object/from16 v1, v16

    move/from16 v16, v17

    move-object/from16 v17, v18

    move/from16 v18, v20

    move/from16 v20, p1

    invoke-static/range {v1 .. v20}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_MT_U16_I16_Div;->$r8$lambda$Bh5fg0Dx9z4s3l1l7Qav8Er55Ig(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;II[SIIIIIIIIIII[SIII)V

    return-void
.end method
