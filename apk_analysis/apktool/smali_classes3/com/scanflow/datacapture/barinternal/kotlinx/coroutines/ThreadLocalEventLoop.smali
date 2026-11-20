.class public final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ThreadLocalEventLoop;
.super Ljava/lang/Object;
.source "EventLoop.common.kt"


# static fields
.field public static final INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ThreadLocalEventLoop;

.field private static final ref:Ljava/lang/ThreadLocal;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ThreadLocalEventLoop;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ThreadLocalEventLoop;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ThreadLocalEventLoop;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ThreadLocalEventLoop;

    .line 123
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    const-string v1, "ThreadLocalEventLoop"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;-><init>(Ljava/lang/String;)V

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ThreadLocalKt;->commonThreadLocal(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;)Ljava/lang/ThreadLocal;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ThreadLocalEventLoop;->ref:Ljava/lang/ThreadLocal;

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 122
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public final currentOrNull$kotlinx_coroutines_core()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;
    .locals 1

    .line 129
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ThreadLocalEventLoop;->ref:Ljava/lang/ThreadLocal;

    invoke-virtual {v0}, Ljava/lang/ThreadLocal;->get()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;

    return-object v0
.end method

.method public final getEventLoop$kotlinx_coroutines_core()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;
    .locals 2

    .line 126
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ThreadLocalEventLoop;->ref:Ljava/lang/ThreadLocal;

    invoke-virtual {v0}, Ljava/lang/ThreadLocal;->get()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;

    if-nez v1, :cond_0

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoopKt;->createEventLoop()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/ThreadLocal;->set(Ljava/lang/Object;)V

    :cond_0
    return-object v1
.end method

.method public final resetEventLoop$kotlinx_coroutines_core()V
    .locals 2

    .line 132
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ThreadLocalEventLoop;->ref:Ljava/lang/ThreadLocal;

    const/4 v1, 0x0

    invoke-virtual {v0, v1}, Ljava/lang/ThreadLocal;->set(Ljava/lang/Object;)V

    return-void
.end method

.method public final setEventLoop$kotlinx_coroutines_core(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/EventLoop;)V
    .locals 1

    .line 136
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ThreadLocalEventLoop;->ref:Ljava/lang/ThreadLocal;

    invoke-virtual {v0, p1}, Ljava/lang/ThreadLocal;->set(Ljava/lang/Object;)V

    return-void
.end method
