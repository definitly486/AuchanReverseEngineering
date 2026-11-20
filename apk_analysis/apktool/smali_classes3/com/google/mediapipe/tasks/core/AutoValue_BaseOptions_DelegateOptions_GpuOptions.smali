.class final Lcom/google/mediapipe/tasks/core/AutoValue_BaseOptions_DelegateOptions_GpuOptions;
.super Lcom/google/mediapipe/tasks/core/BaseOptions$DelegateOptions$GpuOptions;
.source "AutoValue_BaseOptions_DelegateOptions_GpuOptions.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/tasks/core/AutoValue_BaseOptions_DelegateOptions_GpuOptions$Builder;
    }
.end annotation


# instance fields
.field private final cachedKernelPath:Ljava/util/Optional;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Optional<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field private final modelToken:Ljava/util/Optional;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Optional<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field private final serializedModelDir:Ljava/util/Optional;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Optional<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field


# direct methods
.method private constructor <init>(Ljava/util/Optional;Ljava/util/Optional;Ljava/util/Optional;)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/Optional<",
            "Ljava/lang/String;",
            ">;",
            "Ljava/util/Optional<",
            "Ljava/lang/String;",
            ">;",
            "Ljava/util/Optional<",
            "Ljava/lang/String;",
            ">;)V"
        }
    .end annotation

    .line 17
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/core/BaseOptions$DelegateOptions$GpuOptions;-><init>()V

    .line 18
    iput-object p1, p0, Lcom/google/mediapipe/tasks/core/AutoValue_BaseOptions_DelegateOptions_GpuOptions;->cachedKernelPath:Ljava/util/Optional;

    .line 19
    iput-object p2, p0, Lcom/google/mediapipe/tasks/core/AutoValue_BaseOptions_DelegateOptions_GpuOptions;->serializedModelDir:Ljava/util/Optional;

    .line 20
    iput-object p3, p0, Lcom/google/mediapipe/tasks/core/AutoValue_BaseOptions_DelegateOptions_GpuOptions;->modelToken:Ljava/util/Optional;

    return-void
.end method

.method synthetic constructor <init>(Ljava/util/Optional;Ljava/util/Optional;Ljava/util/Optional;Lcom/google/mediapipe/tasks/core/AutoValue_BaseOptions_DelegateOptions_GpuOptions$1;)V
    .locals 0

    .line 6
    invoke-direct {p0, p1, p2, p3}, Lcom/google/mediapipe/tasks/core/AutoValue_BaseOptions_DelegateOptions_GpuOptions;-><init>(Ljava/util/Optional;Ljava/util/Optional;Ljava/util/Optional;)V

    return-void
.end method


# virtual methods
.method cachedKernelPath()Ljava/util/Optional;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/Optional<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .line 25
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/AutoValue_BaseOptions_DelegateOptions_GpuOptions;->cachedKernelPath:Ljava/util/Optional;

    return-object v0
.end method

.method public equals(Ljava/lang/Object;)Z
    .locals 4

    const/4 v0, 0x1

    if-ne p1, p0, :cond_0

    return v0

    .line 52
    :cond_0
    instance-of v1, p1, Lcom/google/mediapipe/tasks/core/BaseOptions$DelegateOptions$GpuOptions;

    const/4 v2, 0x0

    if-eqz v1, :cond_1

    .line 53
    check-cast p1, Lcom/google/mediapipe/tasks/core/BaseOptions$DelegateOptions$GpuOptions;

    .line 54
    iget-object v1, p0, Lcom/google/mediapipe/tasks/core/AutoValue_BaseOptions_DelegateOptions_GpuOptions;->cachedKernelPath:Ljava/util/Optional;

    invoke-virtual {p1}, Lcom/google/mediapipe/tasks/core/BaseOptions$DelegateOptions$GpuOptions;->cachedKernelPath()Ljava/util/Optional;

    move-result-object v3

    invoke-virtual {v1, v3}, Ljava/util/Optional;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_1

    iget-object v1, p0, Lcom/google/mediapipe/tasks/core/AutoValue_BaseOptions_DelegateOptions_GpuOptions;->serializedModelDir:Ljava/util/Optional;

    .line 55
    invoke-virtual {p1}, Lcom/google/mediapipe/tasks/core/BaseOptions$DelegateOptions$GpuOptions;->serializedModelDir()Ljava/util/Optional;

    move-result-object v3

    invoke-virtual {v1, v3}, Ljava/util/Optional;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_1

    iget-object v1, p0, Lcom/google/mediapipe/tasks/core/AutoValue_BaseOptions_DelegateOptions_GpuOptions;->modelToken:Ljava/util/Optional;

    .line 56
    invoke-virtual {p1}, Lcom/google/mediapipe/tasks/core/BaseOptions$DelegateOptions$GpuOptions;->modelToken()Ljava/util/Optional;

    move-result-object p1

    invoke-virtual {v1, p1}, Ljava/util/Optional;->equals(Ljava/lang/Object;)Z

    move-result p1

    if-eqz p1, :cond_1

    return v0

    :cond_1
    return v2
.end method

.method public hashCode()I
    .locals 3

    .line 65
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/AutoValue_BaseOptions_DelegateOptions_GpuOptions;->cachedKernelPath:Ljava/util/Optional;

    invoke-virtual {v0}, Ljava/util/Optional;->hashCode()I

    move-result v0

    const v1, 0xf4243

    xor-int/2addr v0, v1

    mul-int/2addr v0, v1

    .line 67
    iget-object v2, p0, Lcom/google/mediapipe/tasks/core/AutoValue_BaseOptions_DelegateOptions_GpuOptions;->serializedModelDir:Ljava/util/Optional;

    invoke-virtual {v2}, Ljava/util/Optional;->hashCode()I

    move-result v2

    xor-int/2addr v0, v2

    mul-int/2addr v0, v1

    .line 69
    iget-object v1, p0, Lcom/google/mediapipe/tasks/core/AutoValue_BaseOptions_DelegateOptions_GpuOptions;->modelToken:Ljava/util/Optional;

    invoke-virtual {v1}, Ljava/util/Optional;->hashCode()I

    move-result v1

    xor-int/2addr v0, v1

    return v0
.end method

.method modelToken()Ljava/util/Optional;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/Optional<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .line 35
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/AutoValue_BaseOptions_DelegateOptions_GpuOptions;->modelToken:Ljava/util/Optional;

    return-object v0
.end method

.method serializedModelDir()Ljava/util/Optional;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/Optional<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .line 30
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/AutoValue_BaseOptions_DelegateOptions_GpuOptions;->serializedModelDir:Ljava/util/Optional;

    return-object v0
.end method

.method public toString()Ljava/lang/String;
    .locals 2

    .line 40
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "GpuOptions{cachedKernelPath="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/google/mediapipe/tasks/core/AutoValue_BaseOptions_DelegateOptions_GpuOptions;->cachedKernelPath:Ljava/util/Optional;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v1, ", serializedModelDir="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/google/mediapipe/tasks/core/AutoValue_BaseOptions_DelegateOptions_GpuOptions;->serializedModelDir:Ljava/util/Optional;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v1, ", modelToken="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/google/mediapipe/tasks/core/AutoValue_BaseOptions_DelegateOptions_GpuOptions;->modelToken:Ljava/util/Optional;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v1, "}"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
