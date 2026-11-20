.class Landroidx/constraintlayout/core/motion/Motion$1;
.super Ljava/lang/Object;
.source "Motion.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/DifferentialInterpolator;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Landroidx/constraintlayout/core/motion/Motion;->getInterpolator(ILjava/lang/String;I)Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/DifferentialInterpolator;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field mX:F

.field final synthetic val$easing:Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Easing;


# direct methods
.method constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Easing;)V
    .locals 0

    .line 1161
    iput-object p1, p0, Landroidx/constraintlayout/core/motion/Motion$1;->val$easing:Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Easing;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public getInterpolation(F)F
    .locals 3

    .line 1166
    iput p1, p0, Landroidx/constraintlayout/core/motion/Motion$1;->mX:F

    .line 1167
    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion$1;->val$easing:Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Easing;

    float-to-double v1, p1

    invoke-virtual {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Easing;->get(D)D

    move-result-wide v0

    double-to-float p1, v0

    return p1
.end method
