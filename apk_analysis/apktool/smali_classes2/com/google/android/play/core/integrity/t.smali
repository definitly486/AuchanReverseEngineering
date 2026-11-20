.class final Lcom/google/android/play/core/integrity/t;
.super Ljava/lang/Object;
.source "com.google.android.play:integrity@@1.1.0"


# instance fields
.field final a:Lcom/google/android/play/integrity/internal/v;

.field private final b:Lcom/google/android/play/integrity/internal/k;

.field private final c:Ljava/lang/String;


# direct methods
.method constructor <init>(Landroid/content/Context;Lcom/google/android/play/integrity/internal/k;)V
    .locals 8

    .line 1
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    invoke-virtual {p1}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/google/android/play/core/integrity/t;->c:Ljava/lang/String;

    iput-object p2, p0, Lcom/google/android/play/core/integrity/t;->b:Lcom/google/android/play/integrity/internal/k;

    .line 2
    invoke-static {p1}, Lcom/google/android/play/integrity/internal/y;->a(Landroid/content/Context;)Z

    move-result v0

    if-nez v0, :cond_0

    const/4 p1, 0x0

    new-array p1, p1, [Ljava/lang/Object;

    .line 3
    const-string v0, "Phonesky is not installed."

    invoke-virtual {p2, v0, p1}, Lcom/google/android/play/integrity/internal/k;->b(Ljava/lang/String;[Ljava/lang/Object;)I

    const/4 p1, 0x0

    iput-object p1, p0, Lcom/google/android/play/core/integrity/t;->a:Lcom/google/android/play/integrity/internal/v;

    return-void

    .line 4
    :cond_0
    new-instance v0, Lcom/google/android/play/integrity/internal/v;

    sget-object v4, Lcom/google/android/play/core/integrity/u;->a:Landroid/content/Intent;

    sget-object v5, Lcom/google/android/play/core/integrity/q;->a:Lcom/google/android/play/core/integrity/q;

    const/4 v6, 0x0

    const/4 v7, 0x0

    .line 5
    const-string v3, "IntegrityService"

    move-object v1, p1

    move-object v2, p2

    invoke-direct/range {v0 .. v7}, Lcom/google/android/play/integrity/internal/v;-><init>(Landroid/content/Context;Lcom/google/android/play/integrity/internal/k;Ljava/lang/String;Landroid/content/Intent;Lcom/google/android/play/core/integrity/q;Lcom/google/android/play/integrity/internal/q;[B)V

    iput-object v0, p0, Lcom/google/android/play/core/integrity/t;->a:Lcom/google/android/play/integrity/internal/v;

    return-void
.end method

.method static bridge synthetic a(Lcom/google/android/play/core/integrity/t;[BLjava/lang/Long;)Landroid/os/Bundle;
    .locals 8

    .line 1
    new-instance v0, Landroid/os/Bundle;

    invoke-direct {v0}, Landroid/os/Bundle;-><init>()V

    const-string v1, "package.name"

    iget-object p0, p0, Lcom/google/android/play/core/integrity/t;->c:Ljava/lang/String;

    .line 2
    invoke-virtual {v0, v1, p0}, Landroid/os/BaseBundle;->putString(Ljava/lang/String;Ljava/lang/String;)V

    const-string p0, "nonce"

    .line 3
    invoke-virtual {v0, p0, p1}, Landroid/os/Bundle;->putByteArray(Ljava/lang/String;[B)V

    .line 4
    const-string p0, "playcore.integrity.version.major"

    const/4 p1, 0x1

    invoke-virtual {v0, p0, p1}, Landroid/os/BaseBundle;->putInt(Ljava/lang/String;I)V

    const-string p0, "playcore.integrity.version.minor"

    .line 5
    invoke-virtual {v0, p0, p1}, Landroid/os/BaseBundle;->putInt(Ljava/lang/String;I)V

    .line 6
    const-string p0, "playcore.integrity.version.patch"

    const/4 p1, 0x0

    invoke-virtual {v0, p0, p1}, Landroid/os/BaseBundle;->putInt(Ljava/lang/String;I)V

    if-eqz p2, :cond_0

    const-string p0, "cloud.prj"

    .line 7
    invoke-virtual {p2}, Ljava/lang/Long;->longValue()J

    move-result-wide v1

    invoke-virtual {v0, p0, v1, v2}, Landroid/os/BaseBundle;->putLong(Ljava/lang/String;J)V

    :cond_0
    new-instance p0, Ljava/util/ArrayList;

    .line 8
    invoke-direct {p0}, Ljava/util/ArrayList;-><init>()V

    .line 9
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v1

    const/4 p2, 0x3

    invoke-static {p2, v1, v2}, Lcom/google/android/play/integrity/internal/e;->c(IJ)Lcom/google/android/play/integrity/internal/e;

    move-result-object v1

    invoke-interface {p0, v1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    new-instance v1, Ljava/util/ArrayList;

    new-instance v2, Ljava/util/ArrayList;

    .line 10
    invoke-direct {v2}, Ljava/util/ArrayList;-><init>()V

    .line 11
    invoke-virtual {p0}, Ljava/util/ArrayList;->size()I

    move-result v3

    :goto_0
    if-ge p1, v3, :cond_1

    invoke-virtual {p0, p1}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v4

    add-int/lit8 p1, p1, 0x1

    check-cast v4, Lcom/google/android/play/integrity/internal/e;

    new-instance v5, Landroid/os/Bundle;

    .line 12
    invoke-direct {v5}, Landroid/os/Bundle;-><init>()V

    const-string v6, "event_type"

    .line 13
    invoke-virtual {v5, v6, p2}, Landroid/os/BaseBundle;->putInt(Ljava/lang/String;I)V

    .line 14
    invoke-virtual {v4}, Lcom/google/android/play/integrity/internal/e;->b()J

    move-result-wide v6

    const-string v4, "event_timestamp"

    .line 15
    invoke-virtual {v5, v4, v6, v7}, Landroid/os/BaseBundle;->putLong(Ljava/lang/String;J)V

    .line 14
    invoke-interface {v2, v5}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    goto :goto_0

    .line 16
    :cond_1
    invoke-direct {v1, v2}, Ljava/util/ArrayList;-><init>(Ljava/util/Collection;)V

    const-string p0, "event_timestamps"

    .line 17
    invoke-virtual {v0, p0, v1}, Landroid/os/Bundle;->putParcelableArrayList(Ljava/lang/String;Ljava/util/ArrayList;)V

    return-object v0
.end method

.method static bridge synthetic c(Lcom/google/android/play/core/integrity/t;)Lcom/google/android/play/integrity/internal/k;
    .locals 0

    .line 0
    iget-object p0, p0, Lcom/google/android/play/core/integrity/t;->b:Lcom/google/android/play/integrity/internal/k;

    return-object p0
.end method


# virtual methods
.method public final b(Lcom/google/android/play/core/integrity/IntegrityTokenRequest;)Lcom/google/android/gms/tasks/Task;
    .locals 9

    .line 1
    iget-object v0, p0, Lcom/google/android/play/core/integrity/t;->a:Lcom/google/android/play/integrity/internal/v;

    if-nez v0, :cond_0

    new-instance p1, Lcom/google/android/play/core/integrity/IntegrityServiceException;

    const/4 v0, -0x2

    const/4 v1, 0x0

    .line 2
    invoke-direct {p1, v0, v1}, Lcom/google/android/play/core/integrity/IntegrityServiceException;-><init>(ILjava/lang/Throwable;)V

    .line 1
    invoke-static {p1}, Lcom/google/android/gms/tasks/Tasks;->forException(Ljava/lang/Exception;)Lcom/google/android/gms/tasks/Task;

    move-result-object p1

    return-object p1

    .line 3
    :cond_0
    :try_start_0
    invoke-virtual {p1}, Lcom/google/android/play/core/integrity/IntegrityTokenRequest;->nonce()Ljava/lang/String;

    move-result-object v0

    const/16 v1, 0xa

    invoke-static {v0, v1}, Landroid/util/Base64;->decode(Ljava/lang/String;I)[B

    move-result-object v5
    :try_end_0
    .catch Ljava/lang/IllegalArgumentException; {:try_start_0 .. :try_end_0} :catch_0

    .line 5
    invoke-virtual {p1}, Lcom/google/android/play/core/integrity/IntegrityTokenRequest;->cloudProjectNumber()Ljava/lang/Long;

    move-result-object v6

    iget-object v0, p0, Lcom/google/android/play/core/integrity/t;->b:Lcom/google/android/play/integrity/internal/k;

    filled-new-array {p1}, [Ljava/lang/Object;

    move-result-object v1

    const-string v2, "requestIntegrityToken(%s)"

    .line 6
    invoke-virtual {v0, v2, v1}, Lcom/google/android/play/integrity/internal/k;->d(Ljava/lang/String;[Ljava/lang/Object;)I

    .line 7
    new-instance v4, Lcom/google/android/gms/tasks/TaskCompletionSource;

    invoke-direct {v4}, Lcom/google/android/gms/tasks/TaskCompletionSource;-><init>()V

    iget-object v0, p0, Lcom/google/android/play/core/integrity/t;->a:Lcom/google/android/play/integrity/internal/v;

    new-instance v2, Lcom/google/android/play/core/integrity/r;

    move-object v7, v4

    move-object v3, p0

    move-object v8, p1

    invoke-direct/range {v2 .. v8}, Lcom/google/android/play/core/integrity/r;-><init>(Lcom/google/android/play/core/integrity/t;Lcom/google/android/gms/tasks/TaskCompletionSource;[BLjava/lang/Long;Lcom/google/android/gms/tasks/TaskCompletionSource;Lcom/google/android/play/core/integrity/IntegrityTokenRequest;)V

    .line 8
    invoke-virtual {v0, v2, v4}, Lcom/google/android/play/integrity/internal/v;->p(Lcom/google/android/play/integrity/internal/l;Lcom/google/android/gms/tasks/TaskCompletionSource;)V

    .line 9
    invoke-virtual {v4}, Lcom/google/android/gms/tasks/TaskCompletionSource;->getTask()Lcom/google/android/gms/tasks/Task;

    move-result-object p1

    return-object p1

    :catch_0
    move-exception v0

    move-object p1, v0

    .line 4
    new-instance v0, Lcom/google/android/play/core/integrity/IntegrityServiceException;

    const/16 v1, -0xd

    invoke-direct {v0, v1, p1}, Lcom/google/android/play/core/integrity/IntegrityServiceException;-><init>(ILjava/lang/Throwable;)V

    invoke-static {v0}, Lcom/google/android/gms/tasks/Tasks;->forException(Ljava/lang/Exception;)Lcom/google/android/gms/tasks/Task;

    move-result-object p1

    return-object p1
.end method
