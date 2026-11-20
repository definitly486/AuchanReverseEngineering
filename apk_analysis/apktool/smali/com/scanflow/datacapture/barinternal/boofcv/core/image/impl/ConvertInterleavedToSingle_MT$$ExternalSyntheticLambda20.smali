.class public final synthetic Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda20;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Ljava/util/function/IntConsumer;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU16;

.field public final synthetic f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

.field public final synthetic f$2:I


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;I)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda20;->f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU16;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda20;->f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    iput p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda20;->f$2:I

    return-void
.end method


# virtual methods
.method public final accept(I)V
    .locals 3

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda20;->f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU16;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda20;->f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda20;->f$2:I

    invoke-static {v0, v1, v2, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT;->$r8$lambda$avsj8iVfACY9vi1yumEt_jXaxHw(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU16;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;II)V

    return-void
.end method
