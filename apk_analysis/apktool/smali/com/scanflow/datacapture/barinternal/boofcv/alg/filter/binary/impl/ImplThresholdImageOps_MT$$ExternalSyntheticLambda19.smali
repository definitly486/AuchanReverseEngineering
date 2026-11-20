.class public final synthetic Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda19;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Ljava/util/function/IntConsumer;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

.field public final synthetic f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

.field public final synthetic f$2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

.field public final synthetic f$3:F


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;F)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda19;->f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda19;->f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda19;->f$2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iput p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda19;->f$3:F

    return-void
.end method


# virtual methods
.method public final accept(I)V
    .locals 4

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda19;->f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda19;->f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda19;->f$2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT$$ExternalSyntheticLambda19;->f$3:F

    invoke-static {v0, v1, v2, v3, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/impl/ImplThresholdImageOps_MT;->$r8$lambda$46qDHGtpefM5Oy9Tfm7il7cdoZw(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;FI)V

    return-void
.end method
