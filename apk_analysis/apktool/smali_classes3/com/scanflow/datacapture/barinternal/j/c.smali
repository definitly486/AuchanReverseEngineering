.class public final Lcom/scanflow/datacapture/barinternal/j/c;
.super Ljava/lang/Object;
.source "SourceFile"


# instance fields
.field public final a:Lcom/scanflow/datacapture/barinternal/j/b;

.field public final b:Lcom/scanflow/datacapture/barinternal/j/a;

.field public final c:Landroid/net/ConnectivityManager;


# direct methods
.method public constructor <init>(Landroid/content/Context;)V
    .locals 3

    new-instance v0, Lcom/scanflow/datacapture/barinternal/j/b;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/j/b;-><init>()V

    new-instance v1, Lcom/scanflow/datacapture/barinternal/j/a;

    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/j/a;-><init>()V

    .line 1
    const-string v2, "context"

    invoke-static {p1, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v2, "factory"

    invoke-static {v0, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v2, "callback"

    invoke-static {v1, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/j/c;->a:Lcom/scanflow/datacapture/barinternal/j/b;

    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/j/c;->b:Lcom/scanflow/datacapture/barinternal/j/a;

    const-string v0, "connectivity"

    invoke-virtual {p1, v0}, Landroid/content/Context;->getSystemService(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object p1

    const-string v0, "null cannot be cast to non-null type android.net.ConnectivityManager"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast p1, Landroid/net/ConnectivityManager;

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/j/c;->c:Landroid/net/ConnectivityManager;

    return-void
.end method
