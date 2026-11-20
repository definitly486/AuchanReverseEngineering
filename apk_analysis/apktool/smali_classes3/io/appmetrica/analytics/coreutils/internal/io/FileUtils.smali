.class public final Lio/appmetrica/analytics/coreutils/internal/io/FileUtils;
.super Ljava/lang/Object;
.source "SourceFile"


# static fields
.field public static final INSTANCE:Lio/appmetrica/analytics/coreutils/internal/io/FileUtils;

.field public static final SDK_FILES_PREFIX:Ljava/lang/String; = "appmetrica_analytics"

.field public static final SDK_STORAGE_RELATIVE_PATH:Ljava/lang/String; = "/appmetrica/analytics"

.field private static volatile a:Ljava/io/File;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 0
    new-instance v0, Lio/appmetrica/analytics/coreutils/internal/io/FileUtils;

    invoke-direct {v0}, Lio/appmetrica/analytics/coreutils/internal/io/FileUtils;-><init>()V

    sput-object v0, Lio/appmetrica/analytics/coreutils/internal/io/FileUtils;->INSTANCE:Lio/appmetrica/analytics/coreutils/internal/io/FileUtils;

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 1
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static final copyToNullable(Ljava/io/File;Ljava/io/File;)Z
    .locals 8

    const/4 v0, 0x0

    if-eqz p0, :cond_1

    if-nez p1, :cond_0

    goto :goto_0

    .line 1
    :cond_0
    invoke-virtual {p0}, Ljava/io/File;->exists()Z

    move-result v1

    if-eqz v1, :cond_1

    const/4 v6, 0x6

    const/4 v7, 0x0

    const/4 v4, 0x0

    const/4 v5, 0x0

    move-object v2, p0

    move-object v3, p1

    .line 4
    :try_start_0
    invoke-static/range {v2 .. v7}, Lcom/scanflow/datacapture/barinternal/kotlin/io/FilesKt;->copyTo$default(Ljava/io/File;Ljava/io/File;ZIILjava/lang/Object;)Ljava/io/File;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    const/4 p0, 0x1

    return p0

    :catchall_0
    :cond_1
    :goto_0
    return v0
.end method

.method public static final getAppDataDir(Landroid/content/Context;)Ljava/io/File;
    .locals 1

    const/16 v0, 0x18

    .line 1
    invoke-static {v0}, Lio/appmetrica/analytics/coreutils/internal/AndroidUtils;->isApiAchieved(I)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 2
    sget-object v0, Lio/appmetrica/analytics/coreutils/internal/io/AppDataDirProviderForN;->INSTANCE:Lio/appmetrica/analytics/coreutils/internal/io/AppDataDirProviderForN;

    invoke-virtual {v0, p0}, Lio/appmetrica/analytics/coreutils/internal/io/AppDataDirProviderForN;->dataDir(Landroid/content/Context;)Ljava/io/File;

    move-result-object p0

    return-object p0

    .line 4
    :cond_0
    invoke-virtual {p0}, Landroid/content/Context;->getFilesDir()Ljava/io/File;

    move-result-object p0

    if-eqz p0, :cond_1

    invoke-virtual {p0}, Ljava/io/File;->getParentFile()Ljava/io/File;

    move-result-object p0

    return-object p0

    :cond_1
    const/4 p0, 0x0

    return-object p0
.end method

.method public static final getAppStorageDirectory(Landroid/content/Context;)Ljava/io/File;
    .locals 0

    .line 1
    invoke-virtual {p0}, Landroid/content/Context;->getNoBackupFilesDir()Ljava/io/File;

    move-result-object p0

    return-object p0
.end method

.method public static final getCrashesDirectory(Landroid/content/Context;)Ljava/io/File;
    .locals 1

    .line 1
    const-string v0, "crashes"

    invoke-static {p0, v0}, Lio/appmetrica/analytics/coreutils/internal/io/FileUtils;->getFileFromSdkStorage(Landroid/content/Context;Ljava/lang/String;)Ljava/io/File;

    move-result-object p0

    return-object p0
.end method

.method public static final getFileFromAppStorage(Landroid/content/Context;Ljava/lang/String;)Ljava/io/File;
    .locals 1

    .line 1
    invoke-static {p0}, Lio/appmetrica/analytics/coreutils/internal/io/FileUtils;->getAppStorageDirectory(Landroid/content/Context;)Ljava/io/File;

    move-result-object p0

    if-eqz p0, :cond_0

    new-instance v0, Ljava/io/File;

    invoke-direct {v0, p0, p1}, Ljava/io/File;-><init>(Ljava/io/File;Ljava/lang/String;)V

    return-object v0

    :cond_0
    const/4 p0, 0x0

    return-object p0
.end method

.method public static final getFileFromPath(Ljava/lang/String;)Ljava/io/File;
    .locals 1

    .line 1
    new-instance v0, Ljava/io/File;

    invoke-direct {v0, p0}, Ljava/io/File;-><init>(Ljava/lang/String;)V

    return-object v0
.end method

.method public static final getFileFromSdkStorage(Landroid/content/Context;Ljava/lang/String;)Ljava/io/File;
    .locals 1

    .line 1
    invoke-static {p0}, Lio/appmetrica/analytics/coreutils/internal/io/FileUtils;->sdkStorage(Landroid/content/Context;)Ljava/io/File;

    move-result-object p0

    if-eqz p0, :cond_0

    new-instance v0, Ljava/io/File;

    invoke-direct {v0, p0, p1}, Ljava/io/File;-><init>(Ljava/io/File;Ljava/lang/String;)V

    return-object v0

    :cond_0
    const/4 p0, 0x0

    return-object p0
.end method

.method public static final getNativeCrashDirectory(Landroid/content/Context;)Ljava/io/File;
    .locals 1

    .line 1
    const-string v0, "native_crashes"

    invoke-static {p0, v0}, Lio/appmetrica/analytics/coreutils/internal/io/FileUtils;->getFileFromSdkStorage(Landroid/content/Context;Ljava/lang/String;)Ljava/io/File;

    move-result-object p0

    return-object p0
.end method

.method public static final move(Ljava/io/File;Ljava/io/File;)Z
    .locals 2

    .line 1
    sget-object v0, Lio/appmetrica/analytics/coreutils/internal/io/FileUtils;->INSTANCE:Lio/appmetrica/analytics/coreutils/internal/io/FileUtils;

    invoke-virtual {v0, p0, p1}, Lio/appmetrica/analytics/coreutils/internal/io/FileUtils;->moveByRename(Ljava/io/File;Ljava/io/File;)Z

    move-result v1

    if-nez v1, :cond_1

    invoke-virtual {v0, p0, p1}, Lio/appmetrica/analytics/coreutils/internal/io/FileUtils;->moveByCopy(Ljava/io/File;Ljava/io/File;)Z

    move-result p0

    if-eqz p0, :cond_0

    goto :goto_0

    :cond_0
    const/4 p0, 0x0

    return p0

    :cond_1
    :goto_0
    const/4 p0, 0x1

    return p0
.end method

.method public static final resetSdkStorage()V
    .locals 2

    .line 1
    sget-object v0, Lio/appmetrica/analytics/coreutils/internal/io/FileUtils;->INSTANCE:Lio/appmetrica/analytics/coreutils/internal/io/FileUtils;

    monitor-enter v0

    const/4 v1, 0x0

    .line 2
    :try_start_0
    sput-object v1, Lio/appmetrica/analytics/coreutils/internal/io/FileUtils;->a:Ljava/io/File;

    .line 3
    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 4
    monitor-exit v0

    return-void

    :catchall_0
    move-exception v1

    .line 5
    monitor-exit v0

    throw v1
.end method

.method public static final sdkStorage(Landroid/content/Context;)Ljava/io/File;
    .locals 3

    .line 1
    sget-object v0, Lio/appmetrica/analytics/coreutils/internal/io/FileUtils;->a:Ljava/io/File;

    if-nez v0, :cond_2

    .line 2
    sget-object v0, Lio/appmetrica/analytics/coreutils/internal/io/FileUtils;->INSTANCE:Lio/appmetrica/analytics/coreutils/internal/io/FileUtils;

    monitor-enter v0

    .line 6
    :try_start_0
    invoke-static {p0}, Lio/appmetrica/analytics/coreutils/internal/io/FileUtils;->getAppStorageDirectory(Landroid/content/Context;)Ljava/io/File;

    move-result-object p0

    if-nez p0, :cond_0

    const/4 p0, 0x0

    goto :goto_1

    .line 7
    :cond_0
    new-instance v1, Ljava/io/File;

    const-string v2, "/appmetrica/analytics"

    invoke-direct {v1, p0, v2}, Ljava/io/File;-><init>(Ljava/io/File;Ljava/lang/String;)V

    .line 9
    invoke-virtual {v1}, Ljava/io/File;->exists()Z

    move-result p0

    if-nez p0, :cond_1

    .line 11
    invoke-virtual {v1}, Ljava/io/File;->mkdirs()Z

    goto :goto_0

    :catchall_0
    move-exception p0

    goto :goto_2

    :cond_1
    :goto_0
    move-object p0, v1

    .line 12
    :goto_1
    sput-object p0, Lio/appmetrica/analytics/coreutils/internal/io/FileUtils;->a:Ljava/io/File;

    .line 13
    sget-object p0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 14
    monitor-exit v0

    goto :goto_3

    :goto_2
    monitor-exit v0

    throw p0

    .line 21
    :cond_2
    :goto_3
    sget-object p0, Lio/appmetrica/analytics/coreutils/internal/io/FileUtils;->a:Ljava/io/File;

    return-object p0
.end method


# virtual methods
.method public final moveByCopy(Ljava/io/File;Ljava/io/File;)Z
    .locals 8

    const/4 v0, 0x0

    if-eqz p1, :cond_1

    if-nez p2, :cond_0

    goto :goto_0

    .line 1
    :cond_0
    invoke-virtual {p1}, Ljava/io/File;->exists()Z

    move-result v1

    if-eqz v1, :cond_1

    const/4 v6, 0x6

    const/4 v7, 0x0

    const/4 v4, 0x0

    const/4 v5, 0x0

    move-object v2, p1

    move-object v3, p2

    .line 4
    :try_start_0
    invoke-static/range {v2 .. v7}, Lcom/scanflow/datacapture/barinternal/kotlin/io/FilesKt;->copyTo$default(Ljava/io/File;Ljava/io/File;ZIILjava/lang/Object;)Ljava/io/File;

    .line 5
    invoke-virtual {v2}, Ljava/io/File;->delete()Z
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    const/4 p1, 0x1

    return p1

    :catchall_0
    :cond_1
    :goto_0
    return v0
.end method

.method public final moveByRename(Ljava/io/File;Ljava/io/File;)Z
    .locals 0

    if-eqz p2, :cond_1

    if-eqz p1, :cond_0

    .line 1
    invoke-virtual {p1, p2}, Ljava/io/File;->renameTo(Ljava/io/File;)Z

    move-result p1

    invoke-static {p1}, Ljava/lang/Boolean;->valueOf(Z)Ljava/lang/Boolean;

    move-result-object p1

    goto :goto_0

    :cond_0
    const/4 p1, 0x0

    :goto_0
    if-eqz p1, :cond_1

    invoke-virtual {p1}, Ljava/lang/Boolean;->booleanValue()Z

    move-result p1

    return p1

    :cond_1
    const/4 p1, 0x0

    return p1
.end method
