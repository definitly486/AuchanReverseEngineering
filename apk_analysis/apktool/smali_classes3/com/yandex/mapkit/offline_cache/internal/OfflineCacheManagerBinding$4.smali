.class Lcom/yandex/mapkit/offline_cache/internal/OfflineCacheManagerBinding$4;
.super Lcom/yandex/runtime/subscription/Subscription;
.source "OfflineCacheManagerBinding.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/yandex/mapkit/offline_cache/internal/OfflineCacheManagerBinding;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/yandex/runtime/subscription/Subscription<",
        "Lcom/yandex/mapkit/offline_cache/RegionListener;",
        ">;"
    }
.end annotation


# direct methods
.method constructor <init>(Lcom/yandex/mapkit/offline_cache/internal/OfflineCacheManagerBinding;)V
    .locals 0

    .line 170
    invoke-direct {p0}, Lcom/yandex/runtime/subscription/Subscription;-><init>()V

    return-void
.end method


# virtual methods
.method public createNativeListener(Lcom/yandex/mapkit/offline_cache/RegionListener;)Lcom/yandex/runtime/NativeObject;
    .locals 0

    .line 173
    invoke-static {p1}, Lcom/yandex/mapkit/offline_cache/internal/OfflineCacheManagerBinding;->-$$Nest$smcreateRegionListener(Lcom/yandex/mapkit/offline_cache/RegionListener;)Lcom/yandex/runtime/NativeObject;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic createNativeListener(Ljava/lang/Object;)Lcom/yandex/runtime/NativeObject;
    .locals 0

    .line 170
    check-cast p1, Lcom/yandex/mapkit/offline_cache/RegionListener;

    invoke-virtual {p0, p1}, Lcom/yandex/mapkit/offline_cache/internal/OfflineCacheManagerBinding$4;->createNativeListener(Lcom/yandex/mapkit/offline_cache/RegionListener;)Lcom/yandex/runtime/NativeObject;

    move-result-object p1

    return-object p1
.end method
