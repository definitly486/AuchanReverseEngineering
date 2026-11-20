.class public Lcom/yandex/mapkit/map/internal/PlacemarkAnimationBinding;
.super Lcom/yandex/mapkit/map/internal/PlacemarkPresentationBinding;
.source "PlacemarkAnimationBinding.java"

# interfaces
.implements Lcom/yandex/mapkit/map/PlacemarkAnimation;


# direct methods
.method protected constructor <init>(Lcom/yandex/runtime/NativeObject;)V
    .locals 0

    .line 18
    invoke-direct {p0, p1}, Lcom/yandex/mapkit/map/internal/PlacemarkPresentationBinding;-><init>(Lcom/yandex/runtime/NativeObject;)V

    return-void
.end method


# virtual methods
.method public native isReversed()Z
.end method

.method public native pause()V
.end method

.method public native play()V
.end method

.method public native play(Lcom/yandex/mapkit/map/Callback;)V
.end method

.method public native resume()V
.end method

.method public native setIcon(Lcom/yandex/runtime/image/AnimatedImageProvider;Lcom/yandex/mapkit/map/IconStyle;)V
.end method

.method public native setIcon(Lcom/yandex/runtime/image/AnimatedImageProvider;Lcom/yandex/mapkit/map/IconStyle;Lcom/yandex/mapkit/map/Callback;)V
.end method

.method public native setIconStyle(Lcom/yandex/mapkit/map/IconStyle;)V
.end method

.method public native setReversed(Z)V
.end method

.method public native stop()V
.end method
