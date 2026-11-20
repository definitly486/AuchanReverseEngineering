.class public final Lcom/scanflow/datacapture/utils/LogUtils;
.super Ljava/lang/Object;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/utils/LogUtils$Companion;
    }
.end annotation


# static fields
.field public static final ASSERT:I = 0x7

.field public static final Companion:Lcom/scanflow/datacapture/utils/LogUtils$Companion;

.field public static final DEBUG:I = 0x3

.field public static final ERROR:I = 0x6

.field public static final INFO:I = 0x4

.field public static final PRINTLN:I = 0x1

.field public static final TAG:Ljava/lang/String; = "LogUtils"

.field public static final TAG_FORMAT:Ljava/lang/String; = "%s.%s(%s:%d)"

.field public static final VERBOSE:I = 0x2

.field public static final VERTICAL:Ljava/lang/String; = "|"

.field public static final WARN:I = 0x5

.field private static isShowLog:Z

.field private static priority:I


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/utils/LogUtils$Companion;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/utils/LogUtils$Companion;-><init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V

    sput-object v0, Lcom/scanflow/datacapture/utils/LogUtils;->Companion:Lcom/scanflow/datacapture/utils/LogUtils$Companion;

    const/4 v0, 0x1

    sput-boolean v0, Lcom/scanflow/datacapture/utils/LogUtils;->isShowLog:Z

    sput v0, Lcom/scanflow/datacapture/utils/LogUtils;->priority:I

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    new-instance v0, Ljava/lang/AssertionError;

    invoke-direct {v0}, Ljava/lang/AssertionError;-><init>()V

    throw v0
.end method

.method public static final synthetic access$getPriority$cp()I
    .locals 1

    .line 0
    sget v0, Lcom/scanflow/datacapture/utils/LogUtils;->priority:I

    return v0
.end method

.method public static final synthetic access$isShowLog$cp()Z
    .locals 1

    .line 0
    sget-boolean v0, Lcom/scanflow/datacapture/utils/LogUtils;->isShowLog:Z

    return v0
.end method

.method public static final synthetic access$setPriority$cp(I)V
    .locals 0

    .line 0
    sput p0, Lcom/scanflow/datacapture/utils/LogUtils;->priority:I

    return-void
.end method

.method public static final synthetic access$setShowLog$cp(Z)V
    .locals 0

    .line 0
    sput-boolean p0, Lcom/scanflow/datacapture/utils/LogUtils;->isShowLog:Z

    return-void
.end method
