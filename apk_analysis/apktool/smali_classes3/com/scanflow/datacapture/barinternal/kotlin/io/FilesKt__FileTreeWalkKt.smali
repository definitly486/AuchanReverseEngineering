.class abstract Lcom/scanflow/datacapture/barinternal/kotlin/io/FilesKt__FileTreeWalkKt;
.super Lcom/scanflow/datacapture/barinternal/kotlin/io/FilesKt__FileReadWriteKt;
.source "FileTreeWalk.kt"


# direct methods
.method public static final walk(Ljava/io/File;Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;)Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk;
    .locals 1

    const-string v0, "<this>"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "direction"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 260
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk;

    invoke-direct {v0, p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk;-><init>(Ljava/io/File;Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;)V

    return-object v0
.end method

.method public static final walkBottomUp(Ljava/io/File;)Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk;
    .locals 1

    const-string v0, "<this>"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 272
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;->BOTTOM_UP:Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;

    invoke-static {p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/io/FilesKt__FileTreeWalkKt;->walk(Ljava/io/File;Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;)Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk;

    move-result-object p0

    return-object p0
.end method
