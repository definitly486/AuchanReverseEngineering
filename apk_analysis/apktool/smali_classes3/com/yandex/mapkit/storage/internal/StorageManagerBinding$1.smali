.class Lcom/yandex/mapkit/storage/internal/StorageManagerBinding$1;
.super Lcom/yandex/runtime/subscription/Subscription;
.source "StorageManagerBinding.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/yandex/mapkit/storage/internal/StorageManagerBinding;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/yandex/runtime/subscription/Subscription<",
        "Lcom/yandex/mapkit/storage/StorageErrorListener;",
        ">;"
    }
.end annotation


# direct methods
.method constructor <init>(Lcom/yandex/mapkit/storage/internal/StorageManagerBinding;)V
    .locals 0

    .line 57
    invoke-direct {p0}, Lcom/yandex/runtime/subscription/Subscription;-><init>()V

    return-void
.end method


# virtual methods
.method public createNativeListener(Lcom/yandex/mapkit/storage/StorageErrorListener;)Lcom/yandex/runtime/NativeObject;
    .locals 0

    .line 60
    invoke-static {p1}, Lcom/yandex/mapkit/storage/internal/StorageManagerBinding;->-$$Nest$smcreateStorageErrorListener(Lcom/yandex/mapkit/storage/StorageErrorListener;)Lcom/yandex/runtime/NativeObject;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic createNativeListener(Ljava/lang/Object;)Lcom/yandex/runtime/NativeObject;
    .locals 0

    .line 57
    check-cast p1, Lcom/yandex/mapkit/storage/StorageErrorListener;

    invoke-virtual {p0, p1}, Lcom/yandex/mapkit/storage/internal/StorageManagerBinding$1;->createNativeListener(Lcom/yandex/mapkit/storage/StorageErrorListener;)Lcom/yandex/runtime/NativeObject;

    move-result-object p1

    return-object p1
.end method
