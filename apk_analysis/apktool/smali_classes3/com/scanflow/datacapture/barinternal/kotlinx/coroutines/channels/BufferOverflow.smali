.class public final enum Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;
.super Ljava/lang/Enum;
.source "BufferOverflow.kt"


# static fields
.field private static final synthetic $ENTRIES:Lkotlin/enums/EnumEntries;

.field private static final synthetic $VALUES:[Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;

.field public static final enum DROP_LATEST:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;

.field public static final enum DROP_OLDEST:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;

.field public static final enum SUSPEND:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;


# direct methods
.method private static final synthetic $values()[Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;
    .locals 3

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;->SUSPEND:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;->DROP_OLDEST:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;

    sget-object v2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;->DROP_LATEST:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;

    filled-new-array {v0, v1, v2}, [Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;

    move-result-object v0

    return-object v0
.end method

.method static constructor <clinit>()V
    .locals 3

    .line 22
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;

    const-string v1, "SUSPEND"

    const/4 v2, 0x0

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;->SUSPEND:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;

    .line 30
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;

    const-string v1, "DROP_OLDEST"

    const/4 v2, 0x1

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;->DROP_OLDEST:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;

    .line 38
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;

    const-string v1, "DROP_LATEST"

    const/4 v2, 0x2

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;->DROP_LATEST:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;->$values()[Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;->$VALUES:[Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/enums/EnumEntriesKt;->enumEntries([Ljava/lang/Enum;)Lkotlin/enums/EnumEntries;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;->$ENTRIES:Lkotlin/enums/EnumEntries;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;I)V
    .locals 0

    .line 14
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    return-void
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;
    .locals 1

    const-class v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object p0

    .line 39
    check-cast p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;

    return-object p0
.end method

.method public static values()[Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;
    .locals 1

    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;->$VALUES:[Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;

    invoke-virtual {v0}, Ljava/lang/Object;->clone()Ljava/lang/Object;

    move-result-object v0

    .line 39
    check-cast v0, [Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;

    return-object v0
.end method
