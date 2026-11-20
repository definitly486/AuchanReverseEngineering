.class final Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk$FileTreeWalkIterator$SingleFileState;
.super Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk$WalkState;
.source "FileTreeWalk.kt"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk$FileTreeWalkIterator;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x12
    name = "SingleFileState"
.end annotation


# instance fields
.field final synthetic this$0:Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk$FileTreeWalkIterator;

.field private visited:Z


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk$FileTreeWalkIterator;Ljava/io/File;)V
    .locals 1

    const-string v0, "rootFile"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 196
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk$FileTreeWalkIterator$SingleFileState;->this$0:Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk$FileTreeWalkIterator;

    invoke-direct {p0, p2}, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk$WalkState;-><init>(Ljava/io/File;)V

    return-void
.end method


# virtual methods
.method public step()Ljava/io/File;
    .locals 1

    .line 205
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk$FileTreeWalkIterator$SingleFileState;->visited:Z

    if-eqz v0, :cond_0

    const/4 v0, 0x0

    return-object v0

    :cond_0
    const/4 v0, 0x1

    .line 206
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk$FileTreeWalkIterator$SingleFileState;->visited:Z

    .line 207
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk$WalkState;->getRoot()Ljava/io/File;

    move-result-object v0

    return-object v0
.end method
