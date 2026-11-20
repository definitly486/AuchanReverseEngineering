.class public final enum Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;
.super Ljava/lang/Enum;
.source "ConnectRule.java"


# static fields
.field private static final synthetic $VALUES:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;

.field public static final enum EIGHT:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;

.field public static final enum FOUR:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;


# instance fields
.field private final shortName:Ljava/lang/String;


# direct methods
.method private static synthetic $values()[Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;
    .locals 2

    .line 28
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;->FOUR:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;->EIGHT:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;

    filled-new-array {v0, v1}, [Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;

    move-result-object v0

    return-object v0
.end method

.method static constructor <clinit>()V
    .locals 4

    .line 32
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;

    const/4 v1, 0x0

    const-string v2, "4"

    const-string v3, "FOUR"

    invoke-direct {v0, v3, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;-><init>(Ljava/lang/String;ILjava/lang/String;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;->FOUR:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;

    .line 36
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;

    const/4 v1, 0x1

    const-string v2, "8"

    const-string v3, "EIGHT"

    invoke-direct {v0, v3, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;-><init>(Ljava/lang/String;ILjava/lang/String;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;->EIGHT:Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;

    .line 28
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;->$values()[Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;->$VALUES:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;ILjava/lang/String;)V
    .locals 0

    .line 40
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    .line 41
    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;->shortName:Ljava/lang/String;

    return-void
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;
    .locals 1

    .line 28
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;

    return-object p0
.end method

.method public static values()[Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;
    .locals 1

    .line 28
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;->$VALUES:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;

    invoke-virtual {v0}, [Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;

    return-object v0
.end method
