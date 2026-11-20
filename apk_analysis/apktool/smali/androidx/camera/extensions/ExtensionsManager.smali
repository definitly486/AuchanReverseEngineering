.class public final Landroidx/camera/extensions/ExtensionsManager;
.super Ljava/lang/Object;
.source "ExtensionsManager.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Landroidx/camera/extensions/ExtensionsManager$ExtensionsAvailability;
    }
.end annotation


# static fields
.field private static final EXTENSIONS_LOCK:Ljava/lang/Object;

.field private static sExtensionsManager:Landroidx/camera/extensions/ExtensionsManager;


# instance fields
.field private final mExtensionsAvailability:Landroidx/camera/extensions/ExtensionsManager$ExtensionsAvailability;

.field private final mExtensionsInfo:Landroidx/camera/extensions/ExtensionsInfo;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 165
    new-instance v0, Ljava/lang/Object;

    invoke-direct {v0}, Ljava/lang/Object;-><init>()V

    sput-object v0, Landroidx/camera/extensions/ExtensionsManager;->EXTENSIONS_LOCK:Ljava/lang/Object;

    return-void
.end method

.method private constructor <init>(Landroidx/camera/extensions/ExtensionsManager$ExtensionsAvailability;Landroidx/camera/core/CameraProvider;)V
    .locals 0

    .line 559
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 560
    iput-object p1, p0, Landroidx/camera/extensions/ExtensionsManager;->mExtensionsAvailability:Landroidx/camera/extensions/ExtensionsManager$ExtensionsAvailability;

    .line 561
    new-instance p1, Landroidx/camera/extensions/ExtensionsInfo;

    invoke-direct {p1, p2}, Landroidx/camera/extensions/ExtensionsInfo;-><init>(Landroidx/camera/core/CameraProvider;)V

    iput-object p1, p0, Landroidx/camera/extensions/ExtensionsManager;->mExtensionsInfo:Landroidx/camera/extensions/ExtensionsInfo;

    return-void
.end method

.method static getOrCreateExtensionsManager(Landroidx/camera/extensions/ExtensionsManager$ExtensionsAvailability;Landroidx/camera/core/CameraProvider;)Landroidx/camera/extensions/ExtensionsManager;
    .locals 2

    .line 388
    sget-object v0, Landroidx/camera/extensions/ExtensionsManager;->EXTENSIONS_LOCK:Ljava/lang/Object;

    monitor-enter v0

    .line 389
    :try_start_0
    sget-object v1, Landroidx/camera/extensions/ExtensionsManager;->sExtensionsManager:Landroidx/camera/extensions/ExtensionsManager;

    if-eqz v1, :cond_0

    .line 390
    monitor-exit v0

    return-object v1

    :catchall_0
    move-exception p0

    goto :goto_0

    .line 393
    :cond_0
    new-instance v1, Landroidx/camera/extensions/ExtensionsManager;

    invoke-direct {v1, p0, p1}, Landroidx/camera/extensions/ExtensionsManager;-><init>(Landroidx/camera/extensions/ExtensionsManager$ExtensionsAvailability;Landroidx/camera/core/CameraProvider;)V

    sput-object v1, Landroidx/camera/extensions/ExtensionsManager;->sExtensionsManager:Landroidx/camera/extensions/ExtensionsManager;

    .line 395
    monitor-exit v0

    return-object v1

    .line 396
    :goto_0
    monitor-exit v0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw p0
.end method
