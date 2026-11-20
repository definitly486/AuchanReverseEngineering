.class public final synthetic Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda9;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Ljava/util/function/IntConsumer;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;

.field public final synthetic f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

.field public final synthetic f$2:I


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;I)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda9;->f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda9;->f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    iput p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda9;->f$2:I

    return-void
.end method


# virtual methods
.method public final accept(I)V
    .locals 3

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda9;->f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda9;->f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda9;->f$2:I

    invoke-static {v0, v1, v2, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT;->$r8$lambda$_ANHPtn-U9-8-VSVtPPVfcAaCFA(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;II)V

    return-void
.end method
