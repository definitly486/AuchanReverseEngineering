.class Lcom/yandex/mapkit/map/internal/BaseDataSourceBuilderBinding$1;
.super Lcom/yandex/runtime/subscription/Subscription;
.source "BaseDataSourceBuilderBinding.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/yandex/mapkit/map/internal/BaseDataSourceBuilderBinding;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/yandex/runtime/subscription/Subscription<",
        "Lcom/yandex/mapkit/images/ImageUrlProvider;",
        ">;"
    }
.end annotation


# direct methods
.method constructor <init>(Lcom/yandex/mapkit/map/internal/BaseDataSourceBuilderBinding;)V
    .locals 0

    .line 30
    invoke-direct {p0}, Lcom/yandex/runtime/subscription/Subscription;-><init>()V

    return-void
.end method


# virtual methods
.method public createNativeListener(Lcom/yandex/mapkit/images/ImageUrlProvider;)Lcom/yandex/runtime/NativeObject;
    .locals 0

    .line 33
    invoke-static {p1}, Lcom/yandex/mapkit/map/internal/BaseDataSourceBuilderBinding;->-$$Nest$smcreateImageUrlProvider(Lcom/yandex/mapkit/images/ImageUrlProvider;)Lcom/yandex/runtime/NativeObject;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic createNativeListener(Ljava/lang/Object;)Lcom/yandex/runtime/NativeObject;
    .locals 0

    .line 30
    check-cast p1, Lcom/yandex/mapkit/images/ImageUrlProvider;

    invoke-virtual {p0, p1}, Lcom/yandex/mapkit/map/internal/BaseDataSourceBuilderBinding$1;->createNativeListener(Lcom/yandex/mapkit/images/ImageUrlProvider;)Lcom/yandex/runtime/NativeObject;

    move-result-object p1

    return-object p1
.end method
