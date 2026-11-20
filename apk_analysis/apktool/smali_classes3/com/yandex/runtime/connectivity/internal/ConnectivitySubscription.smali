.class public Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;
.super Landroid/content/BroadcastReceiver;
.source "ConnectivitySubscription.java"


# static fields
.field public static final ACTION_CONNECTIVITY_CHANGED:Ljava/lang/String; = "com.yandex.runtime.internal.CONNECTIVITY_CHANGED"

.field private static final ACTION_LIGHT_DEVICE_IDLE_MODE_CHANGED:Ljava/lang/String; = "android.os.action.LIGHT_DEVICE_IDLE_MODE_CHANGED"

.field private static final TAG:Ljava/lang/String; = "com.yandex.runtime.connectivity.internal.ConnectivitySubscription"


# instance fields
.field private connectivityManager:Landroid/net/ConnectivityManager;

.field private isRegistered:Z

.field private jobScheduler:Ljava/lang/Object;

.field private nativePromise:Lcom/yandex/runtime/NativeObject;

.field private networkCallback:Landroid/net/ConnectivityManager$NetworkCallback;


# direct methods
.method static bridge synthetic -$$Nest$fgetconnectivityManager(Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;)Landroid/net/ConnectivityManager;
    .locals 0

    .line 0
    iget-object p0, p0, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;->connectivityManager:Landroid/net/ConnectivityManager;

    return-object p0
.end method

.method static bridge synthetic -$$Nest$fgetisRegistered(Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;)Z
    .locals 0

    .line 0
    iget-boolean p0, p0, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;->isRegistered:Z

    return p0
.end method

.method static bridge synthetic -$$Nest$fgetnetworkCallback(Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;)Landroid/net/ConnectivityManager$NetworkCallback;
    .locals 0

    .line 0
    iget-object p0, p0, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;->networkCallback:Landroid/net/ConnectivityManager$NetworkCallback;

    return-object p0
.end method

.method static bridge synthetic -$$Nest$fputisRegistered(Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;Z)V
    .locals 0

    .line 0
    iput-boolean p1, p0, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;->isRegistered:Z

    return-void
.end method

.method static bridge synthetic -$$Nest$fputnetworkCallback(Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;Landroid/net/ConnectivityManager$NetworkCallback;)V
    .locals 0

    .line 0
    iput-object p1, p0, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;->networkCallback:Landroid/net/ConnectivityManager$NetworkCallback;

    return-void
.end method

.method static bridge synthetic -$$Nest$mgetNetworkCallback(Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;)Landroid/net/ConnectivityManager$NetworkCallback;
    .locals 0

    .line 0
    invoke-direct {p0}, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;->getNetworkCallback()Landroid/net/ConnectivityManager$NetworkCallback;

    move-result-object p0

    return-object p0
.end method

.method static bridge synthetic -$$Nest$mstatus(Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;Landroid/net/NetworkCapabilities;)Lcom/yandex/runtime/connectivity/ConnectivityStatus;
    .locals 0

    .line 0
    invoke-direct {p0, p1}, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;->status(Landroid/net/NetworkCapabilities;)Lcom/yandex/runtime/connectivity/ConnectivityStatus;

    move-result-object p0

    return-object p0
.end method

.method static bridge synthetic -$$Nest$mupdate(Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;Lcom/yandex/runtime/connectivity/ConnectivityStatus;)V
    .locals 0

    .line 0
    invoke-direct {p0, p1}, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;->update(Lcom/yandex/runtime/connectivity/ConnectivityStatus;)V

    return-void
.end method

.method static bridge synthetic -$$Nest$sfgetTAG()Ljava/lang/String;
    .locals 1

    .line 0
    sget-object v0, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;->TAG:Ljava/lang/String;

    return-object v0
.end method

.method static constructor <clinit>()V
    .locals 0

    .line 0
    return-void
.end method

.method public constructor <init>()V
    .locals 2

    .line 37
    invoke-direct {p0}, Landroid/content/BroadcastReceiver;-><init>()V

    const/4 v0, 0x0

    .line 183
    iput-boolean v0, p0, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;->isRegistered:Z

    .line 39
    invoke-static {}, Lcom/yandex/runtime/Runtime;->getApplicationContext()Landroid/content/Context;

    move-result-object v0

    const-string v1, "connectivity"

    invoke-virtual {v0, v1}, Landroid/content/Context;->getSystemService(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/net/ConnectivityManager;

    iput-object v0, p0, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;->connectivityManager:Landroid/net/ConnectivityManager;

    .line 41
    invoke-static {}, Lcom/yandex/runtime/Runtime;->getApplicationContext()Landroid/content/Context;

    move-result-object v0

    const-string v1, "jobscheduler"

    invoke-virtual {v0, v1}, Landroid/content/Context;->getSystemService(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v0

    iput-object v0, p0, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;->jobScheduler:Ljava/lang/Object;

    return-void
.end method

.method private getNetworkCallback()Landroid/net/ConnectivityManager$NetworkCallback;
    .locals 1

    .line 156
    new-instance v0, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription$3;

    invoke-direct {v0, p0}, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription$3;-><init>(Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;)V

    return-object v0
.end method

.method private status(Landroid/net/NetworkCapabilities;)Lcom/yandex/runtime/connectivity/ConnectivityStatus;
    .locals 1

    if-eqz p1, :cond_3

    const/16 v0, 0xc

    .line 104
    invoke-virtual {p1, v0}, Landroid/net/NetworkCapabilities;->hasCapability(I)Z

    move-result v0

    if-eqz v0, :cond_3

    const/16 v0, 0x10

    .line 105
    invoke-virtual {p1, v0}, Landroid/net/NetworkCapabilities;->hasCapability(I)Z

    move-result v0

    if-nez v0, :cond_0

    goto :goto_1

    :cond_0
    const/4 v0, 0x0

    .line 108
    invoke-virtual {p1, v0}, Landroid/net/NetworkCapabilities;->hasTransport(I)Z

    move-result v0

    if-nez v0, :cond_2

    const/4 v0, 0x2

    .line 109
    invoke-virtual {p1, v0}, Landroid/net/NetworkCapabilities;->hasTransport(I)Z

    move-result p1

    if-eqz p1, :cond_1

    goto :goto_0

    .line 112
    :cond_1
    sget-object p1, Lcom/yandex/runtime/connectivity/ConnectivityStatus;->BROADBAND:Lcom/yandex/runtime/connectivity/ConnectivityStatus;

    return-object p1

    .line 110
    :cond_2
    :goto_0
    sget-object p1, Lcom/yandex/runtime/connectivity/ConnectivityStatus;->CELLULAR:Lcom/yandex/runtime/connectivity/ConnectivityStatus;

    return-object p1

    .line 106
    :cond_3
    :goto_1
    sget-object p1, Lcom/yandex/runtime/connectivity/ConnectivityStatus;->NONE:Lcom/yandex/runtime/connectivity/ConnectivityStatus;

    return-object p1
.end method

.method static native submit(Lcom/yandex/runtime/NativeObject;Lcom/yandex/runtime/connectivity/ConnectivityStatus;)V
.end method

.method private update(Lcom/yandex/runtime/connectivity/ConnectivityStatus;)V
    .locals 3

    .line 149
    :try_start_0
    iget-object v0, p0, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;->nativePromise:Lcom/yandex/runtime/NativeObject;

    invoke-static {v0, p1}, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;->submit(Lcom/yandex/runtime/NativeObject;Lcom/yandex/runtime/connectivity/ConnectivityStatus;)V
    :try_end_0
    .catch Ljava/lang/UnsatisfiedLinkError; {:try_start_0 .. :try_end_0} :catch_0

    return-void

    :catch_0
    move-exception p1

    .line 151
    sget-object v0, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;->TAG:Ljava/lang/String;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Native libraries not loaded: "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p1}, Ljava/lang/Throwable;->getMessage()Ljava/lang/String;

    move-result-object p1

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-static {v0, p1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    return-void
.end method


# virtual methods
.method public onReceive(Landroid/content/Context;Landroid/content/Intent;)V
    .locals 2

    .line 121
    invoke-virtual {p2}, Landroid/content/Intent;->getAction()Ljava/lang/String;

    move-result-object p1

    .line 122
    invoke-virtual {p0}, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;->status()Lcom/yandex/runtime/connectivity/ConnectivityStatus;

    move-result-object p2

    .line 124
    invoke-direct {p0, p2}, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;->update(Lcom/yandex/runtime/connectivity/ConnectivityStatus;)V

    .line 127
    const-string v0, "android.os.action.LIGHT_DEVICE_IDLE_MODE_CHANGED"

    if-eq p1, v0, :cond_0

    const-string v0, "android.os.action.DEVICE_IDLE_MODE_CHANGED"

    if-ne p1, v0, :cond_1

    :cond_0
    sget-object p1, Lcom/yandex/runtime/connectivity/ConnectivityStatus;->NONE:Lcom/yandex/runtime/connectivity/ConnectivityStatus;

    if-ne p2, p1, :cond_1

    .line 131
    :try_start_0
    new-instance p1, Landroid/app/job/JobInfo$Builder;

    new-instance p2, Landroid/content/ComponentName;

    .line 133
    invoke-static {}, Lcom/yandex/runtime/Runtime;->getApplicationContext()Landroid/content/Context;

    move-result-object v0

    const-class v1, Lcom/yandex/runtime/connectivity/internal/ConnectivityService;

    invoke-direct {p2, v0, v1}, Landroid/content/ComponentName;-><init>(Landroid/content/Context;Ljava/lang/Class;)V

    const/16 v0, 0x1009

    invoke-direct {p1, v0, p2}, Landroid/app/job/JobInfo$Builder;-><init>(ILandroid/content/ComponentName;)V

    const/4 p2, 0x1

    .line 134
    invoke-virtual {p1, p2}, Landroid/app/job/JobInfo$Builder;->setRequiredNetworkType(I)Landroid/app/job/JobInfo$Builder;

    move-result-object p1

    .line 135
    invoke-virtual {p1}, Landroid/app/job/JobInfo$Builder;->build()Landroid/app/job/JobInfo;

    move-result-object p1

    .line 136
    iget-object p2, p0, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;->jobScheduler:Ljava/lang/Object;

    check-cast p2, Landroid/app/job/JobScheduler;

    invoke-virtual {p2, p1}, Landroid/app/job/JobScheduler;->schedule(Landroid/app/job/JobInfo;)I
    :try_end_0
    .catch Ljava/lang/IllegalArgumentException; {:try_start_0 .. :try_end_0} :catch_0

    return-void

    :catch_0
    move-exception p1

    .line 138
    sget-object p2, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;->TAG:Ljava/lang/String;

    const-string v0, "Failed to schedule job"

    invoke-static {p2, v0, p1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Throwable;)I

    :cond_1
    return-void
.end method

.method public status()Lcom/yandex/runtime/connectivity/ConnectivityStatus;
    .locals 2

    .line 94
    iget-object v0, p0, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;->connectivityManager:Landroid/net/ConnectivityManager;

    invoke-virtual {v0}, Landroid/net/ConnectivityManager;->getActiveNetwork()Landroid/net/Network;

    move-result-object v0

    if-nez v0, :cond_0

    .line 96
    sget-object v0, Lcom/yandex/runtime/connectivity/ConnectivityStatus;->NONE:Lcom/yandex/runtime/connectivity/ConnectivityStatus;

    return-object v0

    .line 98
    :cond_0
    iget-object v1, p0, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;->connectivityManager:Landroid/net/ConnectivityManager;

    invoke-virtual {v1, v0}, Landroid/net/ConnectivityManager;->getNetworkCapabilities(Landroid/net/Network;)Landroid/net/NetworkCapabilities;

    move-result-object v0

    .line 99
    invoke-direct {p0, v0}, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;->status(Landroid/net/NetworkCapabilities;)Lcom/yandex/runtime/connectivity/ConnectivityStatus;

    move-result-object v0

    return-object v0
.end method

.method public subscribe(Lcom/yandex/runtime/NativeObject;)V
    .locals 1

    .line 45
    iput-object p1, p0, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;->nativePromise:Lcom/yandex/runtime/NativeObject;

    .line 46
    new-instance p1, Landroid/os/Handler;

    invoke-static {}, Landroid/os/Looper;->getMainLooper()Landroid/os/Looper;

    move-result-object v0

    invoke-direct {p1, v0}, Landroid/os/Handler;-><init>(Landroid/os/Looper;)V

    .line 47
    new-instance v0, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription$1;

    invoke-direct {v0, p0}, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription$1;-><init>(Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;)V

    invoke-virtual {p1, v0}, Landroid/os/Handler;->post(Ljava/lang/Runnable;)Z

    return-void
.end method

.method public unsubscribe()V
    .locals 2

    .line 75
    new-instance v0, Landroid/os/Handler;

    invoke-static {}, Landroid/os/Looper;->getMainLooper()Landroid/os/Looper;

    move-result-object v1

    invoke-direct {v0, v1}, Landroid/os/Handler;-><init>(Landroid/os/Looper;)V

    .line 76
    new-instance v1, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription$2;

    invoke-direct {v1, p0}, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription$2;-><init>(Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;)V

    invoke-virtual {v0, v1}, Landroid/os/Handler;->post(Ljava/lang/Runnable;)Z

    return-void
.end method
