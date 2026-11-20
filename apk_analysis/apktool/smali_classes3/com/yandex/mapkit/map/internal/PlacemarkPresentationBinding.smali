.class public Lcom/yandex/mapkit/map/internal/PlacemarkPresentationBinding;
.super Ljava/lang/Object;
.source "PlacemarkPresentationBinding.java"

# interfaces
.implements Lcom/yandex/mapkit/map/PlacemarkPresentation;


# instance fields
.field private final nativeObject:Lcom/yandex/runtime/NativeObject;


# direct methods
.method protected constructor <init>(Lcom/yandex/runtime/NativeObject;)V
    .locals 0

    .line 16
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 17
    iput-object p1, p0, Lcom/yandex/mapkit/map/internal/PlacemarkPresentationBinding;->nativeObject:Lcom/yandex/runtime/NativeObject;

    return-void
.end method


# virtual methods
.method public native isValid()Z
.end method

.method public native remove()V
.end method
