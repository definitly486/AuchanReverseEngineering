.class Lcom/yandex/mapkit/map/internal/MapObjectBinding$1;
.super Lcom/yandex/runtime/subscription/Subscription;
.source "MapObjectBinding.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/yandex/mapkit/map/internal/MapObjectBinding;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/yandex/runtime/subscription/Subscription<",
        "Lcom/yandex/mapkit/map/MapObjectDragListener;",
        ">;"
    }
.end annotation


# direct methods
.method constructor <init>(Lcom/yandex/mapkit/map/internal/MapObjectBinding;)V
    .locals 0

    .line 77
    invoke-direct {p0}, Lcom/yandex/runtime/subscription/Subscription;-><init>()V

    return-void
.end method


# virtual methods
.method public createNativeListener(Lcom/yandex/mapkit/map/MapObjectDragListener;)Lcom/yandex/runtime/NativeObject;
    .locals 0

    .line 80
    invoke-static {p1}, Lcom/yandex/mapkit/map/internal/MapObjectBinding;->-$$Nest$smcreateMapObjectDragListener(Lcom/yandex/mapkit/map/MapObjectDragListener;)Lcom/yandex/runtime/NativeObject;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic createNativeListener(Ljava/lang/Object;)Lcom/yandex/runtime/NativeObject;
    .locals 0

    .line 77
    check-cast p1, Lcom/yandex/mapkit/map/MapObjectDragListener;

    invoke-virtual {p0, p1}, Lcom/yandex/mapkit/map/internal/MapObjectBinding$1;->createNativeListener(Lcom/yandex/mapkit/map/MapObjectDragListener;)Lcom/yandex/runtime/NativeObject;

    move-result-object p1

    return-object p1
.end method
