.class public final synthetic Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu_MT$$ExternalSyntheticLambda0;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntRangeConsumer;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu_MT;

.field public final synthetic f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

.field public final synthetic f$2:I

.field public final synthetic f$3:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

.field public final synthetic f$4:I

.field public final synthetic f$5:B

.field public final synthetic f$6:B

.field public final synthetic f$7:I


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu_MT;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;IBBI)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu_MT$$ExternalSyntheticLambda0;->f$0:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu_MT;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu_MT$$ExternalSyntheticLambda0;->f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    iput p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu_MT$$ExternalSyntheticLambda0;->f$2:I

    iput-object p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu_MT$$ExternalSyntheticLambda0;->f$3:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    iput p5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu_MT$$ExternalSyntheticLambda0;->f$4:I

    iput-byte p6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu_MT$$ExternalSyntheticLambda0;->f$5:B

    iput-byte p7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu_MT$$ExternalSyntheticLambda0;->f$6:B

    iput p8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu_MT$$ExternalSyntheticLambda0;->f$7:I

    return-void
.end method


# virtual methods
.method public final accept(II)V
    .locals 10

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu_MT$$ExternalSyntheticLambda0;->f$0:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu_MT;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu_MT$$ExternalSyntheticLambda0;->f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu_MT$$ExternalSyntheticLambda0;->f$2:I

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu_MT$$ExternalSyntheticLambda0;->f$3:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    iget v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu_MT$$ExternalSyntheticLambda0;->f$4:I

    iget-byte v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu_MT$$ExternalSyntheticLambda0;->f$5:B

    iget-byte v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu_MT$$ExternalSyntheticLambda0;->f$6:B

    iget v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu_MT$$ExternalSyntheticLambda0;->f$7:I

    move v8, p1

    move v9, p2

    invoke-static/range {v0 .. v9}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu_MT;->$r8$lambda$dUCKF_QMbnfjPIhcrBpWUGX8CfQ(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdLocalOtsu_MT;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;IBBIII)V

    return-void
.end method
