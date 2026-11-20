.class Lcom/yandex/mapkit/layers/internal/DataSourceLayerBinding$2;
.super Lcom/yandex/runtime/subscription/Subscription;
.source "DataSourceLayerBinding.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/yandex/mapkit/layers/internal/DataSourceLayerBinding;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/yandex/runtime/subscription/Subscription<",
        "Lcom/yandex/mapkit/layers/LayerLoadedListener;",
        ">;"
    }
.end annotation


# direct methods
.method constructor <init>(Lcom/yandex/mapkit/layers/internal/DataSourceLayerBinding;)V
    .locals 0

    .line 62
    invoke-direct {p0}, Lcom/yandex/runtime/subscription/Subscription;-><init>()V

    return-void
.end method


# virtual methods
.method public createNativeListener(Lcom/yandex/mapkit/layers/LayerLoadedListener;)Lcom/yandex/runtime/NativeObject;
    .locals 0

    .line 65
    invoke-static {p1}, Lcom/yandex/mapkit/layers/internal/DataSourceLayerBinding;->-$$Nest$smcreateLayerLoadedListener(Lcom/yandex/mapkit/layers/LayerLoadedListener;)Lcom/yandex/runtime/NativeObject;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic createNativeListener(Ljava/lang/Object;)Lcom/yandex/runtime/NativeObject;
    .locals 0

    .line 62
    check-cast p1, Lcom/yandex/mapkit/layers/LayerLoadedListener;

    invoke-virtual {p0, p1}, Lcom/yandex/mapkit/layers/internal/DataSourceLayerBinding$2;->createNativeListener(Lcom/yandex/mapkit/layers/LayerLoadedListener;)Lcom/yandex/runtime/NativeObject;

    move-result-object p1

    return-object p1
.end method
