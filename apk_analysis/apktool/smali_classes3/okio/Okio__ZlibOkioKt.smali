.class abstract synthetic Lokio/Okio__ZlibOkioKt;
.super Ljava/lang/Object;
.source "ZlibOkio.kt"


# direct methods
.method public static final openZip(Lokio/FileSystem;Lokio/Path;)Lokio/FileSystem;
    .locals 2

    const-string v0, "<this>"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "zipPath"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const/4 v0, 0x0

    const/4 v1, 0x4

    .line 26
    invoke-static {p1, p0, v0, v1, v0}, Lcom/scanflow/datacapture/barinternal/okio/internal/ZipFilesKt;->openZip$default(Lokio/Path;Lokio/FileSystem;Lkotlin/jvm/functions/Function1;ILjava/lang/Object;)Lokio/ZipFileSystem;

    move-result-object p0

    return-object p0
.end method
