.class public final enum Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;
.super Ljava/lang/Enum;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Enum<",
        "Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;",
        ">;"
    }
.end annotation


# static fields
.field private static final synthetic $ENTRIES:Lkotlin/enums/EnumEntries;

.field private static final synthetic $VALUES:[Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;

.field public static final enum COMPONENT_AIRTANK:Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;

.field public static final enum COMPONENT_LEAFSUSPENSION:Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;

.field public static final enum COMPONENT_VINNUMBER:Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;

.field public static final enum COMPONENT_VINPLATE:Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;

.field public static final enum COMPONENT_VINSTICKER:Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;

.field public static final enum UNIVERSAL:Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;


# direct methods
.method private static final synthetic $values()[Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;
    .locals 6

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;->COMPONENT_LEAFSUSPENSION:Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;

    sget-object v1, Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;->COMPONENT_AIRTANK:Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;

    sget-object v2, Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;->COMPONENT_VINNUMBER:Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;

    sget-object v3, Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;->COMPONENT_VINPLATE:Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;

    sget-object v4, Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;->COMPONENT_VINSTICKER:Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;

    sget-object v5, Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;->UNIVERSAL:Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;

    filled-new-array/range {v0 .. v5}, [Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;

    move-result-object v0

    return-object v0
.end method

.method static constructor <clinit>()V
    .locals 3

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;

    const-string v1, "COMPONENT_LEAFSUSPENSION"

    const/4 v2, 0x0

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;->COMPONENT_LEAFSUSPENSION:Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;

    new-instance v0, Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;

    const-string v1, "COMPONENT_AIRTANK"

    const/4 v2, 0x1

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;->COMPONENT_AIRTANK:Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;

    new-instance v0, Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;

    const-string v1, "COMPONENT_VINNUMBER"

    const/4 v2, 0x2

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;->COMPONENT_VINNUMBER:Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;

    new-instance v0, Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;

    const-string v1, "COMPONENT_VINPLATE"

    const/4 v2, 0x3

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;->COMPONENT_VINPLATE:Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;

    new-instance v0, Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;

    const-string v1, "COMPONENT_VINSTICKER"

    const/4 v2, 0x4

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;->COMPONENT_VINSTICKER:Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;

    new-instance v0, Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;

    const-string v1, "UNIVERSAL"

    const/4 v2, 0x5

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;->UNIVERSAL:Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;

    invoke-static {}, Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;->$values()[Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;->$VALUES:[Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/enums/EnumEntriesKt;->enumEntries([Ljava/lang/Enum;)Lkotlin/enums/EnumEntries;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;->$ENTRIES:Lkotlin/enums/EnumEntries;

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
            "Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;",
            ">;"
        }
    .end annotation

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;->$ENTRIES:Lkotlin/enums/EnumEntries;

    return-object v0
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;
    .locals 1

    .line 0
    const-class v0, Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;

    return-object p0
.end method

.method public static values()[Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;
    .locals 1

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;->$VALUES:[Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;

    invoke-virtual {v0}, Ljava/lang/Object;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/scanflow/datacapture/config/DaimlerTextCaptureConfig;

    return-object v0
.end method
