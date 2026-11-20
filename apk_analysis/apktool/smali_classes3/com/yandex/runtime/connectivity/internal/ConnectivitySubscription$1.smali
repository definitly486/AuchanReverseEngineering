.class Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription$1;
.super Ljava/lang/Object;
.source "ConnectivitySubscription.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;->subscribe(Lcom/yandex/runtime/NativeObject;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;


# direct methods
.method constructor <init>(Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;)V
    .locals 0

    .line 47
    iput-object p1, p0, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription$1;->this$0:Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 4

    .line 49
    new-instance v0, Landroid/content/IntentFilter;

    invoke-direct {v0}, Landroid/content/IntentFilter;-><init>()V

    .line 50
    const-string v1, "android.os.action.DEVICE_IDLE_MODE_CHANGED"

    invoke-virtual {v0, v1}, Landroid/content/IntentFilter;->addAction(Ljava/lang/String;)V

    .line 53
    const-string v1, "android.os.action.LIGHT_DEVICE_IDLE_MODE_CHANGED"

    invoke-virtual {v0, v1}, Landroid/content/IntentFilter;->addAction(Ljava/lang/String;)V

    .line 56
    :try_start_0
    iget-object v1, p0, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription$1;->this$0:Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;

    invoke-static {v1}, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;->-$$Nest$mgetNetworkCallback(Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;)Landroid/net/ConnectivityManager$NetworkCallback;

    move-result-object v2

    invoke-static {v1, v2}, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;->-$$Nest$fputnetworkCallback(Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;Landroid/net/ConnectivityManager$NetworkCallback;)V

    .line 57
    iget-object v1, p0, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription$1;->this$0:Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;

    invoke-static {v1}, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;->-$$Nest$fgetconnectivityManager(Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;)Landroid/net/ConnectivityManager;

    move-result-object v1

    iget-object v2, p0, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription$1;->this$0:Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;

    invoke-static {v2}, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;->-$$Nest$fgetnetworkCallback(Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;)Landroid/net/ConnectivityManager$NetworkCallback;

    move-result-object v2

    invoke-virtual {v1, v2}, Landroid/net/ConnectivityManager;->registerDefaultNetworkCallback(Landroid/net/ConnectivityManager$NetworkCallback;)V

    .line 60
    invoke-static {}, Lcom/yandex/runtime/Runtime;->getApplicationContext()Landroid/content/Context;

    move-result-object v1

    iget-object v2, p0, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription$1;->this$0:Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;

    const/4 v3, 0x4

    invoke-virtual {v1, v2, v0, v3}, Landroid/content/Context;->registerReceiver(Landroid/content/BroadcastReceiver;Landroid/content/IntentFilter;I)Landroid/content/Intent;

    .line 64
    iget-object v0, p0, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription$1;->this$0:Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;

    const/4 v1, 0x1

    invoke-static {v0, v1}, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;->-$$Nest$fputisRegistered(Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;Z)V

    .line 66
    iget-object v0, p0, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription$1;->this$0:Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;

    invoke-virtual {v0}, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;->status()Lcom/yandex/runtime/connectivity/ConnectivityStatus;

    move-result-object v1

    invoke-static {v0, v1}, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;->-$$Nest$mupdate(Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;Lcom/yandex/runtime/connectivity/ConnectivityStatus;)V
    :try_end_0
    .catch Ljava/lang/SecurityException; {:try_start_0 .. :try_end_0} :catch_0

    return-void

    :catch_0
    move-exception v0

    .line 68
    invoke-static {}, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;->-$$Nest$sfgetTAG()Ljava/lang/String;

    move-result-object v1

    const-string v2, "Cannot register receiver"

    invoke-static {v1, v2, v0}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Throwable;)I

    return-void
.end method
