.class Lcom/yandex/mapkit/user_location/internal/UserLocationLayerBinding$1;
.super Lcom/yandex/runtime/subscription/Subscription;
.source "UserLocationLayerBinding.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/yandex/mapkit/user_location/internal/UserLocationLayerBinding;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/yandex/runtime/subscription/Subscription<",
        "Lcom/yandex/mapkit/user_location/UserLocationObjectListener;",
        ">;"
    }
.end annotation


# direct methods
.method constructor <init>(Lcom/yandex/mapkit/user_location/internal/UserLocationLayerBinding;)V
    .locals 0

    .line 76
    invoke-direct {p0}, Lcom/yandex/runtime/subscription/Subscription;-><init>()V

    return-void
.end method


# virtual methods
.method public createNativeListener(Lcom/yandex/mapkit/user_location/UserLocationObjectListener;)Lcom/yandex/runtime/NativeObject;
    .locals 0

    .line 79
    invoke-static {p1}, Lcom/yandex/mapkit/user_location/internal/UserLocationLayerBinding;->-$$Nest$smcreateUserLocationObjectListener(Lcom/yandex/mapkit/user_location/UserLocationObjectListener;)Lcom/yandex/runtime/NativeObject;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic createNativeListener(Ljava/lang/Object;)Lcom/yandex/runtime/NativeObject;
    .locals 0

    .line 76
    check-cast p1, Lcom/yandex/mapkit/user_location/UserLocationObjectListener;

    invoke-virtual {p0, p1}, Lcom/yandex/mapkit/user_location/internal/UserLocationLayerBinding$1;->createNativeListener(Lcom/yandex/mapkit/user_location/UserLocationObjectListener;)Lcom/yandex/runtime/NativeObject;

    move-result-object p1

    return-object p1
.end method
