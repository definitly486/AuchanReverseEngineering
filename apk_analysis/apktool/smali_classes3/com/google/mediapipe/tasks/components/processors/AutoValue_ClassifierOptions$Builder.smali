.class final Lcom/google/mediapipe/tasks/components/processors/AutoValue_ClassifierOptions$Builder;
.super Lcom/google/mediapipe/tasks/components/processors/ClassifierOptions$Builder;
.source "AutoValue_ClassifierOptions.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/tasks/components/processors/AutoValue_ClassifierOptions;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x18
    name = "Builder"
.end annotation


# instance fields
.field private categoryAllowlist:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field private categoryDenylist:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field private displayNamesLocale:Ljava/util/Optional;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Optional<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field private maxResults:Ljava/util/Optional;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Optional<",
            "Ljava/lang/Integer;",
            ">;"
        }
    .end annotation
.end field

.field private scoreThreshold:Ljava/util/Optional;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Optional<",
            "Ljava/lang/Float;",
            ">;"
        }
    .end annotation
.end field


# direct methods
.method constructor <init>()V
    .locals 1

    .line 106
    invoke-direct {p0}, Lcom/google/mediapipe/tasks/components/processors/ClassifierOptions$Builder;-><init>()V

    .line 101
    invoke-static {}, Ljava/util/Optional;->empty()Ljava/util/Optional;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/tasks/components/processors/AutoValue_ClassifierOptions$Builder;->displayNamesLocale:Ljava/util/Optional;

    .line 102
    invoke-static {}, Ljava/util/Optional;->empty()Ljava/util/Optional;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/tasks/components/processors/AutoValue_ClassifierOptions$Builder;->maxResults:Ljava/util/Optional;

    .line 103
    invoke-static {}, Ljava/util/Optional;->empty()Ljava/util/Optional;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/tasks/components/processors/AutoValue_ClassifierOptions$Builder;->scoreThreshold:Ljava/util/Optional;

    return-void
.end method


# virtual methods
.method autoBuild()Lcom/google/mediapipe/tasks/components/processors/ClassifierOptions;
    .locals 9

    .line 142
    iget-object v0, p0, Lcom/google/mediapipe/tasks/components/processors/AutoValue_ClassifierOptions$Builder;->categoryAllowlist:Ljava/util/List;

    const-string v1, ""

    if-nez v0, :cond_0

    .line 143
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, " categoryAllowlist"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    .line 145
    :cond_0
    iget-object v0, p0, Lcom/google/mediapipe/tasks/components/processors/AutoValue_ClassifierOptions$Builder;->categoryDenylist:Ljava/util/List;

    if-nez v0, :cond_1

    .line 146
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, " categoryDenylist"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    .line 148
    :cond_1
    invoke-virtual {v1}, Ljava/lang/String;->isEmpty()Z

    move-result v0

    if-eqz v0, :cond_2

    .line 151
    new-instance v2, Lcom/google/mediapipe/tasks/components/processors/AutoValue_ClassifierOptions;

    iget-object v3, p0, Lcom/google/mediapipe/tasks/components/processors/AutoValue_ClassifierOptions$Builder;->displayNamesLocale:Ljava/util/Optional;

    iget-object v4, p0, Lcom/google/mediapipe/tasks/components/processors/AutoValue_ClassifierOptions$Builder;->maxResults:Ljava/util/Optional;

    iget-object v5, p0, Lcom/google/mediapipe/tasks/components/processors/AutoValue_ClassifierOptions$Builder;->scoreThreshold:Ljava/util/Optional;

    iget-object v6, p0, Lcom/google/mediapipe/tasks/components/processors/AutoValue_ClassifierOptions$Builder;->categoryAllowlist:Ljava/util/List;

    iget-object v7, p0, Lcom/google/mediapipe/tasks/components/processors/AutoValue_ClassifierOptions$Builder;->categoryDenylist:Ljava/util/List;

    const/4 v8, 0x0

    invoke-direct/range {v2 .. v8}, Lcom/google/mediapipe/tasks/components/processors/AutoValue_ClassifierOptions;-><init>(Ljava/util/Optional;Ljava/util/Optional;Ljava/util/Optional;Ljava/util/List;Ljava/util/List;Lcom/google/mediapipe/tasks/components/processors/AutoValue_ClassifierOptions$1;)V

    return-object v2

    .line 149
    :cond_2
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

.method public setCategoryAllowlist(Ljava/util/List;)Lcom/google/mediapipe/tasks/components/processors/ClassifierOptions$Builder;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;)",
            "Lcom/google/mediapipe/tasks/components/processors/ClassifierOptions$Builder;"
        }
    .end annotation

    if-eqz p1, :cond_0

    .line 128
    iput-object p1, p0, Lcom/google/mediapipe/tasks/components/processors/AutoValue_ClassifierOptions$Builder;->categoryAllowlist:Ljava/util/List;

    return-object p0

    .line 126
    :cond_0
    new-instance p1, Ljava/lang/NullPointerException;

    const-string v0, "Null categoryAllowlist"

    invoke-direct {p1, v0}, Ljava/lang/NullPointerException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public setCategoryDenylist(Ljava/util/List;)Lcom/google/mediapipe/tasks/components/processors/ClassifierOptions$Builder;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;)",
            "Lcom/google/mediapipe/tasks/components/processors/ClassifierOptions$Builder;"
        }
    .end annotation

    if-eqz p1, :cond_0

    .line 136
    iput-object p1, p0, Lcom/google/mediapipe/tasks/components/processors/AutoValue_ClassifierOptions$Builder;->categoryDenylist:Ljava/util/List;

    return-object p0

    .line 134
    :cond_0
    new-instance p1, Ljava/lang/NullPointerException;

    const-string v0, "Null categoryDenylist"

    invoke-direct {p1, v0}, Ljava/lang/NullPointerException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public setDisplayNamesLocale(Ljava/lang/String;)Lcom/google/mediapipe/tasks/components/processors/ClassifierOptions$Builder;
    .locals 0

    .line 110
    invoke-static {p1}, Ljava/util/Optional;->of(Ljava/lang/Object;)Ljava/util/Optional;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/tasks/components/processors/AutoValue_ClassifierOptions$Builder;->displayNamesLocale:Ljava/util/Optional;

    return-object p0
.end method

.method public setMaxResults(Ljava/lang/Integer;)Lcom/google/mediapipe/tasks/components/processors/ClassifierOptions$Builder;
    .locals 0

    .line 115
    invoke-static {p1}, Ljava/util/Optional;->of(Ljava/lang/Object;)Ljava/util/Optional;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/tasks/components/processors/AutoValue_ClassifierOptions$Builder;->maxResults:Ljava/util/Optional;

    return-object p0
.end method

.method public setScoreThreshold(Ljava/lang/Float;)Lcom/google/mediapipe/tasks/components/processors/ClassifierOptions$Builder;
    .locals 0

    .line 120
    invoke-static {p1}, Ljava/util/Optional;->of(Ljava/lang/Object;)Ljava/util/Optional;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/tasks/components/processors/AutoValue_ClassifierOptions$Builder;->scoreThreshold:Ljava/util/Optional;

    return-object p0
.end method
