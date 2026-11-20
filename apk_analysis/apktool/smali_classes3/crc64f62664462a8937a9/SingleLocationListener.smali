.class public Lcrc64f62664462a8937a9/SingleLocationListener;
.super Ljava/lang/Object;
.source "SingleLocationListener.java"

# interfaces
.implements Lmono/android/IGCUserPeer;
.implements Landroid/location/LocationListener;


# instance fields
.field private refList:Ljava/util/ArrayList;


# direct methods
.method public constructor <init>()V
    .locals 3

    .line 13
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 14
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc64f62664462a8937a9/SingleLocationListener;

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 15
    new-array v0, v0, [Ljava/lang/Object;

    const-string v1, "Microsoft.Maui.Devices.Sensors.SingleLocationListener, Microsoft.Maui.Essentials"

    const-string v2, ""

    invoke-static {v1, v2, p0, v0}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method private native n_onFlushComplete(I)V
.end method

.method private native n_onLocationChanged(Landroid/location/Location;)V
.end method

.method private native n_onProviderDisabled(Ljava/lang/String;)V
.end method

.method private native n_onProviderEnabled(Ljava/lang/String;)V
.end method

.method private native n_onStatusChanged(Ljava/lang/String;ILandroid/os/Bundle;)V
.end method


# virtual methods
.method public monodroidAddReference(Ljava/lang/Object;)V
    .locals 1

    .line 57
    iget-object v0, p0, Lcrc64f62664462a8937a9/SingleLocationListener;->refList:Ljava/util/ArrayList;

    if-nez v0, :cond_0

    .line 58
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcrc64f62664462a8937a9/SingleLocationListener;->refList:Ljava/util/ArrayList;

    .line 59
    :cond_0
    iget-object v0, p0, Lcrc64f62664462a8937a9/SingleLocationListener;->refList:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public monodroidClearReferences()V
    .locals 1

    .line 64
    iget-object v0, p0, Lcrc64f62664462a8937a9/SingleLocationListener;->refList:Ljava/util/ArrayList;

    if-eqz v0, :cond_0

    .line 65
    invoke-virtual {v0}, Ljava/util/ArrayList;->clear()V

    :cond_0
    return-void
.end method

.method public onFlushComplete(I)V
    .locals 0

    .line 49
    invoke-direct {p0, p1}, Lcrc64f62664462a8937a9/SingleLocationListener;->n_onFlushComplete(I)V

    return-void
.end method

.method public onLocationChanged(Landroid/location/Location;)V
    .locals 0

    .line 21
    invoke-direct {p0, p1}, Lcrc64f62664462a8937a9/SingleLocationListener;->n_onLocationChanged(Landroid/location/Location;)V

    return-void
.end method

.method public onProviderDisabled(Ljava/lang/String;)V
    .locals 0

    .line 28
    invoke-direct {p0, p1}, Lcrc64f62664462a8937a9/SingleLocationListener;->n_onProviderDisabled(Ljava/lang/String;)V

    return-void
.end method

.method public onProviderEnabled(Ljava/lang/String;)V
    .locals 0

    .line 35
    invoke-direct {p0, p1}, Lcrc64f62664462a8937a9/SingleLocationListener;->n_onProviderEnabled(Ljava/lang/String;)V

    return-void
.end method

.method public onStatusChanged(Ljava/lang/String;ILandroid/os/Bundle;)V
    .locals 0

    .line 42
    invoke-direct {p0, p1, p2, p3}, Lcrc64f62664462a8937a9/SingleLocationListener;->n_onStatusChanged(Ljava/lang/String;ILandroid/os/Bundle;)V

    return-void
.end method
