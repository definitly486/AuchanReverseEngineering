.class public Lcrc64e53d2f592022988e/ConnectivityImplementation_EssentialsNetworkCallback;
.super Landroid/net/ConnectivityManager$NetworkCallback;
.source "ConnectivityImplementation_EssentialsNetworkCallback.java"

# interfaces
.implements Lmono/android/IGCUserPeer;


# instance fields
.field private refList:Ljava/util/ArrayList;


# direct methods
.method public constructor <init>()V
    .locals 3

    .line 12
    invoke-direct {p0}, Landroid/net/ConnectivityManager$NetworkCallback;-><init>()V

    .line 13
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc64e53d2f592022988e/ConnectivityImplementation_EssentialsNetworkCallback;

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 14
    new-array v0, v0, [Ljava/lang/Object;

    const-string v1, "Microsoft.Maui.Networking.ConnectivityImplementation+EssentialsNetworkCallback, Microsoft.Maui.Essentials"

    const-string v2, ""

    invoke-static {v1, v2, p0, v0}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method private native n_onAvailable(Landroid/net/Network;)V
.end method

.method private native n_onCapabilitiesChanged(Landroid/net/Network;Landroid/net/NetworkCapabilities;)V
.end method

.method private native n_onLinkPropertiesChanged(Landroid/net/Network;Landroid/net/LinkProperties;)V
.end method

.method private native n_onLosing(Landroid/net/Network;I)V
.end method

.method private native n_onLost(Landroid/net/Network;)V
.end method

.method private native n_onUnavailable()V
.end method


# virtual methods
.method public monodroidAddReference(Ljava/lang/Object;)V
    .locals 1

    .line 63
    iget-object v0, p0, Lcrc64e53d2f592022988e/ConnectivityImplementation_EssentialsNetworkCallback;->refList:Ljava/util/ArrayList;

    if-nez v0, :cond_0

    .line 64
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcrc64e53d2f592022988e/ConnectivityImplementation_EssentialsNetworkCallback;->refList:Ljava/util/ArrayList;

    .line 65
    :cond_0
    iget-object v0, p0, Lcrc64e53d2f592022988e/ConnectivityImplementation_EssentialsNetworkCallback;->refList:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public monodroidClearReferences()V
    .locals 1

    .line 70
    iget-object v0, p0, Lcrc64e53d2f592022988e/ConnectivityImplementation_EssentialsNetworkCallback;->refList:Ljava/util/ArrayList;

    if-eqz v0, :cond_0

    .line 71
    invoke-virtual {v0}, Ljava/util/ArrayList;->clear()V

    :cond_0
    return-void
.end method

.method public onAvailable(Landroid/net/Network;)V
    .locals 0

    .line 20
    invoke-direct {p0, p1}, Lcrc64e53d2f592022988e/ConnectivityImplementation_EssentialsNetworkCallback;->n_onAvailable(Landroid/net/Network;)V

    return-void
.end method

.method public onCapabilitiesChanged(Landroid/net/Network;Landroid/net/NetworkCapabilities;)V
    .locals 0

    .line 34
    invoke-direct {p0, p1, p2}, Lcrc64e53d2f592022988e/ConnectivityImplementation_EssentialsNetworkCallback;->n_onCapabilitiesChanged(Landroid/net/Network;Landroid/net/NetworkCapabilities;)V

    return-void
.end method

.method public onLinkPropertiesChanged(Landroid/net/Network;Landroid/net/LinkProperties;)V
    .locals 0

    .line 48
    invoke-direct {p0, p1, p2}, Lcrc64e53d2f592022988e/ConnectivityImplementation_EssentialsNetworkCallback;->n_onLinkPropertiesChanged(Landroid/net/Network;Landroid/net/LinkProperties;)V

    return-void
.end method

.method public onLosing(Landroid/net/Network;I)V
    .locals 0

    .line 55
    invoke-direct {p0, p1, p2}, Lcrc64e53d2f592022988e/ConnectivityImplementation_EssentialsNetworkCallback;->n_onLosing(Landroid/net/Network;I)V

    return-void
.end method

.method public onLost(Landroid/net/Network;)V
    .locals 0

    .line 27
    invoke-direct {p0, p1}, Lcrc64e53d2f592022988e/ConnectivityImplementation_EssentialsNetworkCallback;->n_onLost(Landroid/net/Network;)V

    return-void
.end method

.method public onUnavailable()V
    .locals 0

    .line 41
    invoke-direct {p0}, Lcrc64e53d2f592022988e/ConnectivityImplementation_EssentialsNetworkCallback;->n_onUnavailable()V

    return-void
.end method
