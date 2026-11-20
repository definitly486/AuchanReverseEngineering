.class abstract Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk$DirectoryState;
.super Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk$WalkState;
.source "FileTreeWalk.kt"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x40a
    name = "DirectoryState"
.end annotation


# direct methods
.method public constructor <init>(Ljava/io/File;)V
    .locals 1

    const-string v0, "rootDir"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 59
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk$WalkState;-><init>(Ljava/io/File;)V

    return-void
.end method
