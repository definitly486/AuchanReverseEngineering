.class Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Niblack;
.super Ljava/lang/Object;
.source "ThresholdNiblackFamily.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Threshold;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = "Niblack"
.end annotation


# instance fields
.field final synthetic this$0:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;


# direct methods
.method constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;)V
    .locals 0

    .line 189
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Niblack;->this$0:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public final compute(FF)F
    .locals 1

    .line 191
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Niblack;->this$0:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;

    iget v0, v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;->k:F

    mul-float/2addr v0, p2

    add-float/2addr p1, v0

    return p1
.end method
