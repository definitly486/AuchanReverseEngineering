.class public final enum Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;
.super Ljava/lang/Enum;
.source "Lazy.kt"


# static fields
.field private static final synthetic $ENTRIES:Lkotlin/enums/EnumEntries;

.field private static final synthetic $VALUES:[Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;

.field public static final enum NONE:Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;

.field public static final enum PUBLICATION:Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;

.field public static final enum SYNCHRONIZED:Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;


# direct methods
.method private static final synthetic $values()[Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;
    .locals 3

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;->SYNCHRONIZED:Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;->PUBLICATION:Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;

    sget-object v2, Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;->NONE:Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;

    filled-new-array {v0, v1, v2}, [Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;

    move-result-object v0

    return-object v0
.end method

.method static constructor <clinit>()V
    .locals 3

    .line 70
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;

    const-string v1, "SYNCHRONIZED"

    const/4 v2, 0x0

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;->SYNCHRONIZED:Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;

    .line 78
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;

    const-string v1, "PUBLICATION"

    const/4 v2, 0x1

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;->PUBLICATION:Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;

    .line 86
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;

    const-string v1, "NONE"

    const/4 v2, 0x2

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;->NONE:Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;->$values()[Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;->$VALUES:[Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/enums/EnumEntriesKt;->enumEntries([Ljava/lang/Enum;)Lkotlin/enums/EnumEntries;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;->$ENTRIES:Lkotlin/enums/EnumEntries;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;I)V
    .locals 0

    .line 61
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    return-void
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;
    .locals 1

    .line 0
    const-class v0, Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;

    return-object p0
.end method

.method public static values()[Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;
    .locals 1

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;->$VALUES:[Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;

    invoke-virtual {v0}, Ljava/lang/Object;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/scanflow/datacapture/barinternal/kotlin/LazyThreadSafetyMode;

    return-object v0
.end method
