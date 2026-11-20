.class Lcom/yandex/mapkit/location/internal/LocationSimulatorBinding$1;
.super Lcom/yandex/runtime/subscription/Subscription;
.source "LocationSimulatorBinding.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/yandex/mapkit/location/internal/LocationSimulatorBinding;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/yandex/runtime/subscription/Subscription<",
        "Lcom/yandex/mapkit/location/LocationSimulatorListener;",
        ">;"
    }
.end annotation


# direct methods
.method constructor <init>(Lcom/yandex/mapkit/location/internal/LocationSimulatorBinding;)V
    .locals 0

    .line 56
    invoke-direct {p0}, Lcom/yandex/runtime/subscription/Subscription;-><init>()V

    return-void
.end method


# virtual methods
.method public createNativeListener(Lcom/yandex/mapkit/location/LocationSimulatorListener;)Lcom/yandex/runtime/NativeObject;
    .locals 0

    .line 59
    invoke-static {p1}, Lcom/yandex/mapkit/location/internal/LocationSimulatorBinding;->-$$Nest$smcreateLocationSimulatorListener(Lcom/yandex/mapkit/location/LocationSimulatorListener;)Lcom/yandex/runtime/NativeObject;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic createNativeListener(Ljava/lang/Object;)Lcom/yandex/runtime/NativeObject;
    .locals 0

    .line 56
    check-cast p1, Lcom/yandex/mapkit/location/LocationSimulatorListener;

    invoke-virtual {p0, p1}, Lcom/yandex/mapkit/location/internal/LocationSimulatorBinding$1;->createNativeListener(Lcom/yandex/mapkit/location/LocationSimulatorListener;)Lcom/yandex/runtime/NativeObject;

    move-result-object p1

    return-object p1
.end method
