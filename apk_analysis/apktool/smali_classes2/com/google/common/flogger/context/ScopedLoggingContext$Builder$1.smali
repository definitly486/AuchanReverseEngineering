.class Lcom/google/common/flogger/context/ScopedLoggingContext$Builder$1;
.super Ljava/lang/Object;
.source "ScopedLoggingContext.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/google/common/flogger/context/ScopedLoggingContext$Builder;->wrap(Ljava/lang/Runnable;)Ljava/lang/Runnable;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/google/common/flogger/context/ScopedLoggingContext$Builder;

.field final synthetic val$r:Ljava/lang/Runnable;


# direct methods
.method constructor <init>(Lcom/google/common/flogger/context/ScopedLoggingContext$Builder;Ljava/lang/Runnable;)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()V"
        }
    .end annotation

    .line 191
    iput-object p1, p0, Lcom/google/common/flogger/context/ScopedLoggingContext$Builder$1;->this$0:Lcom/google/common/flogger/context/ScopedLoggingContext$Builder;

    iput-object p2, p0, Lcom/google/common/flogger/context/ScopedLoggingContext$Builder$1;->val$r:Ljava/lang/Runnable;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 3

    .line 196
    iget-object v0, p0, Lcom/google/common/flogger/context/ScopedLoggingContext$Builder$1;->this$0:Lcom/google/common/flogger/context/ScopedLoggingContext$Builder;

    invoke-virtual {v0}, Lcom/google/common/flogger/context/ScopedLoggingContext$Builder;->install()Lcom/google/common/flogger/context/ScopedLoggingContext$LoggingContextCloseable;

    move-result-object v0

    .line 199
    :try_start_0
    iget-object v1, p0, Lcom/google/common/flogger/context/ScopedLoggingContext$Builder$1;->val$r:Ljava/lang/Runnable;

    invoke-interface {v1}, Ljava/lang/Runnable;->run()V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    const/4 v1, 0x0

    .line 202
    invoke-static {v0, v1}, Lcom/google/common/flogger/context/ScopedLoggingContext;->access$000(Lcom/google/common/flogger/context/ScopedLoggingContext$LoggingContextCloseable;Z)V

    return-void

    :catchall_0
    move-exception v1

    const/4 v2, 0x1

    invoke-static {v0, v2}, Lcom/google/common/flogger/context/ScopedLoggingContext;->access$000(Lcom/google/common/flogger/context/ScopedLoggingContext$LoggingContextCloseable;Z)V

    .line 203
    throw v1
.end method
