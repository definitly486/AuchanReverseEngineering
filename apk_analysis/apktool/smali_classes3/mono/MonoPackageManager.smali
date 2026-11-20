.class public Lmono/MonoPackageManager;
.super Ljava/lang/Object;
.source "MonoPackageManager.java"


# static fields
.field static initialized:Z

.field static lock:Ljava/lang/Object;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 25
    new-instance v0, Ljava/lang/Object;

    invoke-direct {v0}, Ljava/lang/Object;-><init>()V

    sput-object v0, Lmono/MonoPackageManager;->lock:Ljava/lang/Object;

    return-void
.end method

.method public constructor <init>()V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static LoadApplication(Landroid/content/Context;)V
    .locals 15

    .line 30
    sget-object v1, Lmono/MonoPackageManager;->lock:Ljava/lang/Object;

    monitor-enter v1

    .line 31
    :try_start_0
    invoke-virtual {p0}, Landroid/content/Context;->getApplicationInfo()Landroid/content/pm/ApplicationInfo;

    move-result-object v0

    .line 33
    iget-object v2, v0, Landroid/content/pm/ApplicationInfo;->splitSourceDirs:[Ljava/lang/String;

    const/4 v3, 0x0

    const/4 v4, 0x1

    if-eqz v2, :cond_0

    .line 34
    array-length v5, v2

    if-lez v5, :cond_0

    .line 35
    array-length v5, v2

    add-int/2addr v5, v4

    new-array v5, v5, [Ljava/lang/String;

    .line 36
    iget-object v6, v0, Landroid/content/pm/ApplicationInfo;->sourceDir:Ljava/lang/String;

    aput-object v6, v5, v3

    .line 37
    array-length v6, v2

    invoke-static {v2, v3, v5, v4, v6}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    :goto_0
    move-object v7, v5

    goto :goto_1

    :catchall_0
    move-exception v0

    move-object p0, v0

    goto/16 :goto_4

    .line 39
    :cond_0
    iget-object v2, v0, Landroid/content/pm/ApplicationInfo;->sourceDir:Ljava/lang/String;

    filled-new-array {v2}, [Ljava/lang/String;

    move-result-object v5

    goto :goto_0

    .line 42
    :goto_1
    instance-of v2, p0, Landroid/app/Application;

    if-eqz v2, :cond_1

    .line 43
    sput-object p0, Lnet/dot/android/ApplicationRegistration;->Context:Landroid/content/Context;

    .line 45
    :cond_1
    sget-boolean v2, Lmono/MonoPackageManager;->initialized:Z

    if-nez v2, :cond_5

    .line 46
    new-instance v2, Landroid/content/IntentFilter;

    const-string v5, "android.intent.action.TIMEZONE_CHANGED"

    invoke-direct {v2, v5}, Landroid/content/IntentFilter;-><init>(Ljava/lang/String;)V

    .line 49
    new-instance v5, Lmono/android/app/NotifyTimeZoneChanges;

    invoke-direct {v5}, Lmono/android/app/NotifyTimeZoneChanges;-><init>()V

    invoke-virtual {p0, v5, v2}, Landroid/content/Context;->registerReceiver(Landroid/content/BroadcastReceiver;Landroid/content/IntentFilter;)Landroid/content/Intent;

    .line 51
    invoke-static {}, Ljava/util/Locale;->getDefault()Ljava/util/Locale;

    move-result-object v2

    .line 52
    invoke-virtual {v2}, Ljava/util/Locale;->getLanguage()Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v2}, Ljava/util/Locale;->getCountry()Ljava/lang/String;

    move-result-object v2

    new-instance v6, Ljava/lang/StringBuilder;

    invoke-direct {v6}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v6, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v5, "-"

    invoke-virtual {v6, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v6, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v6}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v6

    .line 53
    invoke-virtual {p0}, Landroid/content/Context;->getFilesDir()Ljava/io/File;

    move-result-object v2

    invoke-virtual {v2}, Ljava/io/File;->getAbsolutePath()Ljava/lang/String;

    move-result-object v2

    .line 54
    invoke-virtual {p0}, Landroid/content/Context;->getCacheDir()Ljava/io/File;

    move-result-object v5

    invoke-virtual {v5}, Ljava/io/File;->getAbsolutePath()Ljava/lang/String;

    move-result-object v5

    .line 55
    invoke-static {p0}, Lmono/MonoPackageManager;->getNativeLibraryPath(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v8

    .line 56
    invoke-virtual {p0}, Landroid/content/Context;->getClassLoader()Ljava/lang/ClassLoader;

    move-result-object v11

    move-object p0, v8

    .line 57
    invoke-static {v0}, Lmono/MonoPackageManager;->getNativeLibraryPath(Landroid/content/pm/ApplicationInfo;)Ljava/lang/String;

    move-result-object v8

    .line 61
    invoke-static {}, Ljava/time/OffsetDateTime;->now()Ljava/time/OffsetDateTime;

    move-result-object v9

    invoke-virtual {v9}, Ljava/time/OffsetDateTime;->getOffset()Ljava/time/ZoneOffset;

    move-result-object v9

    invoke-virtual {v9}, Ljava/time/ZoneOffset;->getTotalSeconds()I

    move-result v10

    .line 71
    filled-new-array {v2, v5, p0}, [Ljava/lang/String;

    move-result-object v9

    .line 72
    iget-object p0, v0, Landroid/content/pm/ApplicationInfo;->splitSourceDirs:[Ljava/lang/String;

    if-eqz p0, :cond_2

    array-length p0, p0

    if-lez p0, :cond_2

    move v14, v4

    goto :goto_2

    :cond_2
    move v14, v3

    .line 101
    :goto_2
    sget-boolean p0, Lmono/android/BuildConfig;->Debug:Z

    if-eqz p0, :cond_3

    .line 102
    const-string p0, "xamarin-debug-app-helper"

    invoke-static {p0}, Ljava/lang/System;->loadLibrary(Ljava/lang/String;)V

    .line 103
    invoke-static {v7, v8, v9, v14}, Lmono/android/DebugRuntime;->init([Ljava/lang/String;Ljava/lang/String;[Ljava/lang/String;Z)V

    goto :goto_3

    .line 105
    :cond_3
    const-string p0, "monosgen-2.0"

    invoke-static {p0}, Ljava/lang/System;->loadLibrary(Ljava/lang/String;)V

    .line 107
    :goto_3
    const-string p0, "xamarin-app"

    invoke-static {p0}, Ljava/lang/System;->loadLibrary(Ljava/lang/String;)V

    .line 109
    sget-boolean p0, Lmono/android/BuildConfig;->DotNetRuntime:Z

    if-nez p0, :cond_4

    .line 111
    const-string p0, "mono-native"

    invoke-static {p0}, Ljava/lang/System;->loadLibrary(Ljava/lang/String;)V

    .line 114
    :cond_4
    const-string p0, "monodroid"

    invoke-static {p0}, Ljava/lang/System;->loadLibrary(Ljava/lang/String;)V

    .line 116
    sget-object v12, Lmono/MonoPackageManager_Resources;->Assemblies:[Ljava/lang/String;

    .line 124
    invoke-static {}, Lmono/MonoPackageManager;->isEmulator()Z

    move-result v13

    .line 116
    invoke-static/range {v6 .. v14}, Lmono/android/Runtime;->initInternal(Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;[Ljava/lang/String;ILjava/lang/ClassLoader;[Ljava/lang/String;ZZ)V

    .line 128
    invoke-static {}, Lnet/dot/android/ApplicationRegistration;->registerApplications()V

    .line 130
    sput-boolean v4, Lmono/MonoPackageManager;->initialized:Z

    .line 132
    :cond_5
    monitor-exit v1

    return-void

    :goto_4
    monitor-exit v1
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw p0
.end method

.method public static getAssemblies()[Ljava/lang/String;
    .locals 1

    .line 170
    sget-object v0, Lmono/MonoPackageManager_Resources;->Assemblies:[Ljava/lang/String;

    return-object v0
.end method

.method public static getDependencies()[Ljava/lang/String;
    .locals 1

    .line 175
    sget-object v0, Lmono/MonoPackageManager_Resources;->Dependencies:[Ljava/lang/String;

    return-object v0
.end method

.method static getNativeLibraryPath(Landroid/content/Context;)Ljava/lang/String;
    .locals 0

    .line 158
    invoke-virtual {p0}, Landroid/content/Context;->getApplicationInfo()Landroid/content/pm/ApplicationInfo;

    move-result-object p0

    invoke-static {p0}, Lmono/MonoPackageManager;->getNativeLibraryPath(Landroid/content/pm/ApplicationInfo;)Ljava/lang/String;

    move-result-object p0

    return-object p0
.end method

.method static getNativeLibraryPath(Landroid/content/pm/ApplicationInfo;)Ljava/lang/String;
    .locals 0

    .line 164
    iget-object p0, p0, Landroid/content/pm/ApplicationInfo;->nativeLibraryDir:Ljava/lang/String;

    return-object p0
.end method

.method static isEmulator()Z
    .locals 2

    .line 142
    sget-object v0, Landroid/os/Build;->HARDWARE:Ljava/lang/String;

    .line 145
    const-string v1, "ranchu"

    invoke-virtual {v0, v1}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v1

    if-nez v1, :cond_1

    const-string v1, "goldfish"

    invoke-virtual {v0, v1}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v0

    if-eqz v0, :cond_0

    goto :goto_0

    :cond_0
    const/4 v0, 0x0

    return v0

    :cond_1
    :goto_0
    const/4 v0, 0x1

    return v0
.end method

.method public static setContext(Landroid/content/Context;)V
    .locals 0

    .line 0
    return-void
.end method
