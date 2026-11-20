.class public final synthetic Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda0;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Ljava/util/function/IntConsumer;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;

.field public final synthetic f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

.field public final synthetic f$2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

.field public final synthetic f$3:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

.field public final synthetic f$4:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda0;->f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda0;->f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda0;->f$2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    iput-object p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda0;->f$3:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    iput-object p5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda0;->f$4:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    return-void
.end method


# virtual methods
.method public final accept(I)V
    .locals 6

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda0;->f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda0;->f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda0;->f$2:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda0;->f$3:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda0;->f$4:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    move v5, p1

    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray_MT;->$r8$lambda$_7R9Zu1qeVnHN210XL-OdWiyD4Y(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;I)V

    return-void
.end method
