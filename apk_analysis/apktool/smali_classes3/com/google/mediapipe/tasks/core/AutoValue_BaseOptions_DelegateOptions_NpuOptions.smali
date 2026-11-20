.class final Lcom/google/mediapipe/tasks/core/AutoValue_BaseOptions_DelegateOptions_NpuOptions;
.super Lcom/google/mediapipe/tasks/core/BaseOptions$DelegateOptions$NpuOptions;
.source "AutoValue_BaseOptions_DelegateOptions_NpuOptions.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/tasks/core/AutoValue_BaseOptions_DelegateOptions_NpuOptions$Builder;
    }
.end annotation


# instance fields
.field private final dispatchLibraryDirectory:Ljava/lang/String;


# direct methods
.method private constructor <init>(Ljava/lang/String;)V
    .locals 0

    .line 9
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/core/BaseOptions$DelegateOptions$NpuOptions;-><init>()V

    .line 10
    iput-object p1, p0, Lcom/google/mediapipe/tasks/core/AutoValue_BaseOptions_DelegateOptions_NpuOptions;->dispatchLibraryDirectory:Ljava/lang/String;

    return-void
.end method

.method synthetic constructor <init>(Ljava/lang/String;Lcom/google/mediapipe/tasks/core/AutoValue_BaseOptions_DelegateOptions_NpuOptions$1;)V
    .locals 0

    .line 4
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/core/AutoValue_BaseOptions_DelegateOptions_NpuOptions;-><init>(Ljava/lang/String;)V

    return-void
.end method


# virtual methods
.method dispatchLibraryDirectory()Ljava/lang/String;
    .locals 1

    .line 15
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/AutoValue_BaseOptions_DelegateOptions_NpuOptions;->dispatchLibraryDirectory:Ljava/lang/String;

    return-object v0
.end method

.method public equals(Ljava/lang/Object;)Z
    .locals 1

    if-ne p1, p0, :cond_0

    const/4 p1, 0x1

    return p1

    .line 30
    :cond_0
    instance-of v0, p1, Lcom/google/mediapipe/tasks/core/BaseOptions$DelegateOptions$NpuOptions;

    if-eqz v0, :cond_1

    .line 31
    check-cast p1, Lcom/google/mediapipe/tasks/core/BaseOptions$DelegateOptions$NpuOptions;

    .line 32
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/AutoValue_BaseOptions_DelegateOptions_NpuOptions;->dispatchLibraryDirectory:Ljava/lang/String;

    invoke-virtual {p1}, Lcom/google/mediapipe/tasks/core/BaseOptions$DelegateOptions$NpuOptions;->dispatchLibraryDirectory()Ljava/lang/String;

    move-result-object p1

    invoke-virtual {v0, p1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result p1

    return p1

    :cond_1
    const/4 p1, 0x0

    return p1
.end method

.method public hashCode()I
    .locals 2

    .line 41
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/AutoValue_BaseOptions_DelegateOptions_NpuOptions;->dispatchLibraryDirectory:Ljava/lang/String;

    invoke-virtual {v0}, Ljava/lang/String;->hashCode()I

    move-result v0

    const v1, 0xf4243

    xor-int/2addr v0, v1

    return v0
.end method

.method public toString()Ljava/lang/String;
    .locals 2

    .line 20
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "NpuOptions{dispatchLibraryDirectory="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/google/mediapipe/tasks/core/AutoValue_BaseOptions_DelegateOptions_NpuOptions;->dispatchLibraryDirectory:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, "}"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
