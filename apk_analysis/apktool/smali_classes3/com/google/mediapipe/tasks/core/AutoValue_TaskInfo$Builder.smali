.class final Lcom/google/mediapipe/tasks/core/AutoValue_TaskInfo$Builder;
.super Lcom/google/mediapipe/tasks/core/TaskInfo$Builder;
.source "AutoValue_TaskInfo.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/tasks/core/AutoValue_TaskInfo;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x18
    name = "Builder"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "<T:",
        "Lcom/google/mediapipe/tasks/core/TaskOptions;",
        ">",
        "Lcom/google/mediapipe/tasks/core/TaskInfo$Builder<",
        "TT;>;"
    }
.end annotation


# instance fields
.field private enableFlowLimiting:Ljava/lang/Boolean;

.field private inputStreams:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field private outputStreams:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field private taskGraphName:Ljava/lang/String;

.field private taskName:Ljava/lang/String;

.field private taskOptions:Lcom/google/mediapipe/tasks/core/TaskOptions;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "TT;"
        }
    .end annotation
.end field

.field private taskRunningModeName:Ljava/lang/String;


# direct methods
.method constructor <init>()V
    .locals 0

    .line 133
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/core/TaskInfo$Builder;-><init>()V

    return-void
.end method


# virtual methods
.method public autoBuild()Lcom/google/mediapipe/tasks/core/TaskInfo;
    .locals 11
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/mediapipe/tasks/core/TaskInfo<",
            "TT;>;"
        }
    .end annotation

    .line 191
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/AutoValue_TaskInfo$Builder;->taskName:Ljava/lang/String;

    const-string v1, ""

    if-nez v0, :cond_0

    .line 192
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, " taskName"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    .line 194
    :cond_0
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/AutoValue_TaskInfo$Builder;->taskRunningModeName:Ljava/lang/String;

    if-nez v0, :cond_1

    .line 195
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, " taskRunningModeName"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    .line 197
    :cond_1
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/AutoValue_TaskInfo$Builder;->taskGraphName:Ljava/lang/String;

    if-nez v0, :cond_2

    .line 198
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, " taskGraphName"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    .line 200
    :cond_2
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/AutoValue_TaskInfo$Builder;->taskOptions:Lcom/google/mediapipe/tasks/core/TaskOptions;

    if-nez v0, :cond_3

    .line 201
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, " taskOptions"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    .line 203
    :cond_3
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/AutoValue_TaskInfo$Builder;->inputStreams:Ljava/util/List;

    if-nez v0, :cond_4

    .line 204
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, " inputStreams"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    .line 206
    :cond_4
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/AutoValue_TaskInfo$Builder;->outputStreams:Ljava/util/List;

    if-nez v0, :cond_5

    .line 207
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, " outputStreams"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    .line 209
    :cond_5
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/AutoValue_TaskInfo$Builder;->enableFlowLimiting:Ljava/lang/Boolean;

    if-nez v0, :cond_6

    .line 210
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, " enableFlowLimiting"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    .line 212
    :cond_6
    invoke-virtual {v1}, Ljava/lang/String;->isEmpty()Z

    move-result v0

    if-eqz v0, :cond_7

    .line 215
    new-instance v2, Lcom/google/mediapipe/tasks/core/AutoValue_TaskInfo;

    iget-object v3, p0, Lcom/google/mediapipe/tasks/core/AutoValue_TaskInfo$Builder;->taskName:Ljava/lang/String;

    iget-object v4, p0, Lcom/google/mediapipe/tasks/core/AutoValue_TaskInfo$Builder;->taskRunningModeName:Ljava/lang/String;

    iget-object v5, p0, Lcom/google/mediapipe/tasks/core/AutoValue_TaskInfo$Builder;->taskGraphName:Ljava/lang/String;

    iget-object v6, p0, Lcom/google/mediapipe/tasks/core/AutoValue_TaskInfo$Builder;->taskOptions:Lcom/google/mediapipe/tasks/core/TaskOptions;

    iget-object v7, p0, Lcom/google/mediapipe/tasks/core/AutoValue_TaskInfo$Builder;->inputStreams:Ljava/util/List;

    iget-object v8, p0, Lcom/google/mediapipe/tasks/core/AutoValue_TaskInfo$Builder;->outputStreams:Ljava/util/List;

    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/AutoValue_TaskInfo$Builder;->enableFlowLimiting:Ljava/lang/Boolean;

    .line 222
    invoke-virtual {v0}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v9

    const/4 v10, 0x0

    invoke-direct/range {v2 .. v10}, Lcom/google/mediapipe/tasks/core/AutoValue_TaskInfo;-><init>(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/google/mediapipe/tasks/core/TaskOptions;Ljava/util/List;Ljava/util/List;ZLcom/google/mediapipe/tasks/core/AutoValue_TaskInfo$1;)V

    return-object v2

    .line 213
    :cond_7
    new-instance v0, Ljava/lang/IllegalStateException;

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "Missing required properties:"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method public setEnableFlowLimiting(Z)Lcom/google/mediapipe/tasks/core/TaskInfo$Builder;
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(Z)",
            "Lcom/google/mediapipe/tasks/core/TaskInfo$Builder<",
            "TT;>;"
        }
    .end annotation

    .line 185
    invoke-static {p1}, Ljava/lang/Boolean;->valueOf(Z)Ljava/lang/Boolean;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/tasks/core/AutoValue_TaskInfo$Builder;->enableFlowLimiting:Ljava/lang/Boolean;

    return-object p0
.end method

.method public setInputStreams(Ljava/util/List;)Lcom/google/mediapipe/tasks/core/TaskInfo$Builder;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;)",
            "Lcom/google/mediapipe/tasks/core/TaskInfo$Builder<",
            "TT;>;"
        }
    .end annotation

    if-eqz p1, :cond_0

    .line 172
    iput-object p1, p0, Lcom/google/mediapipe/tasks/core/AutoValue_TaskInfo$Builder;->inputStreams:Ljava/util/List;

    return-object p0

    .line 170
    :cond_0
    new-instance p1, Ljava/lang/NullPointerException;

    const-string v0, "Null inputStreams"

    invoke-direct {p1, v0}, Ljava/lang/NullPointerException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public setOutputStreams(Ljava/util/List;)Lcom/google/mediapipe/tasks/core/TaskInfo$Builder;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;)",
            "Lcom/google/mediapipe/tasks/core/TaskInfo$Builder<",
            "TT;>;"
        }
    .end annotation

    if-eqz p1, :cond_0

    .line 180
    iput-object p1, p0, Lcom/google/mediapipe/tasks/core/AutoValue_TaskInfo$Builder;->outputStreams:Ljava/util/List;

    return-object p0

    .line 178
    :cond_0
    new-instance p1, Ljava/lang/NullPointerException;

    const-string v0, "Null outputStreams"

    invoke-direct {p1, v0}, Ljava/lang/NullPointerException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public setTaskGraphName(Ljava/lang/String;)Lcom/google/mediapipe/tasks/core/TaskInfo$Builder;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            ")",
            "Lcom/google/mediapipe/tasks/core/TaskInfo$Builder<",
            "TT;>;"
        }
    .end annotation

    if-eqz p1, :cond_0

    .line 156
    iput-object p1, p0, Lcom/google/mediapipe/tasks/core/AutoValue_TaskInfo$Builder;->taskGraphName:Ljava/lang/String;

    return-object p0

    .line 154
    :cond_0
    new-instance p1, Ljava/lang/NullPointerException;

    const-string v0, "Null taskGraphName"

    invoke-direct {p1, v0}, Ljava/lang/NullPointerException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public setTaskName(Ljava/lang/String;)Lcom/google/mediapipe/tasks/core/TaskInfo$Builder;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            ")",
            "Lcom/google/mediapipe/tasks/core/TaskInfo$Builder<",
            "TT;>;"
        }
    .end annotation

    if-eqz p1, :cond_0

    .line 140
    iput-object p1, p0, Lcom/google/mediapipe/tasks/core/AutoValue_TaskInfo$Builder;->taskName:Ljava/lang/String;

    return-object p0

    .line 138
    :cond_0
    new-instance p1, Ljava/lang/NullPointerException;

    const-string v0, "Null taskName"

    invoke-direct {p1, v0}, Ljava/lang/NullPointerException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public setTaskOptions(Lcom/google/mediapipe/tasks/core/TaskOptions;)Lcom/google/mediapipe/tasks/core/TaskInfo$Builder;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(TT;)",
            "Lcom/google/mediapipe/tasks/core/TaskInfo$Builder<",
            "TT;>;"
        }
    .end annotation

    if-eqz p1, :cond_0

    .line 164
    iput-object p1, p0, Lcom/google/mediapipe/tasks/core/AutoValue_TaskInfo$Builder;->taskOptions:Lcom/google/mediapipe/tasks/core/TaskOptions;

    return-object p0

    .line 162
    :cond_0
    new-instance p1, Ljava/lang/NullPointerException;

    const-string v0, "Null taskOptions"

    invoke-direct {p1, v0}, Ljava/lang/NullPointerException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public setTaskRunningModeName(Ljava/lang/String;)Lcom/google/mediapipe/tasks/core/TaskInfo$Builder;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            ")",
            "Lcom/google/mediapipe/tasks/core/TaskInfo$Builder<",
            "TT;>;"
        }
    .end annotation

    if-eqz p1, :cond_0

    .line 148
    iput-object p1, p0, Lcom/google/mediapipe/tasks/core/AutoValue_TaskInfo$Builder;->taskRunningModeName:Ljava/lang/String;

    return-object p0

    .line 146
    :cond_0
    new-instance p1, Ljava/lang/NullPointerException;

    const-string v0, "Null taskRunningModeName"

    invoke-direct {p1, v0}, Ljava/lang/NullPointerException;-><init>(Ljava/lang/String;)V

    throw p1
.end method
