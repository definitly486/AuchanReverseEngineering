.class Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription$2;
.super Ljava/lang/Object;
.source "ConnectivitySubscription.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;->unsubscribe()V
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

    .line 76
    iput-object p1, p0, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription$2;->this$0:Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 2

    .line 78
    iget-object v0, p0, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription$2;->this$0:Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;

    invoke-static {v0}, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;->-$$Nest$fgetisRegistered(Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;)Z

    move-result v0

    if-nez v0, :cond_0

    return-void

    .line 81
    :cond_0
    invoke-static {}, Lcom/yandex/runtime/Runtime;->getApplicationContext()Landroid/content/Context;

    move-result-object v0

    iget-object v1, p0, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription$2;->this$0:Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;

    invoke-virtual {v0, v1}, Landroid/content/Context;->unregisterReceiver(Landroid/content/BroadcastReceiver;)V

    .line 82
    iget-object v0, p0, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription$2;->this$0:Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;

    invoke-static {v0}, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;->-$$Nest$fgetnetworkCallback(Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;)Landroid/net/ConnectivityManager$NetworkCallback;

    move-result-object v0

    if-eqz v0, :cond_1

    .line 83
    iget-object v0, p0, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription$2;->this$0:Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;

    invoke-static {v0}, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;->-$$Nest$fgetconnectivityManager(Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;)Landroid/net/ConnectivityManager;

    move-result-object v0

    iget-object v1, p0, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription$2;->this$0:Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;

    invoke-static {v1}, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;->-$$Nest$fgetnetworkCallback(Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;)Landroid/net/ConnectivityManager$NetworkCallback;

    move-result-object v1

    invoke-virtual {v0, v1}, Landroid/net/ConnectivityManager;->unregisterNetworkCallback(Landroid/net/ConnectivityManager$NetworkCallback;)V

    .line 84
    iget-object v0, p0, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription$2;->this$0:Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;

    const/4 v1, 0x0

    invoke-static {v0, v1}, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;->-$$Nest$fputnetworkCallback(Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;Landroid/net/ConnectivityManager$NetworkCallback;)V

    .line 86
    :cond_1
    iget-object v0, p0, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription$2;->this$0:Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;

    const/4 v1, 0x0

    invoke-static {v0, v1}, Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;->-$$Nest$fputisRegistered(Lcom/yandex/runtime/connectivity/internal/ConnectivitySubscription;Z)V

    return-void
.end method
