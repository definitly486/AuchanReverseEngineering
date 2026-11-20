.class public final synthetic Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT$$ExternalSyntheticLambda1;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntRangeConsumer;


# instance fields
.field public final synthetic f$0:[I

.field public final synthetic f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;

.field public final synthetic f$2:J

.field public final synthetic f$3:Ljava/util/List;


# direct methods
.method public synthetic constructor <init>([ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;JLjava/util/List;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT$$ExternalSyntheticLambda1;->f$0:[I

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT$$ExternalSyntheticLambda1;->f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;

    iput-wide p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT$$ExternalSyntheticLambda1;->f$2:J

    iput-object p5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT$$ExternalSyntheticLambda1;->f$3:Ljava/util/List;

    return-void
.end method


# virtual methods
.method public final accept(II)V
    .locals 7

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT$$ExternalSyntheticLambda1;->f$0:[I

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT$$ExternalSyntheticLambda1;->f$1:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;

    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT$$ExternalSyntheticLambda1;->f$2:J

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT$$ExternalSyntheticLambda1;->f$3:Ljava/util/List;

    move v5, p1

    move v6, p2

    invoke-static/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/misc/impl/ImplImageStatistics_MT;->$r8$lambda$SxfqGrwqUIDCikjjzYkyxGoUVzs([ILcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;JLjava/util/List;II)V

    return-void
.end method
