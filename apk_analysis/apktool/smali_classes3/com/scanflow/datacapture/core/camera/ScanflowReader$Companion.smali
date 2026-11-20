.class public final Lcom/scanflow/datacapture/core/camera/ScanflowReader$Companion;
.super Ljava/lang/Object;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Companion"
.end annotation


# direct methods
.method private constructor <init>()V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public synthetic constructor <init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V
    .locals 0

    .line 2
    invoke-direct {p0}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$Companion;-><init>()V

    return-void
.end method


# virtual methods
.method public final getLENS_FACING_BACK()I
    .locals 1

    .line 0
    invoke-static {}, Lcom/scanflow/datacapture/core/camera/ScanflowReader;->access$getLENS_FACING_BACK$cp()I

    move-result v0

    return v0
.end method

.method public final getLENS_FACING_FRONT()I
    .locals 1

    .line 0
    invoke-static {}, Lcom/scanflow/datacapture/core/camera/ScanflowReader;->access$getLENS_FACING_FRONT$cp()I

    move-result v0

    return v0
.end method

.method public final getSCAN_RESULT()Ljava/lang/String;
    .locals 1

    .line 0
    invoke-static {}, Lcom/scanflow/datacapture/core/camera/ScanflowReader;->access$getSCAN_RESULT$cp()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public final setLENS_FACING_BACK(I)V
    .locals 0

    .line 0
    invoke-static {p1}, Lcom/scanflow/datacapture/core/camera/ScanflowReader;->access$setLENS_FACING_BACK$cp(I)V

    return-void
.end method

.method public final setLENS_FACING_FRONT(I)V
    .locals 0

    .line 0
    invoke-static {p1}, Lcom/scanflow/datacapture/core/camera/ScanflowReader;->access$setLENS_FACING_FRONT$cp(I)V

    return-void
.end method

.method public final setSCAN_RESULT(Ljava/lang/String;)V
    .locals 1

    .line 0
    const-string v0, "<set-?>"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-static {p1}, Lcom/scanflow/datacapture/core/camera/ScanflowReader;->access$setSCAN_RESULT$cp(Ljava/lang/String;)V

    return-void
.end method
