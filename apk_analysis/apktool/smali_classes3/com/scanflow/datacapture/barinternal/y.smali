.class public final enum Lcom/scanflow/datacapture/barinternal/y;
.super Ljava/lang/Enum;
.source "SourceFile"


# static fields
.field public static final enum a:Lcom/scanflow/datacapture/barinternal/y;

.field public static final synthetic b:[Lcom/scanflow/datacapture/barinternal/y;


# direct methods
.method static constructor <clinit>()V
    .locals 8

    new-instance v0, Lcom/scanflow/datacapture/barinternal/y;

    const-string v1, "INITIAL"

    const/4 v2, 0x0

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/y;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/y;->a:Lcom/scanflow/datacapture/barinternal/y;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/y;

    const-string v2, "SUCCESS"

    const/4 v3, 0x1

    invoke-direct {v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/y;-><init>(Ljava/lang/String;I)V

    new-instance v2, Lcom/scanflow/datacapture/barinternal/y;

    const-string v3, "LONG_DISTANCE"

    const/4 v4, 0x2

    invoke-direct {v2, v3, v4}, Lcom/scanflow/datacapture/barinternal/y;-><init>(Ljava/lang/String;I)V

    new-instance v3, Lcom/scanflow/datacapture/barinternal/y;

    const-string v4, "TILT"

    const/4 v5, 0x3

    invoke-direct {v3, v4, v5}, Lcom/scanflow/datacapture/barinternal/y;-><init>(Ljava/lang/String;I)V

    new-instance v4, Lcom/scanflow/datacapture/barinternal/y;

    const-string v5, "DAMAGED"

    const/4 v6, 0x4

    invoke-direct {v4, v5, v6}, Lcom/scanflow/datacapture/barinternal/y;-><init>(Ljava/lang/String;I)V

    new-instance v5, Lcom/scanflow/datacapture/barinternal/y;

    const-string v6, "FAILED"

    const/4 v7, 0x5

    invoke-direct {v5, v6, v7}, Lcom/scanflow/datacapture/barinternal/y;-><init>(Ljava/lang/String;I)V

    .line 1
    filled-new-array/range {v0 .. v5}, [Lcom/scanflow/datacapture/barinternal/y;

    move-result-object v0

    .line 2
    sput-object v0, Lcom/scanflow/datacapture/barinternal/y;->b:[Lcom/scanflow/datacapture/barinternal/y;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/enums/EnumEntriesKt;->enumEntries([Ljava/lang/Enum;)Lkotlin/enums/EnumEntries;

    return-void
.end method

.method public constructor <init>(Ljava/lang/String;I)V
    .locals 0

    .line 1
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    return-void
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/y;
    .locals 1

    .line 1
    const-class v0, Lcom/scanflow/datacapture/barinternal/y;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/y;

    return-object p0
.end method

.method public static values()[Lcom/scanflow/datacapture/barinternal/y;
    .locals 1

    .line 1
    sget-object v0, Lcom/scanflow/datacapture/barinternal/y;->b:[Lcom/scanflow/datacapture/barinternal/y;

    invoke-virtual {v0}, Ljava/lang/Object;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/scanflow/datacapture/barinternal/y;

    return-object v0
.end method
