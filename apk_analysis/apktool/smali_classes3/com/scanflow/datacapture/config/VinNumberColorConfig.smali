.class public final enum Lcom/scanflow/datacapture/config/VinNumberColorConfig;
.super Ljava/lang/Enum;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Enum<",
        "Lcom/scanflow/datacapture/config/VinNumberColorConfig;",
        ">;"
    }
.end annotation


# static fields
.field private static final synthetic $ENTRIES:Lkotlin/enums/EnumEntries;

.field private static final synthetic $VALUES:[Lcom/scanflow/datacapture/config/VinNumberColorConfig;

.field public static final enum BLACK:Lcom/scanflow/datacapture/config/VinNumberColorConfig;

.field public static final enum SILVER:Lcom/scanflow/datacapture/config/VinNumberColorConfig;


# direct methods
.method private static final synthetic $values()[Lcom/scanflow/datacapture/config/VinNumberColorConfig;
    .locals 2

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/config/VinNumberColorConfig;->BLACK:Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    sget-object v1, Lcom/scanflow/datacapture/config/VinNumberColorConfig;->SILVER:Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    filled-new-array {v0, v1}, [Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    move-result-object v0

    return-object v0
.end method

.method static constructor <clinit>()V
    .locals 3

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    const-string v1, "BLACK"

    const/4 v2, 0x0

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/config/VinNumberColorConfig;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/config/VinNumberColorConfig;->BLACK:Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    new-instance v0, Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    const-string v1, "SILVER"

    const/4 v2, 0x1

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/config/VinNumberColorConfig;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/config/VinNumberColorConfig;->SILVER:Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    invoke-static {}, Lcom/scanflow/datacapture/config/VinNumberColorConfig;->$values()[Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/config/VinNumberColorConfig;->$VALUES:[Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/enums/EnumEntriesKt;->enumEntries([Ljava/lang/Enum;)Lkotlin/enums/EnumEntries;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/config/VinNumberColorConfig;->$ENTRIES:Lkotlin/enums/EnumEntries;

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
            "Lcom/scanflow/datacapture/config/VinNumberColorConfig;",
            ">;"
        }
    .end annotation

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/config/VinNumberColorConfig;->$ENTRIES:Lkotlin/enums/EnumEntries;

    return-object v0
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/scanflow/datacapture/config/VinNumberColorConfig;
    .locals 1

    .line 0
    const-class v0, Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    return-object p0
.end method

.method public static values()[Lcom/scanflow/datacapture/config/VinNumberColorConfig;
    .locals 1

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/config/VinNumberColorConfig;->$VALUES:[Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    invoke-virtual {v0}, Ljava/lang/Object;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    return-object v0
.end method
