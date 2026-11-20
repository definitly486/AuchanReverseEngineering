.class public final Lcom/scanflow/datacapture/utils/LogUtils$Companion;
.super Ljava/lang/Object;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/utils/LogUtils;
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
    invoke-direct {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;-><init>()V

    return-void
.end method

.method private final generateTag(Ljava/lang/StackTraceElement;)Ljava/lang/String;
    .locals 6

    .line 0
    invoke-virtual {p1}, Ljava/lang/StackTraceElement;->getClassName()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    const/4 v4, 0x6

    const/4 v5, 0x0

    const-string v1, "."

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->lastIndexOf$default(Ljava/lang/CharSequence;Ljava/lang/String;IZILjava/lang/Object;)I

    move-result v1

    add-int/lit8 v1, v1, 0x1

    invoke-virtual {v0, v1}, Ljava/lang/String;->substring(I)Ljava/lang/String;

    move-result-object v0

    const-string v1, "substring(...)"

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    sget-object v1, Lkotlin/jvm/internal/StringCompanionObject;->INSTANCE:Lkotlin/jvm/internal/StringCompanionObject;

    invoke-virtual {p1}, Ljava/lang/StackTraceElement;->getMethodName()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {p1}, Ljava/lang/StackTraceElement;->getFileName()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {p1}, Ljava/lang/StackTraceElement;->getLineNumber()I

    move-result p1

    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p1

    filled-new-array {v0, v1, v2, p1}, [Ljava/lang/Object;

    move-result-object p1

    const/4 v0, 0x4

    invoke-static {p1, v0}, Ljava/util/Arrays;->copyOf([Ljava/lang/Object;I)[Ljava/lang/Object;

    move-result-object p1

    const-string v0, "%s.%s(%s:%d)"

    invoke-static {v0, p1}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object p1

    const-string v0, "format(...)"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "LogUtils|"

    invoke-virtual {v0, p1}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object p1

    const-string v0, "toString(...)"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    return-object p1
.end method

.method private final getCallerStackLogTag()Ljava/lang/String;
    .locals 1

    .line 0
    const/4 v0, 0x5

    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getStackTraceElement(I)Ljava/lang/StackTraceElement;

    move-result-object v0

    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->generateTag(Ljava/lang/StackTraceElement;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method private final getStackTraceString(Ljava/lang/Throwable;)Ljava/lang/String;
    .locals 1

    .line 0
    invoke-static {p1}, Landroid/util/Log;->getStackTraceString(Ljava/lang/Throwable;)Ljava/lang/String;

    move-result-object p1

    const-string v0, "getStackTraceString(...)"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    return-object p1
.end method


# virtual methods
.method public final d(Ljava/lang/String;)V
    .locals 2

    .line 1
    const-string v0, "msg"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->isShowLog()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getPriority()I

    move-result v0

    const/4 v1, 0x3

    if-gt v0, v1, :cond_0

    invoke-direct {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getCallerStackLogTag()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0, p1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    :cond_0
    return-void
.end method

.method public final d(Ljava/lang/String;Ljava/lang/Throwable;)V
    .locals 2

    .line 2
    const-string v0, "msg"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->isShowLog()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getPriority()I

    move-result v0

    const/4 v1, 0x3

    if-gt v0, v1, :cond_0

    invoke-direct {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getCallerStackLogTag()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0, p1, p2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Throwable;)I

    :cond_0
    return-void
.end method

.method public final d(Ljava/lang/Throwable;)V
    .locals 2

    .line 3
    const-string v0, "t"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->isShowLog()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getPriority()I

    move-result v0

    const/4 v1, 0x3

    if-gt v0, v1, :cond_0

    invoke-direct {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getCallerStackLogTag()Ljava/lang/String;

    move-result-object v0

    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getStackTraceString(Ljava/lang/Throwable;)Ljava/lang/String;

    move-result-object p1

    invoke-static {v0, p1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    :cond_0
    return-void
.end method

.method public final e(Ljava/lang/String;)V
    .locals 2

    .line 1
    const-string v0, "msg"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->isShowLog()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getPriority()I

    move-result v0

    const/4 v1, 0x6

    if-gt v0, v1, :cond_0

    invoke-direct {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getCallerStackLogTag()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0, p1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    :cond_0
    return-void
.end method

.method public final e(Ljava/lang/String;Ljava/lang/Throwable;)V
    .locals 2

    .line 2
    const-string v0, "msg"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->isShowLog()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getPriority()I

    move-result v0

    const/4 v1, 0x6

    if-gt v0, v1, :cond_0

    invoke-direct {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getCallerStackLogTag()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0, p1, p2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Throwable;)I

    :cond_0
    return-void
.end method

.method public final e(Ljava/lang/Throwable;)V
    .locals 2

    .line 3
    const-string v0, "t"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->isShowLog()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getPriority()I

    move-result v0

    const/4 v1, 0x6

    if-gt v0, v1, :cond_0

    invoke-direct {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getCallerStackLogTag()Ljava/lang/String;

    move-result-object v0

    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getStackTraceString(Ljava/lang/Throwable;)Ljava/lang/String;

    move-result-object p1

    invoke-static {v0, p1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    :cond_0
    return-void
.end method

.method public final getPriority()I
    .locals 1

    .line 0
    invoke-static {}, Lcom/scanflow/datacapture/utils/LogUtils;->access$getPriority$cp()I

    move-result v0

    return v0
.end method

.method public final getStackTraceElement(I)Ljava/lang/StackTraceElement;
    .locals 1

    .line 0
    invoke-static {}, Ljava/lang/Thread;->currentThread()Ljava/lang/Thread;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Thread;->getStackTrace()[Ljava/lang/StackTraceElement;

    move-result-object v0

    aget-object p1, v0, p1

    const-string v0, "get(...)"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    return-object p1
.end method

.method public final i(Ljava/lang/String;)V
    .locals 2

    .line 1
    const-string v0, "msg"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->isShowLog()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getPriority()I

    move-result v0

    const/4 v1, 0x4

    if-gt v0, v1, :cond_0

    invoke-direct {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getCallerStackLogTag()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0, p1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    :cond_0
    return-void
.end method

.method public final i(Ljava/lang/String;Ljava/lang/Throwable;)V
    .locals 2

    .line 2
    const-string v0, "msg"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->isShowLog()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getPriority()I

    move-result v0

    const/4 v1, 0x4

    if-gt v0, v1, :cond_0

    invoke-direct {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getCallerStackLogTag()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0, p1, p2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Throwable;)I

    :cond_0
    return-void
.end method

.method public final i(Ljava/lang/Throwable;)V
    .locals 2

    .line 3
    const-string v0, "t"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->isShowLog()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getPriority()I

    move-result v0

    const/4 v1, 0x4

    if-gt v0, v1, :cond_0

    invoke-direct {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getCallerStackLogTag()Ljava/lang/String;

    move-result-object v0

    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getStackTraceString(Ljava/lang/Throwable;)Ljava/lang/String;

    move-result-object p1

    invoke-static {v0, p1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    :cond_0
    return-void
.end method

.method public final isShowLog()Z
    .locals 1

    .line 0
    invoke-static {}, Lcom/scanflow/datacapture/utils/LogUtils;->access$isShowLog$cp()Z

    move-result v0

    return v0
.end method

.method public final print(Ljava/lang/Object;)V
    .locals 2

    .line 1
    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->isShowLog()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getPriority()I

    move-result v0

    const/4 v1, 0x1

    if-gt v0, v1, :cond_0

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->print(Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method public final print(Ljava/lang/String;)V
    .locals 2

    .line 2
    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->isShowLog()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getPriority()I

    move-result v0

    const/4 v1, 0x1

    if-gt v0, v1, :cond_0

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->print(Ljava/lang/String;)V

    :cond_0
    return-void
.end method

.method public final printf(Ljava/lang/String;)V
    .locals 2

    .line 0
    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->isShowLog()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getPriority()I

    move-result v0

    const/4 v1, 0x1

    if-gt v0, v1, :cond_0

    sget-object v0, Ljava/lang/System;->out:Ljava/io/PrintStream;

    const/4 v1, 0x0

    new-array v1, v1, [Ljava/lang/Object;

    invoke-virtual {v0, p1, v1}, Ljava/io/PrintStream;->printf(Ljava/lang/String;[Ljava/lang/Object;)Ljava/io/PrintStream;

    :cond_0
    return-void
.end method

.method public final println(Ljava/lang/Object;)V
    .locals 2

    .line 1
    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->isShowLog()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getPriority()I

    move-result v0

    const/4 v1, 0x1

    if-gt v0, v1, :cond_0

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->println(Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method public final println(Ljava/lang/String;)V
    .locals 2

    .line 2
    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->isShowLog()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getPriority()I

    move-result v0

    const/4 v1, 0x1

    if-gt v0, v1, :cond_0

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->println(Ljava/lang/String;)V

    :cond_0
    return-void
.end method

.method public final setPriority(I)V
    .locals 0

    .line 0
    invoke-static {p1}, Lcom/scanflow/datacapture/utils/LogUtils;->access$setPriority$cp(I)V

    return-void
.end method

.method public final setShowLog(Z)V
    .locals 0

    .line 0
    invoke-static {p1}, Lcom/scanflow/datacapture/utils/LogUtils;->access$setShowLog$cp(Z)V

    return-void
.end method

.method public final v(Ljava/lang/String;)V
    .locals 2

    .line 1
    const-string v0, "msg"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->isShowLog()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getPriority()I

    move-result v0

    const/4 v1, 0x2

    if-gt v0, v1, :cond_0

    invoke-direct {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getCallerStackLogTag()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0, p1}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    :cond_0
    return-void
.end method

.method public final v(Ljava/lang/String;Ljava/lang/Throwable;)V
    .locals 2

    .line 2
    const-string v0, "msg"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->isShowLog()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getPriority()I

    move-result v0

    const/4 v1, 0x2

    if-gt v0, v1, :cond_0

    invoke-direct {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getCallerStackLogTag()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0, p1, p2}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Throwable;)I

    :cond_0
    return-void
.end method

.method public final v(Ljava/lang/Throwable;)V
    .locals 2

    .line 3
    const-string v0, "t"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->isShowLog()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getPriority()I

    move-result v0

    const/4 v1, 0x2

    if-gt v0, v1, :cond_0

    invoke-direct {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getCallerStackLogTag()Ljava/lang/String;

    move-result-object v0

    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getStackTraceString(Ljava/lang/Throwable;)Ljava/lang/String;

    move-result-object p1

    invoke-static {v0, p1}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    :cond_0
    return-void
.end method

.method public final w(Ljava/lang/String;)V
    .locals 2

    .line 1
    const-string v0, "msg"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->isShowLog()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getPriority()I

    move-result v0

    const/4 v1, 0x5

    if-gt v0, v1, :cond_0

    invoke-direct {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getCallerStackLogTag()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0, p1}, Landroid/util/Log;->w(Ljava/lang/String;Ljava/lang/String;)I

    :cond_0
    return-void
.end method

.method public final w(Ljava/lang/String;Ljava/lang/Throwable;)V
    .locals 2

    .line 2
    const-string v0, "msg"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->isShowLog()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getPriority()I

    move-result v0

    const/4 v1, 0x5

    if-gt v0, v1, :cond_0

    invoke-direct {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getCallerStackLogTag()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0, p1, p2}, Landroid/util/Log;->w(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Throwable;)I

    :cond_0
    return-void
.end method

.method public final w(Ljava/lang/Throwable;)V
    .locals 2

    .line 3
    const-string v0, "t"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->isShowLog()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getPriority()I

    move-result v0

    const/4 v1, 0x5

    if-gt v0, v1, :cond_0

    invoke-direct {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getCallerStackLogTag()Ljava/lang/String;

    move-result-object v0

    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getStackTraceString(Ljava/lang/Throwable;)Ljava/lang/String;

    move-result-object p1

    invoke-static {v0, p1}, Landroid/util/Log;->w(Ljava/lang/String;Ljava/lang/String;)I

    :cond_0
    return-void
.end method

.method public final wtf(Ljava/lang/String;)V
    .locals 2

    .line 1
    const-string v0, "msg"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->isShowLog()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getPriority()I

    move-result v0

    const/4 v1, 0x7

    if-gt v0, v1, :cond_0

    invoke-direct {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getCallerStackLogTag()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0, p1}, Landroid/util/Log;->wtf(Ljava/lang/String;Ljava/lang/String;)I

    :cond_0
    return-void
.end method

.method public final wtf(Ljava/lang/String;Ljava/lang/Throwable;)V
    .locals 2

    .line 2
    const-string v0, "msg"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->isShowLog()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getPriority()I

    move-result v0

    const/4 v1, 0x7

    if-gt v0, v1, :cond_0

    invoke-direct {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getCallerStackLogTag()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0, p1, p2}, Landroid/util/Log;->wtf(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Throwable;)I

    :cond_0
    return-void
.end method

.method public final wtf(Ljava/lang/Throwable;)V
    .locals 2

    .line 3
    const-string v0, "t"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->isShowLog()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getPriority()I

    move-result v0

    const/4 v1, 0x7

    if-gt v0, v1, :cond_0

    invoke-direct {p0}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getCallerStackLogTag()Ljava/lang/String;

    move-result-object v0

    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;->getStackTraceString(Ljava/lang/Throwable;)Ljava/lang/String;

    move-result-object p1

    invoke-static {v0, p1}, Landroid/util/Log;->wtf(Ljava/lang/String;Ljava/lang/String;)I

    :cond_0
    return-void
.end method
