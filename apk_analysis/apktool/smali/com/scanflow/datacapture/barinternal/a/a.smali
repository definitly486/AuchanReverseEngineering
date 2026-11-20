.class public final Lcom/scanflow/datacapture/barinternal/a/a;
.super Ljava/lang/Object;
.source "SourceFile"

# interfaces
.implements Lretrofit2/Callback;


# instance fields
.field public final synthetic a:Lcom/scanflow/datacapture/analytics/BackgroundWorker;

.field public final synthetic b:Ljava/io/File;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/analytics/BackgroundWorker;Ljava/io/File;)V
    .locals 0

    .line 1
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/a/a;->a:Lcom/scanflow/datacapture/analytics/BackgroundWorker;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/a/a;->b:Ljava/io/File;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public final onFailure(Lretrofit2/Call;Ljava/lang/Throwable;)V
    .locals 1

    .line 1
    const-string v0, "call"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string p1, "t"

    invoke-static {p2, p1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/a/a;->b:Ljava/io/File;

    invoke-virtual {p1}, Ljava/io/File;->delete()Z

    return-void
.end method

.method public final onResponse(Lretrofit2/Call;Lretrofit2/Response;)V
    .locals 1

    const-string v0, "call"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string p1, "response"

    invoke-static {p2, p1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/a/a;->a:Lcom/scanflow/datacapture/analytics/BackgroundWorker;

    invoke-virtual {p2}, Lretrofit2/Response;->body()Ljava/lang/Object;

    move-result-object v0

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/a/a$$ExternalSyntheticThrowCCEIfNotNull0;->m(Ljava/lang/Object;)V

    .line 1
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 2
    invoke-virtual {p2}, Lretrofit2/Response;->code()I

    move-result p1

    const/16 p2, 0xc8

    if-ne p1, p2, :cond_0

    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/a/a;->b:Ljava/io/File;

    invoke-virtual {p1}, Ljava/io/File;->delete()Z

    :cond_0
    return-void
.end method
