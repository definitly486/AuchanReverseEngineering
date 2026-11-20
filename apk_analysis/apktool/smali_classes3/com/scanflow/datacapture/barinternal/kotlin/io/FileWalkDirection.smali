.class public final enum Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;
.super Ljava/lang/Enum;
.source "FileTreeWalk.kt"


# static fields
.field private static final synthetic $ENTRIES:Lkotlin/enums/EnumEntries;

.field private static final synthetic $VALUES:[Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;

.field public static final enum BOTTOM_UP:Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;

.field public static final enum TOP_DOWN:Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;


# direct methods
.method private static final synthetic $values()[Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;
    .locals 2

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;->TOP_DOWN:Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;->BOTTOM_UP:Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;

    filled-new-array {v0, v1}, [Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;

    move-result-object v0

    return-object v0
.end method

.method static constructor <clinit>()V
    .locals 3

    .line 22
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;

    const-string v1, "TOP_DOWN"

    const/4 v2, 0x0

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;->TOP_DOWN:Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;

    .line 24
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;

    const-string v1, "BOTTOM_UP"

    const/4 v2, 0x1

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;->BOTTOM_UP:Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;->$values()[Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;->$VALUES:[Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/enums/EnumEntriesKt;->enumEntries([Ljava/lang/Enum;)Lkotlin/enums/EnumEntries;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;->$ENTRIES:Lkotlin/enums/EnumEntries;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;I)V
    .locals 0

    .line 20
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    return-void
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;
    .locals 1

    .line 0
    const-class v0, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;

    return-object p0
.end method

.method public static values()[Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;
    .locals 1

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;->$VALUES:[Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;

    invoke-virtual {v0}, Ljava/lang/Object;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;

    return-object v0
.end method
