.class public final synthetic Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda3;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntRangeObjectConsumer;


# instance fields
.field public final synthetic f$0:I

.field public final synthetic f$1:I

.field public final synthetic f$2:[I

.field public final synthetic f$3:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

.field public final synthetic f$4:I

.field public final synthetic f$5:[B

.field public final synthetic f$6:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;

.field public final synthetic f$7:[B

.field public final synthetic f$8:I

.field public final synthetic f$9:D


# direct methods
.method public synthetic constructor <init>(II[ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I[BLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;[BID)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda3;->f$0:I

    iput p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda3;->f$1:I

    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda3;->f$2:[I

    iput-object p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda3;->f$3:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    iput p5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda3;->f$4:I

    iput-object p6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda3;->f$5:[B

    iput-object p7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda3;->f$6:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;

    iput-object p8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda3;->f$7:[B

    iput p9, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda3;->f$8:I

    iput-wide p10, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda3;->f$9:D

    return-void
.end method


# virtual methods
.method public final accept(Ljava/lang/Object;II)V
    .locals 14

    .line 0
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda3;->f$0:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda3;->f$1:I

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda3;->f$2:[I

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda3;->f$3:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda3;->f$4:I

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda3;->f$5:[B

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda3;->f$6:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;

    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda3;->f$7:[B

    iget v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda3;->f$8:I

    iget-wide v9, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT$$ExternalSyntheticLambda3;->f$9:D

    move-object v11, p1

    check-cast v11, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    move/from16 v12, p2

    move/from16 v13, p3

    invoke-static/range {v0 .. v13}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageStandard_SB_MT;->$r8$lambda$Qnl-XEX3Ijy56wcd0ebmQ31SfkQ(II[ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I[BLcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;[BIDLcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;II)V

    return-void
.end method
