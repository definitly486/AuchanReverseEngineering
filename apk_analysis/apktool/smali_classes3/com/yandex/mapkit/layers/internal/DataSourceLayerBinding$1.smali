.class Lcom/yandex/mapkit/layers/internal/DataSourceLayerBinding$1;
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
        "Lcom/yandex/mapkit/layers/DataSourceListener;",
        ">;"
    }
.end annotation


# direct methods
.method constructor <init>(Lcom/yandex/mapkit/layers/internal/DataSourceLayerBinding;)V
    .locals 0

    .line 54
    invoke-direct {p0}, Lcom/yandex/runtime/subscription/Subscription;-><init>()V

    return-void
.end method


# virtual methods
.method public createNativeListener(Lcom/yandex/mapkit/layers/DataSourceListener;)Lcom/yandex/runtime/NativeObject;
    .locals 0

    .line 57
    invoke-static {p1}, Lcom/yandex/mapkit/layers/internal/DataSourceLayerBinding;->-$$Nest$smcreateDataSourceListener(Lcom/yandex/mapkit/layers/DataSourceListener;)Lcom/yandex/runtime/NativeObject;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic createNativeListener(Ljava/lang/Object;)Lcom/yandex/runtime/NativeObject;
    .locals 0

    .line 54
    check-cast p1, Lcom/yandex/mapkit/layers/DataSourceListener;

    invoke-virtual {p0, p1}, Lcom/yandex/mapkit/layers/internal/DataSourceLayerBinding$1;->createNativeListener(Lcom/yandex/mapkit/layers/DataSourceListener;)Lcom/yandex/runtime/NativeObject;

    move-result-object p1

    return-object p1
.end method
