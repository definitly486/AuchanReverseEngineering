.class public final enum Lcom/scanflow/datacapture/config/SwitchCategory;
.super Ljava/lang/Enum;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Enum<",
        "Lcom/scanflow/datacapture/config/SwitchCategory;",
        ">;"
    }
.end annotation


# static fields
.field private static final synthetic $ENTRIES:Lkotlin/enums/EnumEntries;

.field private static final synthetic $VALUES:[Lcom/scanflow/datacapture/config/SwitchCategory;

.field public static final enum DASHBOARD:Lcom/scanflow/datacapture/config/SwitchCategory;

.field public static final enum DUP:Lcom/scanflow/datacapture/config/SwitchCategory;

.field public static final enum GRID:Lcom/scanflow/datacapture/config/SwitchCategory;

.field public static final enum TOP:Lcom/scanflow/datacapture/config/SwitchCategory;

.field public static final enum TWO:Lcom/scanflow/datacapture/config/SwitchCategory;


# direct methods
.method private static final synthetic $values()[Lcom/scanflow/datacapture/config/SwitchCategory;
    .locals 5

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/config/SwitchCategory;->DASHBOARD:Lcom/scanflow/datacapture/config/SwitchCategory;

    sget-object v1, Lcom/scanflow/datacapture/config/SwitchCategory;->DUP:Lcom/scanflow/datacapture/config/SwitchCategory;

    sget-object v2, Lcom/scanflow/datacapture/config/SwitchCategory;->GRID:Lcom/scanflow/datacapture/config/SwitchCategory;

    sget-object v3, Lcom/scanflow/datacapture/config/SwitchCategory;->TWO:Lcom/scanflow/datacapture/config/SwitchCategory;

    sget-object v4, Lcom/scanflow/datacapture/config/SwitchCategory;->TOP:Lcom/scanflow/datacapture/config/SwitchCategory;

    filled-new-array {v0, v1, v2, v3, v4}, [Lcom/scanflow/datacapture/config/SwitchCategory;

    move-result-object v0

    return-object v0
.end method

.method static constructor <clinit>()V
    .locals 3

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/config/SwitchCategory;

    const-string v1, "DASHBOARD"

    const/4 v2, 0x0

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/config/SwitchCategory;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/config/SwitchCategory;->DASHBOARD:Lcom/scanflow/datacapture/config/SwitchCategory;

    new-instance v0, Lcom/scanflow/datacapture/config/SwitchCategory;

    const-string v1, "DUP"

    const/4 v2, 0x1

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/config/SwitchCategory;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/config/SwitchCategory;->DUP:Lcom/scanflow/datacapture/config/SwitchCategory;

    new-instance v0, Lcom/scanflow/datacapture/config/SwitchCategory;

    const-string v1, "GRID"

    const/4 v2, 0x2

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/config/SwitchCategory;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/config/SwitchCategory;->GRID:Lcom/scanflow/datacapture/config/SwitchCategory;

    new-instance v0, Lcom/scanflow/datacapture/config/SwitchCategory;

    const-string v1, "TWO"

    const/4 v2, 0x3

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/config/SwitchCategory;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/config/SwitchCategory;->TWO:Lcom/scanflow/datacapture/config/SwitchCategory;

    new-instance v0, Lcom/scanflow/datacapture/config/SwitchCategory;

    const-string v1, "TOP"

    const/4 v2, 0x4

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/config/SwitchCategory;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/config/SwitchCategory;->TOP:Lcom/scanflow/datacapture/config/SwitchCategory;

    invoke-static {}, Lcom/scanflow/datacapture/config/SwitchCategory;->$values()[Lcom/scanflow/datacapture/config/SwitchCategory;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/config/SwitchCategory;->$VALUES:[Lcom/scanflow/datacapture/config/SwitchCategory;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/enums/EnumEntriesKt;->enumEntries([Ljava/lang/Enum;)Lkotlin/enums/EnumEntries;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/config/SwitchCategory;->$ENTRIES:Lkotlin/enums/EnumEntries;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;I)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()V"
        }
    .end annotation

    .line 0
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    return-void
.end method

.method public static getEntries()Lkotlin/enums/EnumEntries;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lkotlin/enums/EnumEntries<",
            "Lcom/scanflow/datacapture/config/SwitchCategory;",
            ">;"
        }
    .end annotation

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/config/SwitchCategory;->$ENTRIES:Lkotlin/enums/EnumEntries;

    return-object v0
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/scanflow/datacapture/config/SwitchCategory;
    .locals 1

    .line 0
    const-class v0, Lcom/scanflow/datacapture/config/SwitchCategory;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/config/SwitchCategory;

    return-object p0
.end method

.method public static values()[Lcom/scanflow/datacapture/config/SwitchCategory;
    .locals 1

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/config/SwitchCategory;->$VALUES:[Lcom/scanflow/datacapture/config/SwitchCategory;

    invoke-virtual {v0}, Ljava/lang/Object;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/scanflow/datacapture/config/SwitchCategory;

    return-object v0
.end method
