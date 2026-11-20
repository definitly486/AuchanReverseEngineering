.class public final enum Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;
.super Ljava/lang/Enum;
.source "BorderType.java"


# static fields
.field private static final synthetic $VALUES:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;

.field public static final enum EXTENDED:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;

.field public static final enum NORMALIZED:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;

.field public static final enum REFLECT:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;

.field public static final enum SKIP:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;

.field public static final enum WRAP:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;

.field public static final enum ZERO:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;


# direct methods
.method private static synthetic $values()[Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;
    .locals 6

    .line 27
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;->SKIP:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;->EXTENDED:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;

    sget-object v2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;->NORMALIZED:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;

    sget-object v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;->REFLECT:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;

    sget-object v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;->WRAP:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;

    sget-object v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;->ZERO:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;

    filled-new-array/range {v0 .. v5}, [Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;

    move-result-object v0

    return-object v0
.end method

.method static constructor <clinit>()V
    .locals 3

    .line 31
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;

    const-string v1, "SKIP"

    const/4 v2, 0x0

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;->SKIP:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;

    .line 37
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;

    const-string v1, "EXTENDED"

    const/4 v2, 0x1

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;->EXTENDED:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;

    .line 43
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;

    const-string v1, "NORMALIZED"

    const/4 v2, 0x2

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;->NORMALIZED:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;

    .line 49
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;

    const-string v1, "REFLECT"

    const/4 v2, 0x3

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;->REFLECT:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;

    .line 56
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;

    const-string v1, "WRAP"

    const/4 v2, 0x4

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;->WRAP:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;

    .line 62
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;

    const-string v1, "ZERO"

    const/4 v2, 0x5

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;->ZERO:Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;

    .line 27
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;->$values()[Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;->$VALUES:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;I)V
    .locals 0

    .line 27
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    return-void
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;
    .locals 1

    .line 27
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;

    return-object p0
.end method

.method public static values()[Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;
    .locals 1

    .line 27
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;->$VALUES:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;

    invoke-virtual {v0}, [Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;

    return-object v0
.end method
