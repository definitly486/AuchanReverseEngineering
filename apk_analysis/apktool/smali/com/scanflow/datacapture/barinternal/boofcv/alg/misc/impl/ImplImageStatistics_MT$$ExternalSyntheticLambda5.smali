.class public final synthetic Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT$$ExternalSyntheticLambda5;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntRangeConsumer;


# instance fields
.field public final synthetic f$0:[I

.field public final synthetic f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

.field public final synthetic f$2:I

.field public final synthetic f$3:Ljava/util/List;


# direct methods
.method public synthetic constructor <init>([ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;ILjava/util/List;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT$$ExternalSyntheticLambda5;->f$0:[I

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT$$ExternalSyntheticLambda5;->f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    iput p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT$$ExternalSyntheticLambda5;->f$2:I

    iput-object p4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT$$ExternalSyntheticLambda5;->f$3:Ljava/util/List;

    return-void
.end method


# virtual methods
.method public final accept(II)V
    .locals 6

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT$$ExternalSyntheticLambda5;->f$0:[I

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT$$ExternalSyntheticLambda5;->f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT$$ExternalSyntheticLambda5;->f$2:I

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT$$ExternalSyntheticLambda5;->f$3:Ljava/util/List;

    move v4, p1

    move v5, p2

    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT;->$r8$lambda$-iVURLV8Z4H1yb530Lg0lTfIzJ8([ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;ILjava/util/List;II)V

    return-void
.end method
