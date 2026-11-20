.class public Lcom/scanflow/datacapture/core/source/super_resolution/ProcessResult;
.super Ljava/lang/Object;
.source "SourceFile"


# instance fields
.field private final classes:[Ljava/lang/String;

.field private final inferenceTime:J

.field private final results:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List<",
            "Lcom/scanflow/datacapture/core/source/super_resolution/EnhancementResult;",
            ">;"
        }
    .end annotation
.end field

.field private final totalTime:J


# direct methods
.method public constructor <init>(Ljava/util/List;[Ljava/lang/String;JJ)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/List<",
            "Lcom/scanflow/datacapture/core/source/super_resolution/EnhancementResult;",
            ">;[",
            "Ljava/lang/String;",
            "JJ)V"
        }
    .end annotation

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/core/source/super_resolution/ProcessResult;->results:Ljava/util/List;

    iput-object p2, p0, Lcom/scanflow/datacapture/core/source/super_resolution/ProcessResult;->classes:[Ljava/lang/String;

    iput-wide p3, p0, Lcom/scanflow/datacapture/core/source/super_resolution/ProcessResult;->inferenceTime:J

    iput-wide p5, p0, Lcom/scanflow/datacapture/core/source/super_resolution/ProcessResult;->totalTime:J

    return-void
.end method


# virtual methods
.method public getClasses()[Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/source/super_resolution/ProcessResult;->classes:[Ljava/lang/String;

    return-object v0
.end method

.method public getInferenceTime()J
    .locals 2

    .line 0
    iget-wide v0, p0, Lcom/scanflow/datacapture/core/source/super_resolution/ProcessResult;->inferenceTime:J

    return-wide v0
.end method

.method public getResults()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Lcom/scanflow/datacapture/core/source/super_resolution/EnhancementResult;",
            ">;"
        }
    .end annotation

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/source/super_resolution/ProcessResult;->results:Ljava/util/List;

    return-object v0
.end method

.method public getTotalTime()J
    .locals 2

    .line 0
    iget-wide v0, p0, Lcom/scanflow/datacapture/core/source/super_resolution/ProcessResult;->totalTime:J

    return-wide v0
.end method
