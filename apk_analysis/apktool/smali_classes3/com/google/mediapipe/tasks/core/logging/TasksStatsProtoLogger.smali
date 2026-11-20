.class public Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;
.super Ljava/lang/Object;
.source "TasksStatsProtoLogger.java"

# interfaces
.implements Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger;


# static fields
.field private static final LATENCY_TIMEOUT_THRESHOLD_MS:Ljava/lang/Long;

.field private static final REPORT_INTERVAL_MS:Ljava/lang/Long;

.field private static final TAG:Ljava/lang/String; = "TasksStatsProtoLogger"

.field private static final TASKS_MODE_PREFIX:Ljava/lang/String; = "MODE_TASKS_"

.field private static final TASKS_NAME_PREFIX:Ljava/lang/String; = "TASKS_"


# instance fields
.field private final cpuInputCount:Ljava/util/concurrent/atomic/AtomicInteger;

.field private final droppedCount:Ljava/util/concurrent/atomic/AtomicInteger;

.field private final finishedCount:Ljava/util/concurrent/atomic/AtomicInteger;

.field private final gpuInputCount:Ljava/util/concurrent/atomic/AtomicInteger;

.field private final latestPeakLatencyMs:Ljava/util/concurrent/atomic/AtomicLong;

.field private final lifetimePeakLatencyMs:Ljava/util/concurrent/atomic/AtomicLong;

.field private final loggingClient:Lcom/google/mediapipe/tasks/core/logging/LoggingClient;

.field private reportStartTimeMs:J

.field private final startTimeMap:Ljava/util/concurrent/ConcurrentNavigableMap;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/concurrent/ConcurrentNavigableMap<",
            "Ljava/lang/Long;",
            "Ljava/lang/Long;",
            ">;"
        }
    .end annotation
.end field

.field private statsSnapshot:Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;

.field private final systemInfo:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

.field private final taskInitTimeMs:J

.field private final taskName:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionName;

.field private final taskRunningMode:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

.field private final totalLatencyMs:Ljava/util/concurrent/atomic/AtomicLong;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    const-wide/16 v0, 0x7530

    .line 49
    invoke-static {v0, v1}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v0

    sput-object v0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->REPORT_INTERVAL_MS:Ljava/lang/Long;

    const-wide/16 v0, 0xbb8

    .line 50
    invoke-static {v0, v1}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v0

    sput-object v0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->LATENCY_TIMEOUT_THRESHOLD_MS:Ljava/lang/Long;

    return-void
.end method

.method private constructor <init>(Landroid/content/Context;Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionName;Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;)V
    .locals 3

    .line 125
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 63
    new-instance v0, Ljava/util/concurrent/atomic/AtomicInteger;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Ljava/util/concurrent/atomic/AtomicInteger;-><init>(I)V

    iput-object v0, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->cpuInputCount:Ljava/util/concurrent/atomic/AtomicInteger;

    .line 65
    new-instance v0, Ljava/util/concurrent/atomic/AtomicInteger;

    invoke-direct {v0, v1}, Ljava/util/concurrent/atomic/AtomicInteger;-><init>(I)V

    iput-object v0, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->gpuInputCount:Ljava/util/concurrent/atomic/AtomicInteger;

    .line 67
    new-instance v0, Ljava/util/concurrent/atomic/AtomicInteger;

    invoke-direct {v0, v1}, Ljava/util/concurrent/atomic/AtomicInteger;-><init>(I)V

    iput-object v0, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->finishedCount:Ljava/util/concurrent/atomic/AtomicInteger;

    .line 69
    new-instance v0, Ljava/util/concurrent/atomic/AtomicInteger;

    invoke-direct {v0, v1}, Ljava/util/concurrent/atomic/AtomicInteger;-><init>(I)V

    iput-object v0, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->droppedCount:Ljava/util/concurrent/atomic/AtomicInteger;

    .line 71
    new-instance v0, Ljava/util/concurrent/atomic/AtomicLong;

    const-wide/16 v1, 0x0

    invoke-direct {v0, v1, v2}, Ljava/util/concurrent/atomic/AtomicLong;-><init>(J)V

    iput-object v0, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->totalLatencyMs:Ljava/util/concurrent/atomic/AtomicLong;

    .line 73
    new-instance v0, Ljava/util/concurrent/atomic/AtomicLong;

    invoke-direct {v0, v1, v2}, Ljava/util/concurrent/atomic/AtomicLong;-><init>(J)V

    iput-object v0, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->latestPeakLatencyMs:Ljava/util/concurrent/atomic/AtomicLong;

    .line 75
    new-instance v0, Ljava/util/concurrent/atomic/AtomicLong;

    invoke-direct {v0, v1, v2}, Ljava/util/concurrent/atomic/AtomicLong;-><init>(J)V

    iput-object v0, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->lifetimePeakLatencyMs:Ljava/util/concurrent/atomic/AtomicLong;

    .line 77
    new-instance v0, Ljava/util/concurrent/ConcurrentSkipListMap;

    invoke-direct {v0}, Ljava/util/concurrent/ConcurrentSkipListMap;-><init>()V

    iput-object v0, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->startTimeMap:Ljava/util/concurrent/ConcurrentNavigableMap;

    .line 126
    new-instance v0, Lcom/google/mediapipe/tasks/core/logging/RemoteLoggingClient;

    invoke-direct {v0, p1}, Lcom/google/mediapipe/tasks/core/logging/RemoteLoggingClient;-><init>(Landroid/content/Context;)V

    iput-object v0, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->loggingClient:Lcom/google/mediapipe/tasks/core/logging/LoggingClient;

    .line 127
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v0

    iput-wide v0, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->taskInitTimeMs:J

    .line 128
    iput-object p2, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->taskName:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionName;

    .line 129
    iput-object p3, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->taskRunningMode:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    .line 130
    iput-object p4, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->systemInfo:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    return-void
.end method

.method public static create(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;
    .locals 4

    .line 91
    :try_start_0
    invoke-virtual {p0}, Landroid/content/Context;->getPackageManager()Landroid/content/pm/PackageManager;

    move-result-object v0

    invoke-virtual {p0}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v1

    const/4 v2, 0x0

    invoke-virtual {v0, v1, v2}, Landroid/content/pm/PackageManager;->getPackageInfo(Ljava/lang/String;I)Landroid/content/pm/PackageInfo;

    move-result-object v0

    .line 92
    iget v0, v0, Landroid/content/pm/PackageInfo;->versionCode:I

    invoke-static {v0}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v0
    :try_end_0
    .catch Landroid/content/pm/PackageManager$NameNotFoundException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    :catch_0
    move-exception v0

    .line 94
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Exception thrown when trying to get app version "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    const-string v1, "TasksStatsProtoLogger"

    invoke-static {v1, v0}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    const-string v0, ""

    .line 98
    :goto_0
    :try_start_1
    const-class v1, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionName;

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "TASKS_"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    sget-object v3, Ljava/util/Locale;->ENGLISH:Ljava/util/Locale;

    .line 100
    invoke-virtual {p1, v3}, Ljava/lang/String;->toUpperCase(Ljava/util/Locale;)Ljava/lang/String;

    move-result-object p1

    invoke-virtual {v2, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    .line 99
    invoke-static {v1, p1}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionName;
    :try_end_1
    .catch Ljava/lang/IllegalArgumentException; {:try_start_1 .. :try_end_1} :catch_1

    goto :goto_1

    .line 102
    :catch_1
    sget-object p1, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionName;->SOLUTION_UNKNOWN:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionName;

    .line 106
    :goto_1
    :try_start_2
    const-class v1, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "MODE_TASKS_"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    sget-object v3, Ljava/util/Locale;->ENGLISH:Ljava/util/Locale;

    .line 109
    invoke-virtual {p2, v3}, Ljava/lang/String;->toUpperCase(Ljava/util/Locale;)Ljava/lang/String;

    move-result-object p2

    invoke-virtual {v2, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p2

    .line 107
    invoke-static {v1, p2}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object p2

    check-cast p2, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;
    :try_end_2
    .catch Ljava/lang/IllegalArgumentException; {:try_start_2 .. :try_end_2} :catch_2

    goto :goto_2

    .line 111
    :catch_2
    sget-object p2, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->MODE_TASKS_UNSPECIFIED:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    .line 113
    :goto_2
    new-instance v1, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;

    .line 117
    invoke-static {}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;->newBuilder()Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo$Builder;

    move-result-object v2

    sget-object v3, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$Platform;->PLATFORM_ANDROID:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$Platform;

    .line 118
    invoke-virtual {v2, v3}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo$Builder;->setPlatform(Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$Platform;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo$Builder;

    move-result-object v2

    .line 119
    invoke-virtual {p0}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v2, v3}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo$Builder;->setAppId(Ljava/lang/String;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo$Builder;

    move-result-object v2

    .line 120
    invoke-virtual {v2, v0}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo$Builder;->setAppVersion(Ljava/lang/String;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo$Builder;

    move-result-object v0

    .line 121
    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    invoke-direct {v1, p0, p1, p2, v0}, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;-><init>(Landroid/content/Context;Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionName;Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;)V

    return-object v1
.end method

.method private logTaskEvent(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent;)V
    .locals 2

    .line 329
    invoke-static {}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;->newBuilder()Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension$Builder;

    move-result-object v0

    iget-object v1, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->systemInfo:Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;

    .line 330
    invoke-virtual {v0, v1}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension$Builder;->setSystemInfo(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SystemInfo;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension$Builder;

    move-result-object v0

    .line 331
    invoke-virtual {v0, p1}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension$Builder;->setSolutionEvent(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension$Builder;

    move-result-object p1

    .line 332
    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;

    .line 333
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->loggingClient:Lcom/google/mediapipe/tasks/core/logging/LoggingClient;

    invoke-interface {v0, p1}, Lcom/google/mediapipe/tasks/core/logging/LoggingClient;->logEvent(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$MediaPipeLogExtension;)V

    return-void
.end method

.method private produceInvocationReport(Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionInvocationReport;
    .locals 5

    .line 256
    invoke-static {}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionInvocationReport;->newBuilder()Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionInvocationReport$Builder;

    move-result-object v0

    iget-object v1, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->taskRunningMode:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    .line 257
    invoke-virtual {v0, v1}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionInvocationReport$Builder;->setMode(Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionInvocationReport$Builder;

    move-result-object v0

    .line 258
    invoke-virtual {p1}, Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;->droppedCount()I

    move-result v1

    int-to-long v1, v1

    invoke-virtual {v0, v1, v2}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionInvocationReport$Builder;->setDropped(J)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionInvocationReport$Builder;

    move-result-object v0

    .line 259
    invoke-virtual {p1}, Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;->peakLatencyMs()J

    move-result-wide v1

    invoke-virtual {v0, v1, v2}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionInvocationReport$Builder;->setPipelinePeakLatencyMs(J)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionInvocationReport$Builder;

    move-result-object v0

    .line 260
    invoke-virtual {p1}, Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;->totalLatencyMs()J

    move-result-wide v1

    const/4 v3, 0x1

    invoke-virtual {p1}, Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;->finishedCount()I

    move-result v4

    invoke-static {v3, v4}, Ljava/lang/Math;->max(II)I

    move-result v3

    int-to-long v3, v3

    div-long/2addr v1, v3

    invoke-virtual {v0, v1, v2}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionInvocationReport$Builder;->setPipelineAverageLatencyMs(J)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionInvocationReport$Builder;

    move-result-object v0

    .line 261
    invoke-virtual {p1}, Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;->elapsedTimeMs()J

    move-result-wide v1

    invoke-virtual {v0, v1, v2}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionInvocationReport$Builder;->setElapsedTimeMs(J)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionInvocationReport$Builder;

    move-result-object v0

    .line 262
    invoke-virtual {p1}, Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;->cpuInputCount()I

    move-result v1

    if-eqz v1, :cond_0

    .line 264
    invoke-static {}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionInvocationCount;->newBuilder()Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionInvocationCount$Builder;

    move-result-object v1

    sget-object v2, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$InputDataType;->INPUT_TYPE_TASKS_CPU:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$InputDataType;

    .line 265
    invoke-virtual {v1, v2}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionInvocationCount$Builder;->setInputDataType(Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$InputDataType;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionInvocationCount$Builder;

    move-result-object v1

    .line 266
    invoke-virtual {p1}, Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;->cpuInputCount()I

    move-result v2

    int-to-long v2, v2

    invoke-virtual {v1, v2, v3}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionInvocationCount$Builder;->setCount(J)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionInvocationCount$Builder;

    move-result-object v1

    .line 267
    invoke-virtual {v1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v1

    check-cast v1, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionInvocationCount;

    .line 263
    invoke-virtual {v0, v1}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionInvocationReport$Builder;->addInvocationCount(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionInvocationCount;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionInvocationReport$Builder;

    .line 269
    :cond_0
    invoke-virtual {p1}, Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;->gpuInputCount()I

    move-result v1

    if-eqz v1, :cond_1

    .line 271
    invoke-static {}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionInvocationCount;->newBuilder()Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionInvocationCount$Builder;

    move-result-object v1

    sget-object v2, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$InputDataType;->INPUT_TYPE_TASKS_GPU:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$InputDataType;

    .line 272
    invoke-virtual {v1, v2}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionInvocationCount$Builder;->setInputDataType(Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$InputDataType;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionInvocationCount$Builder;

    move-result-object v1

    .line 273
    invoke-virtual {p1}, Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;->gpuInputCount()I

    move-result p1

    int-to-long v2, p1

    invoke-virtual {v1, v2, v3}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionInvocationCount$Builder;->setCount(J)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionInvocationCount$Builder;

    move-result-object p1

    .line 274
    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionInvocationCount;

    .line 270
    invoke-virtual {v0, p1}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionInvocationReport$Builder;->addInvocationCount(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionInvocationCount;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionInvocationReport$Builder;

    .line 276
    :cond_1
    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionInvocationReport;

    return-object p1
.end method


# virtual methods
.method public logInitError()V
    .locals 3

    .line 319
    invoke-static {}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent;->newBuilder()Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent$Builder;

    move-result-object v0

    iget-object v1, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->taskName:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionName;

    .line 320
    invoke-virtual {v0, v1}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent$Builder;->setSolutionName(Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionName;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent$Builder;

    move-result-object v0

    sget-object v1, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$EventName;->EVENT_ERROR:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$EventName;

    .line 321
    invoke-virtual {v0, v1}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent$Builder;->setEventName(Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$EventName;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent$Builder;

    move-result-object v0

    .line 322
    invoke-static {}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionError;->newBuilder()Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionError$Builder;

    move-result-object v1

    sget-object v2, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$ErrorCode;->ERROR_INIT:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$ErrorCode;

    invoke-virtual {v1, v2}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionError$Builder;->setErrorCode(Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$ErrorCode;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionError$Builder;

    move-result-object v1

    invoke-virtual {v1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v1

    check-cast v1, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionError;

    invoke-virtual {v0, v1}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent$Builder;->setErrorDetails(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionError;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent$Builder;

    move-result-object v0

    .line 323
    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent;

    .line 324
    invoke-direct {p0, v0}, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->logTaskEvent(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent;)V

    return-void
.end method

.method public logInvocationReport(Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;)V
    .locals 2

    .line 283
    invoke-static {}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent;->newBuilder()Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent$Builder;

    move-result-object v0

    iget-object v1, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->taskName:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionName;

    .line 284
    invoke-virtual {v0, v1}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent$Builder;->setSolutionName(Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionName;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent$Builder;

    move-result-object v0

    sget-object v1, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$EventName;->EVENT_INVOCATONS:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$EventName;

    .line 285
    invoke-virtual {v0, v1}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent$Builder;->setEventName(Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$EventName;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent$Builder;

    move-result-object v0

    .line 286
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->produceInvocationReport(Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionInvocationReport;

    move-result-object p1

    invoke-virtual {v0, p1}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent$Builder;->setInvocationReport(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionInvocationReport;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent$Builder;

    move-result-object p1

    .line 287
    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent;

    .line 288
    invoke-direct {p0, p1}, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->logTaskEvent(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent;)V

    return-void
.end method

.method public logSessionClone()V
    .locals 5

    .line 155
    invoke-static {}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent;->newBuilder()Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent$Builder;

    move-result-object v0

    iget-object v1, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->taskName:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionName;

    .line 156
    invoke-virtual {v0, v1}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent$Builder;->setSolutionName(Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionName;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent$Builder;

    move-result-object v0

    sget-object v1, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$EventName;->EVENT_START:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$EventName;

    .line 157
    invoke-virtual {v0, v1}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent$Builder;->setEventName(Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$EventName;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent$Builder;

    move-result-object v0

    .line 159
    invoke-static {}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;->newBuilder()Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone$Builder;

    move-result-object v1

    iget-object v2, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->taskRunningMode:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    .line 160
    invoke-virtual {v1, v2}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone$Builder;->setMode(Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone$Builder;

    move-result-object v1

    .line 161
    invoke-static {}, Ljava/time/Instant;->now()Ljava/time/Instant;

    move-result-object v2

    iget-wide v3, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->taskInitTimeMs:J

    invoke-virtual {v2, v3, v4}, Ljava/time/Instant;->minusMillis(J)Ljava/time/Instant;

    move-result-object v2

    invoke-virtual {v2}, Ljava/time/Instant;->toEpochMilli()J

    move-result-wide v2

    invoke-virtual {v1, v2, v3}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone$Builder;->setInitLatencyMs(J)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone$Builder;

    move-result-object v1

    .line 162
    invoke-virtual {v1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v1

    check-cast v1, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;

    .line 158
    invoke-virtual {v0, v1}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent$Builder;->setSessionClone(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionClone;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent$Builder;

    move-result-object v0

    .line 163
    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent;

    .line 164
    invoke-direct {p0, v0}, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->logTaskEvent(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent;)V

    .line 165
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v0

    iput-wide v0, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->reportStartTimeMs:J

    .line 166
    invoke-static {}, Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;->createDefault()Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->statsSnapshot:Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;

    return-void
.end method

.method public logSessionEnd()V
    .locals 15

    .line 295
    invoke-static {}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent;->newBuilder()Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent$Builder;

    move-result-object v0

    iget-object v1, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->taskName:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionName;

    .line 296
    invoke-virtual {v0, v1}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent$Builder;->setSolutionName(Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionName;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent$Builder;

    move-result-object v0

    sget-object v1, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$EventName;->EVENT_END:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$EventName;

    .line 297
    invoke-virtual {v0, v1}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent$Builder;->setEventName(Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$EventName;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent$Builder;

    move-result-object v0

    .line 299
    invoke-static {}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionEnd;->newBuilder()Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionEnd$Builder;

    move-result-object v1

    iget-object v2, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->cpuInputCount:Ljava/util/concurrent/atomic/AtomicInteger;

    .line 303
    invoke-virtual {v2}, Ljava/util/concurrent/atomic/AtomicInteger;->get()I

    move-result v3

    iget-object v2, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->gpuInputCount:Ljava/util/concurrent/atomic/AtomicInteger;

    .line 304
    invoke-virtual {v2}, Ljava/util/concurrent/atomic/AtomicInteger;->get()I

    move-result v4

    iget-object v2, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->finishedCount:Ljava/util/concurrent/atomic/AtomicInteger;

    .line 305
    invoke-virtual {v2}, Ljava/util/concurrent/atomic/AtomicInteger;->get()I

    move-result v5

    iget-object v2, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->droppedCount:Ljava/util/concurrent/atomic/AtomicInteger;

    .line 306
    invoke-virtual {v2}, Ljava/util/concurrent/atomic/AtomicInteger;->get()I

    move-result v2

    iget-object v6, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->startTimeMap:Ljava/util/concurrent/ConcurrentNavigableMap;

    invoke-interface {v6}, Ljava/util/Map;->size()I

    move-result v6

    add-int/2addr v6, v2

    iget-object v2, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->totalLatencyMs:Ljava/util/concurrent/atomic/AtomicLong;

    .line 307
    invoke-virtual {v2}, Ljava/util/concurrent/atomic/AtomicLong;->get()J

    move-result-wide v7

    iget-object v2, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->lifetimePeakLatencyMs:Ljava/util/concurrent/atomic/AtomicLong;

    .line 308
    invoke-virtual {v2}, Ljava/util/concurrent/atomic/AtomicLong;->get()J

    move-result-wide v9

    .line 309
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v11

    iget-wide v13, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->taskInitTimeMs:J

    sub-long/2addr v11, v13

    .line 302
    invoke-static/range {v3 .. v12}, Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;->create(IIIIJJJ)Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;

    move-result-object v2

    .line 301
    invoke-direct {p0, v2}, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->produceInvocationReport(Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionInvocationReport;

    move-result-object v2

    .line 300
    invoke-virtual {v1, v2}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionEnd$Builder;->setInvocationReport(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionInvocationReport;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionEnd$Builder;

    move-result-object v1

    .line 310
    invoke-virtual {v1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v1

    check-cast v1, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionEnd;

    .line 298
    invoke-virtual {v0, v1}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent$Builder;->setSessionEnd(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionEnd;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent$Builder;

    move-result-object v0

    .line 311
    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent;

    .line 312
    invoke-direct {p0, v0}, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->logTaskEvent(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent;)V

    return-void
.end method

.method public logSessionStart()V
    .locals 5

    .line 137
    invoke-static {}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent;->newBuilder()Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent$Builder;

    move-result-object v0

    iget-object v1, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->taskName:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionName;

    .line 138
    invoke-virtual {v0, v1}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent$Builder;->setSolutionName(Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionName;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent$Builder;

    move-result-object v0

    sget-object v1, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$EventName;->EVENT_START:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$EventName;

    .line 139
    invoke-virtual {v0, v1}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent$Builder;->setEventName(Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$EventName;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent$Builder;

    move-result-object v0

    .line 141
    invoke-static {}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionStart;->newBuilder()Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionStart$Builder;

    move-result-object v1

    iget-object v2, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->taskRunningMode:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    .line 142
    invoke-virtual {v1, v2}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionStart$Builder;->setMode(Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionStart$Builder;

    move-result-object v1

    .line 143
    invoke-static {}, Ljava/time/Instant;->now()Ljava/time/Instant;

    move-result-object v2

    iget-wide v3, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->taskInitTimeMs:J

    invoke-virtual {v2, v3, v4}, Ljava/time/Instant;->minusMillis(J)Ljava/time/Instant;

    move-result-object v2

    invoke-virtual {v2}, Ljava/time/Instant;->toEpochMilli()J

    move-result-wide v2

    invoke-virtual {v1, v2, v3}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionStart$Builder;->setInitLatencyMs(J)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionStart$Builder;

    move-result-object v1

    .line 144
    invoke-virtual {v1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v1

    check-cast v1, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionStart;

    .line 140
    invoke-virtual {v0, v1}, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent$Builder;->setSessionStart(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionSessionStart;)Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent$Builder;

    move-result-object v0

    .line 145
    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent;

    .line 146
    invoke-direct {p0, v0}, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->logTaskEvent(Lcom/google/mediapipe/proto/MediaPipeLoggingProto$SolutionEvent;)V

    .line 147
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v0

    iput-wide v0, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->reportStartTimeMs:J

    .line 148
    invoke-static {}, Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;->createDefault()Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->statsSnapshot:Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;

    return-void
.end method

.method public recordCpuInputArrival(J)V
    .locals 3

    .line 177
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->cpuInputCount:Ljava/util/concurrent/atomic/AtomicInteger;

    invoke-virtual {v0}, Ljava/util/concurrent/atomic/AtomicInteger;->incrementAndGet()I

    .line 178
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->startTimeMap:Ljava/util/concurrent/ConcurrentNavigableMap;

    invoke-static {p1, p2}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object p1

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v1

    invoke-static {v1, v2}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object p2

    invoke-interface {v0, p1, p2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    return-void
.end method

.method public recordGpuInputArrival(J)V
    .locals 3

    .line 189
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->gpuInputCount:Ljava/util/concurrent/atomic/AtomicInteger;

    invoke-virtual {v0}, Ljava/util/concurrent/atomic/AtomicInteger;->incrementAndGet()I

    .line 190
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->startTimeMap:Ljava/util/concurrent/ConcurrentNavigableMap;

    invoke-static {p1, p2}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object p1

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v1

    invoke-static {v1, v2}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object p2

    invoke-interface {v0, p1, p2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    return-void
.end method

.method public recordInvocationEnd(J)V
    .locals 11

    .line 201
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->startTimeMap:Ljava/util/concurrent/ConcurrentNavigableMap;

    invoke-static {p1, p2}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v1

    invoke-interface {v0, v1}, Ljava/util/Map;->containsKey(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_0

    goto/16 :goto_1

    .line 204
    :cond_0
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v0

    iget-object v2, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->startTimeMap:Ljava/util/concurrent/ConcurrentNavigableMap;

    invoke-static {p1, p2}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v3

    invoke-interface {v2, v3}, Ljava/util/Map;->remove(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Ljava/lang/Long;

    invoke-virtual {v2}, Ljava/lang/Long;->longValue()J

    move-result-wide v2

    sub-long/2addr v0, v2

    .line 205
    iget-object v2, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->finishedCount:Ljava/util/concurrent/atomic/AtomicInteger;

    invoke-virtual {v2}, Ljava/util/concurrent/atomic/AtomicInteger;->incrementAndGet()I

    .line 209
    sget-object v2, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->LATENCY_TIMEOUT_THRESHOLD_MS:Ljava/lang/Long;

    invoke-virtual {v2}, Ljava/lang/Long;->longValue()J

    move-result-wide v2

    cmp-long v2, v0, v2

    if-lez v2, :cond_1

    goto/16 :goto_1

    .line 212
    :cond_1
    iget-object v2, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->totalLatencyMs:Ljava/util/concurrent/atomic/AtomicLong;

    invoke-virtual {v2, v0, v1}, Ljava/util/concurrent/atomic/AtomicLong;->addAndGet(J)J

    .line 213
    iget-object v2, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->latestPeakLatencyMs:Ljava/util/concurrent/atomic/AtomicLong;

    invoke-virtual {v2}, Ljava/util/concurrent/atomic/AtomicLong;->get()J

    move-result-wide v3

    invoke-static {v3, v4, v0, v1}, Ljava/lang/Math;->max(JJ)J

    move-result-wide v3

    invoke-virtual {v2, v3, v4}, Ljava/util/concurrent/atomic/AtomicLong;->set(J)V

    .line 214
    iget-object v2, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->lifetimePeakLatencyMs:Ljava/util/concurrent/atomic/AtomicLong;

    invoke-virtual {v2}, Ljava/util/concurrent/atomic/AtomicLong;->get()J

    move-result-wide v3

    invoke-static {v3, v4, v0, v1}, Ljava/lang/Math;->max(JJ)J

    move-result-wide v0

    invoke-virtual {v2, v0, v1}, Ljava/util/concurrent/atomic/AtomicLong;->set(J)V

    .line 216
    invoke-static {}, Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;->createDefault()Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;

    move-result-object v0

    .line 217
    monitor-enter p0

    .line 218
    :try_start_0
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v1

    iget-wide v3, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->reportStartTimeMs:J

    sget-object v5, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->REPORT_INTERVAL_MS:Ljava/lang/Long;

    invoke-virtual {v5}, Ljava/lang/Long;->longValue()J

    move-result-wide v5

    add-long/2addr v3, v5

    cmp-long v1, v1, v3

    if-lez v1, :cond_2

    .line 224
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->droppedCount:Ljava/util/concurrent/atomic/AtomicInteger;

    iget-object v1, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->startTimeMap:Ljava/util/concurrent/ConcurrentNavigableMap;

    invoke-static {p1, p2}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v2

    invoke-interface {v1, v2}, Ljava/util/concurrent/ConcurrentNavigableMap;->headMap(Ljava/lang/Object;)Ljava/util/concurrent/ConcurrentNavigableMap;

    move-result-object v1

    invoke-interface {v1}, Ljava/util/Map;->size()I

    move-result v1

    invoke-virtual {v0, v1}, Ljava/util/concurrent/atomic/AtomicInteger;->addAndGet(I)I

    .line 225
    iget-object v0, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->startTimeMap:Ljava/util/concurrent/ConcurrentNavigableMap;

    invoke-static {p1, p2}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object p1

    invoke-interface {v0, p1}, Ljava/util/concurrent/ConcurrentNavigableMap;->headMap(Ljava/lang/Object;)Ljava/util/concurrent/ConcurrentNavigableMap;

    move-result-object p1

    invoke-interface {p1}, Ljava/util/Map;->clear()V

    .line 226
    iget-object p1, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->cpuInputCount:Ljava/util/concurrent/atomic/AtomicInteger;

    .line 228
    invoke-virtual {p1}, Ljava/util/concurrent/atomic/AtomicInteger;->get()I

    move-result v0

    iget-object p1, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->gpuInputCount:Ljava/util/concurrent/atomic/AtomicInteger;

    .line 229
    invoke-virtual {p1}, Ljava/util/concurrent/atomic/AtomicInteger;->get()I

    move-result v1

    iget-object p1, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->finishedCount:Ljava/util/concurrent/atomic/AtomicInteger;

    .line 230
    invoke-virtual {p1}, Ljava/util/concurrent/atomic/AtomicInteger;->get()I

    move-result v2

    iget-object p1, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->droppedCount:Ljava/util/concurrent/atomic/AtomicInteger;

    .line 231
    invoke-virtual {p1}, Ljava/util/concurrent/atomic/AtomicInteger;->get()I

    move-result v3

    iget-object p1, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->totalLatencyMs:Ljava/util/concurrent/atomic/AtomicLong;

    .line 232
    invoke-virtual {p1}, Ljava/util/concurrent/atomic/AtomicLong;->get()J

    move-result-wide v4

    iget-object p1, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->latestPeakLatencyMs:Ljava/util/concurrent/atomic/AtomicLong;

    const-wide/16 v6, 0x0

    .line 233
    invoke-virtual {p1, v6, v7}, Ljava/util/concurrent/atomic/AtomicLong;->getAndSet(J)J

    move-result-wide v6

    .line 234
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide p1

    iget-wide v8, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->reportStartTimeMs:J

    sub-long v8, p1, v8

    .line 227
    invoke-static/range {v0 .. v9}, Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;->create(IIIIJJJ)Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;

    move-result-object v0

    .line 235
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide p1

    iput-wide p1, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->reportStartTimeMs:J

    const/4 p1, 0x1

    goto :goto_0

    :catchall_0
    move-exception v0

    move-object p1, v0

    goto :goto_2

    :cond_2
    const/4 p1, 0x0

    .line 237
    :goto_0
    monitor-exit p0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    if-eqz p1, :cond_3

    .line 242
    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;->cpuInputCount()I

    move-result p1

    iget-object p2, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->statsSnapshot:Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;

    invoke-virtual {p2}, Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;->cpuInputCount()I

    move-result p2

    sub-int v1, p1, p2

    .line 243
    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;->gpuInputCount()I

    move-result p1

    iget-object p2, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->statsSnapshot:Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;

    invoke-virtual {p2}, Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;->gpuInputCount()I

    move-result p2

    sub-int v2, p1, p2

    .line 244
    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;->finishedCount()I

    move-result p1

    iget-object p2, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->statsSnapshot:Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;

    invoke-virtual {p2}, Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;->finishedCount()I

    move-result p2

    sub-int v3, p1, p2

    .line 245
    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;->droppedCount()I

    move-result p1

    iget-object p2, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->statsSnapshot:Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;

    invoke-virtual {p2}, Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;->droppedCount()I

    move-result p2

    sub-int v4, p1, p2

    .line 246
    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;->totalLatencyMs()J

    move-result-wide p1

    iget-object v5, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->statsSnapshot:Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;

    invoke-virtual {v5}, Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;->totalLatencyMs()J

    move-result-wide v5

    sub-long v5, p1, v5

    .line 247
    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;->peakLatencyMs()J

    move-result-wide v7

    .line 248
    invoke-virtual {v0}, Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;->elapsedTimeMs()J

    move-result-wide v9

    .line 241
    invoke-static/range {v1 .. v10}, Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;->create(IIIIJJJ)Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;

    move-result-object p1

    .line 249
    invoke-virtual {p0, p1}, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->logInvocationReport(Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;)V

    .line 250
    iput-object v0, p0, Lcom/google/mediapipe/tasks/core/logging/TasksStatsProtoLogger;->statsSnapshot:Lcom/google/mediapipe/tasks/core/logging/TasksStatsLogger$StatsSnapshot;

    :cond_3
    :goto_1
    return-void

    .line 237
    :goto_2
    :try_start_1
    monitor-exit p0
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    throw p1
.end method
