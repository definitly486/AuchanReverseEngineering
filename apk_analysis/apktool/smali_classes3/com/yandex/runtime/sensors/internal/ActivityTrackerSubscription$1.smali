.class Lcom/yandex/runtime/sensors/internal/ActivityTrackerSubscription$1;
.super Ljava/lang/Object;
.source "ActivityTrackerSubscription.java"

# interfaces
.implements Lcom/google/android/gms/tasks/OnSuccessListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/yandex/runtime/sensors/internal/ActivityTrackerSubscription;-><init>(Lcom/yandex/runtime/NativeObject;I)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# direct methods
.method constructor <init>(Lcom/yandex/runtime/sensors/internal/ActivityTrackerSubscription;)V
    .locals 0

    .line 65
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onSuccess(Ljava/lang/Object;)V
    .locals 1

    .line 68
    invoke-static {}, Lcom/yandex/runtime/sensors/internal/ActivityTrackerSubscription;->-$$Nest$sfgetTAG()Ljava/lang/String;

    move-result-object p1

    const-string v0, "ActivityTracker subscribed"

    invoke-static {p1, v0}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    return-void
.end method
