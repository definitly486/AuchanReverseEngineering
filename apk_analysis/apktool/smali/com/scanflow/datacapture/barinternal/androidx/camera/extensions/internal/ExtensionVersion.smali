.class public abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/ExtensionVersion;
.super Ljava/lang/Object;
.source "ExtensionVersion.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/ExtensionVersion$VendorExtenderVersioning;,
        Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/ExtensionVersion$DefaultExtenderVersioning;
    }
.end annotation


# static fields
.field private static volatile sExtensionVersion:Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/ExtensionVersion;


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 28
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method private static getInstance()Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/ExtensionVersion;
    .locals 3

    .line 43
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/ExtensionVersion;->sExtensionVersion:Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/ExtensionVersion;

    if-eqz v0, :cond_0

    .line 44
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/ExtensionVersion;->sExtensionVersion:Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/ExtensionVersion;

    return-object v0

    .line 46
    :cond_0
    const-class v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/ExtensionVersion;

    monitor-enter v0

    .line 47
    :try_start_0
    sget-object v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/ExtensionVersion;->sExtensionVersion:Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/ExtensionVersion;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    if-nez v1, :cond_1

    .line 49
    :try_start_1
    new-instance v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/ExtensionVersion$VendorExtenderVersioning;

    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/ExtensionVersion$VendorExtenderVersioning;-><init>()V

    sput-object v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/ExtensionVersion;->sExtensionVersion:Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/ExtensionVersion;
    :try_end_1
    .catch Ljava/lang/NoClassDefFoundError; {:try_start_1 .. :try_end_1} :catch_0
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    goto :goto_0

    :catchall_0
    move-exception v1

    goto :goto_1

    .line 51
    :catch_0
    :try_start_2
    const-string v1, "ExtenderVersion"

    const-string v2, "No versioning extender found. Falling back to default."

    invoke-static {v1, v2}, Landroidx/camera/core/Logger;->d(Ljava/lang/String;Ljava/lang/String;)V

    .line 52
    new-instance v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/ExtensionVersion$DefaultExtenderVersioning;

    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/ExtensionVersion$DefaultExtenderVersioning;-><init>()V

    sput-object v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/ExtensionVersion;->sExtensionVersion:Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/ExtensionVersion;

    .line 55
    :cond_1
    :goto_0
    monitor-exit v0
    :try_end_2
    .catchall {:try_start_2 .. :try_end_2} :catchall_0

    .line 57
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/ExtensionVersion;->sExtensionVersion:Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/ExtensionVersion;

    return-object v0

    .line 55
    :goto_1
    :try_start_3
    monitor-exit v0
    :try_end_3
    .catchall {:try_start_3 .. :try_end_3} :catchall_0

    throw v1
.end method

.method public static getRuntimeVersion()Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/Version;
    .locals 1

    .line 80
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/ExtensionVersion;->getInstance()Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/ExtensionVersion;

    move-result-object v0

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/ExtensionVersion;->getVersionObject()Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/Version;

    move-result-object v0

    return-object v0
.end method

.method public static isMinimumCompatibleVersion(Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/Version;)Z
    .locals 2

    .line 99
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/ExtensionVersion;->getRuntimeVersion()Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/Version;

    move-result-object v0

    .line 100
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/Version;->getMajor()I

    move-result v1

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/Version;->getMinor()I

    move-result p0

    invoke-virtual {v0, v1, p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/Version;->compareTo(II)I

    move-result p0

    if-ltz p0, :cond_0

    const/4 p0, 0x1

    return p0

    :cond_0
    const/4 p0, 0x0

    return p0
.end method


# virtual methods
.method abstract getVersionObject()Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/Version;
.end method
