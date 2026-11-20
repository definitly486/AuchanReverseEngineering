.class public final synthetic Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda6;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Ljava/util/function/IntConsumer;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;

.field public final synthetic f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda6;->f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda6;->f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;

    return-void
.end method


# virtual methods
.method public final accept(I)V
    .locals 2

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda6;->f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda6;->f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;

    invoke-static {v0, v1, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT;->$r8$lambda$LDoexoirWL2DfsjEJ7qJ1zTa0oI(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;I)V

    return-void
.end method
