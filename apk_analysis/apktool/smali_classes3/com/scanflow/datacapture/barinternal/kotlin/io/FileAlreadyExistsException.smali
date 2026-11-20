.class public final Lcom/scanflow/datacapture/barinternal/kotlin/io/FileAlreadyExistsException;
.super Lcom/scanflow/datacapture/barinternal/kotlin/io/FileSystemException;
.source "Exceptions.kt"


# direct methods
.method public constructor <init>(Ljava/io/File;Ljava/io/File;Ljava/lang/String;)V
    .locals 1

    const-string v0, "file"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 37
    invoke-direct {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileSystemException;-><init>(Ljava/io/File;Ljava/io/File;Ljava/lang/String;)V

    return-void
.end method
