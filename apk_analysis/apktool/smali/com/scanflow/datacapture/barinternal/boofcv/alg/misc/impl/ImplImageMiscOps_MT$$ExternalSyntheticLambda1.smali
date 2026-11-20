.class public final synthetic Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageMiscOps_MT$$ExternalSyntheticLambda1;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Ljava/util/function/IntConsumer;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

.field public final synthetic f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;

.field public final synthetic f$2:I

.field public final synthetic f$3:I


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;II)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageMiscOps_MT$$ExternalSyntheticLambda1;->f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageMiscOps_MT$$ExternalSyntheticLambda1;->f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;

    iput p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageMiscOps_MT$$ExternalSyntheticLambda1;->f$2:I

    iput p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageMiscOps_MT$$ExternalSyntheticLambda1;->f$3:I

    return-void
.end method


# virtual methods
.method public final accept(I)V
    .locals 4

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageMiscOps_MT$$ExternalSyntheticLambda1;->f$0:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageMiscOps_MT$$ExternalSyntheticLambda1;->f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageMiscOps_MT$$ExternalSyntheticLambda1;->f$2:I

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageMiscOps_MT$$ExternalSyntheticLambda1;->f$3:I

    invoke-static {v0, v1, v2, v3, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageMiscOps_MT;->$r8$lambda$6qNwGIwwnaUxCd3prRxkzyJQ-84(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;III)V

    return-void
.end method
