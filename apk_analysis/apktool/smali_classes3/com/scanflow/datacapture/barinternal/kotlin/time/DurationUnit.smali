.class public final enum Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;
.super Ljava/lang/Enum;
.source "DurationUnitJvm.kt"


# static fields
.field private static final synthetic $ENTRIES:Lkotlin/enums/EnumEntries;

.field private static final synthetic $VALUES:[Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;

.field public static final enum DAYS:Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;

.field public static final enum HOURS:Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;

.field public static final enum MICROSECONDS:Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;

.field public static final enum MILLISECONDS:Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;

.field public static final enum MINUTES:Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;

.field public static final enum NANOSECONDS:Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;

.field public static final enum SECONDS:Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;


# instance fields
.field private final timeUnit:Ljava/util/concurrent/TimeUnit;


# direct methods
.method private static final synthetic $values()[Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;
    .locals 7

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;->NANOSECONDS:Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;->MICROSECONDS:Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;

    sget-object v2, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;->MILLISECONDS:Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;

    sget-object v3, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;->SECONDS:Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;

    sget-object v4, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;->MINUTES:Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;

    sget-object v5, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;->HOURS:Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;

    sget-object v6, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;->DAYS:Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;

    filled-new-array/range {v0 .. v6}, [Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;

    move-result-object v0

    return-object v0
.end method

.method static constructor <clinit>()V
    .locals 4

    .line 18
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;

    const/4 v1, 0x0

    sget-object v2, Ljava/util/concurrent/TimeUnit;->NANOSECONDS:Ljava/util/concurrent/TimeUnit;

    const-string v3, "NANOSECONDS"

    invoke-direct {v0, v3, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;-><init>(Ljava/lang/String;ILjava/util/concurrent/TimeUnit;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;->NANOSECONDS:Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;

    .line 22
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;

    const/4 v1, 0x1

    sget-object v2, Ljava/util/concurrent/TimeUnit;->MICROSECONDS:Ljava/util/concurrent/TimeUnit;

    const-string v3, "MICROSECONDS"

    invoke-direct {v0, v3, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;-><init>(Ljava/lang/String;ILjava/util/concurrent/TimeUnit;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;->MICROSECONDS:Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;

    .line 26
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;

    const/4 v1, 0x2

    sget-object v2, Ljava/util/concurrent/TimeUnit;->MILLISECONDS:Ljava/util/concurrent/TimeUnit;

    const-string v3, "MILLISECONDS"

    invoke-direct {v0, v3, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;-><init>(Ljava/lang/String;ILjava/util/concurrent/TimeUnit;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;->MILLISECONDS:Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;

    .line 30
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;

    const/4 v1, 0x3

    sget-object v2, Ljava/util/concurrent/TimeUnit;->SECONDS:Ljava/util/concurrent/TimeUnit;

    const-string v3, "SECONDS"

    invoke-direct {v0, v3, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;-><init>(Ljava/lang/String;ILjava/util/concurrent/TimeUnit;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;->SECONDS:Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;

    .line 34
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;

    const/4 v1, 0x4

    sget-object v2, Ljava/util/concurrent/TimeUnit;->MINUTES:Ljava/util/concurrent/TimeUnit;

    const-string v3, "MINUTES"

    invoke-direct {v0, v3, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;-><init>(Ljava/lang/String;ILjava/util/concurrent/TimeUnit;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;->MINUTES:Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;

    .line 38
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;

    const/4 v1, 0x5

    sget-object v2, Ljava/util/concurrent/TimeUnit;->HOURS:Ljava/util/concurrent/TimeUnit;

    const-string v3, "HOURS"

    invoke-direct {v0, v3, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;-><init>(Ljava/lang/String;ILjava/util/concurrent/TimeUnit;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;->HOURS:Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;

    .line 42
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;

    const/4 v1, 0x6

    sget-object v2, Ljava/util/concurrent/TimeUnit;->DAYS:Ljava/util/concurrent/TimeUnit;

    const-string v3, "DAYS"

    invoke-direct {v0, v3, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;-><init>(Ljava/lang/String;ILjava/util/concurrent/TimeUnit;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;->DAYS:Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;->$values()[Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;->$VALUES:[Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/enums/EnumEntriesKt;->enumEntries([Ljava/lang/Enum;)Lkotlin/enums/EnumEntries;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;->$ENTRIES:Lkotlin/enums/EnumEntries;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;ILjava/util/concurrent/TimeUnit;)V
    .locals 0

    .line 13
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    .line 14
    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;->timeUnit:Ljava/util/concurrent/TimeUnit;

    return-void
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;
    .locals 1

    .line 0
    const-class v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;

    return-object p0
.end method

.method public static values()[Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;
    .locals 1

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;->$VALUES:[Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;

    invoke-virtual {v0}, Ljava/lang/Object;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;

    return-object v0
.end method


# virtual methods
.method public final getTimeUnit$kotlin_stdlib()Ljava/util/concurrent/TimeUnit;
    .locals 1

    .line 14
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/DurationUnit;->timeUnit:Ljava/util/concurrent/TimeUnit;

    return-object v0
.end method
