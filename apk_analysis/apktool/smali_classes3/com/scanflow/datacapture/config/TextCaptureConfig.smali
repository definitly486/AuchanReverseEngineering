.class public final enum Lcom/scanflow/datacapture/config/TextCaptureConfig;
.super Ljava/lang/Enum;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Enum<",
        "Lcom/scanflow/datacapture/config/TextCaptureConfig;",
        ">;"
    }
.end annotation


# static fields
.field private static final synthetic $ENTRIES:Lkotlin/enums/EnumEntries;

.field private static final synthetic $VALUES:[Lcom/scanflow/datacapture/config/TextCaptureConfig;

.field public static final enum CONTAINER_HORIZONTAL:Lcom/scanflow/datacapture/config/TextCaptureConfig;

.field public static final enum CONTAINER_VERTICAL:Lcom/scanflow/datacapture/config/TextCaptureConfig;

.field public static final enum GENERIC_TEXT:Lcom/scanflow/datacapture/config/TextCaptureConfig;

.field public static final enum HANDWRITTEN_DIGIT:Lcom/scanflow/datacapture/config/TextCaptureConfig;

.field public static final enum TYRE_DOT:Lcom/scanflow/datacapture/config/TextCaptureConfig;

.field public static final enum TYRE_NUMBER:Lcom/scanflow/datacapture/config/TextCaptureConfig;


# direct methods
.method private static final synthetic $values()[Lcom/scanflow/datacapture/config/TextCaptureConfig;
    .locals 6

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/config/TextCaptureConfig;->TYRE_NUMBER:Lcom/scanflow/datacapture/config/TextCaptureConfig;

    sget-object v1, Lcom/scanflow/datacapture/config/TextCaptureConfig;->TYRE_DOT:Lcom/scanflow/datacapture/config/TextCaptureConfig;

    sget-object v2, Lcom/scanflow/datacapture/config/TextCaptureConfig;->CONTAINER_VERTICAL:Lcom/scanflow/datacapture/config/TextCaptureConfig;

    sget-object v3, Lcom/scanflow/datacapture/config/TextCaptureConfig;->CONTAINER_HORIZONTAL:Lcom/scanflow/datacapture/config/TextCaptureConfig;

    sget-object v4, Lcom/scanflow/datacapture/config/TextCaptureConfig;->HANDWRITTEN_DIGIT:Lcom/scanflow/datacapture/config/TextCaptureConfig;

    sget-object v5, Lcom/scanflow/datacapture/config/TextCaptureConfig;->GENERIC_TEXT:Lcom/scanflow/datacapture/config/TextCaptureConfig;

    filled-new-array/range {v0 .. v5}, [Lcom/scanflow/datacapture/config/TextCaptureConfig;

    move-result-object v0

    return-object v0
.end method

.method static constructor <clinit>()V
    .locals 3

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/config/TextCaptureConfig;

    const-string v1, "TYRE_NUMBER"

    const/4 v2, 0x0

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/config/TextCaptureConfig;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/config/TextCaptureConfig;->TYRE_NUMBER:Lcom/scanflow/datacapture/config/TextCaptureConfig;

    new-instance v0, Lcom/scanflow/datacapture/config/TextCaptureConfig;

    const-string v1, "TYRE_DOT"

    const/4 v2, 0x1

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/config/TextCaptureConfig;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/config/TextCaptureConfig;->TYRE_DOT:Lcom/scanflow/datacapture/config/TextCaptureConfig;

    new-instance v0, Lcom/scanflow/datacapture/config/TextCaptureConfig;

    const-string v1, "CONTAINER_VERTICAL"

    const/4 v2, 0x2

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/config/TextCaptureConfig;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/config/TextCaptureConfig;->CONTAINER_VERTICAL:Lcom/scanflow/datacapture/config/TextCaptureConfig;

    new-instance v0, Lcom/scanflow/datacapture/config/TextCaptureConfig;

    const-string v1, "CONTAINER_HORIZONTAL"

    const/4 v2, 0x3

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/config/TextCaptureConfig;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/config/TextCaptureConfig;->CONTAINER_HORIZONTAL:Lcom/scanflow/datacapture/config/TextCaptureConfig;

    new-instance v0, Lcom/scanflow/datacapture/config/TextCaptureConfig;

    const-string v1, "HANDWRITTEN_DIGIT"

    const/4 v2, 0x4

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/config/TextCaptureConfig;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/config/TextCaptureConfig;->HANDWRITTEN_DIGIT:Lcom/scanflow/datacapture/config/TextCaptureConfig;

    new-instance v0, Lcom/scanflow/datacapture/config/TextCaptureConfig;

    const-string v1, "GENERIC_TEXT"

    const/4 v2, 0x5

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/config/TextCaptureConfig;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/config/TextCaptureConfig;->GENERIC_TEXT:Lcom/scanflow/datacapture/config/TextCaptureConfig;

    invoke-static {}, Lcom/scanflow/datacapture/config/TextCaptureConfig;->$values()[Lcom/scanflow/datacapture/config/TextCaptureConfig;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/config/TextCaptureConfig;->$VALUES:[Lcom/scanflow/datacapture/config/TextCaptureConfig;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/enums/EnumEntriesKt;->enumEntries([Ljava/lang/Enum;)Lkotlin/enums/EnumEntries;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/config/TextCaptureConfig;->$ENTRIES:Lkotlin/enums/EnumEntries;

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
            "Lcom/scanflow/datacapture/config/TextCaptureConfig;",
            ">;"
        }
    .end annotation

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/config/TextCaptureConfig;->$ENTRIES:Lkotlin/enums/EnumEntries;

    return-object v0
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/scanflow/datacapture/config/TextCaptureConfig;
    .locals 1

    .line 0
    const-class v0, Lcom/scanflow/datacapture/config/TextCaptureConfig;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/config/TextCaptureConfig;

    return-object p0
.end method

.method public static values()[Lcom/scanflow/datacapture/config/TextCaptureConfig;
    .locals 1

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/config/TextCaptureConfig;->$VALUES:[Lcom/scanflow/datacapture/config/TextCaptureConfig;

    invoke-virtual {v0}, Ljava/lang/Object;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/scanflow/datacapture/config/TextCaptureConfig;

    return-object v0
.end method
