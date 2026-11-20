.class public final Landroidx/room/RoomTrackingLiveData$observer$1;
.super Landroidx/room/InvalidationTracker$Observer;
.source "RoomTrackingLiveData.android.kt"


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Landroidx/room/RoomTrackingLiveData;-><init>(Landroidx/room/RoomDatabase;Landroidx/room/InvalidationLiveDataContainer;Z[Ljava/lang/String;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Landroidx/room/RoomTrackingLiveData;


# direct methods
.method public static synthetic $r8$lambda$H8uQITgMdSlqjFkErMWBfiLHY1g(Landroidx/room/RoomTrackingLiveData;)V
    .locals 0

    .line 0
    invoke-static {p0}, Landroidx/room/RoomTrackingLiveData$observer$1;->onInvalidated$lambda$0(Landroidx/room/RoomTrackingLiveData;)V

    return-void
.end method

.method constructor <init>([Ljava/lang/String;Landroidx/room/RoomTrackingLiveData;)V
    .locals 0

    iput-object p2, p0, Landroidx/room/RoomTrackingLiveData$observer$1;->this$0:Landroidx/room/RoomTrackingLiveData;

    .line 47
    invoke-direct {p0, p1}, Landroidx/room/InvalidationTracker$Observer;-><init>([Ljava/lang/String;)V

    return-void
.end method

.method private static final onInvalidated$lambda$0(Landroidx/room/RoomTrackingLiveData;)V
    .locals 0

    .line 49
    invoke-static {p0}, Landroidx/room/RoomTrackingLiveData;->access$invalidated(Landroidx/room/RoomTrackingLiveData;)V

    return-void
.end method


# virtual methods
.method public onInvalidated(Ljava/util/Set;)V
    .locals 2

    const-string v0, "tables"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 49
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/arch/core/executor/ArchTaskExecutor;->getInstance()Lcom/scanflow/datacapture/barinternal/androidx/arch/core/executor/ArchTaskExecutor;

    move-result-object p1

    iget-object v0, p0, Landroidx/room/RoomTrackingLiveData$observer$1;->this$0:Landroidx/room/RoomTrackingLiveData;

    new-instance v1, Landroidx/room/RoomTrackingLiveData$observer$1$$ExternalSyntheticLambda0;

    invoke-direct {v1, v0}, Landroidx/room/RoomTrackingLiveData$observer$1$$ExternalSyntheticLambda0;-><init>(Landroidx/room/RoomTrackingLiveData;)V

    invoke-virtual {p1, v1}, Lcom/scanflow/datacapture/barinternal/androidx/arch/core/executor/TaskExecutor;->executeOnMainThread(Ljava/lang/Runnable;)V

    return-void
.end method
