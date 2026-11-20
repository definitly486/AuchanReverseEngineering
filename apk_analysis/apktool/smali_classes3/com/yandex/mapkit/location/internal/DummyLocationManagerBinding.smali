.class public Lcom/yandex/mapkit/location/internal/DummyLocationManagerBinding;
.super Lcom/yandex/mapkit/location/internal/LocationManagerBinding;
.source "DummyLocationManagerBinding.java"

# interfaces
.implements Lcom/yandex/mapkit/location/DummyLocationManager;


# direct methods
.method protected constructor <init>(Lcom/yandex/runtime/NativeObject;)V
    .locals 0

    .line 17
    invoke-direct {p0, p1}, Lcom/yandex/mapkit/location/internal/LocationManagerBinding;-><init>(Lcom/yandex/runtime/NativeObject;)V

    return-void
.end method


# virtual methods
.method public native setLocation(Lcom/yandex/mapkit/location/Location;Lcom/yandex/mapkit/location/DummyLocationQuality;)V
.end method
