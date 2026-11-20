.class public final Lcom/scanflow/datacapture/barinternal/androidx/activity/result/contract/ActivityResultContracts$StartActivityForResult;
.super Landroidx/activity/result/contract/ActivityResultContract;
.source "ActivityResultContracts.kt"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/androidx/activity/result/contract/ActivityResultContracts$StartActivityForResult$Companion;
    }
.end annotation


# static fields
.field public static final Companion:Lcom/scanflow/datacapture/barinternal/androidx/activity/result/contract/ActivityResultContracts$StartActivityForResult$Companion;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/activity/result/contract/ActivityResultContracts$StartActivityForResult$Companion;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/activity/result/contract/ActivityResultContracts$StartActivityForResult$Companion;-><init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/activity/result/contract/ActivityResultContracts$StartActivityForResult;->Companion:Lcom/scanflow/datacapture/barinternal/androidx/activity/result/contract/ActivityResultContracts$StartActivityForResult$Companion;

    return-void
.end method

.method public constructor <init>()V
    .locals 0

    .line 58
    invoke-direct {p0}, Landroidx/activity/result/contract/ActivityResultContract;-><init>()V

    return-void
.end method


# virtual methods
.method public createIntent(Landroid/content/Context;Landroid/content/Intent;)Landroid/content/Intent;
    .locals 1

    .line 0
    const-string v0, "context"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string p1, "input"

    invoke-static {p2, p1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    return-object p2
.end method

.method public bridge synthetic createIntent(Landroid/content/Context;Ljava/lang/Object;)Landroid/content/Intent;
    .locals 0

    .line 58
    check-cast p2, Landroid/content/Intent;

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/activity/result/contract/ActivityResultContracts$StartActivityForResult;->createIntent(Landroid/content/Context;Landroid/content/Intent;)Landroid/content/Intent;

    move-result-object p1

    return-object p1
.end method

.method public parseResult(ILandroid/content/Intent;)Lcom/scanflow/datacapture/barinternal/androidx/activity/result/ActivityResult;
    .locals 1

    .line 76
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/activity/result/ActivityResult;

    invoke-direct {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/activity/result/ActivityResult;-><init>(ILandroid/content/Intent;)V

    return-object v0
.end method

.method public bridge synthetic parseResult(ILandroid/content/Intent;)Ljava/lang/Object;
    .locals 0

    .line 58
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/activity/result/contract/ActivityResultContracts$StartActivityForResult;->parseResult(ILandroid/content/Intent;)Lcom/scanflow/datacapture/barinternal/androidx/activity/result/ActivityResult;

    move-result-object p1

    return-object p1
.end method
