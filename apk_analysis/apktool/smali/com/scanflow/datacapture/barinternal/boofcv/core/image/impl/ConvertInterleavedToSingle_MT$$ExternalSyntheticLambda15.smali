.class public final synthetic Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda15;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Ljava/util/function/IntConsumer;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS8;

.field public final synthetic f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda15;->f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS8;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda15;->f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;

    return-void
.end method


# virtual methods
.method public final accept(I)V
    .locals 2

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda15;->f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS8;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda15;->f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;

    invoke-static {v0, v1, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ConvertInterleavedToSingle_MT;->$r8$lambda$n9AvgPMorITJHzpwV3k-TvUJWps(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;I)V

    return-void
.end method
